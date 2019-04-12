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
    /// This object represents the properties and methods of a Project_Public.
    /// </summary>
    public partial class Project_Public : EntityBase
    {
        public static Project_Public[] GetProjectPublicTreeListByParentID(int ParentID, int ParentProjectID, string Keywords, bool ShowAllParentProject = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string sortorder = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                conditions.Add("([Name] like @LikeKeywords)");
            }
            if (ParentID > 0)
            {
                conditions.Add("[ParentID]=@ParentID");
                parameters.Add(new SqlParameter("@ParentID", ParentID));
            }
            else if (ParentProjectID > 0)
            {
                conditions.Add("[ParentProjectID]=@ParentProjectID");
                conditions.Add("[ParentID]=0");
                parameters.Add(new SqlParameter("@ParentProjectID", ParentProjectID));
            }
            else if (ShowAllParentProject)
            {
                conditions.Add("[ParentProjectID]>0");
                conditions.Add("[ParentID]=0");
            }
            Project_Public[] list = GetList<Project_Public>("select * from [Project_Public] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime asc", parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetProjectPublicGridList(List<int> ParentProjectIDList, List<int> ParentIDList, string Keywords, string orderBy, long startRowIndex, int pageSize, int UserID = 0)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string sortorder = string.Empty;
            var cmdlist = new List<string>();
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                conditions.Add("([Name] like @LikeKeywords)");
            }
            if (ParentProjectIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetPublicProjectIDListConditions(ParentProjectIDList, RoomIDName: "[ParentProjectID]", UserID: UserID);
            }
            if (ParentIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetPublicParentIDListConditions(ParentIDList, RoomIDName: "[ID]", UserID: UserID);
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add(string.Join(" or", cmdlist.ToArray()));
            }
            string fieldList = "A.* ";
            string Statement = " from (select [Project_Public].*,[Project].FullName as ProjectFullName from [Project_Public] left join [Project] on [Project].ID=[Project_Public].ParentProjectID)A where  " + string.Join(" and ", conditions.ToArray());
            var list = GetList<Project_PublicDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Project_Public[] GetAllProject_PublicListByIDs(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            List<string> cmdlist = new List<string>();
            foreach (var ID in IDList)
            {
                cmdlist.Add("([AllParentID] like '%," + ID + ",%' or [ID] =" + ID + ")");
            }
            conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            Project_Public[] list = GetList<Project_Public>("SELECT * FROM [Project_Public] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
    }
    public partial class Project_PublicDetail : Project_Public
    {
        [DatabaseColumn("ProjectFullName")]
        public string ProjectFullName { get; set; }
        public string FinalFullName
        {
            get
            {
                return this.ProjectFullName + "-" + this.FullName;
            }
        }
    }
}
