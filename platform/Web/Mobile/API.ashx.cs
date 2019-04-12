using Foresight.DataAccess;
using Foresight.DataAccess.Framework;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Mobile
{
    /// <summary>
    /// API 的摘要说明
    /// </summary>
    public class API : IHttpHandler, IRequiresSessionState
    {
        const string LogModuel = "Mobile.API";
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
                    case "dologin":
                        dologin(context);
                        break;
                    case "getprojectlist":
                        getprojectlist(context);
                        break;
                    case "savedeviceid":
                        savedeviceid(context);
                        break;
                    case "getservicelist"://工单列表
                        getservicelist(context);
                        break;
                    case "getservicedetail"://工单详情
                        getservicedetail(context);
                        break;
                    case "acceptservice"://接单
                        acceptservice(context);
                        break;
                    case "completeservice"://完成
                        completeservice(context);
                        break;
                    case "getservicestauscount"://任务工单状态数量
                        getservicestauscount(context);
                        break;
                    case "savebaoshibaoxiu"://报事报修提交
                        savebaoshibaoxiu(context);
                        break;
                    case "getservicechulilist"://获取工单处理列表
                        getservicechulilist(context);
                        break;
                    case "saveheadimg"://修改用户头像
                        saveheadimg(context);
                        break;
                    case "saveusernickname"://修改用户昵称
                        saveusernickname(context);
                        break;
                    case "saveuserphone"://修改用户手机号码
                        saveuserphone(context);
                        break;
                    case "savepassword"://修改用户登录密码
                        savepassword(context);
                        break;
                    case "getservicelistgroupbyproject"://根据项目获取工单列表
                        getservicelistgroupbyproject(context);
                        break;
                    case "getservicelistgroupbyuser"://根据用户和项目获取工单列表
                        getservicelistgroupbyuser(context);
                        break;
                    case "getmenulist"://获取物业内控APP菜单
                        getmenulist(context);
                        break;
                    case "getappversion":
                        getappversion(context);
                        break;
                    case "getprojectlistbyparentid":
                        getprojectlistbyparentid(context);
                        break;
                    case "dosaveserviceuser":
                        dosaveserviceuser(context);
                        break;
                    case "getserviceuserlist"://获取服务人员列表
                        getserviceuserlist(context);
                        break;
                    case "getservicedepartmentlist"://获取服务部门
                        getservicedepartmentlist(context);
                        break;
                    case "getlogindata":
                        getlogindata(context);
                        break;
                    case "checkloginstatus":
                        checkloginstatus(context);
                        break;
                    case "getservicetypelistbyparentid":
                        getservicetypelistbyparentid(context);
                        break;
                    case "doreturnservice"://员工退单给派单人
                        doreturnservice(context);
                        break;
                    case "getservicetypeinfobyid":
                        getservicetypeinfobyid(context);
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
        private void getservicetypeinfobyid(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "id");
            var service = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceByID(ID);
            string ServiceType2IDs = Utility.JsonConvert.SerializeObject(service.ServiceType2IDList);
            string ServiceType3IDs = Utility.JsonConvert.SerializeObject(service.ServiceType3IDList);
            WebUtil.WriteJsonResult(context, new { ServiceType1ID = service.ServiceType1ID, ServiceType2ID = ServiceType2IDs, ServiceType3ID = ServiceType3IDs, ServiceType1Name = service.CategoryPartA, ServiceType2Name = service.CategoryPartB, ServiceType3Name = service.CategoryPartC });
        }
        private void doreturnservice(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int ServiceID = WebUtil.GetIntValue(context, "ID");
            var service = Foresight.DataAccess.CustomerService.GetCustomerService(ServiceID);
            var data = new CustomerService_Return();
            data.AddTime = DateTime.Now;
            data.ServiceID = ServiceID;
            data.UserID = uid;
            data.ReturnRemark = context.Request["ReturnRemark"];
            service.ServiceStatus = 10;
            var processUserList = CustomerService_Accpet.GetCustomerService_AccpetListByServiceID(ServiceID, new int[] { }, AccpetUserType: 2);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in processUserList)
                    {
                        item.AccpetStatus = 2;
                        item.Save(helper);
                    }
                    service.ServiceStatus = 10;
                    service.Save(helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            var config = new Utility.SiteConfig();
            string title = config.CompanyName;
            string ErrorMsg = "";
            APPCode.JPushHelper.SendJpushMsgByServiceID(service.ID, out ErrorMsg, title: title, SendUserID: user.UserID, SendUserName: user.FinalRealName, service: service, isReturnNotify: true);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getservicetypelistbyparentid(HttpContext context)
        {
            var uid = GetUID(context);
            var serviceList = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
            int parentid = WebUtil.GetIntValue(context, "parentid");
            var parentids = context.Request["parentids"];
            List<int> parentIDList = new List<int>();
            if (!string.IsNullOrEmpty(parentids))
            {
                parentIDList = Utility.JsonConvert.DeserializeObject<List<int>>(parentids);
            }
            string title = "";
            if (parentid == 1 && parentIDList.Count == 0)
            {
                int BaoXiuServiceID = new Utility.SiteConfig().BaoXiuServiceID;
                serviceList = serviceList.Where(p => p.ID == BaoXiuServiceID).ToArray();
            }
            else
            {
                if (parentIDList.Count == 0)
                {
                    parentIDList.Add(parentid);
                }
                serviceList = Foresight.DataAccess.ServiceType.GetServiceTypes().Where(p => parentIDList.Contains(p.ParentID)).ToArray();
            }
            var items = serviceList.Select(p =>
            {
                return new { id = p.ID, name = p.ServiceTypeName, ischecked = false };
            });
            WebUtil.WriteJsonResult(context, new { list = items, title = title });
        }
        private void checkloginstatus(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            try
            {
                int uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (user != null)
            {
                WebUtil.WriteJsonResult(context, "Success");
                return;
            }
            bool IsLoginCheck = WebUtil.GetIntValue(context, "IsLoginCheck") == 1;
            bool IsAppUserLoginOn = new Utility.SiteConfig().IsAppUserLoginOn;
            if (IsLoginCheck && !IsAppUserLoginOn)
            {
                WebUtil.WriteJsonResult(context, "Success");
                return;
            }
            WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请登录");
        }
        private void getlogindata(HttpContext context)
        {
            WebUtil.WriteJsonResult(context, new { CanAPPUserRegister = new SiteConfig().CanAPPUserRegister });
        }
        private void getservicedepartmentlist(HttpContext context)
        {
            var departments = Foresight.DataAccess.CKDepartment.GetCKDepartments().Select(p =>
            {
                var item = new { ID = p.ID, Name = p.DepartmentName, ischecked = false };
                return item;
            }).ToList();
            departments.Insert(0, new { ID = 0, Name = "不限", ischecked = false });
            WebUtil.WriteJsonResult(context, new { list = departments });
        }
        private void getserviceuserlist(HttpContext context)
        {
            int ServiceID = WebUtil.GetIntValue(context, "ID");
            var service = Foresight.DataAccess.CustomerService.GetCustomerService(ServiceID);
            var processUserStaffList = Foresight.DataAccess.User.GetAccpetUserListByServiceProjectID(service.ProjectID, IsProcessUser: true);
            var items = processUserStaffList.Select(p =>
            {
                var item = new { UserID = p.UserID, RealName = p.FinalRealName, ischecked = false };
                return item;
            }).ToList();
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        /// <summary>
        /// 接单人转派单给处理人
        /// </summary>
        /// <param name="context"></param>
        private void dosaveserviceuser(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int ID = WebUtil.GetIntValue(context, "ID");
            var service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            service.ServiceStatus = 0;
            service.IsAPPSend = false;
            service.IsAPPShow = true;
            string ProcessUserIDs = context.Request["UserIDList"];
            var ProcessUserIDList = Utility.JsonConvert.DeserializeObject<List<int>>(context.Request["UserIDList"]);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    service.ServiceStatus = 0;
                    service.Save(helper);
                    List<int> AccpetManIDList1 = new List<int>();
                    List<int> AccpetManIDList2 = new List<int>();
                    var accpet = CustomerService_Accpet.GetCustomerService_AccpetByUserID(service.ID, uid, helper);
                    if (accpet == null)
                    {
                        accpet = new CustomerService_Accpet();
                        accpet.ServiceID = service.ID;
                        accpet.AccpetManID = uid;
                        accpet.AddTime = DateTime.Now;
                        accpet.AccpetStatus = 0;
                        accpet.AccpetUserType = 1;
                        accpet.Save(helper);
                        AccpetManIDList1.Add(accpet.ID);
                    }
                    foreach (var AccpetManID in ProcessUserIDList)
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
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, ex.Message);
                    return;
                }
            }
            var config = new Utility.SiteConfig();
            string title = config.CompanyName;
            string ErrorMsg = "";
            APPCode.JPushHelper.SendJpushMsgByServiceID(service.ID, out ErrorMsg, title: title, SendUserID: user.UserID, SendUserName: user.FinalRealName, service: service, ServiceProcessManIDList: ProcessUserIDList);
            WebUtil.WriteJsonResult(context, "Success");
        }
        private void getprojectlistbyparentid(HttpContext context)
        {
            var uid = GetUID(context);
            int parentid = WebUtil.GetIntValue(context, "parentid");
            string title = "小区";
            int type = WebUtil.GetIntValue(context, "type");
            bool ExceptRoom = type == 2;
            var project_list = Foresight.DataAccess.ProjectTree.GetProjectTreeListByID(parentid, string.Empty, uid, ExceptRoom: ExceptRoom);
            var items = project_list.Select(p =>
            {
                title = p.TypeDesc;
                string fullname = p.isParent ? p.FullName : p.FullName + '-' + p.Name;
                return new { id = p.ID, name = p.Name, fullname = fullname, isParent = p.isParent, title = p.TypeDesc };
            });
            WebUtil.WriteJsonResult(context, new { list = items, title = title });
        }
        private void getappversion(HttpContext context)
        {
            string version = context.Request["version"];
            string versiontype = context.Request["versiontype"];
            int APPType = WebUtil.GetIntValue(context, "APPType");
            APPType = APPType > 0 ? APPType : 1;
            var data = Foresight.DataAccess.SiteVersion.GetAPPVersionByAPPVersionDesc(version, APPType: APPType, VersionType: versiontype);
            Foresight.DataAccess.SiteVersion last_data = null;
            int APPVersionCode = 0;
            if (data != null)
            {
                APPVersionCode = data.APPVersionCode;
            }
            last_data = Foresight.DataAccess.SiteVersion.GetLatestAPPVersion(APPVersionCode, APPType: APPType, VersionType: versiontype);
            if (last_data != null)
            {
                bool can_update = Utility.Tools.CheckVersionCode(version, last_data.APPVersionDesc);
                if (!can_update)
                {
                    WebUtil.WriteJsonResult(context, new { update = false });
                    return;
                }
                string time = last_data.PublishDate > DateTime.MinValue ? last_data.PublishDate.ToString("yyyy-MM-dd") : "";
                string FilePath = last_data.FilePath;
                if (!FilePath.StartsWith("http") && !FilePath.StartsWith("itms-services"))
                {
                    FilePath = WebUtil.GetContextPath() + FilePath;
                }
                WebUtil.WriteJsonResult(context, new { update = true, closed = false, version = last_data.APPVersionDesc, versionDes = last_data.VersionDesc, time = time, source = FilePath, isforceupdate = last_data.IsForceUpdate });
                return;
            }
            WebUtil.WriteJsonResult(context, new { update = false });
        }
        private void getmenulist(HttpContext context)
        {
            User user = null;
            int uid = 0;
            var list = new List<Dictionary<string, object>>();
            try
            {
                uid = GetUID(context, out user);
            }
            catch (Exception)
            {
            }
            if (user != null)
            {
                list = SysMenu.GetAPPUserMenuList(user.UserID);
            }
            if (!new Utility.SiteConfig().IsMallOn)
            {
                WebUtil.WriteJsonResult(context, new { list = list });
                return;
            }
            var imageItem = new Dictionary<string, object>();
            imageItem["imageurl"] = WebUtil.GetContextPath() + "/styles/images/banner_1.png";
            var imagelist = new List<Dictionary<string, object>>();
            imagelist.Add(imageItem);
            WebUtil.WriteJsonResult(context, new { list = list, imagelist = imagelist });
        }
        private void getservicelistgroupbyuser(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            int ProjectID = WebUtil.GetIntValue(context, "id");
            var list = Foresight.DataAccess.CustomerServiceDetail.GetCustomerServiceCountGroupByUserStatus(uid, status, ProjectID);
            WebUtil.WriteJsonResult(context, new { gongdanlist = list });
        }
        private void getservicelistgroupbyproject(HttpContext context)
        {
            User user = null;
            var uid = GetUID(context, out user);
            int status = WebUtil.GetIntValue(context, "status");
            var list = Foresight.DataAccess.CustomerServiceDetail.GetCustomerServiceCountGroupByProjectStatus(uid, status);
            WebUtil.WriteJsonResult(context, new { gongdanlist = list });
        }
        private void savepassword(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, "没有登录");
                return;
            }
            if (!string.IsNullOrEmpty(context.Request["Password"]))
            {
                user.Password = Foresight.DataAccess.User.EncryptPassword(context.Request["Password"]);
                user.Save();
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void saveuserphone(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, "没有登录");
                return;
            }
            user.PhoneNumber = context.Request["PhoneNo"];
            user.Save();
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void saveusernickname(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, "没有登录");
                return;
            }
            if (!string.IsNullOrEmpty(context.Request["NickName"]))
            {
                user.NickName = context.Request["NickName"];
                user.RealName = user.NickName;
                user.Save();
            }
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void saveheadimg(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.AuthenticationFail, "没有登录");
                return;
            }
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                HttpPostedFile postedFile = uploadFiles[0];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/UserCenter/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    user.HeadImg = filepath + fileName;
                    user.Save();
                }
            }
            WebUtil.WriteJsonResult(context, new { headimg = WebUtil.GetContextPath() + user.HeadImg });
        }
        private void getservicechulilist(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var chulilist = Foresight.DataAccess.CustomerServiceChuli.GetCustomerServiceChuliList(ID);
            var chuliattachlist = Foresight.DataAccess.CustomerServiceChuli_Attach.GetCustomerServiceChuli_AttachListByServiceID(ID);
            var items = chulilist.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["ChuliDate"] = p.ChuliDate > DateTime.MinValue ? p.ChuliDate.ToString("yyyy-MM-dd HH:mm") : "";
                dic["CompleteContent"] = p.ChuliNote;
                dic["ResponseTime"] = p.ResponseTime > DateTime.MinValue ? p.ResponseTime.ToString("yyyy-MM-dd HH:mm") : "";
                dic["ResponseContent"] = p.ResponseRemark;
                dic["CheckTime"] = WebUtil.GetStrDate(p.CheckTime, "yyyy-MM-dd HH:mm");
                dic["CheckContent"] = p.CheckRemark;
                dic["HandleFee"] = p.HandelFee > 0 ? p.HandelFee.ToString("0.00") : "";
                dic["RepairPart"] = p.RepartPartName;
                dic["imglist"] = chuliattachlist.Where(q => q.ChuliID == p.ID).Select(q =>
                {
                    var item = new { url = WebUtil.GetContextPath() + q.AttachedFilePath, cacheurl = "" };
                    return item;
                });
                return dic;
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void savebaoshibaoxiu(HttpContext context)
        {
            Foresight.DataAccess.User user = null;
            var uid = GetUID(context, out user);
            int Type = WebUtil.GetIntValue(context, "Type");
            string AppointTimeStr = context.Request["AppointTime"];
            if (!string.IsNullOrEmpty(AppointTimeStr))
            {
                AppointTimeStr = AppointTimeStr.Replace("T", " ");
            }
            DateTime AppointTime = DateTime.MinValue;
            DateTime.TryParse(AppointTimeStr, out AppointTime);
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            if (RoomID <= 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "请选择项目");
                return;
            }
            string ServiceType = Utility.EnumModel.WechatServiceType.bsbx.ToString();
            string ServiceContent = context.Request["Content"];
            string PhoneNumber = context.Request["PhoneNo"];
            string FullName = context.Request["FullName"];
            string ProjectName = context.Request["ProjectName"];
            string ServiceMan = user.LoginName;
            string ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.app.ToString();
            var customer_service = new Foresight.DataAccess.CustomerService();
            int OrderNumberID = 0;
            string CustomerNumber = Foresight.DataAccess.CustomerService.GetLastestCustomerServiceNumber(Foresight.DataAccess.OrderTypeNameDefine.customerservice.ToString(), RoomID, out OrderNumberID);
            customer_service.ServiceNumber = CustomerNumber;
            customer_service.AddTime = DateTime.Now;
            customer_service.StartTime = DateTime.Now;
            customer_service.AddMan = user.RealName;
            customer_service.AddUserName = user.RealName;
            customer_service.ServiceFrom = ServiceFrom;
            customer_service.ServiceFullName = FullName;
            customer_service.ProjectName = ProjectName;
            string ServiceTypeDesc = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceType), ServiceType);
            var type = Foresight.DataAccess.ServiceType.GetServiceTypes().FirstOrDefault(p => ServiceTypeDesc.Contains(p.ServiceTypeName));
            customer_service.AddCustomerName = ServiceMan;
            customer_service.ServiceContent = ServiceContent;
            customer_service.ServiceAppointTime = DateTime.Now;
            customer_service.AddCallPhone = PhoneNumber;
            customer_service.ServiceStatus = 3;
            customer_service.IsAPPShow = true;
            customer_service.IsUnRead = true;
            customer_service.ProjectID = RoomID;
            customer_service.ServiceType1ID = WebUtil.GetIntValue(context, "ServiceTypeID");
            List<Foresight.DataAccess.CustomerServiceAttach> customer_attachlist = new List<Foresight.DataAccess.CustomerServiceAttach>();
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                        string filepath = "/upload/WechatServiceImg/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        Foresight.DataAccess.CustomerServiceAttach customer_attach = new Foresight.DataAccess.CustomerServiceAttach();
                        customer_attach.FileOriName = fileOriName;
                        customer_attach.AttachedFilePath = filepath + fileName;
                        customer_attach.AddTime = DateTime.Now;
                        customer_attachlist.Add(customer_attach);
                    }
                }
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    customer_service.Save(helper);
                    foreach (var attach in customer_attachlist)
                    {
                        attach.ServiceID = customer_service.ID;
                        attach.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "savebaoshibaoxiu", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "服务器异常");
                    return;
                }
            }
            string OperationTitle = "工单新增";
            string OperatoinContent = "员工" + user.FinalRealName + "在APP端新增了报事报修工单";
            string key = Utility.EnumModel.OperationModule.ServiceAdd.ToString();
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, customer_service.ID.ToString(), "Service", OperationMan: user.FinalRealName, IsHide: false);
            //通知后台
            APPCode.SocketNotify.PushSocketNotifyAlert(Utility.EnumModel.SocketNotifyDefine.notifyservice, ID: customer_service.ID);
            WebUtil.WriteJsonResult(context, "保存成功");
        }
        private void getservicestauscount(HttpContext context)
        {
            try
            {
                var uid = GetUID(context);
                int type = WebUtil.GetIntValue(context, "type");
                int qiangdan_count = 0;
                int jieshou_count = 0;
                int chuli_count = 0;
                jieshou_count = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceCountByStatus(uid, 10);
                chuli_count = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceCountByStatus(uid, 0);
                int banjie_count = 0;
                var item = new { qiangdan_count = qiangdan_count, jieshou_count = jieshou_count, chuli_count = chuli_count, banjie_count = banjie_count };
                WebUtil.WriteJsonResult(context, new { servicecount = item });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModuel, "getservicestauscount", ex);
                var item = new { qiangdan_count = 0, jieshou_count = 0, chuli_count = 0, banjie_count = 0 };
                WebUtil.WriteJsonResult(context, new { servicecount = item });
            }
        }
        private void completeservice(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            var accpetUserList = CustomerService_Accpet.GetCustomerService_AccpetListByServiceID(data.ID, new int[] { 0, 1 }, AccpetUserType: 2);
            if (accpetUserList.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            List<int> ServiceAccpetManIDList = accpetUserList.Select(p => p.AccpetManID).ToList();
            if (!ServiceAccpetManIDList.Contains(uid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            if (data.ServiceStatus != 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前工单状态不允许该操作");
                return;
            }
            string ServiceType2IDs = context.Request["ServiceType2ID"];
            var ServiceType2IDList = new List<int>();
            if (!string.IsNullOrEmpty(ServiceType2IDs))
            {
                ServiceType2IDList = Utility.JsonConvert.DeserializeObject<List<int>>(ServiceType2IDs);
            }
            if (ServiceType2IDList.Count == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "二级类型不能为空");
                return;
            }
            string ServiceType3IDs = context.Request["ServiceType3ID"];
            var ServiceType3IDList = new List<int>();
            if (!string.IsNullOrEmpty(ServiceType3IDs))
            {
                ServiceType3IDList = Utility.JsonConvert.DeserializeObject<List<int>>(ServiceType3IDs);
            }
            if (ServiceType3IDList.Count == 0)
            {
                var typeList3 = ServiceType.GetServiceTypeListByParentIDList(ServiceType2IDList.ToArray());
                if (typeList3.Length > 0)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "三级类型不能为空");
                    return;
                }
            }
            data.ServiceType1ID = WebUtil.GetIntValue(context, "ServiceType1ID");
            data.ServiceType2ID = ServiceType2IDs;
            data.ServiceType3ID = ServiceType3IDs;
            var chuli = new Foresight.DataAccess.CustomerServiceChuli();
            chuli.AddTime = DateTime.Now;
            chuli.ServiceID = data.ID;
            string ResponseContent = context.Request["ResponseContent"];
            if (!string.IsNullOrEmpty(ResponseContent))
            {
                chuli.ResponseRemark = ResponseContent;
                chuli.ResponseTime = DateTime.Now;
            }
            string CheckContent = context.Request["CheckContent"];
            if (!string.IsNullOrEmpty(CheckContent))
            {
                chuli.CheckRemark = CheckContent;
                chuli.CheckTime = DateTime.Now;
            }
            string CompleteContent = context.Request["CompleteContent"];
            decimal HandleFee = WebUtil.GetDecimalValue(context, "HandleFee");
            chuli.ChuliDate = DateTime.Now;
            chuli.ChuliNote = CompleteContent;
            chuli.AddTime = DateTime.Now;
            chuli.HandelFee = HandleFee;
            chuli.OtherFee = 0;
            chuli.RepartPartName = context.Request["RepairPart"];
            bool isComplete = WebUtil.GetBoolValue(context, "isComplete");
            bool isComplete_Ios = WebUtil.GetIntValue(context, "isComplete") == 1;
            if (isComplete_Ios)
            {
                isComplete = true;
            }
            var attachlist = new List<CustomerServiceChuli_Attach>();
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                        string filepath = "/upload/WechatServiceImg/";
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
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    if (isComplete)
                    {
                        data.ServiceStatus = 1;
                        data.BanJieTime = DateTime.Now;
                        data.IsRequireCost = HandleFee > 0;
                        data.BanJieNote = CompleteContent;
                        data.BanJieManUserID = uid;
                        data.BanJieManName = user.FinalRealName;
                        data.Save(helper);
                    }
                    else
                    {
                        data.Save(helper);
                    }
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
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "completeservice", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器异常");
                    return;
                }
            }
            string OperationTitle = "工单处理";
            string OperatoinContent = "员工" + user.FinalRealName + "在APP端对工单" + data.ServiceNumber + "执行了工单处理操作";
            string key = EnumModel.OperationModule.ServiceProcess.ToString();
            if (isComplete)
            {
                OperationTitle = "工单办结";
                OperatoinContent = "员工" + user.FinalRealName + "在APP端对工单" + data.ServiceNumber + "执行了工单办结操作";
                key = EnumModel.OperationModule.ServiceBanJie.ToString();
            }
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, key, OperationTitle, data.ID.ToString(), "Service", OperationMan: user.FinalRealName, IsHide: false);
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void acceptservice(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            var accpetUserList = CustomerService_Accpet.GetCustomerService_AccpetListByServiceID(data.ID, new int[] { 0 });
            if (accpetUserList.Length == 0)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            List<int> ServiceAccpetManIDList = accpetUserList.Select(p => p.AccpetManID).ToList();
            if (!ServiceAccpetManIDList.Contains(uid))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不属于您,禁止该操作");
                return;
            }
            if (data.ServiceStatus != 6)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "当前工单状态不允许该操作");
                return;
            }
            var user = Foresight.DataAccess.User.GetUser(uid);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update CustomerService set [ServiceStatus]=0,[AcceptTime]=getdate() where [ID]=@ID and [ServiceStatus]=6";
                    cmdtext += "update CustomerService_Accpet set [AccpetStatus]=1,[AccpetTime]=getdate() where [ID]=@ID and [AccpetManID]=@UserID and [AccpetUserType]=2";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", data.ID));
                    parameters.Add(new SqlParameter("@UserID", user.UserID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError(LogModuel, "acceptservice", ex);
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, "服务器异常");
                    return;
                }
            }
            string OperationTitle = "工单接受";
            string OperatoinContent = "员工" + user.FinalRealName + "在APP端对工单" + data.ServiceNumber + "执行了工单接受";
            APPCode.CommHelper.SaveOperationLog(OperatoinContent, "ServiceAccpet", OperationTitle, data.ID.ToString(), "Service", OperationMan: user.FinalRealName, IsHide: true);
            WebUtil.WriteJsonResult(context, "成功");
        }
        private void getservicedetail(HttpContext context)
        {
            var uid = GetUID(context);
            int ID = WebUtil.GetIntValue(context, "ID");
            var data = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceByID(ID);
            if (data == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "该工单不存在");
                return;
            }
            decimal HandelFee = 0;
            decimal.TryParse(data.HandelFee, out HandelFee);
            decimal TotalFee = data.TotalFee > 0 ? data.TotalFee : 0;
            decimal OtherFee = (TotalFee - HandelFee) > 0 ? (TotalFee - HandelFee) : 0;
            var serviceimgs = Foresight.DataAccess.CustomerServiceAttach.GetCustomerServiceAttachList(data.ID);
            var imglist = serviceimgs.Select(p =>
            {
                return new { url = WebUtil.GetContextPath() + p.AttachedFilePath, cacheurl = "" };
            });
            var item = new
            {
                ID = data.ID,
                ServiceType = data.ServiceTypeName,
                FullName = data.ServiceFullName,
                AppointTime = data.ServiceAppointTime > DateTime.MinValue ? data.ServiceAppointTime.ToString("yyyy-MM-dd HH:mm") : "",
                Content = string.IsNullOrEmpty(data.ServiceContent) ? "暂无详细描述" : data.ServiceContent,
                CustomerName = data.AddCustomerName,
                Status = data.ServiceStatus,
                RepairFee = HandelFee,
                TotalFee = TotalFee,
                OtherFee = OtherFee,
                CompleteTime = data.BanJieTime > DateTime.MinValue ? data.BanJieTime.ToString("yyyy-MM-dd HH:mm") : "",
                Result = data.BanJieNote,
                imglist = imglist,
                CustomerPhone = data.AddCallPhone,
                ServiceAccpetMan = data.FinalServiceAccpetMan,
                AcceptTime = data.FinalServiceAccpetTime > DateTime.MinValue ? data.FinalServiceAccpetTime.ToString("yyyy-MM-dd HH:mm") : "",
                ServiceProcessMan = data.FinalServiceProcessMan,
                ProcessTime = data.FinalServiceProcessTime > DateTime.MinValue ? data.FinalServiceProcessTime.ToString("yyyy-MM-dd HH:mm") : "",
            };
            WebUtil.WriteJsonResult(context, item);
        }
        private void getservicelist(HttpContext context)
        {
            var uid = GetUID(context);
            int status = WebUtil.GetIntValue(context, "status");
            string pageindex = context.Request.Form["pageindex"];
            string pagesize = context.Request.Form["pagesize"];
            long startRowIndex = long.Parse(pageindex);
            int pageSize = int.Parse(pagesize);
            int UserID = WebUtil.GetIntValue(context, "UserID");
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            List<int> ProjectIDList = new List<int>();
            long totals = 0;
            if (UserID == -1 || UserID > 0)
            {
                uid = UserID;
            }
            if (ProjectID > 0)
            {
                ProjectIDList = new List<int>() { ProjectID };
            }
            else
            {
                ProjectIDList = Foresight.DataAccess.RoleProject.GetRoleProjectListByUserID(uid).Select(p => p.ProjectID).ToList();
            }
            bool cansendorder = WebUtil.GetBoolValue(context, "cansendorder");
            bool cansendorder_ios = WebUtil.GetIntValue(context, "cansendorder") == 1;
            if (cansendorder_ios)
            {
                cansendorder = true;
            }
            string keywords = context.Request["keywords"];
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            var list = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceListByStatus(keywords, status, uid, startRowIndex, pageSize, out totals, StartTime, EndTime, ProjectIDList: ProjectIDList, cansendorder: cansendorder);
            var items = list.Select(p =>
            {
                DateTime BanJieTime = p.BanJieTime > DateTime.MinValue ? p.BanJieTime : p.AddTime;
                string content = string.IsNullOrEmpty(p.ServiceContent) ? "暂无详细说明" : p.ServiceContent;
                var item = new { ID = p.ID, Title = p.ServiceFullName, Content = content, ServiceType = p.CategoryPartA, Status = p.ServiceStatus, BanJieTime = BanJieTime.ToString("yyyy-MM-dd HH:mm") };
                return item;
            });
            bool showsendbtn = SysMenu.CheckSysModulesForUserByUserId(uid, ModuleCode: "1101172");
            WebUtil.WriteJsonResult(context, new { gongdanlist = items, showsendbtn = showsendbtn, totalcount = totals });
        }
        private void savedeviceid(HttpContext context)
        {
            var uid = GetUID(context);
            var user = Foresight.DataAccess.User.GetUser(uid);
            string DeviceId = context.Request["device_id"];
            string DeviceType = context.Request["device_type"];
            if (!string.IsNullOrEmpty(DeviceId))
            {
                user.APPUserDeviceID = DeviceId;
                user.APPUserDeviceType = DeviceType;
                user.Save();
            }
            WebUtil.WriteJsonResult(context, "保存成功");
        }
        private void getprojectlist(HttpContext context)
        {
            var uid = GetUID(context);
            var list = WebUtil.GetMyXiaoQuProjects(uid);
            if (list.Length == 0)
            {
                list = Foresight.DataAccess.Project.GetProjectByParentID(1);
            }
            var items = list.Select(p =>
            {
                return new { ID = p.ID, ProjectName = p.Name };
            });
            WebUtil.WriteJsonResult(context, new { list = items });
        }
        private void dologin(HttpContext context)
        {
            string LoginName = context.Request["Username"];
            string Password = context.Request["Password"];
            if (string.IsNullOrEmpty(LoginName))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "密码不能为空");
                return;
            }
            var user = User.GetAPPUserByLoginNamePassWord(LoginName, Password, UserTypeDefine.APPUser.ToString());
            if (user == null)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "用户名或密码错误");
                return;
            }
            if (user.IsLocked)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "帐号已被锁定,禁止登陆");
                return;
            }
            if (user.Type != UserTypeDefine.APPUser.ToString() && !user.IsAllowAPPUserLogin)
            {
                WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "非APP账号，禁止登陆");
                return;
            }
            string DeviceId = context.Request["device_id"];
            string DeviceType = context.Request["device_type"];
            if (!string.IsNullOrEmpty(DeviceId))
            {
                user.APPUserDeviceID = DeviceId;
                user.APPUserDeviceType = DeviceType;
            }
            user.Save();
            var ticket = new System.Web.Security.FormsAuthenticationTicket(1, user.UserID.ToString(), DateTime.Now,
                       DateTime.Now.AddYears(1), true, string.Empty);
            var uid = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            string headimg = string.IsNullOrEmpty(user.HeadImg) ? "" : WebUtil.GetContextPath() + user.HeadImg;
            string RealName = string.IsNullOrEmpty(user.RealName) ? user.LoginName : user.RealName;
            WebUtil.WriteJsonResult(context, new { uid = uid, username = RealName, headimg = headimg, phonenumber = user.PhoneNumber });
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #region Comm Methods
        static int GetUID(HttpContext context)
        {
            var uidStr = context.Request["uid"];
            if (!string.IsNullOrEmpty(uidStr))
            {
                var uid = 0;
                try
                {
                    var ticket = System.Web.Security.FormsAuthentication.Decrypt(uidStr);
                    uid = Convert.ToInt32(ticket.Name);
                }
                catch (Exception ex)
                {
                    throw new Exception("Decrypt uid fail", ex);
                }
                return uid;
            }
            else
            {
                throw new Exception("uid null");
            }
        }
        static int GetUID(HttpContext context, out User user)
        {
            user = null;
            int uid = GetUID(context);
            user = User.GetUser(uid);
            if (user == null)
            {
                throw new Exception("uid null");
            }
            return uid;
        }
        #endregion
    }
    public class ChaoBiaoModel
    {
        public int ID { get; set; }
        public decimal StartPoint { get; set; }
        public decimal EndPoint { get; set; }
    }
}