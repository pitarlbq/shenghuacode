using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Role.
    /// </summary>
    public partial class Role : EntityBase
    {
        public static Ui.DataGrid GeRoleGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[RoleName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Roles].* ";
            string Statement = " from [Roles] where  " + string.Join(" and ", conditions.ToArray());
            Role[] list = new Role[] { };
            list = GetList<Role>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Role[] GetAdminNotInRoleList(int UserId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            if (UserId > 0)
            {
                parameters.Add(new SqlParameter("@UserId", UserId));
                cmd += " and [RoleID] not in (select RoleID from [UserRoles] where UserID=@UserId)";
            }
            string sqlText = "select * from [Roles] where 1=1 " + cmd;
            return GetList<Role>(sqlText, parameters).ToArray();
        }
        public static Role[] GetAdminInRoleList(int UserId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            if (UserId > 0)
            {
                parameters.Add(new SqlParameter("@UserId", UserId));
                cmd += " and [RoleID] in (select RoleID from [UserRoles] where UserID=@UserId)";
            }
            string sqlText = "select * from [Roles] where 1=1 " + cmd;
            return GetList<Role>(sqlText, parameters).ToArray();
        }
    }
}
