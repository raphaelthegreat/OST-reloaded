// Decompiled with JetBrains decompiler
// Type: Params.OtaParam
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using OtaControl;
using System.Runtime.InteropServices;

namespace Params
{
  internal abstract class OtaParam
  {
    private static OtaParam instance;
    protected OtaAccount account;
    protected OtaAccount password;
    protected OtaAccount commToken;

    public OtaAccount Account
    {
      set => this.account = value;
      get => this.account;
    }

    public OtaAccount Password
    {
      set => this.password = value;
      get => this.password;
    }

    public OtaAccount CommToken
    {
      set => this.commToken = value;
      get => this.commToken;
    }

    protected OtaParam() => OtaParam.SetArgumentInt(243, 1);

    public static OtaParam Instance
    {
      get
      {
        if (OtaParam.instance == null)
        {
          switch (ToolParam.ToolUser)
          {
            case ToolParam.User.Account:
              OtaParam.instance = (OtaParam) new OtaParamAccount();
              break;
            case ToolParam.User.RD:
              OtaParam.instance = (OtaParam) new OtaParamRD();
              break;
            default:
              OtaParam.instance = (OtaParam) new OtaParamEndUser();
              break;
          }
        }
        return OtaParam.instance;
      }
    }

    public virtual int MaxCacheImages => 100;

    public abstract bool UserLoginRequired { get; }

    public abstract string LoginUrl { get; }

    public virtual bool PlatformSupported(string platform) => !platform.Equals("XR");

    public virtual bool DeltaSupported(string platform) => !platform.Equals("XR") && (!platform.StartsWith("M") || platform.CompareTo("M3") < 0);

    [DllImport("MobileFlashDll.dll")]
    private static extern void SetArgumentInt(int argument, int value);
  }
}
