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
    /// This object represents the properties and methods of a CustomerService.
    /// </summary>
    public partial class CustomerService : EntityBase
    {
        public static Dictionary<int, string> ServiceAccpetManList = new Dictionary<int, string>();
        public static void ResetCache()
        {
            ServiceAccpetManList = new Dictionary<int, string>();
        }
        public static CustomerService GetLastCustomerService(int OrderNumberID)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            //conditions.Add("ChargeTime is not null");
            conditions.Add("[AddTime]>=@AddTime");
            conditions.Add("isnull([OrderNumberID],0)=@OrderNumberID");
            parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));
            DateTime start = DateTime.Today.AddDays(1 - DateTime.Now.Day);
            parameters.Add(new SqlParameter("@AddTime", start));
            return GetOne<CustomerService>("select top 1 * from [CustomerService] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters);
        }
        public static string GetLastestCustomerServiceNumber(string OrderTypeName, int RoomID, out int OrderNumberID)
        {
            ResetCache();
            if (string.IsNullOrEmpty(OrderTypeName))
            {
                OrderTypeName = Foresight.DataAccess.OrderTypeNameDefine.customerservice.ToString();
            }
            Sys_OrderNumber sysOrderNumber = Sys_OrderNumber.GetSys_OrderNumberByRoomID(OrderTypeName, RoomID);
            if (sysOrderNumber == null)
            {
                OrderNumberID = 0;
                return string.Empty;
            }
            OrderNumberID = sysOrderNumber.ID;
            CustomerService service = CustomerService.GetLastCustomerService(OrderNumberID);
            string Part1 = string.Empty;
            Part1 += sysOrderNumber.OrderPrefix;
            string time_yyyy = DateTime.Now.ToString("yyyy");
            string time_mm = DateTime.Now.ToString("MM");
            string time_dd = DateTime.Now.ToString("dd");
            if (sysOrderNumber.UseYear)
            {
                Part1 += time_yyyy;
            }
            if (sysOrderNumber.UseMonth)
            {
                Part1 += time_mm;
            }
            if (sysOrderNumber.UseDay)
            {
                Part1 += time_dd;
            }
            int OrderNumberCount = sysOrderNumber.OrderNumberCount <= 0 ? 3 : sysOrderNumber.OrderNumberCount;
            int number = 1;
            if (service != null && !string.IsNullOrEmpty(service.ServiceNumber))
            {
                number = GetOrderNumberBySysOrder(service.ServiceNumber, sysOrderNumber, out OrderNumberCount);
            }
            return Part1 + number.ToString("D" + OrderNumberCount);
        }
        public static int GetOrderNumberBySysOrder(string history_printnumber, Sys_OrderNumber sysOrderNumber, out int OrderNumberCount)
        {
            int number = 1;
            string time_yyyy = DateTime.Now.ToString("yyyy");
            string time_mm = DateTime.Now.ToString("MM");
            string time_dd = DateTime.Now.ToString("dd");
            OrderNumberCount = sysOrderNumber.OrderNumberCount <= 0 ? 3 : sysOrderNumber.OrderNumberCount;
            int use_count_dd = 0;
            int use_count_mm = 0;
            int use_count_yy = 0;
            if (sysOrderNumber.UseDay)
            {
                use_count_dd = 2;
            }
            if (sysOrderNumber.UseMonth)
            {
                use_count_mm = 2 + use_count_dd;
            }
            if (sysOrderNumber.UseYear)
            {
                use_count_yy = 4 + use_count_mm;
            }
            if (history_printnumber.Length >= OrderNumberCount + use_count_yy)
            {
                string printNumber = history_printnumber.Substring((history_printnumber.Length - OrderNumberCount), OrderNumberCount);
                int _printnumber = 0;
                int.TryParse(printNumber, out _printnumber);
                int new_number = _printnumber + 1;
                if (new_number.ToString().Length > OrderNumberCount)
                {
                    new_number = 1;
                }
                if (sysOrderNumber.IsDayReset && sysOrderNumber.UseDay)
                {
                    string printnumber_dd = history_printnumber.Substring((history_printnumber.Length - OrderNumberCount - use_count_dd), 2);
                    if (printnumber_dd == time_dd)
                    {
                        number = new_number;
                    }
                }
                else if (sysOrderNumber.IsMonthReset && sysOrderNumber.UseMonth)
                {
                    string printnumber_mm = history_printnumber.Substring((history_printnumber.Length - OrderNumberCount - use_count_mm), 2);
                    if (printnumber_mm == time_mm)
                    {
                        number = new_number;
                    }
                }
                else if (sysOrderNumber.IsYearReset && sysOrderNumber.UseYear)
                {
                    string printnumber_year = history_printnumber.Substring((history_printnumber.Length - OrderNumberCount - use_count_yy), 4);
                    if (printnumber_year == time_yyyy)
                    {
                        number = new_number;
                    }
                }
                else
                {
                    number = new_number;
                }
            }
            return number;
        }
        public static CustomerService[] GetCustomerServiceListByParams(int[] TaskTypeList = null)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (TaskTypeList != null && TaskTypeList.Length > 0)
            {
                conditions.Add("[TaskType] in (" + string.Join(",", TaskTypeList) + ")");
            }
            return GetList<CustomerService>("select * from [CustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static CustomerService GetExistCustomerServiceByServiceNumber(int ID, string ServiceNumber)
        {
            ResetCache();
            if (string.IsNullOrEmpty(ServiceNumber))
            {
                return null;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (ID > 0)
            {
                conditions.Add("[ID]!=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            if (!string.IsNullOrEmpty(ServiceNumber))
            {
                conditions.Add("[ServiceNumber]=@ServiceNumber");
                parameters.Add(new SqlParameter("@ServiceNumber", ServiceNumber));
            }
            return GetOne<CustomerService>("select top 1 * from [CustomerService] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters);
        }
        public static CustomerService[] GetCustomerServiceListByRoomIDList(List<int> RoomIDList, List<int> ProjectIDList, int UserID = 0, int Status = 0)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomIDList.Count > 0)
            {
                List<string> cmdlist = ViewRoomFeeHistory.GetRoomIDListConditions(RoomIDList, RoomIDName: "[ProjectID]");
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            if (Status == 100)
            {
                conditions.Add("[ServiceStatus] in (3,10)");
            }
            var list = GetList<CustomerService>("select * from [CustomerService] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            var myProjectIDList = new int[] { };
            if (ProjectIDList.Count > 0)
            {
                myProjectIDList = Project.GetProjectIDListbyIDList(ProjectIDList: ProjectIDList, UserID: UserID);
            }
            if (myProjectIDList.Length > 0)
            {
                list = list.Where(p => myProjectIDList.Contains(p.ProjectID)).ToArray();
            }
            return list;
        }
        public static CustomerService[] GetCustomerServiceListByEqualProjectID(List<int> RoomIDList, int ServiceStatus, out int TotalCount, int UserID = 0, List<int> EqualProjectIDList = null, List<int> InProjectIDList = null, bool GetCount = false)
        {
            TotalCount = 0;
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<string> cmdlist = new List<string>();
            conditions.Add("1=1");
            var myProjectIDList = new int[] { };
            if (RoomIDList.Count > 0)
            {
                conditions.Add("[ProjectID] in (" + string.Join(",", RoomIDList) + ")");
            }
            else
            {
                myProjectIDList = Project.GetProjectIDListbyIDList(InProjectIDList: InProjectIDList, EqualProjectIDList: EqualProjectIDList);
            }
            if (ServiceStatus > -1)
            {
                if (ServiceStatus == 100)
                {
                    conditions.Add("[ServiceStatus] in (3,10)");
                }
                else
                {
                    conditions.Add("[ServiceStatus]=@ServiceStatus");
                }
                parameters.Add(new SqlParameter("@ServiceStatus", ServiceStatus));
            }
            if (GetCount)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    var result = helper.ExecuteScalar("select count(1) from [CustomerService] where  " + string.Join(" and ", conditions.ToArray()), CommandType.Text, parameters);
                    if (result != null)
                    {
                        int.TryParse(result.ToString(), out TotalCount);
                    }
                }
                return new CustomerService[] { };
            }
            string cmdtext = "select * from [CustomerService] where  " + string.Join(" and ", conditions.ToArray());
            CustomerService[] list = GetList<CustomerService>(cmdtext, parameters).ToArray();
            if (myProjectIDList.Length > 0)
            {
                list = list.Where(p => myProjectIDList.Contains(p.ProjectID)).ToArray();
            }
            return list;
        }
        public static bool ReOpenCustomerService(int ServiceID, string AddUserName, int UserID, out string error)
        {
            error = string.Empty;
            var data = CustomerService.GetCustomerService(ServiceID);
            if (data == null)
            {
                error = "工单无效";
                return false;
            }
            if (data.ServiceStatus == 2)
            {
                error = "选中的任务已销单";
                return false;
            }
            if (data.ServiceStatus == 5)
            {
                error = "选中的任务已重新开单";
                return false;
            }
            data.ServiceStatus = 5;
            data.Save();
            var newData = new CustomerService();
            newData.ProjectID = data.ProjectID;
            newData.ServiceFullName = data.ServiceFullName;
            newData.ProjectName = data.ProjectName;
            newData.AddUserName = AddUserName;
            newData.StartTime = data.StartTime;
            newData.ServiceArea = data.ServiceArea;
            newData.ServiceNumber = data.ServiceNumber + "_1";
            newData.AddCustomerName = data.AddCustomerName;
            newData.AddCallPhone = data.AddCallPhone;
            newData.ServiceContent = data.ServiceContent;
            newData.AddTime = DateTime.Now;
            newData.ServiceStatus = 3;
            newData.TaskType = data.TaskType;
            newData.AddMan = data.AddMan;
            newData.OrderNumberID = data.OrderNumberID;
            newData.AddUserID = UserID;
            newData.DepartmentID = data.DepartmentID;
            newData.ServiceType1ID = data.ServiceType1ID;
            newData.ServiceType2ID = data.ServiceType2ID;
            newData.ServiceType3ID = data.ServiceType3ID;
            newData.RelatedServiceID = data.ID;
            newData.Save();
            return true;
        }
        public static int GetCustomerServiceCount(List<int> ServiceTypeIDList)
        {
            if (ServiceTypeIDList.Count == 0)
            {
                return 0;
            }
            var conditions = new List<string>();
            conditions.Add("ServiceTypeID in (" + string.Join(",", ServiceTypeIDList.ToArray()) + ")");
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var result = helper.ExecuteScalar("select count(1) from [CustomerService] where " + string.Join(" and ", conditions.ToArray()), CommandType.Text, new List<SqlParameter>());
                if (result != null)
                {
                    int.TryParse(result.ToString(), out count);
                }
            }
            return count;
        }
        public static bool CheckCanCloseService(List<int> IDList, out string error)
        {
            error = string.Empty;
            var list = ViewCustomerService.GetViewCustomerServiceByIDList(IDList);
            if (list.Length == 0)
            {
                error = "请选择工单";
                return false;
            }
            var sServiceIDList = list.Select(p => p.ID).ToList();
            //var callBackList = CustomerServiceHuifang.GetCustomerServiceHuifangListByServiceIDList(sServiceIDList);
            int MinServiceID = list.Min(p => p.ID);
            int MaxServiceID = list.Max(p => p.ID);
            var recordList = PhoneRecord.GetPhoneRecordDetailByServiceIDList(MinServiceID, MaxServiceID);
            foreach (var item in list)
            {
                if (item.IsClosed)
                {
                    error = "工单已关单，不能重复关单";
                    return false;
                }
                if (item.CloseServiceType == 1 || item.IsImportantTouSu)
                {
                    if (item.ServiceStatus != 1)
                    {
                        error = "工单未办结，不能关单";
                        return false;
                    }
                    return true;
                }
                if (item.CloseServiceType == 2)
                {
                    var myRecordList = recordList.Where(p => p.ServiceID == item.ID && p.PhoneType == 2).ToArray();
                    //var myItemList = callBackList.Where(p => p.ServiceID == item.ID).ToArray();
                    if (myRecordList.Length == 0)
                    {
                        error = "投诉类工单未回访，不能关单";
                        return false;
                    }
                    if (myRecordList.Length == 1 && myRecordList[0].PickUpTime == DateTime.MinValue)
                    {
                        error = "投诉类工单仅回访一次且未接电话，不能关单";
                        return false;
                    }
                    return true;
                }
                if (item.CloseServiceType == 3)
                {
                    if (item.ConfirmStatus != 1)
                    {
                        error = "廉洁举报类工单未审计确认，不能关单";
                        return false;
                    }
                    return true;
                }
                if (item.CloseServiceType == 4)
                {
                    return true;
                }
            }
            return true;
        }
        public static bool CheckCanCompleteService(List<int> IDList, out string error)
        {
            error = string.Empty;
            var list = ViewCustomerService.GetViewCustomerServiceByIDList(IDList);
            if (list.Length == 0)
            {
                error = "请选择工单";
                return false;
            }
            var sServiceIDList = list.Select(p => p.ID).ToList();
            var chuliList = CustomerServiceChuli.GetCustomerServiceChuliListByServiceIDList(sServiceIDList);
            foreach (var item in list)
            {
                if (item.ServiceStatus == 1)
                {
                    error = "工单已办结，不能重复办结";
                    return false;
                }
                if (item.BanJieServiceType == 1)
                {
                    var myItemList = chuliList.Where(p => p.ServiceID == item.ID).ToArray();
                    if (myItemList.Length == 0)
                    {
                        error = "工单未处理，不能关单";
                        return false;
                    }
                    return true;
                }
                if (item.BanJieServiceType == 2)
                {
                    return true;
                }
            }
            return true;
        }
        public static bool CheckCanCallbackService(List<int> IDList, out string error)
        {
            error = string.Empty;
            var list = ViewCustomerService.GetViewCustomerServiceByIDList(IDList);
            if (list.Length == 0)
            {
                error = "请选择工单";
                return false;
            }
            foreach (var item in list)
            {
                if (item.CallBackServiceType == 1)
                {
                    if (!item.IsClosed)
                    {
                        error = "工单未关单，不能回访";
                        return false;
                    }
                    return true;
                }
                if (item.CallBackServiceType == 2)
                {
                    if (item.ServiceStatus != 1)
                    {
                        error = "工单未办结，不能回访";
                        return false;
                    }
                    return true;
                }
                if (item.BanJieServiceType == 3)
                {
                    return true;
                }
            }
            return true;
        }
        public static Dictionary<string, object> GetCustomerServiceDataByProjectID(int ProjectID)
        {
            Dictionary<string, object> dic = null;
            CustomerService data = null;
            CustomerService[] dataList = new CustomerService[] { };
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProjectID", ProjectID));
            dataList = GetList<CustomerService>("select * from [CustomerService] where ProjectID=@ProjectID", parameters).ToArray();
            if (dataList.Length > 0)
            {
                data = dataList.FirstOrDefault(p => p.ServiceStatus == 0 || p.ServiceStatus == 3 || p.ServiceStatus == 10);
            }
            if (data == null)
            {
                return dic;
            }
            dic = new Dictionary<string, object>();
            dic["GongDanType"] = "";
            if (data.ServiceType1ID > 0)
            {
                var type = ServiceType.GetServiceType(data.ServiceType1ID);
                dic["GongDanType"] = type != null ? type.ServiceTypeName : string.Empty;
            }
            dic["GongDanAddTime"] = data.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
            dic["GongDanStatusDesc"] = data.ServiceStatusDesc;
            dic["GongDanRemark"] = "";
            var chuLiList = CustomerServiceChuli.GetCustomerServiceChuliList(data.ID);
            if (chuLiList.Length > 0)
            {
                var chuLiData = chuLiList.FirstOrDefault(p => !string.IsNullOrEmpty(p.ChuliNote));
                dic["GongDanRemark"] = chuLiData != null ? chuLiData.ChuliNote : "";
            }
            dic["GongDanContent"] = data.ServiceContent;
            var dataGongDanList = dataList.Where(p => !p.IsSuggestion).ToArray();
            var dataTouSuList = dataList.Where(p => p.IsSuggestion).ToArray();
            dic["HisotryGongDanCount"] = dataGongDanList.Length;
            dic["HisotryTouSuCount"] = dataTouSuList.Length;
            return dic;
        }
        public static int GetCustomerServiceCountByStatus(int UserID, int Status, int Type = 0)
        {
            ResetCache();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            var myProjectIDList = Project.GetProjectIDListbyIDList(UserID: UserID);
            int AccpetStatus = 0;
            if (Status == 10)//待派单
            {
                AccpetStatus = 0;
                conditions.Add("[ServiceStatus]=10");
            }
            if (Status == 0)//处理中
            {
                AccpetStatus = 1;
                conditions.Add("[ServiceStatus]=0");
            }
            if (Status == 1)//已办结
            {
                AccpetStatus = 1;
                conditions.Add("[ServiceStatus]=1");
            }
            if (Type > 0)
            {
                conditions.Add("exists(select 1 from [CustomerService_Accpet] where [AccpetManID]=@UserID and [AccpetUserType]=2 and [AccpetStatus]=@AccpetStatus)");
                parameters.Add(new SqlParameter("@AccpetStatus", AccpetStatus));
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            int count = 0;
            string cmdtext = "select [ProjectID] from [CustomerService] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<CustomerService>(cmdtext, parameters).ToArray();
            if (myProjectIDList.Length > 0)
            {
                list = list.Where(p => myProjectIDList.Contains(p.ProjectID)).ToArray();
            }
            return list.Length;
        }
        public static bool CheckIsMyService(int ServiceID, int UserID)
        {
            if (UserID <= 0)
            {
                return false;
            }
            var data = CustomerService.GetCustomerService(ServiceID);
            if (data == null)
            {
                return false;
            }
            List<int> ProjectIDList = new List<int>();
            ProjectIDList.Add(data.ProjectID);

            var myProjectIDList = Project.GetProjectIDListbyIDList(ProjectIDList: ProjectIDList, UserID: UserID);
            RoleModule roleModule1 = null;
            RoleModule roleModule2 = null;
            List<string> conditions = new List<string>();
            var cmdlist = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            using (SqlHelper helper = new SqlHelper())
            {
                parameters.Add(new SqlParameter("@UserID", UserID));
                //查看微信APP报修派单
                roleModule1 = GetOne<RoleModule>("select ID from [RoleModule] where ModuleId=181 and [UserID]=@UserID or [RoleID] in (select RoleID from [UserRoles] where [UserID]=@UserID)", parameters, helper);
                //查看微信APP投诉派单
                roleModule2 = GetOne<RoleModule>("select ID from [RoleModule] where ModuleId=182 and [UserID]=@UserID or [RoleID] in (select RoleID from [UserRoles] where [UserID]=@UserID)", parameters, helper);
            }
            if (roleModule1 == null && roleModule2 == null)
            {
                return false;
            }
            if (roleModule1 != null)
            {
                cmdlist.Add("isnull(IsSuggestion,0)=0");
            }
            if (roleModule2 != null)
            {
                cmdlist.Add("isnull(IsSuggestion,0)=1");
            }
            if (cmdlist.Count > 0)
            {
                conditions.Add("(" + string.Join(" or ", cmdlist.ToArray()) + ")");
            }
            //项目权限
            conditions.Add("([ServiceFrom]=@ServiceFrom1 or [ServiceFrom]=@ServiceFrom2)");
            conditions.Add("[ID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            parameters.Add(new SqlParameter("@ServiceFrom1", Utility.EnumModel.WechatServiceFromDefine.weixin.ToString()));
            parameters.Add(new SqlParameter("@ServiceFrom2", Utility.EnumModel.WechatServiceFromDefine.app.ToString()));
            string cmdtext = "select [ProjectID] from [CustomerService] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<CustomerService>(cmdtext, parameters).ToArray();
            if (myProjectIDList.Length > 0)
            {
                list = list.Where(p => myProjectIDList.Contains(p.ProjectID)).ToArray();
            }
            return list.Length > 0;
        }
        public static string GetCustomerServicNumbersByIDList(List<int> IDList)
        {
            if (IDList.Count == 0)
            {
                return string.Empty;
            }
            var list = GetList<CustomerService>("select ServiceNumber from [CustomerService] where ID in (" + string.Join(",", IDList.ToArray()) + ")", new List<SqlParameter>()).ToArray();
            if (list.Length > 0)
            {
                return string.Join(",", list.Select(p => p.ServiceNumber).ToArray());
            }
            return string.Empty;
        }
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
                        desc = "待派单";
                        break;
                    case 3:
                        desc = "待处理";
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
        public string ServiceFromDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.ServiceFrom))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceFromDefine), this.ServiceFrom);
            }
        }
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
    }
    public partial class CustomerServiceDetail : CustomerService
    {
        [DatabaseColumn("CompanyID")]
        public int CompanyID { get; set; }
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        [DatabaseColumn("TotalHandleFee")]
        public decimal TotalHandleFee { get; set; }
        public static List<Dictionary<string, object>> GetCustomerServiceCountGroupByProjectStatus(int UserID, int Status)
        {
            ResetCache();
            var results = new List<Dictionary<string, object>>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            List<int> EqualIDList = new List<int>();
            List<int> InIDList = new List<int>();
            var ProjectList = Project.GetXiaoQuProjectListBySystemUserID(UserID);
            conditions.Add("[ServiceStatus]=@Status");
            parameters.Add(new SqlParameter("@Status", Status));
            string cmdtext = "select *,(select AllParentID from [Project] where ID=[CustomerService].ProjectID) as AllParentID from [CustomerService] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<CustomerServiceDetail>(cmdtext, parameters).ToArray();
            var my_list = new CustomerServiceDetail[] { };
            var dic = new Dictionary<string, object>();
            foreach (var project in ProjectList)
            {
                my_list = list.Where(p => !string.IsNullOrEmpty(p.AllParentID) && p.AllParentID.Contains("," + project.ID.ToString() + ",")).ToArray();
                dic = new Dictionary<string, object>();
                dic["ProjectID"] = project.ID;
                dic["ProjectName"] = project.Name;
                dic["TotalCount"] = my_list.Length;
                results.Add(dic);
            }
            results = results.OrderByDescending(p => Convert.ToInt32(p["TotalCount"])).ToList();
            return results;
        }
        public static List<Dictionary<string, object>> GetCustomerServiceCountGroupByUserStatus(int UserID, int Status, int ProjectID)
        {
            ResetCache();
            var results = new List<Dictionary<string, object>>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            var ProjectIDList = new List<int>() { ProjectID };
            var myProjectIDList = Project.GetProjectIDListbyIDList(ProjectIDList: ProjectIDList, UserID: UserID);
            conditions.Add("[ServiceStatus]=@Status");
            parameters.Add(new SqlParameter("@Status", Status));
            string cmdtext = "select [ID],[ProjectID] from [CustomerService] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<CustomerServiceDetail>(cmdtext, parameters).ToArray();
            if (myProjectIDList.Length > 0)
            {
                list = list.Where(p => myProjectIDList.Contains(p.ProjectID)).ToArray();
            }
            if (list.Length == 0)
            {
                return new List<Dictionary<string, object>>();
            }
            int MinServiceID = list.Min(p => p.ID);
            int MaxServiceID = list.Max(p => p.ID);
            var UserList = User.GetAPPUserList();
            CustomerServiceDetail[] my_list = new CustomerServiceDetail[] { };
            var dic = new Dictionary<string, object>();
            var UserIDList = UserList.Select(p => p.UserID).ToList();
            var serviceAccpetList = CustomerService_Accpet.GetCustomerService_AccpetListByMinMaxServiceID(MinServiceID, MaxServiceID);
            foreach (var user in UserList)
            {
                var myAccpetList = serviceAccpetList.Where(p => p.AccpetManID == user.UserID && p.AccpetStatus == 1).ToArray();
                //conditions.Add("REPLACE(REPLACE([ServiceAccpetManID],'[',','),']',',') like '%," + UserID.ToString() + ",%'");
                my_list = list.Where(p => myAccpetList.Select(q => q.ServiceID).Contains(p.ID)).ToArray();
                if (my_list.Length > 0)
                {
                    dic = new Dictionary<string, object>();
                    dic["UserID"] = user.UserID;
                    dic["UserName"] = user.FinalRealName;
                    dic["TotalCount"] = my_list.Length;
                    results.Add(dic);
                }
            }
            my_list = list.Where(p =>
            {
                var myAccpetList = serviceAccpetList.Where(q => q.ServiceID == p.ID).ToArray();
                var myUserList = UserList.Where(q => myAccpetList.Select(m => m.AccpetManID).Contains(q.UserID)).ToArray();
                if (myUserList.Length == 0)
                {
                    return true;
                }
                return false;
            }).ToArray();
            if (my_list.Length > 0)
            {
                dic = new Dictionary<string, object>();
                dic["UserID"] = -1;
                dic["UserName"] = "匿名用户";
                dic["TotalCount"] = my_list.Length;
                results.Add(dic);
            }
            results = results.OrderByDescending(p => Convert.ToInt32(p["TotalCount"])).ToList();
            return results;
        }
    }
    public partial class CustomerServiceStatic : EntityBaseReadOnly
    {
        [DatabaseColumn("ID")]
        public int ID { get; set; }
        [DatabaseColumn("TotalCount")]
        public int TotalCount { get; set; }
        [DatabaseColumn("jiedandengji_count")]
        public int jiedandengji_count { get; set; }
        [DatabaseColumn("chulizhong_count")]
        public int chulizhong_count { get; set; }
        [DatabaseColumn("yiwancheng_count")]
        public int yiwancheng_count { get; set; }
        [DatabaseColumn("yihuifang_count")]
        public int yihuifang_count { get; set; }
        protected override void EnsureParentProperties()
        {
        }
        public static CustomerServiceStatic[] GetCustomerServiceStaticCountByServiceType(DateTime StartTime, DateTime EndTime, int ProjectID = 0, int UserID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[StartTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[StartTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (ProjectID > 0)
            {
                conditions.Add("[ProjectID] in (select ID from Project where AllParentID like '%," + ProjectID + ",%')");
            }
            if (UserID > 0)
            {
                conditions.Add("exists(select 1 from [CustomerService_Accpet] where [AccpetManID]=@UserID and ServiceID=[CustomerService].ID)");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            return GetList<CustomerServiceStatic>("select A.*,B.yiwancheng_count,C.jiedandengji_count,D.chulizhong_count,E.yihuifang_count from (select Count(1) as TotalCount,ServiceTypeID as ID from CustomerService where " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)A left join (select Count(1) as yiwancheng_count,ServiceTypeID as ID from CustomerService where [ServiceStatus]=1 and " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)B on B.ID=A.ID left join (select Count(1) as jiedandengji_count,ServiceTypeID as ID from CustomerService where [ServiceStatus] in (10,3) and " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)C on C.ID=A.ID left join (select Count(1) as chulizhong_count,ServiceTypeID as ID from CustomerService where [ServiceStatus] in (0) and " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)D on D.ID=A.ID left join (select Count(1) as yihuifang_count,ServiceTypeID as ID from CustomerService where exists(select count(1) from [CustomerServiceHuifang] where ServiceID=[CustomerService].ID) and " + string.Join(" and ", conditions.ToArray()) + " group by ServiceTypeID)E on E.ID=A.ID", parameters).ToArray();
        }
        public static CustomerServiceStatic[] GetCustomerServiceStaticCountByTaskType(int ProjectID, DateTime StartTime, DateTime EndTime)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[StartTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[StartTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (ProjectID > 0)
            {
                conditions.Add("[ProjectID] in (select ID from Project where AllParentID like '%," + ProjectID + ",%')");
            }
            return GetList<CustomerServiceStatic>("select A.*,B.yiwancheng_count,C.jiedandengji_count,D.chulizhong_count,E.yihuifang_count from (select Count(1) as TotalCount,TaskType as ID from CustomerService where " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)A left join (select Count(1) as yiwancheng_count,TaskType as ID from CustomerService where [ServiceStatus]=1 and " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)B on B.ID=A.ID left join (select Count(1) as jiedandengji_count,TaskType as ID from CustomerService where [ServiceStatus] in (10,3) and " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)C on C.ID=A.ID left join (select Count(1) as chulizhong_count,TaskType as ID from CustomerService where [ServiceStatus] in (0) and " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)D on D.ID=A.ID left join (select Count(1) as yihuifang_count,TaskType as ID from CustomerService where exists(select count(1) from [CustomerServiceHuifang] where ServiceID=[CustomerService].ID) and " + string.Join(" and ", conditions.ToArray()) + " group by TaskType)E on E.ID=A.ID", parameters).ToArray();
        }
    }
}
