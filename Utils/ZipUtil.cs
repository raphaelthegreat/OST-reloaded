// Decompiled with JetBrains decompiler
// Type: Utils.ZipUtil
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Utils
{
    public static class ZipUtil
    {
        public static void UnZipFiles(string zipFile, string toFolder)
        {
            /*if (!Directory.Exists(toFolder))
              Directory.CreateDirectory(toFolder);
            using (ZipInputStream zipInputStream = new ZipInputStream((Stream) File.OpenRead(zipFile)))
            {
              ZipEntry nextEntry;
              while ((nextEntry = zipInputStream.GetNextEntry()) != null)
              {
                string path = Path.Combine(toFolder, nextEntry.Name.Replace('/', '\\'));
                if (nextEntry.IsFile)
                {
                  using (FileStream fileStream = File.Create(path))
                  {
                    byte[] buffer = new byte[2048];
                    int count;
                    while ((count = zipInputStream.Read(buffer, 0, buffer.Length)) > 0)
                      fileStream.Write(buffer, 0, count);
                  }
                }
                else
                  Directory.CreateDirectory(path);
              }
            }*/
        }

        public static void UnZipFile(string zipFile, int index, string toFile, Progress progress)
        {
            /*if (!Directory.Exists(Path.GetDirectoryName(toFile)))
              Directory.CreateDirectory(Path.GetDirectoryName(toFile));
            using (ZipInputStream zipInputStream = new ZipInputStream((Stream) File.OpenRead(zipFile)))
            {
              int num = 0;
              ZipEntry nextEntry;
              while ((nextEntry = zipInputStream.GetNextEntry()) != null)
              {
                if (nextEntry.IsFile && num++ == index)
                {
                  using (FileStream fileStream = File.Create(toFile))
                  {
                    byte[] buffer = new byte[2048];
                    int count;
                    while ((count = zipInputStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                      fileStream.Write(buffer, 0, count);
                      progress.OffsetPosition((long) count);
                    }
                  }
                }
              }
            }*/
        }
    }
}
