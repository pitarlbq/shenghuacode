using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Encript
{
    public class HttpRequest
    {
        static Encoding m_Encoding = Encoding.UTF8;
        public static string getAPIURL()
        {
            string apiURL = "http://120.77.144.50:10086/Handler/EncryptHandler.ashx";
            return apiURL;
        }
        public static string Get(Dictionary<string, string> queryparameter)
        {
            string apiurl = getAPIURL();
            if (queryparameter != null && queryparameter.Keys.Count > 0)
            {
                string querystr = string.Join("&", queryparameter.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)).ToArray());
                if (apiurl.EndsWith("?") || apiurl.EndsWith("&"))
                {
                    apiurl += querystr;
                }
                else if (apiurl.Contains("?"))
                {
                    apiurl += ("&" + querystr);
                }
                else
                {
                    apiurl += ("?" + querystr);
                }
            }

            var request = System.Net.HttpWebRequest.Create(apiurl);
            request.Method = "GET";

            var res = request.GetResponse();
            string result = null;

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            res.Close();
            return result;
        }
        public static string Post(Dictionary<string, string> queryparameter, Dictionary<string, string> postform, string apiurl = "", bool UrlEncode = false)
        {
            //string apiurl = getAPIURL();
            if (string.IsNullOrEmpty(apiurl))
            {
                apiurl = getAPIURL();
            }
            if (queryparameter != null && queryparameter.Keys.Count > 0)
            {
                string querystr = string.Join("&", queryparameter.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)).ToArray());
                if (apiurl.EndsWith("?") || apiurl.EndsWith("&"))
                {
                    apiurl += querystr;
                }
                else if (apiurl.Contains("?"))
                {
                    apiurl += ("&" + querystr);
                }
                else
                {
                    apiurl += ("?" + querystr);
                }
            }
            var request = System.Net.HttpWebRequest.Create(apiurl);
            request.Method = "POST";
            string postContent = string.Empty;
            if (postform != null)
            {
                postContent = string.Join("&", postform.Select(p => p.Key + "=" + p.Value).ToArray());
            }
            if (UrlEncode)
            {
                postContent = HttpUtility.UrlEncode(postContent, Encoding.Default);
            }
            byte[] buffer = Encoding.UTF8.GetBytes(postContent);
            request.ContentLength = buffer.Length;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            var reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Flush();

            var res = request.GetResponse();
            string result = null;

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            res.Close();
            return result;
        }
    }

    public class NameValue
    {
        public NameValue(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
