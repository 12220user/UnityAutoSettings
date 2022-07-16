using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityAutoSettings.FileSystem;

namespace UnityAutoSettings.MenuItems
{
    public class UnityAutoSettingsConfigurator : MonoBehaviour
    {
        [MenuItem("Edit/UAS/Init (press ctrl+R from update Project frame)")]
        public static void InitPath()
        {

            var file = new UnityAutoSettings.Settings { 
                name = Application.productName,
                context = "Undefiend",
                version = Application.version,
                items = new SettingsItem[] { 
                    new SettingsItem{ 
                        order = 0,
                        type = "Header",
                        value = "Welcome to uas."
                    }
                }
            };
            var path = Application.streamingAssetsPath + "/Settings/defould_settings.json";
            ÑrossplatformFile.Write(path, file);
            Debug.Log($"<color=yellow>Initialization was successful. The default settings profile was created along the path {path}</color>");
        }
    }
}
