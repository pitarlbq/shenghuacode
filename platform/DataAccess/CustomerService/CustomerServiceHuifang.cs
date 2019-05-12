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
    /// This object represents the properties and methods of a CustomerServiceHuifang.
    /// </summary>
    public partial class CustomerServiceHuifang : EntityBase
    {
        public string ChuLiRateDesc
        {
            get
            {
                if (this.ChuLiRate < 0)
                {
                    return string.Empty;
                }
                return this.ChuLiRate.ToString("0.##") + "分";
            }
        }
        public static CustomerServiceHuifang[] GetCustomerServiceHuifangList(int ServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            return GetList<CustomerServiceHuifang>("select * from [CustomerServiceHuifang] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
        public static Ui.DataGrid GetCustomerServiceHuifangGridByKeywords(string Keywords, int ServiceID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("(HuiFangNote like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (ServiceID > 0)
            {
                conditions.Add("ServiceID=@ServiceID");
                parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            }
            string fieldList = "[CustomerServiceHuifang].*";
            string Statement = " from [CustomerServiceHuifang] where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            CustomerServiceHuifang[] list = new CustomerServiceHuifang[] { };
            list = GetList<CustomerServiceHuifang>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            if (list.Length == 0)
            {
                dg.rows = list;
                dg.total = totalRows;
                dg.page = pageSize;
                return dg;
            }
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static CustomerServiceHuifang[] GetCustomerServiceHuifangListByServiceIDList(List<int> ServiceIDList)
        {
            if (ServiceIDList.Count == 0)
            {
                return new CustomerServiceHuifang[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID] in (" + string.Join(",", ServiceIDList.ToArray()) + ")");
            return GetList<CustomerServiceHuifang>("select * from [CustomerServiceHuifang] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static CustomerServiceHuifang[] GetCustomerServiceHuifangListByMinMaxServiceID(int MinServiceID, int MaxServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID] between " + MinServiceID + " and " + MaxServiceID);
            return GetList<CustomerServiceHuifang>("select [ID],[ServiceID],[HuiFangTime],[AddTime],[AddUserID],[PhoneCallBackType],[HuiFangNote] from [CustomerServiceHuifang] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
