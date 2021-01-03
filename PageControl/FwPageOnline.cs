// Decompiled with JetBrains decompiler
// Type: PageControl.FwPageOnline
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using ImageControl;
using ImageControl.ImageLoader;
using System;
using System.Windows.Forms;
using Utils;

namespace PageControl
{
    internal class FwPageOnline : FwPage
    {
        public FwPageOnline(TabPage mainPage, TabPage imagePage, TabPage progressPage)
          : base(mainPage, imagePage, progressPage, "")
        {
        }

        public override long SelectImage(string initPath, ref ImageItem item)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = initPath;
            openFileDialog.CheckFileExists = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = this.toolParam.MainImageFilter;
            return openFileDialog.ShowDialog() != DialogResult.OK ? 1223L : this.LoadImageInformation(openFileDialog.FileName, ref item);
        }

        private long LoadImageInformation(string filePath, ref ImageItem item)
        {
            try
            {
                this.imagePath = filePath;
                item = new ImageItem(new ImageInformation().GetImageInformation(filePath));
                return 0;
            }
            catch (CException ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                return ex.CResult;
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                return 1064;
            }
        }
    }
}
