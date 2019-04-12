using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;

namespace Utility
{
    public enum LogType
    {
        LogType_Debug = 1,
        LogType_Info,
        LogType_Error,
        LogType_Fatal
    }

    public class LogHelper
    {
        private LogHelper()
        {
        }

        static ILog log;
        static LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure();
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                log = LogManager.GetLogger(Assembly.GetEntryAssembly().EntryPoint.DeclaringType);
            }
            else
            {
                log = LogManager.GetLogger("root");
            }
        }

        /// <summary>
        /// LogType,ServerName,Message,Exception
        /// </summary>
        public static event Action<LogType, string, string, Exception> Log;

        private static void OnLog(LogType type, string serverName, string message, Exception ex)
        {
            try
            {
                if (Log != null)
                {
                    Log(type, serverName, message, ex);
                }
            }
            catch
            {
            }
        }

        private static Dictionary<string, string> sAppSettings = new Dictionary<string, string>();

        public static void WriteDebug(string sServerName, string sDebugInfo)
        {
            Writelog(LogType.LogType_Debug, sServerName, sDebugInfo, null);
        }

        public static void WriteDebug(string sServerName, string sDebuginInfoFormat, params object[] args)
        {
            Writelog(LogType.LogType_Debug, sServerName, string.Format(sDebuginInfoFormat, args), null);
        }

        public static void WriteInfo(string sServerName, string sInfo)
        {
            Writelog(LogType.LogType_Info, sServerName, sInfo, null);
        }

        public static void WriteInfo(string sServerName, string sInfoFormat, params object[] args)
        {
            Writelog(LogType.LogType_Info, sServerName, string.Format(sInfoFormat, args), null);
        }

        public static void WriteError(string sServerName, string sErrorDesc, Exception e)
        {
            Writelog(LogType.LogType_Error, sServerName, sErrorDesc, e);
        }

        /// <summary>
        /// 统一的写日志方法
        /// </summary>
        /// <param name="eLogType">日志类型</param>
        /// <param name="sServerName">日志服务名</param>
        /// <param name="sErrorDesc">错误描述</param>
        /// <param name="e">Exception</param>
        public static void Writelog(LogType eLogType, string sServerName, string sErrorDesc, Exception e)
        {
            string message = string.Format("[{0}]{1}", sServerName, sErrorDesc);
            switch (eLogType)
            {
                case LogType.LogType_Debug:
                    {
                        log.Debug(message, e);
                    }
                    break;
                case LogType.LogType_Info:
                    {
                        log.Info(message, e);
                    }
                    break;
                case LogType.LogType_Error:
                    {
                        log.Error(message, e);
                    }
                    break;
                case LogType.LogType_Fatal:
                    {
                        log.Fatal(message, e);
                    }
                    break;
            }
            OnLog(eLogType, sServerName, sErrorDesc, e);
        }


        /// <summary>
        /// 统一的写日志方法(加错误版)
        /// </summary>
        /// <param name="eLogType"></param>
        /// <param name="sServerName"></param>
        /// <param name="logCode"></param>
        /// <param name="sErrorDesc"></param>
        /// <param name="e"></param>
        public static void Writelog(LogType eLogType, string sServerName, int logCode, string sErrorDesc, Exception e)
        {
            string message = string.Format("[{0}]#{2}#{1}", sServerName, sErrorDesc, logCode);
            switch (eLogType)
            {
                case LogType.LogType_Debug:
                    {
                        log.Debug(message, e);
                    }
                    break;
                case LogType.LogType_Info:
                    {
                        log.Info(message, e);
                    }
                    break;
                case LogType.LogType_Error:
                    {
                        log.Error(message, e);
                    }
                    break;
                case LogType.LogType_Fatal:
                    {
                        log.Fatal(message, e);
                    }
                    break;
            }
            OnLog(eLogType, sServerName, sErrorDesc, e);
        }
    }
}
