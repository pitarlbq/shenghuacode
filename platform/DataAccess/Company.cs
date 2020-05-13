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
    /// This object represents the properties and methods of a Company.
    /// </summary>
    public partial class Company : EntityBase
    {
        public static Company[] GetCompanyListByKeywords(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
                conditions.Add("[CompanyName] like @Keywords");
            }
            return GetList<Company>("select * from [Company] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Ui.DataGrid GeCompanyGridByKeywords(string Keywords, int SiteStatus, int ServerLocation, string orderBy, long startRowIndex, int pageSize, int ActiveStatus, int IsWechatOn, DateTime StartTime, DateTime EndTime)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("[ServerEndTime]>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("[ServerEndTime]<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime));
            }
            if (IsWechatOn == 1)
            {
                conditions.Add("isnull([IsWechatOn],0)=1");
            }
            if (IsWechatOn == 2)
            {
                conditions.Add("isnull([IsWechatOn],0)=0");
            }
            if (ActiveStatus == 1)
            {
                conditions.Add("isnull([IsActive],1)=1");
            }
            if (ActiveStatus == 2)
            {
                conditions.Add("isnull([IsActive],1)=0");
            }
            if (SiteStatus == 1)
            {
                conditions.Add("isnull([BaseURL],'')!=''");
            }
            else if (SiteStatus == 2)
            {
                conditions.Add("isnull([BaseURL],'')=''");
            }
            if (ServerLocation > int.MinValue)
            {
                conditions.Add("isnull([ServerLocation],0)=@ServerLocation");
                parameters.Add(new SqlParameter("@ServerLocation", ServerLocation));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([CompanyName] like @Keywords or [PhoneNumber] like @Keywords or [Address] like @Keywords or [VersionCode] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[Company].* ";
            string Statement = " from [Company] where  " + string.Join(" and ", conditions.ToArray());
            Company[] list = new Company[] { };
            list = GetList<Company>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Company GetCompanyByUserID(int UserID)
        {
            var list = GetCompanyListByUserID(UserID);
            if (list.Length == 0)
            {
                return null;
            }
            return list[0];
        }
        public static Company[] GetCompanyListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            conditions.Add("exists (select 1 from [UserCompany] where [CompanyID]=[Company].CompanyID and ([UserID]=@UserID or exists(select 1 from [UserRoles] where [RoleID]=[UserCompany].RoleID and [UserID]=@UserID)))");
            return GetList<Company>("select * from [Company] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Dictionary<string, string> doGetCompanyParam(ref string error)
        {
            var config = new Utility.SiteConfig();
            var data = new Dictionary<string, string>();
            data["JPushKey_Customer"] = config.JPushKey_Customer;
            data["JPushMasterSecret_Customer"] = config.JPushMasterSecret_Customer;
            data["JPushKey_User"] = config.JPushKey_User;
            data["JPushMasterSecret_User"] = config.JPushMasterSecret_User;

            data["tencentSecretId"] = config.tencentSecretId;
            data["tencentSecretKey"] = config.tencentSecretKey;
            data["tencentAppID"] = config.tencentAppID;
            data["SmsServerSendType"] = "1";

            data["RandJsToken"] = System.Configuration.ConfigurationManager.AppSettings["RandJsToken"];
            return data;
        }
        public static bool doChangeCompanyParam(Dictionary<string, object> data, string SiteFullPath, ref string error)
        {
            string ConfigPath = SiteFullPath + @"\Web.config";
            if (System.IO.File.Exists(ConfigPath))
            {
                return Utility.IISManager.UpdateConfigValue(ConfigPath, data);
            }
            else
            {
                error = "路径错误";
                return false;
            }
        }
        public string SystemNumber
        {
            get
            {
                return "9" + this.CompanyID.ToString("D4");
            }
        }
        public string IsActiveDesc
        {
            get
            {
                return this.IsActive ? "已启用" : "已禁用";
            }
        }
        public string IsWechatOnDesc
        {
            get
            {
                return this.IsWechatOn ? "已开通" : "未开通";
            }
        }
        public string IsPayStatus
        {
            get
            {
                return this.IsPay ? "是" : "否";
            }
        }
        public string FinalAPIURL
        {
            get
            {
                if (this.ServerLocation != 1)
                {
                    var config = new Utility.SiteConfig();
                    string _LocalURL = string.IsNullOrEmpty(this.LocalURL) ? config.LocalURL : this.LocalURL;
                    return this.BaseURL.Replace(config.SITE_URL, _LocalURL);
                }
                return this.BaseURL;
            }
        }
    }
    public partial class CompanyDetail : Company
    {
        [DatabaseColumn("MsgID")]
        public int MsgID { get; set; }
        public static CompanyDetail[] GetCompanyDetailTreeListByMsgID(int MsgID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([BaseURL],'')!=''");
            parameters.Add(new SqlParameter("@MsgID", MsgID));
            CompanyDetail[] list = GetList<CompanyDetail>("select *,(select [SystemMsgID] from [SystemMsg_Company] where [SystemMsg_Company].[CompanyID]=[Company].[CompanyID] and [SystemMsgID]=@MsgID) as MsgID from [Company] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime]", parameters).ToArray();
            return list;
        }
    }
}
