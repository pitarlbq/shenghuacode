using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using Jiguang.JPush;
using Jiguang.JPush.Model;
using System.Collections.Generic;
using System.Configuration;

namespace JPush
{
    public class JpushClient
    {
        public static string PushMessage(string title, Dictionary<string, object> extras, List<string> cids, string sendtype = "android")
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.Notification = new Notification();
            pushPayload.Platform = sendtype;
            pushPayload.Audience = new Audience()
            {
                RegistrationId = cids
            };
            if (pushPayload.Platform.Equals("android"))
            {
                pushPayload.Notification.Android = new Android()
                {
                    Title = title,
                    Extras = extras
                };
            }
            else if (pushPayload.Platform.Equals("ios"))
            {
                pushPayload.Notification.IOS = new IOS()
                {
                    Badge = "+1",
                    Extras = extras
                };
            }
            pushPayload.Message = new Message()
            {
                Title = title,
                ContentType = "text",
                Extras = extras
            };
            pushPayload.Options = new Options
            {
                IsApnsProduction = false
            };
            var config = new Utility.SiteConfig();
            var client = new JPushClient(config.JPushKey_User, config.JPushMasterSecret_User);
            var response = client.SendPushAsync(pushPayload).Result;
            return response.Content;
        }
    }
}
