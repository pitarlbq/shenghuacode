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
	/// This object represents the properties and methods of a TableColumnsUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class TableColumnsUser 
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
		private int _tableColumnID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int TableColumnID
		{
			[DebuggerStepThrough()]
			get { return this._tableColumnID; }
			set 
			{
				if (this._tableColumnID != value) 
				{
					this._tableColumnID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TableColumnID");
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
		[DataObjectField(false, false, false)]
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
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isShown = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsShown
		{
			[DebuggerStepThrough()]
			get { return this._isShown; }
			set 
			{
				if (this._isShown != value) 
				{
					this._isShown = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsShown");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceStatus = int.MinValue;
		/// <summary>
		/// 10-调度台 3-待派单 0-处理中 1-已办结 2-已销单 4-已关单
		/// </summary>
        [Description("10-调度台 3-待派单 0-处理中 1-已办结 2-已销单 4-已关单")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceStatus
		{
			[DebuggerStepThrough()]
			get { return this._serviceStatus; }
			set 
			{
				if (this._serviceStatus != value) 
				{
					this._serviceStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceType = int.MinValue;
		/// <summary>
		/// 1-报修单 2-投诉建议 3-统计分析
		/// </summary>
        [Description("1-报修单 2-投诉建议 3-统计分析")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceType
		{
			[DebuggerStepThrough()]
			get { return this._serviceType; }
			set 
			{
				if (this._serviceType != value) 
				{
					this._serviceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceType");
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
	[TableColumnID] int,
	[UserID] int,
	[SortOrder] int,
	[IsShown] bit,
	[ServiceStatus] int,
	[ServiceType] int
);

INSERT INTO [dbo].[TableColumnsUser] (
	[TableColumnsUser].[TableColumnID],
	[TableColumnsUser].[UserID],
	[TableColumnsUser].[SortOrder],
	[TableColumnsUser].[IsShown],
	[TableColumnsUser].[ServiceStatus],
	[TableColumnsUser].[ServiceType]
) 
output 
	INSERTED.[ID],
	INSERTED.[TableColumnID],
	INSERTED.[UserID],
	INSERTED.[SortOrder],
	INSERTED.[IsShown],
	INSERTED.[ServiceStatus],
	INSERTED.[ServiceType]
into @table
VALUES ( 
	@TableColumnID,
	@UserID,
	@SortOrder,
	@IsShown,
	@ServiceStatus,
	@ServiceType 
); 

SELECT 
	[ID],
	[TableColumnID],
	[UserID],
	[SortOrder],
	[IsShown],
	[ServiceStatus],
	[ServiceType] 
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
	[TableColumnID] int,
	[UserID] int,
	[SortOrder] int,
	[IsShown] bit,
	[ServiceStatus] int,
	[ServiceType] int
);

UPDATE [dbo].[TableColumnsUser] SET 
	[TableColumnsUser].[TableColumnID] = @TableColumnID,
	[TableColumnsUser].[UserID] = @UserID,
	[TableColumnsUser].[SortOrder] = @SortOrder,
	[TableColumnsUser].[IsShown] = @IsShown,
	[TableColumnsUser].[ServiceStatus] = @ServiceStatus,
	[TableColumnsUser].[ServiceType] = @ServiceType 
output 
	INSERTED.[ID],
	INSERTED.[TableColumnID],
	INSERTED.[UserID],
	INSERTED.[SortOrder],
	INSERTED.[IsShown],
	INSERTED.[ServiceStatus],
	INSERTED.[ServiceType]
into @table
WHERE 
	[TableColumnsUser].[ID] = @ID

SELECT 
	[ID],
	[TableColumnID],
	[UserID],
	[SortOrder],
	[IsShown],
	[ServiceStatus],
	[ServiceType] 
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
DELETE FROM [dbo].[TableColumnsUser]
WHERE 
	[TableColumnsUser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public TableColumnsUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetTableColumnsUser(this.ID));
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
	[TableColumnsUser].[ID],
	[TableColumnsUser].[TableColumnID],
	[TableColumnsUser].[UserID],
	[TableColumnsUser].[SortOrder],
	[TableColumnsUser].[IsShown],
	[TableColumnsUser].[ServiceStatus],
	[TableColumnsUser].[ServiceType]
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
                return "TableColumnsUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a TableColumnsUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tableColumnID">tableColumnID</param>
		/// <param name="userID">userID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShown">isShown</param>
		/// <param name="serviceStatus">serviceStatus</param>
		/// <param name="serviceType">serviceType</param>
		public static void InsertTableColumnsUser(int @tableColumnID, int @userID, int @sortOrder, bool @isShown, int @serviceStatus, int @serviceType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertTableColumnsUser(@tableColumnID, @userID, @sortOrder, @isShown, @serviceStatus, @serviceType, helper);
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
		/// Insert a TableColumnsUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="tableColumnID">tableColumnID</param>
		/// <param name="userID">userID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShown">isShown</param>
		/// <param name="serviceStatus">serviceStatus</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="helper">helper</param>
		internal static void InsertTableColumnsUser(int @tableColumnID, int @userID, int @sortOrder, bool @isShown, int @serviceStatus, int @serviceType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TableColumnID] int,
	[UserID] int,
	[SortOrder] int,
	[IsShown] bit,
	[ServiceStatus] int,
	[ServiceType] int
);

INSERT INTO [dbo].[TableColumnsUser] (
	[TableColumnsUser].[TableColumnID],
	[TableColumnsUser].[UserID],
	[TableColumnsUser].[SortOrder],
	[TableColumnsUser].[IsShown],
	[TableColumnsUser].[ServiceStatus],
	[TableColumnsUser].[ServiceType]
) 
output 
	INSERTED.[ID],
	INSERTED.[TableColumnID],
	INSERTED.[UserID],
	INSERTED.[SortOrder],
	INSERTED.[IsShown],
	INSERTED.[ServiceStatus],
	INSERTED.[ServiceType]
into @table
VALUES ( 
	@TableColumnID,
	@UserID,
	@SortOrder,
	@IsShown,
	@ServiceStatus,
	@ServiceType 
); 

SELECT 
	[ID],
	[TableColumnID],
	[UserID],
	[SortOrder],
	[IsShown],
	[ServiceStatus],
	[ServiceType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TableColumnID", EntityBase.GetDatabaseValue(@tableColumnID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsShown", @isShown));
			parameters.Add(new SqlParameter("@ServiceStatus", EntityBase.GetDatabaseValue(@serviceStatus)));
			parameters.Add(new SqlParameter("@ServiceType", EntityBase.GetDatabaseValue(@serviceType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a TableColumnsUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="tableColumnID">tableColumnID</param>
		/// <param name="userID">userID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShown">isShown</param>
		/// <param name="serviceStatus">serviceStatus</param>
		/// <param name="serviceType">serviceType</param>
		public static void UpdateTableColumnsUser(int @iD, int @tableColumnID, int @userID, int @sortOrder, bool @isShown, int @serviceStatus, int @serviceType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateTableColumnsUser(@iD, @tableColumnID, @userID, @sortOrder, @isShown, @serviceStatus, @serviceType, helper);
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
		/// Updates a TableColumnsUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="tableColumnID">tableColumnID</param>
		/// <param name="userID">userID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShown">isShown</param>
		/// <param name="serviceStatus">serviceStatus</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateTableColumnsUser(int @iD, int @tableColumnID, int @userID, int @sortOrder, bool @isShown, int @serviceStatus, int @serviceType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TableColumnID] int,
	[UserID] int,
	[SortOrder] int,
	[IsShown] bit,
	[ServiceStatus] int,
	[ServiceType] int
);

UPDATE [dbo].[TableColumnsUser] SET 
	[TableColumnsUser].[TableColumnID] = @TableColumnID,
	[TableColumnsUser].[UserID] = @UserID,
	[TableColumnsUser].[SortOrder] = @SortOrder,
	[TableColumnsUser].[IsShown] = @IsShown,
	[TableColumnsUser].[ServiceStatus] = @ServiceStatus,
	[TableColumnsUser].[ServiceType] = @ServiceType 
output 
	INSERTED.[ID],
	INSERTED.[TableColumnID],
	INSERTED.[UserID],
	INSERTED.[SortOrder],
	INSERTED.[IsShown],
	INSERTED.[ServiceStatus],
	INSERTED.[ServiceType]
into @table
WHERE 
	[TableColumnsUser].[ID] = @ID

SELECT 
	[ID],
	[TableColumnID],
	[UserID],
	[SortOrder],
	[IsShown],
	[ServiceStatus],
	[ServiceType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@TableColumnID", EntityBase.GetDatabaseValue(@tableColumnID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsShown", @isShown));
			parameters.Add(new SqlParameter("@ServiceStatus", EntityBase.GetDatabaseValue(@serviceStatus)));
			parameters.Add(new SqlParameter("@ServiceType", EntityBase.GetDatabaseValue(@serviceType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a TableColumnsUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteTableColumnsUser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteTableColumnsUser(@iD, helper);
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
		/// Deletes a TableColumnsUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteTableColumnsUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[TableColumnsUser]
WHERE 
	[TableColumnsUser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new TableColumnsUser object.
		/// </summary>
		/// <returns>The newly created TableColumnsUser object.</returns>
		public static TableColumnsUser CreateTableColumnsUser()
		{
			return InitializeNew<TableColumnsUser>();
		}
		
		/// <summary>
		/// Retrieve information for a TableColumnsUser by a TableColumnsUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>TableColumnsUser</returns>
		public static TableColumnsUser GetTableColumnsUser(int @iD)
		{
			string commandText = @"
SELECT 
" + TableColumnsUser.SelectFieldList + @"
FROM [dbo].[TableColumnsUser] 
WHERE 
	[TableColumnsUser].[ID] = @ID " + TableColumnsUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<TableColumnsUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a TableColumnsUser by a TableColumnsUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>TableColumnsUser</returns>
		public static TableColumnsUser GetTableColumnsUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + TableColumnsUser.SelectFieldList + @"
FROM [dbo].[TableColumnsUser] 
WHERE 
	[TableColumnsUser].[ID] = @ID " + TableColumnsUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<TableColumnsUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection TableColumnsUser objects.
		/// </summary>
		/// <returns>The retrieved collection of TableColumnsUser objects.</returns>
		public static EntityList<TableColumnsUser> GetTableColumnsUsers()
		{
			string commandText = @"
SELECT " + TableColumnsUser.SelectFieldList + "FROM [dbo].[TableColumnsUser] " + TableColumnsUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<TableColumnsUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection TableColumnsUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of TableColumnsUser objects.</returns>
        public static EntityList<TableColumnsUser> GetTableColumnsUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TableColumnsUser>(SelectFieldList, "FROM [dbo].[TableColumnsUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection TableColumnsUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of TableColumnsUser objects.</returns>
        public static EntityList<TableColumnsUser> GetTableColumnsUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TableColumnsUser>(SelectFieldList, "FROM [dbo].[TableColumnsUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection TableColumnsUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of TableColumnsUser objects.</returns>
		protected static EntityList<TableColumnsUser> GetTableColumnsUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTableColumnsUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection TableColumnsUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of TableColumnsUser objects.</returns>
		protected static EntityList<TableColumnsUser> GetTableColumnsUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTableColumnsUsers(string.Empty, where, parameters, TableColumnsUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TableColumnsUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of TableColumnsUser objects.</returns>
		protected static EntityList<TableColumnsUser> GetTableColumnsUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTableColumnsUsers(prefix, where, parameters, TableColumnsUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TableColumnsUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of TableColumnsUser objects.</returns>
		protected static EntityList<TableColumnsUser> GetTableColumnsUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTableColumnsUsers(string.Empty, where, parameters, TableColumnsUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TableColumnsUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of TableColumnsUser objects.</returns>
		protected static EntityList<TableColumnsUser> GetTableColumnsUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTableColumnsUsers(prefix, where, parameters, TableColumnsUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TableColumnsUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of TableColumnsUser objects.</returns>
		protected static EntityList<TableColumnsUser> GetTableColumnsUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + TableColumnsUser.SelectFieldList + "FROM [dbo].[TableColumnsUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<TableColumnsUser>(reader);
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
        protected static EntityList<TableColumnsUser> GetTableColumnsUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TableColumnsUser>(SelectFieldList, "FROM [dbo].[TableColumnsUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of TableColumnsUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetTableColumnsUserCount()
        {
            return GetTableColumnsUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of TableColumnsUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetTableColumnsUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[TableColumnsUser] " + where;

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
		public static partial class TableColumnsUser_Properties
		{
			public const string ID = "ID";
			public const string TableColumnID = "TableColumnID";
			public const string UserID = "UserID";
			public const string SortOrder = "SortOrder";
			public const string IsShown = "IsShown";
			public const string ServiceStatus = "ServiceStatus";
			public const string ServiceType = "ServiceType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"TableColumnID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"SortOrder" , "int:"},
    			 {"IsShown" , "bool:"},
    			 {"ServiceStatus" , "int:10-调度台 3-待派单 0-处理中 1-已办结 2-已销单 4-已关单"},
    			 {"ServiceType" , "int:1-报修单 2-投诉建议 3-统计分析"},
            };
		}
		#endregion
	}
}
