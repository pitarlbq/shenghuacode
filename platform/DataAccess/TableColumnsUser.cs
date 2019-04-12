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
    /// This object represents the properties and methods of a TableColumnsUser.
    /// </summary>
    public partial class TableColumnsUser : EntityBase
    {
        public static TableColumnsUser[] GetTableColumnsUserListByUserID(int UserID, int ColumnServiceStatus = -1, int ColumnServiceType = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var conditions = new List<string>();
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            
            if (ColumnServiceType > 0)
            {
                if (ColumnServiceStatus > -1)
                {
                    conditions.Add("[ServiceStatus]=@ServiceStatus");
                    parameters.Add(new SqlParameter("@ServiceStatus", ColumnServiceStatus));
                }
                conditions.Add("[ServiceType]=@ServiceType");
                parameters.Add(new SqlParameter("@ServiceType", ColumnServiceType));
            }
            return GetList<TableColumnsUser>("select * from [TableColumnsUser] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
