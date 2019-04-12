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
	/// This object represents the properties and methods of a UserRole.
	/// </summary>
	public partial class UserRole : EntityBase
	{
        public static UserRole[] GetUserRoleListByMinMaxUserID(int MinUserID, int MaxUserID)
        {
            if (MaxUserID <= 0)
            {
                return new UserRole[] { };
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MinUserID", MinUserID));
            parameters.Add(new SqlParameter("@MaxUserID", MaxUserID));
            return GetList<UserRole>("select * from [UserRoles] where UserID between " + MinUserID + " and " + MaxUserID, parameters).ToArray();
        }
        public static bool Save_UserRole(int[] UserIDList, int[] RoleIDList)
        {
            int MinUserID = UserIDList.Min();
            int MaxUserID = UserIDList.Max();
            var userRoleList = UserRole.GetUserRoleListByMinMaxUserID(MinUserID, MaxUserID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var UserID in UserIDList)
                    {
                        var myList = userRoleList.Where(p => p.UserID == UserID).ToArray();
                        foreach (var RoleID in RoleIDList)
                        {
                            var myData = myList.FirstOrDefault(p => p.RoleID == RoleID);
                            if (myData == null)
                            {
                                myData = new UserRole();
                                myData.UserID = UserID;
                                myData.RoleID = RoleID;
                                myData.Save(helper);
                            }
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    return false;
                }
            }
            return true;
        }
        public static bool Remove_UserRole(int[] UserIDList, int[] RoleIDList)
        {
            int MinUserID = UserIDList.Min();
            int MaxUserID = UserIDList.Max();
            var userRoleList = UserRole.GetUserRoleListByMinMaxUserID(MinUserID, MaxUserID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var UserID in UserIDList)
                    {
                        var myList = userRoleList.Where(p => p.UserID == UserID).ToArray();
                        foreach (var RoleID in RoleIDList)
                        {
                            var myData = myList.FirstOrDefault(p => p.RoleID == RoleID);
                            if (myData != null)
                            {
                                myData.Delete(helper);
                            }
                        }
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    return false;
                }
            }
            return true;
        }
	}
}
