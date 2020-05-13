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
    /// This object represents the properties and methods of a ThirdCustomer.
    /// </summary>
    public partial class ThirdCustomer : EntityBase
    {
        public static List<Dictionary<string, object>> GetThirdProjectList()
        {
            var list = GetList<ThirdCustomer>("select ProjectName from ThirdCustomer group by ProjectName", new List<SqlParameter>()).ToArray();
            var results = list.Select(p =>
             {
                 var dic = new Dictionary<string, object>();
                 dic["ID"] = p.ProjectName;
                 dic["Name"] = p.ProjectName;
                 return dic;
             }).ToList();
            results.Insert(0, new Dictionary<string, object> { { "ID", "" }, { "Name", "请选择" } });
            return results;
        }
        public string SendStatusDesc
        {
            get
            {
                if (this.LastSendTime == DateTime.MinValue)
                {
                    return "未发送";
                }
                return "已发送";
            }
        }
        public static ThirdCustomer GetThirdCustomerByPhone(string PhoneNumber)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetThirdCustomerByPhone(PhoneNumber, helper);
            }
        }
        public static ThirdCustomer GetThirdCustomerByPhone(string PhoneNumber, SqlHelper helper)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
            return GetOne<ThirdCustomer>("select * from ThirdCustomer where PhoneNumber=@PhoneNumber", parameters, helper);
        }
        public static Ui.DataGrid GetThirdCustomerListByKeywords(string Keywords, DateTime StartTime, DateTime EndTime, int SendStatus, string ProjectName, string orderBy, long startRowIndex, int pageSize, bool canexport = false)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            #region 关键字查询
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("(CustomerName like @Keywords or PhoneNumber like @Keywords or RoomName like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            #endregion
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("SignDate>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("SignDate<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime.AddDays(1)));
            }
            if (SendStatus == 1)//未发送
            {
                conditions.Add("LastSendTime is null");
            }
            else if (SendStatus == 2)//已发送
            {
                conditions.Add("LastSendTime is not null");
            }
            if (!string.IsNullOrEmpty(ProjectName))
            {
                conditions.Add("[ProjectName]=@ProjectName");
                parameters.Add(new SqlParameter("@ProjectName", ProjectName));
            }
            string fieldList = "[ThirdCustomer].*";
            string Statement = " from [ThirdCustomer] where  " + string.Join(" and ", conditions.ToArray());
            ThirdCustomer[] list = new ThirdCustomer[] { };
            if (canexport)
            {
                list = GetList<ThirdCustomer>("select " + fieldList + Statement + " " + orderBy, parameters).ToArray();
                totalRows = list.Length;
            }
            else
            {
                list = GetList<ThirdCustomer>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static ThirdCustomer[] GetThirdCustomerListByIDList(string Keywords, DateTime StartTime, DateTime EndTime, int SendStatus, string ProjectName, List<int> IDList, bool IsSelectALL)
        {
            if (!IsSelectALL)
            {
                if (IDList.Count == 0)
                {
                    return new ThirdCustomer[] { };
                }
                else if (IDList.Count > 10)
                {
                    return GetList<ThirdCustomer>("select * from ThirdCustomer", new List<SqlParameter>()).Where(p => IDList.Contains(p.ID)).ToArray();
                }
                else
                {
                    return GetList<ThirdCustomer>("select * from ThirdCustomer where ID in (" + string.Join(",", IDList) + ")", new List<SqlParameter>()).ToArray();
                }
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            #region 关键字查询
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("(CustomerName like @Keywords or PhoneNumber like @Keywords or RoomName like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            #endregion
            if (StartTime > DateTime.MinValue)
            {
                conditions.Add("SignDate>=@StartTime");
                parameters.Add(new SqlParameter("@StartTime", StartTime));
            }
            if (EndTime > DateTime.MinValue)
            {
                conditions.Add("SignDate<=@EndTime");
                parameters.Add(new SqlParameter("@EndTime", EndTime.AddDays(1)));
            }
            if (SendStatus == 1)//未发送
            {
                conditions.Add("LastSendTime is null");
            }
            else if (SendStatus == 2)//已发送
            {
                conditions.Add("LastSendTime is not null");
            }
            if (!string.IsNullOrEmpty(ProjectName))
            {
                conditions.Add("[ProjectName]=@ProjectName");
                parameters.Add(new SqlParameter("@ProjectName", ProjectName));
            }
            string Statement = "select * from [ThirdCustomer] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<ThirdCustomer>(Statement, parameters).ToArray();
        }
    }
}
