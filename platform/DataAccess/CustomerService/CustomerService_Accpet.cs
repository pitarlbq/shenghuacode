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
    /// This object represents the properties and methods of a CustomerService_Accpet.
    /// </summary>
    public partial class CustomerService_Accpet : EntityBase
    {
        public static CustomerService_Accpet[] GetCustomerService_AccpetListByServiceID(int ServiceID, int[] AccpetStatusList, int AccpetUserType = 1)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            if (AccpetStatusList.Length > 0)
            {
                conditions.Add("[AccpetStatus] in (" + string.Join(",", AccpetStatusList) + ")");
            }
            if (AccpetUserType > 0)
            {
                conditions.Add("[AccpetUserType]=@AccpetUserType");
                parameters.Add(new SqlParameter("@AccpetUserType", AccpetUserType));
            }
            return GetList<CustomerService_Accpet>("select * from [CustomerService_Accpet] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
        public static CustomerService_Accpet[] GetCustomerService_AccpetListByMinMaxServiceID(int MinServiceID, int MaxServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID] between " + MinServiceID + " and " + MaxServiceID);
            conditions.Add("[AccpetStatus] in (0,1)");
            return GetList<CustomerService_Accpet>("select * from [CustomerService_Accpet] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
        public static CustomerService_Accpet GetCustomerService_AccpetByUserID(int ServiceID,int UserID, SqlHelper helper, int AccpetUserType = 1)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            conditions.Add("[AccpetStatus] in (0,1)");
            parameters.Add(new SqlParameter("@AccpetManID", UserID));
            conditions.Add("[AccpetUserType]=@AccpetUserType");
            parameters.Add(new SqlParameter("@AccpetUserType", AccpetUserType));
            return GetOne<CustomerService_Accpet>("select * from [CustomerService_Accpet] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
    }
}
