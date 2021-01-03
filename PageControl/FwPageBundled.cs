// Decompiled with JetBrains decompiler
// Type: PageControl.FwPageBundled
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Products;
using System.IO;
using System.Windows.Forms;

namespace PageControl
{
    internal class FwPageBundled : FwPage
    {
        public FwPageBundled(
          TabPage mainPage,
          TabPage imagePage,
          TabPage progressPage,
          string imagePath)
          : base(mainPage, imagePage, progressPage, imagePath)
        {
        }

        public override long SelectProduct(string initPath, ref Product product)
        {
            if (!File.Exists(initPath))
                return 50717;
            this.imagePath = string.Empty;
            long product1 = Product.GetProduct(initPath, ref product);
            if (product1 != 0L)
            {
                product = (Product)null;
                this.imagePath = string.Empty;
                return product1;
            }
            this.imagePath = initPath;
            return 0;
        }
    }
}
