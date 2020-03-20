using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// ServiceHandler 的摘要说明
    /// </summary>
    public class ServiceHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("ServiceHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "savecustomerservice":
                        savecustomerservice(context);
                        break;
                    case "getserviceeditparams":
                        getserviceeditparams(context);
                        break;
                    case "getroominfo":
                        getroominfo(context);
                        break;
                    case "loadservicelist":
                        loadservicelist(context);
                        break;
                    case "saveservicechuli":
                        saveservicechuli(context);
                        break;
                    case "saveservicehuifang":
                        saveservicehuifang(context);
                        break;
                    case "saveservicebanjie":
                        saveservicebanjie(context);
                        break;
                    case "removeservice":
                        removeservice(context);
                        break;
                    case "deletefile":
                        deletefile(context);
                        break;
                    case "loaduserlist":
                        loaduserlist(context);
                        break;
                    case "loadstaticcolumn":
                        loadstaticcolumn(context);
                        break;
                    case "loadstaticlist":
                        loadstaticlist(context);
                        break;
                    case "loadserviceattachs":
                        loadserviceattachs(context);
                        break;
                    case "loadservicetypegrid":
                        loadservicetypegrid(context);
                        break;
                    case "saveservicetype":
                        saveservicetype(context);
                        break;
                    case "deleteservicetype":
                        deleteservicetype(context);
                        break;
                    case "removeservicematerial":
                        removeservicematerial(context);
                        break;
                    case "saveservicematerial":
                        saveservicematerial(context);
                        break;
                    case "cancelcustomerservice":
                        cancelcustomerservice(context);
                        break;
                    case "loadservicemateriallist":
                        loadservicemateriallist(context);
                        break;
                    case "completeservice":
                        completeservice(context);
                        break;
                    case "resendjpush":
                        resendjpush(context);
                        break;
                    case "getservicetaskparams":
                        getservicetaskparams(context);
                        break;
                    case "deletecomboboxservicetask":
                        deletecomboboxservicetask(context);
                        break;
                    case "savecomboboxservicetask":
                        savecomboboxservicetask(context);
                        break;
                    case "savewechatservice":
                        savewechatservice(context);
                        break;
                    case "getservicemgrparams":
                        getservicemgrparams(context);
                        break;
                    case "approvepayservice":
                        approvepayservice(context);
                        break;
                    case "getacceptuserlistbydepartmentid":
                        getacceptuserlistbydepartmentid(context);
                        break;
                    case "dosendcustomerservice":
                        dosendcustomerservice(context);
                        break;
                    case "closecustomerservice":
                        closecustomerservice(context);
                        break;
                    case "loadserviceprocesslist":
                        loadserviceprocesslist(context);
                        break;
                    case "loadservicecallbacklist":
                        loadservicecallbacklist(context);
                        break;
                    case "uploadvoicerecord":
                        uploadvoicerecord(context);
                        break;
                    case "loadservicerecordgrid":
                        loadservicerecordgrid(context);
                        break;
                    case "getservicetypelist":
                        getservicetypelist(context);
                        break;
                    case "doconfirmservice":
                        doconfirmservice(context);
                        break;
                    case "doreopenservice":
                        doreopenservice(context);
                        break;
                    case "gethomecountdata":
                        gethomecountdata(context);
                        break;
                    case "getuseraccpetparams":
                        getuseraccpetparams(context);
                        break;
                    case "checkservicecallbackstatus":
                        checkservicecallbackstatus(context);
                        break;
                    case "checkservicecompletestatus":
                        checkservicecompletestatus(context);
                        break;
                    case "checkismyservice":
                        checkismyservice(context);
                        break;
                    case "saveservicecallrate":
                        saveservicecallrate(context);
                        break;
                    case "domarkimportant":
                        domarkimportant(context);
                        break;
                    case "loadserviceanalysislist":
                        loadserviceanalysislist(context);
                        break;
                    case "domarknotcallback":
                        domarknotcallback(context);
                        break;
                    case "getmytimeoutservice":
                        getmytimeoutservice(context);
                        break;
                    case "savephonerecord":
                        savephonerecord(context);
                        break;
                    case "serviceimportapplication":
                        serviceimportapplication(context);
                        break;
                    case "serviceimportapprove":
                        serviceimportapprove(context);
                        break;
                    case "checkimportstatus":
                        checkimportstatus(context);
                        break;
                    case "saveservicetypeimportshixiao":
                        saveservicetypeimportshixiao(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:" + visit, ex);
                WebUtil.WriteJson(context, new { status = false });
            }
        }
        private void saveservicetypeimportshixiao(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.ServiceType_ImportShiXiao data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.ServiceType_ImportShiXiao.GetServiceType_ImportShiXiao(ID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.ServiceType_ImportShiXiao();
                data.AddTime = DateTime.Now;
                data.ServiceTypeID = ID;
            }
            data.PaiDanTime = WebUtil.getServerDecimalValue(context, "tdPaiDanTime");
            data.ResponseTime = WebUtil.getServerDecimalValue(context, "tdResponseTime");
            data.CheckTime = WebUtil.getServerDecimalValue(context, "tdCheckTime");
            data.ChuliTime = WebUtil.getServerDecimalValue(context, "tdChuliTime");
            data.BanJieTime = WebUtil.getServerDecimalValue(context, "tdBanJieTime");
            data.HuiFangTime = WebUtil.getServerDecimalValue(context, "tdHuiFangTime");
            data.GuanDanTime = WebUtil.getServerDecimalValue(context, "tdGuanDanTime");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void checkimportstatus(HttpContext context)
        {
            string IDs = context.Request["IDs"];
            var IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDs))
            {
                IDList = Utility.JsonConvert.DeserializeObject<List<int>>(IDs);
            }
            if (IDList.Count == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择一条任务工单" });
                return;
            }
            int type = WebUtil.GetIntValue(context, "type");
            var importantList = ServiceType_ImportantService.GetServiceType_ImportantServiceListByMinMaxServiceID(IDList.Min(), IDList.Max());
            var myImportantList = importantList.Where(p => IDList.Contains(p.ServiceID)).ToArray();
            if (type == 1)//重大报修标记
            {
                if (myImportantList.Length == 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "选中的任务没有申请记录，操作取消" });
                    return;
                }
                if (myImportantList.FirstOrDefault(p => p.ApproveStatus == 0) != null)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "选中的任务未审核，操作取消" });
                    return;
                }
                if (myImportantList.FirstOrDefault(p => p.ApproveStatus == 2) != null)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "选中的任务审核未通过，操作取消" });
                    return;
                }
            }
            else if (type == 2)//重大报修申请
            {
                if (myImportantList.FirstOrDefault(p => p.ApproveStatus == 0) != null)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "选中的任务未审核，操作取消" });
                    return;
                }
                if (myImportantList.FirstOrDefault(p => p.ApproveStatus == 1) != null)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "选中的任务已审核，操作取消" });
                    return;
                }
            }
            else if (type == 3)//重大报修审核
            {
                if (myImportantList.Length < IDList.Count)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "选中的任务没有申请记录，操作取消" });
                    return;
                }
                if (IDList.Count > 1)
                {
                    if (myImportantList.FirstOrDefault(p => p.ApproveStatus == 1) != null)
                    {
                        WebUtil.WriteJson(context, new { status = false, error = "选中的任务已审核，操作取消" });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        /// <summary>
        /// 重大任务审核
        /// </summary>
        private void serviceimportapprove(HttpContext context)
        {
            int status = WebUtil.GetIntValue(context, "status");
            string ApproveRemark = context.Request["Remark"];
            string ApproveUserName = WebUtil.GetUser(context).LoginName;
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            var importList = ServiceType_ImportantService.GetServiceType_ImportantServiceByServiceIDList(IDList.ToArray());
            if (importList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            var typeList = ServiceType.GetServiceTypes().ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ServiceID in IDList)
                    {
                        var important = importList.FirstOrDefault(p => p.ServiceID == ServiceID);
                        if (important == null)
                        {
                            WebUtil.WriteJson(context, new { status = false, error = "申请记录不存在" });
                            return;
                        }
                        important.ApproveStatus = status == 1 ? 1 : 2;
                        important.ApproveTime = DateTime.Now;
                        important.ApproveUserName = ApproveUserName;
                        important.ApproveRemark = ApproveRemark;
                        ServiceType_ImportantService.ApproveImportantService(typeList, important, helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: serviceimportapprove", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        /// <summary>
        /// 重大任务申请
        /// </summary>
        private void serviceimportapplication(HttpContext context)
        {
            string FilePath = string.Empty;
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
                    FilePath = filepath + fileName;
                }
            }
            int ApplicationType = WebUtil.GetIntValue(context, "ApplicationType");
            DateTime ReturnHomeDate = WebUtil.GetDateValue(context, "ReturnHomeDate");
            string ApplicationRemark = context.Request["Remark"];
            string ApplicationUserName = WebUtil.GetUser(context).LoginName;
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            var importList = ServiceType_ImportantService.GetServiceType_ImportantServiceByServiceIDList(IDList.ToArray());
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var ServiceID in IDList)
                    {
                        var important = importList.FirstOrDefault(p => p.ServiceID == ServiceID);
                        if (important == null)
                        {
                            important = new ServiceType_ImportantService();
                            important.ServiceID = ServiceID;
                            important.AddTime = DateTime.Now;
                        }
                        important.ApplicationType = ApplicationType;
                        important.ApproveStatus = 0;
                        important.ReturnHomeDate = ReturnHomeDate;
                        important.ApplicationTime = DateTime.Now;
                        important.ApplicationUserName = ApplicationUserName;
                        important.ApplicationFilePath = FilePath;
                        important.ApplicationRemark = ApplicationRemark;
                        important.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: serviceimportapplication", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }

        private void getmytimeoutservice(HttpContext context)
        {
            List<int> RoomIDList = new List<int>();
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            int[] CompanyIDList = new int[] { };
            List<int> TopProjectIDList = new List<int>();
            WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            string Keywords = context.Request.Params["Keywords"];
            string orderBy = " order by [AddTime] desc";
            bool getCount = WebUtil.GetIntValue(context, "getCount") == 1;
            bool canexport = false;
            if (getCount)
            {
                canexport = true;
            }
            var user = WebUtil.GetUser(context);
            bool canViewAll = WebUtil.Authorization(context, "1191180", user.UserID);
            bool canViewWechatAPPService = WebUtil.Authorization(context, "1191181", user.UserID);
            bool canViewWechatAPPSuggestoin = WebUtil.Authorization(context, "1191182", user.UserID);
            decimal BeforeBanJieTimeOutHour = WebUtil.GetDecimalValue(context, "BeforeBanJieTimeOutHour");
            DataGrid dg = Foresight.DataAccess.ViewCustomerService.GetMyChaoShiViewCustomerServiceList(Keywords, user.UserID, orderBy, startRowIndex, pageSize, canViewAll, RoomIDList, EqualProjectIDList: EqualProjectIDList, InProjectIDList: InProjectIDList, canViewWechatAPPService: canViewWechatAPPService, canViewWechatAPPSuggestoin: canViewWechatAPPSuggestoin, canexport: canexport, BeforeBanJieTimeOutHour: BeforeBanJieTimeOutHour);
            var list = dg.rows as ViewCustomerService[];
            if (!getCount)
            {
                WebUtil.WriteJson(context, dg);
                return;
            }
            WebUtil.WriteJson(context, new { status = true, chaoshicount = list.Length });
        }
        private void domarknotcallback(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            int status = WebUtil.GetIntValue(context, "status");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [CustomerService] set CanNotCallback=@CanNotCallback where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@CanNotCallback", status));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: domarknotcallback", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            var user = WebUtil.GetUser(context);
            string OperationTitle = status == 1 ? "工单暂不回访" : "工单取消暂不回访";
            string ServiceNumber = Foresight.DataAccess.CustomerService.GetCustomerServicNumbersByIDList(IDList);
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + ServiceNumber + "执行了" + OperationTitle + "标注操作";
            string key = EnumModel.OperationModule.ServiceCanNotCallBack.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, IDs, "Service", OperationMan: user.FinalRealName, IsHide: false);
            context.Response.Write("{\"status\":true}");
        }
        private void domarkimportant(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            int MinID = IDList.Min();
            int MaxID = IDList.Max();
            var list = ServiceType_ImportantService.GetServiceType_ImportantServiceListByMinMaxServiceID(MinID, MaxID);
            decimal PaiDanTime = WebUtil.getServerDecimalValue(context, "tdPaiDanTime");
            decimal ResponseTime = WebUtil.getServerDecimalValue(context, "tdResponseTime");
            decimal CheckTime = WebUtil.getServerDecimalValue(context, "tdCheckTime");
            decimal ChuliTime = WebUtil.getServerDecimalValue(context, "tdChuliTime");
            decimal BanJieTime = WebUtil.getServerDecimalValue(context, "tdBanJieTime");
            decimal HuiFangTime = WebUtil.getServerDecimalValue(context, "tdHuiFangTime");
            decimal GuanDanTime = WebUtil.getServerDecimalValue(context, "tdGuanDanTime");
            bool DisableHolidayTime = WebUtil.getServerIntValue(context, "tdDisableHolidayTime") == 1;
            bool DisableWorkOffTime = WebUtil.getServerIntValue(context, "tdDisableWorkOffTime") == 1;
            string StartHour = WebUtil.getServerValue(context, "tdStartHour");
            string EndHour = WebUtil.getServerValue(context, "tdEndHour");
            int isimport = WebUtil.GetIntValue(context, "isimport");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (isimport == 1)
                    {
                        string cmdtext = "update [CustomerService] set IsImportantTouSu=1 where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                    }
                    foreach (var ServiceID in IDList)
                    {
                        var data = list.FirstOrDefault(p => p.ServiceID == ServiceID);
                        if (data == null)
                        {
                            data = new ServiceType_ImportantService();
                            data.AddTime = DateTime.Now;
                            data.ServiceID = ServiceID;
                            data.ApproveStatus = 1;
                        }
                        data.PaiDanTime = PaiDanTime;
                        data.ResponseTime = ResponseTime;
                        data.CheckTime = CheckTime;
                        data.ChuliTime = ChuliTime;
                        data.BanJieTime = BanJieTime;
                        data.HuiFangTime = HuiFangTime;
                        data.GuanDanTime = GuanDanTime;
                        data.DisableHolidayTime = DisableHolidayTime;
                        data.DisableWorkOffTime = DisableWorkOffTime;
                        data.StartHour = StartHour;
                        data.EndHour = EndHour;
                        if (isimport == 0)
                        {
                            var serviceData = Foresight.DataAccess.CustomerService.GetCustomerService(ServiceID, helper);
                            if (serviceData != null)
                            {
                                DateTime BanJieDateTime = WebUtil.getServerTimeValue(context, "tdBanJieDateTime");
                                decimal myBanJieTime = 0;
                                if (BanJieDateTime > DateTime.MinValue && BanJieDateTime > serviceData.AddTime)
                                {
                                    myBanJieTime = (decimal)((BanJieDateTime - serviceData.AddTime).TotalSeconds) / 3600;
                                }
                                data.PaiDanTime = 0;
                                data.ResponseTime = 0;
                                data.CheckTime = 0;
                                data.ChuliTime = 0;
                                data.BanJieTime = myBanJieTime;
                                data.HuiFangTime = 0;
                                data.GuanDanTime = 0;
                                data.DisableHolidayTime = false;
                                data.StartHour = "";
                                data.EndHour = "";
                            }
                        }
                        data.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: domarkimportant", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            if (isimport == 1)
            {
                var user = WebUtil.GetUser(context);
                string OperationTitle = "工单重大投诉";
                string ServiceNumber = Foresight.DataAccess.CustomerService.GetCustomerServicNumbersByIDList(IDList);
                string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + ServiceNumber + "执行了重大投诉标注操作";
                string key = EnumModel.OperationModule.ServiceMoreImportant.ToString();
                APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, IDs, "Service", OperationMan: user.FinalRealName, IsHide: false);
            }
            context.Response.Write("{\"status\":true}");
        }
        private void saveservicecallrate(HttpContext context)
        {
            Foresight.DataAccess.CustomerService service = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            if (service == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择工单" });
                return;
            }
            service.HuiFangRate = WebUtil.getServerDecimalValue(context, "tdChuLiRate");
            service.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void checkservicecallbackstatus(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var IDList = new List<int>();
            IDList.Add(ID);
            string error = string.Empty;
            bool status = Foresight.DataAccess.CustomerService.CheckCanCallbackService(IDList, out error);
            WebUtil.WriteJson(context, new { status = status, error = error });
        }
        private void checkismyservice(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int UserID = WebUtil.GetIntValue(context, "UserID");
            bool status = Foresight.DataAccess.CustomerService.CheckIsMyService(ID, UserID);
            WebUtil.WriteJson(context, new { status = status });
        }
        private void checkservicecompletestatus(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var IDList = new List<int>();
            IDList.Add(ID);
            string error = string.Empty;
            bool status = Foresight.DataAccess.CustomerService.CheckCanCompleteService(IDList, out error);
            if (!status)
            {
                WebUtil.WriteJson(context, new { status = false, error = error });
                return;
            }
            var callBackList = CustomerServiceHuifang.GetCustomerServiceHuifangList(ID);
            WebUtil.WriteJson(context, new { status = true, callCount = callBackList.Length });
        }
        private void getuseraccpetparams(HttpContext context)
        {
            string results = string.Empty;
            int ID = WebUtil.GetIntValue(context, "ID");
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            ProjectID = ProjectID > 0 ? ProjectID : data.ProjectID;
            var accpetUserStaffList = Foresight.DataAccess.User.GetAccpetUserListByServiceProjectID(ProjectID, IsAccpetUser: true, ServerTypeID: data.ServiceType1ID);
            var processUserStaffList = Foresight.DataAccess.User.GetAccpetUserListByServiceProjectID(data.ProjectID, IsProcessUser: true, ServerTypeID: data.ServiceType1ID);
            var accpetUserStaffItems = accpetUserStaffList.Select(p =>
            {
                var item = new { ID = p.UserID, Name = p.FinalRealName };
                return item;
            }).ToList();
            var processUserStaffItems = processUserStaffList.Select(p =>
            {
                var item = new { ID = p.UserID, Name = p.FinalRealName };
                return item;
            }).ToList();
            var items = new { accpetUserStaffList = accpetUserStaffItems, processUserStaffList = processUserStaffItems };
            WebUtil.WriteJson(context, items);
        }
        private void gethomecountdata(HttpContext context)
        {
            int UserID = WebUtil.GetIntValue(context, "UserID");
            if (UserID <= 0)
            {
                UserID = WebUtil.GetUser(context).UserID;
            }
            int NormalSeatCount = 0;
            int InvalidSeatCount = 0;
            int ServiceCount = 0;
            int SuggestionCount = 0;
            int TotalInCallCount = 0;
            int TotalOutCallCount = 0;
            decimal TotalInCallMin = 0;
            decimal TotalOutCallMin = 0;
            PhoneRecord.GetHomeDataCount(UserID, out NormalSeatCount, out InvalidSeatCount, out ServiceCount, out SuggestionCount, out TotalInCallCount, out TotalOutCallCount, out TotalInCallMin, out TotalOutCallMin);
            WebUtil.WriteJson(context, new { status = true, NormalSeatCount = NormalSeatCount, InvalidSeatCount = InvalidSeatCount, ServiceCount = ServiceCount, SuggestionCount = SuggestionCount, TotalInCallCount = TotalInCallCount, TotalOutCallCount = TotalOutCallCount, TotalInCallMin = TotalInCallMin, TotalOutCallMin = TotalOutCallMin });
        }
        private void doreopenservice(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var user = WebUtil.GetUser(context);
            string error = string.Empty;
            bool status = Foresight.DataAccess.CustomerService.ReOpenCustomerService(ID, user.LoginName, user.UserID, out error);
            if (status)
            {
                var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
                string OperationTitle = "工单重新开单";
                string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + data.ServiceNumber + "执行了重新开单操作";
                string key = EnumModel.OperationModule.ServiceReOpen.ToString();
                APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, ID.ToString(), "Service", OperationMan: user.FinalRealName, IsHide: false);
            }
            WebUtil.WriteJson(context, new { status = status, error = error });
        }
        private void doconfirmservice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [CustomerService] set ConfirmStatus=1 where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: doconfirmservice", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
            var user = WebUtil.GetUser(context);
            string ServiceNumber = Foresight.DataAccess.CustomerService.GetCustomerServicNumbersByIDList(IDList);
            string OperationTitle = "工单审计";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + ServiceNumber + "执行了工单审计操作";
            string key = EnumModel.OperationModule.ServiceShenJi.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, IDs, "Service", OperationMan: user.FinalRealName, IsHide: false);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getservicetypelist(HttpContext context)
        {
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            string ParentIDs = context.Request["ParentIDList"];
            string[] ParentIDArray = new string[] { };
            if (!string.IsNullOrEmpty(ParentIDs))
            {
                ParentIDArray = Utility.JsonConvert.DeserializeObject<string[]>(ParentIDs);
            }
            List<int> ParentIDList = new List<int>();
            foreach (var ParentIDStr in ParentIDArray)
            {
                int ParentID = 0;
                if (!string.IsNullOrEmpty(ParentIDStr))
                {
                    int.TryParse(ParentIDStr, out ParentID);
                }
                if (ParentID > 0)
                {
                    ParentIDList.Add(ParentID);
                }
            }
            var types = Foresight.DataAccess.ServiceType.GetServiceTypes().Where(p => ParentIDList.Contains(p.ParentID)).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.ServiceTypeName };
                return item;
            }).ToList();
            types.Insert(0, new { ID = 0, Name = "请选择" });
            int level = WebUtil.GetIntValue(context, "level");
            var userStaffList = new Foresight.DataAccess.User[] { };
            var departmentList = new CKDepartment[] { };
            var userDepartmentList = new UserDepartment[] { };
            if (level == 2 && ParentIDList.Count > 0)
            {
                userStaffList = Foresight.DataAccess.User.GetAccpetUserListByServiceProjectID(ProjectID, IsAccpetUser: true, ServerTypeID: ParentIDList[0]);
                departmentList = CKDepartment.GetDepartmentListByUserIDList(userStaffList.Select(p => p.UserID).ToArray());

            }
            if (userStaffList.Length > 0)
            {
                int MinUserID = userStaffList.Min(p => p.UserID);
                int MaxUserID = userStaffList.Max(p => p.UserID);
                userDepartmentList = UserDepartment.GetUserDepartmentListByMinMaxUserID(MinUserID, MaxUserID);
            }
            var userStaffItems = userStaffList.Select(p =>
            {
                var myUserDepartment = userDepartmentList.FirstOrDefault(q => q.UserID == p.UserID);
                var item = new { ID = p.UserID, Name = p.FinalRealName, DepartmentID = myUserDepartment != null ? myUserDepartment.DepartmentID : 0 };
                return item;
            }).ToList();
            var departmentItems = departmentList.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.DepartmentName };
                return item;
            }).ToList();
            WebUtil.WriteJson(context, new { list = types, userStaffList = userStaffItems, departmentList = departmentItems });
        }
        private void loadservicerecordgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                int ServiceID = WebUtil.GetIntValue(context, "ServiceID");
                int PhoneType = WebUtil.GetIntValue(context, "PhoneType");
                var dg = Foresight.DataAccess.PhoneRecord.GetPhoneRecordGridByKeywords(StartTime, EndTime, ServiceID, "order by [CallTime] desc,AddTime desc", startRowIndex, pageSize, PhoneType);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令: loadservicerecordgrid", ex);
            }
        }
        private void savephonerecord(HttpContext context)
        {
            int RecordID = WebUtil.GetIntValue(context, "RecordID");
            string PhoneNumber = context.Request["ComingPhone"];
            PhoneRecord record = null;
            if (RecordID > 0)
            {
                record = PhoneRecord.GetPhoneRecord(RecordID);
            }
            if (record == null)
            {
                record = new PhoneRecord();
                record.AddTime = DateTime.Now;
                record.UserID = WebUtil.GetIntValue(context, "UserID");
                record.ServiceID = WebUtil.GetIntValue(context, "ServiceID");
                record.AddUserName = context.Request["AddUserName"];
                record.PhoneType = WebUtil.GetIntValue(context, "PhoneType");
                record.RelatedPhoneRecordID = WebUtil.GetIntValue(context, "RelatedPhoneRecordID");
            }
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                record.PhoneNumber = PhoneNumber;
            }
            if (record.CallTime == DateTime.MinValue)
            {
                DateTime CallTime = WebUtil.GetDateValue(context, "CallTime");
                record.CallTime = CallTime == DateTime.MinValue ? DateTime.Now : CallTime;
            }
            DateTime PickUpTime = WebUtil.GetDateValue(context, "PickUpTime");
            if (PickUpTime > DateTime.MinValue)
            {
                record.PickUpTime = PickUpTime;
            }
            DateTime HangUpTime = WebUtil.GetDateValue(context, "HangUpTime");
            if (HangUpTime > DateTime.MinValue)
            {
                record.HangUpTime = HangUpTime;
            }
            if (record.PhoneType <= 0)
            {
                Utility.LogHelper.WriteError("ServiceHandler.ashx", "savephonerecord", new Exception("error:PhoneType错误;source:" + context.Request["source"] + "data:" + Utility.JsonConvert.SerializeObject(record)));
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            if (record.CallTime == DateTime.MinValue)
            {
                Utility.LogHelper.WriteError("ServiceHandler.ashx", "savephonerecord", new Exception("error:CallTime错误;source:" + context.Request["source"] + "data:" + Utility.JsonConvert.SerializeObject(record)));
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            if (string.IsNullOrEmpty(record.PhoneNumber))
            {
                Utility.LogHelper.WriteError("ServiceHandler.ashx", "savephonerecord", new Exception("error:PhoneNumber错误;source:" + context.Request["source"] + "data:" + Utility.JsonConvert.SerializeObject(record)));
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            record.Save();
            WebUtil.WriteJson(context, new { status = true, RecordID = record.ID });
        }
        private void uploadvoicerecord(HttpContext context)
        {
            string RecordVoicePath = string.Empty;
            string fileName = string.Empty;
            string filepath = string.Empty;
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (!string.IsNullOrEmpty(fileOriName))
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    fileName = System.IO.Path.GetFileName(fileOriName);
                    filepath = "/upload/Record/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    RecordVoicePath = filepath + fileName;
                }
            }
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = context.Request["RecordName"];
            }
            if (string.IsNullOrEmpty(fileName))
            {
                WebUtil.WriteJson(context, "0");
                return;
            }
            int RecordID = WebUtil.GetIntValue(context, "RecordID");
            var record = PhoneRecord.GetPhoneRecord(RecordID);
            if (record == null)
            {
                WebUtil.WriteJson(context, "0");
                return;
            }
            record.RecordVoicePath = RecordVoicePath;
            record.FileOriName = fileName;
            record.Save();
            WebUtil.WriteJson(context, "1");
        }
        private void loadservicecallbacklist(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                string OrderBy = context.Request["OrderBy"];
                string SortOrder = " order by [AddTime] desc";
                int ServiceID = WebUtil.GetIntValue(context, "ServiceID");
                DataGrid dg = Foresight.DataAccess.CustomerServiceHuifang.GetCustomerServiceHuifangGridByKeywords(Keywords, ServiceID, SortOrder, startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:loadservicecallbacklist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadserviceprocesslist(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                string OrderBy = context.Request["OrderBy"];
                string SortOrder = " order by [AddTime] desc";
                int ServiceID = WebUtil.GetIntValue(context, "ServiceID");
                DataGrid dg = Foresight.DataAccess.CustomerServiceChuli.GetCustomerServiceChuliGridByKeywords(Keywords, ServiceID, SortOrder, startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:loadserviceprocesslist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void closecustomerservice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            string error = string.Empty;
            bool closeStatus = Foresight.DataAccess.CustomerService.CheckCanCloseService(IDList, out error);
            if (!closeStatus)
            {
                WebUtil.WriteJson(context, new { status = false, error = error });
                return;
            }
            string FilePath = string.Empty;
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
                    FilePath = filepath + fileName;
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [CustomerService] set IsClosed=1,[CloseTime]=getdate(),[ColseFilePath]='" + FilePath + "' where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: closecustomerservice", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            var user = WebUtil.GetUser(context);
            string ServiceNumber = Foresight.DataAccess.CustomerService.GetCustomerServicNumbersByIDList(IDList);
            string OperationTitle = "工单关单";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + ServiceNumber + "执行了工单关单操作";
            string key = EnumModel.OperationModule.ServiceClose.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, IDs, "Service", OperationMan: user.FinalRealName, IsHide: false);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void dosendcustomerservice(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            Foresight.DataAccess.CustomerService service = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            if (service == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择任务工单" });
                return;
            }
            if (!service.CanReSend)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择可以派单的任务工单" });
                return;
            }
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            int Status = WebUtil.GetIntValue(context, "Status");
            service.ProjectID = ProjectID;
            string ServiceAccpetManIDs = WebUtil.getServerValue(context, "tdAcceptManInput");
            List<int> ServiceAccpetManIDList = new List<int>();
            if (!string.IsNullOrEmpty(ServiceAccpetManIDs) && Status == 10)
            {
                if (!ServiceAccpetManIDs.StartsWith("["))
                {
                    ServiceAccpetManIDs = "[" + ServiceAccpetManIDs + "]";
                }
                ServiceAccpetManIDList = JsonConvert.DeserializeObject<List<int>>(ServiceAccpetManIDs);
            }
            string ServiceProcessManIDs = WebUtil.getServerValue(context, "tdServiceProcessManID");
            List<int> ServiceProcessManIDList = new List<int>();
            if (!string.IsNullOrEmpty(ServiceProcessManIDs) && Status == 3)
            {
                if (!ServiceProcessManIDs.StartsWith("["))
                {
                    ServiceProcessManIDs = "[" + ServiceProcessManIDs + "]";
                }
                ServiceProcessManIDList = JsonConvert.DeserializeObject<List<int>>(ServiceProcessManIDs);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    service.Save(helper);
                    List<int> AccpetManIDList1 = new List<int>();
                    List<int> AccpetManIDList2 = new List<int>();
                    foreach (var AccpetManID in ServiceAccpetManIDList)
                    {
                        var data = new CustomerService_Accpet();
                        data.ServiceID = service.ID;
                        data.AccpetManID = AccpetManID;
                        data.AddTime = DateTime.Now;
                        data.AccpetStatus = 0;
                        data.AccpetUserType = 1;
                        data.Save(helper);
                        AccpetManIDList1.Add(data.ID);
                    }
                    foreach (var AccpetManID in ServiceProcessManIDList)
                    {
                        var data = new CustomerService_Accpet();
                        data.ServiceID = service.ID;
                        data.AccpetManID = AccpetManID;
                        data.AddTime = DateTime.Now;
                        data.AccpetStatus = 0;
                        data.AccpetUserType = 2;
                        data.Save(helper);
                        AccpetManIDList2.Add(data.ID);
                    }
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ServiceID", service.ID));
                    if (AccpetManIDList1.Count > 0)
                    {
                        var conditions = new List<string>();
                        conditions.Add("[ServiceID]=@ServiceID");
                        conditions.Add("[AccpetUserType]=1");
                        conditions.Add("[ID] not in (" + string.Join(",", AccpetManIDList1.ToArray()) + ")");
                        helper.Execute("update [CustomerService_Accpet] set [AccpetStatus]=2 where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                    }
                    if (AccpetManIDList2.Count > 0)
                    {
                        var conditions = new List<string>();
                        conditions.Add("[ServiceID]=@ServiceID");
                        conditions.Add("[AccpetUserType]=2");
                        conditions.Add("[ID] not in (" + string.Join(",", AccpetManIDList2.ToArray()) + ")");
                        helper.Execute("update [CustomerService_Accpet] set [AccpetStatus]=2 where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                    }
                    if (ServiceProcessManIDList.Count > 0)
                    {
                        service.ServiceStatus = 0;
                    }
                    else if (ServiceAccpetManIDList.Count > 0)
                    {
                        service.ServiceStatus = 10;
                    }
                    service.Save(helper);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            string ErrorMsg = string.Empty;
            string title = new SiteConfig().CompanyName;
            //APP推送通知
            APPCode.JPushHelper.SendJpushMsgByServiceID(service.ID, out ErrorMsg, title: title, SendUserID: user.UserID, SendUserName: user.FinalRealName, service: service, ServiceAccpetManIDList: ServiceAccpetManIDList, ServiceProcessManIDList: ServiceProcessManIDList);
            string OperationTitle = "工单派单";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + service.ServiceNumber + "执行了派单操作";
            string key = EnumModel.OperationModule.ServicePaiDan.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, service.ID.ToString(), "Service", OperationMan: user.FinalRealName, IsHide: false);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getacceptuserlistbydepartmentid(HttpContext context)
        {
            int DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            var userlist = Foresight.DataAccess.User.GetAPPUserList(DepartmentID: DepartmentID);
            var items = userlist.Select(p =>
            {
                var item = new { UserID = p.UserID, RealName = p.FinalRealName };
                return item;
            }).ToList();
            WebUtil.WriteJson(context, new { status = true, users = items });
        }
        private void approvepayservice(HttpContext context)
        {
            string ids = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            int status = WebUtil.GetIntValue(context, "status");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [PayService] set Status=@status where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@status", status));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: approvepayservice", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void getservicemgrparams(HttpContext context)
        {
            var userlist = Foresight.DataAccess.User.GetAPPUserList();
            var items = userlist.Select(p =>
            {
                var item = new { UserID = p.UserID, RealName = p.RealName };
                return item;
            }).ToList();
            items.Insert(0, new { UserID = 0, RealName = "全部" });
            WebUtil.WriteJson(context, new { status = true, users = items });
        }
        private void savewechatservice(HttpContext context)
        {
            Foresight.DataAccess.Wechat_Service service = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                service = Foresight.DataAccess.Wechat_Service.GetWechat_Service(ID);
            }
            if (service == null)
            {
                service = new Foresight.DataAccess.Wechat_Service();
                service.AddTime = DateTime.Now;
                service.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.system.ToString();
            }
            service.FullName = getValue(context, "tdFullName");
            service.ServiceContent = getValue(context, "tdServiceContent");
            service.PhoneNumber = getValue(context, "tdPhoneNumber");
            service.ServiceAddTime = getTimeValue(context, "tdServiceAddTime");
            service.ServiceMan = getValue(context, "tdServiceMan");
            service.ServiceContent = getValue(context, "tdServiceContent");
            service.ServiceType = Utility.EnumModel.WechatServiceType.bsbx.ToString();
            List<Foresight.DataAccess.Wechat_ServiceImg> attachlist = new List<Foresight.DataAccess.Wechat_ServiceImg>();
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
                    Foresight.DataAccess.Wechat_ServiceImg attach = new Foresight.DataAccess.Wechat_ServiceImg();
                    attach.FileName = fileOriName;
                    attach.Icon = filepath + fileName;
                    attach.Medium = filepath + fileName;
                    attach.Large = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
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
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: savewechatservice", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecomboboxservicetask(HttpContext context)
        {
            string liststr = context.Request["list"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            List<Utility.BasicModel> list = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(liststr);
            foreach (var item in list)
            {
                Foresight.DataAccess.CustomerService_Task task = null;
                if (item.id > 0)
                {
                    task = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Task(item.id);
                }
                if (task == null)
                {
                    task = new CustomerService_Task();
                    task.AddTime = DateTime.Now;
                }
                task.TaskName = item.value;
                task.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletecomboboxservicetask(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.CustomerService.GetCustomerServiceListByParams(new int[] { ID });
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "任务标签使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.CustomerService_Task.DeleteCustomerService_Task(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getservicetaskparams(HttpContext context)
        {
            var task_list = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Tasks().OrderBy(p => p.ID).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.TaskName };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, task_list = task_list });

        }
        private void resendjpush(HttpContext context)
        {
            var config = new Utility.SiteConfig();
            if (string.IsNullOrEmpty(config.JPushKey_User))
            {
                WebUtil.WriteJson(context, new { status = false, error = "推送服务器未配置" });
                return;
            }
            string type = context.Request["type"];
            if (string.IsNullOrEmpty(type))
            {
                type = "customer_service";
            }
            if (!type.Equals("customer_service"))
            {
                WebUtil.WriteJson(context, "type不合法");
                return;
            }
            int ID = WebUtil.GetIntValue(context, "ID");
            string ErrorMsg = string.Empty;
            string title = new Utility.SiteConfig().CompanyName;
            var user = WebUtil.GetUser(context);
            bool result = APPCode.JPushHelper.SendJpushMsgByServiceID(ID, out ErrorMsg, title: title, SendUserID: user.UserID, SendUserName: user.FinalRealName);
            if (!result)
            {
                WebUtil.WriteJson(context, ErrorMsg);
                return;
            }
            WebUtil.WriteJson(context, "推送成功");
        }
        private void completeservice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            string BalanceStatus = context.Request["BalanceStatus"];
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [CustomerService] set BalanceStatus='" + BalanceStatus + "' where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: removeservice", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void loadservicemateriallist(HttpContext context)
        {
            try
            {
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                List<int> ProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
                }
                string BalanceStatus = context.Request.Params["BalanceStatus"];
                string PayStatusStr = context.Request.Params["PayStatus"];
                int PayStatus = int.MinValue;
                if (!string.IsNullOrEmpty(PayStatusStr))
                {
                    int.TryParse(PayStatusStr, out PayStatus);
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                DataGrid dg = Foresight.DataAccess.ViewCustomerServiceInDetail.GetViewCustomerServiceInDetailGridByKeywords(StartTime, EndTime, PayStatus, BalanceStatus, RoomIDList, ProjectIDList, "order by [ServiceID] desc,[ID] asc", startRowIndex, pageSize, UserID: WebUtil.GetUser(context).UserID, canexport: canexport);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadMaterialListData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:loadservicemateriallist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void cancelcustomerservice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            string FilePath = string.Empty;
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
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
                    FilePath = filepath + fileName;
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [CustomerService] set ServiceStatus=2,CancelFilePath='" + FilePath + "' where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: cancelcustomerservice", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            var user = WebUtil.GetUser(context);
            string ServiceNumber = Foresight.DataAccess.CustomerService.GetCustomerServicNumbersByIDList(IDList);
            string OperationTitle = "工单销单";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + ServiceNumber + "执行了销单操作";
            string key = EnumModel.OperationModule.ServiceXiaoDan.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, IDs, "Service", OperationMan: user.FinalRealName, IsHide: false);
            context.Response.Write("{\"status\":true}");
        }
        private void saveservicematerial(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            Foresight.DataAccess.CustomerService_Material material = null;
            if (ID > 0)
            {
                material = Foresight.DataAccess.CustomerService_Material.GetCustomerService_Material(ID);
            }
            if (material == null)
            {
                material = new Foresight.DataAccess.CustomerService_Material();
                material.CustomerServiceID = WebUtil.GetIntValue(context, "CustomerServiceID");
                material.AddTime = DateTime.Now;
            }
            material.MateralName = context.Request["MateralName"];
            material.UnitPrice = WebUtil.GetDecimalValue(context, "UnitPrice");
            material.TotalCount = WebUtil.GetIntValue(context, "TotalCount");
            material.TotalCost = WebUtil.GetDecimalValue(context, "TotalCost");
            material.GUID = context.Request["guid"];
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    material.Save(helper);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true, ID = material.ID });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ServiceHandler", "命令: saveservicematerial", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void removeservicematerial(HttpContext context)
        {
            string ids = context.Request["IDList"];
            List<int> IDlist = JsonConvert.DeserializeObject<List<int>>(ids);
            if (IDlist.Count > 0)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CustomerService_Material] where [ID] in (" + string.Join(",", IDlist) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ServiceHandler", "命令: removeservicematerial", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deleteservicetype(HttpContext context)
        {
            string ids = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            int serviceCount = Foresight.DataAccess.CustomerService.GetCustomerServiceCount(IDList);
            if (serviceCount > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "分类已被使用，删除操作取消" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [ServiceType] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: deleteservicetype", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            var user = WebUtil.GetUser(context);
            string OperationTitle = "工单类型删除";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单类型执行了删除操作";
            string key = EnumModel.OperationModule.ServiceTypeDel.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, ids, "ServiceType", OperationMan: user.FinalRealName, IsHide: true);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveservicetype(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ParentID = WebUtil.GetIntValue(context, "ParentID");
            string id = context.Request.Params["id"];
            string name = context.Request.Params["name"];
            string sortorder = context.Request.Params["sortorder"];
            Foresight.DataAccess.ServiceType data = null;
            if (ID > 0)
            {
                data = Foresight.DataAccess.ServiceType.GetServiceType(ID);
            }
            if (data == null)
            {
                data = new Foresight.DataAccess.ServiceType();
                data.AddTime = DateTime.Now;
                data.ParentID = ParentID;
            }
            data.ServiceTypeName = WebUtil.getServerValue(context, "tdServiceTypeName");
            data.PaiDanTime = WebUtil.getServerDecimalValue(context, "tdPaiDanTime");
            data.ResponseTime = WebUtil.getServerDecimalValue(context, "tdResponseTime");
            data.CheckTime = WebUtil.getServerDecimalValue(context, "tdCheckTime");
            data.ChuliTime = WebUtil.getServerDecimalValue(context, "tdChuliTime");
            data.BanJieTime = WebUtil.getServerDecimalValue(context, "tdBanJieTime");
            data.HuiFangTime = WebUtil.getServerDecimalValue(context, "tdHuiFangTime");
            data.GuanDanTime = WebUtil.getServerDecimalValue(context, "tdGuanDanTime");
            data.SortOrder = WebUtil.getServerIntValue(context, "tdSortOrder");
            data.DisableSend = WebUtil.getServerIntValue(context, "tdDisableSend") == 1;
            data.DisableProcee = WebUtil.getServerIntValue(context, "tdDisableProcee") == 1;
            data.DisableCompelte = WebUtil.getServerIntValue(context, "tdDisableCompelte") == 1;
            data.DisableCallback = WebUtil.getServerIntValue(context, "tdDisableCallback") == 1;
            data.DisableShenJi = WebUtil.getServerIntValue(context, "tdDisableShenJi") == 1;
            data.CloseServiceType = WebUtil.getServerIntValue(context, "tdCloseServiceType");
            data.GongDanType = WebUtil.getServerIntValue(context, "tdGongDanType");
            data.CallBackServiceType = WebUtil.getServerIntValue(context, "tdCallBackServiceType");
            data.BanJieServiceType = WebUtil.getServerIntValue(context, "tdBanJieServiceType");
            data.DisableHolidayTime = WebUtil.getServerIntValue(context, "tdDisableHolidayTime") == 1;
            data.DisableWorkOffTime = WebUtil.getServerIntValue(context, "tdDisableWorkOffTime") == 1;
            data.StartHour = WebUtil.getServerValue(context, "tdStartHour");
            data.EndHour = WebUtil.getServerValue(context, "tdEndHour");
            data.Save();
            var user = WebUtil.GetUser(context);
            string OperationTitle = "工单类型修改";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单类型" + data.ServiceTypeName + "执行了修改操作";
            string key = EnumModel.OperationModule.ServiceTypeEdit.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, data.ID.ToString(), "ServiceType", OperationMan: user.FinalRealName, IsHide: true);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadservicetypegrid(HttpContext context)
        {
            try
            {
                var keywords = context.Request["keywords"];
                var list = Foresight.DataAccess.ServiceType.GetServiceTypeGridByKeywords(keywords);
                DataGrid dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Count;
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令: loadservicetypegrid", ex);
            }
        }
        private void loadserviceattachs(HttpContext context)
        {
            int ID = int.Parse(context.Request.Params["ID"]);
            var list = Foresight.DataAccess.CustomerServiceAttach.GetCustomerServiceAttachList(ID);
            var items = list.Select(p =>
            {
                var dic = p.ToJsonObject();
                dic["AttachedFilePath"] = string.IsNullOrEmpty(p.AttachedFilePath) ? string.Empty : WebUtil.GetContextPath() + p.AttachedFilePath;
                return dic;
            });
            WebUtil.WriteJson(context, items);
        }
        private void loadstaticlist(HttpContext context)
        {
            string ServiceType = context.Request["ServiceType"];
            if (ServiceType.Equals("servicecategory"))
            {
                loadstaticlistbyservicecategory(context);
                return;
            }
            if (ServiceType.Equals("tasktype"))
            {
                loadstaticlistbytasktype(context);
                return;
            }
            if (ServiceType.Equals("accpetman"))
            {
                loadstaticlistbyaccpetman(context);
                return;
            }
        }
        private void loadstaticlistbyaccpetman(HttpContext context)
        {
            DateTime StartTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
            DateTime EndTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
            var userList = Foresight.DataAccess.User.GetAPPUserList();
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.Append("\"total\":" + userList.Length + ",");
            builder.Append("\"rows\":[");
            int i = 0;
            var list = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            foreach (var user in userList)
            {
                builder.Append("{");
                builder.Append("\"接单人\":\"" + user.RealName + "\"");
                var countList = Foresight.DataAccess.CustomerServiceStatic.GetCustomerServiceStaticCountByServiceType(StartTime, EndTime, 0, user.UserID);
                if (list.Length > 0)
                {
                    builder.Append(",");
                    int total = 0;
                    int completeCount = 0;
                    foreach (var model in list)
                    {
                        var item = countList.FirstOrDefault(p => p.ID == model.ID);
                        if (item == null)
                        {
                            builder.Append("\"" + model.ID + "_jiedandengji\":0,");
                            builder.Append("\"" + model.ID + "_chulizhong\":0,");
                            builder.Append("\"" + model.ID + "_yiwancheng\":0,");
                            builder.Append("\"" + model.ID + "_yihuifang\":0,");
                            builder.Append("\"" + model.ID + "_wanchenglv\":\"--\",");
                        }
                        else
                        {
                            item.TotalCount = item.TotalCount > 0 ? item.TotalCount : 0;
                            item.jiedandengji_count = item.jiedandengji_count > 0 ? item.jiedandengji_count : 0;
                            item.chulizhong_count = item.chulizhong_count > 0 ? item.chulizhong_count : 0;
                            item.yiwancheng_count = item.yiwancheng_count > 0 ? item.yiwancheng_count : 0;
                            item.yihuifang_count = item.yihuifang_count > 0 ? item.yihuifang_count : 0;
                            builder.Append("\"" + item.ID + "_jiedandengji\":" + item.jiedandengji_count + ",");
                            builder.Append("\"" + item.ID + "_chulizhong\":" + item.chulizhong_count + ",");
                            builder.Append("\"" + item.ID + "_yiwancheng\":" + item.yiwancheng_count + ",");
                            builder.Append("\"" + item.ID + "_yihuifang\":" + item.yihuifang_count + ",");
                            string completePer = "--";
                            if ((decimal)item.TotalCount > 0)
                            {
                                completePer = Math.Round((decimal)(item.yiwancheng_count / (decimal)item.TotalCount) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                            }
                            builder.Append("\"" + item.ID + "_wanchenglv\":\"" + completePer + "\",");
                            total += item.TotalCount;
                            completeCount += item.yiwancheng_count;
                        }
                    }
                    string closePer = "--";
                    if ((decimal)total > 0)
                    {
                        closePer = Math.Round((decimal)(completeCount / (decimal)total) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    builder.Append("\"总量\":\"" + total + "\",");
                    builder.Append("\"完成率\":\"" + closePer + "\"");
                }
                if (i == (userList.Length - 1))
                {
                    builder.Append("}");
                }
                else
                {
                    builder.Append("},");
                }
                i++;
            }
            builder.Append("]}");
            string tables = builder.ToString();
            context.Response.Write(tables);
        }
        private void loadstaticlistbytasktype(HttpContext context)
        {
            DateTime StartTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
            DateTime EndTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
            var projectList = Foresight.DataAccess.Project.GetProjectByParentID(1);
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.Append("\"total\":" + projectList.Length + ",");
            builder.Append("\"rows\":[");
            int i = 0;
            var list = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Tasks().ToArray();
            foreach (var project in projectList)
            {
                builder.Append("{");
                builder.Append("\"项目\":\"" + project.Name + "\"");
                var countList = Foresight.DataAccess.CustomerServiceStatic.GetCustomerServiceStaticCountByTaskType(project.ID, StartTime, EndTime);
                if (list.Length > 0)
                {
                    builder.Append(",");
                    int total = 0;
                    int completeCount = 0;
                    foreach (var model in list)
                    {
                        var item = countList.FirstOrDefault(p => p.ID == model.ID);
                        if (item == null)
                        {
                            builder.Append("\"" + model.ID + "_jiedandengji\":0,");
                            builder.Append("\"" + model.ID + "_chulizhong\":0,");
                            builder.Append("\"" + model.ID + "_yiwancheng\":0,");
                            builder.Append("\"" + model.ID + "_yihuifang\":0,");
                            builder.Append("\"" + model.ID + "_wanchenglv\":\"--\",");
                        }
                        else
                        {
                            item.TotalCount = item.TotalCount > 0 ? item.TotalCount : 0;
                            item.jiedandengji_count = item.jiedandengji_count > 0 ? item.jiedandengji_count : 0;
                            item.chulizhong_count = item.chulizhong_count > 0 ? item.chulizhong_count : 0;
                            item.yiwancheng_count = item.yiwancheng_count > 0 ? item.yiwancheng_count : 0;
                            item.yihuifang_count = item.yihuifang_count > 0 ? item.yihuifang_count : 0;
                            builder.Append("\"" + item.ID + "_jiedandengji\":" + item.jiedandengji_count + ",");
                            builder.Append("\"" + item.ID + "_chulizhong\":" + item.chulizhong_count + ",");
                            builder.Append("\"" + item.ID + "_yiwancheng\":" + item.yiwancheng_count + ",");
                            builder.Append("\"" + item.ID + "_yihuifang\":" + item.yihuifang_count + ",");
                            string completePer = "--";
                            if ((decimal)item.TotalCount > 0)
                            {
                                completePer = Math.Round((decimal)(item.yiwancheng_count / (decimal)item.TotalCount) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                            }
                            builder.Append("\"" + item.ID + "_wanchenglv\":\"" + completePer + "\",");
                            total += item.TotalCount;
                            completeCount += item.yiwancheng_count;
                        }
                    }
                    string closePer = "--";
                    if ((decimal)total > 0)
                    {
                        closePer = Math.Round((decimal)(completeCount / (decimal)total) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    builder.Append("\"总量\":\"" + total + "\",");
                    builder.Append("\"完成率\":\"" + closePer + "\"");
                }
                if (i == (projectList.Length - 1))
                {
                    builder.Append("}");
                }
                else
                {
                    builder.Append("},");
                }
                i++;
            }
            builder.Append("]}");
            string tables = builder.ToString();
            context.Response.Write(tables);
        }
        private void loadstaticlistbyservicecategory(HttpContext context)
        {
            DateTime StartTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
            DateTime EndTime = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
            var projectList = Foresight.DataAccess.Project.GetProjectByParentID(1);
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.Append("\"total\":" + projectList.Length + ",");
            builder.Append("\"rows\":[");
            int i = 0;
            var list = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            foreach (var project in projectList)
            {
                builder.Append("{");
                builder.Append("\"项目\":\"" + project.Name + "\"");
                var countList = Foresight.DataAccess.CustomerServiceStatic.GetCustomerServiceStaticCountByServiceType(StartTime, EndTime, project.ID, 0);
                if (list.Length > 0)
                {
                    builder.Append(",");
                    int total = 0;
                    int completeCount = 0;
                    foreach (var model in list)
                    {
                        var item = countList.FirstOrDefault(p => p.ID == model.ID);
                        if (item == null)
                        {
                            builder.Append("\"" + model.ID + "_jiedandengji\":0,");
                            builder.Append("\"" + model.ID + "_chulizhong\":0,");
                            builder.Append("\"" + model.ID + "_yiwancheng\":0,");
                            builder.Append("\"" + model.ID + "_yihuifang\":0,");
                            builder.Append("\"" + model.ID + "_wanchenglv\":\"--\",");
                        }
                        else
                        {
                            item.TotalCount = item.TotalCount > 0 ? item.TotalCount : 0;
                            item.jiedandengji_count = item.jiedandengji_count > 0 ? item.jiedandengji_count : 0;
                            item.chulizhong_count = item.chulizhong_count > 0 ? item.chulizhong_count : 0;
                            item.yiwancheng_count = item.yiwancheng_count > 0 ? item.yiwancheng_count : 0;
                            item.yihuifang_count = item.yihuifang_count > 0 ? item.yihuifang_count : 0;
                            builder.Append("\"" + item.ID + "_jiedandengji\":" + item.jiedandengji_count + ",");
                            builder.Append("\"" + item.ID + "_chulizhong\":" + item.chulizhong_count + ",");
                            builder.Append("\"" + item.ID + "_yiwancheng\":" + item.yiwancheng_count + ",");
                            builder.Append("\"" + item.ID + "_yihuifang\":" + item.yihuifang_count + ",");
                            string completePer = "--";
                            if ((decimal)item.TotalCount > 0)
                            {
                                completePer = Math.Round((decimal)(item.yiwancheng_count / (decimal)item.TotalCount) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                            }
                            builder.Append("\"" + item.ID + "_wanchenglv\":\"" + completePer + "\",");
                            total += item.TotalCount;
                            completeCount += item.yiwancheng_count;
                        }
                    }
                    string closePer = "--";
                    if ((decimal)total > 0)
                    {
                        closePer = Math.Round((decimal)(completeCount / (decimal)total) * 100, 2, MidpointRounding.AwayFromZero) + "%";
                    }
                    builder.Append("\"总量\":\"" + total + "\",");
                    builder.Append("\"完成率\":\"" + closePer + "\"");
                }
                if (i == (projectList.Length - 1))
                {
                    builder.Append("}");
                }
                else
                {
                    builder.Append("},");
                }
                i++;
            }
            builder.Append("]}");
            string tables = builder.ToString();
            context.Response.Write(tables);
        }
        private void loadstaticcolumn(HttpContext context)
        {
            string ServiceType = context.Request["ServiceType"];
            if (ServiceType.Equals("servicecategory"))
            {
                loadstaticcolumnbyservicecategory(context);
                return;
            }
            if (ServiceType.Equals("tasktype"))
            {
                loadstaticcolumnbytasktype(context);
                return;
            }
            if (ServiceType.Equals("accpetman"))
            {
                loadstaticcolumnbyaccpetman(context);
                return;
            }
        }
        private void loadstaticcolumnbyaccpetman(HttpContext context)
        {
            var list = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            StringBuilder columns = new StringBuilder("[[");
            string ColumnField = "field: '接单人', title: '接单人', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            StringBuilder sub_columns = new StringBuilder("],[");
            for (int i = 0; i < list.Length; i++)
            {
                var item = list[i];
                sub_columns.Append("{field: '" + item.ID + "_jiedandengji', title: '接单登记', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_chulizhong', title: '处理中', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yiwancheng', title: '已完成', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yihuifang', title: '已回访', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_wanchenglv', title: '完成率', width: 60},");
                columns.Append("{title: '" + item.ServiceTypeName + "', colspan: 5 },");
            }
            ColumnField = "field: '总量', formatter: formatCount, title: '总量', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            ColumnField = "field: '完成率', title: '完成率', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            columns.Append(sub_columns.ToString());
            columns.Append("]]");
            var items = new
            {
                status = list.Length > 0 ? true : false,
                columns = columns.ToString(),
            };
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void loadstaticcolumnbytasktype(HttpContext context)
        {
            var list = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Tasks().ToArray();
            StringBuilder columns = new StringBuilder("[[");
            string ColumnField = "field: '项目', title: '项目', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            StringBuilder sub_columns = new StringBuilder("],[");
            for (int i = 0; i < list.Length; i++)
            {
                var item = list[i];
                sub_columns.Append("{field: '" + item.ID + "_jiedandengji', title: '接单登记', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_chulizhong', title: '处理中', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yiwancheng', title: '已完成', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yihuifang', title: '已回访', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_wanchenglv', title: '完成率', width: 60},");
                columns.Append("{title: '" + item.TaskName + "', colspan: 5 },");
            }
            ColumnField = "field: '总量', formatter: formatCount, title: '总量', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            ColumnField = "field: '完成率', title: '完成率', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            columns.Append(sub_columns.ToString());

            columns.Append("]]");
            var items = new
            {
                status = list.Length > 0 ? true : false,
                columns = columns.ToString(),
            };
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void loadstaticcolumnbyservicecategory(HttpContext context)
        {
            var list = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            StringBuilder columns = new StringBuilder("[[");
            string ColumnField = "field: '项目', title: '项目', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            StringBuilder sub_columns = new StringBuilder("],[");
            for (int i = 0; i < list.Length; i++)
            {
                var item = list[i];
                sub_columns.Append("{field: '" + item.ID + "_jiedandengji', title: '接单登记', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_chulizhong', title: '处理中', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yiwancheng', title: '已完成', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_yihuifang', title: '已回访', width: 60},");
                sub_columns.Append("{field: '" + item.ID + "_wanchenglv', title: '完成率', width: 60},");
                columns.Append("{title: '" + item.ServiceTypeName + "', colspan: 5 },");
            }
            ColumnField = "field: '总量', formatter: formatCount, title: '总量', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            ColumnField = "field: '完成率', title: '完成率', width: 100, rowspan: 2";
            columns.Append("{" + ColumnField + "},");
            columns.Append(sub_columns.ToString());

            columns.Append("]]");
            var items = new
            {
                status = list.Length > 0 ? true : false,
                columns = columns.ToString(),
            };
            context.Response.Write(JsonConvert.SerializeObject(items));
        }
        private void loaduserlist(HttpContext context)
        {
            var list = Foresight.DataAccess.User.GetSysUserList();
            var dic = new Dictionary<string, object>();
            var userList = list.Select(p =>
            {
                dic = new Dictionary<string, object>();
                dic["UserID"] = p.UserID;
                dic["RealName"] = p.FinalRealName;
                return dic;
            }).ToList();
            var item = new { status = true, list = userList };
            context.Response.Write(JsonConvert.SerializeObject(item));
        }
        private void deletefile(HttpContext context)
        {
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [CustomerServiceAttach] where ID=@ID";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", ID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: deletefile", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void removeservice(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [CustomerService] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: removeservice", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            var user = WebUtil.GetUser(context);
            string OperationTitle = "工单删除";
            string ServiceNumber = Foresight.DataAccess.CustomerService.GetCustomerServicNumbersByIDList(IDList);
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + ServiceNumber + "执行了删除操作";
            string key = EnumModel.OperationModule.ServiceDel.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, IDs, "Service", OperationMan: user.FinalRealName, IsHide: false);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveservicebanjie(HttpContext context)
        {
            Foresight.DataAccess.CustomerService service = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            if (service == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择工单" });
                return;
            }
            var user = WebUtil.GetUser(context);
            service.BanJieTime = WebUtil.getServerTimeValue(context, "tdBanJieTime");
            service.BanJieNote = WebUtil.getServerValue(context, "tdBanJieNote");
            service.BanJieManUserID = user.UserID;
            service.BanJieManName = user.FinalRealName;
            service.ServiceStatus = 1;
            service.Save();
            string OperationTitle = "工单办结";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + service.ServiceNumber + "执行了办结操作";
            string key = EnumModel.OperationModule.ServiceBanJie.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, service.ID.ToString(), "Service", OperationMan: user.FinalRealName, IsHide: false);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveservicehuifang(HttpContext context)
        {
            Foresight.DataAccess.CustomerService service = null;
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            if (service == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择工单" });
                return;
            }
            var user = WebUtil.GetUser(context);
            var huifang = new Foresight.DataAccess.CustomerServiceHuifang();
            huifang.ServiceID = service.ID;
            huifang.HuiFangTime = WebUtil.getServerTimeValue(context, "tdHuiFangTime");
            huifang.HuiFangNote = WebUtil.getServerValue(context, "tdHuiFangNote");
            //huifang.ChuLiRate = WebUtil.getServerDecimalValue(context, "tdChuLiRate");
            huifang.AddTime = DateTime.Now;
            huifang.AddUserID = user.UserID;
            int CanManualyAddPhoneState = WebUtil.GetIntValue(context, "CanManualyAddPhoneState");
            PhoneRecord record = null;
            if (CanManualyAddPhoneState == 1)
            {
                huifang.PhoneCallBackType = WebUtil.getServerIntValue(context, "tdPhoneCallBackType");
                huifang.PhoneCallBackTime = DateTime.Now;
                string RecordVoicePath = string.Empty;
                string fileName = string.Empty;
                string filepath = string.Empty;
                HttpFileCollection uploadFiles = context.Request.Files;
                if (uploadFiles.Count > 0)
                {
                    HttpPostedFile postedFile = uploadFiles[0];
                    string fileOriName = postedFile.FileName;
                    if (!string.IsNullOrEmpty(fileOriName))
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        fileName = System.IO.Path.GetFileName(fileOriName);
                        filepath = "/upload/Record/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        RecordVoicePath = filepath + fileName;
                    }
                }
                if (!string.IsNullOrEmpty(fileName))
                {
                    record = PhoneRecord.GetPhoneRecordByFileName(fileName);
                    if (record == null)
                    {
                        record = new PhoneRecord();
                        record.UserID = user.UserID;
                        record.ServiceID = huifang.ServiceID;
                        record.AddTime = DateTime.Now;
                        record.AddUserName = user.RealName;
                        record.PhoneNumber = service.AddCallPhone;
                        record.CallTime = DateTime.Now;
                        if (huifang.PhoneCallBackType == 1)
                        {
                            record.PickUpTime = DateTime.Now;
                        }
                        record.HangUpTime = DateTime.Now.AddSeconds(30);
                        record.RecordVoicePath = RecordVoicePath;
                        record.PhoneType = 2;
                        record.FileOriName = fileName;
                        record.RelatedPhoneRecordID = 0;
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string ChuliRateStr = WebUtil.getServerValue(context, "tdChuLiRate");
                    if (!string.IsNullOrEmpty(ChuliRateStr))
                    {
                        service.HuiFangRate = WebUtil.getServerDecimalValue(context, "tdChuLiRate");
                        service.Save(helper);
                    }
                    huifang.Save(helper);
                    if (record != null)
                    {
                        record.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: saveservicehuifang", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                }
            }
            string OperationTitle = "工单回访";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + service.ServiceNumber + "执行了回访操作";
            string key = EnumModel.OperationModule.ServiceCallBack.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, service.ID.ToString(), "Service", OperationMan: user.FinalRealName, IsHide: false);
            WebUtil.WriteJson(context, new { status = true, ID = service.ID });
        }
        private void saveservicechuli(HttpContext context)
        {
            Foresight.DataAccess.CustomerService service = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            if (service == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择工单" });
                return;
            }
            var user = WebUtil.GetUser(context);
            service.ServiceType1ID = WebUtil.getServerIntValue(context, "tdServiceType1");
            service.ServiceType2ID = context.Request["ServiceType2ID"];
            service.ServiceType3ID = context.Request["ServiceType3ID"];
            var chuli = new Foresight.DataAccess.CustomerServiceChuli();
            chuli.AddTime = DateTime.Now;
            chuli.HandelFee = 0;
            chuli.OtherFee = 0;
            chuli.HandelType = WebUtil.getServerIntValue(context, "tdHandelType");
            chuli.ServiceID = service.ID;
            if (chuli.HandelType == 1)
            {
                chuli.ResponseTime = WebUtil.getServerTimeValue(context, "tdResponseTime");
                chuli.ResponseRemark = WebUtil.getServerValue(context, "tdResponseRemark");
            }
            if (chuli.HandelType == 2)
            {
                chuli.CheckTime = WebUtil.getServerTimeValue(context, "tdCheckTime");
                chuli.CheckRemark = WebUtil.getServerValue(context, "tdCheckRemark");
            }
            if (chuli.HandelType == 3)
            {
                chuli.ChuliDate = WebUtil.getServerTimeValue(context, "tdChuLiTime");
                chuli.HandelFee = WebUtil.getServerDecimalValue(context, "tdHandelFee");
                chuli.ChuliNote = WebUtil.getServerValue(context, "tdChuLiNote");
                chuli.RepartPartName = WebUtil.getServerValue(context, "tdRepartPartName");
            }
            bool isComplete = WebUtil.GetBoolValue(context, "isComplete");
            List<Foresight.DataAccess.CustomerServiceChuli_Attach> attachlist = new List<Foresight.DataAccess.CustomerServiceChuli_Attach>();
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
                    Foresight.DataAccess.CustomerServiceChuli_Attach attach = new Foresight.DataAccess.CustomerServiceChuli_Attach();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (isComplete)
                    {
                        service.ServiceStatus = 1;
                        service.BanJieTime = DateTime.Now;
                        service.IsRequireCost = chuli.HandelFee > 0;
                        service.BanJieNote = chuli.ChuliNote;
                        service.BanJieManUserID = user.UserID;
                        service.BanJieManName = user.FinalRealName;
                    }
                    service.Save(helper);
                    chuli.ServiceID = service.ID;
                    chuli.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.ChuliID = chuli.ID;
                        item.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: saveservicechuli", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
            string OperationTitle = "工单处理";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + service.ServiceNumber + "执行了处理操作";
            string key = EnumModel.OperationModule.ServiceProcess.ToString();
            if (isComplete)
            {
                OperationTitle = "工单办结";
                OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + service.ServiceNumber + "执行了办结操作";
                key = EnumModel.OperationModule.ServiceBanJie.ToString();
            }
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, service.ID.ToString(), "Service", OperationMan: user.FinalRealName, IsHide: false);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadserviceanalysislist(HttpContext context)
        {
            try
            {
                int ServiceTypeID = WebUtil.GetIntValue(context, "ServiceTypeID");
                int ServiceType2ID = WebUtil.GetIntValue(context, "ServiceType2ID");
                int ServiceType3ID = WebUtil.GetIntValue(context, "ServiceType3ID");
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string SortOrder = " order by [AddTime] desc";
                var user = WebUtil.GetUser(context);
                List<int> RoomIDList = new List<int>();
                List<int> EqualProjectIDList = new List<int>();
                List<int> InProjectIDList = new List<int>();
                int[] CompanyIDList = new int[] { };
                List<int> TopProjectIDList = new List<int>();
                WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
                DataGrid dg = Foresight.DataAccess.ViewCustomerService.GetCustomerServiceGridByServiceTypeID(StartTime, EndTime, SortOrder, startRowIndex, pageSize, ServiceTypeID, CompanyIDList, EqualProjectIDList, InProjectIDList, user.UserID, ServiceType2ID, ServiceType3ID);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:loadserviceanalysislist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void loadservicelist(HttpContext context)
        {
            try
            {
                int ServiceType = WebUtil.GetIntValue(context, "ServiceType");
                List<int> RoomIDList = new List<int>();
                List<int> EqualProjectIDList = new List<int>();
                List<int> InProjectIDList = new List<int>();
                int[] CompanyIDList = new int[] { };
                List<int> TopProjectIDList = new List<int>();
                WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
                string ServiceStatusStr = context.Request["ServiceStatus"];
                int ServiceStatus = int.MinValue;
                if (!string.IsNullOrEmpty(ServiceStatusStr))
                {
                    int.TryParse(ServiceStatusStr, out ServiceStatus);
                }
                DateTime StartTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["StartTime"], out StartTime);
                DateTime EndTime = DateTime.MinValue;
                DateTime.TryParse(context.Request.Params["EndTime"], out EndTime);
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["Keywords"];
                string OrderBy = context.Request["OrderBy"];
                string SortOrder = " order by [AddTime] desc";
                if (!string.IsNullOrEmpty(OrderBy) && OrderBy.Equals("2"))
                {
                    SortOrder = " order by [ServiceNumber] desc";
                }
                if (!string.IsNullOrEmpty(context.Request["ChooseStatus"]))
                {
                    ServiceStatus = WebUtil.GetIntValue(context, "ChooseStatus");
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                var user = WebUtil.GetUser(context);
                bool canViewAll = WebUtil.Authorization(context, "1191180", user.UserID);
                bool canViewWechatAPPService = WebUtil.Authorization(context, "1191181", user.UserID);
                bool canViewWechatAPPSuggestoin = WebUtil.Authorization(context, "1191182", user.UserID);
                bool isServiceAnalysis = WebUtil.GetBoolValue(context, "isServiceAnalysis");
                int CloseType = WebUtil.GetIntValue(context, "CloseType");
                int TimeOutType = WebUtil.GetIntValue(context, "TimeOutType");
                bool IsTouSuChaoShi = WebUtil.GetBoolValue(context, "IsTouSuChaoShi");
                bool IsRepairChaoShi = WebUtil.GetBoolValue(context, "IsRepairChaoShi");
                int CallBackStatus = WebUtil.GetIntValue(context, "CallBackStatus");
                int CallServiceType = WebUtil.GetIntValue(context, "CallServiceType");
                int ServiceType1ID = WebUtil.GetIntValue(context, "ServiceType1ID");
                int ServiceType2ID = WebUtil.GetIntValue(context, "ServiceType2ID");
                int ServiceType3ID = WebUtil.GetIntValue(context, "ServiceType3ID");
                int PayStatus = WebUtil.GetIntValue(context, "PayStatus");
                int IsImportantTouSu = WebUtil.GetIntValue(context, "IsImportantTouSu", -1);
                decimal BeforeBanJieTimeOutHour = WebUtil.GetDecimalValue(context, "BeforeBanJieTimeOutHour");
                DateTime CompleteStartTime = WebUtil.GetDateValue(context, "CompleteStartTime");
                DateTime CompleteEndTime = WebUtil.GetDateValue(context, "CompleteEndTime");
                string ProcessKewords = context.Request["ProcessKewords"];
                string CallBackKeywords = context.Request["CallBackKeywords"];
                DataGrid dg = Foresight.DataAccess.ViewCustomerService.GetCustomerServiceGridByKeywords(Keywords, RoomIDList, StartTime, EndTime, ServiceStatus, SortOrder, startRowIndex, pageSize, user.UserID, canViewAll, EqualProjectIDList: EqualProjectIDList, InProjectIDList: InProjectIDList, CompanyIDList: CompanyIDList, ServiceType: ServiceType, canexport: canexport, canViewWechatAPPService: canViewWechatAPPService, canViewWechatAPPSuggestoin: canViewWechatAPPSuggestoin, isServiceAnalysis: isServiceAnalysis, CloseType: CloseType, TimeOutType: TimeOutType, IsTouSuChaoShi: IsTouSuChaoShi, IsRepairChaoShi: IsRepairChaoShi, CallBackStatus: CallBackStatus, CallServiceType: CallServiceType, ServiceType1ID: ServiceType1ID, ServiceType2ID: ServiceType2ID, ServiceType3ID: ServiceType3ID, PayStatus: PayStatus, BeforeBanJieTimeOutHour: BeforeBanJieTimeOutHour, IsImportantTouSu: IsImportantTouSu, CompleteStartTime: CompleteStartTime, CompleteEndTime: CompleteEndTime, ProcessKewords: ProcessKewords, CallBackKeywords: CallBackKeywords);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadCustomerServiceData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                    return;
                }
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ServiceHandler", "命令:loadservicelist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void getroominfo(HttpContext context)
        {
            string results = string.Empty;
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            bool IsNotRoom = WebUtil.GetBoolValue(context, "IsNotRoom");
            string PhoneNumber = context.Request["phoneNumber"];
            int UserID = WebUtil.GetIntValue(context, "UserID");
            Project project = null;
            RoomPhoneRelation relation = null;
            if (!string.IsNullOrEmpty(PhoneNumber) && ProjectID <= 0)
            {
                project = Project.GetProjectByPhoneNumber(PhoneNumber);
                if (project != null)
                {
                    ProjectID = project.ID;
                    IsNotRoom = false;
                    var relationList = RoomPhoneRelation.GetRoomPhoneRelationsByPhone(PhoneNumber);
                    if (relationList.Length > 0)
                    {
                        relation = relationList[0];
                    }
                }
            }
            if (ProjectID > 0 && project == null)
            {
                project = Foresight.DataAccess.Project.GetProject(ProjectID);
            }
            if (project == null)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            int ServiceTypeID = WebUtil.GetIntValue(context, "ServiceTypeID");
            var userStaffList = Foresight.DataAccess.User.GetAccpetUserListByServiceProjectID(project.ID, IsAccpetUser: true, ServerTypeID: ServiceTypeID);
            var departmentList = CKDepartment.GetDepartmentListByUserIDList(userStaffList.Select(p => p.UserID).ToArray());
            var userDepartmentList = new UserDepartment[] { };
            if (userStaffList.Length > 0)
            {
                int MinUserID = userStaffList.Min(p => p.UserID);
                int MaxUserID = userStaffList.Max(p => p.UserID);
                userDepartmentList = UserDepartment.GetUserDepartmentListByMinMaxUserID(MinUserID, MaxUserID);
            }
            var userStaffItems = userStaffList.Select(p =>
            {
                var myUserDepartment = userDepartmentList.FirstOrDefault(q => q.UserID == p.UserID);
                var item = new { ID = p.UserID, Name = p.FinalRealName, DepartmentID = myUserDepartment != null ? myUserDepartment.DepartmentID : 0 };
                return item;
            }).ToList();
            var departmentItems = departmentList.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.DepartmentName };
                return item;
            }).ToList();
            bool OnlyUserStaff = WebUtil.GetBoolValue(context, "OnlyUserStaff");
            if (OnlyUserStaff)
            {
                WebUtil.WriteJson(context, new { status = true, userStaffList = userStaffItems, departmentList = departmentItems });
                return;
            }
            int OrderNumberID = 0;
            string CustomerNumber = Foresight.DataAccess.CustomerService.GetLastestCustomerServiceNumber(Foresight.DataAccess.OrderTypeNameDefine.customerservice.ToString(), ProjectID, out OrderNumberID);
            string[] ids = project.AllParentID.Split(',');
            List<int> IDList = new List<int>();
            foreach (var id in ids)
            {
                if (string.IsNullOrEmpty(id))
                {
                    continue;
                }
                int ID = int.Parse(id);
                IDList.Add(ID);
            }
            string ProjectName = string.Empty;
            var projectlist = Foresight.DataAccess.Project.GetProjectListByIDs(IDList).Where(p => p.ParentID == 1).ToList();
            if (projectlist.Count > 0)
            {
                ProjectName = projectlist[0].Name;
            }
            else
            {
                ProjectName = project.FullName.Split('-')[0];
            }
            string FullName = project.FullName;
            string RoomName = string.Empty;
            if (!IsNotRoom)
            {
                FullName = FullName + "-" + project.Name;
                RoomName = project.Name;
            }
            if (relation == null)
            {
                var relationList = RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxRoomID(ProjectID, ProjectID);
                if (relationList.Length > 0)
                {
                    relation = relationList[0];
                }
            }
            string RelationPhoneNumber = string.Empty;
            string RelationName = string.Empty;
            if (relation != null)
            {
                RelationPhoneNumber = relation.RelatePhoneNumber;
                RelationName = relation.RelationName;
            }
            var includeHistory = WebUtil.GetBoolValue(context, "includeHistory");
            Dictionary<string, object> history = null;
            if (includeHistory)
            {
                history = Foresight.DataAccess.CustomerService.GetCustomerServiceDataByProjectID(project.ID);
            }
            var items = new { status = true, FullName = FullName, CustomerNumber = CustomerNumber, OrderNumberID = OrderNumberID, ProjectName = ProjectName, RelationPhoneNumber = RelationPhoneNumber, RelationName = RelationName, ProjectID = project.ID, departmentList = departmentItems, userStaffList = userStaffItems, history = history };
            WebUtil.WriteJson(context, items);
        }
        private void getserviceeditparams(HttpContext context)
        {
            var types = Foresight.DataAccess.ServiceType.GetServiceTypes().Where(p => p.ParentID <= 1).Select(p =>
            {
                var item = new { ID = p.ID, Name = p.ServiceTypeName };
                return item;
            }).ToList();
            var tasks = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Tasks().Select(p =>
            {
                var item = new { ID = p.ID, Name = p.TaskName };
                return item;
            }).ToList();
            WebUtil.WriteJson(context, new { types = types, tasks = tasks });
        }
        private void savecustomerservice(HttpContext context)
        {
            int UserID = WebUtil.GetIntValue(context, "UserID");
            User user = null;
            if (UserID > 0)
            {
                user = User.GetUser(UserID);
            }
            else
            {
                user = WebUtil.GetUser(context);
            }
            Foresight.DataAccess.CustomerService service = null;
            int ID = WebUtil.GetIntValue(context, "ID");
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            if (ProjectID <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "项目不能为空" });
                return;
            }
            string ServiceAccpetManIDs = WebUtil.getServerValue(context, "tdAcceptManInput");
            List<int> ServiceAccpetManIDList = new List<int>();
            if (!string.IsNullOrEmpty(ServiceAccpetManIDs))
            {
                if (!ServiceAccpetManIDs.StartsWith("["))
                {
                    ServiceAccpetManIDs = "[" + ServiceAccpetManIDs + "]";
                }
                ServiceAccpetManIDList = JsonConvert.DeserializeObject<List<int>>(ServiceAccpetManIDs);
            }
            if (ID > 0)
            {
                service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            }
            bool isNewAdd = false;
            int ServiceType = WebUtil.GetIntValue(context, "ServiceType");//0-400录入 1-工单录入 2-建议录入
            int ServiceType1ID = WebUtil.getServerIntValue(context, "tdServiceType1");
            if (service == null)
            {
                isNewAdd = true;
                service = new Foresight.DataAccess.CustomerService();
                service.AddTime = DateTime.Now;
                service.AddMan = context.Request.Params["AddMan"];
                service.AddUserID = WebUtil.GetUser(context).UserID;
                service.AddUserName = user.FinalRealName;
                if (ServiceAccpetManIDList.Count > 0)
                {
                    service.ServiceStatus = 3;
                }
                else
                {
                    service.ServiceStatus = 10;
                }
                if (ServiceType == 0)
                {
                    if (ServiceType1ID <= 0)
                    {
                        service.IsSuggestion = false;
                    }
                    else
                    {
                        var serviceType = Foresight.DataAccess.ServiceType.GetServiceType(ServiceType1ID);
                        if (serviceType != null)
                        {
                            service.IsSuggestion = serviceType.GongDanType == 2;
                        }
                        else
                        {
                            service.IsSuggestion = false;
                        }
                    }
                }
                else
                {
                    service.IsSuggestion = ServiceType == 2;
                }
            }
            service.ProjectID = ProjectID;
            service.OrderNumberID = WebUtil.GetIntValue(context, "OrderNumberID");
            string ServiceNumber = WebUtil.getServerValue(context, "tdServiceNumber");
            var exist_service = Foresight.DataAccess.CustomerService.GetExistCustomerServiceByServiceNumber(service.ID, ServiceNumber);
            if (exist_service != null)
            {
                int OrderNumberID = 0;
                ServiceNumber = Foresight.DataAccess.CustomerService.GetLastestCustomerServiceNumber(Foresight.DataAccess.OrderTypeNameDefine.customerservice.ToString(), 0, out OrderNumberID);
                service.ServiceNumber = ServiceNumber;
                service.OrderNumberID = OrderNumberID;
                //WebUtil.WriteJson(context, new { status = false, error = "客户单号已存在" });
                //return;
            }
            service.ServiceFullName = WebUtil.getServerValue(context, "tdFullName");
            service.ProjectName = WebUtil.getServerValue(context, "tdProjectName");
            service.ServiceType1ID = ServiceType1ID;
            service.ServiceType2ID = context.Request["ServiceType2ID"];
            service.ServiceType3ID = context.Request["ServiceType3ID"];
            service.StartTime = DateTime.Now;//反应时间
            service.ServiceArea = WebUtil.getServerValue(context, "tdServiceArea");
            service.ServiceNumber = ServiceNumber;
            service.AddCustomerName = WebUtil.getServerValue(context, "tdAddCustomerName");//反映人
            service.AddCallPhone = WebUtil.getServerValue(context, "tdAddCallPhone");//反映人联系电话
            service.ServiceContent = WebUtil.getServerValue(context, "tdServiceContent");
            service.ServiceAppointTime = WebUtil.getServerTimeValue(context, "tdAppointTime");
            service.IsRequireCost = WebUtil.GetIntValue(context, "IsRequireCost") == 1;
            service.IsAPPShow = WebUtil.GetIntValue(context, "IsSendAPP") == 1;
            service.TaskType = WebUtil.getServerIntValue(context, "tdTaskType");
            service.DepartmentID = WebUtil.getServerIntValue(context, "tdBelongTeamName");
            service.ServiceFrom = WebUtil.getServerValue(context, "hdServiceFrom");
            service.IsInvalidCall = WebUtil.GetIntValue(context, "tdIsInvalidCall") == 1;
            service.IsHighTouSu = WebUtil.getServerIntValue(context, "tdIsHighTouSu") == 1;
            service.IsInWeiBao = WebUtil.getServerIntValue(context, "tdIsInWeiBao") == 1;
            if (service.IsRequireCost)
            {
                service.HandelFee = getValue(context, "tdHandelFee");
                service.TotalFee = getDecimalValue(context, "tdTotalFee");
            }
            else
            {
                service.HandelFee = "0";
                service.TotalFee = 0;
            }
            List<Foresight.DataAccess.CustomerServiceAttach> attachlist = new List<Foresight.DataAccess.CustomerServiceAttach>();
            if (string.IsNullOrEmpty(service.ServiceFrom))
            {
                service.ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.system.ToString();
            }
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
                    Foresight.DataAccess.CustomerServiceAttach attach = new Foresight.DataAccess.CustomerServiceAttach();
                    attach.FileOriName = fileOriName;
                    attach.AttachedFilePath = filepath + fileName;
                    attach.AddTime = DateTime.Now;
                    attachlist.Add(attach);
                }
            }
            string RecordName = context.Request["RecordName"];
            PhoneRecord record = null;
            if (!string.IsNullOrEmpty(RecordName))
            {
                record = PhoneRecord.GetPhoneRecordByFileName(RecordName);
            }
            bool isAdd = true;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    isAdd = service.ID <= 0;
                    service.Save(helper);
                    foreach (var item in attachlist)
                    {
                        item.ServiceID = service.ID;
                        item.Save(helper);
                    }
                    if (record != null)
                    {
                        record.ServiceID = service.ID;
                        record.Save(helper);
                    }
                    foreach (var AccpetManID in ServiceAccpetManIDList)
                    {
                        var data = new CustomerService_Accpet();
                        data.ServiceID = service.ID;
                        data.AccpetManID = AccpetManID;
                        data.AddTime = DateTime.Now;
                        data.AccpetStatus = 0;
                        data.AccpetUserType = 1;
                        data.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("ServiceHandler", "命令: savecustomerservice", ex);
                    helper.Rollback();
                    context.Response.Write("{\"status\":false}");
                    return;
                }
            }
            string OperationTitle = "工单修改";
            string OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + service.ServiceNumber + "执行了修改操作";
            string key = EnumModel.OperationModule.ServiceEdit.ToString();
            if (isAdd)
            {
                OperationTitle = "工单新增";
                OperatoinContent = "员工" + user.FinalRealName + "在后台对工单" + service.ServiceNumber + "执行了新增操作";
                key = EnumModel.OperationModule.ServiceAdd.ToString();
            }
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, service.ID.ToString(), "Service", OperationMan: user.FinalRealName, IsHide: false);
            //推送通知派单人
            if (isNewAdd && ServiceAccpetManIDList.Count > 0)
            {
                string ErrorMsg = string.Empty;
                string title = new SiteConfig().CompanyName;
                bool result = APPCode.JPushHelper.SendJpushMsgByServiceID(service.ID, out ErrorMsg, title: title, SendUserID: user.UserID, SendUserName: user.FinalRealName, service: service, ServiceAccpetManIDList: ServiceAccpetManIDList);
            }
            WebUtil.WriteJson(context, new { status = true, ID = service.ID });
        }
        private string getValue(HttpContext context, string name)
        {
            string PostName = "ctl00$content$";
            return context.Request.Params[PostName + name];
        }
        private int getIntValue(HttpContext context, string name)
        {
            int result = 0;
            int.TryParse(getValue(context, name), out result);
            return result;
        }
        private DateTime getTimeValue(HttpContext context, string name)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(getValue(context, name), out result);
            return result;
        }
        private decimal getDecimalValue(HttpContext context, string name)
        {
            decimal result = 0;
            decimal.TryParse(getValue(context, name), out result);
            return result;
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