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
	/// This object represents the properties and methods of a RoomPhoneRelation.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomPhoneRelation 
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
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int RoomID
		{
			[DebuggerStepThrough()]
			get { return this._roomID; }
			set 
			{
				if (this._roomID != value) 
				{
					this._roomID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relatePhoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelatePhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._relatePhoneNumber; }
			set 
			{
				if (this._relatePhoneNumber != value) 
				{
					this._relatePhoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelatePhoneNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationName
		{
			[DebuggerStepThrough()]
			get { return this._relationName; }
			set 
			{
				if (this._relationName != value) 
				{
					this._relationName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelationName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationIDCard = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationIDCard
		{
			[DebuggerStepThrough()]
			get { return this._relationIDCard; }
			set 
			{
				if (this._relationIDCard != value) 
				{
					this._relationIDCard = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelationIDCard");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDefault = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDefault
		{
			[DebuggerStepThrough()]
			get { return this._isDefault; }
			set 
			{
				if (this._isDefault != value) 
				{
					this._isDefault = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDefault");
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
		private string _relationType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationType
		{
			[DebuggerStepThrough()]
			get { return this._relationType; }
			set 
			{
				if (this._relationType != value) 
				{
					this._relationType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelationType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _iDCardType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int IDCardType
		{
			[DebuggerStepThrough()]
			get { return this._iDCardType; }
			set 
			{
				if (this._iDCardType != value) 
				{
					this._iDCardType = value;
					this.IsDirty = true;	
					OnPropertyChanged("IDCardType");
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
		private string _emailAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string EmailAddress
		{
			[DebuggerStepThrough()]
			get { return this._emailAddress; }
			set 
			{
				if (this._emailAddress != value) 
				{
					this._emailAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("EmailAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _homeAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HomeAddress
		{
			[DebuggerStepThrough()]
			get { return this._homeAddress; }
			set 
			{
				if (this._homeAddress != value) 
				{
					this._homeAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("HomeAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _officeAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OfficeAddress
		{
			[DebuggerStepThrough()]
			get { return this._officeAddress; }
			set 
			{
				if (this._officeAddress != value) 
				{
					this._officeAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("OfficeAddress");
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
		private string _customOne = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomOne
		{
			[DebuggerStepThrough()]
			get { return this._customOne; }
			set 
			{
				if (this._customOne != value) 
				{
					this._customOne = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomOne");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customTwo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomTwo
		{
			[DebuggerStepThrough()]
			get { return this._customTwo; }
			set 
			{
				if (this._customTwo != value) 
				{
					this._customTwo = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomTwo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customThree = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomThree
		{
			[DebuggerStepThrough()]
			get { return this._customThree; }
			set 
			{
				if (this._customThree != value) 
				{
					this._customThree = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomThree");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _customFour = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomFour
		{
			[DebuggerStepThrough()]
			get { return this._customFour; }
			set 
			{
				if (this._customFour != value) 
				{
					this._customFour = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomFour");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _contractStartTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ContractStartTime
		{
			[DebuggerStepThrough()]
			get { return this._contractStartTime; }
			set 
			{
				if (this._contractStartTime != value) 
				{
					this._contractStartTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractStartTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _contractEndTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ContractEndTime
		{
			[DebuggerStepThrough()]
			get { return this._contractEndTime; }
			set 
			{
				if (this._contractEndTime != value) 
				{
					this._contractEndTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractEndTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _brandInfo = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BrandInfo
		{
			[DebuggerStepThrough()]
			get { return this._brandInfo; }
			set 
			{
				if (this._brandInfo != value) 
				{
					this._brandInfo = value;
					this.IsDirty = true;	
					OnPropertyChanged("BrandInfo");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _contractNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ContractNote
		{
			[DebuggerStepThrough()]
			get { return this._contractNote; }
			set 
			{
				if (this._contractNote != value) 
				{
					this._contractNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractNote");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _relationProperty = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RelationProperty
		{
			[DebuggerStepThrough()]
			get { return this._relationProperty; }
			set 
			{
				if (this._relationProperty != value) 
				{
					this._relationProperty = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelationProperty");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isChargeFee = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsChargeFee
		{
			[DebuggerStepThrough()]
			get { return this._isChargeFee; }
			set 
			{
				if (this._isChargeFee != value) 
				{
					this._isChargeFee = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsChargeFee");
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
		private string _interesting = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Interesting
		{
			[DebuggerStepThrough()]
			get { return this._interesting; }
			set 
			{
				if (this._interesting != value) 
				{
					this._interesting = value;
					this.IsDirty = true;	
					OnPropertyChanged("Interesting");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _consumeMore = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ConsumeMore
		{
			[DebuggerStepThrough()]
			get { return this._consumeMore; }
			set 
			{
				if (this._consumeMore != value) 
				{
					this._consumeMore = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConsumeMore");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _belongTeam = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BelongTeam
		{
			[DebuggerStepThrough()]
			get { return this._belongTeam; }
			set 
			{
				if (this._belongTeam != value) 
				{
					this._belongTeam = value;
					this.IsDirty = true;	
					OnPropertyChanged("BelongTeam");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _oneCardNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OneCardNumber
		{
			[DebuggerStepThrough()]
			get { return this._oneCardNumber; }
			set 
			{
				if (this._oneCardNumber != value) 
				{
					this._oneCardNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("OneCardNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _chargeForMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ChargeForMan
		{
			[DebuggerStepThrough()]
			get { return this._chargeForMan; }
			set 
			{
				if (this._chargeForMan != value) 
				{
					this._chargeForMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeForMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isChargeMan = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsChargeMan
		{
			[DebuggerStepThrough()]
			get { return this._isChargeMan; }
			set 
			{
				if (this._isChargeMan != value) 
				{
					this._isChargeMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsChargeMan");
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
		private int _contractID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ContractID
		{
			[DebuggerStepThrough()]
			get { return this._contractID; }
			set 
			{
				if (this._contractID != value) 
				{
					this._contractID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ContractID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
	[RoomID] int,
	[RelatePhoneNumber] nvarchar(50),
	[RelationName] nvarchar(50),
	[RelationIDCard] nvarchar(50),
	[IsDefault] bit,
	[AddTime] datetime,
	[RelationType] nvarchar(50),
	[IDCardType] int,
	[Birthday] datetime,
	[EmailAddress] nvarchar(200),
	[HomeAddress] nvarchar(200),
	[OfficeAddress] nvarchar(200),
	[BankName] nvarchar(200),
	[BankAccountName] nvarchar(200),
	[BankAccountNo] nvarchar(200),
	[CustomOne] nvarchar(200),
	[CustomTwo] nvarchar(200),
	[CustomThree] nvarchar(200),
	[CustomFour] nvarchar(200),
	[Remark] ntext,
	[ContractStartTime] datetime,
	[ContractEndTime] datetime,
	[BrandInfo] ntext,
	[ContractNote] ntext,
	[RelationProperty] nvarchar(50),
	[IsChargeFee] bit,
	[HeadImg] nvarchar(500),
	[Interesting] nvarchar(200),
	[ConsumeMore] nvarchar(200),
	[BelongTeam] nvarchar(50),
	[OneCardNumber] nvarchar(50),
	[ChargeForMan] nvarchar(50),
	[IsChargeMan] bit,
	[CompanyName] nvarchar(100),
	[ContractID] int,
	[UserID] int,
	[TaxpayerNumber] nvarchar(200)
);

INSERT INTO [dbo].[RoomPhoneRelation] (
	[RoomPhoneRelation].[RoomID],
	[RoomPhoneRelation].[RelatePhoneNumber],
	[RoomPhoneRelation].[RelationName],
	[RoomPhoneRelation].[RelationIDCard],
	[RoomPhoneRelation].[IsDefault],
	[RoomPhoneRelation].[AddTime],
	[RoomPhoneRelation].[RelationType],
	[RoomPhoneRelation].[IDCardType],
	[RoomPhoneRelation].[Birthday],
	[RoomPhoneRelation].[EmailAddress],
	[RoomPhoneRelation].[HomeAddress],
	[RoomPhoneRelation].[OfficeAddress],
	[RoomPhoneRelation].[BankName],
	[RoomPhoneRelation].[BankAccountName],
	[RoomPhoneRelation].[BankAccountNo],
	[RoomPhoneRelation].[CustomOne],
	[RoomPhoneRelation].[CustomTwo],
	[RoomPhoneRelation].[CustomThree],
	[RoomPhoneRelation].[CustomFour],
	[RoomPhoneRelation].[Remark],
	[RoomPhoneRelation].[ContractStartTime],
	[RoomPhoneRelation].[ContractEndTime],
	[RoomPhoneRelation].[BrandInfo],
	[RoomPhoneRelation].[ContractNote],
	[RoomPhoneRelation].[RelationProperty],
	[RoomPhoneRelation].[IsChargeFee],
	[RoomPhoneRelation].[HeadImg],
	[RoomPhoneRelation].[Interesting],
	[RoomPhoneRelation].[ConsumeMore],
	[RoomPhoneRelation].[BelongTeam],
	[RoomPhoneRelation].[OneCardNumber],
	[RoomPhoneRelation].[ChargeForMan],
	[RoomPhoneRelation].[IsChargeMan],
	[RoomPhoneRelation].[CompanyName],
	[RoomPhoneRelation].[ContractID],
	[RoomPhoneRelation].[UserID],
	[RoomPhoneRelation].[TaxpayerNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RelatePhoneNumber],
	INSERTED.[RelationName],
	INSERTED.[RelationIDCard],
	INSERTED.[IsDefault],
	INSERTED.[AddTime],
	INSERTED.[RelationType],
	INSERTED.[IDCardType],
	INSERTED.[Birthday],
	INSERTED.[EmailAddress],
	INSERTED.[HomeAddress],
	INSERTED.[OfficeAddress],
	INSERTED.[BankName],
	INSERTED.[BankAccountName],
	INSERTED.[BankAccountNo],
	INSERTED.[CustomOne],
	INSERTED.[CustomTwo],
	INSERTED.[CustomThree],
	INSERTED.[CustomFour],
	INSERTED.[Remark],
	INSERTED.[ContractStartTime],
	INSERTED.[ContractEndTime],
	INSERTED.[BrandInfo],
	INSERTED.[ContractNote],
	INSERTED.[RelationProperty],
	INSERTED.[IsChargeFee],
	INSERTED.[HeadImg],
	INSERTED.[Interesting],
	INSERTED.[ConsumeMore],
	INSERTED.[BelongTeam],
	INSERTED.[OneCardNumber],
	INSERTED.[ChargeForMan],
	INSERTED.[IsChargeMan],
	INSERTED.[CompanyName],
	INSERTED.[ContractID],
	INSERTED.[UserID],
	INSERTED.[TaxpayerNumber]
into @table
VALUES ( 
	@RoomID,
	@RelatePhoneNumber,
	@RelationName,
	@RelationIDCard,
	@IsDefault,
	@AddTime,
	@RelationType,
	@IDCardType,
	@Birthday,
	@EmailAddress,
	@HomeAddress,
	@OfficeAddress,
	@BankName,
	@BankAccountName,
	@BankAccountNo,
	@CustomOne,
	@CustomTwo,
	@CustomThree,
	@CustomFour,
	@Remark,
	@ContractStartTime,
	@ContractEndTime,
	@BrandInfo,
	@ContractNote,
	@RelationProperty,
	@IsChargeFee,
	@HeadImg,
	@Interesting,
	@ConsumeMore,
	@BelongTeam,
	@OneCardNumber,
	@ChargeForMan,
	@IsChargeMan,
	@CompanyName,
	@ContractID,
	@UserID,
	@TaxpayerNumber 
); 

SELECT 
	[ID],
	[RoomID],
	[RelatePhoneNumber],
	[RelationName],
	[RelationIDCard],
	[IsDefault],
	[AddTime],
	[RelationType],
	[IDCardType],
	[Birthday],
	[EmailAddress],
	[HomeAddress],
	[OfficeAddress],
	[BankName],
	[BankAccountName],
	[BankAccountNo],
	[CustomOne],
	[CustomTwo],
	[CustomThree],
	[CustomFour],
	[Remark],
	[ContractStartTime],
	[ContractEndTime],
	[BrandInfo],
	[ContractNote],
	[RelationProperty],
	[IsChargeFee],
	[HeadImg],
	[Interesting],
	[ConsumeMore],
	[BelongTeam],
	[OneCardNumber],
	[ChargeForMan],
	[IsChargeMan],
	[CompanyName],
	[ContractID],
	[UserID],
	[TaxpayerNumber] 
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
	[RoomID] int,
	[RelatePhoneNumber] nvarchar(50),
	[RelationName] nvarchar(50),
	[RelationIDCard] nvarchar(50),
	[IsDefault] bit,
	[AddTime] datetime,
	[RelationType] nvarchar(50),
	[IDCardType] int,
	[Birthday] datetime,
	[EmailAddress] nvarchar(200),
	[HomeAddress] nvarchar(200),
	[OfficeAddress] nvarchar(200),
	[BankName] nvarchar(200),
	[BankAccountName] nvarchar(200),
	[BankAccountNo] nvarchar(200),
	[CustomOne] nvarchar(200),
	[CustomTwo] nvarchar(200),
	[CustomThree] nvarchar(200),
	[CustomFour] nvarchar(200),
	[Remark] ntext,
	[ContractStartTime] datetime,
	[ContractEndTime] datetime,
	[BrandInfo] ntext,
	[ContractNote] ntext,
	[RelationProperty] nvarchar(50),
	[IsChargeFee] bit,
	[HeadImg] nvarchar(500),
	[Interesting] nvarchar(200),
	[ConsumeMore] nvarchar(200),
	[BelongTeam] nvarchar(50),
	[OneCardNumber] nvarchar(50),
	[ChargeForMan] nvarchar(50),
	[IsChargeMan] bit,
	[CompanyName] nvarchar(100),
	[ContractID] int,
	[UserID] int,
	[TaxpayerNumber] nvarchar(200)
);

UPDATE [dbo].[RoomPhoneRelation] SET 
	[RoomPhoneRelation].[RoomID] = @RoomID,
	[RoomPhoneRelation].[RelatePhoneNumber] = @RelatePhoneNumber,
	[RoomPhoneRelation].[RelationName] = @RelationName,
	[RoomPhoneRelation].[RelationIDCard] = @RelationIDCard,
	[RoomPhoneRelation].[IsDefault] = @IsDefault,
	[RoomPhoneRelation].[AddTime] = @AddTime,
	[RoomPhoneRelation].[RelationType] = @RelationType,
	[RoomPhoneRelation].[IDCardType] = @IDCardType,
	[RoomPhoneRelation].[Birthday] = @Birthday,
	[RoomPhoneRelation].[EmailAddress] = @EmailAddress,
	[RoomPhoneRelation].[HomeAddress] = @HomeAddress,
	[RoomPhoneRelation].[OfficeAddress] = @OfficeAddress,
	[RoomPhoneRelation].[BankName] = @BankName,
	[RoomPhoneRelation].[BankAccountName] = @BankAccountName,
	[RoomPhoneRelation].[BankAccountNo] = @BankAccountNo,
	[RoomPhoneRelation].[CustomOne] = @CustomOne,
	[RoomPhoneRelation].[CustomTwo] = @CustomTwo,
	[RoomPhoneRelation].[CustomThree] = @CustomThree,
	[RoomPhoneRelation].[CustomFour] = @CustomFour,
	[RoomPhoneRelation].[Remark] = @Remark,
	[RoomPhoneRelation].[ContractStartTime] = @ContractStartTime,
	[RoomPhoneRelation].[ContractEndTime] = @ContractEndTime,
	[RoomPhoneRelation].[BrandInfo] = @BrandInfo,
	[RoomPhoneRelation].[ContractNote] = @ContractNote,
	[RoomPhoneRelation].[RelationProperty] = @RelationProperty,
	[RoomPhoneRelation].[IsChargeFee] = @IsChargeFee,
	[RoomPhoneRelation].[HeadImg] = @HeadImg,
	[RoomPhoneRelation].[Interesting] = @Interesting,
	[RoomPhoneRelation].[ConsumeMore] = @ConsumeMore,
	[RoomPhoneRelation].[BelongTeam] = @BelongTeam,
	[RoomPhoneRelation].[OneCardNumber] = @OneCardNumber,
	[RoomPhoneRelation].[ChargeForMan] = @ChargeForMan,
	[RoomPhoneRelation].[IsChargeMan] = @IsChargeMan,
	[RoomPhoneRelation].[CompanyName] = @CompanyName,
	[RoomPhoneRelation].[ContractID] = @ContractID,
	[RoomPhoneRelation].[UserID] = @UserID,
	[RoomPhoneRelation].[TaxpayerNumber] = @TaxpayerNumber 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RelatePhoneNumber],
	INSERTED.[RelationName],
	INSERTED.[RelationIDCard],
	INSERTED.[IsDefault],
	INSERTED.[AddTime],
	INSERTED.[RelationType],
	INSERTED.[IDCardType],
	INSERTED.[Birthday],
	INSERTED.[EmailAddress],
	INSERTED.[HomeAddress],
	INSERTED.[OfficeAddress],
	INSERTED.[BankName],
	INSERTED.[BankAccountName],
	INSERTED.[BankAccountNo],
	INSERTED.[CustomOne],
	INSERTED.[CustomTwo],
	INSERTED.[CustomThree],
	INSERTED.[CustomFour],
	INSERTED.[Remark],
	INSERTED.[ContractStartTime],
	INSERTED.[ContractEndTime],
	INSERTED.[BrandInfo],
	INSERTED.[ContractNote],
	INSERTED.[RelationProperty],
	INSERTED.[IsChargeFee],
	INSERTED.[HeadImg],
	INSERTED.[Interesting],
	INSERTED.[ConsumeMore],
	INSERTED.[BelongTeam],
	INSERTED.[OneCardNumber],
	INSERTED.[ChargeForMan],
	INSERTED.[IsChargeMan],
	INSERTED.[CompanyName],
	INSERTED.[ContractID],
	INSERTED.[UserID],
	INSERTED.[TaxpayerNumber]
into @table
WHERE 
	[RoomPhoneRelation].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[RelatePhoneNumber],
	[RelationName],
	[RelationIDCard],
	[IsDefault],
	[AddTime],
	[RelationType],
	[IDCardType],
	[Birthday],
	[EmailAddress],
	[HomeAddress],
	[OfficeAddress],
	[BankName],
	[BankAccountName],
	[BankAccountNo],
	[CustomOne],
	[CustomTwo],
	[CustomThree],
	[CustomFour],
	[Remark],
	[ContractStartTime],
	[ContractEndTime],
	[BrandInfo],
	[ContractNote],
	[RelationProperty],
	[IsChargeFee],
	[HeadImg],
	[Interesting],
	[ConsumeMore],
	[BelongTeam],
	[OneCardNumber],
	[ChargeForMan],
	[IsChargeMan],
	[CompanyName],
	[ContractID],
	[UserID],
	[TaxpayerNumber] 
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
DELETE FROM [dbo].[RoomPhoneRelation]
WHERE 
	[RoomPhoneRelation].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomPhoneRelation() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomPhoneRelation(this.ID));
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
	[RoomPhoneRelation].[ID],
	[RoomPhoneRelation].[RoomID],
	[RoomPhoneRelation].[RelatePhoneNumber],
	[RoomPhoneRelation].[RelationName],
	[RoomPhoneRelation].[RelationIDCard],
	[RoomPhoneRelation].[IsDefault],
	[RoomPhoneRelation].[AddTime],
	[RoomPhoneRelation].[RelationType],
	[RoomPhoneRelation].[IDCardType],
	[RoomPhoneRelation].[Birthday],
	[RoomPhoneRelation].[EmailAddress],
	[RoomPhoneRelation].[HomeAddress],
	[RoomPhoneRelation].[OfficeAddress],
	[RoomPhoneRelation].[BankName],
	[RoomPhoneRelation].[BankAccountName],
	[RoomPhoneRelation].[BankAccountNo],
	[RoomPhoneRelation].[CustomOne],
	[RoomPhoneRelation].[CustomTwo],
	[RoomPhoneRelation].[CustomThree],
	[RoomPhoneRelation].[CustomFour],
	[RoomPhoneRelation].[Remark],
	[RoomPhoneRelation].[ContractStartTime],
	[RoomPhoneRelation].[ContractEndTime],
	[RoomPhoneRelation].[BrandInfo],
	[RoomPhoneRelation].[ContractNote],
	[RoomPhoneRelation].[RelationProperty],
	[RoomPhoneRelation].[IsChargeFee],
	[RoomPhoneRelation].[HeadImg],
	[RoomPhoneRelation].[Interesting],
	[RoomPhoneRelation].[ConsumeMore],
	[RoomPhoneRelation].[BelongTeam],
	[RoomPhoneRelation].[OneCardNumber],
	[RoomPhoneRelation].[ChargeForMan],
	[RoomPhoneRelation].[IsChargeMan],
	[RoomPhoneRelation].[CompanyName],
	[RoomPhoneRelation].[ContractID],
	[RoomPhoneRelation].[UserID],
	[RoomPhoneRelation].[TaxpayerNumber]
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
                return "RoomPhoneRelation";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomPhoneRelation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="relatePhoneNumber">relatePhoneNumber</param>
		/// <param name="relationName">relationName</param>
		/// <param name="relationIDCard">relationIDCard</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="addTime">addTime</param>
		/// <param name="relationType">relationType</param>
		/// <param name="iDCardType">iDCardType</param>
		/// <param name="birthday">birthday</param>
		/// <param name="emailAddress">emailAddress</param>
		/// <param name="homeAddress">homeAddress</param>
		/// <param name="officeAddress">officeAddress</param>
		/// <param name="bankName">bankName</param>
		/// <param name="bankAccountName">bankAccountName</param>
		/// <param name="bankAccountNo">bankAccountNo</param>
		/// <param name="customOne">customOne</param>
		/// <param name="customTwo">customTwo</param>
		/// <param name="customThree">customThree</param>
		/// <param name="customFour">customFour</param>
		/// <param name="remark">remark</param>
		/// <param name="contractStartTime">contractStartTime</param>
		/// <param name="contractEndTime">contractEndTime</param>
		/// <param name="brandInfo">brandInfo</param>
		/// <param name="contractNote">contractNote</param>
		/// <param name="relationProperty">relationProperty</param>
		/// <param name="isChargeFee">isChargeFee</param>
		/// <param name="headImg">headImg</param>
		/// <param name="interesting">interesting</param>
		/// <param name="consumeMore">consumeMore</param>
		/// <param name="belongTeam">belongTeam</param>
		/// <param name="oneCardNumber">oneCardNumber</param>
		/// <param name="chargeForMan">chargeForMan</param>
		/// <param name="isChargeMan">isChargeMan</param>
		/// <param name="companyName">companyName</param>
		/// <param name="contractID">contractID</param>
		/// <param name="userID">userID</param>
		/// <param name="taxpayerNumber">taxpayerNumber</param>
		public static void InsertRoomPhoneRelation(int @roomID, string @relatePhoneNumber, string @relationName, string @relationIDCard, bool @isDefault, DateTime @addTime, string @relationType, int @iDCardType, DateTime @birthday, string @emailAddress, string @homeAddress, string @officeAddress, string @bankName, string @bankAccountName, string @bankAccountNo, string @customOne, string @customTwo, string @customThree, string @customFour, string @remark, DateTime @contractStartTime, DateTime @contractEndTime, string @brandInfo, string @contractNote, string @relationProperty, bool @isChargeFee, string @headImg, string @interesting, string @consumeMore, string @belongTeam, string @oneCardNumber, string @chargeForMan, bool @isChargeMan, string @companyName, int @contractID, int @userID, string @taxpayerNumber)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomPhoneRelation(@roomID, @relatePhoneNumber, @relationName, @relationIDCard, @isDefault, @addTime, @relationType, @iDCardType, @birthday, @emailAddress, @homeAddress, @officeAddress, @bankName, @bankAccountName, @bankAccountNo, @customOne, @customTwo, @customThree, @customFour, @remark, @contractStartTime, @contractEndTime, @brandInfo, @contractNote, @relationProperty, @isChargeFee, @headImg, @interesting, @consumeMore, @belongTeam, @oneCardNumber, @chargeForMan, @isChargeMan, @companyName, @contractID, @userID, @taxpayerNumber, helper);
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
		/// Insert a RoomPhoneRelation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="relatePhoneNumber">relatePhoneNumber</param>
		/// <param name="relationName">relationName</param>
		/// <param name="relationIDCard">relationIDCard</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="addTime">addTime</param>
		/// <param name="relationType">relationType</param>
		/// <param name="iDCardType">iDCardType</param>
		/// <param name="birthday">birthday</param>
		/// <param name="emailAddress">emailAddress</param>
		/// <param name="homeAddress">homeAddress</param>
		/// <param name="officeAddress">officeAddress</param>
		/// <param name="bankName">bankName</param>
		/// <param name="bankAccountName">bankAccountName</param>
		/// <param name="bankAccountNo">bankAccountNo</param>
		/// <param name="customOne">customOne</param>
		/// <param name="customTwo">customTwo</param>
		/// <param name="customThree">customThree</param>
		/// <param name="customFour">customFour</param>
		/// <param name="remark">remark</param>
		/// <param name="contractStartTime">contractStartTime</param>
		/// <param name="contractEndTime">contractEndTime</param>
		/// <param name="brandInfo">brandInfo</param>
		/// <param name="contractNote">contractNote</param>
		/// <param name="relationProperty">relationProperty</param>
		/// <param name="isChargeFee">isChargeFee</param>
		/// <param name="headImg">headImg</param>
		/// <param name="interesting">interesting</param>
		/// <param name="consumeMore">consumeMore</param>
		/// <param name="belongTeam">belongTeam</param>
		/// <param name="oneCardNumber">oneCardNumber</param>
		/// <param name="chargeForMan">chargeForMan</param>
		/// <param name="isChargeMan">isChargeMan</param>
		/// <param name="companyName">companyName</param>
		/// <param name="contractID">contractID</param>
		/// <param name="userID">userID</param>
		/// <param name="taxpayerNumber">taxpayerNumber</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomPhoneRelation(int @roomID, string @relatePhoneNumber, string @relationName, string @relationIDCard, bool @isDefault, DateTime @addTime, string @relationType, int @iDCardType, DateTime @birthday, string @emailAddress, string @homeAddress, string @officeAddress, string @bankName, string @bankAccountName, string @bankAccountNo, string @customOne, string @customTwo, string @customThree, string @customFour, string @remark, DateTime @contractStartTime, DateTime @contractEndTime, string @brandInfo, string @contractNote, string @relationProperty, bool @isChargeFee, string @headImg, string @interesting, string @consumeMore, string @belongTeam, string @oneCardNumber, string @chargeForMan, bool @isChargeMan, string @companyName, int @contractID, int @userID, string @taxpayerNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[RelatePhoneNumber] nvarchar(50),
	[RelationName] nvarchar(50),
	[RelationIDCard] nvarchar(50),
	[IsDefault] bit,
	[AddTime] datetime,
	[RelationType] nvarchar(50),
	[IDCardType] int,
	[Birthday] datetime,
	[EmailAddress] nvarchar(200),
	[HomeAddress] nvarchar(200),
	[OfficeAddress] nvarchar(200),
	[BankName] nvarchar(200),
	[BankAccountName] nvarchar(200),
	[BankAccountNo] nvarchar(200),
	[CustomOne] nvarchar(200),
	[CustomTwo] nvarchar(200),
	[CustomThree] nvarchar(200),
	[CustomFour] nvarchar(200),
	[Remark] ntext,
	[ContractStartTime] datetime,
	[ContractEndTime] datetime,
	[BrandInfo] ntext,
	[ContractNote] ntext,
	[RelationProperty] nvarchar(50),
	[IsChargeFee] bit,
	[HeadImg] nvarchar(500),
	[Interesting] nvarchar(200),
	[ConsumeMore] nvarchar(200),
	[BelongTeam] nvarchar(50),
	[OneCardNumber] nvarchar(50),
	[ChargeForMan] nvarchar(50),
	[IsChargeMan] bit,
	[CompanyName] nvarchar(100),
	[ContractID] int,
	[UserID] int,
	[TaxpayerNumber] nvarchar(200)
);

INSERT INTO [dbo].[RoomPhoneRelation] (
	[RoomPhoneRelation].[RoomID],
	[RoomPhoneRelation].[RelatePhoneNumber],
	[RoomPhoneRelation].[RelationName],
	[RoomPhoneRelation].[RelationIDCard],
	[RoomPhoneRelation].[IsDefault],
	[RoomPhoneRelation].[AddTime],
	[RoomPhoneRelation].[RelationType],
	[RoomPhoneRelation].[IDCardType],
	[RoomPhoneRelation].[Birthday],
	[RoomPhoneRelation].[EmailAddress],
	[RoomPhoneRelation].[HomeAddress],
	[RoomPhoneRelation].[OfficeAddress],
	[RoomPhoneRelation].[BankName],
	[RoomPhoneRelation].[BankAccountName],
	[RoomPhoneRelation].[BankAccountNo],
	[RoomPhoneRelation].[CustomOne],
	[RoomPhoneRelation].[CustomTwo],
	[RoomPhoneRelation].[CustomThree],
	[RoomPhoneRelation].[CustomFour],
	[RoomPhoneRelation].[Remark],
	[RoomPhoneRelation].[ContractStartTime],
	[RoomPhoneRelation].[ContractEndTime],
	[RoomPhoneRelation].[BrandInfo],
	[RoomPhoneRelation].[ContractNote],
	[RoomPhoneRelation].[RelationProperty],
	[RoomPhoneRelation].[IsChargeFee],
	[RoomPhoneRelation].[HeadImg],
	[RoomPhoneRelation].[Interesting],
	[RoomPhoneRelation].[ConsumeMore],
	[RoomPhoneRelation].[BelongTeam],
	[RoomPhoneRelation].[OneCardNumber],
	[RoomPhoneRelation].[ChargeForMan],
	[RoomPhoneRelation].[IsChargeMan],
	[RoomPhoneRelation].[CompanyName],
	[RoomPhoneRelation].[ContractID],
	[RoomPhoneRelation].[UserID],
	[RoomPhoneRelation].[TaxpayerNumber]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RelatePhoneNumber],
	INSERTED.[RelationName],
	INSERTED.[RelationIDCard],
	INSERTED.[IsDefault],
	INSERTED.[AddTime],
	INSERTED.[RelationType],
	INSERTED.[IDCardType],
	INSERTED.[Birthday],
	INSERTED.[EmailAddress],
	INSERTED.[HomeAddress],
	INSERTED.[OfficeAddress],
	INSERTED.[BankName],
	INSERTED.[BankAccountName],
	INSERTED.[BankAccountNo],
	INSERTED.[CustomOne],
	INSERTED.[CustomTwo],
	INSERTED.[CustomThree],
	INSERTED.[CustomFour],
	INSERTED.[Remark],
	INSERTED.[ContractStartTime],
	INSERTED.[ContractEndTime],
	INSERTED.[BrandInfo],
	INSERTED.[ContractNote],
	INSERTED.[RelationProperty],
	INSERTED.[IsChargeFee],
	INSERTED.[HeadImg],
	INSERTED.[Interesting],
	INSERTED.[ConsumeMore],
	INSERTED.[BelongTeam],
	INSERTED.[OneCardNumber],
	INSERTED.[ChargeForMan],
	INSERTED.[IsChargeMan],
	INSERTED.[CompanyName],
	INSERTED.[ContractID],
	INSERTED.[UserID],
	INSERTED.[TaxpayerNumber]
into @table
VALUES ( 
	@RoomID,
	@RelatePhoneNumber,
	@RelationName,
	@RelationIDCard,
	@IsDefault,
	@AddTime,
	@RelationType,
	@IDCardType,
	@Birthday,
	@EmailAddress,
	@HomeAddress,
	@OfficeAddress,
	@BankName,
	@BankAccountName,
	@BankAccountNo,
	@CustomOne,
	@CustomTwo,
	@CustomThree,
	@CustomFour,
	@Remark,
	@ContractStartTime,
	@ContractEndTime,
	@BrandInfo,
	@ContractNote,
	@RelationProperty,
	@IsChargeFee,
	@HeadImg,
	@Interesting,
	@ConsumeMore,
	@BelongTeam,
	@OneCardNumber,
	@ChargeForMan,
	@IsChargeMan,
	@CompanyName,
	@ContractID,
	@UserID,
	@TaxpayerNumber 
); 

SELECT 
	[ID],
	[RoomID],
	[RelatePhoneNumber],
	[RelationName],
	[RelationIDCard],
	[IsDefault],
	[AddTime],
	[RelationType],
	[IDCardType],
	[Birthday],
	[EmailAddress],
	[HomeAddress],
	[OfficeAddress],
	[BankName],
	[BankAccountName],
	[BankAccountNo],
	[CustomOne],
	[CustomTwo],
	[CustomThree],
	[CustomFour],
	[Remark],
	[ContractStartTime],
	[ContractEndTime],
	[BrandInfo],
	[ContractNote],
	[RelationProperty],
	[IsChargeFee],
	[HeadImg],
	[Interesting],
	[ConsumeMore],
	[BelongTeam],
	[OneCardNumber],
	[ChargeForMan],
	[IsChargeMan],
	[CompanyName],
	[ContractID],
	[UserID],
	[TaxpayerNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RelatePhoneNumber", EntityBase.GetDatabaseValue(@relatePhoneNumber)));
			parameters.Add(new SqlParameter("@RelationName", EntityBase.GetDatabaseValue(@relationName)));
			parameters.Add(new SqlParameter("@RelationIDCard", EntityBase.GetDatabaseValue(@relationIDCard)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RelationType", EntityBase.GetDatabaseValue(@relationType)));
			parameters.Add(new SqlParameter("@IDCardType", EntityBase.GetDatabaseValue(@iDCardType)));
			parameters.Add(new SqlParameter("@Birthday", EntityBase.GetDatabaseValue(@birthday)));
			parameters.Add(new SqlParameter("@EmailAddress", EntityBase.GetDatabaseValue(@emailAddress)));
			parameters.Add(new SqlParameter("@HomeAddress", EntityBase.GetDatabaseValue(@homeAddress)));
			parameters.Add(new SqlParameter("@OfficeAddress", EntityBase.GetDatabaseValue(@officeAddress)));
			parameters.Add(new SqlParameter("@BankName", EntityBase.GetDatabaseValue(@bankName)));
			parameters.Add(new SqlParameter("@BankAccountName", EntityBase.GetDatabaseValue(@bankAccountName)));
			parameters.Add(new SqlParameter("@BankAccountNo", EntityBase.GetDatabaseValue(@bankAccountNo)));
			parameters.Add(new SqlParameter("@CustomOne", EntityBase.GetDatabaseValue(@customOne)));
			parameters.Add(new SqlParameter("@CustomTwo", EntityBase.GetDatabaseValue(@customTwo)));
			parameters.Add(new SqlParameter("@CustomThree", EntityBase.GetDatabaseValue(@customThree)));
			parameters.Add(new SqlParameter("@CustomFour", EntityBase.GetDatabaseValue(@customFour)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@ContractStartTime", EntityBase.GetDatabaseValue(@contractStartTime)));
			parameters.Add(new SqlParameter("@ContractEndTime", EntityBase.GetDatabaseValue(@contractEndTime)));
			parameters.Add(new SqlParameter("@BrandInfo", EntityBase.GetDatabaseValue(@brandInfo)));
			parameters.Add(new SqlParameter("@ContractNote", EntityBase.GetDatabaseValue(@contractNote)));
			parameters.Add(new SqlParameter("@RelationProperty", EntityBase.GetDatabaseValue(@relationProperty)));
			parameters.Add(new SqlParameter("@IsChargeFee", @isChargeFee));
			parameters.Add(new SqlParameter("@HeadImg", EntityBase.GetDatabaseValue(@headImg)));
			parameters.Add(new SqlParameter("@Interesting", EntityBase.GetDatabaseValue(@interesting)));
			parameters.Add(new SqlParameter("@ConsumeMore", EntityBase.GetDatabaseValue(@consumeMore)));
			parameters.Add(new SqlParameter("@BelongTeam", EntityBase.GetDatabaseValue(@belongTeam)));
			parameters.Add(new SqlParameter("@OneCardNumber", EntityBase.GetDatabaseValue(@oneCardNumber)));
			parameters.Add(new SqlParameter("@ChargeForMan", EntityBase.GetDatabaseValue(@chargeForMan)));
			parameters.Add(new SqlParameter("@IsChargeMan", @isChargeMan));
			parameters.Add(new SqlParameter("@CompanyName", EntityBase.GetDatabaseValue(@companyName)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@TaxpayerNumber", EntityBase.GetDatabaseValue(@taxpayerNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomPhoneRelation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="relatePhoneNumber">relatePhoneNumber</param>
		/// <param name="relationName">relationName</param>
		/// <param name="relationIDCard">relationIDCard</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="addTime">addTime</param>
		/// <param name="relationType">relationType</param>
		/// <param name="iDCardType">iDCardType</param>
		/// <param name="birthday">birthday</param>
		/// <param name="emailAddress">emailAddress</param>
		/// <param name="homeAddress">homeAddress</param>
		/// <param name="officeAddress">officeAddress</param>
		/// <param name="bankName">bankName</param>
		/// <param name="bankAccountName">bankAccountName</param>
		/// <param name="bankAccountNo">bankAccountNo</param>
		/// <param name="customOne">customOne</param>
		/// <param name="customTwo">customTwo</param>
		/// <param name="customThree">customThree</param>
		/// <param name="customFour">customFour</param>
		/// <param name="remark">remark</param>
		/// <param name="contractStartTime">contractStartTime</param>
		/// <param name="contractEndTime">contractEndTime</param>
		/// <param name="brandInfo">brandInfo</param>
		/// <param name="contractNote">contractNote</param>
		/// <param name="relationProperty">relationProperty</param>
		/// <param name="isChargeFee">isChargeFee</param>
		/// <param name="headImg">headImg</param>
		/// <param name="interesting">interesting</param>
		/// <param name="consumeMore">consumeMore</param>
		/// <param name="belongTeam">belongTeam</param>
		/// <param name="oneCardNumber">oneCardNumber</param>
		/// <param name="chargeForMan">chargeForMan</param>
		/// <param name="isChargeMan">isChargeMan</param>
		/// <param name="companyName">companyName</param>
		/// <param name="contractID">contractID</param>
		/// <param name="userID">userID</param>
		/// <param name="taxpayerNumber">taxpayerNumber</param>
		public static void UpdateRoomPhoneRelation(int @iD, int @roomID, string @relatePhoneNumber, string @relationName, string @relationIDCard, bool @isDefault, DateTime @addTime, string @relationType, int @iDCardType, DateTime @birthday, string @emailAddress, string @homeAddress, string @officeAddress, string @bankName, string @bankAccountName, string @bankAccountNo, string @customOne, string @customTwo, string @customThree, string @customFour, string @remark, DateTime @contractStartTime, DateTime @contractEndTime, string @brandInfo, string @contractNote, string @relationProperty, bool @isChargeFee, string @headImg, string @interesting, string @consumeMore, string @belongTeam, string @oneCardNumber, string @chargeForMan, bool @isChargeMan, string @companyName, int @contractID, int @userID, string @taxpayerNumber)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomPhoneRelation(@iD, @roomID, @relatePhoneNumber, @relationName, @relationIDCard, @isDefault, @addTime, @relationType, @iDCardType, @birthday, @emailAddress, @homeAddress, @officeAddress, @bankName, @bankAccountName, @bankAccountNo, @customOne, @customTwo, @customThree, @customFour, @remark, @contractStartTime, @contractEndTime, @brandInfo, @contractNote, @relationProperty, @isChargeFee, @headImg, @interesting, @consumeMore, @belongTeam, @oneCardNumber, @chargeForMan, @isChargeMan, @companyName, @contractID, @userID, @taxpayerNumber, helper);
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
		/// Updates a RoomPhoneRelation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="relatePhoneNumber">relatePhoneNumber</param>
		/// <param name="relationName">relationName</param>
		/// <param name="relationIDCard">relationIDCard</param>
		/// <param name="isDefault">isDefault</param>
		/// <param name="addTime">addTime</param>
		/// <param name="relationType">relationType</param>
		/// <param name="iDCardType">iDCardType</param>
		/// <param name="birthday">birthday</param>
		/// <param name="emailAddress">emailAddress</param>
		/// <param name="homeAddress">homeAddress</param>
		/// <param name="officeAddress">officeAddress</param>
		/// <param name="bankName">bankName</param>
		/// <param name="bankAccountName">bankAccountName</param>
		/// <param name="bankAccountNo">bankAccountNo</param>
		/// <param name="customOne">customOne</param>
		/// <param name="customTwo">customTwo</param>
		/// <param name="customThree">customThree</param>
		/// <param name="customFour">customFour</param>
		/// <param name="remark">remark</param>
		/// <param name="contractStartTime">contractStartTime</param>
		/// <param name="contractEndTime">contractEndTime</param>
		/// <param name="brandInfo">brandInfo</param>
		/// <param name="contractNote">contractNote</param>
		/// <param name="relationProperty">relationProperty</param>
		/// <param name="isChargeFee">isChargeFee</param>
		/// <param name="headImg">headImg</param>
		/// <param name="interesting">interesting</param>
		/// <param name="consumeMore">consumeMore</param>
		/// <param name="belongTeam">belongTeam</param>
		/// <param name="oneCardNumber">oneCardNumber</param>
		/// <param name="chargeForMan">chargeForMan</param>
		/// <param name="isChargeMan">isChargeMan</param>
		/// <param name="companyName">companyName</param>
		/// <param name="contractID">contractID</param>
		/// <param name="userID">userID</param>
		/// <param name="taxpayerNumber">taxpayerNumber</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomPhoneRelation(int @iD, int @roomID, string @relatePhoneNumber, string @relationName, string @relationIDCard, bool @isDefault, DateTime @addTime, string @relationType, int @iDCardType, DateTime @birthday, string @emailAddress, string @homeAddress, string @officeAddress, string @bankName, string @bankAccountName, string @bankAccountNo, string @customOne, string @customTwo, string @customThree, string @customFour, string @remark, DateTime @contractStartTime, DateTime @contractEndTime, string @brandInfo, string @contractNote, string @relationProperty, bool @isChargeFee, string @headImg, string @interesting, string @consumeMore, string @belongTeam, string @oneCardNumber, string @chargeForMan, bool @isChargeMan, string @companyName, int @contractID, int @userID, string @taxpayerNumber, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[RelatePhoneNumber] nvarchar(50),
	[RelationName] nvarchar(50),
	[RelationIDCard] nvarchar(50),
	[IsDefault] bit,
	[AddTime] datetime,
	[RelationType] nvarchar(50),
	[IDCardType] int,
	[Birthday] datetime,
	[EmailAddress] nvarchar(200),
	[HomeAddress] nvarchar(200),
	[OfficeAddress] nvarchar(200),
	[BankName] nvarchar(200),
	[BankAccountName] nvarchar(200),
	[BankAccountNo] nvarchar(200),
	[CustomOne] nvarchar(200),
	[CustomTwo] nvarchar(200),
	[CustomThree] nvarchar(200),
	[CustomFour] nvarchar(200),
	[Remark] ntext,
	[ContractStartTime] datetime,
	[ContractEndTime] datetime,
	[BrandInfo] ntext,
	[ContractNote] ntext,
	[RelationProperty] nvarchar(50),
	[IsChargeFee] bit,
	[HeadImg] nvarchar(500),
	[Interesting] nvarchar(200),
	[ConsumeMore] nvarchar(200),
	[BelongTeam] nvarchar(50),
	[OneCardNumber] nvarchar(50),
	[ChargeForMan] nvarchar(50),
	[IsChargeMan] bit,
	[CompanyName] nvarchar(100),
	[ContractID] int,
	[UserID] int,
	[TaxpayerNumber] nvarchar(200)
);

UPDATE [dbo].[RoomPhoneRelation] SET 
	[RoomPhoneRelation].[RoomID] = @RoomID,
	[RoomPhoneRelation].[RelatePhoneNumber] = @RelatePhoneNumber,
	[RoomPhoneRelation].[RelationName] = @RelationName,
	[RoomPhoneRelation].[RelationIDCard] = @RelationIDCard,
	[RoomPhoneRelation].[IsDefault] = @IsDefault,
	[RoomPhoneRelation].[AddTime] = @AddTime,
	[RoomPhoneRelation].[RelationType] = @RelationType,
	[RoomPhoneRelation].[IDCardType] = @IDCardType,
	[RoomPhoneRelation].[Birthday] = @Birthday,
	[RoomPhoneRelation].[EmailAddress] = @EmailAddress,
	[RoomPhoneRelation].[HomeAddress] = @HomeAddress,
	[RoomPhoneRelation].[OfficeAddress] = @OfficeAddress,
	[RoomPhoneRelation].[BankName] = @BankName,
	[RoomPhoneRelation].[BankAccountName] = @BankAccountName,
	[RoomPhoneRelation].[BankAccountNo] = @BankAccountNo,
	[RoomPhoneRelation].[CustomOne] = @CustomOne,
	[RoomPhoneRelation].[CustomTwo] = @CustomTwo,
	[RoomPhoneRelation].[CustomThree] = @CustomThree,
	[RoomPhoneRelation].[CustomFour] = @CustomFour,
	[RoomPhoneRelation].[Remark] = @Remark,
	[RoomPhoneRelation].[ContractStartTime] = @ContractStartTime,
	[RoomPhoneRelation].[ContractEndTime] = @ContractEndTime,
	[RoomPhoneRelation].[BrandInfo] = @BrandInfo,
	[RoomPhoneRelation].[ContractNote] = @ContractNote,
	[RoomPhoneRelation].[RelationProperty] = @RelationProperty,
	[RoomPhoneRelation].[IsChargeFee] = @IsChargeFee,
	[RoomPhoneRelation].[HeadImg] = @HeadImg,
	[RoomPhoneRelation].[Interesting] = @Interesting,
	[RoomPhoneRelation].[ConsumeMore] = @ConsumeMore,
	[RoomPhoneRelation].[BelongTeam] = @BelongTeam,
	[RoomPhoneRelation].[OneCardNumber] = @OneCardNumber,
	[RoomPhoneRelation].[ChargeForMan] = @ChargeForMan,
	[RoomPhoneRelation].[IsChargeMan] = @IsChargeMan,
	[RoomPhoneRelation].[CompanyName] = @CompanyName,
	[RoomPhoneRelation].[ContractID] = @ContractID,
	[RoomPhoneRelation].[UserID] = @UserID,
	[RoomPhoneRelation].[TaxpayerNumber] = @TaxpayerNumber 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[RelatePhoneNumber],
	INSERTED.[RelationName],
	INSERTED.[RelationIDCard],
	INSERTED.[IsDefault],
	INSERTED.[AddTime],
	INSERTED.[RelationType],
	INSERTED.[IDCardType],
	INSERTED.[Birthday],
	INSERTED.[EmailAddress],
	INSERTED.[HomeAddress],
	INSERTED.[OfficeAddress],
	INSERTED.[BankName],
	INSERTED.[BankAccountName],
	INSERTED.[BankAccountNo],
	INSERTED.[CustomOne],
	INSERTED.[CustomTwo],
	INSERTED.[CustomThree],
	INSERTED.[CustomFour],
	INSERTED.[Remark],
	INSERTED.[ContractStartTime],
	INSERTED.[ContractEndTime],
	INSERTED.[BrandInfo],
	INSERTED.[ContractNote],
	INSERTED.[RelationProperty],
	INSERTED.[IsChargeFee],
	INSERTED.[HeadImg],
	INSERTED.[Interesting],
	INSERTED.[ConsumeMore],
	INSERTED.[BelongTeam],
	INSERTED.[OneCardNumber],
	INSERTED.[ChargeForMan],
	INSERTED.[IsChargeMan],
	INSERTED.[CompanyName],
	INSERTED.[ContractID],
	INSERTED.[UserID],
	INSERTED.[TaxpayerNumber]
into @table
WHERE 
	[RoomPhoneRelation].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[RelatePhoneNumber],
	[RelationName],
	[RelationIDCard],
	[IsDefault],
	[AddTime],
	[RelationType],
	[IDCardType],
	[Birthday],
	[EmailAddress],
	[HomeAddress],
	[OfficeAddress],
	[BankName],
	[BankAccountName],
	[BankAccountNo],
	[CustomOne],
	[CustomTwo],
	[CustomThree],
	[CustomFour],
	[Remark],
	[ContractStartTime],
	[ContractEndTime],
	[BrandInfo],
	[ContractNote],
	[RelationProperty],
	[IsChargeFee],
	[HeadImg],
	[Interesting],
	[ConsumeMore],
	[BelongTeam],
	[OneCardNumber],
	[ChargeForMan],
	[IsChargeMan],
	[CompanyName],
	[ContractID],
	[UserID],
	[TaxpayerNumber] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@RelatePhoneNumber", EntityBase.GetDatabaseValue(@relatePhoneNumber)));
			parameters.Add(new SqlParameter("@RelationName", EntityBase.GetDatabaseValue(@relationName)));
			parameters.Add(new SqlParameter("@RelationIDCard", EntityBase.GetDatabaseValue(@relationIDCard)));
			parameters.Add(new SqlParameter("@IsDefault", @isDefault));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RelationType", EntityBase.GetDatabaseValue(@relationType)));
			parameters.Add(new SqlParameter("@IDCardType", EntityBase.GetDatabaseValue(@iDCardType)));
			parameters.Add(new SqlParameter("@Birthday", EntityBase.GetDatabaseValue(@birthday)));
			parameters.Add(new SqlParameter("@EmailAddress", EntityBase.GetDatabaseValue(@emailAddress)));
			parameters.Add(new SqlParameter("@HomeAddress", EntityBase.GetDatabaseValue(@homeAddress)));
			parameters.Add(new SqlParameter("@OfficeAddress", EntityBase.GetDatabaseValue(@officeAddress)));
			parameters.Add(new SqlParameter("@BankName", EntityBase.GetDatabaseValue(@bankName)));
			parameters.Add(new SqlParameter("@BankAccountName", EntityBase.GetDatabaseValue(@bankAccountName)));
			parameters.Add(new SqlParameter("@BankAccountNo", EntityBase.GetDatabaseValue(@bankAccountNo)));
			parameters.Add(new SqlParameter("@CustomOne", EntityBase.GetDatabaseValue(@customOne)));
			parameters.Add(new SqlParameter("@CustomTwo", EntityBase.GetDatabaseValue(@customTwo)));
			parameters.Add(new SqlParameter("@CustomThree", EntityBase.GetDatabaseValue(@customThree)));
			parameters.Add(new SqlParameter("@CustomFour", EntityBase.GetDatabaseValue(@customFour)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@ContractStartTime", EntityBase.GetDatabaseValue(@contractStartTime)));
			parameters.Add(new SqlParameter("@ContractEndTime", EntityBase.GetDatabaseValue(@contractEndTime)));
			parameters.Add(new SqlParameter("@BrandInfo", EntityBase.GetDatabaseValue(@brandInfo)));
			parameters.Add(new SqlParameter("@ContractNote", EntityBase.GetDatabaseValue(@contractNote)));
			parameters.Add(new SqlParameter("@RelationProperty", EntityBase.GetDatabaseValue(@relationProperty)));
			parameters.Add(new SqlParameter("@IsChargeFee", @isChargeFee));
			parameters.Add(new SqlParameter("@HeadImg", EntityBase.GetDatabaseValue(@headImg)));
			parameters.Add(new SqlParameter("@Interesting", EntityBase.GetDatabaseValue(@interesting)));
			parameters.Add(new SqlParameter("@ConsumeMore", EntityBase.GetDatabaseValue(@consumeMore)));
			parameters.Add(new SqlParameter("@BelongTeam", EntityBase.GetDatabaseValue(@belongTeam)));
			parameters.Add(new SqlParameter("@OneCardNumber", EntityBase.GetDatabaseValue(@oneCardNumber)));
			parameters.Add(new SqlParameter("@ChargeForMan", EntityBase.GetDatabaseValue(@chargeForMan)));
			parameters.Add(new SqlParameter("@IsChargeMan", @isChargeMan));
			parameters.Add(new SqlParameter("@CompanyName", EntityBase.GetDatabaseValue(@companyName)));
			parameters.Add(new SqlParameter("@ContractID", EntityBase.GetDatabaseValue(@contractID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@TaxpayerNumber", EntityBase.GetDatabaseValue(@taxpayerNumber)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomPhoneRelation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomPhoneRelation(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomPhoneRelation(@iD, helper);
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
		/// Deletes a RoomPhoneRelation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomPhoneRelation(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomPhoneRelation]
WHERE 
	[RoomPhoneRelation].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomPhoneRelation object.
		/// </summary>
		/// <returns>The newly created RoomPhoneRelation object.</returns>
		public static RoomPhoneRelation CreateRoomPhoneRelation()
		{
			return InitializeNew<RoomPhoneRelation>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomPhoneRelation by a RoomPhoneRelation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomPhoneRelation</returns>
		public static RoomPhoneRelation GetRoomPhoneRelation(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomPhoneRelation.SelectFieldList + @"
FROM [dbo].[RoomPhoneRelation] 
WHERE 
	[RoomPhoneRelation].[ID] = @ID " + RoomPhoneRelation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomPhoneRelation>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomPhoneRelation by a RoomPhoneRelation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomPhoneRelation</returns>
		public static RoomPhoneRelation GetRoomPhoneRelation(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomPhoneRelation.SelectFieldList + @"
FROM [dbo].[RoomPhoneRelation] 
WHERE 
	[RoomPhoneRelation].[ID] = @ID " + RoomPhoneRelation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomPhoneRelation>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomPhoneRelation objects.</returns>
		public static EntityList<RoomPhoneRelation> GetRoomPhoneRelations()
		{
			string commandText = @"
SELECT " + RoomPhoneRelation.SelectFieldList + "FROM [dbo].[RoomPhoneRelation] " + RoomPhoneRelation.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomPhoneRelation>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomPhoneRelation objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomPhoneRelation objects.</returns>
        public static EntityList<RoomPhoneRelation> GetRoomPhoneRelations(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPhoneRelation>(SelectFieldList, "FROM [dbo].[RoomPhoneRelation]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomPhoneRelation objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomPhoneRelation objects.</returns>
        public static EntityList<RoomPhoneRelation> GetRoomPhoneRelations(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPhoneRelation>(SelectFieldList, "FROM [dbo].[RoomPhoneRelation]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomPhoneRelation objects.</returns>
		protected static EntityList<RoomPhoneRelation> GetRoomPhoneRelations(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPhoneRelations(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation objects.</returns>
		protected static EntityList<RoomPhoneRelation> GetRoomPhoneRelations(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPhoneRelations(string.Empty, where, parameters, RoomPhoneRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation objects.</returns>
		protected static EntityList<RoomPhoneRelation> GetRoomPhoneRelations(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomPhoneRelations(prefix, where, parameters, RoomPhoneRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation objects.</returns>
		protected static EntityList<RoomPhoneRelation> GetRoomPhoneRelations(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomPhoneRelations(string.Empty, where, parameters, RoomPhoneRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomPhoneRelation objects.</returns>
		protected static EntityList<RoomPhoneRelation> GetRoomPhoneRelations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomPhoneRelations(prefix, where, parameters, RoomPhoneRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomPhoneRelation objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomPhoneRelation objects.</returns>
		protected static EntityList<RoomPhoneRelation> GetRoomPhoneRelations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomPhoneRelation.SelectFieldList + "FROM [dbo].[RoomPhoneRelation] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomPhoneRelation>(reader);
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
        protected static EntityList<RoomPhoneRelation> GetRoomPhoneRelations(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomPhoneRelation>(SelectFieldList, "FROM [dbo].[RoomPhoneRelation] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomPhoneRelation objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomPhoneRelationCount()
        {
            return GetRoomPhoneRelationCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomPhoneRelation objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomPhoneRelationCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomPhoneRelation] " + where;

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
		public static partial class RoomPhoneRelation_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string RelatePhoneNumber = "RelatePhoneNumber";
			public const string RelationName = "RelationName";
			public const string RelationIDCard = "RelationIDCard";
			public const string IsDefault = "IsDefault";
			public const string AddTime = "AddTime";
			public const string RelationType = "RelationType";
			public const string IDCardType = "IDCardType";
			public const string Birthday = "Birthday";
			public const string EmailAddress = "EmailAddress";
			public const string HomeAddress = "HomeAddress";
			public const string OfficeAddress = "OfficeAddress";
			public const string BankName = "BankName";
			public const string BankAccountName = "BankAccountName";
			public const string BankAccountNo = "BankAccountNo";
			public const string CustomOne = "CustomOne";
			public const string CustomTwo = "CustomTwo";
			public const string CustomThree = "CustomThree";
			public const string CustomFour = "CustomFour";
			public const string Remark = "Remark";
			public const string ContractStartTime = "ContractStartTime";
			public const string ContractEndTime = "ContractEndTime";
			public const string BrandInfo = "BrandInfo";
			public const string ContractNote = "ContractNote";
			public const string RelationProperty = "RelationProperty";
			public const string IsChargeFee = "IsChargeFee";
			public const string HeadImg = "HeadImg";
			public const string Interesting = "Interesting";
			public const string ConsumeMore = "ConsumeMore";
			public const string BelongTeam = "BelongTeam";
			public const string OneCardNumber = "OneCardNumber";
			public const string ChargeForMan = "ChargeForMan";
			public const string IsChargeMan = "IsChargeMan";
			public const string CompanyName = "CompanyName";
			public const string ContractID = "ContractID";
			public const string UserID = "UserID";
			public const string TaxpayerNumber = "TaxpayerNumber";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"RelatePhoneNumber" , "string:"},
    			 {"RelationName" , "string:"},
    			 {"RelationIDCard" , "string:"},
    			 {"IsDefault" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"RelationType" , "string:"},
    			 {"IDCardType" , "int:"},
    			 {"Birthday" , "DateTime:"},
    			 {"EmailAddress" , "string:"},
    			 {"HomeAddress" , "string:"},
    			 {"OfficeAddress" , "string:"},
    			 {"BankName" , "string:"},
    			 {"BankAccountName" , "string:"},
    			 {"BankAccountNo" , "string:"},
    			 {"CustomOne" , "string:"},
    			 {"CustomTwo" , "string:"},
    			 {"CustomThree" , "string:"},
    			 {"CustomFour" , "string:"},
    			 {"Remark" , "string:"},
    			 {"ContractStartTime" , "DateTime:"},
    			 {"ContractEndTime" , "DateTime:"},
    			 {"BrandInfo" , "string:"},
    			 {"ContractNote" , "string:"},
    			 {"RelationProperty" , "string:"},
    			 {"IsChargeFee" , "bool:"},
    			 {"HeadImg" , "string:"},
    			 {"Interesting" , "string:"},
    			 {"ConsumeMore" , "string:"},
    			 {"BelongTeam" , "string:"},
    			 {"OneCardNumber" , "string:"},
    			 {"ChargeForMan" , "string:"},
    			 {"IsChargeMan" , "bool:"},
    			 {"CompanyName" , "string:"},
    			 {"ContractID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"TaxpayerNumber" , "string:"},
            };
		}
		#endregion
	}
}
