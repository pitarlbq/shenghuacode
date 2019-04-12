using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Utility
{
    public class HttpRequest
    {
        public static T DoPost<T>(Dictionary<string, object> postform, string postname, string apiurl = "", Encoding encoding = null)
        {
            T response;
            HttpWebRequest request = null;
            HttpWebResponse myResponse = null;
            try
            {
                apiurl = apiurl + postname;
                System.Net.ServicePointManager.DefaultConnectionLimit = 512;
                request = (HttpWebRequest)System.Net.HttpWebRequest.Create(apiurl);
                request.Timeout = 60000;
                request.KeepAlive = false;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                string postcontent = JsonConvert.SerializeObject(postform);
                string result = string.Empty;
                if (encoding == null)
                {
                    encoding = Encoding.UTF8;
                }
                byte[] postData = encoding.GetBytes(postcontent);
                Stream newStream = request.GetRequestStream();
                newStream.Write(postData, 0, postData.Length);
                newStream.Flush();
                newStream.Close();
                myResponse = (HttpWebResponse)request.GetResponse();
                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader sr = new StreamReader(myResponse.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                if (!string.IsNullOrEmpty(result))
                {
                    response = JsonConvert.DeserializeObject<T>(result);
                    return response;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (myResponse != null)
                {
                    myResponse.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return default(T);
        }
    }
}
