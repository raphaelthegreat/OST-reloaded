// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaAccount
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Collections.Generic;

namespace OtaControl
{
    internal class OtaAccount
    {
        private string username;
        private string password;
        private string commToken;
        private List<OtaRight> rights;
        protected Dictionary<string, List<OtaService>> webServiceGroups;

        public string Username => this.username;

        public string Password => this.password;

        public string CommToken => this.commToken;

        public List<OtaRight> Rights => this.rights;

        public Dictionary<string, List<OtaService>> WebServiceGroups => this.webServiceGroups;

        public OtaAccount()
        {
            this.rights = new List<OtaRight>();
            this.webServiceGroups = new Dictionary<string, List<OtaService>>();
        }

        public OtaAccount(OtaData right, string group, List<OtaData> webServices)
        {
            this.rights = new List<OtaRight>();
            this.webServiceGroups = new Dictionary<string, List<OtaService>>();
            this.AddRight(right);
            this.SetWebServiceGroup(group, webServices);
        }

        public void SetUsername(string username) => this.username = username;

        public void SetPassword(string password) => this.password = password;

        public void SetCommToken(string commToken) => this.commToken = commToken;

        public void SetRights(List<OtaData> rights)
        {
            this.rights.Clear();
            this.webServiceGroups.Clear();
            foreach (OtaData right in rights)
                this.AddRight(right);
        }

        public void AddRight(OtaData right)
        {
            OtaRight otaRight = new OtaRight(right);
            this.rights.Add(otaRight);
            foreach (string webServiceGroup in otaRight.WebServiceGroups)
                this.webServiceGroups[webServiceGroup] = new List<OtaService>();
        }

        public void SetWebServiceGroup(string group, List<OtaData> webServices)
        {
            if (!this.webServiceGroups.ContainsKey(group))
                return;
            List<OtaService> otaServiceList = new List<OtaService>();
            foreach (OtaData webService in webServices)
                otaServiceList.Add(new OtaService(webService));
            this.webServiceGroups[group] = otaServiceList;
        }

        public bool LatestVersionListed => this.rights.Exists((Predicate<OtaRight>)(right => right.LatestImageListed));

        public void ForEachRight(OtaAccount.RightAction action)
        {
            foreach (OtaRight right in this.rights)
            {
                foreach (OtaService webService in this.GetWebServices(right.WebServiceGroups))
                    action(right, webService);
            }
        }

        private List<OtaService> GetWebServices(string[] groups)
        {
            List<OtaService> otaServiceList = new List<OtaService>();
            foreach (string group in groups)
            {
                if (this.webServiceGroups.ContainsKey(group))
                {
                    foreach (OtaService otaService in this.webServiceGroups[group])
                    {
                        if (otaService.Enabled && otaService.Available)
                            otaServiceList.Add(otaService);
                    }
                }
            }
            return otaServiceList;
        }

        public delegate void RightAction(OtaRight right, OtaService service);
    }
}
