using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Web.APPCode
{
    public class MasterBasePage : System.Web.UI.MasterPage
    {
        const string tokenkey = "1000";
        public string getToken()
        {
            string RandJsToken = ConfigurationManager.AppSettings["RandJsToken"];
            if (string.IsNullOrEmpty(RandJsToken))
            {
                RandJsToken = "yyyyMMdd";
            }
            return DateTime.Now.ToString(RandJsToken) + tokenkey;
        }
    }
}