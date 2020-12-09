// Decompiled with JetBrains decompiler
// Type: Utils.NetworkInformation
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;

namespace Utils
{
  public class NetworkInformation
  {
    private List<string> physicalAddress = new List<string>();

    public string GetMacAddressUsedByIp()
    {
      string end;
      try
      {
        Process process = new Process()
        {
          StartInfo = {
            UseShellExecute = false,
            RedirectStandardOutput = true
          }
        };
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.FileName = "ipconfig";
        process.StartInfo.Arguments = "/all";
        process.Start();
        end = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
      }
      catch
      {
        return (string) null;
      }
      CLogs.I("[IPCONFIG/ALL] " + end);
      return this.ParseIpconfigString(end);
    }

    public string ParseIpconfigString(string ipconfigData)
    {
      string str1 = "";
      StreamReader streamReader = new StreamReader(ipconfigData);
      string str2;
      while ((str2 = streamReader.ReadLine()) != null)
      {
        if (str2.IndexOf("Physical Address") > 0)
        {
          int startIndex = str2.IndexOf(":") + 2;
          string str3 = str2.Substring(startIndex);
          str1 = str1 + str3 + ",";
        }
      }
      if (str1.Length > 0 && str1[str1.Length - 1] == ',')
        str1 = str1.Substring(0, str1.Length - 1);
      return str1;
    }

    public Utils.NetworkInformation EnumPhysicalAddress()
    {
      this.physicalAddress.Clear();
      foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
      {
        if (networkInterface.OperationalStatus == OperationalStatus.Up && !networkInterface.Description.Contains("Virtual") && !networkInterface.Description.Contains("Pseudo"))
          this.physicalAddress.Add(networkInterface.GetPhysicalAddress().ToString());
      }
      if (this.physicalAddress.Count <= 0)
      {
        foreach (ManagementObject instance in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
        {
          if ((bool) instance["IPEnabled"])
          {
            Console.WriteLine("MAC address\t{0}", (object) instance["MacAddress"].ToString());
            this.physicalAddress.Add(instance["MacAddress"].ToString());
          }
          instance.Dispose();
        }
      }
      return this;
    }

    public string GetPhysicalAddressByIndex(int index) => this.physicalAddress.Count <= index ? "" : this.physicalAddress[index];

    public List<string> All() => this.physicalAddress;

    public string GetAllPhysicalAddressString()
    {
      string str1 = "";
      foreach (string str2 in this.physicalAddress)
        str1 = str1 + str2 + ",";
      if (str1.Length > 0 && str1[str1.Length - 1] == ',')
        str1 = str1.Substring(0, str1.Length - 1);
      return str1;
    }
  }
}
