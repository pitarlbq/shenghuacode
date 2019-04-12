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
    /// This object represents the properties and methods of a Project_Property.
    /// </summary>
    public partial class Project_Property : EntityBase
    {
        public static Project_Property GetProject_Property(int ProjectID, int RelationID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdtext = "select * from [Project_Property] where [ProjectID]=@ProjectID and [RelationID]=@RelationID";
            parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            parameters.Add(new SqlParameter("@RelationID", RelationID));
            return GetOne<Project_Property>(cmdtext, parameters, helper);
        }
    }
}
