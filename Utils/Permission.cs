// Decompiled with JetBrains decompiler
// Type: Utils.Permission
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Utils
{
  public class Permission
  {
    public UserPermissionGroup Group = UserPermissionGroup.NONE;
    public bool Enable;

    public Permission(UserPermissionGroup group, bool enable)
    {
      this.Group = group;
      this.Enable = enable;
    }
  }
}
