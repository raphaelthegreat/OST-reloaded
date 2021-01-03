// Decompiled with JetBrains decompiler
// Type: Products.Product
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using ImageControl;
using ImageControl.ImageLoader;
using MyResources.Properties;
using Newtonsoft.Json;
using Params;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Utils;

namespace Products
{
    internal abstract class Product
    {
        private static Product _product;
        protected static ImageData imageData;
        protected ToolParam toolParam;
        protected int runCount;
        private static ProductQ3 productQ3;
        private static ProductQ6 productQ6;
        private static ProductQ8 productQ8;
        private static ProductQ9 productQ9;
        private static ProductT1 productT1;
        private static ProductT2 productT2;
        private static ProductI1 productI1;
        private static ProductM2 productM2;
        private static ProductW1 productW1;
        private static ProductW2 productW2;
        private static ProductA1 productA1;
        private static ProductS1 productS1;
        private static ProductQcXml productQcXml;
        private static ProductFastboot productFastboot;

        public bool HasBackupNvOption => Product.imageData != null && Product.imageData.Get(nameof(HasBackupNvOption)).Equals("True");

        public bool HasEraseUserDataOption => Product.imageData != null && Product.imageData.Get(nameof(HasEraseUserDataOption)).Equals("True");

        public bool HasEraseBoxDataOption => Product.imageData != null && Product.imageData.Get(nameof(HasEraseBoxDataOption)).Equals("True");

        public bool HasCustomerSKUIDOption => Product.imageData != null && Product.imageData.Get(nameof(HasCustomerSKUIDOption)).Equals("True");

        public bool HasNativeOption => Product.imageData != null && Product.imageData.Get(nameof(HasNativeOption)).Equals("True");

        public bool HasNativeFormatOption => Product.imageData != null && Product.imageData.Get(nameof(HasNativeFormatOption)).Equals("True");

        public bool HasEraseFrpOption => Product.imageData != null && Product.imageData.Get(nameof(HasEraseFrpOption)).Equals("True");

        public bool HasUnlockOption => Product.imageData != null && Product.imageData.Get(nameof(HasUnlockOption)).Equals("True");

        public uint ImgSecurityVersion => Convert.ToUInt32(Product.imageData.Get("SecurityVersion"), 16);

        public bool HasUFSProvisionOption => Product.imageData != null && Product.imageData.Get(nameof(HasUFSProvisionOption)).Equals("True");

        public static Product sharedProduct => Product._product;

        protected Product()
        {
            this.runCount = 0;
            this.toolParam = ToolParam.Instance;
        }

        public static long GetProduct(string imagePath, ref Product product)
        {
            long num = 0;
            StringBuilder platform = new StringBuilder(500);
            StringBuilder imageInfo = new StringBuilder(1024);
            Product.SetAppName(Settings.Default.ProductName);
            if (num == 0L)
                num = (long)Product.SetImagePath(imagePath);
            if (num == 0L)
                num = (long)Product.GetImagePlatform(platform, platform.Capacity);
            if (num == 0L)
                num = Product.FindProduct(platform.ToString(), ref product);
            if (num == 0L)
                num = (long)Product.GetImageInformation(imageInfo, imageInfo.Capacity);
            if (num == 0L)
                num = Product.ParseImageInformation(imageInfo.ToString());
            Product._product = product;
            return num;
        }

        private static long ParseImageInformation(string imageInfo)
        {
            try
            {
                Product.imageData = ImageData.Parse(JsonConvert.DeserializeObject<ImageInformationEntity>(imageInfo));
                return 0;
            }
            catch (Exception ex)
            {
                CLogs.E("Catch exception - " + ex.Message + ex.StackTrace);
                return 50718;
            }
        }

        public virtual void InitProduct(string imagePath) => Product.SetImagePath(imagePath);

        public abstract long StartUpdate(
          string sessionId,
          string imagePath,
          string deviceId,
          int option);

        public virtual void StopUpdate() => Product.UnloadImageFile();

        public virtual int FetchProgress(string sessionId)
        {
            int progress;
            return !Product.GetProgress(sessionId, out progress) ? 0 : progress;
        }

        public virtual string FetchProgressMessage(string sessionId)
        {
            StringBuilder message = new StringBuilder(1024);
            return !Product.GetProgressMessage(sessionId, message, message.Capacity) ? string.Empty : message.ToString();
        }

        public virtual string FetchDetailMessage(string sessionId)
        {
            StringBuilder message = new StringBuilder(1024);
            return !Product.GetDetailMessage(sessionId, message, message.Capacity) ? string.Empty : message.ToString();
        }

        public abstract bool HasUserOption(ProductOptions option);

        public virtual uint GetUserOptions(int option)
        {
            BitVector32 bitVector32 = new BitVector32(0);
            int mask1 = BitVector32.CreateMask();
            int mask2 = BitVector32.CreateMask(mask1);
            int mask3 = BitVector32.CreateMask(mask2);
            int mask4 = BitVector32.CreateMask(mask3);
            int mask5 = BitVector32.CreateMask(mask4);
            int mask6 = BitVector32.CreateMask(mask5);
            int mask7 = BitVector32.CreateMask(mask6);
            int mask8 = BitVector32.CreateMask(mask7);
            int mask9 = BitVector32.CreateMask(mask8);
            bitVector32[mask1] = this.IsDownloadOption(option, ProductOptions.NATIVE_UPDATE_PROCESS);
            bitVector32[mask2] = this.IsDownloadOption(option, ProductOptions.ERASE_USER_DATA) || this.IsDownloadOption(option, ProductOptions.NATIVE_UPDATE_PROCESS) || (this.IsDownloadOption(option, ProductOptions.NATIVE_ERASE_UPDATE_PROCESS) || this.toolParam.Option.DoEraseUserData) || this.toolParam.Option.DoSkipPidData;
            bitVector32[mask3] = this.IsDownloadOption(option, ProductOptions.NATIVE_FORMAT_UPDATE_PROCESS);
            bitVector32[mask4] = this.IsDownloadOption(option, ProductOptions.ERASE_BOX_DATA) || this.toolParam.Option.DoEraseBoxData;
            bitVector32[mask5] = this.IsDownloadOption(option, ProductOptions.SWITCH_CUSTOMER_SKUID) || this.toolParam.Option.DoSwitchCustomerSKUID;
            bitVector32[mask6] = this.IsDownloadOption(option, ProductOptions.ERASE_FRP) || this.toolParam.Option.DoEraseFrp;
            bitVector32[mask7] = this.IsDownloadOption(option, ProductOptions.UFS_PROVISION);
            bitVector32[mask8] = this.IsDownloadOption(option, ProductOptions.UNLOCK_SCREEN_LOCK);
            bitVector32[mask9] = this.IsDownloadOption(option, ProductOptions.COLLECT_APR_LOG) || this.toolParam.Option.DoCollectAprLog;
            return (uint)bitVector32.Data;
        }

        public bool IsDownloadOption(int value, ProductOptions option)
        {
            int num = 1 << (int)(option & (ProductOptions)31);
            return (value & num) == num;
        }

        public ImageType JudgeImageType(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                switch (new FileInfo(imagePath).Extension.ToLower())
                {
                    case ".mlf":
                        return ImageType.MLF_TYPE;
                    case ".nb0":
                        return ImageType.NB0_TYPE;
                    case ".xml":
                        return ImageType.NV_XML_TYPE;
                }
            }
            return ImageType.UNKNOEN_TYPE;
        }

        public bool HasSecurityVersion() => ((int)this.ImgSecurityVersion & -14) == 0;

        public int RunCount => this.runCount;

        [DllImport("MobileFlashDll.dll")]
        private static extern void SetAppName(string appName);

        [DllImport("MobileFlashDll.dll")]
        private static extern int SetImagePath(string imagePath);

        [DllImport("MobileFlashDll.dll")]
        private static extern int GetImagePlatform(StringBuilder platform, int platformSize);

        [DllImport("MobileFlashDll.dll")]
        private static extern void UnloadImageFile();

        [DllImport("MobileFlashDll.dll")]
        private static extern int GetImageInformation(StringBuilder imageInfo, int imageInfoSize);

        [DllImport("MobileFlashDll.dll")]
        protected static extern int BackupSettings(string sessionId, string deviceId, uint userOptions);

        [DllImport("MobileFlashDll.dll")]
        protected static extern int RestoreSettings(
          string sessionId,
          string deviceId,
          uint userOptions);

        [DllImport("MobileFlashDll.dll")]
        protected static extern int UpdateSoftware(string sessionId, string deviceId, uint userOptions);

        [DllImport("MobileFlashDll.dll")]
        protected static extern int EmergencyUpdateSoftware(string sessionId, uint userOptions);

        [DllImport("MobileFlashDll.dll")]
        private static extern bool GetProgress(string sessionId, out int progress);

        [DllImport("MobileFlashDll.dll")]
        private static extern bool GetProgressMessage(
          string sessionId,
          StringBuilder message,
          int messageSize);

        [DllImport("MobileFlashDll.dll")]
        private static extern bool GetDetailMessage(
          string sessionId,
          StringBuilder message,
          int messageSize);

        private static void CreateProducts()
        {
            if (Product.productQ3 == null)
                Product.productQ3 = new ProductQ3();
            if (Product.productQ6 == null)
                Product.productQ6 = new ProductQ6();
            if (Product.productQ8 == null)
                Product.productQ8 = new ProductQ8();
            if (Product.productQ9 == null)
                Product.productQ9 = new ProductQ9();
            if (Product.productT1 == null)
                Product.productT1 = new ProductT1();
            if (Product.productT2 == null)
                Product.productT2 = new ProductT2();
            if (Product.productI1 == null)
                Product.productI1 = new ProductI1();
            if (Product.productM2 == null)
                Product.productM2 = new ProductM2();
            if (Product.productW1 == null)
                Product.productW1 = new ProductW1();
            if (Product.productW2 == null)
                Product.productW2 = new ProductW2();
            if (Product.productA1 == null)
                Product.productA1 = new ProductA1();
            if (Product.productS1 == null)
                Product.productS1 = new ProductS1();
            if (Product.productQcXml == null)
                Product.productQcXml = new ProductQcXml();
            if (Product.productFastboot != null)
                return;
            Product.productFastboot = new ProductFastboot();
        }

        private static long FindProduct(string platform, ref Product product)
        {
            Product.CreateProducts();
            product = !platform.StartsWith("Q3") ? (!platform.StartsWith("Q4") ? (!platform.StartsWith("Q5") ? (!platform.StartsWith("Q6") ? (!platform.StartsWith("Q7") ? (!platform.StartsWith("Q8") ? (!platform.StartsWith("Q9") ? (!platform.StartsWith("T1") ? (!platform.StartsWith("T2") ? (!platform.StartsWith("I1") ? (!platform.StartsWith("I2") ? (!platform.StartsWith("M2") ? (!platform.StartsWith("M3") ? (!platform.StartsWith("M4") ? (!platform.StartsWith("M5") ? (!platform.StartsWith("M6") ? (!platform.StartsWith("W1") ? (!platform.StartsWith("W2") ? (!platform.StartsWith("A1") ? (!platform.StartsWith("S1") ? (!platform.StartsWith("XR") ? (Product)Product.productFastboot : (Product)Product.productQcXml) : (Product)Product.productS1) : (Product)Product.productA1) : (Product)Product.productW2) : (Product)Product.productW1) : (Product)Product.productM2) : (Product)Product.productM2) : (Product)Product.productM2) : (Product)Product.productM2) : (Product)Product.productM2) : (Product)Product.productI1) : (Product)Product.productI1) : (Product)Product.productT2) : (Product)Product.productT1) : (Product)Product.productQ9) : (Product)Product.productQ8) : (Product)Product.productQ3) : (Product)Product.productQ6) : (Product)Product.productQ3) : (Product)Product.productQ3) : (Product)Product.productQ3;
            return 0;
        }
    }
}
