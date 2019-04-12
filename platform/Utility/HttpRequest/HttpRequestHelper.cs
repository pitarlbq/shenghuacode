using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class HttpRequestHelper
    {
        public static T DoPostData<T>(Dictionary<string,object> postdata, string postname, string apiurl = "")
        {
            T response = default(T);
            int i = 0;
            do
            {
                try
                {
                    response = Utility.HttpRequest.DoPost<T>(postdata, postname, apiurl: apiurl);
                    i++;
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("Utility.HttpRequestHelper.DoPostData." + postname, postname, ex);
                }
            } while (response == null && i <= 3);
            return response;
        }
    }
}
