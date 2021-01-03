// Decompiled with JetBrains decompiler
// Type: ImageControl.ImageLoader.ImageInformation
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using ErrorDef;
using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Utils;

namespace ImageControl.ImageLoader
{
    public class ImageInformation
    {
        public ImageData GetImageInformation(string imagePath)
        {
            try
            {
                int num;
                if ((num = ImageInformation.SetImagePath(imagePath)) != 0)
                    throw new CException((long)num, "Parse image file content fails, last error: " + ErrorCode.StringOf((long)num));
                StringBuilder platform = new StringBuilder(1024);
                int imagePlatform;
                if ((imagePlatform = ImageInformation.GetImagePlatform(platform, platform.Capacity)) != 0)
                    throw new CException((long)imagePlatform, "Load platform from image file fails, last error: " + ErrorCode.StringOf((long)imagePlatform));
                StringBuilder imageInfo = new StringBuilder(1024);
                int imageInformation;
                if ((imageInformation = ImageInformation.GetImageInformation(imageInfo, imageInfo.Capacity)) != 0)
                    throw new CException((long)imageInformation, "Load information from image file fails, last error: " + ErrorCode.StringOf((long)imageInformation));
                return ImageData.Parse(JsonConvert.DeserializeObject<ImageInformationEntity>(imageInfo.ToString())).Set("Platform", platform.ToString()).Set("FilePath", imagePath);
            }
            catch (CException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                throw new CException(50718L, "Catch exception when loading image information.");
            }
        }

        [DllImport("MobileFlashDll.dll")]
        private static extern int SetImagePath(string imagePath);

        [DllImport("MobileFlashDll.dll")]
        private static extern int GetImagePlatform(StringBuilder platform, int platformSize);

        [DllImport("MobileFlashDll.dll")]
        private static extern int GetImageInformation(StringBuilder imageInfo, int imageInfoSize);
    }
}
