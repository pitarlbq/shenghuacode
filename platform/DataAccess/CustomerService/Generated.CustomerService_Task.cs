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
	/// This object represents the properties and methods of a CustomerService_Task.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CustomerService_Task 
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
		private string _taskName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string TaskName
		{
			[DebuggerStepThrough()]
			get { return this._taskName; }
			set 
			{
				if (this._taskName != value) 
				{
					this._taskName = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskName");
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
		[DataObjectField(false, false, true)]
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
	[TaskName] nvarchar(100),
	[AddTime] datetime
);

INSERT INTO [dbo].[CustomerService_Task] (
	[CustomerService_Task].[TaskName],
	[CustomerService_Task].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[TaskName],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@TaskName,
	@AddTime 
); 

SELECT 
	[ID],
	[TaskName],
	[AddTime] 
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
	[TaskName] nvarchar(100),
	[AddTime] datetime
);

UPDATE [dbo].[CustomerService_Task] SET 
	[CustomerService_Task].[TaskName] = @TaskName,
	[CustomerService_Task].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[TaskName],
	INSERTED.[AddTime]
into @table
WHERE 
	[CustomerService_Task].[ID] = @ID

SELECT 
	[ID],
	[TaskName],
	[AddTime] 
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
DELETE FROM [dbo].[CustomerService_Task]
WHERE 
	[CustomerService_Task].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CustomerService_Task() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCustomerService_Task(this.ID));
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
	[CustomerService_Task].[ID],
	[CustomerService_Task].[TaskName],
	[CustomerService_Task].[AddTime]
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
                return "CustomerService_Task";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CustomerService_Task into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="taskName">taskName</param>
		/// <param name="addTime">addTime</param>
		public static void InsertCustomerService_Task(string @taskName, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCustomerService_Task(@taskName, @addTime, helper);
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
		/// Insert a CustomerService_Task into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="taskName">taskName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertCustomerService_Task(string @taskName, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TaskName] nvarchar(100),
	[AddTime] datetime
);

INSERT INTO [dbo].[CustomerService_Task] (
	[CustomerService_Task].[TaskName],
	[CustomerService_Task].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[TaskName],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@TaskName,
	@AddTime 
); 

SELECT 
	[ID],
	[TaskName],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TaskName", EntityBase.GetDatabaseValue(@taskName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CustomerService_Task into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="taskName">taskName</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateCustomerService_Task(int @iD, string @taskName, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCustomerService_Task(@iD, @taskName, @addTime, helper);
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
		/// Updates a CustomerService_Task into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="taskName">taskName</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCustomerService_Task(int @iD, string @taskName, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TaskName] nvarchar(100),
	[AddTime] datetime
);

UPDATE [dbo].[CustomerService_Task] SET 
	[CustomerService_Task].[TaskName] = @TaskName,
	[CustomerService_Task].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[TaskName],
	INSERTED.[AddTime]
into @table
WHERE 
	[CustomerService_Task].[ID] = @ID

SELECT 
	[ID],
	[TaskName],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@TaskName", EntityBase.GetDatabaseValue(@taskName)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CustomerService_Task from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCustomerService_Task(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCustomerService_Task(@iD, helper);
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
		/// Deletes a CustomerService_Task from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCustomerService_Task(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CustomerService_Task]
WHERE 
	[CustomerService_Task].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CustomerService_Task object.
		/// </summary>
		/// <returns>The newly created CustomerService_Task object.</returns>
		public static CustomerService_Task CreateCustomerService_Task()
		{
			return InitializeNew<CustomerService_Task>();
		}
		
		/// <summary>
		/// Retrieve information for a CustomerService_Task by a CustomerService_Task's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CustomerService_Task</returns>
		public static CustomerService_Task GetCustomerService_Task(int @iD)
		{
			string commandText = @"
SELECT 
" + CustomerService_Task.SelectFieldList + @"
FROM [dbo].[CustomerService_Task] 
WHERE 
	[CustomerService_Task].[ID] = @ID " + CustomerService_Task.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService_Task>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CustomerService_Task by a CustomerService_Task's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CustomerService_Task</returns>
		public static CustomerService_Task GetCustomerService_Task(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CustomerService_Task.SelectFieldList + @"
FROM [dbo].[CustomerService_Task] 
WHERE 
	[CustomerService_Task].[ID] = @ID " + CustomerService_Task.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService_Task>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Task objects.
		/// </summary>
		/// <returns>The retrieved collection of CustomerService_Task objects.</returns>
		public static EntityList<CustomerService_Task> GetCustomerService_Tasks()
		{
			string commandText = @"
SELECT " + CustomerService_Task.SelectFieldList + "FROM [dbo].[CustomerService_Task] " + CustomerService_Task.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CustomerService_Task>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CustomerService_Task objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_Task objects.</returns>
        public static EntityList<CustomerService_Task> GetCustomerService_Tasks(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Task>(SelectFieldList, "FROM [dbo].[CustomerService_Task]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CustomerService_Task objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_Task objects.</returns>
        public static EntityList<CustomerService_Task> GetCustomerService_Tasks(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Task>(SelectFieldList, "FROM [dbo].[CustomerService_Task]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CustomerService_Task objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_Task objects.</returns>
		protected static EntityList<CustomerService_Task> GetCustomerService_Tasks(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Tasks(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Task objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Task objects.</returns>
		protected static EntityList<CustomerService_Task> GetCustomerService_Tasks(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Tasks(string.Empty, where, parameters, CustomerService_Task.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Task objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Task objects.</returns>
		protected static EntityList<CustomerService_Task> GetCustomerService_Tasks(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Tasks(prefix, where, parameters, CustomerService_Task.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Task objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Task objects.</returns>
		protected static EntityList<CustomerService_Task> GetCustomerService_Tasks(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_Tasks(string.Empty, where, parameters, CustomerService_Task.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Task objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Task objects.</returns>
		protected static EntityList<CustomerService_Task> GetCustomerService_Tasks(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_Tasks(prefix, where, parameters, CustomerService_Task.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Task objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_Task objects.</returns>
		protected static EntityList<CustomerService_Task> GetCustomerService_Tasks(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CustomerService_Task.SelectFieldList + "FROM [dbo].[CustomerService_Task] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CustomerService_Task>(reader);
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
        protected static EntityList<CustomerService_Task> GetCustomerService_Tasks(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Task>(SelectFieldList, "FROM [dbo].[CustomerService_Task] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CustomerService_Task objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_TaskCount()
        {
            return GetCustomerService_TaskCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CustomerService_Task objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_TaskCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CustomerService_Task] " + where;

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
		public static partial class CustomerService_Task_Properties
		{
			public const string ID = "ID";
			public const string TaskName = "TaskName";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"TaskName" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
