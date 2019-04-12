using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;
using Utility;
using DataAccess.Analysis;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a JPushLog.
    /// </summary>
    public partial class AnalysisAccess : EntityBaseReadOnly
    {
        protected override void EnsureParentProperties()
        {
        }
    }
    public partial class CallSummaryAnalysis : AnalysisAccess
    {
        /// <summary>
        /// 呼入管理统计表
        /// </summary>
        /// <param name="RoomIDList"></param>
        /// <param name="EqualProjectIDList"></param>
        /// <param name="InProjectIDList"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="UserID"></param>
        /// <param name="AddUserID"></param>
        /// <returns></returns>
        public static Ui.DataGrid GetCallSummaryAnalysisGrid(List<int> RoomIDList, List<int> EqualProjectIDList, List<int> InProjectIDList, DateTime StartTime, DateTime EndTime, int UserID, int AddUserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var dg = new Ui.DataGrid();
            dg.page = 1;
            dg.total = 0;
            dg.rows = new int[] { };
            string cmdtext = "select [UserID],[RealName] from [User] where [PositionName]='400专员'";
            var userList = GetList<User>(cmdtext, new List<SqlParameter>()).ToArray();
            if (AddUserID > 0)
            {
                userList = userList.Where(p => p.UserID == AddUserID).ToArray();
            }
            if (userList.Length == 0)
            {
                return dg;
            }
            var userIDList = userList.Select(p => p.UserID).ToList();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("ServiceStatus not in (2,5)");
            conditions.Add("(CanNotCallback is null or CanNotCallback=0)");
            //if (StartTime > DateTime.MinValue)
            //{
            //    conditions.Add("[AddTime]>=@StartTime");
            //    parameters.Add(new SqlParameter("@StartTime", StartTime));
            //}
            //if (EndTime > DateTime.MinValue)
            //{
            //    conditions.Add("[AddTime]<=@EndTime");
            //    parameters.Add(new SqlParameter("@EndTime", EndTime));
            //}
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            //cmdlist = new List<string>();
            //cmdlist.Add("([IsClosed]=1 and exists(select 1 from [ServiceType] where [CallBackServiceType]=1 and [ID]=A.ServiceType1ID))");
            //cmdlist.Add("([ServiceStatus]=1 and exists(select 1 from [ServiceType] where [CallBackServiceType]=2 and [ID]=A.ServiceType1ID))");
            //cmdlist.Add("(exists(select 1 from [ServiceType] where [CallBackServiceType]=3 and [ID]=A.ServiceType1ID))");
            //if (cmdlist.Count > 0)
            //{
            //    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            //}
            var serviceTypeList = ServiceType.GetServiceTypes().ToArray();
            var list = GetList<ViewCustomerService>("select * from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            ViewCustomerService.GetFinalViewCustomerDataGrid(list, IncludeTimeOutData: true);
            var serviceList = list.Where(p =>
            {
                var myServiceType = serviceTypeList.FirstOrDefault(q => q.ID == p.ServiceType1ID);
                if (myServiceType == null)
                {
                    return false;
                }
                if (p.IsClosed && p.CallBackServiceType == 1)
                {
                    return true;
                }
                if (p.ServiceStatus == 1 && p.CallBackServiceType == 2)
                {
                    return true;
                }
                if (p.CallBackServiceType == 3)
                {
                    return true;
                }
                return false;
            }).ToArray();
            var banJieList = list.Where(p =>
            {
                var myServiceType = serviceTypeList.FirstOrDefault(q => q.ID == p.ServiceType1ID);
                if (myServiceType == null)
                {
                    return false;
                }
                if (p.IsClosed && p.CallBackServiceType == 1)
                {
                    return true;
                }
                if (p.ServiceStatus == 1 && p.CallBackServiceType == 2)
                {
                    return true;
                }
                if (p.CallBackServiceType == 3)
                {
                    return true;
                }
                return false;
            }).ToArray();
            if (StartTime > DateTime.MinValue)
            {
                banJieList = banJieList.Where(p => p.BanJieTime >= StartTime).ToArray();
                serviceList = serviceList.Where(p => p.AddTime >= StartTime).ToArray();
            }
            if (EndTime > DateTime.MinValue)
            {
                banJieList = banJieList.Where(p => p.BanJieTime <= DateTime.Parse(EndTime.AddDays(1).ToString("yyyy-MM-dd"))).ToArray();
                serviceList = serviceList.Where(p => p.AddTime <= DateTime.Parse(EndTime.AddDays(1).ToString("yyyy-MM-dd"))).ToArray();
            }
            var recordList = GetList<PhoneRecord>("select [ServiceID], [PickUpTime],[HangUpTime],[PhoneType] from [PhoneRecord] where PhoneType=2", new List<SqlParameter>()).ToArray();

            var recordServiceIDList = recordList.Select(p => p.ServiceID).ToArray();
            var recordServiceList = serviceList.Where(p => recordServiceIDList.Contains(p.ID)).ToArray();

            var recordServicePickUpIDList = recordList.Where(p => p.FinalPickUpTime > DateTime.MinValue).Select(p => p.ServiceID).ToArray();
            var recordServicePickUpList = serviceList.Where(p => recordServicePickUpIDList.Contains(p.ID)).ToArray();

            int LianJieTouSuServiceID = new Utility.SiteConfig().LianJieTouSuServiceID;
            int WuYeTouSuServiceID = new Utility.SiteConfig().WuYeTouSuServiceID;
            int YingXiaoTouSuServiceID = new Utility.SiteConfig().YingXiaoTouSuServiceID;
            var tousuList = banJieList.Where(p => p.ServiceType1ID == LianJieTouSuServiceID || p.ServiceType1ID == WuYeTouSuServiceID || p.ServiceType1ID == YingXiaoTouSuServiceID).ToArray();
            int BaoXiuServiceID = new Utility.SiteConfig().BaoXiuServiceID;
            var baoXiuList = serviceList.Where(p => p.ServiceType1ID == BaoXiuServiceID).ToArray();
            var dataList = new List<CallSummaryAnalysisModel>();
            int TotalCallBackTimeOutCount = 0;
            int TotalAddServiceTimeOutCount = 0;
            int CallBackFromPhoneTotalCount = 0;
            int CallBackFromPhonePickUpCount = 0;
            int TouSuTotalCount = tousuList.Length;
            int TouSuCallBackCount = 0;
            int BaoXiuTotalCount = baoXiuList.Length;
            int BaoXiuCallBackCount = 0;
            int TotalCount = 0;
            foreach (var item in userList)
            {
                var data = new CallSummaryAnalysisModel();
                data.UserID = item.UserID;
                data.RealName = item.RealName;

                var myRecordServiceList = recordServiceList.Where(p => p.HuiFangAddUserIDList != null && p.HuiFangAddUserIDList.Contains(item.UserID)).ToArray();
                var myRecordServicePickUpList = recordServicePickUpList.Where(p => p.HuiFangAddUserIDList != null && p.HuiFangAddUserIDList.Contains(item.UserID)).ToArray();
                data.CallBackFromPhoneTotalCount = myRecordServiceList.Length;//电话回访工单总数
                data.CallBackFromPhonePickUpCount = myRecordServicePickUpList.Length;//电话回访接通工单总数

                CallBackFromPhoneTotalCount += data.CallBackFromPhoneTotalCount;
                CallBackFromPhonePickUpCount += data.CallBackFromPhonePickUpCount;

                //投诉回访统计
                var mySericeHuiFangList = serviceList.Where(p => p.HuiFangAddUserIDList != null && p.HuiFangAddUserIDList.Contains(item.UserID)).ToArray();
                mySericeHuiFangList = mySericeHuiFangList.Where(p => p.ServiceType1ID == LianJieTouSuServiceID || p.ServiceType1ID == WuYeTouSuServiceID || p.ServiceType1ID == YingXiaoTouSuServiceID).ToArray();

                data.TotalCallBackTimeOutCount = mySericeHuiFangList.Where(p => p.CallBackTimeOutStatus > 1).ToArray().Length;//投诉回访超时条数
                TotalCallBackTimeOutCount += data.TotalCallBackTimeOutCount;

                data.TouSuTotalCount = TouSuTotalCount;//投诉工单数量

                var myTouSuList = tousuList.Where(p => p.HuiFangAddUserIDList != null && p.HuiFangAddUserIDList.Contains(item.UserID)).ToArray();
                data.TouSuCallBackCount = myTouSuList.Where(p => p.ServiceHuiFangCount > 0).ToArray().Length;//投诉回访数
                TouSuCallBackCount += data.TouSuCallBackCount;

                //报修回访统计
                data.BaoXiuTotalCount = BaoXiuTotalCount;//维修工单数量
                var myBaoXiuList = baoXiuList.Where(p => p.HuiFangAddUserIDList != null && p.HuiFangAddUserIDList.Contains(item.UserID)).ToArray();
                data.BaoXiuCallBackCount = myBaoXiuList.Where(p => p.ServiceHuiFangCount > 0).ToArray().Length;//维修回访数
                BaoXiuCallBackCount += data.BaoXiuCallBackCount;
                var myServiceList = list.Where(p => p.AddUserID == item.UserID).ToArray();
                data.TotalCount = myServiceList.Length;//工单总数
                TotalCount += data.TotalCount;

                var chaoShiList = list.Where(p => p.AddUserID == item.UserID && p.XiaDanTimeOutStatus > 1).ToArray();

                data.TotalAddServiceTimeOutCount = chaoShiList.Length;//下单超时条数
                TotalAddServiceTimeOutCount += data.TotalAddServiceTimeOutCount;

                dataList.Add(data);
            }
            var footerData = new CallSummaryAnalysisModel();
            footerData.RealName = "合计";
            footerData.TotalCallBackTimeOutCount = TotalCallBackTimeOutCount;
            footerData.TotalAddServiceTimeOutCount = TotalAddServiceTimeOutCount;
            footerData.CallBackFromPhoneTotalCount = CallBackFromPhoneTotalCount;
            footerData.CallBackFromPhonePickUpCount = CallBackFromPhonePickUpCount;
            footerData.TouSuTotalCount = TouSuTotalCount;
            footerData.TouSuCallBackCount = TouSuCallBackCount;
            footerData.BaoXiuTotalCount = BaoXiuTotalCount;
            footerData.BaoXiuCallBackCount = BaoXiuCallBackCount;
            footerData.TotalCount = TotalCount;
            dataList.Add(footerData);
            dg.rows = dataList;
            dg.total = dataList.Count;
            return dg;
        }
        /// <summary>
        /// 400热线接通率&未接来电回复率
        /// </summary>
        public static Ui.DataGrid GetCallTotalAnalysisGrid(DateTime StartTime, DateTime EndTime, int UserID, int AddUserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var dg = new Ui.DataGrid();
            dg.page = 1;
            dg.total = 0;
            dg.rows = new int[] { };
            string cmdtext = "select [UserID],[RealName] from [User] where [PositionName]='400专员'";
            var userList = GetList<User>(cmdtext, new List<SqlParameter>()).ToArray();
            if (AddUserID > 0)
            {
                userList = userList.Where(p => p.UserID == AddUserID).ToArray();
            }
            if (userList.Length == 0)
            {
                return dg;
            }
            var allList = GetList<PhoneRecord>("select * from [PhoneRecord]", new List<SqlParameter>()).ToArray();
            var recordList = allList;
            if (StartTime > DateTime.MinValue)
            {
                recordList = recordList.Where(p => p.CallTime >= StartTime).ToArray();
            }
            if (EndTime > DateTime.MinValue)
            {
                recordList = recordList.Where(p => p.AddTime <= DateTime.Parse(EndTime.AddDays(1).ToString("yyyy-MM-dd"))).ToArray();
            }
            var recordLaiDianList = recordList.Where(p => p.PhoneType == 1).ToArray();
            var recordQuDianList = recordList.Where(p => p.PhoneType == 2).ToArray();
            var recordLaiDianPickUpList = recordLaiDianList.Where(p => p.PickUpTime > DateTime.MinValue).ToArray();
            var recordLaiDianCallBackList = recordLaiDianList.Where(p =>
            {
                if (p.PickUpTime > DateTime.MinValue)
                {
                    return false;
                }
                var myList = allList.Where(q => q.RelatedPhoneRecordID == p.ID).ToArray();
                if (myList.Length >= 2)
                {
                    return true;
                }
                if (myList.Length == 1 && myList[0].PickUpTime > DateTime.MinValue)
                {
                    return true;
                }
                return false;
            }).ToArray();
            var data = new CallTotalAnalysisModel();
            data.ALLCallTotalCount = recordLaiDianList.Length;
            data.ALLCallIsOnCount = recordLaiDianPickUpList.Length;
            data.ALLCallNotPickUpBackCount = recordLaiDianCallBackList.Length;

            var holidayList = HolidayLog.GetHolidayTypeList(DateTime.Now, DateTime.Now);
            DateTime WorkStartTime = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd") + " 09:00");
            DateTime WorkEndTime = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd") + " 18:00");
            var workRecordLaiDianList = recordLaiDianList.Where(p =>
            {
                return CheckWorkTimeStatus(p, holidayList, WorkStartTime, WorkEndTime);
            }).ToArray();
            var workRecordLaiDianPickUpList = recordLaiDianPickUpList.Where(p =>
            {
                return CheckWorkTimeStatus(p, holidayList, WorkStartTime, WorkEndTime);
            }).ToArray();
            var workRecordLaiDianCallBackList = recordLaiDianCallBackList.Where(p =>
            {
                return CheckWorkTimeStatus(p, holidayList, WorkStartTime, WorkEndTime);
            }).ToArray();
            data.WorkCallTotalCount = workRecordLaiDianList.Length;
            data.WorkCallIsOnCount = workRecordLaiDianPickUpList.Length;
            data.WorkCallNotPickUpBackCount = workRecordLaiDianCallBackList.Length;

            var list = new CallTotalAnalysisModel[] { data };
            dg.rows = list.ToList();
            dg.total = 1;
            dg.page = 1;
            return dg;
        }
        public static bool CheckWorkTimeStatus(PhoneRecord data, HolidayLog[] holidayList, DateTime WorkStartTime, DateTime WorkEndTime)
        {
            DateTime callTime = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd") + " " + data.CallTime.ToString("HH:mm:ss"));
            string callStr = data.CallTime.ToString("yyyyMMdd");
            var myHolidayData = holidayList.FirstOrDefault(q => q.Day.Equals(callStr));
            if (myHolidayData != null && myHolidayData.Value == 0)
            {
                if (callTime >= WorkStartTime && callTime <= WorkEndTime)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public partial class TouSuCountAnalysis : AnalysisAccess
    {
        /// <summary>
        /// 数量统计表
        /// </summary>
        /// <param name="RoomIDList"></param>
        /// <param name="EqualProjectIDList"></param>
        /// <param name="InProjectIDList"></param>
        /// <param name="UserID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="CompanyIDList"></param>
        /// <param name="ServiceTypeID2List"></param>
        /// <param name="ServiceTypeID">1-物业投诉 2-营销投诉</param>
        /// <returns></returns>
        public static Ui.DataGrid GetTouSuCountAnalysisGrid(List<int> RoomIDList, List<int> EqualProjectIDList, List<int> InProjectIDList, List<int> TopProjectIDList, int TopCompanyID, int UserID, DateTime StartTime, DateTime EndTime, int[] CompanyIDList, int ServiceTypeID2, int ServiceTypeID3, int ServiceTypeID = 1)
        {
            var dg = new Ui.DataGrid();
            dg.page = 1;
            dg.total = 0;
            dg.rows = new int[] { };
            var serviceTypeList = ServiceType.GetServiceTypes().ToArray();
            var serviceType2List = new ServiceType[] { };
            var serviceType3List = new ServiceType[] { };
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("ServiceStatus not in (2,5)");
            if (ServiceTypeID == 1)
            {
                int WuYeTouSuServiceID = new SiteConfig().WuYeTouSuServiceID;
                conditions.Add("ServiceType1ID=" + WuYeTouSuServiceID);
                serviceType2List = serviceTypeList.Where(p => p.ParentID == WuYeTouSuServiceID).ToArray();
            }
            else
            {
                int YingXiaoTouSuServiceID = new SiteConfig().YingXiaoTouSuServiceID;
                conditions.Add("ServiceType1ID=" + YingXiaoTouSuServiceID);
                serviceType2List = serviceTypeList.Where(p => p.ParentID == YingXiaoTouSuServiceID).ToArray();
            }
            serviceType3List = serviceTypeList.Where(p => serviceType2List.Select(q => q.ID).ToArray().Contains(p.ParentID)).ToArray();
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
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (CompanyIDList.Length > 0)
            {
                conditions.Add("exists(select 1 from [Project] where [CustomerService].ProjectID=Project.ID and [Project].CompanyID in (" + string.Join(",", CompanyIDList) + "))");
            }
            var serviceList = GetList<CustomerServiceDetail>("select ID,ProjectID,ServiceType2ID,ServiceType3ID,(select AllParentID from [Project] where ID=[CustomerService].ProjectID) as AllParentID,(select CompanyID from [Project] where ID=[CustomerService].ProjectID) as CompanyID from [CustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            if (ServiceTypeID2 > 0)
            {
                serviceList = serviceList.Where(p => p.ServiceType2IDList.Contains(ServiceTypeID2)).ToArray();
                serviceType2List = serviceType2List.Where(p => p.ID == ServiceTypeID2).ToArray();
            }
            if (ServiceTypeID3 > 0)
            {
                serviceList = serviceList.Where(p => p.ServiceType3IDList.Contains(ServiceTypeID3)).ToArray();
                serviceType3List = serviceType3List.Where(p => p.ID == ServiceTypeID3).ToArray();
            }
            var companyList = Company.GetCompanies().ToArray();
            string cmdwhere = "";
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            if (CompanyIDList.Length > 0)
            {
                cmdwhere = " and CompanyID in (" + string.Join(",", CompanyIDList) + ")";
                companyList = companyList.Where(p => CompanyIDList.Contains(p.CompanyID)).ToArray();
            }
            var topProjectList = GetList<Project>("select * from [Project] where ParentID=1 " + cmdwhere, parameters2);
            var dataList = new List<TouSuCountAnalysisModel>();
            if (TopCompanyID <= -1 && TopProjectIDList.Count == 0 && ServiceTypeID2 > -1)
            {
                var dataList1 = AnalysisHelper.GetTouSuCountAnalysisModelList(serviceType2List, serviceType3List, serviceList, ServiceTypeID2, ServiceTypeID3);
                dataList.AddRange(dataList1);
            }
            else
            {
                foreach (var companyItem in companyList)
                {
                    var myCompanyServiceList = serviceList.Where(p => p.CompanyID == companyItem.CompanyID).ToArray();
                    if (myCompanyServiceList.Length == 0)
                    {
                        continue;
                    }
                    if (TopCompanyID > -1 && TopProjectIDList.Count == 0)
                    {
                        if (ServiceTypeID2 > -1)
                        {
                            var dataList1 = AnalysisHelper.GetTouSuCountAnalysisModelList(serviceType2List, serviceType3List, myCompanyServiceList, ServiceTypeID2, ServiceTypeID3, companyItem: companyItem);
                            dataList.AddRange(dataList1);
                            continue;
                        }
                        var data = new TouSuCountAnalysisModel();
                        data.CompanyID = companyItem.CompanyID;
                        data.CompanyName = companyItem.CompanyName;
                        data.ProjectID = 0;
                        data.ProjectName = "";
                        data.TotalCount = myCompanyServiceList.Length;
                        data.ServiceType2ID = 0;
                        data.ServiceTypeName2 = "";
                        data.ServiceType3ID = 0;
                        data.ServiceTypeName3 = "";
                        dataList.Add(data);
                        continue;
                    }
                    foreach (var item in topProjectList)
                    {
                        var myList = myCompanyServiceList.Where(p => (!string.IsNullOrEmpty(p.AllParentID) && p.AllParentID.Contains("," + item.ID.ToString() + ",")) || p.ProjectID == item.ID).ToArray();
                        if (myList.Length == 0)
                        {
                            continue;
                        }
                        if (ServiceTypeID2 <= -1 && TopProjectIDList.Count > 0)
                        {
                            var data = new TouSuCountAnalysisModel();
                            data.CompanyID = companyItem.CompanyID;
                            data.CompanyName = companyItem.CompanyName;
                            data.ProjectID = item.ID;
                            data.ProjectName = item.Name;
                            data.TotalCount = myList.Length;
                            data.ServiceType2ID = 0;
                            data.ServiceTypeName2 = "";
                            data.ServiceType3ID = 0;
                            data.ServiceTypeName3 = "";
                            dataList.Add(data);
                            continue;
                        }
                        var dataList1 = AnalysisHelper.GetTouSuCountAnalysisModelList(serviceType2List, serviceType3List, myList, ServiceTypeID2, ServiceTypeID3, companyItem: companyItem, projectItem: item);
                        dataList.AddRange(dataList1);
                    }
                }
            }
            dg.rows = dataList;
            dg.total = dataList.Count;
            return dg;
        }
    }
    public partial class TouSuFromAnalysis : AnalysisAccess
    {
        /// <summary>
        /// 投诉来源统计表
        /// </summary>
        /// <param name="RoomIDList"></param>
        /// <param name="EqualProjectIDList"></param>
        /// <param name="InProjectIDList"></param>
        /// <param name="UserID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public static Ui.DataGrid GetTouSuFromAnalysisGrid(List<int> RoomIDList, List<int> EqualProjectIDList, List<int> InProjectIDList, int UserID, DateTime StartTime, DateTime EndTime, int ServiceTypeID = 1)
        {
            var dg = new Ui.DataGrid();
            dg.page = 1;
            dg.total = 0;
            dg.rows = new int[] { };
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("ServiceStatus not in (2,5)");
            if (ServiceTypeID == 1)
            {
                int BaoXiuServiceID = new SiteConfig().BaoXiuServiceID;
                conditions.Add("ServiceType1ID=" + BaoXiuServiceID);
            }
            else
            {
                int YingXiaoTouSuServiceID = new SiteConfig().YingXiaoTouSuServiceID;
                int LianJieTouSuServiceID = new SiteConfig().LianJieTouSuServiceID;
                int WuYeTouSuServiceID = new SiteConfig().WuYeTouSuServiceID;
                conditions.Add("ServiceType1ID in (" + YingXiaoTouSuServiceID + "," + LianJieTouSuServiceID + "," + WuYeTouSuServiceID + ")");
            }
            //conditions.Add("exists(select 1 from [ServiceType] where ID=[CustomerService].ServiceType1ID and GongDanType=2)");
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
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            string cmdtext = "";
            cmdtext = "select count(1) as TotalCount,ServiceFrom from [CustomerService] where " + string.Join(" and ", conditions.ToArray()) + " group by ServiceFrom";
            var list = GetList<TouSuFromAnalysisModel>(cmdtext, parameters).ToArray();
            var dataList = new List<TouSuFromAnalysisModel>();
            foreach (Utility.EnumModel.WechatServiceFromDefine item in Enum.GetValues(typeof(Utility.EnumModel.WechatServiceFromDefine)))
            {
                if (item.ToString().Equals("app"))
                {
                    continue;
                }
                var data = new TouSuFromAnalysisModel();
                data.ServiceFrom = item.ToString();
                var myItem = list.FirstOrDefault(p => p.ServiceFrom.Equals(item.ToString()));
                if (myItem != null)
                {
                    data.TotalCount = myItem.TotalCount;
                }
                dataList.Add(data);
            }
            dg.rows = dataList;
            dg.total = dataList.Count;
            return dg;
        }
    }
    public partial class RepairCountAnalysis : AnalysisAccess
    {
        /// <summary>
        /// 维修数量统计表
        /// </summary>
        /// <param name="RoomIDList"></param>
        /// <param name="EqualProjectIDList"></param>
        /// <param name="InProjectIDList"></param>
        /// <param name="UserID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="CompanyID"></param>
        /// <param name="ServiceTypeID2"></param>
        /// <param name="ServiceTypeID3"></param>
        /// <returns></returns>
        public static Ui.DataGrid GetRepairCountAnalysisGrid(List<int> RoomIDList, List<int> EqualProjectIDList, List<int> InProjectIDList, List<int> TopProjectIDList, int TopCompanyID, int UserID, DateTime StartTime, DateTime EndTime, int[] CompanyIDList, int ServiceTypeID2, int ServiceTypeID3)
        {
            var dg = new Ui.DataGrid();
            dg.page = 1;
            dg.total = 0;
            dg.rows = new int[] { };
            var serviceTypeList = ServiceType.GetServiceTypes().ToArray();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("ServiceStatus not in (2,5)");
            int BaoXiuServiceID = new SiteConfig().BaoXiuServiceID;
            conditions.Add("ServiceType1ID=" + BaoXiuServiceID);
            var serviceType2List = serviceTypeList.Where(p => p.ParentID == BaoXiuServiceID).ToArray();
            var serviceType3List = serviceTypeList.Where(p => serviceType2List.Select(q => q.ID).Contains(p.ParentID)).ToArray();
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
            var list = new RepairCountAnalysisModel[] { };
            var dataList = new List<RepairCountAnalysisModel>();
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (CompanyIDList.Length > 0)
            {
                conditions.Add("exists(select 1 from [Project] where [CustomerService].ProjectID=Project.ID and [Project].CompanyID in (" + string.Join(",", CompanyIDList) + "))");
            }
            var serviceList = GetList<CustomerServiceDetail>("select ID,ProjectID,ServiceType2ID,ServiceType3ID,(select AllParentID from [Project] where ID=[CustomerService].ProjectID) as AllParentID,(select CompanyID from [Project] where ID=[CustomerService].ProjectID) as CompanyID from [CustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            if (ServiceTypeID2 > 0)
            {
                serviceList = serviceList.Where(p => p.ServiceType2IDList.Contains(ServiceTypeID2)).ToArray();
                serviceType2List = serviceType2List.Where(p => p.ID == ServiceTypeID2).ToArray();
            }
            if (ServiceTypeID3 > 0)
            {
                serviceList = serviceList.Where(p => p.ServiceType3IDList.Contains(ServiceTypeID3)).ToArray();
                serviceType3List = serviceType3List.Where(p => p.ID == ServiceTypeID3).ToArray();
            }
            Project[] projectList = new Project[] { };
            string cmdwhere = "";
            var companyList = Company.GetCompanies().ToArray();
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            if (CompanyIDList.Length > 0)
            {
                cmdwhere = " and CompanyID in (" + string.Join(",", CompanyIDList) + ")";
                companyList = companyList.Where(p => CompanyIDList.Contains(p.CompanyID)).ToArray();
            }
            var topProjectList = GetList<Project>("select * from [Project] where ParentID=1 " + cmdwhere, parameters2);
            if (TopCompanyID <= -1 && TopProjectIDList.Count == 0 && ServiceTypeID2 > -1)
            {
                var dataList1 = AnalysisHelper.GetRepairCountAnalysisModelList(serviceType2List, serviceType3List, serviceList, ServiceTypeID2, ServiceTypeID3);
                dataList.AddRange(dataList1);
            }
            else
            {
                foreach (var companyItem in companyList)
                {
                    var myCompanyServiceList = serviceList.Where(p => p.CompanyID == companyItem.CompanyID).ToArray();
                    if (myCompanyServiceList.Length == 0)
                    {
                        continue;
                    }
                    if (TopCompanyID > -1 && TopProjectIDList.Count == 0)
                    {
                        if (ServiceTypeID2 > -1)
                        {
                            var dataList1 = AnalysisHelper.GetRepairCountAnalysisModelList(serviceType2List, serviceType3List, myCompanyServiceList, ServiceTypeID2, ServiceTypeID3, companyItem: companyItem);
                            dataList.AddRange(dataList1);
                            continue;
                        }
                        var data = new RepairCountAnalysisModel();
                        data.CompanyID = companyItem.CompanyID;
                        data.CompanyName = companyItem.CompanyName;
                        data.ProjectID = 0;
                        data.ProjectName = "";
                        data.TotalCount = myCompanyServiceList.Length;
                        data.ServiceType2ID = 0;
                        data.ServiceTypeName2 = "";
                        data.ServiceType3ID = 0;
                        data.ServiceTypeName3 = "";
                        dataList.Add(data);
                        continue;
                    }
                    foreach (var item in topProjectList)
                    {
                        var myServiceList = myCompanyServiceList.Where(p => (!string.IsNullOrEmpty(p.AllParentID) && p.AllParentID.Contains("," + item.ID.ToString() + ",")) || p.ProjectID == item.ID).ToArray();
                        if (myServiceList.Length == 0)
                        {
                            continue;
                        }
                        if (ServiceTypeID2 <= -1 && TopProjectIDList.Count > 0)
                        {
                            var data = new RepairCountAnalysisModel();
                            data.CompanyID = companyItem.CompanyID;
                            data.CompanyName = companyItem.CompanyName;
                            data.ProjectID = item.ID;
                            data.ProjectName = item.Name;
                            data.ServiceType2ID = 0;
                            data.ServiceTypeName2 = string.Empty;
                            data.TotalCount = myServiceList.Length;
                            dataList.Add(data);
                            continue;
                        }
                        var dataList1 = AnalysisHelper.GetRepairCountAnalysisModelList(serviceType2List, serviceType3List, myServiceList, ServiceTypeID2, ServiceTypeID3, companyItem: companyItem, projectItem: item);
                        dataList.AddRange(dataList1);
                    }
                }
            }
            dg.rows = dataList;
            dg.total = dataList.Count;
            return dg;
        }
    }
    public partial class YingXiaoManyiAnalysis : AnalysisAccess
    {
        /// <summary>
        /// 营销类投诉处理满意度统计表
        /// </summary>
        /// <param name="RoomIDList"></param>
        /// <param name="EqualProjectIDList"></param>
        /// <param name="InProjectIDList"></param>
        /// <param name="UserID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="CompanyID"></param>
        /// <param name="ServiceType">1-营销类投诉 2-物业投诉、维修 3-物业投诉 4-维修</param>
        /// <returns></returns>
        public static Ui.DataGrid GetYingXiaoManyiAnalysisGrid(List<int> RoomIDList, List<int> EqualProjectIDList, List<int> InProjectIDList, List<int> TopProjectIDList, int TopCompanyID, int UserID, DateTime StartTime, DateTime EndTime, int[] CompanyIDList, int ServiceTypeID = 1)
        {
            var dg = new Ui.DataGrid();
            dg.page = 1;
            dg.total = 0;
            dg.rows = new int[] { };
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("ServiceStatus not in (2,5)");
            int BaoXiuServiceID = new SiteConfig().BaoXiuServiceID;
            int WuYeTouSuServiceID = new SiteConfig().WuYeTouSuServiceID;
            int YingXiaoTouSuServiceID = new SiteConfig().YingXiaoTouSuServiceID;
            if (ServiceTypeID == 1)
            {
                conditions.Add("ServiceType1ID=" + YingXiaoTouSuServiceID);
            }
            if (ServiceTypeID == 2)
            {
                conditions.Add("(ServiceType1ID=" + BaoXiuServiceID + " or ServiceType1ID=" + WuYeTouSuServiceID + ")");
            }
            if (ServiceTypeID == 3)
            {
                conditions.Add("ServiceType1ID=" + WuYeTouSuServiceID);
            }
            if (ServiceTypeID == 4)
            {
                conditions.Add("ServiceType1ID=" + BaoXiuServiceID);
            }
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
            var dataList = new List<YingXiaoManyiAnalysisModel>();
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (CompanyIDList.Length > 0)
            {
                conditions.Add("exists(select 1 from [Project] where [CustomerService].ProjectID=Project.ID and [Project].CompanyID in (" + string.Join(",", CompanyIDList) + "))");
            }
            conditions.Add("HuiFangRate>0");
            var list = GetList<YingXiaoManyiAnalysisModel>("select A.*,(select AllParentID from [Project] where ID=A.ProjectID) as AllParentID,(select CompanyID from [Project] where ID=A.ProjectID) as CompanyID from (select count(1) as TotalCount, sum(HuiFangRate) as TotalRate,[CustomerService].ProjectID,[CustomerService].ServiceType1ID as ServiceTypeID from [CustomerService] where " + string.Join(" and ", conditions.ToArray()) + " group by [CustomerService].ProjectID,[CustomerService].ServiceType1ID)A", parameters).ToArray();
            var companyList = Company.GetCompanies().ToArray();
            string cmdwhere = "";
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            if (CompanyIDList.Length > 0)
            {
                cmdwhere = " and CompanyID in (" + string.Join(",", CompanyIDList) + ")";
                companyList = companyList.Where(p => CompanyIDList.Contains(p.CompanyID)).ToArray();
            }
            var topProjectList = GetList<Project>("select * from [Project] where ParentID=1 " + cmdwhere, parameters2);
            foreach (var companyItem in companyList)
            {
                var myCompanyServiceList = list.Where(p => p.CompanyID == companyItem.CompanyID).ToArray();
                if (myCompanyServiceList.Length == 0)
                {
                    continue;
                }
                if (TopCompanyID > -1 && TopProjectIDList.Count == 0)
                {
                    var data = new YingXiaoManyiAnalysisModel();
                    //1-营销类投诉 2-物业投诉、维修 3-物业投诉 4-维修
                    data.CompanyID = companyItem.CompanyID;
                    data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                    data.ProjectID = 0;
                    if (ServiceTypeID != 2)
                    {
                        data.ServiceTypeID = ServiceTypeID;
                        data.TotalRate = myCompanyServiceList.Sum(p => p.TotalRate);
                        data.TotalCount = myCompanyServiceList.Sum(p => p.TotalCount);
                        dataList.Add(data);
                    }
                    else
                    {
                        data.ServiceTypeID = 3;
                        data.TotalRate = myCompanyServiceList.Where(p => p.ServiceTypeID == WuYeTouSuServiceID).Sum(p => p.TotalRate);
                        data.TotalCount = myCompanyServiceList.Where(p => p.ServiceTypeID == WuYeTouSuServiceID).Sum(p => p.TotalCount);
                        if (data.TotalCount > 0)
                        {
                            dataList.Add(data);
                        }
                        data.ServiceTypeID = 4;
                        data.TotalRate = myCompanyServiceList.Where(p => p.ServiceTypeID == BaoXiuServiceID).Sum(p => p.TotalRate);
                        data.TotalCount = myCompanyServiceList.Where(p => p.ServiceTypeID == BaoXiuServiceID).Sum(p => p.TotalCount);
                        if (data.TotalCount > 0)
                        {
                            dataList.Add(data);
                        }
                    }
                    continue;
                }
                foreach (var item in topProjectList)
                {
                    var myList = myCompanyServiceList.Where(p => (!string.IsNullOrEmpty(p.AllParentID) && p.AllParentID.Contains("," + item.ID.ToString() + ",")) || p.ProjectID == item.ID).ToArray();
                    if (myList.Length == 0)
                    {
                        continue;
                    }
                    if (ServiceTypeID != 2)
                    {
                        var data = new YingXiaoManyiAnalysisModel();
                        data.CompanyID = companyItem.CompanyID;
                        data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                        data.ProjectID = item.ID;
                        data.ProjectName = item.Name;
                        data.ServiceTypeID = ServiceTypeID;
                        data.TotalRate = myList.Sum(p => p.TotalRate);
                        data.TotalCount = myList.Sum(p => p.TotalCount);
                        dataList.Add(data);
                    }
                    else
                    {
                        var data = new YingXiaoManyiAnalysisModel();
                        data.CompanyID = companyItem.CompanyID;
                        data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                        data.ProjectID = item.ID;
                        data.ProjectName = item.Name;
                        data.ServiceTypeID = 3;
                        data.TotalRate = myList.Where(p => p.ServiceTypeID == WuYeTouSuServiceID).Sum(p => p.TotalRate);
                        data.TotalCount = myList.Where(p => p.ServiceTypeID == WuYeTouSuServiceID).Sum(p => p.TotalCount);
                        if (data.TotalCount > 0)
                        {
                            dataList.Add(data);
                        }
                        data = new YingXiaoManyiAnalysisModel();
                        data.CompanyID = companyItem.CompanyID;
                        data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                        data.ProjectID = item.ID;
                        data.ProjectName = item.Name;
                        data.ServiceTypeID = 4;
                        data.TotalRate = myList.Where(p => p.ServiceTypeID == BaoXiuServiceID).Sum(p => p.TotalRate);
                        data.TotalCount = myList.Where(p => p.ServiceTypeID == BaoXiuServiceID).Sum(p => p.TotalCount);
                        if (data.TotalCount > 0)
                        {
                            dataList.Add(data);
                        }
                    }
                }
            }
            dg.rows = dataList;
            dg.total = dataList.Count;
            return dg;
        }
    }
    public partial class TouSuShiXiaoAnalysis : AnalysisAccess
    {
        /// <summary>
        /// 投诉时效统计表
        /// </summary>
        /// <param name="RoomIDList"></param>
        /// <param name="EqualProjectIDList"></param>
        /// <param name="InProjectIDList"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="UserID"></param>
        /// <param name="CompanyID"></param>
        /// <param name="ServiceTypeID">1-营销投诉 2-物业投诉 3-维修时效</param>
        /// <returns></returns>
        public static Ui.DataGrid GetTouSuShiXiaoAnalysisGrid(List<int> RoomIDList, List<int> EqualProjectIDList, List<int> InProjectIDList, List<int> TopProjectIDList, int TopCompanyID, int UserID, DateTime StartTime, DateTime EndTime, int[] CompanyIDList, int ServiceTypeID2, int ServiceTypeID3, int ServiceTypeID = 1)
        {
            var dg = new Ui.DataGrid();
            dg.page = 1;
            dg.total = 0;
            dg.rows = new int[] { };
            var serviceTypeList = ServiceType.GetServiceTypes().ToArray();
            var serviceType2List = new ServiceType[] { };
            var serviceType3List = new ServiceType[] { };
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("ServiceStatus not in (2,5)");
            if (ServiceTypeID == 1)
            {
                int YingXiaoTouSuServiceID = new SiteConfig().YingXiaoTouSuServiceID;
                conditions.Add("ServiceType1ID=" + YingXiaoTouSuServiceID);
                serviceType2List = serviceTypeList.Where(p => p.ParentID == YingXiaoTouSuServiceID).ToArray();
            }
            if (ServiceTypeID == 2)
            {
                int WuYeTouSuServiceID = new SiteConfig().WuYeTouSuServiceID;
                conditions.Add("ServiceType1ID=" + WuYeTouSuServiceID);
                serviceType2List = serviceTypeList.Where(p => p.ParentID == WuYeTouSuServiceID).ToArray();
            }
            if (ServiceTypeID == 3)
            {
                int BaoXiuServiceID = new SiteConfig().BaoXiuServiceID;
                conditions.Add("ServiceType1ID=" + BaoXiuServiceID);
                serviceType2List = serviceTypeList.Where(p => p.ParentID == BaoXiuServiceID).ToArray();
            }
            serviceType3List = serviceTypeList.Where(p => serviceType2List.Select(q => q.ID).ToArray().Contains(p.ParentID)).ToArray();
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
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ViewCustomerService].[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ViewCustomerService].[ProjectID]", UserID: UserID);
            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ViewCustomerService].[ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (CompanyIDList.Length > 0)
            {
                conditions.Add("exists(select 1 from [Project] where [ViewCustomerService].ProjectID=Project.ID and [Project].CompanyID in (" + string.Join(",", CompanyIDList) + "))");
            }
            var serviceList = GetList<ViewCustomerService>("select *,(select AllParentID from [Project] where ID=[ViewCustomerService].ProjectID) as AllParentID from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            if (ServiceTypeID2 > 0)
            {
                serviceList = serviceList.Where(p => p.ServiceType2IDList.Contains(ServiceTypeID2)).ToArray();
                serviceType2List = serviceType2List.Where(p => p.ID == ServiceTypeID2).ToArray();
            }
            if (ServiceTypeID3 > 0)
            {
                serviceList = serviceList.Where(p => p.ServiceType3IDList.Contains(ServiceTypeID3)).ToArray();
                serviceType3List = serviceType3List.Where(p => p.ID == ServiceTypeID3).ToArray();
            }
            ViewCustomerService.GetFinalViewCustomerDataGrid(serviceList, IncludeTimeOutData: true);
            var companyList = Company.GetCompanies().ToArray();
            string cmdwhere = "";
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            if (CompanyIDList.Length > 0)
            {
                cmdwhere = " and CompanyID in (" + string.Join(",", CompanyIDList) + ")";
                companyList = companyList.Where(p => CompanyIDList.Contains(p.CompanyID)).ToArray();
            }
            var topProjectList = GetList<Project>("select * from [Project] where ParentID=1 " + cmdwhere, parameters2);
            var dataList = new List<TouSuShiXiaoAnalysisModel>();
            if (TopCompanyID <= -1 && topProjectList.Count == 0 && ServiceTypeID2 > -1)
            {
                var dataList1 = AnalysisHelper.GetTouSuShiXiaoAnalysisModelList(serviceType2List, serviceType3List, serviceList, ServiceTypeID2, ServiceTypeID3);
                dataList.AddRange(dataList1);
            }
            else
            {

                foreach (var companyItem in companyList)
                {
                    var myServiceList = serviceList.Where(p => p.CompanyID == companyItem.CompanyID).ToArray();
                    if (myServiceList.Length == 0)
                    {
                        continue;
                    }
                    if (TopCompanyID > -1 && TopProjectIDList.Count == 0)
                    {
                        if (ServiceTypeID2 > -1)
                        {
                            var dataList1 = AnalysisHelper.GetTouSuShiXiaoAnalysisModelList(serviceType2List, serviceType3List, myServiceList, ServiceTypeID2, ServiceTypeID3, companyItem: companyItem);
                            dataList.AddRange(dataList1);
                            continue;
                        }
                        var data = new TouSuShiXiaoAnalysisModel();
                        data.CompanyID = companyItem.CompanyID;
                        data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                        data.ProjectID = 0;
                        data.ProjectName = "";
                        data.TotalCount = myServiceList.Length;
                        data.ChaoShiCount = myServiceList.Where(p => p.TimeOutStatus == 2).ToArray().Length;
                        data.ResponseTimeOutHour = myServiceList.Sum(p => p.ResponseTakeHour);
                        data.ProcessTimeOut = myServiceList.Sum(p => p.ProcessTakeHour);
                        data.CheckTimeOut = myServiceList.Sum(p => p.CheckTakeHour);
                        data.ServiceTypeName2 = "";
                        data.ServiceTypeName3 = "";
                        data.TotalBanJieTimeOut = myServiceList.Sum(p => p.BanJieTakeHour);
                        dataList.Add(data);
                        continue;
                    }
                    foreach (var item in topProjectList)
                    {
                        var myList = myServiceList.Where(p => (!string.IsNullOrEmpty(p.AllParentID) && p.AllParentID.Contains("," + item.ID.ToString() + ",")) || p.ProjectID == item.ID).ToArray();
                        if (myList.Length == 0)
                        {
                            continue;
                        }
                        if (TopProjectIDList.Count > 0 && ServiceTypeID2 < 0)
                        {
                            var data = new TouSuShiXiaoAnalysisModel();
                            data.CompanyID = companyItem.CompanyID;
                            data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                            data.ProjectID = item.ID;
                            data.ProjectName = item.Name;
                            data.TotalCount = myList.Length;
                            data.ChaoShiCount = myList.Where(p => p.TimeOutStatus == 2).ToArray().Length;
                            data.CheckTimeOut = myList.Sum(p => p.CheckTakeHour);
                            data.ResponseTimeOutHour = myList.Sum(p => p.ResponseTakeHour);
                            data.ProcessTimeOut = myList.Sum(p => p.ProcessTakeHour);
                            data.ServiceTypeName2 = "";
                            data.ServiceTypeName3 = "";
                            data.TotalBanJieTimeOut = myList.Sum(p => p.BanJieTakeHour);
                            dataList.Add(data);
                            continue;
                        }
                        var dataList1 = AnalysisHelper.GetTouSuShiXiaoAnalysisModelList(serviceType2List, serviceType3List, myList, ServiceTypeID2, ServiceTypeID3, companyItem: companyItem, projectItem: item);
                        dataList.AddRange(dataList1);
                    }
                }
            }
            dg.rows = dataList;
            dg.total = dataList.Count;
            return dg;
        }
    }
    public partial class RepairFeeAnalysis : AnalysisAccess
    {
        /// <summary>
        /// 维修费用统计表
        /// </summary>
        /// <param name="RoomIDList"></param>
        /// <param name="EqualProjectIDList"></param>
        /// <param name="InProjectIDList"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="UserID"></param>
        /// <param name="CompanyIDList"></param>
        /// <param name="ServiceType2IDList"></param>
        /// <param name="ServiceTypeID">1-营销类投诉 2-物业投诉 3-报修</param>
        /// <returns></returns>
        public static Ui.DataGrid GetRepairFeeAnalysisGrid(List<int> RoomIDList, List<int> EqualProjectIDList, List<int> InProjectIDList, List<int> TopProjectIDList, int TopCompanyID, int UserID, DateTime StartTime, DateTime EndTime, int[] CompanyIDList, int ServiceTypeID2, int ServiceTypeID3, int ServiceTypeID = 1)
        {
            var dg = new Ui.DataGrid();
            dg.page = 1;
            dg.total = 0;
            dg.rows = new int[] { };
            var serviceTypeList = ServiceType.GetServiceTypes().ToArray();
            var serviceType2List = new ServiceType[] { };
            var serviceType3List = new ServiceType[] { };
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("ServiceStatus not in (2,5)");
            if (ServiceTypeID == 1)
            {
                int YingXiaoTouSuServiceID = new SiteConfig().YingXiaoTouSuServiceID;
                conditions.Add("ServiceType1ID=" + YingXiaoTouSuServiceID);
                serviceType2List = serviceTypeList.Where(p => p.ParentID == YingXiaoTouSuServiceID).ToArray();
            }
            else if (ServiceTypeID == 2)
            {
                int WuYeTouSuServiceID = new SiteConfig().WuYeTouSuServiceID;
                conditions.Add("ServiceType1ID=" + WuYeTouSuServiceID);
                serviceType2List = serviceTypeList.Where(p => p.ParentID == WuYeTouSuServiceID).ToArray();
            }
            else if (ServiceTypeID == 3)
            {
                int BaoXiuServiceID = new SiteConfig().BaoXiuServiceID;
                conditions.Add("ServiceType1ID=" + BaoXiuServiceID);
                serviceType2List = serviceTypeList.Where(p => p.ParentID == BaoXiuServiceID).ToArray();
            }
            serviceType3List = serviceTypeList.Where(p => serviceType2List.Select(q => q.ID).ToArray().Contains(p.ParentID)).ToArray();
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
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ProjectID]", UserID: UserID);
            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (CompanyIDList.Length > 0)
            {
                conditions.Add("exists(select 1 from [Project] where [CustomerService].ProjectID=Project.ID and [Project].CompanyID in (" + string.Join(",", CompanyIDList) + "))");
            }
            conditions.Add("exists(select 1 from [CustomerServiceChuli] where [ServiceID]=[CustomerService].ID and isnull(HandelFee,0)>0)");
            var serviceList = GetList<CustomerServiceDetail>("select ID,ServiceType2ID,ServiceType3ID,[ProjectID],(select AllParentID from [Project] where ID=[CustomerService].ProjectID) as AllParentID,(select CompanyID from [Project] where ID=[CustomerService].ProjectID) as CompanyID,(select sum(HandelFee) from [CustomerServiceChuli] where [ServiceID]=[CustomerService].ID) as TotalHandleFee from [CustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            if (ServiceTypeID2 > 0)
            {
                serviceList = serviceList.Where(p => p.ServiceType2IDList.Contains(ServiceTypeID2)).ToArray();
                serviceType2List = serviceType2List.Where(p => p.ID == ServiceTypeID2).ToArray();
            }
            if (ServiceTypeID3 > 0)
            {
                serviceList = serviceList.Where(p => p.ServiceType3IDList.Contains(ServiceTypeID3)).ToArray();
                serviceType3List = serviceType3List.Where(p => p.ID == ServiceTypeID3).ToArray();
            }
            var finalList = new List<CustomerServiceDetail>();
            var companyList = Company.GetCompanies().ToArray();
            string cmdwhere = "";
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            if (CompanyIDList.Length > 0)
            {
                cmdwhere = " and CompanyID in (" + string.Join(",", CompanyIDList) + ")";
                companyList = companyList.Where(p => CompanyIDList.Contains(p.CompanyID)).ToArray();
            }
            var topProjectList = GetList<Project>("select * from [Project] where ParentID=1 " + cmdwhere, parameters2);
            var dataList = new List<RepairFeeAnalysisModel>();
            if (TopCompanyID <= -1 && TopProjectIDList.Count == 0 && ServiceTypeID2 > -1)
            {
                var dataList1 = AnalysisHelper.GetRepairFeeAnalysisModelList(serviceType2List, serviceType3List, serviceList, ServiceTypeID2, ServiceTypeID3);
                dataList.AddRange(dataList1);
            }
            else
            {
                foreach (var companyItem in companyList)
                {
                    var myServiceList = serviceList.Where(p => p.CompanyID == companyItem.CompanyID).ToArray();
                    if (myServiceList.Length == 0)
                    {
                        continue;
                    }
                    if (TopCompanyID > -1 && TopProjectIDList.Count == 0)
                    {
                        if (ServiceTypeID2 > -1)
                        {
                            var dataList1 = AnalysisHelper.GetRepairFeeAnalysisModelList(serviceType2List, serviceType3List, myServiceList, ServiceTypeID2, ServiceTypeID3, companyItem: companyItem);
                            dataList.AddRange(dataList1);
                            continue;
                        }
                        var data = new RepairFeeAnalysisModel();
                        data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                        data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                        data.ProjectID = 0;
                        data.ProjectName = "";
                        data.HandleFee = myServiceList.Sum(p => p.TotalHandleFee);
                        data.ServiceTypeName2 = "";
                        data.ServiceTypeName3 = "";
                        dataList.Add(data);
                        continue;
                    }
                    foreach (var projectItem in topProjectList)
                    {
                        var myList = myServiceList.Where(p => (!string.IsNullOrEmpty(p.AllParentID) && p.AllParentID.Contains("," + projectItem.ID.ToString() + ",")) || p.ProjectID == projectItem.ID).ToArray();
                        if (myList.Length == 0)
                        {
                            continue;
                        }
                        if (TopProjectIDList.Count > 0 && ServiceTypeID2 < 0)
                        {
                            var data = new RepairFeeAnalysisModel();
                            data.CompanyID = companyItem != null ? companyItem.CompanyID : 0;
                            data.CompanyName = companyItem != null ? companyItem.CompanyName : "";
                            data.ProjectID = projectItem != null ? projectItem.ID : 0;
                            data.ProjectName = projectItem != null ? projectItem.Name : "";
                            data.HandleFee = myList.Sum(p => p.TotalHandleFee);
                            data.ServiceTypeName2 = "";
                            data.ServiceTypeName3 = "";
                            dataList.Add(data);
                            continue;
                        }
                        var dataList1 = AnalysisHelper.GetRepairFeeAnalysisModelList(serviceType2List, serviceType3List, myList, ServiceTypeID2, ServiceTypeID3, companyItem: companyItem, projectItem: projectItem);
                        dataList.AddRange(dataList1);
                    }
                }
            }
            dg.rows = dataList;
            dg.total = dataList.Count;
            return dg;
        }
    }
    public partial class ChuLiJieDianAnalysis : AnalysisAccess
    {
        public static Ui.DataGrid GetChuLiJieDianAnalysisGrid(List<int> RoomIDList, List<int> EqualProjectIDList, List<int> InProjectIDList, List<int> TopProjectIDList, int TopCompanyID, int UserID, DateTime StartTime, DateTime EndTime, int[] CompanyIDList, int ServiceTypeID = 1)
        {
            var dg = new Ui.DataGrid();
            dg.page = 1;
            dg.total = 0;
            dg.rows = new int[] { };
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("ServiceStatus not in (2,5)");
            if (ServiceTypeID == 1)
            {
                int YingXiaoTouSuServiceID = new SiteConfig().YingXiaoTouSuServiceID;
                conditions.Add("ServiceType1ID=" + YingXiaoTouSuServiceID);
            }
            if (ServiceTypeID == 2)
            {
                int WuYeTouSuServiceID = new SiteConfig().WuYeTouSuServiceID;
                conditions.Add("ServiceType1ID=" + WuYeTouSuServiceID);
            }
            if (ServiceTypeID == 3)
            {
                int BaoXiuServiceID = new SiteConfig().BaoXiuServiceID;
                conditions.Add("ServiceType1ID=" + BaoXiuServiceID);
            }
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
            if (RoomIDList.Count > 0)
            {
                cmdlist = new List<string>();
                cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, IncludeRelation: false, RoomIDName: "[ViewCustomerService].[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (InProjectIDList != null && InProjectIDList.Count > 0)
            {
                cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(InProjectIDList, IncludeRelation: false, RoomIDName: "[ViewCustomerService].[ProjectID]", UserID: UserID);
            }
            if (EqualProjectIDList != null && EqualProjectIDList.Count > 0)
            {
                cmdlist.Add("([ViewCustomerService].[ProjectID] in (" + string.Join(",", EqualProjectIDList.ToArray()) + "))");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (CompanyIDList.Length > 0)
            {
                conditions.Add("exists(select 1 from [Project] where [ViewCustomerService].ProjectID=Project.ID and [Project].CompanyID in (" + string.Join(",", CompanyIDList) + "))");
            }
            var serviceList = GetList<ViewCustomerService>("select *,(select AllParentID from [Project] where ID=[ViewCustomerService].ProjectID) as AllParentID from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            ViewCustomerService.GetFinalViewCustomerDataGrid(serviceList, IncludeTimeOutData: true);
            var companyList = Company.GetCompanies().ToArray();
            string cmdwhere = "";
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            if (CompanyIDList.Length > 0)
            {
                cmdwhere = " and CompanyID in (" + string.Join(",", CompanyIDList) + ")";
                companyList = companyList.Where(p => CompanyIDList.Contains(p.CompanyID)).ToArray();
            }
            var topProjectList = GetList<Project>("select * from [Project] where ParentID=1 " + cmdwhere, parameters2);
            var dataList = new List<ChuLiJieDianAnalysisModel>();
            if (TopCompanyID <= -1 && topProjectList.Count == 0)
            {
                var data = new ChuLiJieDianAnalysisModel();
                data.CompanyID = 0;
                data.CompanyName = "";
                data.ProjectID = 0;
                data.ProjectName = "";
                data.TotalCount = serviceList.Length;
                data.XiaDanTotalTakeHour = serviceList.Sum(p => p.XiaDanTakeHour);
                data.PaiDanTotalTakeHour = serviceList.Sum(p => p.PaiDanTakeHour);
                data.ChuLiTotalTakeHour = serviceList.Sum(p => p.ProcessTakeHour);
                data.BanJieTotalTakeHour = serviceList.Sum(p => p.BanJieTakeHour);
                data.HuiFangTotalTakeHour = serviceList.Sum(p => p.CallBackTakeHour);
                dataList.Add(data);
            }
            else
            {

                foreach (var companyItem in companyList)
                {
                    var myServiceList = serviceList.Where(p => p.CompanyID == companyItem.CompanyID).ToArray();
                    if (myServiceList.Length == 0)
                    {
                        continue;
                    }
                    if (TopCompanyID > -1 && TopProjectIDList.Count == 0)
                    {
                        var data = new ChuLiJieDianAnalysisModel();
                        data.CompanyID = companyItem.CompanyID;
                        data.CompanyName = companyItem.CompanyName;
                        data.ProjectID = 0;
                        data.ProjectName = "";
                        data.TotalCount = myServiceList.Length;
                        data.XiaDanTotalTakeHour = myServiceList.Sum(p => p.XiaDanTakeHour);
                        data.PaiDanTotalTakeHour = myServiceList.Sum(p => p.PaiDanTakeHour);
                        data.ChuLiTotalTakeHour = myServiceList.Sum(p => p.ProcessTakeHour);
                        data.BanJieTotalTakeHour = myServiceList.Sum(p => p.BanJieTakeHour);
                        data.HuiFangTotalTakeHour = myServiceList.Sum(p => p.CallBackTakeHour);
                        dataList.Add(data);
                        continue;
                    }
                    foreach (var item in topProjectList)
                    {
                        var myList = myServiceList.Where(p => (!string.IsNullOrEmpty(p.AllParentID) && p.AllParentID.Contains("," + item.ID.ToString() + ",")) || p.ProjectID == item.ID).ToArray();
                        if (myList.Length == 0)
                        {
                            continue;
                        }
                        var data = new ChuLiJieDianAnalysisModel();
                        data.CompanyID = companyItem.CompanyID;
                        data.CompanyName = companyItem.CompanyName;
                        data.ProjectID = item.ID;
                        data.ProjectName = item.Name;
                        data.TotalCount = myList.Length;
                        data.XiaDanTotalTakeHour = myList.Sum(p => p.XiaDanTakeHour);
                        data.PaiDanTotalTakeHour = myList.Sum(p => p.PaiDanTakeHour);
                        data.ChuLiTotalTakeHour = myList.Sum(p => p.ProcessTakeHour);
                        data.BanJieTotalTakeHour = myList.Sum(p => p.BanJieTakeHour);
                        data.HuiFangTotalTakeHour = myList.Sum(p => p.CallBackTakeHour);
                        dataList.Add(data);
                    }
                }
            }
            dg.rows = dataList;
            dg.total = dataList.Count;
            return dg;
        }
    }
}
