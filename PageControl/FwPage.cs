// Decompiled with JetBrains decompiler
// Type: PageControl.FwPage
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using ImageControl;
using Params;
using Products;
using System.Windows.Forms;

namespace PageControl
{
    internal abstract class FwPage
    {
        protected ToolParam toolParam;
        protected string imagePath;
        protected TabPage mainPage;
        protected TabPage imagePage;
        protected TabPage progressPage;

        protected FwPage(TabPage mainPage, TabPage imagePage, TabPage progressPage, string imagePath)
        {
            this.imagePath = imagePath;
            this.mainPage = mainPage;
            this.imagePage = imagePage;
            this.progressPage = progressPage;
            this.toolParam = ToolParam.Instance;
        }

        public virtual long SelectProduct(string initPath, ref Product product) => 1;

        public virtual long SelectImage(string initPath, ref ImageItem item) => 1;

        public string ImagePath
        {
            get => this.imagePath;
            set => this.imagePath = value;
        }

        public virtual string SelectPath => this.imagePath;

        public TabPage MainPage => this.mainPage;

        public TabPage ImagePage => this.imagePage;

        public TabPage ProgressPage => this.progressPage;
    }
}
