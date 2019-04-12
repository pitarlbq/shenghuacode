using Foresight.DataAccess;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// UserRoleHandler 的摘要说明
    /// </summary>
    public class UserRoleHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("UserHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadnoroles":
                        loadnoroles(context);
                        break;
                    case "loadinroles":
                        loadinroles(context);
                        break;
                    case "loadusers":
                        loadusers(context);
                        break;
                    case "addroles":
                        addroles(context);
                        break;
                    case "removeroles":
                        removeroles(context);
                        break;
                    case "loadnodepartments":
                        loadnodepartments(context);
                        break;
                    case "loadindepartments":
                        loadindepartments(context);
                        break;
                    case "adddepartments":
                        adddepartments(context);
                        break;
                    case "removedepartments":
                        removedepartments(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("UserRoleHandler", "命令:" + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void removedepartments(HttpContext context)
        {
            string UserIDs = context.Request["UserIDList"];
            string RoleIDs = context.Request["RoleIDList"];
            int[] UserIDList = new int[] { };
            int[] RoleIDList = new int[] { };
            if (!string.IsNullOrEmpty(UserIDs))
            {
                UserIDList = Utility.JsonConvert.DeserializeObject<int[]>(UserIDs);
            }
            if (!string.IsNullOrEmpty(RoleIDs))
            {
                RoleIDList = Utility.JsonConvert.DeserializeObject<int[]>(RoleIDs);
            }
            if (UserIDList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择用户" });
                return;
            }
            if (RoleIDList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择部门" });
                return;
            }
            bool status = UserDepartment.Remove_UserDepartment(UserIDList, RoleIDList);
            WebUtil.WriteJson(context, new { status = status });
        }
        private void adddepartments(HttpContext context)
        {
            string UserIDs = context.Request["UserIDList"];
            string RoleIDs = context.Request["RoleIDList"];
            int[] UserIDList = new int[] { };
            int[] RoleIDList = new int[] { };
            if (!string.IsNullOrEmpty(UserIDs))
            {
                UserIDList = Utility.JsonConvert.DeserializeObject<int[]>(UserIDs);
            }
            if (!string.IsNullOrEmpty(RoleIDs))
            {
                RoleIDList = Utility.JsonConvert.DeserializeObject<int[]>(RoleIDs);
            }
            if (UserIDList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择用户" });
                return;
            }
            if (RoleIDList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择部门" });
                return;
            }
            bool status = UserDepartment.Save_UserDepartment(UserIDList, RoleIDList);
            WebUtil.WriteJson(context, new { status = status });
        }
        private void loadindepartments(HttpContext context)
        {
            try
            {
                int UserID = GetIntValue(context, "UserID");
                Foresight.DataAccess.CKDepartment[] items = Foresight.DataAccess.CKDepartment.GetAdminInDepartmentList(UserID);
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserRoleHandler", "命令: loadindepartments", ex);
                context.Response.Write("[]");
            }
        }
        private void loadnodepartments(HttpContext context)
        {
            try
            {
                string keywords = context.Request["keywords"];
                int UserID = GetIntValue(context, "UserID");
                Foresight.DataAccess.CKDepartment[] items = Foresight.DataAccess.CKDepartment.GetAdminNotInDepartmentList(UserID, keywords);
                WebUtil.WriteJson(context, items);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserRoleHandler", "命令: loadnodepartments", ex);
                context.Response.Write("[]");
            }
        }
        private void loadusers(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                if (string.IsNullOrEmpty(page) || string.IsNullOrEmpty(rows))
                {
                    var users = Foresight.DataAccess.User.GetSysAPPUserList();
                    string result = JsonConvert.SerializeObject(users);
                    context.Response.Write(result);
                    return;
                }
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = User.GeUserGridByKeywords(Keywords, "order by UserID desc", startRowIndex, pageSize);
                if (dg != null)
                {
                    string result = JsonConvert.SerializeObject(dg);
                    context.Response.Write(result);
                    return;
                }
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserRoleHandler", "命令: loadusers", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void removeroles(HttpContext context)
        {
            string UserIDs = context.Request["UserIDList"];
            string RoleIDs = context.Request["RoleIDList"];
            int[] UserIDList = new int[] { };
            int[] RoleIDList = new int[] { };
            if (!string.IsNullOrEmpty(UserIDs))
            {
                UserIDList = Utility.JsonConvert.DeserializeObject<int[]>(UserIDs);
            }
            if (!string.IsNullOrEmpty(RoleIDs))
            {
                RoleIDList = Utility.JsonConvert.DeserializeObject<int[]>(RoleIDs);
            }
            if (UserIDList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择用户" });
                return;
            }
            if (RoleIDList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择角色" });
                return;
            }
            bool status = UserRole.Remove_UserRole(UserIDList, RoleIDList);
            WebUtil.WriteJson(context, new { status = status });
        }
        private void addroles(HttpContext context)
        {
            string UserIDs = context.Request["UserIDList"];
            string RoleIDs = context.Request["RoleIDList"];
            int[] UserIDList = new int[] { };
            int[] RoleIDList = new int[] { };
            if (!string.IsNullOrEmpty(UserIDs))
            {
                UserIDList = Utility.JsonConvert.DeserializeObject<int[]>(UserIDs);
            }
            if (!string.IsNullOrEmpty(RoleIDs))
            {
                RoleIDList = Utility.JsonConvert.DeserializeObject<int[]>(RoleIDs);
            }
            if (UserIDList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择用户" });
                return;
            }
            if (RoleIDList.Length == 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "请选择角色" });
                return;
            }
            bool status = UserRole.Save_UserRole(UserIDList, RoleIDList);
            WebUtil.WriteJson(context, new { status = status });
        }
        private void loadinroles(HttpContext context)
        {
            try
            {
                int UserID = GetIntValue(context, "UserID");
                Foresight.DataAccess.Role[] role = Foresight.DataAccess.Role.GetAdminInRoleList(UserID);
                string JsonValue = JsonConvert.SerializeObject(role);
                context.Response.Write(JsonValue);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserRoleHandler", "命令: loadinroles", ex);
                context.Response.Write("[]");
            }
        }
        private void loadnoroles(HttpContext context)
        {
            try
            {
                int UserID = GetIntValue(context, "UserID");
                Foresight.DataAccess.Role[] role = Foresight.DataAccess.Role.GetAdminNotInRoleList(UserID);
                string JsonValue = JsonConvert.SerializeObject(role);
                context.Response.Write(JsonValue);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserRoleHandler", "命令: loadnoroles", ex);
                context.Response.Write("[]");
            }
        }
        private int GetIntValue(HttpContext context, string name)
        {
            int value = int.MinValue;
            int.TryParse(context.Request.Params[name], out value);
            return value;
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