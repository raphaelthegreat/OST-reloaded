// Decompiled with JetBrains decompiler
// Type: Deployment.DeployCaches.ApplicationFile
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Deployment.DeployCaches
{
    public class ApplicationFile
    {
        private XmlDocument doc;
        private string xmlPath;

        private ApplicationFile(XmlDocument doc, string xmlPath)
        {
            this.doc = doc;
            this.xmlPath = xmlPath;
        }

        public static ApplicationFile LoadFile(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            return new ApplicationFile(doc, filePath);
        }

        public static ApplicationFile LoadStream(string stream)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(stream);
            return new ApplicationFile(doc, string.Empty);
        }

        public ApplicationFile SaveFile(string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            this.doc.Save(filePath);
            this.xmlPath = filePath;
            return this;
        }

        public List<DeployFile> GetFiles()
        {
            List<DeployFile> deployFileList = new List<DeployFile>();
            foreach (XmlElement selectNode in this.doc.SelectNodes("/Application/File"))
            {
                DeployFile deployFile = DeployFile.Parse(selectNode);
                if (!string.IsNullOrEmpty(this.xmlPath))
                    deployFile.FindFile(Path.GetDirectoryName(this.xmlPath));
                deployFileList.Add(deployFile);
            }
            return deployFileList;
        }

        public ApplicationFile RemoveFile(string name)
        {
            XmlNodeList xmlNodeList = this.doc.SelectNodes("/Application/File");
            for (int i = 0; i < xmlNodeList.Count; ++i)
            {
                if (((XmlElement)xmlNodeList[i]).GetAttribute("Name").Equals(name))
                {
                    xmlNodeList[i].ParentNode.RemoveChild(xmlNodeList[i]);
                    break;
                }
            }
            return this;
        }

        public string DeployerPath
        {
            get
            {
                DeployFile deployFile = this.GetFiles().Find((Predicate<DeployFile>)(file => file.IsDeployFile));
                return deployFile.IsDeployFile && !string.IsNullOrEmpty(this.xmlPath) ? Path.Combine(Path.GetDirectoryName(this.xmlPath), deployFile.Name) : string.Empty;
            }
        }
    }
}
