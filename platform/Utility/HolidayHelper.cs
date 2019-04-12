using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Utility
{
    public class HolidayHelper
    {
        public static string GetHoliday(string date)
        {
            string result = string.Empty;
            try
            {
                string apiurl = "https://tool.bitefu.net/jiari/?d=" + date + "&info=1";
                var request = System.Net.HttpWebRequest.Create(apiurl);
                request.Method = "GET";
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                myResponse.Headers.Add("apikey", "jB22VnZCrdpAvAPHvl2SecsxAFu0XGlH");
                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader sr = new StreamReader(myResponse.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                return result;
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
