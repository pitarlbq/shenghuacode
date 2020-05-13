using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// Api 的摘要说明
    /// </summary>
    public class Api : NonAuthBaseHandler
    {

        const string LogModule = "APIHandler";
        private void savesmstemplateparam(HttpContext context)
        {
            string AddUserName = context.Request["AddUserName"];
            int SmsTemplateID = WebUtil.GetIntValue(context, "SmsTemplateID");
            var list = Utility.JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(context.Request["List"]);
            string errormsg = string.Empty;
            bool status = Sms_Tencent_Template.Save_SmsChargeRelationList(SmsTemplateID, list, ref errormsg, AddUserName);
            WebUtil.WriteJson(context, new { status = true, error = errormsg });
        }
        private void getsmstemplateparamlist(HttpContext context)
        {
            int SmsTemplateID = WebUtil.GetIntValue(context, "SmsTemplateID");
            var chargeList = new List<Dictionary<string, object>>();
            var list = Sms_Tencent_Template.GetSmsChargeRelationList(SmsTemplateID);
            WebUtil.WriteJson(context, new { status = true, errormsg = "OK", list = list, chargeList = chargeList });
        }
        private void deletesmstemplate(HttpContext context)
        {
            string ids = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Sms_Tencent_Template] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [Sms_Tencent_Params] where [SmsTemplateID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    throw ex;
                }
            }
            WebUtil.WriteJson(context, new { status = true, errormsg = "OK" });
        }
        private void getsmstemplatedata(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Sms_Tencent_Template data = null;
            if (ID > 0)
            {
                data = Sms_Tencent_Template.GetSms_Tencent_Template(ID);
                if (data != null)
                {
                    WebUtil.WriteJson(context, new { status = true, errormsg = "OK", data = data });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = false, errormsg = "无效的ID" });
        }
        private void savesmstemplate(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Sms_Tencent_Template data = null;
            if (ID > 0)
            {
                data = Sms_Tencent_Template.GetSms_Tencent_Template(ID);
            }
            if (data == null)
            {
                data = new Sms_Tencent_Template();
                data.AddTime = DateTime.Now;
                data.AddUserName = context.Request["AddUserName"];
            }
            data.TemplateID = context.Request["TemplateID"];
            data.TemplateSign = context.Request["TemplateSign"];
            data.TemplteTitle = context.Request["TemplteTitle"];
            data.ParamCount = WebUtil.GetIntValue(context, "ParamCount");
            data.TemplateContent = context.Request["TemplateContent"];
            data.TemplateRemark = context.Request["TemplateRemark"];
            data.TemplateType = WebUtil.GetIntValue(context, "TemplateType");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getsmstemplatelist(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            long startRowIndex = long.Parse(context.Request["startRowIndex"]);
            int pageSize = int.Parse(context.Request["pageSize"]);
            string errormsg = string.Empty;
            var dg = Sms_Tencent_Template_Ext.GetSms_Tencent_TemplateGrid(Keywords, startRowIndex, pageSize);
            WebUtil.WriteJson(context, new { status = true, errormsg = "OK", list = dg });
        }
        private void getcompanyparam(HttpContext context)
        {
            string errormsg = string.Empty;
            var data = Company.doGetCompanyParam(ref errormsg);
            bool status = true;
            if (data == null)
            {
                status = false;
            }
            WebUtil.WriteJson(context, new { status = status, errormsg = errormsg, data = data });
        }
        private void savecompanyparam(HttpContext context)
        {
            string allitems = context.Request["allitems"];
            var postItem = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(allitems))
            {
                postItem = Utility.JsonConvert.DeserializeObject<Dictionary<string, object>>(allitems);
            }
            string errormsg = string.Empty;
            bool status = false;
            if (postItem.Keys.Count > 0)
            {
                string SiteFullPath = context.Server.MapPath("~/");
                status = Foresight.DataAccess.Company.doChangeCompanyParam(postItem, SiteFullPath, ref errormsg);
            }
            WebUtil.WriteJson(context, new { status = status, errormsg = errormsg });
        }
    }
}