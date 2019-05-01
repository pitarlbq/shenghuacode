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
    /// This object represents the properties and methods of a PhoneRecord.
    /// </summary>
    public partial class PhoneRecord : EntityBase
    {
        public string PhoneTypeDesc
        {
            get
            {
                if (this.PhoneType == 1)
                {
                    return "来电";
                }
                if (this.PhoneType == 2)
                {
                    return "去电";
                }
                return "未知";
            }
        }
        public string IsPickUpDesc
        {
            get
            {
                return this.PickUpTime > DateTime.MinValue ? "是" : "否";
            }
        }
        public string FullRecordPath { get; set; }
        public static Ui.DataGrid GetPhoneRecordGridByKeywords(DateTime StartTime, DateTime EndTime, int ServiceID, string orderBy, long startRowIndex, int pageSize, int PhoneType)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([FileOriName],'')!=''");
            string cmd = string.Empty;
            if (PhoneType > 0)
            {
                conditions.Add("[PhoneType]=@PhoneType");
                parameters.Add(new SqlParameter("@PhoneType", PhoneType));
            }
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[CallTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[CallTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (ServiceID > 0)
            {
                conditions.Add("ServiceID=@ServiceID");
                parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            }
            string fieldList = "A.*";
            string Statement = " from (select [PhoneRecord].*,CustomerService.ServiceNumber,(select count(1) from [PhoneRecord] as PR where PR.[RelatedPhoneRecordID]=[PhoneRecord].ID) as CallbackCount from [PhoneRecord] left join [CustomerService] on [CustomerService].ID=[PhoneRecord].ServiceID)A where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            PhoneRecordDetail[] list = new PhoneRecordDetail[] { };
            list = GetList<PhoneRecordDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            string contextPath = Utility.Tools.GetContextPath();
            foreach (var item in list)
            {
                item.FullRecordPath = contextPath + item.RecordVoicePath;
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static PhoneRecord GetPhoneRecordByFileName(string FileName)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@FileName", FileName));
            return GetOne<PhoneRecord>("select * from [PhoneRecord] where FileOriName=@FileName", parameters);
        }
        public static PhoneRecord[] GetPhoneRecorByServiceID(int ServiceID, int PhoneType)
        {
            string cmdtext = "select * from [PhoneRecord] where [ServiceID]=@ServiceID and PhoneType=@PhoneType";
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            parameters.Add(new SqlParameter("@PhoneType", PhoneType));
            return GetList<PhoneRecordDetail>(cmdtext, parameters).ToArray();
        }
        public static void GetPhoneRecordCountAnalysis(out int NormalSeatCount)
        {
            NormalSeatCount = 0;
        }
        public static PhoneRecordDetail[] GetPhoneRecordDetailByUserIDList(List<int> UserIDList)
        {
            if (UserIDList.Count == 0)
            {
                return new PhoneRecordDetail[] { };
            }
            string cmdtext = "select * from (select *,(select [AddUserID] from [CustomerService] where [ID]=[PhoneRecord].[ServiceID] and PhoneType=2) as AddUserID from [PhoneRecord])A where [AddUserID] in (" + string.Join(",", UserIDList.ToArray()) + ")";
            return GetList<PhoneRecordDetail>(cmdtext, new List<SqlParameter>()).ToArray();
        }
        public static PhoneRecordDetail[] GetPhoneRecordDetailByServiceIDList(int MinServerID, int MaxServerID)
        {
            string cmdtext = "select * from [PhoneRecord] where [ServiceID] between " + MinServerID + " and " + MaxServerID;
            return GetList<PhoneRecordDetail>(cmdtext, new List<SqlParameter>()).ToArray();
        }

        public static void GetHomeDataCount(int UserID, out int NormalSeatCount, out int InvalidSeatCount, out int ServiceCount, out int SuggestionCount, out int TotalInCallCount, out int TotalOutCallCount, out decimal TotalInCallMin, out decimal TotalOutCallMin)
        {
            NormalSeatCount = 0;
            InvalidSeatCount = 0;
            ServiceCount = 0;
            SuggestionCount = 0;
            TotalInCallCount = 0;
            TotalOutCallCount = 0;
            TotalInCallMin = 0;
            TotalOutCallMin = 0;
            string cmdtext = "select [PickUpTime],[HangUpTime],[PhoneType] from [PhoneRecord]";
            var recordList = GetList<PhoneRecord>(cmdtext, new List<SqlParameter>()).ToArray();
            using (SqlHelper helper = new SqlHelper())
            {
                var parameters = new List<SqlParameter>();
                cmdtext = "select count(1) from [Seat] where [DriverStatus]=1";
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out NormalSeatCount);
                }
                cmdtext = "select count(1) from [Seat] where [DriverStatus]=2";
                result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out InvalidSeatCount);
                }
                cmdtext = "select count(1) from [CustomerService] where [IsSuggestion]=0";
                result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out ServiceCount);
                }
                cmdtext = "select count(1) from [CustomerService] where [IsSuggestion]=1";
                result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out SuggestionCount);
                }
                var totalInRecordList = recordList.Where(p => p.PhoneType == 1).ToArray();
                TotalInCallCount = totalInRecordList.Length;
                TotalInCallMin = totalInRecordList.Sum(p => p.TotalCallHour);
                TotalInCallMin = Math.Round(TotalInCallMin, 2, MidpointRounding.AwayFromZero);

                var totalOutnRecordList = recordList.Where(p => p.PhoneType == 2).ToArray();
                TotalOutCallCount = totalOutnRecordList.Length;
                TotalOutCallMin = totalOutnRecordList.Sum(p => p.TotalCallHour);
                TotalOutCallMin = Math.Round(TotalOutCallMin, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal TotalCallHour
        {
            get
            {
                if (this.PickUpTime == DateTime.MinValue || this.HangUpTime == DateTime.MinValue)
                {
                    return 0;
                }
                if (this.PickUpTime.AddSeconds(5) > this.HangUpTime && this.PhoneType == 2)
                {
                    return 0;
                }
                var timeSpan = this.HangUpTime - this.PickUpTime;
                //return (decimal)timeSpan.TotalSeconds / 3600;
                return (decimal)timeSpan.TotalSeconds;
            }
        }
        public DateTime FinalPickUpTime
        {
            get
            {
                if (this.TotalCallHour <= 0)
                {
                    return DateTime.MinValue;
                }
                return this.PickUpTime;
            }
        }
    }
    public partial class PhoneRecordDetail : PhoneRecord
    {
        [DatabaseColumn("ServiceNumber")]
        public string ServiceNumber { get; set; }
        [DatabaseColumn("CallbackCount")]
        public int CallbackCount { get; set; }
        [DatabaseColumn("AddUserID")]
        public int AddUserID { get; set; }
    }
}
