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
    /// This object represents the properties and methods of a CustomerServiceChuli.
    /// </summary>
    public partial class CustomerServiceChuli : EntityBase
    {
        public string HandelTypeDesc
        {
            get
            {
                if (this.HandelType == 1)
                {
                    return "回复";
                }
                if (this.HandelType == 2)
                {
                    return "处理";
                }
                if (this.HandelType == 3)
                {
                    return "返修";
                }
                return string.Empty;
            }
        }
        public decimal ChuLiHandelFee
        {
            get
            {
                if (this.HandelType == 2)
                {
                    return this.HandelFee > 0 ? this.HandelFee : 0;
                }
                return 0;
            }
        }
        public decimal FanXiuHandelFee
        {
            get
            {
                if (this.HandelType == 3)
                {
                    return this.HandelFee > 0 ? this.HandelFee : 0;
                }
                return 0;
            }
        }
        public static CustomerServiceChuli[] GetCustomerServiceChuliList(int ServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            return GetList<CustomerServiceChuli>("select * from [CustomerServiceChuli] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
        public static CustomerServiceChuli[] GetCustomerServiceChuliListByServiceIDList(List<int> ServiceIDList)
        {
            if (ServiceIDList.Count == 0)
            {
                return new CustomerServiceChuli[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID] in (" + string.Join(",", ServiceIDList.ToArray()) + ")");
            return GetList<CustomerServiceChuli>("select * from [CustomerServiceChuli] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static Ui.DataGrid GetCustomerServiceChuliGridByKeywords(string Keywords, int ServiceID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            string cmd = string.Empty;
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("(ChuliNote like @Keywords or FanXiuContent like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            if (ServiceID > 0)
            {
                conditions.Add("ServiceID=@ServiceID");
                parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            }
            string fieldList = "A.*";
            string Statement = " from (select [CustomerServiceChuli].*,(select count(1) from [CustomerServiceChuli_Attach] where [ChuliID] = [CustomerServiceChuli].ID) as FileCount from [CustomerServiceChuli])A where  " + string.Join(" and ", conditions.ToArray()) + cmd;
            CustomerServiceChuliDetail[] list = new CustomerServiceChuliDetail[] { };
            list = GetList<CustomerServiceChuliDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
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
        public static CustomerServiceChuli[] GetCustomerServiceChuliListByMinMaxServiceID(int MinServiceID, int MaxServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID] between " + MinServiceID + " and " + MaxServiceID);
            return GetList<CustomerServiceChuli>("select [ID],[ServiceID],[ChuliDate],[AddTime],[HandelType],[ResponseTime],[CheckTime],[HandelFee] from [CustomerServiceChuli] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
    public partial class CustomerServiceChuliDetail : CustomerServiceChuli
    {
        [DatabaseColumn("FileCount")]
        public int FileCount { get; set; }
    }
    }
