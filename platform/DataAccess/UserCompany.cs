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
    /// This object represents the properties and methods of a UserCompany.
    /// </summary>
    public partial class UserCompany : EntityBase
    {
        public static UserCompany GetUserCompanyByUserID(int UserID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetUserCompanyByUserID(UserID, helper);
            }
        }
        public static UserCompany GetUserCompanyByUserID(int UserID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[UserID]=@UserID");
            parameters.Add(new SqlParameter("@UserID", UserID));
            return GetOne<UserCompany>("select top 1 * from [UserCompany] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static void Delete_UserCompany(int RoleID, int UserID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (RoleID > 0)
            {
                conditions.Add("[RoleId] = @RoleID");
                parameters.Add(new SqlParameter("@RoleID", RoleID));
            }
            if (UserID > 0)
            {
                conditions.Add("[UserID] = @UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            string commandText = @"delete from [UserCompany] where " + string.Join(" or ", conditions.ToArray());
            helper.Execute(commandText, CommandType.Text, parameters);
        }
    }
}
