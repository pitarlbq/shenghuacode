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
	/// This object represents the properties and methods of a Mall_Coupon.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_Coupon 
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
		private string _couponName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string CouponName
		{
			[DebuggerStepThrough()]
			get { return this._couponName; }
			set 
			{
				if (this._couponName != value) 
				{
					this._couponName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CouponName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _summary = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Summary
		{
			[DebuggerStepThrough()]
			get { return this._summary; }
			set 
			{
				if (this._summary != value) 
				{
					this._summary = value;
					this.IsDirty = true;	
					OnPropertyChanged("Summary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _startTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime StartTime
		{
			[DebuggerStepThrough()]
			get { return this._startTime; }
			set 
			{
				if (this._startTime != value) 
				{
					this._startTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _endTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime EndTime
		{
			[DebuggerStepThrough()]
			get { return this._endTime; }
			set 
			{
				if (this._endTime != value) 
				{
					this._endTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _useNeedAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal UseNeedAmount
		{
			[DebuggerStepThrough()]
			get { return this._useNeedAmount; }
			set 
			{
				if (this._useNeedAmount != value) 
				{
					this._useNeedAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseNeedAmount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _reduceAmount = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public decimal ReduceAmount
		{
			[DebuggerStepThrough()]
			get { return this._reduceAmount; }
			set 
			{
				if (this._reduceAmount != value) 
				{
					this._reduceAmount = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReduceAmount");
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
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsActive
		{
			[DebuggerStepThrough()]
			get { return this._isActive; }
			set 
			{
				if (this._isActive != value) 
				{
					this._isActive = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsActive");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _useType = int.MinValue;
		/// <summary>
		/// 1-满减 2-折扣
		/// </summary>
        [Description("1-满减 2-折扣")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UseType
		{
			[DebuggerStepThrough()]
			get { return this._useType; }
			set 
			{
				if (this._useType != value) 
				{
					this._useType = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUser
		{
			[DebuggerStepThrough()]
			get { return this._addUser; }
			set 
			{
				if (this._addUser != value) 
				{
					this._addUser = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUser");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _amountType = int.MinValue;
		/// <summary>
		/// 1-固定金额 2-百分比
		/// </summary>
        [Description("1-固定金额 2-百分比")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AmountType
		{
			[DebuggerStepThrough()]
			get { return this._amountType; }
			set 
			{
				if (this._amountType != value) 
				{
					this._amountType = value;
					this.IsDirty = true;	
					OnPropertyChanged("AmountType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForWY = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForWY
		{
			[DebuggerStepThrough()]
			get { return this._isUseForWY; }
			set 
			{
				if (this._isUseForWY != value) 
				{
					this._isUseForWY = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForWY");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForProduct = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForProduct
		{
			[DebuggerStepThrough()]
			get { return this._isUseForProduct; }
			set 
			{
				if (this._isUseForProduct != value) 
				{
					this._isUseForProduct = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForProduct");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForService = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForService
		{
			[DebuggerStepThrough()]
			get { return this._isUseForService; }
			set 
			{
				if (this._isUseForService != value) 
				{
					this._isUseForService = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForService");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForALLProduct = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForALLProduct
		{
			[DebuggerStepThrough()]
			get { return this._isUseForALLProduct; }
			set 
			{
				if (this._isUseForALLProduct != value) 
				{
					this._isUseForALLProduct = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForALLProduct");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForALLService = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForALLService
		{
			[DebuggerStepThrough()]
			get { return this._isUseForALLService; }
			set 
			{
				if (this._isUseForALLService != value) 
				{
					this._isUseForALLService = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForALLService");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _couponType = int.MinValue;
		/// <summary>
		/// 1-单品券 2-店铺券 3-全场通用劵 4-品类优惠券 5-物业缴费优惠券 6-生日券
		/// </summary>
        [Description("1-单品券 2-店铺券 3-全场通用劵 4-品类优惠券 5-物业缴费优惠券 6-生日券")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CouponType
		{
			[DebuggerStepThrough()]
			get { return this._couponType; }
			set 
			{
				if (this._couponType != value) 
				{
					this._couponType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CouponType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForALLStore = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForALLStore
		{
			[DebuggerStepThrough()]
			get { return this._isUseForALLStore; }
			set 
			{
				if (this._isUseForALLStore != value) 
				{
					this._isUseForALLStore = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForALLStore");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUseForALLCategory = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUseForALLCategory
		{
			[DebuggerStepThrough()]
			get { return this._isUseForALLCategory; }
			set 
			{
				if (this._isUseForALLCategory != value) 
				{
					this._isUseForALLCategory = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUseForALLCategory");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _coverImage = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CoverImage
		{
			[DebuggerStepThrough()]
			get { return this._coverImage; }
			set 
			{
				if (this._coverImage != value) 
				{
					this._coverImage = value;
					this.IsDirty = true;	
					OnPropertyChanged("CoverImage");
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
	[CouponName] nvarchar(200),
	[Summary] ntext,
	[StartTime] datetime,
	[EndTime] datetime,
	[UseNeedAmount] decimal(18, 2),
	[ReduceAmount] decimal(18, 2),
	[AddTime] datetime,
	[IsActive] bit,
	[UseType] int,
	[AddUser] nvarchar(200),
	[AmountType] int,
	[IsUseForWY] bit,
	[IsUseForProduct] bit,
	[IsUseForService] bit,
	[IsUseForALLProduct] bit,
	[IsUseForALLService] bit,
	[CouponType] int,
	[IsUseForALLStore] bit,
	[IsUseForALLCategory] bit,
	[CoverImage] nvarchar(500)
);

INSERT INTO [dbo].[Mall_Coupon] (
	[Mall_Coupon].[CouponName],
	[Mall_Coupon].[Summary],
	[Mall_Coupon].[StartTime],
	[Mall_Coupon].[EndTime],
	[Mall_Coupon].[UseNeedAmount],
	[Mall_Coupon].[ReduceAmount],
	[Mall_Coupon].[AddTime],
	[Mall_Coupon].[IsActive],
	[Mall_Coupon].[UseType],
	[Mall_Coupon].[AddUser],
	[Mall_Coupon].[AmountType],
	[Mall_Coupon].[IsUseForWY],
	[Mall_Coupon].[IsUseForProduct],
	[Mall_Coupon].[IsUseForService],
	[Mall_Coupon].[IsUseForALLProduct],
	[Mall_Coupon].[IsUseForALLService],
	[Mall_Coupon].[CouponType],
	[Mall_Coupon].[IsUseForALLStore],
	[Mall_Coupon].[IsUseForALLCategory],
	[Mall_Coupon].[CoverImage]
) 
output 
	INSERTED.[ID],
	INSERTED.[CouponName],
	INSERTED.[Summary],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[UseNeedAmount],
	INSERTED.[ReduceAmount],
	INSERTED.[AddTime],
	INSERTED.[IsActive],
	INSERTED.[UseType],
	INSERTED.[AddUser],
	INSERTED.[AmountType],
	INSERTED.[IsUseForWY],
	INSERTED.[IsUseForProduct],
	INSERTED.[IsUseForService],
	INSERTED.[IsUseForALLProduct],
	INSERTED.[IsUseForALLService],
	INSERTED.[CouponType],
	INSERTED.[IsUseForALLStore],
	INSERTED.[IsUseForALLCategory],
	INSERTED.[CoverImage]
into @table
VALUES ( 
	@CouponName,
	@Summary,
	@StartTime,
	@EndTime,
	@UseNeedAmount,
	@ReduceAmount,
	@AddTime,
	@IsActive,
	@UseType,
	@AddUser,
	@AmountType,
	@IsUseForWY,
	@IsUseForProduct,
	@IsUseForService,
	@IsUseForALLProduct,
	@IsUseForALLService,
	@CouponType,
	@IsUseForALLStore,
	@IsUseForALLCategory,
	@CoverImage 
); 

SELECT 
	[ID],
	[CouponName],
	[Summary],
	[StartTime],
	[EndTime],
	[UseNeedAmount],
	[ReduceAmount],
	[AddTime],
	[IsActive],
	[UseType],
	[AddUser],
	[AmountType],
	[IsUseForWY],
	[IsUseForProduct],
	[IsUseForService],
	[IsUseForALLProduct],
	[IsUseForALLService],
	[CouponType],
	[IsUseForALLStore],
	[IsUseForALLCategory],
	[CoverImage] 
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
	[CouponName] nvarchar(200),
	[Summary] ntext,
	[StartTime] datetime,
	[EndTime] datetime,
	[UseNeedAmount] decimal(18, 2),
	[ReduceAmount] decimal(18, 2),
	[AddTime] datetime,
	[IsActive] bit,
	[UseType] int,
	[AddUser] nvarchar(200),
	[AmountType] int,
	[IsUseForWY] bit,
	[IsUseForProduct] bit,
	[IsUseForService] bit,
	[IsUseForALLProduct] bit,
	[IsUseForALLService] bit,
	[CouponType] int,
	[IsUseForALLStore] bit,
	[IsUseForALLCategory] bit,
	[CoverImage] nvarchar(500)
);

UPDATE [dbo].[Mall_Coupon] SET 
	[Mall_Coupon].[CouponName] = @CouponName,
	[Mall_Coupon].[Summary] = @Summary,
	[Mall_Coupon].[StartTime] = @StartTime,
	[Mall_Coupon].[EndTime] = @EndTime,
	[Mall_Coupon].[UseNeedAmount] = @UseNeedAmount,
	[Mall_Coupon].[ReduceAmount] = @ReduceAmount,
	[Mall_Coupon].[AddTime] = @AddTime,
	[Mall_Coupon].[IsActive] = @IsActive,
	[Mall_Coupon].[UseType] = @UseType,
	[Mall_Coupon].[AddUser] = @AddUser,
	[Mall_Coupon].[AmountType] = @AmountType,
	[Mall_Coupon].[IsUseForWY] = @IsUseForWY,
	[Mall_Coupon].[IsUseForProduct] = @IsUseForProduct,
	[Mall_Coupon].[IsUseForService] = @IsUseForService,
	[Mall_Coupon].[IsUseForALLProduct] = @IsUseForALLProduct,
	[Mall_Coupon].[IsUseForALLService] = @IsUseForALLService,
	[Mall_Coupon].[CouponType] = @CouponType,
	[Mall_Coupon].[IsUseForALLStore] = @IsUseForALLStore,
	[Mall_Coupon].[IsUseForALLCategory] = @IsUseForALLCategory,
	[Mall_Coupon].[CoverImage] = @CoverImage 
output 
	INSERTED.[ID],
	INSERTED.[CouponName],
	INSERTED.[Summary],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[UseNeedAmount],
	INSERTED.[ReduceAmount],
	INSERTED.[AddTime],
	INSERTED.[IsActive],
	INSERTED.[UseType],
	INSERTED.[AddUser],
	INSERTED.[AmountType],
	INSERTED.[IsUseForWY],
	INSERTED.[IsUseForProduct],
	INSERTED.[IsUseForService],
	INSERTED.[IsUseForALLProduct],
	INSERTED.[IsUseForALLService],
	INSERTED.[CouponType],
	INSERTED.[IsUseForALLStore],
	INSERTED.[IsUseForALLCategory],
	INSERTED.[CoverImage]
into @table
WHERE 
	[Mall_Coupon].[ID] = @ID

SELECT 
	[ID],
	[CouponName],
	[Summary],
	[StartTime],
	[EndTime],
	[UseNeedAmount],
	[ReduceAmount],
	[AddTime],
	[IsActive],
	[UseType],
	[AddUser],
	[AmountType],
	[IsUseForWY],
	[IsUseForProduct],
	[IsUseForService],
	[IsUseForALLProduct],
	[IsUseForALLService],
	[CouponType],
	[IsUseForALLStore],
	[IsUseForALLCategory],
	[CoverImage] 
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
DELETE FROM [dbo].[Mall_Coupon]
WHERE 
	[Mall_Coupon].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_Coupon() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_Coupon(this.ID));
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
	[Mall_Coupon].[ID],
	[Mall_Coupon].[CouponName],
	[Mall_Coupon].[Summary],
	[Mall_Coupon].[StartTime],
	[Mall_Coupon].[EndTime],
	[Mall_Coupon].[UseNeedAmount],
	[Mall_Coupon].[ReduceAmount],
	[Mall_Coupon].[AddTime],
	[Mall_Coupon].[IsActive],
	[Mall_Coupon].[UseType],
	[Mall_Coupon].[AddUser],
	[Mall_Coupon].[AmountType],
	[Mall_Coupon].[IsUseForWY],
	[Mall_Coupon].[IsUseForProduct],
	[Mall_Coupon].[IsUseForService],
	[Mall_Coupon].[IsUseForALLProduct],
	[Mall_Coupon].[IsUseForALLService],
	[Mall_Coupon].[CouponType],
	[Mall_Coupon].[IsUseForALLStore],
	[Mall_Coupon].[IsUseForALLCategory],
	[Mall_Coupon].[CoverImage]
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
                return "Mall_Coupon";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_Coupon into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="couponName">couponName</param>
		/// <param name="summary">summary</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="useNeedAmount">useNeedAmount</param>
		/// <param name="reduceAmount">reduceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="useType">useType</param>
		/// <param name="addUser">addUser</param>
		/// <param name="amountType">amountType</param>
		/// <param name="isUseForWY">isUseForWY</param>
		/// <param name="isUseForProduct">isUseForProduct</param>
		/// <param name="isUseForService">isUseForService</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="isUseForALLService">isUseForALLService</param>
		/// <param name="couponType">couponType</param>
		/// <param name="isUseForALLStore">isUseForALLStore</param>
		/// <param name="isUseForALLCategory">isUseForALLCategory</param>
		/// <param name="coverImage">coverImage</param>
		public static void InsertMall_Coupon(string @couponName, string @summary, DateTime @startTime, DateTime @endTime, decimal @useNeedAmount, decimal @reduceAmount, DateTime @addTime, bool @isActive, int @useType, string @addUser, int @amountType, bool @isUseForWY, bool @isUseForProduct, bool @isUseForService, bool @isUseForALLProduct, bool @isUseForALLService, int @couponType, bool @isUseForALLStore, bool @isUseForALLCategory, string @coverImage)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_Coupon(@couponName, @summary, @startTime, @endTime, @useNeedAmount, @reduceAmount, @addTime, @isActive, @useType, @addUser, @amountType, @isUseForWY, @isUseForProduct, @isUseForService, @isUseForALLProduct, @isUseForALLService, @couponType, @isUseForALLStore, @isUseForALLCategory, @coverImage, helper);
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
		/// Insert a Mall_Coupon into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="couponName">couponName</param>
		/// <param name="summary">summary</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="useNeedAmount">useNeedAmount</param>
		/// <param name="reduceAmount">reduceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="useType">useType</param>
		/// <param name="addUser">addUser</param>
		/// <param name="amountType">amountType</param>
		/// <param name="isUseForWY">isUseForWY</param>
		/// <param name="isUseForProduct">isUseForProduct</param>
		/// <param name="isUseForService">isUseForService</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="isUseForALLService">isUseForALLService</param>
		/// <param name="couponType">couponType</param>
		/// <param name="isUseForALLStore">isUseForALLStore</param>
		/// <param name="isUseForALLCategory">isUseForALLCategory</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_Coupon(string @couponName, string @summary, DateTime @startTime, DateTime @endTime, decimal @useNeedAmount, decimal @reduceAmount, DateTime @addTime, bool @isActive, int @useType, string @addUser, int @amountType, bool @isUseForWY, bool @isUseForProduct, bool @isUseForService, bool @isUseForALLProduct, bool @isUseForALLService, int @couponType, bool @isUseForALLStore, bool @isUseForALLCategory, string @coverImage, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CouponName] nvarchar(200),
	[Summary] ntext,
	[StartTime] datetime,
	[EndTime] datetime,
	[UseNeedAmount] decimal(18, 2),
	[ReduceAmount] decimal(18, 2),
	[AddTime] datetime,
	[IsActive] bit,
	[UseType] int,
	[AddUser] nvarchar(200),
	[AmountType] int,
	[IsUseForWY] bit,
	[IsUseForProduct] bit,
	[IsUseForService] bit,
	[IsUseForALLProduct] bit,
	[IsUseForALLService] bit,
	[CouponType] int,
	[IsUseForALLStore] bit,
	[IsUseForALLCategory] bit,
	[CoverImage] nvarchar(500)
);

INSERT INTO [dbo].[Mall_Coupon] (
	[Mall_Coupon].[CouponName],
	[Mall_Coupon].[Summary],
	[Mall_Coupon].[StartTime],
	[Mall_Coupon].[EndTime],
	[Mall_Coupon].[UseNeedAmount],
	[Mall_Coupon].[ReduceAmount],
	[Mall_Coupon].[AddTime],
	[Mall_Coupon].[IsActive],
	[Mall_Coupon].[UseType],
	[Mall_Coupon].[AddUser],
	[Mall_Coupon].[AmountType],
	[Mall_Coupon].[IsUseForWY],
	[Mall_Coupon].[IsUseForProduct],
	[Mall_Coupon].[IsUseForService],
	[Mall_Coupon].[IsUseForALLProduct],
	[Mall_Coupon].[IsUseForALLService],
	[Mall_Coupon].[CouponType],
	[Mall_Coupon].[IsUseForALLStore],
	[Mall_Coupon].[IsUseForALLCategory],
	[Mall_Coupon].[CoverImage]
) 
output 
	INSERTED.[ID],
	INSERTED.[CouponName],
	INSERTED.[Summary],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[UseNeedAmount],
	INSERTED.[ReduceAmount],
	INSERTED.[AddTime],
	INSERTED.[IsActive],
	INSERTED.[UseType],
	INSERTED.[AddUser],
	INSERTED.[AmountType],
	INSERTED.[IsUseForWY],
	INSERTED.[IsUseForProduct],
	INSERTED.[IsUseForService],
	INSERTED.[IsUseForALLProduct],
	INSERTED.[IsUseForALLService],
	INSERTED.[CouponType],
	INSERTED.[IsUseForALLStore],
	INSERTED.[IsUseForALLCategory],
	INSERTED.[CoverImage]
into @table
VALUES ( 
	@CouponName,
	@Summary,
	@StartTime,
	@EndTime,
	@UseNeedAmount,
	@ReduceAmount,
	@AddTime,
	@IsActive,
	@UseType,
	@AddUser,
	@AmountType,
	@IsUseForWY,
	@IsUseForProduct,
	@IsUseForService,
	@IsUseForALLProduct,
	@IsUseForALLService,
	@CouponType,
	@IsUseForALLStore,
	@IsUseForALLCategory,
	@CoverImage 
); 

SELECT 
	[ID],
	[CouponName],
	[Summary],
	[StartTime],
	[EndTime],
	[UseNeedAmount],
	[ReduceAmount],
	[AddTime],
	[IsActive],
	[UseType],
	[AddUser],
	[AmountType],
	[IsUseForWY],
	[IsUseForProduct],
	[IsUseForService],
	[IsUseForALLProduct],
	[IsUseForALLService],
	[CouponType],
	[IsUseForALLStore],
	[IsUseForALLCategory],
	[CoverImage] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CouponName", EntityBase.GetDatabaseValue(@couponName)));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@UseNeedAmount", EntityBase.GetDatabaseValue(@useNeedAmount)));
			parameters.Add(new SqlParameter("@ReduceAmount", EntityBase.GetDatabaseValue(@reduceAmount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@UseType", EntityBase.GetDatabaseValue(@useType)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@AmountType", EntityBase.GetDatabaseValue(@amountType)));
			parameters.Add(new SqlParameter("@IsUseForWY", @isUseForWY));
			parameters.Add(new SqlParameter("@IsUseForProduct", @isUseForProduct));
			parameters.Add(new SqlParameter("@IsUseForService", @isUseForService));
			parameters.Add(new SqlParameter("@IsUseForALLProduct", @isUseForALLProduct));
			parameters.Add(new SqlParameter("@IsUseForALLService", @isUseForALLService));
			parameters.Add(new SqlParameter("@CouponType", EntityBase.GetDatabaseValue(@couponType)));
			parameters.Add(new SqlParameter("@IsUseForALLStore", @isUseForALLStore));
			parameters.Add(new SqlParameter("@IsUseForALLCategory", @isUseForALLCategory));
			parameters.Add(new SqlParameter("@CoverImage", EntityBase.GetDatabaseValue(@coverImage)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_Coupon into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="couponName">couponName</param>
		/// <param name="summary">summary</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="useNeedAmount">useNeedAmount</param>
		/// <param name="reduceAmount">reduceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="useType">useType</param>
		/// <param name="addUser">addUser</param>
		/// <param name="amountType">amountType</param>
		/// <param name="isUseForWY">isUseForWY</param>
		/// <param name="isUseForProduct">isUseForProduct</param>
		/// <param name="isUseForService">isUseForService</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="isUseForALLService">isUseForALLService</param>
		/// <param name="couponType">couponType</param>
		/// <param name="isUseForALLStore">isUseForALLStore</param>
		/// <param name="isUseForALLCategory">isUseForALLCategory</param>
		/// <param name="coverImage">coverImage</param>
		public static void UpdateMall_Coupon(int @iD, string @couponName, string @summary, DateTime @startTime, DateTime @endTime, decimal @useNeedAmount, decimal @reduceAmount, DateTime @addTime, bool @isActive, int @useType, string @addUser, int @amountType, bool @isUseForWY, bool @isUseForProduct, bool @isUseForService, bool @isUseForALLProduct, bool @isUseForALLService, int @couponType, bool @isUseForALLStore, bool @isUseForALLCategory, string @coverImage)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_Coupon(@iD, @couponName, @summary, @startTime, @endTime, @useNeedAmount, @reduceAmount, @addTime, @isActive, @useType, @addUser, @amountType, @isUseForWY, @isUseForProduct, @isUseForService, @isUseForALLProduct, @isUseForALLService, @couponType, @isUseForALLStore, @isUseForALLCategory, @coverImage, helper);
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
		/// Updates a Mall_Coupon into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="couponName">couponName</param>
		/// <param name="summary">summary</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="useNeedAmount">useNeedAmount</param>
		/// <param name="reduceAmount">reduceAmount</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="useType">useType</param>
		/// <param name="addUser">addUser</param>
		/// <param name="amountType">amountType</param>
		/// <param name="isUseForWY">isUseForWY</param>
		/// <param name="isUseForProduct">isUseForProduct</param>
		/// <param name="isUseForService">isUseForService</param>
		/// <param name="isUseForALLProduct">isUseForALLProduct</param>
		/// <param name="isUseForALLService">isUseForALLService</param>
		/// <param name="couponType">couponType</param>
		/// <param name="isUseForALLStore">isUseForALLStore</param>
		/// <param name="isUseForALLCategory">isUseForALLCategory</param>
		/// <param name="coverImage">coverImage</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_Coupon(int @iD, string @couponName, string @summary, DateTime @startTime, DateTime @endTime, decimal @useNeedAmount, decimal @reduceAmount, DateTime @addTime, bool @isActive, int @useType, string @addUser, int @amountType, bool @isUseForWY, bool @isUseForProduct, bool @isUseForService, bool @isUseForALLProduct, bool @isUseForALLService, int @couponType, bool @isUseForALLStore, bool @isUseForALLCategory, string @coverImage, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CouponName] nvarchar(200),
	[Summary] ntext,
	[StartTime] datetime,
	[EndTime] datetime,
	[UseNeedAmount] decimal(18, 2),
	[ReduceAmount] decimal(18, 2),
	[AddTime] datetime,
	[IsActive] bit,
	[UseType] int,
	[AddUser] nvarchar(200),
	[AmountType] int,
	[IsUseForWY] bit,
	[IsUseForProduct] bit,
	[IsUseForService] bit,
	[IsUseForALLProduct] bit,
	[IsUseForALLService] bit,
	[CouponType] int,
	[IsUseForALLStore] bit,
	[IsUseForALLCategory] bit,
	[CoverImage] nvarchar(500)
);

UPDATE [dbo].[Mall_Coupon] SET 
	[Mall_Coupon].[CouponName] = @CouponName,
	[Mall_Coupon].[Summary] = @Summary,
	[Mall_Coupon].[StartTime] = @StartTime,
	[Mall_Coupon].[EndTime] = @EndTime,
	[Mall_Coupon].[UseNeedAmount] = @UseNeedAmount,
	[Mall_Coupon].[ReduceAmount] = @ReduceAmount,
	[Mall_Coupon].[AddTime] = @AddTime,
	[Mall_Coupon].[IsActive] = @IsActive,
	[Mall_Coupon].[UseType] = @UseType,
	[Mall_Coupon].[AddUser] = @AddUser,
	[Mall_Coupon].[AmountType] = @AmountType,
	[Mall_Coupon].[IsUseForWY] = @IsUseForWY,
	[Mall_Coupon].[IsUseForProduct] = @IsUseForProduct,
	[Mall_Coupon].[IsUseForService] = @IsUseForService,
	[Mall_Coupon].[IsUseForALLProduct] = @IsUseForALLProduct,
	[Mall_Coupon].[IsUseForALLService] = @IsUseForALLService,
	[Mall_Coupon].[CouponType] = @CouponType,
	[Mall_Coupon].[IsUseForALLStore] = @IsUseForALLStore,
	[Mall_Coupon].[IsUseForALLCategory] = @IsUseForALLCategory,
	[Mall_Coupon].[CoverImage] = @CoverImage 
output 
	INSERTED.[ID],
	INSERTED.[CouponName],
	INSERTED.[Summary],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[UseNeedAmount],
	INSERTED.[ReduceAmount],
	INSERTED.[AddTime],
	INSERTED.[IsActive],
	INSERTED.[UseType],
	INSERTED.[AddUser],
	INSERTED.[AmountType],
	INSERTED.[IsUseForWY],
	INSERTED.[IsUseForProduct],
	INSERTED.[IsUseForService],
	INSERTED.[IsUseForALLProduct],
	INSERTED.[IsUseForALLService],
	INSERTED.[CouponType],
	INSERTED.[IsUseForALLStore],
	INSERTED.[IsUseForALLCategory],
	INSERTED.[CoverImage]
into @table
WHERE 
	[Mall_Coupon].[ID] = @ID

SELECT 
	[ID],
	[CouponName],
	[Summary],
	[StartTime],
	[EndTime],
	[UseNeedAmount],
	[ReduceAmount],
	[AddTime],
	[IsActive],
	[UseType],
	[AddUser],
	[AmountType],
	[IsUseForWY],
	[IsUseForProduct],
	[IsUseForService],
	[IsUseForALLProduct],
	[IsUseForALLService],
	[CouponType],
	[IsUseForALLStore],
	[IsUseForALLCategory],
	[CoverImage] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CouponName", EntityBase.GetDatabaseValue(@couponName)));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@UseNeedAmount", EntityBase.GetDatabaseValue(@useNeedAmount)));
			parameters.Add(new SqlParameter("@ReduceAmount", EntityBase.GetDatabaseValue(@reduceAmount)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@UseType", EntityBase.GetDatabaseValue(@useType)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@AmountType", EntityBase.GetDatabaseValue(@amountType)));
			parameters.Add(new SqlParameter("@IsUseForWY", @isUseForWY));
			parameters.Add(new SqlParameter("@IsUseForProduct", @isUseForProduct));
			parameters.Add(new SqlParameter("@IsUseForService", @isUseForService));
			parameters.Add(new SqlParameter("@IsUseForALLProduct", @isUseForALLProduct));
			parameters.Add(new SqlParameter("@IsUseForALLService", @isUseForALLService));
			parameters.Add(new SqlParameter("@CouponType", EntityBase.GetDatabaseValue(@couponType)));
			parameters.Add(new SqlParameter("@IsUseForALLStore", @isUseForALLStore));
			parameters.Add(new SqlParameter("@IsUseForALLCategory", @isUseForALLCategory));
			parameters.Add(new SqlParameter("@CoverImage", EntityBase.GetDatabaseValue(@coverImage)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_Coupon from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_Coupon(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_Coupon(@iD, helper);
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
		/// Deletes a Mall_Coupon from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_Coupon(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_Coupon]
WHERE 
	[Mall_Coupon].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_Coupon object.
		/// </summary>
		/// <returns>The newly created Mall_Coupon object.</returns>
		public static Mall_Coupon CreateMall_Coupon()
		{
			return InitializeNew<Mall_Coupon>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_Coupon by a Mall_Coupon's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_Coupon</returns>
		public static Mall_Coupon GetMall_Coupon(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_Coupon.SelectFieldList + @"
FROM [dbo].[Mall_Coupon] 
WHERE 
	[Mall_Coupon].[ID] = @ID " + Mall_Coupon.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Coupon>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_Coupon by a Mall_Coupon's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_Coupon</returns>
		public static Mall_Coupon GetMall_Coupon(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_Coupon.SelectFieldList + @"
FROM [dbo].[Mall_Coupon] 
WHERE 
	[Mall_Coupon].[ID] = @ID " + Mall_Coupon.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_Coupon>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_Coupon objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_Coupon objects.</returns>
		public static EntityList<Mall_Coupon> GetMall_Coupons()
		{
			string commandText = @"
SELECT " + Mall_Coupon.SelectFieldList + "FROM [dbo].[Mall_Coupon] " + Mall_Coupon.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_Coupon>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_Coupon objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Coupon objects.</returns>
        public static EntityList<Mall_Coupon> GetMall_Coupons(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Coupon>(SelectFieldList, "FROM [dbo].[Mall_Coupon]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_Coupon objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_Coupon objects.</returns>
        public static EntityList<Mall_Coupon> GetMall_Coupons(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Coupon>(SelectFieldList, "FROM [dbo].[Mall_Coupon]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_Coupon objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Coupon objects.</returns>
		protected static EntityList<Mall_Coupon> GetMall_Coupons(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Coupons(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_Coupon objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Coupon objects.</returns>
		protected static EntityList<Mall_Coupon> GetMall_Coupons(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Coupons(string.Empty, where, parameters, Mall_Coupon.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Coupon objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_Coupon objects.</returns>
		protected static EntityList<Mall_Coupon> GetMall_Coupons(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_Coupons(prefix, where, parameters, Mall_Coupon.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Coupon objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Coupon objects.</returns>
		protected static EntityList<Mall_Coupon> GetMall_Coupons(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Coupons(string.Empty, where, parameters, Mall_Coupon.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Coupon objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_Coupon objects.</returns>
		protected static EntityList<Mall_Coupon> GetMall_Coupons(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_Coupons(prefix, where, parameters, Mall_Coupon.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_Coupon objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_Coupon objects.</returns>
		protected static EntityList<Mall_Coupon> GetMall_Coupons(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_Coupon.SelectFieldList + "FROM [dbo].[Mall_Coupon] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_Coupon>(reader);
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
        protected static EntityList<Mall_Coupon> GetMall_Coupons(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_Coupon>(SelectFieldList, "FROM [dbo].[Mall_Coupon] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_Coupon objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CouponCount()
        {
            return GetMall_CouponCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_Coupon objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CouponCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_Coupon] " + where;

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
		public static partial class Mall_Coupon_Properties
		{
			public const string ID = "ID";
			public const string CouponName = "CouponName";
			public const string Summary = "Summary";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string UseNeedAmount = "UseNeedAmount";
			public const string ReduceAmount = "ReduceAmount";
			public const string AddTime = "AddTime";
			public const string IsActive = "IsActive";
			public const string UseType = "UseType";
			public const string AddUser = "AddUser";
			public const string AmountType = "AmountType";
			public const string IsUseForWY = "IsUseForWY";
			public const string IsUseForProduct = "IsUseForProduct";
			public const string IsUseForService = "IsUseForService";
			public const string IsUseForALLProduct = "IsUseForALLProduct";
			public const string IsUseForALLService = "IsUseForALLService";
			public const string CouponType = "CouponType";
			public const string IsUseForALLStore = "IsUseForALLStore";
			public const string IsUseForALLCategory = "IsUseForALLCategory";
			public const string CoverImage = "CoverImage";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CouponName" , "string:"},
    			 {"Summary" , "string:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"UseNeedAmount" , "decimal:"},
    			 {"ReduceAmount" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsActive" , "bool:"},
    			 {"UseType" , "int:1-满减 2-折扣"},
    			 {"AddUser" , "string:"},
    			 {"AmountType" , "int:1-固定金额 2-百分比"},
    			 {"IsUseForWY" , "bool:"},
    			 {"IsUseForProduct" , "bool:"},
    			 {"IsUseForService" , "bool:"},
    			 {"IsUseForALLProduct" , "bool:"},
    			 {"IsUseForALLService" , "bool:"},
    			 {"CouponType" , "int:1-单品券 2-店铺券 3-全场通用劵 4-品类优惠券 5-物业缴费优惠券 6-生日券"},
    			 {"IsUseForALLStore" , "bool:"},
    			 {"IsUseForALLCategory" , "bool:"},
    			 {"CoverImage" , "string:"},
            };
		}
		#endregion
	}
}
