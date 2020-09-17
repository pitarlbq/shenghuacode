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
	/// This object represents the properties and methods of a CustomerService_ManualTimeout.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ServiceID: {ServiceID}")]
	public partial class CustomerService_ManualTimeout 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int ServiceID
		{
			[DebuggerStepThrough()]
			get { return this._serviceID; }
			set 
			{
				if (this._serviceID != value) 
				{
					this._serviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isTimeOutInvalid = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsTimeOutInvalid
		{
			[DebuggerStepThrough()]
			get { return this._isTimeOutInvalid; }
			set 
			{
				if (this._isTimeOutInvalid != value) 
				{
					this._isTimeOutInvalid = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsTimeOutInvalid");
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddMan
		{
			[DebuggerStepThrough()]
			get { return this._addMan; }
			set 
			{
				if (this._addMan != value) 
				{
					this._addMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddMan");
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
	[ServiceID] int,
	[IsTimeOutInvalid] bit,
	[AddTime] datetime,
	[AddMan] nvarchar(50)
);

INSERT INTO [dbo].[CustomerService_ManualTimeout] (
	[CustomerService_ManualTimeout].[ServiceID],
	[CustomerService_ManualTimeout].[IsTimeOutInvalid],
	[CustomerService_ManualTimeout].[AddTime],
	[CustomerService_ManualTimeout].[AddMan]
) 
output 
	INSERTED.[ServiceID],
	INSERTED.[IsTimeOutInvalid],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@ServiceID,
	@IsTimeOutInvalid,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ServiceID],
	[IsTimeOutInvalid],
	[AddTime],
	[AddMan] 
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
	[ServiceID] int,
	[IsTimeOutInvalid] bit,
	[AddTime] datetime,
	[AddMan] nvarchar(50)
);

UPDATE [dbo].[CustomerService_ManualTimeout] SET 
	[CustomerService_ManualTimeout].[IsTimeOutInvalid] = @IsTimeOutInvalid,
	[CustomerService_ManualTimeout].[AddTime] = @AddTime,
	[CustomerService_ManualTimeout].[AddMan] = @AddMan 
output 
	INSERTED.[ServiceID],
	INSERTED.[IsTimeOutInvalid],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[CustomerService_ManualTimeout].[ServiceID] = @ServiceID

SELECT 
	[ServiceID],
	[IsTimeOutInvalid],
	[AddTime],
	[AddMan] 
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
DELETE FROM [dbo].[CustomerService_ManualTimeout]
WHERE 
	[CustomerService_ManualTimeout].[ServiceID] = @ServiceID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CustomerService_ManualTimeout() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCustomerService_ManualTimeout(this.ServiceID));
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
	[CustomerService_ManualTimeout].[ServiceID],
	[CustomerService_ManualTimeout].[IsTimeOutInvalid],
	[CustomerService_ManualTimeout].[AddTime],
	[CustomerService_ManualTimeout].[AddMan]
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
                return "CustomerService_ManualTimeout";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CustomerService_ManualTimeout into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="isTimeOutInvalid">isTimeOutInvalid</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void InsertCustomerService_ManualTimeout(int @serviceID, bool @isTimeOutInvalid, DateTime @addTime, string @addMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCustomerService_ManualTimeout(@serviceID, @isTimeOutInvalid, @addTime, @addMan, helper);
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
		/// Insert a CustomerService_ManualTimeout into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="isTimeOutInvalid">isTimeOutInvalid</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertCustomerService_ManualTimeout(int @serviceID, bool @isTimeOutInvalid, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ServiceID] int,
	[IsTimeOutInvalid] bit,
	[AddTime] datetime,
	[AddMan] nvarchar(50)
);

INSERT INTO [dbo].[CustomerService_ManualTimeout] (
	[CustomerService_ManualTimeout].[ServiceID],
	[CustomerService_ManualTimeout].[IsTimeOutInvalid],
	[CustomerService_ManualTimeout].[AddTime],
	[CustomerService_ManualTimeout].[AddMan]
) 
output 
	INSERTED.[ServiceID],
	INSERTED.[IsTimeOutInvalid],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@ServiceID,
	@IsTimeOutInvalid,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ServiceID],
	[IsTimeOutInvalid],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@IsTimeOutInvalid", @isTimeOutInvalid));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CustomerService_ManualTimeout into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="isTimeOutInvalid">isTimeOutInvalid</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void UpdateCustomerService_ManualTimeout(int @serviceID, bool @isTimeOutInvalid, DateTime @addTime, string @addMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCustomerService_ManualTimeout(@serviceID, @isTimeOutInvalid, @addTime, @addMan, helper);
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
		/// Updates a CustomerService_ManualTimeout into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="isTimeOutInvalid">isTimeOutInvalid</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCustomerService_ManualTimeout(int @serviceID, bool @isTimeOutInvalid, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ServiceID] int,
	[IsTimeOutInvalid] bit,
	[AddTime] datetime,
	[AddMan] nvarchar(50)
);

UPDATE [dbo].[CustomerService_ManualTimeout] SET 
	[CustomerService_ManualTimeout].[IsTimeOutInvalid] = @IsTimeOutInvalid,
	[CustomerService_ManualTimeout].[AddTime] = @AddTime,
	[CustomerService_ManualTimeout].[AddMan] = @AddMan 
output 
	INSERTED.[ServiceID],
	INSERTED.[IsTimeOutInvalid],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[CustomerService_ManualTimeout].[ServiceID] = @ServiceID

SELECT 
	[ServiceID],
	[IsTimeOutInvalid],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@IsTimeOutInvalid", @isTimeOutInvalid));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CustomerService_ManualTimeout from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		public static void DeleteCustomerService_ManualTimeout(int @serviceID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCustomerService_ManualTimeout(@serviceID, helper);
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
		/// Deletes a CustomerService_ManualTimeout from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCustomerService_ManualTimeout(int @serviceID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CustomerService_ManualTimeout]
WHERE 
	[CustomerService_ManualTimeout].[ServiceID] = @ServiceID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", @serviceID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CustomerService_ManualTimeout object.
		/// </summary>
		/// <returns>The newly created CustomerService_ManualTimeout object.</returns>
		public static CustomerService_ManualTimeout CreateCustomerService_ManualTimeout()
		{
			return InitializeNew<CustomerService_ManualTimeout>();
		}
		
		/// <summary>
		/// Retrieve information for a CustomerService_ManualTimeout by a CustomerService_ManualTimeout's unique identifier.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <returns>CustomerService_ManualTimeout</returns>
		public static CustomerService_ManualTimeout GetCustomerService_ManualTimeout(int @serviceID)
		{
			string commandText = @"
SELECT 
" + CustomerService_ManualTimeout.SelectFieldList + @"
FROM [dbo].[CustomerService_ManualTimeout] 
WHERE 
	[CustomerService_ManualTimeout].[ServiceID] = @ServiceID " + CustomerService_ManualTimeout.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", @serviceID));
			
			return GetOne<CustomerService_ManualTimeout>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CustomerService_ManualTimeout by a CustomerService_ManualTimeout's unique identifier.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CustomerService_ManualTimeout</returns>
		public static CustomerService_ManualTimeout GetCustomerService_ManualTimeout(int @serviceID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CustomerService_ManualTimeout.SelectFieldList + @"
FROM [dbo].[CustomerService_ManualTimeout] 
WHERE 
	[CustomerService_ManualTimeout].[ServiceID] = @ServiceID " + CustomerService_ManualTimeout.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", @serviceID));
			
			return GetOne<CustomerService_ManualTimeout>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_ManualTimeout objects.
		/// </summary>
		/// <returns>The retrieved collection of CustomerService_ManualTimeout objects.</returns>
		public static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts()
		{
			string commandText = @"
SELECT " + CustomerService_ManualTimeout.SelectFieldList + "FROM [dbo].[CustomerService_ManualTimeout] " + CustomerService_ManualTimeout.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CustomerService_ManualTimeout>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CustomerService_ManualTimeout objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_ManualTimeout objects.</returns>
        public static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_ManualTimeout>(SelectFieldList, "FROM [dbo].[CustomerService_ManualTimeout]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CustomerService_ManualTimeout objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_ManualTimeout objects.</returns>
        public static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_ManualTimeout>(SelectFieldList, "FROM [dbo].[CustomerService_ManualTimeout]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CustomerService_ManualTimeout objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_ManualTimeout objects.</returns>
		protected static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_ManualTimeouts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_ManualTimeout objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_ManualTimeout objects.</returns>
		protected static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_ManualTimeouts(string.Empty, where, parameters, CustomerService_ManualTimeout.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_ManualTimeout objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_ManualTimeout objects.</returns>
		protected static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_ManualTimeouts(prefix, where, parameters, CustomerService_ManualTimeout.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_ManualTimeout objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_ManualTimeout objects.</returns>
		protected static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_ManualTimeouts(string.Empty, where, parameters, CustomerService_ManualTimeout.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_ManualTimeout objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_ManualTimeout objects.</returns>
		protected static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_ManualTimeouts(prefix, where, parameters, CustomerService_ManualTimeout.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_ManualTimeout objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_ManualTimeout objects.</returns>
		protected static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CustomerService_ManualTimeout.SelectFieldList + "FROM [dbo].[CustomerService_ManualTimeout] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CustomerService_ManualTimeout>(reader);
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
        protected static EntityList<CustomerService_ManualTimeout> GetCustomerService_ManualTimeouts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_ManualTimeout>(SelectFieldList, "FROM [dbo].[CustomerService_ManualTimeout] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CustomerService_ManualTimeout objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_ManualTimeoutCount()
        {
            return GetCustomerService_ManualTimeoutCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CustomerService_ManualTimeout objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_ManualTimeoutCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CustomerService_ManualTimeout] " + where;

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
		public static partial class CustomerService_ManualTimeout_Properties
		{
			public const string ServiceID = "ServiceID";
			public const string IsTimeOutInvalid = "IsTimeOutInvalid";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ServiceID" , "int:"},
    			 {"IsTimeOutInvalid" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
            };
		}
		#endregion
	}
}
