// Decompiled with JetBrains decompiler
// Type: PageControl.FwPageSelected
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using Products;
using System.IO;
using System.Windows.Forms;
using UserConfigs;
using Utils;

namespace PageControl
{
  internal class FwPageSelected : FwPageBundled
  {
    private string selectPath;

    public FwPageSelected(TabPage mainPage, TabPage imagePage, TabPage progressPage)
      : base(mainPage, imagePage, progressPage, "")
    {
    }

    public override long SelectProduct(string initPath, ref Product product)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = initPath == string.Empty ? UserConfig.Instance.InitFirmwareDir : Path.GetDirectoryName(initPath);
      openFileDialog.CheckFileExists = true;
      openFileDialog.RestoreDirectory = true;
      openFileDialog.Filter = this.toolParam.MainImageFilter + "|xml files (*.xml)|*.xml";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return 1223;
      UserConfig.Instance.InitFirmwareDir = Path.GetDirectoryName(openFileDialog.FileName);
      return !Path.GetExtension(openFileDialog.FileName).Equals(".ini") ? this.LoadFwImage(openFileDialog.FileName, ref product) : this.LoadAutoTestScript(openFileDialog.FileName, ref product);
    }

    public override string SelectPath => this.selectPath;

    private void ResetContent()
    {
      this.imagePath = string.Empty;
      this.selectPath = string.Empty;
      this.toolParam.AutoTest = false;
    }

    private long LoadAutoTestScript(string scriptPath, ref Product product)
    {
      this.ResetContent();
      long num = base.SelectProduct(new Profile(scriptPath).ReadString("SUT", "Firmware"), ref product);
      if (num != 0L)
      {
        product = (Product) null;
        return num;
      }
      this.selectPath = scriptPath;
      this.toolParam.ConfigAutoTest(scriptPath);
      return 0;
    }

    private long LoadFwImage(string fwPath, ref Product product)
    {
      this.ResetContent();
      long product1 = Product.GetProduct(fwPath, ref product);
      if (product1 != 0L)
      {
        product = (Product) null;
        return product1;
      }
      this.imagePath = this.selectPath = fwPath;
      return 0;
    }
  }
}
