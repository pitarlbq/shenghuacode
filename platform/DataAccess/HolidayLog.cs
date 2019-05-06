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
    /// This object represents the properties and methods of a HolidayLog.
    /// </summary>
    public partial class HolidayLog : EntityBase
    {
        public static HolidayLog[] GetHolidayTypeList(DateTime MinTime, DateTime MaxTime)
        {
            //string cmdtext = "select * from [HolidayLog] where [Day] between '" + MinTime.ToString("yyyyMMdd") + "' and '" + MaxTime.ToString("yyyyMMdd") + "';";
            string cmdtext = "select * from [HolidayLog];";
            List<SqlParameter> parameters = new List<SqlParameter>();
            var list = GetList<HolidayLog>(cmdtext, parameters).ToArray();
            HolidayLog data = null;
            if (list.Length > 0)
            {
                data = list.OrderByDescending(p => p.Day).FirstOrDefault();
            }
            string MonthStr = MaxTime.ToString("yyyyMM");
            int now_yy = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int now_mm = Convert.ToInt32(DateTime.Now.ToString("MM"));
            int db_yy = 0;
            int db_mm = 0;
            if (data != null)
            {
                db_yy = Convert.ToInt32(data.Day.Substring(0, 4));
                db_mm = Convert.ToInt32(data.Day.Substring(4, 2));
            }
            else
            {
                db_yy = now_yy;
                db_mm = 0;
            }
            if (data != null && db_yy >= (now_yy + 1) && db_mm == 12)
            {
                return list;
            }
            if (db_mm == 12)
            {
                db_yy += 1;
                db_mm = 1;
            }
            else
            {
                db_mm += 1;
            }
            string date = db_yy.ToString() + db_mm.ToString("D2");
            string result = Utility.HolidayHelper.GetHoliday(date);
            if (string.IsNullOrEmpty(result))
            {
                return new HolidayLog[] { };
            }
            var resultData = Utility.JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            Dictionary<string, object> contentData = null;
            if (resultData != null && resultData.ContainsKey(date))
            {
                contentData = Utility.JsonConvert.DeserializeObject<Dictionary<string, object>>(resultData[date].ToString());
            }
            if (contentData == null)
            {
                return new HolidayLog[] { };
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    for (int i = 1; i <= 31; i++)
                    {
                        string dd_mm = db_mm.ToString("D2") + i.ToString("D2");
                        Dictionary<string, object> contentData2 = null;
                        if (contentData.ContainsKey(dd_mm))
                        {
                            contentData2 = Utility.JsonConvert.DeserializeObject<Dictionary<string, object>>(contentData[dd_mm].ToString());
                        }
                        if (contentData2 == null)
                        {
                            continue;
                        }
                        if (contentData2.ContainsKey("type"))
                        {
                            string day = db_yy.ToString() + dd_mm;
                            var dataItem = list.FirstOrDefault(p => p.Day.Equals(day));
                            if (dataItem == null)
                            {
                                dataItem = new HolidayLog();
                                dataItem.AddTime = DateTime.Now;
                                dataItem.Day = day;
                                dataItem.Value = Convert.ToInt32(contentData2["type"]);
                                dataItem.Save(helper);
                            }
                        }
                    }
                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                }
            }
            return GetList<HolidayLog>(cmdtext, parameters).ToArray();
        }
        public static decimal GetTimeHourRange(DateTime StartTime, DateTime EndTime, bool DisableHolidayTime, string StartHour, string EndHour, HolidayLog[] holidayList = null)
        {
            if (StartTime == DateTime.MinValue || EndTime == DateTime.MinValue)
            {
                return 0;
            }
            if (StartTime > EndTime)
            {
                return 0;
            }
            StartHour = string.IsNullOrEmpty(StartHour) ? "00:00" : StartHour;
            EndHour = string.IsNullOrEmpty(EndHour) ? "00:00" : EndHour;
            if (!DisableHolidayTime)
            {
                return CalculateTotalHours(StartTime, EndTime);
            }
            decimal totalHours = 0;
            int MinDay = StartTime.Day;
            int MaxDay = EndTime.Day;
            int dayCount = MaxDay - MinDay;
            for (int i = 0; i <= dayCount; i++)
            {
                DateTime iStartDate = GetDateByHourStr(StartTime.AddDays(i), StartHour, goNextDay: false);
                if (iStartDate < StartTime)
                {
                    iStartDate = StartTime;
                }
                DateTime iEndDate = GetDateByHourStr(StartTime.AddDays(i), EndHour, goNextDay: true);
                if (iEndDate > EndTime)
                {
                    iEndDate = EndTime;
                }
                if (iStartDate > iEndDate)
                {
                    continue;
                }
                HolidayLog holidayLog = null;
                if (holidayList != null)
                {
                    holidayLog = holidayList.FirstOrDefault(p => p.Day.Equals(iStartDate.ToString("yyyyMMdd")));
                }
                int holidayType = 0;
                if (holidayLog != null)
                {
                    holidayType = holidayLog.Value;
                }
                if (holidayType == 0)
                {
                    totalHours += CalculateTotalHours(iStartDate, iEndDate);
                }
            }
            return totalHours;
        }
        public static decimal CalculateTotalHours(DateTime StartTime, DateTime EndTime)
        {
            if (StartTime == DateTime.MinValue || EndTime == DateTime.MinValue)
            {
                return 0;
            }
            if (StartTime > EndTime)
            {
                return 0;
            }
            var timeSpan = EndTime - StartTime;
            double totalHour = timeSpan.TotalSeconds / 3600;
            return (decimal)Math.Round(totalHour, 2, MidpointRounding.AwayFromZero);
        }
        public static DateTime GetDateByHourStr(DateTime nowDate, string HourStr, bool goNextDay = true)
        {
            if (HourStr.Equals("00:00") && goNextDay)
            {
                return Convert.ToDateTime(nowDate.ToString("yyyy-MM-dd")).AddDays(1);
            }
            return Convert.ToDateTime(nowDate.ToString("yyyy-MM-dd") + " " + HourStr);
        }
    }
}
