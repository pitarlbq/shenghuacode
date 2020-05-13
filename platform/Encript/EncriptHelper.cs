using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Encript
{
    public class EncriptHelper
    {
        /// <summary>
        /// 获取我的剩余短信记录
        /// </summary>
        /// <returns></returns>
        public static int GetMySmsRestCount()
        {
            string BaseURL = Utility.Tools.GetContextPath();
            ResponseSmsRestCount response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = BaseURL;
                    string result = HttpRequest.Get(new Dictionary<string, string>() { { "visit", "getsmsrestcount" }, { "key", key }, { "signature", SysConfig.GetSignature() }, { "token", SysConfig.GetToken() } });
                    response = JsonConvert.DeserializeObject<ResponseSmsRestCount>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "GetMySmsRestCount", ex);
                }
            } while (response == null && i <= 3);
            if (response != null)
            {
                return response.RestCount;
            }
            return 0;
        }
        /// <summary>
        /// 获取短信发送记录
        /// </summary>
        public static bool GetMySmsPullStatusList(DateTime StartTime, DateTime EndTime, long startRowIndex, int pageSize, out string errormsg, ref Utility.ResponseDataGrid list, ref int BillNumber, ref int RequestNumber, ref int SuccessNumber, ref int TotalSmsCount, ref decimal TotalSmsAmount)
        {
            errormsg = string.Empty;
            string BaseURL = Utility.Tools.GetContextPath();
            ResponseSmsPull response = null;
            int i = 0;
            do
            {
                try
                {
                    i++;
                    string key = BaseURL;
                    string result = HttpRequest.Get(new Dictionary<string, string>() { { "visit", "getsmspulllist" }, { "key", key }, { "signature", SysConfig.GetSignature() }, { "token", SysConfig.GetToken() }, { "StartTime", StartTime.ToString("yyyy-MM-dd") }, { "EndTime", EndTime.ToString("yyyy-MM-dd") }, { "startRowIndex", startRowIndex.ToString() }, { "pageSize", pageSize.ToString() } });
                    response = JsonConvert.DeserializeObject<ResponseSmsPull>(result);
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("EncryptHelper", "GetMySmsPullStatusList", ex);
                }
            } while (response == null && i <= 3);
            if (response != null)
            {
                list = response.list;
                BillNumber = response.BillNumber;
                RequestNumber = response.RequestNumber;
                SuccessNumber = response.SuccessNumber;
                TotalSmsCount = response.TotalSmsCount;
                TotalSmsAmount = response.TotalSmsAmount;
                errormsg = response.errormsg;
                return response.status;
            }
            errormsg = "操作超时，请稍候重试";
            return false;
        }
    }
    public class ResponseData
    {
        public bool status { get; set; }
        public string errormsg { get; set; }
    }
    public class ResponseSmsRestCount : ResponseData
    {
        public int RestCount { get; set; }
    }
    public class ResponseSmsPull : ResponseData
    {
        public int TotalSmsCount { get; set; }
        public decimal TotalSmsAmount { get; set; }
        public int BillNumber { get; set; }
        public int RequestNumber { get; set; }
        public int SuccessNumber { get; set; }
        public Utility.ResponseDataGrid list { get; set; }
    }
}
