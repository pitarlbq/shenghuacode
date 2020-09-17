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
	/// This object represents the properties and methods of a ViewCustomerService.
	/// </summary>
	[Serializable()]
	public partial class ViewCustomerService 
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
            protected set { this._serviceFullName = value;}
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
            protected set { this._projectName = value;}
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
            protected set { this._addUserName = value;}
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
            protected set { this._startTime = value;}
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
            protected set { this._serviceArea = value;}
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
            protected set { this._addCustomerName = value;}
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
            protected set { this._addCallPhone = value;}
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
            protected set { this._serviceContent = value;}
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
		private int _serviceStatus = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServiceStatus
		{
			[DebuggerStepThrough()]
			get { return this._serviceStatus; }
            protected set { this._serviceStatus = value;}
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
            protected set { this._banJieTime = value;}
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
            protected set { this._banJieNote = value;}
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
            protected set { this._serviceAppointTime = value;}
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
            protected set { this._orderNumberID = value;}
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
            protected set { this._isRequireCost = value;}
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
            protected set { this._isRequireProduct = value;}
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
            protected set { this._isAPPShow = value;}
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
            protected set { this._isAPPSend = value;}
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
            protected set { this._aPPSendTime = value;}
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
            protected set { this._aPPSendResult = value;}
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
            protected set { this._wechatServiceID = value;}
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
            protected set { this._acceptTime = value;}
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
            protected set { this._taskType = value;}
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
            protected set { this._serviceFrom = value;}
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
            protected set { this._departmentID = value;}
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
            protected set { this._isSuggestion = value;}
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
            protected set { this._publicProjectID = value;}
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
            protected set { this._addUserID = value;}
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
            protected set { this._sendUserID = value;}
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
            protected set { this._sendUserName = value;}
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
            protected set { this._banJieManUserID = value;}
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
            protected set { this._banJieManName = value;}
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
            protected set { this._isUnRead = value;}
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
            protected set { this._isInvalidCall = value;}
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
            protected set { this._isInWeiBao = value;}
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
            protected set { this._isHighTouSu = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _project_Name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Project_Name
		{
			[DebuggerStepThrough()]
			get { return this._project_Name; }
            protected set { this._project_Name = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FullName
		{
			[DebuggerStepThrough()]
			get { return this._fullName; }
            protected set { this._fullName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buildingNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuildingNumber
		{
			[DebuggerStepThrough()]
			get { return this._buildingNumber; }
            protected set { this._buildingNumber = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomType
		{
			[DebuggerStepThrough()]
			get { return this._roomType; }
            protected set { this._roomType = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _isJingZhuangXiu = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int IsJingZhuangXiu
		{
			[DebuggerStepThrough()]
			get { return this._isJingZhuangXiu; }
            protected set { this._isJingZhuangXiu = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taskName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaskName
		{
			[DebuggerStepThrough()]
			get { return this._taskName; }
            protected set { this._taskName = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _departmentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DepartmentName
		{
			[DebuggerStepThrough()]
			get { return this._departmentName; }
            protected set { this._departmentName = value;}
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
            protected set { this._isClosed = value;}
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
            protected set { this._serviceType1ID = value;}
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
            protected set { this._serviceType2ID = value;}
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
            protected set { this._serviceType3ID = value;}
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
            protected set { this._confirmStatus = value;}
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
            protected set { this._relatedServiceID = value;}
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
            protected set { this._closeTime = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _companyName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CompanyName
		{
			[DebuggerStepThrough()]
			get { return this._companyName; }
            protected set { this._companyName = value;}
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
            protected set { this._huiFangRate = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CompanyID
		{
			[DebuggerStepThrough()]
			get { return this._companyID; }
            protected set { this._companyID = value;}
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
            protected set { this._isImportantTouSu = value;}
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
            protected set { this._canNotCallback = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectDelayHour = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectDelayHour
		{
			[DebuggerStepThrough()]
			get { return this._projectDelayHour; }
            protected set { this._projectDelayHour = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isTimeOutInvalid = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsTimeOutInvalid
		{
			[DebuggerStepThrough()]
			get { return this._isTimeOutInvalid; }
            protected set { this._isTimeOutInvalid = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewCustomerService() { }
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
	[ViewCustomerService].[ID],
	[ViewCustomerService].[ProjectID],
	[ViewCustomerService].[ServiceFullName],
	[ViewCustomerService].[ProjectName],
	[ViewCustomerService].[AddUserName],
	[ViewCustomerService].[StartTime],
	[ViewCustomerService].[ServiceArea],
	[ViewCustomerService].[ServiceNumber],
	[ViewCustomerService].[AddCustomerName],
	[ViewCustomerService].[AddCallPhone],
	[ViewCustomerService].[ServiceContent],
	[ViewCustomerService].[AddTime],
	[ViewCustomerService].[ServiceStatus],
	[ViewCustomerService].[BanJieTime],
	[ViewCustomerService].[BanJieNote],
	[ViewCustomerService].[ServiceAppointTime],
	[ViewCustomerService].[AddMan],
	[ViewCustomerService].[OrderNumberID],
	[ViewCustomerService].[HandelFee],
	[ViewCustomerService].[TotalFee],
	[ViewCustomerService].[BalanceStatus],
	[ViewCustomerService].[CKProductOutSumaryID],
	[ViewCustomerService].[IsRequireCost],
	[ViewCustomerService].[IsRequireProduct],
	[ViewCustomerService].[IsAPPShow],
	[ViewCustomerService].[IsAPPSend],
	[ViewCustomerService].[APPSendTime],
	[ViewCustomerService].[APPSendResult],
	[ViewCustomerService].[WechatServiceID],
	[ViewCustomerService].[AcceptTime],
	[ViewCustomerService].[TaskType],
	[ViewCustomerService].[ServiceFrom],
	[ViewCustomerService].[DepartmentID],
	[ViewCustomerService].[IsSuggestion],
	[ViewCustomerService].[PublicProjectID],
	[ViewCustomerService].[AddUserID],
	[ViewCustomerService].[SendUserID],
	[ViewCustomerService].[SendUserName],
	[ViewCustomerService].[BanJieManUserID],
	[ViewCustomerService].[BanJieManName],
	[ViewCustomerService].[IsUnRead],
	[ViewCustomerService].[IsInvalidCall],
	[ViewCustomerService].[IsInWeiBao],
	[ViewCustomerService].[IsHighTouSu],
	[ViewCustomerService].[Project_Name],
	[ViewCustomerService].[FullName],
	[ViewCustomerService].[BuildingNumber],
	[ViewCustomerService].[RoomType],
	[ViewCustomerService].[IsJingZhuangXiu],
	[ViewCustomerService].[TaskName],
	[ViewCustomerService].[DepartmentName],
	[ViewCustomerService].[IsClosed],
	[ViewCustomerService].[ServiceType1ID],
	[ViewCustomerService].[ServiceType2ID],
	[ViewCustomerService].[ServiceType3ID],
	[ViewCustomerService].[ConfirmStatus],
	[ViewCustomerService].[RelatedServiceID],
	[ViewCustomerService].[CloseTime],
	[ViewCustomerService].[CompanyName],
	[ViewCustomerService].[HuiFangRate],
	[ViewCustomerService].[CompanyID],
	[ViewCustomerService].[IsImportantTouSu],
	[ViewCustomerService].[CanNotCallback],
	[ViewCustomerService].[ProjectDelayHour],
	[ViewCustomerService].[IsTimeOutInvalid]
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
                return "ViewCustomerService";
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
		/// Gets a collection ViewCustomerService objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		public static EntityList<ViewCustomerService> GetViewCustomerServices()
		{
			string commandText = @"
SELECT " + ViewCustomerService.SelectFieldList + "FROM [dbo].[ViewCustomerService] " + ViewCustomerService.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewCustomerService>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewCustomerService objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCustomerService objects.</returns>
        public static EntityList<ViewCustomerService> GetViewCustomerServices(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCustomerService>(SelectFieldList, "FROM [dbo].[ViewCustomerService]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewCustomerService objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewCustomerService objects.</returns>
        public static EntityList<ViewCustomerService> GetViewCustomerServices(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCustomerService>(SelectFieldList, "FROM [dbo].[ViewCustomerService]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewCustomerService objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCustomerServiceCount()
        {
            return GetViewCustomerServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewCustomerService objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewCustomerServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewCustomerService] " + where;

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
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCustomerServices(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCustomerServices(string.Empty, where, parameters, ViewCustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewCustomerServices(prefix, where, parameters, ViewCustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCustomerServices(string.Empty, where, parameters, ViewCustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewCustomerServices(prefix, where, parameters, ViewCustomerService.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewCustomerService objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewCustomerService objects.</returns>
		protected static EntityList<ViewCustomerService> GetViewCustomerServices(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewCustomerService.SelectFieldList + "FROM [dbo].[ViewCustomerService] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewCustomerService>(reader);
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
        protected static EntityList<ViewCustomerService> GetViewCustomerServices(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewCustomerService>(SelectFieldList, "FROM [dbo].[ViewCustomerService] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewCustomerServiceProperties
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
			public const string DepartmentID = "DepartmentID";
			public const string IsSuggestion = "IsSuggestion";
			public const string PublicProjectID = "PublicProjectID";
			public const string AddUserID = "AddUserID";
			public const string SendUserID = "SendUserID";
			public const string SendUserName = "SendUserName";
			public const string BanJieManUserID = "BanJieManUserID";
			public const string BanJieManName = "BanJieManName";
			public const string IsUnRead = "IsUnRead";
			public const string IsInvalidCall = "IsInvalidCall";
			public const string IsInWeiBao = "IsInWeiBao";
			public const string IsHighTouSu = "IsHighTouSu";
			public const string Project_Name = "Project_Name";
			public const string FullName = "FullName";
			public const string BuildingNumber = "BuildingNumber";
			public const string RoomType = "RoomType";
			public const string IsJingZhuangXiu = "IsJingZhuangXiu";
			public const string TaskName = "TaskName";
			public const string DepartmentName = "DepartmentName";
			public const string IsClosed = "IsClosed";
			public const string ServiceType1ID = "ServiceType1ID";
			public const string ServiceType2ID = "ServiceType2ID";
			public const string ServiceType3ID = "ServiceType3ID";
			public const string ConfirmStatus = "ConfirmStatus";
			public const string RelatedServiceID = "RelatedServiceID";
			public const string CloseTime = "CloseTime";
			public const string CompanyName = "CompanyName";
			public const string HuiFangRate = "HuiFangRate";
			public const string CompanyID = "CompanyID";
			public const string IsImportantTouSu = "IsImportantTouSu";
			public const string CanNotCallback = "CanNotCallback";
			public const string ProjectDelayHour = "ProjectDelayHour";
			public const string IsTimeOutInvalid = "IsTimeOutInvalid";
            
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
    			 {"ServiceStatus" , "int:"},
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
    			 {"DepartmentID" , "int:"},
    			 {"IsSuggestion" , "bool:"},
    			 {"PublicProjectID" , "int:"},
    			 {"AddUserID" , "int:"},
    			 {"SendUserID" , "int:"},
    			 {"SendUserName" , "string:"},
    			 {"BanJieManUserID" , "int:"},
    			 {"BanJieManName" , "string:"},
    			 {"IsUnRead" , "bool:"},
    			 {"IsInvalidCall" , "bool:"},
    			 {"IsInWeiBao" , "bool:"},
    			 {"IsHighTouSu" , "bool:"},
    			 {"Project_Name" , "string:"},
    			 {"FullName" , "string:"},
    			 {"BuildingNumber" , "string:"},
    			 {"RoomType" , "string:"},
    			 {"IsJingZhuangXiu" , "int:"},
    			 {"TaskName" , "string:"},
    			 {"DepartmentName" , "string:"},
    			 {"IsClosed" , "bool:"},
    			 {"ServiceType1ID" , "int:"},
    			 {"ServiceType2ID" , "string:"},
    			 {"ServiceType3ID" , "string:"},
    			 {"ConfirmStatus" , "int:"},
    			 {"RelatedServiceID" , "int:"},
    			 {"CloseTime" , "DateTime:"},
    			 {"CompanyName" , "string:"},
    			 {"HuiFangRate" , "decimal:"},
    			 {"CompanyID" , "int:"},
    			 {"IsImportantTouSu" , "bool:"},
    			 {"CanNotCallback" , "bool:"},
    			 {"ProjectDelayHour" , "int:"},
    			 {"IsTimeOutInvalid" , "bool:"},
            };
		}
		#endregion
	}
}
