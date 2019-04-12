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
	/// This object represents the properties and methods of a CKProudctInDetail.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKProudctInDetail 
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
			set 
			{
				if (this._inSummaryID != value) 
				{
					this._inSummaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("InSummaryID");
				}
			}
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
			set 
			{
				if (this._productID != value) 
				{
					this._productID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductID");
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
			set 
			{
				if (this._inTotalCount != value) 
				{
					this._inTotalCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("InTotalCount");
				}
			}
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
			set 
			{
				if (this._inTotalPrice != value) 
				{
					this._inTotalPrice = value;
					this.IsDirty = true;	
					OnPropertyChanged("InTotalPrice");
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
		private string _sysProductOrderNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SysProductOrderNumber
		{
			[DebuggerStepThrough()]
			get { return this._sysProductOrderNumber; }
			set 
			{
				if (this._sysProductOrderNumber != value) 
				{
					this._sysProductOrderNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("SysProductOrderNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Remark
		{
			[DebuggerStepThrough()]
			get { return this._remark; }
			set 
			{
				if (this._remark != value) 
				{
					this._remark = value;
					this.IsDirty = true;	
					OnPropertyChanged("Remark");
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
	[InSummaryID] int,
	[ProductID] int,
	[UnitPrice] decimal(18, 2),
	[InTotalCount] int,
	[InTotalPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ServiceID] int,
	[SysProductOrderNumber] nvarchar(100),
	[Remark] ntext
);

INSERT INTO [dbo].[CKProudctInDetail] (
	[CKProudctInDetail].[InSummaryID],
	[CKProudctInDetail].[ProductID],
	[CKProudctInDetail].[UnitPrice],
	[CKProudctInDetail].[InTotalCount],
	[CKProudctInDetail].[InTotalPrice],
	[CKProudctInDetail].[AddTime],
	[CKProudctInDetail].[AddMan],
	[CKProudctInDetail].[ServiceID],
	[CKProudctInDetail].[SysProductOrderNumber],
	[CKProudctInDetail].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[ProductID],
	INSERTED.[UnitPrice],
	INSERTED.[InTotalCount],
	INSERTED.[InTotalPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ServiceID],
	INSERTED.[SysProductOrderNumber],
	INSERTED.[Remark]
into @table
VALUES ( 
	@InSummaryID,
	@ProductID,
	@UnitPrice,
	@InTotalCount,
	@InTotalPrice,
	@AddTime,
	@AddMan,
	@ServiceID,
	@SysProductOrderNumber,
	@Remark 
); 

SELECT 
	[ID],
	[InSummaryID],
	[ProductID],
	[UnitPrice],
	[InTotalCount],
	[InTotalPrice],
	[AddTime],
	[AddMan],
	[ServiceID],
	[SysProductOrderNumber],
	[Remark] 
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
	[InSummaryID] int,
	[ProductID] int,
	[UnitPrice] decimal(18, 2),
	[InTotalCount] int,
	[InTotalPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ServiceID] int,
	[SysProductOrderNumber] nvarchar(100),
	[Remark] ntext
);

UPDATE [dbo].[CKProudctInDetail] SET 
	[CKProudctInDetail].[InSummaryID] = @InSummaryID,
	[CKProudctInDetail].[ProductID] = @ProductID,
	[CKProudctInDetail].[UnitPrice] = @UnitPrice,
	[CKProudctInDetail].[InTotalCount] = @InTotalCount,
	[CKProudctInDetail].[InTotalPrice] = @InTotalPrice,
	[CKProudctInDetail].[AddTime] = @AddTime,
	[CKProudctInDetail].[AddMan] = @AddMan,
	[CKProudctInDetail].[ServiceID] = @ServiceID,
	[CKProudctInDetail].[SysProductOrderNumber] = @SysProductOrderNumber,
	[CKProudctInDetail].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[ProductID],
	INSERTED.[UnitPrice],
	INSERTED.[InTotalCount],
	INSERTED.[InTotalPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ServiceID],
	INSERTED.[SysProductOrderNumber],
	INSERTED.[Remark]
into @table
WHERE 
	[CKProudctInDetail].[ID] = @ID

SELECT 
	[ID],
	[InSummaryID],
	[ProductID],
	[UnitPrice],
	[InTotalCount],
	[InTotalPrice],
	[AddTime],
	[AddMan],
	[ServiceID],
	[SysProductOrderNumber],
	[Remark] 
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
DELETE FROM [dbo].[CKProudctInDetail]
WHERE 
	[CKProudctInDetail].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKProudctInDetail() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKProudctInDetail(this.ID));
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
	[CKProudctInDetail].[ID],
	[CKProudctInDetail].[InSummaryID],
	[CKProudctInDetail].[ProductID],
	[CKProudctInDetail].[UnitPrice],
	[CKProudctInDetail].[InTotalCount],
	[CKProudctInDetail].[InTotalPrice],
	[CKProudctInDetail].[AddTime],
	[CKProudctInDetail].[AddMan],
	[CKProudctInDetail].[ServiceID],
	[CKProudctInDetail].[SysProductOrderNumber],
	[CKProudctInDetail].[Remark]
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
                return "CKProudctInDetail";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKProudctInDetail into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="inTotalCount">inTotalCount</param>
		/// <param name="inTotalPrice">inTotalPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="sysProductOrderNumber">sysProductOrderNumber</param>
		/// <param name="remark">remark</param>
		public static void InsertCKProudctInDetail(int @inSummaryID, int @productID, decimal @unitPrice, int @inTotalCount, decimal @inTotalPrice, DateTime @addTime, string @addMan, int @serviceID, string @sysProductOrderNumber, string @remark)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKProudctInDetail(@inSummaryID, @productID, @unitPrice, @inTotalCount, @inTotalPrice, @addTime, @addMan, @serviceID, @sysProductOrderNumber, @remark, helper);
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
		/// Insert a CKProudctInDetail into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="inTotalCount">inTotalCount</param>
		/// <param name="inTotalPrice">inTotalPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="sysProductOrderNumber">sysProductOrderNumber</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKProudctInDetail(int @inSummaryID, int @productID, decimal @unitPrice, int @inTotalCount, decimal @inTotalPrice, DateTime @addTime, string @addMan, int @serviceID, string @sysProductOrderNumber, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InSummaryID] int,
	[ProductID] int,
	[UnitPrice] decimal(18, 2),
	[InTotalCount] int,
	[InTotalPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ServiceID] int,
	[SysProductOrderNumber] nvarchar(100),
	[Remark] ntext
);

INSERT INTO [dbo].[CKProudctInDetail] (
	[CKProudctInDetail].[InSummaryID],
	[CKProudctInDetail].[ProductID],
	[CKProudctInDetail].[UnitPrice],
	[CKProudctInDetail].[InTotalCount],
	[CKProudctInDetail].[InTotalPrice],
	[CKProudctInDetail].[AddTime],
	[CKProudctInDetail].[AddMan],
	[CKProudctInDetail].[ServiceID],
	[CKProudctInDetail].[SysProductOrderNumber],
	[CKProudctInDetail].[Remark]
) 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[ProductID],
	INSERTED.[UnitPrice],
	INSERTED.[InTotalCount],
	INSERTED.[InTotalPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ServiceID],
	INSERTED.[SysProductOrderNumber],
	INSERTED.[Remark]
into @table
VALUES ( 
	@InSummaryID,
	@ProductID,
	@UnitPrice,
	@InTotalCount,
	@InTotalPrice,
	@AddTime,
	@AddMan,
	@ServiceID,
	@SysProductOrderNumber,
	@Remark 
); 

SELECT 
	[ID],
	[InSummaryID],
	[ProductID],
	[UnitPrice],
	[InTotalCount],
	[InTotalPrice],
	[AddTime],
	[AddMan],
	[ServiceID],
	[SysProductOrderNumber],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@InSummaryID", EntityBase.GetDatabaseValue(@inSummaryID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@InTotalCount", EntityBase.GetDatabaseValue(@inTotalCount)));
			parameters.Add(new SqlParameter("@InTotalPrice", EntityBase.GetDatabaseValue(@inTotalPrice)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@SysProductOrderNumber", EntityBase.GetDatabaseValue(@sysProductOrderNumber)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKProudctInDetail into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="inTotalCount">inTotalCount</param>
		/// <param name="inTotalPrice">inTotalPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="sysProductOrderNumber">sysProductOrderNumber</param>
		/// <param name="remark">remark</param>
		public static void UpdateCKProudctInDetail(int @iD, int @inSummaryID, int @productID, decimal @unitPrice, int @inTotalCount, decimal @inTotalPrice, DateTime @addTime, string @addMan, int @serviceID, string @sysProductOrderNumber, string @remark)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKProudctInDetail(@iD, @inSummaryID, @productID, @unitPrice, @inTotalCount, @inTotalPrice, @addTime, @addMan, @serviceID, @sysProductOrderNumber, @remark, helper);
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
		/// Updates a CKProudctInDetail into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="inSummaryID">inSummaryID</param>
		/// <param name="productID">productID</param>
		/// <param name="unitPrice">unitPrice</param>
		/// <param name="inTotalCount">inTotalCount</param>
		/// <param name="inTotalPrice">inTotalPrice</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="sysProductOrderNumber">sysProductOrderNumber</param>
		/// <param name="remark">remark</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKProudctInDetail(int @iD, int @inSummaryID, int @productID, decimal @unitPrice, int @inTotalCount, decimal @inTotalPrice, DateTime @addTime, string @addMan, int @serviceID, string @sysProductOrderNumber, string @remark, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[InSummaryID] int,
	[ProductID] int,
	[UnitPrice] decimal(18, 2),
	[InTotalCount] int,
	[InTotalPrice] decimal(18, 2),
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[ServiceID] int,
	[SysProductOrderNumber] nvarchar(100),
	[Remark] ntext
);

UPDATE [dbo].[CKProudctInDetail] SET 
	[CKProudctInDetail].[InSummaryID] = @InSummaryID,
	[CKProudctInDetail].[ProductID] = @ProductID,
	[CKProudctInDetail].[UnitPrice] = @UnitPrice,
	[CKProudctInDetail].[InTotalCount] = @InTotalCount,
	[CKProudctInDetail].[InTotalPrice] = @InTotalPrice,
	[CKProudctInDetail].[AddTime] = @AddTime,
	[CKProudctInDetail].[AddMan] = @AddMan,
	[CKProudctInDetail].[ServiceID] = @ServiceID,
	[CKProudctInDetail].[SysProductOrderNumber] = @SysProductOrderNumber,
	[CKProudctInDetail].[Remark] = @Remark 
output 
	INSERTED.[ID],
	INSERTED.[InSummaryID],
	INSERTED.[ProductID],
	INSERTED.[UnitPrice],
	INSERTED.[InTotalCount],
	INSERTED.[InTotalPrice],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[ServiceID],
	INSERTED.[SysProductOrderNumber],
	INSERTED.[Remark]
into @table
WHERE 
	[CKProudctInDetail].[ID] = @ID

SELECT 
	[ID],
	[InSummaryID],
	[ProductID],
	[UnitPrice],
	[InTotalCount],
	[InTotalPrice],
	[AddTime],
	[AddMan],
	[ServiceID],
	[SysProductOrderNumber],
	[Remark] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@InSummaryID", EntityBase.GetDatabaseValue(@inSummaryID)));
			parameters.Add(new SqlParameter("@ProductID", EntityBase.GetDatabaseValue(@productID)));
			parameters.Add(new SqlParameter("@UnitPrice", EntityBase.GetDatabaseValue(@unitPrice)));
			parameters.Add(new SqlParameter("@InTotalCount", EntityBase.GetDatabaseValue(@inTotalCount)));
			parameters.Add(new SqlParameter("@InTotalPrice", EntityBase.GetDatabaseValue(@inTotalPrice)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@SysProductOrderNumber", EntityBase.GetDatabaseValue(@sysProductOrderNumber)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKProudctInDetail from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKProudctInDetail(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKProudctInDetail(@iD, helper);
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
		/// Deletes a CKProudctInDetail from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKProudctInDetail(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKProudctInDetail]
WHERE 
	[CKProudctInDetail].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKProudctInDetail object.
		/// </summary>
		/// <returns>The newly created CKProudctInDetail object.</returns>
		public static CKProudctInDetail CreateCKProudctInDetail()
		{
			return InitializeNew<CKProudctInDetail>();
		}
		
		/// <summary>
		/// Retrieve information for a CKProudctInDetail by a CKProudctInDetail's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKProudctInDetail</returns>
		public static CKProudctInDetail GetCKProudctInDetail(int @iD)
		{
			string commandText = @"
SELECT 
" + CKProudctInDetail.SelectFieldList + @"
FROM [dbo].[CKProudctInDetail] 
WHERE 
	[CKProudctInDetail].[ID] = @ID " + CKProudctInDetail.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProudctInDetail>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKProudctInDetail by a CKProudctInDetail's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKProudctInDetail</returns>
		public static CKProudctInDetail GetCKProudctInDetail(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKProudctInDetail.SelectFieldList + @"
FROM [dbo].[CKProudctInDetail] 
WHERE 
	[CKProudctInDetail].[ID] = @ID " + CKProudctInDetail.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProudctInDetail>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKProudctInDetail objects.
		/// </summary>
		/// <returns>The retrieved collection of CKProudctInDetail objects.</returns>
		public static EntityList<CKProudctInDetail> GetCKProudctInDetails()
		{
			string commandText = @"
SELECT " + CKProudctInDetail.SelectFieldList + "FROM [dbo].[CKProudctInDetail] " + CKProudctInDetail.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKProudctInDetail>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKProudctInDetail objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProudctInDetail objects.</returns>
        public static EntityList<CKProudctInDetail> GetCKProudctInDetails(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProudctInDetail>(SelectFieldList, "FROM [dbo].[CKProudctInDetail]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKProudctInDetail objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProudctInDetail objects.</returns>
        public static EntityList<CKProudctInDetail> GetCKProudctInDetails(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProudctInDetail>(SelectFieldList, "FROM [dbo].[CKProudctInDetail]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKProudctInDetail objects.</returns>
		protected static EntityList<CKProudctInDetail> GetCKProudctInDetails(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProudctInDetails(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProudctInDetail objects.</returns>
		protected static EntityList<CKProudctInDetail> GetCKProudctInDetails(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProudctInDetails(string.Empty, where, parameters, CKProudctInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProudctInDetail objects.</returns>
		protected static EntityList<CKProudctInDetail> GetCKProudctInDetails(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProudctInDetails(prefix, where, parameters, CKProudctInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProudctInDetail objects.</returns>
		protected static EntityList<CKProudctInDetail> GetCKProudctInDetails(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProudctInDetails(string.Empty, where, parameters, CKProudctInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProudctInDetail objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProudctInDetail objects.</returns>
		protected static EntityList<CKProudctInDetail> GetCKProudctInDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProudctInDetails(prefix, where, parameters, CKProudctInDetail.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProudctInDetail objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKProudctInDetail objects.</returns>
		protected static EntityList<CKProudctInDetail> GetCKProudctInDetails(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKProudctInDetail.SelectFieldList + "FROM [dbo].[CKProudctInDetail] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKProudctInDetail>(reader);
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
        protected static EntityList<CKProudctInDetail> GetCKProudctInDetails(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProudctInDetail>(SelectFieldList, "FROM [dbo].[CKProudctInDetail] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKProudctInDetail objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProudctInDetailCount()
        {
            return GetCKProudctInDetailCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKProudctInDetail objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProudctInDetailCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKProudctInDetail] " + where;

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
		public static partial class CKProudctInDetail_Properties
		{
			public const string ID = "ID";
			public const string InSummaryID = "InSummaryID";
			public const string ProductID = "ProductID";
			public const string UnitPrice = "UnitPrice";
			public const string InTotalCount = "InTotalCount";
			public const string InTotalPrice = "InTotalPrice";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string ServiceID = "ServiceID";
			public const string SysProductOrderNumber = "SysProductOrderNumber";
			public const string Remark = "Remark";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"InSummaryID" , "int:"},
    			 {"ProductID" , "int:"},
    			 {"UnitPrice" , "decimal:"},
    			 {"InTotalCount" , "int:"},
    			 {"InTotalPrice" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"ServiceID" , "int:"},
    			 {"SysProductOrderNumber" , "string:"},
    			 {"Remark" , "string:"},
            };
		}
		#endregion
	}
}
