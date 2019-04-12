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
	/// This object represents the properties and methods of a CustomerServiceHuifang.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CustomerServiceHuifang 
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
		private DateTime _huiFangTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime HuiFangTime
		{
			[DebuggerStepThrough()]
			get { return this._huiFangTime; }
			set 
			{
				if (this._huiFangTime != value) 
				{
					this._huiFangTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("HuiFangTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _huiFangNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HuiFangNote
		{
			[DebuggerStepThrough()]
			get { return this._huiFangNote; }
			set 
			{
				if (this._huiFangNote != value) 
				{
					this._huiFangNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("HuiFangNote");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _chuLiRate = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChuLiRate
		{
			[DebuggerStepThrough()]
			get { return this._chuLiRate; }
			set 
			{
				if (this._chuLiRate != value) 
				{
					this._chuLiRate = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChuLiRate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _addUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AddUserID
		{
			[DebuggerStepThrough()]
			get { return this._addUserID; }
			set 
			{
				if (this._addUserID != value) 
				{
					this._addUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserID");
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
	[HuiFangTime] datetime,
	[HuiFangNote] ntext,
	[AddTime] datetime,
	[ChuLiRate] decimal(18, 2),
	[AddUserID] int
);

INSERT INTO [dbo].[CustomerServiceHuifang] (
	[CustomerServiceHuifang].[ServiceID],
	[CustomerServiceHuifang].[HuiFangTime],
	[CustomerServiceHuifang].[HuiFangNote],
	[CustomerServiceHuifang].[AddTime],
	[CustomerServiceHuifang].[ChuLiRate],
	[CustomerServiceHuifang].[AddUserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[HuiFangTime],
	INSERTED.[HuiFangNote],
	INSERTED.[AddTime],
	INSERTED.[ChuLiRate],
	INSERTED.[AddUserID]
into @table
VALUES ( 
	@ServiceID,
	@HuiFangTime,
	@HuiFangNote,
	@AddTime,
	@ChuLiRate,
	@AddUserID 
); 

SELECT 
	[ID],
	[ServiceID],
	[HuiFangTime],
	[HuiFangNote],
	[AddTime],
	[ChuLiRate],
	[AddUserID] 
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
	[HuiFangTime] datetime,
	[HuiFangNote] ntext,
	[AddTime] datetime,
	[ChuLiRate] decimal(18, 2),
	[AddUserID] int
);

UPDATE [dbo].[CustomerServiceHuifang] SET 
	[CustomerServiceHuifang].[ServiceID] = @ServiceID,
	[CustomerServiceHuifang].[HuiFangTime] = @HuiFangTime,
	[CustomerServiceHuifang].[HuiFangNote] = @HuiFangNote,
	[CustomerServiceHuifang].[AddTime] = @AddTime,
	[CustomerServiceHuifang].[ChuLiRate] = @ChuLiRate,
	[CustomerServiceHuifang].[AddUserID] = @AddUserID 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[HuiFangTime],
	INSERTED.[HuiFangNote],
	INSERTED.[AddTime],
	INSERTED.[ChuLiRate],
	INSERTED.[AddUserID]
into @table
WHERE 
	[CustomerServiceHuifang].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[HuiFangTime],
	[HuiFangNote],
	[AddTime],
	[ChuLiRate],
	[AddUserID] 
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
DELETE FROM [dbo].[CustomerServiceHuifang]
WHERE 
	[CustomerServiceHuifang].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CustomerServiceHuifang() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCustomerServiceHuifang(this.ID));
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
	[CustomerServiceHuifang].[ID],
	[CustomerServiceHuifang].[ServiceID],
	[CustomerServiceHuifang].[HuiFangTime],
	[CustomerServiceHuifang].[HuiFangNote],
	[CustomerServiceHuifang].[AddTime],
	[CustomerServiceHuifang].[ChuLiRate],
	[CustomerServiceHuifang].[AddUserID]
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
                return "CustomerServiceHuifang";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CustomerServiceHuifang into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="huiFangNote">huiFangNote</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chuLiRate">chuLiRate</param>
		/// <param name="addUserID">addUserID</param>
		public static void InsertCustomerServiceHuifang(int @serviceID, DateTime @huiFangTime, string @huiFangNote, DateTime @addTime, decimal @chuLiRate, int @addUserID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCustomerServiceHuifang(@serviceID, @huiFangTime, @huiFangNote, @addTime, @chuLiRate, @addUserID, helper);
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
		/// Insert a CustomerServiceHuifang into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="huiFangNote">huiFangNote</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chuLiRate">chuLiRate</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCustomerServiceHuifang(int @serviceID, DateTime @huiFangTime, string @huiFangNote, DateTime @addTime, decimal @chuLiRate, int @addUserID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[HuiFangTime] datetime,
	[HuiFangNote] ntext,
	[AddTime] datetime,
	[ChuLiRate] decimal(18, 2),
	[AddUserID] int
);

INSERT INTO [dbo].[CustomerServiceHuifang] (
	[CustomerServiceHuifang].[ServiceID],
	[CustomerServiceHuifang].[HuiFangTime],
	[CustomerServiceHuifang].[HuiFangNote],
	[CustomerServiceHuifang].[AddTime],
	[CustomerServiceHuifang].[ChuLiRate],
	[CustomerServiceHuifang].[AddUserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[HuiFangTime],
	INSERTED.[HuiFangNote],
	INSERTED.[AddTime],
	INSERTED.[ChuLiRate],
	INSERTED.[AddUserID]
into @table
VALUES ( 
	@ServiceID,
	@HuiFangTime,
	@HuiFangNote,
	@AddTime,
	@ChuLiRate,
	@AddUserID 
); 

SELECT 
	[ID],
	[ServiceID],
	[HuiFangTime],
	[HuiFangNote],
	[AddTime],
	[ChuLiRate],
	[AddUserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@HuiFangTime", EntityBase.GetDatabaseValue(@huiFangTime)));
			parameters.Add(new SqlParameter("@HuiFangNote", EntityBase.GetDatabaseValue(@huiFangNote)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ChuLiRate", EntityBase.GetDatabaseValue(@chuLiRate)));
			parameters.Add(new SqlParameter("@AddUserID", EntityBase.GetDatabaseValue(@addUserID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CustomerServiceHuifang into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="huiFangNote">huiFangNote</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chuLiRate">chuLiRate</param>
		/// <param name="addUserID">addUserID</param>
		public static void UpdateCustomerServiceHuifang(int @iD, int @serviceID, DateTime @huiFangTime, string @huiFangNote, DateTime @addTime, decimal @chuLiRate, int @addUserID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCustomerServiceHuifang(@iD, @serviceID, @huiFangTime, @huiFangNote, @addTime, @chuLiRate, @addUserID, helper);
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
		/// Updates a CustomerServiceHuifang into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="huiFangNote">huiFangNote</param>
		/// <param name="addTime">addTime</param>
		/// <param name="chuLiRate">chuLiRate</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCustomerServiceHuifang(int @iD, int @serviceID, DateTime @huiFangTime, string @huiFangNote, DateTime @addTime, decimal @chuLiRate, int @addUserID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[HuiFangTime] datetime,
	[HuiFangNote] ntext,
	[AddTime] datetime,
	[ChuLiRate] decimal(18, 2),
	[AddUserID] int
);

UPDATE [dbo].[CustomerServiceHuifang] SET 
	[CustomerServiceHuifang].[ServiceID] = @ServiceID,
	[CustomerServiceHuifang].[HuiFangTime] = @HuiFangTime,
	[CustomerServiceHuifang].[HuiFangNote] = @HuiFangNote,
	[CustomerServiceHuifang].[AddTime] = @AddTime,
	[CustomerServiceHuifang].[ChuLiRate] = @ChuLiRate,
	[CustomerServiceHuifang].[AddUserID] = @AddUserID 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[HuiFangTime],
	INSERTED.[HuiFangNote],
	INSERTED.[AddTime],
	INSERTED.[ChuLiRate],
	INSERTED.[AddUserID]
into @table
WHERE 
	[CustomerServiceHuifang].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[HuiFangTime],
	[HuiFangNote],
	[AddTime],
	[ChuLiRate],
	[AddUserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@HuiFangTime", EntityBase.GetDatabaseValue(@huiFangTime)));
			parameters.Add(new SqlParameter("@HuiFangNote", EntityBase.GetDatabaseValue(@huiFangNote)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ChuLiRate", EntityBase.GetDatabaseValue(@chuLiRate)));
			parameters.Add(new SqlParameter("@AddUserID", EntityBase.GetDatabaseValue(@addUserID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CustomerServiceHuifang from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCustomerServiceHuifang(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCustomerServiceHuifang(@iD, helper);
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
		/// Deletes a CustomerServiceHuifang from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCustomerServiceHuifang(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CustomerServiceHuifang]
WHERE 
	[CustomerServiceHuifang].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CustomerServiceHuifang object.
		/// </summary>
		/// <returns>The newly created CustomerServiceHuifang object.</returns>
		public static CustomerServiceHuifang CreateCustomerServiceHuifang()
		{
			return InitializeNew<CustomerServiceHuifang>();
		}
		
		/// <summary>
		/// Retrieve information for a CustomerServiceHuifang by a CustomerServiceHuifang's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CustomerServiceHuifang</returns>
		public static CustomerServiceHuifang GetCustomerServiceHuifang(int @iD)
		{
			string commandText = @"
SELECT 
" + CustomerServiceHuifang.SelectFieldList + @"
FROM [dbo].[CustomerServiceHuifang] 
WHERE 
	[CustomerServiceHuifang].[ID] = @ID " + CustomerServiceHuifang.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerServiceHuifang>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CustomerServiceHuifang by a CustomerServiceHuifang's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CustomerServiceHuifang</returns>
		public static CustomerServiceHuifang GetCustomerServiceHuifang(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CustomerServiceHuifang.SelectFieldList + @"
FROM [dbo].[CustomerServiceHuifang] 
WHERE 
	[CustomerServiceHuifang].[ID] = @ID " + CustomerServiceHuifang.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerServiceHuifang>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceHuifang objects.
		/// </summary>
		/// <returns>The retrieved collection of CustomerServiceHuifang objects.</returns>
		public static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs()
		{
			string commandText = @"
SELECT " + CustomerServiceHuifang.SelectFieldList + "FROM [dbo].[CustomerServiceHuifang] " + CustomerServiceHuifang.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CustomerServiceHuifang>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CustomerServiceHuifang objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerServiceHuifang objects.</returns>
        public static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerServiceHuifang>(SelectFieldList, "FROM [dbo].[CustomerServiceHuifang]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CustomerServiceHuifang objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerServiceHuifang objects.</returns>
        public static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerServiceHuifang>(SelectFieldList, "FROM [dbo].[CustomerServiceHuifang]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CustomerServiceHuifang objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CustomerServiceHuifang objects.</returns>
		protected static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerServiceHuifangs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceHuifang objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerServiceHuifang objects.</returns>
		protected static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerServiceHuifangs(string.Empty, where, parameters, CustomerServiceHuifang.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceHuifang objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerServiceHuifang objects.</returns>
		protected static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerServiceHuifangs(prefix, where, parameters, CustomerServiceHuifang.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceHuifang objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerServiceHuifang objects.</returns>
		protected static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerServiceHuifangs(string.Empty, where, parameters, CustomerServiceHuifang.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceHuifang objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerServiceHuifang objects.</returns>
		protected static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerServiceHuifangs(prefix, where, parameters, CustomerServiceHuifang.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceHuifang objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CustomerServiceHuifang objects.</returns>
		protected static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CustomerServiceHuifang.SelectFieldList + "FROM [dbo].[CustomerServiceHuifang] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CustomerServiceHuifang>(reader);
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
        protected static EntityList<CustomerServiceHuifang> GetCustomerServiceHuifangs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerServiceHuifang>(SelectFieldList, "FROM [dbo].[CustomerServiceHuifang] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CustomerServiceHuifang objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerServiceHuifangCount()
        {
            return GetCustomerServiceHuifangCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CustomerServiceHuifang objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerServiceHuifangCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CustomerServiceHuifang] " + where;

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
		public static partial class CustomerServiceHuifang_Properties
		{
			public const string ID = "ID";
			public const string ServiceID = "ServiceID";
			public const string HuiFangTime = "HuiFangTime";
			public const string HuiFangNote = "HuiFangNote";
			public const string AddTime = "AddTime";
			public const string ChuLiRate = "ChuLiRate";
			public const string AddUserID = "AddUserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"HuiFangTime" , "DateTime:"},
    			 {"HuiFangNote" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ChuLiRate" , "decimal:"},
    			 {"AddUserID" , "int:"},
            };
		}
		#endregion
	}
}
