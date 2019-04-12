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

            APIURL = ConfigurationManager.AppSettings["APIURL"];
            APIURL = string.IsNullOrEmpty(APIURL) ? @"http://120.77.144.50:10086/Handler/EncryptHandler.ashx" : APIURL;

            smsServer = ConfigurationManager.AppSettings["smsServer"];
            smsServer = string.IsNullOrEmpty(smsServer) ? @"http://120.76.25.160:7788/sms.aspx" : smsServer;

            smsUserID = ConfigurationManager.AppSettings["smsUserID"];
            smsUserID = string.IsNullOrEmpty(smsUserID) ? "793" : smsUserID;

            smsAccount = ConfigurationManager.AppSettings["smsAccount"];
            smsAccount = string.IsNullOrEmpty(smsAccount) ? "saasyy" : smsAccount;

            smsPassword = ConfigurationManager.AppSettings["smsPassword"];
            smsPassword = string.IsNullOrEmpty(smsPassword) ? "520620" : smsPassword;

            smsSign = ConfigurationManager.AppSettings["smsSign"];
            smsSign = string.IsNullOrEmpty(smsSign) ? "永友科技" : smsSign;

            ServerSiteID = ConfigurationManager.AppSettings["ServerSiteID"];
            ServerSiteID = string.IsNullOrEmpty(ServerSiteID) ? "" : ServerSiteID;

            JPushKey_User = ConfigurationManager.AppSettings["JPushKey_User"];
            JPushKey_User = string.IsNullOrEmpty(JPushKey_User) ? "f25f2eb8c8cea16322be74d1" : JPushKey_User;

            JPushMasterSecret_User = ConfigurationManager.AppSettings["JPushMasterSecret_User"];
            JPushMasterSecret_User = string.IsNullOrEmpty(JPushMasterSecret_User) ? "a7f67b2c8878dac1a08fc594" : JPushMasterSecret_User;

            bool _PaasSmsServerEnable = false;
            string PaasSmsServerEnableStr = ConfigurationManager.AppSettings["PaasSmsServerEnable"];
            if (!string.IsNullOrEmpty(PaasSmsServerEnableStr))
            {
                bool.TryParse(PaasSmsServerEnableStr, out _PaasSmsServerEnable);
            }
            PaasSmsServerEnable = _PaasSmsServerEnable;

            PaasSmsServer = ConfigurationManager.AppSettings["PaasSmsServer"];
            PaasSmsServer = string.IsNullOrEmpty(PaasSmsServer) ? "http://sapi.253.com/msg/HttpBatchSendSM" : PaasSmsServer;

            PaasSms_UserName = ConfigurationManager.AppSettings["PaasSms_UserName"];
            PaasSms_UserName = string.IsNullOrEmpty(PaasSms_UserName) ? "daili2_FukHome" : PaasSms_UserName;

            PaasSms_Password = ConfigurationManager.AppSettings["PaasSms_Password"];
            PaasSms_Password = string.IsNullOrEmpty(PaasSms_Password) ? "GZfsju3333186" : PaasSms_Password;

            JPushKey_Customer = ConfigurationManager.AppSettings["JPushKey_Customer"];
            JPushKey_Customer = string.IsNullOrEmpty(JPushKey_Customer) ? "32f101fde82b8310063cc8ed" : JPushKey_Customer;

            JPushMasterSecret_Customer = ConfigurationManager.AppSettings["JPushMasterSecret_Customer"];
            JPushMasterSecret_Customer = string.IsNullOrEmpty(JPushMasterSecret_Customer) ? "6e836a4bf30caead5ead5a51" : JPushMasterSecret_Customer;

            bool DefaultIsMallOn = false;
            string IsMallOnStr = ConfigurationManager.AppSettings["IsMallOn"];
            if (!string.IsNullOrEmpty(IsMallOnStr))
            {
                bool.TryParse(IsMallOnStr, out DefaultIsMallOn);
            }
            IsMallOn = DefaultIsMallOn;

            LocalURL = ConfigurationManager.AppSettings["LocalURL"];
            LocalURL = string.IsNullOrEmpty(LocalURL) ? "http://172.18.174.157/" : LocalURL;

            SystemName = ConfigurationManager.AppSettings["SystemName"];
            SystemName = string.IsNullOrEmpty(SystemName) ? "永友网络科技" : SystemName;

            bool DefaultIsFuShunJu = false;
            string IsFuShunJuStr = ConfigurationManager.AppSettings["IsFuShunJu"];
            if (!string.IsNullOrEmpty(IsFuShunJuStr))
            {
                bool.TryParse(IsFuShunJuStr, out DefaultIsFuShunJu);
            }
            IsFuShunJu = DefaultIsFuShunJu;

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

            string IsWriteChequeOnStr = ConfigurationManager.AppSettings["IsWriteChequeOn"];
            bool _IsWriteChequeOn = false;
            if (!string.IsNullOrEmpty(IsWriteChequeOnStr))
            {
                bool.TryParse(IsWriteChequeOnStr, out _IsWriteChequeOn);
            }
            IsWriteChequeOn = _IsWriteChequeOn;

            Cheque_UserName = ConfigurationManager.AppSettings["Cheque_UserName"];
            Cheque_UserName = string.IsNullOrEmpty(Cheque_UserName) ? string.Empty : Cheque_UserName;

            Cheque_Password = ConfigurationManager.AppSettings["Cheque_Password"];
            Cheque_Password = string.IsNullOrEmpty(Cheque_Password) ? string.Empty : Cheque_Password;

            Cheque_QYSH = ConfigurationManager.AppSettings["Cheque_QYSH"];
            Cheque_QYSH = string.IsNullOrEmpty(Cheque_QYSH) ? string.Empty : Cheque_QYSH;

            Cheque_APPID = ConfigurationManager.AppSettings["Cheque_APPID"];
            Cheque_APPID = string.IsNullOrEmpty(Cheque_APPID) ? string.Empty : Cheque_APPID;

            Cheque_FLBM = ConfigurationManager.AppSettings["Cheque_FLBM"];
            Cheque_FLBM = string.IsNullOrEmpty(Cheque_FLBM) ? string.Empty : Cheque_FLBM;

            bool DefaultIsAppUserLoginOn = true;
            string IsAppUserLoginOnStr = ConfigurationManager.AppSettings["IsAppUserLoginOn"];
            if (!string.IsNullOrEmpty(IsAppUserLoginOnStr))
            {
                bool.TryParse(IsAppUserLoginOnStr, out DefaultIsAppUserLoginOn);
            }
            IsAppUserLoginOn = DefaultIsAppUserLoginOn;

            int DefaultTotalRoomCount = 5000;
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

            bool _tencentSmsEnable = false;
            string tencentSmsEnableStr = ConfigurationManager.AppSettings["tencentSmsEnable"];
            if (!string.IsNullOrEmpty(tencentSmsEnableStr))
            {
                bool.TryParse(tencentSmsEnableStr, out _tencentSmsEnable);
            }
            tencentSmsEnable = _tencentSmsEnable;

            tencentAppID = ConfigurationManager.AppSettings["tencentAppID"];
            tencentAppID = string.IsNullOrEmpty(tencentAppID) ? "1400176446" : tencentAppID;

            tencentAppKey = ConfigurationManager.AppSettings["tencentAppKey"];
            tencentAppKey = string.IsNullOrEmpty(tencentAppKey) ? "cc515c02ace142198eb884e8e73aa6d1" : tencentAppKey;

            tencentServer = ConfigurationManager.AppSettings["tencentServer"];
            tencentServer = string.IsNullOrEmpty(tencentServer) ? "https://yun.tim.qq.com/v5/tlssmssvr/sendsms?sdkappid={0}&random={1}" : tencentServer;

            int _tencentTemplateID = 261875;
            string tencentTemplateIDStr = ConfigurationManager.AppSettings["tencentTemplateID"];
            if (!string.IsNullOrEmpty(tencentTemplateIDStr))
            {
                int.TryParse(tencentTemplateIDStr, out _tencentTemplateID);
            }
            tencentTemplateID = _tencentTemplateID;

            bool _IsAdminSite = false;
            string IsAdminSiteStr = ConfigurationManager.AppSettings["IsAdminSite"];
            if (!string.IsNullOrEmpty(IsAdminSiteStr))
            {
                bool.TryParse(IsAdminSiteStr, out _IsAdminSite);
            }
            IsAdminSite = _IsAdminSite;

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

            int _LianJieTouSuServiceID = 0;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["LianJieTouSuServiceID"]))
            {
                int.TryParse(ConfigurationManager.AppSettings["LianJieTouSuServiceID"], out _LianJieTouSuServiceID);
            }
            LianJieTouSuServiceID = _LianJieTouSuServiceID;
        }
        public int LianJieTouSuServiceID { get; set; }
        public int BaoXiuServiceID { get; set; }
        public int YingXiaoTouSuServiceID { get; set; }
        public int WuYeTouSuServiceID { get; set; }
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
        /// 应用程序访问admin系统地址
        /// </summary>
        public string APIURL { get; set; }
        /// <summary>
        /// 短信服务器地址
        /// </summary>
        public string smsServer { get; set; }
        /// <summary>
        /// 短信用户ID
        /// </summary>
        public string smsUserID { get; set; }
        /// <summary>
        /// 短信服务帐号
        /// </summary>
        public string smsAccount { get; set; }
        /// <summary>
        /// 短息密码
        /// </summary>
        public string smsPassword { get; set; }
        /// <summary>
        /// 短信签名
        /// </summary>
        public string smsSign { get; set; }
        /// <summary>
        /// 在admin系统公司ID（仅限单机系统使用）
        /// </summary>
        public string ServerSiteID { get; set; }
        /// <summary>
        /// 员工端APP极光推送Key
        /// </summary>
        public string JPushKey_User { get; set; }
        /// <summary>
        /// 员工端APP极光推送密钥
        /// </summary>
        public string JPushMasterSecret_User { get; set; }
        public bool PaasSmsServerEnable { get; set; }

        /// <summary>
        /// Paas短信服务器地址
        /// </summary>
        public string PaasSmsServer { get; set; }
        /// <summary>
        /// Paas短信服务帐号
        /// </summary>
        public string PaasSms_UserName { get; set; }
        /// <summary>
        /// Paas短息密码
        /// </summary>
        public string PaasSms_Password { get; set; }
        /// <summary>
        /// 业主端APP极光推送Key
        /// </summary>
        public string JPushKey_Customer { get; set; }
        /// <summary>
        /// 业主端APP极光推送密钥
        /// </summary>
        public string JPushMasterSecret_Customer { get; set; }

        public bool IsMallOn { get; set; }

        public string LocalURL { get; set; }

        public string SystemName { get; set; }

        public bool IsFuShunJu { get; set; }

        public string JPushKey_Business { get; set; }

        public string JPushMasterSecret_Business { get; set; }
        public bool CanAPPUserRegister { get; set; }
        public bool IsWriteChequeOn { get; set; }
        public string Cheque_UserName { get; set; }
        public string Cheque_Password { get; set; }
        public string Cheque_QYSH { get; set; }
        public string Cheque_APPID { get; set; }
        public string Cheque_FLBM { get; set; }
        public bool IsAppUserLoginOn { get; set; }
        public int TotalRoomCount { get; set; }
        public string PreIndex { get; set; }
        public bool tencentSmsEnable { get; set; }
        public string tencentServer { get; set; }
        public int tencentTemplateID { get; set; }
        public string tencentAppID { get; set; }
        public string tencentAppKey { get; set; }
        public bool IsAdminSite { get; set; }
    }
}
