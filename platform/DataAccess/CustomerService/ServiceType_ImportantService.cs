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
    /// This object represents the properties and methods of a ServiceType_ImportantService.
    /// </summary>
    public partial class ServiceType_ImportantService : EntityBase
    {
        public static ServiceType_ImportantService[] GetServiceType_ImportantServiceListByMinMaxServiceID(int MinServiceID, int MaxServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (MaxServiceID <= 0)
            {
                return new ServiceType_ImportantService[] { };
            }
            conditions.Add("[ServiceID] between " + MinServiceID + " and " + MaxServiceID);
            string sqlText = "select * from [ServiceType_ImportantService] where " + string.Join(" or ", conditions.ToArray());
            return GetList<ServiceType_ImportantService>(sqlText, parameters).ToArray();
        }
    }
}
