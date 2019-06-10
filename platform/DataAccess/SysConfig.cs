using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;
using System.ComponentModel;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a SysConfig.
    /// </summary>
    public partial class SysConfig : EntityBase
    {
        public int ProjectID { get; set; }
        public static SysConfig GetSysConfigByName(string Name, SqlHelper helper = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(Name))
            {
                return null;
            }
            conditions.Add("[Name]=@Name");
            parameters.Add(new SqlParameter("@Name", Name));
            string cmdtext = "select * from [SysConfig] where " + string.Join(" and ", conditions.ToArray());
            if (helper == null)
            {
                return GetOne<SysConfig>(cmdtext, parameters);
            }
            return GetOne<SysConfig>(cmdtext, parameters, helper);
        }
        public static SysConfig[] GetSysConfigListByType(string ConfigType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ConfigType", ConfigType));
            return GetList<SysConfig>("select * from [SysConfig] where [ConfigType]=@ConfigType", parameters).ToArray();
        }
        public static SysConfig SaveSysConfigByType(SysConfig[] list, SysConfigNameDefine Name, string Value, SqlHelper helper, string ConfigType = "", bool CanSaveValue = true)
        {
            var data = list.FirstOrDefault(p => p.Name.Equals(Name.ToString()));
            if (data == null)
            {
                data = new SysConfig();
                data.AddTime = DateTime.Now;
                data.ConfigType = ConfigType;
                data.Name = Name.ToString();
                data.Value = Value;
            }
            if (CanSaveValue)
            {
                data.Value = Value;
            }
            data.Save(helper);
            return data;
        }
        public static string GetSysConfigValueByName(SysConfig[] list, SysConfigNameDefine Name)
        {
            var data = list.FirstOrDefault(p => p.Name.Equals(Name.ToString()));
            return data == null ? string.Empty : data.Value;
        }
    }
    public enum SysConfigNameDefine
    {
        [Description("派单时效")]
        ServiceTypePaiDanTime,
        [Description("回复时效")]
        ServiceTypeResponseTime,
        [Description("核查时效")]
        ServiceTypeCheckTime,
        [Description("处理时效")]
        ServiceTypeChuliTime,
        [Description("办结时效")]
        ServiceTypeBanJieTime,
        [Description("回访时效")]
        ServiceTypeHuiFangTime,
        [Description("关单时效")]
        ServiceTypeGuanDanTime,
        [Description("包括节假日")]
        ServiceTypeDisableHolidayTime,
        [Description("上班时间")]
        ServiceTypeStartHour,
        [Description("下班时间")]
        ServiceTypeEndHour,
        [Description("包括下班时间")]
        ServiceTypeDisableWorkOffTime,
    }
}
