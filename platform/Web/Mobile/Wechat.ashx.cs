using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Mobile
{
    /// <summary>
    /// Wechat 的摘要说明
    /// </summary>
    public class Wechat : IHttpHandler, IRequiresSessionState
    {
        const string LogModuel = "Mobile.Wechat";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Params["action"];
            if (string.IsNullOrEmpty(action))
            {
                LogHelper.WriteDebug(LogModuel, "action为空");
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "action为空");
                return;
            }
            action = action.ToLower();
            try
            {
                switch (action)
                {
                    case "savewxservice":
                        savewxservice(context);
                        break;
                    case "getprojecttreedata":
                        getprojecttreedata(context);
                        break;
                    case "gettypetreedata":
                        gettypetreedata(context);
                        break;
                    case "uploadimage":
                        uploadimage(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "action不合法");
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "action: " + action, ex);
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
            }
        }
        private void uploadimage(HttpContext context)
        {
            var results = new List<Dictionary<string, object>>();
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/CustomerService/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    var dic = new Dictionary<string, object>();
                    dic["FileOriName"] = System.IO.Path.GetFileName(fileOriName).ToLower();
                    dic["FilePath"] = filepath + fileName;
                    results.Add(dic);
                }
            }
            WebUtil.WriteJson(context, new { status = true, list = results });
        }
        private void gettypetreedata(HttpContext context)
        {
            int ParentID = WebUtil.GetIntValue(context, "ParentID");
            ParentID = ParentID > 0 ? ParentID : 1;
            var allTypes = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            var types = allTypes.Where(p => p.ParentID == ParentID).ToArray();
            var typeItems = types.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["id"] = p.ID;
                dic["name"] = p.ServiceTypeName;
                dic["parentid"] = p.ParentID;
                dic["hasparent"] = allTypes.Where(q => q.ParentID == p.ID).ToArray().Length > 0;
                return dic;
            }).ToList();
            WebUtil.WriteJsonResult(context, new { list = typeItems });
        }
        private void getprojecttreedata(HttpContext context)
        {
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            if (CompanyID == 0)
            {
                var companyList = Foresight.DataAccess.Company.GetCompanies().Where(p => !p.CompanyName.Equals("总部")).ToArray();
                var companyItems = companyList.Select(p =>
                {
                    var dic = new Dictionary<string, object>();
                    dic["id"] = p.CompanyID;
                    dic["name"] = p.CompanyName.Replace("公司", "");
                    dic["type"] = "company";
                    return dic;
                }).ToList();
                WebUtil.WriteJsonResult(context, new { list = companyItems });
                return;
            }
            var projectList = Foresight.DataAccess.Project.GetTopProjectListByCompanyID(CompanyID, 0);
            var projectItems = projectList.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["id"] = p.ID;
                dic["name"] = p.Name;
                dic["type"] = "project";
                return dic;
            }).ToList();
            WebUtil.WriteJsonResult(context, new { list = projectItems });
        }
        private void savewxservice(HttpContext context)
        {
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            if (ProjectID <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择项目");
                return;
            }
            var service = new Foresight.DataAccess.CustomerService();
            service.AddTime = DateTime.Now;
            service.AddMan = context.Request.Params["AddMan"];
            service.AddUserID = 0;
            service.IsSuggestion = WebUtil.GetBoolValue(context, "IsSuggestion");
            service.ServiceStatus = 3;
            service.ServiceFullName = context.Request["FullName"];
            service.ProjectID = ProjectID;
            service.ServiceType1ID = WebUtil.GetIntValue(context, "TypeID1");
            int TypeID2 = WebUtil.GetIntValue(context, "TypeID2");
            int TypeID3 = WebUtil.GetIntValue(context, "TypeID3");
            if (TypeID2 > 0)
            {
                service.ServiceType2ID = "[" + TypeID2 + "]";
            }
            if (TypeID3 > 0)
            {
                service.ServiceType3ID = "[" + TypeID3 + "]";
            }
            service.ProjectName = context.Request["ProjectName"];
            service.ServiceFullName = service.ProjectName;
            service.AddUserName = "WechatUser";
            service.StartTime = DateTime.Now;//反应时间
            int OrderNumberID = 0;
            string ServiceNumber = Foresight.DataAccess.CustomerService.GetLastestCustomerServiceNumber(Foresight.DataAccess.OrderTypeNameDefine.customerservice.ToString(), 0, out OrderNumberID);
            service.ServiceNumber = ServiceNumber;
            service.OrderNumberID = OrderNumberID;
            service.AddCustomerName = context.Request["AddCustomerName"];//反映人
            service.AddCallPhone = context.Request["PhoneNo"];//反映人联系电话
            service.ServiceContent = context.Request["Content"];
            service.ServiceAppointTime = WebUtil.GetDateValue(context, "AppointTime");
            service.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.weixin.ToString();
            List<Foresight.DataAccess.CustomerServiceAttach> attachlist = new List<Foresight.DataAccess.CustomerServiceAttach>();
            string FilePaths = context.Request["FilePaths"];
            List<Dictionary<string, object>> FilePathList = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(FilePaths))
            {
                FilePathList = Utility.JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(FilePaths);
            }
            HttpFileCollection uploadFiles = context.Request.Files;
            foreach (var item in FilePathList)
            {
                Foresight.DataAccess.CustomerServiceAttach attach = new Foresight.DataAccess.CustomerServiceAttach();
                attach.FileOriName = item["FileOriName"].ToString();
                attach.AttachedFilePath = item["FilePath"].ToString();
                attach.AddTime = DateTime.Now;
                attachlist.Add(attach);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    service.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.ServiceID = service.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: savewxservice", ex);
                    helper.Rollback();
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            if (!service.IsSuggestion)
            {
                string title = new Utility.SiteConfig().CompanyName;
                APPCode.SocketNotify.PushSocketNotifyAlert(EnumModel.SocketNotifyDefine.notifyservice, ID: service.ID);
            }
            else
            {
                string notify_msg = APPCode.SocketNotify.PushSocketNotifyAlert(EnumModel.SocketNotifyDefine.notifysuggestion, ID: service.ID);
            }
            WebUtil.WriteJsonResult(context, "Success");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}