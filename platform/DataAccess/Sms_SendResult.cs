using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Sms_SendResult.
    /// </summary>
    public partial class Sms_SendResult : EntityBase
    {
        public static bool Send_SmsTemplteMsg(List<int> IDList, DateTime StartTime, DateTime EndTime, int SmsTemplateID, int MyUserID, string Keywords, string ProjectName, int SendStatus, bool IsSelectAll, ref string error, int RestCount)
        {
            var dataList = ThirdCustomer.GetThirdCustomerListByIDList(Keywords, StartTime, EndTime, SendStatus, ProjectName, IDList, IsSelectAll);
            if (dataList.Length == 0)
            {
                error = "客户数据为空";
                return false;
            }
            var templateList = Sms_Tencent_Template.GetSms_Tencent_Templates().ToArray();
            if (SmsTemplateID > 0)
            {
                templateList = templateList.Where(p => p.ID == SmsTemplateID).ToArray();
            }
            if (templateList.Length == 0)
            {
                error = "选中的短信模板不存在";
                return false;
            }
            var templateParamList = Sms_Tencent_Param.GetSms_Tencent_Params().Where(p => (templateList.Select(q => q.ID).Contains(p.SmsTemplateID))).ToArray();

            bool sendStatus = false;
            var sendParamList = new List<Dictionary<string, object>>();
            int needSendCount = 0;
            foreach (var dataItem in dataList)
            {
                foreach (var item in templateList)
                {
                    var sendParamItem = new Dictionary<string, object>();
                    var myParamList = templateParamList.Where(p => p.SmsTemplateID == item.ID).Take(item.ParamCount).ToArray();
                    var paramList = new List<string>();
                    foreach (var myParamItem in myParamList)
                    {
                        if (myParamItem.ParamType == 203)//业主姓名
                        {
                            paramList.Add(dataItem.CustomerName);
                            continue;
                        }
                        if (myParamItem.ParamType == 204)//业主电话
                        {
                            paramList.Add(dataItem.PhoneNumber);
                            continue;
                        }
                        if (myParamItem.ParamType == 201)//项目名称
                        {
                            paramList.Add(dataItem.ProjectName);
                            continue;
                        }
                        if (myParamItem.ParamType == 202)//资源编号
                        {
                            paramList.Add(dataItem.RoomName);
                            continue;
                        }
                        if (myParamItem.ParamType == 101)//验证码
                        {
                            paramList.Add(Utility.Tools.GetVerifyCode());
                            continue;
                        }
                        if (myParamItem.ParamType == 102)//有效分钟
                        {
                            paramList.Add(myParamItem.ParamValue);
                            continue;
                        }
                    }
                    string sendResult = string.Empty;
                    sendParamItem["RelatePhoneNumber"] = dataItem.PhoneNumber;
                    sendParamItem["TemplateID"] = item.TemplateID;
                    sendParamItem["paramList"] = paramList;
                    sendParamItem["TemplateSign"] = item.TemplateSign;
                    sendParamItem["dataItem"] = dataItem;
                    sendParamList.Add(sendParamItem);
                    needSendCount += GetRealSmsCountByContent(item.TemplateContent, paramList);
                }
            }
            if (RestCount < needSendCount)
            {
                error = "短信余额不足，请先充值";
                return false;
            }
            var sendResultList = new List<Sms_SendResult>();
            var customerList = new List<ThirdCustomer>();
            foreach (var sendParamItem in sendParamList)
            {
                var dataItem = sendParamItem["dataItem"] as ThirdCustomer;
                string RelatePhoneNumber = sendParamItem["RelatePhoneNumber"].ToString();
                string TemplateID = sendParamItem["TemplateID"].ToString();
                var paramList = sendParamItem["paramList"] as List<string>;
                string TemplateSign = sendParamItem["TemplateSign"].ToString();
                string sendResult = string.Empty;
                bool status = Utility.TencentSmsNew.doPostSmsMethod(new string[] { RelatePhoneNumber }, paramList, TemplateID, ref sendResult, sign: TemplateSign);
                if (status)
                {
                    sendStatus = true;
                    dataItem.LastSendTime = DateTime.Now;
                    customerList.Add(dataItem);
                }
                var sendResultItem = new Sms_SendResult();
                sendResultItem.TemplateID = !string.IsNullOrEmpty(TemplateID) ? TemplateID : "无";
                sendResultItem.SendTime = DateTime.Now;
                sendResultItem.SendStatus = status ? 1 : 2;
                sendResultItem.SendResult = sendResult;
                sendResultItem.CustomerID = dataItem.ID;
                sendResultList.Add(sendResultItem);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var item in sendResultList)
                    {
                        item.Save(helper);
                    }
                    foreach (var item in customerList)
                    {
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("Sms_SendResult", "Save", ex);
                }
            }
            return sendStatus;
        }
        public static int GetRealSmsCountByContent(string content, List<string> paramList)
        {
            for (int i = 0; i < paramList.Count; i++)
            {
                content = content.Replace("{" + i + "}", paramList[i]);
            }
            int count = content.Length / 67;
            int rest = content.Length % 67;
            return count + (rest > 0 ? 1 : 0);
        }
    }
}
