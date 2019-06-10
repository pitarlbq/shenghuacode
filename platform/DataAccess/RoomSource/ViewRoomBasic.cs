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
    /// This object represents the properties and methods of a ViewRoomBasic.
    /// </summary>
    public partial class ViewRoomBasic : EntityBaseReadOnly
    {
        public static Ui.DataGrid GetProjectDetailsGridByRoomID(int RoomID, bool loadIn, string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RoomID]=@RoomID");
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            string table = string.Empty;
            string cmdwhere = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                cmdwhere += " and ([Name] like @Keywords or [PName] like @Keywords)";
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (loadIn)
            {
                table = @"(select * from [ViewRoomBasic] where [RoomID] in (select RoomID from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where " + string.Join(" and ", conditions.ToArray()) + ")) and [RoomID] in(select [ID] from [Project] where [isParent]=0) " + cmdwhere + ") [ViewProjectRelation]";
            }
            else
            {
                table = @"(select * from [ViewRoomBasic] where [RoomID] not in (select RoomID from [RoomRelation] where [GUID] in (select [GUID] from [RoomRelation] where " + string.Join(" and ", conditions.ToArray()) + ")) and [RoomID] in(select [ID] from [Project] where [isParent]=0)" + cmdwhere + ") [ViewProjectRelation]";
            }

            string fieldList = "[ViewProjectRelation].* ";
            string Statement = " from " + table;
            ViewRoomBasic[] list = new ViewRoomBasic[] { };
            list = GetList<ViewRoomBasic>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ViewRoomBasic GetViewRoomBasicByRoomID(int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            return GetOne<ViewRoomBasic>("select top 1 * from [ViewRoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static string GetSearchConditions(List<string> SearchAreas, string keyword)
        {
            string cmd = string.Empty;
            for (int i = 0; i < SearchAreas.Count; i++)
            {
                if (i == 0)
                {
                    cmd += "[" + SearchAreas[i] + "] like '%" + keyword + "%'";
                }
                else
                {
                    cmd += " or [" + SearchAreas[i] + "] like '%" + keyword + "%'";
                }
            }
            cmd += " or [RoomID] in (select [RoomID] from [RoomPhoneRelation] where [RelatePhoneNumber] like '%" + keyword + "%')";
            var config = new Utility.SiteConfig();
            if (config.IsMallOn)
            {
                cmd += " or [RoomID] in (select [RoomID] from [RoomPhoneRelation] where [RelatePhoneNumber] like '%" + keyword + "%' or RelationName like '%" + keyword + "%')";
            }
            return cmd;
        }
        public static Ui.DataGrid GetRoomBasicListByKeywords(List<int> RoomIDList, List<int> ProjectIDList, string RoomOwner, string OwnerPhone, string Keywords, List<string> SearchAreas, string orderBy, long startRowIndex, int pageSize, bool canexport = false, int CompanyID = 0)
        {
            return GetRoomBasicListByKeywords(RoomIDList, ProjectIDList, RoomOwner, OwnerPhone, Keywords, SearchAreas, orderBy, startRowIndex, pageSize, string.Empty, int.MinValue, canexport: canexport, CompanyID: CompanyID);
        }
        public static Ui.DataGrid GetRoomBasicListByKeywords(List<int> RoomIDList, List<int> ProjectIDList, string RoomOwner, string OwnerPhone, string Keywords, List<string> SearchAreas, string orderBy, long startRowIndex, int pageSize, string OpenID, int ConnectStatus, bool canexport = false, int CompanyID = 0)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([isParent],0)=0");
            if (CompanyID > 0)
            {
                conditions.Add("exists(select 1 from Project where [CompanyID]=@CompanyID and [ID]=ViewRoomBasic.RoomID)");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
            }
            if (!string.IsNullOrEmpty(OpenID))
            {
                if (ConnectStatus > int.MinValue)
                {
                    if (ConnectStatus == 1)
                    {
                        conditions.Add("[RoomID] in (select [ProjectID] from [WechatUser_Project] where OpenID=@OpenID)");
                        parameters.Add(new SqlParameter("@OpenID", OpenID));
                    }
                    else if (ConnectStatus == 0)
                    {
                        conditions.Add("[RoomID] not in (select [ProjectID] from [WechatUser_Project] where OpenID=@OpenID)");
                        parameters.Add(new SqlParameter("@OpenID", OpenID));
                    }
                }
            }
            #region 关键字查询
            string cmd = string.Empty;

            if (!string.IsNullOrEmpty(Keywords))
            {
                cmd += "  and  (" + GetSearchConditions(SearchAreas, Keywords) + ")";
            }
            #endregion
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = new List<string>();
                foreach (var ProjectID in ProjectIDList)
                {
                    cmdlist.Add("([AllParentID] like '%," + ProjectID + ",%' or [RoomID] =" + ProjectID + ")");
                }
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (!string.IsNullOrEmpty(RoomOwner))
            {
                conditions.Add("[RoomOwner]=@RoomOwner");
                parameters.Add(new SqlParameter("@RoomOwner", RoomOwner));
            }
            if (!string.IsNullOrEmpty(OwnerPhone))
            {
                conditions.Add("[OwnerPhone]=@OwnerPhone");
                parameters.Add(new SqlParameter("@OwnerPhone", OwnerPhone));
            }
            string fieldList = "[ViewRoomBasic].*";
            string Statement = " from [ViewRoomBasic] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            ViewRoomBasic[] list = new ViewRoomBasic[] { };
            var phoneList = new RoomPhoneRelation[] { };
            int MinRoomID = 0;
            int MaxRoomID = 0;
            if (canexport)
            {
                list = GetList<ViewRoomBasic>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<ViewRoomBasic>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            if (list.Length == 0)
            {
                dg.rows = list;
                dg.total = 0;
                dg.page = pageSize;
                return dg;
            }
            MinRoomID = list.Min(p => p.RoomID);
            MaxRoomID = list.Max(p => p.RoomID);
            phoneList = RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxRoomID(MinRoomID, MaxRoomID);
            var fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString()).Where(p => p.IsShown).ToArray();

            var contentlist = Foresight.DataAccess.RoomBasicField.GetRoomBasicFieldsByRoomIDList(MinRoomID, MaxRoomID);
            var results = list.Select(p =>
            {
                var dic = p.ToJsonObject(ignoreDBColumn: false);
                dic["RoomOwner1Name"] = string.Empty;
                dic["RoomOwner1Phone"] = string.Empty;
                dic["RoomOwner2Name"] = string.Empty;
                dic["RoomOwner2Phone"] = string.Empty;
                dic["Rent1Name"] = string.Empty;
                dic["Rent1Phone"] = string.Empty;
                if (phoneList.Length > 0)
                {
                    var myPhoneList1 = phoneList.Where(q => q.RoomID == p.RoomID && q.RelationType.Equals("homefamily")).OrderByDescending(q => q.IsDefault).ThenBy(q => q.ID).ToArray();
                    var myPhoneList2 = phoneList.Where(q => q.RoomID == p.RoomID && q.RelationType.Equals("rentfamily")).OrderByDescending(q => q.IsDefault).ThenBy(q => q.ID).ToArray();
                    int count = 0;
                    foreach (var item in myPhoneList1)
                    {
                        count++;
                        dic["RoomOwner" + count.ToString() + "Name"] = item.RelationName;
                        dic["RoomOwner" + count.ToString() + "Phone"] = item.RelatePhoneNumber;
                    }
                    count = 0;
                    foreach (var item in myPhoneList2)
                    {
                        count++;
                        dic["Rent" + count.ToString() + "Name"] = item.RelationName;
                        dic["Rent" + count.ToString() + "Phone"] = item.RelatePhoneNumber;
                    }
                }

                foreach (var item in fieldlist)
                {
                    var contentmodel = contentlist.FirstOrDefault(q => q.FieldID == item.ID && q.RoomID == p.RoomID);
                    dic[item.FieldName] = contentmodel == null ? "" : contentmodel.FieldContent;
                }
                return dic;
            }).ToList();
            dg.rows = results;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static int GetIDCardType(string desc)
        {
            if (desc.Equals("身份证"))
            {
                return 1;
            }
            if (desc.Equals("护照"))
            {
                return 2;
            }
            if (desc.Equals("军人证"))
            {
                return 3;
            }
            if (desc.Equals("驾驶证"))
            {
                return 4;
            }
            return 5;
        }
        public string IsJingZhuangXiuDesc
        {
            get
            {
                if (this.IsJingZhuangXiu == 1)
                {
                    return "是";
                }
                if (this.IsJingZhuangXiu == 2)
                {
                    return "否";
                }
                return string.Empty;
            }
        }
    }
}
