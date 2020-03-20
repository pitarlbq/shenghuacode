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
    /// This object represents the properties and methods of a ViewCustomerService.
    /// </summary>
    public partial class ViewCustomerService : EntityBaseReadOnly
    {
        [DatabaseColumn("AccpetUserCount")]
        public int AccpetUserCount { get; set; }
        [DatabaseColumn("ProcessUserCount")]
        public int ProcessUserCount { get; set; }
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        public static Dictionary<int, string> ServiceAccpetManList = new Dictionary<int, string>();
        public string FinalServiceAccpetMan { get; set; }
        public DateTime FinalServiceAccpetTime { get; set; }
        public string FinalServiceProcessMan { get; set; }
        public DateTime FinalServiceProcessTime { get; set; }
        public static void ResetCache()
        {
            ServiceAccpetManList = new Dictionary<int, string>();
        }
        public string FinalProjectName
        {
            get
            {
                string name = string.Empty;
                if (!string.IsNullOrEmpty(this.FullName))
                {
                    name = this.FullName.Split('-')[0];
                }
                else
                {
                    name = string.IsNullOrEmpty(this.Project_Name) ? this.ProjectName : this.Project_Name;
                }
                return name;
            }
        }
        public static Ui.DataGrid GetMyChaoShiViewCustomerServiceList(string Keywords, int UserID, string orderBy, long startRowIndex, int pageSize, bool canViewAll, List<int> RoomIDList, List<int> EqualProjectIDList = null, List<int> InProjectIDList = null, bool canViewWechatAPPService = false, bool canViewWechatAPPSuggestoin = false, bool canexport = false, decimal BeforeBanJieTimeOutHour = 0)
        {
            return GetCustomerServiceGridByKeywords(Keywords, RoomIDList, DateTime.MinValue, DateTime.MinValue, 13, orderBy, startRowIndex, pageSize, UserID, canViewAll, EqualProjectIDList: EqualProjectIDList, InProjectIDList: InProjectIDList, canexport: canexport, canViewWechatAPPService: canViewWechatAPPService, canViewWechatAPPSuggestoin: canViewWechatAPPSuggestoin, BeforeBanJieTimeOutHour: BeforeBanJieTimeOutHour);
        }
        public static Ui.DataGrid GetCustomerServiceGridByKeywords(string Keywords, List<int> RoomIDList, DateTime StartTime, DateTime EndTime, int ServiceStatus, string orderBy, long startRowIndex, int pageSize, int UserID, bool canViewAll, List<int> EqualProjectIDList = null, List<int> InProjectIDList = null, int[] CompanyIDList = null, int ServiceType = 0, bool canexport = false, bool canViewWechatAPPService = false, bool canViewWechatAPPSuggestoin = false, bool isServiceAnalysis = false, int CloseType = 0, int TimeOutType = 0, bool IsTouSuChaoShi = false, bool IsRepairChaoShi = false, int CallBackStatus = 0, int CallServiceType = 0, int ServiceType1ID = 0, int ServiceType2ID = 0, int ServiceType3ID = 0, int PayStatus = 0, decimal BeforeBanJieTimeOutHour = 0, int IsImportantTouSu = -1, DateTime? CompleteStartTime = null, DateTime? CompleteEndTime = null, string ProcessKewords = "", string CallBackKeywords = "")
        {
            ResetCache();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("1=1");
            conditions.Add("(exists(select 1 from [UserServiceType] where [ServiceTypeID]=A.ServiceType1ID and ([UserID]=@UserID or exists(select 1 from [UserRoles] where [RoleID]=[UserServiceType].RoleID and [UserID]=@UserID))) or A.ServiceType1ID=0)");
            parameters.Add(new SqlParameter("@UserID", UserID));
            if (CompleteStartTime != null && CompleteStartTime.Value > DateTime.MinValue)
            {
                conditions.Add("[BanJieTime]>=@CompleteStartTime");
                parameters.Add(new SqlParameter("@CompleteStartTime", CompleteStartTime.Value));
            }
            if (CompleteEndTime != null && CompleteEndTime.Value > DateTime.MinValue)
            {
                conditions.Add("[BanJieTime]<=@CompleteEndTime");
                parameters.Add(new SqlParameter("@CompleteEndTime", CompleteEndTime.Value.AddDays(1)));
            }
            if (!string.IsNullOrEmpty(ProcessKewords))
            {
                conditions.Add("exists(select 1 from [CustomerServiceChuli] where [ServiceID]=A.ID and ChuliNote like @ProcessKewords)");
                parameters.Add(new SqlParameter("@ProcessKewords", "%" + ProcessKewords + "%"));
            }
            if (!string.IsNullOrEmpty(CallBackKeywords))
            {
                conditions.Add("exists(select 1 from [CustomerServiceHuifang] where [ServiceID]=A.ID and HuiFangNote like @CallBackKeywords)");
                parameters.Add(new SqlParameter("@CallBackKeywords", "%" + CallBackKeywords + "%"));
            }
            if (IsImportantTouSu == -1)//不显示重大报修投诉
            {
                conditions.Add("([IsImportantTouSu]=0 or [IsImportantTouSu] is null)");
            }
            if (IsImportantTouSu == 0)//显示重大报修投诉
            {
                conditions.Add("[IsImportantTouSu]=1");
            }
            if (IsImportantTouSu == 2)//待审核
            {
                conditions.Add("exists(select 1 from [ServiceType_ImportantService] where ServiceID=A.ID and ApproveStatus=0)");
            }
            if (IsImportantTouSu == 3)//审核通过
            {
                conditions.Add("[IsImportantTouSu]=1 and exists(select 1 from [ServiceType_ImportantService] where ServiceID=A.ID and ApproveStatus=1)");
            }
            if (IsImportantTouSu == 4)//审核未通过
            {
                conditions.Add("exists(select 1 from [ServiceType_ImportantService] where ServiceID=A.ID and ApproveStatus=2)");
            }
            if (PayStatus == 1)
            {
                conditions.Add("exists(select 1 from [CustomerServiceChuli] where [ServiceID]=A.ID and HandelFee>0)");
            }
            if (PayStatus == 2)
            {
                conditions.Add("(not exists(select 1 from [CustomerServiceChuli] where [ServiceID]=A.ID) or exists(select 1 from [CustomerServiceChuli] where [ServiceID]=A.ID and isnull(HandelFee,0)=0))");
            }
            #region 关键字查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                string[] keywords = Keywords.Trim().Split(' ');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  (isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  (isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and ((isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  (isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            int BaoXiuServiceID = new Utility.SiteConfig().BaoXiuServiceID;
            int LianJieTouSuServiceID = new Utility.SiteConfig().LianJieTouSuServiceID;
            int WuYeTouSuServiceID = new Utility.SiteConfig().WuYeTouSuServiceID;
            int YingXiaoTouSuServiceID = new Utility.SiteConfig().YingXiaoTouSuServiceID;
            if (ServiceType1ID > 0)
            {
                conditions.Add("ServiceType1ID=@ServiceType1ID");
                parameters.Add(new SqlParameter("@ServiceType1ID", ServiceType1ID));
            }
            if (CallBackStatus == 1)//已回访
            {
                conditions.Add("exists(select 1 from [CustomerServiceHuifang] where [ServiceID]=A.ID)");
            }
            if (CallBackStatus == 2)//未回访
            {
                conditions.Add("not exists(select 1 from [CustomerServiceHuifang] where [ServiceID]=A.ID)");
            }
            if (ServiceType == 2)
            {
                conditions.Add("ServiceType1ID!=" + BaoXiuServiceID);
            }
            else if (ServiceType == 1)
            {
                conditions.Add("ServiceType1ID=" + BaoXiuServiceID);
            }
            if (CallServiceType == 1 || IsRepairChaoShi)//报修
            {
                conditions.Add("ServiceType1ID=" + BaoXiuServiceID);
            }
            if (CallServiceType == 2 || IsTouSuChaoShi)//投诉
            {
                conditions.Add("ServiceType1ID in (" + LianJieTouSuServiceID + "," + WuYeTouSuServiceID + "," + YingXiaoTouSuServiceID + ")");
            }
            if (CloseType == 1)
            {
                conditions.Add("[IsClosed]=1");
            }
            if (CloseType == 2)
            {
                conditions.Add("isnull([IsClosed],0)=0");
            }
            if (UserID > 0 && ServiceStatus != 12 && !isServiceAnalysis)
            {
                cmdlist = new List<string>();
                if (!canViewAll || !canViewWechatAPPService || !canViewWechatAPPSuggestoin)
                {
                    cmdlist.Add("[AddUserID]=@UserID");
                    cmdlist.Add("exists(select 1 from [CustomerService_Accpet] where [ServiceID]=A.ID and AccpetManID=@UserID and AccpetStatus!=3)");
                    if (canViewWechatAPPService)
                    {
                        cmdlist.Add("(([ServiceFrom]=@ServiceFrom1 or [ServiceFrom]=@ServiceFrom2) and ((isnull(IsSuggestion,0)=0 and ServiceType1ID=0) or ServiceType1ID = " + BaoXiuServiceID + "))");
                    }
                    else
                    {
                        cmdlist.Add("([ServiceFrom]!=@ServiceFrom1 and [ServiceFrom]!=@ServiceFrom2 and (isnull(IsSuggestion,0)=0 or ServiceType1ID = " + BaoXiuServiceID + "))");
                    }
                    if (canViewWechatAPPSuggestoin)
                    {
                        cmdlist.Add("(([ServiceFrom]=@ServiceFrom1 or [ServiceFrom]=@ServiceFrom2) and ((isnull(IsSuggestion,0)=1 and ServiceType1ID=0) or ServiceType1ID in (" + LianJieTouSuServiceID + "," + WuYeTouSuServiceID + "," + YingXiaoTouSuServiceID + ")))");
                    }
                    else
                    {
                        cmdlist.Add("([ServiceFrom]!=@ServiceFrom1 and [ServiceFrom]!=@ServiceFrom2 and (isnull(IsSuggestion,0)=1 or ServiceType1ID in (" + LianJieTouSuServiceID + "," + WuYeTouSuServiceID + "," + YingXiaoTouSuServiceID + ")))");
                    }
                    if (canViewAll)
                    {
                        cmdlist.Add("([ServiceFrom]!=@ServiceFrom1 and [ServiceFrom]!=@ServiceFrom2)");
                    }
                }
                parameters.Add(new SqlParameter("@ServiceFrom1", Utility.EnumModel.WechatServiceFromDefine.weixin.ToString()));
                parameters.Add(new SqlParameter("@ServiceFrom2", Utility.EnumModel.WechatServiceFromDefine.app.ToString()));

                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            cmdlist = new List<string>();
            var myProjectIDList = new int[] { };
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[ProjectID] in (" + string.Join(",", RoomIDList) + ")");
            }
            else
            {
                myProjectIDList = Project.GetProjectIDListbyIDList(InProjectIDList: InProjectIDList, EqualProjectIDList: EqualProjectIDList);
                //if (myProjectIDList.Length > 0)
                //{
                //    cmdlist = ViewRoomFeeHistory.GetProjectIDListConditions(myProjectIDList.ToList(), RoomIDName: "[ProjectID]", UserID: UserID);
                //    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                //}
            }
            if (CompanyIDList != null && CompanyIDList.Length > 0)
            {
                conditions.Add("exists(select 1 from [Project] where A.ProjectID=Project.ID and [Project].CompanyID in (" + string.Join(",", CompanyIDList) + "))");
            }
            if (ServiceStatus == 12 && CallBackStatus == 1)
            {
                conditions.Add("isnull([ServiceFrom],'')!='app'");
                if (StartTime > DateTime.MinValue)
                {
                    conditions.Add("exists(select 1 from [CustomerServiceHuifang] where [ServiceID]=A.ID and  [HuiFangTime]>=@StartTime)");
                    parameters.Add(new SqlParameter("@StartTime", StartTime));
                }
                if (EndTime > DateTime.MinValue)
                {
                    EndTime = EndTime.AddDays(1);
                    conditions.Add("exists(select 1 from [CustomerServiceHuifang] where  [ServiceID]=A.ID and [HuiFangTime]<=@EndTime)");
                    parameters.Add(new SqlParameter("@EndTime", EndTime));
                }
            }
            else
            {
                if (StartTime > DateTime.MinValue)
                {
                    conditions.Add("[AddTime]>=@StartTime");
                    parameters.Add(new SqlParameter("@StartTime", StartTime));
                }
                if (EndTime > DateTime.MinValue)
                {
                    EndTime = EndTime.AddDays(1);
                    conditions.Add("[AddTime]<=@EndTime");
                    parameters.Add(new SqlParameter("@EndTime", EndTime));
                }
            }
            if (ServiceStatus > -1 && ServiceStatus != 101 && ServiceStatus != 13)
            {
                if (ServiceStatus == 4)
                {
                    conditions.Add("[IsClosed]=1");
                }
                else if (ServiceStatus == 250)
                {
                    conditions.Add("ServiceStatus not in (2,5)");
                }
                else if (ServiceStatus == 12)//回访管理
                {
                    cmdlist = new List<string>();
                    cmdlist.Add("([IsClosed]=1 and exists(select 1 from [ServiceType] where [CallBackServiceType]=1 and [ID]=A.ServiceType1ID))");
                    cmdlist.Add("([ServiceStatus]=1 and exists(select 1 from [ServiceType] where [CallBackServiceType]=2 and [ID]=A.ServiceType1ID))");
                    cmdlist.Add("(exists(select 1 from [ServiceType] where [CallBackServiceType]=3 and [ID]=A.ServiceType1ID))");
                    if (cmdlist.Count > 0)
                    {
                        conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                    }
                }
                else if (ServiceStatus == 11)//收费工单
                {
                    conditions.Add("exists(select 1 from [CustomerServiceChuli] where [ServiceID]=A.ID and [HandelFee]>0)");
                }
                else
                {
                    conditions.Add("[IsClosed]=0");
                    if (ServiceStatus == 100)
                    {
                        conditions.Add("[ServiceStatus] in (3,6,10)");
                    }

                    else if (ServiceStatus == 2)//工单销单
                    {
                        conditions.Add("[ServiceStatus] in (2,5)");
                    }
                    else if (ServiceStatus == 10)//待派单工单
                    {
                        conditions.Add("ServiceStatus in (3,10)");
                        conditions.Add("A.AccpetUserCount<=0");
                        //conditions.Add("exists(select 1 from [ServiceType] where [DisableSend]=0 and [ID]=A.ServiceType1ID)");
                    }
                    else if (ServiceStatus == 3)//待处理工单
                    {
                        //conditions.Add("exists(select 1 from [ServiceType] where [DisableSend]=0 and [ID]=A.ServiceType1ID)");
                        conditions.Add("ServiceStatus in (3,10)");
                        conditions.Add("A.AccpetUserCount>0");
                        conditions.Add("A.ProcessUserCount<=0");
                    }
                    else
                    {
                        conditions.Add("[ServiceStatus]=@ServiceStatus");
                    }
                }
                parameters.Add(new SqlParameter("@ServiceStatus", ServiceStatus));
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select count(1) from [CustomerService_Accpet] where [ServiceID]=ViewCustomerService.ID and AccpetUserType=1 and AccpetStatus in (0,1)) as AccpetUserCount,(select count(1) from [CustomerService_Accpet] where [ServiceID]=ViewCustomerService.ID and AccpetUserType=2 and AccpetStatus in (0,1)) as ProcessUserCount from [ViewCustomerService])A where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            ViewCustomerService[] list = new ViewCustomerService[] { };
            if (canexport || TimeOutType > 0 || ServiceStatus == 13 || ServiceType2ID > 0 || ServiceType3ID > 0 || myProjectIDList.Length > 0)
            {
                list = GetList<ViewCustomerService>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ViewCustomerService>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            if (myProjectIDList.Length > 0)
            {
                list = list.Where(p => myProjectIDList.Contains(p.ProjectID)).ToArray();
            }
            if (ServiceType2ID > 0)
            {
                list = list.Where(p => p.ServiceType2IDList.Contains(ServiceType2ID)).ToArray();
            }
            if (ServiceType3ID > 0)
            {
                list = list.Where(p => p.ServiceType3IDList.Contains(ServiceType3ID)).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            if (list.Length == 0)
            {
                dg.rows = list;
                dg.total = totalRows;
                dg.page = pageSize;
                return dg;
            }
            if (TimeOutType > 0 || ServiceStatus == 13)
            {
                GetFinalViewCustomerDataGrid(list, IncludeTimeOutData: true, IsDataGridView: true);
                if (TimeOutType > 0)//1-正常 2-超时
                {
                    list = list.Where(p => p.TimeOutStatus == TimeOutType).ToArray();
                }
                else if (ServiceStatus == 13)//超时工单
                {
                    if (BeforeBanJieTimeOutHour > 0)
                    {
                        list = list.Where(p => p.ServiceStatus != 2 && p.ServiceStatus != 5 && (p.BanJieChaoShiTakeHour + BeforeBanJieTimeOutHour) > 0 && p.BanJieChaoShiTakeHour < 0 && p.BanJieTime == DateTime.MinValue).ToArray();
                    }
                    else
                    {
                        list = list.Where(p => p.TimeOutStatus == 2).ToArray();
                    }
                }
                if (!canexport)
                {
                    totalRows = list.Length;
                    list = list.Skip((int)startRowIndex).Take(pageSize).ToArray();
                }
            }
            else
            {
                if (ServiceType2ID > 0 || ServiceType3ID > 0 || myProjectIDList.Length > 0)
                {
                    if (!canexport)
                    {
                        totalRows = list.Length;
                        list = list.Skip((int)startRowIndex).Take(pageSize).ToArray();
                    }
                }
                GetFinalViewCustomerDataGrid(list, IncludeTimeOutData: true, IsDataGridView: true);
            }
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GetCustomerServiceGridByServiceTypeID(DateTime StartTime, DateTime EndTime, string orderBy, long startRowIndex, int pageSize, int ServiceTypeID, int[] CompanyIDList, List<int> EqualProjectIDList, List<int> InProjectIDList, int UserID, int ServiceType2ID, int ServiceType3ID)
        {
            ResetCache();
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("(ServiceStatus=1 or isnull(IsClosed,0)=1)");
            conditions.Add("(IsImportantTouSu is null or IsImportantTouSu=0)");

            if (CompanyIDList.Length > 0)
            {
                conditions.Add("exists(select 1 from [Project] where A.ProjectID=Project.ID and [Project].CompanyID in (" + string.Join(",", CompanyIDList) + "))");
            }
            int BaoXiuServiceID = new Utility.SiteConfig().BaoXiuServiceID;
            int LianJieTouSuServiceID = new Utility.SiteConfig().LianJieTouSuServiceID;
            int WuYeTouSuServiceID = new Utility.SiteConfig().WuYeTouSuServiceID;
            int YingXiaoTouSuServiceID = new Utility.SiteConfig().YingXiaoTouSuServiceID;
            if (ServiceTypeID == 1)
            {
                conditions.Add("ServiceType1ID=" + YingXiaoTouSuServiceID);
            }
            if (ServiceTypeID == 2)
            {
                conditions.Add("ServiceType1ID=" + WuYeTouSuServiceID);
            }
            if (ServiceTypeID == 3)
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
                EndTime = EndTime.AddDays(1);
                conditions.Add("[AddTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select count(1) from [CustomerService_Accpet] where [ServiceID]=ViewCustomerService.ID and AccpetUserType=1 and AccpetStatus in (0,1)) as AccpetUserCount,(select count(1) from [CustomerService_Accpet] where [ServiceID]=ViewCustomerService.ID and AccpetUserType=2 and AccpetStatus in (0,1)) as ProcessUserCount from [ViewCustomerService])A where  " + string.Join(" and ", conditions.ToArray());
            ViewCustomerService[] list = new ViewCustomerService[] { };
            list = GetList<ViewCustomerService>("select " + fieldList + Statement + orderBy, parameters).ToArray();
            if (list.Length == 0)
            {
                return new Ui.DataGrid();
            }
            if (ServiceType2ID > 0)
            {
                list = list.Where(p => p.ServiceType2IDList.Contains(ServiceType2ID)).ToArray();
            }
            if (ServiceType3ID > 0)
            {
                list = list.Where(p => p.ServiceType3IDList.Contains(ServiceType3ID)).ToArray();
            }
            if (ServiceTypeID == 3 || ServiceTypeID == 4)
            {
                var BaoShiServiceIDList = new Utility.SiteConfig().BaoShiServiceIDList;
                if (BaoShiServiceIDList != null && BaoShiServiceIDList.Length > 0)
                {
                    if (ServiceTypeID == 3)//报修
                    {
                        list = list.Where(p =>
                        {
                            if (p.ServiceType2IDList == null || p.ServiceType2IDList.Length == 0)
                            {
                                return true;
                            }
                            var finalServiceType2IDList = p.ServiceType2IDList.Distinct().ToArray();
                            var resultList = finalServiceType2IDList.Except(BaoShiServiceIDList).ToArray();
                            return resultList.Length == p.ServiceType2IDList.Length;
                        }).ToArray();
                    }
                    if (ServiceTypeID == 4)//报事
                    {
                        list = list.Where(p =>
                        {
                            if (p.ServiceType2IDList == null || p.ServiceType2IDList.Length == 0)
                            {
                                return false;
                            }
                            var finalServiceType2IDList = p.ServiceType2IDList.Distinct().ToArray();
                            var resultList = finalServiceType2IDList.Except(BaoShiServiceIDList).ToArray();
                            return resultList.Length < finalServiceType2IDList.Length;
                        }).ToArray();
                    }
                }
            }
            var myProjectIDList = Project.GetProjectIDListbyIDList(InProjectIDList: InProjectIDList, EqualProjectIDList: EqualProjectIDList);
            if (myProjectIDList.Length > 0)
            {
                list = list.Where(p => myProjectIDList.Contains(p.ProjectID)).ToArray();
            }
            GetFinalViewCustomerDataGrid(list, IncludeTimeOutData: true, IsDataGridView: true);
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            if (list.Length == 0)
            {
                dg.rows = list;
                dg.total = totalRows;
                dg.page = pageSize;
                return dg;
            }
            totalRows = list.Length;

            var footerList = new List<ViewCustomerService>();
            var footerItem = new ViewCustomerService();
            footerItem.XiaDanTakeHour = list.Sum(p => p.XiaDanTakeHour);
            footerItem.ResponseTakeHour = list.Sum(p => p.ResponseTakeHour);
            footerItem.PaiDanTakeHour = list.Sum(p => p.PaiDanTakeHour);
            footerItem.ProcessTakeHour = list.Sum(p => p.ProcessTakeHour);
            footerItem.BanJieTakeHour = list.Sum(p => p.BanJieTakeHour);
            footerItem.CallBackTakeHour = list.Sum(p => p.CallBackTakeHour);
            footerList.Add(footerItem);
            list = list.Skip((int)startRowIndex).Take(pageSize).ToArray();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            dg.footer = footerList;
            return dg;
        }
        public static ViewCustomerService GetViewCustomerServiceByID(int ID)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ID]=@ID");
            parameters.Add(new SqlParameter("@ID", ID));
            string cmdText = "select * from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray());
            var data = GetOne<ViewCustomerService>(cmdText, parameters);
            if (data == null)
            {
                return null;
            }
            var list = new ViewCustomerService[] { data };
            GetFinalViewCustomerDataGrid(list);
            return list[0];
        }
        public static ViewCustomerService[] GetViewCustomerServiceByIDList(List<int> IDList)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (IDList.Count == 0)
            {
                return new ViewCustomerService[] { };
            }
            conditions.Add("[ID] in (" + string.Join(",", IDList.ToArray()) + ")");
            var list = GetList<ViewCustomerService>("select * from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            GetFinalViewCustomerDataGrid(list);
            return list;
        }
        public static ViewCustomerService[] GetViewCustomerServiceListByStatus(string Keywords, int status, int UserID, long startRowIndex, int pageSize, out long totalRows, DateTime StartTime, DateTime EndTime, List<int> ProjectIDList = null, bool cansendorder = false)
        {
            totalRows = 0;
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            string orderby = " order by [AddTime] desc";
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[AddTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                EndTime = EndTime.AddDays(1);
                conditions.Add("[AddTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            #region 关键字查询
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                string[] keywords = Keywords.Trim().Split(' ');
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (string.IsNullOrEmpty(keywords[i].ToString()))
                    {
                        continue;
                    }
                    if (i + 1 == keywords.Length)
                    {
                        if (keywords.Length == 1)
                        {
                            cmd += "  and  (isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%')";
                        }
                        else
                        {
                            cmd += "  (isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%'))";
                        }
                    }
                    else if (i == 0)
                    {
                        cmd += " and ((isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%') or";
                    }
                    else
                    {
                        cmd += "  (isnull([ServiceNumber],'') like '%" + keywords[i] + "%' or [AddCustomerName] like '%" + keywords[i] + "%' or [AddCallPhone] like '%" + keywords[i] + "%' or [ServiceFullName] like '%" + keywords[i] + "%' or [ServiceContent] like '%" + keywords[i] + "%') or ";
                    }
                }
            }
            #endregion
            var myProjectIDList = new int[] { };
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                myProjectIDList = Project.GetProjectIDListbyIDList(ProjectIDList: ProjectIDList, UserID: UserID);
            }
            parameters.Add(new SqlParameter("@UserID", UserID));
            if (status == 0)//处理中工单
            {
                conditions.Add("ServiceStatus=0");
                conditions.Add("exists(select 1 from [CustomerService_Accpet] where [ServiceID]=A.ID and [AccpetManID]=@UserID and AccpetUserType=2 and [AccpetStatus] in (0,1))");
            }
            else if (status == 1)//已办结工单
            {
                conditions.Add("(ServiceStatus=1 or [IsClosed]=1)");
                bool canViewAll = RoleModule.CheckIsInModule(UserID, "1191180");
                if (!canViewAll)
                {
                    conditions.Add("exists(select 1 from [CustomerService_Accpet] where [ServiceID]=A.ID and [AccpetManID]=@UserID and [AccpetStatus] in (0,1))");
                }
                orderby = " order by [BanJieTime] desc,[AddTime] desc";
            }
            else
            {
                bool canSend = RoleModule.CheckIsInModule(UserID, "1101172");
                if (!canSend)
                {
                    return new ViewCustomerService[] { };
                }
                conditions.Add("ServiceStatus in (3,10)");
                //conditions.Add("exists(select 1 from [ServiceType] where [DisableSend]=0 and [ID]=A.ServiceType1ID)");
                var cmdlist = new List<string>();
                cmdlist.Add("exists(select 1 from [CustomerService_Accpet] where [ServiceID]=A.ID and [AccpetManID]=@UserID and AccpetUserType=1 and [AccpetStatus] in (0,1))");
                var user = User.GetUser(UserID);
                if (!string.IsNullOrEmpty(user.PositionName) && (user.PositionName.Equals("内业") || user.PositionName.Equals("客服")))
                {
                    cmdlist.Add("[AddUserID]=@UserID");
                }
                bool canViewWechatAPPService = RoleModule.CheckIsInModule(UserID, "1191181");
                int BaoXiuServiceID = new Utility.SiteConfig().BaoXiuServiceID;
                if (canViewWechatAPPService)
                {
                    cmdlist.Add("(([ServiceFrom]=@ServiceFrom1 or [ServiceFrom]=@ServiceFrom2) and ((isnull(IsSuggestion,0)=0 and ServiceType1ID=0) or ServiceType1ID = " + BaoXiuServiceID + ") and A.AccpetUserCount<=0)");
                }
                else
                {
                    cmdlist.Add("(([ServiceFrom]!=@ServiceFrom1 and [ServiceFrom]!=@ServiceFrom2) and (isnull(IsSuggestion,0)=0 or ServiceType1ID = " + BaoXiuServiceID + ") and [AddUserID]=@UserID)");
                }
                bool canViewWechatAPPSuggestoin = RoleModule.CheckIsInModule(UserID, "1191182");
                int LianJieTouSuServiceID = new Utility.SiteConfig().LianJieTouSuServiceID;
                int WuYeTouSuServiceID = new Utility.SiteConfig().WuYeTouSuServiceID;
                int YingXiaoTouSuServiceID = new Utility.SiteConfig().YingXiaoTouSuServiceID;
                if (canViewWechatAPPSuggestoin)
                {
                    cmdlist.Add("(([ServiceFrom]=@ServiceFrom1 or [ServiceFrom]=@ServiceFrom2) and (isnull(IsSuggestion,0)=1 or ServiceType1ID in (" + LianJieTouSuServiceID + "," + WuYeTouSuServiceID + "," + YingXiaoTouSuServiceID + ")) and A.AccpetUserCount<0)");
                }
                else
                {
                    cmdlist.Add("(([ServiceFrom]!=@ServiceFrom1 and [ServiceFrom]!=@ServiceFrom2) and (isnull(IsSuggestion,0)=1 or ServiceType1ID in (" + LianJieTouSuServiceID + "," + WuYeTouSuServiceID + "," + YingXiaoTouSuServiceID + ")) and [AddUserID]=@UserID)");
                }
                //if (canViewWechatAPPSuggestoin)
                //{
                //    cmdlist.Add("(([ServiceFrom]=@ServiceFrom1 or [ServiceFrom]=@ServiceFrom2) and isnull(IsSuggestion,0)=1 and not exists(select 1 from [CustomerService_Accpet] where [ServiceID]=A.ID and AccpetUserType=1 and [AccpetStatus] in (0,1)))");
                //}
                parameters.Add(new SqlParameter("@ServiceFrom1", Utility.EnumModel.WechatServiceFromDefine.weixin.ToString()));
                parameters.Add(new SqlParameter("@ServiceFrom2", Utility.EnumModel.WechatServiceFromDefine.app.ToString()));
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select count(1) from [CustomerService_Accpet] where [ServiceID]=ViewCustomerService.ID and AccpetUserType=1 and AccpetStatus in (0,1)) as AccpetUserCount from [ViewCustomerService])A where " + string.Join(" and ", conditions.ToArray()) + cmd;
            //Utility.LogHelper.WriteDebug("GetViewCustomerServiceListByStatus", Statement);
            var list = GetList<ViewCustomerService>(fieldList, Statement, parameters, orderby, startRowIndex, pageSize, out totalRows).ToArray();
            if (myProjectIDList.Length > 0)
            {
                list = list.Where(p => myProjectIDList.Contains(p.ProjectID)).ToArray();
            }
            GetFinalViewCustomerDataGrid(list);
            return list;
        }
        public static int GetViewCustomerServiceCountByStatus(int UserID, int Status)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            var myProjectIDList = Project.GetProjectIDListbyIDList(UserID: UserID);
            List<string> cmdlist = new List<string>();
            if (Status == 10)//待派单
            {
                cmdlist = new List<string>();
                conditions.Add("exists(select 1 from [ServiceType] where [DisableSend]=0 and [ID]=[CustomerService].ServiceType1ID)");
                conditions.Add("ServiceStatus in (3,10)");
                cmdlist = new List<string>();
                cmdlist.Add("exists(select 1 from [CustomerService_Accpet] where [ServiceID]=[CustomerService].ID and [AccpetManID]=@UserID and AccpetUserType=1 and [AccpetStatus] in (0,1))");
                bool canViewWechatAPPService = RoleModule.CheckIsInModule(UserID, "1191181");
                if (canViewWechatAPPService)
                {
                    cmdlist.Add("(([ServiceFrom]=@ServiceFrom1 or [ServiceFrom]=@ServiceFrom2) and isnull(IsSuggestion,0)=0 and not exists(select 1 from [CustomerService_Accpet] where [ServiceID]=[CustomerService].ID and AccpetUserType=1 and [AccpetStatus] in (0,1)))");
                }
                bool canViewWechatAPPSuggestoin = RoleModule.CheckIsInModule(UserID, "1191182");
                if (canViewWechatAPPSuggestoin)
                {
                    cmdlist.Add("(([ServiceFrom]=@ServiceFrom1 or [ServiceFrom]=@ServiceFrom2) and isnull(IsSuggestion,0)=1 and not exists(select 1 from [CustomerService_Accpet] where [ServiceID]=[CustomerService].ID and AccpetUserType=1 and [AccpetStatus] in (0,1)))");
                }
                parameters.Add(new SqlParameter("@ServiceFrom1", Utility.EnumModel.WechatServiceFromDefine.weixin.ToString()));
                parameters.Add(new SqlParameter("@ServiceFrom2", Utility.EnumModel.WechatServiceFromDefine.app.ToString()));
                if (cmdlist.Count > 0)
                {
                    conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
                }
            }
            if (Status == 0)//处理中
            {
                conditions.Add("[ServiceStatus]=0");
                conditions.Add("exists(select 1 from [CustomerService_Accpet] where [ServiceID]=[CustomerService].ID and [AccpetManID]=@UserID and [AccpetUserType]=2 and [AccpetStatus] in (0,1))");
            }
            parameters.Add(new SqlParameter("@UserID", UserID));
            string cmdtext = "select ProjectID from [CustomerService] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<CustomerService>(cmdtext, parameters).ToArray();
            if (myProjectIDList.Length > 0)
            {
                list = list.Where(p => myProjectIDList.Contains(p.ProjectID)).ToArray();
            }
            return list.Length;
        }
        public static ViewCustomerService[] GetViewCustomerServiceByAddUserIDList(List<int> UserIDList)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (UserIDList.Count == 0)
            {
                return new ViewCustomerService[] { };
            }
            conditions.Add("[AddUserID] in (" + string.Join(",", UserIDList.ToArray()) + ")");
            var list = GetList<ViewCustomerService>("select * from [ViewCustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            GetFinalViewCustomerDataGrid(list);
            return list;
        }
        public static void GetFinalViewCustomerDataGrid(ViewCustomerService[] list, bool IncludeTimeOutData = false, bool IsDataGridView = false)
        {
            if (list.Length == 0)
            {
                return;
            }
            int MinServiceID = list.Min(p => p.ID);
            int MaxServiceID = list.Max(p => p.ID);
            var serviceTypeList = ServiceType.GetServiceTypes().ToArray();
            var userList = User.GetSysAPPUserList();
            var serviceAccpetList = CustomerService_Accpet.GetCustomerService_AccpetListByMinMaxServiceID(MinServiceID, MaxServiceID);
            var serviceProcessList = CustomerServiceChuli.GetCustomerServiceChuliListByMinMaxServiceID(MinServiceID, MaxServiceID, IsDataGridView: IsDataGridView);
            var serviceHuifangList = CustomerServiceHuifang.GetCustomerServiceHuifangListByMinMaxServiceID(MinServiceID, MaxServiceID);
            CustomerServiceChuli_Attach[] chuliAttachedList = new CustomerServiceChuli_Attach[] { };
            if (IsDataGridView && serviceProcessList.Length > 0)
            {
                int MinChuliID = serviceProcessList.Min(p => p.ID);
                int MaxChuliID = serviceProcessList.Max(p => p.ID);
                chuliAttachedList = CustomerServiceChuli_Attach.GetCustomerServiceChuli_AttachListByMinMaxChuliID(MinChuliID, MaxChuliID);
            }
            foreach (var item in list)
            {
                var myServiceType1 = serviceTypeList.FirstOrDefault(q => q.ID == item.ServiceType1ID);
                item.CategoryPartA = myServiceType1 != null ? myServiceType1.ServiceTypeName : string.Empty;
                var myServiceType2List = serviceTypeList.Where(q => item.ServiceType2IDList.Contains(q.ID)).ToArray();
                item.CategoryPartB = myServiceType2List.Length == 0 ? string.Empty : string.Join(",", myServiceType2List.Select(p => p.ServiceTypeName).ToArray());
                var myServiceType3List = serviceTypeList.Where(q => item.ServiceType3IDList.Contains(q.ID)).ToArray();
                item.CategoryPartC = myServiceType3List.Length == 0 ? string.Empty : string.Join(",", myServiceType3List.Select(p => p.ServiceTypeName).ToArray());

                item.DisableCallback = myServiceType1 != null ? myServiceType1.DisableCallback : false;
                item.DisableCompelte = myServiceType1 != null ? myServiceType1.DisableCompelte : false;
                item.DisableProcee = myServiceType1 != null ? myServiceType1.DisableProcee : false;
                item.DisableSend = myServiceType1 != null ? myServiceType1.DisableSend : false;
                item.DisableShenJi = myServiceType1 != null ? myServiceType1.DisableShenJi : false;
                item.CloseServiceType = myServiceType1 != null ? myServiceType1.CloseServiceType : 1;

                item.CallBackServiceType = myServiceType1 != null ? myServiceType1.CallBackServiceType : 1;
                item.BanJieServiceType = myServiceType1 != null ? myServiceType1.BanJieServiceType : 1;

                var myServiceAccpetUserList = serviceAccpetList.Where(q => q.ServiceID == item.ID && q.AccpetUserType == 1).ToArray();
                if (myServiceAccpetUserList.Length > 0)
                {
                    List<int> ServiceAccpetManIDList = myServiceAccpetUserList.Select(q => q.AccpetManID).ToList();
                    var users = userList.Where(p => ServiceAccpetManIDList.Contains(p.UserID)).ToArray();
                    if (users.Length > 0)
                    {
                        item.FinalServiceAccpetMan = string.Join(",", users.Select(p => p.FinalRealName).ToArray());
                        item.FinalServiceAccpetTime = myServiceAccpetUserList[0].AddTime;
                    }
                }
                var myServiceProcessUserList = serviceAccpetList.Where(q => q.ServiceID == item.ID && q.AccpetUserType == 2).ToArray();
                if (myServiceProcessUserList.Length > 0)
                {
                    List<int> ServiceProcessManIDList = myServiceProcessUserList.Select(q => q.AccpetManID).ToList();
                    var users = userList.Where(p => ServiceProcessManIDList.Contains(p.UserID)).ToArray();
                    if (users.Length > 0)
                    {
                        item.FinalServiceProcessMan = string.Join(",", users.Select(p => p.FinalRealName).ToArray());
                        item.FinalServiceProcessTime = myServiceProcessUserList[0].AddTime;
                    }
                    var myChuliAttachList = chuliAttachedList.Where(q => myServiceProcessUserList.Select(m => m.ID).Contains(q.ChuliID) && !string.IsNullOrEmpty(q.AttachedFilePath)).ToArray();
                    if (myChuliAttachList.Length > 0)
                    {
                        item.RepareImg = Utility.Tools.GetContextPath() + myChuliAttachList[0].AttachedFilePath;
                    }
                }
                if (string.IsNullOrEmpty(item.FinalServiceProcessMan) && !string.IsNullOrWhiteSpace(item.BanJieManName))
                {
                    item.FinalServiceProcessMan = item.BanJieManName;
                }
                if (item.FinalServiceProcessTime == DateTime.MinValue && item.BanJieTime > DateTime.MinValue)
                {
                    item.FinalServiceProcessTime = item.BanJieTime;
                }
                var myServiceHuiFangList = serviceHuifangList.Where(q => q.ServiceID == item.ID).ToArray();
                item.ServiceHuiFangCount = myServiceHuiFangList.Length;
                if (myServiceHuiFangList.FirstOrDefault(p => p.PhoneCallBackType == 1) != null)
                {
                    item.ManuallyPhoneCallBackType = 1;
                }
                else if (myServiceHuiFangList.FirstOrDefault(p => p.PhoneCallBackType == 2) != null)
                {
                    item.ManuallyPhoneCallBackType = 2;
                }
                else
                {
                    item.ManuallyPhoneCallBackType = 3;
                }
                item.HuiFangAddUserIDList = myServiceHuiFangList.Where(p => p.AddUserID > 0).Select(p => p.AddUserID).ToArray();
                var myHuiFangUserList = userList.Where(p => item.HuiFangAddUserIDList.Contains(p.UserID)).ToArray();
                if (myHuiFangUserList.Length > 0)
                {
                    item.HuiFangAddUserNames = string.Join(",", myHuiFangUserList.Select(p => p.FinalRealName).ToArray());
                }
                var myServiceProcessList = serviceProcessList.Where(q => q.ServiceID == item.ID).ToArray();
                if (myServiceProcessList.Length > 0)
                {
                    var myResponseProcessData = myServiceProcessList.FirstOrDefault(p => p.ResponseTime > DateTime.MinValue);
                    if (myResponseProcessData != null)
                    {
                        item.ResponseTime = myResponseProcessData.ResponseTime;
                    }
                    var myCheckData = myServiceProcessList.FirstOrDefault(p => p.CheckTime > DateTime.MinValue);
                    if (myCheckData != null)
                    {
                        item.CheckTime = myCheckData.CheckTime;
                    }
                    var myRepairData = myServiceProcessList.FirstOrDefault(p => !string.IsNullOrEmpty(p.RepartPartName));
                    if (myRepairData != null)
                    {
                        item.RepartPartName = myRepairData.RepartPartName;
                    }
                    var myChuLiData = myServiceProcessList.FirstOrDefault(p => p.ChuliDate > DateTime.MinValue);
                    if (myChuLiData != null)
                    {
                        item.ChuliDate = myChuLiData.ChuliDate;
                    }
                    var myChuLiNoteData = myServiceProcessList.FirstOrDefault(p => !string.IsNullOrEmpty(p.ChuliNote));
                    if (myChuLiNoteData != null)
                    {
                        item.ChuliNote = myChuLiNoteData.ChuliNote;
                    }
                    item.ChuLiHandelFee = myServiceProcessList.Sum(p => p.HandelFee);
                    item.FinalTotalFee = item.ChuLiHandelFee;
                }
                if (myServiceHuiFangList.Length > 0)
                {
                    var myHuiFangTimeData = myServiceHuiFangList.OrderBy(p => p.HuiFangTime).FirstOrDefault(p => p.HuiFangTime > DateTime.MinValue);
                    if (myHuiFangTimeData != null)
                    {
                        item.HuiFangTime = myHuiFangTimeData.HuiFangTime;
                    }
                    var myHuiFangNoteData = myServiceHuiFangList.FirstOrDefault(p => !string.IsNullOrEmpty(p.HuiFangNote));
                    if (myHuiFangNoteData != null)
                    {
                        item.HuiFangNote = myHuiFangNoteData.HuiFangNote;
                    }
                    //var myChuLiRateData = myServiceHuiFangList.FirstOrDefault(p => p.ChuLiRate > 0);
                    //if (myChuLiRateData != null)
                    //{
                    //    item.ChuLiRate = myChuLiRateData.ChuLiRate + "星";
                    //}
                    if (item.RelatedServiceID > 0)
                    {
                        item.FanXiuHandelFee = item.ChuLiHandelFee;
                        item.FanXiuTime = item.ChuliDate;
                        item.FanXiuContent = item.ChuliNote;
                    }
                }
            }
            if (IncludeTimeOutData)
            {
                GetTimeOutViewCustomerDataGrid(list, serviceTypeList: serviceTypeList, serviceAccpetList: serviceAccpetList, serviceHuifangList: serviceHuifangList, serviceProcessList: serviceProcessList);
            }
        }
        public static void GetTimeOutViewCustomerDataGrid(ViewCustomerService[] list, ServiceType[] serviceTypeList = null, CustomerService_Accpet[] serviceAccpetList = null, CustomerServiceHuifang[] serviceHuifangList = null, CustomerServiceChuli[] serviceProcessList = null)
        {
            if (list.Length == 0)
            {
                return;
            }
            int MinServiceID = 0;
            int MaxServiceID = 0;
            var list1 = list.Where(p => p.ServiceStatus == 1 && p.IsClosed).ToArray();
            var timeShiXiaoList = new CustomerService_TimeShiXiao[] { };
            var list2 = list;
            if (list1.Length > 0)
            {
                MinServiceID = list1.Min(p => p.ID);
                MaxServiceID = list1.Max(p => p.ID);
                timeShiXiaoList = CustomerService_TimeShiXiao.GetCustomerService_TimeShiXiaoByMinMaxID(MinServiceID, MaxServiceID);
            }
            var importantServiceType = ServiceType.GetImportServiceType();
            DateTime MinStartTime = list.Min(p => p.AddTime);
            DateTime MaxStartTime = list.Max(p => p.AddTime);
            var holidayList = HolidayLog.GetHolidayTypeList(MinStartTime, MaxStartTime);
            DateTime nowDate = DateTime.Now;
            MinServiceID = list.Min(p => p.ID);
            MaxServiceID = list.Max(p => p.ID);
            var importantList = ServiceType_ImportantService.GetServiceType_ImportantServiceListByMinMaxServiceID(MinServiceID, MaxServiceID).Where(p => p.ApproveStatus == 1).ToArray();
            if (serviceTypeList == null)
            {
                serviceTypeList = ServiceType.GetServiceTypes().ToArray();
            }
            if (serviceAccpetList == null)
            {
                serviceAccpetList = CustomerService_Accpet.GetCustomerService_AccpetListByMinMaxServiceID(MinServiceID, MaxServiceID);
            }
            if (serviceProcessList == null)
            {
                serviceProcessList = CustomerServiceChuli.GetCustomerServiceChuliListByMinMaxServiceID(MinServiceID, MaxServiceID);
            }
            if (serviceHuifangList == null)
            {
                serviceHuifangList = CustomerServiceHuifang.GetCustomerServiceHuifangListByMinMaxServiceID(MinServiceID, MaxServiceID);
            }
            var PinZhiShengJiServiceID = new Utility.SiteConfig().PinZhiShengJiServiceID;
            var sqlList = new List<string>();
            foreach (var item in list)
            {
                var myServiceType = serviceTypeList.FirstOrDefault(p => p.ID == item.ServiceType1ID);
                bool IsPinZhiShengJi = item.ServiceType2IDList.Contains(PinZhiShengJiServiceID);
                bool isImportant = false;
                if (item.IsImportantTouSu || IsPinZhiShengJi)
                {
                    var myImportant = importantList.FirstOrDefault(p => p.ServiceID == item.ID);
                    ServiceType.SetServiceTypeData(myServiceType, oldData: importantServiceType, importantData: myImportant);
                    isImportant = true;
                }
                var myServiceType2List = serviceTypeList.Where(p => item.ServiceType2IDList.Contains(p.ID)).ToArray();
                var myServiceType3List = serviceTypeList.Where(p => item.ServiceType3IDList.Contains(p.ID)).ToArray();
                decimal nowHourRange = 0;
                var myTimeItem = timeShiXiaoList.FirstOrDefault(p => p.ServiceID == item.ID);
                if (item.ServiceStatus == 1 && item.IsClosed && myTimeItem != null)
                {
                    CustomerService_TimeShiXiao.SetViewCustomerServiceData(item, myTimeItem);
                }
                else
                {
                    if (myServiceType == null)
                    {
                        continue;
                    }
                    decimal DelayTimeOutHour = new Utility.SiteConfig().DelayTimeOutHour;
                    DateTime addTime = item.AddTime;
                    item.XiaDanDate = DateTime.MinValue;
                    item.PaiDanDate = DateTime.MinValue;
                    item.ResponseTime = DateTime.MinValue;
                    item.CheckTime = DateTime.MinValue;
                    item.ChuliDate = DateTime.MinValue;
                    //DateTime banJieTime = DateTime.MinValue;
                    item.HuiFangTime = DateTime.MinValue;
                    //DateTime closeTime = DateTime.MinValue;
                    nowHourRange = 0;
                    #region 下单超时
                    var myServiceAccpetMan = serviceAccpetList.OrderBy(p => p.AddTime).FirstOrDefault(p => p.ServiceID == item.ID && p.AccpetUserType == 1);
                    var myXiaDanServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 1, IsPinZhiShengJi: isImportant);
                    if (myXiaDanServiceTypeItem == null)
                    {
                        continue;
                    }
                    if (myServiceAccpetMan != null)
                    {
                        item.XiaDanDate = myServiceAccpetMan.AddTime;
                    }
                    if (addTime == DateTime.MinValue)
                    {
                        item.XiaDanTakeHour = 0;
                        item.XiaDanTimeOutStatus = 1;
                    }
                    else
                    {
                        DateTime StartTime = addTime;
                        DateTime EndTime = item.XiaDanDate > DateTime.MinValue ? item.XiaDanDate : nowDate;
                        item.XiaDanChaoShiTakeHour = CheckDelayTimeStatus(myXiaDanServiceTypeItem, StartTime, EndTime, out nowHourRange, myXiaDanServiceTypeItem.PaiDanTime, holidayList: holidayList);
                        item.XiaDanTimeOutStatus = item.XiaDanChaoShiTakeHour <= 0 ? 1 : 2;
                        if (item.XiaDanDate == DateTime.MinValue)
                        {
                            item.XiaDanTakeHour = 0;
                        }
                        else
                        {
                            item.XiaDanTakeHour = nowHourRange;
                        }
                        if (myXiaDanServiceTypeItem.PaiDanTime <= 0)
                        {
                            item.XiaDanTimeOutStatus = 1;
                        }
                    }
                    #endregion
                    #region 派单超时
                    myServiceAccpetMan = serviceAccpetList.OrderBy(p => p.AddTime).FirstOrDefault(p => p.ServiceID == item.ID && p.AccpetUserType == 2);
                    var myPaiDanServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 1, IsPinZhiShengJi: IsPinZhiShengJi);
                    if (myPaiDanServiceTypeItem == null)
                    {
                        continue;
                    }
                    if (myServiceAccpetMan != null)
                    {
                        item.PaiDanDate = myServiceAccpetMan.AddTime;
                    }
                    if (addTime == DateTime.MinValue)
                    {
                        item.PaiDanTakeHour = 0;
                        item.PaiDanTimeOutStatus = 1;
                    }
                    else
                    {
                        DateTime StartTime = addTime;
                        DateTime EndTime = item.PaiDanDate > DateTime.MinValue ? item.PaiDanDate : nowDate;
                        item.PaiDanChaoShiTakeHour = CheckDelayTimeStatus(myPaiDanServiceTypeItem, StartTime, EndTime, out nowHourRange, myPaiDanServiceTypeItem.PaiDanTime, holidayList: holidayList);
                        item.PaiDanTimeOutStatus = item.PaiDanChaoShiTakeHour <= 0 ? 1 : 2;
                        if (item.PaiDanDate == DateTime.MinValue)
                        {
                            item.PaiDanTakeHour = 0;
                        }
                        else
                        {
                            item.PaiDanTakeHour = nowHourRange;
                        }
                        if (myPaiDanServiceTypeItem.PaiDanTime <= 0)
                        {
                            item.PaiDanTimeOutStatus = 1;
                        }
                    }
                    #endregion
                    #region 回复时效
                    var myResponseServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 2, IsPinZhiShengJi: IsPinZhiShengJi);
                    if (myResponseServiceTypeItem == null)
                    {
                        continue;
                    }
                    var myServiceResponse = serviceProcessList.Where(p => p.ServiceID == item.ID && p.ResponseTime > DateTime.MinValue).OrderBy(p => p.ResponseTime).FirstOrDefault();
                    if (myServiceResponse != null)
                    {
                        item.ResponseTime = myServiceResponse.ResponseTime;
                    }
                    if (item.PaiDanDate == DateTime.MinValue)
                    {
                        item.ResponseTakeHour = 0;
                        item.ResponseTimeOutStatus = 1;
                    }
                    else
                    {
                        DateTime StartTime = item.PaiDanDate;
                        DateTime EndTime = item.ResponseTime > DateTime.MinValue ? item.ResponseTime : nowDate;
                        item.ResponseChaoShiTakeHour = CheckDelayTimeStatus(myResponseServiceTypeItem, StartTime, EndTime, out nowHourRange, myResponseServiceTypeItem.ResponseTime, holidayList: holidayList);
                        item.ResponseTimeOutStatus = item.ResponseChaoShiTakeHour <= 0 ? 1 : 2;
                        if (item.ResponseTime == DateTime.MinValue)
                        {
                            item.ResponseTakeHour = 0;
                        }
                        else
                        {
                            item.ResponseTakeHour = nowHourRange;
                        }
                        if (myResponseServiceTypeItem.ResponseTime <= 0)
                        {
                            item.ResponseTimeOutStatus = 1;
                        }
                    }
                    #endregion
                    #region 核查时效
                    var myCheckServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 3, IsPinZhiShengJi: IsPinZhiShengJi);
                    if (myCheckServiceTypeItem == null)
                    {
                        continue;
                    }
                    var myServiceCheck = serviceProcessList.Where(p => p.ServiceID == item.ID && p.CheckTime > DateTime.MinValue).OrderBy(p => p.AddTime).FirstOrDefault();
                    if (myServiceCheck != null)
                    {
                        item.CheckTime = myServiceCheck.CheckTime;
                    }
                    if (item.PaiDanDate == DateTime.MinValue)
                    {
                        item.CheckTakeHour = 0;
                        item.CheckTimeOutStatus = 1;
                    }
                    else
                    {
                        DateTime StartTime = item.PaiDanDate;
                        DateTime EndTime = item.CheckTime > DateTime.MinValue ? item.CheckTime : nowDate;
                        item.CheckChaoShiTakeHour = CheckDelayTimeStatus(myCheckServiceTypeItem, StartTime, EndTime, out nowHourRange, myCheckServiceTypeItem.CheckTime, holidayList: holidayList);
                        item.CheckTimeOutStatus = item.CheckChaoShiTakeHour <= 0 ? 1 : 2;
                        if (item.CheckTime == DateTime.MinValue)
                        {
                            item.CheckTakeHour = 0;
                        }
                        else
                        {
                            item.CheckTakeHour = nowHourRange;
                        }
                        if (myCheckServiceTypeItem.CheckTime <= 0)
                        {
                            item.CheckTimeOutStatus = 1;
                        }
                    }
                    #endregion
                    #region 处理超时
                    var myProcessServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 4, IsPinZhiShengJi: IsPinZhiShengJi);
                    if (myProcessServiceTypeItem == null)
                    {
                        continue;
                    }
                    var myServiceProcess = serviceProcessList.Where(p => p.ServiceID == item.ID && p.ChuliDate > DateTime.MinValue).OrderBy(p => p.AddTime).FirstOrDefault();
                    if (myServiceProcess != null)
                    {
                        item.ChuliDate = myServiceProcess.ChuliDate;
                    }
                    else if (item.BanJieTime > DateTime.MinValue)
                    {
                        item.ChuliDate = item.BanJieTime;
                    }
                    if (item.PaiDanDate == DateTime.MinValue)
                    {
                        item.ProcessTakeHour = 0;
                        item.ProcessTimeOutStatus = 1;
                    }
                    else
                    {
                        DateTime StartTime = item.PaiDanDate;
                        DateTime EndTime = item.ChuliDate > DateTime.MinValue ? item.ChuliDate : nowDate;
                        item.ProcessChaoShiTakeHour = CheckDelayTimeStatus(myProcessServiceTypeItem, StartTime, EndTime, out nowHourRange, myProcessServiceTypeItem.ChuliTime, holidayList: holidayList);
                        item.ProcessTimeOutStatus = item.ProcessChaoShiTakeHour <= 0 ? 1 : 2;
                        if (item.ChuliDate == DateTime.MinValue)
                        {
                            item.ProcessTakeHour = 0;
                        }
                        else
                        {
                            item.ProcessTakeHour = nowHourRange;
                        }
                        if (myProcessServiceTypeItem.ChuliTime <= 0)
                        {
                            item.ProcessTimeOutStatus = 1;
                        }
                    }
                    #endregion
                    #region 办结超时
                    var myBanJieServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 5, IsPinZhiShengJi: IsPinZhiShengJi);
                    if (myBanJieServiceTypeItem == null)
                    {
                        continue;
                    }
                    if (item.AddTime == DateTime.MinValue)
                    {
                        item.BanJieTakeHour = 0;
                        item.BanJieTimeOutStatus = 1;
                    }
                    else
                    {
                        DateTime StartTime = item.AddTime;
                        DateTime EndTime = item.BanJieTime > DateTime.MinValue ? item.BanJieTime : nowDate;
                        item.BanJieChaoShiTakeHour = CheckDelayTimeStatus(myBanJieServiceTypeItem, StartTime, EndTime, out nowHourRange, myBanJieServiceTypeItem.BanJieTime, holidayList: holidayList);
                        item.BanJieTimeOutStatus = item.BanJieChaoShiTakeHour <= 0 ? 1 : 2;
                        if (item.BanJieTime == DateTime.MinValue)
                        {
                            item.BanJieTakeHour = 0;
                        }
                        else
                        {
                            item.BanJieTakeHour = nowHourRange;
                        }
                        if (myBanJieServiceTypeItem.BanJieTime <= 0)
                        {
                            item.BanJieTimeOutStatus = 1;
                        }
                    }
                    #endregion
                    #region 关单超时
                    var myGuanDanServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 7, IsPinZhiShengJi: IsPinZhiShengJi);
                    if (myGuanDanServiceTypeItem == null)
                    {
                        continue;
                    }
                    if (item.BanJieTime == DateTime.MinValue)
                    {
                        item.CloseTakeHour = 0;
                        item.CloseTimeOutStatus = 1;
                    }
                    else
                    {
                        DateTime StartTime = item.BanJieTime;
                        DateTime EndTime = item.CloseTime > DateTime.MinValue ? item.CloseTime : nowDate;
                        item.CloseChaoShiTakeHour = CheckDelayTimeStatus(myGuanDanServiceTypeItem, StartTime, EndTime, out nowHourRange, myGuanDanServiceTypeItem.GuanDanTime, holidayList: holidayList);
                        item.CloseTimeOutStatus = item.CloseChaoShiTakeHour <= 0 ? 1 : 2;
                        if (item.CloseTime == DateTime.MinValue)
                        {
                            item.CloseTakeHour = 0;
                        }
                        else
                        {
                            item.CloseTakeHour = nowHourRange;
                        }
                        if (myGuanDanServiceTypeItem.GuanDanTime <= 0)
                        {
                            item.CloseTimeOutStatus = 1;
                        }
                    }
                    CustomerService_TimeShiXiao.SetTimeShiXiaoData(item, myTimeItem, sqlList);
                    #endregion
                }
                #region 回访超时
                var myHuiFangServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 6, IsPinZhiShengJi: IsPinZhiShengJi);
                if (myHuiFangServiceTypeItem == null)
                {
                    continue;
                }
                var myServiceHuifang = serviceHuifangList.Where(p => p.ServiceID == item.ID).OrderBy(p => p.AddTime).FirstOrDefault();
                if (myServiceHuifang != null)
                {
                    item.HuiFangTime = myServiceHuifang.AddTime;
                }
                if (item.BanJieTime == DateTime.MinValue)
                {
                    item.CallBackTakeHour = 0;
                    item.CallBackTimeOutStatus = 1;
                }
                else
                {
                    DateTime StartTime = item.BanJieTime;
                    DateTime EndTime = item.HuiFangTime > DateTime.MinValue ? item.HuiFangTime : nowDate;
                    item.CallBackChaoShiTakeHour = CheckDelayTimeStatus(myHuiFangServiceTypeItem, StartTime, EndTime, out nowHourRange, myHuiFangServiceTypeItem.HuiFangTime, holidayList: holidayList);
                    item.CallBackTimeOutStatus = item.CallBackChaoShiTakeHour <= 0 ? 1 : 2;
                    if (item.HuiFangTime == DateTime.MinValue)
                    {
                        item.CallBackTakeHour = 0;
                    }
                    else
                    {
                        item.CallBackTakeHour = nowHourRange;
                    }
                    if (myHuiFangServiceTypeItem.HuiFangTime <= 0)
                    {
                        item.CallBackTimeOutStatus = 1;
                    }
                }
                #endregion
            }
            CustomerService_TimeShiXiao.UpdateTimeShiXiaoData(sqlList);
        }
        public static decimal CheckDelayTimeStatus(ServiceType myServiceType, DateTime StartTime, DateTime EndTime, out decimal nowHourRange, decimal DefineTimeHour, HolidayLog[] holidayList = null)
        {
            nowHourRange = HolidayLog.GetTimeHourRange(StartTime, EndTime, myServiceType.DisableHolidayTime, myServiceType.DisableWorkOffTime, myServiceType.StartHour, myServiceType.EndHour, holidayList: holidayList);
            if (DefineTimeHour <= 0)
            {
                return 0;
            }
            return nowHourRange - DefineTimeHour;
        }
        public string HuiFangAddUserNames { get; set; }
        public int[] HuiFangAddUserIDList { get; set; } = new int[] { };
        public decimal CheckTakeHour { get; set; }
        public decimal CheckChaoShiTakeHour { get; set; }
        public decimal FinalCheckChaoShiTakeHour
        {
            get
            {
                return this.CheckChaoShiTakeHour > 0 ? this.CheckChaoShiTakeHour : 0;
            }
        }
        public decimal ResponseTakeHour { get; set; }
        public decimal ResponseChaoShiTakeHour { get; set; }
        public decimal FinalResponseChaoShiTakeHour
        {
            get
            {
                return this.ResponseChaoShiTakeHour > 0 ? this.ResponseChaoShiTakeHour : 0;
            }
        }
        public decimal XiaDanTakeHour { get; set; }
        public decimal XiaDanChaoShiTakeHour { get; set; }
        public decimal FinalXiaDanChaoShiTakeHour
        {
            get
            {
                return this.XiaDanChaoShiTakeHour > 0 ? this.XiaDanChaoShiTakeHour : 0;
            }
        }
        public decimal PaiDanTakeHour { get; set; }
        public decimal PaiDanChaoShiTakeHour { get; set; }
        public decimal FinalPaiDanChaoShiTakeHour
        {
            get
            {
                return this.PaiDanChaoShiTakeHour > 0 ? this.PaiDanChaoShiTakeHour : 0;
            }
        }
        public decimal ProcessTakeHour { get; set; }
        public decimal ProcessChaoShiTakeHour { get; set; }
        public decimal FinalProcessChaoShiTakeHour
        {
            get
            {
                return this.ProcessChaoShiTakeHour > 0 ? this.ProcessChaoShiTakeHour : 0;
            }
        }
        public decimal BanJieTakeHour { get; set; }
        public decimal BanJieChaoShiTakeHour { get; set; }
        public decimal FinalBanJieChaoShiTakeHour
        {
            get
            {
                return this.BanJieChaoShiTakeHour > 0 ? this.BanJieChaoShiTakeHour : 0;
            }
        }
        public decimal CallBackTakeHour { get; set; }
        public decimal CallBackChaoShiTakeHour { get; set; }
        public decimal FinalCallBackChaoShiTakeHour
        {
            get
            {
                return this.CallBackChaoShiTakeHour > 0 ? this.CallBackChaoShiTakeHour : 0;
            }
        }
        public decimal CloseTakeHour { get; set; }
        public decimal CloseChaoShiTakeHour { get; set; }
        public decimal FinalCloseChaoShiTakeHour
        {
            get
            {
                return this.CloseChaoShiTakeHour > 0 ? this.CloseChaoShiTakeHour : 0;
            }
        }
        public decimal TotalChaoShiTakeHour
        {
            get
            {
                return this.FinalCheckChaoShiTakeHour + this.FinalResponseChaoShiTakeHour + this.FinalPaiDanChaoShiTakeHour + this.FinalProcessChaoShiTakeHour + this.FinalBanJieChaoShiTakeHour + this.FinalCallBackChaoShiTakeHour + this.FinalCloseChaoShiTakeHour + this.FinalXiaDanChaoShiTakeHour;
            }
        }
        public string ChaoShiStatusNames
        {
            get
            {
                string desc = string.Empty;
                if (this.PaiDanTimeOutStatus == 2)
                {
                    desc += "派单|";
                }
                if (this.ResponseTimeOutStatus == 2)
                {
                    desc += "回复|";
                }
                if (this.CheckTimeOutStatus == 2)
                {
                    desc += "核查|";
                }
                if (this.ProcessTimeOutStatus == 2)
                {
                    desc += "处理|";
                }
                if (this.BanJieTimeOutStatus == 2)
                {
                    desc += "办结|";
                }
                if (this.CallBackTimeOutStatus == 2)
                {
                    desc += "回访|";
                }
                if (this.CloseTimeOutStatus == 2)
                {
                    desc += "关单|";
                }
                if (!string.IsNullOrEmpty(desc))
                {
                    desc = desc.Substring(0, desc.Length - 1);
                }
                return desc;
            }
        }
        public decimal FinalTotalFee { get; set; }
        public DateTime FanXiuTime { get; set; }
        public decimal FanXiuHandelFee { get; set; }
        public string FanXiuContent { get; set; }
        public string ChuLiRate
        {
            get
            {
                if (this.HuiFangRate > 0)
                {
                    return this.HuiFangRate.ToString("0") + "星";
                }
                return string.Empty;
            }
        }
        public string HuiFangNote { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime XiaDanDate { get; set; }
        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime PaiDanDate { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime ChuliDate { get; set; }
        /// <summary>
        /// 回访时间
        /// </summary>
        public DateTime HuiFangTime { get; set; }
        public decimal ChuLiHandelFee { get; set; }
        public string ChuliNote { get; set; }
        public string RepartPartName { get; set; }
        public DateTime CheckTime { get; set; }
        public DateTime ResponseTime { get; set; }
        public int ServiceHuiFangCount { get; set; }
        public string ServiceStatusDesc
        {
            get
            {
                if (this.IsClosed)
                {
                    return "已关单";
                }
                if (this.ServiceStatus == int.MinValue)
                {
                    return "处理中";
                }
                string desc = string.Empty;
                switch (this.ServiceStatus)
                {
                    case 0:
                        desc = "处理中";
                        break;
                    case 1:
                        desc = "已办结";
                        break;
                    case 2:
                        desc = "已销单";
                        break;
                    case 10:
                        if (this.AccpetUserCount <= 0)
                        {
                            desc = "待分配接单人";
                        }
                        else
                        {
                            desc = "待分配处理人";
                        }
                        break;
                    case 3:
                        if (this.AccpetUserCount <= 0)
                        {
                            desc = "待分配接单人";
                        }
                        else
                        {
                            desc = "待分配处理人";
                        }
                        break;
                    case 4:
                        desc = "已关单";
                        break;
                    case 5:
                        desc = "重新开单";
                        break;
                    case 6:
                        desc = "待接单";
                        break;
                    case 100:
                        desc = "";
                        break;
                    default:
                        desc = "待接单";
                        break;
                }
                return desc;
            }
        }
        public string IsInvalidCallDesc
        {
            get
            {
                return this.IsInvalidCall ? "是" : "否";
            }
        }
        public string ServiceFromDesc
        {
            get
            {
                if (this.ServiceFullName.Equals("合计"))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceFromDefine), this.ServiceFrom);
            }
        }
        public string CategoryPartA { get; set; }
        public string CategoryPartB { get; set; }
        public string CategoryPartC { get; set; }
        public string ServiceTypeName
        {
            get
            {
                List<string> desc = new List<string>();
                if (!string.IsNullOrEmpty(CategoryPartA))
                {
                    desc.Add(CategoryPartA);
                }
                if (!string.IsNullOrEmpty(CategoryPartB))
                {
                    desc.Add(CategoryPartB);
                }
                if (!string.IsNullOrEmpty(CategoryPartC))
                {
                    desc.Add(CategoryPartC);
                }
                if (desc.Count > 0)
                {
                    return string.Join("-", desc.ToArray());
                }
                return string.Empty;
            }
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
        public bool DisableSend { get; set; }
        public bool DisableProcee { get; set; }
        public bool DisableCompelte { get; set; }
        public bool DisableCallback { get; set; }
        public bool DisableShenJi { get; set; }
        /// <summary>
        /// 1-办结后关单 2-回访后关单 3-审计确认后关单 4-无限制关单
        /// </summary>
        public int CloseServiceType { get; set; }
        /// <summary>
        /// 1-关单后回访 2-办结后回访 3-任何时候都可回访
        /// </summary>
        public int CallBackServiceType { get; set; }
        /// <summary>
        /// 1-处理后办结 2-任何时候都可办结
        /// </summary>
        public int BanJieServiceType { get; set; }
        public bool CanReSend
        {
            get
            {
                if (this.ServiceStatus == 1 || this.ServiceStatus == 2 || this.ServiceStatus == 4)
                {
                    return false;
                }
                return true;
            }
        }
        public bool CanDeal
        {
            get
            {
                if (this.ServiceStatus == 1 || this.ServiceStatus == 2 || this.ServiceStatus == 4)
                {
                    return false;
                }
                return true;
            }
        }
        public bool CanComplete
        {
            get
            {
                if (this.ServiceStatus == 1 || this.ServiceStatus == 2 || this.ServiceStatus == 4)
                {
                    return false;
                }
                return true;
            }
        }
        public bool CanCallBack
        {
            get
            {
                if (this.ServiceStatus == 1)
                {
                    return true;
                }
                return false;
            }
        }
        public int[] ServiceType2IDList
        {
            get
            {
                if (string.IsNullOrEmpty(this.ServiceType2ID))
                {
                    return new int[] { };
                }
                this.ServiceType2ID = this.ServiceType2ID.Replace("[", "").Replace("]", "");
                if (string.IsNullOrEmpty(this.ServiceType2ID))
                {
                    return new int[] { };
                }
                this.ServiceType2ID = "[" + this.ServiceType2ID + "]";
                string[] ServiceTypeIDArray = Utility.JsonConvert.DeserializeObject<string[]>(this.ServiceType2ID);
                List<int> IDList = new List<int>();
                foreach (var ServiceTypeIDStr in ServiceTypeIDArray)
                {
                    int ServiceTypeID = 0;
                    int.TryParse(ServiceTypeIDStr, out ServiceTypeID);
                    if (ServiceTypeID > 0)
                    {
                        IDList.Add(ServiceTypeID);
                    }
                }
                return IDList.ToArray();
            }
        }
        public int[] ServiceType3IDList
        {
            get
            {
                if (string.IsNullOrEmpty(this.ServiceType3ID))
                {
                    return new int[] { };
                }
                this.ServiceType3ID = this.ServiceType3ID.Replace("[", "").Replace("]", "");
                if (string.IsNullOrEmpty(this.ServiceType3ID))
                {
                    return new int[] { };
                }
                this.ServiceType3ID = "[" + this.ServiceType3ID + "]";
                string[] ServiceTypeIDArray = Utility.JsonConvert.DeserializeObject<string[]>(this.ServiceType3ID);
                List<int> IDList = new List<int>();
                foreach (var ServiceTypeIDStr in ServiceTypeIDArray)
                {
                    int ServiceTypeID = 0;
                    int.TryParse(ServiceTypeIDStr, out ServiceTypeID);
                    if (ServiceTypeID > 0)
                    {
                        IDList.Add(ServiceTypeID);
                    }
                }
                return IDList.ToArray();
            }
        }
        /// <summary>
        /// 1-接单 2-处理 3-办结 4-回访
        /// </summary>
        public int ProcessStatus
        {
            get
            {
                if (this.ServiceHuiFangCount > 0)
                {
                    return 4;
                }
                if (this.ServiceStatus == 1)
                {
                    return 3;
                }
                if (this.ProcessUserCount > 0)
                {
                    return 2;
                }
                return 1;
            }
        }
        /// <summary>
        /// 超时状态 1-正常 2-超时
        /// </summary>
        public int TimeOutStatus
        {
            get
            {
                if (this.PaiDanTimeOutStatus == 2 || this.ProcessTimeOutStatus == 2 || this.BanJieTimeOutStatus == 2 || this.CallBackTimeOutStatus == 2 || this.CloseTimeOutStatus == 2 || ResponseTimeOutStatus == 2 || this.CheckTimeOutStatus == 2)
                {
                    return 2;
                }
                return 1;
            }
        }
        /// <summary>
        /// 下单超时状态 1-正常 2-超时
        /// </summary>
        public int XiaDanTimeOutStatus { get; set; }
        /// <summary>
        /// 派单超时状态 1-正常 2-超时
        /// </summary>
        public int PaiDanTimeOutStatus { get; set; }
        /// <summary>
        /// 处理超时状态 1-正常 2-超时
        /// </summary>
        public int ProcessTimeOutStatus { get; set; }
        /// <summary>
        /// 办结超时状态 1-正常 2-超时
        /// </summary>
        public int BanJieTimeOutStatus { get; set; }
        /// <summary>
        /// 回访超时状态 1-正常 2-超时
        /// </summary>
        public int CallBackTimeOutStatus { get; set; }
        /// <summary>
        /// 关单超时状态 1-正常 2-超时
        /// </summary>
        public int CloseTimeOutStatus { get; set; }
        /// <summary>
        /// 回复超时状态 1-正常 2-超时
        /// </summary>
        public int ResponseTimeOutStatus { get; set; }
        /// <summary>
        /// 核查超时状态 1-正常 2-超时
        /// </summary>
        public int CheckTimeOutStatus { get; set; }
        public string ImportantDesc
        {
            get
            {
                if (this.IsImportantTouSu)
                {
                    return "重大投诉";
                }
                return string.Empty;
            }
        }
        public string CanNotCallbackDesc
        {
            get
            {
                return this.CanNotCallback ? "暂不回访" : "";
            }
        }
        /// <summary>
        /// 1-电话接通 2-电话未接通 3-未拨打
        /// </summary>
        public int ManuallyPhoneCallBackType { get; set; }
        public string RepareImg { get; set; }
        public string IsInWeiBaoDesc
        {
            get
            {
                return this.IsInWeiBao ? "是" : "否";
            }
        }
        public string IsHighTouSuDesc
        {
            get
            {
                return this.IsHighTouSu ? "是" : "否";
            }
        }
    }
}
