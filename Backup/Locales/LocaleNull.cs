// Decompiled with JetBrains decompiler
// Type: Locales.LocaleNull
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

namespace Locales
{
  internal class LocaleNull : Locale
  {
    public LocaleNull()
      : base("", "")
    {
    }

    public override string LoadText(string localeId) => localeId;

    public override string LoadCombinedText(string localeId) => localeId;
  }
}
