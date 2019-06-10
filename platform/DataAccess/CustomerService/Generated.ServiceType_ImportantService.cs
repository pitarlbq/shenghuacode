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
	/// This object represents the properties and methods of a ServiceType_ImportantService.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ServiceType_ImportantService 
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
		private bool _disableHolidayTime = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableHolidayTime
		{
			[DebuggerStepThrough()]
			get { return this._disableHolidayTime; }
			set 
			{
				if (this._disableHolidayTime != value) 
				{
					this._disableHolidayTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableHolidayTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _startHour = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string StartHour
		{
			[DebuggerStepThrough()]
			get { return this._startHour; }
			set 
			{
				if (this._startHour != value) 
				{
					this._startHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("StartHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _endHour = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string EndHour
		{
			[DebuggerStepThrough()]
			get { return this._endHour; }
			set 
			{
				if (this._endHour != value) 
				{
					this._endHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndHour");
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
		private bool _disableWorkOffTime = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableWorkOffTime
		{
			[DebuggerStepThrough()]
			get { return this._disableWorkOffTime; }
			set 
			{
				if (this._disableWorkOffTime != value) 
				{
					this._disableWorkOffTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableWorkOffTime");
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
	[DealTime] decimal(18, 2),
	[AddTime] datetime,
	[PaiDanTime] decimal(18, 2),
	[ChuliTime] decimal(18, 2),
	[BanJieTime] decimal(18, 2),
	[HuiFangTime] decimal(18, 2),
	[GuanDanTime] decimal(18, 2),
	[DisableHolidayTime] bit,
	[StartHour] nvarchar(20),
	[EndHour] nvarchar(20),
	[ResponseTime] decimal(18, 2),
	[CheckTime] decimal(18, 2),
	[DisableWorkOffTime] bit
);

INSERT INTO [dbo].[ServiceType_ImportantService] (
	[ServiceType_ImportantService].[ServiceID],
	[ServiceType_ImportantService].[DealTime],
	[ServiceType_ImportantService].[AddTime],
	[ServiceType_ImportantService].[PaiDanTime],
	[ServiceType_ImportantService].[ChuliTime],
	[ServiceType_ImportantService].[BanJieTime],
	[ServiceType_ImportantService].[HuiFangTime],
	[ServiceType_ImportantService].[GuanDanTime],
	[ServiceType_ImportantService].[DisableHolidayTime],
	[ServiceType_ImportantService].[StartHour],
	[ServiceType_ImportantService].[EndHour],
	[ServiceType_ImportantService].[ResponseTime],
	[ServiceType_ImportantService].[CheckTime],
	[ServiceType_ImportantService].[DisableWorkOffTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[DealTime],
	INSERTED.[AddTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[DisableHolidayTime],
	INSERTED.[StartHour],
	INSERTED.[EndHour],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[DisableWorkOffTime]
into @table
VALUES ( 
	@ServiceID,
	@DealTime,
	@AddTime,
	@PaiDanTime,
	@ChuliTime,
	@BanJieTime,
	@HuiFangTime,
	@GuanDanTime,
	@DisableHolidayTime,
	@StartHour,
	@EndHour,
	@ResponseTime,
	@CheckTime,
	@DisableWorkOffTime 
); 

SELECT 
	[ID],
	[ServiceID],
	[DealTime],
	[AddTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[DisableHolidayTime],
	[StartHour],
	[EndHour],
	[ResponseTime],
	[CheckTime],
	[DisableWorkOffTime] 
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
	[DealTime] decimal(18, 2),
	[AddTime] datetime,
	[PaiDanTime] decimal(18, 2),
	[ChuliTime] decimal(18, 2),
	[BanJieTime] decimal(18, 2),
	[HuiFangTime] decimal(18, 2),
	[GuanDanTime] decimal(18, 2),
	[DisableHolidayTime] bit,
	[StartHour] nvarchar(20),
	[EndHour] nvarchar(20),
	[ResponseTime] decimal(18, 2),
	[CheckTime] decimal(18, 2),
	[DisableWorkOffTime] bit
);

UPDATE [dbo].[ServiceType_ImportantService] SET 
	[ServiceType_ImportantService].[ServiceID] = @ServiceID,
	[ServiceType_ImportantService].[DealTime] = @DealTime,
	[ServiceType_ImportantService].[AddTime] = @AddTime,
	[ServiceType_ImportantService].[PaiDanTime] = @PaiDanTime,
	[ServiceType_ImportantService].[ChuliTime] = @ChuliTime,
	[ServiceType_ImportantService].[BanJieTime] = @BanJieTime,
	[ServiceType_ImportantService].[HuiFangTime] = @HuiFangTime,
	[ServiceType_ImportantService].[GuanDanTime] = @GuanDanTime,
	[ServiceType_ImportantService].[DisableHolidayTime] = @DisableHolidayTime,
	[ServiceType_ImportantService].[StartHour] = @StartHour,
	[ServiceType_ImportantService].[EndHour] = @EndHour,
	[ServiceType_ImportantService].[ResponseTime] = @ResponseTime,
	[ServiceType_ImportantService].[CheckTime] = @CheckTime,
	[ServiceType_ImportantService].[DisableWorkOffTime] = @DisableWorkOffTime 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[DealTime],
	INSERTED.[AddTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[DisableHolidayTime],
	INSERTED.[StartHour],
	INSERTED.[EndHour],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[DisableWorkOffTime]
into @table
WHERE 
	[ServiceType_ImportantService].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[DealTime],
	[AddTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[DisableHolidayTime],
	[StartHour],
	[EndHour],
	[ResponseTime],
	[CheckTime],
	[DisableWorkOffTime] 
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
DELETE FROM [dbo].[ServiceType_ImportantService]
WHERE 
	[ServiceType_ImportantService].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ServiceType_ImportantService() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetServiceType_ImportantService(this.ID));
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
	[ServiceType_ImportantService].[ID],
	[ServiceType_ImportantService].[ServiceID],
	[ServiceType_ImportantService].[DealTime],
	[ServiceType_ImportantService].[AddTime],
	[ServiceType_ImportantService].[PaiDanTime],
	[ServiceType_ImportantService].[ChuliTime],
	[ServiceType_ImportantService].[BanJieTime],
	[ServiceType_ImportantService].[HuiFangTime],
	[ServiceType_ImportantService].[GuanDanTime],
	[ServiceType_ImportantService].[DisableHolidayTime],
	[ServiceType_ImportantService].[StartHour],
	[ServiceType_ImportantService].[EndHour],
	[ServiceType_ImportantService].[ResponseTime],
	[ServiceType_ImportantService].[CheckTime],
	[ServiceType_ImportantService].[DisableWorkOffTime]
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
                return "ServiceType_ImportantService";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ServiceType_ImportantService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="disableHolidayTime">disableHolidayTime</param>
		/// <param name="startHour">startHour</param>
		/// <param name="endHour">endHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="disableWorkOffTime">disableWorkOffTime</param>
		public static void InsertServiceType_ImportantService(int @serviceID, decimal @dealTime, DateTime @addTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, bool @disableHolidayTime, string @startHour, string @endHour, decimal @responseTime, decimal @checkTime, bool @disableWorkOffTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertServiceType_ImportantService(@serviceID, @dealTime, @addTime, @paiDanTime, @chuliTime, @banJieTime, @huiFangTime, @guanDanTime, @disableHolidayTime, @startHour, @endHour, @responseTime, @checkTime, @disableWorkOffTime, helper);
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
		/// Insert a ServiceType_ImportantService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="disableHolidayTime">disableHolidayTime</param>
		/// <param name="startHour">startHour</param>
		/// <param name="endHour">endHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="disableWorkOffTime">disableWorkOffTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertServiceType_ImportantService(int @serviceID, decimal @dealTime, DateTime @addTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, bool @disableHolidayTime, string @startHour, string @endHour, decimal @responseTime, decimal @checkTime, bool @disableWorkOffTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[DealTime] decimal(18, 2),
	[AddTime] datetime,
	[PaiDanTime] decimal(18, 2),
	[ChuliTime] decimal(18, 2),
	[BanJieTime] decimal(18, 2),
	[HuiFangTime] decimal(18, 2),
	[GuanDanTime] decimal(18, 2),
	[DisableHolidayTime] bit,
	[StartHour] nvarchar(20),
	[EndHour] nvarchar(20),
	[ResponseTime] decimal(18, 2),
	[CheckTime] decimal(18, 2),
	[DisableWorkOffTime] bit
);

INSERT INTO [dbo].[ServiceType_ImportantService] (
	[ServiceType_ImportantService].[ServiceID],
	[ServiceType_ImportantService].[DealTime],
	[ServiceType_ImportantService].[AddTime],
	[ServiceType_ImportantService].[PaiDanTime],
	[ServiceType_ImportantService].[ChuliTime],
	[ServiceType_ImportantService].[BanJieTime],
	[ServiceType_ImportantService].[HuiFangTime],
	[ServiceType_ImportantService].[GuanDanTime],
	[ServiceType_ImportantService].[DisableHolidayTime],
	[ServiceType_ImportantService].[StartHour],
	[ServiceType_ImportantService].[EndHour],
	[ServiceType_ImportantService].[ResponseTime],
	[ServiceType_ImportantService].[CheckTime],
	[ServiceType_ImportantService].[DisableWorkOffTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[DealTime],
	INSERTED.[AddTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[DisableHolidayTime],
	INSERTED.[StartHour],
	INSERTED.[EndHour],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[DisableWorkOffTime]
into @table
VALUES ( 
	@ServiceID,
	@DealTime,
	@AddTime,
	@PaiDanTime,
	@ChuliTime,
	@BanJieTime,
	@HuiFangTime,
	@GuanDanTime,
	@DisableHolidayTime,
	@StartHour,
	@EndHour,
	@ResponseTime,
	@CheckTime,
	@DisableWorkOffTime 
); 

SELECT 
	[ID],
	[ServiceID],
	[DealTime],
	[AddTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[DisableHolidayTime],
	[StartHour],
	[EndHour],
	[ResponseTime],
	[CheckTime],
	[DisableWorkOffTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@DealTime", EntityBase.GetDatabaseValue(@dealTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PaiDanTime", EntityBase.GetDatabaseValue(@paiDanTime)));
			parameters.Add(new SqlParameter("@ChuliTime", EntityBase.GetDatabaseValue(@chuliTime)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@HuiFangTime", EntityBase.GetDatabaseValue(@huiFangTime)));
			parameters.Add(new SqlParameter("@GuanDanTime", EntityBase.GetDatabaseValue(@guanDanTime)));
			parameters.Add(new SqlParameter("@DisableHolidayTime", @disableHolidayTime));
			parameters.Add(new SqlParameter("@StartHour", EntityBase.GetDatabaseValue(@startHour)));
			parameters.Add(new SqlParameter("@EndHour", EntityBase.GetDatabaseValue(@endHour)));
			parameters.Add(new SqlParameter("@ResponseTime", EntityBase.GetDatabaseValue(@responseTime)));
			parameters.Add(new SqlParameter("@CheckTime", EntityBase.GetDatabaseValue(@checkTime)));
			parameters.Add(new SqlParameter("@DisableWorkOffTime", @disableWorkOffTime));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ServiceType_ImportantService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="disableHolidayTime">disableHolidayTime</param>
		/// <param name="startHour">startHour</param>
		/// <param name="endHour">endHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="disableWorkOffTime">disableWorkOffTime</param>
		public static void UpdateServiceType_ImportantService(int @iD, int @serviceID, decimal @dealTime, DateTime @addTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, bool @disableHolidayTime, string @startHour, string @endHour, decimal @responseTime, decimal @checkTime, bool @disableWorkOffTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateServiceType_ImportantService(@iD, @serviceID, @dealTime, @addTime, @paiDanTime, @chuliTime, @banJieTime, @huiFangTime, @guanDanTime, @disableHolidayTime, @startHour, @endHour, @responseTime, @checkTime, @disableWorkOffTime, helper);
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
		/// Updates a ServiceType_ImportantService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="disableHolidayTime">disableHolidayTime</param>
		/// <param name="startHour">startHour</param>
		/// <param name="endHour">endHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="disableWorkOffTime">disableWorkOffTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateServiceType_ImportantService(int @iD, int @serviceID, decimal @dealTime, DateTime @addTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, bool @disableHolidayTime, string @startHour, string @endHour, decimal @responseTime, decimal @checkTime, bool @disableWorkOffTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[DealTime] decimal(18, 2),
	[AddTime] datetime,
	[PaiDanTime] decimal(18, 2),
	[ChuliTime] decimal(18, 2),
	[BanJieTime] decimal(18, 2),
	[HuiFangTime] decimal(18, 2),
	[GuanDanTime] decimal(18, 2),
	[DisableHolidayTime] bit,
	[StartHour] nvarchar(20),
	[EndHour] nvarchar(20),
	[ResponseTime] decimal(18, 2),
	[CheckTime] decimal(18, 2),
	[DisableWorkOffTime] bit
);

UPDATE [dbo].[ServiceType_ImportantService] SET 
	[ServiceType_ImportantService].[ServiceID] = @ServiceID,
	[ServiceType_ImportantService].[DealTime] = @DealTime,
	[ServiceType_ImportantService].[AddTime] = @AddTime,
	[ServiceType_ImportantService].[PaiDanTime] = @PaiDanTime,
	[ServiceType_ImportantService].[ChuliTime] = @ChuliTime,
	[ServiceType_ImportantService].[BanJieTime] = @BanJieTime,
	[ServiceType_ImportantService].[HuiFangTime] = @HuiFangTime,
	[ServiceType_ImportantService].[GuanDanTime] = @GuanDanTime,
	[ServiceType_ImportantService].[DisableHolidayTime] = @DisableHolidayTime,
	[ServiceType_ImportantService].[StartHour] = @StartHour,
	[ServiceType_ImportantService].[EndHour] = @EndHour,
	[ServiceType_ImportantService].[ResponseTime] = @ResponseTime,
	[ServiceType_ImportantService].[CheckTime] = @CheckTime,
	[ServiceType_ImportantService].[DisableWorkOffTime] = @DisableWorkOffTime 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[DealTime],
	INSERTED.[AddTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[DisableHolidayTime],
	INSERTED.[StartHour],
	INSERTED.[EndHour],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[DisableWorkOffTime]
into @table
WHERE 
	[ServiceType_ImportantService].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[DealTime],
	[AddTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[DisableHolidayTime],
	[StartHour],
	[EndHour],
	[ResponseTime],
	[CheckTime],
	[DisableWorkOffTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@DealTime", EntityBase.GetDatabaseValue(@dealTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PaiDanTime", EntityBase.GetDatabaseValue(@paiDanTime)));
			parameters.Add(new SqlParameter("@ChuliTime", EntityBase.GetDatabaseValue(@chuliTime)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@HuiFangTime", EntityBase.GetDatabaseValue(@huiFangTime)));
			parameters.Add(new SqlParameter("@GuanDanTime", EntityBase.GetDatabaseValue(@guanDanTime)));
			parameters.Add(new SqlParameter("@DisableHolidayTime", @disableHolidayTime));
			parameters.Add(new SqlParameter("@StartHour", EntityBase.GetDatabaseValue(@startHour)));
			parameters.Add(new SqlParameter("@EndHour", EntityBase.GetDatabaseValue(@endHour)));
			parameters.Add(new SqlParameter("@ResponseTime", EntityBase.GetDatabaseValue(@responseTime)));
			parameters.Add(new SqlParameter("@CheckTime", EntityBase.GetDatabaseValue(@checkTime)));
			parameters.Add(new SqlParameter("@DisableWorkOffTime", @disableWorkOffTime));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ServiceType_ImportantService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteServiceType_ImportantService(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteServiceType_ImportantService(@iD, helper);
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
		/// Deletes a ServiceType_ImportantService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteServiceType_ImportantService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ServiceType_ImportantService]
WHERE 
	[ServiceType_ImportantService].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ServiceType_ImportantService object.
		/// </summary>
		/// <returns>The newly created ServiceType_ImportantService object.</returns>
		public static ServiceType_ImportantService CreateServiceType_ImportantService()
		{
			return InitializeNew<ServiceType_ImportantService>();
		}
		
		/// <summary>
		/// Retrieve information for a ServiceType_ImportantService by a ServiceType_ImportantService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ServiceType_ImportantService</returns>
		public static ServiceType_ImportantService GetServiceType_ImportantService(int @iD)
		{
			string commandText = @"
SELECT 
" + ServiceType_ImportantService.SelectFieldList + @"
FROM [dbo].[ServiceType_ImportantService] 
WHERE 
	[ServiceType_ImportantService].[ID] = @ID " + ServiceType_ImportantService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ServiceType_ImportantService>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ServiceType_ImportantService by a ServiceType_ImportantService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ServiceType_ImportantService</returns>
		public static ServiceType_ImportantService GetServiceType_ImportantService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ServiceType_ImportantService.SelectFieldList + @"
FROM [dbo].[ServiceType_ImportantService] 
WHERE 
	[ServiceType_ImportantService].[ID] = @ID " + ServiceType_ImportantService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ServiceType_ImportantService>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportantService objects.
		/// </summary>
		/// <returns>The retrieved collection of ServiceType_ImportantService objects.</returns>
		public static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices()
		{
			string commandText = @"
SELECT " + ServiceType_ImportantService.SelectFieldList + "FROM [dbo].[ServiceType_ImportantService] " + ServiceType_ImportantService.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ServiceType_ImportantService>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ServiceType_ImportantService objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ServiceType_ImportantService objects.</returns>
        public static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ServiceType_ImportantService>(SelectFieldList, "FROM [dbo].[ServiceType_ImportantService]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ServiceType_ImportantService objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ServiceType_ImportantService objects.</returns>
        public static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ServiceType_ImportantService>(SelectFieldList, "FROM [dbo].[ServiceType_ImportantService]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ServiceType_ImportantService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ServiceType_ImportantService objects.</returns>
		protected static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetServiceType_ImportantServices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportantService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ServiceType_ImportantService objects.</returns>
		protected static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetServiceType_ImportantServices(string.Empty, where, parameters, ServiceType_ImportantService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportantService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ServiceType_ImportantService objects.</returns>
		protected static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetServiceType_ImportantServices(prefix, where, parameters, ServiceType_ImportantService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportantService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ServiceType_ImportantService objects.</returns>
		protected static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetServiceType_ImportantServices(string.Empty, where, parameters, ServiceType_ImportantService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportantService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ServiceType_ImportantService objects.</returns>
		protected static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetServiceType_ImportantServices(prefix, where, parameters, ServiceType_ImportantService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType_ImportantService objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ServiceType_ImportantService objects.</returns>
		protected static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ServiceType_ImportantService.SelectFieldList + "FROM [dbo].[ServiceType_ImportantService] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ServiceType_ImportantService>(reader);
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
        protected static EntityList<ServiceType_ImportantService> GetServiceType_ImportantServices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ServiceType_ImportantService>(SelectFieldList, "FROM [dbo].[ServiceType_ImportantService] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ServiceType_ImportantService objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetServiceType_ImportantServiceCount()
        {
            return GetServiceType_ImportantServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ServiceType_ImportantService objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetServiceType_ImportantServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ServiceType_ImportantService] " + where;

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
		public static partial class ServiceType_ImportantService_Properties
		{
			public const string ID = "ID";
			public const string ServiceID = "ServiceID";
			public const string DealTime = "DealTime";
			public const string AddTime = "AddTime";
			public const string PaiDanTime = "PaiDanTime";
			public const string ChuliTime = "ChuliTime";
			public const string BanJieTime = "BanJieTime";
			public const string HuiFangTime = "HuiFangTime";
			public const string GuanDanTime = "GuanDanTime";
			public const string DisableHolidayTime = "DisableHolidayTime";
			public const string StartHour = "StartHour";
			public const string EndHour = "EndHour";
			public const string ResponseTime = "ResponseTime";
			public const string CheckTime = "CheckTime";
			public const string DisableWorkOffTime = "DisableWorkOffTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"DealTime" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PaiDanTime" , "decimal:"},
    			 {"ChuliTime" , "decimal:"},
    			 {"BanJieTime" , "decimal:"},
    			 {"HuiFangTime" , "decimal:"},
    			 {"GuanDanTime" , "decimal:"},
    			 {"DisableHolidayTime" , "bool:"},
    			 {"StartHour" , "string:"},
    			 {"EndHour" , "string:"},
    			 {"ResponseTime" , "decimal:"},
    			 {"CheckTime" , "decimal:"},
    			 {"DisableWorkOffTime" , "bool:"},
            };
		}
		#endregion
	}
}
