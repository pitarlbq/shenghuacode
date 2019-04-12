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
	/// This object represents the properties and methods of a Company.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("CompanyID: {CompanyID}")]
	public partial class Company 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public int CompanyID
		{
			[DebuggerStepThrough()]
			get { return this._companyID; }
			 set 
			{
				if (this._companyID != value) 
				{
					this._companyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyID");
				}
			}
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
			set 
			{
				if (this._companyName != value) 
				{
					this._companyName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _companyDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CompanyDesc
		{
			[DebuggerStepThrough()]
			get { return this._companyDesc; }
			set 
			{
				if (this._companyDesc != value) 
				{
					this._companyDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyDesc");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _phoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._phoneNumber; }
			set 
			{
				if (this._phoneNumber != value) 
				{
					this._phoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PhoneNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _address = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Address
		{
			[DebuggerStepThrough()]
			get { return this._address; }
			set 
			{
				if (this._address != value) 
				{
					this._address = value;
					this.IsDirty = true;	
					OnPropertyChanged("Address");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargePerson = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargePerson
		{
			[DebuggerStepThrough()]
			get { return this._chargePerson; }
			set 
			{
				if (this._chargePerson != value) 
				{
					this._chargePerson = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargePerson");
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
		private bool _isActive = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private string _baseURL = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BaseURL
		{
			[DebuggerStepThrough()]
			get { return this._baseURL; }
			set 
			{
				if (this._baseURL != value) 
				{
					this._baseURL = value;
					this.IsDirty = true;	
					OnPropertyChanged("BaseURL");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int UserCount
		{
			[DebuggerStepThrough()]
			get { return this._userCount; }
			set 
			{
				if (this._userCount != value) 
				{
					this._userCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _distributor = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Distributor
		{
			[DebuggerStepThrough()]
			get { return this._distributor; }
			set 
			{
				if (this._distributor != value) 
				{
					this._distributor = value;
					this.IsDirty = true;	
					OnPropertyChanged("Distributor");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _serverStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ServerStartTime
		{
			[DebuggerStepThrough()]
			get { return this._serverStartTime; }
			set 
			{
				if (this._serverStartTime != value) 
				{
					this._serverStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServerStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _serverEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ServerEndTime
		{
			[DebuggerStepThrough()]
			get { return this._serverEndTime; }
			set 
			{
				if (this._serverEndTime != value) 
				{
					this._serverEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServerEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPay = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPay
		{
			[DebuggerStepThrough()]
			get { return this._isPay; }
			set 
			{
				if (this._isPay != value) 
				{
					this._isPay = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPay");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAdmin = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAdmin
		{
			[DebuggerStepThrough()]
			get { return this._isAdmin; }
			set 
			{
				if (this._isAdmin != value) 
				{
					this._isAdmin = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAdmin");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isCustomer = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsCustomer
		{
			[DebuggerStepThrough()]
			get { return this._isCustomer; }
			set 
			{
				if (this._isCustomer != value) 
				{
					this._isCustomer = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsCustomer");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _serverLocation = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ServerLocation
		{
			[DebuggerStepThrough()]
			get { return this._serverLocation; }
			set 
			{
				if (this._serverLocation != value) 
				{
					this._serverLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServerLocation");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _localURL = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string LocalURL
		{
			[DebuggerStepThrough()]
			get { return this._localURL; }
			set 
			{
				if (this._localURL != value) 
				{
					this._localURL = value;
					this.IsDirty = true;	
					OnPropertyChanged("LocalURL");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _login_LogImg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Login_LogImg
		{
			[DebuggerStepThrough()]
			get { return this._login_LogImg; }
			set 
			{
				if (this._login_LogImg != value) 
				{
					this._login_LogImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("Login_LogImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _login_BodyImg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Login_BodyImg
		{
			[DebuggerStepThrough()]
			get { return this._login_BodyImg; }
			set 
			{
				if (this._login_BodyImg != value) 
				{
					this._login_BodyImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("Login_BodyImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _home_LogoImg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Home_LogoImg
		{
			[DebuggerStepThrough()]
			get { return this._home_LogoImg; }
			set 
			{
				if (this._home_LogoImg != value) 
				{
					this._home_LogoImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("Home_LogoImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _versionCode = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VersionCode
		{
			[DebuggerStepThrough()]
			get { return this._versionCode; }
			set 
			{
				if (this._versionCode != value) 
				{
					this._versionCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("VersionCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectCount
		{
			[DebuggerStepThrough()]
			get { return this._projectCount; }
			set 
			{
				if (this._projectCount != value) 
				{
					this._projectCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _fromCompanyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FromCompanyID
		{
			[DebuggerStepThrough()]
			get { return this._fromCompanyID; }
			set 
			{
				if (this._fromCompanyID != value) 
				{
					this._fromCompanyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("FromCompanyID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideLogin_LogImg = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideLogin_LogImg
		{
			[DebuggerStepThrough()]
			get { return this._isHideLogin_LogImg; }
			set 
			{
				if (this._isHideLogin_LogImg != value) 
				{
					this._isHideLogin_LogImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideLogin_LogImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideLogin_BodyImg = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideLogin_BodyImg
		{
			[DebuggerStepThrough()]
			get { return this._isHideLogin_BodyImg; }
			set 
			{
				if (this._isHideLogin_BodyImg != value) 
				{
					this._isHideLogin_BodyImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideLogin_BodyImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideHome_LogoImg = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideHome_LogoImg
		{
			[DebuggerStepThrough()]
			get { return this._isHideHome_LogoImg; }
			set 
			{
				if (this._isHideHome_LogoImg != value) 
				{
					this._isHideHome_LogoImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideHome_LogoImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _copyRightText = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CopyRightText
		{
			[DebuggerStepThrough()]
			get { return this._copyRightText; }
			set 
			{
				if (this._copyRightText != value) 
				{
					this._copyRightText = value;
					this.IsDirty = true;	
					OnPropertyChanged("CopyRightText");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHideCopyRightText = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHideCopyRightText
		{
			[DebuggerStepThrough()]
			get { return this._isHideCopyRightText; }
			set 
			{
				if (this._isHideCopyRightText != value) 
				{
					this._isHideCopyRightText = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHideCopyRightText");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _alowRemoteUpdate = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool AlowRemoteUpdate
		{
			[DebuggerStepThrough()]
			get { return this._alowRemoteUpdate; }
			set 
			{
				if (this._alowRemoteUpdate != value) 
				{
					this._alowRemoteUpdate = value;
					this.IsDirty = true;	
					OnPropertyChanged("AlowRemoteUpdate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isWechatOn = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsWechatOn
		{
			[DebuggerStepThrough()]
			get { return this._isWechatOn; }
			set 
			{
				if (this._isWechatOn != value) 
				{
					this._isWechatOn = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsWechatOn");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isMallOn = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsMallOn
		{
			[DebuggerStepThrough()]
			get { return this._isMallOn; }
			set 
			{
				if (this._isMallOn != value) 
				{
					this._isMallOn = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsMallOn");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _expiringMsg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ExpiringMsg
		{
			[DebuggerStepThrough()]
			get { return this._expiringMsg; }
			set 
			{
				if (this._expiringMsg != value) 
				{
					this._expiringMsg = value;
					this.IsDirty = true;	
					OnPropertyChanged("ExpiringMsg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _expiringDay = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ExpiringDay
		{
			[DebuggerStepThrough()]
			get { return this._expiringDay; }
			set 
			{
				if (this._expiringDay != value) 
				{
					this._expiringDay = value;
					this.IsDirty = true;	
					OnPropertyChanged("ExpiringDay");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _expiringShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool ExpiringShow
		{
			[DebuggerStepThrough()]
			get { return this._expiringShow; }
			set 
			{
				if (this._expiringShow != value) 
				{
					this._expiringShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("ExpiringShow");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _virName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string VirName
		{
			[DebuggerStepThrough()]
			get { return this._virName; }
			set 
			{
				if (this._virName != value) 
				{
					this._virName = value;
					this.IsDirty = true;	
					OnPropertyChanged("VirName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _signature = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Signature
		{
			[DebuggerStepThrough()]
			get { return this._signature; }
			set 
			{
				if (this._signature != value) 
				{
					this._signature = value;
					this.IsDirty = true;	
					OnPropertyChanged("Signature");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _token = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Token
		{
			[DebuggerStepThrough()]
			get { return this._token; }
			set 
			{
				if (this._token != value) 
				{
					this._token = value;
					this.IsDirty = true;	
					OnPropertyChanged("Token");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _systemNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SystemNo
		{
			[DebuggerStepThrough()]
			get { return this._systemNo; }
			set 
			{
				if (this._systemNo != value) 
				{
					this._systemNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("SystemNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chequeTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChequeTitle
		{
			[DebuggerStepThrough()]
			get { return this._chequeTitle; }
			set 
			{
				if (this._chequeTitle != value) 
				{
					this._chequeTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChequeTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _taxpayerNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TaxpayerNumber
		{
			[DebuggerStepThrough()]
			get { return this._taxpayerNumber; }
			set 
			{
				if (this._taxpayerNumber != value) 
				{
					this._taxpayerNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("TaxpayerNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _bankAccountName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BankAccountName
		{
			[DebuggerStepThrough()]
			get { return this._bankAccountName; }
			set 
			{
				if (this._bankAccountName != value) 
				{
					this._bankAccountName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BankAccountName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _bankAccountNo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BankAccountNo
		{
			[DebuggerStepThrough()]
			get { return this._bankAccountNo; }
			set 
			{
				if (this._bankAccountNo != value) 
				{
					this._bankAccountNo = value;
					this.IsDirty = true;	
					OnPropertyChanged("BankAccountNo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _bankName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BankName
		{
			[DebuggerStepThrough()]
			get { return this._bankName; }
			set 
			{
				if (this._bankName != value) 
				{
					this._bankName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BankName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _reCheckUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ReCheckUserName
		{
			[DebuggerStepThrough()]
			get { return this._reCheckUserName; }
			set 
			{
				if (this._reCheckUserName != value) 
				{
					this._reCheckUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReCheckUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal _cheque_SL = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal Cheque_SL
		{
			[DebuggerStepThrough()]
			get { return this._cheque_SL; }
			set 
			{
				if (this._cheque_SL != value) 
				{
					this._cheque_SL = value;
					this.IsDirty = true;	
					OnPropertyChanged("Cheque_SL");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _cheque_FLBM = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Cheque_FLBM
		{
			[DebuggerStepThrough()]
			get { return this._cheque_FLBM; }
			set 
			{
				if (this._cheque_FLBM != value) 
				{
					this._cheque_FLBM = value;
					this.IsDirty = true;	
					OnPropertyChanged("Cheque_FLBM");
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
	[CompanyID] int,
	[CompanyName] nvarchar(50),
	[CompanyDesc] ntext,
	[PhoneNumber] nvarchar(20),
	[Address] nvarchar(100),
	[ChargePerson] nvarchar(50),
	[AddTime] datetime,
	[IsActive] bit,
	[BaseURL] nvarchar(2000),
	[UserCount] int,
	[Distributor] nvarchar(500),
	[ServerStartTime] datetime,
	[ServerEndTime] datetime,
	[IsPay] bit,
	[IsAdmin] bit,
	[IsCustomer] bit,
	[ServerLocation] int,
	[LocalURL] nvarchar(500),
	[Login_LogImg] nvarchar(500),
	[Login_BodyImg] nvarchar(500),
	[Home_LogoImg] nvarchar(500),
	[VersionCode] int,
	[ProjectCount] int,
	[FromCompanyID] int,
	[IsHideLogin_LogImg] bit,
	[IsHideLogin_BodyImg] bit,
	[IsHideHome_LogoImg] bit,
	[CopyRightText] nvarchar(200),
	[IsHideCopyRightText] bit,
	[AlowRemoteUpdate] bit,
	[IsWechatOn] bit,
	[IsMallOn] bit,
	[ExpiringMsg] nvarchar(200),
	[ExpiringDay] int,
	[ExpiringShow] bit,
	[VirName] nvarchar(200),
	[Signature] nvarchar(200),
	[Token] nvarchar(100),
	[SystemNo] nvarchar(50),
	[ChequeTitle] nvarchar(200),
	[TaxpayerNumber] nvarchar(200),
	[BankAccountName] nvarchar(200),
	[BankAccountNo] nvarchar(200),
	[BankName] nvarchar(200),
	[ReCheckUserName] nvarchar(200),
	[Cheque_SL] decimal(18, 2),
	[Cheque_FLBM] nvarchar(200)
);

INSERT INTO [dbo].[Company] (
	[Company].[CompanyName],
	[Company].[CompanyDesc],
	[Company].[PhoneNumber],
	[Company].[Address],
	[Company].[ChargePerson],
	[Company].[AddTime],
	[Company].[IsActive],
	[Company].[BaseURL],
	[Company].[UserCount],
	[Company].[Distributor],
	[Company].[ServerStartTime],
	[Company].[ServerEndTime],
	[Company].[IsPay],
	[Company].[IsAdmin],
	[Company].[IsCustomer],
	[Company].[ServerLocation],
	[Company].[LocalURL],
	[Company].[Login_LogImg],
	[Company].[Login_BodyImg],
	[Company].[Home_LogoImg],
	[Company].[VersionCode],
	[Company].[ProjectCount],
	[Company].[FromCompanyID],
	[Company].[IsHideLogin_LogImg],
	[Company].[IsHideLogin_BodyImg],
	[Company].[IsHideHome_LogoImg],
	[Company].[CopyRightText],
	[Company].[IsHideCopyRightText],
	[Company].[AlowRemoteUpdate],
	[Company].[IsWechatOn],
	[Company].[IsMallOn],
	[Company].[ExpiringMsg],
	[Company].[ExpiringDay],
	[Company].[ExpiringShow],
	[Company].[VirName],
	[Company].[Signature],
	[Company].[Token],
	[Company].[SystemNo],
	[Company].[ChequeTitle],
	[Company].[TaxpayerNumber],
	[Company].[BankAccountName],
	[Company].[BankAccountNo],
	[Company].[BankName],
	[Company].[ReCheckUserName],
	[Company].[Cheque_SL],
	[Company].[Cheque_FLBM]
) 
output 
	INSERTED.[CompanyID],
	INSERTED.[CompanyName],
	INSERTED.[CompanyDesc],
	INSERTED.[PhoneNumber],
	INSERTED.[Address],
	INSERTED.[ChargePerson],
	INSERTED.[AddTime],
	INSERTED.[IsActive],
	INSERTED.[BaseURL],
	INSERTED.[UserCount],
	INSERTED.[Distributor],
	INSERTED.[ServerStartTime],
	INSERTED.[ServerEndTime],
	INSERTED.[IsPay],
	INSERTED.[IsAdmin],
	INSERTED.[IsCustomer],
	INSERTED.[ServerLocation],
	INSERTED.[LocalURL],
	INSERTED.[Login_LogImg],
	INSERTED.[Login_BodyImg],
	INSERTED.[Home_LogoImg],
	INSERTED.[VersionCode],
	INSERTED.[ProjectCount],
	INSERTED.[FromCompanyID],
	INSERTED.[IsHideLogin_LogImg],
	INSERTED.[IsHideLogin_BodyImg],
	INSERTED.[IsHideHome_LogoImg],
	INSERTED.[CopyRightText],
	INSERTED.[IsHideCopyRightText],
	INSERTED.[AlowRemoteUpdate],
	INSERTED.[IsWechatOn],
	INSERTED.[IsMallOn],
	INSERTED.[ExpiringMsg],
	INSERTED.[ExpiringDay],
	INSERTED.[ExpiringShow],
	INSERTED.[VirName],
	INSERTED.[Signature],
	INSERTED.[Token],
	INSERTED.[SystemNo],
	INSERTED.[ChequeTitle],
	INSERTED.[TaxpayerNumber],
	INSERTED.[BankAccountName],
	INSERTED.[BankAccountNo],
	INSERTED.[BankName],
	INSERTED.[ReCheckUserName],
	INSERTED.[Cheque_SL],
	INSERTED.[Cheque_FLBM]
into @table
VALUES ( 
	@CompanyName,
	@CompanyDesc,
	@PhoneNumber,
	@Address,
	@ChargePerson,
	@AddTime,
	@IsActive,
	@BaseURL,
	@UserCount,
	@Distributor,
	@ServerStartTime,
	@ServerEndTime,
	@IsPay,
	@IsAdmin,
	@IsCustomer,
	@ServerLocation,
	@LocalURL,
	@Login_LogImg,
	@Login_BodyImg,
	@Home_LogoImg,
	@VersionCode,
	@ProjectCount,
	@FromCompanyID,
	@IsHideLogin_LogImg,
	@IsHideLogin_BodyImg,
	@IsHideHome_LogoImg,
	@CopyRightText,
	@IsHideCopyRightText,
	@AlowRemoteUpdate,
	@IsWechatOn,
	@IsMallOn,
	@ExpiringMsg,
	@ExpiringDay,
	@ExpiringShow,
	@VirName,
	@Signature,
	@Token,
	@SystemNo,
	@ChequeTitle,
	@TaxpayerNumber,
	@BankAccountName,
	@BankAccountNo,
	@BankName,
	@ReCheckUserName,
	@Cheque_SL,
	@Cheque_FLBM 
); 

SELECT 
	[CompanyID],
	[CompanyName],
	[CompanyDesc],
	[PhoneNumber],
	[Address],
	[ChargePerson],
	[AddTime],
	[IsActive],
	[BaseURL],
	[UserCount],
	[Distributor],
	[ServerStartTime],
	[ServerEndTime],
	[IsPay],
	[IsAdmin],
	[IsCustomer],
	[ServerLocation],
	[LocalURL],
	[Login_LogImg],
	[Login_BodyImg],
	[Home_LogoImg],
	[VersionCode],
	[ProjectCount],
	[FromCompanyID],
	[IsHideLogin_LogImg],
	[IsHideLogin_BodyImg],
	[IsHideHome_LogoImg],
	[CopyRightText],
	[IsHideCopyRightText],
	[AlowRemoteUpdate],
	[IsWechatOn],
	[IsMallOn],
	[ExpiringMsg],
	[ExpiringDay],
	[ExpiringShow],
	[VirName],
	[Signature],
	[Token],
	[SystemNo],
	[ChequeTitle],
	[TaxpayerNumber],
	[BankAccountName],
	[BankAccountNo],
	[BankName],
	[ReCheckUserName],
	[Cheque_SL],
	[Cheque_FLBM] 
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
	[CompanyID] int,
	[CompanyName] nvarchar(50),
	[CompanyDesc] ntext,
	[PhoneNumber] nvarchar(20),
	[Address] nvarchar(100),
	[ChargePerson] nvarchar(50),
	[AddTime] datetime,
	[IsActive] bit,
	[BaseURL] nvarchar(2000),
	[UserCount] int,
	[Distributor] nvarchar(500),
	[ServerStartTime] datetime,
	[ServerEndTime] datetime,
	[IsPay] bit,
	[IsAdmin] bit,
	[IsCustomer] bit,
	[ServerLocation] int,
	[LocalURL] nvarchar(500),
	[Login_LogImg] nvarchar(500),
	[Login_BodyImg] nvarchar(500),
	[Home_LogoImg] nvarchar(500),
	[VersionCode] int,
	[ProjectCount] int,
	[FromCompanyID] int,
	[IsHideLogin_LogImg] bit,
	[IsHideLogin_BodyImg] bit,
	[IsHideHome_LogoImg] bit,
	[CopyRightText] nvarchar(200),
	[IsHideCopyRightText] bit,
	[AlowRemoteUpdate] bit,
	[IsWechatOn] bit,
	[IsMallOn] bit,
	[ExpiringMsg] nvarchar(200),
	[ExpiringDay] int,
	[ExpiringShow] bit,
	[VirName] nvarchar(200),
	[Signature] nvarchar(200),
	[Token] nvarchar(100),
	[SystemNo] nvarchar(50),
	[ChequeTitle] nvarchar(200),
	[TaxpayerNumber] nvarchar(200),
	[BankAccountName] nvarchar(200),
	[BankAccountNo] nvarchar(200),
	[BankName] nvarchar(200),
	[ReCheckUserName] nvarchar(200),
	[Cheque_SL] decimal(18, 2),
	[Cheque_FLBM] nvarchar(200)
);

UPDATE [dbo].[Company] SET 
	[Company].[CompanyName] = @CompanyName,
	[Company].[CompanyDesc] = @CompanyDesc,
	[Company].[PhoneNumber] = @PhoneNumber,
	[Company].[Address] = @Address,
	[Company].[ChargePerson] = @ChargePerson,
	[Company].[AddTime] = @AddTime,
	[Company].[IsActive] = @IsActive,
	[Company].[BaseURL] = @BaseURL,
	[Company].[UserCount] = @UserCount,
	[Company].[Distributor] = @Distributor,
	[Company].[ServerStartTime] = @ServerStartTime,
	[Company].[ServerEndTime] = @ServerEndTime,
	[Company].[IsPay] = @IsPay,
	[Company].[IsAdmin] = @IsAdmin,
	[Company].[IsCustomer] = @IsCustomer,
	[Company].[ServerLocation] = @ServerLocation,
	[Company].[LocalURL] = @LocalURL,
	[Company].[Login_LogImg] = @Login_LogImg,
	[Company].[Login_BodyImg] = @Login_BodyImg,
	[Company].[Home_LogoImg] = @Home_LogoImg,
	[Company].[VersionCode] = @VersionCode,
	[Company].[ProjectCount] = @ProjectCount,
	[Company].[FromCompanyID] = @FromCompanyID,
	[Company].[IsHideLogin_LogImg] = @IsHideLogin_LogImg,
	[Company].[IsHideLogin_BodyImg] = @IsHideLogin_BodyImg,
	[Company].[IsHideHome_LogoImg] = @IsHideHome_LogoImg,
	[Company].[CopyRightText] = @CopyRightText,
	[Company].[IsHideCopyRightText] = @IsHideCopyRightText,
	[Company].[AlowRemoteUpdate] = @AlowRemoteUpdate,
	[Company].[IsWechatOn] = @IsWechatOn,
	[Company].[IsMallOn] = @IsMallOn,
	[Company].[ExpiringMsg] = @ExpiringMsg,
	[Company].[ExpiringDay] = @ExpiringDay,
	[Company].[ExpiringShow] = @ExpiringShow,
	[Company].[VirName] = @VirName,
	[Company].[Signature] = @Signature,
	[Company].[Token] = @Token,
	[Company].[SystemNo] = @SystemNo,
	[Company].[ChequeTitle] = @ChequeTitle,
	[Company].[TaxpayerNumber] = @TaxpayerNumber,
	[Company].[BankAccountName] = @BankAccountName,
	[Company].[BankAccountNo] = @BankAccountNo,
	[Company].[BankName] = @BankName,
	[Company].[ReCheckUserName] = @ReCheckUserName,
	[Company].[Cheque_SL] = @Cheque_SL,
	[Company].[Cheque_FLBM] = @Cheque_FLBM 
output 
	INSERTED.[CompanyID],
	INSERTED.[CompanyName],
	INSERTED.[CompanyDesc],
	INSERTED.[PhoneNumber],
	INSERTED.[Address],
	INSERTED.[ChargePerson],
	INSERTED.[AddTime],
	INSERTED.[IsActive],
	INSERTED.[BaseURL],
	INSERTED.[UserCount],
	INSERTED.[Distributor],
	INSERTED.[ServerStartTime],
	INSERTED.[ServerEndTime],
	INSERTED.[IsPay],
	INSERTED.[IsAdmin],
	INSERTED.[IsCustomer],
	INSERTED.[ServerLocation],
	INSERTED.[LocalURL],
	INSERTED.[Login_LogImg],
	INSERTED.[Login_BodyImg],
	INSERTED.[Home_LogoImg],
	INSERTED.[VersionCode],
	INSERTED.[ProjectCount],
	INSERTED.[FromCompanyID],
	INSERTED.[IsHideLogin_LogImg],
	INSERTED.[IsHideLogin_BodyImg],
	INSERTED.[IsHideHome_LogoImg],
	INSERTED.[CopyRightText],
	INSERTED.[IsHideCopyRightText],
	INSERTED.[AlowRemoteUpdate],
	INSERTED.[IsWechatOn],
	INSERTED.[IsMallOn],
	INSERTED.[ExpiringMsg],
	INSERTED.[ExpiringDay],
	INSERTED.[ExpiringShow],
	INSERTED.[VirName],
	INSERTED.[Signature],
	INSERTED.[Token],
	INSERTED.[SystemNo],
	INSERTED.[ChequeTitle],
	INSERTED.[TaxpayerNumber],
	INSERTED.[BankAccountName],
	INSERTED.[BankAccountNo],
	INSERTED.[BankName],
	INSERTED.[ReCheckUserName],
	INSERTED.[Cheque_SL],
	INSERTED.[Cheque_FLBM]
into @table
WHERE 
	[Company].[CompanyID] = @CompanyID

SELECT 
	[CompanyID],
	[CompanyName],
	[CompanyDesc],
	[PhoneNumber],
	[Address],
	[ChargePerson],
	[AddTime],
	[IsActive],
	[BaseURL],
	[UserCount],
	[Distributor],
	[ServerStartTime],
	[ServerEndTime],
	[IsPay],
	[IsAdmin],
	[IsCustomer],
	[ServerLocation],
	[LocalURL],
	[Login_LogImg],
	[Login_BodyImg],
	[Home_LogoImg],
	[VersionCode],
	[ProjectCount],
	[FromCompanyID],
	[IsHideLogin_LogImg],
	[IsHideLogin_BodyImg],
	[IsHideHome_LogoImg],
	[CopyRightText],
	[IsHideCopyRightText],
	[AlowRemoteUpdate],
	[IsWechatOn],
	[IsMallOn],
	[ExpiringMsg],
	[ExpiringDay],
	[ExpiringShow],
	[VirName],
	[Signature],
	[Token],
	[SystemNo],
	[ChequeTitle],
	[TaxpayerNumber],
	[BankAccountName],
	[BankAccountNo],
	[BankName],
	[ReCheckUserName],
	[Cheque_SL],
	[Cheque_FLBM] 
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
DELETE FROM [dbo].[Company]
WHERE 
	[Company].[CompanyID] = @CompanyID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Company() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCompany(this.CompanyID));
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
	[Company].[CompanyID],
	[Company].[CompanyName],
	[Company].[CompanyDesc],
	[Company].[PhoneNumber],
	[Company].[Address],
	[Company].[ChargePerson],
	[Company].[AddTime],
	[Company].[IsActive],
	[Company].[BaseURL],
	[Company].[UserCount],
	[Company].[Distributor],
	[Company].[ServerStartTime],
	[Company].[ServerEndTime],
	[Company].[IsPay],
	[Company].[IsAdmin],
	[Company].[IsCustomer],
	[Company].[ServerLocation],
	[Company].[LocalURL],
	[Company].[Login_LogImg],
	[Company].[Login_BodyImg],
	[Company].[Home_LogoImg],
	[Company].[VersionCode],
	[Company].[ProjectCount],
	[Company].[FromCompanyID],
	[Company].[IsHideLogin_LogImg],
	[Company].[IsHideLogin_BodyImg],
	[Company].[IsHideHome_LogoImg],
	[Company].[CopyRightText],
	[Company].[IsHideCopyRightText],
	[Company].[AlowRemoteUpdate],
	[Company].[IsWechatOn],
	[Company].[IsMallOn],
	[Company].[ExpiringMsg],
	[Company].[ExpiringDay],
	[Company].[ExpiringShow],
	[Company].[VirName],
	[Company].[Signature],
	[Company].[Token],
	[Company].[SystemNo],
	[Company].[ChequeTitle],
	[Company].[TaxpayerNumber],
	[Company].[BankAccountName],
	[Company].[BankAccountNo],
	[Company].[BankName],
	[Company].[ReCheckUserName],
	[Company].[Cheque_SL],
	[Company].[Cheque_FLBM]
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
                return "Company";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Company into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyName">companyName</param>
		/// <param name="companyDesc">companyDesc</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="address">address</param>
		/// <param name="chargePerson">chargePerson</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="baseURL">baseURL</param>
		/// <param name="userCount">userCount</param>
		/// <param name="distributor">distributor</param>
		/// <param name="serverStartTime">serverStartTime</param>
		/// <param name="serverEndTime">serverEndTime</param>
		/// <param name="isPay">isPay</param>
		/// <param name="isAdmin">isAdmin</param>
		/// <param name="isCustomer">isCustomer</param>
		/// <param name="serverLocation">serverLocation</param>
		/// <param name="localURL">localURL</param>
		/// <param name="login_LogImg">login_LogImg</param>
		/// <param name="login_BodyImg">login_BodyImg</param>
		/// <param name="home_LogoImg">home_LogoImg</param>
		/// <param name="versionCode">versionCode</param>
		/// <param name="projectCount">projectCount</param>
		/// <param name="fromCompanyID">fromCompanyID</param>
		/// <param name="isHideLogin_LogImg">isHideLogin_LogImg</param>
		/// <param name="isHideLogin_BodyImg">isHideLogin_BodyImg</param>
		/// <param name="isHideHome_LogoImg">isHideHome_LogoImg</param>
		/// <param name="copyRightText">copyRightText</param>
		/// <param name="isHideCopyRightText">isHideCopyRightText</param>
		/// <param name="alowRemoteUpdate">alowRemoteUpdate</param>
		/// <param name="isWechatOn">isWechatOn</param>
		/// <param name="isMallOn">isMallOn</param>
		/// <param name="expiringMsg">expiringMsg</param>
		/// <param name="expiringDay">expiringDay</param>
		/// <param name="expiringShow">expiringShow</param>
		/// <param name="virName">virName</param>
		/// <param name="signature">signature</param>
		/// <param name="token">token</param>
		/// <param name="systemNo">systemNo</param>
		/// <param name="chequeTitle">chequeTitle</param>
		/// <param name="taxpayerNumber">taxpayerNumber</param>
		/// <param name="bankAccountName">bankAccountName</param>
		/// <param name="bankAccountNo">bankAccountNo</param>
		/// <param name="bankName">bankName</param>
		/// <param name="reCheckUserName">reCheckUserName</param>
		/// <param name="cheque_SL">cheque_SL</param>
		/// <param name="cheque_FLBM">cheque_FLBM</param>
		public static void InsertCompany(string @companyName, string @companyDesc, string @phoneNumber, string @address, string @chargePerson, DateTime @addTime, bool @isActive, string @baseURL, int @userCount, string @distributor, DateTime @serverStartTime, DateTime @serverEndTime, bool @isPay, bool @isAdmin, bool @isCustomer, int @serverLocation, string @localURL, string @login_LogImg, string @login_BodyImg, string @home_LogoImg, int @versionCode, int @projectCount, int @fromCompanyID, bool @isHideLogin_LogImg, bool @isHideLogin_BodyImg, bool @isHideHome_LogoImg, string @copyRightText, bool @isHideCopyRightText, bool @alowRemoteUpdate, bool @isWechatOn, bool @isMallOn, string @expiringMsg, int @expiringDay, bool @expiringShow, string @virName, string @signature, string @token, string @systemNo, string @chequeTitle, string @taxpayerNumber, string @bankAccountName, string @bankAccountNo, string @bankName, string @reCheckUserName, decimal @cheque_SL, string @cheque_FLBM)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCompany(@companyName, @companyDesc, @phoneNumber, @address, @chargePerson, @addTime, @isActive, @baseURL, @userCount, @distributor, @serverStartTime, @serverEndTime, @isPay, @isAdmin, @isCustomer, @serverLocation, @localURL, @login_LogImg, @login_BodyImg, @home_LogoImg, @versionCode, @projectCount, @fromCompanyID, @isHideLogin_LogImg, @isHideLogin_BodyImg, @isHideHome_LogoImg, @copyRightText, @isHideCopyRightText, @alowRemoteUpdate, @isWechatOn, @isMallOn, @expiringMsg, @expiringDay, @expiringShow, @virName, @signature, @token, @systemNo, @chequeTitle, @taxpayerNumber, @bankAccountName, @bankAccountNo, @bankName, @reCheckUserName, @cheque_SL, @cheque_FLBM, helper);
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
		/// Insert a Company into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyName">companyName</param>
		/// <param name="companyDesc">companyDesc</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="address">address</param>
		/// <param name="chargePerson">chargePerson</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="baseURL">baseURL</param>
		/// <param name="userCount">userCount</param>
		/// <param name="distributor">distributor</param>
		/// <param name="serverStartTime">serverStartTime</param>
		/// <param name="serverEndTime">serverEndTime</param>
		/// <param name="isPay">isPay</param>
		/// <param name="isAdmin">isAdmin</param>
		/// <param name="isCustomer">isCustomer</param>
		/// <param name="serverLocation">serverLocation</param>
		/// <param name="localURL">localURL</param>
		/// <param name="login_LogImg">login_LogImg</param>
		/// <param name="login_BodyImg">login_BodyImg</param>
		/// <param name="home_LogoImg">home_LogoImg</param>
		/// <param name="versionCode">versionCode</param>
		/// <param name="projectCount">projectCount</param>
		/// <param name="fromCompanyID">fromCompanyID</param>
		/// <param name="isHideLogin_LogImg">isHideLogin_LogImg</param>
		/// <param name="isHideLogin_BodyImg">isHideLogin_BodyImg</param>
		/// <param name="isHideHome_LogoImg">isHideHome_LogoImg</param>
		/// <param name="copyRightText">copyRightText</param>
		/// <param name="isHideCopyRightText">isHideCopyRightText</param>
		/// <param name="alowRemoteUpdate">alowRemoteUpdate</param>
		/// <param name="isWechatOn">isWechatOn</param>
		/// <param name="isMallOn">isMallOn</param>
		/// <param name="expiringMsg">expiringMsg</param>
		/// <param name="expiringDay">expiringDay</param>
		/// <param name="expiringShow">expiringShow</param>
		/// <param name="virName">virName</param>
		/// <param name="signature">signature</param>
		/// <param name="token">token</param>
		/// <param name="systemNo">systemNo</param>
		/// <param name="chequeTitle">chequeTitle</param>
		/// <param name="taxpayerNumber">taxpayerNumber</param>
		/// <param name="bankAccountName">bankAccountName</param>
		/// <param name="bankAccountNo">bankAccountNo</param>
		/// <param name="bankName">bankName</param>
		/// <param name="reCheckUserName">reCheckUserName</param>
		/// <param name="cheque_SL">cheque_SL</param>
		/// <param name="cheque_FLBM">cheque_FLBM</param>
		/// <param name="helper">helper</param>
		internal static void InsertCompany(string @companyName, string @companyDesc, string @phoneNumber, string @address, string @chargePerson, DateTime @addTime, bool @isActive, string @baseURL, int @userCount, string @distributor, DateTime @serverStartTime, DateTime @serverEndTime, bool @isPay, bool @isAdmin, bool @isCustomer, int @serverLocation, string @localURL, string @login_LogImg, string @login_BodyImg, string @home_LogoImg, int @versionCode, int @projectCount, int @fromCompanyID, bool @isHideLogin_LogImg, bool @isHideLogin_BodyImg, bool @isHideHome_LogoImg, string @copyRightText, bool @isHideCopyRightText, bool @alowRemoteUpdate, bool @isWechatOn, bool @isMallOn, string @expiringMsg, int @expiringDay, bool @expiringShow, string @virName, string @signature, string @token, string @systemNo, string @chequeTitle, string @taxpayerNumber, string @bankAccountName, string @bankAccountNo, string @bankName, string @reCheckUserName, decimal @cheque_SL, string @cheque_FLBM, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[CompanyID] int,
	[CompanyName] nvarchar(50),
	[CompanyDesc] ntext,
	[PhoneNumber] nvarchar(20),
	[Address] nvarchar(100),
	[ChargePerson] nvarchar(50),
	[AddTime] datetime,
	[IsActive] bit,
	[BaseURL] nvarchar(2000),
	[UserCount] int,
	[Distributor] nvarchar(500),
	[ServerStartTime] datetime,
	[ServerEndTime] datetime,
	[IsPay] bit,
	[IsAdmin] bit,
	[IsCustomer] bit,
	[ServerLocation] int,
	[LocalURL] nvarchar(500),
	[Login_LogImg] nvarchar(500),
	[Login_BodyImg] nvarchar(500),
	[Home_LogoImg] nvarchar(500),
	[VersionCode] int,
	[ProjectCount] int,
	[FromCompanyID] int,
	[IsHideLogin_LogImg] bit,
	[IsHideLogin_BodyImg] bit,
	[IsHideHome_LogoImg] bit,
	[CopyRightText] nvarchar(200),
	[IsHideCopyRightText] bit,
	[AlowRemoteUpdate] bit,
	[IsWechatOn] bit,
	[IsMallOn] bit,
	[ExpiringMsg] nvarchar(200),
	[ExpiringDay] int,
	[ExpiringShow] bit,
	[VirName] nvarchar(200),
	[Signature] nvarchar(200),
	[Token] nvarchar(100),
	[SystemNo] nvarchar(50),
	[ChequeTitle] nvarchar(200),
	[TaxpayerNumber] nvarchar(200),
	[BankAccountName] nvarchar(200),
	[BankAccountNo] nvarchar(200),
	[BankName] nvarchar(200),
	[ReCheckUserName] nvarchar(200),
	[Cheque_SL] decimal(18, 2),
	[Cheque_FLBM] nvarchar(200)
);

INSERT INTO [dbo].[Company] (
	[Company].[CompanyName],
	[Company].[CompanyDesc],
	[Company].[PhoneNumber],
	[Company].[Address],
	[Company].[ChargePerson],
	[Company].[AddTime],
	[Company].[IsActive],
	[Company].[BaseURL],
	[Company].[UserCount],
	[Company].[Distributor],
	[Company].[ServerStartTime],
	[Company].[ServerEndTime],
	[Company].[IsPay],
	[Company].[IsAdmin],
	[Company].[IsCustomer],
	[Company].[ServerLocation],
	[Company].[LocalURL],
	[Company].[Login_LogImg],
	[Company].[Login_BodyImg],
	[Company].[Home_LogoImg],
	[Company].[VersionCode],
	[Company].[ProjectCount],
	[Company].[FromCompanyID],
	[Company].[IsHideLogin_LogImg],
	[Company].[IsHideLogin_BodyImg],
	[Company].[IsHideHome_LogoImg],
	[Company].[CopyRightText],
	[Company].[IsHideCopyRightText],
	[Company].[AlowRemoteUpdate],
	[Company].[IsWechatOn],
	[Company].[IsMallOn],
	[Company].[ExpiringMsg],
	[Company].[ExpiringDay],
	[Company].[ExpiringShow],
	[Company].[VirName],
	[Company].[Signature],
	[Company].[Token],
	[Company].[SystemNo],
	[Company].[ChequeTitle],
	[Company].[TaxpayerNumber],
	[Company].[BankAccountName],
	[Company].[BankAccountNo],
	[Company].[BankName],
	[Company].[ReCheckUserName],
	[Company].[Cheque_SL],
	[Company].[Cheque_FLBM]
) 
output 
	INSERTED.[CompanyID],
	INSERTED.[CompanyName],
	INSERTED.[CompanyDesc],
	INSERTED.[PhoneNumber],
	INSERTED.[Address],
	INSERTED.[ChargePerson],
	INSERTED.[AddTime],
	INSERTED.[IsActive],
	INSERTED.[BaseURL],
	INSERTED.[UserCount],
	INSERTED.[Distributor],
	INSERTED.[ServerStartTime],
	INSERTED.[ServerEndTime],
	INSERTED.[IsPay],
	INSERTED.[IsAdmin],
	INSERTED.[IsCustomer],
	INSERTED.[ServerLocation],
	INSERTED.[LocalURL],
	INSERTED.[Login_LogImg],
	INSERTED.[Login_BodyImg],
	INSERTED.[Home_LogoImg],
	INSERTED.[VersionCode],
	INSERTED.[ProjectCount],
	INSERTED.[FromCompanyID],
	INSERTED.[IsHideLogin_LogImg],
	INSERTED.[IsHideLogin_BodyImg],
	INSERTED.[IsHideHome_LogoImg],
	INSERTED.[CopyRightText],
	INSERTED.[IsHideCopyRightText],
	INSERTED.[AlowRemoteUpdate],
	INSERTED.[IsWechatOn],
	INSERTED.[IsMallOn],
	INSERTED.[ExpiringMsg],
	INSERTED.[ExpiringDay],
	INSERTED.[ExpiringShow],
	INSERTED.[VirName],
	INSERTED.[Signature],
	INSERTED.[Token],
	INSERTED.[SystemNo],
	INSERTED.[ChequeTitle],
	INSERTED.[TaxpayerNumber],
	INSERTED.[BankAccountName],
	INSERTED.[BankAccountNo],
	INSERTED.[BankName],
	INSERTED.[ReCheckUserName],
	INSERTED.[Cheque_SL],
	INSERTED.[Cheque_FLBM]
into @table
VALUES ( 
	@CompanyName,
	@CompanyDesc,
	@PhoneNumber,
	@Address,
	@ChargePerson,
	@AddTime,
	@IsActive,
	@BaseURL,
	@UserCount,
	@Distributor,
	@ServerStartTime,
	@ServerEndTime,
	@IsPay,
	@IsAdmin,
	@IsCustomer,
	@ServerLocation,
	@LocalURL,
	@Login_LogImg,
	@Login_BodyImg,
	@Home_LogoImg,
	@VersionCode,
	@ProjectCount,
	@FromCompanyID,
	@IsHideLogin_LogImg,
	@IsHideLogin_BodyImg,
	@IsHideHome_LogoImg,
	@CopyRightText,
	@IsHideCopyRightText,
	@AlowRemoteUpdate,
	@IsWechatOn,
	@IsMallOn,
	@ExpiringMsg,
	@ExpiringDay,
	@ExpiringShow,
	@VirName,
	@Signature,
	@Token,
	@SystemNo,
	@ChequeTitle,
	@TaxpayerNumber,
	@BankAccountName,
	@BankAccountNo,
	@BankName,
	@ReCheckUserName,
	@Cheque_SL,
	@Cheque_FLBM 
); 

SELECT 
	[CompanyID],
	[CompanyName],
	[CompanyDesc],
	[PhoneNumber],
	[Address],
	[ChargePerson],
	[AddTime],
	[IsActive],
	[BaseURL],
	[UserCount],
	[Distributor],
	[ServerStartTime],
	[ServerEndTime],
	[IsPay],
	[IsAdmin],
	[IsCustomer],
	[ServerLocation],
	[LocalURL],
	[Login_LogImg],
	[Login_BodyImg],
	[Home_LogoImg],
	[VersionCode],
	[ProjectCount],
	[FromCompanyID],
	[IsHideLogin_LogImg],
	[IsHideLogin_BodyImg],
	[IsHideHome_LogoImg],
	[CopyRightText],
	[IsHideCopyRightText],
	[AlowRemoteUpdate],
	[IsWechatOn],
	[IsMallOn],
	[ExpiringMsg],
	[ExpiringDay],
	[ExpiringShow],
	[VirName],
	[Signature],
	[Token],
	[SystemNo],
	[ChequeTitle],
	[TaxpayerNumber],
	[BankAccountName],
	[BankAccountNo],
	[BankName],
	[ReCheckUserName],
	[Cheque_SL],
	[Cheque_FLBM] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyName", EntityBase.GetDatabaseValue(@companyName)));
			parameters.Add(new SqlParameter("@CompanyDesc", EntityBase.GetDatabaseValue(@companyDesc)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@Address", EntityBase.GetDatabaseValue(@address)));
			parameters.Add(new SqlParameter("@ChargePerson", EntityBase.GetDatabaseValue(@chargePerson)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@BaseURL", EntityBase.GetDatabaseValue(@baseURL)));
			parameters.Add(new SqlParameter("@UserCount", EntityBase.GetDatabaseValue(@userCount)));
			parameters.Add(new SqlParameter("@Distributor", EntityBase.GetDatabaseValue(@distributor)));
			parameters.Add(new SqlParameter("@ServerStartTime", EntityBase.GetDatabaseValue(@serverStartTime)));
			parameters.Add(new SqlParameter("@ServerEndTime", EntityBase.GetDatabaseValue(@serverEndTime)));
			parameters.Add(new SqlParameter("@IsPay", @isPay));
			parameters.Add(new SqlParameter("@IsAdmin", @isAdmin));
			parameters.Add(new SqlParameter("@IsCustomer", @isCustomer));
			parameters.Add(new SqlParameter("@ServerLocation", EntityBase.GetDatabaseValue(@serverLocation)));
			parameters.Add(new SqlParameter("@LocalURL", EntityBase.GetDatabaseValue(@localURL)));
			parameters.Add(new SqlParameter("@Login_LogImg", EntityBase.GetDatabaseValue(@login_LogImg)));
			parameters.Add(new SqlParameter("@Login_BodyImg", EntityBase.GetDatabaseValue(@login_BodyImg)));
			parameters.Add(new SqlParameter("@Home_LogoImg", EntityBase.GetDatabaseValue(@home_LogoImg)));
			parameters.Add(new SqlParameter("@VersionCode", EntityBase.GetDatabaseValue(@versionCode)));
			parameters.Add(new SqlParameter("@ProjectCount", EntityBase.GetDatabaseValue(@projectCount)));
			parameters.Add(new SqlParameter("@FromCompanyID", EntityBase.GetDatabaseValue(@fromCompanyID)));
			parameters.Add(new SqlParameter("@IsHideLogin_LogImg", @isHideLogin_LogImg));
			parameters.Add(new SqlParameter("@IsHideLogin_BodyImg", @isHideLogin_BodyImg));
			parameters.Add(new SqlParameter("@IsHideHome_LogoImg", @isHideHome_LogoImg));
			parameters.Add(new SqlParameter("@CopyRightText", EntityBase.GetDatabaseValue(@copyRightText)));
			parameters.Add(new SqlParameter("@IsHideCopyRightText", @isHideCopyRightText));
			parameters.Add(new SqlParameter("@AlowRemoteUpdate", @alowRemoteUpdate));
			parameters.Add(new SqlParameter("@IsWechatOn", @isWechatOn));
			parameters.Add(new SqlParameter("@IsMallOn", @isMallOn));
			parameters.Add(new SqlParameter("@ExpiringMsg", EntityBase.GetDatabaseValue(@expiringMsg)));
			parameters.Add(new SqlParameter("@ExpiringDay", EntityBase.GetDatabaseValue(@expiringDay)));
			parameters.Add(new SqlParameter("@ExpiringShow", @expiringShow));
			parameters.Add(new SqlParameter("@VirName", EntityBase.GetDatabaseValue(@virName)));
			parameters.Add(new SqlParameter("@Signature", EntityBase.GetDatabaseValue(@signature)));
			parameters.Add(new SqlParameter("@Token", EntityBase.GetDatabaseValue(@token)));
			parameters.Add(new SqlParameter("@SystemNo", EntityBase.GetDatabaseValue(@systemNo)));
			parameters.Add(new SqlParameter("@ChequeTitle", EntityBase.GetDatabaseValue(@chequeTitle)));
			parameters.Add(new SqlParameter("@TaxpayerNumber", EntityBase.GetDatabaseValue(@taxpayerNumber)));
			parameters.Add(new SqlParameter("@BankAccountName", EntityBase.GetDatabaseValue(@bankAccountName)));
			parameters.Add(new SqlParameter("@BankAccountNo", EntityBase.GetDatabaseValue(@bankAccountNo)));
			parameters.Add(new SqlParameter("@BankName", EntityBase.GetDatabaseValue(@bankName)));
			parameters.Add(new SqlParameter("@ReCheckUserName", EntityBase.GetDatabaseValue(@reCheckUserName)));
			parameters.Add(new SqlParameter("@Cheque_SL", EntityBase.GetDatabaseValue(@cheque_SL)));
			parameters.Add(new SqlParameter("@Cheque_FLBM", EntityBase.GetDatabaseValue(@cheque_FLBM)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Company into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="companyName">companyName</param>
		/// <param name="companyDesc">companyDesc</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="address">address</param>
		/// <param name="chargePerson">chargePerson</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="baseURL">baseURL</param>
		/// <param name="userCount">userCount</param>
		/// <param name="distributor">distributor</param>
		/// <param name="serverStartTime">serverStartTime</param>
		/// <param name="serverEndTime">serverEndTime</param>
		/// <param name="isPay">isPay</param>
		/// <param name="isAdmin">isAdmin</param>
		/// <param name="isCustomer">isCustomer</param>
		/// <param name="serverLocation">serverLocation</param>
		/// <param name="localURL">localURL</param>
		/// <param name="login_LogImg">login_LogImg</param>
		/// <param name="login_BodyImg">login_BodyImg</param>
		/// <param name="home_LogoImg">home_LogoImg</param>
		/// <param name="versionCode">versionCode</param>
		/// <param name="projectCount">projectCount</param>
		/// <param name="fromCompanyID">fromCompanyID</param>
		/// <param name="isHideLogin_LogImg">isHideLogin_LogImg</param>
		/// <param name="isHideLogin_BodyImg">isHideLogin_BodyImg</param>
		/// <param name="isHideHome_LogoImg">isHideHome_LogoImg</param>
		/// <param name="copyRightText">copyRightText</param>
		/// <param name="isHideCopyRightText">isHideCopyRightText</param>
		/// <param name="alowRemoteUpdate">alowRemoteUpdate</param>
		/// <param name="isWechatOn">isWechatOn</param>
		/// <param name="isMallOn">isMallOn</param>
		/// <param name="expiringMsg">expiringMsg</param>
		/// <param name="expiringDay">expiringDay</param>
		/// <param name="expiringShow">expiringShow</param>
		/// <param name="virName">virName</param>
		/// <param name="signature">signature</param>
		/// <param name="token">token</param>
		/// <param name="systemNo">systemNo</param>
		/// <param name="chequeTitle">chequeTitle</param>
		/// <param name="taxpayerNumber">taxpayerNumber</param>
		/// <param name="bankAccountName">bankAccountName</param>
		/// <param name="bankAccountNo">bankAccountNo</param>
		/// <param name="bankName">bankName</param>
		/// <param name="reCheckUserName">reCheckUserName</param>
		/// <param name="cheque_SL">cheque_SL</param>
		/// <param name="cheque_FLBM">cheque_FLBM</param>
		public static void UpdateCompany(int @companyID, string @companyName, string @companyDesc, string @phoneNumber, string @address, string @chargePerson, DateTime @addTime, bool @isActive, string @baseURL, int @userCount, string @distributor, DateTime @serverStartTime, DateTime @serverEndTime, bool @isPay, bool @isAdmin, bool @isCustomer, int @serverLocation, string @localURL, string @login_LogImg, string @login_BodyImg, string @home_LogoImg, int @versionCode, int @projectCount, int @fromCompanyID, bool @isHideLogin_LogImg, bool @isHideLogin_BodyImg, bool @isHideHome_LogoImg, string @copyRightText, bool @isHideCopyRightText, bool @alowRemoteUpdate, bool @isWechatOn, bool @isMallOn, string @expiringMsg, int @expiringDay, bool @expiringShow, string @virName, string @signature, string @token, string @systemNo, string @chequeTitle, string @taxpayerNumber, string @bankAccountName, string @bankAccountNo, string @bankName, string @reCheckUserName, decimal @cheque_SL, string @cheque_FLBM)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCompany(@companyID, @companyName, @companyDesc, @phoneNumber, @address, @chargePerson, @addTime, @isActive, @baseURL, @userCount, @distributor, @serverStartTime, @serverEndTime, @isPay, @isAdmin, @isCustomer, @serverLocation, @localURL, @login_LogImg, @login_BodyImg, @home_LogoImg, @versionCode, @projectCount, @fromCompanyID, @isHideLogin_LogImg, @isHideLogin_BodyImg, @isHideHome_LogoImg, @copyRightText, @isHideCopyRightText, @alowRemoteUpdate, @isWechatOn, @isMallOn, @expiringMsg, @expiringDay, @expiringShow, @virName, @signature, @token, @systemNo, @chequeTitle, @taxpayerNumber, @bankAccountName, @bankAccountNo, @bankName, @reCheckUserName, @cheque_SL, @cheque_FLBM, helper);
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
		/// Updates a Company into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="companyName">companyName</param>
		/// <param name="companyDesc">companyDesc</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="address">address</param>
		/// <param name="chargePerson">chargePerson</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="baseURL">baseURL</param>
		/// <param name="userCount">userCount</param>
		/// <param name="distributor">distributor</param>
		/// <param name="serverStartTime">serverStartTime</param>
		/// <param name="serverEndTime">serverEndTime</param>
		/// <param name="isPay">isPay</param>
		/// <param name="isAdmin">isAdmin</param>
		/// <param name="isCustomer">isCustomer</param>
		/// <param name="serverLocation">serverLocation</param>
		/// <param name="localURL">localURL</param>
		/// <param name="login_LogImg">login_LogImg</param>
		/// <param name="login_BodyImg">login_BodyImg</param>
		/// <param name="home_LogoImg">home_LogoImg</param>
		/// <param name="versionCode">versionCode</param>
		/// <param name="projectCount">projectCount</param>
		/// <param name="fromCompanyID">fromCompanyID</param>
		/// <param name="isHideLogin_LogImg">isHideLogin_LogImg</param>
		/// <param name="isHideLogin_BodyImg">isHideLogin_BodyImg</param>
		/// <param name="isHideHome_LogoImg">isHideHome_LogoImg</param>
		/// <param name="copyRightText">copyRightText</param>
		/// <param name="isHideCopyRightText">isHideCopyRightText</param>
		/// <param name="alowRemoteUpdate">alowRemoteUpdate</param>
		/// <param name="isWechatOn">isWechatOn</param>
		/// <param name="isMallOn">isMallOn</param>
		/// <param name="expiringMsg">expiringMsg</param>
		/// <param name="expiringDay">expiringDay</param>
		/// <param name="expiringShow">expiringShow</param>
		/// <param name="virName">virName</param>
		/// <param name="signature">signature</param>
		/// <param name="token">token</param>
		/// <param name="systemNo">systemNo</param>
		/// <param name="chequeTitle">chequeTitle</param>
		/// <param name="taxpayerNumber">taxpayerNumber</param>
		/// <param name="bankAccountName">bankAccountName</param>
		/// <param name="bankAccountNo">bankAccountNo</param>
		/// <param name="bankName">bankName</param>
		/// <param name="reCheckUserName">reCheckUserName</param>
		/// <param name="cheque_SL">cheque_SL</param>
		/// <param name="cheque_FLBM">cheque_FLBM</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCompany(int @companyID, string @companyName, string @companyDesc, string @phoneNumber, string @address, string @chargePerson, DateTime @addTime, bool @isActive, string @baseURL, int @userCount, string @distributor, DateTime @serverStartTime, DateTime @serverEndTime, bool @isPay, bool @isAdmin, bool @isCustomer, int @serverLocation, string @localURL, string @login_LogImg, string @login_BodyImg, string @home_LogoImg, int @versionCode, int @projectCount, int @fromCompanyID, bool @isHideLogin_LogImg, bool @isHideLogin_BodyImg, bool @isHideHome_LogoImg, string @copyRightText, bool @isHideCopyRightText, bool @alowRemoteUpdate, bool @isWechatOn, bool @isMallOn, string @expiringMsg, int @expiringDay, bool @expiringShow, string @virName, string @signature, string @token, string @systemNo, string @chequeTitle, string @taxpayerNumber, string @bankAccountName, string @bankAccountNo, string @bankName, string @reCheckUserName, decimal @cheque_SL, string @cheque_FLBM, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[CompanyID] int,
	[CompanyName] nvarchar(50),
	[CompanyDesc] ntext,
	[PhoneNumber] nvarchar(20),
	[Address] nvarchar(100),
	[ChargePerson] nvarchar(50),
	[AddTime] datetime,
	[IsActive] bit,
	[BaseURL] nvarchar(2000),
	[UserCount] int,
	[Distributor] nvarchar(500),
	[ServerStartTime] datetime,
	[ServerEndTime] datetime,
	[IsPay] bit,
	[IsAdmin] bit,
	[IsCustomer] bit,
	[ServerLocation] int,
	[LocalURL] nvarchar(500),
	[Login_LogImg] nvarchar(500),
	[Login_BodyImg] nvarchar(500),
	[Home_LogoImg] nvarchar(500),
	[VersionCode] int,
	[ProjectCount] int,
	[FromCompanyID] int,
	[IsHideLogin_LogImg] bit,
	[IsHideLogin_BodyImg] bit,
	[IsHideHome_LogoImg] bit,
	[CopyRightText] nvarchar(200),
	[IsHideCopyRightText] bit,
	[AlowRemoteUpdate] bit,
	[IsWechatOn] bit,
	[IsMallOn] bit,
	[ExpiringMsg] nvarchar(200),
	[ExpiringDay] int,
	[ExpiringShow] bit,
	[VirName] nvarchar(200),
	[Signature] nvarchar(200),
	[Token] nvarchar(100),
	[SystemNo] nvarchar(50),
	[ChequeTitle] nvarchar(200),
	[TaxpayerNumber] nvarchar(200),
	[BankAccountName] nvarchar(200),
	[BankAccountNo] nvarchar(200),
	[BankName] nvarchar(200),
	[ReCheckUserName] nvarchar(200),
	[Cheque_SL] decimal(18, 2),
	[Cheque_FLBM] nvarchar(200)
);

UPDATE [dbo].[Company] SET 
	[Company].[CompanyName] = @CompanyName,
	[Company].[CompanyDesc] = @CompanyDesc,
	[Company].[PhoneNumber] = @PhoneNumber,
	[Company].[Address] = @Address,
	[Company].[ChargePerson] = @ChargePerson,
	[Company].[AddTime] = @AddTime,
	[Company].[IsActive] = @IsActive,
	[Company].[BaseURL] = @BaseURL,
	[Company].[UserCount] = @UserCount,
	[Company].[Distributor] = @Distributor,
	[Company].[ServerStartTime] = @ServerStartTime,
	[Company].[ServerEndTime] = @ServerEndTime,
	[Company].[IsPay] = @IsPay,
	[Company].[IsAdmin] = @IsAdmin,
	[Company].[IsCustomer] = @IsCustomer,
	[Company].[ServerLocation] = @ServerLocation,
	[Company].[LocalURL] = @LocalURL,
	[Company].[Login_LogImg] = @Login_LogImg,
	[Company].[Login_BodyImg] = @Login_BodyImg,
	[Company].[Home_LogoImg] = @Home_LogoImg,
	[Company].[VersionCode] = @VersionCode,
	[Company].[ProjectCount] = @ProjectCount,
	[Company].[FromCompanyID] = @FromCompanyID,
	[Company].[IsHideLogin_LogImg] = @IsHideLogin_LogImg,
	[Company].[IsHideLogin_BodyImg] = @IsHideLogin_BodyImg,
	[Company].[IsHideHome_LogoImg] = @IsHideHome_LogoImg,
	[Company].[CopyRightText] = @CopyRightText,
	[Company].[IsHideCopyRightText] = @IsHideCopyRightText,
	[Company].[AlowRemoteUpdate] = @AlowRemoteUpdate,
	[Company].[IsWechatOn] = @IsWechatOn,
	[Company].[IsMallOn] = @IsMallOn,
	[Company].[ExpiringMsg] = @ExpiringMsg,
	[Company].[ExpiringDay] = @ExpiringDay,
	[Company].[ExpiringShow] = @ExpiringShow,
	[Company].[VirName] = @VirName,
	[Company].[Signature] = @Signature,
	[Company].[Token] = @Token,
	[Company].[SystemNo] = @SystemNo,
	[Company].[ChequeTitle] = @ChequeTitle,
	[Company].[TaxpayerNumber] = @TaxpayerNumber,
	[Company].[BankAccountName] = @BankAccountName,
	[Company].[BankAccountNo] = @BankAccountNo,
	[Company].[BankName] = @BankName,
	[Company].[ReCheckUserName] = @ReCheckUserName,
	[Company].[Cheque_SL] = @Cheque_SL,
	[Company].[Cheque_FLBM] = @Cheque_FLBM 
output 
	INSERTED.[CompanyID],
	INSERTED.[CompanyName],
	INSERTED.[CompanyDesc],
	INSERTED.[PhoneNumber],
	INSERTED.[Address],
	INSERTED.[ChargePerson],
	INSERTED.[AddTime],
	INSERTED.[IsActive],
	INSERTED.[BaseURL],
	INSERTED.[UserCount],
	INSERTED.[Distributor],
	INSERTED.[ServerStartTime],
	INSERTED.[ServerEndTime],
	INSERTED.[IsPay],
	INSERTED.[IsAdmin],
	INSERTED.[IsCustomer],
	INSERTED.[ServerLocation],
	INSERTED.[LocalURL],
	INSERTED.[Login_LogImg],
	INSERTED.[Login_BodyImg],
	INSERTED.[Home_LogoImg],
	INSERTED.[VersionCode],
	INSERTED.[ProjectCount],
	INSERTED.[FromCompanyID],
	INSERTED.[IsHideLogin_LogImg],
	INSERTED.[IsHideLogin_BodyImg],
	INSERTED.[IsHideHome_LogoImg],
	INSERTED.[CopyRightText],
	INSERTED.[IsHideCopyRightText],
	INSERTED.[AlowRemoteUpdate],
	INSERTED.[IsWechatOn],
	INSERTED.[IsMallOn],
	INSERTED.[ExpiringMsg],
	INSERTED.[ExpiringDay],
	INSERTED.[ExpiringShow],
	INSERTED.[VirName],
	INSERTED.[Signature],
	INSERTED.[Token],
	INSERTED.[SystemNo],
	INSERTED.[ChequeTitle],
	INSERTED.[TaxpayerNumber],
	INSERTED.[BankAccountName],
	INSERTED.[BankAccountNo],
	INSERTED.[BankName],
	INSERTED.[ReCheckUserName],
	INSERTED.[Cheque_SL],
	INSERTED.[Cheque_FLBM]
into @table
WHERE 
	[Company].[CompanyID] = @CompanyID

SELECT 
	[CompanyID],
	[CompanyName],
	[CompanyDesc],
	[PhoneNumber],
	[Address],
	[ChargePerson],
	[AddTime],
	[IsActive],
	[BaseURL],
	[UserCount],
	[Distributor],
	[ServerStartTime],
	[ServerEndTime],
	[IsPay],
	[IsAdmin],
	[IsCustomer],
	[ServerLocation],
	[LocalURL],
	[Login_LogImg],
	[Login_BodyImg],
	[Home_LogoImg],
	[VersionCode],
	[ProjectCount],
	[FromCompanyID],
	[IsHideLogin_LogImg],
	[IsHideLogin_BodyImg],
	[IsHideHome_LogoImg],
	[CopyRightText],
	[IsHideCopyRightText],
	[AlowRemoteUpdate],
	[IsWechatOn],
	[IsMallOn],
	[ExpiringMsg],
	[ExpiringDay],
	[ExpiringShow],
	[VirName],
	[Signature],
	[Token],
	[SystemNo],
	[ChequeTitle],
	[TaxpayerNumber],
	[BankAccountName],
	[BankAccountNo],
	[BankName],
	[ReCheckUserName],
	[Cheque_SL],
	[Cheque_FLBM] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@CompanyName", EntityBase.GetDatabaseValue(@companyName)));
			parameters.Add(new SqlParameter("@CompanyDesc", EntityBase.GetDatabaseValue(@companyDesc)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@Address", EntityBase.GetDatabaseValue(@address)));
			parameters.Add(new SqlParameter("@ChargePerson", EntityBase.GetDatabaseValue(@chargePerson)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@BaseURL", EntityBase.GetDatabaseValue(@baseURL)));
			parameters.Add(new SqlParameter("@UserCount", EntityBase.GetDatabaseValue(@userCount)));
			parameters.Add(new SqlParameter("@Distributor", EntityBase.GetDatabaseValue(@distributor)));
			parameters.Add(new SqlParameter("@ServerStartTime", EntityBase.GetDatabaseValue(@serverStartTime)));
			parameters.Add(new SqlParameter("@ServerEndTime", EntityBase.GetDatabaseValue(@serverEndTime)));
			parameters.Add(new SqlParameter("@IsPay", @isPay));
			parameters.Add(new SqlParameter("@IsAdmin", @isAdmin));
			parameters.Add(new SqlParameter("@IsCustomer", @isCustomer));
			parameters.Add(new SqlParameter("@ServerLocation", EntityBase.GetDatabaseValue(@serverLocation)));
			parameters.Add(new SqlParameter("@LocalURL", EntityBase.GetDatabaseValue(@localURL)));
			parameters.Add(new SqlParameter("@Login_LogImg", EntityBase.GetDatabaseValue(@login_LogImg)));
			parameters.Add(new SqlParameter("@Login_BodyImg", EntityBase.GetDatabaseValue(@login_BodyImg)));
			parameters.Add(new SqlParameter("@Home_LogoImg", EntityBase.GetDatabaseValue(@home_LogoImg)));
			parameters.Add(new SqlParameter("@VersionCode", EntityBase.GetDatabaseValue(@versionCode)));
			parameters.Add(new SqlParameter("@ProjectCount", EntityBase.GetDatabaseValue(@projectCount)));
			parameters.Add(new SqlParameter("@FromCompanyID", EntityBase.GetDatabaseValue(@fromCompanyID)));
			parameters.Add(new SqlParameter("@IsHideLogin_LogImg", @isHideLogin_LogImg));
			parameters.Add(new SqlParameter("@IsHideLogin_BodyImg", @isHideLogin_BodyImg));
			parameters.Add(new SqlParameter("@IsHideHome_LogoImg", @isHideHome_LogoImg));
			parameters.Add(new SqlParameter("@CopyRightText", EntityBase.GetDatabaseValue(@copyRightText)));
			parameters.Add(new SqlParameter("@IsHideCopyRightText", @isHideCopyRightText));
			parameters.Add(new SqlParameter("@AlowRemoteUpdate", @alowRemoteUpdate));
			parameters.Add(new SqlParameter("@IsWechatOn", @isWechatOn));
			parameters.Add(new SqlParameter("@IsMallOn", @isMallOn));
			parameters.Add(new SqlParameter("@ExpiringMsg", EntityBase.GetDatabaseValue(@expiringMsg)));
			parameters.Add(new SqlParameter("@ExpiringDay", EntityBase.GetDatabaseValue(@expiringDay)));
			parameters.Add(new SqlParameter("@ExpiringShow", @expiringShow));
			parameters.Add(new SqlParameter("@VirName", EntityBase.GetDatabaseValue(@virName)));
			parameters.Add(new SqlParameter("@Signature", EntityBase.GetDatabaseValue(@signature)));
			parameters.Add(new SqlParameter("@Token", EntityBase.GetDatabaseValue(@token)));
			parameters.Add(new SqlParameter("@SystemNo", EntityBase.GetDatabaseValue(@systemNo)));
			parameters.Add(new SqlParameter("@ChequeTitle", EntityBase.GetDatabaseValue(@chequeTitle)));
			parameters.Add(new SqlParameter("@TaxpayerNumber", EntityBase.GetDatabaseValue(@taxpayerNumber)));
			parameters.Add(new SqlParameter("@BankAccountName", EntityBase.GetDatabaseValue(@bankAccountName)));
			parameters.Add(new SqlParameter("@BankAccountNo", EntityBase.GetDatabaseValue(@bankAccountNo)));
			parameters.Add(new SqlParameter("@BankName", EntityBase.GetDatabaseValue(@bankName)));
			parameters.Add(new SqlParameter("@ReCheckUserName", EntityBase.GetDatabaseValue(@reCheckUserName)));
			parameters.Add(new SqlParameter("@Cheque_SL", EntityBase.GetDatabaseValue(@cheque_SL)));
			parameters.Add(new SqlParameter("@Cheque_FLBM", EntityBase.GetDatabaseValue(@cheque_FLBM)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Company from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		public static void DeleteCompany(int @companyID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCompany(@companyID, helper);
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
		/// Deletes a Company from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCompany(int @companyID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Company]
WHERE 
	[Company].[CompanyID] = @CompanyID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", @companyID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Company object.
		/// </summary>
		/// <returns>The newly created Company object.</returns>
		public static Company CreateCompany()
		{
			return InitializeNew<Company>();
		}
		
		/// <summary>
		/// Retrieve information for a Company by a Company's unique identifier.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <returns>Company</returns>
		public static Company GetCompany(int @companyID)
		{
			string commandText = @"
SELECT 
" + Company.SelectFieldList + @"
FROM [dbo].[Company] 
WHERE 
	[Company].[CompanyID] = @CompanyID " + Company.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", @companyID));
			
			return GetOne<Company>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Company by a Company's unique identifier.
		/// </summary>
		/// <param name="companyID">companyID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Company</returns>
		public static Company GetCompany(int @companyID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Company.SelectFieldList + @"
FROM [dbo].[Company] 
WHERE 
	[Company].[CompanyID] = @CompanyID " + Company.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", @companyID));
			
			return GetOne<Company>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Company objects.
		/// </summary>
		/// <returns>The retrieved collection of Company objects.</returns>
		public static EntityList<Company> GetCompanies()
		{
			string commandText = @"
SELECT " + Company.SelectFieldList + "FROM [dbo].[Company] " + Company.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Company>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Company objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Company objects.</returns>
        public static EntityList<Company> GetCompanies(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Company>(SelectFieldList, "FROM [dbo].[Company]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Company objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Company objects.</returns>
        public static EntityList<Company> GetCompanies(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Company>(SelectFieldList, "FROM [dbo].[Company]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Company objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Company objects.</returns>
		protected static EntityList<Company> GetCompanies(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCompanies(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Company objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Company objects.</returns>
		protected static EntityList<Company> GetCompanies(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCompanies(string.Empty, where, parameters, Company.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Company objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Company objects.</returns>
		protected static EntityList<Company> GetCompanies(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCompanies(prefix, where, parameters, Company.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Company objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Company objects.</returns>
		protected static EntityList<Company> GetCompanies(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCompanies(string.Empty, where, parameters, Company.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Company objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Company objects.</returns>
		protected static EntityList<Company> GetCompanies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCompanies(prefix, where, parameters, Company.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Company objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Company objects.</returns>
		protected static EntityList<Company> GetCompanies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Company.SelectFieldList + "FROM [dbo].[Company] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Company>(reader);
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
        protected static EntityList<Company> GetCompanies(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Company>(SelectFieldList, "FROM [dbo].[Company] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Company objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCompanyCount()
        {
            return GetCompanyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Company objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCompanyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Company] " + where;

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
		public static partial class Company_Properties
		{
			public const string CompanyID = "CompanyID";
			public const string CompanyName = "CompanyName";
			public const string CompanyDesc = "CompanyDesc";
			public const string PhoneNumber = "PhoneNumber";
			public const string Address = "Address";
			public const string ChargePerson = "ChargePerson";
			public const string AddTime = "AddTime";
			public const string IsActive = "IsActive";
			public const string BaseURL = "BaseURL";
			public const string UserCount = "UserCount";
			public const string Distributor = "Distributor";
			public const string ServerStartTime = "ServerStartTime";
			public const string ServerEndTime = "ServerEndTime";
			public const string IsPay = "IsPay";
			public const string IsAdmin = "IsAdmin";
			public const string IsCustomer = "IsCustomer";
			public const string ServerLocation = "ServerLocation";
			public const string LocalURL = "LocalURL";
			public const string Login_LogImg = "Login_LogImg";
			public const string Login_BodyImg = "Login_BodyImg";
			public const string Home_LogoImg = "Home_LogoImg";
			public const string VersionCode = "VersionCode";
			public const string ProjectCount = "ProjectCount";
			public const string FromCompanyID = "FromCompanyID";
			public const string IsHideLogin_LogImg = "IsHideLogin_LogImg";
			public const string IsHideLogin_BodyImg = "IsHideLogin_BodyImg";
			public const string IsHideHome_LogoImg = "IsHideHome_LogoImg";
			public const string CopyRightText = "CopyRightText";
			public const string IsHideCopyRightText = "IsHideCopyRightText";
			public const string AlowRemoteUpdate = "AlowRemoteUpdate";
			public const string IsWechatOn = "IsWechatOn";
			public const string IsMallOn = "IsMallOn";
			public const string ExpiringMsg = "ExpiringMsg";
			public const string ExpiringDay = "ExpiringDay";
			public const string ExpiringShow = "ExpiringShow";
			public const string VirName = "VirName";
			public const string Signature = "Signature";
			public const string Token = "Token";
			public const string SystemNo = "SystemNo";
			public const string ChequeTitle = "ChequeTitle";
			public const string TaxpayerNumber = "TaxpayerNumber";
			public const string BankAccountName = "BankAccountName";
			public const string BankAccountNo = "BankAccountNo";
			public const string BankName = "BankName";
			public const string ReCheckUserName = "ReCheckUserName";
			public const string Cheque_SL = "Cheque_SL";
			public const string Cheque_FLBM = "Cheque_FLBM";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"CompanyID" , "int:"},
    			 {"CompanyName" , "string:"},
    			 {"CompanyDesc" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"Address" , "string:"},
    			 {"ChargePerson" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsActive" , "bool:"},
    			 {"BaseURL" , "string:"},
    			 {"UserCount" , "int:"},
    			 {"Distributor" , "string:"},
    			 {"ServerStartTime" , "DateTime:"},
    			 {"ServerEndTime" , "DateTime:"},
    			 {"IsPay" , "bool:"},
    			 {"IsAdmin" , "bool:"},
    			 {"IsCustomer" , "bool:"},
    			 {"ServerLocation" , "int:"},
    			 {"LocalURL" , "string:"},
    			 {"Login_LogImg" , "string:"},
    			 {"Login_BodyImg" , "string:"},
    			 {"Home_LogoImg" , "string:"},
    			 {"VersionCode" , "int:"},
    			 {"ProjectCount" , "int:"},
    			 {"FromCompanyID" , "int:"},
    			 {"IsHideLogin_LogImg" , "bool:"},
    			 {"IsHideLogin_BodyImg" , "bool:"},
    			 {"IsHideHome_LogoImg" , "bool:"},
    			 {"CopyRightText" , "string:"},
    			 {"IsHideCopyRightText" , "bool:"},
    			 {"AlowRemoteUpdate" , "bool:"},
    			 {"IsWechatOn" , "bool:"},
    			 {"IsMallOn" , "bool:"},
    			 {"ExpiringMsg" , "string:"},
    			 {"ExpiringDay" , "int:"},
    			 {"ExpiringShow" , "bool:"},
    			 {"VirName" , "string:"},
    			 {"Signature" , "string:"},
    			 {"Token" , "string:"},
    			 {"SystemNo" , "string:"},
    			 {"ChequeTitle" , "string:"},
    			 {"TaxpayerNumber" , "string:"},
    			 {"BankAccountName" , "string:"},
    			 {"BankAccountNo" , "string:"},
    			 {"BankName" , "string:"},
    			 {"ReCheckUserName" , "string:"},
    			 {"Cheque_SL" , "decimal:"},
    			 {"Cheque_FLBM" , "string:"},
            };
		}
		#endregion
	}
}
