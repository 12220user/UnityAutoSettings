using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityAutoSettings.FileSystem;
using UnityAutoSettings.Exception;
using UnityAutoSettings.Rule.Types;

namespace UnityAutoSettings
{
    public partial class SettingsObject
    {
        public string name { get; private set; }
        public string context { get; private set; }
        public string version { get; private set; }
        private Dictionary<string, SettingsItem> items;
        private Settings self;
        private List<TypeRule> typeRules;

        public event Action<SettingsObject, int> OnItemValueChangedEvent;
        public static event Action<SettingsObject> InitSettingsEvent;
        private string path;

        public SettingsObject(Settings source , string path) {
            this.path = path;
            self = source;
            name = source.name;
            context = source.context;
            version = source.version;
            foreach (SettingsItem item in source.items) {
                items.Add(item.name, item);
            }
            typeRules = new List<TypeRule>();
            AddSettingsItemTypeBasic();

            InitSettingsEvent?.Invoke(this);
        }

        public SettingsItem GetItem(int order)
        {
            return items
                .Where(x => x.Value.order == order)
                .First()
                .Value;
        }

        public SettingsItem GetItem(string name) {
            return items
                .Where(x => x.Key == name)
                .First()
                .Value;
        }

        public (string, object) GetValue(int order) {
            SettingsItem item = GetItem(order);
            return (item.type , item.value);
        }

        public (string, object) GetValue(string name)
        {
            SettingsItem item = GetItem(name);
            return (item.type, item.value);
        }

        public void SetValue(int order, object value , bool saveFromFile = true) {
            string serlValue = value.ToString();
            string type = items
                .Where(x => x.Value.order == order)
                .First()
                .Value
                .type;

            if (!CheckÑomplianceType(type, serlValue)) {
                throw new SettingsTypeExeption(self.items.Where(x => x.order == order).First(), serlValue);
            }

            items
                .Where(x => x.Value.order == order)
                .First()
                .Value
                .value = serlValue;
            self.items
                .Where(x => x.order == order)
                .First()
                .value = items
                .Where(x => x.Value.order == order)
                .First()
                .Value
                .value;
            if (saveFromFile) Save(); 
            OnItemValueChangedEvent?.Invoke(this, order);
        }

        public void SetValue(string name, object value, bool saveFromFile = true) {
            int order = items
                .Where(x => x.Value.name == name)
                .First()
                .Value
                .order;
            SetValue(order, value, saveFromFile);
        }

        private SettingsItem[] ConvertDictionaryToArray() {
            return items
                .Select(x => x.Value)
                .ToArray();
        }

        public void Save() {
            CrossplatformFile.Write(path, self);
        }

        private bool CheckÑomplianceType(string type , string value) {
            var rules = typeRules.Where(x => x.type.Contains(type)).ToArray();
            if (rules.Length == 0) return false;
            else {
                foreach (var rule in rules) {
                    if (!rule.Check(value))
                        return false;
                }
                return true;
            }
        }
    }
}
