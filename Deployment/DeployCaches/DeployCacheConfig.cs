// Decompiled with JetBrains decompiler
// Type: Deployment.DeployCaches.DeployCacheConfig
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using MyResources.Properties;
using System.IO;
using System.Reflection;
using Utils;

namespace Deployment.DeployCaches
{
  public class DeployCacheConfig
  {
    private static DeployCacheConfig instance;
    private Profile config;

    public static DeployCacheConfig Instance => DeployCacheConfig.instance;

    protected DeployCacheConfig(string cacheFolder) => this.config = new Profile(Path.Combine(cacheFolder, "chche_config.ini"));

    public static void CreateInstance(string cacheFolder)
    {
      if (DeployCacheConfig.instance != null)
        return;
      DeployCacheConfig.instance = new DeployCacheConfig(cacheFolder);
    }

    public string WebSite
    {
      get
      {
        string productName = Settings.Default.ProductName;
        return string.Format("{0}/{1}/{2}/", (object) this.Host, (object) Assembly.GetExecutingAssembly().GetName().Name, (object) productName);
      }
    }

    public string Host => this.config.ReadString("Deploy", nameof (Host), "http://tpe-ota.fihtdc.com/SWUpdateTool/MsiDeploy/").TrimEnd('/');
  }
}
