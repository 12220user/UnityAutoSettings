using System.IO;

namespace UnityAutoSettings.FileSystem
{
    public static class CrossplatformUrlFormat
    {
        public static string GetDirectoryFromFilePath(string path) {
            string dir = "";
            string[] data = path.Split('/' , '\\');
            data[data.Length - 1] = "";
            dir = string.Join('/' , data);
            return dir;
        }

        public static string ToJarDir(string path) {
            string dir = "";
            string[] data = path.Split('/', '\\');
            data[0] = "";
            dir = string.Join('/', data);
            return string.Join('/', "jar:file:", dir);
        }
    }
}
