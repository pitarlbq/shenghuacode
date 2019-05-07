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
	/// This object represents the properties and methods of a CustomerService.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CustomerService 
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
			set 
			{
				if (this._projectID != value) 
				{
					this._projectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceFullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceFullName
		{
			[DebuggerStepThrough()]
			get { return this._serviceFullName; }
			set 
			{
				if (this._serviceFullName != value) 
				{
					this._serviceFullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceFullName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectName
		{
			[DebuggerStepThrough()]
			get { return this._projectName; }
			set 
			{
				if (this._projectName != value) 
				{
					this._projectName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
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
		private string _serviceArea = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceArea
		{
			[DebuggerStepThrough()]
			get { return this._serviceArea; }
			set 
			{
				if (this._serviceArea != value) 
				{
					this._serviceArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceArea");
				}
			}
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
			set 
			{
				if (this._serviceNumber != value) 
				{
					this._serviceNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addCustomerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddCustomerName
		{
			[DebuggerStepThrough()]
			get { return this._addCustomerName; }
			set 
			{
				if (this._addCustomerName != value) 
				{
					this._addCustomerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddCustomerName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addCallPhone = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddCallPhone
		{
			[DebuggerStepThrough()]
			get { return this._addCallPhone; }
			set 
			{
				if (this._addCallPhone != value) 
				{
					this._addCallPhone = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddCallPhone");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceContent
		{
			[DebuggerStepThrough()]
			get { return this._serviceContent; }
			set 
			{
				if (this._serviceContent != value) 
				{
					this._serviceContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceContent");
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
		private int _serviceStatus = int.MinValue;
		/// <summary>
		/// 0-处理中 1-已办结 2-已销单 3-待处理 10-待接单
		/// </summary>
        [Description("0-处理中 1-已办结 2-已销单 3-待处理 10-待接单")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceStatus
		{
			[DebuggerStepThrough()]
			get { return this._serviceStatus; }
			set 
			{
				if (this._serviceStatus != value) 
				{
					this._serviceStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceStatus");
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
		private string _banJieNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BanJieNote
		{
			[DebuggerStepThrough()]
			get { return this._banJieNote; }
			set 
			{
				if (this._banJieNote != value) 
				{
					this._banJieNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("BanJieNote");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _serviceAppointTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ServiceAppointTime
		{
			[DebuggerStepThrough()]
			get { return this._serviceAppointTime; }
			set 
			{
				if (this._serviceAppointTime != value) 
				{
					this._serviceAppointTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceAppointTime");
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
		private int _orderNumberID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderNumberID
		{
			[DebuggerStepThrough()]
			get { return this._orderNumberID; }
			set 
			{
				if (this._orderNumberID != value) 
				{
					this._orderNumberID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderNumberID");
				}
			}
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
			set 
			{
				if (this._handelFee != value) 
				{
					this._handelFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("HandelFee");
				}
			}
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
			set 
			{
				if (this._totalFee != value) 
				{
					this._totalFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("TotalFee");
				}
			}
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
			set 
			{
				if (this._balanceStatus != value) 
				{
					this._balanceStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("BalanceStatus");
				}
			}
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
			set 
			{
				if (this._cKProductOutSumaryID != value) 
				{
					this._cKProductOutSumaryID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CKProductOutSumaryID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isRequireCost = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsRequireCost
		{
			[DebuggerStepThrough()]
			get { return this._isRequireCost; }
			set 
			{
				if (this._isRequireCost != value) 
				{
					this._isRequireCost = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsRequireCost");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isRequireProduct = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsRequireProduct
		{
			[DebuggerStepThrough()]
			get { return this._isRequireProduct; }
			set 
			{
				if (this._isRequireProduct != value) 
				{
					this._isRequireProduct = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsRequireProduct");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPShow
		{
			[DebuggerStepThrough()]
			get { return this._isAPPShow; }
			set 
			{
				if (this._isAPPShow != value) 
				{
					this._isAPPShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAPPSend = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAPPSend
		{
			[DebuggerStepThrough()]
			get { return this._isAPPSend; }
			set 
			{
				if (this._isAPPSend != value) 
				{
					this._isAPPSend = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAPPSend");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _aPPSendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime APPSendTime
		{
			[DebuggerStepThrough()]
			get { return this._aPPSendTime; }
			set 
			{
				if (this._aPPSendTime != value) 
				{
					this._aPPSendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPSendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPSendResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPSendResult
		{
			[DebuggerStepThrough()]
			get { return this._aPPSendResult; }
			set 
			{
				if (this._aPPSendResult != value) 
				{
					this._aPPSendResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPSendResult");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _wechatServiceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int WechatServiceID
		{
			[DebuggerStepThrough()]
			get { return this._wechatServiceID; }
			set 
			{
				if (this._wechatServiceID != value) 
				{
					this._wechatServiceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("WechatServiceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _acceptTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AcceptTime
		{
			[DebuggerStepThrough()]
			get { return this._acceptTime; }
			set 
			{
				if (this._acceptTime != value) 
				{
					this._acceptTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AcceptTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _taskType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TaskType
		{
			[DebuggerStepThrough()]
			get { return this._taskType; }
			set 
			{
				if (this._taskType != value) 
				{
					this._taskType = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaskType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceFrom = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceFrom
		{
			[DebuggerStepThrough()]
			get { return this._serviceFrom; }
			set 
			{
				if (this._serviceFrom != value) 
				{
					this._serviceFrom = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceFrom");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sendUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SendUserID
		{
			[DebuggerStepThrough()]
			get { return this._sendUserID; }
			set 
			{
				if (this._sendUserID != value) 
				{
					this._sendUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sendUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SendUserName
		{
			[DebuggerStepThrough()]
			get { return this._sendUserName; }
			set 
			{
				if (this._sendUserName != value) 
				{
					this._sendUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _banJieManUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int BanJieManUserID
		{
			[DebuggerStepThrough()]
			get { return this._banJieManUserID; }
			set 
			{
				if (this._banJieManUserID != value) 
				{
					this._banJieManUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("BanJieManUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _banJieManName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BanJieManName
		{
			[DebuggerStepThrough()]
			get { return this._banJieManName; }
			set 
			{
				if (this._banJieManName != value) 
				{
					this._banJieManName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BanJieManName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUnRead = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsUnRead
		{
			[DebuggerStepThrough()]
			get { return this._isUnRead; }
			set 
			{
				if (this._isUnRead != value) 
				{
					this._isUnRead = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUnRead");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _departmentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int DepartmentID
		{
			[DebuggerStepThrough()]
			get { return this._departmentID; }
			set 
			{
				if (this._departmentID != value) 
				{
					this._departmentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isSuggestion = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsSuggestion
		{
			[DebuggerStepThrough()]
			get { return this._isSuggestion; }
			set 
			{
				if (this._isSuggestion != value) 
				{
					this._isSuggestion = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsSuggestion");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _publicProjectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PublicProjectID
		{
			[DebuggerStepThrough()]
			get { return this._publicProjectID; }
			set 
			{
				if (this._publicProjectID != value) 
				{
					this._publicProjectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PublicProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHighTouSu = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHighTouSu
		{
			[DebuggerStepThrough()]
			get { return this._isHighTouSu; }
			set 
			{
				if (this._isHighTouSu != value) 
				{
					this._isHighTouSu = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHighTouSu");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isInvalidCall = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsInvalidCall
		{
			[DebuggerStepThrough()]
			get { return this._isInvalidCall; }
			set 
			{
				if (this._isInvalidCall != value) 
				{
					this._isInvalidCall = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsInvalidCall");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isInWeiBao = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsInWeiBao
		{
			[DebuggerStepThrough()]
			get { return this._isInWeiBao; }
			set 
			{
				if (this._isInWeiBao != value) 
				{
					this._isInWeiBao = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsInWeiBao");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isClosed = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsClosed
		{
			[DebuggerStepThrough()]
			get { return this._isClosed; }
			set 
			{
				if (this._isClosed != value) 
				{
					this._isClosed = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsClosed");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _confirmStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ConfirmStatus
		{
			[DebuggerStepThrough()]
			get { return this._confirmStatus; }
			set 
			{
				if (this._confirmStatus != value) 
				{
					this._confirmStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfirmStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serviceType1ID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceType1ID
		{
			[DebuggerStepThrough()]
			get { return this._serviceType1ID; }
			set 
			{
				if (this._serviceType1ID != value) 
				{
					this._serviceType1ID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceType1ID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceType2ID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceType2ID
		{
			[DebuggerStepThrough()]
			get { return this._serviceType2ID; }
			set 
			{
				if (this._serviceType2ID != value) 
				{
					this._serviceType2ID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceType2ID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _serviceType3ID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceType3ID
		{
			[DebuggerStepThrough()]
			get { return this._serviceType3ID; }
			set 
			{
				if (this._serviceType3ID != value) 
				{
					this._serviceType3ID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceType3ID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _relatedServiceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelatedServiceID
		{
			[DebuggerStepThrough()]
			get { return this._relatedServiceID; }
			set 
			{
				if (this._relatedServiceID != value) 
				{
					this._relatedServiceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelatedServiceID");
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
		private decimal _huiFangRate = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal HuiFangRate
		{
			[DebuggerStepThrough()]
			get { return this._huiFangRate; }
			set 
			{
				if (this._huiFangRate != value) 
				{
					this._huiFangRate = value;
					this.IsDirty = true;	
					OnPropertyChanged("HuiFangRate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isImportantTouSu = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsImportantTouSu
		{
			[DebuggerStepThrough()]
			get { return this._isImportantTouSu; }
			set 
			{
				if (this._isImportantTouSu != value) 
				{
					this._isImportantTouSu = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsImportantTouSu");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _canNotCallback = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool CanNotCallback
		{
			[DebuggerStepThrough()]
			get { return this._canNotCallback; }
			set 
			{
				if (this._canNotCallback != value) 
				{
					this._canNotCallback = value;
					this.IsDirty = true;	
					OnPropertyChanged("CanNotCallback");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _colseFilePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ColseFilePath
		{
			[DebuggerStepThrough()]
			get { return this._colseFilePath; }
			set 
			{
				if (this._colseFilePath != value) 
				{
					this._colseFilePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("ColseFilePath");
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
	[ProjectID] int,
	[ServiceFullName] nvarchar(500),
	[ProjectName] nvarchar(100),
	[AddUserName] nvarchar(50),
	[StartTime] datetime,
	[ServiceArea] nvarchar(50),
	[ServiceNumber] nvarchar(100),
	[AddCustomerName] nvarchar(50),
	[AddCallPhone] nvarchar(50),
	[ServiceContent] ntext,
	[AddTime] datetime,
	[ServiceStatus] int,
	[BanJieTime] datetime,
	[BanJieNote] ntext,
	[ServiceAppointTime] datetime,
	[AddMan] nvarchar(50),
	[OrderNumberID] int,
	[HandelFee] nvarchar(50),
	[TotalFee] decimal(18, 2),
	[BalanceStatus] nvarchar(50),
	[CKProductOutSumaryID] int,
	[IsRequireCost] bit,
	[IsRequireProduct] bit,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[APPSendTime] datetime,
	[APPSendResult] ntext,
	[WechatServiceID] int,
	[AcceptTime] datetime,
	[TaskType] int,
	[ServiceFrom] nvarchar(50),
	[AddUserID] int,
	[SendUserID] int,
	[SendUserName] nvarchar(50),
	[BanJieManUserID] int,
	[BanJieManName] nvarchar(100),
	[IsUnRead] bit,
	[DepartmentID] int,
	[IsSuggestion] bit,
	[PublicProjectID] int,
	[IsHighTouSu] bit,
	[IsInvalidCall] bit,
	[IsInWeiBao] bit,
	[IsClosed] bit,
	[ConfirmStatus] int,
	[ServiceType1ID] int,
	[ServiceType2ID] nvarchar(200),
	[ServiceType3ID] nvarchar(200),
	[RelatedServiceID] int,
	[CloseTime] datetime,
	[HuiFangRate] decimal(18, 2),
	[IsImportantTouSu] bit,
	[CanNotCallback] bit,
	[ColseFilePath] nvarchar(500)
);

INSERT INTO [dbo].[CustomerService] (
	[CustomerService].[ProjectID],
	[CustomerService].[ServiceFullName],
	[CustomerService].[ProjectName],
	[CustomerService].[AddUserName],
	[CustomerService].[StartTime],
	[CustomerService].[ServiceArea],
	[CustomerService].[ServiceNumber],
	[CustomerService].[AddCustomerName],
	[CustomerService].[AddCallPhone],
	[CustomerService].[ServiceContent],
	[CustomerService].[AddTime],
	[CustomerService].[ServiceStatus],
	[CustomerService].[BanJieTime],
	[CustomerService].[BanJieNote],
	[CustomerService].[ServiceAppointTime],
	[CustomerService].[AddMan],
	[CustomerService].[OrderNumberID],
	[CustomerService].[HandelFee],
	[CustomerService].[TotalFee],
	[CustomerService].[BalanceStatus],
	[CustomerService].[CKProductOutSumaryID],
	[CustomerService].[IsRequireCost],
	[CustomerService].[IsRequireProduct],
	[CustomerService].[IsAPPShow],
	[CustomerService].[IsAPPSend],
	[CustomerService].[APPSendTime],
	[CustomerService].[APPSendResult],
	[CustomerService].[WechatServiceID],
	[CustomerService].[AcceptTime],
	[CustomerService].[TaskType],
	[CustomerService].[ServiceFrom],
	[CustomerService].[AddUserID],
	[CustomerService].[SendUserID],
	[CustomerService].[SendUserName],
	[CustomerService].[BanJieManUserID],
	[CustomerService].[BanJieManName],
	[CustomerService].[IsUnRead],
	[CustomerService].[DepartmentID],
	[CustomerService].[IsSuggestion],
	[CustomerService].[PublicProjectID],
	[CustomerService].[IsHighTouSu],
	[CustomerService].[IsInvalidCall],
	[CustomerService].[IsInWeiBao],
	[CustomerService].[IsClosed],
	[CustomerService].[ConfirmStatus],
	[CustomerService].[ServiceType1ID],
	[CustomerService].[ServiceType2ID],
	[CustomerService].[ServiceType3ID],
	[CustomerService].[RelatedServiceID],
	[CustomerService].[CloseTime],
	[CustomerService].[HuiFangRate],
	[CustomerService].[IsImportantTouSu],
	[CustomerService].[CanNotCallback],
	[CustomerService].[ColseFilePath]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ServiceFullName],
	INSERTED.[ProjectName],
	INSERTED.[AddUserName],
	INSERTED.[StartTime],
	INSERTED.[ServiceArea],
	INSERTED.[ServiceNumber],
	INSERTED.[AddCustomerName],
	INSERTED.[AddCallPhone],
	INSERTED.[ServiceContent],
	INSERTED.[AddTime],
	INSERTED.[ServiceStatus],
	INSERTED.[BanJieTime],
	INSERTED.[BanJieNote],
	INSERTED.[ServiceAppointTime],
	INSERTED.[AddMan],
	INSERTED.[OrderNumberID],
	INSERTED.[HandelFee],
	INSERTED.[TotalFee],
	INSERTED.[BalanceStatus],
	INSERTED.[CKProductOutSumaryID],
	INSERTED.[IsRequireCost],
	INSERTED.[IsRequireProduct],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[APPSendTime],
	INSERTED.[APPSendResult],
	INSERTED.[WechatServiceID],
	INSERTED.[AcceptTime],
	INSERTED.[TaskType],
	INSERTED.[ServiceFrom],
	INSERTED.[AddUserID],
	INSERTED.[SendUserID],
	INSERTED.[SendUserName],
	INSERTED.[BanJieManUserID],
	INSERTED.[BanJieManName],
	INSERTED.[IsUnRead],
	INSERTED.[DepartmentID],
	INSERTED.[IsSuggestion],
	INSERTED.[PublicProjectID],
	INSERTED.[IsHighTouSu],
	INSERTED.[IsInvalidCall],
	INSERTED.[IsInWeiBao],
	INSERTED.[IsClosed],
	INSERTED.[ConfirmStatus],
	INSERTED.[ServiceType1ID],
	INSERTED.[ServiceType2ID],
	INSERTED.[ServiceType3ID],
	INSERTED.[RelatedServiceID],
	INSERTED.[CloseTime],
	INSERTED.[HuiFangRate],
	INSERTED.[IsImportantTouSu],
	INSERTED.[CanNotCallback],
	INSERTED.[ColseFilePath]
into @table
VALUES ( 
	@ProjectID,
	@ServiceFullName,
	@ProjectName,
	@AddUserName,
	@StartTime,
	@ServiceArea,
	@ServiceNumber,
	@AddCustomerName,
	@AddCallPhone,
	@ServiceContent,
	@AddTime,
	@ServiceStatus,
	@BanJieTime,
	@BanJieNote,
	@ServiceAppointTime,
	@AddMan,
	@OrderNumberID,
	@HandelFee,
	@TotalFee,
	@BalanceStatus,
	@CKProductOutSumaryID,
	@IsRequireCost,
	@IsRequireProduct,
	@IsAPPShow,
	@IsAPPSend,
	@APPSendTime,
	@APPSendResult,
	@WechatServiceID,
	@AcceptTime,
	@TaskType,
	@ServiceFrom,
	@AddUserID,
	@SendUserID,
	@SendUserName,
	@BanJieManUserID,
	@BanJieManName,
	@IsUnRead,
	@DepartmentID,
	@IsSuggestion,
	@PublicProjectID,
	@IsHighTouSu,
	@IsInvalidCall,
	@IsInWeiBao,
	@IsClosed,
	@ConfirmStatus,
	@ServiceType1ID,
	@ServiceType2ID,
	@ServiceType3ID,
	@RelatedServiceID,
	@CloseTime,
	@HuiFangRate,
	@IsImportantTouSu,
	@CanNotCallback,
	@ColseFilePath 
); 

SELECT 
	[ID],
	[ProjectID],
	[ServiceFullName],
	[ProjectName],
	[AddUserName],
	[StartTime],
	[ServiceArea],
	[ServiceNumber],
	[AddCustomerName],
	[AddCallPhone],
	[ServiceContent],
	[AddTime],
	[ServiceStatus],
	[BanJieTime],
	[BanJieNote],
	[ServiceAppointTime],
	[AddMan],
	[OrderNumberID],
	[HandelFee],
	[TotalFee],
	[BalanceStatus],
	[CKProductOutSumaryID],
	[IsRequireCost],
	[IsRequireProduct],
	[IsAPPShow],
	[IsAPPSend],
	[APPSendTime],
	[APPSendResult],
	[WechatServiceID],
	[AcceptTime],
	[TaskType],
	[ServiceFrom],
	[AddUserID],
	[SendUserID],
	[SendUserName],
	[BanJieManUserID],
	[BanJieManName],
	[IsUnRead],
	[DepartmentID],
	[IsSuggestion],
	[PublicProjectID],
	[IsHighTouSu],
	[IsInvalidCall],
	[IsInWeiBao],
	[IsClosed],
	[ConfirmStatus],
	[ServiceType1ID],
	[ServiceType2ID],
	[ServiceType3ID],
	[RelatedServiceID],
	[CloseTime],
	[HuiFangRate],
	[IsImportantTouSu],
	[CanNotCallback],
	[ColseFilePath] 
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
	[ProjectID] int,
	[ServiceFullName] nvarchar(500),
	[ProjectName] nvarchar(100),
	[AddUserName] nvarchar(50),
	[StartTime] datetime,
	[ServiceArea] nvarchar(50),
	[ServiceNumber] nvarchar(100),
	[AddCustomerName] nvarchar(50),
	[AddCallPhone] nvarchar(50),
	[ServiceContent] ntext,
	[AddTime] datetime,
	[ServiceStatus] int,
	[BanJieTime] datetime,
	[BanJieNote] ntext,
	[ServiceAppointTime] datetime,
	[AddMan] nvarchar(50),
	[OrderNumberID] int,
	[HandelFee] nvarchar(50),
	[TotalFee] decimal(18, 2),
	[BalanceStatus] nvarchar(50),
	[CKProductOutSumaryID] int,
	[IsRequireCost] bit,
	[IsRequireProduct] bit,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[APPSendTime] datetime,
	[APPSendResult] ntext,
	[WechatServiceID] int,
	[AcceptTime] datetime,
	[TaskType] int,
	[ServiceFrom] nvarchar(50),
	[AddUserID] int,
	[SendUserID] int,
	[SendUserName] nvarchar(50),
	[BanJieManUserID] int,
	[BanJieManName] nvarchar(100),
	[IsUnRead] bit,
	[DepartmentID] int,
	[IsSuggestion] bit,
	[PublicProjectID] int,
	[IsHighTouSu] bit,
	[IsInvalidCall] bit,
	[IsInWeiBao] bit,
	[IsClosed] bit,
	[ConfirmStatus] int,
	[ServiceType1ID] int,
	[ServiceType2ID] nvarchar(200),
	[ServiceType3ID] nvarchar(200),
	[RelatedServiceID] int,
	[CloseTime] datetime,
	[HuiFangRate] decimal(18, 2),
	[IsImportantTouSu] bit,
	[CanNotCallback] bit,
	[ColseFilePath] nvarchar(500)
);

UPDATE [dbo].[CustomerService] SET 
	[CustomerService].[ProjectID] = @ProjectID,
	[CustomerService].[ServiceFullName] = @ServiceFullName,
	[CustomerService].[ProjectName] = @ProjectName,
	[CustomerService].[AddUserName] = @AddUserName,
	[CustomerService].[StartTime] = @StartTime,
	[CustomerService].[ServiceArea] = @ServiceArea,
	[CustomerService].[ServiceNumber] = @ServiceNumber,
	[CustomerService].[AddCustomerName] = @AddCustomerName,
	[CustomerService].[AddCallPhone] = @AddCallPhone,
	[CustomerService].[ServiceContent] = @ServiceContent,
	[CustomerService].[AddTime] = @AddTime,
	[CustomerService].[ServiceStatus] = @ServiceStatus,
	[CustomerService].[BanJieTime] = @BanJieTime,
	[CustomerService].[BanJieNote] = @BanJieNote,
	[CustomerService].[ServiceAppointTime] = @ServiceAppointTime,
	[CustomerService].[AddMan] = @AddMan,
	[CustomerService].[OrderNumberID] = @OrderNumberID,
	[CustomerService].[HandelFee] = @HandelFee,
	[CustomerService].[TotalFee] = @TotalFee,
	[CustomerService].[BalanceStatus] = @BalanceStatus,
	[CustomerService].[CKProductOutSumaryID] = @CKProductOutSumaryID,
	[CustomerService].[IsRequireCost] = @IsRequireCost,
	[CustomerService].[IsRequireProduct] = @IsRequireProduct,
	[CustomerService].[IsAPPShow] = @IsAPPShow,
	[CustomerService].[IsAPPSend] = @IsAPPSend,
	[CustomerService].[APPSendTime] = @APPSendTime,
	[CustomerService].[APPSendResult] = @APPSendResult,
	[CustomerService].[WechatServiceID] = @WechatServiceID,
	[CustomerService].[AcceptTime] = @AcceptTime,
	[CustomerService].[TaskType] = @TaskType,
	[CustomerService].[ServiceFrom] = @ServiceFrom,
	[CustomerService].[AddUserID] = @AddUserID,
	[CustomerService].[SendUserID] = @SendUserID,
	[CustomerService].[SendUserName] = @SendUserName,
	[CustomerService].[BanJieManUserID] = @BanJieManUserID,
	[CustomerService].[BanJieManName] = @BanJieManName,
	[CustomerService].[IsUnRead] = @IsUnRead,
	[CustomerService].[DepartmentID] = @DepartmentID,
	[CustomerService].[IsSuggestion] = @IsSuggestion,
	[CustomerService].[PublicProjectID] = @PublicProjectID,
	[CustomerService].[IsHighTouSu] = @IsHighTouSu,
	[CustomerService].[IsInvalidCall] = @IsInvalidCall,
	[CustomerService].[IsInWeiBao] = @IsInWeiBao,
	[CustomerService].[IsClosed] = @IsClosed,
	[CustomerService].[ConfirmStatus] = @ConfirmStatus,
	[CustomerService].[ServiceType1ID] = @ServiceType1ID,
	[CustomerService].[ServiceType2ID] = @ServiceType2ID,
	[CustomerService].[ServiceType3ID] = @ServiceType3ID,
	[CustomerService].[RelatedServiceID] = @RelatedServiceID,
	[CustomerService].[CloseTime] = @CloseTime,
	[CustomerService].[HuiFangRate] = @HuiFangRate,
	[CustomerService].[IsImportantTouSu] = @IsImportantTouSu,
	[CustomerService].[CanNotCallback] = @CanNotCallback,
	[CustomerService].[ColseFilePath] = @ColseFilePath 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ServiceFullName],
	INSERTED.[ProjectName],
	INSERTED.[AddUserName],
	INSERTED.[StartTime],
	INSERTED.[ServiceArea],
	INSERTED.[ServiceNumber],
	INSERTED.[AddCustomerName],
	INSERTED.[AddCallPhone],
	INSERTED.[ServiceContent],
	INSERTED.[AddTime],
	INSERTED.[ServiceStatus],
	INSERTED.[BanJieTime],
	INSERTED.[BanJieNote],
	INSERTED.[ServiceAppointTime],
	INSERTED.[AddMan],
	INSERTED.[OrderNumberID],
	INSERTED.[HandelFee],
	INSERTED.[TotalFee],
	INSERTED.[BalanceStatus],
	INSERTED.[CKProductOutSumaryID],
	INSERTED.[IsRequireCost],
	INSERTED.[IsRequireProduct],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[APPSendTime],
	INSERTED.[APPSendResult],
	INSERTED.[WechatServiceID],
	INSERTED.[AcceptTime],
	INSERTED.[TaskType],
	INSERTED.[ServiceFrom],
	INSERTED.[AddUserID],
	INSERTED.[SendUserID],
	INSERTED.[SendUserName],
	INSERTED.[BanJieManUserID],
	INSERTED.[BanJieManName],
	INSERTED.[IsUnRead],
	INSERTED.[DepartmentID],
	INSERTED.[IsSuggestion],
	INSERTED.[PublicProjectID],
	INSERTED.[IsHighTouSu],
	INSERTED.[IsInvalidCall],
	INSERTED.[IsInWeiBao],
	INSERTED.[IsClosed],
	INSERTED.[ConfirmStatus],
	INSERTED.[ServiceType1ID],
	INSERTED.[ServiceType2ID],
	INSERTED.[ServiceType3ID],
	INSERTED.[RelatedServiceID],
	INSERTED.[CloseTime],
	INSERTED.[HuiFangRate],
	INSERTED.[IsImportantTouSu],
	INSERTED.[CanNotCallback],
	INSERTED.[ColseFilePath]
into @table
WHERE 
	[CustomerService].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[ServiceFullName],
	[ProjectName],
	[AddUserName],
	[StartTime],
	[ServiceArea],
	[ServiceNumber],
	[AddCustomerName],
	[AddCallPhone],
	[ServiceContent],
	[AddTime],
	[ServiceStatus],
	[BanJieTime],
	[BanJieNote],
	[ServiceAppointTime],
	[AddMan],
	[OrderNumberID],
	[HandelFee],
	[TotalFee],
	[BalanceStatus],
	[CKProductOutSumaryID],
	[IsRequireCost],
	[IsRequireProduct],
	[IsAPPShow],
	[IsAPPSend],
	[APPSendTime],
	[APPSendResult],
	[WechatServiceID],
	[AcceptTime],
	[TaskType],
	[ServiceFrom],
	[AddUserID],
	[SendUserID],
	[SendUserName],
	[BanJieManUserID],
	[BanJieManName],
	[IsUnRead],
	[DepartmentID],
	[IsSuggestion],
	[PublicProjectID],
	[IsHighTouSu],
	[IsInvalidCall],
	[IsInWeiBao],
	[IsClosed],
	[ConfirmStatus],
	[ServiceType1ID],
	[ServiceType2ID],
	[ServiceType3ID],
	[RelatedServiceID],
	[CloseTime],
	[HuiFangRate],
	[IsImportantTouSu],
	[CanNotCallback],
	[ColseFilePath] 
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
DELETE FROM [dbo].[CustomerService]
WHERE 
	[CustomerService].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CustomerService() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCustomerService(this.ID));
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
	[CustomerService].[ID],
	[CustomerService].[ProjectID],
	[CustomerService].[ServiceFullName],
	[CustomerService].[ProjectName],
	[CustomerService].[AddUserName],
	[CustomerService].[StartTime],
	[CustomerService].[ServiceArea],
	[CustomerService].[ServiceNumber],
	[CustomerService].[AddCustomerName],
	[CustomerService].[AddCallPhone],
	[CustomerService].[ServiceContent],
	[CustomerService].[AddTime],
	[CustomerService].[ServiceStatus],
	[CustomerService].[BanJieTime],
	[CustomerService].[BanJieNote],
	[CustomerService].[ServiceAppointTime],
	[CustomerService].[AddMan],
	[CustomerService].[OrderNumberID],
	[CustomerService].[HandelFee],
	[CustomerService].[TotalFee],
	[CustomerService].[BalanceStatus],
	[CustomerService].[CKProductOutSumaryID],
	[CustomerService].[IsRequireCost],
	[CustomerService].[IsRequireProduct],
	[CustomerService].[IsAPPShow],
	[CustomerService].[IsAPPSend],
	[CustomerService].[APPSendTime],
	[CustomerService].[APPSendResult],
	[CustomerService].[WechatServiceID],
	[CustomerService].[AcceptTime],
	[CustomerService].[TaskType],
	[CustomerService].[ServiceFrom],
	[CustomerService].[AddUserID],
	[CustomerService].[SendUserID],
	[CustomerService].[SendUserName],
	[CustomerService].[BanJieManUserID],
	[CustomerService].[BanJieManName],
	[CustomerService].[IsUnRead],
	[CustomerService].[DepartmentID],
	[CustomerService].[IsSuggestion],
	[CustomerService].[PublicProjectID],
	[CustomerService].[IsHighTouSu],
	[CustomerService].[IsInvalidCall],
	[CustomerService].[IsInWeiBao],
	[CustomerService].[IsClosed],
	[CustomerService].[ConfirmStatus],
	[CustomerService].[ServiceType1ID],
	[CustomerService].[ServiceType2ID],
	[CustomerService].[ServiceType3ID],
	[CustomerService].[RelatedServiceID],
	[CustomerService].[CloseTime],
	[CustomerService].[HuiFangRate],
	[CustomerService].[IsImportantTouSu],
	[CustomerService].[CanNotCallback],
	[CustomerService].[ColseFilePath]
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
                return "CustomerService";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CustomerService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="serviceFullName">serviceFullName</param>
		/// <param name="projectName">projectName</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="serviceArea">serviceArea</param>
		/// <param name="serviceNumber">serviceNumber</param>
		/// <param name="addCustomerName">addCustomerName</param>
		/// <param name="addCallPhone">addCallPhone</param>
		/// <param name="serviceContent">serviceContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="serviceStatus">serviceStatus</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="banJieNote">banJieNote</param>
		/// <param name="serviceAppointTime">serviceAppointTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="handelFee">handelFee</param>
		/// <param name="totalFee">totalFee</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="cKProductOutSumaryID">cKProductOutSumaryID</param>
		/// <param name="isRequireCost">isRequireCost</param>
		/// <param name="isRequireProduct">isRequireProduct</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="aPPSendTime">aPPSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="wechatServiceID">wechatServiceID</param>
		/// <param name="acceptTime">acceptTime</param>
		/// <param name="taskType">taskType</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="sendUserID">sendUserID</param>
		/// <param name="sendUserName">sendUserName</param>
		/// <param name="banJieManUserID">banJieManUserID</param>
		/// <param name="banJieManName">banJieManName</param>
		/// <param name="isUnRead">isUnRead</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="publicProjectID">publicProjectID</param>
		/// <param name="isHighTouSu">isHighTouSu</param>
		/// <param name="isInvalidCall">isInvalidCall</param>
		/// <param name="isInWeiBao">isInWeiBao</param>
		/// <param name="isClosed">isClosed</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="serviceType1ID">serviceType1ID</param>
		/// <param name="serviceType2ID">serviceType2ID</param>
		/// <param name="serviceType3ID">serviceType3ID</param>
		/// <param name="relatedServiceID">relatedServiceID</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="huiFangRate">huiFangRate</param>
		/// <param name="isImportantTouSu">isImportantTouSu</param>
		/// <param name="canNotCallback">canNotCallback</param>
		/// <param name="colseFilePath">colseFilePath</param>
		public static void InsertCustomerService(int @projectID, string @serviceFullName, string @projectName, string @addUserName, DateTime @startTime, string @serviceArea, string @serviceNumber, string @addCustomerName, string @addCallPhone, string @serviceContent, DateTime @addTime, int @serviceStatus, DateTime @banJieTime, string @banJieNote, DateTime @serviceAppointTime, string @addMan, int @orderNumberID, string @handelFee, decimal @totalFee, string @balanceStatus, int @cKProductOutSumaryID, bool @isRequireCost, bool @isRequireProduct, bool @isAPPShow, bool @isAPPSend, DateTime @aPPSendTime, string @aPPSendResult, int @wechatServiceID, DateTime @acceptTime, int @taskType, string @serviceFrom, int @addUserID, int @sendUserID, string @sendUserName, int @banJieManUserID, string @banJieManName, bool @isUnRead, int @departmentID, bool @isSuggestion, int @publicProjectID, bool @isHighTouSu, bool @isInvalidCall, bool @isInWeiBao, bool @isClosed, int @confirmStatus, int @serviceType1ID, string @serviceType2ID, string @serviceType3ID, int @relatedServiceID, DateTime @closeTime, decimal @huiFangRate, bool @isImportantTouSu, bool @canNotCallback, string @colseFilePath)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCustomerService(@projectID, @serviceFullName, @projectName, @addUserName, @startTime, @serviceArea, @serviceNumber, @addCustomerName, @addCallPhone, @serviceContent, @addTime, @serviceStatus, @banJieTime, @banJieNote, @serviceAppointTime, @addMan, @orderNumberID, @handelFee, @totalFee, @balanceStatus, @cKProductOutSumaryID, @isRequireCost, @isRequireProduct, @isAPPShow, @isAPPSend, @aPPSendTime, @aPPSendResult, @wechatServiceID, @acceptTime, @taskType, @serviceFrom, @addUserID, @sendUserID, @sendUserName, @banJieManUserID, @banJieManName, @isUnRead, @departmentID, @isSuggestion, @publicProjectID, @isHighTouSu, @isInvalidCall, @isInWeiBao, @isClosed, @confirmStatus, @serviceType1ID, @serviceType2ID, @serviceType3ID, @relatedServiceID, @closeTime, @huiFangRate, @isImportantTouSu, @canNotCallback, @colseFilePath, helper);
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
		/// Insert a CustomerService into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="serviceFullName">serviceFullName</param>
		/// <param name="projectName">projectName</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="serviceArea">serviceArea</param>
		/// <param name="serviceNumber">serviceNumber</param>
		/// <param name="addCustomerName">addCustomerName</param>
		/// <param name="addCallPhone">addCallPhone</param>
		/// <param name="serviceContent">serviceContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="serviceStatus">serviceStatus</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="banJieNote">banJieNote</param>
		/// <param name="serviceAppointTime">serviceAppointTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="handelFee">handelFee</param>
		/// <param name="totalFee">totalFee</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="cKProductOutSumaryID">cKProductOutSumaryID</param>
		/// <param name="isRequireCost">isRequireCost</param>
		/// <param name="isRequireProduct">isRequireProduct</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="aPPSendTime">aPPSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="wechatServiceID">wechatServiceID</param>
		/// <param name="acceptTime">acceptTime</param>
		/// <param name="taskType">taskType</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="sendUserID">sendUserID</param>
		/// <param name="sendUserName">sendUserName</param>
		/// <param name="banJieManUserID">banJieManUserID</param>
		/// <param name="banJieManName">banJieManName</param>
		/// <param name="isUnRead">isUnRead</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="publicProjectID">publicProjectID</param>
		/// <param name="isHighTouSu">isHighTouSu</param>
		/// <param name="isInvalidCall">isInvalidCall</param>
		/// <param name="isInWeiBao">isInWeiBao</param>
		/// <param name="isClosed">isClosed</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="serviceType1ID">serviceType1ID</param>
		/// <param name="serviceType2ID">serviceType2ID</param>
		/// <param name="serviceType3ID">serviceType3ID</param>
		/// <param name="relatedServiceID">relatedServiceID</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="huiFangRate">huiFangRate</param>
		/// <param name="isImportantTouSu">isImportantTouSu</param>
		/// <param name="canNotCallback">canNotCallback</param>
		/// <param name="colseFilePath">colseFilePath</param>
		/// <param name="helper">helper</param>
		internal static void InsertCustomerService(int @projectID, string @serviceFullName, string @projectName, string @addUserName, DateTime @startTime, string @serviceArea, string @serviceNumber, string @addCustomerName, string @addCallPhone, string @serviceContent, DateTime @addTime, int @serviceStatus, DateTime @banJieTime, string @banJieNote, DateTime @serviceAppointTime, string @addMan, int @orderNumberID, string @handelFee, decimal @totalFee, string @balanceStatus, int @cKProductOutSumaryID, bool @isRequireCost, bool @isRequireProduct, bool @isAPPShow, bool @isAPPSend, DateTime @aPPSendTime, string @aPPSendResult, int @wechatServiceID, DateTime @acceptTime, int @taskType, string @serviceFrom, int @addUserID, int @sendUserID, string @sendUserName, int @banJieManUserID, string @banJieManName, bool @isUnRead, int @departmentID, bool @isSuggestion, int @publicProjectID, bool @isHighTouSu, bool @isInvalidCall, bool @isInWeiBao, bool @isClosed, int @confirmStatus, int @serviceType1ID, string @serviceType2ID, string @serviceType3ID, int @relatedServiceID, DateTime @closeTime, decimal @huiFangRate, bool @isImportantTouSu, bool @canNotCallback, string @colseFilePath, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[ServiceFullName] nvarchar(500),
	[ProjectName] nvarchar(100),
	[AddUserName] nvarchar(50),
	[StartTime] datetime,
	[ServiceArea] nvarchar(50),
	[ServiceNumber] nvarchar(100),
	[AddCustomerName] nvarchar(50),
	[AddCallPhone] nvarchar(50),
	[ServiceContent] ntext,
	[AddTime] datetime,
	[ServiceStatus] int,
	[BanJieTime] datetime,
	[BanJieNote] ntext,
	[ServiceAppointTime] datetime,
	[AddMan] nvarchar(50),
	[OrderNumberID] int,
	[HandelFee] nvarchar(50),
	[TotalFee] decimal(18, 2),
	[BalanceStatus] nvarchar(50),
	[CKProductOutSumaryID] int,
	[IsRequireCost] bit,
	[IsRequireProduct] bit,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[APPSendTime] datetime,
	[APPSendResult] ntext,
	[WechatServiceID] int,
	[AcceptTime] datetime,
	[TaskType] int,
	[ServiceFrom] nvarchar(50),
	[AddUserID] int,
	[SendUserID] int,
	[SendUserName] nvarchar(50),
	[BanJieManUserID] int,
	[BanJieManName] nvarchar(100),
	[IsUnRead] bit,
	[DepartmentID] int,
	[IsSuggestion] bit,
	[PublicProjectID] int,
	[IsHighTouSu] bit,
	[IsInvalidCall] bit,
	[IsInWeiBao] bit,
	[IsClosed] bit,
	[ConfirmStatus] int,
	[ServiceType1ID] int,
	[ServiceType2ID] nvarchar(200),
	[ServiceType3ID] nvarchar(200),
	[RelatedServiceID] int,
	[CloseTime] datetime,
	[HuiFangRate] decimal(18, 2),
	[IsImportantTouSu] bit,
	[CanNotCallback] bit,
	[ColseFilePath] nvarchar(500)
);

INSERT INTO [dbo].[CustomerService] (
	[CustomerService].[ProjectID],
	[CustomerService].[ServiceFullName],
	[CustomerService].[ProjectName],
	[CustomerService].[AddUserName],
	[CustomerService].[StartTime],
	[CustomerService].[ServiceArea],
	[CustomerService].[ServiceNumber],
	[CustomerService].[AddCustomerName],
	[CustomerService].[AddCallPhone],
	[CustomerService].[ServiceContent],
	[CustomerService].[AddTime],
	[CustomerService].[ServiceStatus],
	[CustomerService].[BanJieTime],
	[CustomerService].[BanJieNote],
	[CustomerService].[ServiceAppointTime],
	[CustomerService].[AddMan],
	[CustomerService].[OrderNumberID],
	[CustomerService].[HandelFee],
	[CustomerService].[TotalFee],
	[CustomerService].[BalanceStatus],
	[CustomerService].[CKProductOutSumaryID],
	[CustomerService].[IsRequireCost],
	[CustomerService].[IsRequireProduct],
	[CustomerService].[IsAPPShow],
	[CustomerService].[IsAPPSend],
	[CustomerService].[APPSendTime],
	[CustomerService].[APPSendResult],
	[CustomerService].[WechatServiceID],
	[CustomerService].[AcceptTime],
	[CustomerService].[TaskType],
	[CustomerService].[ServiceFrom],
	[CustomerService].[AddUserID],
	[CustomerService].[SendUserID],
	[CustomerService].[SendUserName],
	[CustomerService].[BanJieManUserID],
	[CustomerService].[BanJieManName],
	[CustomerService].[IsUnRead],
	[CustomerService].[DepartmentID],
	[CustomerService].[IsSuggestion],
	[CustomerService].[PublicProjectID],
	[CustomerService].[IsHighTouSu],
	[CustomerService].[IsInvalidCall],
	[CustomerService].[IsInWeiBao],
	[CustomerService].[IsClosed],
	[CustomerService].[ConfirmStatus],
	[CustomerService].[ServiceType1ID],
	[CustomerService].[ServiceType2ID],
	[CustomerService].[ServiceType3ID],
	[CustomerService].[RelatedServiceID],
	[CustomerService].[CloseTime],
	[CustomerService].[HuiFangRate],
	[CustomerService].[IsImportantTouSu],
	[CustomerService].[CanNotCallback],
	[CustomerService].[ColseFilePath]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ServiceFullName],
	INSERTED.[ProjectName],
	INSERTED.[AddUserName],
	INSERTED.[StartTime],
	INSERTED.[ServiceArea],
	INSERTED.[ServiceNumber],
	INSERTED.[AddCustomerName],
	INSERTED.[AddCallPhone],
	INSERTED.[ServiceContent],
	INSERTED.[AddTime],
	INSERTED.[ServiceStatus],
	INSERTED.[BanJieTime],
	INSERTED.[BanJieNote],
	INSERTED.[ServiceAppointTime],
	INSERTED.[AddMan],
	INSERTED.[OrderNumberID],
	INSERTED.[HandelFee],
	INSERTED.[TotalFee],
	INSERTED.[BalanceStatus],
	INSERTED.[CKProductOutSumaryID],
	INSERTED.[IsRequireCost],
	INSERTED.[IsRequireProduct],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[APPSendTime],
	INSERTED.[APPSendResult],
	INSERTED.[WechatServiceID],
	INSERTED.[AcceptTime],
	INSERTED.[TaskType],
	INSERTED.[ServiceFrom],
	INSERTED.[AddUserID],
	INSERTED.[SendUserID],
	INSERTED.[SendUserName],
	INSERTED.[BanJieManUserID],
	INSERTED.[BanJieManName],
	INSERTED.[IsUnRead],
	INSERTED.[DepartmentID],
	INSERTED.[IsSuggestion],
	INSERTED.[PublicProjectID],
	INSERTED.[IsHighTouSu],
	INSERTED.[IsInvalidCall],
	INSERTED.[IsInWeiBao],
	INSERTED.[IsClosed],
	INSERTED.[ConfirmStatus],
	INSERTED.[ServiceType1ID],
	INSERTED.[ServiceType2ID],
	INSERTED.[ServiceType3ID],
	INSERTED.[RelatedServiceID],
	INSERTED.[CloseTime],
	INSERTED.[HuiFangRate],
	INSERTED.[IsImportantTouSu],
	INSERTED.[CanNotCallback],
	INSERTED.[ColseFilePath]
into @table
VALUES ( 
	@ProjectID,
	@ServiceFullName,
	@ProjectName,
	@AddUserName,
	@StartTime,
	@ServiceArea,
	@ServiceNumber,
	@AddCustomerName,
	@AddCallPhone,
	@ServiceContent,
	@AddTime,
	@ServiceStatus,
	@BanJieTime,
	@BanJieNote,
	@ServiceAppointTime,
	@AddMan,
	@OrderNumberID,
	@HandelFee,
	@TotalFee,
	@BalanceStatus,
	@CKProductOutSumaryID,
	@IsRequireCost,
	@IsRequireProduct,
	@IsAPPShow,
	@IsAPPSend,
	@APPSendTime,
	@APPSendResult,
	@WechatServiceID,
	@AcceptTime,
	@TaskType,
	@ServiceFrom,
	@AddUserID,
	@SendUserID,
	@SendUserName,
	@BanJieManUserID,
	@BanJieManName,
	@IsUnRead,
	@DepartmentID,
	@IsSuggestion,
	@PublicProjectID,
	@IsHighTouSu,
	@IsInvalidCall,
	@IsInWeiBao,
	@IsClosed,
	@ConfirmStatus,
	@ServiceType1ID,
	@ServiceType2ID,
	@ServiceType3ID,
	@RelatedServiceID,
	@CloseTime,
	@HuiFangRate,
	@IsImportantTouSu,
	@CanNotCallback,
	@ColseFilePath 
); 

SELECT 
	[ID],
	[ProjectID],
	[ServiceFullName],
	[ProjectName],
	[AddUserName],
	[StartTime],
	[ServiceArea],
	[ServiceNumber],
	[AddCustomerName],
	[AddCallPhone],
	[ServiceContent],
	[AddTime],
	[ServiceStatus],
	[BanJieTime],
	[BanJieNote],
	[ServiceAppointTime],
	[AddMan],
	[OrderNumberID],
	[HandelFee],
	[TotalFee],
	[BalanceStatus],
	[CKProductOutSumaryID],
	[IsRequireCost],
	[IsRequireProduct],
	[IsAPPShow],
	[IsAPPSend],
	[APPSendTime],
	[APPSendResult],
	[WechatServiceID],
	[AcceptTime],
	[TaskType],
	[ServiceFrom],
	[AddUserID],
	[SendUserID],
	[SendUserName],
	[BanJieManUserID],
	[BanJieManName],
	[IsUnRead],
	[DepartmentID],
	[IsSuggestion],
	[PublicProjectID],
	[IsHighTouSu],
	[IsInvalidCall],
	[IsInWeiBao],
	[IsClosed],
	[ConfirmStatus],
	[ServiceType1ID],
	[ServiceType2ID],
	[ServiceType3ID],
	[RelatedServiceID],
	[CloseTime],
	[HuiFangRate],
	[IsImportantTouSu],
	[CanNotCallback],
	[ColseFilePath] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ServiceFullName", EntityBase.GetDatabaseValue(@serviceFullName)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@ServiceArea", EntityBase.GetDatabaseValue(@serviceArea)));
			parameters.Add(new SqlParameter("@ServiceNumber", EntityBase.GetDatabaseValue(@serviceNumber)));
			parameters.Add(new SqlParameter("@AddCustomerName", EntityBase.GetDatabaseValue(@addCustomerName)));
			parameters.Add(new SqlParameter("@AddCallPhone", EntityBase.GetDatabaseValue(@addCallPhone)));
			parameters.Add(new SqlParameter("@ServiceContent", EntityBase.GetDatabaseValue(@serviceContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ServiceStatus", EntityBase.GetDatabaseValue(@serviceStatus)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@BanJieNote", EntityBase.GetDatabaseValue(@banJieNote)));
			parameters.Add(new SqlParameter("@ServiceAppointTime", EntityBase.GetDatabaseValue(@serviceAppointTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@HandelFee", EntityBase.GetDatabaseValue(@handelFee)));
			parameters.Add(new SqlParameter("@TotalFee", EntityBase.GetDatabaseValue(@totalFee)));
			parameters.Add(new SqlParameter("@BalanceStatus", EntityBase.GetDatabaseValue(@balanceStatus)));
			parameters.Add(new SqlParameter("@CKProductOutSumaryID", EntityBase.GetDatabaseValue(@cKProductOutSumaryID)));
			parameters.Add(new SqlParameter("@IsRequireCost", @isRequireCost));
			parameters.Add(new SqlParameter("@IsRequireProduct", @isRequireProduct));
			parameters.Add(new SqlParameter("@IsAPPShow", @isAPPShow));
			parameters.Add(new SqlParameter("@IsAPPSend", @isAPPSend));
			parameters.Add(new SqlParameter("@APPSendTime", EntityBase.GetDatabaseValue(@aPPSendTime)));
			parameters.Add(new SqlParameter("@APPSendResult", EntityBase.GetDatabaseValue(@aPPSendResult)));
			parameters.Add(new SqlParameter("@WechatServiceID", EntityBase.GetDatabaseValue(@wechatServiceID)));
			parameters.Add(new SqlParameter("@AcceptTime", EntityBase.GetDatabaseValue(@acceptTime)));
			parameters.Add(new SqlParameter("@TaskType", EntityBase.GetDatabaseValue(@taskType)));
			parameters.Add(new SqlParameter("@ServiceFrom", EntityBase.GetDatabaseValue(@serviceFrom)));
			parameters.Add(new SqlParameter("@AddUserID", EntityBase.GetDatabaseValue(@addUserID)));
			parameters.Add(new SqlParameter("@SendUserID", EntityBase.GetDatabaseValue(@sendUserID)));
			parameters.Add(new SqlParameter("@SendUserName", EntityBase.GetDatabaseValue(@sendUserName)));
			parameters.Add(new SqlParameter("@BanJieManUserID", EntityBase.GetDatabaseValue(@banJieManUserID)));
			parameters.Add(new SqlParameter("@BanJieManName", EntityBase.GetDatabaseValue(@banJieManName)));
			parameters.Add(new SqlParameter("@IsUnRead", @isUnRead));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@IsSuggestion", @isSuggestion));
			parameters.Add(new SqlParameter("@PublicProjectID", EntityBase.GetDatabaseValue(@publicProjectID)));
			parameters.Add(new SqlParameter("@IsHighTouSu", @isHighTouSu));
			parameters.Add(new SqlParameter("@IsInvalidCall", @isInvalidCall));
			parameters.Add(new SqlParameter("@IsInWeiBao", @isInWeiBao));
			parameters.Add(new SqlParameter("@IsClosed", @isClosed));
			parameters.Add(new SqlParameter("@ConfirmStatus", EntityBase.GetDatabaseValue(@confirmStatus)));
			parameters.Add(new SqlParameter("@ServiceType1ID", EntityBase.GetDatabaseValue(@serviceType1ID)));
			parameters.Add(new SqlParameter("@ServiceType2ID", EntityBase.GetDatabaseValue(@serviceType2ID)));
			parameters.Add(new SqlParameter("@ServiceType3ID", EntityBase.GetDatabaseValue(@serviceType3ID)));
			parameters.Add(new SqlParameter("@RelatedServiceID", EntityBase.GetDatabaseValue(@relatedServiceID)));
			parameters.Add(new SqlParameter("@CloseTime", EntityBase.GetDatabaseValue(@closeTime)));
			parameters.Add(new SqlParameter("@HuiFangRate", EntityBase.GetDatabaseValue(@huiFangRate)));
			parameters.Add(new SqlParameter("@IsImportantTouSu", @isImportantTouSu));
			parameters.Add(new SqlParameter("@CanNotCallback", @canNotCallback));
			parameters.Add(new SqlParameter("@ColseFilePath", EntityBase.GetDatabaseValue(@colseFilePath)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CustomerService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="serviceFullName">serviceFullName</param>
		/// <param name="projectName">projectName</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="serviceArea">serviceArea</param>
		/// <param name="serviceNumber">serviceNumber</param>
		/// <param name="addCustomerName">addCustomerName</param>
		/// <param name="addCallPhone">addCallPhone</param>
		/// <param name="serviceContent">serviceContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="serviceStatus">serviceStatus</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="banJieNote">banJieNote</param>
		/// <param name="serviceAppointTime">serviceAppointTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="handelFee">handelFee</param>
		/// <param name="totalFee">totalFee</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="cKProductOutSumaryID">cKProductOutSumaryID</param>
		/// <param name="isRequireCost">isRequireCost</param>
		/// <param name="isRequireProduct">isRequireProduct</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="aPPSendTime">aPPSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="wechatServiceID">wechatServiceID</param>
		/// <param name="acceptTime">acceptTime</param>
		/// <param name="taskType">taskType</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="sendUserID">sendUserID</param>
		/// <param name="sendUserName">sendUserName</param>
		/// <param name="banJieManUserID">banJieManUserID</param>
		/// <param name="banJieManName">banJieManName</param>
		/// <param name="isUnRead">isUnRead</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="publicProjectID">publicProjectID</param>
		/// <param name="isHighTouSu">isHighTouSu</param>
		/// <param name="isInvalidCall">isInvalidCall</param>
		/// <param name="isInWeiBao">isInWeiBao</param>
		/// <param name="isClosed">isClosed</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="serviceType1ID">serviceType1ID</param>
		/// <param name="serviceType2ID">serviceType2ID</param>
		/// <param name="serviceType3ID">serviceType3ID</param>
		/// <param name="relatedServiceID">relatedServiceID</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="huiFangRate">huiFangRate</param>
		/// <param name="isImportantTouSu">isImportantTouSu</param>
		/// <param name="canNotCallback">canNotCallback</param>
		/// <param name="colseFilePath">colseFilePath</param>
		public static void UpdateCustomerService(int @iD, int @projectID, string @serviceFullName, string @projectName, string @addUserName, DateTime @startTime, string @serviceArea, string @serviceNumber, string @addCustomerName, string @addCallPhone, string @serviceContent, DateTime @addTime, int @serviceStatus, DateTime @banJieTime, string @banJieNote, DateTime @serviceAppointTime, string @addMan, int @orderNumberID, string @handelFee, decimal @totalFee, string @balanceStatus, int @cKProductOutSumaryID, bool @isRequireCost, bool @isRequireProduct, bool @isAPPShow, bool @isAPPSend, DateTime @aPPSendTime, string @aPPSendResult, int @wechatServiceID, DateTime @acceptTime, int @taskType, string @serviceFrom, int @addUserID, int @sendUserID, string @sendUserName, int @banJieManUserID, string @banJieManName, bool @isUnRead, int @departmentID, bool @isSuggestion, int @publicProjectID, bool @isHighTouSu, bool @isInvalidCall, bool @isInWeiBao, bool @isClosed, int @confirmStatus, int @serviceType1ID, string @serviceType2ID, string @serviceType3ID, int @relatedServiceID, DateTime @closeTime, decimal @huiFangRate, bool @isImportantTouSu, bool @canNotCallback, string @colseFilePath)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCustomerService(@iD, @projectID, @serviceFullName, @projectName, @addUserName, @startTime, @serviceArea, @serviceNumber, @addCustomerName, @addCallPhone, @serviceContent, @addTime, @serviceStatus, @banJieTime, @banJieNote, @serviceAppointTime, @addMan, @orderNumberID, @handelFee, @totalFee, @balanceStatus, @cKProductOutSumaryID, @isRequireCost, @isRequireProduct, @isAPPShow, @isAPPSend, @aPPSendTime, @aPPSendResult, @wechatServiceID, @acceptTime, @taskType, @serviceFrom, @addUserID, @sendUserID, @sendUserName, @banJieManUserID, @banJieManName, @isUnRead, @departmentID, @isSuggestion, @publicProjectID, @isHighTouSu, @isInvalidCall, @isInWeiBao, @isClosed, @confirmStatus, @serviceType1ID, @serviceType2ID, @serviceType3ID, @relatedServiceID, @closeTime, @huiFangRate, @isImportantTouSu, @canNotCallback, @colseFilePath, helper);
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
		/// Updates a CustomerService into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="serviceFullName">serviceFullName</param>
		/// <param name="projectName">projectName</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="startTime">startTime</param>
		/// <param name="serviceArea">serviceArea</param>
		/// <param name="serviceNumber">serviceNumber</param>
		/// <param name="addCustomerName">addCustomerName</param>
		/// <param name="addCallPhone">addCallPhone</param>
		/// <param name="serviceContent">serviceContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="serviceStatus">serviceStatus</param>
		/// <param name="banJieTime">banJieTime</param>
		/// <param name="banJieNote">banJieNote</param>
		/// <param name="serviceAppointTime">serviceAppointTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="handelFee">handelFee</param>
		/// <param name="totalFee">totalFee</param>
		/// <param name="balanceStatus">balanceStatus</param>
		/// <param name="cKProductOutSumaryID">cKProductOutSumaryID</param>
		/// <param name="isRequireCost">isRequireCost</param>
		/// <param name="isRequireProduct">isRequireProduct</param>
		/// <param name="isAPPShow">isAPPShow</param>
		/// <param name="isAPPSend">isAPPSend</param>
		/// <param name="aPPSendTime">aPPSendTime</param>
		/// <param name="aPPSendResult">aPPSendResult</param>
		/// <param name="wechatServiceID">wechatServiceID</param>
		/// <param name="acceptTime">acceptTime</param>
		/// <param name="taskType">taskType</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="sendUserID">sendUserID</param>
		/// <param name="sendUserName">sendUserName</param>
		/// <param name="banJieManUserID">banJieManUserID</param>
		/// <param name="banJieManName">banJieManName</param>
		/// <param name="isUnRead">isUnRead</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="isSuggestion">isSuggestion</param>
		/// <param name="publicProjectID">publicProjectID</param>
		/// <param name="isHighTouSu">isHighTouSu</param>
		/// <param name="isInvalidCall">isInvalidCall</param>
		/// <param name="isInWeiBao">isInWeiBao</param>
		/// <param name="isClosed">isClosed</param>
		/// <param name="confirmStatus">confirmStatus</param>
		/// <param name="serviceType1ID">serviceType1ID</param>
		/// <param name="serviceType2ID">serviceType2ID</param>
		/// <param name="serviceType3ID">serviceType3ID</param>
		/// <param name="relatedServiceID">relatedServiceID</param>
		/// <param name="closeTime">closeTime</param>
		/// <param name="huiFangRate">huiFangRate</param>
		/// <param name="isImportantTouSu">isImportantTouSu</param>
		/// <param name="canNotCallback">canNotCallback</param>
		/// <param name="colseFilePath">colseFilePath</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCustomerService(int @iD, int @projectID, string @serviceFullName, string @projectName, string @addUserName, DateTime @startTime, string @serviceArea, string @serviceNumber, string @addCustomerName, string @addCallPhone, string @serviceContent, DateTime @addTime, int @serviceStatus, DateTime @banJieTime, string @banJieNote, DateTime @serviceAppointTime, string @addMan, int @orderNumberID, string @handelFee, decimal @totalFee, string @balanceStatus, int @cKProductOutSumaryID, bool @isRequireCost, bool @isRequireProduct, bool @isAPPShow, bool @isAPPSend, DateTime @aPPSendTime, string @aPPSendResult, int @wechatServiceID, DateTime @acceptTime, int @taskType, string @serviceFrom, int @addUserID, int @sendUserID, string @sendUserName, int @banJieManUserID, string @banJieManName, bool @isUnRead, int @departmentID, bool @isSuggestion, int @publicProjectID, bool @isHighTouSu, bool @isInvalidCall, bool @isInWeiBao, bool @isClosed, int @confirmStatus, int @serviceType1ID, string @serviceType2ID, string @serviceType3ID, int @relatedServiceID, DateTime @closeTime, decimal @huiFangRate, bool @isImportantTouSu, bool @canNotCallback, string @colseFilePath, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[ServiceFullName] nvarchar(500),
	[ProjectName] nvarchar(100),
	[AddUserName] nvarchar(50),
	[StartTime] datetime,
	[ServiceArea] nvarchar(50),
	[ServiceNumber] nvarchar(100),
	[AddCustomerName] nvarchar(50),
	[AddCallPhone] nvarchar(50),
	[ServiceContent] ntext,
	[AddTime] datetime,
	[ServiceStatus] int,
	[BanJieTime] datetime,
	[BanJieNote] ntext,
	[ServiceAppointTime] datetime,
	[AddMan] nvarchar(50),
	[OrderNumberID] int,
	[HandelFee] nvarchar(50),
	[TotalFee] decimal(18, 2),
	[BalanceStatus] nvarchar(50),
	[CKProductOutSumaryID] int,
	[IsRequireCost] bit,
	[IsRequireProduct] bit,
	[IsAPPShow] bit,
	[IsAPPSend] bit,
	[APPSendTime] datetime,
	[APPSendResult] ntext,
	[WechatServiceID] int,
	[AcceptTime] datetime,
	[TaskType] int,
	[ServiceFrom] nvarchar(50),
	[AddUserID] int,
	[SendUserID] int,
	[SendUserName] nvarchar(50),
	[BanJieManUserID] int,
	[BanJieManName] nvarchar(100),
	[IsUnRead] bit,
	[DepartmentID] int,
	[IsSuggestion] bit,
	[PublicProjectID] int,
	[IsHighTouSu] bit,
	[IsInvalidCall] bit,
	[IsInWeiBao] bit,
	[IsClosed] bit,
	[ConfirmStatus] int,
	[ServiceType1ID] int,
	[ServiceType2ID] nvarchar(200),
	[ServiceType3ID] nvarchar(200),
	[RelatedServiceID] int,
	[CloseTime] datetime,
	[HuiFangRate] decimal(18, 2),
	[IsImportantTouSu] bit,
	[CanNotCallback] bit,
	[ColseFilePath] nvarchar(500)
);

UPDATE [dbo].[CustomerService] SET 
	[CustomerService].[ProjectID] = @ProjectID,
	[CustomerService].[ServiceFullName] = @ServiceFullName,
	[CustomerService].[ProjectName] = @ProjectName,
	[CustomerService].[AddUserName] = @AddUserName,
	[CustomerService].[StartTime] = @StartTime,
	[CustomerService].[ServiceArea] = @ServiceArea,
	[CustomerService].[ServiceNumber] = @ServiceNumber,
	[CustomerService].[AddCustomerName] = @AddCustomerName,
	[CustomerService].[AddCallPhone] = @AddCallPhone,
	[CustomerService].[ServiceContent] = @ServiceContent,
	[CustomerService].[AddTime] = @AddTime,
	[CustomerService].[ServiceStatus] = @ServiceStatus,
	[CustomerService].[BanJieTime] = @BanJieTime,
	[CustomerService].[BanJieNote] = @BanJieNote,
	[CustomerService].[ServiceAppointTime] = @ServiceAppointTime,
	[CustomerService].[AddMan] = @AddMan,
	[CustomerService].[OrderNumberID] = @OrderNumberID,
	[CustomerService].[HandelFee] = @HandelFee,
	[CustomerService].[TotalFee] = @TotalFee,
	[CustomerService].[BalanceStatus] = @BalanceStatus,
	[CustomerService].[CKProductOutSumaryID] = @CKProductOutSumaryID,
	[CustomerService].[IsRequireCost] = @IsRequireCost,
	[CustomerService].[IsRequireProduct] = @IsRequireProduct,
	[CustomerService].[IsAPPShow] = @IsAPPShow,
	[CustomerService].[IsAPPSend] = @IsAPPSend,
	[CustomerService].[APPSendTime] = @APPSendTime,
	[CustomerService].[APPSendResult] = @APPSendResult,
	[CustomerService].[WechatServiceID] = @WechatServiceID,
	[CustomerService].[AcceptTime] = @AcceptTime,
	[CustomerService].[TaskType] = @TaskType,
	[CustomerService].[ServiceFrom] = @ServiceFrom,
	[CustomerService].[AddUserID] = @AddUserID,
	[CustomerService].[SendUserID] = @SendUserID,
	[CustomerService].[SendUserName] = @SendUserName,
	[CustomerService].[BanJieManUserID] = @BanJieManUserID,
	[CustomerService].[BanJieManName] = @BanJieManName,
	[CustomerService].[IsUnRead] = @IsUnRead,
	[CustomerService].[DepartmentID] = @DepartmentID,
	[CustomerService].[IsSuggestion] = @IsSuggestion,
	[CustomerService].[PublicProjectID] = @PublicProjectID,
	[CustomerService].[IsHighTouSu] = @IsHighTouSu,
	[CustomerService].[IsInvalidCall] = @IsInvalidCall,
	[CustomerService].[IsInWeiBao] = @IsInWeiBao,
	[CustomerService].[IsClosed] = @IsClosed,
	[CustomerService].[ConfirmStatus] = @ConfirmStatus,
	[CustomerService].[ServiceType1ID] = @ServiceType1ID,
	[CustomerService].[ServiceType2ID] = @ServiceType2ID,
	[CustomerService].[ServiceType3ID] = @ServiceType3ID,
	[CustomerService].[RelatedServiceID] = @RelatedServiceID,
	[CustomerService].[CloseTime] = @CloseTime,
	[CustomerService].[HuiFangRate] = @HuiFangRate,
	[CustomerService].[IsImportantTouSu] = @IsImportantTouSu,
	[CustomerService].[CanNotCallback] = @CanNotCallback,
	[CustomerService].[ColseFilePath] = @ColseFilePath 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[ServiceFullName],
	INSERTED.[ProjectName],
	INSERTED.[AddUserName],
	INSERTED.[StartTime],
	INSERTED.[ServiceArea],
	INSERTED.[ServiceNumber],
	INSERTED.[AddCustomerName],
	INSERTED.[AddCallPhone],
	INSERTED.[ServiceContent],
	INSERTED.[AddTime],
	INSERTED.[ServiceStatus],
	INSERTED.[BanJieTime],
	INSERTED.[BanJieNote],
	INSERTED.[ServiceAppointTime],
	INSERTED.[AddMan],
	INSERTED.[OrderNumberID],
	INSERTED.[HandelFee],
	INSERTED.[TotalFee],
	INSERTED.[BalanceStatus],
	INSERTED.[CKProductOutSumaryID],
	INSERTED.[IsRequireCost],
	INSERTED.[IsRequireProduct],
	INSERTED.[IsAPPShow],
	INSERTED.[IsAPPSend],
	INSERTED.[APPSendTime],
	INSERTED.[APPSendResult],
	INSERTED.[WechatServiceID],
	INSERTED.[AcceptTime],
	INSERTED.[TaskType],
	INSERTED.[ServiceFrom],
	INSERTED.[AddUserID],
	INSERTED.[SendUserID],
	INSERTED.[SendUserName],
	INSERTED.[BanJieManUserID],
	INSERTED.[BanJieManName],
	INSERTED.[IsUnRead],
	INSERTED.[DepartmentID],
	INSERTED.[IsSuggestion],
	INSERTED.[PublicProjectID],
	INSERTED.[IsHighTouSu],
	INSERTED.[IsInvalidCall],
	INSERTED.[IsInWeiBao],
	INSERTED.[IsClosed],
	INSERTED.[ConfirmStatus],
	INSERTED.[ServiceType1ID],
	INSERTED.[ServiceType2ID],
	INSERTED.[ServiceType3ID],
	INSERTED.[RelatedServiceID],
	INSERTED.[CloseTime],
	INSERTED.[HuiFangRate],
	INSERTED.[IsImportantTouSu],
	INSERTED.[CanNotCallback],
	INSERTED.[ColseFilePath]
into @table
WHERE 
	[CustomerService].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[ServiceFullName],
	[ProjectName],
	[AddUserName],
	[StartTime],
	[ServiceArea],
	[ServiceNumber],
	[AddCustomerName],
	[AddCallPhone],
	[ServiceContent],
	[AddTime],
	[ServiceStatus],
	[BanJieTime],
	[BanJieNote],
	[ServiceAppointTime],
	[AddMan],
	[OrderNumberID],
	[HandelFee],
	[TotalFee],
	[BalanceStatus],
	[CKProductOutSumaryID],
	[IsRequireCost],
	[IsRequireProduct],
	[IsAPPShow],
	[IsAPPSend],
	[APPSendTime],
	[APPSendResult],
	[WechatServiceID],
	[AcceptTime],
	[TaskType],
	[ServiceFrom],
	[AddUserID],
	[SendUserID],
	[SendUserName],
	[BanJieManUserID],
	[BanJieManName],
	[IsUnRead],
	[DepartmentID],
	[IsSuggestion],
	[PublicProjectID],
	[IsHighTouSu],
	[IsInvalidCall],
	[IsInWeiBao],
	[IsClosed],
	[ConfirmStatus],
	[ServiceType1ID],
	[ServiceType2ID],
	[ServiceType3ID],
	[RelatedServiceID],
	[CloseTime],
	[HuiFangRate],
	[IsImportantTouSu],
	[CanNotCallback],
	[ColseFilePath] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@ServiceFullName", EntityBase.GetDatabaseValue(@serviceFullName)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@ServiceArea", EntityBase.GetDatabaseValue(@serviceArea)));
			parameters.Add(new SqlParameter("@ServiceNumber", EntityBase.GetDatabaseValue(@serviceNumber)));
			parameters.Add(new SqlParameter("@AddCustomerName", EntityBase.GetDatabaseValue(@addCustomerName)));
			parameters.Add(new SqlParameter("@AddCallPhone", EntityBase.GetDatabaseValue(@addCallPhone)));
			parameters.Add(new SqlParameter("@ServiceContent", EntityBase.GetDatabaseValue(@serviceContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ServiceStatus", EntityBase.GetDatabaseValue(@serviceStatus)));
			parameters.Add(new SqlParameter("@BanJieTime", EntityBase.GetDatabaseValue(@banJieTime)));
			parameters.Add(new SqlParameter("@BanJieNote", EntityBase.GetDatabaseValue(@banJieNote)));
			parameters.Add(new SqlParameter("@ServiceAppointTime", EntityBase.GetDatabaseValue(@serviceAppointTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			parameters.Add(new SqlParameter("@HandelFee", EntityBase.GetDatabaseValue(@handelFee)));
			parameters.Add(new SqlParameter("@TotalFee", EntityBase.GetDatabaseValue(@totalFee)));
			parameters.Add(new SqlParameter("@BalanceStatus", EntityBase.GetDatabaseValue(@balanceStatus)));
			parameters.Add(new SqlParameter("@CKProductOutSumaryID", EntityBase.GetDatabaseValue(@cKProductOutSumaryID)));
			parameters.Add(new SqlParameter("@IsRequireCost", @isRequireCost));
			parameters.Add(new SqlParameter("@IsRequireProduct", @isRequireProduct));
			parameters.Add(new SqlParameter("@IsAPPShow", @isAPPShow));
			parameters.Add(new SqlParameter("@IsAPPSend", @isAPPSend));
			parameters.Add(new SqlParameter("@APPSendTime", EntityBase.GetDatabaseValue(@aPPSendTime)));
			parameters.Add(new SqlParameter("@APPSendResult", EntityBase.GetDatabaseValue(@aPPSendResult)));
			parameters.Add(new SqlParameter("@WechatServiceID", EntityBase.GetDatabaseValue(@wechatServiceID)));
			parameters.Add(new SqlParameter("@AcceptTime", EntityBase.GetDatabaseValue(@acceptTime)));
			parameters.Add(new SqlParameter("@TaskType", EntityBase.GetDatabaseValue(@taskType)));
			parameters.Add(new SqlParameter("@ServiceFrom", EntityBase.GetDatabaseValue(@serviceFrom)));
			parameters.Add(new SqlParameter("@AddUserID", EntityBase.GetDatabaseValue(@addUserID)));
			parameters.Add(new SqlParameter("@SendUserID", EntityBase.GetDatabaseValue(@sendUserID)));
			parameters.Add(new SqlParameter("@SendUserName", EntityBase.GetDatabaseValue(@sendUserName)));
			parameters.Add(new SqlParameter("@BanJieManUserID", EntityBase.GetDatabaseValue(@banJieManUserID)));
			parameters.Add(new SqlParameter("@BanJieManName", EntityBase.GetDatabaseValue(@banJieManName)));
			parameters.Add(new SqlParameter("@IsUnRead", @isUnRead));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@IsSuggestion", @isSuggestion));
			parameters.Add(new SqlParameter("@PublicProjectID", EntityBase.GetDatabaseValue(@publicProjectID)));
			parameters.Add(new SqlParameter("@IsHighTouSu", @isHighTouSu));
			parameters.Add(new SqlParameter("@IsInvalidCall", @isInvalidCall));
			parameters.Add(new SqlParameter("@IsInWeiBao", @isInWeiBao));
			parameters.Add(new SqlParameter("@IsClosed", @isClosed));
			parameters.Add(new SqlParameter("@ConfirmStatus", EntityBase.GetDatabaseValue(@confirmStatus)));
			parameters.Add(new SqlParameter("@ServiceType1ID", EntityBase.GetDatabaseValue(@serviceType1ID)));
			parameters.Add(new SqlParameter("@ServiceType2ID", EntityBase.GetDatabaseValue(@serviceType2ID)));
			parameters.Add(new SqlParameter("@ServiceType3ID", EntityBase.GetDatabaseValue(@serviceType3ID)));
			parameters.Add(new SqlParameter("@RelatedServiceID", EntityBase.GetDatabaseValue(@relatedServiceID)));
			parameters.Add(new SqlParameter("@CloseTime", EntityBase.GetDatabaseValue(@closeTime)));
			parameters.Add(new SqlParameter("@HuiFangRate", EntityBase.GetDatabaseValue(@huiFangRate)));
			parameters.Add(new SqlParameter("@IsImportantTouSu", @isImportantTouSu));
			parameters.Add(new SqlParameter("@CanNotCallback", @canNotCallback));
			parameters.Add(new SqlParameter("@ColseFilePath", EntityBase.GetDatabaseValue(@colseFilePath)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CustomerService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCustomerService(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCustomerService(@iD, helper);
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
		/// Deletes a CustomerService from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCustomerService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CustomerService]
WHERE 
	[CustomerService].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CustomerService object.
		/// </summary>
		/// <returns>The newly created CustomerService object.</returns>
		public static CustomerService CreateCustomerService()
		{
			return InitializeNew<CustomerService>();
		}
		
		/// <summary>
		/// Retrieve information for a CustomerService by a CustomerService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CustomerService</returns>
		public static CustomerService GetCustomerService(int @iD)
		{
			string commandText = @"
SELECT 
" + CustomerService.SelectFieldList + @"
FROM [dbo].[CustomerService] 
WHERE 
	[CustomerService].[ID] = @ID " + CustomerService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CustomerService by a CustomerService's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CustomerService</returns>
		public static CustomerService GetCustomerService(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CustomerService.SelectFieldList + @"
FROM [dbo].[CustomerService] 
WHERE 
	[CustomerService].[ID] = @ID " + CustomerService.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CustomerService objects.
		/// </summary>
		/// <returns>The retrieved collection of CustomerService objects.</returns>
		public static EntityList<CustomerService> GetCustomerServices()
		{
			string commandText = @"
SELECT " + CustomerService.SelectFieldList + "FROM [dbo].[CustomerService] " + CustomerService.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CustomerService>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CustomerService objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService objects.</returns>
        public static EntityList<CustomerService> GetCustomerServices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService>(SelectFieldList, "FROM [dbo].[CustomerService]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CustomerService objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService objects.</returns>
        public static EntityList<CustomerService> GetCustomerServices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService>(SelectFieldList, "FROM [dbo].[CustomerService]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CustomerService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService objects.</returns>
		protected static EntityList<CustomerService> GetCustomerServices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerServices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CustomerService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService objects.</returns>
		protected static EntityList<CustomerService> GetCustomerServices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerServices(string.Empty, where, parameters, CustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService objects.</returns>
		protected static EntityList<CustomerService> GetCustomerServices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerServices(prefix, where, parameters, CustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService objects.</returns>
		protected static EntityList<CustomerService> GetCustomerServices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerServices(string.Empty, where, parameters, CustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService objects.</returns>
		protected static EntityList<CustomerService> GetCustomerServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerServices(prefix, where, parameters, CustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService objects.</returns>
		protected static EntityList<CustomerService> GetCustomerServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CustomerService.SelectFieldList + "FROM [dbo].[CustomerService] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CustomerService>(reader);
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
        protected static EntityList<CustomerService> GetCustomerServices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService>(SelectFieldList, "FROM [dbo].[CustomerService] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CustomerService objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerServiceCount()
        {
            return GetCustomerServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CustomerService objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CustomerService] " + where;

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
		public static partial class CustomerService_Properties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string ServiceFullName = "ServiceFullName";
			public const string ProjectName = "ProjectName";
			public const string AddUserName = "AddUserName";
			public const string StartTime = "StartTime";
			public const string ServiceArea = "ServiceArea";
			public const string ServiceNumber = "ServiceNumber";
			public const string AddCustomerName = "AddCustomerName";
			public const string AddCallPhone = "AddCallPhone";
			public const string ServiceContent = "ServiceContent";
			public const string AddTime = "AddTime";
			public const string ServiceStatus = "ServiceStatus";
			public const string BanJieTime = "BanJieTime";
			public const string BanJieNote = "BanJieNote";
			public const string ServiceAppointTime = "ServiceAppointTime";
			public const string AddMan = "AddMan";
			public const string OrderNumberID = "OrderNumberID";
			public const string HandelFee = "HandelFee";
			public const string TotalFee = "TotalFee";
			public const string BalanceStatus = "BalanceStatus";
			public const string CKProductOutSumaryID = "CKProductOutSumaryID";
			public const string IsRequireCost = "IsRequireCost";
			public const string IsRequireProduct = "IsRequireProduct";
			public const string IsAPPShow = "IsAPPShow";
			public const string IsAPPSend = "IsAPPSend";
			public const string APPSendTime = "APPSendTime";
			public const string APPSendResult = "APPSendResult";
			public const string WechatServiceID = "WechatServiceID";
			public const string AcceptTime = "AcceptTime";
			public const string TaskType = "TaskType";
			public const string ServiceFrom = "ServiceFrom";
			public const string AddUserID = "AddUserID";
			public const string SendUserID = "SendUserID";
			public const string SendUserName = "SendUserName";
			public const string BanJieManUserID = "BanJieManUserID";
			public const string BanJieManName = "BanJieManName";
			public const string IsUnRead = "IsUnRead";
			public const string DepartmentID = "DepartmentID";
			public const string IsSuggestion = "IsSuggestion";
			public const string PublicProjectID = "PublicProjectID";
			public const string IsHighTouSu = "IsHighTouSu";
			public const string IsInvalidCall = "IsInvalidCall";
			public const string IsInWeiBao = "IsInWeiBao";
			public const string IsClosed = "IsClosed";
			public const string ConfirmStatus = "ConfirmStatus";
			public const string ServiceType1ID = "ServiceType1ID";
			public const string ServiceType2ID = "ServiceType2ID";
			public const string ServiceType3ID = "ServiceType3ID";
			public const string RelatedServiceID = "RelatedServiceID";
			public const string CloseTime = "CloseTime";
			public const string HuiFangRate = "HuiFangRate";
			public const string IsImportantTouSu = "IsImportantTouSu";
			public const string CanNotCallback = "CanNotCallback";
			public const string ColseFilePath = "ColseFilePath";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"ServiceFullName" , "string:"},
    			 {"ProjectName" , "string:"},
    			 {"AddUserName" , "string:"},
    			 {"StartTime" , "DateTime:"},
    			 {"ServiceArea" , "string:"},
    			 {"ServiceNumber" , "string:"},
    			 {"AddCustomerName" , "string:"},
    			 {"AddCallPhone" , "string:"},
    			 {"ServiceContent" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ServiceStatus" , "int:0-处理中 1-已办结 2-已销单 3-待处理 10-待接单"},
    			 {"BanJieTime" , "DateTime:"},
    			 {"BanJieNote" , "string:"},
    			 {"ServiceAppointTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"OrderNumberID" , "int:"},
    			 {"HandelFee" , "string:"},
    			 {"TotalFee" , "decimal:"},
    			 {"BalanceStatus" , "string:"},
    			 {"CKProductOutSumaryID" , "int:"},
    			 {"IsRequireCost" , "bool:"},
    			 {"IsRequireProduct" , "bool:"},
    			 {"IsAPPShow" , "bool:"},
    			 {"IsAPPSend" , "bool:"},
    			 {"APPSendTime" , "DateTime:"},
    			 {"APPSendResult" , "string:"},
    			 {"WechatServiceID" , "int:"},
    			 {"AcceptTime" , "DateTime:"},
    			 {"TaskType" , "int:"},
    			 {"ServiceFrom" , "string:"},
    			 {"AddUserID" , "int:"},
    			 {"SendUserID" , "int:"},
    			 {"SendUserName" , "string:"},
    			 {"BanJieManUserID" , "int:"},
    			 {"BanJieManName" , "string:"},
    			 {"IsUnRead" , "bool:"},
    			 {"DepartmentID" , "int:"},
    			 {"IsSuggestion" , "bool:"},
    			 {"PublicProjectID" , "int:"},
    			 {"IsHighTouSu" , "bool:"},
    			 {"IsInvalidCall" , "bool:"},
    			 {"IsInWeiBao" , "bool:"},
    			 {"IsClosed" , "bool:"},
    			 {"ConfirmStatus" , "int:"},
    			 {"ServiceType1ID" , "int:"},
    			 {"ServiceType2ID" , "string:"},
    			 {"ServiceType3ID" , "string:"},
    			 {"RelatedServiceID" , "int:"},
    			 {"CloseTime" , "DateTime:"},
    			 {"HuiFangRate" , "decimal:"},
    			 {"IsImportantTouSu" , "bool:"},
    			 {"CanNotCallback" , "bool:"},
    			 {"ColseFilePath" , "string:"},
            };
		}
		#endregion
	}
}
