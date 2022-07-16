using UnityEngine;

namespace UnityAutoSettings
{
    [System.Serializable]
    [SerializeField]
    public class SettingsItem
    {
        public string name = "undefiend";
        public int order;
        public string type;
        public string value;
    }
}
