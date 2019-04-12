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
	/// This object represents the properties and methods of a Wechat_Service.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_Service 
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
		private string _serviceType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ServiceType
		{
			[DebuggerStepThrough()]
			get { return this._serviceType; }
			set 
			{
				if (this._serviceType != value) 
				{
					this._serviceType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceType");
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
		private DateTime _serviceAddTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime ServiceAddTime
		{
			[DebuggerStepThrough()]
			get { return this._serviceAddTime; }
			set 
			{
				if (this._serviceAddTime != value) 
				{
					this._serviceAddTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceAddTime");
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
		[DataObjectField(false, false, false)]
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
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
			set 
			{
				if (this._fullName != value) 
				{
					this._fullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FullName");
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
		private string _serviceMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ServiceMan
		{
			[DebuggerStepThrough()]
			get { return this._serviceMan; }
			set 
			{
				if (this._serviceMan != value) 
				{
					this._serviceMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceMan");
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
	[ServiceType] nvarchar(50),
	[ServiceContent] ntext,
	[PhoneNumber] nvarchar(20),
	[ServiceAddTime] datetime,
	[OpenID] nvarchar(200),
	[AddTime] datetime,
	[RoomID] int,
	[FullName] nvarchar(500),
	[AddUserID] int,
	[ServiceMan] nvarchar(100),
	[ServiceFrom] nvarchar(50),
	[PublicProjectID] int
);

INSERT INTO [dbo].[Wechat_Service] (
	[Wechat_Service].[ServiceType],
	[Wechat_Service].[ServiceContent],
	[Wechat_Service].[PhoneNumber],
	[Wechat_Service].[ServiceAddTime],
	[Wechat_Service].[OpenID],
	[Wechat_Service].[AddTime],
	[Wechat_Service].[RoomID],
	[Wechat_Service].[FullName],
	[Wechat_Service].[AddUserID],
	[Wechat_Service].[ServiceMan],
	[Wechat_Service].[ServiceFrom],
	[Wechat_Service].[PublicProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceType],
	INSERTED.[ServiceContent],
	INSERTED.[PhoneNumber],
	INSERTED.[ServiceAddTime],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[RoomID],
	INSERTED.[FullName],
	INSERTED.[AddUserID],
	INSERTED.[ServiceMan],
	INSERTED.[ServiceFrom],
	INSERTED.[PublicProjectID]
into @table
VALUES ( 
	@ServiceType,
	@ServiceContent,
	@PhoneNumber,
	@ServiceAddTime,
	@OpenID,
	@AddTime,
	@RoomID,
	@FullName,
	@AddUserID,
	@ServiceMan,
	@ServiceFrom,
	@PublicProjectID 
); 

SELECT 
	[ID],
	[ServiceType],
	[ServiceContent],
	[PhoneNumber],
	[ServiceAddTime],
	[OpenID],
	[AddTime],
	[RoomID],
	[FullName],
	[AddUserID],
	[ServiceMan],
	[ServiceFrom],
	[PublicProjectID] 
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
	[ServiceType] nvarchar(50),
	[ServiceContent] ntext,
	[PhoneNumber] nvarchar(20),
	[ServiceAddTime] datetime,
	[OpenID] nvarchar(200),
	[AddTime] datetime,
	[RoomID] int,
	[FullName] nvarchar(500),
	[AddUserID] int,
	[ServiceMan] nvarchar(100),
	[ServiceFrom] nvarchar(50),
	[PublicProjectID] int
);

UPDATE [dbo].[Wechat_Service] SET 
	[Wechat_Service].[ServiceType] = @ServiceType,
	[Wechat_Service].[ServiceContent] = @ServiceContent,
	[Wechat_Service].[PhoneNumber] = @PhoneNumber,
	[Wechat_Service].[ServiceAddTime] = @ServiceAddTime,
	[Wechat_Service].[OpenID] = @OpenID,
	[Wechat_Service].[AddTime] = @AddTime,
	[Wechat_Service].[RoomID] = @RoomID,
	[Wechat_Service].[FullName] = @FullName,
	[Wechat_Service].[AddUserID] = @AddUserID,
	[Wechat_Service].[ServiceMan] = @ServiceMan,
	[Wechat_Service].[ServiceFrom] = @ServiceFrom,
	[Wechat_Service].[PublicProjectID] = @PublicProjectID 
output 
	INSERTED.[ID],
	INSERTED.[ServiceType],
	INSERTED.[ServiceContent],
	INSERTED.[PhoneNumber],
	INSERTED.[ServiceAddTime],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[RoomID],
	INSERTED.[FullName],
	INSERTED.[AddUserID],
	INSERTED.[ServiceMan],
	INSERTED.[ServiceFrom],
	INSERTED.[PublicProjectID]
into @table
WHERE 
	[Wechat_Service].[ID] = @ID

SELECT 
	[ID],
	[ServiceType],
	[ServiceContent],
	[PhoneNumber],
	[ServiceAddTime],
	[OpenID],
	[AddTime],
	[RoomID],
	[FullName],
	[AddUserID],
	[ServiceMan],
	[ServiceFrom],
	[PublicProjectID] 
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
DELETE FROM [dbo].[Wechat_Service]
WHERE 
	[Wechat_Service].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_Service() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_Service(this.ID));
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
	[Wechat_Service].[ID],
	[Wechat_Service].[ServiceType],
	[Wechat_Service].[ServiceContent],
	[Wechat_Service].[PhoneNumber],
	[Wechat_Service].[ServiceAddTime],
	[Wechat_Service].[OpenID],
	[Wechat_Service].[AddTime],
	[Wechat_Service].[RoomID],
	[Wechat_Service].[FullName],
	[Wechat_Service].[AddUserID],
	[Wechat_Service].[ServiceMan],
	[Wechat_Service].[ServiceFrom],
	[Wechat_Service].[PublicProjectID]
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
                return "Wechat_Service";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_Service into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceType">serviceType</param>
		/// <param name="serviceContent">serviceContent</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="serviceAddTime">serviceAddTime</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="roomID">roomID</param>
		/// <param name="fullName">fullName</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="serviceMan">serviceMan</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="publicProjectID">publicProjectID</param>
		public static void InsertWechat_Service(string @serviceType, string @serviceContent, string @phoneNumber, DateTime @serviceAddTime, string @openID, DateTime @addTime, int @roomID, string @fullName, int @addUserID, string @serviceMan, string @serviceFrom, int @publicProjectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_Service(@serviceType, @serviceContent, @phoneNumber, @serviceAddTime, @openID, @addTime, @roomID, @fullName, @addUserID, @serviceMan, @serviceFrom, @publicProjectID, helper);
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
		/// Insert a Wechat_Service into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceType">serviceType</param>
		/// <param name="serviceContent">serviceContent</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="serviceAddTime">serviceAddTime</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="roomID">roomID</param>
		/// <param name="fullName">fullName</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="serviceMan">serviceMan</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="publicProjectID">publicProjectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_Service(string @serviceType, string @serviceContent, string @phoneNumber, DateTime @serviceAddTime, string @openID, DateTime @addTime, int @roomID, string @fullName, int @addUserID, string @serviceMan, string @serviceFrom, int @publicProjectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceType] nvarchar(50),
	[ServiceContent] ntext,
	[PhoneNumber] nvarchar(20),
	[ServiceAddTime] datetime,
	[OpenID] nvarchar(200),
	[AddTime] datetime,
	[RoomID] int,
	[FullName] nvarchar(500),
	[AddUserID] int,
	[ServiceMan] nvarchar(100),
	[ServiceFrom] nvarchar(50),
	[PublicProjectID] int
);

INSERT INTO [dbo].[Wechat_Service] (
	[Wechat_Service].[ServiceType],
	[Wechat_Service].[ServiceContent],
	[Wechat_Service].[PhoneNumber],
	[Wechat_Service].[ServiceAddTime],
	[Wechat_Service].[OpenID],
	[Wechat_Service].[AddTime],
	[Wechat_Service].[RoomID],
	[Wechat_Service].[FullName],
	[Wechat_Service].[AddUserID],
	[Wechat_Service].[ServiceMan],
	[Wechat_Service].[ServiceFrom],
	[Wechat_Service].[PublicProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceType],
	INSERTED.[ServiceContent],
	INSERTED.[PhoneNumber],
	INSERTED.[ServiceAddTime],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[RoomID],
	INSERTED.[FullName],
	INSERTED.[AddUserID],
	INSERTED.[ServiceMan],
	INSERTED.[ServiceFrom],
	INSERTED.[PublicProjectID]
into @table
VALUES ( 
	@ServiceType,
	@ServiceContent,
	@PhoneNumber,
	@ServiceAddTime,
	@OpenID,
	@AddTime,
	@RoomID,
	@FullName,
	@AddUserID,
	@ServiceMan,
	@ServiceFrom,
	@PublicProjectID 
); 

SELECT 
	[ID],
	[ServiceType],
	[ServiceContent],
	[PhoneNumber],
	[ServiceAddTime],
	[OpenID],
	[AddTime],
	[RoomID],
	[FullName],
	[AddUserID],
	[ServiceMan],
	[ServiceFrom],
	[PublicProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceType", EntityBase.GetDatabaseValue(@serviceType)));
			parameters.Add(new SqlParameter("@ServiceContent", EntityBase.GetDatabaseValue(@serviceContent)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@ServiceAddTime", EntityBase.GetDatabaseValue(@serviceAddTime)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			parameters.Add(new SqlParameter("@AddUserID", EntityBase.GetDatabaseValue(@addUserID)));
			parameters.Add(new SqlParameter("@ServiceMan", EntityBase.GetDatabaseValue(@serviceMan)));
			parameters.Add(new SqlParameter("@ServiceFrom", EntityBase.GetDatabaseValue(@serviceFrom)));
			parameters.Add(new SqlParameter("@PublicProjectID", EntityBase.GetDatabaseValue(@publicProjectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_Service into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="serviceContent">serviceContent</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="serviceAddTime">serviceAddTime</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="roomID">roomID</param>
		/// <param name="fullName">fullName</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="serviceMan">serviceMan</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="publicProjectID">publicProjectID</param>
		public static void UpdateWechat_Service(int @iD, string @serviceType, string @serviceContent, string @phoneNumber, DateTime @serviceAddTime, string @openID, DateTime @addTime, int @roomID, string @fullName, int @addUserID, string @serviceMan, string @serviceFrom, int @publicProjectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_Service(@iD, @serviceType, @serviceContent, @phoneNumber, @serviceAddTime, @openID, @addTime, @roomID, @fullName, @addUserID, @serviceMan, @serviceFrom, @publicProjectID, helper);
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
		/// Updates a Wechat_Service into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceType">serviceType</param>
		/// <param name="serviceContent">serviceContent</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="serviceAddTime">serviceAddTime</param>
		/// <param name="openID">openID</param>
		/// <param name="addTime">addTime</param>
		/// <param name="roomID">roomID</param>
		/// <param name="fullName">fullName</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="serviceMan">serviceMan</param>
		/// <param name="serviceFrom">serviceFrom</param>
		/// <param name="publicProjectID">publicProjectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_Service(int @iD, string @serviceType, string @serviceContent, string @phoneNumber, DateTime @serviceAddTime, string @openID, DateTime @addTime, int @roomID, string @fullName, int @addUserID, string @serviceMan, string @serviceFrom, int @publicProjectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceType] nvarchar(50),
	[ServiceContent] ntext,
	[PhoneNumber] nvarchar(20),
	[ServiceAddTime] datetime,
	[OpenID] nvarchar(200),
	[AddTime] datetime,
	[RoomID] int,
	[FullName] nvarchar(500),
	[AddUserID] int,
	[ServiceMan] nvarchar(100),
	[ServiceFrom] nvarchar(50),
	[PublicProjectID] int
);

UPDATE [dbo].[Wechat_Service] SET 
	[Wechat_Service].[ServiceType] = @ServiceType,
	[Wechat_Service].[ServiceContent] = @ServiceContent,
	[Wechat_Service].[PhoneNumber] = @PhoneNumber,
	[Wechat_Service].[ServiceAddTime] = @ServiceAddTime,
	[Wechat_Service].[OpenID] = @OpenID,
	[Wechat_Service].[AddTime] = @AddTime,
	[Wechat_Service].[RoomID] = @RoomID,
	[Wechat_Service].[FullName] = @FullName,
	[Wechat_Service].[AddUserID] = @AddUserID,
	[Wechat_Service].[ServiceMan] = @ServiceMan,
	[Wechat_Service].[ServiceFrom] = @ServiceFrom,
	[Wechat_Service].[PublicProjectID] = @PublicProjectID 
output 
	INSERTED.[ID],
	INSERTED.[ServiceType],
	INSERTED.[ServiceContent],
	INSERTED.[PhoneNumber],
	INSERTED.[ServiceAddTime],
	INSERTED.[OpenID],
	INSERTED.[AddTime],
	INSERTED.[RoomID],
	INSERTED.[FullName],
	INSERTED.[AddUserID],
	INSERTED.[ServiceMan],
	INSERTED.[ServiceFrom],
	INSERTED.[PublicProjectID]
into @table
WHERE 
	[Wechat_Service].[ID] = @ID

SELECT 
	[ID],
	[ServiceType],
	[ServiceContent],
	[PhoneNumber],
	[ServiceAddTime],
	[OpenID],
	[AddTime],
	[RoomID],
	[FullName],
	[AddUserID],
	[ServiceMan],
	[ServiceFrom],
	[PublicProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceType", EntityBase.GetDatabaseValue(@serviceType)));
			parameters.Add(new SqlParameter("@ServiceContent", EntityBase.GetDatabaseValue(@serviceContent)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@ServiceAddTime", EntityBase.GetDatabaseValue(@serviceAddTime)));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			parameters.Add(new SqlParameter("@AddUserID", EntityBase.GetDatabaseValue(@addUserID)));
			parameters.Add(new SqlParameter("@ServiceMan", EntityBase.GetDatabaseValue(@serviceMan)));
			parameters.Add(new SqlParameter("@ServiceFrom", EntityBase.GetDatabaseValue(@serviceFrom)));
			parameters.Add(new SqlParameter("@PublicProjectID", EntityBase.GetDatabaseValue(@publicProjectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_Service from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_Service(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_Service(@iD, helper);
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
		/// Deletes a Wechat_Service from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_Service(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_Service]
WHERE 
	[Wechat_Service].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_Service object.
		/// </summary>
		/// <returns>The newly created Wechat_Service object.</returns>
		public static Wechat_Service CreateWechat_Service()
		{
			return InitializeNew<Wechat_Service>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_Service by a Wechat_Service's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_Service</returns>
		public static Wechat_Service GetWechat_Service(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_Service.SelectFieldList + @"
FROM [dbo].[Wechat_Service] 
WHERE 
	[Wechat_Service].[ID] = @ID " + Wechat_Service.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Service>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_Service by a Wechat_Service's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_Service</returns>
		public static Wechat_Service GetWechat_Service(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_Service.SelectFieldList + @"
FROM [dbo].[Wechat_Service] 
WHERE 
	[Wechat_Service].[ID] = @ID " + Wechat_Service.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_Service>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Service objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_Service objects.</returns>
		public static EntityList<Wechat_Service> GetWechat_Services()
		{
			string commandText = @"
SELECT " + Wechat_Service.SelectFieldList + "FROM [dbo].[Wechat_Service] " + Wechat_Service.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_Service>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_Service objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Service objects.</returns>
        public static EntityList<Wechat_Service> GetWechat_Services(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Service>(SelectFieldList, "FROM [dbo].[Wechat_Service]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_Service objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_Service objects.</returns>
        public static EntityList<Wechat_Service> GetWechat_Services(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Service>(SelectFieldList, "FROM [dbo].[Wechat_Service]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_Service objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Service objects.</returns>
		protected static EntityList<Wechat_Service> GetWechat_Services(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Services(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Service objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Service objects.</returns>
		protected static EntityList<Wechat_Service> GetWechat_Services(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Services(string.Empty, where, parameters, Wechat_Service.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Service objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Service objects.</returns>
		protected static EntityList<Wechat_Service> GetWechat_Services(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_Services(prefix, where, parameters, Wechat_Service.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Service objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Service objects.</returns>
		protected static EntityList<Wechat_Service> GetWechat_Services(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Services(string.Empty, where, parameters, Wechat_Service.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Service objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_Service objects.</returns>
		protected static EntityList<Wechat_Service> GetWechat_Services(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_Services(prefix, where, parameters, Wechat_Service.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_Service objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_Service objects.</returns>
		protected static EntityList<Wechat_Service> GetWechat_Services(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_Service.SelectFieldList + "FROM [dbo].[Wechat_Service] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_Service>(reader);
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
        protected static EntityList<Wechat_Service> GetWechat_Services(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_Service>(SelectFieldList, "FROM [dbo].[Wechat_Service] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_Service objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ServiceCount()
        {
            return GetWechat_ServiceCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_Service objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ServiceCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_Service] " + where;

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
		public static partial class Wechat_Service_Properties
		{
			public const string ID = "ID";
			public const string ServiceType = "ServiceType";
			public const string ServiceContent = "ServiceContent";
			public const string PhoneNumber = "PhoneNumber";
			public const string ServiceAddTime = "ServiceAddTime";
			public const string OpenID = "OpenID";
			public const string AddTime = "AddTime";
			public const string RoomID = "RoomID";
			public const string FullName = "FullName";
			public const string AddUserID = "AddUserID";
			public const string ServiceMan = "ServiceMan";
			public const string ServiceFrom = "ServiceFrom";
			public const string PublicProjectID = "PublicProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceType" , "string:"},
    			 {"ServiceContent" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"ServiceAddTime" , "DateTime:"},
    			 {"OpenID" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"RoomID" , "int:"},
    			 {"FullName" , "string:"},
    			 {"AddUserID" , "int:"},
    			 {"ServiceMan" , "string:"},
    			 {"ServiceFrom" , "string:"},
    			 {"PublicProjectID" , "int:"},
            };
		}
		#endregion
	}
}
