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
    /// This object represents the properties and methods of a CKDepartment.
    /// </summary>
    public partial class CKDepartment : EntityBase
    {
        public string ParentName { get; set; }
        public static Ui.DataGrid GetCKDepartmentGridByKeywords(string Keywords, string orderBy)
        {
            var list = CKDepartment.GetCKDepartments().ToArray();
            if (list.Length > 0)
            {
                foreach (var item in list)
                {
                    var myParentData = list.FirstOrDefault(p => p.ID == item.ParentID);
                    if (myParentData != null)
                    {
                        item.ParentName = myParentData.DepartmentName;
                    }
                }
            }
            #region 关键字查询
            string cmd = string.Empty;
            CKDepartment[] dataList = new CKDepartment[] { };
            if (!string.IsNullOrEmpty(Keywords))
            {
                dataList = list.Where(p => p.DepartmentName.Contains(Keywords)).ToArray();
            }
            #endregion
            dataList = dataList.OrderBy(p => p.SortOrder).ThenBy(p => p.ID).ToArray();
            var items = list.Select(p =>
            {
                var type = "department";
                var dic = new Dictionary<string, object>();
                dic["type"] = type;
                dic["ID"] = p.ID;
                dic["ParentID"] = p.ParentID;
                dic["CompanyID"] = p.CompanyID > 0 ? p.CompanyID : 0;
                dic["id"] = type + "_" + p.ID;
                dic["name"] = p.DepartmentName;
                dic["_parentId"] = p.ParentID <= 1 ? "company_" + p.CompanyID : p.ParentID.ToString();
                var childItems = list.Where(q => q.ParentID == p.ID).ToArray();
                if (childItems.Length > 0)
                {
                    dic["state"] = "closed";
                }
                return dic;
            }).ToList();
            var companys = Company.GetCompanies().ToArray();
            var companyItems = companys.Select(p =>
            {
                var type = "company";
                var dic = new Dictionary<string, object>();
                dic["type"] = type;
                dic["ID"] = p.CompanyID;
                dic["ParentID"] = 0;
                dic["CompanyID"] = p.CompanyID > 0 ? p.CompanyID : 0;
                dic["id"] = type + "_" + p.CompanyID;
                dic["name"] = p.CompanyName;
                dic["_parentId"] = 0;
                return dic;
            }).ToList();
            items.AddRange(companyItems);
            Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = items;
            dg.total = items.Count;
            return dg;
        }
        public static CKDepartment[] GetCKDepartmentListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[DepartmentName] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            return GetList<CKDepartment>("select * from [CKDepartment] where " + string.Join(" and ", conditions.ToArray()) + " order by [DepartmentName] collate Chinese_PRC_CS_AS_KS_WS", parameters).ToArray();
        }
        public static CKDepartment[] GetAdminNotInDepartmentList(int UserId, string keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(keywords))
            {
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
                cmd += " and [DepartmentName] like @keywords";
            }
            if (UserId > 0)
            {
                parameters.Add(new SqlParameter("@UserId", UserId));
                cmd += " and [ID] not in (select [DepartmentID] from [UserDepartment] where [UserID]=@UserId)";
            }
            string sqlText = "select * from [CKDepartment] where 1=1 " + cmd;
            return GetList<CKDepartment>(sqlText, parameters).ToArray();
        }
        public static CKDepartment[] GetAdminInDepartmentList(int UserId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            if (UserId > 0)
            {
                parameters.Add(new SqlParameter("@UserId", UserId));
                cmd += " and [ID] in (select [DepartmentID] from [UserDepartment] where [UserID]=@UserId)";
            }
            string sqlText = "select * from [CKDepartment] where 1=1 " + cmd;
            return GetList<CKDepartment>(sqlText, parameters).ToArray();
        }
        public static CKDepartment[] GetDepartmentListByUserIDList(int[] UserIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = string.Empty;
            if (UserIDList.Length == 0)
            {
                return new CKDepartment[] { };
            }
            cmd += " and exists(select 1 from [UserDepartment] where [UserID] in (" + string.Join(",", UserIDList.ToArray()) + ") and [DepartmentID]=[CKDepartment].ID)";
            string sqlText = "select * from [CKDepartment] where 1=1 " + cmd;
            return GetList<CKDepartment>(sqlText, parameters).ToArray();
        }
    }
}
