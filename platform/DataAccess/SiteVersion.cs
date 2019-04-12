using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a SiteVersion.
    /// </summary>
    public partial class SiteVersion : EntityBase
    {
        public static int GetLastestSiteVersionCode()
        {
            string cmdtext = "select top 1 * from SiteVersion where VersionCode>0 and (VersionType is null or VersionType='platform') order by VersionCode desc;";
            var data = GetOne<SiteVersion>(cmdtext, new List<SqlParameter>());
            if (data == null)
            {
                return 1;
            }
            return data.VersionCode + 1;
        }
        public static Ui.DataGrid GetSiteVersionGrid(string Keywords, string orderBy, long startRowIndex, int pageSize, string VersionType, bool OnlyAPP = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (OnlyAPP)
            {
                conditions.Add("([VersionType] = 'android' or [VersionType] = 'ios')");
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("[VersionDesc] like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (!string.IsNullOrEmpty(VersionType))
            {
                conditions.Add("[VersionType] = @VersionType");
                parameters.Add(new SqlParameter("@VersionType", VersionType));
            }
            string fieldList = "[SiteVersion].* ";
            string Statement = " from [SiteVersion] where  " + string.Join(" and ", conditions.ToArray());
            SiteVersion[] list = GetList<SiteVersion>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static SiteVersion GetAPPVersionByAPPVersionDesc(string APPVersionDesc, int APPType = 1, string VersionType = "android")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([DisableUpdate] is null or [DisableUpdate]=0)");
            if (!string.IsNullOrEmpty(VersionType))
            {
                conditions.Add("([VersionType]=@VersionType)");
                parameters.Add(new SqlParameter("@VersionType", VersionType));
            }
            else
            {
                conditions.Add("([VersionType]=@VersionType1 or [VersionType]=@VersionType2)");
                parameters.Add(new SqlParameter("@VersionType1", "android"));
                parameters.Add(new SqlParameter("@VersionType2", "ios"));
            }
            conditions.Add("[APPVersionDesc]=@APPVersionDesc");
            parameters.Add(new SqlParameter("@APPVersionDesc", APPVersionDesc));
            if (APPType > 0)
            {
                conditions.Add("[APPType]=@APPType");
                parameters.Add(new SqlParameter("@APPType", APPType));
            }
            string cmdtext = "select top 1 * from SiteVersion where " + string.Join(" and ", conditions.ToArray());
            return GetOne<SiteVersion>(cmdtext, parameters);
        }
        public static SiteVersion GetLatestAPPVersion(int APPVersionCode = 0, int APPType = 1, string VersionType = "android")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([DisableUpdate] is null or [DisableUpdate]=0)");
            if (!string.IsNullOrEmpty(VersionType))
            {
                conditions.Add("([VersionType]=@VersionType)");
                parameters.Add(new SqlParameter("@VersionType", VersionType));
            }
            else
            {
                conditions.Add("([VersionType]=@VersionType1 or [VersionType]=@VersionType2)");
                parameters.Add(new SqlParameter("@VersionType1", "android"));
                parameters.Add(new SqlParameter("@VersionType2", "ios"));
            }
            if (APPVersionCode > 0)
            {
                conditions.Add("[APPVersionCode]>@APPVersionCode");
                parameters.Add(new SqlParameter("@APPVersionCode", APPVersionCode));
            }
            if (APPType > 0)
            {
                conditions.Add("[APPType]=@APPType");
                parameters.Add(new SqlParameter("@APPType", APPType));
            }
            string cmdtext = "select top 1 * from SiteVersion where " + string.Join(" and ", conditions.ToArray()) + " order by [APPVersionCode] desc";
            return GetOne<SiteVersion>(cmdtext, parameters);
        }
        public string VersionTypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.VersionType)
                {
                    case "platform":
                        desc = "后台";
                        break;
                    case "android":
                        desc = "Android版本";
                        break;
                    case "ios":
                        desc = "IOS版本";
                        break;
                    case "weixin":
                        desc = "微信端";
                        break;
                    default:
                        desc = "后台";
                        break;
                }
                return desc;
            }
        }
        public string APPTypeDesc
        {
            get
            {
                string desc = string.Empty;
                switch (this.APPType)
                {
                    case 1:
                        desc = "业主端";
                        break;
                    case 2:
                        desc = "员工端";
                        break;
                    case 3:
                        desc = "商家端";
                        break;
                    default:
                        desc = "";
                        break;
                }
                return desc;
            }
        }
        public string IsForceUpdateDesc
        {
            get
            {
                return this.IsForceUpdate ? "是" : "否";
            }
        }
    }
}
