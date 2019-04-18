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
	/// This object represents the properties and methods of a CKProduct.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKProduct 
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
		private int _categoryID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CategoryID
		{
			[DebuggerStepThrough()]
			get { return this._categoryID; }
			set 
			{
				if (this._categoryID != value) 
				{
					this._categoryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CategoryID");
				}
			}
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
			set 
			{
				if (this._productNumber != value) 
				{
					this._productNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductNumber");
				}
			}
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
			set 
			{
				if (this._productName != value) 
				{
					this._productName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductName");
				}
			}
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
			set 
			{
				if (this._unit != value) 
				{
					this._unit = value;
					this.IsDirty = true;	
					OnPropertyChanged("Unit");
				}
			}
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
			set 
			{
				if (this._modelNumber != value) 
				{
					this._modelNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModelNumber");
				}
			}
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
			set 
			{
				if (this._inventoryMin != value) 
				{
					this._inventoryMin = value;
					this.IsDirty = true;	
					OnPropertyChanged("InventoryMin");
				}
			}
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
			set 
			{
				if (this._inventoryMax != value) 
				{
					this._inventoryMax = value;
					this.IsDirty = true;	
					OnPropertyChanged("InventoryMax");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _productUnitPrice = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ProductUnitPrice
		{
			[DebuggerStepThrough()]
			get { return this._productUnitPrice; }
			set 
			{
				if (this._productUnitPrice != value) 
				{
					this._productUnitPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductUnitPrice");
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
	[CategoryID] int,
	[ProductNumber] nvarchar(100),
	[ProductName] nvarchar(100),
	[Unit] nvarchar(50),
	[ModelNumber] nvarchar(100),
	[InventoryMin] int,
	[InventoryMax] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ProductUnitPrice] decimal(18, 2)
);

INSERT INTO [dbo].[CKProduct] (
	[CKProduct].[CategoryID],
	[CKProduct].[ProductNumber],
	[CKProduct].[ProductName],
	[CKProduct].[Unit],
	[CKProduct].[ModelNumber],
	[CKProduct].[InventoryMin],
	[CKProduct].[InventoryMax],
	[CKProduct].[AddTime],
	[CKProduct].[AddMan],
	[CKProduct].[ProductUnitPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryID],
	INSERTED.[ProductNumber],
	INSERTED.[ProductName],
	INSERTED.[Unit],
	INSERTED.[ModelNumber],
	INSERTED.[InventoryMin],
	INSERTED.[InventoryMax],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ProductUnitPrice]
into @table
VALUES ( 
	@CategoryID,
	@ProductNumber,
	@ProductName,
	@Unit,
	@ModelNumber,
	@InventoryMin,
	@InventoryMax,
	@AddTime,
	@AddMan,
	@ProductUnitPrice 
); 

SELECT 
	[ID],
	[CategoryID],
	[ProductNumber],
	[ProductName],
	[Unit],
	[ModelNumber],
	[InventoryMin],
	[InventoryMax],
	[AddTime],
	[AddMan],
	[ProductUnitPrice] 
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
	[CategoryID] int,
	[ProductNumber] nvarchar(100),
	[ProductName] nvarchar(100),
	[Unit] nvarchar(50),
	[ModelNumber] nvarchar(100),
	[InventoryMin] int,
	[InventoryMax] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ProductUnitPrice] decimal(18, 2)
);

UPDATE [dbo].[CKProduct] SET 
	[CKProduct].[CategoryID] = @CategoryID,
	[CKProduct].[ProductNumber] = @ProductNumber,
	[CKProduct].[ProductName] = @ProductName,
	[CKProduct].[Unit] = @Unit,
	[CKProduct].[ModelNumber] = @ModelNumber,
	[CKProduct].[InventoryMin] = @InventoryMin,
	[CKProduct].[InventoryMax] = @InventoryMax,
	[CKProduct].[AddTime] = @AddTime,
	[CKProduct].[AddMan] = @AddMan,
	[CKProduct].[ProductUnitPrice] = @ProductUnitPrice 
output 
	INSERTED.[ID],
	INSERTED.[CategoryID],
	INSERTED.[ProductNumber],
	INSERTED.[ProductName],
	INSERTED.[Unit],
	INSERTED.[ModelNumber],
	INSERTED.[InventoryMin],
	INSERTED.[InventoryMax],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ProductUnitPrice]
into @table
WHERE 
	[CKProduct].[ID] = @ID

SELECT 
	[ID],
	[CategoryID],
	[ProductNumber],
	[ProductName],
	[Unit],
	[ModelNumber],
	[InventoryMin],
	[InventoryMax],
	[AddTime],
	[AddMan],
	[ProductUnitPrice] 
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
DELETE FROM [dbo].[CKProduct]
WHERE 
	[CKProduct].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKProduct() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKProduct(this.ID));
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
	[CKProduct].[ID],
	[CKProduct].[CategoryID],
	[CKProduct].[ProductNumber],
	[CKProduct].[ProductName],
	[CKProduct].[Unit],
	[CKProduct].[ModelNumber],
	[CKProduct].[InventoryMin],
	[CKProduct].[InventoryMax],
	[CKProduct].[AddTime],
	[CKProduct].[AddMan],
	[CKProduct].[ProductUnitPrice]
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
                return "CKProduct";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKProduct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryID">categoryID</param>
		/// <param name="productNumber">productNumber</param>
		/// <param name="productName">productName</param>
		/// <param name="unit">unit</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="inventoryMin">inventoryMin</param>
		/// <param name="inventoryMax">inventoryMax</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="productUnitPrice">productUnitPrice</param>
		public static void InsertCKProduct(int @categoryID, string @productNumber, string @productName, string @unit, string @modelNumber, int @inventoryMin, int @inventoryMax, DateTime @addTime, string @addMan, decimal @productUnitPrice)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKProduct(@categoryID, @productNumber, @productName, @unit, @modelNumber, @inventoryMin, @inventoryMax, @addTime, @addMan, @productUnitPrice, helper);
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
		/// Insert a CKProduct into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="categoryID">categoryID</param>
		/// <param name="productNumber">productNumber</param>
		/// <param name="productName">productName</param>
		/// <param name="unit">unit</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="inventoryMin">inventoryMin</param>
		/// <param name="inventoryMax">inventoryMax</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="productUnitPrice">productUnitPrice</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKProduct(int @categoryID, string @productNumber, string @productName, string @unit, string @modelNumber, int @inventoryMin, int @inventoryMax, DateTime @addTime, string @addMan, decimal @productUnitPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryID] int,
	[ProductNumber] nvarchar(100),
	[ProductName] nvarchar(100),
	[Unit] nvarchar(50),
	[ModelNumber] nvarchar(100),
	[InventoryMin] int,
	[InventoryMax] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ProductUnitPrice] decimal(18, 2)
);

INSERT INTO [dbo].[CKProduct] (
	[CKProduct].[CategoryID],
	[CKProduct].[ProductNumber],
	[CKProduct].[ProductName],
	[CKProduct].[Unit],
	[CKProduct].[ModelNumber],
	[CKProduct].[InventoryMin],
	[CKProduct].[InventoryMax],
	[CKProduct].[AddTime],
	[CKProduct].[AddMan],
	[CKProduct].[ProductUnitPrice]
) 
output 
	INSERTED.[ID],
	INSERTED.[CategoryID],
	INSERTED.[ProductNumber],
	INSERTED.[ProductName],
	INSERTED.[Unit],
	INSERTED.[ModelNumber],
	INSERTED.[InventoryMin],
	INSERTED.[InventoryMax],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ProductUnitPrice]
into @table
VALUES ( 
	@CategoryID,
	@ProductNumber,
	@ProductName,
	@Unit,
	@ModelNumber,
	@InventoryMin,
	@InventoryMax,
	@AddTime,
	@AddMan,
	@ProductUnitPrice 
); 

SELECT 
	[ID],
	[CategoryID],
	[ProductNumber],
	[ProductName],
	[Unit],
	[ModelNumber],
	[InventoryMin],
	[InventoryMax],
	[AddTime],
	[AddMan],
	[ProductUnitPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@ProductNumber", EntityBase.GetDatabaseValue(@productNumber)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@InventoryMin", EntityBase.GetDatabaseValue(@inventoryMin)));
			parameters.Add(new SqlParameter("@InventoryMax", EntityBase.GetDatabaseValue(@inventoryMax)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ProductUnitPrice", EntityBase.GetDatabaseValue(@productUnitPrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKProduct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="productNumber">productNumber</param>
		/// <param name="productName">productName</param>
		/// <param name="unit">unit</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="inventoryMin">inventoryMin</param>
		/// <param name="inventoryMax">inventoryMax</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="productUnitPrice">productUnitPrice</param>
		public static void UpdateCKProduct(int @iD, int @categoryID, string @productNumber, string @productName, string @unit, string @modelNumber, int @inventoryMin, int @inventoryMax, DateTime @addTime, string @addMan, decimal @productUnitPrice)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKProduct(@iD, @categoryID, @productNumber, @productName, @unit, @modelNumber, @inventoryMin, @inventoryMax, @addTime, @addMan, @productUnitPrice, helper);
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
		/// Updates a CKProduct into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="categoryID">categoryID</param>
		/// <param name="productNumber">productNumber</param>
		/// <param name="productName">productName</param>
		/// <param name="unit">unit</param>
		/// <param name="modelNumber">modelNumber</param>
		/// <param name="inventoryMin">inventoryMin</param>
		/// <param name="inventoryMax">inventoryMax</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="productUnitPrice">productUnitPrice</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKProduct(int @iD, int @categoryID, string @productNumber, string @productName, string @unit, string @modelNumber, int @inventoryMin, int @inventoryMax, DateTime @addTime, string @addMan, decimal @productUnitPrice, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CategoryID] int,
	[ProductNumber] nvarchar(100),
	[ProductName] nvarchar(100),
	[Unit] nvarchar(50),
	[ModelNumber] nvarchar(100),
	[InventoryMin] int,
	[InventoryMax] int,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ProductUnitPrice] decimal(18, 2)
);

UPDATE [dbo].[CKProduct] SET 
	[CKProduct].[CategoryID] = @CategoryID,
	[CKProduct].[ProductNumber] = @ProductNumber,
	[CKProduct].[ProductName] = @ProductName,
	[CKProduct].[Unit] = @Unit,
	[CKProduct].[ModelNumber] = @ModelNumber,
	[CKProduct].[InventoryMin] = @InventoryMin,
	[CKProduct].[InventoryMax] = @InventoryMax,
	[CKProduct].[AddTime] = @AddTime,
	[CKProduct].[AddMan] = @AddMan,
	[CKProduct].[ProductUnitPrice] = @ProductUnitPrice 
output 
	INSERTED.[ID],
	INSERTED.[CategoryID],
	INSERTED.[ProductNumber],
	INSERTED.[ProductName],
	INSERTED.[Unit],
	INSERTED.[ModelNumber],
	INSERTED.[InventoryMin],
	INSERTED.[InventoryMax],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ProductUnitPrice]
into @table
WHERE 
	[CKProduct].[ID] = @ID

SELECT 
	[ID],
	[CategoryID],
	[ProductNumber],
	[ProductName],
	[Unit],
	[ModelNumber],
	[InventoryMin],
	[InventoryMax],
	[AddTime],
	[AddMan],
	[ProductUnitPrice] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CategoryID", EntityBase.GetDatabaseValue(@categoryID)));
			parameters.Add(new SqlParameter("@ProductNumber", EntityBase.GetDatabaseValue(@productNumber)));
			parameters.Add(new SqlParameter("@ProductName", EntityBase.GetDatabaseValue(@productName)));
			parameters.Add(new SqlParameter("@Unit", EntityBase.GetDatabaseValue(@unit)));
			parameters.Add(new SqlParameter("@ModelNumber", EntityBase.GetDatabaseValue(@modelNumber)));
			parameters.Add(new SqlParameter("@InventoryMin", EntityBase.GetDatabaseValue(@inventoryMin)));
			parameters.Add(new SqlParameter("@InventoryMax", EntityBase.GetDatabaseValue(@inventoryMax)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ProductUnitPrice", EntityBase.GetDatabaseValue(@productUnitPrice)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKProduct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKProduct(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKProduct(@iD, helper);
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
		/// Deletes a CKProduct from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKProduct(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKProduct]
WHERE 
	[CKProduct].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKProduct object.
		/// </summary>
		/// <returns>The newly created CKProduct object.</returns>
		public static CKProduct CreateCKProduct()
		{
			return InitializeNew<CKProduct>();
		}
		
		/// <summary>
		/// Retrieve information for a CKProduct by a CKProduct's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKProduct</returns>
		public static CKProduct GetCKProduct(int @iD)
		{
			string commandText = @"
SELECT 
" + CKProduct.SelectFieldList + @"
FROM [dbo].[CKProduct] 
WHERE 
	[CKProduct].[ID] = @ID " + CKProduct.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProduct>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKProduct by a CKProduct's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKProduct</returns>
		public static CKProduct GetCKProduct(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKProduct.SelectFieldList + @"
FROM [dbo].[CKProduct] 
WHERE 
	[CKProduct].[ID] = @ID " + CKProduct.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProduct>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKProduct objects.
		/// </summary>
		/// <returns>The retrieved collection of CKProduct objects.</returns>
		public static EntityList<CKProduct> GetCKProducts()
		{
			string commandText = @"
SELECT " + CKProduct.SelectFieldList + "FROM [dbo].[CKProduct] " + CKProduct.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKProduct>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKProduct objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProduct objects.</returns>
        public static EntityList<CKProduct> GetCKProducts(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProduct>(SelectFieldList, "FROM [dbo].[CKProduct]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKProduct objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProduct objects.</returns>
        public static EntityList<CKProduct> GetCKProducts(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProduct>(SelectFieldList, "FROM [dbo].[CKProduct]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKProduct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKProduct objects.</returns>
		protected static EntityList<CKProduct> GetCKProducts(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProducts(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKProduct objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProduct objects.</returns>
		protected static EntityList<CKProduct> GetCKProducts(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProducts(string.Empty, where, parameters, CKProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProduct objects.</returns>
		protected static EntityList<CKProduct> GetCKProducts(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProducts(prefix, where, parameters, CKProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProduct objects.</returns>
		protected static EntityList<CKProduct> GetCKProducts(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProducts(string.Empty, where, parameters, CKProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProduct objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProduct objects.</returns>
		protected static EntityList<CKProduct> GetCKProducts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProducts(prefix, where, parameters, CKProduct.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProduct objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKProduct objects.</returns>
		protected static EntityList<CKProduct> GetCKProducts(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKProduct.SelectFieldList + "FROM [dbo].[CKProduct] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKProduct>(reader);
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
        protected static EntityList<CKProduct> GetCKProducts(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProduct>(SelectFieldList, "FROM [dbo].[CKProduct] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKProduct objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProductCount()
        {
            return GetCKProductCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKProduct objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProductCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKProduct] " + where;

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
		public static partial class CKProduct_Properties
		{
			public const string ID = "ID";
			public const string CategoryID = "CategoryID";
			public const string ProductNumber = "ProductNumber";
			public const string ProductName = "ProductName";
			public const string Unit = "Unit";
			public const string ModelNumber = "ModelNumber";
			public const string InventoryMin = "InventoryMin";
			public const string InventoryMax = "InventoryMax";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ProductUnitPrice = "ProductUnitPrice";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CategoryID" , "int:"},
    			 {"ProductNumber" , "string:"},
    			 {"ProductName" , "string:"},
    			 {"Unit" , "string:"},
    			 {"ModelNumber" , "string:"},
    			 {"InventoryMin" , "int:"},
    			 {"InventoryMax" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ProductUnitPrice" , "decimal:"},
            };
		}
		#endregion
	}
}
