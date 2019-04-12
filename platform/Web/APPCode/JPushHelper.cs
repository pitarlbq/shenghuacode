using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;

namespace Web.APPCode
{
    public class JPushHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ServiceID"></param>
        /// <param name="ErrorMsg"></param>
        /// <param name="title"></param>
        /// <param name="SendUserID"></param>
        /// <param name="SendUserName"></param>
        /// <param name="service"></param>
        /// <param name="AccpetUserType">1-通知接单人 2-通知处理人</param>
        /// <returns></returns>
        public static bool SendJpushMsgByServiceID(int ServiceID, out string ErrorMsg, string title = "", int SendUserID = 0, string SendUserName = "", Foresight.DataAccess.CustomerService service = null, List<int> ServiceAccpetManIDList = null, List<int> ServiceProcessManIDList = null, bool isReturnNotify = false)
        {
            ErrorMsg = "";
            var config = new Utility.SiteConfig();
            if (string.IsNullOrEmpty(config.JPushKey_User))
            {
                ErrorMsg = "推送未配置";
                return false;
            }
            if (service == null)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ServiceID);
            }
            if (service == null)
            {
                ErrorMsg = "ID不合法";
                return false;
            }
            string result = string.Empty;
            string result_push = string.Empty;
            string result_ios = string.Empty;
            #region 派单人推送
            if (service.ServiceStatus == 10 || service.ServiceStatus == 3)
            {
                if (ServiceAccpetManIDList == null)
                {
                    ServiceAccpetManIDList = Foresight.DataAccess.CustomerService_Accpet.GetCustomerService_AccpetListByServiceID(ServiceID, new int[] { 0, 1 }, AccpetUserType: 1).Select(p => p.AccpetManID).ToList();
                }
                if (ServiceAccpetManIDList.Count > 0)//待派单
                {
                    var users = Foresight.DataAccess.User.GetPushUserListByIDListByIDList(ServiceAccpetManIDList);
                    if (users.Length > 0)
                    {
                        Dictionary<string, object> extras = new Dictionary<string, object>();
                        string pushMsg = string.Empty;
                        if (isReturnNotify)
                        {
                            pushMsg = "您有新工单需要重新派单，请尽快处理";
                        }
                        var extra_model = new Utility.JpushContent(service.ServiceStatus, Msg: pushMsg, Type: "customerservice");
                        extras["code"] = extra_model.code;
                        extras["msg"] = extra_model.msg;
                        extras["type"] = extra_model.type;
                        extras["id"] = service.ID;
                        extras["status"] = service.ServiceStatus;
                        extras["isreturn"] = isReturnNotify;
                        var users_android = users.Where(p => p.APPUserDeviceType.Equals("android")).ToArray();
                        var users_ios = users.Where(p => p.APPUserDeviceType.Equals("ios")).ToArray();
                        string[] android_cids = new string[] { };
                        string[] ios_cids = new string[] { };
                        if (users_android.Length > 0)
                        {
                            android_cids = users_android.Select(p => p.APPUserDeviceID).ToArray();
                        }
                        if (users_ios.Length > 0)
                        {
                            ios_cids = users_ios.Select(p => p.APPUserDeviceID).ToArray();
                        }
                        result_push = JPush.JpushAPI.PushMessage(title, extras, android_cids, ios_cids, extra_model.msg);
                        Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result_push, 1, service.ID, true, title);
                    }
                }
            }
            #endregion
            #region 处理人推送
            if (service.ServiceStatus == 0)
            {
                if (ServiceProcessManIDList == null)
                {
                    ServiceProcessManIDList = Foresight.DataAccess.CustomerService_Accpet.GetCustomerService_AccpetListByServiceID(ServiceID, new int[] { 0, 1 }, AccpetUserType: 2).Select(p => p.AccpetManID).ToList();
                }
                if (ServiceProcessManIDList.Count > 0)//通知处理人
                {
                    var users = Foresight.DataAccess.User.GetPushUserListByIDListByIDList(ServiceProcessManIDList);
                    if (users.Length > 0)
                    {
                        Dictionary<string, object> extras = new Dictionary<string, object>();
                        var extra_model = new Utility.JpushContent(service.ServiceStatus, Type: "customerservice");
                        extras["code"] = extra_model.code;
                        extras["msg"] = extra_model.msg;
                        extras["type"] = extra_model.type;
                        extras["id"] = service.ID;
                        extras["status"] = service.ServiceStatus;
                        var users_android = users.Where(p => p.APPUserDeviceType.Equals("android")).ToArray();
                        var users_ios = users.Where(p => p.APPUserDeviceType.Equals("ios")).ToArray();
                        string[] android_cids = new string[] { };
                        string[] ios_cids = new string[] { };
                        if (users_android.Length > 0)
                        {
                            android_cids = users_android.Select(p => p.APPUserDeviceID).ToArray();
                        }
                        if (users_ios.Length > 0)
                        {
                            ios_cids = users_ios.Select(p => p.APPUserDeviceID).ToArray();
                        }
                        result_push = JPush.JpushAPI.PushMessage(title, extras, android_cids, ios_cids, extra_model.msg);
                        Foresight.DataAccess.JPushLog.Insert_JPushLog(android_cids, ios_cids, extras, result_push, 1, service.ID, true, title);
                    }
                }
            }
            #endregion
            service.IsAPPSend = true;
            service.SendUserID = SendUserID;
            service.SendUserName = SendUserName;
            service.APPSendTime = DateTime.Now;
            service.APPSendResult = result_push;
            service.Save();
            return true;
        }
    }
}