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
	/// This object represents the properties and methods of a PhoneRecord.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class PhoneRecord 
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
		private DateTime _callTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CallTime
		{
			[DebuggerStepThrough()]
			get { return this._callTime; }
			set 
			{
				if (this._callTime != value) 
				{
					this._callTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CallTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _hangUpTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime HangUpTime
		{
			[DebuggerStepThrough()]
			get { return this._hangUpTime; }
			set 
			{
				if (this._hangUpTime != value) 
				{
					this._hangUpTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("HangUpTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _recordVoicePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RecordVoicePath
		{
			[DebuggerStepThrough()]
			get { return this._recordVoicePath; }
			set 
			{
				if (this._recordVoicePath != value) 
				{
					this._recordVoicePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("RecordVoicePath");
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
		private int _phoneType = int.MinValue;
		/// <summary>
		/// 1-来电 2-去电
		/// </summary>
        [Description("1-来电 2-去电")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PhoneType
		{
			[DebuggerStepThrough()]
			get { return this._phoneType; }
			set 
			{
				if (this._phoneType != value) 
				{
					this._phoneType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PhoneType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fileOriName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FileOriName
		{
			[DebuggerStepThrough()]
			get { return this._fileOriName; }
			set 
			{
				if (this._fileOriName != value) 
				{
					this._fileOriName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FileOriName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _relatedPhoneRecordID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelatedPhoneRecordID
		{
			[DebuggerStepThrough()]
			get { return this._relatedPhoneRecordID; }
			set 
			{
				if (this._relatedPhoneRecordID != value) 
				{
					this._relatedPhoneRecordID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelatedPhoneRecordID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _pickUpTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PickUpTime
		{
			[DebuggerStepThrough()]
			get { return this._pickUpTime; }
			set 
			{
				if (this._pickUpTime != value) 
				{
					this._pickUpTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PickUpTime");
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
	[PhoneNumber] nvarchar(50),
	[CallTime] datetime,
	[HangUpTime] datetime,
	[RecordVoicePath] nvarchar(500),
	[ServiceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[UserID] int,
	[PhoneType] int,
	[FileOriName] nvarchar(260),
	[RelatedPhoneRecordID] int,
	[PickUpTime] datetime
);

INSERT INTO [dbo].[PhoneRecord] (
	[PhoneRecord].[PhoneNumber],
	[PhoneRecord].[CallTime],
	[PhoneRecord].[HangUpTime],
	[PhoneRecord].[RecordVoicePath],
	[PhoneRecord].[ServiceID],
	[PhoneRecord].[AddTime],
	[PhoneRecord].[AddUserName],
	[PhoneRecord].[UserID],
	[PhoneRecord].[PhoneType],
	[PhoneRecord].[FileOriName],
	[PhoneRecord].[RelatedPhoneRecordID],
	[PhoneRecord].[PickUpTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[PhoneNumber],
	INSERTED.[CallTime],
	INSERTED.[HangUpTime],
	INSERTED.[RecordVoicePath],
	INSERTED.[ServiceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[UserID],
	INSERTED.[PhoneType],
	INSERTED.[FileOriName],
	INSERTED.[RelatedPhoneRecordID],
	INSERTED.[PickUpTime]
into @table
VALUES ( 
	@PhoneNumber,
	@CallTime,
	@HangUpTime,
	@RecordVoicePath,
	@ServiceID,
	@AddTime,
	@AddUserName,
	@UserID,
	@PhoneType,
	@FileOriName,
	@RelatedPhoneRecordID,
	@PickUpTime 
); 

SELECT 
	[ID],
	[PhoneNumber],
	[CallTime],
	[HangUpTime],
	[RecordVoicePath],
	[ServiceID],
	[AddTime],
	[AddUserName],
	[UserID],
	[PhoneType],
	[FileOriName],
	[RelatedPhoneRecordID],
	[PickUpTime] 
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
	[PhoneNumber] nvarchar(50),
	[CallTime] datetime,
	[HangUpTime] datetime,
	[RecordVoicePath] nvarchar(500),
	[ServiceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[UserID] int,
	[PhoneType] int,
	[FileOriName] nvarchar(260),
	[RelatedPhoneRecordID] int,
	[PickUpTime] datetime
);

UPDATE [dbo].[PhoneRecord] SET 
	[PhoneRecord].[PhoneNumber] = @PhoneNumber,
	[PhoneRecord].[CallTime] = @CallTime,
	[PhoneRecord].[HangUpTime] = @HangUpTime,
	[PhoneRecord].[RecordVoicePath] = @RecordVoicePath,
	[PhoneRecord].[ServiceID] = @ServiceID,
	[PhoneRecord].[AddTime] = @AddTime,
	[PhoneRecord].[AddUserName] = @AddUserName,
	[PhoneRecord].[UserID] = @UserID,
	[PhoneRecord].[PhoneType] = @PhoneType,
	[PhoneRecord].[FileOriName] = @FileOriName,
	[PhoneRecord].[RelatedPhoneRecordID] = @RelatedPhoneRecordID,
	[PhoneRecord].[PickUpTime] = @PickUpTime 
output 
	INSERTED.[ID],
	INSERTED.[PhoneNumber],
	INSERTED.[CallTime],
	INSERTED.[HangUpTime],
	INSERTED.[RecordVoicePath],
	INSERTED.[ServiceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[UserID],
	INSERTED.[PhoneType],
	INSERTED.[FileOriName],
	INSERTED.[RelatedPhoneRecordID],
	INSERTED.[PickUpTime]
into @table
WHERE 
	[PhoneRecord].[ID] = @ID

SELECT 
	[ID],
	[PhoneNumber],
	[CallTime],
	[HangUpTime],
	[RecordVoicePath],
	[ServiceID],
	[AddTime],
	[AddUserName],
	[UserID],
	[PhoneType],
	[FileOriName],
	[RelatedPhoneRecordID],
	[PickUpTime] 
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
DELETE FROM [dbo].[PhoneRecord]
WHERE 
	[PhoneRecord].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public PhoneRecord() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetPhoneRecord(this.ID));
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
	[PhoneRecord].[ID],
	[PhoneRecord].[PhoneNumber],
	[PhoneRecord].[CallTime],
	[PhoneRecord].[HangUpTime],
	[PhoneRecord].[RecordVoicePath],
	[PhoneRecord].[ServiceID],
	[PhoneRecord].[AddTime],
	[PhoneRecord].[AddUserName],
	[PhoneRecord].[UserID],
	[PhoneRecord].[PhoneType],
	[PhoneRecord].[FileOriName],
	[PhoneRecord].[RelatedPhoneRecordID],
	[PhoneRecord].[PickUpTime]
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
                return "PhoneRecord";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a PhoneRecord into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="callTime">callTime</param>
		/// <param name="hangUpTime">hangUpTime</param>
		/// <param name="recordVoicePath">recordVoicePath</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="userID">userID</param>
		/// <param name="phoneType">phoneType</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="relatedPhoneRecordID">relatedPhoneRecordID</param>
		/// <param name="pickUpTime">pickUpTime</param>
		public static void InsertPhoneRecord(string @phoneNumber, DateTime @callTime, DateTime @hangUpTime, string @recordVoicePath, int @serviceID, DateTime @addTime, string @addUserName, int @userID, int @phoneType, string @fileOriName, int @relatedPhoneRecordID, DateTime @pickUpTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertPhoneRecord(@phoneNumber, @callTime, @hangUpTime, @recordVoicePath, @serviceID, @addTime, @addUserName, @userID, @phoneType, @fileOriName, @relatedPhoneRecordID, @pickUpTime, helper);
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
		/// Insert a PhoneRecord into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="callTime">callTime</param>
		/// <param name="hangUpTime">hangUpTime</param>
		/// <param name="recordVoicePath">recordVoicePath</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="userID">userID</param>
		/// <param name="phoneType">phoneType</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="relatedPhoneRecordID">relatedPhoneRecordID</param>
		/// <param name="pickUpTime">pickUpTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertPhoneRecord(string @phoneNumber, DateTime @callTime, DateTime @hangUpTime, string @recordVoicePath, int @serviceID, DateTime @addTime, string @addUserName, int @userID, int @phoneType, string @fileOriName, int @relatedPhoneRecordID, DateTime @pickUpTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PhoneNumber] nvarchar(50),
	[CallTime] datetime,
	[HangUpTime] datetime,
	[RecordVoicePath] nvarchar(500),
	[ServiceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[UserID] int,
	[PhoneType] int,
	[FileOriName] nvarchar(260),
	[RelatedPhoneRecordID] int,
	[PickUpTime] datetime
);

INSERT INTO [dbo].[PhoneRecord] (
	[PhoneRecord].[PhoneNumber],
	[PhoneRecord].[CallTime],
	[PhoneRecord].[HangUpTime],
	[PhoneRecord].[RecordVoicePath],
	[PhoneRecord].[ServiceID],
	[PhoneRecord].[AddTime],
	[PhoneRecord].[AddUserName],
	[PhoneRecord].[UserID],
	[PhoneRecord].[PhoneType],
	[PhoneRecord].[FileOriName],
	[PhoneRecord].[RelatedPhoneRecordID],
	[PhoneRecord].[PickUpTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[PhoneNumber],
	INSERTED.[CallTime],
	INSERTED.[HangUpTime],
	INSERTED.[RecordVoicePath],
	INSERTED.[ServiceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[UserID],
	INSERTED.[PhoneType],
	INSERTED.[FileOriName],
	INSERTED.[RelatedPhoneRecordID],
	INSERTED.[PickUpTime]
into @table
VALUES ( 
	@PhoneNumber,
	@CallTime,
	@HangUpTime,
	@RecordVoicePath,
	@ServiceID,
	@AddTime,
	@AddUserName,
	@UserID,
	@PhoneType,
	@FileOriName,
	@RelatedPhoneRecordID,
	@PickUpTime 
); 

SELECT 
	[ID],
	[PhoneNumber],
	[CallTime],
	[HangUpTime],
	[RecordVoicePath],
	[ServiceID],
	[AddTime],
	[AddUserName],
	[UserID],
	[PhoneType],
	[FileOriName],
	[RelatedPhoneRecordID],
	[PickUpTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@CallTime", EntityBase.GetDatabaseValue(@callTime)));
			parameters.Add(new SqlParameter("@HangUpTime", EntityBase.GetDatabaseValue(@hangUpTime)));
			parameters.Add(new SqlParameter("@RecordVoicePath", EntityBase.GetDatabaseValue(@recordVoicePath)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@PhoneType", EntityBase.GetDatabaseValue(@phoneType)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			parameters.Add(new SqlParameter("@RelatedPhoneRecordID", EntityBase.GetDatabaseValue(@relatedPhoneRecordID)));
			parameters.Add(new SqlParameter("@PickUpTime", EntityBase.GetDatabaseValue(@pickUpTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a PhoneRecord into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="callTime">callTime</param>
		/// <param name="hangUpTime">hangUpTime</param>
		/// <param name="recordVoicePath">recordVoicePath</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="userID">userID</param>
		/// <param name="phoneType">phoneType</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="relatedPhoneRecordID">relatedPhoneRecordID</param>
		/// <param name="pickUpTime">pickUpTime</param>
		public static void UpdatePhoneRecord(int @iD, string @phoneNumber, DateTime @callTime, DateTime @hangUpTime, string @recordVoicePath, int @serviceID, DateTime @addTime, string @addUserName, int @userID, int @phoneType, string @fileOriName, int @relatedPhoneRecordID, DateTime @pickUpTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdatePhoneRecord(@iD, @phoneNumber, @callTime, @hangUpTime, @recordVoicePath, @serviceID, @addTime, @addUserName, @userID, @phoneType, @fileOriName, @relatedPhoneRecordID, @pickUpTime, helper);
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
		/// Updates a PhoneRecord into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="callTime">callTime</param>
		/// <param name="hangUpTime">hangUpTime</param>
		/// <param name="recordVoicePath">recordVoicePath</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="userID">userID</param>
		/// <param name="phoneType">phoneType</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="relatedPhoneRecordID">relatedPhoneRecordID</param>
		/// <param name="pickUpTime">pickUpTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdatePhoneRecord(int @iD, string @phoneNumber, DateTime @callTime, DateTime @hangUpTime, string @recordVoicePath, int @serviceID, DateTime @addTime, string @addUserName, int @userID, int @phoneType, string @fileOriName, int @relatedPhoneRecordID, DateTime @pickUpTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PhoneNumber] nvarchar(50),
	[CallTime] datetime,
	[HangUpTime] datetime,
	[RecordVoicePath] nvarchar(500),
	[ServiceID] int,
	[AddTime] datetime,
	[AddUserName] nvarchar(200),
	[UserID] int,
	[PhoneType] int,
	[FileOriName] nvarchar(260),
	[RelatedPhoneRecordID] int,
	[PickUpTime] datetime
);

UPDATE [dbo].[PhoneRecord] SET 
	[PhoneRecord].[PhoneNumber] = @PhoneNumber,
	[PhoneRecord].[CallTime] = @CallTime,
	[PhoneRecord].[HangUpTime] = @HangUpTime,
	[PhoneRecord].[RecordVoicePath] = @RecordVoicePath,
	[PhoneRecord].[ServiceID] = @ServiceID,
	[PhoneRecord].[AddTime] = @AddTime,
	[PhoneRecord].[AddUserName] = @AddUserName,
	[PhoneRecord].[UserID] = @UserID,
	[PhoneRecord].[PhoneType] = @PhoneType,
	[PhoneRecord].[FileOriName] = @FileOriName,
	[PhoneRecord].[RelatedPhoneRecordID] = @RelatedPhoneRecordID,
	[PhoneRecord].[PickUpTime] = @PickUpTime 
output 
	INSERTED.[ID],
	INSERTED.[PhoneNumber],
	INSERTED.[CallTime],
	INSERTED.[HangUpTime],
	INSERTED.[RecordVoicePath],
	INSERTED.[ServiceID],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[UserID],
	INSERTED.[PhoneType],
	INSERTED.[FileOriName],
	INSERTED.[RelatedPhoneRecordID],
	INSERTED.[PickUpTime]
into @table
WHERE 
	[PhoneRecord].[ID] = @ID

SELECT 
	[ID],
	[PhoneNumber],
	[CallTime],
	[HangUpTime],
	[RecordVoicePath],
	[ServiceID],
	[AddTime],
	[AddUserName],
	[UserID],
	[PhoneType],
	[FileOriName],
	[RelatedPhoneRecordID],
	[PickUpTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@CallTime", EntityBase.GetDatabaseValue(@callTime)));
			parameters.Add(new SqlParameter("@HangUpTime", EntityBase.GetDatabaseValue(@hangUpTime)));
			parameters.Add(new SqlParameter("@RecordVoicePath", EntityBase.GetDatabaseValue(@recordVoicePath)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@PhoneType", EntityBase.GetDatabaseValue(@phoneType)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			parameters.Add(new SqlParameter("@RelatedPhoneRecordID", EntityBase.GetDatabaseValue(@relatedPhoneRecordID)));
			parameters.Add(new SqlParameter("@PickUpTime", EntityBase.GetDatabaseValue(@pickUpTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a PhoneRecord from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeletePhoneRecord(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeletePhoneRecord(@iD, helper);
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
		/// Deletes a PhoneRecord from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeletePhoneRecord(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[PhoneRecord]
WHERE 
	[PhoneRecord].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new PhoneRecord object.
		/// </summary>
		/// <returns>The newly created PhoneRecord object.</returns>
		public static PhoneRecord CreatePhoneRecord()
		{
			return InitializeNew<PhoneRecord>();
		}
		
		/// <summary>
		/// Retrieve information for a PhoneRecord by a PhoneRecord's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>PhoneRecord</returns>
		public static PhoneRecord GetPhoneRecord(int @iD)
		{
			string commandText = @"
SELECT 
" + PhoneRecord.SelectFieldList + @"
FROM [dbo].[PhoneRecord] 
WHERE 
	[PhoneRecord].[ID] = @ID " + PhoneRecord.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PhoneRecord>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a PhoneRecord by a PhoneRecord's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>PhoneRecord</returns>
		public static PhoneRecord GetPhoneRecord(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + PhoneRecord.SelectFieldList + @"
FROM [dbo].[PhoneRecord] 
WHERE 
	[PhoneRecord].[ID] = @ID " + PhoneRecord.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<PhoneRecord>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection PhoneRecord objects.
		/// </summary>
		/// <returns>The retrieved collection of PhoneRecord objects.</returns>
		public static EntityList<PhoneRecord> GetPhoneRecords()
		{
			string commandText = @"
SELECT " + PhoneRecord.SelectFieldList + "FROM [dbo].[PhoneRecord] " + PhoneRecord.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<PhoneRecord>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection PhoneRecord objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PhoneRecord objects.</returns>
        public static EntityList<PhoneRecord> GetPhoneRecords(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PhoneRecord>(SelectFieldList, "FROM [dbo].[PhoneRecord]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection PhoneRecord objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of PhoneRecord objects.</returns>
        public static EntityList<PhoneRecord> GetPhoneRecords(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PhoneRecord>(SelectFieldList, "FROM [dbo].[PhoneRecord]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection PhoneRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of PhoneRecord objects.</returns>
		protected static EntityList<PhoneRecord> GetPhoneRecords(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPhoneRecords(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection PhoneRecord objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PhoneRecord objects.</returns>
		protected static EntityList<PhoneRecord> GetPhoneRecords(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPhoneRecords(string.Empty, where, parameters, PhoneRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PhoneRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of PhoneRecord objects.</returns>
		protected static EntityList<PhoneRecord> GetPhoneRecords(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetPhoneRecords(prefix, where, parameters, PhoneRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PhoneRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PhoneRecord objects.</returns>
		protected static EntityList<PhoneRecord> GetPhoneRecords(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPhoneRecords(string.Empty, where, parameters, PhoneRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PhoneRecord objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of PhoneRecord objects.</returns>
		protected static EntityList<PhoneRecord> GetPhoneRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetPhoneRecords(prefix, where, parameters, PhoneRecord.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection PhoneRecord objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of PhoneRecord objects.</returns>
		protected static EntityList<PhoneRecord> GetPhoneRecords(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + PhoneRecord.SelectFieldList + "FROM [dbo].[PhoneRecord] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<PhoneRecord>(reader);
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
        protected static EntityList<PhoneRecord> GetPhoneRecords(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<PhoneRecord>(SelectFieldList, "FROM [dbo].[PhoneRecord] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of PhoneRecord objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPhoneRecordCount()
        {
            return GetPhoneRecordCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of PhoneRecord objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetPhoneRecordCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[PhoneRecord] " + where;

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
		public static partial class PhoneRecord_Properties
		{
			public const string ID = "ID";
			public const string PhoneNumber = "PhoneNumber";
			public const string CallTime = "CallTime";
			public const string HangUpTime = "HangUpTime";
			public const string RecordVoicePath = "RecordVoicePath";
			public const string ServiceID = "ServiceID";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string UserID = "UserID";
			public const string PhoneType = "PhoneType";
			public const string FileOriName = "FileOriName";
			public const string RelatedPhoneRecordID = "RelatedPhoneRecordID";
			public const string PickUpTime = "PickUpTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"PhoneNumber" , "string:"},
    			 {"CallTime" , "DateTime:"},
    			 {"HangUpTime" , "DateTime:"},
    			 {"RecordVoicePath" , "string:"},
    			 {"ServiceID" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"UserID" , "int:"},
    			 {"PhoneType" , "int:1-来电 2-去电"},
    			 {"FileOriName" , "string:"},
    			 {"RelatedPhoneRecordID" , "int:"},
    			 {"PickUpTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
