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
    /// This object represents the properties and methods of a ProjectName.
    /// </summary>
    public partial class ProjectName : EntityBase
    {
        public static ProjectName GetProjectNameByName(string Name, string PName, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[Name]=@Name");
            parameters.Add(new SqlParameter("@Name", Name));
            conditions.Add("[PName]=@PName");
            parameters.Add(new SqlParameter("@PName", PName));
            return GetOne<ProjectName>("select top 1 * from [ProjectName] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }

        public static ProjectName GetFirstProjectNameByID(int ID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetFirstProjectNameByID(ID, helper);
            }
        }
        public static ProjectName GetFirstProjectNameByID(int ID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (select ID from ProjectNameRelation where PID=@ID)");
            parameters.Add(new SqlParameter("@ID", ID));
            return GetOne<ProjectName>("select top 1 * from [ProjectName] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
    }
    public class ProjectNameDetails : ProjectName
    {
        [DatabaseColumn("OrderBy")]
        public int OrderBy { get; set; }
        public static ProjectNameDetails[] GetProjectNameListByName(int ProjectID, string Name, int CompanyID, string PName)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[PName] not in (select [Name] from [ProjectYTOrder] where [IsShow]=0 and [CompanyID]=@CompanyID and [ProjectID]=@ProjectID)");
            if (string.IsNullOrEmpty(PName))
            {
                conditions.Add("[ID] in (select ID from ProjectNameRelation where PID=0)");
            }
            else if (Name.Equals(PName))
            {
                conditions.Add("[ID] in (select ID from ProjectNameRelation where PID=0)");
                parameters.Add(new SqlParameter("@PName", PName));
                conditions.Add("[ID] in (select ID from [ProjectName] where [PName]=@PName)");
            }
            else
            {
                parameters.Add(new SqlParameter("@PName", PName));
                conditions.Add("[ID] in (select ID from [ProjectName] where [PName]=@PName)");
                conditions.Add("[ID] in (select ID from ProjectNameRelation where PID in (select [ID] from [ProjectName] where [Name]=@Name))");
                parameters.Add(new SqlParameter("@Name", Name));
            }
            parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            return GetList<ProjectNameDetails>("select *,isnull((select top 1 [OrderBy] from [ProjectYTOrder] where [Name]=[ProjectName].PName and [CompanyID]=@CompanyID and [ProjectID]=@ProjectID),1) as OrderBy from [ProjectName] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
