// Decompiled with JetBrains decompiler
// Type: Utils.PathEx
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.IO;
using System.Windows.Forms;

namespace Utils
{
    internal class PathEx
    {
        public static string GetModulePath() => Path.GetDirectoryName(Application.ExecutablePath);

        public static string GetModulePath(string path) => Path.Combine(PathEx.GetModulePath(), path);

        public static string GetProgramPath(string path) => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), path);

        public static string GetProgramx86Path(string path) => Path.Combine(PathEx.GetProgramFilesx86(), path);

        public static string ReverseFindFirstFile(string folder, string pattern, int levels)
        {
            do
            {
                string[] files = Directory.GetFiles(folder, pattern);
                if (files.Length > 0)
                    return files[0];
                DirectoryInfo parent = Directory.GetParent(folder);
                if (parent != null && parent.Exists)
                    folder = parent.FullName;
            }
            while (--levels > 0 && !string.IsNullOrEmpty(folder));
            return string.Empty;
        }

        private static string GetProgramFilesx86() => 8 == IntPtr.Size || !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432")) ? Environment.GetEnvironmentVariable("ProgramFiles(x86)") : Environment.GetEnvironmentVariable("ProgramFiles");
    }
}
