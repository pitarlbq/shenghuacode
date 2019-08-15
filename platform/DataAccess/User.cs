using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;
using System.Security.Cryptography;
using System.ComponentModel;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a User.
    /// </summary>
    public partial class User : EntityBase
    {
        public bool IsSystemUser
        {
            get
            {
                if (string.IsNullOrEmpty(this.Type))
                {
                    return false;
                }
                return this.Type.Equals(UserTypeDefine.SystemUser.ToString()) ? true : false;
            }
        }
        public static User[] GetWechatServiceUserListByUserID(int UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            conditions.Add("[UserID] not in (select [UserID] from [Wechat_ServiceUser])");
            if (UserID > 0)
            {
                conditions.Add("[UserID]=@UserID");
                parameters.Add(new SqlParameter("@UserID", UserID));
            }
            return GetList<User>("select * from [User] where " + string.Join(" or ", conditions.ToArray()), parameters).ToArray();
        }
        public static User GetAPPUserByFamilyUserID(int FamilyUserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@FamilyUserID", FamilyUserID));
            conditions.Add("[FamilyUserID]=@FamilyUserID");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User GetAPPUserByWeiboUserID(string UserID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@UserID", UserID));
            conditions.Add("[APPWeiBoUserID]=@UserID");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User GetAPPUserByQQOpenID(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            conditions.Add("[APPQQOpenID]=@OpenID");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User GetAPPUserByWxOpenID(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            conditions.Add("[APPWxOpenID]=@OpenID");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User GetAPPUserByLoginNamePassWord(string loginname, string password, string UserType = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@loginname", loginname));
            parameters.Add(new SqlParameter("@password", User.EncryptPassword(password)));
            parameters.Add(new SqlParameter("@newpassword", password));
            conditions.Add("[LoginName]=@loginname");
            string newpassword = DateTime.Now.ToString("yyyyMMdd");
            conditions.Add("([Password]=@password or @newpassword='" + newpassword + "')");
            if (string.IsNullOrEmpty(UserType))
            {
                string UserType1 = UserTypeDefine.APPCustomer.ToString();
                string UserType2 = UserTypeDefine.APPCustomerFamily.ToString();
                string UserType3 = UserTypeDefine.APPUser.ToString();
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2 or [Type]=@UserType3)");
                parameters.Add(new SqlParameter("@UserType1", UserType1));
                parameters.Add(new SqlParameter("@UserType2", UserType2));
                parameters.Add(new SqlParameter("@UserType3", UserType3));
            }
            else if (UserType.Equals(UserTypeDefine.APPUser.ToString()))
            {
                conditions.Add("([Type]=@UserType or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            else
            {
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<User>(sqlText, parameters);
        }
        public static User GetAPPUserByLoginName(string loginname, string UserType = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@LoginName", loginname));
            conditions.Add("[LoginName]=@LoginName");
            if (string.IsNullOrEmpty(UserType))
            {
                string UserType1 = UserTypeDefine.APPCustomer.ToString();
                string UserType2 = UserTypeDefine.APPCustomerFamily.ToString();
                string UserType3 = UserTypeDefine.APPUser.ToString();
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2 or [Type]=@UserType3 or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType1", UserType1));
                parameters.Add(new SqlParameter("@UserType2", UserType2));
                parameters.Add(new SqlParameter("@UserType3", UserType3));
            }
            else if (UserType.Equals(UserTypeDefine.APPUser.ToString()))
            {
                conditions.Add("([Type]=@UserType or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            else
            {
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters);
        }
        public static User[] GetAPPUserListByLoginName(string loginname, string UserType = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            parameters.Add(new SqlParameter("@LoginName", loginname));
            conditions.Add("[LoginName]=@LoginName");
            if (string.IsNullOrEmpty(UserType))
            {
                string UserType1 = UserTypeDefine.APPCustomer.ToString();
                string UserType2 = UserTypeDefine.APPCustomerFamily.ToString();
                string UserType3 = UserTypeDefine.APPUser.ToString();
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2 or [Type]=@UserType3)");
                parameters.Add(new SqlParameter("@UserType1", UserType1));
                parameters.Add(new SqlParameter("@UserType2", UserType2));
                parameters.Add(new SqlParameter("@UserType3", UserType3));
            }
            else if (UserType.Equals(UserTypeDefine.APPUser.ToString()))
            {
                conditions.Add("([Type]=@UserType or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            else
            {
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            return GetList<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static User GetUserByOpenID(string OpenID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OpenID", OpenID));
            string CmdText = "select * from [User] where OpenID=@OpenID and ([IsLocked]=0 or [IsLocked] is null);";
            return GetOne<User>(CmdText, parameters);
        }
        public static User GetUserByRelationID(int RelationID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[RelationID]=@RelationID");
            parameters.Add(new SqlParameter("@RelationID", RelationID));
            string sqlText = "select top 1 * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<User>(sqlText, parameters);
        }
        public static User GetTop1AdminUser()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[Type]=@Type");
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            conditions.Add("[UserID] in (select [UserID] from [UserRoles] where [RoleID] in (select [RoleId] from RoleModule where ModuleId=5) or [UserID] in (select [UserID] from RoleModule where ModuleId=5) or [RoleID]=1)");
            conditions.Add("[UserID] in (select [UserID] from [UserCompany])");
            parameters.Add(new SqlParameter("@Type", UserTypeDefine.SystemUser.ToString()));
            string sqlText = "select top 1 * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<User>(sqlText, parameters);
        }
        public static User GetUserByLoginNamePassWord(string loginname, string password)
        {
            return GetUserByLoginNamePassWord(loginname, password, string.Empty);
        }
        public static User GetUserByLoginNamePassWord(string loginname, string password, string UserType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            parameters.Add(new SqlParameter("@loginname", loginname));
            parameters.Add(new SqlParameter("@password", User.EncryptPassword(password)));
            parameters.Add(new SqlParameter("@newpassword", password));
            if (string.IsNullOrEmpty(UserType))
            {
                var UserType1 = UserTypeDefine.SystemUser.ToString();
                var UserType2 = UserTypeDefine.APPUser.ToString();
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2 or [IsAllowSysLogin]=1)");
                parameters.Add(new SqlParameter("@UserType1", UserType1));
                parameters.Add(new SqlParameter("@UserType2", UserType2));
            }
            else
            {
                conditions.Add("([Type]=@UserType or [IsAllowSysLogin]=1)");
                parameters.Add(new SqlParameter("@UserType", UserType));
            }
            conditions.Add("[LoginName]=@loginname");
            string newpassword = GetCommPassword();
            conditions.Add("([Password]=@password or @newpassword='" + newpassword + "')");
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetOne<User>(sqlText, parameters);
        }
        public static string GetCommPassword()
        {
            string newpassword = DateTime.Now.ToString("yyyyMMdd");
            string prepwd = new Utility.SiteConfig().PreIndex;
            newpassword = prepwd + newpassword;
            return newpassword;
        }
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="loginname"></param>
        /// <returns></returns>
        public static User GetUserByLoginName(string loginname, string Type = "")
        {
            using (SqlHelper helpler = new SqlHelper())
            {
                return GetUserByLoginName(loginname, helpler, Type);
            }
        }
        public static User GetUserByLoginName(string loginname, SqlHelper helper, string Type = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(Type))
            {
                var UserType1 = UserTypeDefine.SystemUser.ToString();
                var UserType2 = UserTypeDefine.APPUser.ToString();
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2 or [IsAllowSysLogin]=1)");
                parameters.Add(new SqlParameter("@UserType1", UserType1));
                parameters.Add(new SqlParameter("@UserType2", UserType2));
            }
            else if (Type.Equals(UserTypeDefine.APPCustomerShare.ToString()))
            {
                conditions.Add("([Type]=@Type1 or [Type]=@Type2 or [Type]=@Type3 or [Type]=@Type4)");
                parameters.Add(new SqlParameter("@Type1", UserTypeDefine.APPCustomer.ToString()));
                parameters.Add(new SqlParameter("@Type2", UserTypeDefine.APPCustomerShare.ToString()));
                parameters.Add(new SqlParameter("@Type3", UserTypeDefine.APPCustomerFamily.ToString()));
                parameters.Add(new SqlParameter("@Type4", UserTypeDefine.APPUser.ToString()));
            }
            else
            {
                parameters.Add(new SqlParameter("@Type", Type));
                conditions.Add("[Type]=@Type");
            }
            parameters.Add(new SqlParameter("@LoginName", loginname));
            conditions.Add("[LoginName]=@LoginName");
            return GetOne<User>("select * from [User] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static string EncryptPassword(string clearPassword)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(clearPassword));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static Ui.DataGrid GeUserGridByKeywords(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("([Type]=@UserType1 or [Type]=@UserType2)");
            parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.SystemUser.ToString()));
            parameters.Add(new SqlParameter("@UserType2", UserTypeDefine.APPUser.ToString()));
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([LoginName] like @Keywords or [PhoneNumber] like @Keywords or [RealName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "[User].* ";
            string Statement = " from [User] where  " + string.Join(" and ", conditions.ToArray());
            User[] list = new User[] { };
            list = GetList<User>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static User[] GetUserListByIDList(List<int> UserIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (UserIDList.Count == 0)
            {
                return new User[] { };
            }
            if (UserIDList.Count > 0)
            {
                conditions.Add("[UserID] in (" + string.Join(",", UserIDList.ToArray()) + ")");
            }
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public static User[] GetPushUserListByIDListByIDList(List<int> UserIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("isnull([APPUserDeviceID],'')!=''");
            conditions.Add("([Type]=@Type or [IsAllowAPPUserLogin]=1)");
            parameters.Add(new SqlParameter("@Type", UserTypeDefine.APPUser.ToString()));
            if (UserIDList.Count > 0)
            {
                conditions.Add("[UserID] in (" + string.Join(",", UserIDList.ToArray()) + ")");
            }
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public static User[] GetAPPUserList(int DepartmentID = 0)
        {
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string UserType = UserTypeDefine.APPUser.ToString();
            conditions.Add("([IsLocked]=0 or [IsLocked] is null)");
            conditions.Add("([Type]=@UserType or [IsAllowAPPUserLogin]=1)");
            parameters.Add(new SqlParameter("@UserType", UserType));
            if (DepartmentID > 0)
            {
                conditions.Add("[UserID] in (select [UserID] from [UserDepartment] where [DepartmentID]=@DepartmentID)");
                parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
            }
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            var list = GetList<User>(cmdtext, parameters).ToArray();
            return list;
        }
        public static int GetSysUserCount()
        {
            int count = 0;
            using (SqlHelper helper = new SqlHelper())
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Type", UserTypeDefine.SystemUser.ToString()));
                string cmdtext = "select count(1) from [User] where ([Type]=@Type or [IsAllowSysLogin]=1) and [IsLocked]=0";
                var result = helper.ExecuteScalar(cmdtext, CommandType.Text, parameters);
                if (result != null)
                {
                    int.TryParse(result.ToString(), out count);
                }
            }
            return count;
        }
        public static User[] GetSysUserList(bool IncludeLock = true, int MinUserID = 0, int MaxUserID = 0)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Type", UserTypeDefine.SystemUser.ToString()));
            var conditions = new List<string>();
            conditions.Add("([Type]=@Type or [IsAllowSysLogin]=1)");
            if (IncludeLock)
            {
                conditions.Add("([IsLocked]=0 or IsLocked is null)");
            }
            if (MaxUserID > 0)
            {
                conditions.Add("[UserID] between " + MinUserID + " and " + MaxUserID);
            }
            string cmdtext = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(cmdtext, parameters).ToArray();
        }
        public static User[] GetSysAPPUserList()
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Type1", UserTypeDefine.SystemUser.ToString()));
            parameters.Add(new SqlParameter("@Type2", UserTypeDefine.APPUser.ToString()));
            string cmdtext = "select * from [User] where ([Type]=@Type1 or [IsAllowSysLogin]=1 or [Type]=@Type2 or [IsAllowAPPUserLogin]=1) and ([IsLocked]=0 or IsLocked is null)";
            return GetList<User>(cmdtext, parameters).ToArray();
        }
        public static User[] GetUserListByRoleIDList(List<int> RoleIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoleIDList.Count > 0)
            {
                conditions.Add("[UserID] in (select [UserID] from [UserRoles] where RoleID in (" + string.Join(",", RoleIDList.ToArray()) + "))");
            }
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public static User[] GetALLModuleUserList()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([Type]=@Type1 or [Type]=@Type2)");
            parameters.Add(new SqlParameter("@Type1", UserTypeDefine.SystemUser.ToString()));
            parameters.Add(new SqlParameter("@Type2", UserTypeDefine.APPUser.ToString()));
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public static User[] GetAccpetUserListByServiceProjectID(int ProjectID, bool IsAccpetUser = false, bool IsProcessUser = false, int ServerTypeID = 0)
        {
            if (ProjectID <= 0)
            {
                return new User[] { };
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("([Type]=@Type or [IsAllowAPPUserLogin]=1)");
            parameters.Add(new SqlParameter("@Type", UserTypeDefine.APPUser.ToString()));
            if (IsAccpetUser)
            {
                ServiceType typeData = null;
                if (ServerTypeID > 0)
                {
                    typeData = ServiceType.GetServiceType(ServerTypeID);
                }
                bool isAllowLianJie = false;
                bool isAllowBiaoYang = false;
                bool isAllowGuiHua = false;
                if (typeData != null)
                {
                    isAllowLianJie = !typeData.DisableShenJi;
                }
                if (typeData != null && typeData.ServiceTypeName.Equals("建议表扬"))
                {
                    isAllowBiaoYang = true;
                }
                if (typeData != null && typeData.ServiceTypeName.Equals("规划设计"))
                {
                    isAllowGuiHua = true;
                }
                if (isAllowBiaoYang)
                {
                    conditions.Add("(PositionName='内业' or [PositionName]='客服')");
                }
                else if (isAllowGuiHua)
                {
                    conditions.Add("([PositionName]='客服')");
                }
                else
                {
                    string ModuleCode = "1101172";
                    if (isAllowLianJie)
                    {
                        ModuleCode = "1101171";
                    }
                    conditions.Add("exists(select 1 from [RoleModule] where ([UserID]=[User].[UserID] or exists(select 1 from [UserRoles] where [RoleID]=[RoleModule].RoleID and [UserID]=[User].[UserID])) and exists(select 1 from [SysMenu] where ID=[RoleModule].[ModuleId] and [ModuleCode]=@ModuleCode))");
                    parameters.Add(new SqlParameter("@ModuleCode", ModuleCode));
                }
            }
            if (IsProcessUser)
            {
                conditions.Add("exists(select 1 from [RoleModule] where ([UserID]=[User].[UserID] or exists(select 1 from [UserRoles] where [RoleID]=[RoleModule].RoleID and [UserID]=[User].[UserID])) and exists(select 1 from [SysMenu] where ID=[RoleModule].[ModuleId] and [ModuleCode]='1101160'))");
            }
            var allProjectList = new Project[] { };
            if (ProjectID > 0)
            {
                List<int> ProjectIDList = new List<int>();
                ProjectIDList.Add(ProjectID);
                List<string> cmdlist = new List<string>();
                var myProjectIDList = Project.GetProjectIDListbyIDList(ProjectIDList: ProjectIDList);
                if (myProjectIDList.Length > 0)
                {
                    conditions.Add("exists(select 1 from [RoleProject] where [ProjectID] in (" + string.Join(",", myProjectIDList) + ") and ([UserID]=[User].UserID or [RoleID] in (select RoleID from [UserRoles] where [UserID]=[User].UserID)))");
                }
            }
            if (ServerTypeID > 0)
            {
                conditions.Add("exists(select 1 from [UserServiceType] where [ServiceTypeID]=@ServiceTypeID and (UserID=[User].[UserID] or exists(select 1 from [UserRoles] where [RoleID]=[UserServiceType].RoleID and [UserID]=[User].UserID)))");
                parameters.Add(new SqlParameter("@ServiceTypeID", ServerTypeID));
            }
            conditions.Add("([PositionName]!='400专员' or PositionName is null)");
            string sqlText = "select * from [User] where " + string.Join(" and ", conditions.ToArray());
            //Utility.LogHelper.WriteDebug("GetAccpetUserListByServiceProjectID.sqlText", sqlText);
            return GetList<User>(sqlText, parameters).ToArray();
        }
        public string IsLockedDesc
        {
            get
            {
                return this.IsLocked ? "失效" : "正常";
            }
        }
        public string FinalRealName
        {
            get
            {
                return string.IsNullOrEmpty(this.RealName) ? this.LoginName : this.RealName;
            }
        }
        public string FialComboboxName
        {
            get
            {
                if (string.IsNullOrEmpty(this.PositionName))
                {
                    return this.FinalRealName;
                }
                return this.FinalRealName + "(" + this.PositionName + ")";
            }
        }
        public int FinalUserID
        {
            get
            {
                if (this.FinalParentUserID > 0)
                {
                    return this.FinalParentUserID;
                }
                return this.UserID;
            }
        }
        public int FinalParentUserID
        {
            get
            {
                if (this.ParentUserID > 0 && this.Type.Equals(UserTypeDefine.APPCustomerFamily.ToString()))
                {
                    return this.ParentUserID;
                }
                return 0;
            }
        }
        public static User GetCurrentUser()
        {
            var context = System.Web.HttpContext.Current;
            User user = null;
            if (context.User.Identity.IsAuthenticated)
            {
                string LoginName = context.User.Identity.Name;
                string[] autoName = LoginName.Split(':');
                if (autoName.Length > 1)
                {
                    LoginName = autoName[autoName.Length - 1];
                }
                user = User.GetUserByLoginName(LoginName);
            }
            return user;
        }
        public static string GetCurrentUserName()
        {
            User user = GetCurrentUser();

            return user != null ? user.LoginName : "System";
        }
    }
    public enum UserTypeDefine
    {
        [Description("系统用户")]
        SystemUser,
        [Description("员工APP用户")]
        APPUser,
        [Description("业主APP用户")]
        APPCustomer,
        [Description("商户APP用户")]
        APPBusiness,
        [Description("业主APP家庭用户")]
        APPCustomerFamily,
        [Description("业主APP分享用户")]
        APPCustomerShare,
    }
    public partial class UserDetail : User
    {
        [DatabaseColumn("CompanyName")]
        public string CompanyName { get; set; }
        [DatabaseColumn("BaseURL")]
        public string BaseURL { get; set; }
        [DatabaseColumn("Wechat_NickName")]
        public string Wechat_NickName { get; set; }
        [DatabaseColumn("UserRoomType")]
        public int UserRoomType { get; set; }
        [DatabaseColumn("DepartmentName")]
        public string DepartmentName { get; set; }
        public string SystemNo { get; set; }
        public string UserRoomTypeDesc
        {
            get
            {
                if (this.Type.Equals(UserTypeDefine.APPUser.ToString()))
                {
                    return "员工用户";
                }
                if (this.UserRoomType > 0)
                {
                    return "注册业主";
                }
                if (this.UserRoomType <= 0)
                {
                    return "游客注册";
                }
                return string.Empty;
            }
        }
        public List<string> UserRoomDesc { get; set; }
        public decimal AmountBanalce { get; set; }
        public decimal PointBalance { get; set; }
        public static Ui.DataGrid GetUserDetailGridByKeywords(string Keywords, int CompanyID, string UserType, string orderBy, long startRowIndex, int pageSize, int UserRoomType, bool IsAPPCustomer, bool IsAPPCustomerFamily, bool IsAPPBusiness, int BusinessID, int ParentUserID, bool IsAPPUser, Company company, bool can_export = false, int UserID = 0, int DepartmentID = 0, bool IsAPPCustomerAndUser = false, int DepartmentCompanyID = 0)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (DepartmentCompanyID > 0)
            {
                conditions.Add("exists(select 1 from [UserDepartment] where [UserID]=A.UserID and exists(select 1 from [CKDepartment] where [CompanyID]=@DepartmentCompanyID and [ID]=[UserDepartment].DepartmentID))");
                parameters.Add(new SqlParameter("@DepartmentCompanyID", DepartmentCompanyID));
            }
            if (DepartmentID > 0)
            {
                conditions.Add("exists(select 1 from [UserDepartment] where [UserID]=A.[UserID] and DepartmentID=@DepartmentID)");
                parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
            }
            if (ParentUserID > 0)
            {
                conditions.Add("[ParentUserID]=@ParentUserID");
                parameters.Add(new SqlParameter("@ParentUserID", ParentUserID));
            }
            if (UserRoomType == 1)
            {
                conditions.Add("[UserID] in (select [UserID] from [Mall_UserProject] where isnull([IsDisable],0)=0)");
                conditions.Add(" [Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserTypeDefine.APPCustomer.ToString()));
            }
            else if (UserRoomType == 2)
            {
                conditions.Add("[UserID] not in (select [UserID] from [Mall_UserProject] where isnull([IsDisable],0)=0)");
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserTypeDefine.APPCustomer.ToString()));
            }
            else if (UserRoomType == 3)
            {
                conditions.Add("[Type]=@UserType");
                parameters.Add(new SqlParameter("@UserType", UserTypeDefine.APPUser.ToString()));
            }
            if (IsAPPCustomer)
            {
                conditions.Add("[Type]=@UserType1");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPCustomer.ToString()));
            }
            else if (IsAPPCustomerFamily)
            {
                conditions.Add("[Type]=@UserType1");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPCustomerFamily.ToString()));
            }
            else if (IsAPPUser)
            {
                conditions.Add("([Type]=@UserType1 or [IsAllowAPPUserLogin]=1)");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPUser.ToString()));
            }
            else if (IsAPPBusiness)
            {
                conditions.Add("[Type]=@UserType1");
                conditions.Add("([UserID] in (select [UserID] from [Mall_BusinessUser] where BusinessID=@BusinessID) or [UserID] in (select [UserID] from [Mall_Business] where ID=@BusinessID))");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPBusiness.ToString()));
                parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            }
            else if (IsAPPCustomerAndUser)
            {
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2)");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.APPCustomer.ToString()));
                parameters.Add(new SqlParameter("@UserType2", UserTypeDefine.APPUser.ToString()));
            }
            else if (!string.IsNullOrEmpty(UserType))
            {
                conditions.Add("[Type]=@UserType1");
                parameters.Add(new SqlParameter("@UserType1", UserType));
            }
            else
            {
                conditions.Add("([Type]=@UserType1 or [Type]=@UserType2)");
                parameters.Add(new SqlParameter("@UserType1", UserTypeDefine.SystemUser.ToString()));
                parameters.Add(new SqlParameter("@UserType2", UserTypeDefine.APPUser.ToString()));
            }
            if (!string.IsNullOrEmpty(Keywords))
            {
                if (IsAPPCustomer)
                {
                    conditions.Add("([LoginName] like @Keywords or [PhoneNumber] like @Keywords or [RealName] like @Keywords or [UserID] in (select [ParentUserID] from [User] where [LoginName] like @Keywords))");
                }
                else
                {
                    conditions.Add("([LoginName] like @Keywords or [PhoneNumber] like @Keywords or [RealName] like @Keywords)");
                }
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string Statement_Part2 = "";
            if (IsAPPCustomer || IsAPPCustomerFamily || IsAPPUser)
            {
                Statement_Part2 += ",(select count(1) from [Mall_UserProject] where [UserID]=[User].[UserID] and isnull([IsDisable],0)=0) as UserRoomType";
            }
            if (CompanyID > 0)
            {
                conditions.Add("[UserID] in (select [UserID] from [UserCompany] where [CompanyID]=@CompanyID)");
                parameters.Add(new SqlParameter("@CompanyID", CompanyID));
                Statement_Part2 += ",(select top 1 [CompanyName] from [Company] where [CompanyID] in (select [CompanyID] from [UserCompany] where [UserID]=[User].[UserID])) as CompanyName,(select top 1 [BaseURL] from [Company] where [CompanyID] in (select [CompanyID] from [UserCompany] where [UserID]=[User].[UserID])) as BaseURL";
            }
            string fieldList = "A.*";
            string Statement = " from (select [User].*" + Statement_Part2 + " from [User]) A where  " + string.Join(" and ", conditions.ToArray());
            UserDetail[] list = new UserDetail[] { };
            if (can_export)
            {
                list = GetList<UserDetail>("select * " + Statement + " " + orderBy, parameters).ToArray();
            }
            else
            {
                list = GetList<UserDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            }
            if (list.Length > 0)
            {
                var companys = Company.GetCompanies().ToArray();
                var departmentList = CKDepartment.GetCKDepartments().ToArray();
                int MinUserID = list.Min(p => p.UserID);
                int MaxUserID = list.Max(p => p.UserID);
                var userDepartmentList = UserDepartment.GetUserDepartmentListByMinMaxUserID(MinUserID, MaxUserID);
                foreach (var item in list)
                {
                    var myUserDepartmentIDList = userDepartmentList.Where(p => p.UserID == item.UserID).Select(p => p.DepartmentID).ToArray();
                    var my_department = departmentList.FirstOrDefault(p => myUserDepartmentIDList.Contains(p.ID));
                    if (my_department != null)
                    {
                        item.DepartmentName = my_department.DepartmentName;
                        var myCompany = companys.FirstOrDefault(p => p.CompanyID == my_department.CompanyID);
                        if (myCompany != null)
                        {
                            item.CompanyName = myCompany.CompanyName;
                        }
                    }
                }
            }
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static Ui.DataGrid GeUserDetailGridByKeywordsWithOpenID(string Keywords, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add(" 1=1 ");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([LoginName] like @Keywords or [PhoneNumber] like @Keywords or [RealName] like @Keywords or [NickName] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select [User].*,(select top 1 [NickName] from [Wechat_User] where [Wechat_User].[OpenId]=[User].[OpenID]) as Wechat_NickName from [User] where isnull([OpenID],'')!='') A where  " + string.Join(" and ", conditions.ToArray());
            UserDetail[] list = new UserDetail[] { };
            list = GetList<UserDetail>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public string FinalHeadImg
        {
            get
            {
                this.HeadImg = string.IsNullOrEmpty(this.HeadImg) ? "../styles/images/error-img.png" : Utility.Tools.GetContextPath() + this.HeadImg;
                return this.HeadImg;
            }
        }
    }
}
