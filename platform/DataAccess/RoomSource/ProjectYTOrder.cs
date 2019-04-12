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
	/// This object represents the properties and methods of a ProjectYTOrder.
	/// </summary>
	public partial class ProjectYTOrder : EntityBase
	{
        public static ProjectYTOrder GetProjectYTOrderByName(string Name, int CompanyID,int ProjectID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[Name]=@Name");
            parameters.Add(new SqlParameter("@Name", Name));
            conditions.Add("[CompanyID]=@CompanyID");
            parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            conditions.Add("[ProjectID]=@ProjectID");
            parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            return GetOne<ProjectYTOrder>("select top 1 * from [ProjectYTOrder] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
	}
}
