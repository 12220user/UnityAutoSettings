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
        /// <summary>
        /// Format {settings item name} == { needed value }
        /// </summary>
        public string condition ="";
        public bool interactable = false;
        public bool visualised = true;
    }
}
