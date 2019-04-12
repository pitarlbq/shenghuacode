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
	/// This object represents the properties and methods of a Mall_CouponUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Mall_CouponUser 
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
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private int _couponID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CouponID
		{
			[DebuggerStepThrough()]
			get { return this._couponID; }
			set 
			{
				if (this._couponID != value) 
				{
					this._couponID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CouponID");
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
		[DataObjectField(false, false, false)]
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
		private string _addUserMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserMan
		{
			[DebuggerStepThrough()]
			get { return this._addUserMan; }
			set 
			{
				if (this._addUserMan != value) 
				{
					this._addUserMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isUsed = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsUsed
		{
			[DebuggerStepThrough()]
			get { return this._isUsed; }
			set 
			{
				if (this._isUsed != value) 
				{
					this._isUsed = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsUsed");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _useTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime UseTime
		{
			[DebuggerStepThrough()]
			get { return this._useTime; }
			set 
			{
				if (this._useTime != value) 
				{
					this._useTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _useType = int.MinValue;
		/// <summary>
		/// 1-商品消费 2-积分消费 3-物业缴费
		/// </summary>
        [Description("1-商品消费 2-积分消费 3-物业缴费")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UseType
		{
			[DebuggerStepThrough()]
			get { return this._useType; }
			set 
			{
				if (this._useType != value) 
				{
					this._useType = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _couponType = int.MinValue;
		/// <summary>
		/// 1-充值赠送 2-生日赠送 3-消费赠送 4-手动发放 5-自己领取
		/// </summary>
        [Description("1-充值赠送 2-生日赠送 3-消费赠送 4-手动发放 5-自己领取")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int CouponType
		{
			[DebuggerStepThrough()]
			get { return this._couponType; }
			set 
			{
				if (this._couponType != value) 
				{
					this._couponType = value;
					this.IsDirty = true;	
					OnPropertyChanged("CouponType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _amountRuleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AmountRuleID
		{
			[DebuggerStepThrough()]
			get { return this._amountRuleID; }
			set 
			{
				if (this._amountRuleID != value) 
				{
					this._amountRuleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AmountRuleID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isRead = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsRead
		{
			[DebuggerStepThrough()]
			get { return this._isRead; }
			set 
			{
				if (this._isRead != value) 
				{
					this._isRead = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsRead");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _readDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ReadDate
		{
			[DebuggerStepThrough()]
			get { return this._readDate; }
			set 
			{
				if (this._readDate != value) 
				{
					this._readDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("ReadDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isSent = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsSent
		{
			[DebuggerStepThrough()]
			get { return this._isSent; }
			set 
			{
				if (this._isSent != value) 
				{
					this._isSent = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsSent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _sentTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SentTime
		{
			[DebuggerStepThrough()]
			get { return this._sentTime; }
			set 
			{
				if (this._sentTime != value) 
				{
					this._sentTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SentTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _isReadySendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime IsReadySendTime
		{
			[DebuggerStepThrough()]
			get { return this._isReadySendTime; }
			set 
			{
				if (this._isReadySendTime != value) 
				{
					this._isReadySendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsReadySendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isTaken = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsTaken
		{
			[DebuggerStepThrough()]
			get { return this._isTaken; }
			set 
			{
				if (this._isTaken != value) 
				{
					this._isTaken = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsTaken");
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
		private DateTime _endTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime EndTime
		{
			[DebuggerStepThrough()]
			get { return this._endTime; }
			set 
			{
				if (this._endTime != value) 
				{
					this._endTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("EndTime");
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
		private DateTime _expireReadDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ExpireReadDate
		{
			[DebuggerStepThrough()]
			get { return this._expireReadDate; }
			set 
			{
				if (this._expireReadDate != value) 
				{
					this._expireReadDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("ExpireReadDate");
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
	[UserID] int,
	[CouponID] int,
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[IsUsed] bit,
	[UseTime] datetime,
	[UseType] int,
	[CouponType] int,
	[AmountRuleID] int,
	[IsRead] bit,
	[ReadDate] datetime,
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime,
	[IsTaken] bit,
	[StartTime] datetime,
	[EndTime] datetime,
	[IsActive] bit,
	[ExpireReadDate] datetime
);

INSERT INTO [dbo].[Mall_CouponUser] (
	[Mall_CouponUser].[UserID],
	[Mall_CouponUser].[CouponID],
	[Mall_CouponUser].[AddTime],
	[Mall_CouponUser].[AddUserMan],
	[Mall_CouponUser].[IsUsed],
	[Mall_CouponUser].[UseTime],
	[Mall_CouponUser].[UseType],
	[Mall_CouponUser].[CouponType],
	[Mall_CouponUser].[AmountRuleID],
	[Mall_CouponUser].[IsRead],
	[Mall_CouponUser].[ReadDate],
	[Mall_CouponUser].[IsSent],
	[Mall_CouponUser].[SentTime],
	[Mall_CouponUser].[IsReadySendTime],
	[Mall_CouponUser].[IsTaken],
	[Mall_CouponUser].[StartTime],
	[Mall_CouponUser].[EndTime],
	[Mall_CouponUser].[IsActive],
	[Mall_CouponUser].[ExpireReadDate]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[CouponID],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[IsUsed],
	INSERTED.[UseTime],
	INSERTED.[UseType],
	INSERTED.[CouponType],
	INSERTED.[AmountRuleID],
	INSERTED.[IsRead],
	INSERTED.[ReadDate],
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime],
	INSERTED.[IsTaken],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsActive],
	INSERTED.[ExpireReadDate]
into @table
VALUES ( 
	@UserID,
	@CouponID,
	@AddTime,
	@AddUserMan,
	@IsUsed,
	@UseTime,
	@UseType,
	@CouponType,
	@AmountRuleID,
	@IsRead,
	@ReadDate,
	@IsSent,
	@SentTime,
	@IsReadySendTime,
	@IsTaken,
	@StartTime,
	@EndTime,
	@IsActive,
	@ExpireReadDate 
); 

SELECT 
	[ID],
	[UserID],
	[CouponID],
	[AddTime],
	[AddUserMan],
	[IsUsed],
	[UseTime],
	[UseType],
	[CouponType],
	[AmountRuleID],
	[IsRead],
	[ReadDate],
	[IsSent],
	[SentTime],
	[IsReadySendTime],
	[IsTaken],
	[StartTime],
	[EndTime],
	[IsActive],
	[ExpireReadDate] 
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
	[UserID] int,
	[CouponID] int,
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[IsUsed] bit,
	[UseTime] datetime,
	[UseType] int,
	[CouponType] int,
	[AmountRuleID] int,
	[IsRead] bit,
	[ReadDate] datetime,
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime,
	[IsTaken] bit,
	[StartTime] datetime,
	[EndTime] datetime,
	[IsActive] bit,
	[ExpireReadDate] datetime
);

UPDATE [dbo].[Mall_CouponUser] SET 
	[Mall_CouponUser].[UserID] = @UserID,
	[Mall_CouponUser].[CouponID] = @CouponID,
	[Mall_CouponUser].[AddTime] = @AddTime,
	[Mall_CouponUser].[AddUserMan] = @AddUserMan,
	[Mall_CouponUser].[IsUsed] = @IsUsed,
	[Mall_CouponUser].[UseTime] = @UseTime,
	[Mall_CouponUser].[UseType] = @UseType,
	[Mall_CouponUser].[CouponType] = @CouponType,
	[Mall_CouponUser].[AmountRuleID] = @AmountRuleID,
	[Mall_CouponUser].[IsRead] = @IsRead,
	[Mall_CouponUser].[ReadDate] = @ReadDate,
	[Mall_CouponUser].[IsSent] = @IsSent,
	[Mall_CouponUser].[SentTime] = @SentTime,
	[Mall_CouponUser].[IsReadySendTime] = @IsReadySendTime,
	[Mall_CouponUser].[IsTaken] = @IsTaken,
	[Mall_CouponUser].[StartTime] = @StartTime,
	[Mall_CouponUser].[EndTime] = @EndTime,
	[Mall_CouponUser].[IsActive] = @IsActive,
	[Mall_CouponUser].[ExpireReadDate] = @ExpireReadDate 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[CouponID],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[IsUsed],
	INSERTED.[UseTime],
	INSERTED.[UseType],
	INSERTED.[CouponType],
	INSERTED.[AmountRuleID],
	INSERTED.[IsRead],
	INSERTED.[ReadDate],
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime],
	INSERTED.[IsTaken],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsActive],
	INSERTED.[ExpireReadDate]
into @table
WHERE 
	[Mall_CouponUser].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[CouponID],
	[AddTime],
	[AddUserMan],
	[IsUsed],
	[UseTime],
	[UseType],
	[CouponType],
	[AmountRuleID],
	[IsRead],
	[ReadDate],
	[IsSent],
	[SentTime],
	[IsReadySendTime],
	[IsTaken],
	[StartTime],
	[EndTime],
	[IsActive],
	[ExpireReadDate] 
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
DELETE FROM [dbo].[Mall_CouponUser]
WHERE 
	[Mall_CouponUser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_CouponUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_CouponUser(this.ID));
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
	[Mall_CouponUser].[ID],
	[Mall_CouponUser].[UserID],
	[Mall_CouponUser].[CouponID],
	[Mall_CouponUser].[AddTime],
	[Mall_CouponUser].[AddUserMan],
	[Mall_CouponUser].[IsUsed],
	[Mall_CouponUser].[UseTime],
	[Mall_CouponUser].[UseType],
	[Mall_CouponUser].[CouponType],
	[Mall_CouponUser].[AmountRuleID],
	[Mall_CouponUser].[IsRead],
	[Mall_CouponUser].[ReadDate],
	[Mall_CouponUser].[IsSent],
	[Mall_CouponUser].[SentTime],
	[Mall_CouponUser].[IsReadySendTime],
	[Mall_CouponUser].[IsTaken],
	[Mall_CouponUser].[StartTime],
	[Mall_CouponUser].[EndTime],
	[Mall_CouponUser].[IsActive],
	[Mall_CouponUser].[ExpireReadDate]
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
                return "Mall_CouponUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_CouponUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="couponID">couponID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="isUsed">isUsed</param>
		/// <param name="useTime">useTime</param>
		/// <param name="useType">useType</param>
		/// <param name="couponType">couponType</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="isRead">isRead</param>
		/// <param name="readDate">readDate</param>
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="isTaken">isTaken</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="expireReadDate">expireReadDate</param>
		public static void InsertMall_CouponUser(int @userID, int @couponID, DateTime @addTime, string @addUserMan, bool @isUsed, DateTime @useTime, int @useType, int @couponType, int @amountRuleID, bool @isRead, DateTime @readDate, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, bool @isTaken, DateTime @startTime, DateTime @endTime, bool @isActive, DateTime @expireReadDate)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_CouponUser(@userID, @couponID, @addTime, @addUserMan, @isUsed, @useTime, @useType, @couponType, @amountRuleID, @isRead, @readDate, @isSent, @sentTime, @isReadySendTime, @isTaken, @startTime, @endTime, @isActive, @expireReadDate, helper);
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
		/// Insert a Mall_CouponUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="couponID">couponID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="isUsed">isUsed</param>
		/// <param name="useTime">useTime</param>
		/// <param name="useType">useType</param>
		/// <param name="couponType">couponType</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="isRead">isRead</param>
		/// <param name="readDate">readDate</param>
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="isTaken">isTaken</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="expireReadDate">expireReadDate</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_CouponUser(int @userID, int @couponID, DateTime @addTime, string @addUserMan, bool @isUsed, DateTime @useTime, int @useType, int @couponType, int @amountRuleID, bool @isRead, DateTime @readDate, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, bool @isTaken, DateTime @startTime, DateTime @endTime, bool @isActive, DateTime @expireReadDate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[CouponID] int,
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[IsUsed] bit,
	[UseTime] datetime,
	[UseType] int,
	[CouponType] int,
	[AmountRuleID] int,
	[IsRead] bit,
	[ReadDate] datetime,
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime,
	[IsTaken] bit,
	[StartTime] datetime,
	[EndTime] datetime,
	[IsActive] bit,
	[ExpireReadDate] datetime
);

INSERT INTO [dbo].[Mall_CouponUser] (
	[Mall_CouponUser].[UserID],
	[Mall_CouponUser].[CouponID],
	[Mall_CouponUser].[AddTime],
	[Mall_CouponUser].[AddUserMan],
	[Mall_CouponUser].[IsUsed],
	[Mall_CouponUser].[UseTime],
	[Mall_CouponUser].[UseType],
	[Mall_CouponUser].[CouponType],
	[Mall_CouponUser].[AmountRuleID],
	[Mall_CouponUser].[IsRead],
	[Mall_CouponUser].[ReadDate],
	[Mall_CouponUser].[IsSent],
	[Mall_CouponUser].[SentTime],
	[Mall_CouponUser].[IsReadySendTime],
	[Mall_CouponUser].[IsTaken],
	[Mall_CouponUser].[StartTime],
	[Mall_CouponUser].[EndTime],
	[Mall_CouponUser].[IsActive],
	[Mall_CouponUser].[ExpireReadDate]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[CouponID],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[IsUsed],
	INSERTED.[UseTime],
	INSERTED.[UseType],
	INSERTED.[CouponType],
	INSERTED.[AmountRuleID],
	INSERTED.[IsRead],
	INSERTED.[ReadDate],
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime],
	INSERTED.[IsTaken],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsActive],
	INSERTED.[ExpireReadDate]
into @table
VALUES ( 
	@UserID,
	@CouponID,
	@AddTime,
	@AddUserMan,
	@IsUsed,
	@UseTime,
	@UseType,
	@CouponType,
	@AmountRuleID,
	@IsRead,
	@ReadDate,
	@IsSent,
	@SentTime,
	@IsReadySendTime,
	@IsTaken,
	@StartTime,
	@EndTime,
	@IsActive,
	@ExpireReadDate 
); 

SELECT 
	[ID],
	[UserID],
	[CouponID],
	[AddTime],
	[AddUserMan],
	[IsUsed],
	[UseTime],
	[UseType],
	[CouponType],
	[AmountRuleID],
	[IsRead],
	[ReadDate],
	[IsSent],
	[SentTime],
	[IsReadySendTime],
	[IsTaken],
	[StartTime],
	[EndTime],
	[IsActive],
	[ExpireReadDate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@CouponID", EntityBase.GetDatabaseValue(@couponID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@IsUsed", @isUsed));
			parameters.Add(new SqlParameter("@UseTime", EntityBase.GetDatabaseValue(@useTime)));
			parameters.Add(new SqlParameter("@UseType", EntityBase.GetDatabaseValue(@useType)));
			parameters.Add(new SqlParameter("@CouponType", EntityBase.GetDatabaseValue(@couponType)));
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@IsRead", @isRead));
			parameters.Add(new SqlParameter("@ReadDate", EntityBase.GetDatabaseValue(@readDate)));
			parameters.Add(new SqlParameter("@IsSent", @isSent));
			parameters.Add(new SqlParameter("@SentTime", EntityBase.GetDatabaseValue(@sentTime)));
			parameters.Add(new SqlParameter("@IsReadySendTime", EntityBase.GetDatabaseValue(@isReadySendTime)));
			parameters.Add(new SqlParameter("@IsTaken", @isTaken));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@ExpireReadDate", EntityBase.GetDatabaseValue(@expireReadDate)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_CouponUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="couponID">couponID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="isUsed">isUsed</param>
		/// <param name="useTime">useTime</param>
		/// <param name="useType">useType</param>
		/// <param name="couponType">couponType</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="isRead">isRead</param>
		/// <param name="readDate">readDate</param>
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="isTaken">isTaken</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="expireReadDate">expireReadDate</param>
		public static void UpdateMall_CouponUser(int @iD, int @userID, int @couponID, DateTime @addTime, string @addUserMan, bool @isUsed, DateTime @useTime, int @useType, int @couponType, int @amountRuleID, bool @isRead, DateTime @readDate, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, bool @isTaken, DateTime @startTime, DateTime @endTime, bool @isActive, DateTime @expireReadDate)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_CouponUser(@iD, @userID, @couponID, @addTime, @addUserMan, @isUsed, @useTime, @useType, @couponType, @amountRuleID, @isRead, @readDate, @isSent, @sentTime, @isReadySendTime, @isTaken, @startTime, @endTime, @isActive, @expireReadDate, helper);
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
		/// Updates a Mall_CouponUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="couponID">couponID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserMan">addUserMan</param>
		/// <param name="isUsed">isUsed</param>
		/// <param name="useTime">useTime</param>
		/// <param name="useType">useType</param>
		/// <param name="couponType">couponType</param>
		/// <param name="amountRuleID">amountRuleID</param>
		/// <param name="isRead">isRead</param>
		/// <param name="readDate">readDate</param>
		/// <param name="isSent">isSent</param>
		/// <param name="sentTime">sentTime</param>
		/// <param name="isReadySendTime">isReadySendTime</param>
		/// <param name="isTaken">isTaken</param>
		/// <param name="startTime">startTime</param>
		/// <param name="endTime">endTime</param>
		/// <param name="isActive">isActive</param>
		/// <param name="expireReadDate">expireReadDate</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_CouponUser(int @iD, int @userID, int @couponID, DateTime @addTime, string @addUserMan, bool @isUsed, DateTime @useTime, int @useType, int @couponType, int @amountRuleID, bool @isRead, DateTime @readDate, bool @isSent, DateTime @sentTime, DateTime @isReadySendTime, bool @isTaken, DateTime @startTime, DateTime @endTime, bool @isActive, DateTime @expireReadDate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[CouponID] int,
	[AddTime] datetime,
	[AddUserMan] nvarchar(200),
	[IsUsed] bit,
	[UseTime] datetime,
	[UseType] int,
	[CouponType] int,
	[AmountRuleID] int,
	[IsRead] bit,
	[ReadDate] datetime,
	[IsSent] bit,
	[SentTime] datetime,
	[IsReadySendTime] datetime,
	[IsTaken] bit,
	[StartTime] datetime,
	[EndTime] datetime,
	[IsActive] bit,
	[ExpireReadDate] datetime
);

UPDATE [dbo].[Mall_CouponUser] SET 
	[Mall_CouponUser].[UserID] = @UserID,
	[Mall_CouponUser].[CouponID] = @CouponID,
	[Mall_CouponUser].[AddTime] = @AddTime,
	[Mall_CouponUser].[AddUserMan] = @AddUserMan,
	[Mall_CouponUser].[IsUsed] = @IsUsed,
	[Mall_CouponUser].[UseTime] = @UseTime,
	[Mall_CouponUser].[UseType] = @UseType,
	[Mall_CouponUser].[CouponType] = @CouponType,
	[Mall_CouponUser].[AmountRuleID] = @AmountRuleID,
	[Mall_CouponUser].[IsRead] = @IsRead,
	[Mall_CouponUser].[ReadDate] = @ReadDate,
	[Mall_CouponUser].[IsSent] = @IsSent,
	[Mall_CouponUser].[SentTime] = @SentTime,
	[Mall_CouponUser].[IsReadySendTime] = @IsReadySendTime,
	[Mall_CouponUser].[IsTaken] = @IsTaken,
	[Mall_CouponUser].[StartTime] = @StartTime,
	[Mall_CouponUser].[EndTime] = @EndTime,
	[Mall_CouponUser].[IsActive] = @IsActive,
	[Mall_CouponUser].[ExpireReadDate] = @ExpireReadDate 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[CouponID],
	INSERTED.[AddTime],
	INSERTED.[AddUserMan],
	INSERTED.[IsUsed],
	INSERTED.[UseTime],
	INSERTED.[UseType],
	INSERTED.[CouponType],
	INSERTED.[AmountRuleID],
	INSERTED.[IsRead],
	INSERTED.[ReadDate],
	INSERTED.[IsSent],
	INSERTED.[SentTime],
	INSERTED.[IsReadySendTime],
	INSERTED.[IsTaken],
	INSERTED.[StartTime],
	INSERTED.[EndTime],
	INSERTED.[IsActive],
	INSERTED.[ExpireReadDate]
into @table
WHERE 
	[Mall_CouponUser].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[CouponID],
	[AddTime],
	[AddUserMan],
	[IsUsed],
	[UseTime],
	[UseType],
	[CouponType],
	[AmountRuleID],
	[IsRead],
	[ReadDate],
	[IsSent],
	[SentTime],
	[IsReadySendTime],
	[IsTaken],
	[StartTime],
	[EndTime],
	[IsActive],
	[ExpireReadDate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@CouponID", EntityBase.GetDatabaseValue(@couponID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserMan", EntityBase.GetDatabaseValue(@addUserMan)));
			parameters.Add(new SqlParameter("@IsUsed", @isUsed));
			parameters.Add(new SqlParameter("@UseTime", EntityBase.GetDatabaseValue(@useTime)));
			parameters.Add(new SqlParameter("@UseType", EntityBase.GetDatabaseValue(@useType)));
			parameters.Add(new SqlParameter("@CouponType", EntityBase.GetDatabaseValue(@couponType)));
			parameters.Add(new SqlParameter("@AmountRuleID", EntityBase.GetDatabaseValue(@amountRuleID)));
			parameters.Add(new SqlParameter("@IsRead", @isRead));
			parameters.Add(new SqlParameter("@ReadDate", EntityBase.GetDatabaseValue(@readDate)));
			parameters.Add(new SqlParameter("@IsSent", @isSent));
			parameters.Add(new SqlParameter("@SentTime", EntityBase.GetDatabaseValue(@sentTime)));
			parameters.Add(new SqlParameter("@IsReadySendTime", EntityBase.GetDatabaseValue(@isReadySendTime)));
			parameters.Add(new SqlParameter("@IsTaken", @isTaken));
			parameters.Add(new SqlParameter("@StartTime", EntityBase.GetDatabaseValue(@startTime)));
			parameters.Add(new SqlParameter("@EndTime", EntityBase.GetDatabaseValue(@endTime)));
			parameters.Add(new SqlParameter("@IsActive", @isActive));
			parameters.Add(new SqlParameter("@ExpireReadDate", EntityBase.GetDatabaseValue(@expireReadDate)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_CouponUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteMall_CouponUser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_CouponUser(@iD, helper);
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
		/// Deletes a Mall_CouponUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_CouponUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_CouponUser]
WHERE 
	[Mall_CouponUser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_CouponUser object.
		/// </summary>
		/// <returns>The newly created Mall_CouponUser object.</returns>
		public static Mall_CouponUser CreateMall_CouponUser()
		{
			return InitializeNew<Mall_CouponUser>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_CouponUser by a Mall_CouponUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Mall_CouponUser</returns>
		public static Mall_CouponUser GetMall_CouponUser(int @iD)
		{
			string commandText = @"
SELECT 
" + Mall_CouponUser.SelectFieldList + @"
FROM [dbo].[Mall_CouponUser] 
WHERE 
	[Mall_CouponUser].[ID] = @ID " + Mall_CouponUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CouponUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_CouponUser by a Mall_CouponUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_CouponUser</returns>
		public static Mall_CouponUser GetMall_CouponUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_CouponUser.SelectFieldList + @"
FROM [dbo].[Mall_CouponUser] 
WHERE 
	[Mall_CouponUser].[ID] = @ID " + Mall_CouponUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Mall_CouponUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_CouponUser objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_CouponUser objects.</returns>
		public static EntityList<Mall_CouponUser> GetMall_CouponUsers()
		{
			string commandText = @"
SELECT " + Mall_CouponUser.SelectFieldList + "FROM [dbo].[Mall_CouponUser] " + Mall_CouponUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_CouponUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_CouponUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CouponUser objects.</returns>
        public static EntityList<Mall_CouponUser> GetMall_CouponUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CouponUser>(SelectFieldList, "FROM [dbo].[Mall_CouponUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_CouponUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_CouponUser objects.</returns>
        public static EntityList<Mall_CouponUser> GetMall_CouponUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CouponUser>(SelectFieldList, "FROM [dbo].[Mall_CouponUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_CouponUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CouponUser objects.</returns>
		protected static EntityList<Mall_CouponUser> GetMall_CouponUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CouponUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_CouponUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CouponUser objects.</returns>
		protected static EntityList<Mall_CouponUser> GetMall_CouponUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CouponUsers(string.Empty, where, parameters, Mall_CouponUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CouponUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_CouponUser objects.</returns>
		protected static EntityList<Mall_CouponUser> GetMall_CouponUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_CouponUsers(prefix, where, parameters, Mall_CouponUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CouponUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CouponUser objects.</returns>
		protected static EntityList<Mall_CouponUser> GetMall_CouponUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CouponUsers(string.Empty, where, parameters, Mall_CouponUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CouponUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_CouponUser objects.</returns>
		protected static EntityList<Mall_CouponUser> GetMall_CouponUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_CouponUsers(prefix, where, parameters, Mall_CouponUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_CouponUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_CouponUser objects.</returns>
		protected static EntityList<Mall_CouponUser> GetMall_CouponUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_CouponUser.SelectFieldList + "FROM [dbo].[Mall_CouponUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_CouponUser>(reader);
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
        protected static EntityList<Mall_CouponUser> GetMall_CouponUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_CouponUser>(SelectFieldList, "FROM [dbo].[Mall_CouponUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_CouponUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CouponUserCount()
        {
            return GetMall_CouponUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_CouponUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_CouponUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_CouponUser] " + where;

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
		public static partial class Mall_CouponUser_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string CouponID = "CouponID";
			public const string AddTime = "AddTime";
			public const string AddUserMan = "AddUserMan";
			public const string IsUsed = "IsUsed";
			public const string UseTime = "UseTime";
			public const string UseType = "UseType";
			public const string CouponType = "CouponType";
			public const string AmountRuleID = "AmountRuleID";
			public const string IsRead = "IsRead";
			public const string ReadDate = "ReadDate";
			public const string IsSent = "IsSent";
			public const string SentTime = "SentTime";
			public const string IsReadySendTime = "IsReadySendTime";
			public const string IsTaken = "IsTaken";
			public const string StartTime = "StartTime";
			public const string EndTime = "EndTime";
			public const string IsActive = "IsActive";
			public const string ExpireReadDate = "ExpireReadDate";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"CouponID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserMan" , "string:"},
    			 {"IsUsed" , "bool:"},
    			 {"UseTime" , "DateTime:"},
    			 {"UseType" , "int:1-商品消费 2-积分消费 3-物业缴费"},
    			 {"CouponType" , "int:1-充值赠送 2-生日赠送 3-消费赠送 4-手动发放 5-自己领取"},
    			 {"AmountRuleID" , "int:"},
    			 {"IsRead" , "bool:"},
    			 {"ReadDate" , "DateTime:"},
    			 {"IsSent" , "bool:"},
    			 {"SentTime" , "DateTime:"},
    			 {"IsReadySendTime" , "DateTime:"},
    			 {"IsTaken" , "bool:"},
    			 {"StartTime" , "DateTime:"},
    			 {"EndTime" , "DateTime:"},
    			 {"IsActive" , "bool:"},
    			 {"ExpireReadDate" , "DateTime:"},
            };
		}
		#endregion
	}
}
