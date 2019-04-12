using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public class TencentSms
    {
        public static bool Send(string phoneNumber, string verifyCode)
        {
            return doPostSmsMethod(phoneNumber, verifyCode);
        }
        private static bool doPostSmsMethod(string phoneNumber, string verifyCode, int minute = 15)
        {
            SmsModel sms = new SmsModel();
            try
            {
                var config = new Utility.SiteConfig();
                string serverUrl = config.tencentServer;
                string random = Utility.Tools.GetRandomString(8);
                serverUrl = string.Format(serverUrl, config.tencentAppID, random);
                string result = String.Empty;
                long time = getCurrentTime();
                string sig = calculateSignature(phoneNumber, time, random);
                int tpl_id = config.tencentTemplateID;
                string postJsonTpl = "\"ext\":\"\",\"extend\":\"\",\"params\":[\"" + verifyCode + "\",\"" + minute + "\"],\"sig\":\"" + sig + "\",\"sign\":\"\",\"tel\":{\"mobile\":\"" + phoneNumber + "\",\"nationcode\":\"86\"},\"time\":" + time + ",\"tpl_id\":" + tpl_id + "";
                string jsonBody = "{" + postJsonTpl + "}";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(serverUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonBody);
                    streamWriter.Flush();
                    streamWriter.Close();
                    HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                var response = Utility.JsonConvert.DeserializeObject<TencentSmsResponse>(result);
                if (response.result == 0)
                {
                    return true;
                }
                LogHelper.WriteInfo("Utility.TencentSms.doPostSmsMethod", result);
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.TencentSms", "doPostSmsMethod", ex);
                return false;
            }
        }
        public static string calculateSignature(string phoneNumber, long time, string random)
        {
            string appkey = new SiteConfig().tencentAppKey;
            StringBuilder builder = new StringBuilder("appkey=")
                .Append(appkey)
                .Append("&random=")
                .Append(random)
                .Append("&time=")
                .Append(time)
                .Append("&mobile=")
                .Append(phoneNumber);

            return sha256(builder.ToString());
        }
        public static long getCurrentTime()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
        private static string sha256(string rawString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(rawString);
            byte[] hash = SHA256Managed.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }
            return builder.ToString().ToLower();
        }
    }
    public class TencentSmsResponse
    {
        public int result { get; set; }
        public string errmsg { get; set; }
        public string ext { get; set; }
        public int fee { get; set; }
        public string sid { get; set; }
    }
}
