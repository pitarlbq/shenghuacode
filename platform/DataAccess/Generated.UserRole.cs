using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Script.Serialization;
using Foresight.DataAccess.Framework;


namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a UserRole.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("RoleID: {RoleID}, UserID: {UserID}")]
	public partial class UserRole 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int RoleID
		{
			[DebuggerStepThrough()]
			get { return this._roleID; }
			set 
			{
				if (this._roleID != value) 
				{
					this._roleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoleID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
				}
			}
		}
		
		
		
		#endregion
		
		#region Non-Public Properties
		/// <summary>
		/// Gets the SQL statement for an insert
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string InsertSqlStatement
		{
			[DebuggerStepThrough()]
			get 
			{
				return @"
DECLARE @table TABLE(
	[RoleID] int,
	[UserID] int
);

INSERT INTO [dbo].[UserRoles] (
	[UserRoles].[RoleID],
	[UserRoles].[UserID]
) 
output 
	INSERTED.[RoleID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RoleID,
	@UserID 
); 

SELECT 
	[RoleID],
	[UserID] 
FROM @table;
";
			}
		}
		
		/// <summary>
		/// Gets the SQL statement for an update by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string UpdateSqlStatement
		{
			[DebuggerStepThrough()]
			get
			{
				return @"
DECLARE @table TABLE(
	[RoleID] int,
	[UserID] int
);

UPDATE [dbo].[UserRoles] SET 
 
output 
	INSERTED.[RoleID],
	INSERTED.[UserID]
into @table
WHERE 
	[UserRoles].[RoleID] = @RoleID
	AND [UserRoles].[UserID] = @UserID

SELECT 
	[RoleID],
	[UserID] 
FROM @table;
";
			}
		}
		
		/// <summary>
		/// Gets the SQL statement for a delete by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected override string DeleteSqlStatement
		{
			[DebuggerStepThrough()]
			get
			{
				return @"
DELETE FROM [dbo].[UserRoles]
WHERE 
	[UserRoles].[RoleID] = @RoleID
	AND [UserRoles].[UserID] = @UserID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public UserRole() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetUserRole(this.RoleID, this.UserID));
		}

		#endregion
		
		#region Non-Public Methods
		/// <summary>
		/// This is called before an entity is saved to ensure that any parent entities keys are set properly
		/// </summary>
		protected override void EnsureParentProperties()
		{
		}
		#endregion
		
		#region Static Properties
		/// <summary>
		/// A list of all fields for this entity in the database. It does not include the 
		/// select keyword, or the table information - just the fields. This can be used
		/// for new dynamic methods.
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static string SelectFieldList 
		{
			get 
			{
				return @"
	[UserRoles].[RoleID],
	[UserRoles].[UserID]
";
			}
		}
		
		
		/// <summary>
        /// Table Name
        /// </summary>
        public new static string TableName
        {
            get
            {
                return "UserRoles";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a UserRole into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		public static void InsertUserRole(int @roleID, int @userID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertUserRole(@roleID, @userID, helper);
                    helper.Commit();
                }
                catch
                {
                    helper.Rollback();
                    throw;
                }
            }
		}

		/// <summary>
		/// Insert a UserRole into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void InsertUserRole(int @roleID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[RoleID] int,
	[UserID] int
);

INSERT INTO [dbo].[UserRoles] (
	[UserRoles].[RoleID],
	[UserRoles].[UserID]
) 
output 
	INSERTED.[RoleID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RoleID,
	@UserID 
); 

SELECT 
	[RoleID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a UserRole into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		public static void UpdateUserRole(int @roleID, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateUserRole(@roleID, @userID, helper);
					helper.Commit();
				}
				catch 
				{
					helper.Rollback();	
					throw;
				}
			}
		}
		
		/// <summary>
		/// Updates a UserRole into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateUserRole(int @roleID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[RoleID] int,
	[UserID] int
);

UPDATE [dbo].[UserRoles] SET 
 
output 
	INSERTED.[RoleID],
	INSERTED.[UserID]
into @table
WHERE 
	[UserRoles].[RoleID] = @RoleID
	AND [UserRoles].[UserID] = @UserID

SELECT 
	[RoleID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a UserRole from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		public static void DeleteUserRole(int @roleID, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteUserRole(@roleID, @userID, helper);
					helper.Commit();
				} 
				catch 
				{
					helper.Rollback();
					throw;
				}
			}
		}
		
		/// <summary>
		/// Deletes a UserRole from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteUserRole(int @roleID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[UserRoles]
WHERE 
	[UserRoles].[RoleID] = @RoleID
	AND [UserRoles].[UserID] = @UserID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", @roleID));
			parameters.Add(new SqlParameter("@UserID", @userID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new UserRole object.
		/// </summary>
		/// <returns>The newly created UserRole object.</returns>
		public static UserRole CreateUserRole()
		{
			return InitializeNew<UserRole>();
		}
		
		/// <summary>
		/// Retrieve information for a UserRole by a UserRole's unique identifier.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <returns>UserRole</returns>
		public static UserRole GetUserRole(int @roleID, int @userID)
		{
			string commandText = @"
SELECT 
" + UserRole.SelectFieldList + @"
FROM [dbo].[UserRoles] 
WHERE 
	[UserRoles].[RoleID] = @RoleID
	AND [UserRoles].[UserID] = @UserID " + UserRole.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", @roleID));
			parameters.Add(new SqlParameter("@UserID", @userID));
			
			return GetOne<UserRole>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a UserRole by a UserRole's unique identifier.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>UserRole</returns>
		public static UserRole GetUserRole(int @roleID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + UserRole.SelectFieldList + @"
FROM [dbo].[UserRoles] 
WHERE 
	[UserRoles].[RoleID] = @RoleID
	AND [UserRoles].[UserID] = @UserID " + UserRole.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", @roleID));
			parameters.Add(new SqlParameter("@UserID", @userID));
			
			return GetOne<UserRole>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection UserRole objects.
		/// </summary>
		/// <returns>The retrieved collection of UserRole objects.</returns>
		public static EntityList<UserRole> GetUserRoles()
		{
			string commandText = @"
SELECT " + UserRole.SelectFieldList + "FROM [dbo].[UserRoles] " + UserRole.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<UserRole>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection UserRole objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of UserRole objects.</returns>
        public static EntityList<UserRole> GetUserRoles(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserRole>(SelectFieldList, "FROM [dbo].[UserRoles]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection UserRole objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of UserRole objects.</returns>
        public static EntityList<UserRole> GetUserRoles(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserRole>(SelectFieldList, "FROM [dbo].[UserRoles]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection UserRole objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of UserRole objects.</returns>
		protected static EntityList<UserRole> GetUserRoles(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserRoles(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection UserRole objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of UserRole objects.</returns>
		protected static EntityList<UserRole> GetUserRoles(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserRoles(string.Empty, where, parameters, UserRole.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserRole objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of UserRole objects.</returns>
		protected static EntityList<UserRole> GetUserRoles(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserRoles(prefix, where, parameters, UserRole.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserRole objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of UserRole objects.</returns>
		protected static EntityList<UserRole> GetUserRoles(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUserRoles(string.Empty, where, parameters, UserRole.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserRole objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of UserRole objects.</returns>
		protected static EntityList<UserRole> GetUserRoles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUserRoles(prefix, where, parameters, UserRole.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserRole objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of UserRole objects.</returns>
		protected static EntityList<UserRole> GetUserRoles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + UserRole.SelectFieldList + "FROM [dbo].[UserRoles] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<UserRole>(reader);
				}
			}
		}		
		
		/// <summary>
        /// Gets a collection Address objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="where">where</param>
		/// <param name=parameters">parameters</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Address objects.</returns>
        protected static EntityList<UserRole> GetUserRoles(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserRole>(SelectFieldList, "FROM [dbo].[UserRoles] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class UserRoleProperties
		{
			public const string RoleID = "RoleID";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"RoleID" , "int:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
