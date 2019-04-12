using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Foresight.DataAccess.Framework;


namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a ViewCustomerServiceInDetail.
	/// </summary>
	[Serializable()]
	public partial class ViewCustomerServiceInDetail 
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
		[DataObjectField(false, false, false)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
            protected set { this._iD = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inSummaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int InSummaryID
		{
			[DebuggerStepThrough()]
			get { return this._inSummaryID; }
            protected set { this._inSummaryID = value;}
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
            protected set { this._unitPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inTotalCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InTotalCount
		{
			[DebuggerStepThrough()]
			get { return this._inTotalCount; }
            protected set { this._inTotalCount = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _inTotalPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal InTotalPrice
		{
			[DebuggerStepThrough()]
			get { return this._inTotalPrice; }
            protected set { this._inTotalPrice = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddMan
		{
			[DebuggerStepThrough()]
			get { return this._addMan; }
            protected set { this._addMan = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _productID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ProductID
		{
			[DebuggerStepThrough()]
			get { return this._productID; }
            protected set { this._productID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductName
		{
			[DebuggerStepThrough()]
			get { return this._productName; }
            protected set { this._productName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductNumber
		{
			[DebuggerStepThrough()]
			get { return this._productNumber; }
            protected set { this._productNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _unit = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Unit
		{
			[DebuggerStepThrough()]
			get { return this._unit; }
            protected set { this._unit = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _modelNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModelNumber
		{
			[DebuggerStepThrough()]
			get { return this._modelNumber; }
            protected set { this._modelNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inventoryMax = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InventoryMax
		{
			[DebuggerStepThrough()]
			get { return this._inventoryMax; }
            protected set { this._inventoryMax = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _inventoryMin = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int InventoryMin
		{
			[DebuggerStepThrough()]
			get { return this._inventoryMin; }
            protected set { this._inventoryMin = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceID
		{
			[DebuggerStepThrough()]
			get { return this._serviceID; }
            protected set { this._serviceID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceNumber
		{
			[DebuggerStepThrough()]
			get { return this._serviceNumber; }
            protected set { this._serviceNumber = value;}
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
            protected set { this._addTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _handelFee = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HandelFee
		{
			[DebuggerStepThrough()]
			get { return this._handelFee; }
            protected set { this._handelFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _totalFee = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal TotalFee
		{
			[DebuggerStepThrough()]
			get { return this._totalFee; }
            protected set { this._totalFee = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _warehouseName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string WarehouseName
		{
			[DebuggerStepThrough()]
			get { return this._warehouseName; }
            protected set { this._warehouseName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _categoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CategoryName
		{
			[DebuggerStepThrough()]
			get { return this._categoryName; }
            protected set { this._categoryName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _balanceStatus = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BalanceStatus
		{
			[DebuggerStepThrough()]
			get { return this._balanceStatus; }
            protected set { this._balanceStatus = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
            protected set { this._projectID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _cKProductOutSumaryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CKProductOutSumaryID
		{
			[DebuggerStepThrough()]
			get { return this._cKProductOutSumaryID; }
            protected set { this._cKProductOutSumaryID = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewCustomerServiceInDetail() { }
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
	[ViewCustomerServiceInDetail].[ID],
	[ViewCustomerServiceInDetail].[InSummaryID],
	[ViewCustomerServiceInDetail].[UnitPrice],
	[ViewCustomerServiceInDetail].[InTotalCount],
	[ViewCustomerServiceInDetail].[InTotalPrice],
	[ViewCustomerServiceInDetail].[AddMan],
	[ViewCustomerServiceInDetail].[ProductID],
	[ViewCustomerServiceInDetail].[ProductName],
	[ViewCustomerServiceInDetail].[ProductNumber],
	[ViewCustomerServiceInDetail].[Unit],
	[ViewCustomerServiceInDetail].[ModelNumber],
	[ViewCustomerServiceInDetail].[InventoryMax],
	[ViewCustomerServiceInDetail].[InventoryMin],
	[ViewCustomerServiceInDetail].[ServiceID],
	[ViewCustomerServiceInDetail].[ServiceNumber],
	[ViewCustomerServiceInDetail].[AddTime],
	[ViewCustomerServiceInDetail].[HandelFee],
	[ViewCustomerServiceInDetail].[TotalFee],
	[ViewCustomerServiceInDetail].[WarehouseName],
	[ViewCustomerServiceInDetail].[CategoryName],
	[ViewCustomerServiceInDetail].[BalanceStatus],
	[ViewCustomerServiceInDetail].[ProjectID],
	[ViewCustomerServiceInDetail].[CKProductOutSumaryID]
";
			}
		}
		
		
		/// <summary>
        /// View Name
        /// </summary>
        public static string ViewName
        {
            get
            {
                return "ViewCustomerServiceInDetail";
            }
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
		
		#region Static Methods
				
		/// <summary>
		/// Gets a collection ViewCustomerServiceInDetail objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewCustomerServiceInDetail objects.</returns>
		public static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails()
		{
			string commandText = @"
SELECT " + ViewCustomerServiceInDetail.SelectFieldList + "FROM [dbo].[ViewCustomerServiceInDetail] " + ViewCustomerServiceInDetail.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewCustomerServiceInDetail>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewCustomerServiceInDetail objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCustomerServiceInDetail objects.</returns>
        public static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCustomerServiceInDetail>(SelectFieldList, "FROM [dbo].[ViewCustomerServiceInDetail]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewCustomerServiceInDetail objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCustomerServiceInDetail objects.</returns>
        public static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCustomerServiceInDetail>(SelectFieldList, "FROM [dbo].[ViewCustomerServiceInDetail]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewCustomerServiceInDetail objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCustomerServiceInDetailCount()
        {
            return GetViewCustomerServiceInDetailCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewCustomerServiceInDetail objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCustomerServiceInDetailCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewCustomerServiceInDetail] " + where;

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
		
		/// <summary>
		/// Gets a collection ViewCustomerServiceInDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewCustomerServiceInDetail objects.</returns>
		protected static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCustomerServiceInDetails(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerServiceInDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerServiceInDetail objects.</returns>
		protected static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCustomerServiceInDetails(string.Empty, where, parameters, ViewCustomerServiceInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerServiceInDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerServiceInDetail objects.</returns>
		protected static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCustomerServiceInDetails(prefix, where, parameters, ViewCustomerServiceInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerServiceInDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerServiceInDetail objects.</returns>
		protected static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCustomerServiceInDetails(string.Empty, where, parameters, ViewCustomerServiceInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerServiceInDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerServiceInDetail objects.</returns>
		protected static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCustomerServiceInDetails(prefix, where, parameters, ViewCustomerServiceInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerServiceInDetail objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewCustomerServiceInDetail objects.</returns>
		protected static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewCustomerServiceInDetail.SelectFieldList + "FROM [dbo].[ViewCustomerServiceInDetail] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewCustomerServiceInDetail>(reader);
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
        protected static EntityList<ViewCustomerServiceInDetail> GetViewCustomerServiceInDetails(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCustomerServiceInDetail>(SelectFieldList, "FROM [dbo].[ViewCustomerServiceInDetail] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewCustomerServiceInDetailProperties
		{
			public const string ID = "ID";
			public const string InSummaryID = "InSummaryID";
			public const string UnitPrice = "UnitPrice";
			public const string InTotalCount = "InTotalCount";
			public const string InTotalPrice = "InTotalPrice";
			public const string AddMan = "AddMan";
			public const string ProductID = "ProductID";
			public const string ProductName = "ProductName";
			public const string ProductNumber = "ProductNumber";
			public const string Unit = "Unit";
			public const string ModelNumber = "ModelNumber";
			public const string InventoryMax = "InventoryMax";
			public const string InventoryMin = "InventoryMin";
			public const string ServiceID = "ServiceID";
			public const string ServiceNumber = "ServiceNumber";
			public const string AddTime = "AddTime";
			public const string HandelFee = "HandelFee";
			public const string TotalFee = "TotalFee";
			public const string WarehouseName = "WarehouseName";
			public const string CategoryName = "CategoryName";
			public const string BalanceStatus = "BalanceStatus";
			public const string ProjectID = "ProjectID";
			public const string CKProductOutSumaryID = "CKProductOutSumaryID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"InSummaryID" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"InTotalCount" , "int:"},
    			 {"InTotalPrice" , "decimal:"},
    			 {"AddMan" , "string:"},
    			 {"ProductID" , "int:"},
    			 {"ProductName" , "string:"},
    			 {"ProductNumber" , "string:"},
    			 {"Unit" , "string:"},
    			 {"ModelNumber" , "string:"},
    			 {"InventoryMax" , "int:"},
    			 {"InventoryMin" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"ServiceNumber" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"HandelFee" , "string:"},
    			 {"TotalFee" , "decimal:"},
    			 {"WarehouseName" , "string:"},
    			 {"CategoryName" , "string:"},
    			 {"BalanceStatus" , "string:"},
    			 {"ProjectID" , "int:"},
    			 {"CKProductOutSumaryID" , "int:"},
            };
		}
		#endregion
	}
}
