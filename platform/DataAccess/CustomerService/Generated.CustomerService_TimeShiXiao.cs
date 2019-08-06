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
	/// This object represents the properties and methods of a CustomerService_TimeShiXiao.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ServiceID: {ServiceID}")]
	public partial class CustomerService_TimeShiXiao 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
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
		private DateTime _xiaDanDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime XiaDanDate
		{
			[DebuggerStepThrough()]
			get { return this._xiaDanDate; }
			set 
			{
				if (this._xiaDanDate != value) 
				{
					this._xiaDanDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("XiaDanDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _xiaDanTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal XiaDanTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._xiaDanTakeHour; }
			set 
			{
				if (this._xiaDanTakeHour != value) 
				{
					this._xiaDanTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("XiaDanTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _xiaDanTimeOutStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int XiaDanTimeOutStatus
		{
			[DebuggerStepThrough()]
			get { return this._xiaDanTimeOutStatus; }
			set 
			{
				if (this._xiaDanTimeOutStatus != value) 
				{
					this._xiaDanTimeOutStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("XiaDanTimeOutStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _xiaDanChaoShiTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal XiaDanChaoShiTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._xiaDanChaoShiTakeHour; }
			set 
			{
				if (this._xiaDanChaoShiTakeHour != value) 
				{
					this._xiaDanChaoShiTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("XiaDanChaoShiTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _paiDanDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PaiDanDate
		{
			[DebuggerStepThrough()]
			get { return this._paiDanDate; }
			set 
			{
				if (this._paiDanDate != value) 
				{
					this._paiDanDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaiDanDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _paiDanTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PaiDanTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._paiDanTakeHour; }
			set 
			{
				if (this._paiDanTakeHour != value) 
				{
					this._paiDanTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaiDanTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _paiDanTimeOutStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PaiDanTimeOutStatus
		{
			[DebuggerStepThrough()]
			get { return this._paiDanTimeOutStatus; }
			set 
			{
				if (this._paiDanTimeOutStatus != value) 
				{
					this._paiDanTimeOutStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaiDanTimeOutStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _paiDanChaoShiTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal PaiDanChaoShiTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._paiDanChaoShiTakeHour; }
			set 
			{
				if (this._paiDanChaoShiTakeHour != value) 
				{
					this._paiDanChaoShiTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaiDanChaoShiTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _responseTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ResponseTime
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
		private decimal _responseTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ResponseTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._responseTakeHour; }
			set 
			{
				if (this._responseTakeHour != value) 
				{
					this._responseTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("ResponseTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _responseTimeOutStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ResponseTimeOutStatus
		{
			[DebuggerStepThrough()]
			get { return this._responseTimeOutStatus; }
			set 
			{
				if (this._responseTimeOutStatus != value) 
				{
					this._responseTimeOutStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ResponseTimeOutStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _responseChaoShiTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ResponseChaoShiTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._responseChaoShiTakeHour; }
			set 
			{
				if (this._responseChaoShiTakeHour != value) 
				{
					this._responseChaoShiTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("ResponseChaoShiTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _checkTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CheckTime
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
		private decimal _checkTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CheckTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._checkTakeHour; }
			set 
			{
				if (this._checkTakeHour != value) 
				{
					this._checkTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _checkTimeOutStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CheckTimeOutStatus
		{
			[DebuggerStepThrough()]
			get { return this._checkTimeOutStatus; }
			set 
			{
				if (this._checkTimeOutStatus != value) 
				{
					this._checkTimeOutStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckTimeOutStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _checkChaoShiTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CheckChaoShiTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._checkChaoShiTakeHour; }
			set 
			{
				if (this._checkChaoShiTakeHour != value) 
				{
					this._checkChaoShiTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("CheckChaoShiTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _chuliDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ChuliDate
		{
			[DebuggerStepThrough()]
			get { return this._chuliDate; }
			set 
			{
				if (this._chuliDate != value) 
				{
					this._chuliDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChuliDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _processTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ProcessTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._processTakeHour; }
			set 
			{
				if (this._processTakeHour != value) 
				{
					this._processTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _processTimeOutStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProcessTimeOutStatus
		{
			[DebuggerStepThrough()]
			get { return this._processTimeOutStatus; }
			set 
			{
				if (this._processTimeOutStatus != value) 
				{
					this._processTimeOutStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessTimeOutStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _processChaoShiTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal ProcessChaoShiTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._processChaoShiTakeHour; }
			set 
			{
				if (this._processChaoShiTakeHour != value) 
				{
					this._processChaoShiTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProcessChaoShiTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _banJieTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime BanJieTime
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
		private decimal _banJieTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BanJieTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._banJieTakeHour; }
			set 
			{
				if (this._banJieTakeHour != value) 
				{
					this._banJieTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("BanJieTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _banJieTimeOutStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BanJieTimeOutStatus
		{
			[DebuggerStepThrough()]
			get { return this._banJieTimeOutStatus; }
			set 
			{
				if (this._banJieTimeOutStatus != value) 
				{
					this._banJieTimeOutStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("BanJieTimeOutStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _banJieChaoShiTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BanJieChaoShiTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._banJieChaoShiTakeHour; }
			set 
			{
				if (this._banJieChaoShiTakeHour != value) 
				{
					this._banJieChaoShiTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("BanJieChaoShiTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _closeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CloseTime
		{
			[DebuggerStepThrough()]
			get { return this._closeTime; }
			set 
			{
				if (this._closeTime != value) 
				{
					this._closeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CloseTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _closeTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CloseTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._closeTakeHour; }
			set 
			{
				if (this._closeTakeHour != value) 
				{
					this._closeTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("CloseTakeHour");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _closeTimeOutStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CloseTimeOutStatus
		{
			[DebuggerStepThrough()]
			get { return this._closeTimeOutStatus; }
			set 
			{
				if (this._closeTimeOutStatus != value) 
				{
					this._closeTimeOutStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("CloseTimeOutStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _closeChaoShiTakeHour = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal CloseChaoShiTakeHour
		{
			[DebuggerStepThrough()]
			get { return this._closeChaoShiTakeHour; }
			set 
			{
				if (this._closeChaoShiTakeHour != value) 
				{
					this._closeChaoShiTakeHour = value;
					this.IsDirty = true;	
					OnPropertyChanged("CloseChaoShiTakeHour");
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
	[ServiceID] int,
	[XiaDanDate] datetime,
	[XiaDanTakeHour] decimal(18, 8),
	[XiaDanTimeOutStatus] int,
	[XiaDanChaoShiTakeHour] decimal(18, 8),
	[PaiDanDate] datetime,
	[PaiDanTakeHour] decimal(18, 8),
	[PaiDanTimeOutStatus] int,
	[PaiDanChaoShiTakeHour] decimal(18, 8),
	[ResponseTime] datetime,
	[ResponseTakeHour] decimal(18, 8),
	[ResponseTimeOutStatus] int,
	[ResponseChaoShiTakeHour] decimal(18, 8),
	[CheckTime] datetime,
	[CheckTakeHour] decimal(18, 8),
	[CheckTimeOutStatus] int,
	[CheckChaoShiTakeHour] decimal(18, 8),
	[ChuliDate] datetime,
	[ProcessTakeHour] decimal(18, 8),
	[ProcessTimeOutStatus] int,
	[ProcessChaoShiTakeHour] decimal(18, 8),
	[BanJieTime] datetime,
	[BanJieTakeHour] decimal(18, 8),
	[BanJieTimeOutStatus] int,
	[BanJieChaoShiTakeHour] decimal(18, 8),
	[CloseTime] datetime,
	[CloseTakeHour] decimal(18, 8),
	[CloseTimeOutStatus] int,
	[CloseChaoShiTakeHour] decimal(18, 8)
);

INSERT INTO [dbo].[CustomerService_TimeShiXiao] (
	[CustomerService_TimeShiXiao].[ServiceID],
	[CustomerService_TimeShiXiao].[XiaDanDate],
	[CustomerService_TimeShiXiao].[XiaDanTakeHour],
	[CustomerService_TimeShiXiao].[XiaDanTimeOutStatus],
	[CustomerService_TimeShiXiao].[XiaDanChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[PaiDanDate],
	[CustomerService_TimeShiXiao].[PaiDanTakeHour],
	[CustomerService_TimeShiXiao].[PaiDanTimeOutStatus],
	[CustomerService_TimeShiXiao].[PaiDanChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[ResponseTime],
	[CustomerService_TimeShiXiao].[ResponseTakeHour],
	[CustomerService_TimeShiXiao].[ResponseTimeOutStatus],
	[CustomerService_TimeShiXiao].[ResponseChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[CheckTime],
	[CustomerService_TimeShiXiao].[CheckTakeHour],
	[CustomerService_TimeShiXiao].[CheckTimeOutStatus],
	[CustomerService_TimeShiXiao].[CheckChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[ChuliDate],
	[CustomerService_TimeShiXiao].[ProcessTakeHour],
	[CustomerService_TimeShiXiao].[ProcessTimeOutStatus],
	[CustomerService_TimeShiXiao].[ProcessChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[BanJieTime],
	[CustomerService_TimeShiXiao].[BanJieTakeHour],
	[CustomerService_TimeShiXiao].[BanJieTimeOutStatus],
	[CustomerService_TimeShiXiao].[BanJieChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[CloseTime],
	[CustomerService_TimeShiXiao].[CloseTakeHour],
	[CustomerService_TimeShiXiao].[CloseTimeOutStatus],
	[CustomerService_TimeShiXiao].[CloseChaoShiTakeHour]
) 
output 
	INSERTED.[ServiceID],
	INSERTED.[XiaDanDate],
	INSERTED.[XiaDanTakeHour],
	INSERTED.[XiaDanTimeOutStatus],
	INSERTED.[XiaDanChaoShiTakeHour],
	INSERTED.[PaiDanDate],
	INSERTED.[PaiDanTakeHour],
	INSERTED.[PaiDanTimeOutStatus],
	INSERTED.[PaiDanChaoShiTakeHour],
	INSERTED.[ResponseTime],
	INSERTED.[ResponseTakeHour],
	INSERTED.[ResponseTimeOutStatus],
	INSERTED.[ResponseChaoShiTakeHour],
	INSERTED.[CheckTime],
	INSERTED.[CheckTakeHour],
	INSERTED.[CheckTimeOutStatus],
	INSERTED.[CheckChaoShiTakeHour],
	INSERTED.[ChuliDate],
	INSERTED.[ProcessTakeHour],
	INSERTED.[ProcessTimeOutStatus],
	INSERTED.[ProcessChaoShiTakeHour],
	INSERTED.[BanJieTime],
	INSERTED.[BanJieTakeHour],
	INSERTED.[BanJieTimeOutStatus],
	INSERTED.[BanJieChaoShiTakeHour],
	INSERTED.[CloseTime],
	INSERTED.[CloseTakeHour],
	INSERTED.[CloseTimeOutStatus],
	INSERTED.[CloseChaoShiTakeHour]
into @table
VALUES ( 
	@ServiceID,
	@XiaDanDate,
	@XiaDanTakeHour,
	@XiaDanTimeOutStatus,
	@XiaDanChaoShiTakeHour,
	@PaiDanDate,
	@PaiDanTakeHour,
	@PaiDanTimeOutStatus,
	@PaiDanChaoShiTakeHour,
	@ResponseTime,
	@ResponseTakeHour,
	@ResponseTimeOutStatus,
	@ResponseChaoShiTakeHour,
	@CheckTime,
	@CheckTakeHour,
	@CheckTimeOutStatus,
	@CheckChaoShiTakeHour,
	@ChuliDate,
	@ProcessTakeHour,
	@ProcessTimeOutStatus,
	@ProcessChaoShiTakeHour,
	@BanJieTime,
	@BanJieTakeHour,
	@BanJieTimeOutStatus,
	@BanJieChaoShiTakeHour,
	@CloseTime,
	@CloseTakeHour,
	@CloseTimeOutStatus,
	@CloseChaoShiTakeHour 
); 

SELECT 
	[ServiceID],
	[XiaDanDate],
	[XiaDanTakeHour],
	[XiaDanTimeOutStatus],
	[XiaDanChaoShiTakeHour],
	[PaiDanDate],
	[PaiDanTakeHour],
	[PaiDanTimeOutStatus],
	[PaiDanChaoShiTakeHour],
	[ResponseTime],
	[ResponseTakeHour],
	[ResponseTimeOutStatus],
	[ResponseChaoShiTakeHour],
	[CheckTime],
	[CheckTakeHour],
	[CheckTimeOutStatus],
	[CheckChaoShiTakeHour],
	[ChuliDate],
	[ProcessTakeHour],
	[ProcessTimeOutStatus],
	[ProcessChaoShiTakeHour],
	[BanJieTime],
	[BanJieTakeHour],
	[BanJieTimeOutStatus],
	[BanJieChaoShiTakeHour],
	[CloseTime],
	[CloseTakeHour],
	[CloseTimeOutStatus],
	[CloseChaoShiTakeHour] 
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
	[ServiceID] int,
	[XiaDanDate] datetime,
	[XiaDanTakeHour] decimal(18, 8),
	[XiaDanTimeOutStatus] int,
	[XiaDanChaoShiTakeHour] decimal(18, 8),
	[PaiDanDate] datetime,
	[PaiDanTakeHour] decimal(18, 8),
	[PaiDanTimeOutStatus] int,
	[PaiDanChaoShiTakeHour] decimal(18, 8),
	[ResponseTime] datetime,
	[ResponseTakeHour] decimal(18, 8),
	[ResponseTimeOutStatus] int,
	[ResponseChaoShiTakeHour] decimal(18, 8),
	[CheckTime] datetime,
	[CheckTakeHour] decimal(18, 8),
	[CheckTimeOutStatus] int,
	[CheckChaoShiTakeHour] decimal(18, 8),
	[ChuliDate] datetime,
	[ProcessTakeHour] decimal(18, 8),
	[ProcessTimeOutStatus] int,
	[ProcessChaoShiTakeHour] decimal(18, 8),
	[BanJieTime] datetime,
	[BanJieTakeHour] decimal(18, 8),
	[BanJieTimeOutStatus] int,
	[BanJieChaoShiTakeHour] decimal(18, 8),
	[CloseTime] datetime,
	[CloseTakeHour] decimal(18, 8),
	[CloseTimeOutStatus] int,
	[CloseChaoShiTakeHour] decimal(18, 8)
);

UPDATE [dbo].[CustomerService_TimeShiXiao] SET 
	[CustomerService_TimeShiXiao].[XiaDanDate] = @XiaDanDate,
	[CustomerService_TimeShiXiao].[XiaDanTakeHour] = @XiaDanTakeHour,
	[CustomerService_TimeShiXiao].[XiaDanTimeOutStatus] = @XiaDanTimeOutStatus,
	[CustomerService_TimeShiXiao].[XiaDanChaoShiTakeHour] = @XiaDanChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[PaiDanDate] = @PaiDanDate,
	[CustomerService_TimeShiXiao].[PaiDanTakeHour] = @PaiDanTakeHour,
	[CustomerService_TimeShiXiao].[PaiDanTimeOutStatus] = @PaiDanTimeOutStatus,
	[CustomerService_TimeShiXiao].[PaiDanChaoShiTakeHour] = @PaiDanChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[ResponseTime] = @ResponseTime,
	[CustomerService_TimeShiXiao].[ResponseTakeHour] = @ResponseTakeHour,
	[CustomerService_TimeShiXiao].[ResponseTimeOutStatus] = @ResponseTimeOutStatus,
	[CustomerService_TimeShiXiao].[ResponseChaoShiTakeHour] = @ResponseChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[CheckTime] = @CheckTime,
	[CustomerService_TimeShiXiao].[CheckTakeHour] = @CheckTakeHour,
	[CustomerService_TimeShiXiao].[CheckTimeOutStatus] = @CheckTimeOutStatus,
	[CustomerService_TimeShiXiao].[CheckChaoShiTakeHour] = @CheckChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[ChuliDate] = @ChuliDate,
	[CustomerService_TimeShiXiao].[ProcessTakeHour] = @ProcessTakeHour,
	[CustomerService_TimeShiXiao].[ProcessTimeOutStatus] = @ProcessTimeOutStatus,
	[CustomerService_TimeShiXiao].[ProcessChaoShiTakeHour] = @ProcessChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[BanJieTime] = @BanJieTime,
	[CustomerService_TimeShiXiao].[BanJieTakeHour] = @BanJieTakeHour,
	[CustomerService_TimeShiXiao].[BanJieTimeOutStatus] = @BanJieTimeOutStatus,
	[CustomerService_TimeShiXiao].[BanJieChaoShiTakeHour] = @BanJieChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[CloseTime] = @CloseTime,
	[CustomerService_TimeShiXiao].[CloseTakeHour] = @CloseTakeHour,
	[CustomerService_TimeShiXiao].[CloseTimeOutStatus] = @CloseTimeOutStatus,
	[CustomerService_TimeShiXiao].[CloseChaoShiTakeHour] = @CloseChaoShiTakeHour 
output 
	INSERTED.[ServiceID],
	INSERTED.[XiaDanDate],
	INSERTED.[XiaDanTakeHour],
	INSERTED.[XiaDanTimeOutStatus],
	INSERTED.[XiaDanChaoShiTakeHour],
	INSERTED.[PaiDanDate],
	INSERTED.[PaiDanTakeHour],
	INSERTED.[PaiDanTimeOutStatus],
	INSERTED.[PaiDanChaoShiTakeHour],
	INSERTED.[ResponseTime],
	INSERTED.[ResponseTakeHour],
	INSERTED.[ResponseTimeOutStatus],
	INSERTED.[ResponseChaoShiTakeHour],
	INSERTED.[CheckTime],
	INSERTED.[CheckTakeHour],
	INSERTED.[CheckTimeOutStatus],
	INSERTED.[CheckChaoShiTakeHour],
	INSERTED.[ChuliDate],
	INSERTED.[ProcessTakeHour],
	INSERTED.[ProcessTimeOutStatus],
	INSERTED.[ProcessChaoShiTakeHour],
	INSERTED.[BanJieTime],
	INSERTED.[BanJieTakeHour],
	INSERTED.[BanJieTimeOutStatus],
	INSERTED.[BanJieChaoShiTakeHour],
	INSERTED.[CloseTime],
	INSERTED.[CloseTakeHour],
	INSERTED.[CloseTimeOutStatus],
	INSERTED.[CloseChaoShiTakeHour]
into @table
WHERE 
	[CustomerService_TimeShiXiao].[ServiceID] = @ServiceID

SELECT 
	[ServiceID],
	[XiaDanDate],
	[XiaDanTakeHour],
	[XiaDanTimeOutStatus],
	[XiaDanChaoShiTakeHour],
	[PaiDanDate],
	[PaiDanTakeHour],
	[PaiDanTimeOutStatus],
	[PaiDanChaoShiTakeHour],
	[ResponseTime],
	[ResponseTakeHour],
	[ResponseTimeOutStatus],
	[ResponseChaoShiTakeHour],
	[CheckTime],
	[CheckTakeHour],
	[CheckTimeOutStatus],
	[CheckChaoShiTakeHour],
	[ChuliDate],
	[ProcessTakeHour],
	[ProcessTimeOutStatus],
	[ProcessChaoShiTakeHour],
	[BanJieTime],
	[BanJieTakeHour],
	[BanJieTimeOutStatus],
	[BanJieChaoShiTakeHour],
	[CloseTime],
	[CloseTakeHour],
	[CloseTimeOutStatus],
	[CloseChaoShiTakeHour] 
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
DELETE FROM [dbo].[CustomerService_TimeShiXiao]
WHERE 
	[CustomerService_TimeShiXiao].[ServiceID] = @ServiceID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CustomerService_TimeShiXiao() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCustomerService_TimeShiXiao(this.ServiceID));
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
	[CustomerService_TimeShiXiao].[ServiceID],
	[CustomerService_TimeShiXiao].[XiaDanDate],
	[CustomerService_TimeShiXiao].[XiaDanTakeHour],
	[CustomerService_TimeShiXiao].[XiaDanTimeOutStatus],
	[CustomerService_TimeShiXiao].[XiaDanChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[PaiDanDate],
	[CustomerService_TimeShiXiao].[PaiDanTakeHour],
	[CustomerService_TimeShiXiao].[PaiDanTimeOutStatus],
	[CustomerService_TimeShiXiao].[PaiDanChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[ResponseTime],
	[CustomerService_TimeShiXiao].[ResponseTakeHour],
	[CustomerService_TimeShiXiao].[ResponseTimeOutStatus],
	[CustomerService_TimeShiXiao].[ResponseChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[CheckTime],
	[CustomerService_TimeShiXiao].[CheckTakeHour],
	[CustomerService_TimeShiXiao].[CheckTimeOutStatus],
	[CustomerService_TimeShiXiao].[CheckChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[ChuliDate],
	[CustomerService_TimeShiXiao].[ProcessTakeHour],
	[CustomerService_TimeShiXiao].[ProcessTimeOutStatus],
	[CustomerService_TimeShiXiao].[ProcessChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[BanJieTime],
	[CustomerService_TimeShiXiao].[BanJieTakeHour],
	[CustomerService_TimeShiXiao].[BanJieTimeOutStatus],
	[CustomerService_TimeShiXiao].[BanJieChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[CloseTime],
	[CustomerService_TimeShiXiao].[CloseTakeHour],
	[CustomerService_TimeShiXiao].[CloseTimeOutStatus],
	[CustomerService_TimeShiXiao].[CloseChaoShiTakeHour]
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
                return "CustomerService_TimeShiXiao";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CustomerService_TimeShiXiao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="xiaDanDate">xiaDanDate</param>
		/// <param name="xiaDanTakeHour">xiaDanTakeHour</param>
		/// <param name="xiaDanTimeOutStatus">xiaDanTimeOutStatus</param>
		/// <param name="xiaDanChaoShiTakeHour">xiaDanChaoShiTakeHour</param>
		/// <param name="paiDanDate">paiDanDate</param>
		/// <param name="paiDanTakeHour">paiDanTakeHour</param>
		/// <param name="paiDanTimeOutStatus">paiDanTimeOutStatus</param>
		/// <param name="paiDanChaoShiTakeHour">paiDanChaoShiTakeHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="responseTakeHour">responseTakeHour</param>
		/// <param name="responseTimeOutStatus">responseTimeOutStatus</param>
		/// <param name="responseChaoShiTakeHour">responseChaoShiTakeHour</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="checkTakeHour">checkTakeHour</param>
		/// <param name="checkTimeOutStatus">checkTimeOutStatus</param>
		/// <param name="checkChaoShiTakeHour">checkChaoShiTakeHour</param>
		/// <param name="chuliDate">chuliDate</param>
		/// <param name="processTakeHour">processTakeHour</param>
		/// <param name="processTimeOutStatus">processTimeOutStatus</param>
		/// <param name="processChaoShiTakeHour">processChaoShiTakeHour</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="banJieTakeHour">banJieTakeHour</param>
		/// <param name="banJieTimeOutStatus">banJieTimeOutStatus</param>
		/// <param name="banJieChaoShiTakeHour">banJieChaoShiTakeHour</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="closeTakeHour">closeTakeHour</param>
		/// <param name="closeTimeOutStatus">closeTimeOutStatus</param>
		/// <param name="closeChaoShiTakeHour">closeChaoShiTakeHour</param>
		public static void InsertCustomerService_TimeShiXiao(int @serviceID, DateTime @xiaDanDate, decimal @xiaDanTakeHour, int @xiaDanTimeOutStatus, decimal @xiaDanChaoShiTakeHour, DateTime @paiDanDate, decimal @paiDanTakeHour, int @paiDanTimeOutStatus, decimal @paiDanChaoShiTakeHour, DateTime @responseTime, decimal @responseTakeHour, int @responseTimeOutStatus, decimal @responseChaoShiTakeHour, DateTime @checkTime, decimal @checkTakeHour, int @checkTimeOutStatus, decimal @checkChaoShiTakeHour, DateTime @chuliDate, decimal @processTakeHour, int @processTimeOutStatus, decimal @processChaoShiTakeHour, DateTime @banJieTime, decimal @banJieTakeHour, int @banJieTimeOutStatus, decimal @banJieChaoShiTakeHour, DateTime @closeTime, decimal @closeTakeHour, int @closeTimeOutStatus, decimal @closeChaoShiTakeHour)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCustomerService_TimeShiXiao(@serviceID, @xiaDanDate, @xiaDanTakeHour, @xiaDanTimeOutStatus, @xiaDanChaoShiTakeHour, @paiDanDate, @paiDanTakeHour, @paiDanTimeOutStatus, @paiDanChaoShiTakeHour, @responseTime, @responseTakeHour, @responseTimeOutStatus, @responseChaoShiTakeHour, @checkTime, @checkTakeHour, @checkTimeOutStatus, @checkChaoShiTakeHour, @chuliDate, @processTakeHour, @processTimeOutStatus, @processChaoShiTakeHour, @banJieTime, @banJieTakeHour, @banJieTimeOutStatus, @banJieChaoShiTakeHour, @closeTime, @closeTakeHour, @closeTimeOutStatus, @closeChaoShiTakeHour, helper);
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
		/// Insert a CustomerService_TimeShiXiao into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="xiaDanDate">xiaDanDate</param>
		/// <param name="xiaDanTakeHour">xiaDanTakeHour</param>
		/// <param name="xiaDanTimeOutStatus">xiaDanTimeOutStatus</param>
		/// <param name="xiaDanChaoShiTakeHour">xiaDanChaoShiTakeHour</param>
		/// <param name="paiDanDate">paiDanDate</param>
		/// <param name="paiDanTakeHour">paiDanTakeHour</param>
		/// <param name="paiDanTimeOutStatus">paiDanTimeOutStatus</param>
		/// <param name="paiDanChaoShiTakeHour">paiDanChaoShiTakeHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="responseTakeHour">responseTakeHour</param>
		/// <param name="responseTimeOutStatus">responseTimeOutStatus</param>
		/// <param name="responseChaoShiTakeHour">responseChaoShiTakeHour</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="checkTakeHour">checkTakeHour</param>
		/// <param name="checkTimeOutStatus">checkTimeOutStatus</param>
		/// <param name="checkChaoShiTakeHour">checkChaoShiTakeHour</param>
		/// <param name="chuliDate">chuliDate</param>
		/// <param name="processTakeHour">processTakeHour</param>
		/// <param name="processTimeOutStatus">processTimeOutStatus</param>
		/// <param name="processChaoShiTakeHour">processChaoShiTakeHour</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="banJieTakeHour">banJieTakeHour</param>
		/// <param name="banJieTimeOutStatus">banJieTimeOutStatus</param>
		/// <param name="banJieChaoShiTakeHour">banJieChaoShiTakeHour</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="closeTakeHour">closeTakeHour</param>
		/// <param name="closeTimeOutStatus">closeTimeOutStatus</param>
		/// <param name="closeChaoShiTakeHour">closeChaoShiTakeHour</param>
		/// <param name="helper">helper</param>
		internal static void InsertCustomerService_TimeShiXiao(int @serviceID, DateTime @xiaDanDate, decimal @xiaDanTakeHour, int @xiaDanTimeOutStatus, decimal @xiaDanChaoShiTakeHour, DateTime @paiDanDate, decimal @paiDanTakeHour, int @paiDanTimeOutStatus, decimal @paiDanChaoShiTakeHour, DateTime @responseTime, decimal @responseTakeHour, int @responseTimeOutStatus, decimal @responseChaoShiTakeHour, DateTime @checkTime, decimal @checkTakeHour, int @checkTimeOutStatus, decimal @checkChaoShiTakeHour, DateTime @chuliDate, decimal @processTakeHour, int @processTimeOutStatus, decimal @processChaoShiTakeHour, DateTime @banJieTime, decimal @banJieTakeHour, int @banJieTimeOutStatus, decimal @banJieChaoShiTakeHour, DateTime @closeTime, decimal @closeTakeHour, int @closeTimeOutStatus, decimal @closeChaoShiTakeHour, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ServiceID] int,
	[XiaDanDate] datetime,
	[XiaDanTakeHour] decimal(18, 8),
	[XiaDanTimeOutStatus] int,
	[XiaDanChaoShiTakeHour] decimal(18, 8),
	[PaiDanDate] datetime,
	[PaiDanTakeHour] decimal(18, 8),
	[PaiDanTimeOutStatus] int,
	[PaiDanChaoShiTakeHour] decimal(18, 8),
	[ResponseTime] datetime,
	[ResponseTakeHour] decimal(18, 8),
	[ResponseTimeOutStatus] int,
	[ResponseChaoShiTakeHour] decimal(18, 8),
	[CheckTime] datetime,
	[CheckTakeHour] decimal(18, 8),
	[CheckTimeOutStatus] int,
	[CheckChaoShiTakeHour] decimal(18, 8),
	[ChuliDate] datetime,
	[ProcessTakeHour] decimal(18, 8),
	[ProcessTimeOutStatus] int,
	[ProcessChaoShiTakeHour] decimal(18, 8),
	[BanJieTime] datetime,
	[BanJieTakeHour] decimal(18, 8),
	[BanJieTimeOutStatus] int,
	[BanJieChaoShiTakeHour] decimal(18, 8),
	[CloseTime] datetime,
	[CloseTakeHour] decimal(18, 8),
	[CloseTimeOutStatus] int,
	[CloseChaoShiTakeHour] decimal(18, 8)
);

INSERT INTO [dbo].[CustomerService_TimeShiXiao] (
	[CustomerService_TimeShiXiao].[ServiceID],
	[CustomerService_TimeShiXiao].[XiaDanDate],
	[CustomerService_TimeShiXiao].[XiaDanTakeHour],
	[CustomerService_TimeShiXiao].[XiaDanTimeOutStatus],
	[CustomerService_TimeShiXiao].[XiaDanChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[PaiDanDate],
	[CustomerService_TimeShiXiao].[PaiDanTakeHour],
	[CustomerService_TimeShiXiao].[PaiDanTimeOutStatus],
	[CustomerService_TimeShiXiao].[PaiDanChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[ResponseTime],
	[CustomerService_TimeShiXiao].[ResponseTakeHour],
	[CustomerService_TimeShiXiao].[ResponseTimeOutStatus],
	[CustomerService_TimeShiXiao].[ResponseChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[CheckTime],
	[CustomerService_TimeShiXiao].[CheckTakeHour],
	[CustomerService_TimeShiXiao].[CheckTimeOutStatus],
	[CustomerService_TimeShiXiao].[CheckChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[ChuliDate],
	[CustomerService_TimeShiXiao].[ProcessTakeHour],
	[CustomerService_TimeShiXiao].[ProcessTimeOutStatus],
	[CustomerService_TimeShiXiao].[ProcessChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[BanJieTime],
	[CustomerService_TimeShiXiao].[BanJieTakeHour],
	[CustomerService_TimeShiXiao].[BanJieTimeOutStatus],
	[CustomerService_TimeShiXiao].[BanJieChaoShiTakeHour],
	[CustomerService_TimeShiXiao].[CloseTime],
	[CustomerService_TimeShiXiao].[CloseTakeHour],
	[CustomerService_TimeShiXiao].[CloseTimeOutStatus],
	[CustomerService_TimeShiXiao].[CloseChaoShiTakeHour]
) 
output 
	INSERTED.[ServiceID],
	INSERTED.[XiaDanDate],
	INSERTED.[XiaDanTakeHour],
	INSERTED.[XiaDanTimeOutStatus],
	INSERTED.[XiaDanChaoShiTakeHour],
	INSERTED.[PaiDanDate],
	INSERTED.[PaiDanTakeHour],
	INSERTED.[PaiDanTimeOutStatus],
	INSERTED.[PaiDanChaoShiTakeHour],
	INSERTED.[ResponseTime],
	INSERTED.[ResponseTakeHour],
	INSERTED.[ResponseTimeOutStatus],
	INSERTED.[ResponseChaoShiTakeHour],
	INSERTED.[CheckTime],
	INSERTED.[CheckTakeHour],
	INSERTED.[CheckTimeOutStatus],
	INSERTED.[CheckChaoShiTakeHour],
	INSERTED.[ChuliDate],
	INSERTED.[ProcessTakeHour],
	INSERTED.[ProcessTimeOutStatus],
	INSERTED.[ProcessChaoShiTakeHour],
	INSERTED.[BanJieTime],
	INSERTED.[BanJieTakeHour],
	INSERTED.[BanJieTimeOutStatus],
	INSERTED.[BanJieChaoShiTakeHour],
	INSERTED.[CloseTime],
	INSERTED.[CloseTakeHour],
	INSERTED.[CloseTimeOutStatus],
	INSERTED.[CloseChaoShiTakeHour]
into @table
VALUES ( 
	@ServiceID,
	@XiaDanDate,
	@XiaDanTakeHour,
	@XiaDanTimeOutStatus,
	@XiaDanChaoShiTakeHour,
	@PaiDanDate,
	@PaiDanTakeHour,
	@PaiDanTimeOutStatus,
	@PaiDanChaoShiTakeHour,
	@ResponseTime,
	@ResponseTakeHour,
	@ResponseTimeOutStatus,
	@ResponseChaoShiTakeHour,
	@CheckTime,
	@CheckTakeHour,
	@CheckTimeOutStatus,
	@CheckChaoShiTakeHour,
	@ChuliDate,
	@ProcessTakeHour,
	@ProcessTimeOutStatus,
	@ProcessChaoShiTakeHour,
	@BanJieTime,
	@BanJieTakeHour,
	@BanJieTimeOutStatus,
	@BanJieChaoShiTakeHour,
	@CloseTime,
	@CloseTakeHour,
	@CloseTimeOutStatus,
	@CloseChaoShiTakeHour 
); 

SELECT 
	[ServiceID],
	[XiaDanDate],
	[XiaDanTakeHour],
	[XiaDanTimeOutStatus],
	[XiaDanChaoShiTakeHour],
	[PaiDanDate],
	[PaiDanTakeHour],
	[PaiDanTimeOutStatus],
	[PaiDanChaoShiTakeHour],
	[ResponseTime],
	[ResponseTakeHour],
	[ResponseTimeOutStatus],
	[ResponseChaoShiTakeHour],
	[CheckTime],
	[CheckTakeHour],
	[CheckTimeOutStatus],
	[CheckChaoShiTakeHour],
	[ChuliDate],
	[ProcessTakeHour],
	[ProcessTimeOutStatus],
	[ProcessChaoShiTakeHour],
	[BanJieTime],
	[BanJieTakeHour],
	[BanJieTimeOutStatus],
	[BanJieChaoShiTakeHour],
	[CloseTime],
	[CloseTakeHour],
	[CloseTimeOutStatus],
	[CloseChaoShiTakeHour] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@XiaDanDate", EntityBase.GetDatabaseValue(@xiaDanDate)));
			parameters.Add(new SqlParameter("@XiaDanTakeHour", EntityBase.GetDatabaseValue(@xiaDanTakeHour)));
			parameters.Add(new SqlParameter("@XiaDanTimeOutStatus", EntityBase.GetDatabaseValue(@xiaDanTimeOutStatus)));
			parameters.Add(new SqlParameter("@XiaDanChaoShiTakeHour", EntityBase.GetDatabaseValue(@xiaDanChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@PaiDanDate", EntityBase.GetDatabaseValue(@paiDanDate)));
			parameters.Add(new SqlParameter("@PaiDanTakeHour", EntityBase.GetDatabaseValue(@paiDanTakeHour)));
			parameters.Add(new SqlParameter("@PaiDanTimeOutStatus", EntityBase.GetDatabaseValue(@paiDanTimeOutStatus)));
			parameters.Add(new SqlParameter("@PaiDanChaoShiTakeHour", EntityBase.GetDatabaseValue(@paiDanChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@ResponseTime", EntityBase.GetDatabaseValue(@responseTime)));
			parameters.Add(new SqlParameter("@ResponseTakeHour", EntityBase.GetDatabaseValue(@responseTakeHour)));
			parameters.Add(new SqlParameter("@ResponseTimeOutStatus", EntityBase.GetDatabaseValue(@responseTimeOutStatus)));
			parameters.Add(new SqlParameter("@ResponseChaoShiTakeHour", EntityBase.GetDatabaseValue(@responseChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@CheckTime", EntityBase.GetDatabaseValue(@checkTime)));
			parameters.Add(new SqlParameter("@CheckTakeHour", EntityBase.GetDatabaseValue(@checkTakeHour)));
			parameters.Add(new SqlParameter("@CheckTimeOutStatus", EntityBase.GetDatabaseValue(@checkTimeOutStatus)));
			parameters.Add(new SqlParameter("@CheckChaoShiTakeHour", EntityBase.GetDatabaseValue(@checkChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@ChuliDate", EntityBase.GetDatabaseValue(@chuliDate)));
			parameters.Add(new SqlParameter("@ProcessTakeHour", EntityBase.GetDatabaseValue(@processTakeHour)));
			parameters.Add(new SqlParameter("@ProcessTimeOutStatus", EntityBase.GetDatabaseValue(@processTimeOutStatus)));
			parameters.Add(new SqlParameter("@ProcessChaoShiTakeHour", EntityBase.GetDatabaseValue(@processChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@BanJieTakeHour", EntityBase.GetDatabaseValue(@banJieTakeHour)));
			parameters.Add(new SqlParameter("@BanJieTimeOutStatus", EntityBase.GetDatabaseValue(@banJieTimeOutStatus)));
			parameters.Add(new SqlParameter("@BanJieChaoShiTakeHour", EntityBase.GetDatabaseValue(@banJieChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@CloseTime", EntityBase.GetDatabaseValue(@closeTime)));
			parameters.Add(new SqlParameter("@CloseTakeHour", EntityBase.GetDatabaseValue(@closeTakeHour)));
			parameters.Add(new SqlParameter("@CloseTimeOutStatus", EntityBase.GetDatabaseValue(@closeTimeOutStatus)));
			parameters.Add(new SqlParameter("@CloseChaoShiTakeHour", EntityBase.GetDatabaseValue(@closeChaoShiTakeHour)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CustomerService_TimeShiXiao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="xiaDanDate">xiaDanDate</param>
		/// <param name="xiaDanTakeHour">xiaDanTakeHour</param>
		/// <param name="xiaDanTimeOutStatus">xiaDanTimeOutStatus</param>
		/// <param name="xiaDanChaoShiTakeHour">xiaDanChaoShiTakeHour</param>
		/// <param name="paiDanDate">paiDanDate</param>
		/// <param name="paiDanTakeHour">paiDanTakeHour</param>
		/// <param name="paiDanTimeOutStatus">paiDanTimeOutStatus</param>
		/// <param name="paiDanChaoShiTakeHour">paiDanChaoShiTakeHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="responseTakeHour">responseTakeHour</param>
		/// <param name="responseTimeOutStatus">responseTimeOutStatus</param>
		/// <param name="responseChaoShiTakeHour">responseChaoShiTakeHour</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="checkTakeHour">checkTakeHour</param>
		/// <param name="checkTimeOutStatus">checkTimeOutStatus</param>
		/// <param name="checkChaoShiTakeHour">checkChaoShiTakeHour</param>
		/// <param name="chuliDate">chuliDate</param>
		/// <param name="processTakeHour">processTakeHour</param>
		/// <param name="processTimeOutStatus">processTimeOutStatus</param>
		/// <param name="processChaoShiTakeHour">processChaoShiTakeHour</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="banJieTakeHour">banJieTakeHour</param>
		/// <param name="banJieTimeOutStatus">banJieTimeOutStatus</param>
		/// <param name="banJieChaoShiTakeHour">banJieChaoShiTakeHour</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="closeTakeHour">closeTakeHour</param>
		/// <param name="closeTimeOutStatus">closeTimeOutStatus</param>
		/// <param name="closeChaoShiTakeHour">closeChaoShiTakeHour</param>
		public static void UpdateCustomerService_TimeShiXiao(int @serviceID, DateTime @xiaDanDate, decimal @xiaDanTakeHour, int @xiaDanTimeOutStatus, decimal @xiaDanChaoShiTakeHour, DateTime @paiDanDate, decimal @paiDanTakeHour, int @paiDanTimeOutStatus, decimal @paiDanChaoShiTakeHour, DateTime @responseTime, decimal @responseTakeHour, int @responseTimeOutStatus, decimal @responseChaoShiTakeHour, DateTime @checkTime, decimal @checkTakeHour, int @checkTimeOutStatus, decimal @checkChaoShiTakeHour, DateTime @chuliDate, decimal @processTakeHour, int @processTimeOutStatus, decimal @processChaoShiTakeHour, DateTime @banJieTime, decimal @banJieTakeHour, int @banJieTimeOutStatus, decimal @banJieChaoShiTakeHour, DateTime @closeTime, decimal @closeTakeHour, int @closeTimeOutStatus, decimal @closeChaoShiTakeHour)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCustomerService_TimeShiXiao(@serviceID, @xiaDanDate, @xiaDanTakeHour, @xiaDanTimeOutStatus, @xiaDanChaoShiTakeHour, @paiDanDate, @paiDanTakeHour, @paiDanTimeOutStatus, @paiDanChaoShiTakeHour, @responseTime, @responseTakeHour, @responseTimeOutStatus, @responseChaoShiTakeHour, @checkTime, @checkTakeHour, @checkTimeOutStatus, @checkChaoShiTakeHour, @chuliDate, @processTakeHour, @processTimeOutStatus, @processChaoShiTakeHour, @banJieTime, @banJieTakeHour, @banJieTimeOutStatus, @banJieChaoShiTakeHour, @closeTime, @closeTakeHour, @closeTimeOutStatus, @closeChaoShiTakeHour, helper);
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
		/// Updates a CustomerService_TimeShiXiao into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="xiaDanDate">xiaDanDate</param>
		/// <param name="xiaDanTakeHour">xiaDanTakeHour</param>
		/// <param name="xiaDanTimeOutStatus">xiaDanTimeOutStatus</param>
		/// <param name="xiaDanChaoShiTakeHour">xiaDanChaoShiTakeHour</param>
		/// <param name="paiDanDate">paiDanDate</param>
		/// <param name="paiDanTakeHour">paiDanTakeHour</param>
		/// <param name="paiDanTimeOutStatus">paiDanTimeOutStatus</param>
		/// <param name="paiDanChaoShiTakeHour">paiDanChaoShiTakeHour</param>
		/// <param name="responseTime">responseTime</param>
		/// <param name="responseTakeHour">responseTakeHour</param>
		/// <param name="responseTimeOutStatus">responseTimeOutStatus</param>
		/// <param name="responseChaoShiTakeHour">responseChaoShiTakeHour</param>
		/// <param name="checkTime">checkTime</param>
		/// <param name="checkTakeHour">checkTakeHour</param>
		/// <param name="checkTimeOutStatus">checkTimeOutStatus</param>
		/// <param name="checkChaoShiTakeHour">checkChaoShiTakeHour</param>
		/// <param name="chuliDate">chuliDate</param>
		/// <param name="processTakeHour">processTakeHour</param>
		/// <param name="processTimeOutStatus">processTimeOutStatus</param>
		/// <param name="processChaoShiTakeHour">processChaoShiTakeHour</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="banJieTakeHour">banJieTakeHour</param>
		/// <param name="banJieTimeOutStatus">banJieTimeOutStatus</param>
		/// <param name="banJieChaoShiTakeHour">banJieChaoShiTakeHour</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="closeTakeHour">closeTakeHour</param>
		/// <param name="closeTimeOutStatus">closeTimeOutStatus</param>
		/// <param name="closeChaoShiTakeHour">closeChaoShiTakeHour</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCustomerService_TimeShiXiao(int @serviceID, DateTime @xiaDanDate, decimal @xiaDanTakeHour, int @xiaDanTimeOutStatus, decimal @xiaDanChaoShiTakeHour, DateTime @paiDanDate, decimal @paiDanTakeHour, int @paiDanTimeOutStatus, decimal @paiDanChaoShiTakeHour, DateTime @responseTime, decimal @responseTakeHour, int @responseTimeOutStatus, decimal @responseChaoShiTakeHour, DateTime @checkTime, decimal @checkTakeHour, int @checkTimeOutStatus, decimal @checkChaoShiTakeHour, DateTime @chuliDate, decimal @processTakeHour, int @processTimeOutStatus, decimal @processChaoShiTakeHour, DateTime @banJieTime, decimal @banJieTakeHour, int @banJieTimeOutStatus, decimal @banJieChaoShiTakeHour, DateTime @closeTime, decimal @closeTakeHour, int @closeTimeOutStatus, decimal @closeChaoShiTakeHour, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ServiceID] int,
	[XiaDanDate] datetime,
	[XiaDanTakeHour] decimal(18, 8),
	[XiaDanTimeOutStatus] int,
	[XiaDanChaoShiTakeHour] decimal(18, 8),
	[PaiDanDate] datetime,
	[PaiDanTakeHour] decimal(18, 8),
	[PaiDanTimeOutStatus] int,
	[PaiDanChaoShiTakeHour] decimal(18, 8),
	[ResponseTime] datetime,
	[ResponseTakeHour] decimal(18, 8),
	[ResponseTimeOutStatus] int,
	[ResponseChaoShiTakeHour] decimal(18, 8),
	[CheckTime] datetime,
	[CheckTakeHour] decimal(18, 8),
	[CheckTimeOutStatus] int,
	[CheckChaoShiTakeHour] decimal(18, 8),
	[ChuliDate] datetime,
	[ProcessTakeHour] decimal(18, 8),
	[ProcessTimeOutStatus] int,
	[ProcessChaoShiTakeHour] decimal(18, 8),
	[BanJieTime] datetime,
	[BanJieTakeHour] decimal(18, 8),
	[BanJieTimeOutStatus] int,
	[BanJieChaoShiTakeHour] decimal(18, 8),
	[CloseTime] datetime,
	[CloseTakeHour] decimal(18, 8),
	[CloseTimeOutStatus] int,
	[CloseChaoShiTakeHour] decimal(18, 8)
);

UPDATE [dbo].[CustomerService_TimeShiXiao] SET 
	[CustomerService_TimeShiXiao].[XiaDanDate] = @XiaDanDate,
	[CustomerService_TimeShiXiao].[XiaDanTakeHour] = @XiaDanTakeHour,
	[CustomerService_TimeShiXiao].[XiaDanTimeOutStatus] = @XiaDanTimeOutStatus,
	[CustomerService_TimeShiXiao].[XiaDanChaoShiTakeHour] = @XiaDanChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[PaiDanDate] = @PaiDanDate,
	[CustomerService_TimeShiXiao].[PaiDanTakeHour] = @PaiDanTakeHour,
	[CustomerService_TimeShiXiao].[PaiDanTimeOutStatus] = @PaiDanTimeOutStatus,
	[CustomerService_TimeShiXiao].[PaiDanChaoShiTakeHour] = @PaiDanChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[ResponseTime] = @ResponseTime,
	[CustomerService_TimeShiXiao].[ResponseTakeHour] = @ResponseTakeHour,
	[CustomerService_TimeShiXiao].[ResponseTimeOutStatus] = @ResponseTimeOutStatus,
	[CustomerService_TimeShiXiao].[ResponseChaoShiTakeHour] = @ResponseChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[CheckTime] = @CheckTime,
	[CustomerService_TimeShiXiao].[CheckTakeHour] = @CheckTakeHour,
	[CustomerService_TimeShiXiao].[CheckTimeOutStatus] = @CheckTimeOutStatus,
	[CustomerService_TimeShiXiao].[CheckChaoShiTakeHour] = @CheckChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[ChuliDate] = @ChuliDate,
	[CustomerService_TimeShiXiao].[ProcessTakeHour] = @ProcessTakeHour,
	[CustomerService_TimeShiXiao].[ProcessTimeOutStatus] = @ProcessTimeOutStatus,
	[CustomerService_TimeShiXiao].[ProcessChaoShiTakeHour] = @ProcessChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[BanJieTime] = @BanJieTime,
	[CustomerService_TimeShiXiao].[BanJieTakeHour] = @BanJieTakeHour,
	[CustomerService_TimeShiXiao].[BanJieTimeOutStatus] = @BanJieTimeOutStatus,
	[CustomerService_TimeShiXiao].[BanJieChaoShiTakeHour] = @BanJieChaoShiTakeHour,
	[CustomerService_TimeShiXiao].[CloseTime] = @CloseTime,
	[CustomerService_TimeShiXiao].[CloseTakeHour] = @CloseTakeHour,
	[CustomerService_TimeShiXiao].[CloseTimeOutStatus] = @CloseTimeOutStatus,
	[CustomerService_TimeShiXiao].[CloseChaoShiTakeHour] = @CloseChaoShiTakeHour 
output 
	INSERTED.[ServiceID],
	INSERTED.[XiaDanDate],
	INSERTED.[XiaDanTakeHour],
	INSERTED.[XiaDanTimeOutStatus],
	INSERTED.[XiaDanChaoShiTakeHour],
	INSERTED.[PaiDanDate],
	INSERTED.[PaiDanTakeHour],
	INSERTED.[PaiDanTimeOutStatus],
	INSERTED.[PaiDanChaoShiTakeHour],
	INSERTED.[ResponseTime],
	INSERTED.[ResponseTakeHour],
	INSERTED.[ResponseTimeOutStatus],
	INSERTED.[ResponseChaoShiTakeHour],
	INSERTED.[CheckTime],
	INSERTED.[CheckTakeHour],
	INSERTED.[CheckTimeOutStatus],
	INSERTED.[CheckChaoShiTakeHour],
	INSERTED.[ChuliDate],
	INSERTED.[ProcessTakeHour],
	INSERTED.[ProcessTimeOutStatus],
	INSERTED.[ProcessChaoShiTakeHour],
	INSERTED.[BanJieTime],
	INSERTED.[BanJieTakeHour],
	INSERTED.[BanJieTimeOutStatus],
	INSERTED.[BanJieChaoShiTakeHour],
	INSERTED.[CloseTime],
	INSERTED.[CloseTakeHour],
	INSERTED.[CloseTimeOutStatus],
	INSERTED.[CloseChaoShiTakeHour]
into @table
WHERE 
	[CustomerService_TimeShiXiao].[ServiceID] = @ServiceID

SELECT 
	[ServiceID],
	[XiaDanDate],
	[XiaDanTakeHour],
	[XiaDanTimeOutStatus],
	[XiaDanChaoShiTakeHour],
	[PaiDanDate],
	[PaiDanTakeHour],
	[PaiDanTimeOutStatus],
	[PaiDanChaoShiTakeHour],
	[ResponseTime],
	[ResponseTakeHour],
	[ResponseTimeOutStatus],
	[ResponseChaoShiTakeHour],
	[CheckTime],
	[CheckTakeHour],
	[CheckTimeOutStatus],
	[CheckChaoShiTakeHour],
	[ChuliDate],
	[ProcessTakeHour],
	[ProcessTimeOutStatus],
	[ProcessChaoShiTakeHour],
	[BanJieTime],
	[BanJieTakeHour],
	[BanJieTimeOutStatus],
	[BanJieChaoShiTakeHour],
	[CloseTime],
	[CloseTakeHour],
	[CloseTimeOutStatus],
	[CloseChaoShiTakeHour] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@XiaDanDate", EntityBase.GetDatabaseValue(@xiaDanDate)));
			parameters.Add(new SqlParameter("@XiaDanTakeHour", EntityBase.GetDatabaseValue(@xiaDanTakeHour)));
			parameters.Add(new SqlParameter("@XiaDanTimeOutStatus", EntityBase.GetDatabaseValue(@xiaDanTimeOutStatus)));
			parameters.Add(new SqlParameter("@XiaDanChaoShiTakeHour", EntityBase.GetDatabaseValue(@xiaDanChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@PaiDanDate", EntityBase.GetDatabaseValue(@paiDanDate)));
			parameters.Add(new SqlParameter("@PaiDanTakeHour", EntityBase.GetDatabaseValue(@paiDanTakeHour)));
			parameters.Add(new SqlParameter("@PaiDanTimeOutStatus", EntityBase.GetDatabaseValue(@paiDanTimeOutStatus)));
			parameters.Add(new SqlParameter("@PaiDanChaoShiTakeHour", EntityBase.GetDatabaseValue(@paiDanChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@ResponseTime", EntityBase.GetDatabaseValue(@responseTime)));
			parameters.Add(new SqlParameter("@ResponseTakeHour", EntityBase.GetDatabaseValue(@responseTakeHour)));
			parameters.Add(new SqlParameter("@ResponseTimeOutStatus", EntityBase.GetDatabaseValue(@responseTimeOutStatus)));
			parameters.Add(new SqlParameter("@ResponseChaoShiTakeHour", EntityBase.GetDatabaseValue(@responseChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@CheckTime", EntityBase.GetDatabaseValue(@checkTime)));
			parameters.Add(new SqlParameter("@CheckTakeHour", EntityBase.GetDatabaseValue(@checkTakeHour)));
			parameters.Add(new SqlParameter("@CheckTimeOutStatus", EntityBase.GetDatabaseValue(@checkTimeOutStatus)));
			parameters.Add(new SqlParameter("@CheckChaoShiTakeHour", EntityBase.GetDatabaseValue(@checkChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@ChuliDate", EntityBase.GetDatabaseValue(@chuliDate)));
			parameters.Add(new SqlParameter("@ProcessTakeHour", EntityBase.GetDatabaseValue(@processTakeHour)));
			parameters.Add(new SqlParameter("@ProcessTimeOutStatus", EntityBase.GetDatabaseValue(@processTimeOutStatus)));
			parameters.Add(new SqlParameter("@ProcessChaoShiTakeHour", EntityBase.GetDatabaseValue(@processChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@BanJieTakeHour", EntityBase.GetDatabaseValue(@banJieTakeHour)));
			parameters.Add(new SqlParameter("@BanJieTimeOutStatus", EntityBase.GetDatabaseValue(@banJieTimeOutStatus)));
			parameters.Add(new SqlParameter("@BanJieChaoShiTakeHour", EntityBase.GetDatabaseValue(@banJieChaoShiTakeHour)));
			parameters.Add(new SqlParameter("@CloseTime", EntityBase.GetDatabaseValue(@closeTime)));
			parameters.Add(new SqlParameter("@CloseTakeHour", EntityBase.GetDatabaseValue(@closeTakeHour)));
			parameters.Add(new SqlParameter("@CloseTimeOutStatus", EntityBase.GetDatabaseValue(@closeTimeOutStatus)));
			parameters.Add(new SqlParameter("@CloseChaoShiTakeHour", EntityBase.GetDatabaseValue(@closeChaoShiTakeHour)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CustomerService_TimeShiXiao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		public static void DeleteCustomerService_TimeShiXiao(int @serviceID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCustomerService_TimeShiXiao(@serviceID, helper);
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
		/// Deletes a CustomerService_TimeShiXiao from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCustomerService_TimeShiXiao(int @serviceID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CustomerService_TimeShiXiao]
WHERE 
	[CustomerService_TimeShiXiao].[ServiceID] = @ServiceID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", @serviceID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CustomerService_TimeShiXiao object.
		/// </summary>
		/// <returns>The newly created CustomerService_TimeShiXiao object.</returns>
		public static CustomerService_TimeShiXiao CreateCustomerService_TimeShiXiao()
		{
			return InitializeNew<CustomerService_TimeShiXiao>();
		}
		
		/// <summary>
		/// Retrieve information for a CustomerService_TimeShiXiao by a CustomerService_TimeShiXiao's unique identifier.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <returns>CustomerService_TimeShiXiao</returns>
		public static CustomerService_TimeShiXiao GetCustomerService_TimeShiXiao(int @serviceID)
		{
			string commandText = @"
SELECT 
" + CustomerService_TimeShiXiao.SelectFieldList + @"
FROM [dbo].[CustomerService_TimeShiXiao] 
WHERE 
	[CustomerService_TimeShiXiao].[ServiceID] = @ServiceID " + CustomerService_TimeShiXiao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", @serviceID));
			
			return GetOne<CustomerService_TimeShiXiao>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CustomerService_TimeShiXiao by a CustomerService_TimeShiXiao's unique identifier.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CustomerService_TimeShiXiao</returns>
		public static CustomerService_TimeShiXiao GetCustomerService_TimeShiXiao(int @serviceID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CustomerService_TimeShiXiao.SelectFieldList + @"
FROM [dbo].[CustomerService_TimeShiXiao] 
WHERE 
	[CustomerService_TimeShiXiao].[ServiceID] = @ServiceID " + CustomerService_TimeShiXiao.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", @serviceID));
			
			return GetOne<CustomerService_TimeShiXiao>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_TimeShiXiao objects.
		/// </summary>
		/// <returns>The retrieved collection of CustomerService_TimeShiXiao objects.</returns>
		public static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos()
		{
			string commandText = @"
SELECT " + CustomerService_TimeShiXiao.SelectFieldList + "FROM [dbo].[CustomerService_TimeShiXiao] " + CustomerService_TimeShiXiao.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CustomerService_TimeShiXiao>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CustomerService_TimeShiXiao objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_TimeShiXiao objects.</returns>
        public static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_TimeShiXiao>(SelectFieldList, "FROM [dbo].[CustomerService_TimeShiXiao]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CustomerService_TimeShiXiao objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_TimeShiXiao objects.</returns>
        public static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_TimeShiXiao>(SelectFieldList, "FROM [dbo].[CustomerService_TimeShiXiao]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CustomerService_TimeShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_TimeShiXiao objects.</returns>
		protected static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_TimeShiXiaos(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_TimeShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_TimeShiXiao objects.</returns>
		protected static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_TimeShiXiaos(string.Empty, where, parameters, CustomerService_TimeShiXiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_TimeShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_TimeShiXiao objects.</returns>
		protected static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_TimeShiXiaos(prefix, where, parameters, CustomerService_TimeShiXiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_TimeShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_TimeShiXiao objects.</returns>
		protected static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_TimeShiXiaos(string.Empty, where, parameters, CustomerService_TimeShiXiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_TimeShiXiao objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_TimeShiXiao objects.</returns>
		protected static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_TimeShiXiaos(prefix, where, parameters, CustomerService_TimeShiXiao.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_TimeShiXiao objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_TimeShiXiao objects.</returns>
		protected static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CustomerService_TimeShiXiao.SelectFieldList + "FROM [dbo].[CustomerService_TimeShiXiao] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CustomerService_TimeShiXiao>(reader);
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
        protected static EntityList<CustomerService_TimeShiXiao> GetCustomerService_TimeShiXiaos(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_TimeShiXiao>(SelectFieldList, "FROM [dbo].[CustomerService_TimeShiXiao] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CustomerService_TimeShiXiao objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_TimeShiXiaoCount()
        {
            return GetCustomerService_TimeShiXiaoCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CustomerService_TimeShiXiao objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_TimeShiXiaoCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CustomerService_TimeShiXiao] " + where;

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
		public static partial class CustomerService_TimeShiXiao_Properties
		{
			public const string ServiceID = "ServiceID";
			public const string XiaDanDate = "XiaDanDate";
			public const string XiaDanTakeHour = "XiaDanTakeHour";
			public const string XiaDanTimeOutStatus = "XiaDanTimeOutStatus";
			public const string XiaDanChaoShiTakeHour = "XiaDanChaoShiTakeHour";
			public const string PaiDanDate = "PaiDanDate";
			public const string PaiDanTakeHour = "PaiDanTakeHour";
			public const string PaiDanTimeOutStatus = "PaiDanTimeOutStatus";
			public const string PaiDanChaoShiTakeHour = "PaiDanChaoShiTakeHour";
			public const string ResponseTime = "ResponseTime";
			public const string ResponseTakeHour = "ResponseTakeHour";
			public const string ResponseTimeOutStatus = "ResponseTimeOutStatus";
			public const string ResponseChaoShiTakeHour = "ResponseChaoShiTakeHour";
			public const string CheckTime = "CheckTime";
			public const string CheckTakeHour = "CheckTakeHour";
			public const string CheckTimeOutStatus = "CheckTimeOutStatus";
			public const string CheckChaoShiTakeHour = "CheckChaoShiTakeHour";
			public const string ChuliDate = "ChuliDate";
			public const string ProcessTakeHour = "ProcessTakeHour";
			public const string ProcessTimeOutStatus = "ProcessTimeOutStatus";
			public const string ProcessChaoShiTakeHour = "ProcessChaoShiTakeHour";
			public const string BanJieTime = "BanJieTime";
			public const string BanJieTakeHour = "BanJieTakeHour";
			public const string BanJieTimeOutStatus = "BanJieTimeOutStatus";
			public const string BanJieChaoShiTakeHour = "BanJieChaoShiTakeHour";
			public const string CloseTime = "CloseTime";
			public const string CloseTakeHour = "CloseTakeHour";
			public const string CloseTimeOutStatus = "CloseTimeOutStatus";
			public const string CloseChaoShiTakeHour = "CloseChaoShiTakeHour";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ServiceID" , "int:"},
    			 {"XiaDanDate" , "DateTime:"},
    			 {"XiaDanTakeHour" , "decimal:"},
    			 {"XiaDanTimeOutStatus" , "int:"},
    			 {"XiaDanChaoShiTakeHour" , "decimal:"},
    			 {"PaiDanDate" , "DateTime:"},
    			 {"PaiDanTakeHour" , "decimal:"},
    			 {"PaiDanTimeOutStatus" , "int:"},
    			 {"PaiDanChaoShiTakeHour" , "decimal:"},
    			 {"ResponseTime" , "DateTime:"},
    			 {"ResponseTakeHour" , "decimal:"},
    			 {"ResponseTimeOutStatus" , "int:"},
    			 {"ResponseChaoShiTakeHour" , "decimal:"},
    			 {"CheckTime" , "DateTime:"},
    			 {"CheckTakeHour" , "decimal:"},
    			 {"CheckTimeOutStatus" , "int:"},
    			 {"CheckChaoShiTakeHour" , "decimal:"},
    			 {"ChuliDate" , "DateTime:"},
    			 {"ProcessTakeHour" , "decimal:"},
    			 {"ProcessTimeOutStatus" , "int:"},
    			 {"ProcessChaoShiTakeHour" , "decimal:"},
    			 {"BanJieTime" , "DateTime:"},
    			 {"BanJieTakeHour" , "decimal:"},
    			 {"BanJieTimeOutStatus" , "int:"},
    			 {"BanJieChaoShiTakeHour" , "decimal:"},
    			 {"CloseTime" , "DateTime:"},
    			 {"CloseTakeHour" , "decimal:"},
    			 {"CloseTimeOutStatus" , "int:"},
    			 {"CloseChaoShiTakeHour" , "decimal:"},
            };
		}
		#endregion
	}
}
