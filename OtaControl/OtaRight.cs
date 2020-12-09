// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaRight
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System;
using System.Collections.Generic;

namespace OtaControl
{
  public class OtaRight
  {
    private OtaData right;

    public OtaData Right
    {
      set => this.right = value;
      get => this.right;
    }

    public OtaRight() => this.right = new OtaData();

    public OtaRight(OtaData right) => this.right = right;

    public string OtaGroup => this.right.Get("OGP");

    public string[] WebServiceGroups => this.right.Get("SGP").Split(',');

    public bool LatestImageListed => this.right.Get("LO").Equals("Y");

    public bool Enabled => !this.right.Get("EL").Equals("N");

    public bool Released => !this.right.Get("RLS").Equals("N");

    public bool MpImageListed => this.right.Get("MO").Equals("Y");

    public bool OfficialImageListed => this.right.Get("OO").Equals("Y");

    public bool ServiceImageListed => this.right.Get("SO").Equals("Y");

    public bool ChannelEqual => this.right.Get("CCL").Equals("Y");

    public bool CustomerEqual => this.right.Get("CCR").Equals("Y");

    public bool ModelEqual => this.right.Get("CM").Equals("Y");

    public string[] CompatibleChannels
    {
      get
      {
        if (!this.right.Contain("CMCL"))
          return new string[0];
        return this.right.Get("CMCL").Split(',');
      }
    }

    public string[] CompatibleCustomers
    {
      get
      {
        if (!this.right.Contain("CMCR"))
          return new string[0];
        return this.right.Get("CMCR").Split(',');
      }
    }

    public string[] CompatibleModels
    {
      get
      {
        if (!this.right.Contain("CCM"))
          return new string[0];
        return this.right.Get("CCM").Split(',');
      }
    }

    public string TargetModel => this.right.Get("TM");

    public bool IsEmpty => !this.MpImageListed && !this.OfficialImageListed && (!this.ServiceImageListed && !this.ChannelEqual) && (!this.CustomerEqual && !this.ModelEqual && (this.CompatibleChannels.Length <= 0 && this.CompatibleCustomers.Length <= 0)) && (this.CompatibleModels.Length <= 0 && string.IsNullOrEmpty(this.TargetModel) && !this.OtaGroup.StartsWith("@"));

    public List<OtaData> Apply(OtaData phone, List<OtaData> images)
    {
      if (phone.Get("ChannelID").Equals("FIH"))
        return images;
      return this.IsEmpty ? new List<OtaData>() : this.GenericApply(phone, images);
    }

    private List<OtaData> GenericApply(OtaData phone, List<OtaData> images)
    {
      if (this.MpImageListed)
        images.RemoveAll((Predicate<OtaData>) (image => !image.Get("MP").Equals("True")));
      if (this.OfficialImageListed)
        images.RemoveAll((Predicate<OtaData>) (image => !image.Get("Official").Equals("True")));
      if (this.ServiceImageListed)
        images.RemoveAll((Predicate<OtaData>) (image => !image.Get("Service").Equals("True")));
      List<string> channels = new List<string>((IEnumerable<string>) this.CompatibleChannels);
      if (this.ChannelEqual)
        channels.Add(phone.Get("ChannelID"));
      if (channels.Count > 0)
        images.RemoveAll((Predicate<OtaData>) (image => !channels.Contains(image.Get("ChannelID")) && !this.IsTargetModel(image)));
      List<string> customers = new List<string>((IEnumerable<string>) this.CompatibleCustomers);
      if (this.CustomerEqual)
        customers.Add(phone.Get("OperatorID"));
      if (customers.Count > 0)
        images.RemoveAll((Predicate<OtaData>) (image => !customers.Contains(image.Get("OperatorID")) && !this.IsTargetModel(image)));
      List<string> models = new List<string>((IEnumerable<string>) this.CompatibleModels);
      if (this.ModelEqual)
        models.Add(phone.Get("ImageID"));
      if (models.Count > 0)
        images.RemoveAll((Predicate<OtaData>) (image => !models.Contains(image.Get("ImageID")) && !this.IsTargetModel(image)));
      return images;
    }

    private bool IsTargetModel(OtaData image) => !string.IsNullOrEmpty(this.TargetModel) && image.Contain("ImageID") && this.TargetModel.Equals(image.Get("ImageID"));

    public bool Compare(OtaData phone, OtaData image)
    {
      if (phone.Get("ChannelID").Equals("FIH"))
        return true;
      return !this.IsEmpty && this.GenericCompare(phone, image);
    }

    private bool GenericCompare(OtaData phone, OtaData image)
    {
      List<string> stringList1 = new List<string>((IEnumerable<string>) this.CompatibleChannels);
      if (this.ChannelEqual)
        stringList1.Add(phone.Get("ChannelID"));
      if (stringList1.Count > 0 && !this.IsTargetModel(image) && !stringList1.Contains(image.Get("ChannelID")))
        return false;
      List<string> stringList2 = new List<string>((IEnumerable<string>) this.CompatibleCustomers);
      if (this.CustomerEqual)
        stringList2.Add(phone.Get("OperatorID"));
      if (stringList2.Count > 0 && !this.IsTargetModel(image) && !stringList2.Contains(image.Get("OperatorID")))
        return false;
      List<string> stringList3 = new List<string>((IEnumerable<string>) this.CompatibleModels);
      if (this.ModelEqual)
        stringList3.Add(phone.Get("ImageID"));
      return stringList3.Count <= 0 || this.IsTargetModel(image) || stringList3.Contains(image.Get("ImageID"));
    }
  }
}
