using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityAutoSettings.FileSystem{
    public static class СrossplatformFile
    {
        public static void Write(string url, string data) {
            switch (Application.platform) {
                case RuntimePlatform.WindowsEditor:
                    WriteFileWindows(url, data);
                    break;
                case (RuntimePlatform.WindowsPlayer):
                    WriteFileWindows(Path.GetFullPath(url), data);
                    break;
                case (RuntimePlatform.Android):
                    break;
                default:
                    throw new System.Exception("This platform todata nonsupported, pls wait when add this OS!!");
            }
        }

        public static void Write(string url, object obj) =>
            Write(url ,JsonUtility.ToJson(obj , true));

        private static void WriteFileWindows(string url, string data) {
            string dir = CrossplatformUrlFormat.GetDirectoryFromFilePath(url);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            //if (!File.Exists(url)) 
            //{
            //      File.Create(url);
            //}

            File.WriteAllText(url, data);
        }



        [System.Obsolete]
        private static void WriteFileAndroid(string url, string data) {
            WWW w = new WWW(url , System.Text.Encoding.ASCII.GetBytes(data));
            while (!w.isDone) { }
        }
    }
}
