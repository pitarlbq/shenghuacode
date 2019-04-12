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
    /// This object represents the properties and methods of a CustomerServiceChuli_Attach.
    /// </summary>
    public partial class CustomerServiceChuli_Attach : EntityBase
    {
        public static CustomerServiceChuli_Attach[] GetCustomerServiceChuli_AttachList(int RelateID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ChuliID]=@RelateID");
            parameters.Add(new SqlParameter("@RelateID", RelateID));
            return GetList<CustomerServiceChuli_Attach>("select * from [CustomerServiceChuli_Attach] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
        public static CustomerServiceChuli_Attach[] GetCustomerServiceChuli_AttachListByServiceID(int ServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ServiceID <= 0)
            {
                return new CustomerServiceChuli_Attach[] { };
            }
            conditions.Add("[ChuliID] in (select ID from CustomerServiceChuli where ServiceID=@ServiceID)");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            return GetList<CustomerServiceChuli_Attach>("select * from [CustomerServiceChuli_Attach] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
    }
}
