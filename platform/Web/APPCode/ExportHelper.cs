using ExcelProcess;
using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace Web.APPCode
{
    public class ExportHelper
    {
        public static bool DownLoadCallTotalAnalysis(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<CallTotalAnalysisModel>();
            if (dg != null)
            {
                list = dg.rows as List<CallTotalAnalysisModel>;
            }
            if (list == null || list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            var parent_head = new NpoiHeadCfg();
            parent_head = SaveNpoiHead("作时间周一到周五（9:00-18.00）", "作时间周一到周五（9:00-18.00）", HAlign: "center");
            SaveNpoiHead("来电总数", "WorkCallTotalCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("未接来电总数", "WorkCallNotOnCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("接通率(%)", "WorkCallOnPercent", parent_head: parent_head, HAlign: "center");
            head_list.Add(parent_head);
            dt.Columns.Add("WorkCallTotalCount");
            dt.Columns.Add("WorkCallNotOnCount");
            dt.Columns.Add("WorkCallOnPercent");

            parent_head = SaveNpoiHead("非工作时间（含节假日）", "非工作时间（含节假日）", HAlign: "center");
            SaveNpoiHead("未接来电总数", "NotWorkCallNotOnCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("未接来电回复数", "NotWorkCallNotPickUpBackCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("未接来电回复率(%)", "NotWorkCallNotPickUpBackPercent", parent_head: parent_head, HAlign: "center");
            head_list.Add(parent_head);
            dt.Columns.Add("NotWorkCallNotOnCount");
            dt.Columns.Add("NotWorkCallNotPickUpBackCount");
            dt.Columns.Add("NotWorkCallNotPickUpBackPercent");

            parent_head = SaveNpoiHead("全部时间", "全部时间", HAlign: "center");
            SaveNpoiHead("接通率(%)", "ALLWorkCallOnPercent", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("未接来电回复率(%)", "ALLWorkCallNotPickUpBackPercent", parent_head: parent_head, HAlign: "center");
            head_list.Add(parent_head);
            dt.Columns.Add("ALLWorkCallOnPercent");
            dt.Columns.Add("ALLWorkCallNotPickUpBackPercent");

            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                    dr[dt.Columns[j].ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "400_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadJieDianTimeoutAnalysis(Foresight.DataAccess.Ui.DataGrid dg, int TopCompanyID, List<int> TopProjectIDList, int ServiceTypeID, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<ChuLiJieDianAnalysisModel>();
            if (dg != null)
            {
                list = dg.rows as List<ChuLiJieDianAnalysisModel>;
            }
            if (list == null || list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            var parent_head = new NpoiHeadCfg();
            if (TopCompanyID < 0 && TopProjectIDList.Count <= 0)
            {
                SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("CompanyName");
                SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ProjectName");
            }
            else
            {
                if (TopCompanyID >= 0)
                {
                    SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("CompanyName");
                }
                if (TopProjectIDList.Count > 0)
                {
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("ProjectName");
                }
            }
            SaveNpoiHead("总工单数", "TotalCount", head_list: head_list, HAlign: "center");
            dt.Columns.Add("TotalCount");
            SaveNpoiHead("下单平均处理时效", "AverageXiaDanTotalTakeHour", head_list: head_list, HAlign: "center");
            dt.Columns.Add("AverageXiaDanTotalTakeHour");
            SaveNpoiHead("派单平均处理时效", "AveragePaiDanTotalTakeHour", head_list: head_list, HAlign: "center");
            dt.Columns.Add("AveragePaiDanTotalTakeHour");
            SaveNpoiHead("处理平均处理时效", "AverageChuLiTotalTakeHour", head_list: head_list, HAlign: "center");
            dt.Columns.Add("AverageChuLiTotalTakeHour");
            SaveNpoiHead("办结平均处理时效", "AverageBanJieTotalTakeHour", head_list: head_list, HAlign: "center");
            dt.Columns.Add("AverageBanJieTotalTakeHour");
            SaveNpoiHead("回访平均处理时效", "AverageHuiFangTotalTakeHour", head_list: head_list, HAlign: "center");
            dt.Columns.Add("AverageHuiFangTotalTakeHour");
            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                    dr[dt.Columns[j].ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "";
            if (ServiceTypeID == 1)
            {
                FileName = "营销投诉时效";
            }
            else if (ServiceTypeID == 2)
            {
                FileName = "物业投诉时效";
            }
            else if (ServiceTypeID == 3)
            {
                FileName = "报修投诉时效";
            }
            FileName += "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadRepairFeeAnalysis(Foresight.DataAccess.Ui.DataGrid dg, int TopCompanyID, List<int> TopProjectIDList, int ServiceTypeID2, int ServiceTypeID3, int ServiceTypeID, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<RepairFeeAnalysisModel>();
            if (dg != null)
            {
                list = dg.rows as List<RepairFeeAnalysisModel>;
            }
            if (list == null || list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            var parent_head = new NpoiHeadCfg();
            if (TopCompanyID < 0 && TopProjectIDList.Count <= 0 && ServiceTypeID2 < 0 && ServiceTypeID3 < 0)
            {
                SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("CompanyName");
                SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ProjectName");
                if (ServiceTypeID == 3)
                {
                    SaveNpoiHead("维修类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                }
                else
                {
                    SaveNpoiHead("投诉类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                }
                dt.Columns.Add("ServiceTypeName2");
            }
            else
            {
                if (TopCompanyID >= 0)
                {
                    SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("CompanyName");
                }
                if (TopProjectIDList.Count > 0)
                {
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                }
                if (ServiceTypeID2 >= 0)
                {
                    if (ServiceTypeID == 3)
                    {
                        SaveNpoiHead("维修类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                    }
                    else
                    {
                        SaveNpoiHead("投诉类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                    }
                    dt.Columns.Add("ServiceTypeName2");
                }
                if (ServiceTypeID3 >= 0)
                {
                    if (ServiceTypeID == 3)
                    {
                        SaveNpoiHead("维修类型（三级）", "ServiceTypeName3", head_list: head_list, HAlign: "center");
                    }
                    else
                    {
                        SaveNpoiHead("投诉类型（三级）", "ServiceTypeName3", head_list: head_list, HAlign: "center");
                    }
                    dt.Columns.Add("ServiceTypeName3");
                }
            }
            if (ServiceTypeID == 3)
            {
                SaveNpoiHead("处理费用", "HandleFee", head_list: head_list, HAlign: "center");
                dt.Columns.Add("HandleFee");
            }
            else
            {
                SaveNpoiHead("赔付总额", "HandleFee", head_list: head_list, HAlign: "center");
                dt.Columns.Add("HandleFee");
            }
            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                    dr[dt.Columns[j].ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "";
            if (ServiceTypeID == 1)
            {
                FileName = "营销投诉费用";
            }
            else if (ServiceTypeID == 2)
            {
                FileName = "物业投诉费用";
            }
            else if (ServiceTypeID == 3)
            {
                FileName = "报修投诉费用";
            }
            FileName += "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadTouSuShiXiaoAnalysis(Foresight.DataAccess.Ui.DataGrid dg, int TopCompanyID, List<int> TopProjectIDList, int ServiceTypeID2, int ServiceTypeID3, int ServiceTypeID, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<TouSuShiXiaoAnalysisModel>();
            if (dg != null)
            {
                list = dg.rows as List<TouSuShiXiaoAnalysisModel>;
            }
            if (list == null || list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            var parent_head = new NpoiHeadCfg();
            if (TopCompanyID < 0 && TopProjectIDList.Count <= 0 && ServiceTypeID2 < 0 && ServiceTypeID3 < 0)
            {
                SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("CompanyName");
                SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ProjectName");
                if (ServiceTypeID == 3)
                {
                    SaveNpoiHead("维修类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                }
                else
                {
                    SaveNpoiHead("投诉类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                }
                dt.Columns.Add("ServiceTypeName2");
            }
            else
            {
                if (TopCompanyID >= 0)
                {
                    SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("CompanyName");
                }
                if (TopProjectIDList.Count > 0)
                {
                    //SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("ProjectName");
                }
                if (ServiceTypeID2 >= 0)
                {
                    if (ServiceTypeID == 3)
                    {
                        SaveNpoiHead("维修类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                    }
                    else
                    {
                        SaveNpoiHead("投诉类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                    }
                    dt.Columns.Add("ServiceTypeName2");
                }
                if (ServiceTypeID3 >= 0)
                {
                    if (ServiceTypeID == 3)
                    {
                        SaveNpoiHead("维修类型（三级）", "ServiceTypeName3", head_list: head_list, HAlign: "center");
                        dt.Columns.Add("ServiceTypeName2");
                    }
                    else
                    {
                        SaveNpoiHead("投诉类型（三级）", "ServiceTypeName3", head_list: head_list, HAlign: "center");
                        dt.Columns.Add("ServiceTypeName3");
                    }
                }
            }
            if (ServiceTypeID == 3)
            {
                SaveNpoiHead("报修总数", "TotalCount", head_list: head_list, HAlign: "center");
                dt.Columns.Add("TotalCount");
                SaveNpoiHead("超时总数", "ChaoShiCount", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ChaoShiCount");
                SaveNpoiHead("报修超时率", "TimeOutPercent", head_list: head_list, HAlign: "center");
                dt.Columns.Add("TimeOutPercent");
                SaveNpoiHead("报修核查时效率", "AverageCheckTimeOut", head_list: head_list, HAlign: "center");
                dt.Columns.Add("AverageCheckTimeOut");
                SaveNpoiHead("报修处理时效率", "AverageProcessTimeOut", head_list: head_list, HAlign: "center");
                dt.Columns.Add("AverageProcessTimeOut");
                SaveNpoiHead("总体时效率", "AverageTotalBanJieTimeOut", head_list: head_list, HAlign: "center");
                dt.Columns.Add("AverageTotalBanJieTimeOut");
            }
            else
            {
                SaveNpoiHead("投诉总数", "TotalCount", head_list: head_list, HAlign: "center");
                dt.Columns.Add("TotalCount");
                SaveNpoiHead("超时条数（含未关单）", "MoreChaoShiCount", head_list: head_list, HAlign: "center");
                dt.Columns.Add("MoreChaoShiCount");
                SaveNpoiHead("投诉超时率", "TouSuTimeOutPercent", head_list: head_list, HAlign: "center");
                dt.Columns.Add("TouSuTimeOutPercent");
                SaveNpoiHead("回复时效率", "AverageResponseTimeOut", head_list: head_list, HAlign: "center");
                dt.Columns.Add("AverageResponseTimeOut");
                SaveNpoiHead("平均处理时效", "AverageTouSuProcessTimeOut", head_list: head_list, HAlign: "center");
                dt.Columns.Add("AverageTouSuProcessTimeOut");
            }
            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                    dr[dt.Columns[j].ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "";
            if (ServiceTypeID == 1)
            {
                FileName = "营销投诉时效";
            }
            else if (ServiceTypeID == 2)
            {
                FileName = "物业投诉时效";
            }
            else if (ServiceTypeID == 3)
            {
                FileName = "报修投诉时效";
            }
            FileName += "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadYingXiaoManyiAnalysis(Foresight.DataAccess.Ui.DataGrid dg, int TopCompanyID, List<int> TopProjectIDList, int ServiceTypeID, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<YingXiaoManyiAnalysisModel>();
            if (dg != null)
            {
                list = dg.rows as List<YingXiaoManyiAnalysisModel>;
            }
            if (list == null || list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            var parent_head = new NpoiHeadCfg();
            if (TopCompanyID < 0 && TopProjectIDList.Count <= 0)
            {
                SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("CompanyName");
                SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ProjectName");
            }
            else
            {
                if (TopCompanyID >= 0)
                {
                    SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("CompanyName");
                }
                if (TopProjectIDList.Count > 0)
                {
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                }
            }
            SaveNpoiHead("平均满意度", "AverageRate", head_list: head_list, HAlign: "center");
            dt.Columns.Add("AverageRate");
            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                    dr[dt.Columns[j].ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "";
            if (ServiceTypeID == 1)
            {
                FileName = "营销满意";
            }
            else if (ServiceTypeID == 3)
            {
                FileName = "投诉满意";
            }
            else if (ServiceTypeID == 4)
            {
                FileName = "维修满意";
            }
            else
            {
                FileName = "维修投诉满意";
            }
            FileName += "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadRepairCountAnalysis(Foresight.DataAccess.Ui.DataGrid dg, int TopCompanyID, List<int> TopProjectIDList, int ServiceTypeID2, int ServiceTypeID3, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<RepairCountAnalysisModel>();
            if (dg != null)
            {
                list = dg.rows as List<RepairCountAnalysisModel>;
            }
            if (list == null || list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            var parent_head = new NpoiHeadCfg();
            if (TopCompanyID < 0 && TopProjectIDList.Count <= 0 && ServiceTypeID2 < 0 && ServiceTypeID3 < 0)
            {
                SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("CompanyName");
                SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ProjectName");
                SaveNpoiHead("维修类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ServiceTypeName2");
            }
            else
            {
                if (TopCompanyID >= 0)
                {
                    SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("CompanyName");
                }
                if (TopProjectIDList.Count > 0)
                {
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                }
                if (ServiceTypeID2 >= 0)
                {
                    SaveNpoiHead("维修类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("ServiceTypeName2");
                }
                if (ServiceTypeID3 >= 0)
                {
                    SaveNpoiHead("维修类型（三级）", "ServiceTypeName3", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("ServiceTypeName3");
                }
            }
            SaveNpoiHead("数量", "TotalCount", head_list: head_list, HAlign: "center");
            dt.Columns.Add("TotalCount");
            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                    dr[dt.Columns[j].ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "维修数量_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadServiceFromCountAnalysis(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<TouSuFromAnalysisModel>();
            if (dg != null)
            {
                list = dg.rows as List<TouSuFromAnalysisModel>;
            }
            if (list == null || list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            var parent_head = new NpoiHeadCfg();
            SaveNpoiHead("来源", "FromNameDesc", head_list: head_list, HAlign: "center");
            dt.Columns.Add("FromNameDesc");
            SaveNpoiHead("数量", "TotalCount", head_list: head_list, HAlign: "center");
            dt.Columns.Add("TotalCount");
            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                    dr[dt.Columns[j].ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "投诉来源_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadWuYeTouSuCountAnalysis(Foresight.DataAccess.Ui.DataGrid dg, int TopCompanyID, List<int> TopProjectIDList, int ServiceTypeID2, int ServiceTypeID3, int ServiceTypeID, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<TouSuCountAnalysisModel>();
            if (dg != null)
            {
                list = dg.rows as List<TouSuCountAnalysisModel>;
            }
            if (list == null || list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            var parent_head = new NpoiHeadCfg();
            if (TopCompanyID < 0 && TopProjectIDList.Count <= 0 && ServiceTypeID2 < 0 && ServiceTypeID3 < 0)
            {
                SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("CompanyName");
                SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ProjectName");
                SaveNpoiHead("投诉类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ServiceTypeName2");
            }
            else
            {
                if (TopCompanyID >= 0)
                {
                    SaveNpoiHead("公司", "CompanyName", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("CompanyName");
                }
                if (TopProjectIDList.Count > 0)
                {
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                    SaveNpoiHead("项目", "ProjectName", head_list: head_list, HAlign: "center");
                }
                if (ServiceTypeID2 >= 0)
                {
                    SaveNpoiHead("投诉类型（二级）", "ServiceTypeName2", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("ServiceTypeName2");
                }
                if (ServiceTypeID3 >= 0)
                {
                    SaveNpoiHead("投诉类型（三级）", "ServiceTypeName3", head_list: head_list, HAlign: "center");
                    dt.Columns.Add("ServiceTypeName3");
                }
            }
            SaveNpoiHead("数量", "TotalCount", head_list: head_list, HAlign: "center");
            dt.Columns.Add("TotalCount");
            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                    dr[dt.Columns[j].ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "投诉数量_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadCallSummaryAnalysis(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new List<CallSummaryAnalysisModel>();
            if (dg != null)
            {
                list = dg.rows as List<CallSummaryAnalysisModel>;
            }
            if (list == null || list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            DataTable dt = new DataTable();
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            var parent_head = new NpoiHeadCfg();
            SaveNpoiHead("客服姓名", "RealName", head_list: head_list, HAlign: "center");
            dt.Columns.Add("RealName");

            parent_head = SaveNpoiHead("投诉回访信息", "投诉回访信息", HAlign: "center");
            SaveNpoiHead("回访超时条数", "TotalCallBackTimeOutCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("回访超时率", "TotalCallBackTimeOutPercent", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("回访接通率(%)", "CallBackIsOnPercentDesc", parent_head: parent_head, HAlign: "center");
            head_list.Add(parent_head);
            dt.Columns.Add("TotalCallBackTimeOutCount");
            dt.Columns.Add("TotalCallBackTimeOutPercent");
            dt.Columns.Add("CallBackIsOnPercentDesc");

            parent_head = SaveNpoiHead("投诉信息", "投诉信息", HAlign: "center");
            SaveNpoiHead("投诉工单数量", "TouSuTotalCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("投诉回访数", "TouSuCallBackCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("投诉回访率", "TouSuCallBackPercentDesc", parent_head: parent_head, HAlign: "center");
            head_list.Add(parent_head);
            dt.Columns.Add("TouSuTotalCount");
            dt.Columns.Add("TouSuCallBackCount");
            dt.Columns.Add("TouSuCallBackPercentDesc");

            parent_head = SaveNpoiHead("报事信息", "报事信息", HAlign: "center");
            SaveNpoiHead("维修工单数量", "BaoXiuTotalCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("维修回访数", "BaoXiuCallBackCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("维修回访率", "BaoXiuCallBackPercentDesc", parent_head: parent_head, HAlign: "center");
            head_list.Add(parent_head);
            dt.Columns.Add("BaoXiuTotalCount");
            dt.Columns.Add("BaoXiuCallBackCount");
            dt.Columns.Add("BaoXiuCallBackPercentDesc");

            parent_head = SaveNpoiHead("400工单数", "400工单数", HAlign: "center");
            SaveNpoiHead("工单总数", "TotalCount", parent_head: parent_head, HAlign: "center");
            SaveNpoiHead("下单超时条数", "TotalAddServiceTimeOutCount", parent_head: parent_head, HAlign: "center");
            head_list.Add(parent_head);
            dt.Columns.Add("TotalCount");
            dt.Columns.Add("TotalAddServiceTimeOutCount");
            for (int i = 0; i < list.Count; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                    dr[dt.Columns[j].ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
            string FileName = "呼入管理_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadMaterialListData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewCustomerServiceInDetail[] { };
            if (dg != null)
            {
                list = dg.rows as ViewCustomerServiceInDetail[];
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            List<CellRangeAddressModel> rangeList = new List<CellRangeAddressModel>();
            DataTable dt = new DataTable();
            dt.Columns.Add("服务单号");
            dt.Columns.Add("登记时间");
            dt.Columns.Add("是否有偿");
            dt.Columns.Add("是否出库");
            dt.Columns.Add("物品名称");
            dt.Columns.Add("物品规格");
            dt.Columns.Add("数量");
            dt.Columns.Add("单价");
            dt.Columns.Add("金额");
            dt.Columns.Add("维修工费");
            dt.Columns.Add("收费金额");
            dt.Columns.Add("结算状态");
            CellRangeAddressModel model1 = new CellRangeAddressModel();
            CellRangeAddressModel model2 = new CellRangeAddressModel();
            CellRangeAddressModel model3 = new CellRangeAddressModel();
            CellRangeAddressModel model4 = new CellRangeAddressModel();
            CellRangeAddressModel model5 = new CellRangeAddressModel();
            CellRangeAddressModel model6 = new CellRangeAddressModel();
            CellRangeAddressModel model7 = new CellRangeAddressModel();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == 0)
                {

                    model1 = new CellRangeAddressModel();
                    model1.FirstRow = (i + 1);
                    model2 = new CellRangeAddressModel();
                    model2.FirstRow = (i + 1);
                    model3 = new CellRangeAddressModel();
                    model3.FirstRow = (i + 1);
                    model4 = new CellRangeAddressModel();
                    model4.FirstRow = (i + 1);
                    model5 = new CellRangeAddressModel();
                    model5.FirstRow = (i + 1);
                    model6 = new CellRangeAddressModel();
                    model6.FirstRow = (i + 1);
                    model7 = new CellRangeAddressModel();
                    model7.FirstRow = (i + 1);
                }
                DataRow dr = dt.NewRow();
                dr["服务单号"] = list[i].ServiceNumber;
                dr["登记时间"] = WebUtil.GetStrDate(list[i].AddTime);
                dr["是否有偿"] = list[i].PayStatusDesc;
                dr["是否出库"] = list[i].ChukuStatus;
                dr["物品名称"] = list[i].ProductName;
                dr["物品规格"] = list[i].ModelNumber;
                dr["数量"] = list[i].InTotalCount;
                dr["单价"] = list[i].UnitPrice;
                dr["金额"] = list[i].InTotalPrice;
                dr["维修工费"] = list[i].HandelFee;
                dr["收费金额"] = list[i].TotalFee;
                dr["结算状态"] = list[i].BalanceStatusDesc;
                dt.Rows.Add(dr);
                if (i == list.Length - 1)
                {
                    if (model1.IsUse)
                    {
                        rangeList.Add(model1);
                    }
                    if (model2.IsUse)
                    {
                        rangeList.Add(model2);
                    }
                    if (model3.IsUse)
                    {
                        rangeList.Add(model3);
                    }
                    if (model4.IsUse)
                    {
                        rangeList.Add(model4);
                    }
                    if (model5.IsUse)
                    {
                        rangeList.Add(model5);
                    }
                    if (model6.IsUse)
                    {
                        rangeList.Add(model6);
                    }
                    if (model7.IsUse)
                    {
                        rangeList.Add(model7);
                    }
                }
                if (i < list.Length - 1)
                {
                    if (list[i].ServiceID == list[i + 1].ServiceID)
                    {
                        if (dt.Columns["服务单号"] != null)
                        {
                            model1.IsUse = true;
                            model1.LastRow = (i + 2);
                            model1.FirstCol = dt.Columns["服务单号"].Ordinal;
                            model1.LastCol = dt.Columns["服务单号"].Ordinal;
                        }
                        if (dt.Columns["登记时间"] != null)
                        {
                            model2.IsUse = true;
                            model2.LastRow = (i + 2);
                            model2.FirstCol = dt.Columns["登记时间"].Ordinal;
                            model2.LastCol = dt.Columns["登记时间"].Ordinal;
                        }
                        if (dt.Columns["是否有偿"] != null)
                        {
                            model3.IsUse = true;
                            model3.LastRow = (i + 2);
                            model3.FirstCol = dt.Columns["是否有偿"].Ordinal;
                            model3.LastCol = dt.Columns["是否有偿"].Ordinal;
                        }
                        if (dt.Columns["是否出库"] != null)
                        {
                            model4.IsUse = true;
                            model4.LastRow = (i + 2);
                            model4.FirstCol = dt.Columns["是否出库"].Ordinal;
                            model4.LastCol = dt.Columns["是否出库"].Ordinal;
                        }
                        if (dt.Columns["维修工费"] != null)
                        {
                            model5.IsUse = true;
                            model5.LastRow = (i + 2);
                            model5.FirstCol = dt.Columns["维修工费"].Ordinal;
                            model5.LastCol = dt.Columns["维修工费"].Ordinal;
                        }
                        if (dt.Columns["收费金额"] != null)
                        {
                            model6.IsUse = true;
                            model6.LastRow = (i + 2);
                            model6.FirstCol = dt.Columns["收费金额"].Ordinal;
                            model6.LastCol = dt.Columns["收费金额"].Ordinal;
                        }
                        if (dt.Columns["结算状态"] != null)
                        {
                            model7.IsUse = true;
                            model7.LastRow = (i + 2);
                            model7.FirstCol = dt.Columns["结算状态"].Ordinal;
                            model7.LastCol = dt.Columns["结算状态"].Ordinal;
                        }
                    }
                    else
                    {
                        if (model1.IsUse)
                        {
                            rangeList.Add(model1);
                        }
                        if (model2.IsUse)
                        {
                            rangeList.Add(model2);
                        }
                        if (model3.IsUse)
                        {
                            rangeList.Add(model3);
                        }
                        if (model4.IsUse)
                        {
                            rangeList.Add(model4);
                        }
                        if (model5.IsUse)
                        {
                            rangeList.Add(model5);
                        }
                        if (model6.IsUse)
                        {
                            rangeList.Add(model6);
                        }
                        if (model7.IsUse)
                        {
                            rangeList.Add(model7);
                        }
                        model1 = new CellRangeAddressModel();
                        model1.FirstRow = (i + 2);
                        model2 = new CellRangeAddressModel();
                        model2.FirstRow = (i + 2);
                        model3 = new CellRangeAddressModel();
                        model3.FirstRow = (i + 2);
                        model4 = new CellRangeAddressModel();
                        model4.FirstRow = (i + 2);
                        model5 = new CellRangeAddressModel();
                        model5.FirstRow = (i + 2);
                        model6 = new CellRangeAddressModel();
                        model6.FirstRow = (i + 2);
                        model7 = new CellRangeAddressModel();
                        model7.FirstRow = (i + 2);
                    }
                }
            }
            string FileName = "物料清单_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导入模板.xlsx";
            downloadurl = DoExport(FileName, dt, rangeList: rangeList);
            return true;
        }
        public static bool DownLoadCustomerServiceData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            downloadurl = string.Empty;
            error = string.Empty;
            var list = new ViewCustomerService[] { };
            var footers = new ViewCustomerService[] { };
            if (dg != null)
            {
                list = dg.rows as ViewCustomerService[];
                if (dg.footer != null)
                {
                    footers = dg.footer as ViewCustomerService[];
                }
            }
            if (list.Length == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var titleList = GetTableColumns("customerservice");
            List<NpoiHeadCfg> head_list = new List<NpoiHeadCfg>();
            DataTable dt = new DataTable();
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    SaveNpoiHead(item["ColumnName"].ToString(), item["FieldName"].ToString(), head_list: head_list, HAlign: "center");
                    dt.Columns.Add(item["FieldName"].ToString());
                }
            }
            if (!dt.Columns.Contains("重大投诉"))
            {
                SaveNpoiHead("重大投诉", "ImportantDesc", head_list: head_list, HAlign: "center");
                dt.Columns.Add("ImportantDesc");
            }
            for (int i = 0; i < list.Length; i++)
            {
                var dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].ColumnName.Equals("TimeOutDesc"))
                    {
                        dr[dt.Columns[j].ColumnName] = list[i].TimeOutStatus == 2 ? "超时" : "正常";
                    }
                    else if (dt.Columns[j].ColumnName.Equals("ProcessDesc"))
                    {
                        dr[dt.Columns[j].ColumnName] = list[i].ServiceStatusDesc;
                    }
                    else if (dt.Columns[j].ColumnName.Equals("CloseDesc"))
                    {
                        dr[dt.Columns[j].ColumnName] = list[i].IsClosed ? "已关单" : "未关单";
                    }
                    else
                    {
                        object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                        dr[dt.Columns[j].ColumnName] = value;
                    }
                }
                dt.Rows.Add(dr);
            }
            if (footers.Length > 0)
            {
                for (int i = 0; i < footers.Length; i++)
                {
                    var dr = dt.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        object value = GetPropertyValue(list[i], dt.Columns[j].ColumnName);
                        dr[dt.Columns[j].ColumnName] = value;
                    }
                    dt.Rows.Add(dr);
                }
            }
            string FileName = "任务工单_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            downloadurl = DoExport(FileName, dt, heads: head_list);
            return true;
        }
        public static bool DownLoadRoomSourceData(Foresight.DataAccess.Ui.DataGrid dg, out string downloadurl, out string error)
        {
            error = string.Empty;
            downloadurl = string.Empty;
            string PageCode = "roomsource";
            string TableName = Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString();
            var list = dg.rows as List<Dictionary<string, object>>;
            if (list.Count == 0)
            {
                error = "没有可导出的数据";
                return false;
            }
            var fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName).Where(p => p.IsShown).ToArray();
            int MinRoomID = list.Min(p => Convert.ToInt32(p["RoomID"]));
            int MaxRoomID = list.Max(p => Convert.ToInt32(p["RoomID"]));
            var contentlist = Foresight.DataAccess.RoomBasicField.GetRoomBasicFieldsByRoomIDList(MinRoomID, MaxRoomID);
            var titleList = GetTableColumns(PageCode, TableName: TableName);
            DataTable dt = new DataTable();
            dt.Columns.Add("资源ID");
            foreach (var item in titleList)
            {
                if (!dt.Columns.Contains(item["ColumnName"].ToString()))
                {
                    dt.Columns.Add(item["ColumnName"].ToString());
                }
            }
            var comHelper = new APPCode.CommHelper();
            for (int i = 0; i < list.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["资源ID"] = list[i]["RoomID"];
                SetDrValue(titleList, dr, "资源位置", list[i]["FullName"] + "|" + list[i]["Name"]);
                SetDrValue(titleList, dr, "房号", list[i]["Name"]);
                SetDrValue(titleList, dr, "期数", list[i]["BuildingNumber"]);
                DateTime SignDate = WebUtil.GetDateTimeByObj(list[i], "SignDate");
                SetDrValue(titleList, dr, "签约日期", WebUtil.GetStrDate(SignDate));
                DateTime PaymentTime = WebUtil.GetDateTimeByObj(list[i], "PaymentTime");
                SetDrValue(titleList, dr, "交付时间", WebUtil.GetStrDate(PaymentTime));
                DateTime CertificateTime = WebUtil.GetDateTimeByObj(list[i], "CertificateTime");
                SetDrValue(titleList, dr, "产权办理时间", WebUtil.GetStrDate(CertificateTime));
                SetDrValue(titleList, dr, "房产类别", list[i]["RoomType"]);
                SetDrValue(titleList, dr, "精装修情况", list[i]["IsJingZhuangXiuDesc"]);
                SetDrValue(titleList, dr, "房产类型", list[i]["RoomProperty"]);
                decimal BuildingOutArea = WebUtil.GetDecimalByObj(list[i], "BuildingOutArea");
                SetDrValue(titleList, dr, "建筑面积", BuildingOutArea);
                SetDrValue(titleList, dr, "业主1", list[i]["RoomOwner1Name"]);
                SetDrValue(titleList, dr, "业主1联系方式", list[i]["RoomOwner1Phone"]);
                SetDrValue(titleList, dr, "业主2", list[i]["RoomOwner2Name"]);
                SetDrValue(titleList, dr, "业主2联系方式", list[i]["RoomOwner2Phone"]);
                SetDrValue(titleList, dr, "住户1", list[i]["Rent1Name"]);
                SetDrValue(titleList, dr, "住户1联系方式", list[i]["Rent1Phone"]);
                dt.Rows.Add(dr);
            }
            string FileName = "资源信息_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_导出.xlsx";
            downloadurl = DoExport(FileName, dt);
            return true;
        }
        private static string DoExport(string FileName, DataTable dt, List<CellRangeAddressModel> rangeList = null, List<NpoiHeadCfg> heads = null)
        {
            string FileLocation = "/upload/ExcelExport/";
            string filepath = HttpContext.Current.Server.MapPath("~" + FileLocation);
            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }
            string strFileName = System.IO.Path.Combine(filepath, FileName);
            ExcelProcess.ExcelExportHelper.ReportExcel(dt, strFileName, rangeList: rangeList, heads: heads);
            return WebUtil.GetContextPath() + FileLocation + FileName;
        }
        private static List<Dictionary<string, object>> GetTableColumns(string PageCode, string TableName = "")
        {
            var results = new List<Dictionary<string, object>>();
            var context = HttpContext.Current;
            int ColumnServiceStatus = WebUtil.GetIntValue(context, "ColumnServiceStatus");
            int ColumnServiceType = WebUtil.GetIntValue(context, "ColumnServiceType");
            if (ColumnServiceStatus == 35 && ColumnServiceType == 3)
            {
                var dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "CompanyName";
                dataItem["ColumnName"] = "公司";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "FinalProjectName";
                dataItem["ColumnName"] = "项目";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "AddCustomerName";
                dataItem["ColumnName"] = "姓名";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "AddCallPhone";
                dataItem["ColumnName"] = "电话";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "CategoryPartA";
                dataItem["ColumnName"] = "工单类型";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "ServiceContent";
                dataItem["ColumnName"] = "工单内容";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "ServiceStatusDesc";
                dataItem["ColumnName"] = "状态";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "TimeOutDesc";
                dataItem["ColumnName"] = "是否超时";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "FinalBanJieChaoShiTakeHour";
                dataItem["ColumnName"] = "办结超时时间";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "TotalChaoShiTakeHour";
                dataItem["ColumnName"] = "总体超时时间";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "ChaoShiStatusNames";
                dataItem["ColumnName"] = "超时节点";
                results.Add(dataItem);
                dataItem = new Dictionary<string, object>();
                dataItem["FieldName"] = "ServiceFromDesc";
                dataItem["ColumnName"] = "投诉来源";
                results.Add(dataItem);
                return results;
            }
            var list = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode(PageCode, false, ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            var all_fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0);
            results = list.Select(p =>
           {
               if (p.ColumnName.StartsWith("业主自定义"))
               {
                   p.ColumnName = p.ColumnName.Replace("业主", "");
               }
               var exist_fieldlist = all_fieldlist.Where(q => !string.IsNullOrEmpty(q.ColumnName));
               var exist_field = exist_fieldlist.FirstOrDefault(q => q.OriFieldName.Equals(p.ColumnName));
               if (exist_field != null)
               {
                   p.ColumnField = p.ColumnField.Replace(p.ColumnName, exist_field.FieldName);
                   p.ColumnName = exist_field.FieldName;
               }
               var dic = p.ToJsonObject();
               if (dic.ContainsKey("ColumnField"))
               {
                   dic["FieldName"] = Utility.Tools.GetJosnValue("{" + dic["ColumnField"].ToString() + "}", "field", IncludeDoubleMarks: false);
               }
               else
               {
                   dic["FieldName"] = "";
               }
               return dic;
           }).ToList();
            var fieldlist = all_fieldlist.Where(p => string.IsNullOrEmpty(p.ColumnName) && p.IsShown);
            foreach (var item in fieldlist)
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = 0;
                dic["FieldID"] = item.ID;
                dic["PageCode"] = "roomsource";
                dic["FieldName"] = item.FieldName;
                dic["ColumnField"] = "field: '" + item.FieldName + "', title: '" + item.FieldName + "', width: 150";
                dic["SortOrder"] = item.SortOrder < 0 ? 0 : item.SortOrder;
                dic["IsShown"] = item.IsShown;
                dic["ColumnName"] = item.FieldName;
                results.Add(dic);
            }
            results = results.OrderBy(p => p["SortOrder"]).ToList();
            return results;
        }
        private static void SetDrValue(List<Dictionary<string, object>> titleList, DataRow dr, string Title, object Value)
        {
            for (int i = 0; i < titleList.Count; i++)
            {
                if (titleList[i]["ColumnName"].Equals(Title))
                {
                    dr[Title] = Value;
                    break;
                }
            }
        }
        private static NpoiHeadCfg SaveNpoiHead(string FieldLable, string FieldName, List<NpoiHeadCfg> head_list = null, NpoiHeadCfg parent_head = null, int Width = 100, int Height = 20, string HAlign = "left")
        {
            var data = new NpoiHeadCfg();
            data.FieldLable = FieldLable;
            data.FieldName = FieldName;
            data.Width = Width;
            data.Height = Height;
            data.IsBold = true;
            data.HAlign = HAlign;
            if (head_list != null)
            {
                head_list.Add(data);
            }
            if (parent_head != null)
            {
                parent_head.Childs.Add(data);
            }
            return data;
        }
        public static object GetPropertyValue(object data, string Name)
        {
            var data_type = data.GetType();
            var data_property = data_type.GetProperties();
            foreach (PropertyInfo item in data_property)
            {
                if (item.PropertyType == typeof(String) || item.PropertyType == typeof(Int32) || item.PropertyType == typeof(Decimal) || item.PropertyType == typeof(Boolean) || item.PropertyType == typeof(DateTime))//属性的类型判断
                {
                    if (item.Name.Equals(Name))
                    {
                        var Value = item.GetValue(data, null);
                        if (item.PropertyType == typeof(Int32))
                        {
                            int result = 0;
                            int.TryParse(Value.ToString(), out result);
                            return result > int.MinValue ? result : 0;
                        }
                        if (item.PropertyType == typeof(Decimal))
                        {
                            decimal result = 0;
                            decimal.TryParse(Value.ToString(), out result);
                            return result > decimal.MinValue ? result : 0;
                        }
                        if (item.PropertyType == typeof(DateTime))
                        {
                            DateTime result = DateTime.MinValue;
                            DateTime.TryParse(Value.ToString(), out result);
                            return result > DateTime.MinValue ? result.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                        }
                        if (item.PropertyType == typeof(String))
                        {
                            return Value;
                        }
                        break;
                    }
                }
            }
            return string.Empty;
        }
    }
}