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
    /// This object represents the properties and methods of a ViewCustomerServiceInDetail.
    /// </summary>
    public partial class ViewCustomerServiceInDetail : EntityBaseReadOnly
    {
        public static Ui.DataGrid GetViewCustomerServiceInDetailGridByKeywords(DateTime StartTime, DateTime EndTime, int PayStatus, string BalanceStatus, List<int> RoomIDList, List<int> ProjectIDList, string orderBy, long startRowIndex, int pageSize, int UserID = 0, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID]>0");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (PayStatus == 1)
            {
                conditions.Add("isnull([TotalFee],0)>0");
            }
            else if (PayStatus == 0)
            {
                conditions.Add("isnull([TotalFee],0)=0");
            }
            if (!string.IsNullOrEmpty(BalanceStatus))
            {
                conditions.Add("isnull([BalanceStatus],'balanceno')=@BalanceStatus");
                parameters.Add(new SqlParameter("@BalanceStatus", BalanceStatus));
            }
            if (ProjectIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(ProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string fieldList = "[ViewCustomerServiceInDetail].*";
            string Statement = " from [ViewCustomerServiceInDetail] where  " + string.Join(" and ", conditions.ToArray());
            ViewCustomerServiceInDetail[] list = new ViewCustomerServiceInDetail[] { };
            if (canexport)
            {
                list = GetList<ViewCustomerServiceInDetail>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<ViewCustomerServiceInDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string PayStatusDesc
        {
            get
            {
                return this.TotalFee > 0 ? "有偿" : "无偿";
            }
        }
        public string ChukuStatus
        {
            get
            {
                return this.CKProductOutSumaryID > 0 ? "是" : "否";
            }
        }
        public string BalanceStatusDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.BalanceStatus))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.BalanceStatus), this.BalanceStatus);
            }
        }
    }
}
