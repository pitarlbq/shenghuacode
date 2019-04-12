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
	/// This object represents the properties and methods of a CustomerService_Return.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CustomerService_Return 
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
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private string _returnRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ReturnRemark
		{
			[DebuggerStepThrough()]
			get { return this._returnRemark; }
			set 
			{
				if (this._returnRemark != value) 
				{
					this._returnRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReturnRemark");
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
	[ServiceID] int,
	[UserID] int,
	[AddTime] datetime,
	[ReturnRemark] ntext
);

INSERT INTO [dbo].[CustomerService_Return] (
	[CustomerService_Return].[ServiceID],
	[CustomerService_Return].[UserID],
	[CustomerService_Return].[AddTime],
	[CustomerService_Return].[ReturnRemark]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[ReturnRemark]
into @table
VALUES ( 
	@ServiceID,
	@UserID,
	@AddTime,
	@ReturnRemark 
); 

SELECT 
	[ID],
	[ServiceID],
	[UserID],
	[AddTime],
	[ReturnRemark] 
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
	[ServiceID] int,
	[UserID] int,
	[AddTime] datetime,
	[ReturnRemark] ntext
);

UPDATE [dbo].[CustomerService_Return] SET 
	[CustomerService_Return].[ServiceID] = @ServiceID,
	[CustomerService_Return].[UserID] = @UserID,
	[CustomerService_Return].[AddTime] = @AddTime,
	[CustomerService_Return].[ReturnRemark] = @ReturnRemark 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[ReturnRemark]
into @table
WHERE 
	[CustomerService_Return].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[UserID],
	[AddTime],
	[ReturnRemark] 
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
DELETE FROM [dbo].[CustomerService_Return]
WHERE 
	[CustomerService_Return].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CustomerService_Return() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCustomerService_Return(this.ID));
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
	[CustomerService_Return].[ID],
	[CustomerService_Return].[ServiceID],
	[CustomerService_Return].[UserID],
	[CustomerService_Return].[AddTime],
	[CustomerService_Return].[ReturnRemark]
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
                return "CustomerService_Return";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CustomerService_Return into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="returnRemark">returnRemark</param>
		public static void InsertCustomerService_Return(int @serviceID, int @userID, DateTime @addTime, string @returnRemark)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCustomerService_Return(@serviceID, @userID, @addTime, @returnRemark, helper);
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
		/// Insert a CustomerService_Return into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="returnRemark">returnRemark</param>
		/// <param name="helper">helper</param>
		internal static void InsertCustomerService_Return(int @serviceID, int @userID, DateTime @addTime, string @returnRemark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[UserID] int,
	[AddTime] datetime,
	[ReturnRemark] ntext
);

INSERT INTO [dbo].[CustomerService_Return] (
	[CustomerService_Return].[ServiceID],
	[CustomerService_Return].[UserID],
	[CustomerService_Return].[AddTime],
	[CustomerService_Return].[ReturnRemark]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[ReturnRemark]
into @table
VALUES ( 
	@ServiceID,
	@UserID,
	@AddTime,
	@ReturnRemark 
); 

SELECT 
	[ID],
	[ServiceID],
	[UserID],
	[AddTime],
	[ReturnRemark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ReturnRemark", EntityBase.GetDatabaseValue(@returnRemark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CustomerService_Return into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="returnRemark">returnRemark</param>
		public static void UpdateCustomerService_Return(int @iD, int @serviceID, int @userID, DateTime @addTime, string @returnRemark)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCustomerService_Return(@iD, @serviceID, @userID, @addTime, @returnRemark, helper);
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
		/// Updates a CustomerService_Return into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="userID">userID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="returnRemark">returnRemark</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCustomerService_Return(int @iD, int @serviceID, int @userID, DateTime @addTime, string @returnRemark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[UserID] int,
	[AddTime] datetime,
	[ReturnRemark] ntext
);

UPDATE [dbo].[CustomerService_Return] SET 
	[CustomerService_Return].[ServiceID] = @ServiceID,
	[CustomerService_Return].[UserID] = @UserID,
	[CustomerService_Return].[AddTime] = @AddTime,
	[CustomerService_Return].[ReturnRemark] = @ReturnRemark 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[UserID],
	INSERTED.[AddTime],
	INSERTED.[ReturnRemark]
into @table
WHERE 
	[CustomerService_Return].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[UserID],
	[AddTime],
	[ReturnRemark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ReturnRemark", EntityBase.GetDatabaseValue(@returnRemark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CustomerService_Return from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCustomerService_Return(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCustomerService_Return(@iD, helper);
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
		/// Deletes a CustomerService_Return from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCustomerService_Return(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CustomerService_Return]
WHERE 
	[CustomerService_Return].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CustomerService_Return object.
		/// </summary>
		/// <returns>The newly created CustomerService_Return object.</returns>
		public static CustomerService_Return CreateCustomerService_Return()
		{
			return InitializeNew<CustomerService_Return>();
		}
		
		/// <summary>
		/// Retrieve information for a CustomerService_Return by a CustomerService_Return's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CustomerService_Return</returns>
		public static CustomerService_Return GetCustomerService_Return(int @iD)
		{
			string commandText = @"
SELECT 
" + CustomerService_Return.SelectFieldList + @"
FROM [dbo].[CustomerService_Return] 
WHERE 
	[CustomerService_Return].[ID] = @ID " + CustomerService_Return.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService_Return>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CustomerService_Return by a CustomerService_Return's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CustomerService_Return</returns>
		public static CustomerService_Return GetCustomerService_Return(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CustomerService_Return.SelectFieldList + @"
FROM [dbo].[CustomerService_Return] 
WHERE 
	[CustomerService_Return].[ID] = @ID " + CustomerService_Return.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService_Return>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Return objects.
		/// </summary>
		/// <returns>The retrieved collection of CustomerService_Return objects.</returns>
		public static EntityList<CustomerService_Return> GetCustomerService_Returns()
		{
			string commandText = @"
SELECT " + CustomerService_Return.SelectFieldList + "FROM [dbo].[CustomerService_Return] " + CustomerService_Return.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CustomerService_Return>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CustomerService_Return objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_Return objects.</returns>
        public static EntityList<CustomerService_Return> GetCustomerService_Returns(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Return>(SelectFieldList, "FROM [dbo].[CustomerService_Return]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CustomerService_Return objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_Return objects.</returns>
        public static EntityList<CustomerService_Return> GetCustomerService_Returns(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Return>(SelectFieldList, "FROM [dbo].[CustomerService_Return]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CustomerService_Return objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_Return objects.</returns>
		protected static EntityList<CustomerService_Return> GetCustomerService_Returns(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Returns(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Return objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Return objects.</returns>
		protected static EntityList<CustomerService_Return> GetCustomerService_Returns(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Returns(string.Empty, where, parameters, CustomerService_Return.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Return objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Return objects.</returns>
		protected static EntityList<CustomerService_Return> GetCustomerService_Returns(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Returns(prefix, where, parameters, CustomerService_Return.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Return objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Return objects.</returns>
		protected static EntityList<CustomerService_Return> GetCustomerService_Returns(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_Returns(string.Empty, where, parameters, CustomerService_Return.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Return objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Return objects.</returns>
		protected static EntityList<CustomerService_Return> GetCustomerService_Returns(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_Returns(prefix, where, parameters, CustomerService_Return.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Return objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_Return objects.</returns>
		protected static EntityList<CustomerService_Return> GetCustomerService_Returns(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CustomerService_Return.SelectFieldList + "FROM [dbo].[CustomerService_Return] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CustomerService_Return>(reader);
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
        protected static EntityList<CustomerService_Return> GetCustomerService_Returns(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Return>(SelectFieldList, "FROM [dbo].[CustomerService_Return] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CustomerService_Return objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_ReturnCount()
        {
            return GetCustomerService_ReturnCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CustomerService_Return objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_ReturnCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CustomerService_Return] " + where;

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
		public static partial class CustomerService_Return_Properties
		{
			public const string ID = "ID";
			public const string ServiceID = "ServiceID";
			public const string UserID = "UserID";
			public const string AddTime = "AddTime";
			public const string ReturnRemark = "ReturnRemark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ReturnRemark" , "string:"},
            };
		}
		#endregion
	}
}
