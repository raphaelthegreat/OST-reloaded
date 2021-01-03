// Decompiled with JetBrains decompiler
// Type: OtaControl.OtaImageCache.OtaCacheConfig
// Assembly: OnlineUpdateTool, Version=6.3.7.0, Culture=neutral, PublicKeyToken=null
// MVID: EA27343A-8B18-4C76-B602-BBE3AEAD61D6
// Assembly location: C:\Program Files (x86)\OST LA\OnlineUpdateTool.exe

using System.IO;
using Utils;

namespace OtaControl.OtaImageCache
{
    public class OtaCacheConfig
    {
        private const int baseWebServiceId = 11;
        private const string activeSection = "Service2";
        private OtaService WEB_SERVICE_TPEOTA_DEMO = new OtaService("http://tpe-ota.fihtdc.com/demo/filehandler.asmx", "http://tpe-ota.fihtdc.com/demo/login.asmx", "http://tpe-ota.fihtdc.com/demo/swimage.asmx", "http://tpe-ota.fihtdc.com/demo/log.asmx");
        private OtaService WEB_SERVICE_TPEOTA_WEEKLY = new OtaService("http://tpe-ota.fihtdc.com/weekly/filehandler.asmx", "http://tpe-ota.fihtdc.com/weekly/login.asmx", "http://tpe-ota.fihtdc.com/weekly/swimage.asmx", "http://tpe-ota.fihtdc.com/weekly/log.asmx");
        private OtaService WEB_SERVICE_AMAZON = new OtaService("http://www.c2dms.com/filehandler.asmx", "http://www.c2dms.com/login.asmx", "http://www.c2dms.com/swimage.asmx", "http://www.c2dms.com/log.asmx");
        private OtaService WEB_SERVICE_ALIYUN = new OtaService("http://cn.c2dms.com/filehandler.asmx", "http://cn.c2dms.com/login.asmx", "http://cn.c2dms.com/swimage.asmx", "http://cn.c2dms.com/log.asmx");
        private OtaService WEB_SERVICE_TPEOTA = new OtaService("http://tpe-ota.fihtdc.com/filehandler.asmx", "http://tpe-ota.fihtdc.com/login.asmx", "http://tpe-ota.fihtdc.com/swimage.asmx", "http://tpe-ota.fihtdc.com/log.asmx");
        private static OtaCacheConfig instance;
        private Profile config;

        public static OtaCacheConfig Instance => OtaCacheConfig.instance;

        protected OtaCacheConfig(string cacheFolder) => this.config = new Profile(Path.Combine(cacheFolder, "chche_config.ini"));

        public static void CreateInstance(string cacheFolder)
        {
            if (OtaCacheConfig.instance != null)
                return;
            OtaCacheConfig.instance = new OtaCacheConfig(cacheFolder);
        }

        public OtaService GetWebService(int webServiceId)
        {
            switch (webServiceId)
            {
                case 0:
                    return this.WEB_SERVICE_TPEOTA_DEMO;
                case 1:
                    return this.WEB_SERVICE_TPEOTA_WEEKLY;
                case 2:
                    return this.WEB_SERVICE_AMAZON;
                case 3:
                    return this.WEB_SERVICE_ALIYUN;
                case 4:
                    return this.WEB_SERVICE_TPEOTA;
                default:
                    return this.LoadWebService(webServiceId);
            }
        }

        private OtaService LoadWebService(int webServiceId)
        {
            string[] strArray = this.config.ReadString("Service2", webServiceId.ToString()).Split(',');
            if (strArray.Length == 4)
                return new OtaService(strArray[0], strArray[1], strArray[2], strArray[3]);
            CLogs.E("Get value of URL ID fails, ID: " + webServiceId.ToString());
            return (OtaService)null;
        }

        public int SetWebService(OtaService webService)
        {
            if (webService.Equals((object)this.WEB_SERVICE_TPEOTA_DEMO))
                return 0;
            if (webService.Equals((object)this.WEB_SERVICE_TPEOTA_WEEKLY))
                return 1;
            if (webService.Equals((object)this.WEB_SERVICE_AMAZON))
                return 2;
            if (webService.Equals((object)this.WEB_SERVICE_ALIYUN))
                return 3;
            return webService.Equals((object)this.WEB_SERVICE_TPEOTA) ? 4 : this.SaveWebService(webService);
        }

        private int SaveWebService(OtaService webService)
        {
            int webServiceId = 11;
            while (true)
            {
                OtaService otaService = this.LoadWebService(webServiceId);
                if (otaService != null)
                {
                    if (!otaService.Equals((object)webService))
                        ++webServiceId;
                    else
                        goto label_5;
                }
                else
                    break;
            }
            this.config.WriteString("Service2", webServiceId.ToString(), string.Join(",", new string[4]
            {
        webService.FileHandler,
        webService.Login,
        webService.SWImage,
        webService.Log
            }));
        label_5:
            return webServiceId;
        }
    }
}
