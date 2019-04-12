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
    /// This object represents the properties and methods of a ProjectYT.
    /// </summary>
    public partial class ProjectYT : EntityBase
    {
        public static ProjectYT GetProjectYTByName(string Name, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[Name]=@Name");
            parameters.Add(new SqlParameter("@Name", Name));
            return GetOne<ProjectYT>("select top 1 * from [ProjectYT] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
    }
}
