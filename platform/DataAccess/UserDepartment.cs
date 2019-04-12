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
    /// This object represents the properties and methods of a UserDepartment.
    /// </summary>
    public partial class UserDepartment : EntityBase
    {
        public static UserDepartment[] GetUserDepartmentListByMinMaxUserID(int MinUserID, int MaxUserID)
        {
            if (MaxUserID <= 0)
            {
                return new UserDepartment[] { };
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MinUserID", MinUserID));
            parameters.Add(new SqlParameter("@MaxUserID", MaxUserID));
            return GetList<UserDepartment>("select * from [UserDepartment] where UserID between " + MinUserID + " and " + MaxUserID, parameters).ToArray();
        }
        public static bool Save_UserDepartment(int[] UserIDList, int[] DepartmentIDList)
        {
            int MinUserID = UserIDList.Min();
            int MaxUserID = UserIDList.Max();
            var userDepartmentList = UserDepartment.GetUserDepartmentListByMinMaxUserID(MinUserID, MaxUserID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var UserID in UserIDList)
                    {
                        var myList = userDepartmentList.Where(p => p.UserID == UserID).ToArray();
                        foreach (var DepartmentID in DepartmentIDList)
                        {
                            var myData = myList.FirstOrDefault(p => p.DepartmentID == DepartmentID);
                            if (myData == null)
                            {
                                myData = new UserDepartment();
                                myData.UserID = UserID;
                                myData.DepartmentID = DepartmentID;
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
        public static bool Remove_UserDepartment(int[] UserIDList, int[] DepartmentIDList)
        {
            int MinUserID = UserIDList.Min();
            int MaxUserID = UserIDList.Max();
            var userDepartmentList = UserDepartment.GetUserDepartmentListByMinMaxUserID(MinUserID, MaxUserID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    foreach (var UserID in UserIDList)
                    {
                        var myList = userDepartmentList.Where(p => p.UserID == UserID).ToArray();
                        foreach (var DepartmentID in DepartmentIDList)
                        {
                            var myData = myList.FirstOrDefault(p => p.DepartmentID == DepartmentID);
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
