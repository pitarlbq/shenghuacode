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
	/// This object represents the properties and methods of a CustomerService_Material.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CustomerService_Material 
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
		private int _customerServiceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CustomerServiceID
		{
			[DebuggerStepThrough()]
			get { return this._customerServiceID; }
			set 
			{
				if (this._customerServiceID != value) 
				{
					this._customerServiceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomerServiceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _materalName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string MateralName
		{
			[DebuggerStepThrough()]
			get { return this._materalName; }
			set 
			{
				if (this._materalName != value) 
				{
					this._materalName = value;
					this.IsDirty = true;	
					OnPropertyChanged("MateralName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _totalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TotalCount
		{
			[DebuggerStepThrough()]
			get { return this._totalCount; }
			set 
			{
				if (this._totalCount != value) 
				{
					this._totalCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _unitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal UnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._unitPrice; }
			set 
			{
				if (this._unitPrice != value) 
				{
					this._unitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("UnitPrice");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalCost = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalCost
		{
			[DebuggerStepThrough()]
			get { return this._totalCost; }
			set 
			{
				if (this._totalCost != value) 
				{
					this._totalCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _gUID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GUID
		{
			[DebuggerStepThrough()]
			get { return this._gUID; }
			set 
			{
				if (this._gUID != value) 
				{
					this._gUID = value;
					this.IsDirty = true;	
					OnPropertyChanged("GUID");
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
	[CustomerServiceID] int,
	[MateralName] nvarchar(100),
	[TotalCount] int,
	[UnitPrice] decimal(18, 2),
	[TotalCost] decimal(18, 2),
	[GUID] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[CustomerService_Material] (
	[CustomerService_Material].[CustomerServiceID],
	[CustomerService_Material].[MateralName],
	[CustomerService_Material].[TotalCount],
	[CustomerService_Material].[UnitPrice],
	[CustomerService_Material].[TotalCost],
	[CustomerService_Material].[GUID],
	[CustomerService_Material].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[CustomerServiceID],
	INSERTED.[MateralName],
	INSERTED.[TotalCount],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCost],
	INSERTED.[GUID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@CustomerServiceID,
	@MateralName,
	@TotalCount,
	@UnitPrice,
	@TotalCost,
	@GUID,
	@AddTime 
); 

SELECT 
	[ID],
	[CustomerServiceID],
	[MateralName],
	[TotalCount],
	[UnitPrice],
	[TotalCost],
	[GUID],
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
	[CustomerServiceID] int,
	[MateralName] nvarchar(100),
	[TotalCount] int,
	[UnitPrice] decimal(18, 2),
	[TotalCost] decimal(18, 2),
	[GUID] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[CustomerService_Material] SET 
	[CustomerService_Material].[CustomerServiceID] = @CustomerServiceID,
	[CustomerService_Material].[MateralName] = @MateralName,
	[CustomerService_Material].[TotalCount] = @TotalCount,
	[CustomerService_Material].[UnitPrice] = @UnitPrice,
	[CustomerService_Material].[TotalCost] = @TotalCost,
	[CustomerService_Material].[GUID] = @GUID,
	[CustomerService_Material].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[CustomerServiceID],
	INSERTED.[MateralName],
	INSERTED.[TotalCount],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCost],
	INSERTED.[GUID],
	INSERTED.[AddTime]
into @table
WHERE 
	[CustomerService_Material].[ID] = @ID

SELECT 
	[ID],
	[CustomerServiceID],
	[MateralName],
	[TotalCount],
	[UnitPrice],
	[TotalCost],
	[GUID],
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
DELETE FROM [dbo].[CustomerService_Material]
WHERE 
	[CustomerService_Material].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CustomerService_Material() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCustomerService_Material(this.ID));
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
	[CustomerService_Material].[ID],
	[CustomerService_Material].[CustomerServiceID],
	[CustomerService_Material].[MateralName],
	[CustomerService_Material].[TotalCount],
	[CustomerService_Material].[UnitPrice],
	[CustomerService_Material].[TotalCost],
	[CustomerService_Material].[GUID],
	[CustomerService_Material].[AddTime]
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
                return "CustomerService_Material";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CustomerService_Material into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="customerServiceID">customerServiceID</param>
		/// <param name="materalName">materalName</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="gUID">gUID</param>
		/// <param name="addTime">addTime</param>
		public static void InsertCustomerService_Material(int @customerServiceID, string @materalName, int @totalCount, decimal @unitPrice, decimal @totalCost, string @gUID, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCustomerService_Material(@customerServiceID, @materalName, @totalCount, @unitPrice, @totalCost, @gUID, @addTime, helper);
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
		/// Insert a CustomerService_Material into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="customerServiceID">customerServiceID</param>
		/// <param name="materalName">materalName</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="gUID">gUID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertCustomerService_Material(int @customerServiceID, string @materalName, int @totalCount, decimal @unitPrice, decimal @totalCost, string @gUID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CustomerServiceID] int,
	[MateralName] nvarchar(100),
	[TotalCount] int,
	[UnitPrice] decimal(18, 2),
	[TotalCost] decimal(18, 2),
	[GUID] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[CustomerService_Material] (
	[CustomerService_Material].[CustomerServiceID],
	[CustomerService_Material].[MateralName],
	[CustomerService_Material].[TotalCount],
	[CustomerService_Material].[UnitPrice],
	[CustomerService_Material].[TotalCost],
	[CustomerService_Material].[GUID],
	[CustomerService_Material].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[CustomerServiceID],
	INSERTED.[MateralName],
	INSERTED.[TotalCount],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCost],
	INSERTED.[GUID],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@CustomerServiceID,
	@MateralName,
	@TotalCount,
	@UnitPrice,
	@TotalCost,
	@GUID,
	@AddTime 
); 

SELECT 
	[ID],
	[CustomerServiceID],
	[MateralName],
	[TotalCount],
	[UnitPrice],
	[TotalCost],
	[GUID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CustomerServiceID", EntityBase.GetDatabaseValue(@customerServiceID)));
			parameters.Add(new SqlParameter("@MateralName", EntityBase.GetDatabaseValue(@materalName)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CustomerService_Material into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="customerServiceID">customerServiceID</param>
		/// <param name="materalName">materalName</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="gUID">gUID</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateCustomerService_Material(int @iD, int @customerServiceID, string @materalName, int @totalCount, decimal @unitPrice, decimal @totalCost, string @gUID, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCustomerService_Material(@iD, @customerServiceID, @materalName, @totalCount, @unitPrice, @totalCost, @gUID, @addTime, helper);
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
		/// Updates a CustomerService_Material into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="customerServiceID">customerServiceID</param>
		/// <param name="materalName">materalName</param>
		/// <param name="totalCount">totalCount</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="totalCost">totalCost</param>
		/// <param name="gUID">gUID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCustomerService_Material(int @iD, int @customerServiceID, string @materalName, int @totalCount, decimal @unitPrice, decimal @totalCost, string @gUID, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CustomerServiceID] int,
	[MateralName] nvarchar(100),
	[TotalCount] int,
	[UnitPrice] decimal(18, 2),
	[TotalCost] decimal(18, 2),
	[GUID] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[CustomerService_Material] SET 
	[CustomerService_Material].[CustomerServiceID] = @CustomerServiceID,
	[CustomerService_Material].[MateralName] = @MateralName,
	[CustomerService_Material].[TotalCount] = @TotalCount,
	[CustomerService_Material].[UnitPrice] = @UnitPrice,
	[CustomerService_Material].[TotalCost] = @TotalCost,
	[CustomerService_Material].[GUID] = @GUID,
	[CustomerService_Material].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[CustomerServiceID],
	INSERTED.[MateralName],
	INSERTED.[TotalCount],
	INSERTED.[UnitPrice],
	INSERTED.[TotalCost],
	INSERTED.[GUID],
	INSERTED.[AddTime]
into @table
WHERE 
	[CustomerService_Material].[ID] = @ID

SELECT 
	[ID],
	[CustomerServiceID],
	[MateralName],
	[TotalCount],
	[UnitPrice],
	[TotalCost],
	[GUID],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CustomerServiceID", EntityBase.GetDatabaseValue(@customerServiceID)));
			parameters.Add(new SqlParameter("@MateralName", EntityBase.GetDatabaseValue(@materalName)));
			parameters.Add(new SqlParameter("@TotalCount", EntityBase.GetDatabaseValue(@totalCount)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@TotalCost", EntityBase.GetDatabaseValue(@totalCost)));
			parameters.Add(new SqlParameter("@GUID", EntityBase.GetDatabaseValue(@gUID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CustomerService_Material from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCustomerService_Material(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCustomerService_Material(@iD, helper);
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
		/// Deletes a CustomerService_Material from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCustomerService_Material(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CustomerService_Material]
WHERE 
	[CustomerService_Material].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CustomerService_Material object.
		/// </summary>
		/// <returns>The newly created CustomerService_Material object.</returns>
		public static CustomerService_Material CreateCustomerService_Material()
		{
			return InitializeNew<CustomerService_Material>();
		}
		
		/// <summary>
		/// Retrieve information for a CustomerService_Material by a CustomerService_Material's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CustomerService_Material</returns>
		public static CustomerService_Material GetCustomerService_Material(int @iD)
		{
			string commandText = @"
SELECT 
" + CustomerService_Material.SelectFieldList + @"
FROM [dbo].[CustomerService_Material] 
WHERE 
	[CustomerService_Material].[ID] = @ID " + CustomerService_Material.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService_Material>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CustomerService_Material by a CustomerService_Material's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CustomerService_Material</returns>
		public static CustomerService_Material GetCustomerService_Material(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CustomerService_Material.SelectFieldList + @"
FROM [dbo].[CustomerService_Material] 
WHERE 
	[CustomerService_Material].[ID] = @ID " + CustomerService_Material.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService_Material>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Material objects.
		/// </summary>
		/// <returns>The retrieved collection of CustomerService_Material objects.</returns>
		public static EntityList<CustomerService_Material> GetCustomerService_Materials()
		{
			string commandText = @"
SELECT " + CustomerService_Material.SelectFieldList + "FROM [dbo].[CustomerService_Material] " + CustomerService_Material.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CustomerService_Material>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CustomerService_Material objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_Material objects.</returns>
        public static EntityList<CustomerService_Material> GetCustomerService_Materials(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Material>(SelectFieldList, "FROM [dbo].[CustomerService_Material]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CustomerService_Material objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_Material objects.</returns>
        public static EntityList<CustomerService_Material> GetCustomerService_Materials(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Material>(SelectFieldList, "FROM [dbo].[CustomerService_Material]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CustomerService_Material objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_Material objects.</returns>
		protected static EntityList<CustomerService_Material> GetCustomerService_Materials(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Materials(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Material objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Material objects.</returns>
		protected static EntityList<CustomerService_Material> GetCustomerService_Materials(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Materials(string.Empty, where, parameters, CustomerService_Material.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Material objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Material objects.</returns>
		protected static EntityList<CustomerService_Material> GetCustomerService_Materials(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Materials(prefix, where, parameters, CustomerService_Material.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Material objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Material objects.</returns>
		protected static EntityList<CustomerService_Material> GetCustomerService_Materials(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_Materials(string.Empty, where, parameters, CustomerService_Material.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Material objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Material objects.</returns>
		protected static EntityList<CustomerService_Material> GetCustomerService_Materials(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_Materials(prefix, where, parameters, CustomerService_Material.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Material objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_Material objects.</returns>
		protected static EntityList<CustomerService_Material> GetCustomerService_Materials(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CustomerService_Material.SelectFieldList + "FROM [dbo].[CustomerService_Material] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CustomerService_Material>(reader);
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
        protected static EntityList<CustomerService_Material> GetCustomerService_Materials(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Material>(SelectFieldList, "FROM [dbo].[CustomerService_Material] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CustomerService_Material objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_MaterialCount()
        {
            return GetCustomerService_MaterialCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CustomerService_Material objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_MaterialCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CustomerService_Material] " + where;

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
		public static partial class CustomerService_Material_Properties
		{
			public const string ID = "ID";
			public const string CustomerServiceID = "CustomerServiceID";
			public const string MateralName = "MateralName";
			public const string TotalCount = "TotalCount";
			public const string UnitPrice = "UnitPrice";
			public const string TotalCost = "TotalCost";
			public const string GUID = "GUID";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CustomerServiceID" , "int:"},
    			 {"MateralName" , "string:"},
    			 {"TotalCount" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"TotalCost" , "decimal:"},
    			 {"GUID" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
