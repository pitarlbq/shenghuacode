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
    /// This object represents the properties and methods of a Seat.
    /// </summary>
    public partial class Seat : EntityBase
    {
        public static Seat GetSeatByIDAndUserID(int ID, int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var conditions = new List<string>();
            if (ID > 0)
            {
                conditions.Add("[ID]=@ID");
                parameters.Add(new SqlParameter("@ID", ID));
            }
            else if (UserID > 0)
            {
                conditions.Add("[UserID]=@UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            return GetOne<Seat>("select * from [Seat] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
    }
}
