using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Utility
{
    public class SiteConfig
    {
        public SiteConfig()
        {
            SITE_URL = ConfigurationManager.AppSettings["SITE_URL"];
            SITE_URL = string.IsNullOrEmpty(SITE_URL) ? @"http://te-cool.com:99/" : SITE_URL;

            CompanyName = ConfigurationManager.AppSettings["CompanyName"];
            CompanyName = string.IsNullOrEmpty(CompanyName) ? "重庆永友网络有限公司" : CompanyName;

            SocketURL = ConfigurationManager.AppSettings["SocketURL"];
            SocketURL = string.IsNullOrEmpty(SocketURL) ? @"120.77.144.50:3000" : SocketURL;

            JPushKey_User = ConfigurationManager.AppSettings["JPushKey_User"];
            JPushKey_User = string.IsNullOrEmpty(JPushKey_User) ? "f25f2eb8c8cea16322be74d1" : JPushKey_User;

            JPushMasterSecret_User = ConfigurationManager.AppSettings["JPushMasterSecret_User"];
            JPushMasterSecret_User = string.IsNullOrEmpty(JPushMasterSecret_User) ? "a7f67b2c8878dac1a08fc594" : JPushMasterSecret_User;

            JPushKey_Customer = ConfigurationManager.AppSettings["JPushKey_Customer"];
            JPushKey_Customer = string.IsNullOrEmpty(JPushKey_Customer) ? "32f101fde82b8310063cc8ed" : JPushKey_Customer;

            JPushMasterSecret_Customer = ConfigurationManager.AppSettings["JPushMasterSecret_Customer"];
            JPushMasterSecret_Customer = string.IsNullOrEmpty(JPushMasterSecret_Customer) ? "6e836a4bf30caead5ead5a51" : JPushMasterSecret_Customer;

            LocalURL = ConfigurationManager.AppSettings["LocalURL"];
            LocalURL = string.IsNullOrEmpty(LocalURL) ? "http://172.18.174.157/" : LocalURL;

            JPushKey_Business = ConfigurationManager.AppSettings["JPushKey_Business"];
            JPushKey_Business = string.IsNullOrEmpty(JPushKey_Business) ? "6e836a4bf30caead5ead5a51" : JPushKey_Business;

            JPushMasterSecret_Business = ConfigurationManager.AppSettings["JPushMasterSecret_Business"];
            JPushMasterSecret_Business = string.IsNullOrEmpty(JPushMasterSecret_Business) ? "6e836a4bf30caead5ead5a51" : JPushMasterSecret_Business;

            string CanAPPUserRegisterStr = ConfigurationManager.AppSettings["CanAPPUserRegister"];
            bool _CanAPPUserRegister = false;
            if (!string.IsNullOrEmpty(CanAPPUserRegisterStr))
            {
                bool.TryParse(CanAPPUserRegisterStr, out _CanAPPUserRegister);
            }
            CanAPPUserRegister = _CanAPPUserRegister;

            bool DefaultIsAppUserLoginOn = true;
            string IsAppUserLoginOnStr = ConfigurationManager.AppSettings["IsAppUserLoginOn"];
            if (!string.IsNullOrEmpty(IsAppUserLoginOnStr))
            {
                bool.TryParse(IsAppUserLoginOnStr, out DefaultIsAppUserLoginOn);
            }
            IsAppUserLoginOn = DefaultIsAppUserLoginOn;

            int DefaultTotalRoomCount = 50000;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TotalRoomCount"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["TotalRoomCount"], out DefaultTotalRoomCount);
            }
            TotalRoomCount = DefaultTotalRoomCount;

            PreIndex = ConfigurationManager.AppSettings["PreIndex"];
            if (string.IsNullOrEmpty(PreIndex))
            {
                PreIndex = Utility.Tools.getApplicationPath();
                if (PreIndex.Length > 0)
                {
                    PreIndex = PreIndex.Substring(1, PreIndex.Length - 1);
                }
            }
            PreIndex = string.IsNullOrEmpty(PreIndex) ? "saasyy" : PreIndex;

            tencentAppID = ConfigurationManager.AppSettings["tencentAppID"];
            tencentAppID = string.IsNullOrEmpty(tencentAppID) ? "1400176446" : tencentAppID;

            tencentSecretId = ConfigurationManager.AppSettings["tencentSecretId"];
            tencentSecretId = string.IsNullOrEmpty(tencentSecretId) ? "" : tencentSecretId;

            tencentSecretKey = ConfigurationManager.AppSettings["tencentSecretKey"];
            tencentSecretKey = string.IsNullOrEmpty(tencentSecretKey) ? "" : tencentSecretKey;

            int _DelayTimeOutHour = 0;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DelayTimeOutHour"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["DelayTimeOutHour"], out _DelayTimeOutHour);
            }
            DelayTimeOutHour = _DelayTimeOutHour;

            int _BaoXiuServiceID = 0;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["BaoXiuServiceID"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["BaoXiuServiceID"], out _BaoXiuServiceID);
            }
            BaoXiuServiceID = _BaoXiuServiceID;

            int _YingXiaoTouSuServiceID = 0;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["YingXiaoTouSuServiceID"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["YingXiaoTouSuServiceID"], out _YingXiaoTouSuServiceID);
            }
            YingXiaoTouSuServiceID = _YingXiaoTouSuServiceID;

            int _WuYeTouSuServiceID = 0;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["WuYeTouSuServiceID"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["WuYeTouSuServiceID"], out _WuYeTouSuServiceID);
            }
            WuYeTouSuServiceID = _WuYeTouSuServiceID;

            int _WuYeBaoShiServiceID = 0;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["WuYeBaoShiServiceID"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["WuYeBaoShiServiceID"], out _WuYeBaoShiServiceID);
            }
            WuYeBaoShiServiceID = _WuYeBaoShiServiceID;

            int _LianJieTouSuServiceID = 0;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LianJieTouSuServiceID"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["LianJieTouSuServiceID"], out _LianJieTouSuServiceID);
            }
            LianJieTouSuServiceID = _LianJieTouSuServiceID;

            int _PinZhiShengJiServiceID = 0;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["PinZhiShengJiServiceID"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["PinZhiShengJiServiceID"], out _PinZhiShengJiServiceID);
            }
            PinZhiShengJiServiceID = _PinZhiShengJiServiceID;

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["BaoShiServiceIDs"]))
            {
                BaoShiServiceIDList = JsonConvert.DeserializeObject<int[]>(ConfigurationManager.AppSettings["BaoShiServiceIDs"]);
            }
        }
        public int[] BaoShiServiceIDList { get; set; }
        public int LianJieTouSuServiceID { get; set; }
        public int BaoXiuServiceID { get; set; }
        public int YingXiaoTouSuServiceID { get; set; }
        public int WuYeTouSuServiceID { get; set; }
        public int WuYeBaoShiServiceID { get; set; }
        public int PinZhiShengJiServiceID { get; set; }
        public decimal DelayTimeOutHour { get; set; }
        /// 发布系统一级URL
        /// </summary>
        public string SITE_URL { get; set; }
        public string CompanyName { get; set; }
        /// <summary>
        /// socket地址
        /// </summary>
        public string SocketURL { get; set; }
        /// <summary>
        /// 员工端APP极光推送Key
        /// </summary>
        public string JPushKey_User { get; set; }
        /// <summary>
        /// 员工端APP极光推送密钥
        /// </summary>
        public string JPushMasterSecret_User { get; set; }
        /// <summary>
        /// 业主端APP极光推送Key
        /// </summary>
        public string JPushKey_Customer { get; set; }
        /// <summary>
        /// 业主端APP极光推送密钥
        /// </summary>
        public string JPushMasterSecret_Customer { get; set; }
        public string LocalURL { get; set; }
        public string JPushKey_Business { get; set; }
        public string JPushMasterSecret_Business { get; set; }
        public bool CanAPPUserRegister { get; set; }
        public bool IsAppUserLoginOn { get; set; }
        public int TotalRoomCount { get; set; }
        public string PreIndex { get; set; }
        public string tencentAppID { get; set; }
        public string tencentSecretId { get; set; }
        public string tencentSecretKey { get; set; }
    }
}
