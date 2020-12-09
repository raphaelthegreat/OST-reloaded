// Decompiled with JetBrains decompiler
// Type: Utils.functionObject
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Utils
{
  internal class functionObject
  {
    public Dictionary<string, object> functions;
    private static string sSession = Guid.NewGuid().ToString();
    public string name;
    public string status;
    public Dictionary<string, object> extraInfo;

    public functionObject(string jsonString)
    {
      this.name = "";
      this.status = "";
      this.functions = new Dictionary<string, object>();
      this.loadJsonString(jsonString);
    }

    public void loadJsonString(string jsonString)
    {
      try
      {
        JObject jobject = jsonString.Length != 0 ? JObject.Parse(jsonString) : throw new CException("[functionObject] Load empty json string fail!");
        if (jobject["session"] != null)
          this.status = jobject["session"].ToString();
        if (jobject["name"] != null)
          this.name = jobject["name"].ToString();
        if (jobject["status"] != null)
          this.status = jobject["status"].ToString();
        if (jobject["extraInfo"] == null)
          return;
        this.extraInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(jobject["extraInfo"].ToString());
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
