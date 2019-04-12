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
    /// This object represents the properties and methods of a Project.
    /// </summary>
    public partial class Project : EntityBase
    {
        public static void GetMyProjectListByProjectIDList(List<int> ProjectIDList, out List<int> EqualIDList, out List<int> InIDList)
        {
            EqualIDList = new List<int>();
            InIDList = new List<int>();
            if (ProjectIDList.Count == 0)
            {
                return;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            string sqlText = "select * from [Project] where [ID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")";
            var list = GetList<Project>(sqlText, parameters).ToArray();
            if (list.Length > 0)
            {
                List<string> InIDStrList = string.Join("", list.Select(p => p.AllParentID).ToList()).Split(',').ToList();
                var NewEqualIDList = new List<int>();
                foreach (var item in InIDStrList)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    int ID = 0;
                    int.TryParse(item, out ID);
                    if (ID > 0 && !NewEqualIDList.Contains(ID))
                    {
                        NewEqualIDList.Add(ID);
                    }
                }
                InIDList = list.Where(p => p.ID != 1 && !NewEqualIDList.Contains(p.ID)).Select(p => p.ID).ToList();
                NewEqualIDList.AddRange(InIDList);
                EqualIDList = NewEqualIDList.Where(ID => ID > 1).Distinct().ToList();
            }
        }
        public static void GetMyProjectListByUserID(int UserID, out List<int> EqualIDList, out List<int> InIDList, List<int> ProjectIDList = null)
        {
            EqualIDList = new List<int>();
            InIDList = new List<int>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            string cmdwhere = string.Empty;
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                cmdwhere += " and [ParentID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")";
            }
            string sqlText = "select * from [Project] where [ID] in (select [ProjectID] from [RoleProject] where [UserID] = @UserID or [RoleID] in (select [RoleID] from [UserRoles] where [UserID] = @UserID))" + cmdwhere;
            var list = GetList<Project>(sqlText, parameters).ToArray();
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                sqlText = "select * from [Project] where [ID] in (" + string.Join(",", ProjectIDList.ToArray()) + ")";
                list = GetList<Project>(sqlText, parameters).ToArray();
            }
            if (list.Length > 0)
            {
                List<string> InIDStrList = string.Join("", list.Select(p => p.AllParentID).ToList()).Split(',').ToList();
                var NewEqualIDList = new List<int>();
                foreach (var item in InIDStrList)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    int ID = 0;
                    int.TryParse(item, out ID);
                    if (ID > 0 && !NewEqualIDList.Contains(ID))
                    {
                        NewEqualIDList.Add(ID);
                    }
                }
                InIDList = list.Where(p => p.ID != 1 && !NewEqualIDList.Contains(p.ID)).Select(p => p.ID).ToList();
                NewEqualIDList.AddRange(list.Select(p => p.ID).ToList());
                EqualIDList = NewEqualIDList;
            }
        }
        public static Project[] GetSameLevelProjectListByID(int ID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var myProjectIDList = Project.GetProjectIDListbyIDList(UserID: UserID);
            string cmdwhere = string.Empty;
            if (myProjectIDList.Length > 0)
            {
                cmdwhere += " ID in (" + string.Join(",", myProjectIDList.ToArray()) + ")";
            }
            string cmdtext = "select * from [Project] where [ParentID] in (select [ParentID] from [Project] where [ID]=@ID) " + cmdwhere + ";";
            parameters.Add(new SqlParameter("@ID", ID));
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetList<Project>(cmdtext, parameters).ToArray();
        }
        public static Project[] GetAllChildProjectListByID(int ID)
        {
            List<int> IDList = new List<int>();
            IDList.Add(ID);
            return GetAllChildProjectListByIDs(IDList, 0);
        }
        public static Project[] GetAllChildProjectListByIDs(List<int> ProjectIDList)
        {
            return GetAllChildProjectListByIDs(ProjectIDList, 0);
        }
        public static Project[] GetAllChildProjectListByIDs(List<int> ProjectIDList, int ParentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (ParentID > 0)
            {
                conditions.Add("[ParentID]=@ParentID");
                parameters.Add(new SqlParameter("@ParentID", ParentID));
            }
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetProjectListByIDs(List<int> IDList)
        {
            if (IDList.Count == 0)
            {
                return new Project[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project[] GetProjectByParentID(int ParentID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=@ParentID");
            parameters.Add(new SqlParameter("@ParentID", ParentID));
            Project[] list = GetList<Project>("SELECT * FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Project GetMaxProjectByParentID(int ParentID, string TypeDesc, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=@ParentID");
            parameters.Add(new SqlParameter("@ParentID", ParentID));
            if (!string.IsNullOrEmpty(TypeDesc))
            {
                conditions.Add("[TypeDesc]=@TypeDesc");
                parameters.Add(new SqlParameter("@TypeDesc", TypeDesc));
            }
            return GetOne<Project>("select top 1 * from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [Level] desc", parameters, helper);
        }
        public static Project[] GetProjectListByParentID(int ID, int ParentID, int CompanyID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ParentID == 1)
            {
                conditions.Add("[ParentID] in (select [ID] from [Project] where [ParentID]=@ID)");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            else
            {
                conditions.Add("[ParentID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            if (CompanyID > 0)
            {
                conditions.Add("[CompanyID]=@CompanyID");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            Project[] list = GetList<Project>("SELECT [TypeDesc],[PName],Max([Level]) as [Level] FROM [Project] where " + string.Join(" and ", conditions.ToArray()) + " group by [TypeDesc],[PName]", parameters).ToArray();
            return list;
        }
        public static Project[] GetTopProjectListByCompanyID(int CompanyID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]!=1");
            conditions.Add("[ParentID]=1");
            if (CompanyID > 0)
            {
                conditions.Add("[CompanyID]=@CompanyID");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            else
            {
                conditions.Add("exists(select 1 from [RoleProject] where [ProjectID]=[Project].ID and (UserID=@UserID or RoleID in(select RoleID from [UserRoles] where [UserID]=@UserID)))");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            Project[] list = GetList<Project>("SELECT ID,Name FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static void DeleteProjectByID(int ID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string commandText = @";with temp
AS ( select ID from Project where ID = @ID
UNION ALL  
select  d.ID from  temp
INNER JOIN Project d ON d.ParentID = temp.ID
)
delete from Project where ID in (select ID from temp)";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@ID", ID));
                    helper.Execute(commandText, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch
                {
                    helper.Rollback();
                    throw;
                }
            }
        }
        public static Project GetProjectByName(int ParentID, string ProjectName, SqlHelper helper, out int SortBy)
        {
            SortBy = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string cmdwhere = string.Empty;
            conditions.Add("[ParentID]=@ID");
            parameters.Add(new SqlParameter("@ID", ParentID));
            cmdwhere += " and [ParentID]=@ID";
            conditions.Add("[Name]=@ProjectName");
            parameters.Add(new SqlParameter("@ProjectName", ProjectName));
            var project = GetOne<Project>("select top 1 * from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] desc", parameters, helper);
            if (project == null)
            {
                project = GetOne<Project>("select top 1 * from [Project] where 1=1 " + cmdwhere + " order by [DefaultOrder] desc", parameters, helper);
                SortBy = project == null ? SortBy : project.OrderBy;
                return null;
            }
            return project;
        }
        public static Project[] GetAllRoomChild(List<int> IDList)
        {
            string commandText = @";with temp
AS ( select * from Project where ID in (" + string.Join(",", IDList.ToArray()) + @")
UNION ALL  
select  d.* from  temp
INNER JOIN Project d ON d.ParentID = temp.ID
)
select * from [Project] where ID in (select [ID] from temp where [isParent]=0)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            return GetList<Project>(commandText, parameters).ToArray();
        }
        public static Project[] GetAllRoomChild(int ID)
        {
            List<int> IDList = new List<int>();
            IDList.Add(ID);
            return GetAllRoomChild(IDList);
        }
        public static Project[] GetProjectListByUserID(int UserID, List<int> ProjectIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<int> EqualIDList = null;
            List<int> InIDList = null;
            Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList, ProjectIDList: ProjectIDList);
            if (InIDList.Count > 0)
            {
                conditions.Add("ID in (" + string.Join(",", InIDList.ToArray()) + ")");
                return GetList<Project>("select * from [Project] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            }
            else
            {
                return new Project[] { };
            }
        }
        public static Project GetProjectByPhoneNumber(string PhoneNumber)
        {
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                return null;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("exists(select 1 from [RoomPhoneRelation] where [RelatePhoneNumber]=@PhoneNumber and [RoomID]=[Project].ID)");
            parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
            return GetOne<Project>("select * from [Project] where  " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static Project[] GetXiaoQuProjectListBySystemUserID(int UserID)
        {
            var list = GetProjectListByUserID(UserID, null);
            if (list.Length == 0)
            {
                return new Project[] { };
            }
            string IDs = string.Join(",", list.Select(p => p.AllParentID).ToArray());
            List<string> IDStrList = IDs.Split(',').ToList();
            List<int> IDList = new List<int>();
            foreach (var IDStr in IDStrList)
            {
                if (string.IsNullOrEmpty(IDStr))
                {
                    continue;
                }
                int ID = 0;
                int.TryParse(IDStr, out ID);
                if (IDList.Contains(ID))
                {
                    continue;
                }
                IDList.Add(ID);
            }
            if (IDList.Count == 0)
            {
                return new Project[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ParentID]=1");
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            list = GetList<Project>("select * from [Project] where  " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static int[] GetProjectIDListbyIDList(List<int> ProjectIDList = null, int UserID = 0)
        {
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            if (UserID > 0)
            {
                Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList, ProjectIDList: ProjectIDList);
            }
            else if (ProjectIDList != null)
            {
                Project.GetMyProjectListByProjectIDList(ProjectIDList, out EqualIDList, out InIDList);
            }
            var cmdlist = new List<string>();
            if (InIDList.Count > 0)
            {
                foreach (var InID in InIDList)
                {
                    cmdlist.Add("([Project].AllParentID like '%," + InID + ",%' or ID=" + InID + ")");
                }
            }
            if (EqualIDList.Count > 0)
            {
                foreach (var EqualID in EqualIDList)
                {
                    cmdlist.Add("([Project].ID=" + EqualID + ")");
                }
            }
            if (cmdlist.Count > 0)
            {
                var list = GetList<Project>("select ID from [Project] where " + string.Join(" or ", cmdlist.ToArray()), new List<SqlParameter>());
                return list.Select(p => p.ID).ToArray();
            }
            return new int[] { };
        }
    }
    public class ProjectTree : EntityBaseReadOnly
    {
        [DatabaseColumn("ID")]
        public int ID { get; set; }
        [DatabaseColumn("ParentID")]
        public int ParentID { get; set; }
        [DatabaseColumn("Name")]
        public string Name { get; set; }
        [DatabaseColumn("FullName")]
        public string FullName { get; set; }
        [DatabaseColumn("IconID")]
        public int IconID { get; set; }

        [DatabaseColumn("IsLocked")]
        public bool IsLocked { get; set; }
        [DatabaseColumn("isParent")]
        public bool isParent { get; set; }
        [DatabaseColumn("CompanyID")]
        public int CompanyID { get; set; }
        [DatabaseColumn("RoleID")]
        public int RoleID { get; set; }
        [DatabaseColumn("OrderNumberID")]
        public int OrderNumberID { get; set; }
        [DatabaseColumn("MsgID")]
        public int MsgID { get; set; }
        [DatabaseColumn("TypeDesc")]
        public string TypeDesc { get; set; }
        [DatabaseColumn("UserID")]
        public int UserID { get; set; }
        public int FinalParentID
        {
            get
            {
                if (this.ParentID == 1)
                {
                    return this.CompanyID > 0 ? this.CompanyID : 1;
                }
                return this.ParentID;
            }
        }
        public static string ProjectColumns = "[Project].ID,[Project].ParentID,[Project].Name,[Project].FullName,[Project].IconID,[Project].isParent,[Project].TypeDesc,[Project].CompanyID";
        public static ProjectTree GetProjectTree(int ID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID <= 0)
            {
                return null;
            }
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            return GetOne<ProjectTree>("SELECT top 1 [Project].ID,[Project].ParentID,[Project].Name,[Project].FullName,[Project].IconID,[Project].isParent FROM [Project] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static ProjectTree[] GetProjectTreeListByID(int ID, string Keywords, int UserID, int IconID = 0, bool OnlyXiaoqu = false, bool ExceptRoom = false, int CompanyID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]>1");
            if (ExceptRoom)
            {
                conditions.Add("[isParent]=1");
            }
            if (CompanyID > 0)
            {
                conditions.Add("[CompanyID]=@CompanyID");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            string sortorder = string.Empty;
            if (UserID > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
                List<string> cmdlist = new List<string>();
                if (InIDList.Count > 0)
                {
                    foreach (var InID in InIDList)
                    {
                        cmdlist.Add("([Project].AllParentID like '%," + InID + ",%' or ID=" + InID + ")");
                    }
                }
                if (EqualIDList.Count > 0)
                {
                    foreach (var EqualID in EqualIDList)
                    {
                        cmdlist.Add("([Project].ID=" + EqualID + ")");
                    }
                }
                string cmdwhere = string.Empty;
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            if (OnlyXiaoqu)
            {
                conditions.Add("[ParentID]=1");
                if (!string.IsNullOrEmpty(Keywords))
                {
                    parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                    conditions.Add("([Name] like @LikeKeywords)");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Keywords))
                {
                    parameters.Add(new SqlParameter("@Keywords", Keywords));
                    parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                    conditions.Add("[isParent]=0");
                    conditions.Add("([Name] like @LikeKeywords or [ID] in (select [RoomID] from [RoomBasic] where [RoomType] like @LikeKeywords) or [ID] in (select [RoomID] from [RoomPhoneRelation] where [RelationName] like @LikeKeywords or [RelatePhoneNumber] like @LikeKeywords))");
                }
                else if (ID > 0)
                {
                    conditions.Add("[ParentID]=@ID");
                    parameters.Add(new SqlParameter("@ID", ID));
                }
                else
                {
                    conditions.Add("[IconID]<=2");
                }
                if (IconID > 0)
                {
                    conditions.Add("[IconID]=@IconID");
                    parameters.Add(new SqlParameter("@IconID", IconID));
                }
            }
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + " from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by DefaultOrder asc", parameters).ToArray();
            return list;
        }
        public static ProjectTree[] GetProjectTreeListByRoleIDAndUserID(int ID, string Keywords, int RoleID, int UserID, int CompanyID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ID>1");
            if (CompanyID > 0)
            {
                conditions.Add("[CompanyID]=@CompanyID");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", Keywords));
                parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                conditions.Add("[isParent]=0");
                conditions.Add("([Name] like @LikeKeywords or [ID] in (select [RoomID] from [RoomBasic] where [RoomType] like @LikeKeywords or [RoomOwner] like @LikeKeywords or [OwnerPhone] like @LikeKeywords or [RentName] like @LikeKeywords or [RentPhoneNumber] like @LikeKeywords))");
            }
            else if (ID > 0)
            {
                conditions.Add("[ParentID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            else
            {
                conditions.Add("[IconID]<=2");
            }
            string cmdcolumns = string.Empty;
            if (RoleID > 0)
            {
                cmdcolumns += ",(select [RoleID] from [RoleProject] where [RoleProject].[ProjectID]=[Project].[ID] and [RoleID]=@RoleID) as RoleID";
            }
            else
            {
                cmdcolumns += ",0 as RoleID";
            }
            if (UserID > 0)
            {
                cmdcolumns += ",(select [UserID] from [RoleProject] where [RoleProject].[ProjectID]=[Project].[ID] and [UserID]=@UserID) as UserID";
            }
            else
            {
                cmdcolumns += ",0 as UserID";
            }
            parameters.Add(new SqlParameter("@RoleID", RoleID));
            parameters.Add(new SqlParameter("@UserID", UserID));
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + cmdcolumns + " from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder] asc", parameters).ToArray();
            return list;
        }
        public static ProjectTree[] GetProjectTreeListByOrderNumberID(int ID, string Keywords, int OrderNumberID, int Level, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[IconID]<=" + Level);
            if (UserID > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
                List<string> cmdlist = new List<string>();
                if (InIDList.Count > 0)
                {
                    foreach (var InID in InIDList)
                    {
                        cmdlist.Add("([Project].AllParentID like '%," + InID + ",%' or ID=" + InID + ")");
                    }
                }
                if (EqualIDList.Count > 0)
                {
                    foreach (var EqualID in EqualIDList)
                    {
                        cmdlist.Add("([Project].ID=" + EqualID + ")");
                    }
                }
                string cmdwhere = string.Empty;
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", Keywords));
                parameters.Add(new SqlParameter("@LikeKeywords", "%" + Keywords + "%"));
                conditions.Add("[isParent]=0");
                conditions.Add("([Name] like @LikeKeywords or [ID] in (select [RoomID] from [RoomBasic] where [RoomType] like @LikeKeywords or [RoomOwner] like @LikeKeywords or [OwnerPhone] like @LikeKeywords or [RentName] like @LikeKeywords or [RentPhoneNumber] like @LikeKeywords))");
            }
            else if (ID > 0)
            {
                conditions.Add("[ParentID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + ",(select [OrderNumberID] from [ProjectOrderNumber] where [ProjectOrderNumber].[ProjectID]=[Project].[ID] and [OrderNumberID]=@OrderNumberID) as OrderNumberID from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [OrderBy],[Level],[ID]", parameters).ToArray();
            return list;
        }
        public static ProjectTree[] GetProjectTreeListByMsgID(int CompanyID, int MsgID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
                List<string> cmdlist = new List<string>();
                if (InIDList.Count > 0)
                {
                    foreach (var InID in InIDList)
                    {
                        cmdlist.Add("([Project].AllParentID like '%," + InID + ",%' or ID=" + InID + ")");
                    }
                }
                if (EqualIDList.Count > 0)
                {
                    foreach (var EqualID in EqualIDList)
                    {
                        cmdlist.Add("([Project].ID=" + EqualID + ")");
                    }
                }
                string cmdwhere = string.Empty;
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            conditions.Add("([ID]=1 or [ParentID]=1)");
            parameters.Add(new SqlParameter("@MsgID", MsgID));
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + ",(select [MsgID] from [Wechat_MsgProject] where [Wechat_MsgProject].[ProjectID]=[Project].[ID] and [MsgID]=@MsgID) as MsgID from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder]", parameters).ToArray();
            return list;
        }
        public static ProjectTree[] GetProjectTreeListByContactID(int CompanyID, int ContactID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserID > 0)
            {
                List<int> EqualIDList = new List<int>();
                List<int> InIDList = new List<int>();
                Project.GetMyProjectListByUserID(UserID, out EqualIDList, out InIDList);
                List<string> cmdlist = new List<string>();
                if (InIDList.Count > 0)
                {
                    foreach (var InID in InIDList)
                    {
                        cmdlist.Add("([Project].AllParentID like '%," + InID + ",%' or ID=" + InID + ")");
                    }
                }
                if (EqualIDList.Count > 0)
                {
                    foreach (var EqualID in EqualIDList)
                    {
                        cmdlist.Add("([Project].ID=" + EqualID + ")");
                    }
                }
                string cmdwhere = string.Empty;
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            conditions.Add("([ID]=1 or [ParentID]=1)");
            parameters.Add(new SqlParameter("@ContactID", ContactID));
            ProjectTree[] list = GetList<ProjectTree>("select " + ProjectColumns + ",(select [WechatContactID] from [Wechat_ContactProject] where [Wechat_ContactProject].[ProjectID]=[Project].[ID] and [WechatContactID]=@ContactID) as MsgID from [Project] where " + string.Join(" and ", conditions.ToArray()) + " order by [DefaultOrder]", parameters).ToArray();
            return list;
        }
        protected override void EnsureParentProperties()
        {
        }

    }
}
