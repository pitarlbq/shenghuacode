/*
 *  Copyright (c) 2016 The KXTSMS project authors. All Rights Reserved.
 *
 * 说明：
 * 以下代码只是为了方便客户测试而提供的样例代码，客户可以根据自己网站的需要，按照技术文档自行编写,并非一定要使用该代码。
 * 该代码仅供学习和研究使用，只是提供一个参考。
 */
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace Utility
{
    /// <summary>
    /// 短信SDK
    /// </summary>
    public class KXTSms
    {
        public static bool Send(string mobile, string body)
        {
            string RestCount = "0";
            return Send(mobile, body, out RestCount);
        }
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">号码</param>
        /// <param name="body">短信内容</param>
        /// <returns></returns>
        public static bool Send(string mobile, string body, out string RestCount)
        {
            var config = new Utility.SiteConfig();
            string uriStr = config.smsServer;
            string userId = config.smsUserID;
            string account = config.smsAccount;
            string token = config.smsPassword;
            string sign = "【" + config.smsSign + "】";
            string result = GetResponse(uriStr, string.Format("action=send&userid={0}&account={1}&password={2}&mobile={3}&content={4}", userId, account, token, mobile, HttpUtility.UrlEncode(sign + body, Encoding.UTF8)), Encoding.UTF8, 50000);
            return getResultStatus(result, out RestCount);
        }
        public static void SendTest(string mobile, string body, out string result)
        {
            var config = new Utility.SiteConfig();
            string uriStr = config.smsServer;
            string userId = config.smsUserID;
            string account = config.smsAccount;
            string token = config.smsPassword;
            string sign = config.smsSign;
            result = GetResponse(uriStr, string.Format("action=send&userid={0}&account={1}&password={2}&mobile={3}&content={4}", userId, account, token, mobile, HttpUtility.UrlEncode(body, Encoding.UTF8)), Encoding.UTF8, 50000);
        }
        /// <summary>
        /// 获得网页请求
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="paramData">参数</param>
        /// <returns></returns>
        private static string GetResponse(string postUrl, string paramData, Encoding encoding, int timeOut = 50000)
        {
            string result = string.Empty;
            WebResponse wResponse = null;
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                Uri uri = new Uri(postUrl);
                byte[] byteArray = encoding.GetBytes(paramData); //转化
                HttpWebRequest wRequest = (HttpWebRequest)WebRequest.Create(uri);
                wRequest.Method = "POST";
                wRequest.ContentType = "application/x-www-form-urlencoded";
                wRequest.ContentLength = byteArray.Length;
                wRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.134 Safari/537.36";
                wRequest.Timeout = timeOut;
                stream = wRequest.GetRequestStream();
                stream.Write(byteArray, 0, byteArray.Length);//写入参数
                wResponse = (HttpWebResponse)wRequest.GetResponse();
                reader = new StreamReader(wResponse.GetResponseStream(), encoding);
                result = reader.ReadToEnd();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (wResponse != null)
                {
                    wResponse.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return result;
        }
        private static bool getResultStatus(string xmlstr, out string restCount)
        {
            string returnstatus = string.Empty;
            string message = string.Empty;
            restCount = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlstr);
            XmlNodeList topM = xmlDoc.SelectNodes("//returnsms");
            foreach (XmlElement element in topM)
            {
                returnstatus = element.GetElementsByTagName("returnstatus")[0].InnerText;
                message = element.GetElementsByTagName("message")[0].InnerText;
                restCount = element.GetElementsByTagName("remainpoint")[0].InnerText;
            }
            if (returnstatus.ToLower().Equals("success") && message.Equals("ok"))
            {
                return true;
            }
            return false;
        }
    }
}
