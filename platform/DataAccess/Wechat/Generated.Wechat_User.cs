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
	/// This object represents the properties and methods of a Wechat_User.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_User 
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
		private string _openId = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string OpenId
		{
			[DebuggerStepThrough()]
			get { return this._openId; }
			set 
			{
				if (this._openId != value) 
				{
					this._openId = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenId");
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
		private string _headImgUrl = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HeadImgUrl
		{
			[DebuggerStepThrough()]
			get { return this._headImgUrl; }
			set 
			{
				if (this._headImgUrl != value) 
				{
					this._headImgUrl = value;
					this.IsDirty = true;	
					OnPropertyChanged("HeadImgUrl");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sex = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Sex
		{
			[DebuggerStepThrough()]
			get { return this._sex; }
			set 
			{
				if (this._sex != value) 
				{
					this._sex = value;
					this.IsDirty = true;	
					OnPropertyChanged("Sex");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _city = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string City
		{
			[DebuggerStepThrough()]
			get { return this._city; }
			set 
			{
				if (this._city != value) 
				{
					this._city = value;
					this.IsDirty = true;	
					OnPropertyChanged("City");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _country = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Country
		{
			[DebuggerStepThrough()]
			get { return this._country; }
			set 
			{
				if (this._country != value) 
				{
					this._country = value;
					this.IsDirty = true;	
					OnPropertyChanged("Country");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _province = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Province
		{
			[DebuggerStepThrough()]
			get { return this._province; }
			set 
			{
				if (this._province != value) 
				{
					this._province = value;
					this.IsDirty = true;	
					OnPropertyChanged("Province");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _language = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Language
		{
			[DebuggerStepThrough()]
			get { return this._language; }
			set 
			{
				if (this._language != value) 
				{
					this._language = value;
					this.IsDirty = true;	
					OnPropertyChanged("Language");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _subScribe = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SubScribe
		{
			[DebuggerStepThrough()]
			get { return this._subScribe; }
			set 
			{
				if (this._subScribe != value) 
				{
					this._subScribe = value;
					this.IsDirty = true;	
					OnPropertyChanged("SubScribe");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _subscribeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SubscribeTime
		{
			[DebuggerStepThrough()]
			get { return this._subscribeTime; }
			set 
			{
				if (this._subscribeTime != value) 
				{
					this._subscribeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SubscribeTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _unSubscribeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime UnSubscribeTime
		{
			[DebuggerStepThrough()]
			get { return this._unSubscribeTime; }
			set 
			{
				if (this._unSubscribeTime != value) 
				{
					this._unSubscribeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("UnSubscribeTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastVisitTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LastVisitTime
		{
			[DebuggerStepThrough()]
			get { return this._lastVisitTime; }
			set 
			{
				if (this._lastVisitTime != value) 
				{
					this._lastVisitTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("LastVisitTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _visitCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VisitCount
		{
			[DebuggerStepThrough()]
			get { return this._visitCount; }
			set 
			{
				if (this._visitCount != value) 
				{
					this._visitCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("VisitCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fromOpenId = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FromOpenId
		{
			[DebuggerStepThrough()]
			get { return this._fromOpenId; }
			set 
			{
				if (this._fromOpenId != value) 
				{
					this._fromOpenId = value;
					this.IsDirty = true;	
					OnPropertyChanged("FromOpenId");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _firstSubScribeTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime FirstSubScribeTime
		{
			[DebuggerStepThrough()]
			get { return this._firstSubScribeTime; }
			set 
			{
				if (this._firstSubScribeTime != value) 
				{
					this._firstSubScribeTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("FirstSubScribeTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _fromQrID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FromQrID
		{
			[DebuggerStepThrough()]
			get { return this._fromQrID; }
			set 
			{
				if (this._fromQrID != value) 
				{
					this._fromQrID = value;
					this.IsDirty = true;	
					OnPropertyChanged("FromQrID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _currentProjectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CurrentProjectID
		{
			[DebuggerStepThrough()]
			get { return this._currentProjectID; }
			set 
			{
				if (this._currentProjectID != value) 
				{
					this._currentProjectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CurrentProjectID");
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
	[OpenId] nvarchar(255),
	[NickName] nvarchar(50),
	[HeadImgUrl] text,
	[Sex] int,
	[City] nvarchar(255),
	[Country] nvarchar(255),
	[Province] nvarchar(255),
	[Language] nvarchar(255),
	[SubScribe] int,
	[SubscribeTime] datetime,
	[UnSubscribeTime] datetime,
	[LastVisitTime] datetime,
	[VisitCount] int,
	[FromOpenId] nvarchar(255),
	[FirstSubScribeTime] datetime,
	[FromQrID] int,
	[CurrentProjectID] int
);

INSERT INTO [dbo].[Wechat_User] (
	[Wechat_User].[OpenId],
	[Wechat_User].[NickName],
	[Wechat_User].[HeadImgUrl],
	[Wechat_User].[Sex],
	[Wechat_User].[City],
	[Wechat_User].[Country],
	[Wechat_User].[Province],
	[Wechat_User].[Language],
	[Wechat_User].[SubScribe],
	[Wechat_User].[SubscribeTime],
	[Wechat_User].[UnSubscribeTime],
	[Wechat_User].[LastVisitTime],
	[Wechat_User].[VisitCount],
	[Wechat_User].[FromOpenId],
	[Wechat_User].[FirstSubScribeTime],
	[Wechat_User].[FromQrID],
	[Wechat_User].[CurrentProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenId],
	INSERTED.[NickName],
	INSERTED.[HeadImgUrl],
	INSERTED.[Sex],
	INSERTED.[City],
	INSERTED.[Country],
	INSERTED.[Province],
	INSERTED.[Language],
	INSERTED.[SubScribe],
	INSERTED.[SubscribeTime],
	INSERTED.[UnSubscribeTime],
	INSERTED.[LastVisitTime],
	INSERTED.[VisitCount],
	INSERTED.[FromOpenId],
	INSERTED.[FirstSubScribeTime],
	INSERTED.[FromQrID],
	INSERTED.[CurrentProjectID]
into @table
VALUES ( 
	@OpenId,
	@NickName,
	@HeadImgUrl,
	@Sex,
	@City,
	@Country,
	@Province,
	@Language,
	@SubScribe,
	@SubscribeTime,
	@UnSubscribeTime,
	@LastVisitTime,
	@VisitCount,
	@FromOpenId,
	@FirstSubScribeTime,
	@FromQrID,
	@CurrentProjectID 
); 

SELECT 
	[ID],
	[OpenId],
	[NickName],
	[HeadImgUrl],
	[Sex],
	[City],
	[Country],
	[Province],
	[Language],
	[SubScribe],
	[SubscribeTime],
	[UnSubscribeTime],
	[LastVisitTime],
	[VisitCount],
	[FromOpenId],
	[FirstSubScribeTime],
	[FromQrID],
	[CurrentProjectID] 
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
	[OpenId] nvarchar(255),
	[NickName] nvarchar(50),
	[HeadImgUrl] text,
	[Sex] int,
	[City] nvarchar(255),
	[Country] nvarchar(255),
	[Province] nvarchar(255),
	[Language] nvarchar(255),
	[SubScribe] int,
	[SubscribeTime] datetime,
	[UnSubscribeTime] datetime,
	[LastVisitTime] datetime,
	[VisitCount] int,
	[FromOpenId] nvarchar(255),
	[FirstSubScribeTime] datetime,
	[FromQrID] int,
	[CurrentProjectID] int
);

UPDATE [dbo].[Wechat_User] SET 
	[Wechat_User].[OpenId] = @OpenId,
	[Wechat_User].[NickName] = @NickName,
	[Wechat_User].[HeadImgUrl] = @HeadImgUrl,
	[Wechat_User].[Sex] = @Sex,
	[Wechat_User].[City] = @City,
	[Wechat_User].[Country] = @Country,
	[Wechat_User].[Province] = @Province,
	[Wechat_User].[Language] = @Language,
	[Wechat_User].[SubScribe] = @SubScribe,
	[Wechat_User].[SubscribeTime] = @SubscribeTime,
	[Wechat_User].[UnSubscribeTime] = @UnSubscribeTime,
	[Wechat_User].[LastVisitTime] = @LastVisitTime,
	[Wechat_User].[VisitCount] = @VisitCount,
	[Wechat_User].[FromOpenId] = @FromOpenId,
	[Wechat_User].[FirstSubScribeTime] = @FirstSubScribeTime,
	[Wechat_User].[FromQrID] = @FromQrID,
	[Wechat_User].[CurrentProjectID] = @CurrentProjectID 
output 
	INSERTED.[ID],
	INSERTED.[OpenId],
	INSERTED.[NickName],
	INSERTED.[HeadImgUrl],
	INSERTED.[Sex],
	INSERTED.[City],
	INSERTED.[Country],
	INSERTED.[Province],
	INSERTED.[Language],
	INSERTED.[SubScribe],
	INSERTED.[SubscribeTime],
	INSERTED.[UnSubscribeTime],
	INSERTED.[LastVisitTime],
	INSERTED.[VisitCount],
	INSERTED.[FromOpenId],
	INSERTED.[FirstSubScribeTime],
	INSERTED.[FromQrID],
	INSERTED.[CurrentProjectID]
into @table
WHERE 
	[Wechat_User].[ID] = @ID

SELECT 
	[ID],
	[OpenId],
	[NickName],
	[HeadImgUrl],
	[Sex],
	[City],
	[Country],
	[Province],
	[Language],
	[SubScribe],
	[SubscribeTime],
	[UnSubscribeTime],
	[LastVisitTime],
	[VisitCount],
	[FromOpenId],
	[FirstSubScribeTime],
	[FromQrID],
	[CurrentProjectID] 
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
DELETE FROM [dbo].[Wechat_User]
WHERE 
	[Wechat_User].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_User() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_User(this.ID));
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
	[Wechat_User].[ID],
	[Wechat_User].[OpenId],
	[Wechat_User].[NickName],
	[Wechat_User].[HeadImgUrl],
	[Wechat_User].[Sex],
	[Wechat_User].[City],
	[Wechat_User].[Country],
	[Wechat_User].[Province],
	[Wechat_User].[Language],
	[Wechat_User].[SubScribe],
	[Wechat_User].[SubscribeTime],
	[Wechat_User].[UnSubscribeTime],
	[Wechat_User].[LastVisitTime],
	[Wechat_User].[VisitCount],
	[Wechat_User].[FromOpenId],
	[Wechat_User].[FirstSubScribeTime],
	[Wechat_User].[FromQrID],
	[Wechat_User].[CurrentProjectID]
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
                return "Wechat_User";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_User into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openId">openId</param>
		/// <param name="nickName">nickName</param>
		/// <param name="headImgUrl">headImgUrl</param>
		/// <param name="sex">sex</param>
		/// <param name="city">city</param>
		/// <param name="country">country</param>
		/// <param name="province">province</param>
		/// <param name="language">language</param>
		/// <param name="subScribe">subScribe</param>
		/// <param name="subscribeTime">subscribeTime</param>
		/// <param name="unSubscribeTime">unSubscribeTime</param>
		/// <param name="lastVisitTime">lastVisitTime</param>
		/// <param name="visitCount">visitCount</param>
		/// <param name="fromOpenId">fromOpenId</param>
		/// <param name="firstSubScribeTime">firstSubScribeTime</param>
		/// <param name="fromQrID">fromQrID</param>
		/// <param name="currentProjectID">currentProjectID</param>
		public static void InsertWechat_User(string @openId, string @nickName, string @headImgUrl, int @sex, string @city, string @country, string @province, string @language, int @subScribe, DateTime @subscribeTime, DateTime @unSubscribeTime, DateTime @lastVisitTime, int @visitCount, string @fromOpenId, DateTime @firstSubScribeTime, int @fromQrID, int @currentProjectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_User(@openId, @nickName, @headImgUrl, @sex, @city, @country, @province, @language, @subScribe, @subscribeTime, @unSubscribeTime, @lastVisitTime, @visitCount, @fromOpenId, @firstSubScribeTime, @fromQrID, @currentProjectID, helper);
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
		/// Insert a Wechat_User into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="openId">openId</param>
		/// <param name="nickName">nickName</param>
		/// <param name="headImgUrl">headImgUrl</param>
		/// <param name="sex">sex</param>
		/// <param name="city">city</param>
		/// <param name="country">country</param>
		/// <param name="province">province</param>
		/// <param name="language">language</param>
		/// <param name="subScribe">subScribe</param>
		/// <param name="subscribeTime">subscribeTime</param>
		/// <param name="unSubscribeTime">unSubscribeTime</param>
		/// <param name="lastVisitTime">lastVisitTime</param>
		/// <param name="visitCount">visitCount</param>
		/// <param name="fromOpenId">fromOpenId</param>
		/// <param name="firstSubScribeTime">firstSubScribeTime</param>
		/// <param name="fromQrID">fromQrID</param>
		/// <param name="currentProjectID">currentProjectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_User(string @openId, string @nickName, string @headImgUrl, int @sex, string @city, string @country, string @province, string @language, int @subScribe, DateTime @subscribeTime, DateTime @unSubscribeTime, DateTime @lastVisitTime, int @visitCount, string @fromOpenId, DateTime @firstSubScribeTime, int @fromQrID, int @currentProjectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenId] nvarchar(255),
	[NickName] nvarchar(50),
	[HeadImgUrl] text,
	[Sex] int,
	[City] nvarchar(255),
	[Country] nvarchar(255),
	[Province] nvarchar(255),
	[Language] nvarchar(255),
	[SubScribe] int,
	[SubscribeTime] datetime,
	[UnSubscribeTime] datetime,
	[LastVisitTime] datetime,
	[VisitCount] int,
	[FromOpenId] nvarchar(255),
	[FirstSubScribeTime] datetime,
	[FromQrID] int,
	[CurrentProjectID] int
);

INSERT INTO [dbo].[Wechat_User] (
	[Wechat_User].[OpenId],
	[Wechat_User].[NickName],
	[Wechat_User].[HeadImgUrl],
	[Wechat_User].[Sex],
	[Wechat_User].[City],
	[Wechat_User].[Country],
	[Wechat_User].[Province],
	[Wechat_User].[Language],
	[Wechat_User].[SubScribe],
	[Wechat_User].[SubscribeTime],
	[Wechat_User].[UnSubscribeTime],
	[Wechat_User].[LastVisitTime],
	[Wechat_User].[VisitCount],
	[Wechat_User].[FromOpenId],
	[Wechat_User].[FirstSubScribeTime],
	[Wechat_User].[FromQrID],
	[Wechat_User].[CurrentProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[OpenId],
	INSERTED.[NickName],
	INSERTED.[HeadImgUrl],
	INSERTED.[Sex],
	INSERTED.[City],
	INSERTED.[Country],
	INSERTED.[Province],
	INSERTED.[Language],
	INSERTED.[SubScribe],
	INSERTED.[SubscribeTime],
	INSERTED.[UnSubscribeTime],
	INSERTED.[LastVisitTime],
	INSERTED.[VisitCount],
	INSERTED.[FromOpenId],
	INSERTED.[FirstSubScribeTime],
	INSERTED.[FromQrID],
	INSERTED.[CurrentProjectID]
into @table
VALUES ( 
	@OpenId,
	@NickName,
	@HeadImgUrl,
	@Sex,
	@City,
	@Country,
	@Province,
	@Language,
	@SubScribe,
	@SubscribeTime,
	@UnSubscribeTime,
	@LastVisitTime,
	@VisitCount,
	@FromOpenId,
	@FirstSubScribeTime,
	@FromQrID,
	@CurrentProjectID 
); 

SELECT 
	[ID],
	[OpenId],
	[NickName],
	[HeadImgUrl],
	[Sex],
	[City],
	[Country],
	[Province],
	[Language],
	[SubScribe],
	[SubscribeTime],
	[UnSubscribeTime],
	[LastVisitTime],
	[VisitCount],
	[FromOpenId],
	[FirstSubScribeTime],
	[FromQrID],
	[CurrentProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OpenId", EntityBase.GetDatabaseValue(@openId)));
			parameters.Add(new SqlParameter("@NickName", EntityBase.GetDatabaseValue(@nickName)));
			parameters.Add(new SqlParameter("@HeadImgUrl", EntityBase.GetDatabaseValue(@headImgUrl)));
			parameters.Add(new SqlParameter("@Sex", EntityBase.GetDatabaseValue(@sex)));
			parameters.Add(new SqlParameter("@City", EntityBase.GetDatabaseValue(@city)));
			parameters.Add(new SqlParameter("@Country", EntityBase.GetDatabaseValue(@country)));
			parameters.Add(new SqlParameter("@Province", EntityBase.GetDatabaseValue(@province)));
			parameters.Add(new SqlParameter("@Language", EntityBase.GetDatabaseValue(@language)));
			parameters.Add(new SqlParameter("@SubScribe", EntityBase.GetDatabaseValue(@subScribe)));
			parameters.Add(new SqlParameter("@SubscribeTime", EntityBase.GetDatabaseValue(@subscribeTime)));
			parameters.Add(new SqlParameter("@UnSubscribeTime", EntityBase.GetDatabaseValue(@unSubscribeTime)));
			parameters.Add(new SqlParameter("@LastVisitTime", EntityBase.GetDatabaseValue(@lastVisitTime)));
			parameters.Add(new SqlParameter("@VisitCount", EntityBase.GetDatabaseValue(@visitCount)));
			parameters.Add(new SqlParameter("@FromOpenId", EntityBase.GetDatabaseValue(@fromOpenId)));
			parameters.Add(new SqlParameter("@FirstSubScribeTime", EntityBase.GetDatabaseValue(@firstSubScribeTime)));
			parameters.Add(new SqlParameter("@FromQrID", EntityBase.GetDatabaseValue(@fromQrID)));
			parameters.Add(new SqlParameter("@CurrentProjectID", EntityBase.GetDatabaseValue(@currentProjectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_User into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openId">openId</param>
		/// <param name="nickName">nickName</param>
		/// <param name="headImgUrl">headImgUrl</param>
		/// <param name="sex">sex</param>
		/// <param name="city">city</param>
		/// <param name="country">country</param>
		/// <param name="province">province</param>
		/// <param name="language">language</param>
		/// <param name="subScribe">subScribe</param>
		/// <param name="subscribeTime">subscribeTime</param>
		/// <param name="unSubscribeTime">unSubscribeTime</param>
		/// <param name="lastVisitTime">lastVisitTime</param>
		/// <param name="visitCount">visitCount</param>
		/// <param name="fromOpenId">fromOpenId</param>
		/// <param name="firstSubScribeTime">firstSubScribeTime</param>
		/// <param name="fromQrID">fromQrID</param>
		/// <param name="currentProjectID">currentProjectID</param>
		public static void UpdateWechat_User(int @iD, string @openId, string @nickName, string @headImgUrl, int @sex, string @city, string @country, string @province, string @language, int @subScribe, DateTime @subscribeTime, DateTime @unSubscribeTime, DateTime @lastVisitTime, int @visitCount, string @fromOpenId, DateTime @firstSubScribeTime, int @fromQrID, int @currentProjectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_User(@iD, @openId, @nickName, @headImgUrl, @sex, @city, @country, @province, @language, @subScribe, @subscribeTime, @unSubscribeTime, @lastVisitTime, @visitCount, @fromOpenId, @firstSubScribeTime, @fromQrID, @currentProjectID, helper);
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
		/// Updates a Wechat_User into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="openId">openId</param>
		/// <param name="nickName">nickName</param>
		/// <param name="headImgUrl">headImgUrl</param>
		/// <param name="sex">sex</param>
		/// <param name="city">city</param>
		/// <param name="country">country</param>
		/// <param name="province">province</param>
		/// <param name="language">language</param>
		/// <param name="subScribe">subScribe</param>
		/// <param name="subscribeTime">subscribeTime</param>
		/// <param name="unSubscribeTime">unSubscribeTime</param>
		/// <param name="lastVisitTime">lastVisitTime</param>
		/// <param name="visitCount">visitCount</param>
		/// <param name="fromOpenId">fromOpenId</param>
		/// <param name="firstSubScribeTime">firstSubScribeTime</param>
		/// <param name="fromQrID">fromQrID</param>
		/// <param name="currentProjectID">currentProjectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_User(int @iD, string @openId, string @nickName, string @headImgUrl, int @sex, string @city, string @country, string @province, string @language, int @subScribe, DateTime @subscribeTime, DateTime @unSubscribeTime, DateTime @lastVisitTime, int @visitCount, string @fromOpenId, DateTime @firstSubScribeTime, int @fromQrID, int @currentProjectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OpenId] nvarchar(255),
	[NickName] nvarchar(50),
	[HeadImgUrl] text,
	[Sex] int,
	[City] nvarchar(255),
	[Country] nvarchar(255),
	[Province] nvarchar(255),
	[Language] nvarchar(255),
	[SubScribe] int,
	[SubscribeTime] datetime,
	[UnSubscribeTime] datetime,
	[LastVisitTime] datetime,
	[VisitCount] int,
	[FromOpenId] nvarchar(255),
	[FirstSubScribeTime] datetime,
	[FromQrID] int,
	[CurrentProjectID] int
);

UPDATE [dbo].[Wechat_User] SET 
	[Wechat_User].[OpenId] = @OpenId,
	[Wechat_User].[NickName] = @NickName,
	[Wechat_User].[HeadImgUrl] = @HeadImgUrl,
	[Wechat_User].[Sex] = @Sex,
	[Wechat_User].[City] = @City,
	[Wechat_User].[Country] = @Country,
	[Wechat_User].[Province] = @Province,
	[Wechat_User].[Language] = @Language,
	[Wechat_User].[SubScribe] = @SubScribe,
	[Wechat_User].[SubscribeTime] = @SubscribeTime,
	[Wechat_User].[UnSubscribeTime] = @UnSubscribeTime,
	[Wechat_User].[LastVisitTime] = @LastVisitTime,
	[Wechat_User].[VisitCount] = @VisitCount,
	[Wechat_User].[FromOpenId] = @FromOpenId,
	[Wechat_User].[FirstSubScribeTime] = @FirstSubScribeTime,
	[Wechat_User].[FromQrID] = @FromQrID,
	[Wechat_User].[CurrentProjectID] = @CurrentProjectID 
output 
	INSERTED.[ID],
	INSERTED.[OpenId],
	INSERTED.[NickName],
	INSERTED.[HeadImgUrl],
	INSERTED.[Sex],
	INSERTED.[City],
	INSERTED.[Country],
	INSERTED.[Province],
	INSERTED.[Language],
	INSERTED.[SubScribe],
	INSERTED.[SubscribeTime],
	INSERTED.[UnSubscribeTime],
	INSERTED.[LastVisitTime],
	INSERTED.[VisitCount],
	INSERTED.[FromOpenId],
	INSERTED.[FirstSubScribeTime],
	INSERTED.[FromQrID],
	INSERTED.[CurrentProjectID]
into @table
WHERE 
	[Wechat_User].[ID] = @ID

SELECT 
	[ID],
	[OpenId],
	[NickName],
	[HeadImgUrl],
	[Sex],
	[City],
	[Country],
	[Province],
	[Language],
	[SubScribe],
	[SubscribeTime],
	[UnSubscribeTime],
	[LastVisitTime],
	[VisitCount],
	[FromOpenId],
	[FirstSubScribeTime],
	[FromQrID],
	[CurrentProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OpenId", EntityBase.GetDatabaseValue(@openId)));
			parameters.Add(new SqlParameter("@NickName", EntityBase.GetDatabaseValue(@nickName)));
			parameters.Add(new SqlParameter("@HeadImgUrl", EntityBase.GetDatabaseValue(@headImgUrl)));
			parameters.Add(new SqlParameter("@Sex", EntityBase.GetDatabaseValue(@sex)));
			parameters.Add(new SqlParameter("@City", EntityBase.GetDatabaseValue(@city)));
			parameters.Add(new SqlParameter("@Country", EntityBase.GetDatabaseValue(@country)));
			parameters.Add(new SqlParameter("@Province", EntityBase.GetDatabaseValue(@province)));
			parameters.Add(new SqlParameter("@Language", EntityBase.GetDatabaseValue(@language)));
			parameters.Add(new SqlParameter("@SubScribe", EntityBase.GetDatabaseValue(@subScribe)));
			parameters.Add(new SqlParameter("@SubscribeTime", EntityBase.GetDatabaseValue(@subscribeTime)));
			parameters.Add(new SqlParameter("@UnSubscribeTime", EntityBase.GetDatabaseValue(@unSubscribeTime)));
			parameters.Add(new SqlParameter("@LastVisitTime", EntityBase.GetDatabaseValue(@lastVisitTime)));
			parameters.Add(new SqlParameter("@VisitCount", EntityBase.GetDatabaseValue(@visitCount)));
			parameters.Add(new SqlParameter("@FromOpenId", EntityBase.GetDatabaseValue(@fromOpenId)));
			parameters.Add(new SqlParameter("@FirstSubScribeTime", EntityBase.GetDatabaseValue(@firstSubScribeTime)));
			parameters.Add(new SqlParameter("@FromQrID", EntityBase.GetDatabaseValue(@fromQrID)));
			parameters.Add(new SqlParameter("@CurrentProjectID", EntityBase.GetDatabaseValue(@currentProjectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_User from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_User(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_User(@iD, helper);
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
		/// Deletes a Wechat_User from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_User(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_User]
WHERE 
	[Wechat_User].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_User object.
		/// </summary>
		/// <returns>The newly created Wechat_User object.</returns>
		public static Wechat_User CreateWechat_User()
		{
			return InitializeNew<Wechat_User>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_User by a Wechat_User's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_User</returns>
		public static Wechat_User GetWechat_User(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_User.SelectFieldList + @"
FROM [dbo].[Wechat_User] 
WHERE 
	[Wechat_User].[ID] = @ID " + Wechat_User.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_User>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_User by a Wechat_User's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_User</returns>
		public static Wechat_User GetWechat_User(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_User.SelectFieldList + @"
FROM [dbo].[Wechat_User] 
WHERE 
	[Wechat_User].[ID] = @ID " + Wechat_User.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_User>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_User objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_User objects.</returns>
		public static EntityList<Wechat_User> GetWechat_Users()
		{
			string commandText = @"
SELECT " + Wechat_User.SelectFieldList + "FROM [dbo].[Wechat_User] " + Wechat_User.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_User>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_User objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_User objects.</returns>
        public static EntityList<Wechat_User> GetWechat_Users(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_User>(SelectFieldList, "FROM [dbo].[Wechat_User]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_User objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_User objects.</returns>
        public static EntityList<Wechat_User> GetWechat_Users(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_User>(SelectFieldList, "FROM [dbo].[Wechat_User]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_User objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_User objects.</returns>
		protected static EntityList<Wechat_User> GetWechat_Users(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Users(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_User objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_User objects.</returns>
		protected static EntityList<Wechat_User> GetWechat_Users(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Users(string.Empty, where, parameters, Wechat_User.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_User objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_User objects.</returns>
		protected static EntityList<Wechat_User> GetWechat_Users(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Users(prefix, where, parameters, Wechat_User.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_User objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_User objects.</returns>
		protected static EntityList<Wechat_User> GetWechat_Users(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Users(string.Empty, where, parameters, Wechat_User.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_User objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_User objects.</returns>
		protected static EntityList<Wechat_User> GetWechat_Users(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Users(prefix, where, parameters, Wechat_User.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_User objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_User objects.</returns>
		protected static EntityList<Wechat_User> GetWechat_Users(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_User.SelectFieldList + "FROM [dbo].[Wechat_User] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_User>(reader);
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
        protected static EntityList<Wechat_User> GetWechat_Users(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_User>(SelectFieldList, "FROM [dbo].[Wechat_User] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_User objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_UserCount()
        {
            return GetWechat_UserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_User objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_UserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_User] " + where;

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
		public static partial class Wechat_User_Properties
		{
			public const string ID = "ID";
			public const string OpenId = "OpenId";
			public const string NickName = "NickName";
			public const string HeadImgUrl = "HeadImgUrl";
			public const string Sex = "Sex";
			public const string City = "City";
			public const string Country = "Country";
			public const string Province = "Province";
			public const string Language = "Language";
			public const string SubScribe = "SubScribe";
			public const string SubscribeTime = "SubscribeTime";
			public const string UnSubscribeTime = "UnSubscribeTime";
			public const string LastVisitTime = "LastVisitTime";
			public const string VisitCount = "VisitCount";
			public const string FromOpenId = "FromOpenId";
			public const string FirstSubScribeTime = "FirstSubScribeTime";
			public const string FromQrID = "FromQrID";
			public const string CurrentProjectID = "CurrentProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OpenId" , "string:"},
    			 {"NickName" , "string:"},
    			 {"HeadImgUrl" , "string:"},
    			 {"Sex" , "int:"},
    			 {"City" , "string:"},
    			 {"Country" , "string:"},
    			 {"Province" , "string:"},
    			 {"Language" , "string:"},
    			 {"SubScribe" , "int:"},
    			 {"SubscribeTime" , "DateTime:"},
    			 {"UnSubscribeTime" , "DateTime:"},
    			 {"LastVisitTime" , "DateTime:"},
    			 {"VisitCount" , "int:"},
    			 {"FromOpenId" , "string:"},
    			 {"FirstSubScribeTime" , "DateTime:"},
    			 {"FromQrID" , "int:"},
    			 {"CurrentProjectID" , "int:"},
            };
		}
		#endregion
	}
}
