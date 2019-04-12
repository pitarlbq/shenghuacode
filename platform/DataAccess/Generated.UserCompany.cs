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
	/// This object represents the properties and methods of a UserCompany.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("CompanyID: {CompanyID}, UserID: {UserID}")]
	public partial class UserCompany 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int CompanyID
		{
			[DebuggerStepThrough()]
			get { return this._companyID; }
			set 
			{
				if (this._companyID != value) 
				{
					this._companyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyID");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
	[CompanyID] int,
	[UserID] int,
	[RoleID] int
);

INSERT INTO [dbo].[UserCompany] (
	[UserCompany].[CompanyID],
	[UserCompany].[UserID],
	[UserCompany].[RoleID]
) 
output 
	INSERTED.[CompanyID],
	INSERTED.[UserID],
	INSERTED.[RoleID]
into @table
VALUES ( 
	@CompanyID,
	@UserID,
	@RoleID 
); 

SELECT 
	[CompanyID],
	[UserID],
	[RoleID] 
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
	[CompanyID] int,
	[UserID] int,
	[RoleID] int
);

UPDATE [dbo].[UserCompany] SET 
	[UserCompany].[RoleID] = @RoleID 
output 
	INSERTED.[CompanyID],
	INSERTED.[UserID],
	INSERTED.[RoleID]
into @table
WHERE 
	[UserCompany].[CompanyID] = @CompanyID
	AND [UserCompany].[UserID] = @UserID

SELECT 
	[CompanyID],
	[UserID],
	[RoleID] 
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
DELETE FROM [dbo].[UserCompany]
WHERE 
	[UserCompany].[CompanyID] = @CompanyID
	AND [UserCompany].[UserID] = @UserID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public UserCompany() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetUserCompany(this.CompanyID, this.UserID));
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
	[UserCompany].[CompanyID],
	[UserCompany].[UserID],
	[UserCompany].[RoleID]
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
                return "UserCompany";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a UserCompany into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="userID">userID</param>
		/// <param name="roleID">roleID</param>
		public static void InsertUserCompany(int @companyID, int @userID, int @roleID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertUserCompany(@companyID, @userID, @roleID, helper);
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
		/// Insert a UserCompany into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="userID">userID</param>
		/// <param name="roleID">roleID</param>
		/// <param name="helper">helper</param>
		internal static void InsertUserCompany(int @companyID, int @userID, int @roleID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[CompanyID] int,
	[UserID] int,
	[RoleID] int
);

INSERT INTO [dbo].[UserCompany] (
	[UserCompany].[CompanyID],
	[UserCompany].[UserID],
	[UserCompany].[RoleID]
) 
output 
	INSERTED.[CompanyID],
	INSERTED.[UserID],
	INSERTED.[RoleID]
into @table
VALUES ( 
	@CompanyID,
	@UserID,
	@RoleID 
); 

SELECT 
	[CompanyID],
	[UserID],
	[RoleID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a UserCompany into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="userID">userID</param>
		/// <param name="roleID">roleID</param>
		public static void UpdateUserCompany(int @companyID, int @userID, int @roleID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateUserCompany(@companyID, @userID, @roleID, helper);
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
		/// Updates a UserCompany into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="userID">userID</param>
		/// <param name="roleID">roleID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateUserCompany(int @companyID, int @userID, int @roleID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[CompanyID] int,
	[UserID] int,
	[RoleID] int
);

UPDATE [dbo].[UserCompany] SET 
	[UserCompany].[RoleID] = @RoleID 
output 
	INSERTED.[CompanyID],
	INSERTED.[UserID],
	INSERTED.[RoleID]
into @table
WHERE 
	[UserCompany].[CompanyID] = @CompanyID
	AND [UserCompany].[UserID] = @UserID

SELECT 
	[CompanyID],
	[UserID],
	[RoleID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a UserCompany from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="userID">userID</param>
		public static void DeleteUserCompany(int @companyID, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteUserCompany(@companyID, @userID, helper);
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
		/// Deletes a UserCompany from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteUserCompany(int @companyID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[UserCompany]
WHERE 
	[UserCompany].[CompanyID] = @CompanyID
	AND [UserCompany].[UserID] = @UserID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", @companyID));
			parameters.Add(new SqlParameter("@UserID", @userID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new UserCompany object.
		/// </summary>
		/// <returns>The newly created UserCompany object.</returns>
		public static UserCompany CreateUserCompany()
		{
			return InitializeNew<UserCompany>();
		}
		
		/// <summary>
		/// Retrieve information for a UserCompany by a UserCompany's unique identifier.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="userID">userID</param>
		/// <returns>UserCompany</returns>
		public static UserCompany GetUserCompany(int @companyID, int @userID)
		{
			string commandText = @"
SELECT 
" + UserCompany.SelectFieldList + @"
FROM [dbo].[UserCompany] 
WHERE 
	[UserCompany].[CompanyID] = @CompanyID
	AND [UserCompany].[UserID] = @UserID " + UserCompany.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", @companyID));
			parameters.Add(new SqlParameter("@UserID", @userID));
			
			return GetOne<UserCompany>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a UserCompany by a UserCompany's unique identifier.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="userID">userID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>UserCompany</returns>
		public static UserCompany GetUserCompany(int @companyID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + UserCompany.SelectFieldList + @"
FROM [dbo].[UserCompany] 
WHERE 
	[UserCompany].[CompanyID] = @CompanyID
	AND [UserCompany].[UserID] = @UserID " + UserCompany.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", @companyID));
			parameters.Add(new SqlParameter("@UserID", @userID));
			
			return GetOne<UserCompany>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection UserCompany objects.
		/// </summary>
		/// <returns>The retrieved collection of UserCompany objects.</returns>
		public static EntityList<UserCompany> GetUserCompanies()
		{
			string commandText = @"
SELECT " + UserCompany.SelectFieldList + "FROM [dbo].[UserCompany] " + UserCompany.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<UserCompany>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection UserCompany objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of UserCompany objects.</returns>
        public static EntityList<UserCompany> GetUserCompanies(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserCompany>(SelectFieldList, "FROM [dbo].[UserCompany]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection UserCompany objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of UserCompany objects.</returns>
        public static EntityList<UserCompany> GetUserCompanies(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserCompany>(SelectFieldList, "FROM [dbo].[UserCompany]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection UserCompany objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of UserCompany objects.</returns>
		protected static EntityList<UserCompany> GetUserCompanies(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserCompanies(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection UserCompany objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of UserCompany objects.</returns>
		protected static EntityList<UserCompany> GetUserCompanies(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserCompanies(string.Empty, where, parameters, UserCompany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserCompany objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of UserCompany objects.</returns>
		protected static EntityList<UserCompany> GetUserCompanies(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserCompanies(prefix, where, parameters, UserCompany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserCompany objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of UserCompany objects.</returns>
		protected static EntityList<UserCompany> GetUserCompanies(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUserCompanies(string.Empty, where, parameters, UserCompany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserCompany objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of UserCompany objects.</returns>
		protected static EntityList<UserCompany> GetUserCompanies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUserCompanies(prefix, where, parameters, UserCompany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserCompany objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of UserCompany objects.</returns>
		protected static EntityList<UserCompany> GetUserCompanies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + UserCompany.SelectFieldList + "FROM [dbo].[UserCompany] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<UserCompany>(reader);
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
        protected static EntityList<UserCompany> GetUserCompanies(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserCompany>(SelectFieldList, "FROM [dbo].[UserCompany] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of UserCompany objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetUserCompanyCount()
        {
            return GetUserCompanyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of UserCompany objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetUserCompanyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[UserCompany] " + where;

            using (SqlHelper helper = new SqlHelper())
            {
                var obj = helper.ExecuteScalar(commandText, CommandType.Text, parameters);
                if (obj != null && obj != DBNull.Value)
                {
                    return Convert.ToInt64(obj);
                }
            }
            return 0;
        }
		#endregion
		
		#region Subclasses
		public static partial class UserCompany_Properties
		{
			public const string CompanyID = "CompanyID";
			public const string UserID = "UserID";
			public const string RoleID = "RoleID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"CompanyID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"RoleID" , "int:"},
            };
		}
		#endregion
	}
}
