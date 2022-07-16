using UnityEngine;


namespace UnityAutoSettings
{
    [System.Serializable]
    [SerializeField]
    public class Settings
    {
        public string name;
        public string context;
        public string version;
        public SettingsItem[] items;
    }
}
