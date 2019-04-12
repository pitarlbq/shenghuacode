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
	/// This object represents the properties and methods of a UserServiceType.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class UserServiceType 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _iD = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
			 set 
			{
				if (this._iD != value) 
				{
					this._iD = value;
					this.IsDirty = true;	
					OnPropertyChanged("ID");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private int _serviceTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ServiceTypeID
		{
			[DebuggerStepThrough()]
			get { return this._serviceTypeID; }
			set 
			{
				if (this._serviceTypeID != value) 
				{
					this._serviceTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceTypeID");
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
	[ID] int,
	[RoleID] int,
	[UserID] int,
	[ServiceTypeID] int
);

INSERT INTO [dbo].[UserServiceType] (
	[UserServiceType].[RoleID],
	[UserServiceType].[UserID],
	[UserServiceType].[ServiceTypeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[UserID],
	INSERTED.[ServiceTypeID]
into @table
VALUES ( 
	@RoleID,
	@UserID,
	@ServiceTypeID 
); 

SELECT 
	[ID],
	[RoleID],
	[UserID],
	[ServiceTypeID] 
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
	[ID] int,
	[RoleID] int,
	[UserID] int,
	[ServiceTypeID] int
);

UPDATE [dbo].[UserServiceType] SET 
	[UserServiceType].[RoleID] = @RoleID,
	[UserServiceType].[UserID] = @UserID,
	[UserServiceType].[ServiceTypeID] = @ServiceTypeID 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[UserID],
	INSERTED.[ServiceTypeID]
into @table
WHERE 
	[UserServiceType].[ID] = @ID

SELECT 
	[ID],
	[RoleID],
	[UserID],
	[ServiceTypeID] 
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
DELETE FROM [dbo].[UserServiceType]
WHERE 
	[UserServiceType].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public UserServiceType() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetUserServiceType(this.ID));
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
	[UserServiceType].[ID],
	[UserServiceType].[RoleID],
	[UserServiceType].[UserID],
	[UserServiceType].[ServiceTypeID]
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
                return "UserServiceType";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a UserServiceType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <param name="serviceTypeID">serviceTypeID</param>
		public static void InsertUserServiceType(int @roleID, int @userID, int @serviceTypeID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertUserServiceType(@roleID, @userID, @serviceTypeID, helper);
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
		/// Insert a UserServiceType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <param name="serviceTypeID">serviceTypeID</param>
		/// <param name="helper">helper</param>
		internal static void InsertUserServiceType(int @roleID, int @userID, int @serviceTypeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoleID] int,
	[UserID] int,
	[ServiceTypeID] int
);

INSERT INTO [dbo].[UserServiceType] (
	[UserServiceType].[RoleID],
	[UserServiceType].[UserID],
	[UserServiceType].[ServiceTypeID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[UserID],
	INSERTED.[ServiceTypeID]
into @table
VALUES ( 
	@RoleID,
	@UserID,
	@ServiceTypeID 
); 

SELECT 
	[ID],
	[RoleID],
	[UserID],
	[ServiceTypeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ServiceTypeID", EntityBase.GetDatabaseValue(@serviceTypeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a UserServiceType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <param name="serviceTypeID">serviceTypeID</param>
		public static void UpdateUserServiceType(int @iD, int @roleID, int @userID, int @serviceTypeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateUserServiceType(@iD, @roleID, @userID, @serviceTypeID, helper);
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
		/// Updates a UserServiceType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roleID">roleID</param>
		/// <param name="userID">userID</param>
		/// <param name="serviceTypeID">serviceTypeID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateUserServiceType(int @iD, int @roleID, int @userID, int @serviceTypeID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoleID] int,
	[UserID] int,
	[ServiceTypeID] int
);

UPDATE [dbo].[UserServiceType] SET 
	[UserServiceType].[RoleID] = @RoleID,
	[UserServiceType].[UserID] = @UserID,
	[UserServiceType].[ServiceTypeID] = @ServiceTypeID 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[UserID],
	INSERTED.[ServiceTypeID]
into @table
WHERE 
	[UserServiceType].[ID] = @ID

SELECT 
	[ID],
	[RoleID],
	[UserID],
	[ServiceTypeID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ServiceTypeID", EntityBase.GetDatabaseValue(@serviceTypeID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a UserServiceType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteUserServiceType(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteUserServiceType(@iD, helper);
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
		/// Deletes a UserServiceType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteUserServiceType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[UserServiceType]
WHERE 
	[UserServiceType].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new UserServiceType object.
		/// </summary>
		/// <returns>The newly created UserServiceType object.</returns>
		public static UserServiceType CreateUserServiceType()
		{
			return InitializeNew<UserServiceType>();
		}
		
		/// <summary>
		/// Retrieve information for a UserServiceType by a UserServiceType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>UserServiceType</returns>
		public static UserServiceType GetUserServiceType(int @iD)
		{
			string commandText = @"
SELECT 
" + UserServiceType.SelectFieldList + @"
FROM [dbo].[UserServiceType] 
WHERE 
	[UserServiceType].[ID] = @ID " + UserServiceType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<UserServiceType>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a UserServiceType by a UserServiceType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>UserServiceType</returns>
		public static UserServiceType GetUserServiceType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + UserServiceType.SelectFieldList + @"
FROM [dbo].[UserServiceType] 
WHERE 
	[UserServiceType].[ID] = @ID " + UserServiceType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<UserServiceType>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection UserServiceType objects.
		/// </summary>
		/// <returns>The retrieved collection of UserServiceType objects.</returns>
		public static EntityList<UserServiceType> GetUserServiceTypes()
		{
			string commandText = @"
SELECT " + UserServiceType.SelectFieldList + "FROM [dbo].[UserServiceType] " + UserServiceType.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<UserServiceType>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection UserServiceType objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of UserServiceType objects.</returns>
        public static EntityList<UserServiceType> GetUserServiceTypes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserServiceType>(SelectFieldList, "FROM [dbo].[UserServiceType]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection UserServiceType objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of UserServiceType objects.</returns>
        public static EntityList<UserServiceType> GetUserServiceTypes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserServiceType>(SelectFieldList, "FROM [dbo].[UserServiceType]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection UserServiceType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of UserServiceType objects.</returns>
		protected static EntityList<UserServiceType> GetUserServiceTypes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserServiceTypes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection UserServiceType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of UserServiceType objects.</returns>
		protected static EntityList<UserServiceType> GetUserServiceTypes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserServiceTypes(string.Empty, where, parameters, UserServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserServiceType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of UserServiceType objects.</returns>
		protected static EntityList<UserServiceType> GetUserServiceTypes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserServiceTypes(prefix, where, parameters, UserServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserServiceType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of UserServiceType objects.</returns>
		protected static EntityList<UserServiceType> GetUserServiceTypes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUserServiceTypes(string.Empty, where, parameters, UserServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserServiceType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of UserServiceType objects.</returns>
		protected static EntityList<UserServiceType> GetUserServiceTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUserServiceTypes(prefix, where, parameters, UserServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserServiceType objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of UserServiceType objects.</returns>
		protected static EntityList<UserServiceType> GetUserServiceTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + UserServiceType.SelectFieldList + "FROM [dbo].[UserServiceType] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<UserServiceType>(reader);
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
        protected static EntityList<UserServiceType> GetUserServiceTypes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserServiceType>(SelectFieldList, "FROM [dbo].[UserServiceType] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of UserServiceType objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetUserServiceTypeCount()
        {
            return GetUserServiceTypeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of UserServiceType objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetUserServiceTypeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[UserServiceType] " + where;

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
		public static partial class UserServiceType_Properties
		{
			public const string ID = "ID";
			public const string RoleID = "RoleID";
			public const string UserID = "UserID";
			public const string ServiceTypeID = "ServiceTypeID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoleID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"ServiceTypeID" , "int:"},
            };
		}
		#endregion
	}
}
