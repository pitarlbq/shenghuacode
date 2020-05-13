using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Utility;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Sms.V20190711;
using TencentCloud.Sms.V20190711.Models;

namespace Utility
{
    public class TencentSmsNew
    {
        public static bool SendTemplateNotifyMsg(string phoneNumber, List<string> paramList, ref string sendResult, string TemplateID = "", string sign = "")
        {
            return doPostSmsMethod(new string[] { phoneNumber }, paramList, TemplateID, ref sendResult, sign: sign);
        }
        public static bool doPostSmsMethod(string[] PhoneNumbers, List<string> paramList, string templateID, ref string sendResult, string sign = "")
        {
            try
            {
                var config = new Utility.SiteConfig();
                Credential cred = new Credential
                {
                    SecretId = config.tencentSecretId,
                    SecretKey = config.tencentSecretKey
                };

                ClientProfile clientProfile = new ClientProfile();
                HttpProfile httpProfile = new HttpProfile();
                httpProfile.Endpoint = ("sms.tencentcloudapi.com");
                clientProfile.HttpProfile = httpProfile;

                SmsClient client = new SmsClient(cred, "", clientProfile);
                SendSmsRequest req = new SendSmsRequest();
                PhoneNumbers = PhoneNumbers.Select(p =>
                {
                    return "+86" + p;
                }).ToArray();
                string strParams = "{\"PhoneNumberSet\":" + Utility.JsonConvert.SerializeObject(PhoneNumbers) + ",\"TemplateID\":\"" + templateID + "\",\"Sign\":\"" + sign + "\",\"TemplateParamSet\":" + Utility.JsonConvert.SerializeObject(paramList) + ",\"SmsSdkAppid\":\"" + config.tencentAppID + "\"}";
                req = SendSmsRequest.FromJsonString<SendSmsRequest>(strParams);
                SendSmsResponse resp = client.SendSmsSync(req);
                sendResult = Utility.JsonConvert.SerializeObject(resp);
                if (resp.SendStatusSet != null && resp.SendStatusSet.Length > 0 && resp.SendStatusSet[0].Code.ToLower().Equals("ok"))
                {
                    return true;
                }
                sendResult = Utility.JsonConvert.SerializeObject(resp);
                Utility.LogHelper.WriteInfo("Utility.TencentSms.doPostSmsMethod", sendResult);
                return false;
            }
            catch (Exception ex)
            {
                sendResult = ex.Message;
                LogHelper.WriteError("Utility.TencentSms", "doPostSmsMethod", ex);
                return false;
            }
        }
        /// <summary>
        /// 统计发送
        /// </summary>
        public static bool doPullSendStatus(DateTime StartTime, DateTime EndTime, ref int FeeCount, ref int RequestCount, ref int RequestSuccessCount)
        {
            try
            {
                var config = new Utility.SiteConfig();
                Credential cred = new Credential
                {
                    SecretId = config.tencentSecretId,
                    SecretKey = config.tencentSecretKey
                };

                ClientProfile clientProfile = new ClientProfile();
                HttpProfile httpProfile = new HttpProfile();
                httpProfile.Endpoint = ("sms.tencentcloudapi.com");
                clientProfile.HttpProfile = httpProfile;

                SmsClient client = new SmsClient(cred, "", clientProfile);
                SendStatusStatisticsRequest req = new SendStatusStatisticsRequest();
                string strParams = "{}";
                req = SendStatusStatisticsRequest.FromJsonString<SendStatusStatisticsRequest>(strParams);
                SendStatusStatisticsResponse resp = client.SendStatusStatisticsSync(req);
                if (resp.SendStatusStatistics != null)
                {
                    FeeCount = (int)resp.SendStatusStatistics.FeeCount;
                    RequestCount = (int)resp.SendStatusStatistics.RequestCount;
                    RequestSuccessCount = (int)resp.SendStatusStatistics.RequestSuccessCount;
                    return true;
                }
                Utility.LogHelper.WriteInfo("Utility.TencentSms.doPullSendStatus", Utility.JsonConvert.SerializeObject(resp));
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.TencentSms", "doPullSendStatus", ex);
                return false;
            }
        }
    }
}
