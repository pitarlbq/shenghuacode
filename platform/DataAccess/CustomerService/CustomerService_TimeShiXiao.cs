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
    /// This object represents the properties and methods of a CustomerService_TimeShiXiao.
    /// </summary>
    public partial class CustomerService_TimeShiXiao : EntityBase
    {
        public static CustomerService_TimeShiXiao[] GetCustomerService_TimeShiXiaoByMinMaxID(int MinID, int MaxID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID] between " + MinID + " and " + MaxID);
            return GetList<CustomerService_TimeShiXiao>("select * from [CustomerService_TimeShiXiao] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static void SetViewCustomerServiceData(ViewCustomerService item, CustomerService_TimeShiXiao myTimeItem)
        {
            if (myTimeItem == null || item == null)
            {
                return;
            }
            item.XiaDanDate = myTimeItem.XiaDanDate;
            item.XiaDanTakeHour = myTimeItem.XiaDanTakeHour;
            item.XiaDanTimeOutStatus = myTimeItem.XiaDanTimeOutStatus;
            item.XiaDanChaoShiTakeHour = myTimeItem.XiaDanChaoShiTakeHour;

            item.PaiDanDate = myTimeItem.PaiDanDate;
            item.PaiDanTakeHour = myTimeItem.PaiDanTakeHour;
            item.PaiDanTimeOutStatus = myTimeItem.PaiDanTimeOutStatus;
            item.PaiDanChaoShiTakeHour = myTimeItem.PaiDanChaoShiTakeHour;

            item.ResponseTime = myTimeItem.ResponseTime;
            item.ResponseTakeHour = myTimeItem.ResponseTakeHour;
            item.ResponseTimeOutStatus = myTimeItem.ResponseTimeOutStatus;
            item.ResponseChaoShiTakeHour = myTimeItem.ResponseChaoShiTakeHour;

            item.ResponseTime = myTimeItem.ResponseTime;
            item.ResponseTakeHour = myTimeItem.ResponseTakeHour;
            item.ResponseTimeOutStatus = myTimeItem.ResponseTimeOutStatus;
            item.ResponseChaoShiTakeHour = myTimeItem.ResponseChaoShiTakeHour;

            item.CheckTime = myTimeItem.CheckTime;
            item.CheckTakeHour = myTimeItem.CheckTakeHour;
            item.CheckTimeOutStatus = myTimeItem.CheckTimeOutStatus;
            item.CheckChaoShiTakeHour = myTimeItem.CheckChaoShiTakeHour;

            item.ChuliDate = myTimeItem.ChuliDate;
            item.ProcessTakeHour = myTimeItem.ProcessTakeHour;
            item.ProcessTimeOutStatus = myTimeItem.ProcessTimeOutStatus;
            item.ProcessChaoShiTakeHour = myTimeItem.ProcessChaoShiTakeHour;

            //item.BanJieTime = myTimeItem.BanJieTime;
            item.BanJieTakeHour = myTimeItem.BanJieTakeHour;
            item.BanJieTimeOutStatus = myTimeItem.BanJieTimeOutStatus;
            item.BanJieChaoShiTakeHour = myTimeItem.BanJieChaoShiTakeHour;

            //item.CloseTime = myTimeItem.CloseTime;
            item.CloseTakeHour = myTimeItem.CloseTakeHour;
            item.CloseTimeOutStatus = myTimeItem.CloseTimeOutStatus;
            item.CloseChaoShiTakeHour = myTimeItem.CloseChaoShiTakeHour;
        }
        public static void SetTimeShiXiaoData(ViewCustomerService item, CustomerService_TimeShiXiao myTimeItem, List<string> sqlList)
        {
            string cmdtext = string.Empty;
            if (item == null)
            {
                return;
            }
            if (item.ServiceStatus != 1 || !item.IsClosed)
            {
                if (myTimeItem != null)
                {
                    cmdtext = $"delete from [CustomerService_TimeShiXiao] where ServiceID={item.ID};";
                }
            }
            else if (myTimeItem == null)
            {
                cmdtext = $@"insert into [CustomerService_TimeShiXiao] ([ServiceID]
           ,[XiaDanDate]
           ,[XiaDanTakeHour]
           ,[XiaDanTimeOutStatus]
           ,[XiaDanChaoShiTakeHour]
           ,[PaiDanDate]
           ,[PaiDanTakeHour]
           ,[PaiDanTimeOutStatus]
           ,[PaiDanChaoShiTakeHour]
           ,[ResponseTime]
           ,[ResponseTakeHour]
           ,[ResponseTimeOutStatus]
           ,[ResponseChaoShiTakeHour]
           ,[CheckTime]
           ,[CheckTakeHour]
           ,[CheckTimeOutStatus]
           ,[CheckChaoShiTakeHour]
           ,[ChuliDate]
           ,[ProcessTakeHour]
           ,[ProcessTimeOutStatus]
           ,[ProcessChaoShiTakeHour]
           ,[BanJieTime]
           ,[BanJieTakeHour]
           ,[BanJieTimeOutStatus]
           ,[BanJieChaoShiTakeHour]
           ,[CloseTime]
           ,[CloseTakeHour]
           ,[CloseTimeOutStatus]
           ,[CloseChaoShiTakeHour]) values({item.ID}
            ,{GetDateTimeStr(item.XiaDanDate)}
           ,{item.XiaDanTakeHour}
           ,{item.XiaDanTimeOutStatus}
           ,{item.XiaDanChaoShiTakeHour}
           ,{GetDateTimeStr(item.PaiDanDate)}
           ,{item.PaiDanTakeHour}
           ,{item.PaiDanTimeOutStatus}
           ,{item.PaiDanChaoShiTakeHour}
           ,{GetDateTimeStr(item.ResponseTime)}
           ,{item.ResponseTakeHour}
           ,{item.ResponseTimeOutStatus}
           ,{item.ResponseChaoShiTakeHour}
           ,{GetDateTimeStr(item.CheckTime)}
           ,{item.CheckTakeHour}
           ,{item.CheckTimeOutStatus}
           ,{item.CheckChaoShiTakeHour}
           ,{GetDateTimeStr(item.ChuliDate)}
           ,{item.ProcessTakeHour}
           ,{item.ProcessTimeOutStatus}
           ,{item.ProcessChaoShiTakeHour}
           ,{GetDateTimeStr(item.BanJieTime)}
           ,{item.BanJieTakeHour}
           ,{item.BanJieTimeOutStatus}
           ,{item.BanJieChaoShiTakeHour}
           ,{GetDateTimeStr(item.CloseTime)}
           ,{item.CloseTakeHour}
           ,{item.CloseTimeOutStatus}
           ,{item.CloseChaoShiTakeHour});";
            }
            else
            {
                cmdtext = $@"update [CustomerService_TimeShiXiao] set [ServiceID] = {item.ID}
      ,[XiaDanDate] ={GetDateTimeStr(item.XiaDanDate)}
      ,[XiaDanTakeHour] = {item.XiaDanTakeHour}
      ,[XiaDanTimeOutStatus] = {item.XiaDanTimeOutStatus}
      ,[XiaDanChaoShiTakeHour] = {item.XiaDanChaoShiTakeHour}
      ,[PaiDanDate] = {GetDateTimeStr(item.PaiDanDate)}
      ,[PaiDanTakeHour] = {item.PaiDanTakeHour}
      ,[PaiDanTimeOutStatus] = {item.PaiDanTimeOutStatus}
      ,[PaiDanChaoShiTakeHour] = {item.PaiDanChaoShiTakeHour}
      ,[ResponseTime] = {GetDateTimeStr(item.ResponseTime)}
      ,[ResponseTakeHour] = {item.ResponseTakeHour}
      ,[ResponseTimeOutStatus] = {item.ResponseTimeOutStatus}
      ,[ResponseChaoShiTakeHour] = {item.ResponseChaoShiTakeHour}
      ,[CheckTime] = {GetDateTimeStr(item.CheckTime)}
      ,[CheckTakeHour] = {item.CheckTakeHour}
      ,[CheckTimeOutStatus] = {item.CheckTimeOutStatus}
      ,[CheckChaoShiTakeHour] = {item.CheckChaoShiTakeHour}
      ,[ChuliDate] = {GetDateTimeStr(item.ChuliDate)}
      ,[ProcessTakeHour] = {item.ProcessTakeHour}
      ,[ProcessTimeOutStatus] = {item.ProcessTimeOutStatus}
      ,[ProcessChaoShiTakeHour] = {item.ProcessChaoShiTakeHour}
      ,[BanJieTime] = {GetDateTimeStr(item.BanJieTime)}
      ,[BanJieTakeHour] = {item.BanJieTakeHour}
      ,[BanJieTimeOutStatus] = {item.BanJieTimeOutStatus}
      ,[BanJieChaoShiTakeHour] = {item.BanJieChaoShiTakeHour}
      ,[CloseTime] = {GetDateTimeStr(item.CloseTime)}
      ,[CloseTakeHour] = {item.CloseTakeHour}
      ,[CloseTimeOutStatus] = {item.CloseTimeOutStatus}
      ,[CloseChaoShiTakeHour] = {item.CloseChaoShiTakeHour} where ServiceID={item.ID};";
            }
            if (!string.IsNullOrEmpty(cmdtext.Trim()))
            {
                sqlList.Add(cmdtext);
            }
            return;
        }
        public static void UpdateTimeShiXiaoData(List<string> sqlList)
        {
            if (sqlList.Count == 0)
            {
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    var parameters = new List<SqlParameter>();
                    foreach (var item in sqlList)
                    {
                        helper.Execute(item, CommandType.Text, parameters);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("CustomerService_TimeShiXiao.cs", "UpdateTimeShiXiaoData", ex);
                }
            }
        }
        public static string GetDateTimeStr(DateTime nowDate)
        {
            if (nowDate == DateTime.MinValue)
            {
                return "NULL";
            }
            return $"'{nowDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}'";
        }
    }
}
