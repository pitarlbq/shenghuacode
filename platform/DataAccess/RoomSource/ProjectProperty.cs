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
    /// This object represents the properties and methods of a ProjectProperty.
    /// </summary>
    public partial class ProjectProperty : EntityBase
    {

    }
    public partial class ProjectPropertyDetail : ProjectProperty
    {
        [DatabaseColumn("ProjectID")]
        public int ProjectID { get; set; }
        [DatabaseColumn("IsHide")]
        public bool IsHide { get; set; }
        [DatabaseColumn("SortOrder")]
        public int SortOrder { get; set; }
        public static ProjectPropertyDetail[] GetProjectPropertyDetailListByProjectID(int ProjectID, int PropertyID, bool OnlyShow)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmdwhere = " 1=1 ";
            
            if (PropertyID > 0)
            {
                cmdwhere += " and p.ID=@PropertyID";
                parameters.Add(new SqlParameter("@PropertyID", PropertyID));
            }
            cmdwhere += " and isnull([Level1],'')!=''";
            string cmdtext = "select p.*,pr.ProjectID,pr.IsHide,pr.SortOrder from ProjectProperty p left join (select * from Project_Property where ProjectID=@ProjectID) pr on pr.RelationID=p.ID where " + cmdwhere + " order by isnull(pr.SortOrder,p.MainSortOrder) asc";
            parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            var list = GetList<ProjectPropertyDetail>(cmdtext, parameters).ToArray();
            foreach (var item in list)
            {
                if (item.ProjectID <= 0)
                {
                    item.IsHide = false;
                }
            }
            if (OnlyShow)
            {
                list = list.Where(p => !p.IsHide).ToArray();
            }
            return list;
        }
        public static ProjectPropertyDetail[] GetProjectPropertyDetailListByProjectID(int ProjectID, int PropertyID = 0)
        {
            return GetProjectPropertyDetailListByProjectID(ProjectID, PropertyID, true);
        }
        public static ProjectPropertyDetail GetProjectPropertyDetailByID(int ID, int ProjectID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            if (ProjectID > 0)
            {
                conditions.Add("([ID] in (select [RelationID] from [Project_Property] where [IsHide]=1 and ProjectID=@ProjectID) or [ID] not in (select [RelationID] from [Project_Property] where ProjectID=@ProjectID))");
                parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            }
            string cmdtext = "select * from ProjectProperty where " + string.Join(" and ", conditions.ToArray());
            return GetOne<ProjectPropertyDetail>(cmdtext, parameters);
        }
    }
}
