using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityAutoSettings.FileSystem{
    public static class CrossplatformFile
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
                    WriteFileAndroid(url, data);
                    break;
                default:
                    throw new System.Exception("This platform todata nonsupported, pls wait when add this OS!!");
            }
        }

        public static string Read(string url) {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                    return WindowsRead(url);
                case (RuntimePlatform.WindowsPlayer):
                    return WindowsRead(url);
                case (RuntimePlatform.Android):
                    return AndroidRead(url);
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

        private static string WindowsRead(string url)
        {
            return File.ReadAllText(url);
        }

        private static string AndroidRead(string url) {
            WWW www = new WWW(url);
            while (!www.isDone) { }
            return www.text;
        }


        private static void WriteFileAndroid(string url, string data) {
            WWW w = new WWW(url , System.Text.Encoding.ASCII.GetBytes(data));
            while (!w.isDone) { }
        }
    }
}
