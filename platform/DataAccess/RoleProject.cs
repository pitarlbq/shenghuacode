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
    /// This object represents the properties and methods of a RoleProject.
    /// </summary>
    public partial class RoleProject : EntityBase
    {
        public static RoleProject[] GetRoleProjectListByUserID(int UserID)
        {
            if (UserID <= 0)
            {
                return new RoleProject[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserID", UserID));
            string sqlText = "select * from [RoleProject] where [RoleID] in (select [RoleID] from [UserRoles] where [UserID] = @UserID) or [UserID]=@UserID";
            return GetList<RoleProject>(sqlText, parameters).ToArray();
        }
        public static void DeleteRoleProjectRoleId(int RoleID, int UserID, SqlHelper helper)
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
            string commandText = @"delete from [RoleProject] where " + string.Join(" or ", conditions.ToArray());
            helper.Execute(commandText, CommandType.Text, parameters);
        }
        public static void Save_RoleProject(bool role_can_add, bool user_can_add, List<int> RoleIDList, RoleProject[] role_list, int ProjectID, int UserID, SqlHelper helper)
        {
            if (role_can_add)
            {
                foreach (var RoleID in RoleIDList)
                {
                    var roleproject = role_list.FirstOrDefault(p => p.ProjectID == ProjectID && p.RoleID == RoleID);
                    if (roleproject == null)
                    {
                        roleproject = new RoleProject()
                        {
                            RoleID = RoleID,
                            ProjectID = ProjectID,
                            UserID = 0
                        };
                        roleproject.Save(helper);
                    }
                }
            }
            if (user_can_add)
            {
                var roleproject = role_list.FirstOrDefault(p => p.ProjectID == ProjectID && p.UserID == UserID);
                if (roleproject == null)
                {
                    roleproject = new RoleProject()
                    {
                        UserID = UserID,
                        ProjectID = ProjectID,
                        RoleID = 0
                    };
                    roleproject.Save(helper);
                }
            }
        }
    }
}
