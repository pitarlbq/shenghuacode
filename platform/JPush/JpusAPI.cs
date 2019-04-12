using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using cn.jpush.api;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;

namespace JPush
{
    public class JpushAPI
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="extras"></param>
        /// <param name="android_cids"></param>
        /// <param name="ios_cids"></param>
        /// <param name="msg_content"></param>
        /// <param name="PushAPP">1-内部员工APP 2-业主端APP 3-商户端APP</param>
        /// <returns></returns>
        public static string PushMessage(string title, Dictionary<string, object> extras, string[] android_cids = null, string[] ios_cids = null, string msg_content = "", int PushAPP = 1, bool IsToAll = false)
        {
            string result = string.Empty;
            if (IsToAll)
            {
                string result1 = doPushMessage(title, extras, sendtype: "android", msg_content: msg_content, PushAPP: PushAPP, IsToAll: IsToAll);
                string result2 = doPushMessage(title, extras, sendtype: "ios", msg_content: msg_content, PushAPP: PushAPP, IsToAll: IsToAll);
                result = result1 + " | " + result2;
                return result;
            }
            if (android_cids == null && ios_cids == null)
            {
                return "没有接收用户";
            }
            if (android_cids != null && android_cids.Length > 0)
            {
                string result1 = doPushMessage(title, extras, android_cids, sendtype: "android", msg_content: msg_content, PushAPP: PushAPP);
                result = result1;
            }
            if (ios_cids != null && ios_cids.Length > 0)
            {
                string result2 = doPushMessage(title, extras, ios_cids, sendtype: "ios", msg_content: msg_content, PushAPP: PushAPP);
                if (string.IsNullOrEmpty(result))
                {
                    result = result2;
                }
                else
                {
                    result = result + " | " + result2;
                }
            }
            return result;
        }
        public static string doPushMessage(string title, Dictionary<string, object> extras, string[] cids = null, string sendtype = "android", string msg_content = "", int PushAPP = 1, bool IsToAll = false)
        {
            try
            {
                if (cids == null && !IsToAll)
                {
                    return "没有接收用户";
                }
                PushPayload pushPayload = new PushPayload();
                //pushPayload.notification = new Notification();
                if (IsToAll)
                {
                    pushPayload.audience = Audience.all();
                }
                else
                {
                    pushPayload.audience = Audience.s_registrationId(cids);
                }
                pushPayload.message = Message.content(msg_content);
                //pushPayload.message.setTitle(title);
                pushPayload.message.setContentType("text");
                foreach (var item in extras)
                {
                    pushPayload.message.AddExtras(item.Key, item.Value.ToString());
                }
                pushPayload.message.AddExtras("sound", "widget://res/newmessage.mp3");
                var notification = new Notification();
                notification.setAlert(msg_content);
                if (sendtype.Equals("android"))
                {
                    pushPayload.platform = Platform.android();
                    notification.AndroidNotification = new AndroidNotification();
                    //notification.AndroidNotification.setAlert(msg_content);
                    foreach (var item in extras)
                    {
                        notification.AndroidNotification.AddExtra(item.Key, item.Value.ToString());
                    }
                    notification.AndroidNotification.AddExtra("sound", "widget://res/newmessage.mp3");
                    //pushPayload.notification = notification;
                }
                else if (sendtype.Equals("ios"))
                {
                    pushPayload.platform = Platform.ios();
                    notification.IosNotification = new IosNotification();
                    notification.IosNotification.setBadge(1);
                    notification.IosNotification.setSound("widget://res/newmessage.mp3");
                    notification.IosNotification.setAlert(msg_content);
                    foreach (var item in extras)
                    {
                        notification.IosNotification.AddExtra(item.Key, item.Value.ToString());
                    }
                    pushPayload.notification = notification;
                }
                pushPayload.options.apns_production = true;
                pushPayload.options.time_to_live = 3600;
                var config = new Utility.SiteConfig();
                string key = string.Empty;
                string secret = string.Empty;
                if (PushAPP == 1)
                {
                    key = config.JPushKey_User;
                    secret = config.JPushMasterSecret_User;
                }
                else if (PushAPP == 2)
                {
                    key = config.JPushKey_Customer;
                    secret = config.JPushMasterSecret_Customer;
                }
                else if (PushAPP == 3)
                {
                    key = config.JPushKey_Business;
                    secret = config.JPushMasterSecret_Business;
                }
                var client = new JPushClient(key, secret);
                var response = client.SendPush(pushPayload);
                return "code:" + response.ResponseResult.responseCode + " content:" + response.ResponseResult.responseContent;
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("Jpush.JpushAPI", "PushMessage", ex);
                return ex.Message;
            }
        }
        public static string doPushMessageBak(string title, Dictionary<string, object> extras, string[] cids = null, string sendtype = "android", string msg_content = "", int PushAPP = 1, bool IsToAll = false)
        {
            try
            {
                if (cids == null && !IsToAll)
                {
                    return "没有接收用户";
                }
                PushPayload pushPayload = new PushPayload();
                pushPayload.notification = new Notification();
                if (IsToAll)
                {
                    pushPayload.audience = Audience.all();
                }
                else
                {
                    pushPayload.audience = Audience.s_registrationId(cids);
                }
                var notification = new Notification();
                notification.setAlert(extras["msg"].ToString());

                if (sendtype.Equals("android"))
                {
                    pushPayload.platform = Platform.android();
                    notification.AndroidNotification = new AndroidNotification();
                    foreach (var item in extras)
                    {
                        notification.AndroidNotification.AddExtra(item.Key, item.Value.ToString());
                    }
                    notification.AndroidNotification.AddExtra("sound", "widget://res/newmessage.mp3");
                    pushPayload.notification = notification;
                }
                else if (sendtype.Equals("ios"))
                {
                    pushPayload.platform = Platform.ios();
                    notification.IosNotification = new IosNotification();
                    notification.IosNotification.setBadge(1);
                    notification.IosNotification.setSound("default");
                    foreach (var item in extras)
                    {
                        notification.IosNotification.AddExtra(item.Key, item.Value.ToString());
                    }
                    notification.IosNotification.AddExtra("sound", "widget://res/newmessage.mp3");
                    pushPayload.notification = notification;
                    pushPayload.message = Message.content(msg_content);
                    pushPayload.message.setTitle(title);
                    pushPayload.message.setContentType("text");
                    foreach (var item in extras)
                    {
                        pushPayload.message.AddExtras(item.Key, item.Value.ToString());
                    }
                }

                pushPayload.options.apns_production = true;
                pushPayload.options.time_to_live = 3600;
                var config = new Utility.SiteConfig();
                string key = string.Empty;
                string secret = string.Empty;
                if (PushAPP == 1)
                {
                    key = config.JPushKey_User;
                    secret = config.JPushMasterSecret_User;
                }
                else if (PushAPP == 2)
                {
                    key = config.JPushKey_Customer;
                    secret = config.JPushMasterSecret_Customer;
                }
                var client = new JPushClient(key, secret);
                var response = client.SendPush(pushPayload);
                return "code:" + response.ResponseResult.responseCode + " content:" + response.ResponseResult.responseContent;
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("Jpush.JpushAPI", "PushMessage", ex);
                return ex.Message;
            }
        }
    }
}
