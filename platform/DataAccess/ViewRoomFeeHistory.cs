using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

using Foresight.DataAccess.Framework;
using System.Configuration;
using System.Reflection;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ViewRoomFeeHistory.
    /// </summary>
    public partial class ViewRoomFeeHistory : EntityBaseReadOnly
    {
        public static void Inert2DBBySqlBulkCopy(List<int> IDList, int UserID = 0, bool InsertProjectID = false)//插入sql方法
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID", System.Type.GetType("System.Int32"));
            if (InsertProjectID)
            {
                dt.Columns.Add("ProjectID", System.Type.GetType("System.String"));
            }
            else
            {
                dt.Columns.Add("id", System.Type.GetType("System.Int32"));
            }
            foreach (var ID in IDList)
            {
                DataRow dr = dt.NewRow();
                dr["UserID"] = UserID;
                if (InsertProjectID)
                {
                    dr["ProjectID"] = ID.ToString();
                }
                else
                {
                    dr["id"] = ID;
                }
                dt.Rows.Add(dr);
            }
            string connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = "TempIDs";
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                    }
                    catch (System.Exception ex)
                    {
                        Utility.LogHelper.WriteError("ViewRoomFeeHistory.cs", "Inert2DBBySqlBulkCopy", ex);
                        throw ex;
                    }
                }
            }
        }
        private static Object thisLock = new Object();
        public static void CreateTempTable(List<int> IDList, bool DeleteTempHistoryIDList = true, int UserID = 0, bool InsertProjectID = false)
        {
            lock (thisLock)
            {
                string cmdtext = string.Empty;
                if (DeleteTempHistoryIDList)
                {
                    cmdtext += "delete from [TempIDs] where isnull(UserID,0)=" + UserID + " and isnull([id],0)!=0;";
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                            helper.Commit();
                        }
                        catch (Exception)
                        {
                            helper.Rollback();
                        }
                    }
                    Inert2DBBySqlBulkCopy(IDList, UserID, InsertProjectID);
                    return;
                }
                if (InsertProjectID)
                {
                    cmdtext += "delete from [TempIDs] where isnull(UserID,0)=" + UserID + " and isnull([ProjectID],'0')!='0';";
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                            helper.Commit();
                        }
                        catch (Exception)
                        {
                            helper.Rollback();
                        }
                    }
                    Inert2DBBySqlBulkCopy(IDList, UserID, InsertProjectID);
                }
            }
        }
        public static List<string> GetRoomIDListConditions(List<int> RoomIDList, bool IncludeRelation = true, bool IsContractFee = false, string RoomIDName = "[RoomID]", string ContractIDName = "[ContractID]")
        {
            List<string> cmdlist = new List<string>();
            cmdlist.Add("(" + RoomIDName + " in (" + string.Join(",", RoomIDList.ToArray()) + "))");
            if (IncludeRelation)
            {
                cmdlist.Add("(" + RoomIDName + " in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + "))))");
            }
            if (IsContractFee)
            {
                cmdlist.Add("(" + RoomIDName + "=0 and isnull(" + ContractIDName + ",0)>0 and " + ContractIDName + " in (select ContractID from [Contract_Room] where [RoomID] in (" + string.Join(",", RoomIDList.ToArray()) + ")))");
            }
            return cmdlist;
        }
        public static List<string> GetProjectIDListConditions(List<int> ProjectIDList, bool IncludeRelation = true, bool IsContractFee = false, string RoomIDName = "[RoomID]", int UserID = 0, string ContractIDName = "[ContractID]")
        {
            List<string> cmdlist = new List<string>();
            ProjectIDList = ProjectIDList.Where(p => p != 0).ToList();
            if (ProjectIDList.Count == 0)
            {
                cmdlist.Add("1=1");
                return cmdlist;
            }
            List<string> cmdwhere = new List<string>();
            if (ProjectIDList.Count > 100)
            {
                ViewRoomFeeHistory.CreateTempTable(ProjectIDList, UserID: UserID, InsertProjectID: true, DeleteTempHistoryIDList: false);
                cmdwhere.Add("exists (select 1 from [TempIDs] where [UserID]=" + UserID + " and ([Project].[AllParentID] like '%,'+[TempIDs].[ProjectID]+',%' or [Project].ID=[TempIDs].[ProjectID]))");
            }
            else
            {
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdwhere.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID] =" + ProjectID + ")");
                }
            }
            cmdlist.Add("(" + RoomIDName + " in (select ID from [Project] where " + string.Join(" or ", cmdwhere) + "))");
            if (IncludeRelation)
            {
                cmdlist.Add("(" + RoomIDName + " in (select [RoomID] from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where [RoomID] in (select ID from [Project] where " + string.Join(" or ", cmdwhere) + "))))");
            }
            if (IsContractFee)
            {
                cmdlist.Add("(" + RoomIDName + "=0 and isnull(" + ContractIDName + ",0)>0 and " + ContractIDName + " in (select ContractID from [Contract_Room] where [RoomID] in (select ID from [Project] where " + string.Join(" or ", cmdwhere) + ")))");
            }
            return cmdlist;
        }
        public static List<string> GetPublicProjectIDListConditions(List<int> ProjectIDList, string RoomIDName = "[PublicProjectID]", int UserID = 0)
        {
            List<string> cmdlist = new List<string>();
            ProjectIDList = ProjectIDList.Where(p => p != 0).ToList();
            if (ProjectIDList.Count == 0)
            {
                return cmdlist;
            }
            List<string> cmdwhere = new List<string>();
            if (ProjectIDList.Count > 100)
            {
                ViewRoomFeeHistory.CreateTempTable(ProjectIDList, UserID: UserID, InsertProjectID: true, DeleteTempHistoryIDList: false);
                cmdwhere.Add("exists (select 1 from [TempIDs] where [UserID]=" + UserID + " and ([Project].[AllParentID] like '%,'+[TempIDs].[ProjectID]+',%' or [Project].[ID]=[TempIDs].[ProjectID]))");
            }
            else
            {
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdwhere.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID]=" + ProjectID + ")");
                }
            }
            if (RoomIDName.Equals("[ParentProjectID]"))
            {
                cmdlist.Add("([ParentProjectID] in (select [ID] from [Project] where " + string.Join(" or ", cmdwhere) + "))");
            }
            else
            {
                cmdlist.Add("(" + RoomIDName + " in (select ID from [Project_Public] where [ParentProjectID] in (select [ID] from [Project] where " + string.Join(" or ", cmdwhere) + ")))");
            }
            return cmdlist;
        }
        public static List<string> GetPublicParentIDListConditions(List<int> ParentIDList, string RoomIDName = "[PublicProjectID]", int UserID = 0)
        {
            List<string> cmdlist = new List<string>();
            ParentIDList = ParentIDList.Where(p => p != 0).ToList();
            if (ParentIDList.Count == 0)
            {
                return cmdlist;
            }
            List<string> cmdwhere = new List<string>();
            if (ParentIDList.Count > 100)
            {
                ViewRoomFeeHistory.CreateTempTable(ParentIDList, UserID: UserID, InsertProjectID: true, DeleteTempHistoryIDList: false);
                cmdwhere.Add("exists (select 1 from [TempIDs] where [UserID]=" + UserID + " and ([Project_Public].[AllParentID] like '%,'+[TempIDs].[ProjectID]+',%' or [Project_Public].ID=[TempIDs].[ProjectID]))");
            }
            else
            {
                foreach (var ProjectID in ParentIDList)
                {
                    cmdwhere.Add("([AllParentID] like '%," + ProjectID + ",%' or [ID]=" + ProjectID + ")");
                }
            }
            if (RoomIDName.Equals("[ID]"))
            {
                cmdlist.Add("(" + string.Join(" or ", cmdwhere) + ")");
            }
            else
            {
                cmdlist.Add("(" + RoomIDName + " in (select ID from [Project_Public] where " + string.Join(" or ", cmdwhere) + "))");
            }
            return cmdlist;
        }
    }
}
