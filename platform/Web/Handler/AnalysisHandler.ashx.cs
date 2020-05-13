using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;
using Encript;
using Foresight.DataAccess.Ui;

namespace Web.Handler
{
    /// <summary>
    /// AnalysisHandler 的摘要说明
    /// </summary>
    public class AnalysisHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("CheckStatusHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadcallsummaryanalysis"://投诉来源统计表
                        loadcallsummaryanalysis(context);
                        break;
                    case "loadwuyetousucountanalysis"://物业投诉数量统计表
                        loadwuyetousucountanalysis(context);
                        break;
                    case "loadservicefromcountanalysis"://呼入管理统计表
                        loadservicefromcountanalysis(context);
                        break;
                    case "loadrepaircountanalysis"://维修数量统计表
                        loadrepaircountanalysis(context);
                        break;
                    case "loadrepairmayianalysis"://物业投诉、维修处理满意度统计表
                        loadrepairmayianalysis(context);
                        break;
                    case "loadtousushixiaoanalysis"://时效统计表
                        loadtousushixiaoanalysis(context);
                        break;
                    case "loadrepairfeeanalysis"://费用统计表
                        loadrepairfeeanalysis(context);
                        break;
                    case "loadjiediantimeoutanalysis"://超时平均时效统计
                        loadjiediantimeoutanalysis(context);
                        break;
                    case "loadcalltotalanalysis":
                        loadcalltotalanalysis(context);
                        break;
                    case "getsmssendstatusanalysis":
                        getsmssendstatusanalysis(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("AnalysisHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void getsmssendstatusanalysis(HttpContext context)
        {
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            long startRowIndex = WebUtil.GetDataGridStartRowIndex();
            int pageSize = WebUtil.GetDataGridPageSize();
            string errormsg = string.Empty;
            var list = new Utility.ResponseDataGrid();
            int BillNumber = 0;
            int RequestNumber = 0;
            int SuccessNumber = 0;
            int TotalSmsCount = 0;
            decimal TotalSmsAmount = 0;
            int RestNumber = 0;
            bool status = Encript.EncriptHelper.GetMySmsPullStatusList(StartTime, EndTime, startRowIndex, pageSize, out errormsg, ref list, ref BillNumber, ref RequestNumber, ref SuccessNumber, ref TotalSmsCount, ref TotalSmsAmount);
            RestNumber = TotalSmsCount - BillNumber;
            if (!status)
            {
                WebUtil.WriteJson(context, new DataGrid());
                return;
            }
            var result = new Dictionary<string, object>();
            result["rows"] = list.rows;
            result["page"] = list.page;
            result["total"] = list.total;
            result["countitem"] = new { BillNumber = BillNumber, RequestNumber = RequestNumber, SuccessNumber = SuccessNumber, TotalSmsCount = TotalSmsCount, TotalSmsAmount = TotalSmsAmount, RestNumber = RestNumber };
            WebUtil.WriteJson(context, result);
        }
        private void loadcalltotalanalysis(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            var dg = CallSummaryAnalysis.GetCallTotalAnalysisGrid(StartTime, EndTime, user.UserID, 0);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadCallTotalAnalysis(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadjiediantimeoutanalysis(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            List<int> RoomIDList = new List<int>();
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            int[] CompanyIDList = new int[] { };
            List<int> TopProjectIDList = new List<int>();
            WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int ServiceTypeID = WebUtil.GetIntValue(context, "ServiceTypeID");
            int TopCompanyID = WebUtil.GetIntValue(context, "TopCompanyID");
            int ServiceTypeID2 = WebUtil.GetIntValue(context, "ServiceTypeID2");
            int ServiceTypeID3 = WebUtil.GetIntValue(context, "ServiceTypeID3");
            var dg = ChuLiJieDianAnalysis.GetChuLiJieDianAnalysisGrid(RoomIDList, EqualProjectIDList, InProjectIDList, TopProjectIDList, TopCompanyID, user.UserID, StartTime, EndTime, CompanyIDList, ServiceTypeID2, ServiceTypeID3, ServiceTypeID: ServiceTypeID);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadJieDianTimeoutAnalysis(dg, TopCompanyID, TopProjectIDList, ServiceTypeID2, ServiceTypeID3, ServiceTypeID, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadrepairfeeanalysis(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            List<int> RoomIDList = new List<int>();
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            int[] CompanyIDList = new int[] { };
            List<int> TopProjectIDList = new List<int>();
            WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            string ServiceType2IDs = context.Request["ServiceType2IDs"];
            int[] ServiceType2IDList = new int[] { };
            if (!string.IsNullOrEmpty(ServiceType2IDs))
            {
                ServiceType2IDList = Utility.JsonConvert.DeserializeObject<int[]>(ServiceType2IDs);
            }
            int ServiceTypeID = WebUtil.GetIntValue(context, "ServiceTypeID");
            int TopCompanyID = WebUtil.GetIntValue(context, "TopCompanyID");
            int ServiceTypeID2 = WebUtil.GetIntValue(context, "ServiceTypeID2");
            int ServiceTypeID3 = WebUtil.GetIntValue(context, "ServiceTypeID3");
            var dg = RepairFeeAnalysis.GetRepairFeeAnalysisGrid(RoomIDList, EqualProjectIDList, InProjectIDList, TopProjectIDList, TopCompanyID, user.UserID, StartTime, EndTime, CompanyIDList, ServiceTypeID2, ServiceTypeID3, ServiceTypeID: ServiceTypeID);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadRepairFeeAnalysis(dg, TopCompanyID, TopProjectIDList, ServiceTypeID2, ServiceTypeID3, ServiceTypeID, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadtousushixiaoanalysis(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            List<int> RoomIDList = new List<int>();
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            int[] CompanyIDList = new int[] { };
            List<int> TopProjectIDList = new List<int>();
            WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int ServiceTypeID = WebUtil.GetIntValue(context, "ServiceTypeID");
            int ServiceTypeID2 = WebUtil.GetIntValue(context, "ServiceTypeID2");
            int ServiceTypeID3 = WebUtil.GetIntValue(context, "ServiceTypeID3");
            int TopCompanyID = WebUtil.GetIntValue(context, "TopCompanyID");
            var dg = TouSuShiXiaoAnalysis.GetTouSuShiXiaoAnalysisGrid(RoomIDList, EqualProjectIDList, InProjectIDList, TopProjectIDList, TopCompanyID, user.UserID, StartTime, EndTime, CompanyIDList, ServiceTypeID2, ServiceTypeID3, ServiceTypeID: ServiceTypeID);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadTouSuShiXiaoAnalysis(dg, TopCompanyID, TopProjectIDList, ServiceTypeID2, ServiceTypeID3, ServiceTypeID, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadrepairmayianalysis(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            List<int> RoomIDList = new List<int>();
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            int[] CompanyIDList = new int[] { };
            List<int> TopProjectIDList = new List<int>();
            WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int ServiceTypeID = WebUtil.GetIntValue(context, "ServiceTypeID");
            int TopCompanyID = WebUtil.GetIntValue(context, "TopCompanyID");
            var dg = YingXiaoManyiAnalysis.GetYingXiaoManyiAnalysisGrid(RoomIDList, EqualProjectIDList, InProjectIDList, TopProjectIDList, TopCompanyID, user.UserID, StartTime, EndTime, CompanyIDList, ServiceTypeID);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadYingXiaoManyiAnalysis(dg, TopCompanyID, TopProjectIDList, ServiceTypeID, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadrepaircountanalysis(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            List<int> RoomIDList = new List<int>();
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            int[] CompanyIDList = new int[] { };
            List<int> TopProjectIDList = new List<int>();
            WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int ServiceTypeID2 = WebUtil.GetIntValue(context, "ServiceTypeID2");
            int ServiceTypeID3 = WebUtil.GetIntValue(context, "ServiceTypeID3");
            int TopCompanyID = WebUtil.GetIntValue(context, "TopCompanyID");
            var dg = RepairCountAnalysis.GetRepairCountAnalysisGrid(RoomIDList, EqualProjectIDList, InProjectIDList, TopProjectIDList, TopCompanyID, user.UserID, StartTime, EndTime, CompanyIDList, ServiceTypeID2, ServiceTypeID3);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadRepairCountAnalysis(dg, TopCompanyID, TopProjectIDList, ServiceTypeID2, ServiceTypeID3, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadservicefromcountanalysis(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            List<int> RoomIDList = new List<int>();
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            int[] CompanyIDList = new int[] { };
            List<int> TopProjectIDList = new List<int>();
            WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int ServiceTypeID = WebUtil.GetIntValue(context, "ServiceTypeID");
            var dg = TouSuFromAnalysis.GetTouSuFromAnalysisGrid(RoomIDList, EqualProjectIDList, InProjectIDList, user.UserID, StartTime, EndTime, ServiceTypeID: ServiceTypeID);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadServiceFromCountAnalysis(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadwuyetousucountanalysis(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            List<int> RoomIDList = new List<int>();
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            int[] CompanyIDList = new int[] { };
            List<int> TopProjectIDList = new List<int>();
            WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int ServiceTypeID = WebUtil.GetIntValue(context, "ServiceTypeID");
            int ServiceTypeID2 = WebUtil.GetIntValue(context, "ServiceTypeID2");
            int ServiceTypeID3 = WebUtil.GetIntValue(context, "ServiceTypeID3");
            int TopCompanyID = WebUtil.GetIntValue(context, "TopCompanyID");
            var dg = TouSuCountAnalysis.GetTouSuCountAnalysisGrid(RoomIDList, EqualProjectIDList, InProjectIDList, TopProjectIDList, TopCompanyID, user.UserID, StartTime, EndTime, CompanyIDList, ServiceTypeID2, ServiceTypeID3, ServiceTypeID: ServiceTypeID);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadWuYeTouSuCountAnalysis(dg, TopCompanyID, TopProjectIDList, ServiceTypeID2, ServiceTypeID3, ServiceTypeID, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }
        private void loadcallsummaryanalysis(HttpContext context)
        {
            var user = WebUtil.GetUser(context);
            List<int> RoomIDList = new List<int>();
            List<int> EqualProjectIDList = new List<int>();
            List<int> InProjectIDList = new List<int>();
            int[] CompanyIDList = new int[] { };
            List<int> TopProjectIDList = new List<int>();
            WebUtil.GetRoomProjectIDList(out RoomIDList, out EqualProjectIDList, out InProjectIDList, out CompanyIDList, out TopProjectIDList);
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int AddUserID = WebUtil.GetIntValue(context, "AddUserID");
            var dg = CallSummaryAnalysis.GetCallSummaryAnalysisGrid(RoomIDList, EqualProjectIDList, InProjectIDList, StartTime, EndTime, user.UserID, AddUserID);
            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            if (canexport)
            {
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadCallSummaryAnalysis(dg, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                return;
            }
            WebUtil.WriteJson(context, dg);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}