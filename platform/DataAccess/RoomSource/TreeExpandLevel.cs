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
    /// This object represents the properties and methods of a TreeExpandLevel.
    /// </summary>
    public partial class TreeExpandLevel : EntityBase
    {
        public static TreeExpandLevel GetTreeExpandLevelByCompanyID(int CompanyID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            conditions.Add("[CompanyID]=@CompanyID");
            string sqlText = "select * from [TreeExpandLevel] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<TreeExpandLevel>(sqlText, parameters);
        }
    }
}
