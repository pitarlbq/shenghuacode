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
	/// This object represents the properties and methods of a Project_ServiceTypeDelay.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ProjectID: {ProjectID}")]
	public partial class Project_ServiceTypeDelay 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
			set 
			{
				if (this._projectID != value) 
				{
					this._projectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _delayHour = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DelayHour
		{
			[DebuggerStepThrough()]
			get { return this._delayHour; }
			set 
			{
				if (this._delayHour != value) 
				{
					this._delayHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("DelayHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _addTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime AddTime
		{
			[DebuggerStepThrough()]
			get { return this._addTime; }
			set 
			{
				if (this._addTime != value) 
				{
					this._addTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddName
		{
			[DebuggerStepThrough()]
			get { return this._addName; }
			set 
			{
				if (this._addName != value) 
				{
					this._addName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _updateTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime UpdateTime
		{
			[DebuggerStepThrough()]
			get { return this._updateTime; }
			set 
			{
				if (this._updateTime != value) 
				{
					this._updateTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("UpdateTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _updateName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string UpdateName
		{
			[DebuggerStepThrough()]
			get { return this._updateName; }
			set 
			{
				if (this._updateName != value) 
				{
					this._updateName = value;
					this.IsDirty = true;	
					OnPropertyChanged("UpdateName");
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
	[ProjectID] int,
	[DelayHour] int,
	[AddTime] datetime,
	[AddName] nvarchar(50),
	[UpdateTime] datetime,
	[UpdateName] nvarchar(50)
);

INSERT INTO [dbo].[Project_ServiceTypeDelay] (
	[Project_ServiceTypeDelay].[ProjectID],
	[Project_ServiceTypeDelay].[DelayHour],
	[Project_ServiceTypeDelay].[AddTime],
	[Project_ServiceTypeDelay].[AddName],
	[Project_ServiceTypeDelay].[UpdateTime],
	[Project_ServiceTypeDelay].[UpdateName]
) 
output 
	INSERTED.[ProjectID],
	INSERTED.[DelayHour],
	INSERTED.[AddTime],
	INSERTED.[AddName],
	INSERTED.[UpdateTime],
	INSERTED.[UpdateName]
into @table
VALUES ( 
	@ProjectID,
	@DelayHour,
	@AddTime,
	@AddName,
	@UpdateTime,
	@UpdateName 
); 

SELECT 
	[ProjectID],
	[DelayHour],
	[AddTime],
	[AddName],
	[UpdateTime],
	[UpdateName] 
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
	[ProjectID] int,
	[DelayHour] int,
	[AddTime] datetime,
	[AddName] nvarchar(50),
	[UpdateTime] datetime,
	[UpdateName] nvarchar(50)
);

UPDATE [dbo].[Project_ServiceTypeDelay] SET 
	[Project_ServiceTypeDelay].[DelayHour] = @DelayHour,
	[Project_ServiceTypeDelay].[AddTime] = @AddTime,
	[Project_ServiceTypeDelay].[AddName] = @AddName,
	[Project_ServiceTypeDelay].[UpdateTime] = @UpdateTime,
	[Project_ServiceTypeDelay].[UpdateName] = @UpdateName 
output 
	INSERTED.[ProjectID],
	INSERTED.[DelayHour],
	INSERTED.[AddTime],
	INSERTED.[AddName],
	INSERTED.[UpdateTime],
	INSERTED.[UpdateName]
into @table
WHERE 
	[Project_ServiceTypeDelay].[ProjectID] = @ProjectID

SELECT 
	[ProjectID],
	[DelayHour],
	[AddTime],
	[AddName],
	[UpdateTime],
	[UpdateName] 
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
DELETE FROM [dbo].[Project_ServiceTypeDelay]
WHERE 
	[Project_ServiceTypeDelay].[ProjectID] = @ProjectID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Project_ServiceTypeDelay() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProject_ServiceTypeDelay(this.ProjectID));
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
	[Project_ServiceTypeDelay].[ProjectID],
	[Project_ServiceTypeDelay].[DelayHour],
	[Project_ServiceTypeDelay].[AddTime],
	[Project_ServiceTypeDelay].[AddName],
	[Project_ServiceTypeDelay].[UpdateTime],
	[Project_ServiceTypeDelay].[UpdateName]
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
                return "Project_ServiceTypeDelay";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Project_ServiceTypeDelay into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="delayHour">delayHour</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addName">addName</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="updateName">updateName</param>
		public static void InsertProject_ServiceTypeDelay(int @projectID, int @delayHour, DateTime @addTime, string @addName, DateTime @updateTime, string @updateName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProject_ServiceTypeDelay(@projectID, @delayHour, @addTime, @addName, @updateTime, @updateName, helper);
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
		/// Insert a Project_ServiceTypeDelay into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="delayHour">delayHour</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addName">addName</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="updateName">updateName</param>
		/// <param name="helper">helper</param>
		internal static void InsertProject_ServiceTypeDelay(int @projectID, int @delayHour, DateTime @addTime, string @addName, DateTime @updateTime, string @updateName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ProjectID] int,
	[DelayHour] int,
	[AddTime] datetime,
	[AddName] nvarchar(50),
	[UpdateTime] datetime,
	[UpdateName] nvarchar(50)
);

INSERT INTO [dbo].[Project_ServiceTypeDelay] (
	[Project_ServiceTypeDelay].[ProjectID],
	[Project_ServiceTypeDelay].[DelayHour],
	[Project_ServiceTypeDelay].[AddTime],
	[Project_ServiceTypeDelay].[AddName],
	[Project_ServiceTypeDelay].[UpdateTime],
	[Project_ServiceTypeDelay].[UpdateName]
) 
output 
	INSERTED.[ProjectID],
	INSERTED.[DelayHour],
	INSERTED.[AddTime],
	INSERTED.[AddName],
	INSERTED.[UpdateTime],
	INSERTED.[UpdateName]
into @table
VALUES ( 
	@ProjectID,
	@DelayHour,
	@AddTime,
	@AddName,
	@UpdateTime,
	@UpdateName 
); 

SELECT 
	[ProjectID],
	[DelayHour],
	[AddTime],
	[AddName],
	[UpdateTime],
	[UpdateName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@DelayHour", EntityBase.GetDatabaseValue(@delayHour)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddName", EntityBase.GetDatabaseValue(@addName)));
			parameters.Add(new SqlParameter("@UpdateTime", EntityBase.GetDatabaseValue(@updateTime)));
			parameters.Add(new SqlParameter("@UpdateName", EntityBase.GetDatabaseValue(@updateName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Project_ServiceTypeDelay into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="delayHour">delayHour</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addName">addName</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="updateName">updateName</param>
		public static void UpdateProject_ServiceTypeDelay(int @projectID, int @delayHour, DateTime @addTime, string @addName, DateTime @updateTime, string @updateName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProject_ServiceTypeDelay(@projectID, @delayHour, @addTime, @addName, @updateTime, @updateName, helper);
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
		/// Updates a Project_ServiceTypeDelay into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="delayHour">delayHour</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addName">addName</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="updateName">updateName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProject_ServiceTypeDelay(int @projectID, int @delayHour, DateTime @addTime, string @addName, DateTime @updateTime, string @updateName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ProjectID] int,
	[DelayHour] int,
	[AddTime] datetime,
	[AddName] nvarchar(50),
	[UpdateTime] datetime,
	[UpdateName] nvarchar(50)
);

UPDATE [dbo].[Project_ServiceTypeDelay] SET 
	[Project_ServiceTypeDelay].[DelayHour] = @DelayHour,
	[Project_ServiceTypeDelay].[AddTime] = @AddTime,
	[Project_ServiceTypeDelay].[AddName] = @AddName,
	[Project_ServiceTypeDelay].[UpdateTime] = @UpdateTime,
	[Project_ServiceTypeDelay].[UpdateName] = @UpdateName 
output 
	INSERTED.[ProjectID],
	INSERTED.[DelayHour],
	INSERTED.[AddTime],
	INSERTED.[AddName],
	INSERTED.[UpdateTime],
	INSERTED.[UpdateName]
into @table
WHERE 
	[Project_ServiceTypeDelay].[ProjectID] = @ProjectID

SELECT 
	[ProjectID],
	[DelayHour],
	[AddTime],
	[AddName],
	[UpdateTime],
	[UpdateName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@DelayHour", EntityBase.GetDatabaseValue(@delayHour)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddName", EntityBase.GetDatabaseValue(@addName)));
			parameters.Add(new SqlParameter("@UpdateTime", EntityBase.GetDatabaseValue(@updateTime)));
			parameters.Add(new SqlParameter("@UpdateName", EntityBase.GetDatabaseValue(@updateName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Project_ServiceTypeDelay from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		public static void DeleteProject_ServiceTypeDelay(int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProject_ServiceTypeDelay(@projectID, helper);
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
		/// Deletes a Project_ServiceTypeDelay from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProject_ServiceTypeDelay(int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Project_ServiceTypeDelay]
WHERE 
	[Project_ServiceTypeDelay].[ProjectID] = @ProjectID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Project_ServiceTypeDelay object.
		/// </summary>
		/// <returns>The newly created Project_ServiceTypeDelay object.</returns>
		public static Project_ServiceTypeDelay CreateProject_ServiceTypeDelay()
		{
			return InitializeNew<Project_ServiceTypeDelay>();
		}
		
		/// <summary>
		/// Retrieve information for a Project_ServiceTypeDelay by a Project_ServiceTypeDelay's unique identifier.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <returns>Project_ServiceTypeDelay</returns>
		public static Project_ServiceTypeDelay GetProject_ServiceTypeDelay(int @projectID)
		{
			string commandText = @"
SELECT 
" + Project_ServiceTypeDelay.SelectFieldList + @"
FROM [dbo].[Project_ServiceTypeDelay] 
WHERE 
	[Project_ServiceTypeDelay].[ProjectID] = @ProjectID " + Project_ServiceTypeDelay.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Project_ServiceTypeDelay>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Project_ServiceTypeDelay by a Project_ServiceTypeDelay's unique identifier.
		/// </summary>
		/// <param name="projectID">projectID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Project_ServiceTypeDelay</returns>
		public static Project_ServiceTypeDelay GetProject_ServiceTypeDelay(int @projectID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Project_ServiceTypeDelay.SelectFieldList + @"
FROM [dbo].[Project_ServiceTypeDelay] 
WHERE 
	[Project_ServiceTypeDelay].[ProjectID] = @ProjectID " + Project_ServiceTypeDelay.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Project_ServiceTypeDelay>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Project_ServiceTypeDelay objects.
		/// </summary>
		/// <returns>The retrieved collection of Project_ServiceTypeDelay objects.</returns>
		public static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays()
		{
			string commandText = @"
SELECT " + Project_ServiceTypeDelay.SelectFieldList + "FROM [dbo].[Project_ServiceTypeDelay] " + Project_ServiceTypeDelay.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Project_ServiceTypeDelay>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Project_ServiceTypeDelay objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project_ServiceTypeDelay objects.</returns>
        public static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_ServiceTypeDelay>(SelectFieldList, "FROM [dbo].[Project_ServiceTypeDelay]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Project_ServiceTypeDelay objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project_ServiceTypeDelay objects.</returns>
        public static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_ServiceTypeDelay>(SelectFieldList, "FROM [dbo].[Project_ServiceTypeDelay]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Project_ServiceTypeDelay objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Project_ServiceTypeDelay objects.</returns>
		protected static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_ServiceTypeDelays(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Project_ServiceTypeDelay objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project_ServiceTypeDelay objects.</returns>
		protected static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_ServiceTypeDelays(string.Empty, where, parameters, Project_ServiceTypeDelay.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_ServiceTypeDelay objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project_ServiceTypeDelay objects.</returns>
		protected static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_ServiceTypeDelays(prefix, where, parameters, Project_ServiceTypeDelay.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_ServiceTypeDelay objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project_ServiceTypeDelay objects.</returns>
		protected static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProject_ServiceTypeDelays(string.Empty, where, parameters, Project_ServiceTypeDelay.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_ServiceTypeDelay objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project_ServiceTypeDelay objects.</returns>
		protected static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProject_ServiceTypeDelays(prefix, where, parameters, Project_ServiceTypeDelay.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_ServiceTypeDelay objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Project_ServiceTypeDelay objects.</returns>
		protected static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Project_ServiceTypeDelay.SelectFieldList + "FROM [dbo].[Project_ServiceTypeDelay] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Project_ServiceTypeDelay>(reader);
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
        protected static EntityList<Project_ServiceTypeDelay> GetProject_ServiceTypeDelays(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_ServiceTypeDelay>(SelectFieldList, "FROM [dbo].[Project_ServiceTypeDelay] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Project_ServiceTypeDelay objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProject_ServiceTypeDelayCount()
        {
            return GetProject_ServiceTypeDelayCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Project_ServiceTypeDelay objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProject_ServiceTypeDelayCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Project_ServiceTypeDelay] " + where;

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
		public static partial class Project_ServiceTypeDelay_Properties
		{
			public const string ProjectID = "ProjectID";
			public const string DelayHour = "DelayHour";
			public const string AddTime = "AddTime";
			public const string AddName = "AddName";
			public const string UpdateTime = "UpdateTime";
			public const string UpdateName = "UpdateName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ProjectID" , "int:"},
    			 {"DelayHour" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddName" , "string:"},
    			 {"UpdateTime" , "DateTime:"},
    			 {"UpdateName" , "string:"},
            };
		}
		#endregion
	}
}
