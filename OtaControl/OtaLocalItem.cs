// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaLocalItem
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using ImageControl;
using Locales;

namespace OtaControl
{
    public class OtaLocalItem : OtaItem
    {
        private bool showModel;

        public OtaLocalItem(ImageItem item)
          : base(new OtaData(item.Item))
          => this.item.Set(nameof(FilePath), item.FilePath);

        public string FilePath => this.item.Get(nameof(FilePath));

        public bool ShowModel
        {
            set => this.showModel = value;
        }

        public override string ToString() => this.showModel ? string.Format("{0} ({1}, {2})", (object)base.ToString(), (object)Locale.Instance.LoadText("ONLINE_LOCAL_TAG"), (object)this.DisplayModel) : string.Format("{0} ({1})", (object)base.ToString(), (object)Locale.Instance.LoadText("ONLINE_LOCAL_TAG"));
    }
}
