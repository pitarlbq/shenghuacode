using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPCode
{
    public class SocketNotify
    {
        public static string PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine type, int ID = 0, string url = "")
        {
            try
            {
                string domain_path = new Utility.SiteConfig().SITE_URL;
                url = string.IsNullOrEmpty(url) ? domain_path : url;
                JObject obj = new JObject();
                obj.Add("url", url);
                obj.Add("socketserver", "http://" + new Utility.SiteConfig().SocketURL);
                obj.Add("action", "notifyalert");
                obj.Add("type", type.ToString());
                obj.Add("ID", ID);
                obj.Add("systemtype", "platform");
                SocketIOClient.SocketClient.EmitMsg(obj);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }
    }
}