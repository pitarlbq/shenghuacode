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
	/// This object represents the properties and methods of a UserDepartment.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("UserID: {UserID}, DepartmentID: {DepartmentID}")]
	public partial class UserDepartment 
	{
		#region Public Properties
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
		private int _departmentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int DepartmentID
		{
			[DebuggerStepThrough()]
			get { return this._departmentID; }
			set 
			{
				if (this._departmentID != value) 
				{
					this._departmentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentID");
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
	[UserID] int,
	[DepartmentID] int
);

INSERT INTO [dbo].[UserDepartment] (
	[UserDepartment].[UserID],
	[UserDepartment].[DepartmentID]
) 
output 
	INSERTED.[UserID],
	INSERTED.[DepartmentID]
into @table
VALUES ( 
	@UserID,
	@DepartmentID 
); 

SELECT 
	[UserID],
	[DepartmentID] 
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
	[UserID] int,
	[DepartmentID] int
);

UPDATE [dbo].[UserDepartment] SET 
 
output 
	INSERTED.[UserID],
	INSERTED.[DepartmentID]
into @table
WHERE 
	[UserDepartment].[UserID] = @UserID
	AND [UserDepartment].[DepartmentID] = @DepartmentID

SELECT 
	[UserID],
	[DepartmentID] 
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
DELETE FROM [dbo].[UserDepartment]
WHERE 
	[UserDepartment].[UserID] = @UserID
	AND [UserDepartment].[DepartmentID] = @DepartmentID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public UserDepartment() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetUserDepartment(this.UserID, this.DepartmentID));
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
	[UserDepartment].[UserID],
	[UserDepartment].[DepartmentID]
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
                return "UserDepartment";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a UserDepartment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="departmentID">departmentID</param>
		public static void InsertUserDepartment(int @userID, int @departmentID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertUserDepartment(@userID, @departmentID, helper);
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
		/// Insert a UserDepartment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="helper">helper</param>
		internal static void InsertUserDepartment(int @userID, int @departmentID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[UserID] int,
	[DepartmentID] int
);

INSERT INTO [dbo].[UserDepartment] (
	[UserDepartment].[UserID],
	[UserDepartment].[DepartmentID]
) 
output 
	INSERTED.[UserID],
	INSERTED.[DepartmentID]
into @table
VALUES ( 
	@UserID,
	@DepartmentID 
); 

SELECT 
	[UserID],
	[DepartmentID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a UserDepartment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="departmentID">departmentID</param>
		public static void UpdateUserDepartment(int @userID, int @departmentID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateUserDepartment(@userID, @departmentID, helper);
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
		/// Updates a UserDepartment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateUserDepartment(int @userID, int @departmentID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[UserID] int,
	[DepartmentID] int
);

UPDATE [dbo].[UserDepartment] SET 
 
output 
	INSERTED.[UserID],
	INSERTED.[DepartmentID]
into @table
WHERE 
	[UserDepartment].[UserID] = @UserID
	AND [UserDepartment].[DepartmentID] = @DepartmentID

SELECT 
	[UserID],
	[DepartmentID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a UserDepartment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="departmentID">departmentID</param>
		public static void DeleteUserDepartment(int @userID, int @departmentID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteUserDepartment(@userID, @departmentID, helper);
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
		/// Deletes a UserDepartment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteUserDepartment(int @userID, int @departmentID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[UserDepartment]
WHERE 
	[UserDepartment].[UserID] = @UserID
	AND [UserDepartment].[DepartmentID] = @DepartmentID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", @userID));
			parameters.Add(new SqlParameter("@DepartmentID", @departmentID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new UserDepartment object.
		/// </summary>
		/// <returns>The newly created UserDepartment object.</returns>
		public static UserDepartment CreateUserDepartment()
		{
			return InitializeNew<UserDepartment>();
		}
		
		/// <summary>
		/// Retrieve information for a UserDepartment by a UserDepartment's unique identifier.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="departmentID">departmentID</param>
		/// <returns>UserDepartment</returns>
		public static UserDepartment GetUserDepartment(int @userID, int @departmentID)
		{
			string commandText = @"
SELECT 
" + UserDepartment.SelectFieldList + @"
FROM [dbo].[UserDepartment] 
WHERE 
	[UserDepartment].[UserID] = @UserID
	AND [UserDepartment].[DepartmentID] = @DepartmentID " + UserDepartment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", @userID));
			parameters.Add(new SqlParameter("@DepartmentID", @departmentID));
			
			return GetOne<UserDepartment>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a UserDepartment by a UserDepartment's unique identifier.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="departmentID">departmentID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>UserDepartment</returns>
		public static UserDepartment GetUserDepartment(int @userID, int @departmentID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + UserDepartment.SelectFieldList + @"
FROM [dbo].[UserDepartment] 
WHERE 
	[UserDepartment].[UserID] = @UserID
	AND [UserDepartment].[DepartmentID] = @DepartmentID " + UserDepartment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", @userID));
			parameters.Add(new SqlParameter("@DepartmentID", @departmentID));
			
			return GetOne<UserDepartment>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection UserDepartment objects.
		/// </summary>
		/// <returns>The retrieved collection of UserDepartment objects.</returns>
		public static EntityList<UserDepartment> GetUserDepartments()
		{
			string commandText = @"
SELECT " + UserDepartment.SelectFieldList + "FROM [dbo].[UserDepartment] " + UserDepartment.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<UserDepartment>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection UserDepartment objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of UserDepartment objects.</returns>
        public static EntityList<UserDepartment> GetUserDepartments(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserDepartment>(SelectFieldList, "FROM [dbo].[UserDepartment]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection UserDepartment objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of UserDepartment objects.</returns>
        public static EntityList<UserDepartment> GetUserDepartments(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserDepartment>(SelectFieldList, "FROM [dbo].[UserDepartment]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection UserDepartment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of UserDepartment objects.</returns>
		protected static EntityList<UserDepartment> GetUserDepartments(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserDepartments(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection UserDepartment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of UserDepartment objects.</returns>
		protected static EntityList<UserDepartment> GetUserDepartments(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserDepartments(string.Empty, where, parameters, UserDepartment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserDepartment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of UserDepartment objects.</returns>
		protected static EntityList<UserDepartment> GetUserDepartments(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUserDepartments(prefix, where, parameters, UserDepartment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserDepartment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of UserDepartment objects.</returns>
		protected static EntityList<UserDepartment> GetUserDepartments(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUserDepartments(string.Empty, where, parameters, UserDepartment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserDepartment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of UserDepartment objects.</returns>
		protected static EntityList<UserDepartment> GetUserDepartments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUserDepartments(prefix, where, parameters, UserDepartment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection UserDepartment objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of UserDepartment objects.</returns>
		protected static EntityList<UserDepartment> GetUserDepartments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + UserDepartment.SelectFieldList + "FROM [dbo].[UserDepartment] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<UserDepartment>(reader);
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
        protected static EntityList<UserDepartment> GetUserDepartments(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<UserDepartment>(SelectFieldList, "FROM [dbo].[UserDepartment] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of UserDepartment objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetUserDepartmentCount()
        {
            return GetUserDepartmentCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of UserDepartment objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetUserDepartmentCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[UserDepartment] " + where;

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
		public static partial class UserDepartment_Properties
		{
			public const string UserID = "UserID";
			public const string DepartmentID = "DepartmentID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"UserID" , "int:"},
    			 {"DepartmentID" , "int:"},
            };
		}
		#endregion
	}
}
