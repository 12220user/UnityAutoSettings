using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAutoSettings.FileSystem;

public class FileSystemTests : MonoBehaviour
{
    
    void Start()
    {
        AndroidUrlTest(Application.persistentDataPath + "/settings.json");
    }

    private void RandonDirTest(int count) {
        string dir = "";
        for (int i = 0; i < count; i++) {
            dir = $"C:/{Random.Range(100 ,1000)}/{Random.Range(100, 1000)}.txt";
            Debug.Log(string.Format("start <color=yellow>{0}</color>   -- result <color=green>{1}</color>" , dir , CrossplatformUrlFormat.GetDirectoryFromFilePath(dir)));
        }
    }

    private void AndroidUrlTest(string dir) {
        Debug.Log(string.Format("start <color=yellow>{0}</color>   -- result <color=green>{1}</color>", dir, CrossplatformUrlFormat.ToJarDir(dir)));
    }
}
