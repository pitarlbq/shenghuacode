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
    /// This object represents the properties and methods of a OperationLog.
    /// </summary>
    public partial class OperationLog : EntityBase
    {
        public static OperationLog GetLatestLoginop(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID.ToString()));
            return GetOne<OperationLog>("select top 1 * from [OperationLog] where convert(nvarchar(max), [OperationTableKey])=@UserID order by [OperationTime] desc", parameters);
        }
        public static Ui.DataGrid GeOperationLogGridByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, string OperationKey, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([IsHide],0)=0");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([OperationContent] like @Keywords or [OperationMan] like @Keywords or [OperationTitle] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[OperationTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[OperationTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (!string.IsNullOrEmpty(OperationKey))
            {
                conditions.Add("[OperationKey]=@OperationKey");
                parameters.Add(new SqlParameter("@OperationKey", OperationKey));
            }
            string fieldList = "[OperationLog].* ";
            string Statement = " from [OperationLog] where  " + string.Join(" and ", conditions.ToArray());
            OperationLog[] list = GetList<OperationLog>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string OperationKeyDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.OperationKey))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.OperationModule), this.OperationKey);
            }
        }
    }
}
