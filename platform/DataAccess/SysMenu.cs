using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a SysMenu.
    /// </summary>
    public partial class SysMenu : EntityBase
    {
        public static SysMenu[] GetSysMenuForUser(int userID, int ParentID, string GroupName = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([Disabled],0)=0");
            //conditions.Add("[IsAuthority]=0");
            if (userID > 0)
            {
                parameters.Add(new SqlParameter("@UserID", userID));
                conditions.Add("([ModuleCode] is NULL or [ModuleCode]='' or ID in (select ModuleId from RoleModule where RoleID in (select RoleID from UserRoles where [UserID]=@UserID) or [UserID]=@UserID))");
            }
            if (!string.IsNullOrEmpty(GroupName) && ParentID == 0)
            {
                conditions.Add("isnull([GroupName],'wynk')=@GroupName");
                parameters.Add(new SqlParameter("@GroupName", GroupName));
            }
            if (ParentID > int.MinValue)
            {
                conditions.Add("[ParentID]=@ParentID");
                parameters.Add(new SqlParameter("@ParentID", ParentID));
            }

            var list = GetList<SysMenu>("select * from [SysMenu] where " + string.Join(" and ", conditions.ToArray()) + " order by SortOrder", parameters).ToArray();
            var myServiceItem = list.FirstOrDefault(p => p.ID == 53);
            if (myServiceItem != null)
            {
                conditions = new List<string>();
                conditions.Add("exists(select 1 from [ServiceType] where [GongDanType]=1 and [ID]=[UserServiceType].ServiceTypeID)");
                conditions.Add("([UserID]=@UserID or exists(select 1 from [UserRoles] where [RoleID]=[UserServiceType].RoleID and [UserID]=@UserID))");
                var data = GetOne<UserServiceType>("select * from [UserServiceType] where " + string.Join(" and ", conditions.ToArray()), parameters);
                if (data == null)
                {
                    list = list.Where(p => p.ID != myServiceItem.ID).ToArray();
                }
            }
            myServiceItem = list.FirstOrDefault(p => p.ID == 502);
            if (myServiceItem != null)
            {
                conditions = new List<string>();
                conditions.Add("exists(select 1 from [ServiceType] where [GongDanType]=2 and [ID]=[UserServiceType].ServiceTypeID)");
                conditions.Add("([UserID]=@UserID or exists(select 1 from [UserRoles] where [RoleID]=[UserServiceType].RoleID and [UserID]=@UserID))");
                var data = GetOne<UserServiceType>("select * from [UserServiceType] where " + string.Join(" and ", conditions.ToArray()), parameters);
                if (data == null)
                {
                    list = list.Where(p => p.ID != myServiceItem.ID).ToArray();
                }
            }
            return list;
        }
        public static SysMenu[] GetAllSysMenuList(int ParentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@ParentID", ParentID));
            conditions.Add("[ParentID]=@ParentID");
            conditions.Add("isnull([Disabled],0)=0");
            string sqlText = "select * from [SysMenu] where " + string.Join(" and ", conditions.ToArray());
            return GetList<SysMenu>(sqlText, parameters).ToArray();
        }
        public static SysMenu[] GetSysModulesForUserByUserId(int userId, string ModuleCode = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userId));
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (select [ModuleId] from [RoleModule] where [RoleId] in (select [RoleID] from [UserRoles] where [UserID] = @UserId) or [UserID]=@UserId)");
            if (!string.IsNullOrEmpty(ModuleCode))
            {
                conditions.Add("[ModuleCode]=@ModuleCode");
                parameters.Add(new SqlParameter("@ModuleCode", ModuleCode));
            }
            return GetList<SysMenu>("select * from [SysMenu] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static SysMenu[] GetSysModulesByCompany(int CompanyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            return GetList<SysMenu>("select * from [SysMenu] where [ID] in (select [ModuleId] from [CompanyModule] where [CompanyID]=@CompanyID)", parameters).ToArray();
        }
        public static SysMenu[] GetSysModulesByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (IDList.Count == 0)
            {
                return new SysMenu[] { };
            }
            return GetList<SysMenu>("select * from [SysMenu] where [ID] in (" + string.Join(",", IDList.ToArray()) + ");", parameters).ToArray();
        }
        public static List<Dictionary<string, object>> GetAPPUserMenuList(int UserID)
        {
            if (UserID <= 0)
            {
                return new List<Dictionary<string, object>>();
            }
            string cmdtext = "select * from [SysMenu] where ([Disabled] is null or [Disabled]=0) and [GroupName]=@GroupName and [ParentID]=0 and [ID] in (select [ModuleId] from [RoleModule] where [RoleId] in (select [RoleID] from [UserRoles] where [UserID] = @UserId) or [UserID]=@UserId) order by [SortOrder] asc";
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@GroupName", Utility.EnumModel.SysMenuGroupNameDefine.wynkapp.ToString()));
            parameters.Add(new SqlParameter("@UserId", UserID));
            var list = GetList<SysMenu>(cmdtext, parameters).ToArray();
            var items = list.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["name"] = p.Name;
                dic["url"] = p.Url;
                dic["css"] = p.CssClass;
                return dic;
            }).ToList();
            return items;
        }
        public static bool CheckSysModulesForUserByUserId(int userId, string ModuleCode = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = string.Empty;
            if (userId > 0)
            {
                cmdwhere = " and ([RoleId] in (select [RoleID] from [UserRoles] where [UserID] = @UserId) or [UserID]=@UserId)";
                parameters.Add(new SqlParameter("@UserId", userId));
            }
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (select [ModuleId] from [RoleModule] where 1=1 " + cmdwhere + ")");
            if (!string.IsNullOrEmpty(ModuleCode))
            {
                conditions.Add("[ModuleCode]=@ModuleCode");
                parameters.Add(new SqlParameter("@ModuleCode", ModuleCode));
            }
            using (SqlHelper helper = new SqlHelper())
            {
                int total = 0;
                string cmdtext = "select count(1) from [SysMenu] where " + string.Join(" and ", conditions.ToArray());
                var obj = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (obj != null)
                {
                    total = Convert.ToInt32(obj);
                }
                return total > 0;
            }
        }
        public static SysMenu[] GetSysMenuPageCodeList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetList<SysMenu>("select [ModuleCode],[GroupName] from [SysMenu] where GroupName is not null and ParentID=0", parameters).ToArray();
        }
    }
}
