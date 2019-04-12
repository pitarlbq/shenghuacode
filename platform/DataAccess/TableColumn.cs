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
    /// This object represents the properties and methods of a TableColumn.
    /// </summary>
    public partial class TableColumn : EntityBase
    {
        public static TableColumn[] GetTableColumnByPageCode(string PageCode, bool OnlyShow, int ColumnServiceStatus = -1, int ColumnServiceType = 0)
        {
            var user = User.GetCurrentUser();
            if (user == null)
            {
                return new TableColumn[] { };
            }
            int UserID = user.UserID;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsDeleted],0)=0");
            parameters.Add(new SqlParameter("@PageCode", PageCode));
            conditions.Add("PageCode=@PageCode");
            if (ColumnServiceType == 1)
            {
                conditions.Add("ID not in (70,71)");
            }
            var list = GetList<TableColumn>("select * from [TableColumns] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            parameters.Add(new SqlParameter("@UserID", UserID));
            var comlun_user_list = TableColumnsUser.GetTableColumnsUserListByUserID(UserID, ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType);
            foreach (var item in list)
            {
                var my_column_user = comlun_user_list.FirstOrDefault(p => p.TableColumnID == item.ID);
                if (my_column_user != null)
                {
                    item.IsShown = my_column_user.IsShown;
                    item.SortOrder = my_column_user.SortOrder;
                }
                else
                {
                    item.IsShown = false;
                }
            }
            if (OnlyShow)
            {
                var finalList = list.Where(p => p.IsShown).OrderBy(p => p.SortOrder).ToArray();
                if (finalList.Length == 0)
                {
                    if (ColumnServiceStatus == 30)
                    {
                        finalList = list.Where(p => p.IsAnalysis).OrderBy(p => p.SortOrder).ToArray();
                    }
                    else
                    {
                        finalList = list.OrderBy(p => p.SortOrder).ToArray();
                    }
                }
                return finalList;
            }
            return list.OrderBy(p => p.SortOrder).ToArray();
        }
        public string FinalGroupName
        {
            get
            {
                if (this.IsNecessary)
                {
                    return string.IsNullOrEmpty(this.GroupName) ? "基本信息" : this.GroupName;
                }
                return this.GroupName;
            }
        }
    }
}
