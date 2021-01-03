// Decompiled with JetBrains decompiler
// Type: Utils.webResponseObject
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Utils
{
    internal class webResponseObject
    {
        public string status;
        public string message;
        public Dictionary<string, object> result;

        public webResponseObject()
        {
            this.status = "";
            this.message = "";
            this.result = new Dictionary<string, object>();
        }

        public webResponseObject(string jsonString)
        {
            this.status = "";
            this.message = "";
            this.result = new Dictionary<string, object>();
            this.loadJsonString(jsonString);
        }

        public void loadJsonString(string jsonString)
        {
            try
            {
                JObject jobject = jsonString.Length != 0 ? JObject.Parse(jsonString) : throw new CException("[webResponseObject] Load empty json string fail!");
                if (jobject["status"] != null)
                    this.status = jobject["status"].ToString();
                if (jobject["message"] != null)
                    this.message = jobject["message"].ToString();
                if (jobject["result"] == null)
                    return;
                this.result = JsonConvert.DeserializeObject<Dictionary<string, object>>(jobject["result"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
