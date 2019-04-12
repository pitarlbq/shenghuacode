using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Utility;

namespace Web.APPCode
{
    public class CommHelper
    {
        private List<Foresight.DataAccess.DefineField> DefineField_List = new List<DefineField>();
        private string origin_tablename = string.Empty;
        public string GetExistColumns(string TableName, string ColumnName)
        {
            if (string.IsNullOrEmpty(TableName))
            {
                return string.Empty;
            }
            if (DefineField_List.Count == 0)
            {
                DefineField_List = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 2).ToList();
            }
            else
            {
                if (!origin_tablename.Equals(TableName))
                {
                    DefineField_List = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 2).ToList();
                }
                origin_tablename = TableName;
            }
            if (DefineField_List.Count > 0)
            {
                var define_field = DefineField_List.FirstOrDefault(p => p.ColumnName.Equals(ColumnName));
                if (define_field != null)
                {
                    return define_field.FieldName;
                }
            }
            return string.Empty;
        }

        public static void SaveOperationLog(string OperationContent, string OperationKey, string OperationTitle, string OperationTableKey, string OperationTableName, string OperationMan = "", DateTime? LogoutTime = null, bool IsHide = false)
        {
            DateTime _LogoutTime = DateTime.MinValue;
            if (LogoutTime.HasValue)
            {
                _LogoutTime = Convert.ToDateTime(LogoutTime);
            }
            var context = HttpContext.Current;
            if (string.IsNullOrEmpty(OperationMan))
            {
                OperationMan = WebUtil.GetUser(context).LoginName;
            }
            string IPAddress = GetHostAddress();
            var log = new OperationLog();
            log.OperationTime = DateTime.Now;
            log.OperationMan = OperationMan;
            log.OperationContent = OperationContent;
            log.OperationKey = OperationKey;
            log.LogoutTime = _LogoutTime;
            log.IPAddress = IPAddress;
            log.OperationTitle = OperationTitle;
            log.OperationTableKey = OperationTableKey;
            log.OperationTableName = OperationTableName;
            log.IsHide = IsHide;
            log.Save();
        }
        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetHostAddress()
        {
            string userHostAddress = HttpContext.Current.Request.UserHostAddress;
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
    }
}