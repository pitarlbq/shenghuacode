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
	/// This object represents the properties and methods of a CustomerService_Material.
	/// </summary>
	public partial class CustomerService_Material : EntityBase
	{
        public static Ui.DataGrid GetCustomerService_MaterialGridByKeywords(int CustomerServiceID, string GUID, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[GUID]=@GUID");
            parameters.Add(new SqlParameter("@GUID", GUID));
            if (CustomerServiceID > 0)
            {
                conditions.Add("[CustomerServiceID]=@CustomerServiceID");
                parameters.Add(new SqlParameter("@CustomerServiceID", CustomerServiceID));
            }
            string fieldList = "[CustomerService_Material].*";
            string Statement = " from [CustomerService_Material] where  " + string.Join(" or ", conditions.ToArray());
            CustomerService_Material[] list = GetList<CustomerService_Material>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
	}
}
