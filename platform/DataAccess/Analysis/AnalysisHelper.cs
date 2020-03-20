using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Analysis
{
    public class AnalysisHelper
    {
        public static List<TouSuCountAnalysisModel> GetTouSuCountAnalysisModelList(ServiceType[] serviceType2List, ServiceType[] serviceType3List, CustomerServiceDetail[] serviceList, int ServiceTypeID2, int ServiceTypeID3, Company companyItem = null, Project projectItem = null)
        {
            var dataList = new List<TouSuCountAnalysisModel>();
            foreach (var myServiceType2 in serviceType2List)
            {
                var myServiceList2 = serviceList.Where(p => p.ServiceType2IDList.Contains(myServiceType2.ID)).ToArray();
                if (myServiceList2.Length == 0)
                {
                    continue;
                }
                if (ServiceTypeID3 < 0)
                {
                    var data = new TouSuCountAnalysisModel();
                    data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem != null ? projectItem.ID : 0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.TotalCount = myServiceList2.Length;
                    data.ServiceType2ID = myServiceType2.ID;
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceType3ID = 0;
                    data.ServiceTypeName3 = "";
                    dataList.Add(data);
                    continue;
                }
                var myServiceType3List = serviceType3List.Where(p => p.ParentID == myServiceType2.ID).ToArray();
                foreach (var myServiceType3 in myServiceType3List)
                {
                    var myServiceList3 = serviceList.Where(p => p.ServiceType3IDList.Contains(myServiceType3.ID)).ToArray();
                    if (myServiceList3.Length == 0)
                    {
                        continue;
                    }
                    var data = new TouSuCountAnalysisModel();
                    data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem != null ? projectItem.ID : 0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.TotalCount = myServiceList3.Length;
                    data.ServiceType2ID = myServiceType2.ID;
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceType3ID = myServiceType3.ID;
                    data.ServiceTypeName3 = myServiceType3.ServiceTypeName;
                    dataList.Add(data);
                }
            }
            return dataList;
        }
        public static List<RepairCountAnalysisModel> GetRepairCountAnalysisModelList(ServiceType[] serviceType2List, ServiceType[] serviceType3List, CustomerServiceDetail[] serviceList, int ServiceTypeID2, int ServiceTypeID3, Company companyItem = null, Project projectItem = null)
        {
            var dataList = new List<RepairCountAnalysisModel>();
            foreach (var myServiceType2 in serviceType2List)
            {
                var myServiceList2 = serviceList.Where(p => p.ServiceType2IDList.Contains(myServiceType2.ID)).ToArray();
                if (myServiceList2.Length == 0)
                {
                    continue;
                }
                if (ServiceTypeID3 < 0)
                {
                    var data = new RepairCountAnalysisModel();
                    data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem != null ? projectItem.ID : 0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.TotalCount = myServiceList2.Length;
                    data.ServiceType2ID = myServiceType2.ID;
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceType3ID = 0;
                    data.ServiceTypeName3 = "";
                    dataList.Add(data);
                    continue;
                }
                var myServiceType3List = serviceType3List.Where(p => p.ParentID == myServiceType2.ID).ToArray();
                foreach (var myServiceType3 in myServiceType3List)
                {
                    var myServiceList3 = serviceList.Where(p => p.ServiceType3IDList.Contains(myServiceType3.ID)).ToArray();
                    if (myServiceList3.Length == 0)
                    {
                        continue;
                    }
                    var data = new RepairCountAnalysisModel();
                    data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem != null ? projectItem.ID : 0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.TotalCount = myServiceList3.Length;
                    data.ServiceType2ID = myServiceType2.ID;
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceType3ID = myServiceType3.ID;
                    data.ServiceTypeName3 = myServiceType3.ServiceTypeName;
                    dataList.Add(data);
                }
            }
            return dataList;
        }
        public static List<TouSuShiXiaoAnalysisModel> GetTouSuShiXiaoAnalysisModelList(ServiceType[] serviceType2List, ServiceType[] serviceType3List, ViewCustomerService[] serviceList, int ServiceTypeID2, int ServiceTypeID3, Company companyItem = null, Project projectItem = null)
        {
            var dataList = new List<TouSuShiXiaoAnalysisModel>();
            foreach (var myServiceType2 in serviceType2List)
            {
                var myServiceList2 = serviceList.Where(p => p.ServiceType2IDList.Contains(myServiceType2.ID)).ToArray();
                if (myServiceList2.Length == 0)
                {
                    continue;
                }
                if (ServiceTypeID3 < 0)
                {
                    var data = new TouSuShiXiaoAnalysisModel();
                    data.CompanyID = companyItem.CompanyID;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem!=null?projectItem.ID:0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.TotalCount = myServiceList2.Length;
                    data.ChaoShiCount = myServiceList2.Where(p => p.BanJieTimeOutStatus == 2).ToArray().Length;
                    data.ResponseTimeOutHour = myServiceList2.Sum(p => p.ResponseTakeHour);
                    data.ProcessTimeOut = myServiceList2.Sum(p => p.ProcessTakeHour);
                    data.CheckTimeOut = myServiceList2.Sum(p => p.CheckTakeHour);
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceTypeName3 = "";
                    data.TotalBanJieTimeOut = myServiceList2.Sum(p => p.BanJieTakeHour);
                    dataList.Add(data);
                    continue;
                }
                var myServiceType3List = serviceType3List.Where(p => p.ParentID == myServiceType2.ID).ToArray();
                foreach (var myServiceType3 in myServiceType3List)
                {
                    var myServiceList3 = serviceList.Where(p => p.ServiceType3IDList.Contains(myServiceType3.ID)).ToArray();
                    if (myServiceList3.Length == 0)
                    {
                        continue;
                    }
                    var data = new TouSuShiXiaoAnalysisModel();
                    data.CompanyID = companyItem.CompanyID;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem != null ? projectItem.ID : 0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.TotalCount = myServiceList3.Length;
                    data.ChaoShiCount = myServiceList3.Where(p => p.BanJieTimeOutStatus == 2).ToArray().Length;
                    data.ProcessTimeOut = myServiceList3.Sum(p => p.ProcessTakeHour);
                    data.CheckTimeOut = myServiceList3.Sum(p => p.CheckTakeHour);
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceTypeName3 = myServiceType3.ServiceTypeName;
                    data.TotalBanJieTimeOut = myServiceList3.Sum(p => p.BanJieTakeHour);
                    data.ResponseTimeOutHour = myServiceList3.Sum(p => p.ResponseTakeHour);
                    dataList.Add(data);
                }
            }
            return dataList;
        }
        public static List<RepairFeeAnalysisModel> GetRepairFeeAnalysisModelList(ServiceType[] serviceType2List, ServiceType[] serviceType3List, CustomerServiceDetail[] serviceList, int ServiceTypeID2, int ServiceTypeID3, Company companyItem = null, Project projectItem = null)
        {
            var dataList = new List<RepairFeeAnalysisModel>();
            foreach (var myServiceType2 in serviceType2List)
            {
                var myServiceList2 = serviceList.Where(p => p.ServiceType2IDList.Contains(myServiceType2.ID)).ToArray();
                if (myServiceList2.Length == 0)
                {
                    continue;
                }
                if (ServiceTypeID3 < 0)
                {
                    var data = new RepairFeeAnalysisModel();
                    data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem != null ? projectItem.ID : 0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.HandleFee = myServiceList2.Sum(p => p.TotalHandleFee);
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceTypeName3 = "";
                    dataList.Add(data);
                    continue;
                }
                var myServiceType3List = serviceType3List.Where(p => p.ParentID == myServiceType2.ID).ToArray();
                foreach (var myServiceType3 in myServiceType3List)
                {
                    var myServiceList3 = serviceList.Where(p => p.ServiceType3IDList.Contains(myServiceType3.ID)).ToArray();
                    if (myServiceList3.Length == 0)
                    {
                        continue;
                    }
                    var data = new RepairFeeAnalysisModel();
                    data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem != null ? projectItem.ID : 0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.HandleFee = myServiceList3.Sum(p => p.TotalHandleFee);
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceTypeName3 = myServiceType3.ServiceTypeName;
                    dataList.Add(data);
                }
            }
            return dataList;
        }

        public static List<ChuLiJieDianAnalysisModel> GetChuLiJieDianAnalysisModelList(ServiceType[] serviceType2List, ServiceType[] serviceType3List, ViewCustomerService[] serviceList, int ServiceTypeID2, int ServiceTypeID3, Company companyItem = null, Project projectItem = null)
        {
            var dataList = new List<ChuLiJieDianAnalysisModel>();
            foreach (var myServiceType2 in serviceType2List)
            {
                var myServiceList2 = serviceList.Where(p => p.ServiceType2IDList.Contains(myServiceType2.ID)).ToArray();
                if (myServiceList2.Length == 0)
                {
                    continue;
                }
                if (ServiceTypeID3 < 0)
                {
                    var data = new ChuLiJieDianAnalysisModel();
                    data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem != null ? projectItem.ID : 0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.ServiceType2ID = myServiceType2.ID;
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceTypeName3 = "";
                    data.TotalCount = myServiceList2.Length;
                    data.ResponseTotalTakeHour = myServiceList2.Sum(p => p.ResponseTakeHour);
                    data.PaiDanTotalTakeHour = myServiceList2.Sum(p => p.PaiDanTakeHour);
                    data.ChuLiTotalTakeHour = myServiceList2.Sum(p => p.ProcessTakeHour);
                    data.BanJieTotalTakeHour = myServiceList2.Sum(p => p.BanJieTakeHour);
                    data.HuiFangTotalTakeHour = myServiceList2.Sum(p => p.CallBackTakeHour);
                    dataList.Add(data);

                    continue;
                }
                var myServiceType3List = serviceType3List.Where(p => p.ParentID == myServiceType2.ID).ToArray();
                foreach (var myServiceType3 in myServiceType3List)
                {
                    var myServiceList3 = serviceList.Where(p => p.ServiceType3IDList.Contains(myServiceType3.ID)).ToArray();
                    if (myServiceList3.Length == 0)
                    {
                        continue;
                    }
                    var data = new ChuLiJieDianAnalysisModel();
                    data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = projectItem != null ? projectItem.ID : 0;
                    data.ProjectName = projectItem != null ? projectItem.Name : "";
                    data.ServiceType2ID = myServiceType2.ID;
                    data.ServiceTypeName2 = myServiceType2.ServiceTypeName;
                    data.ServiceType3ID = myServiceType3.ID;
                    data.ServiceTypeName3 = myServiceType3.ServiceTypeName;
                    data.TotalCount = myServiceList2.Length;
                    data.ResponseTotalTakeHour = myServiceList3.Sum(p => p.ResponseTakeHour);
                    data.PaiDanTotalTakeHour = myServiceList3.Sum(p => p.PaiDanTakeHour);
                    data.ChuLiTotalTakeHour = myServiceList3.Sum(p => p.ProcessTakeHour);
                    data.BanJieTotalTakeHour = myServiceList3.Sum(p => p.BanJieTakeHour);
                    data.HuiFangTotalTakeHour = myServiceList3.Sum(p => p.CallBackTakeHour);
                }
            }
            return dataList;
        }
    }
}
