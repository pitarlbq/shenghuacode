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
	/// This object represents the properties and methods of a ServiceType.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ServiceType 
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
		private string _serviceTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceTypeName
		{
			[DebuggerStepThrough()]
			get { return this._serviceTypeName; }
			set 
			{
				if (this._serviceTypeName != value) 
				{
					this._serviceTypeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceTypeName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ParentID
		{
			[DebuggerStepThrough()]
			get { return this._parentID; }
			set 
			{
				if (this._parentID != value) 
				{
					this._parentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentID");
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
		private int _gongDanType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int GongDanType
		{
			[DebuggerStepThrough()]
			get { return this._gongDanType; }
			set 
			{
				if (this._gongDanType != value) 
				{
					this._gongDanType = value;
					this.IsDirty = true;	
					OnPropertyChanged("GongDanType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _disableSend = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableSend
		{
			[DebuggerStepThrough()]
			get { return this._disableSend; }
			set 
			{
				if (this._disableSend != value) 
				{
					this._disableSend = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableSend");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _disableProcee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableProcee
		{
			[DebuggerStepThrough()]
			get { return this._disableProcee; }
			set 
			{
				if (this._disableProcee != value) 
				{
					this._disableProcee = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableProcee");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _disableCompelte = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableCompelte
		{
			[DebuggerStepThrough()]
			get { return this._disableCompelte; }
			set 
			{
				if (this._disableCompelte != value) 
				{
					this._disableCompelte = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableCompelte");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _disableCallback = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableCallback
		{
			[DebuggerStepThrough()]
			get { return this._disableCallback; }
			set 
			{
				if (this._disableCallback != value) 
				{
					this._disableCallback = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableCallback");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _disableShenJi = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableShenJi
		{
			[DebuggerStepThrough()]
			get { return this._disableShenJi; }
			set 
			{
				if (this._disableShenJi != value) 
				{
					this._disableShenJi = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableShenJi");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _closeServiceType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CloseServiceType
		{
			[DebuggerStepThrough()]
			get { return this._closeServiceType; }
			set 
			{
				if (this._closeServiceType != value) 
				{
					this._closeServiceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CloseServiceType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _callBackServiceType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CallBackServiceType
		{
			[DebuggerStepThrough()]
			get { return this._callBackServiceType; }
			set 
			{
				if (this._callBackServiceType != value) 
				{
					this._callBackServiceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CallBackServiceType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _banJieServiceType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BanJieServiceType
		{
			[DebuggerStepThrough()]
			get { return this._banJieServiceType; }
			set 
			{
				if (this._banJieServiceType != value) 
				{
					this._banJieServiceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("BanJieServiceType");
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
		private bool _isDisableTime = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDisableTime
		{
			[DebuggerStepThrough()]
			get { return this._isDisableTime; }
			set 
			{
				if (this._isDisableTime != value) 
				{
					this._isDisableTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDisableTime");
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
	[ServiceTypeName] nvarchar(100),
	[SortOrder] int,
	[ParentID] int,
	[DealTime] decimal(18, 2),
	[AddTime] datetime,
	[PaiDanTime] decimal(18, 2),
	[ChuliTime] decimal(18, 2),
	[BanJieTime] decimal(18, 2),
	[HuiFangTime] decimal(18, 2),
	[GuanDanTime] decimal(18, 2),
	[GongDanType] int,
	[DisableSend] bit,
	[DisableProcee] bit,
	[DisableCompelte] bit,
	[DisableCallback] bit,
	[DisableShenJi] bit,
	[CloseServiceType] int,
	[CallBackServiceType] int,
	[BanJieServiceType] int,
	[DisableHolidayTime] bit,
	[StartHour] nvarchar(20),
	[EndHour] nvarchar(20),
	[ResponseTime] decimal(18, 2),
	[CheckTime] decimal(18, 2),
	[IsDisableTime] bit
);

INSERT INTO [dbo].[ServiceType] (
	[ServiceType].[ServiceTypeName],
	[ServiceType].[SortOrder],
	[ServiceType].[ParentID],
	[ServiceType].[DealTime],
	[ServiceType].[AddTime],
	[ServiceType].[PaiDanTime],
	[ServiceType].[ChuliTime],
	[ServiceType].[BanJieTime],
	[ServiceType].[HuiFangTime],
	[ServiceType].[GuanDanTime],
	[ServiceType].[GongDanType],
	[ServiceType].[DisableSend],
	[ServiceType].[DisableProcee],
	[ServiceType].[DisableCompelte],
	[ServiceType].[DisableCallback],
	[ServiceType].[DisableShenJi],
	[ServiceType].[CloseServiceType],
	[ServiceType].[CallBackServiceType],
	[ServiceType].[BanJieServiceType],
	[ServiceType].[DisableHolidayTime],
	[ServiceType].[StartHour],
	[ServiceType].[EndHour],
	[ServiceType].[ResponseTime],
	[ServiceType].[CheckTime],
	[ServiceType].[IsDisableTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceTypeName],
	INSERTED.[SortOrder],
	INSERTED.[ParentID],
	INSERTED.[DealTime],
	INSERTED.[AddTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[GongDanType],
	INSERTED.[DisableSend],
	INSERTED.[DisableProcee],
	INSERTED.[DisableCompelte],
	INSERTED.[DisableCallback],
	INSERTED.[DisableShenJi],
	INSERTED.[CloseServiceType],
	INSERTED.[CallBackServiceType],
	INSERTED.[BanJieServiceType],
	INSERTED.[DisableHolidayTime],
	INSERTED.[StartHour],
	INSERTED.[EndHour],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[IsDisableTime]
into @table
VALUES ( 
	@ServiceTypeName,
	@SortOrder,
	@ParentID,
	@DealTime,
	@AddTime,
	@PaiDanTime,
	@ChuliTime,
	@BanJieTime,
	@HuiFangTime,
	@GuanDanTime,
	@GongDanType,
	@DisableSend,
	@DisableProcee,
	@DisableCompelte,
	@DisableCallback,
	@DisableShenJi,
	@CloseServiceType,
	@CallBackServiceType,
	@BanJieServiceType,
	@DisableHolidayTime,
	@StartHour,
	@EndHour,
	@ResponseTime,
	@CheckTime,
	@IsDisableTime 
); 

SELECT 
	[ID],
	[ServiceTypeName],
	[SortOrder],
	[ParentID],
	[DealTime],
	[AddTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[GongDanType],
	[DisableSend],
	[DisableProcee],
	[DisableCompelte],
	[DisableCallback],
	[DisableShenJi],
	[CloseServiceType],
	[CallBackServiceType],
	[BanJieServiceType],
	[DisableHolidayTime],
	[StartHour],
	[EndHour],
	[ResponseTime],
	[CheckTime],
	[IsDisableTime] 
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
	[ServiceTypeName] nvarchar(100),
	[SortOrder] int,
	[ParentID] int,
	[DealTime] decimal(18, 2),
	[AddTime] datetime,
	[PaiDanTime] decimal(18, 2),
	[ChuliTime] decimal(18, 2),
	[BanJieTime] decimal(18, 2),
	[HuiFangTime] decimal(18, 2),
	[GuanDanTime] decimal(18, 2),
	[GongDanType] int,
	[DisableSend] bit,
	[DisableProcee] bit,
	[DisableCompelte] bit,
	[DisableCallback] bit,
	[DisableShenJi] bit,
	[CloseServiceType] int,
	[CallBackServiceType] int,
	[BanJieServiceType] int,
	[DisableHolidayTime] bit,
	[StartHour] nvarchar(20),
	[EndHour] nvarchar(20),
	[ResponseTime] decimal(18, 2),
	[CheckTime] decimal(18, 2),
	[IsDisableTime] bit
);

UPDATE [dbo].[ServiceType] SET 
	[ServiceType].[ServiceTypeName] = @ServiceTypeName,
	[ServiceType].[SortOrder] = @SortOrder,
	[ServiceType].[ParentID] = @ParentID,
	[ServiceType].[DealTime] = @DealTime,
	[ServiceType].[AddTime] = @AddTime,
	[ServiceType].[PaiDanTime] = @PaiDanTime,
	[ServiceType].[ChuliTime] = @ChuliTime,
	[ServiceType].[BanJieTime] = @BanJieTime,
	[ServiceType].[HuiFangTime] = @HuiFangTime,
	[ServiceType].[GuanDanTime] = @GuanDanTime,
	[ServiceType].[GongDanType] = @GongDanType,
	[ServiceType].[DisableSend] = @DisableSend,
	[ServiceType].[DisableProcee] = @DisableProcee,
	[ServiceType].[DisableCompelte] = @DisableCompelte,
	[ServiceType].[DisableCallback] = @DisableCallback,
	[ServiceType].[DisableShenJi] = @DisableShenJi,
	[ServiceType].[CloseServiceType] = @CloseServiceType,
	[ServiceType].[CallBackServiceType] = @CallBackServiceType,
	[ServiceType].[BanJieServiceType] = @BanJieServiceType,
	[ServiceType].[DisableHolidayTime] = @DisableHolidayTime,
	[ServiceType].[StartHour] = @StartHour,
	[ServiceType].[EndHour] = @EndHour,
	[ServiceType].[ResponseTime] = @ResponseTime,
	[ServiceType].[CheckTime] = @CheckTime,
	[ServiceType].[IsDisableTime] = @IsDisableTime 
output 
	INSERTED.[ID],
	INSERTED.[ServiceTypeName],
	INSERTED.[SortOrder],
	INSERTED.[ParentID],
	INSERTED.[DealTime],
	INSERTED.[AddTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[GongDanType],
	INSERTED.[DisableSend],
	INSERTED.[DisableProcee],
	INSERTED.[DisableCompelte],
	INSERTED.[DisableCallback],
	INSERTED.[DisableShenJi],
	INSERTED.[CloseServiceType],
	INSERTED.[CallBackServiceType],
	INSERTED.[BanJieServiceType],
	INSERTED.[DisableHolidayTime],
	INSERTED.[StartHour],
	INSERTED.[EndHour],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[IsDisableTime]
into @table
WHERE 
	[ServiceType].[ID] = @ID

SELECT 
	[ID],
	[ServiceTypeName],
	[SortOrder],
	[ParentID],
	[DealTime],
	[AddTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[GongDanType],
	[DisableSend],
	[DisableProcee],
	[DisableCompelte],
	[DisableCallback],
	[DisableShenJi],
	[CloseServiceType],
	[CallBackServiceType],
	[BanJieServiceType],
	[DisableHolidayTime],
	[StartHour],
	[EndHour],
	[ResponseTime],
	[CheckTime],
	[IsDisableTime] 
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
DELETE FROM [dbo].[ServiceType]
WHERE 
	[ServiceType].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ServiceType() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetServiceType(this.ID));
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
	[ServiceType].[ID],
	[ServiceType].[ServiceTypeName],
	[ServiceType].[SortOrder],
	[ServiceType].[ParentID],
	[ServiceType].[DealTime],
	[ServiceType].[AddTime],
	[ServiceType].[PaiDanTime],
	[ServiceType].[ChuliTime],
	[ServiceType].[BanJieTime],
	[ServiceType].[HuiFangTime],
	[ServiceType].[GuanDanTime],
	[ServiceType].[GongDanType],
	[ServiceType].[DisableSend],
	[ServiceType].[DisableProcee],
	[ServiceType].[DisableCompelte],
	[ServiceType].[DisableCallback],
	[ServiceType].[DisableShenJi],
	[ServiceType].[CloseServiceType],
	[ServiceType].[CallBackServiceType],
	[ServiceType].[BanJieServiceType],
	[ServiceType].[DisableHolidayTime],
	[ServiceType].[StartHour],
	[ServiceType].[EndHour],
	[ServiceType].[ResponseTime],
	[ServiceType].[CheckTime],
	[ServiceType].[IsDisableTime]
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
                return "ServiceType";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ServiceType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceTypeName">serviceTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="parentID">parentID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="gongDanType">gongDanType</param>
		/// <param name="disableSend">disableSend</param>
		/// <param name="disableProcee">disableProcee</param>
		/// <param name="disableCompelte">disableCompelte</param>
		/// <param name="disableCallback">disableCallback</param>
		/// <param name="disableShenJi">disableShenJi</param>
		/// <param name="closeServiceType">closeServiceType</param>
		/// <param name="callBackServiceType">callBackServiceType</param>
		/// <param name="banJieServiceType">banJieServiceType</param>
		/// <param name="disableHolidayTime">disableHolidayTime</param>
		/// <param name="startHour">startHour</param>
		/// <param name="endHour">endHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="isDisableTime">isDisableTime</param>
		public static void InsertServiceType(string @serviceTypeName, int @sortOrder, int @parentID, decimal @dealTime, DateTime @addTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, int @gongDanType, bool @disableSend, bool @disableProcee, bool @disableCompelte, bool @disableCallback, bool @disableShenJi, int @closeServiceType, int @callBackServiceType, int @banJieServiceType, bool @disableHolidayTime, string @startHour, string @endHour, decimal @responseTime, decimal @checkTime, bool @isDisableTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertServiceType(@serviceTypeName, @sortOrder, @parentID, @dealTime, @addTime, @paiDanTime, @chuliTime, @banJieTime, @huiFangTime, @guanDanTime, @gongDanType, @disableSend, @disableProcee, @disableCompelte, @disableCallback, @disableShenJi, @closeServiceType, @callBackServiceType, @banJieServiceType, @disableHolidayTime, @startHour, @endHour, @responseTime, @checkTime, @isDisableTime, helper);
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
		/// Insert a ServiceType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceTypeName">serviceTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="parentID">parentID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="gongDanType">gongDanType</param>
		/// <param name="disableSend">disableSend</param>
		/// <param name="disableProcee">disableProcee</param>
		/// <param name="disableCompelte">disableCompelte</param>
		/// <param name="disableCallback">disableCallback</param>
		/// <param name="disableShenJi">disableShenJi</param>
		/// <param name="closeServiceType">closeServiceType</param>
		/// <param name="callBackServiceType">callBackServiceType</param>
		/// <param name="banJieServiceType">banJieServiceType</param>
		/// <param name="disableHolidayTime">disableHolidayTime</param>
		/// <param name="startHour">startHour</param>
		/// <param name="endHour">endHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="isDisableTime">isDisableTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertServiceType(string @serviceTypeName, int @sortOrder, int @parentID, decimal @dealTime, DateTime @addTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, int @gongDanType, bool @disableSend, bool @disableProcee, bool @disableCompelte, bool @disableCallback, bool @disableShenJi, int @closeServiceType, int @callBackServiceType, int @banJieServiceType, bool @disableHolidayTime, string @startHour, string @endHour, decimal @responseTime, decimal @checkTime, bool @isDisableTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceTypeName] nvarchar(100),
	[SortOrder] int,
	[ParentID] int,
	[DealTime] decimal(18, 2),
	[AddTime] datetime,
	[PaiDanTime] decimal(18, 2),
	[ChuliTime] decimal(18, 2),
	[BanJieTime] decimal(18, 2),
	[HuiFangTime] decimal(18, 2),
	[GuanDanTime] decimal(18, 2),
	[GongDanType] int,
	[DisableSend] bit,
	[DisableProcee] bit,
	[DisableCompelte] bit,
	[DisableCallback] bit,
	[DisableShenJi] bit,
	[CloseServiceType] int,
	[CallBackServiceType] int,
	[BanJieServiceType] int,
	[DisableHolidayTime] bit,
	[StartHour] nvarchar(20),
	[EndHour] nvarchar(20),
	[ResponseTime] decimal(18, 2),
	[CheckTime] decimal(18, 2),
	[IsDisableTime] bit
);

INSERT INTO [dbo].[ServiceType] (
	[ServiceType].[ServiceTypeName],
	[ServiceType].[SortOrder],
	[ServiceType].[ParentID],
	[ServiceType].[DealTime],
	[ServiceType].[AddTime],
	[ServiceType].[PaiDanTime],
	[ServiceType].[ChuliTime],
	[ServiceType].[BanJieTime],
	[ServiceType].[HuiFangTime],
	[ServiceType].[GuanDanTime],
	[ServiceType].[GongDanType],
	[ServiceType].[DisableSend],
	[ServiceType].[DisableProcee],
	[ServiceType].[DisableCompelte],
	[ServiceType].[DisableCallback],
	[ServiceType].[DisableShenJi],
	[ServiceType].[CloseServiceType],
	[ServiceType].[CallBackServiceType],
	[ServiceType].[BanJieServiceType],
	[ServiceType].[DisableHolidayTime],
	[ServiceType].[StartHour],
	[ServiceType].[EndHour],
	[ServiceType].[ResponseTime],
	[ServiceType].[CheckTime],
	[ServiceType].[IsDisableTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceTypeName],
	INSERTED.[SortOrder],
	INSERTED.[ParentID],
	INSERTED.[DealTime],
	INSERTED.[AddTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[GongDanType],
	INSERTED.[DisableSend],
	INSERTED.[DisableProcee],
	INSERTED.[DisableCompelte],
	INSERTED.[DisableCallback],
	INSERTED.[DisableShenJi],
	INSERTED.[CloseServiceType],
	INSERTED.[CallBackServiceType],
	INSERTED.[BanJieServiceType],
	INSERTED.[DisableHolidayTime],
	INSERTED.[StartHour],
	INSERTED.[EndHour],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[IsDisableTime]
into @table
VALUES ( 
	@ServiceTypeName,
	@SortOrder,
	@ParentID,
	@DealTime,
	@AddTime,
	@PaiDanTime,
	@ChuliTime,
	@BanJieTime,
	@HuiFangTime,
	@GuanDanTime,
	@GongDanType,
	@DisableSend,
	@DisableProcee,
	@DisableCompelte,
	@DisableCallback,
	@DisableShenJi,
	@CloseServiceType,
	@CallBackServiceType,
	@BanJieServiceType,
	@DisableHolidayTime,
	@StartHour,
	@EndHour,
	@ResponseTime,
	@CheckTime,
	@IsDisableTime 
); 

SELECT 
	[ID],
	[ServiceTypeName],
	[SortOrder],
	[ParentID],
	[DealTime],
	[AddTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[GongDanType],
	[DisableSend],
	[DisableProcee],
	[DisableCompelte],
	[DisableCallback],
	[DisableShenJi],
	[CloseServiceType],
	[CallBackServiceType],
	[BanJieServiceType],
	[DisableHolidayTime],
	[StartHour],
	[EndHour],
	[ResponseTime],
	[CheckTime],
	[IsDisableTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceTypeName", EntityBase.GetDatabaseValue(@serviceTypeName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@DealTime", EntityBase.GetDatabaseValue(@dealTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PaiDanTime", EntityBase.GetDatabaseValue(@paiDanTime)));
			parameters.Add(new SqlParameter("@ChuliTime", EntityBase.GetDatabaseValue(@chuliTime)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@HuiFangTime", EntityBase.GetDatabaseValue(@huiFangTime)));
			parameters.Add(new SqlParameter("@GuanDanTime", EntityBase.GetDatabaseValue(@guanDanTime)));
			parameters.Add(new SqlParameter("@GongDanType", EntityBase.GetDatabaseValue(@gongDanType)));
			parameters.Add(new SqlParameter("@DisableSend", @disableSend));
			parameters.Add(new SqlParameter("@DisableProcee", @disableProcee));
			parameters.Add(new SqlParameter("@DisableCompelte", @disableCompelte));
			parameters.Add(new SqlParameter("@DisableCallback", @disableCallback));
			parameters.Add(new SqlParameter("@DisableShenJi", @disableShenJi));
			parameters.Add(new SqlParameter("@CloseServiceType", EntityBase.GetDatabaseValue(@closeServiceType)));
			parameters.Add(new SqlParameter("@CallBackServiceType", EntityBase.GetDatabaseValue(@callBackServiceType)));
			parameters.Add(new SqlParameter("@BanJieServiceType", EntityBase.GetDatabaseValue(@banJieServiceType)));
			parameters.Add(new SqlParameter("@DisableHolidayTime", @disableHolidayTime));
			parameters.Add(new SqlParameter("@StartHour", EntityBase.GetDatabaseValue(@startHour)));
			parameters.Add(new SqlParameter("@EndHour", EntityBase.GetDatabaseValue(@endHour)));
			parameters.Add(new SqlParameter("@ResponseTime", EntityBase.GetDatabaseValue(@responseTime)));
			parameters.Add(new SqlParameter("@CheckTime", EntityBase.GetDatabaseValue(@checkTime)));
			parameters.Add(new SqlParameter("@IsDisableTime", @isDisableTime));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ServiceType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceTypeName">serviceTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="parentID">parentID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="gongDanType">gongDanType</param>
		/// <param name="disableSend">disableSend</param>
		/// <param name="disableProcee">disableProcee</param>
		/// <param name="disableCompelte">disableCompelte</param>
		/// <param name="disableCallback">disableCallback</param>
		/// <param name="disableShenJi">disableShenJi</param>
		/// <param name="closeServiceType">closeServiceType</param>
		/// <param name="callBackServiceType">callBackServiceType</param>
		/// <param name="banJieServiceType">banJieServiceType</param>
		/// <param name="disableHolidayTime">disableHolidayTime</param>
		/// <param name="startHour">startHour</param>
		/// <param name="endHour">endHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="isDisableTime">isDisableTime</param>
		public static void UpdateServiceType(int @iD, string @serviceTypeName, int @sortOrder, int @parentID, decimal @dealTime, DateTime @addTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, int @gongDanType, bool @disableSend, bool @disableProcee, bool @disableCompelte, bool @disableCallback, bool @disableShenJi, int @closeServiceType, int @callBackServiceType, int @banJieServiceType, bool @disableHolidayTime, string @startHour, string @endHour, decimal @responseTime, decimal @checkTime, bool @isDisableTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateServiceType(@iD, @serviceTypeName, @sortOrder, @parentID, @dealTime, @addTime, @paiDanTime, @chuliTime, @banJieTime, @huiFangTime, @guanDanTime, @gongDanType, @disableSend, @disableProcee, @disableCompelte, @disableCallback, @disableShenJi, @closeServiceType, @callBackServiceType, @banJieServiceType, @disableHolidayTime, @startHour, @endHour, @responseTime, @checkTime, @isDisableTime, helper);
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
		/// Updates a ServiceType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceTypeName">serviceTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="parentID">parentID</param>
		/// <param name="dealTime">dealTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paiDanTime">paiDanTime</param>
		/// <param name="chuliTime">chuliTime</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="huiFangTime">huiFangTime</param>
		/// <param name="guanDanTime">guanDanTime</param>
		/// <param name="gongDanType">gongDanType</param>
		/// <param name="disableSend">disableSend</param>
		/// <param name="disableProcee">disableProcee</param>
		/// <param name="disableCompelte">disableCompelte</param>
		/// <param name="disableCallback">disableCallback</param>
		/// <param name="disableShenJi">disableShenJi</param>
		/// <param name="closeServiceType">closeServiceType</param>
		/// <param name="callBackServiceType">callBackServiceType</param>
		/// <param name="banJieServiceType">banJieServiceType</param>
		/// <param name="disableHolidayTime">disableHolidayTime</param>
		/// <param name="startHour">startHour</param>
		/// <param name="endHour">endHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="isDisableTime">isDisableTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateServiceType(int @iD, string @serviceTypeName, int @sortOrder, int @parentID, decimal @dealTime, DateTime @addTime, decimal @paiDanTime, decimal @chuliTime, decimal @banJieTime, decimal @huiFangTime, decimal @guanDanTime, int @gongDanType, bool @disableSend, bool @disableProcee, bool @disableCompelte, bool @disableCallback, bool @disableShenJi, int @closeServiceType, int @callBackServiceType, int @banJieServiceType, bool @disableHolidayTime, string @startHour, string @endHour, decimal @responseTime, decimal @checkTime, bool @isDisableTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceTypeName] nvarchar(100),
	[SortOrder] int,
	[ParentID] int,
	[DealTime] decimal(18, 2),
	[AddTime] datetime,
	[PaiDanTime] decimal(18, 2),
	[ChuliTime] decimal(18, 2),
	[BanJieTime] decimal(18, 2),
	[HuiFangTime] decimal(18, 2),
	[GuanDanTime] decimal(18, 2),
	[GongDanType] int,
	[DisableSend] bit,
	[DisableProcee] bit,
	[DisableCompelte] bit,
	[DisableCallback] bit,
	[DisableShenJi] bit,
	[CloseServiceType] int,
	[CallBackServiceType] int,
	[BanJieServiceType] int,
	[DisableHolidayTime] bit,
	[StartHour] nvarchar(20),
	[EndHour] nvarchar(20),
	[ResponseTime] decimal(18, 2),
	[CheckTime] decimal(18, 2),
	[IsDisableTime] bit
);

UPDATE [dbo].[ServiceType] SET 
	[ServiceType].[ServiceTypeName] = @ServiceTypeName,
	[ServiceType].[SortOrder] = @SortOrder,
	[ServiceType].[ParentID] = @ParentID,
	[ServiceType].[DealTime] = @DealTime,
	[ServiceType].[AddTime] = @AddTime,
	[ServiceType].[PaiDanTime] = @PaiDanTime,
	[ServiceType].[ChuliTime] = @ChuliTime,
	[ServiceType].[BanJieTime] = @BanJieTime,
	[ServiceType].[HuiFangTime] = @HuiFangTime,
	[ServiceType].[GuanDanTime] = @GuanDanTime,
	[ServiceType].[GongDanType] = @GongDanType,
	[ServiceType].[DisableSend] = @DisableSend,
	[ServiceType].[DisableProcee] = @DisableProcee,
	[ServiceType].[DisableCompelte] = @DisableCompelte,
	[ServiceType].[DisableCallback] = @DisableCallback,
	[ServiceType].[DisableShenJi] = @DisableShenJi,
	[ServiceType].[CloseServiceType] = @CloseServiceType,
	[ServiceType].[CallBackServiceType] = @CallBackServiceType,
	[ServiceType].[BanJieServiceType] = @BanJieServiceType,
	[ServiceType].[DisableHolidayTime] = @DisableHolidayTime,
	[ServiceType].[StartHour] = @StartHour,
	[ServiceType].[EndHour] = @EndHour,
	[ServiceType].[ResponseTime] = @ResponseTime,
	[ServiceType].[CheckTime] = @CheckTime,
	[ServiceType].[IsDisableTime] = @IsDisableTime 
output 
	INSERTED.[ID],
	INSERTED.[ServiceTypeName],
	INSERTED.[SortOrder],
	INSERTED.[ParentID],
	INSERTED.[DealTime],
	INSERTED.[AddTime],
	INSERTED.[PaiDanTime],
	INSERTED.[ChuliTime],
	INSERTED.[BanJieTime],
	INSERTED.[HuiFangTime],
	INSERTED.[GuanDanTime],
	INSERTED.[GongDanType],
	INSERTED.[DisableSend],
	INSERTED.[DisableProcee],
	INSERTED.[DisableCompelte],
	INSERTED.[DisableCallback],
	INSERTED.[DisableShenJi],
	INSERTED.[CloseServiceType],
	INSERTED.[CallBackServiceType],
	INSERTED.[BanJieServiceType],
	INSERTED.[DisableHolidayTime],
	INSERTED.[StartHour],
	INSERTED.[EndHour],
	INSERTED.[ResponseTime],
	INSERTED.[CheckTime],
	INSERTED.[IsDisableTime]
into @table
WHERE 
	[ServiceType].[ID] = @ID

SELECT 
	[ID],
	[ServiceTypeName],
	[SortOrder],
	[ParentID],
	[DealTime],
	[AddTime],
	[PaiDanTime],
	[ChuliTime],
	[BanJieTime],
	[HuiFangTime],
	[GuanDanTime],
	[GongDanType],
	[DisableSend],
	[DisableProcee],
	[DisableCompelte],
	[DisableCallback],
	[DisableShenJi],
	[CloseServiceType],
	[CallBackServiceType],
	[BanJieServiceType],
	[DisableHolidayTime],
	[StartHour],
	[EndHour],
	[ResponseTime],
	[CheckTime],
	[IsDisableTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceTypeName", EntityBase.GetDatabaseValue(@serviceTypeName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@DealTime", EntityBase.GetDatabaseValue(@dealTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PaiDanTime", EntityBase.GetDatabaseValue(@paiDanTime)));
			parameters.Add(new SqlParameter("@ChuliTime", EntityBase.GetDatabaseValue(@chuliTime)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@HuiFangTime", EntityBase.GetDatabaseValue(@huiFangTime)));
			parameters.Add(new SqlParameter("@GuanDanTime", EntityBase.GetDatabaseValue(@guanDanTime)));
			parameters.Add(new SqlParameter("@GongDanType", EntityBase.GetDatabaseValue(@gongDanType)));
			parameters.Add(new SqlParameter("@DisableSend", @disableSend));
			parameters.Add(new SqlParameter("@DisableProcee", @disableProcee));
			parameters.Add(new SqlParameter("@DisableCompelte", @disableCompelte));
			parameters.Add(new SqlParameter("@DisableCallback", @disableCallback));
			parameters.Add(new SqlParameter("@DisableShenJi", @disableShenJi));
			parameters.Add(new SqlParameter("@CloseServiceType", EntityBase.GetDatabaseValue(@closeServiceType)));
			parameters.Add(new SqlParameter("@CallBackServiceType", EntityBase.GetDatabaseValue(@callBackServiceType)));
			parameters.Add(new SqlParameter("@BanJieServiceType", EntityBase.GetDatabaseValue(@banJieServiceType)));
			parameters.Add(new SqlParameter("@DisableHolidayTime", @disableHolidayTime));
			parameters.Add(new SqlParameter("@StartHour", EntityBase.GetDatabaseValue(@startHour)));
			parameters.Add(new SqlParameter("@EndHour", EntityBase.GetDatabaseValue(@endHour)));
			parameters.Add(new SqlParameter("@ResponseTime", EntityBase.GetDatabaseValue(@responseTime)));
			parameters.Add(new SqlParameter("@CheckTime", EntityBase.GetDatabaseValue(@checkTime)));
			parameters.Add(new SqlParameter("@IsDisableTime", @isDisableTime));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ServiceType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteServiceType(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteServiceType(@iD, helper);
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
		/// Deletes a ServiceType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteServiceType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ServiceType]
WHERE 
	[ServiceType].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ServiceType object.
		/// </summary>
		/// <returns>The newly created ServiceType object.</returns>
		public static ServiceType CreateServiceType()
		{
			return InitializeNew<ServiceType>();
		}
		
		/// <summary>
		/// Retrieve information for a ServiceType by a ServiceType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ServiceType</returns>
		public static ServiceType GetServiceType(int @iD)
		{
			string commandText = @"
SELECT 
" + ServiceType.SelectFieldList + @"
FROM [dbo].[ServiceType] 
WHERE 
	[ServiceType].[ID] = @ID " + ServiceType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ServiceType>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ServiceType by a ServiceType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ServiceType</returns>
		public static ServiceType GetServiceType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ServiceType.SelectFieldList + @"
FROM [dbo].[ServiceType] 
WHERE 
	[ServiceType].[ID] = @ID " + ServiceType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ServiceType>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ServiceType objects.
		/// </summary>
		/// <returns>The retrieved collection of ServiceType objects.</returns>
		public static EntityList<ServiceType> GetServiceTypes()
		{
			string commandText = @"
SELECT " + ServiceType.SelectFieldList + "FROM [dbo].[ServiceType] " + ServiceType.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ServiceType>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ServiceType objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ServiceType objects.</returns>
        public static EntityList<ServiceType> GetServiceTypes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ServiceType>(SelectFieldList, "FROM [dbo].[ServiceType]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ServiceType objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ServiceType objects.</returns>
        public static EntityList<ServiceType> GetServiceTypes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ServiceType>(SelectFieldList, "FROM [dbo].[ServiceType]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ServiceType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ServiceType objects.</returns>
		protected static EntityList<ServiceType> GetServiceTypes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetServiceTypes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ServiceType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ServiceType objects.</returns>
		protected static EntityList<ServiceType> GetServiceTypes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetServiceTypes(string.Empty, where, parameters, ServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ServiceType objects.</returns>
		protected static EntityList<ServiceType> GetServiceTypes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetServiceTypes(prefix, where, parameters, ServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ServiceType objects.</returns>
		protected static EntityList<ServiceType> GetServiceTypes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetServiceTypes(string.Empty, where, parameters, ServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ServiceType objects.</returns>
		protected static EntityList<ServiceType> GetServiceTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetServiceTypes(prefix, where, parameters, ServiceType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ServiceType objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ServiceType objects.</returns>
		protected static EntityList<ServiceType> GetServiceTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ServiceType.SelectFieldList + "FROM [dbo].[ServiceType] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ServiceType>(reader);
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
        protected static EntityList<ServiceType> GetServiceTypes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ServiceType>(SelectFieldList, "FROM [dbo].[ServiceType] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ServiceType objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetServiceTypeCount()
        {
            return GetServiceTypeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ServiceType objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetServiceTypeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ServiceType] " + where;

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
		public static partial class ServiceType_Properties
		{
			public const string ID = "ID";
			public const string ServiceTypeName = "ServiceTypeName";
			public const string SortOrder = "SortOrder";
			public const string ParentID = "ParentID";
			public const string DealTime = "DealTime";
			public const string AddTime = "AddTime";
			public const string PaiDanTime = "PaiDanTime";
			public const string ChuliTime = "ChuliTime";
			public const string BanJieTime = "BanJieTime";
			public const string HuiFangTime = "HuiFangTime";
			public const string GuanDanTime = "GuanDanTime";
			public const string GongDanType = "GongDanType";
			public const string DisableSend = "DisableSend";
			public const string DisableProcee = "DisableProcee";
			public const string DisableCompelte = "DisableCompelte";
			public const string DisableCallback = "DisableCallback";
			public const string DisableShenJi = "DisableShenJi";
			public const string CloseServiceType = "CloseServiceType";
			public const string CallBackServiceType = "CallBackServiceType";
			public const string BanJieServiceType = "BanJieServiceType";
			public const string DisableHolidayTime = "DisableHolidayTime";
			public const string StartHour = "StartHour";
			public const string EndHour = "EndHour";
			public const string ResponseTime = "ResponseTime";
			public const string CheckTime = "CheckTime";
			public const string IsDisableTime = "IsDisableTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceTypeName" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"ParentID" , "int:"},
    			 {"DealTime" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PaiDanTime" , "decimal:"},
    			 {"ChuliTime" , "decimal:"},
    			 {"BanJieTime" , "decimal:"},
    			 {"HuiFangTime" , "decimal:"},
    			 {"GuanDanTime" , "decimal:"},
    			 {"GongDanType" , "int:"},
    			 {"DisableSend" , "bool:"},
    			 {"DisableProcee" , "bool:"},
    			 {"DisableCompelte" , "bool:"},
    			 {"DisableCallback" , "bool:"},
    			 {"DisableShenJi" , "bool:"},
    			 {"CloseServiceType" , "int:"},
    			 {"CallBackServiceType" , "int:"},
    			 {"BanJieServiceType" , "int:"},
    			 {"DisableHolidayTime" , "bool:"},
    			 {"StartHour" , "string:"},
    			 {"EndHour" , "string:"},
    			 {"ResponseTime" , "decimal:"},
    			 {"CheckTime" , "decimal:"},
    			 {"IsDisableTime" , "bool:"},
            };
		}
		#endregion
	}
}
