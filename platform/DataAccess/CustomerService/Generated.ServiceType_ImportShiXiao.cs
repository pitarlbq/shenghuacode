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
	/// This object represents the properties and methods of a ServiceType_ImportShiXiao.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ServiceTypeID: {ServiceTypeID}")]
	public partial class ServiceType_ImportShiXiao 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceTypeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int ServiceTypeID
		{
			[DebuggerStepThrough()]
			get { return this._serviceTypeID; }
			set 
			{
				if (this._serviceTypeID != value) 
				{
					this._serviceTypeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceTypeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _dealTime = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal DealTime
		{
			[DebuggerStepThrough()]
			get { return this._dealTime; }
			set 
			{
				if (this._dealTime != value) 
				{
					this._dealTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("DealTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _paiDanTime = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PaiDanTime
		{
			[DebuggerStepThrough()]
			get { return this._paiDanTime; }
			set 
			{
				if (this._paiDanTime != value) 
				{
					this._paiDanTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaiDanTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _chuliTime = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ChuliTime
		{
			[DebuggerStepThrough()]
			get { return this._chuliTime; }
			set 
			{
				if (this._chuliTime != value) 
				{
					this._chuliTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChuliTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _banJieTime = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BanJieTime
		{
			[DebuggerStepThrough()]
			get { return this._banJieTime; }
			set 
			{
				if (this._banJieTime != value) 
				{
					this._banJieTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("BanJieTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _huiFangTime = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal HuiFangTime
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
		private decimal _guanDanTime = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal GuanDanTime
		{
			[DebuggerStepThrough()]
			get { return this._guanDanTime; }
			set 
			{
				if (this._guanDanTime != value) 
				{
					this._guanDanTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("GuanDanTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _responseTime = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ResponseTime
		{
			[DebuggerStepThrough()]
			get { return this._responseTime; }
			set 
			{
				if (this._responseTime != value) 
				{
					this._responseTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ResponseTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _checkTime = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CheckTime
		{
			[DebuggerStepThrough()]
			get { return this._checkTime; }
			set 
			{
				if (this._checkTime != value) 
				{
					this._checkTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckTime");
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
	[ServiceTypeID] int,
	[DealTime] decimal(18, 10),
	[PaiDanTime] decimal(18, 10),
	[ChuliTime] decimal(18, 10),
	[BanJieTime] decimal(18, 10),
	[HuiFangTime] decimal(18, 10),
	[GuanDanTime] decimal(18, 10),
	[ResponseTime] decimal(18, 10),
	[CheckTime] decimal(18, 10),
	[AddTime] datetime
);

INSERT INTO [dbo].[ServiceType_ImportShiXiao] (
	[ServiceType_ImportShiXiao].[ServiceTypeID],
	[ServiceType_ImportShiXiao].[DealTime],
	[ServiceType_ImportShiXiao].[PaiDanTime],
	[ServiceType_ImportShiXiao].[ChuliTime],
	[ServiceType_ImportShiXiao].[BanJieTime],
	[ServiceType_ImportShiXiao].[HuiFangTime],
	[ServiceType_ImportShiXiao].[GuanDanTime],
	[ServiceType_ImportShiXiao].[ResponseTime],
	[ServiceType_ImportShiXiao].[CheckTime],
	[ServiceType_ImportShiXiao].[AddTime]
) 
output 
	INSERTED.[ServiceTypeID],
	INSERTED.[DealTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ServiceTypeID,
	@DealTime,
	@PaiDanTime,
	@ChuliTime,
	@BanJieTime,
	@HuiFangTime,
	@GuanDanTime,
	@ResponseTime,
	@CheckTime,
	@AddTime 
); 

SELECT 
	[ServiceTypeID],
	[DealTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[ResponseTime],
	[CheckTime],
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
	[ServiceTypeID] int,
	[DealTime] decimal(18, 10),
	[PaiDanTime] decimal(18, 10),
	[ChuliTime] decimal(18, 10),
	[BanJieTime] decimal(18, 10),
	[HuiFangTime] decimal(18, 10),
	[GuanDanTime] decimal(18, 10),
	[ResponseTime] decimal(18, 10),
	[CheckTime] decimal(18, 10),
	[AddTime] datetime
);

UPDATE [dbo].[ServiceType_ImportShiXiao] SET 
	[ServiceType_ImportShiXiao].[DealTime] = @DealTime,
	[ServiceType_ImportShiXiao].[PaiDanTime] = @PaiDanTime,
	[ServiceType_ImportShiXiao].[ChuliTime] = @ChuliTime,
	[ServiceType_ImportShiXiao].[BanJieTime] = @BanJieTime,
	[ServiceType_ImportShiXiao].[HuiFangTime] = @HuiFangTime,
	[ServiceType_ImportShiXiao].[GuanDanTime] = @GuanDanTime,
	[ServiceType_ImportShiXiao].[ResponseTime] = @ResponseTime,
	[ServiceType_ImportShiXiao].[CheckTime] = @CheckTime,
	[ServiceType_ImportShiXiao].[AddTime] = @AddTime 
output 
	INSERTED.[ServiceTypeID],
	INSERTED.[DealTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[AddTime]
into @table
WHERE 
	[ServiceType_ImportShiXiao].[ServiceTypeID] = @ServiceTypeID

SELECT 
	[ServiceTypeID],
	[DealTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[ResponseTime],
	[CheckTime],
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
DELETE FROM [dbo].[ServiceType_ImportShiXiao]
WHERE 
	[ServiceType_ImportShiXiao].[ServiceTypeID] = @ServiceTypeID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ServiceType_ImportShiXiao() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetServiceType_ImportShiXiao(this.ServiceTypeID));
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
	[ServiceType_ImportShiXiao].[ServiceTypeID],
	[ServiceType_ImportShiXiao].[DealTime],
	[ServiceType_ImportShiXiao].[PaiDanTime],
	[ServiceType_ImportShiXiao].[ChuliTime],
	[ServiceType_ImportShiXiao].[BanJieTime],
	[ServiceType_ImportShiXiao].[HuiFangTime],
	[ServiceType_ImportShiXiao].[GuanDanTime],
	[ServiceType_ImportShiXiao].[ResponseTime],
	[ServiceType_ImportShiXiao].[CheckTime],
	[ServiceType_ImportShiXiao].[AddTime]
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
                return "ServiceType_ImportShiXiao";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ServiceType_ImportShiXiao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceTypeID">serviceTypeID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="addTime">addTime</param>
		public static void InsertServiceType_ImportShiXiao(int @serviceTypeID, decimal @dealTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, decimal @responseTime, decimal @checkTime, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertServiceType_ImportShiXiao(@serviceTypeID, @dealTime, @paiDanTime, @chuliTime, @banJieTime, @huiFangTime, @guanDanTime, @responseTime, @checkTime, @addTime, helper);
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
		/// Insert a ServiceType_ImportShiXiao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceTypeID">serviceTypeID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertServiceType_ImportShiXiao(int @serviceTypeID, decimal @dealTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, decimal @responseTime, decimal @checkTime, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ServiceTypeID] int,
	[DealTime] decimal(18, 10),
	[PaiDanTime] decimal(18, 10),
	[ChuliTime] decimal(18, 10),
	[BanJieTime] decimal(18, 10),
	[HuiFangTime] decimal(18, 10),
	[GuanDanTime] decimal(18, 10),
	[ResponseTime] decimal(18, 10),
	[CheckTime] decimal(18, 10),
	[AddTime] datetime
);

INSERT INTO [dbo].[ServiceType_ImportShiXiao] (
	[ServiceType_ImportShiXiao].[ServiceTypeID],
	[ServiceType_ImportShiXiao].[DealTime],
	[ServiceType_ImportShiXiao].[PaiDanTime],
	[ServiceType_ImportShiXiao].[ChuliTime],
	[ServiceType_ImportShiXiao].[BanJieTime],
	[ServiceType_ImportShiXiao].[HuiFangTime],
	[ServiceType_ImportShiXiao].[GuanDanTime],
	[ServiceType_ImportShiXiao].[ResponseTime],
	[ServiceType_ImportShiXiao].[CheckTime],
	[ServiceType_ImportShiXiao].[AddTime]
) 
output 
	INSERTED.[ServiceTypeID],
	INSERTED.[DealTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ServiceTypeID,
	@DealTime,
	@PaiDanTime,
	@ChuliTime,
	@BanJieTime,
	@HuiFangTime,
	@GuanDanTime,
	@ResponseTime,
	@CheckTime,
	@AddTime 
); 

SELECT 
	[ServiceTypeID],
	[DealTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[ResponseTime],
	[CheckTime],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceTypeID", EntityBase.GetDatabaseValue(@serviceTypeID)));
			parameters.Add(new SqlParameter("@DealTime", EntityBase.GetDatabaseValue(@dealTime)));
			parameters.Add(new SqlParameter("@PaiDanTime", EntityBase.GetDatabaseValue(@paiDanTime)));
			parameters.Add(new SqlParameter("@ChuliTime", EntityBase.GetDatabaseValue(@chuliTime)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@HuiFangTime", EntityBase.GetDatabaseValue(@huiFangTime)));
			parameters.Add(new SqlParameter("@GuanDanTime", EntityBase.GetDatabaseValue(@guanDanTime)));
			parameters.Add(new SqlParameter("@ResponseTime", EntityBase.GetDatabaseValue(@responseTime)));
			parameters.Add(new SqlParameter("@CheckTime", EntityBase.GetDatabaseValue(@checkTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ServiceType_ImportShiXiao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceTypeID">serviceTypeID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateServiceType_ImportShiXiao(int @serviceTypeID, decimal @dealTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, decimal @responseTime, decimal @checkTime, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateServiceType_ImportShiXiao(@serviceTypeID, @dealTime, @paiDanTime, @chuliTime, @banJieTime, @huiFangTime, @guanDanTime, @responseTime, @checkTime, @addTime, helper);
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
		/// Updates a ServiceType_ImportShiXiao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceTypeID">serviceTypeID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateServiceType_ImportShiXiao(int @serviceTypeID, decimal @dealTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, decimal @responseTime, decimal @checkTime, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ServiceTypeID] int,
	[DealTime] decimal(18, 10),
	[PaiDanTime] decimal(18, 10),
	[ChuliTime] decimal(18, 10),
	[BanJieTime] decimal(18, 10),
	[HuiFangTime] decimal(18, 10),
	[GuanDanTime] decimal(18, 10),
	[ResponseTime] decimal(18, 10),
	[CheckTime] decimal(18, 10),
	[AddTime] datetime
);

UPDATE [dbo].[ServiceType_ImportShiXiao] SET 
	[ServiceType_ImportShiXiao].[DealTime] = @DealTime,
	[ServiceType_ImportShiXiao].[PaiDanTime] = @PaiDanTime,
	[ServiceType_ImportShiXiao].[ChuliTime] = @ChuliTime,
	[ServiceType_ImportShiXiao].[BanJieTime] = @BanJieTime,
	[ServiceType_ImportShiXiao].[HuiFangTime] = @HuiFangTime,
	[ServiceType_ImportShiXiao].[GuanDanTime] = @GuanDanTime,
	[ServiceType_ImportShiXiao].[ResponseTime] = @ResponseTime,
	[ServiceType_ImportShiXiao].[CheckTime] = @CheckTime,
	[ServiceType_ImportShiXiao].[AddTime] = @AddTime 
output 
	INSERTED.[ServiceTypeID],
	INSERTED.[DealTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[AddTime]
into @table
WHERE 
	[ServiceType_ImportShiXiao].[ServiceTypeID] = @ServiceTypeID

SELECT 
	[ServiceTypeID],
	[DealTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[ResponseTime],
	[CheckTime],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceTypeID", EntityBase.GetDatabaseValue(@serviceTypeID)));
			parameters.Add(new SqlParameter("@DealTime", EntityBase.GetDatabaseValue(@dealTime)));
			parameters.Add(new SqlParameter("@PaiDanTime", EntityBase.GetDatabaseValue(@paiDanTime)));
			parameters.Add(new SqlParameter("@ChuliTime", EntityBase.GetDatabaseValue(@chuliTime)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@HuiFangTime", EntityBase.GetDatabaseValue(@huiFangTime)));
			parameters.Add(new SqlParameter("@GuanDanTime", EntityBase.GetDatabaseValue(@guanDanTime)));
			parameters.Add(new SqlParameter("@ResponseTime", EntityBase.GetDatabaseValue(@responseTime)));
			parameters.Add(new SqlParameter("@CheckTime", EntityBase.GetDatabaseValue(@checkTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ServiceType_ImportShiXiao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceTypeID">serviceTypeID</param>
		public static void DeleteServiceType_ImportShiXiao(int @serviceTypeID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteServiceType_ImportShiXiao(@serviceTypeID, helper);
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
		/// Deletes a ServiceType_ImportShiXiao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceTypeID">serviceTypeID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteServiceType_ImportShiXiao(int @serviceTypeID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ServiceType_ImportShiXiao]
WHERE 
	[ServiceType_ImportShiXiao].[ServiceTypeID] = @ServiceTypeID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceTypeID", @serviceTypeID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ServiceType_ImportShiXiao object.
		/// </summary>
		/// <returns>The newly created ServiceType_ImportShiXiao object.</returns>
		public static ServiceType_ImportShiXiao CreateServiceType_ImportShiXiao()
		{
			return InitializeNew<ServiceType_ImportShiXiao>();
		}
		
		/// <summary>
		/// Retrieve information for a ServiceType_ImportShiXiao by a ServiceType_ImportShiXiao's unique identifier.
		/// </summary>
		/// <param name="serviceTypeID">serviceTypeID</param>
		/// <returns>ServiceType_ImportShiXiao</returns>
		public static ServiceType_ImportShiXiao GetServiceType_ImportShiXiao(int @serviceTypeID)
		{
			string commandText = @"
SELECT 
" + ServiceType_ImportShiXiao.SelectFieldList + @"
FROM [dbo].[ServiceType_ImportShiXiao] 
WHERE 
	[ServiceType_ImportShiXiao].[ServiceTypeID] = @ServiceTypeID " + ServiceType_ImportShiXiao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceTypeID", @serviceTypeID));
			
			return GetOne<ServiceType_ImportShiXiao>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ServiceType_ImportShiXiao by a ServiceType_ImportShiXiao's unique identifier.
		/// </summary>
		/// <param name="serviceTypeID">serviceTypeID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ServiceType_ImportShiXiao</returns>
		public static ServiceType_ImportShiXiao GetServiceType_ImportShiXiao(int @serviceTypeID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ServiceType_ImportShiXiao.SelectFieldList + @"
FROM [dbo].[ServiceType_ImportShiXiao] 
WHERE 
	[ServiceType_ImportShiXiao].[ServiceTypeID] = @ServiceTypeID " + ServiceType_ImportShiXiao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceTypeID", @serviceTypeID));
			
			return GetOne<ServiceType_ImportShiXiao>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportShiXiao objects.
		/// </summary>
		/// <returns>The retrieved collection of ServiceType_ImportShiXiao objects.</returns>
		public static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos()
		{
			string commandText = @"
SELECT " + ServiceType_ImportShiXiao.SelectFieldList + "FROM [dbo].[ServiceType_ImportShiXiao] " + ServiceType_ImportShiXiao.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ServiceType_ImportShiXiao>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ServiceType_ImportShiXiao objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ServiceType_ImportShiXiao objects.</returns>
        public static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ServiceType_ImportShiXiao>(SelectFieldList, "FROM [dbo].[ServiceType_ImportShiXiao]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ServiceType_ImportShiXiao objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ServiceType_ImportShiXiao objects.</returns>
        public static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ServiceType_ImportShiXiao>(SelectFieldList, "FROM [dbo].[ServiceType_ImportShiXiao]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ServiceType_ImportShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ServiceType_ImportShiXiao objects.</returns>
		protected static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetServiceType_ImportShiXiaos(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ServiceType_ImportShiXiao objects.</returns>
		protected static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetServiceType_ImportShiXiaos(string.Empty, where, parameters, ServiceType_ImportShiXiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ServiceType_ImportShiXiao objects.</returns>
		protected static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetServiceType_ImportShiXiaos(prefix, where, parameters, ServiceType_ImportShiXiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ServiceType_ImportShiXiao objects.</returns>
		protected static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetServiceType_ImportShiXiaos(string.Empty, where, parameters, ServiceType_ImportShiXiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ServiceType_ImportShiXiao objects.</returns>
		protected static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetServiceType_ImportShiXiaos(prefix, where, parameters, ServiceType_ImportShiXiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportShiXiao objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ServiceType_ImportShiXiao objects.</returns>
		protected static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ServiceType_ImportShiXiao.SelectFieldList + "FROM [dbo].[ServiceType_ImportShiXiao] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ServiceType_ImportShiXiao>(reader);
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
        protected static EntityList<ServiceType_ImportShiXiao> GetServiceType_ImportShiXiaos(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ServiceType_ImportShiXiao>(SelectFieldList, "FROM [dbo].[ServiceType_ImportShiXiao] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ServiceType_ImportShiXiao objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetServiceType_ImportShiXiaoCount()
        {
            return GetServiceType_ImportShiXiaoCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ServiceType_ImportShiXiao objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetServiceType_ImportShiXiaoCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ServiceType_ImportShiXiao] " + where;

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
		public static partial class ServiceType_ImportShiXiao_Properties
		{
			public const string ServiceTypeID = "ServiceTypeID";
			public const string DealTime = "DealTime";
			public const string PaiDanTime = "PaiDanTime";
			public const string ChuliTime = "ChuliTime";
			public const string BanJieTime = "BanJieTime";
			public const string HuiFangTime = "HuiFangTime";
			public const string GuanDanTime = "GuanDanTime";
			public const string ResponseTime = "ResponseTime";
			public const string CheckTime = "CheckTime";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ServiceTypeID" , "int:"},
    			 {"DealTime" , "decimal:"},
    			 {"PaiDanTime" , "decimal:"},
    			 {"ChuliTime" , "decimal:"},
    			 {"BanJieTime" , "decimal:"},
    			 {"HuiFangTime" , "decimal:"},
    			 {"GuanDanTime" , "decimal:"},
    			 {"ResponseTime" , "decimal:"},
    			 {"CheckTime" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
