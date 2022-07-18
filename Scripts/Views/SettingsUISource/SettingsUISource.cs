using System.Collections.Generic;
using UnityEngine;

namespace UnityAutoSettings.UI.Source
{
    [CreateAssetMenu(fileName = "new UI Source", menuName = "Unity Auto Settings/UI/UI Source", order = 0)]
    public class SettingsUISource: ScriptableObject
    {
        public string Name;
        [SerializeField]
        public List<SettingsUIItem> items;
    } 
}
