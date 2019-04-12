using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Utility
{
    /// <summary>
    /// 短信SDK
    /// </summary>
    public class PaasSms
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">号码</param>
        /// <param name="body">短信内容</param>
        /// <returns></returns>
        public static bool Send(string mobile, string body)
        {
            var config = new Utility.SiteConfig();
            string sign = "【" + config.smsSign + "】";
            string content = sign + HttpContext.Current.Server.UrlEncode(body);
            return doPostSmsMethod(mobile, content);
        }
        private static bool doPostSmsMethod(string phonenumber, string sendbody)
        {
            SmsModel sms = new SmsModel();
            try
            {
                var config = new Utility.SiteConfig();
                string serverUrl = config.PaasSmsServer;
                string result = String.Empty;
                string username = config.PaasSms_UserName;
                string password = config.PaasSms_Password;
                string postJsonTpl = "\"account\":\"{0}\",\"password\":\"{1}\",\"phone\":\"{2}\",\"report\":\"true\",\"msg\":\"{3}\"";
                string jsonBody = string.Format(postJsonTpl, username, password, phonenumber, sendbody);
                jsonBody = "{" + jsonBody + "}";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(serverUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                // Create NetworkCredential Object 
                NetworkCredential admin_auth = new NetworkCredential(username, password);

                // Set your HTTP credentials in your request header
                httpWebRequest.Credentials = admin_auth;

                // callback for handling server certificates
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

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
                var response = Utility.JsonConvert.DeserializeObject<PaasSmsResponse>(result);
                if (response.code.Equals("0"))
                {
                    return true;
                }
                LogHelper.WriteInfo("Utility.PaasSms.doPostSmsMethod", response.errorMsg);
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.PaasSms", "doPostSmsMethod", ex);
                return false;
            }
        }
    }
    public class SmsModel
    {
        public string Message { get; set; }
        public int Code { get; set; }
    }
    public class PaasSmsResponse
    {
        public string code { get; set; }
        public string msgId { get; set; }
        public string time { get; set; }
        public string errorMsg { get; set; }
    }
}
