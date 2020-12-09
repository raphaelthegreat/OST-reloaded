// Decompiled with JetBrains decompiler
// Type: Deployment.DeployCaches.DeploymentFile
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.IO;
using System.Xml;

namespace Deployment.DeployCaches
{
  public class DeploymentFile
  {
    private XmlDocument doc;
    private string xmlPath;

    private DeploymentFile(XmlDocument doc, string xmlPath)
    {
      this.doc = doc;
      this.xmlPath = xmlPath;
    }

    public static DeploymentFile LoadFile(string filePath)
    {
      XmlDocument doc = new XmlDocument();
      doc.Load(filePath);
      return new DeploymentFile(doc, filePath);
    }

    public static DeploymentFile LoadStream(string stream)
    {
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(stream);
      return new DeploymentFile(doc, string.Empty);
    }

    public DeploymentFile SaveFile(string filePath)
    {
      Directory.CreateDirectory(Path.GetDirectoryName(filePath));
      this.doc.Save(filePath);
      this.xmlPath = filePath;
      return this;
    }

    public string Publisher => ((XmlElement) this.doc.SelectSingleNode("/Deployment/Information")).GetAttribute(nameof (Publisher));

    public string DisplayName => ((XmlElement) this.doc.SelectSingleNode("/Deployment/Information")).GetAttribute(nameof (DisplayName));

    public string DisplayVersion => ((XmlElement) this.doc.SelectSingleNode("/Deployment/Information")).GetAttribute(nameof (DisplayVersion));

    public string ApplicationFolder => Path.GetDirectoryName(this.ApplicationName);

    public string ApplicationName => ((XmlElement) this.doc.SelectSingleNode("/Deployment/Application")).GetAttribute("Name");

    public string ApplicationChecksum => ((XmlElement) this.doc.SelectSingleNode("/Deployment/Application")).GetAttribute("Checksum");
  }
}
