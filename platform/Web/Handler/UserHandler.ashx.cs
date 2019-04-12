using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class UserHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("UserHandler", "visit为空");
                context.Response.Write("visit为空");
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loaduserlist":
                        LoadUserList(context);
                        break;
                    case "saveuserinfo":
                        SaveUserInfo(context);
                        break;
                    case "savecompanyinfo":
                        SaveCompanyInfo(context);
                        break;
                    case "removeuser":
                        RemoveUser(context);
                        break;
                    case "saveuserpwd":
                        SaveUserPwd(context);
                        break;
                    case "loadrolelist":
                        LoadRoleList(context);
                        break;
                    case "saveroleinfo":
                        SaveRoleInfo(context);
                        break;
                    case "removerole":
                        RemoveRole(context);
                        break;
                    case "loadcompanylist":
                        LoadCompanyList(context);
                        break;
                    case "removecompany":
                        RemoveCompany(context);
                        break;
                    case "saveapppwd":
                        saveapppwd(context);
                        break;
                    case "removecompanylogo":
                        removecompanylogo(context);
                        break;
                    case "getcompanyinfo":
                        getcompanyinfo(context);
                        break;
                    case "loadoperationloggrid":
                        loadoperationloggrid(context);
                        break;
                    case "removeuserfamily":
                        removeuserfamily(context);
                        break;
                    case "socketinit":
                        socketinit(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("UserHandler", "命令:" + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void socketinit(HttpContext context)
        {
            var config = new Utility.SiteConfig();
            WebUtil.WriteJson(context, new { loginname = Web.WebUtil.GetUserLoginFullName(context) + Web.WebUtil.GetUser(context).LoginName, guid = HttpContext.Current.User.Identity.Name, url = config.SITE_URL, socketserver = config.SocketURL });
        }
        private void removeuserfamily(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "update [User] set [Type]=@Type where UserID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@Type", UserTypeDefine.APPCustomer.ToString()));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("UserHandler", "命令: removeuserfamily", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void loadoperationloggrid(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                string OperationKey = context.Request["OperationKey"];
                DataGrid dg = OperationLog.GeOperationLogGridByKeywords(Keywords, StartTime, EndTime, OperationKey, "order by [OperationTime] desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserHandler", "命令: loadoperationloggrid", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void getcompanyinfo(HttpContext context)
        {
            string BaseURL = WebUtil.GetContextPath();
            string errormsg = string.Empty;
            Foresight.DataAccess.Company company = WebUtil.GetCompany(context, readCache: false);
            string Login_LogoImg = company != null ? company.Login_LogImg : string.Empty;
            string Login_BodyImg = company != null ? company.Login_BodyImg : string.Empty;
            string Home_LogoImg = company != null ? company.Home_LogoImg : string.Empty;
            string CompanyName = company != null ? company.CompanyName : string.Empty;
            string CopyRightText = company != null ? company.CopyRightText : string.Empty;
            string ExpiringMsg = company != null ? company.ExpiringMsg : string.Empty;

            bool IsHideLogin_LogImg = company != null ? company.IsHideLogin_LogImg : false;
            bool IsHideLogin_BodyImg = company != null ? company.IsHideLogin_BodyImg : false;
            bool IsHideHome_LogoImg = company != null ? company.IsHideHome_LogoImg : false;
            bool IsHideCopyRightText = company != null ? company.IsHideCopyRightText : false;
            bool ExpiringShow = company != null ? company.ExpiringShow : false;
            DateTime EndTime = company != null ? company.ServerEndTime : DateTime.MinValue;
            int ExpiringDay = company != null ? company.ExpiringDay : 0;
            WebUtil.WriteJson(context, new { status = true, Login_LogoImg = Login_LogoImg, Login_BodyImg = Login_BodyImg, errormsg = errormsg, Home_LogoImg = Home_LogoImg, CompanyName = CompanyName, IsHideLogin_LogImg = IsHideLogin_LogImg, IsHideLogin_BodyImg = IsHideLogin_BodyImg, IsHideHome_LogoImg = IsHideHome_LogoImg, CopyRightText = CopyRightText, IsHideCopyRightText = IsHideCopyRightText, ExpiringShow = ExpiringShow, ExpiringDay = ExpiringDay, ExpiringMsg = ExpiringMsg });
        }
        private void removecompanylogo(HttpContext context)
        {
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            int index = WebUtil.GetIntValue(context, "index");
            var company = Foresight.DataAccess.Company.GetCompany(CompanyID);
            if (company == null)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "公司不存在" });
                return;
            }
            if (index == 0)
            {
                company.Login_LogImg = string.Empty;
            }
            else if (index == 1)
            {
                company.Login_BodyImg = string.Empty;
            }
            else
            {
                company.Home_LogoImg = string.Empty;
            }
            company.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveapppwd(HttpContext context)
        {
            int RelationID = GetIntValue(context, "RelationID");
            var relation = RoomPhoneRelation.GetRoomPhoneRelation(RelationID);
            if (relation == null)
            {
                WebUtil.WriteJson(context, new { status = false, errormsg = "房间用户不存在" });
                return;
            }
            string LoginName = context.Request.Params["LoginName"];
            string Pwd = context.Request.Params["Password"];
            int IsLocked = WebUtil.GetIntValue(context, "IsLocked");
            User user = null;
            if (relation.UserID > 0)
            {
                user = User.GetUser(relation.UserID);
            }
            var exist_user = User.GetAPPUserByLoginName(LoginName);
            if (user == null && exist_user != null)
            {
                WebUtil.WriteJson(context, new { status = false, errormsg = "登录名已存在" });
                return;
            }
            if (user != null && exist_user != null && user.UserID != exist_user.UserID)
            {
                WebUtil.WriteJson(context, new { status = false, errormsg = "登录名已存在" });
                return;
            }
            if (user == null)
            {
                user = new User();
                user.CreateTime = DateTime.Now;
                user.Type = UserTypeDefine.APPCustomer.ToString();
                user.RealName = relation.RelationName;
                user.RelationID = RelationID;
            }
            user.LoginName = LoginName;
            if (!string.IsNullOrEmpty(Pwd))
            {
                user.Password = User.EncryptPassword(Pwd);
            }
            user.IsLocked = IsLocked == 1 ? true : false;
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    user.Save(helper);
                    relation.UserID = user.UserID;
                    relation.Save(helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("UserHandler", "saveapppwd", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
            var company = Foresight.DataAccess.Company.GetCompany(WebUtil.GetCompanyID(context));
            string errormsg = string.Empty;
            var usercompany = Foresight.DataAccess.UserCompany.GetUserCompanyByUserID(user.UserID);
            if (usercompany != null)
            {
                usercompany.Delete();
            }
            usercompany = new UserCompany();
            usercompany.CompanyID = company.CompanyID;
            usercompany.UserID = user.UserID;
            usercompany.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void SaveCompanyInfo(HttpContext context)
        {
            int CompanyID = GetIntValue(context, "CompanyID");
            Foresight.DataAccess.Company company = null;
            if (CompanyID > 0)
            {
                company = Company.GetCompany(CompanyID);
            }
            if (company == null)
            {
                company = new Company();
                company.AddTime = DateTime.Now;
            }
            company.CompanyName = context.Request.Params["CompanyName"];
            company.PhoneNumber = context.Request.Params["PhoneNumber"];
            company.CompanyDesc = context.Request.Params["Description"];
            company.IsActive = GetIntValue(context, "IsActive") == 0 ? false : true;
            company.IsPay = GetIntValue(context, "IsPay") == 0 ? false : true;
            company.Address = context.Request.Params["Address"];
            company.ChargePerson = context.Request.Params["ChargeMan"];
            company.Distributor = context.Request.Params["Distributor"];
            company.UserCount = GetIntValue(context, "UserCount");
            company.ServerStartTime = GetDateTimeValue(context, "StartTime");
            company.ServerEndTime = GetDateTimeValue(context, "EndtTime");
            company.IsHideLogin_LogImg = WebUtil.GetIntValue(context, "IsHideLogin_LogImg") == 1;
            company.IsHideLogin_BodyImg = WebUtil.GetIntValue(context, "IsHideLogin_BodyImg") == 1;
            company.IsHideHome_LogoImg = WebUtil.GetIntValue(context, "IsHideHome_LogoImg") == 1;
            company.IsHideCopyRightText = WebUtil.GetIntValue(context, "IsHideCopyRightText") == 1;
            company.CopyRightText = context.Request["CopyRightText"];
            company.AlowRemoteUpdate = WebUtil.GetIntValue(context, "AlowRemoteUpdate") == 1;
            company.IsWechatOn = WebUtil.GetIntValue(context, "IsWechatOn") == 1;
            company.VersionCode = GetIntValue(context, "VersionCode");
            company.ExpiringDay = WebUtil.GetIntValue(context, "ExpiringDay");
            company.ExpiringShow = WebUtil.GetIntValue(context, "ExpiringShow") == 1;
            company.ExpiringMsg = context.Request["ExpiringMsg"];
            if (!string.IsNullOrEmpty(context.Request["ProjectCount"]))
            {
                int ProjectCount = WebUtil.GetIntValue(context, "ProjectCount");
                company.ProjectCount = ProjectCount;
            }
            else
            {
                company.ProjectCount = int.MinValue;
            }
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
                        string filepath = "/upload/Project/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        if (i == 0)
                        {
                            company.Login_LogImg = filepath + fileName;
                        }
                        else if (i == 1)
                        {
                            company.Login_BodyImg = filepath + fileName;
                        }
                        else
                        {
                            company.Home_LogoImg = filepath + fileName;
                        }
                    }
                }
            }
            company.Save();
            string errormsg = string.Empty;
            context.Response.Write("{\"status\":true}");
        }
        private void RemoveCompany(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Company] where [CompanyID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    cmdtext += "delete from [UserCompany] where [CompanyID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("UserHandler", "命令: RemoveCompany", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void LoadCompanyList(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                int SiteStatus = WebUtil.GetIntValue(context, "SiteStatus");
                int ServerLocation = int.MinValue;
                if (!string.IsNullOrEmpty(context.Request["ServerLocation"]))
                {
                    ServerLocation = WebUtil.GetIntValue(context, "ServerLocation");
                }
                int ActiveStatus = WebUtil.GetIntValue(context, "ActiveStatus");
                int IsWechatOn = WebUtil.GetIntValue(context, "IsWechatOn");
                DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
                DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
                DataGrid dg = Company.GeCompanyGridByKeywords(Keywords, SiteStatus, ServerLocation, "order by [IsAdmin] desc, [AddTime] desc", startRowIndex, pageSize, ActiveStatus, IsWechatOn, StartTime, EndTime);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserHandler", "命令: LoadCompanyList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void RemoveRole(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            var user_list = Foresight.DataAccess.User.GetUserListByRoleIDList(IDList);
            if (user_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "选中的角色包含用户，请先删除用户" });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Roles] where [RoleID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    cmdtext += "delete from [UserRoles] where [RoleID] in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("UserHandler", "命令: RemoveRole", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void SaveRoleInfo(HttpContext context)
        {
            int RoleID = GetIntValue(context, "RoleID");
            Foresight.DataAccess.Role role = new Role();
            if (RoleID > 0)
            {
                role = Role.GetRole(RoleID);
                if (role == null)
                {
                    role = new Role();
                }
            }
            role.RoleName = context.Request.Params["RoleName"];
            role.RoleDes = context.Request.Params["RoleDes"];
            role.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void LoadRoleList(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = Role.GeRoleGridByKeywords(Keywords, "order by RoleID desc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserHandler", "命令: LoadRoleList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void SaveUserPwd(HttpContext context)
        {
            int UserID = GetIntValue(context, "UserID");
            string LoginName = context.Request.Params["LoginName"];
            string Pwd = context.Request.Params["Password"];
            var user = User.GetUser(UserID);
            user.LoginName = LoginName;
            user.Password = User.EncryptPassword(Pwd);
            user.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void RemoveUser(HttpContext context)
        {
            string IDListArry = context.Request.Params["IDList"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDListArry))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDListArry);
            }
            if (IDList.Count > 0)
            {
                var users = Foresight.DataAccess.User.GetUserListByIDList(IDList);
                var app_users = users.Where(p => p.Type.Equals(UserTypeDefine.APPUser.ToString())).ToArray();
                bool delete_success = true;
                string errormsg = string.Empty;
                if (app_users.Length > 0)
                {
                    List<int> UserIDList = app_users.Select(p => p.UserID).ToList();
                    var company = Company.GetCompanyByUserID(WebUtil.GetUser(context).UserID);
                }
                if (!delete_success)
                {
                    WebUtil.WriteJson(context, new { status = false, error = errormsg });
                    return;
                }
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [User] where [UserID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        cmdtext += "delete from [UserRoles] where [UserID] in (" + string.Join(",", IDList.ToArray()) + ");";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("UserHandler", "命令: RemoveUser", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                string UserNames = string.Join(",", users.Select(p => p.RealName).ToArray());
                #region 删除账号日志
                APPCode.CommHelper.SaveOperationLog("删除账号" + UserNames, Utility.EnumModel.OperationModule.RemoveUser.ToString(), "删除账号", IDListArry, "User", IsHide: true);
                #endregion
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void SaveUserInfo(HttpContext context)
        {
            bool new_user_add = false;
            string UserType = context.Request["UserType"];
            UserType = string.IsNullOrEmpty(UserType) ? UserTypeDefine.SystemUser.ToString() : UserType;
            int UserID = GetIntValue(context, "UserID");
            int CompanyID = GetIntValue(context, "CompanyID");
            CompanyID = CompanyID <= 0 ? WebUtil.GetCompanyID(context) : CompanyID;
            Foresight.DataAccess.User user = null;
            Foresight.DataAccess.Company company = null;
            int isLocked = GetIntValue(context, "IsLocked");
            bool IsAllowSysLogin = WebUtil.GetIntValue(context, "IsAllowSysLogin") == 1;

            int user_type = WebUtil.GetIntValue(context, "user_type");
            if (UserID > 0)
            {
                user = User.GetUser(UserID);
            }
            if (user == null || isLocked == 0)
            {
                if (UserType.Equals(UserTypeDefine.SystemUser.ToString()) || IsAllowSysLogin)
                {
                    company = WebUtil.GetCompany(context, false);
                    int userCount = company.UserCount;
                    int TotalCount = Foresight.DataAccess.User.GetSysUserCount();
                    if (user == null || (user != null && user.IsLocked))
                    {
                        TotalCount = TotalCount + 1;
                    }
                    if (TotalCount > userCount)
                    {
                        WebUtil.WriteJson(context, new { status = true, addfailed = true });
                        return;
                    }
                }
            }
            if (user == null)
            {
                new_user_add = true;
                user = new User();
                user.CreateTime = DateTime.Now;
            }
            string LoginName = context.Request.Params["LoginName"];
            if (UserType.Equals(UserTypeDefine.SystemUser.ToString()))
            {
                var sameuser = Foresight.DataAccess.User.GetUserByLoginName(LoginName);
                if (sameuser != null && sameuser.UserID != user.UserID)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "登录名已存在" });
                    return;
                }
            }
            else
            {
                var sameuser = Foresight.DataAccess.User.GetAPPUserByLoginName(LoginName);
                if (sameuser != null && sameuser.UserID != user.UserID)
                {
                    if (UserType.Equals(Foresight.DataAccess.UserTypeDefine.APPUser.ToString()) && sameuser.Type.Equals(UserTypeDefine.APPCustomer.ToString()))
                    {
                        user = sameuser;
                    }
                    else
                    {
                        WebUtil.WriteJson(context, new { status = false, error = "登录名已存在" });
                        return;
                    }
                }
            }
            if (user_type <= 0 || new_user_add)
            {
                user.Type = UserType;
            }
            user.NickName = context.Request.Params["NickName"];
            user.RealName = context.Request.Params["RealName"];
            user.PhoneNumber = context.Request.Params["PhoneNumber"];
            user.Gender = context.Request.Params["Gender"];
            user.IsLocked = isLocked == 0 ? false : true;
            if (user.IsLocked)
            {
                user.LockTime = DateTime.Now;
            }
            if (!user.IsLocked)
            {
                user.ActiveTime = DateTime.Now;
            }
            string Pwd = context.Request.Params["Password"];
            user.LoginName = LoginName;
            if (!string.IsNullOrEmpty(Pwd))
            {
                user.Password = User.EncryptPassword(Pwd);
            }
            user.IsAllowSysLogin = IsAllowSysLogin;
            user.IsAllowAPPUserLogin = WebUtil.GetIntValue(context, "IsAllowAPPUserLogin") == 1;
            user.HotPhoneLine = context.Request.Params["HotPhoneLine"];
            user.BelongServiceName = context.Request.Params["BelongServiceName"];
            user.QQNumber = context.Request.Params["QQNumber"];
            user.OpenID = context.Request.Params["OpenID"];
            user.PositionName = context.Request["PositionName"];
            user.Education = context.Request["Education"];
            user.DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");
            user.FixedPoint = WebUtil.GetIntValue(context, "FixedPoint");
            user.FixedPointUpdateDate = WebUtil.GetDateValue(context, "FixedPointUpdateDate");
            user.IsAllowPhrase = WebUtil.GetIntValue(context, "IsAllowPhrase") == 1;
            string DepartmentIDs = context.Request["DepartmentIDList"];
            int[] DepartmentIDList = new int[] { };
            if (!string.IsNullOrEmpty(DepartmentIDs))
            {
                DepartmentIDList = Utility.JsonConvert.DeserializeObject<int[]>(DepartmentIDs);
            }
            UserDepartment[] userDepartmentList = new UserDepartment[] { };
            if (user.UserID > 0)
            {
                userDepartmentList = UserDepartment.GetUserDepartmentListByMinMaxUserID(user.UserID, user.UserID);
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    user.Save(helper);
                    foreach (var item in userDepartmentList)
                    {
                        item.Delete(helper);
                    }
                    foreach (var DepartmentID in DepartmentIDList)
                    {
                        var data = new UserDepartment();
                        data.UserID = user.UserID;
                        data.DepartmentID = DepartmentID;
                        data.Save(helper);
                    }
                    var usercompany = Foresight.DataAccess.UserCompany.GetUserCompanyByUserID(user.UserID, helper);
                    if (usercompany == null)
                    {
                        usercompany = new UserCompany();
                        usercompany.CompanyID = CompanyID;
                    }
                    usercompany.UserID = user.UserID;
                    usercompany.Save(helper);
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
            //if (UserType.Equals(UserTypeDefine.APPUser.ToString()))
            //{
            //    company = Foresight.DataAccess.Company.GetCompanies().FirstOrDefault();
            //    string errormsg = string.Empty;
            //    if (!EncryptHelper.SaveAPPUser(company, user.LoginName, user.Password, user.UserID, user.Type, out errormsg))
            //    {
            //        user.Delete();
            //        WebUtil.WriteJson(context, new { status = false, error = errormsg });
            //        return;
            //    }
            //}
            if (new_user_add)
            {
                #region 新增账号日志
                APPCode.CommHelper.SaveOperationLog("新增账号" + user.LoginName, Utility.EnumModel.OperationModule.AddUser.ToString(), "新增账号", user.UserID.ToString(), "User", IsHide: true);
                #endregion
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private int GetIntValue(HttpContext context, string name)
        {
            int value = int.MinValue;
            int.TryParse(context.Request.Params[name], out value);
            return value;
        }
        private DateTime GetDateTimeValue(HttpContext context, string name)
        {
            DateTime value = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params[name], out value);
            return value;
        }
        private void LoadUserList(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                bool can_export = false;
                if (!string.IsNullOrEmpty(context.Request["can_export"]))
                {
                    bool.TryParse(context.Request["can_export"], out can_export);
                }
                long startRowIndex = 0;
                int pageSize = 0;
                if (!can_export)
                {
                    string page = context.Request.Form["page"];
                    string rows = context.Request.Form["rows"];
                    startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                    pageSize = int.Parse(rows);
                }
                int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
                string UserType = context.Request["UserType"];
                int UserRoomType = WebUtil.GetIntValue(context, "UserRoomType");
                bool IsAPPCustomer = false;
                if (!string.IsNullOrEmpty(context.Request["IsAPPCustomer"]))
                {
                    bool.TryParse(context.Request["IsAPPCustomer"], out IsAPPCustomer);
                }
                bool IsAPPCustomerFamily = false;
                if (!string.IsNullOrEmpty(context.Request["IsAPPCustomerFamily"]))
                {
                    bool.TryParse(context.Request["IsAPPCustomerFamily"], out IsAPPCustomerFamily);
                }
                bool IsAPPUser = false;
                if (!string.IsNullOrEmpty(context.Request["IsAPPUser"]))
                {
                    bool.TryParse(context.Request["IsAPPUser"], out IsAPPUser);
                }
                bool IsAPPBusiness = false;
                if (!string.IsNullOrEmpty(context.Request["IsAPPBusiness"]))
                {
                    bool.TryParse(context.Request["IsAPPBusiness"], out IsAPPBusiness);
                }
                int ParentUserID = WebUtil.GetIntValue(context, "ParentUserID");
                int BusinessID = WebUtil.GetIntValue(context, "BusinessID");
                int DepartmentID = WebUtil.GetIntValue(context, "DepartmentID");

                var company = WebUtil.GetCompany(context);
                int UserID = WebUtil.GetUser(context).UserID;

                int DepartmentCompanyID = WebUtil.GetIntValue(context, "DepartmentCompanyID");

                bool IsAPPCustomerAndUser = WebUtil.GetBoolValue(context, "IsAPPCustomerAndUser");
                DataGrid dg = UserDetail.GetUserDetailGridByKeywords(Keywords, CompanyID, UserType, "order by UserID desc", startRowIndex, pageSize, UserRoomType, IsAPPCustomer, IsAPPCustomerFamily, IsAPPBusiness, BusinessID, ParentUserID, IsAPPUser, company, can_export: can_export, UserID: UserID, DepartmentID: DepartmentID, IsAPPCustomerAndUser: IsAPPCustomerAndUser, DepartmentCompanyID: DepartmentCompanyID);
                if (can_export)
                {
                    var list = dg.rows as UserDetail[];
                    if (list.Length > 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("昵称");
                        dt.Columns.Add("电话");
                        dt.Columns.Add("性别");
                        dt.Columns.Add("登录名");
                        dt.Columns.Add("是否有效");
                        dt.Columns.Add("用户类型");
                        dt.Columns.Add("用户小区");
                        for (int i = 0; i < list.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["昵称"] = list[i].NickName;
                            dr["电话"] = list[i].PhoneNumber;
                            dr["性别"] = list[i].Gender;
                            dr["登录名"] = list[i].LoginName;
                            dr["是否有效"] = list[i].IsLockedDesc;
                            dr["用户类型"] = list[i].UserRoomTypeDesc;
                            if (list[i].UserRoomDesc != null && list[i].UserRoomDesc.Count > 0)
                            {
                                dr["用户小区"] = string.Join(",", list[i].UserRoomDesc);
                            }
                            dt.Rows.Add(dr);
                        }
                        string FileName = "APP用户" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导出.xls";
                        string FileLocation = "/upload/ExcelExport/ExportUser/";
                        string filepath = context.Server.MapPath("~" + FileLocation);
                        if (!System.IO.Directory.Exists(filepath))
                        {
                            System.IO.Directory.CreateDirectory(filepath);
                        }
                        string strFileName = System.IO.Path.Combine(filepath, FileName);
                        ExcelProcess.ExcelExportHelper.ReportExcel(dt, strFileName);
                        WebUtil.WriteJson(context, new { status = true, downloadurl = WebUtil.GetContextPath() + FileLocation + FileName });
                    }
                    else
                    {
                        WebUtil.WriteJson(context, new { status = false, error = "没有可以导出的数据" });
                    }
                }
                else
                {
                    WebUtil.WriteJson(context, dg);
                    return;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserHandler", "LoadUserList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
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