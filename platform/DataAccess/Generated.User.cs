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
	/// This object represents the properties and methods of a User.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("UserID: {UserID}")]
	public partial class User 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			 set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _loginName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string LoginName
		{
			[DebuggerStepThrough()]
			get { return this._loginName; }
			set 
			{
				if (this._loginName != value) 
				{
					this._loginName = value;
					this.IsDirty = true;	
					OnPropertyChanged("LoginName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _password = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Password
		{
			[DebuggerStepThrough()]
			get { return this._password; }
			set 
			{
				if (this._password != value) 
				{
					this._password = value;
					this.IsDirty = true;	
					OnPropertyChanged("Password");
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
		private string _email = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Email
		{
			[DebuggerStepThrough()]
			get { return this._email; }
			set 
			{
				if (this._email != value) 
				{
					this._email = value;
					this.IsDirty = true;	
					OnPropertyChanged("Email");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _headImg = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HeadImg
		{
			[DebuggerStepThrough()]
			get { return this._headImg; }
			set 
			{
				if (this._headImg != value) 
				{
					this._headImg = value;
					this.IsDirty = true;	
					OnPropertyChanged("HeadImg");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _nickName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string NickName
		{
			[DebuggerStepThrough()]
			get { return this._nickName; }
			set 
			{
				if (this._nickName != value) 
				{
					this._nickName = value;
					this.IsDirty = true;	
					OnPropertyChanged("NickName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _realName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RealName
		{
			[DebuggerStepThrough()]
			get { return this._realName; }
			set 
			{
				if (this._realName != value) 
				{
					this._realName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RealName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _gender = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Gender
		{
			[DebuggerStepThrough()]
			get { return this._gender; }
			set 
			{
				if (this._gender != value) 
				{
					this._gender = value;
					this.IsDirty = true;	
					OnPropertyChanged("Gender");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _type = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Type
		{
			[DebuggerStepThrough()]
			get { return this._type; }
			set 
			{
				if (this._type != value) 
				{
					this._type = value;
					this.IsDirty = true;	
					OnPropertyChanged("Type");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _createTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CreateTime
		{
			[DebuggerStepThrough()]
			get { return this._createTime; }
			set 
			{
				if (this._createTime != value) 
				{
					this._createTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CreateTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isLocked = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsLocked
		{
			[DebuggerStepThrough()]
			get { return this._isLocked; }
			set 
			{
				if (this._isLocked != value) 
				{
					this._isLocked = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsLocked");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lockTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LockTime
		{
			[DebuggerStepThrough()]
			get { return this._lockTime; }
			set 
			{
				if (this._lockTime != value) 
				{
					this._lockTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("LockTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _activeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ActiveTime
		{
			[DebuggerStepThrough()]
			get { return this._activeTime; }
			set 
			{
				if (this._activeTime != value) 
				{
					this._activeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ActiveTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _hotPhoneLine = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HotPhoneLine
		{
			[DebuggerStepThrough()]
			get { return this._hotPhoneLine; }
			set 
			{
				if (this._hotPhoneLine != value) 
				{
					this._hotPhoneLine = value;
					this.IsDirty = true;	
					OnPropertyChanged("HotPhoneLine");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _belongServiceName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BelongServiceName
		{
			[DebuggerStepThrough()]
			get { return this._belongServiceName; }
			set 
			{
				if (this._belongServiceName != value) 
				{
					this._belongServiceName = value;
					this.IsDirty = true;	
					OnPropertyChanged("BelongServiceName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _qQNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string QQNumber
		{
			[DebuggerStepThrough()]
			get { return this._qQNumber; }
			set 
			{
				if (this._qQNumber != value) 
				{
					this._qQNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("QQNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _fromUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FromUserID
		{
			[DebuggerStepThrough()]
			get { return this._fromUserID; }
			set 
			{
				if (this._fromUserID != value) 
				{
					this._fromUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("FromUserID");
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
		private int _relationID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelationID
		{
			[DebuggerStepThrough()]
			get { return this._relationID; }
			set 
			{
				if (this._relationID != value) 
				{
					this._relationID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelationID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceType
		{
			[DebuggerStepThrough()]
			get { return this._deviceType; }
			set 
			{
				if (this._deviceType != value) 
				{
					this._deviceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _deviceId = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DeviceId
		{
			[DebuggerStepThrough()]
			get { return this._deviceId; }
			set 
			{
				if (this._deviceId != value) 
				{
					this._deviceId = value;
					this.IsDirty = true;	
					OnPropertyChanged("DeviceId");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPWxOpenID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPWxOpenID
		{
			[DebuggerStepThrough()]
			get { return this._aPPWxOpenID; }
			set 
			{
				if (this._aPPWxOpenID != value) 
				{
					this._aPPWxOpenID = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPWxOpenID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPQQOpenID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPQQOpenID
		{
			[DebuggerStepThrough()]
			get { return this._aPPQQOpenID; }
			set 
			{
				if (this._aPPQQOpenID != value) 
				{
					this._aPPQQOpenID = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPQQOpenID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPWeiBoUserID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPWeiBoUserID
		{
			[DebuggerStepThrough()]
			get { return this._aPPWeiBoUserID; }
			set 
			{
				if (this._aPPWeiBoUserID != value) 
				{
					this._aPPWeiBoUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPWeiBoUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _payPassword = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PayPassword
		{
			[DebuggerStepThrough()]
			get { return this._payPassword; }
			set 
			{
				if (this._payPassword != value) 
				{
					this._payPassword = value;
					this.IsDirty = true;	
					OnPropertyChanged("PayPassword");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _familyUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FamilyUserID
		{
			[DebuggerStepThrough()]
			get { return this._familyUserID; }
			set 
			{
				if (this._familyUserID != value) 
				{
					this._familyUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("FamilyUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ParentUserID
		{
			[DebuggerStepThrough()]
			get { return this._parentUserID; }
			set 
			{
				if (this._parentUserID != value) 
				{
					this._parentUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _birthday = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime Birthday
		{
			[DebuggerStepThrough()]
			get { return this._birthday; }
			set 
			{
				if (this._birthday != value) 
				{
					this._birthday = value;
					this.IsDirty = true;	
					OnPropertyChanged("Birthday");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowSysLogin = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowSysLogin
		{
			[DebuggerStepThrough()]
			get { return this._isAllowSysLogin; }
			set 
			{
				if (this._isAllowSysLogin != value) 
				{
					this._isAllowSysLogin = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowSysLogin");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowAPPUserLogin = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowAPPUserLogin
		{
			[DebuggerStepThrough()]
			get { return this._isAllowAPPUserLogin; }
			set 
			{
				if (this._isAllowAPPUserLogin != value) 
				{
					this._isAllowAPPUserLogin = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowAPPUserLogin");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowAPPCustomerLogin = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowAPPCustomerLogin
		{
			[DebuggerStepThrough()]
			get { return this._isAllowAPPCustomerLogin; }
			set 
			{
				if (this._isAllowAPPCustomerLogin != value) 
				{
					this._isAllowAPPCustomerLogin = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowAPPCustomerLogin");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _positionName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PositionName
		{
			[DebuggerStepThrough()]
			get { return this._positionName; }
			set 
			{
				if (this._positionName != value) 
				{
					this._positionName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PositionName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _education = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Education
		{
			[DebuggerStepThrough()]
			get { return this._education; }
			set 
			{
				if (this._education != value) 
				{
					this._education = value;
					this.IsDirty = true;	
					OnPropertyChanged("Education");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _fixedPoint = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FixedPoint
		{
			[DebuggerStepThrough()]
			get { return this._fixedPoint; }
			set 
			{
				if (this._fixedPoint != value) 
				{
					this._fixedPoint = value;
					this.IsDirty = true;	
					OnPropertyChanged("FixedPoint");
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
		private DateTime _fixedPointUpdateDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FixedPointUpdateDate
		{
			[DebuggerStepThrough()]
			get { return this._fixedPointUpdateDate; }
			set 
			{
				if (this._fixedPointUpdateDate != value) 
				{
					this._fixedPointUpdateDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("FixedPointUpdateDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userLevelID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int UserLevelID
		{
			[DebuggerStepThrough()]
			get { return this._userLevelID; }
			set 
			{
				if (this._userLevelID != value) 
				{
					this._userLevelID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserLevelID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAllowPhrase = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAllowPhrase
		{
			[DebuggerStepThrough()]
			get { return this._isAllowPhrase; }
			set 
			{
				if (this._isAllowPhrase != value) 
				{
					this._isAllowPhrase = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAllowPhrase");
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
		private bool _firstChangeBirthday = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool FirstChangeBirthday
		{
			[DebuggerStepThrough()]
			get { return this._firstChangeBirthday; }
			set 
			{
				if (this._firstChangeBirthday != value) 
				{
					this._firstChangeBirthday = value;
					this.IsDirty = true;	
					OnPropertyChanged("FirstChangeBirthday");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPUserDeviceType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPUserDeviceType
		{
			[DebuggerStepThrough()]
			get { return this._aPPUserDeviceType; }
			set 
			{
				if (this._aPPUserDeviceType != value) 
				{
					this._aPPUserDeviceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPUserDeviceType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPUserDeviceID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPUserDeviceID
		{
			[DebuggerStepThrough()]
			get { return this._aPPUserDeviceID; }
			set 
			{
				if (this._aPPUserDeviceID != value) 
				{
					this._aPPUserDeviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPUserDeviceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPBusinessDeviceType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPBusinessDeviceType
		{
			[DebuggerStepThrough()]
			get { return this._aPPBusinessDeviceType; }
			set 
			{
				if (this._aPPBusinessDeviceType != value) 
				{
					this._aPPBusinessDeviceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPBusinessDeviceType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPBusinessDeviceID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPBusinessDeviceID
		{
			[DebuggerStepThrough()]
			get { return this._aPPBusinessDeviceID; }
			set 
			{
				if (this._aPPBusinessDeviceID != value) 
				{
					this._aPPBusinessDeviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPBusinessDeviceID");
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
	[UserID] int,
	[LoginName] nvarchar(50),
	[Password] nvarchar(200),
	[PhoneNumber] nvarchar(20),
	[Email] nvarchar(50),
	[HeadImg] nvarchar(500),
	[NickName] nvarchar(50),
	[RealName] nvarchar(50),
	[Gender] nvarchar(20),
	[Type] nvarchar(20),
	[CreateTime] datetime,
	[IsLocked] bit,
	[LockTime] datetime,
	[ActiveTime] datetime,
	[HotPhoneLine] nvarchar(100),
	[BelongServiceName] nvarchar(100),
	[QQNumber] nvarchar(100),
	[FromUserID] int,
	[FromCompanyID] int,
	[RelationID] int,
	[DeviceType] nvarchar(50),
	[DeviceId] nvarchar(200),
	[OpenID] nvarchar(500),
	[APPWxOpenID] nvarchar(500),
	[APPQQOpenID] nvarchar(500),
	[APPWeiBoUserID] nvarchar(500),
	[PayPassword] nvarchar(200),
	[FamilyUserID] int,
	[ParentUserID] int,
	[Birthday] datetime,
	[IsAllowSysLogin] bit,
	[IsAllowAPPUserLogin] bit,
	[IsAllowAPPCustomerLogin] bit,
	[PositionName] nvarchar(200),
	[Education] nvarchar(200),
	[FixedPoint] int,
	[DepartmentID] int,
	[FixedPointUpdateDate] datetime,
	[UserLevelID] int,
	[IsAllowPhrase] bit,
	[Summary] ntext,
	[FirstChangeBirthday] bit,
	[APPUserDeviceType] nvarchar(50),
	[APPUserDeviceID] nvarchar(200),
	[APPBusinessDeviceType] nvarchar(50),
	[APPBusinessDeviceID] nvarchar(200),
	[ServiceFrom] nvarchar(100)
);

INSERT INTO [dbo].[User] (
	[User].[LoginName],
	[User].[Password],
	[User].[PhoneNumber],
	[User].[Email],
	[User].[HeadImg],
	[User].[NickName],
	[User].[RealName],
	[User].[Gender],
	[User].[Type],
	[User].[CreateTime],
	[User].[IsLocked],
	[User].[LockTime],
	[User].[ActiveTime],
	[User].[HotPhoneLine],
	[User].[BelongServiceName],
	[User].[QQNumber],
	[User].[FromUserID],
	[User].[FromCompanyID],
	[User].[RelationID],
	[User].[DeviceType],
	[User].[DeviceId],
	[User].[OpenID],
	[User].[APPWxOpenID],
	[User].[APPQQOpenID],
	[User].[APPWeiBoUserID],
	[User].[PayPassword],
	[User].[FamilyUserID],
	[User].[ParentUserID],
	[User].[Birthday],
	[User].[IsAllowSysLogin],
	[User].[IsAllowAPPUserLogin],
	[User].[IsAllowAPPCustomerLogin],
	[User].[PositionName],
	[User].[Education],
	[User].[FixedPoint],
	[User].[DepartmentID],
	[User].[FixedPointUpdateDate],
	[User].[UserLevelID],
	[User].[IsAllowPhrase],
	[User].[Summary],
	[User].[FirstChangeBirthday],
	[User].[APPUserDeviceType],
	[User].[APPUserDeviceID],
	[User].[APPBusinessDeviceType],
	[User].[APPBusinessDeviceID],
	[User].[ServiceFrom]
) 
output 
	INSERTED.[UserID],
	INSERTED.[LoginName],
	INSERTED.[Password],
	INSERTED.[PhoneNumber],
	INSERTED.[Email],
	INSERTED.[HeadImg],
	INSERTED.[NickName],
	INSERTED.[RealName],
	INSERTED.[Gender],
	INSERTED.[Type],
	INSERTED.[CreateTime],
	INSERTED.[IsLocked],
	INSERTED.[LockTime],
	INSERTED.[ActiveTime],
	INSERTED.[HotPhoneLine],
	INSERTED.[BelongServiceName],
	INSERTED.[QQNumber],
	INSERTED.[FromUserID],
	INSERTED.[FromCompanyID],
	INSERTED.[RelationID],
	INSERTED.[DeviceType],
	INSERTED.[DeviceId],
	INSERTED.[OpenID],
	INSERTED.[APPWxOpenID],
	INSERTED.[APPQQOpenID],
	INSERTED.[APPWeiBoUserID],
	INSERTED.[PayPassword],
	INSERTED.[FamilyUserID],
	INSERTED.[ParentUserID],
	INSERTED.[Birthday],
	INSERTED.[IsAllowSysLogin],
	INSERTED.[IsAllowAPPUserLogin],
	INSERTED.[IsAllowAPPCustomerLogin],
	INSERTED.[PositionName],
	INSERTED.[Education],
	INSERTED.[FixedPoint],
	INSERTED.[DepartmentID],
	INSERTED.[FixedPointUpdateDate],
	INSERTED.[UserLevelID],
	INSERTED.[IsAllowPhrase],
	INSERTED.[Summary],
	INSERTED.[FirstChangeBirthday],
	INSERTED.[APPUserDeviceType],
	INSERTED.[APPUserDeviceID],
	INSERTED.[APPBusinessDeviceType],
	INSERTED.[APPBusinessDeviceID],
	INSERTED.[ServiceFrom]
into @table
VALUES ( 
	@LoginName,
	@Password,
	@PhoneNumber,
	@Email,
	@HeadImg,
	@NickName,
	@RealName,
	@Gender,
	@Type,
	@CreateTime,
	@IsLocked,
	@LockTime,
	@ActiveTime,
	@HotPhoneLine,
	@BelongServiceName,
	@QQNumber,
	@FromUserID,
	@FromCompanyID,
	@RelationID,
	@DeviceType,
	@DeviceId,
	@OpenID,
	@APPWxOpenID,
	@APPQQOpenID,
	@APPWeiBoUserID,
	@PayPassword,
	@FamilyUserID,
	@ParentUserID,
	@Birthday,
	@IsAllowSysLogin,
	@IsAllowAPPUserLogin,
	@IsAllowAPPCustomerLogin,
	@PositionName,
	@Education,
	@FixedPoint,
	@DepartmentID,
	@FixedPointUpdateDate,
	@UserLevelID,
	@IsAllowPhrase,
	@Summary,
	@FirstChangeBirthday,
	@APPUserDeviceType,
	@APPUserDeviceID,
	@APPBusinessDeviceType,
	@APPBusinessDeviceID,
	@ServiceFrom 
); 

SELECT 
	[UserID],
	[LoginName],
	[Password],
	[PhoneNumber],
	[Email],
	[HeadImg],
	[NickName],
	[RealName],
	[Gender],
	[Type],
	[CreateTime],
	[IsLocked],
	[LockTime],
	[ActiveTime],
	[HotPhoneLine],
	[BelongServiceName],
	[QQNumber],
	[FromUserID],
	[FromCompanyID],
	[RelationID],
	[DeviceType],
	[DeviceId],
	[OpenID],
	[APPWxOpenID],
	[APPQQOpenID],
	[APPWeiBoUserID],
	[PayPassword],
	[FamilyUserID],
	[ParentUserID],
	[Birthday],
	[IsAllowSysLogin],
	[IsAllowAPPUserLogin],
	[IsAllowAPPCustomerLogin],
	[PositionName],
	[Education],
	[FixedPoint],
	[DepartmentID],
	[FixedPointUpdateDate],
	[UserLevelID],
	[IsAllowPhrase],
	[Summary],
	[FirstChangeBirthday],
	[APPUserDeviceType],
	[APPUserDeviceID],
	[APPBusinessDeviceType],
	[APPBusinessDeviceID],
	[ServiceFrom] 
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
	[UserID] int,
	[LoginName] nvarchar(50),
	[Password] nvarchar(200),
	[PhoneNumber] nvarchar(20),
	[Email] nvarchar(50),
	[HeadImg] nvarchar(500),
	[NickName] nvarchar(50),
	[RealName] nvarchar(50),
	[Gender] nvarchar(20),
	[Type] nvarchar(20),
	[CreateTime] datetime,
	[IsLocked] bit,
	[LockTime] datetime,
	[ActiveTime] datetime,
	[HotPhoneLine] nvarchar(100),
	[BelongServiceName] nvarchar(100),
	[QQNumber] nvarchar(100),
	[FromUserID] int,
	[FromCompanyID] int,
	[RelationID] int,
	[DeviceType] nvarchar(50),
	[DeviceId] nvarchar(200),
	[OpenID] nvarchar(500),
	[APPWxOpenID] nvarchar(500),
	[APPQQOpenID] nvarchar(500),
	[APPWeiBoUserID] nvarchar(500),
	[PayPassword] nvarchar(200),
	[FamilyUserID] int,
	[ParentUserID] int,
	[Birthday] datetime,
	[IsAllowSysLogin] bit,
	[IsAllowAPPUserLogin] bit,
	[IsAllowAPPCustomerLogin] bit,
	[PositionName] nvarchar(200),
	[Education] nvarchar(200),
	[FixedPoint] int,
	[DepartmentID] int,
	[FixedPointUpdateDate] datetime,
	[UserLevelID] int,
	[IsAllowPhrase] bit,
	[Summary] ntext,
	[FirstChangeBirthday] bit,
	[APPUserDeviceType] nvarchar(50),
	[APPUserDeviceID] nvarchar(200),
	[APPBusinessDeviceType] nvarchar(50),
	[APPBusinessDeviceID] nvarchar(200),
	[ServiceFrom] nvarchar(100)
);

UPDATE [dbo].[User] SET 
	[User].[LoginName] = @LoginName,
	[User].[Password] = @Password,
	[User].[PhoneNumber] = @PhoneNumber,
	[User].[Email] = @Email,
	[User].[HeadImg] = @HeadImg,
	[User].[NickName] = @NickName,
	[User].[RealName] = @RealName,
	[User].[Gender] = @Gender,
	[User].[Type] = @Type,
	[User].[CreateTime] = @CreateTime,
	[User].[IsLocked] = @IsLocked,
	[User].[LockTime] = @LockTime,
	[User].[ActiveTime] = @ActiveTime,
	[User].[HotPhoneLine] = @HotPhoneLine,
	[User].[BelongServiceName] = @BelongServiceName,
	[User].[QQNumber] = @QQNumber,
	[User].[FromUserID] = @FromUserID,
	[User].[FromCompanyID] = @FromCompanyID,
	[User].[RelationID] = @RelationID,
	[User].[DeviceType] = @DeviceType,
	[User].[DeviceId] = @DeviceId,
	[User].[OpenID] = @OpenID,
	[User].[APPWxOpenID] = @APPWxOpenID,
	[User].[APPQQOpenID] = @APPQQOpenID,
	[User].[APPWeiBoUserID] = @APPWeiBoUserID,
	[User].[PayPassword] = @PayPassword,
	[User].[FamilyUserID] = @FamilyUserID,
	[User].[ParentUserID] = @ParentUserID,
	[User].[Birthday] = @Birthday,
	[User].[IsAllowSysLogin] = @IsAllowSysLogin,
	[User].[IsAllowAPPUserLogin] = @IsAllowAPPUserLogin,
	[User].[IsAllowAPPCustomerLogin] = @IsAllowAPPCustomerLogin,
	[User].[PositionName] = @PositionName,
	[User].[Education] = @Education,
	[User].[FixedPoint] = @FixedPoint,
	[User].[DepartmentID] = @DepartmentID,
	[User].[FixedPointUpdateDate] = @FixedPointUpdateDate,
	[User].[UserLevelID] = @UserLevelID,
	[User].[IsAllowPhrase] = @IsAllowPhrase,
	[User].[Summary] = @Summary,
	[User].[FirstChangeBirthday] = @FirstChangeBirthday,
	[User].[APPUserDeviceType] = @APPUserDeviceType,
	[User].[APPUserDeviceID] = @APPUserDeviceID,
	[User].[APPBusinessDeviceType] = @APPBusinessDeviceType,
	[User].[APPBusinessDeviceID] = @APPBusinessDeviceID,
	[User].[ServiceFrom] = @ServiceFrom 
output 
	INSERTED.[UserID],
	INSERTED.[LoginName],
	INSERTED.[Password],
	INSERTED.[PhoneNumber],
	INSERTED.[Email],
	INSERTED.[HeadImg],
	INSERTED.[NickName],
	INSERTED.[RealName],
	INSERTED.[Gender],
	INSERTED.[Type],
	INSERTED.[CreateTime],
	INSERTED.[IsLocked],
	INSERTED.[LockTime],
	INSERTED.[ActiveTime],
	INSERTED.[HotPhoneLine],
	INSERTED.[BelongServiceName],
	INSERTED.[QQNumber],
	INSERTED.[FromUserID],
	INSERTED.[FromCompanyID],
	INSERTED.[RelationID],
	INSERTED.[DeviceType],
	INSERTED.[DeviceId],
	INSERTED.[OpenID],
	INSERTED.[APPWxOpenID],
	INSERTED.[APPQQOpenID],
	INSERTED.[APPWeiBoUserID],
	INSERTED.[PayPassword],
	INSERTED.[FamilyUserID],
	INSERTED.[ParentUserID],
	INSERTED.[Birthday],
	INSERTED.[IsAllowSysLogin],
	INSERTED.[IsAllowAPPUserLogin],
	INSERTED.[IsAllowAPPCustomerLogin],
	INSERTED.[PositionName],
	INSERTED.[Education],
	INSERTED.[FixedPoint],
	INSERTED.[DepartmentID],
	INSERTED.[FixedPointUpdateDate],
	INSERTED.[UserLevelID],
	INSERTED.[IsAllowPhrase],
	INSERTED.[Summary],
	INSERTED.[FirstChangeBirthday],
	INSERTED.[APPUserDeviceType],
	INSERTED.[APPUserDeviceID],
	INSERTED.[APPBusinessDeviceType],
	INSERTED.[APPBusinessDeviceID],
	INSERTED.[ServiceFrom]
into @table
WHERE 
	[User].[UserID] = @UserID

SELECT 
	[UserID],
	[LoginName],
	[Password],
	[PhoneNumber],
	[Email],
	[HeadImg],
	[NickName],
	[RealName],
	[Gender],
	[Type],
	[CreateTime],
	[IsLocked],
	[LockTime],
	[ActiveTime],
	[HotPhoneLine],
	[BelongServiceName],
	[QQNumber],
	[FromUserID],
	[FromCompanyID],
	[RelationID],
	[DeviceType],
	[DeviceId],
	[OpenID],
	[APPWxOpenID],
	[APPQQOpenID],
	[APPWeiBoUserID],
	[PayPassword],
	[FamilyUserID],
	[ParentUserID],
	[Birthday],
	[IsAllowSysLogin],
	[IsAllowAPPUserLogin],
	[IsAllowAPPCustomerLogin],
	[PositionName],
	[Education],
	[FixedPoint],
	[DepartmentID],
	[FixedPointUpdateDate],
	[UserLevelID],
	[IsAllowPhrase],
	[Summary],
	[FirstChangeBirthday],
	[APPUserDeviceType],
	[APPUserDeviceID],
	[APPBusinessDeviceType],
	[APPBusinessDeviceID],
	[ServiceFrom] 
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
DELETE FROM [dbo].[User]
WHERE 
	[User].[UserID] = @UserID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public User() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetUser(this.UserID));
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
	[User].[UserID],
	[User].[LoginName],
	[User].[Password],
	[User].[PhoneNumber],
	[User].[Email],
	[User].[HeadImg],
	[User].[NickName],
	[User].[RealName],
	[User].[Gender],
	[User].[Type],
	[User].[CreateTime],
	[User].[IsLocked],
	[User].[LockTime],
	[User].[ActiveTime],
	[User].[HotPhoneLine],
	[User].[BelongServiceName],
	[User].[QQNumber],
	[User].[FromUserID],
	[User].[FromCompanyID],
	[User].[RelationID],
	[User].[DeviceType],
	[User].[DeviceId],
	[User].[OpenID],
	[User].[APPWxOpenID],
	[User].[APPQQOpenID],
	[User].[APPWeiBoUserID],
	[User].[PayPassword],
	[User].[FamilyUserID],
	[User].[ParentUserID],
	[User].[Birthday],
	[User].[IsAllowSysLogin],
	[User].[IsAllowAPPUserLogin],
	[User].[IsAllowAPPCustomerLogin],
	[User].[PositionName],
	[User].[Education],
	[User].[FixedPoint],
	[User].[DepartmentID],
	[User].[FixedPointUpdateDate],
	[User].[UserLevelID],
	[User].[IsAllowPhrase],
	[User].[Summary],
	[User].[FirstChangeBirthday],
	[User].[APPUserDeviceType],
	[User].[APPUserDeviceID],
	[User].[APPBusinessDeviceType],
	[User].[APPBusinessDeviceID],
	[User].[ServiceFrom]
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
                return "User";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a User into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="loginName">loginName</param>
		/// <param name="password">password</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="email">email</param>
		/// <param name="headImg">headImg</param>
		/// <param name="nickName">nickName</param>
		/// <param name="realName">realName</param>
		/// <param name="gender">gender</param>
		/// <param name="type">type</param>
		/// <param name="createTime">createTime</param>
		/// <param name="isLocked">isLocked</param>
		/// <param name="lockTime">lockTime</param>
		/// <param name="activeTime">activeTime</param>
		/// <param name="hotPhoneLine">hotPhoneLine</param>
		/// <param name="belongServiceName">belongServiceName</param>
		/// <param name="qQNumber">qQNumber</param>
		/// <param name="fromUserID">fromUserID</param>
		/// <param name="fromCompanyID">fromCompanyID</param>
		/// <param name="relationID">relationID</param>
		/// <param name="deviceType">deviceType</param>
		/// <param name="deviceId">deviceId</param>
		/// <param name="openID">openID</param>
		/// <param name="aPPWxOpenID">aPPWxOpenID</param>
		/// <param name="aPPQQOpenID">aPPQQOpenID</param>
		/// <param name="aPPWeiBoUserID">aPPWeiBoUserID</param>
		/// <param name="payPassword">payPassword</param>
		/// <param name="familyUserID">familyUserID</param>
		/// <param name="parentUserID">parentUserID</param>
		/// <param name="birthday">birthday</param>
		/// <param name="isAllowSysLogin">isAllowSysLogin</param>
		/// <param name="isAllowAPPUserLogin">isAllowAPPUserLogin</param>
		/// <param name="isAllowAPPCustomerLogin">isAllowAPPCustomerLogin</param>
		/// <param name="positionName">positionName</param>
		/// <param name="education">education</param>
		/// <param name="fixedPoint">fixedPoint</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="fixedPointUpdateDate">fixedPointUpdateDate</param>
		/// <param name="userLevelID">userLevelID</param>
		/// <param name="isAllowPhrase">isAllowPhrase</param>
		/// <param name="summary">summary</param>
		/// <param name="firstChangeBirthday">firstChangeBirthday</param>
		/// <param name="aPPUserDeviceType">aPPUserDeviceType</param>
		/// <param name="aPPUserDeviceID">aPPUserDeviceID</param>
		/// <param name="aPPBusinessDeviceType">aPPBusinessDeviceType</param>
		/// <param name="aPPBusinessDeviceID">aPPBusinessDeviceID</param>
		/// <param name="serviceFrom">serviceFrom</param>
		public static void InsertUser(string @loginName, string @password, string @phoneNumber, string @email, string @headImg, string @nickName, string @realName, string @gender, string @type, DateTime @createTime, bool @isLocked, DateTime @lockTime, DateTime @activeTime, string @hotPhoneLine, string @belongServiceName, string @qQNumber, int @fromUserID, int @fromCompanyID, int @relationID, string @deviceType, string @deviceId, string @openID, string @aPPWxOpenID, string @aPPQQOpenID, string @aPPWeiBoUserID, string @payPassword, int @familyUserID, int @parentUserID, DateTime @birthday, bool @isAllowSysLogin, bool @isAllowAPPUserLogin, bool @isAllowAPPCustomerLogin, string @positionName, string @education, int @fixedPoint, int @departmentID, DateTime @fixedPointUpdateDate, int @userLevelID, bool @isAllowPhrase, string @summary, bool @firstChangeBirthday, string @aPPUserDeviceType, string @aPPUserDeviceID, string @aPPBusinessDeviceType, string @aPPBusinessDeviceID, string @serviceFrom)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertUser(@loginName, @password, @phoneNumber, @email, @headImg, @nickName, @realName, @gender, @type, @createTime, @isLocked, @lockTime, @activeTime, @hotPhoneLine, @belongServiceName, @qQNumber, @fromUserID, @fromCompanyID, @relationID, @deviceType, @deviceId, @openID, @aPPWxOpenID, @aPPQQOpenID, @aPPWeiBoUserID, @payPassword, @familyUserID, @parentUserID, @birthday, @isAllowSysLogin, @isAllowAPPUserLogin, @isAllowAPPCustomerLogin, @positionName, @education, @fixedPoint, @departmentID, @fixedPointUpdateDate, @userLevelID, @isAllowPhrase, @summary, @firstChangeBirthday, @aPPUserDeviceType, @aPPUserDeviceID, @aPPBusinessDeviceType, @aPPBusinessDeviceID, @serviceFrom, helper);
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
		/// Insert a User into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="loginName">loginName</param>
		/// <param name="password">password</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="email">email</param>
		/// <param name="headImg">headImg</param>
		/// <param name="nickName">nickName</param>
		/// <param name="realName">realName</param>
		/// <param name="gender">gender</param>
		/// <param name="type">type</param>
		/// <param name="createTime">createTime</param>
		/// <param name="isLocked">isLocked</param>
		/// <param name="lockTime">lockTime</param>
		/// <param name="activeTime">activeTime</param>
		/// <param name="hotPhoneLine">hotPhoneLine</param>
		/// <param name="belongServiceName">belongServiceName</param>
		/// <param name="qQNumber">qQNumber</param>
		/// <param name="fromUserID">fromUserID</param>
		/// <param name="fromCompanyID">fromCompanyID</param>
		/// <param name="relationID">relationID</param>
		/// <param name="deviceType">deviceType</param>
		/// <param name="deviceId">deviceId</param>
		/// <param name="openID">openID</param>
		/// <param name="aPPWxOpenID">aPPWxOpenID</param>
		/// <param name="aPPQQOpenID">aPPQQOpenID</param>
		/// <param name="aPPWeiBoUserID">aPPWeiBoUserID</param>
		/// <param name="payPassword">payPassword</param>
		/// <param name="familyUserID">familyUserID</param>
		/// <param name="parentUserID">parentUserID</param>
		/// <param name="birthday">birthday</param>
		/// <param name="isAllowSysLogin">isAllowSysLogin</param>
		/// <param name="isAllowAPPUserLogin">isAllowAPPUserLogin</param>
		/// <param name="isAllowAPPCustomerLogin">isAllowAPPCustomerLogin</param>
		/// <param name="positionName">positionName</param>
		/// <param name="education">education</param>
		/// <param name="fixedPoint">fixedPoint</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="fixedPointUpdateDate">fixedPointUpdateDate</param>
		/// <param name="userLevelID">userLevelID</param>
		/// <param name="isAllowPhrase">isAllowPhrase</param>
		/// <param name="summary">summary</param>
		/// <param name="firstChangeBirthday">firstChangeBirthday</param>
		/// <param name="aPPUserDeviceType">aPPUserDeviceType</param>
		/// <param name="aPPUserDeviceID">aPPUserDeviceID</param>
		/// <param name="aPPBusinessDeviceType">aPPBusinessDeviceType</param>
		/// <param name="aPPBusinessDeviceID">aPPBusinessDeviceID</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="helper">helper</param>
		internal static void InsertUser(string @loginName, string @password, string @phoneNumber, string @email, string @headImg, string @nickName, string @realName, string @gender, string @type, DateTime @createTime, bool @isLocked, DateTime @lockTime, DateTime @activeTime, string @hotPhoneLine, string @belongServiceName, string @qQNumber, int @fromUserID, int @fromCompanyID, int @relationID, string @deviceType, string @deviceId, string @openID, string @aPPWxOpenID, string @aPPQQOpenID, string @aPPWeiBoUserID, string @payPassword, int @familyUserID, int @parentUserID, DateTime @birthday, bool @isAllowSysLogin, bool @isAllowAPPUserLogin, bool @isAllowAPPCustomerLogin, string @positionName, string @education, int @fixedPoint, int @departmentID, DateTime @fixedPointUpdateDate, int @userLevelID, bool @isAllowPhrase, string @summary, bool @firstChangeBirthday, string @aPPUserDeviceType, string @aPPUserDeviceID, string @aPPBusinessDeviceType, string @aPPBusinessDeviceID, string @serviceFrom, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[UserID] int,
	[LoginName] nvarchar(50),
	[Password] nvarchar(200),
	[PhoneNumber] nvarchar(20),
	[Email] nvarchar(50),
	[HeadImg] nvarchar(500),
	[NickName] nvarchar(50),
	[RealName] nvarchar(50),
	[Gender] nvarchar(20),
	[Type] nvarchar(20),
	[CreateTime] datetime,
	[IsLocked] bit,
	[LockTime] datetime,
	[ActiveTime] datetime,
	[HotPhoneLine] nvarchar(100),
	[BelongServiceName] nvarchar(100),
	[QQNumber] nvarchar(100),
	[FromUserID] int,
	[FromCompanyID] int,
	[RelationID] int,
	[DeviceType] nvarchar(50),
	[DeviceId] nvarchar(200),
	[OpenID] nvarchar(500),
	[APPWxOpenID] nvarchar(500),
	[APPQQOpenID] nvarchar(500),
	[APPWeiBoUserID] nvarchar(500),
	[PayPassword] nvarchar(200),
	[FamilyUserID] int,
	[ParentUserID] int,
	[Birthday] datetime,
	[IsAllowSysLogin] bit,
	[IsAllowAPPUserLogin] bit,
	[IsAllowAPPCustomerLogin] bit,
	[PositionName] nvarchar(200),
	[Education] nvarchar(200),
	[FixedPoint] int,
	[DepartmentID] int,
	[FixedPointUpdateDate] datetime,
	[UserLevelID] int,
	[IsAllowPhrase] bit,
	[Summary] ntext,
	[FirstChangeBirthday] bit,
	[APPUserDeviceType] nvarchar(50),
	[APPUserDeviceID] nvarchar(200),
	[APPBusinessDeviceType] nvarchar(50),
	[APPBusinessDeviceID] nvarchar(200),
	[ServiceFrom] nvarchar(100)
);

INSERT INTO [dbo].[User] (
	[User].[LoginName],
	[User].[Password],
	[User].[PhoneNumber],
	[User].[Email],
	[User].[HeadImg],
	[User].[NickName],
	[User].[RealName],
	[User].[Gender],
	[User].[Type],
	[User].[CreateTime],
	[User].[IsLocked],
	[User].[LockTime],
	[User].[ActiveTime],
	[User].[HotPhoneLine],
	[User].[BelongServiceName],
	[User].[QQNumber],
	[User].[FromUserID],
	[User].[FromCompanyID],
	[User].[RelationID],
	[User].[DeviceType],
	[User].[DeviceId],
	[User].[OpenID],
	[User].[APPWxOpenID],
	[User].[APPQQOpenID],
	[User].[APPWeiBoUserID],
	[User].[PayPassword],
	[User].[FamilyUserID],
	[User].[ParentUserID],
	[User].[Birthday],
	[User].[IsAllowSysLogin],
	[User].[IsAllowAPPUserLogin],
	[User].[IsAllowAPPCustomerLogin],
	[User].[PositionName],
	[User].[Education],
	[User].[FixedPoint],
	[User].[DepartmentID],
	[User].[FixedPointUpdateDate],
	[User].[UserLevelID],
	[User].[IsAllowPhrase],
	[User].[Summary],
	[User].[FirstChangeBirthday],
	[User].[APPUserDeviceType],
	[User].[APPUserDeviceID],
	[User].[APPBusinessDeviceType],
	[User].[APPBusinessDeviceID],
	[User].[ServiceFrom]
) 
output 
	INSERTED.[UserID],
	INSERTED.[LoginName],
	INSERTED.[Password],
	INSERTED.[PhoneNumber],
	INSERTED.[Email],
	INSERTED.[HeadImg],
	INSERTED.[NickName],
	INSERTED.[RealName],
	INSERTED.[Gender],
	INSERTED.[Type],
	INSERTED.[CreateTime],
	INSERTED.[IsLocked],
	INSERTED.[LockTime],
	INSERTED.[ActiveTime],
	INSERTED.[HotPhoneLine],
	INSERTED.[BelongServiceName],
	INSERTED.[QQNumber],
	INSERTED.[FromUserID],
	INSERTED.[FromCompanyID],
	INSERTED.[RelationID],
	INSERTED.[DeviceType],
	INSERTED.[DeviceId],
	INSERTED.[OpenID],
	INSERTED.[APPWxOpenID],
	INSERTED.[APPQQOpenID],
	INSERTED.[APPWeiBoUserID],
	INSERTED.[PayPassword],
	INSERTED.[FamilyUserID],
	INSERTED.[ParentUserID],
	INSERTED.[Birthday],
	INSERTED.[IsAllowSysLogin],
	INSERTED.[IsAllowAPPUserLogin],
	INSERTED.[IsAllowAPPCustomerLogin],
	INSERTED.[PositionName],
	INSERTED.[Education],
	INSERTED.[FixedPoint],
	INSERTED.[DepartmentID],
	INSERTED.[FixedPointUpdateDate],
	INSERTED.[UserLevelID],
	INSERTED.[IsAllowPhrase],
	INSERTED.[Summary],
	INSERTED.[FirstChangeBirthday],
	INSERTED.[APPUserDeviceType],
	INSERTED.[APPUserDeviceID],
	INSERTED.[APPBusinessDeviceType],
	INSERTED.[APPBusinessDeviceID],
	INSERTED.[ServiceFrom]
into @table
VALUES ( 
	@LoginName,
	@Password,
	@PhoneNumber,
	@Email,
	@HeadImg,
	@NickName,
	@RealName,
	@Gender,
	@Type,
	@CreateTime,
	@IsLocked,
	@LockTime,
	@ActiveTime,
	@HotPhoneLine,
	@BelongServiceName,
	@QQNumber,
	@FromUserID,
	@FromCompanyID,
	@RelationID,
	@DeviceType,
	@DeviceId,
	@OpenID,
	@APPWxOpenID,
	@APPQQOpenID,
	@APPWeiBoUserID,
	@PayPassword,
	@FamilyUserID,
	@ParentUserID,
	@Birthday,
	@IsAllowSysLogin,
	@IsAllowAPPUserLogin,
	@IsAllowAPPCustomerLogin,
	@PositionName,
	@Education,
	@FixedPoint,
	@DepartmentID,
	@FixedPointUpdateDate,
	@UserLevelID,
	@IsAllowPhrase,
	@Summary,
	@FirstChangeBirthday,
	@APPUserDeviceType,
	@APPUserDeviceID,
	@APPBusinessDeviceType,
	@APPBusinessDeviceID,
	@ServiceFrom 
); 

SELECT 
	[UserID],
	[LoginName],
	[Password],
	[PhoneNumber],
	[Email],
	[HeadImg],
	[NickName],
	[RealName],
	[Gender],
	[Type],
	[CreateTime],
	[IsLocked],
	[LockTime],
	[ActiveTime],
	[HotPhoneLine],
	[BelongServiceName],
	[QQNumber],
	[FromUserID],
	[FromCompanyID],
	[RelationID],
	[DeviceType],
	[DeviceId],
	[OpenID],
	[APPWxOpenID],
	[APPQQOpenID],
	[APPWeiBoUserID],
	[PayPassword],
	[FamilyUserID],
	[ParentUserID],
	[Birthday],
	[IsAllowSysLogin],
	[IsAllowAPPUserLogin],
	[IsAllowAPPCustomerLogin],
	[PositionName],
	[Education],
	[FixedPoint],
	[DepartmentID],
	[FixedPointUpdateDate],
	[UserLevelID],
	[IsAllowPhrase],
	[Summary],
	[FirstChangeBirthday],
	[APPUserDeviceType],
	[APPUserDeviceID],
	[APPBusinessDeviceType],
	[APPBusinessDeviceID],
	[ServiceFrom] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@LoginName", EntityBase.GetDatabaseValue(@loginName)));
			parameters.Add(new SqlParameter("@Password", EntityBase.GetDatabaseValue(@password)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@Email", EntityBase.GetDatabaseValue(@email)));
			parameters.Add(new SqlParameter("@HeadImg", EntityBase.GetDatabaseValue(@headImg)));
			parameters.Add(new SqlParameter("@NickName", EntityBase.GetDatabaseValue(@nickName)));
			parameters.Add(new SqlParameter("@RealName", EntityBase.GetDatabaseValue(@realName)));
			parameters.Add(new SqlParameter("@Gender", EntityBase.GetDatabaseValue(@gender)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@CreateTime", EntityBase.GetDatabaseValue(@createTime)));
			parameters.Add(new SqlParameter("@IsLocked", @isLocked));
			parameters.Add(new SqlParameter("@LockTime", EntityBase.GetDatabaseValue(@lockTime)));
			parameters.Add(new SqlParameter("@ActiveTime", EntityBase.GetDatabaseValue(@activeTime)));
			parameters.Add(new SqlParameter("@HotPhoneLine", EntityBase.GetDatabaseValue(@hotPhoneLine)));
			parameters.Add(new SqlParameter("@BelongServiceName", EntityBase.GetDatabaseValue(@belongServiceName)));
			parameters.Add(new SqlParameter("@QQNumber", EntityBase.GetDatabaseValue(@qQNumber)));
			parameters.Add(new SqlParameter("@FromUserID", EntityBase.GetDatabaseValue(@fromUserID)));
			parameters.Add(new SqlParameter("@FromCompanyID", EntityBase.GetDatabaseValue(@fromCompanyID)));
			parameters.Add(new SqlParameter("@RelationID", EntityBase.GetDatabaseValue(@relationID)));
			parameters.Add(new SqlParameter("@DeviceType", EntityBase.GetDatabaseValue(@deviceType)));
			parameters.Add(new SqlParameter("@DeviceId", EntityBase.GetDatabaseValue(@deviceId)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@APPWxOpenID", EntityBase.GetDatabaseValue(@aPPWxOpenID)));
			parameters.Add(new SqlParameter("@APPQQOpenID", EntityBase.GetDatabaseValue(@aPPQQOpenID)));
			parameters.Add(new SqlParameter("@APPWeiBoUserID", EntityBase.GetDatabaseValue(@aPPWeiBoUserID)));
			parameters.Add(new SqlParameter("@PayPassword", EntityBase.GetDatabaseValue(@payPassword)));
			parameters.Add(new SqlParameter("@FamilyUserID", EntityBase.GetDatabaseValue(@familyUserID)));
			parameters.Add(new SqlParameter("@ParentUserID", EntityBase.GetDatabaseValue(@parentUserID)));
			parameters.Add(new SqlParameter("@Birthday", EntityBase.GetDatabaseValue(@birthday)));
			parameters.Add(new SqlParameter("@IsAllowSysLogin", @isAllowSysLogin));
			parameters.Add(new SqlParameter("@IsAllowAPPUserLogin", @isAllowAPPUserLogin));
			parameters.Add(new SqlParameter("@IsAllowAPPCustomerLogin", @isAllowAPPCustomerLogin));
			parameters.Add(new SqlParameter("@PositionName", EntityBase.GetDatabaseValue(@positionName)));
			parameters.Add(new SqlParameter("@Education", EntityBase.GetDatabaseValue(@education)));
			parameters.Add(new SqlParameter("@FixedPoint", EntityBase.GetDatabaseValue(@fixedPoint)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@FixedPointUpdateDate", EntityBase.GetDatabaseValue(@fixedPointUpdateDate)));
			parameters.Add(new SqlParameter("@UserLevelID", EntityBase.GetDatabaseValue(@userLevelID)));
			parameters.Add(new SqlParameter("@IsAllowPhrase", @isAllowPhrase));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@FirstChangeBirthday", @firstChangeBirthday));
			parameters.Add(new SqlParameter("@APPUserDeviceType", EntityBase.GetDatabaseValue(@aPPUserDeviceType)));
			parameters.Add(new SqlParameter("@APPUserDeviceID", EntityBase.GetDatabaseValue(@aPPUserDeviceID)));
			parameters.Add(new SqlParameter("@APPBusinessDeviceType", EntityBase.GetDatabaseValue(@aPPBusinessDeviceType)));
			parameters.Add(new SqlParameter("@APPBusinessDeviceID", EntityBase.GetDatabaseValue(@aPPBusinessDeviceID)));
			parameters.Add(new SqlParameter("@ServiceFrom", EntityBase.GetDatabaseValue(@serviceFrom)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a User into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="loginName">loginName</param>
		/// <param name="password">password</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="email">email</param>
		/// <param name="headImg">headImg</param>
		/// <param name="nickName">nickName</param>
		/// <param name="realName">realName</param>
		/// <param name="gender">gender</param>
		/// <param name="type">type</param>
		/// <param name="createTime">createTime</param>
		/// <param name="isLocked">isLocked</param>
		/// <param name="lockTime">lockTime</param>
		/// <param name="activeTime">activeTime</param>
		/// <param name="hotPhoneLine">hotPhoneLine</param>
		/// <param name="belongServiceName">belongServiceName</param>
		/// <param name="qQNumber">qQNumber</param>
		/// <param name="fromUserID">fromUserID</param>
		/// <param name="fromCompanyID">fromCompanyID</param>
		/// <param name="relationID">relationID</param>
		/// <param name="deviceType">deviceType</param>
		/// <param name="deviceId">deviceId</param>
		/// <param name="openID">openID</param>
		/// <param name="aPPWxOpenID">aPPWxOpenID</param>
		/// <param name="aPPQQOpenID">aPPQQOpenID</param>
		/// <param name="aPPWeiBoUserID">aPPWeiBoUserID</param>
		/// <param name="payPassword">payPassword</param>
		/// <param name="familyUserID">familyUserID</param>
		/// <param name="parentUserID">parentUserID</param>
		/// <param name="birthday">birthday</param>
		/// <param name="isAllowSysLogin">isAllowSysLogin</param>
		/// <param name="isAllowAPPUserLogin">isAllowAPPUserLogin</param>
		/// <param name="isAllowAPPCustomerLogin">isAllowAPPCustomerLogin</param>
		/// <param name="positionName">positionName</param>
		/// <param name="education">education</param>
		/// <param name="fixedPoint">fixedPoint</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="fixedPointUpdateDate">fixedPointUpdateDate</param>
		/// <param name="userLevelID">userLevelID</param>
		/// <param name="isAllowPhrase">isAllowPhrase</param>
		/// <param name="summary">summary</param>
		/// <param name="firstChangeBirthday">firstChangeBirthday</param>
		/// <param name="aPPUserDeviceType">aPPUserDeviceType</param>
		/// <param name="aPPUserDeviceID">aPPUserDeviceID</param>
		/// <param name="aPPBusinessDeviceType">aPPBusinessDeviceType</param>
		/// <param name="aPPBusinessDeviceID">aPPBusinessDeviceID</param>
		/// <param name="serviceFrom">serviceFrom</param>
		public static void UpdateUser(int @userID, string @loginName, string @password, string @phoneNumber, string @email, string @headImg, string @nickName, string @realName, string @gender, string @type, DateTime @createTime, bool @isLocked, DateTime @lockTime, DateTime @activeTime, string @hotPhoneLine, string @belongServiceName, string @qQNumber, int @fromUserID, int @fromCompanyID, int @relationID, string @deviceType, string @deviceId, string @openID, string @aPPWxOpenID, string @aPPQQOpenID, string @aPPWeiBoUserID, string @payPassword, int @familyUserID, int @parentUserID, DateTime @birthday, bool @isAllowSysLogin, bool @isAllowAPPUserLogin, bool @isAllowAPPCustomerLogin, string @positionName, string @education, int @fixedPoint, int @departmentID, DateTime @fixedPointUpdateDate, int @userLevelID, bool @isAllowPhrase, string @summary, bool @firstChangeBirthday, string @aPPUserDeviceType, string @aPPUserDeviceID, string @aPPBusinessDeviceType, string @aPPBusinessDeviceID, string @serviceFrom)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateUser(@userID, @loginName, @password, @phoneNumber, @email, @headImg, @nickName, @realName, @gender, @type, @createTime, @isLocked, @lockTime, @activeTime, @hotPhoneLine, @belongServiceName, @qQNumber, @fromUserID, @fromCompanyID, @relationID, @deviceType, @deviceId, @openID, @aPPWxOpenID, @aPPQQOpenID, @aPPWeiBoUserID, @payPassword, @familyUserID, @parentUserID, @birthday, @isAllowSysLogin, @isAllowAPPUserLogin, @isAllowAPPCustomerLogin, @positionName, @education, @fixedPoint, @departmentID, @fixedPointUpdateDate, @userLevelID, @isAllowPhrase, @summary, @firstChangeBirthday, @aPPUserDeviceType, @aPPUserDeviceID, @aPPBusinessDeviceType, @aPPBusinessDeviceID, @serviceFrom, helper);
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
		/// Updates a User into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="loginName">loginName</param>
		/// <param name="password">password</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="email">email</param>
		/// <param name="headImg">headImg</param>
		/// <param name="nickName">nickName</param>
		/// <param name="realName">realName</param>
		/// <param name="gender">gender</param>
		/// <param name="type">type</param>
		/// <param name="createTime">createTime</param>
		/// <param name="isLocked">isLocked</param>
		/// <param name="lockTime">lockTime</param>
		/// <param name="activeTime">activeTime</param>
		/// <param name="hotPhoneLine">hotPhoneLine</param>
		/// <param name="belongServiceName">belongServiceName</param>
		/// <param name="qQNumber">qQNumber</param>
		/// <param name="fromUserID">fromUserID</param>
		/// <param name="fromCompanyID">fromCompanyID</param>
		/// <param name="relationID">relationID</param>
		/// <param name="deviceType">deviceType</param>
		/// <param name="deviceId">deviceId</param>
		/// <param name="openID">openID</param>
		/// <param name="aPPWxOpenID">aPPWxOpenID</param>
		/// <param name="aPPQQOpenID">aPPQQOpenID</param>
		/// <param name="aPPWeiBoUserID">aPPWeiBoUserID</param>
		/// <param name="payPassword">payPassword</param>
		/// <param name="familyUserID">familyUserID</param>
		/// <param name="parentUserID">parentUserID</param>
		/// <param name="birthday">birthday</param>
		/// <param name="isAllowSysLogin">isAllowSysLogin</param>
		/// <param name="isAllowAPPUserLogin">isAllowAPPUserLogin</param>
		/// <param name="isAllowAPPCustomerLogin">isAllowAPPCustomerLogin</param>
		/// <param name="positionName">positionName</param>
		/// <param name="education">education</param>
		/// <param name="fixedPoint">fixedPoint</param>
		/// <param name="departmentID">departmentID</param>
		/// <param name="fixedPointUpdateDate">fixedPointUpdateDate</param>
		/// <param name="userLevelID">userLevelID</param>
		/// <param name="isAllowPhrase">isAllowPhrase</param>
		/// <param name="summary">summary</param>
		/// <param name="firstChangeBirthday">firstChangeBirthday</param>
		/// <param name="aPPUserDeviceType">aPPUserDeviceType</param>
		/// <param name="aPPUserDeviceID">aPPUserDeviceID</param>
		/// <param name="aPPBusinessDeviceType">aPPBusinessDeviceType</param>
		/// <param name="aPPBusinessDeviceID">aPPBusinessDeviceID</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="helper">helper</param>
		internal static void UpdateUser(int @userID, string @loginName, string @password, string @phoneNumber, string @email, string @headImg, string @nickName, string @realName, string @gender, string @type, DateTime @createTime, bool @isLocked, DateTime @lockTime, DateTime @activeTime, string @hotPhoneLine, string @belongServiceName, string @qQNumber, int @fromUserID, int @fromCompanyID, int @relationID, string @deviceType, string @deviceId, string @openID, string @aPPWxOpenID, string @aPPQQOpenID, string @aPPWeiBoUserID, string @payPassword, int @familyUserID, int @parentUserID, DateTime @birthday, bool @isAllowSysLogin, bool @isAllowAPPUserLogin, bool @isAllowAPPCustomerLogin, string @positionName, string @education, int @fixedPoint, int @departmentID, DateTime @fixedPointUpdateDate, int @userLevelID, bool @isAllowPhrase, string @summary, bool @firstChangeBirthday, string @aPPUserDeviceType, string @aPPUserDeviceID, string @aPPBusinessDeviceType, string @aPPBusinessDeviceID, string @serviceFrom, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[UserID] int,
	[LoginName] nvarchar(50),
	[Password] nvarchar(200),
	[PhoneNumber] nvarchar(20),
	[Email] nvarchar(50),
	[HeadImg] nvarchar(500),
	[NickName] nvarchar(50),
	[RealName] nvarchar(50),
	[Gender] nvarchar(20),
	[Type] nvarchar(20),
	[CreateTime] datetime,
	[IsLocked] bit,
	[LockTime] datetime,
	[ActiveTime] datetime,
	[HotPhoneLine] nvarchar(100),
	[BelongServiceName] nvarchar(100),
	[QQNumber] nvarchar(100),
	[FromUserID] int,
	[FromCompanyID] int,
	[RelationID] int,
	[DeviceType] nvarchar(50),
	[DeviceId] nvarchar(200),
	[OpenID] nvarchar(500),
	[APPWxOpenID] nvarchar(500),
	[APPQQOpenID] nvarchar(500),
	[APPWeiBoUserID] nvarchar(500),
	[PayPassword] nvarchar(200),
	[FamilyUserID] int,
	[ParentUserID] int,
	[Birthday] datetime,
	[IsAllowSysLogin] bit,
	[IsAllowAPPUserLogin] bit,
	[IsAllowAPPCustomerLogin] bit,
	[PositionName] nvarchar(200),
	[Education] nvarchar(200),
	[FixedPoint] int,
	[DepartmentID] int,
	[FixedPointUpdateDate] datetime,
	[UserLevelID] int,
	[IsAllowPhrase] bit,
	[Summary] ntext,
	[FirstChangeBirthday] bit,
	[APPUserDeviceType] nvarchar(50),
	[APPUserDeviceID] nvarchar(200),
	[APPBusinessDeviceType] nvarchar(50),
	[APPBusinessDeviceID] nvarchar(200),
	[ServiceFrom] nvarchar(100)
);

UPDATE [dbo].[User] SET 
	[User].[LoginName] = @LoginName,
	[User].[Password] = @Password,
	[User].[PhoneNumber] = @PhoneNumber,
	[User].[Email] = @Email,
	[User].[HeadImg] = @HeadImg,
	[User].[NickName] = @NickName,
	[User].[RealName] = @RealName,
	[User].[Gender] = @Gender,
	[User].[Type] = @Type,
	[User].[CreateTime] = @CreateTime,
	[User].[IsLocked] = @IsLocked,
	[User].[LockTime] = @LockTime,
	[User].[ActiveTime] = @ActiveTime,
	[User].[HotPhoneLine] = @HotPhoneLine,
	[User].[BelongServiceName] = @BelongServiceName,
	[User].[QQNumber] = @QQNumber,
	[User].[FromUserID] = @FromUserID,
	[User].[FromCompanyID] = @FromCompanyID,
	[User].[RelationID] = @RelationID,
	[User].[DeviceType] = @DeviceType,
	[User].[DeviceId] = @DeviceId,
	[User].[OpenID] = @OpenID,
	[User].[APPWxOpenID] = @APPWxOpenID,
	[User].[APPQQOpenID] = @APPQQOpenID,
	[User].[APPWeiBoUserID] = @APPWeiBoUserID,
	[User].[PayPassword] = @PayPassword,
	[User].[FamilyUserID] = @FamilyUserID,
	[User].[ParentUserID] = @ParentUserID,
	[User].[Birthday] = @Birthday,
	[User].[IsAllowSysLogin] = @IsAllowSysLogin,
	[User].[IsAllowAPPUserLogin] = @IsAllowAPPUserLogin,
	[User].[IsAllowAPPCustomerLogin] = @IsAllowAPPCustomerLogin,
	[User].[PositionName] = @PositionName,
	[User].[Education] = @Education,
	[User].[FixedPoint] = @FixedPoint,
	[User].[DepartmentID] = @DepartmentID,
	[User].[FixedPointUpdateDate] = @FixedPointUpdateDate,
	[User].[UserLevelID] = @UserLevelID,
	[User].[IsAllowPhrase] = @IsAllowPhrase,
	[User].[Summary] = @Summary,
	[User].[FirstChangeBirthday] = @FirstChangeBirthday,
	[User].[APPUserDeviceType] = @APPUserDeviceType,
	[User].[APPUserDeviceID] = @APPUserDeviceID,
	[User].[APPBusinessDeviceType] = @APPBusinessDeviceType,
	[User].[APPBusinessDeviceID] = @APPBusinessDeviceID,
	[User].[ServiceFrom] = @ServiceFrom 
output 
	INSERTED.[UserID],
	INSERTED.[LoginName],
	INSERTED.[Password],
	INSERTED.[PhoneNumber],
	INSERTED.[Email],
	INSERTED.[HeadImg],
	INSERTED.[NickName],
	INSERTED.[RealName],
	INSERTED.[Gender],
	INSERTED.[Type],
	INSERTED.[CreateTime],
	INSERTED.[IsLocked],
	INSERTED.[LockTime],
	INSERTED.[ActiveTime],
	INSERTED.[HotPhoneLine],
	INSERTED.[BelongServiceName],
	INSERTED.[QQNumber],
	INSERTED.[FromUserID],
	INSERTED.[FromCompanyID],
	INSERTED.[RelationID],
	INSERTED.[DeviceType],
	INSERTED.[DeviceId],
	INSERTED.[OpenID],
	INSERTED.[APPWxOpenID],
	INSERTED.[APPQQOpenID],
	INSERTED.[APPWeiBoUserID],
	INSERTED.[PayPassword],
	INSERTED.[FamilyUserID],
	INSERTED.[ParentUserID],
	INSERTED.[Birthday],
	INSERTED.[IsAllowSysLogin],
	INSERTED.[IsAllowAPPUserLogin],
	INSERTED.[IsAllowAPPCustomerLogin],
	INSERTED.[PositionName],
	INSERTED.[Education],
	INSERTED.[FixedPoint],
	INSERTED.[DepartmentID],
	INSERTED.[FixedPointUpdateDate],
	INSERTED.[UserLevelID],
	INSERTED.[IsAllowPhrase],
	INSERTED.[Summary],
	INSERTED.[FirstChangeBirthday],
	INSERTED.[APPUserDeviceType],
	INSERTED.[APPUserDeviceID],
	INSERTED.[APPBusinessDeviceType],
	INSERTED.[APPBusinessDeviceID],
	INSERTED.[ServiceFrom]
into @table
WHERE 
	[User].[UserID] = @UserID

SELECT 
	[UserID],
	[LoginName],
	[Password],
	[PhoneNumber],
	[Email],
	[HeadImg],
	[NickName],
	[RealName],
	[Gender],
	[Type],
	[CreateTime],
	[IsLocked],
	[LockTime],
	[ActiveTime],
	[HotPhoneLine],
	[BelongServiceName],
	[QQNumber],
	[FromUserID],
	[FromCompanyID],
	[RelationID],
	[DeviceType],
	[DeviceId],
	[OpenID],
	[APPWxOpenID],
	[APPQQOpenID],
	[APPWeiBoUserID],
	[PayPassword],
	[FamilyUserID],
	[ParentUserID],
	[Birthday],
	[IsAllowSysLogin],
	[IsAllowAPPUserLogin],
	[IsAllowAPPCustomerLogin],
	[PositionName],
	[Education],
	[FixedPoint],
	[DepartmentID],
	[FixedPointUpdateDate],
	[UserLevelID],
	[IsAllowPhrase],
	[Summary],
	[FirstChangeBirthday],
	[APPUserDeviceType],
	[APPUserDeviceID],
	[APPBusinessDeviceType],
	[APPBusinessDeviceID],
	[ServiceFrom] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@LoginName", EntityBase.GetDatabaseValue(@loginName)));
			parameters.Add(new SqlParameter("@Password", EntityBase.GetDatabaseValue(@password)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@Email", EntityBase.GetDatabaseValue(@email)));
			parameters.Add(new SqlParameter("@HeadImg", EntityBase.GetDatabaseValue(@headImg)));
			parameters.Add(new SqlParameter("@NickName", EntityBase.GetDatabaseValue(@nickName)));
			parameters.Add(new SqlParameter("@RealName", EntityBase.GetDatabaseValue(@realName)));
			parameters.Add(new SqlParameter("@Gender", EntityBase.GetDatabaseValue(@gender)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			parameters.Add(new SqlParameter("@CreateTime", EntityBase.GetDatabaseValue(@createTime)));
			parameters.Add(new SqlParameter("@IsLocked", @isLocked));
			parameters.Add(new SqlParameter("@LockTime", EntityBase.GetDatabaseValue(@lockTime)));
			parameters.Add(new SqlParameter("@ActiveTime", EntityBase.GetDatabaseValue(@activeTime)));
			parameters.Add(new SqlParameter("@HotPhoneLine", EntityBase.GetDatabaseValue(@hotPhoneLine)));
			parameters.Add(new SqlParameter("@BelongServiceName", EntityBase.GetDatabaseValue(@belongServiceName)));
			parameters.Add(new SqlParameter("@QQNumber", EntityBase.GetDatabaseValue(@qQNumber)));
			parameters.Add(new SqlParameter("@FromUserID", EntityBase.GetDatabaseValue(@fromUserID)));
			parameters.Add(new SqlParameter("@FromCompanyID", EntityBase.GetDatabaseValue(@fromCompanyID)));
			parameters.Add(new SqlParameter("@RelationID", EntityBase.GetDatabaseValue(@relationID)));
			parameters.Add(new SqlParameter("@DeviceType", EntityBase.GetDatabaseValue(@deviceType)));
			parameters.Add(new SqlParameter("@DeviceId", EntityBase.GetDatabaseValue(@deviceId)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@APPWxOpenID", EntityBase.GetDatabaseValue(@aPPWxOpenID)));
			parameters.Add(new SqlParameter("@APPQQOpenID", EntityBase.GetDatabaseValue(@aPPQQOpenID)));
			parameters.Add(new SqlParameter("@APPWeiBoUserID", EntityBase.GetDatabaseValue(@aPPWeiBoUserID)));
			parameters.Add(new SqlParameter("@PayPassword", EntityBase.GetDatabaseValue(@payPassword)));
			parameters.Add(new SqlParameter("@FamilyUserID", EntityBase.GetDatabaseValue(@familyUserID)));
			parameters.Add(new SqlParameter("@ParentUserID", EntityBase.GetDatabaseValue(@parentUserID)));
			parameters.Add(new SqlParameter("@Birthday", EntityBase.GetDatabaseValue(@birthday)));
			parameters.Add(new SqlParameter("@IsAllowSysLogin", @isAllowSysLogin));
			parameters.Add(new SqlParameter("@IsAllowAPPUserLogin", @isAllowAPPUserLogin));
			parameters.Add(new SqlParameter("@IsAllowAPPCustomerLogin", @isAllowAPPCustomerLogin));
			parameters.Add(new SqlParameter("@PositionName", EntityBase.GetDatabaseValue(@positionName)));
			parameters.Add(new SqlParameter("@Education", EntityBase.GetDatabaseValue(@education)));
			parameters.Add(new SqlParameter("@FixedPoint", EntityBase.GetDatabaseValue(@fixedPoint)));
			parameters.Add(new SqlParameter("@DepartmentID", EntityBase.GetDatabaseValue(@departmentID)));
			parameters.Add(new SqlParameter("@FixedPointUpdateDate", EntityBase.GetDatabaseValue(@fixedPointUpdateDate)));
			parameters.Add(new SqlParameter("@UserLevelID", EntityBase.GetDatabaseValue(@userLevelID)));
			parameters.Add(new SqlParameter("@IsAllowPhrase", @isAllowPhrase));
			parameters.Add(new SqlParameter("@Summary", EntityBase.GetDatabaseValue(@summary)));
			parameters.Add(new SqlParameter("@FirstChangeBirthday", @firstChangeBirthday));
			parameters.Add(new SqlParameter("@APPUserDeviceType", EntityBase.GetDatabaseValue(@aPPUserDeviceType)));
			parameters.Add(new SqlParameter("@APPUserDeviceID", EntityBase.GetDatabaseValue(@aPPUserDeviceID)));
			parameters.Add(new SqlParameter("@APPBusinessDeviceType", EntityBase.GetDatabaseValue(@aPPBusinessDeviceType)));
			parameters.Add(new SqlParameter("@APPBusinessDeviceID", EntityBase.GetDatabaseValue(@aPPBusinessDeviceID)));
			parameters.Add(new SqlParameter("@ServiceFrom", EntityBase.GetDatabaseValue(@serviceFrom)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a User from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		public static void DeleteUser(int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteUser(@userID, helper);
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
		/// Deletes a User from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteUser(int @userID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[User]
WHERE 
	[User].[UserID] = @UserID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", @userID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new User object.
		/// </summary>
		/// <returns>The newly created User object.</returns>
		public static User CreateUser()
		{
			return InitializeNew<User>();
		}
		
		/// <summary>
		/// Retrieve information for a User by a User's unique identifier.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <returns>User</returns>
		public static User GetUser(int @userID)
		{
			string commandText = @"
SELECT 
" + User.SelectFieldList + @"
FROM [dbo].[User] 
WHERE 
	[User].[UserID] = @UserID " + User.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", @userID));
			
			return GetOne<User>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a User by a User's unique identifier.
		/// </summary>
		/// <param name="userID">userID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>User</returns>
		public static User GetUser(int @userID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + User.SelectFieldList + @"
FROM [dbo].[User] 
WHERE 
	[User].[UserID] = @UserID " + User.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", @userID));
			
			return GetOne<User>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection User objects.
		/// </summary>
		/// <returns>The retrieved collection of User objects.</returns>
		public static EntityList<User> GetUsers()
		{
			string commandText = @"
SELECT " + User.SelectFieldList + "FROM [dbo].[User] " + User.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<User>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection User objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of User objects.</returns>
        public static EntityList<User> GetUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<User>(SelectFieldList, "FROM [dbo].[User]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection User objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of User objects.</returns>
        public static EntityList<User> GetUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<User>(SelectFieldList, "FROM [dbo].[User]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection User objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of User objects.</returns>
		protected static EntityList<User> GetUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection User objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of User objects.</returns>
		protected static EntityList<User> GetUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUsers(string.Empty, where, parameters, User.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection User objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of User objects.</returns>
		protected static EntityList<User> GetUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetUsers(prefix, where, parameters, User.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection User objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of User objects.</returns>
		protected static EntityList<User> GetUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUsers(string.Empty, where, parameters, User.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection User objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of User objects.</returns>
		protected static EntityList<User> GetUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetUsers(prefix, where, parameters, User.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection User objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of User objects.</returns>
		protected static EntityList<User> GetUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + User.SelectFieldList + "FROM [dbo].[User] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<User>(reader);
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
        protected static EntityList<User> GetUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<User>(SelectFieldList, "FROM [dbo].[User] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of User objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetUserCount()
        {
            return GetUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of User objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[User] " + where;

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
		public static partial class User_Properties
		{
			public const string UserID = "UserID";
			public const string LoginName = "LoginName";
			public const string Password = "Password";
			public const string PhoneNumber = "PhoneNumber";
			public const string Email = "Email";
			public const string HeadImg = "HeadImg";
			public const string NickName = "NickName";
			public const string RealName = "RealName";
			public const string Gender = "Gender";
			public const string Type = "Type";
			public const string CreateTime = "CreateTime";
			public const string IsLocked = "IsLocked";
			public const string LockTime = "LockTime";
			public const string ActiveTime = "ActiveTime";
			public const string HotPhoneLine = "HotPhoneLine";
			public const string BelongServiceName = "BelongServiceName";
			public const string QQNumber = "QQNumber";
			public const string FromUserID = "FromUserID";
			public const string FromCompanyID = "FromCompanyID";
			public const string RelationID = "RelationID";
			public const string DeviceType = "DeviceType";
			public const string DeviceId = "DeviceId";
			public const string OpenID = "OpenID";
			public const string APPWxOpenID = "APPWxOpenID";
			public const string APPQQOpenID = "APPQQOpenID";
			public const string APPWeiBoUserID = "APPWeiBoUserID";
			public const string PayPassword = "PayPassword";
			public const string FamilyUserID = "FamilyUserID";
			public const string ParentUserID = "ParentUserID";
			public const string Birthday = "Birthday";
			public const string IsAllowSysLogin = "IsAllowSysLogin";
			public const string IsAllowAPPUserLogin = "IsAllowAPPUserLogin";
			public const string IsAllowAPPCustomerLogin = "IsAllowAPPCustomerLogin";
			public const string PositionName = "PositionName";
			public const string Education = "Education";
			public const string FixedPoint = "FixedPoint";
			public const string DepartmentID = "DepartmentID";
			public const string FixedPointUpdateDate = "FixedPointUpdateDate";
			public const string UserLevelID = "UserLevelID";
			public const string IsAllowPhrase = "IsAllowPhrase";
			public const string Summary = "Summary";
			public const string FirstChangeBirthday = "FirstChangeBirthday";
			public const string APPUserDeviceType = "APPUserDeviceType";
			public const string APPUserDeviceID = "APPUserDeviceID";
			public const string APPBusinessDeviceType = "APPBusinessDeviceType";
			public const string APPBusinessDeviceID = "APPBusinessDeviceID";
			public const string ServiceFrom = "ServiceFrom";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"UserID" , "int:"},
    			 {"LoginName" , "string:"},
    			 {"Password" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"Email" , "string:"},
    			 {"HeadImg" , "string:"},
    			 {"NickName" , "string:"},
    			 {"RealName" , "string:"},
    			 {"Gender" , "string:"},
    			 {"Type" , "string:"},
    			 {"CreateTime" , "DateTime:"},
    			 {"IsLocked" , "bool:"},
    			 {"LockTime" , "DateTime:"},
    			 {"ActiveTime" , "DateTime:"},
    			 {"HotPhoneLine" , "string:"},
    			 {"BelongServiceName" , "string:"},
    			 {"QQNumber" , "string:"},
    			 {"FromUserID" , "int:"},
    			 {"FromCompanyID" , "int:"},
    			 {"RelationID" , "int:"},
    			 {"DeviceType" , "string:"},
    			 {"DeviceId" , "string:"},
    			 {"OpenID" , "string:"},
    			 {"APPWxOpenID" , "string:"},
    			 {"APPQQOpenID" , "string:"},
    			 {"APPWeiBoUserID" , "string:"},
    			 {"PayPassword" , "string:"},
    			 {"FamilyUserID" , "int:"},
    			 {"ParentUserID" , "int:"},
    			 {"Birthday" , "DateTime:"},
    			 {"IsAllowSysLogin" , "bool:"},
    			 {"IsAllowAPPUserLogin" , "bool:"},
    			 {"IsAllowAPPCustomerLogin" , "bool:"},
    			 {"PositionName" , "string:"},
    			 {"Education" , "string:"},
    			 {"FixedPoint" , "int:"},
    			 {"DepartmentID" , "int:"},
    			 {"FixedPointUpdateDate" , "DateTime:"},
    			 {"UserLevelID" , "int:"},
    			 {"IsAllowPhrase" , "bool:"},
    			 {"Summary" , "string:"},
    			 {"FirstChangeBirthday" , "bool:"},
    			 {"APPUserDeviceType" , "string:"},
    			 {"APPUserDeviceID" , "string:"},
    			 {"APPBusinessDeviceType" , "string:"},
    			 {"APPBusinessDeviceID" , "string:"},
    			 {"ServiceFrom" , "string:"},
            };
		}
		#endregion
	}
}
