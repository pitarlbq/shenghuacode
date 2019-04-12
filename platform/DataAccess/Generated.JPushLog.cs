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
	/// This object represents the properties and methods of a JPushLog.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class JPushLog 
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
		private string _androidUserID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AndroidUserID
		{
			[DebuggerStepThrough()]
			get { return this._androidUserID; }
			set 
			{
				if (this._androidUserID != value) 
				{
					this._androidUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AndroidUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iOSUserID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IOSUserID
		{
			[DebuggerStepThrough()]
			get { return this._iOSUserID; }
			set 
			{
				if (this._iOSUserID != value) 
				{
					this._iOSUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("IOSUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _pushTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PushTime
		{
			[DebuggerStepThrough()]
			get { return this._pushTime; }
			set 
			{
				if (this._pushTime != value) 
				{
					this._pushTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PushTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _pushContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PushContent
		{
			[DebuggerStepThrough()]
			get { return this._pushContent; }
			set 
			{
				if (this._pushContent != value) 
				{
					this._pushContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("PushContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _pushResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PushResult
		{
			[DebuggerStepThrough()]
			get { return this._pushResult; }
			set 
			{
				if (this._pushResult != value) 
				{
					this._pushResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("PushResult");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pushType = int.MinValue;
		/// <summary>
		/// 1-客户服务 2-物业公告 3-小区新闻 4-系统通知 5-设备维保 6-限时购通知 7-团购通知 8-生日通知 9-退款通知 10 发货通知 11-绩效考核
		/// </summary>
        [Description("1-客户服务 2-物业公告 3-小区新闻 4-系统通知 5-设备维保 6-限时购通知 7-团购通知 8-生日通知 9-退款通知 10 发货通知 11-绩效考核")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int PushType
		{
			[DebuggerStepThrough()]
			get { return this._pushType; }
			set 
			{
				if (this._pushType != value) 
				{
					this._pushType = value;
					this.IsDirty = true;	
					OnPropertyChanged("PushType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _relatedID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelatedID
		{
			[DebuggerStepThrough()]
			get { return this._relatedID; }
			set 
			{
				if (this._relatedID != value) 
				{
					this._relatedID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelatedID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isPushed = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsPushed
		{
			[DebuggerStepThrough()]
			get { return this._isPushed; }
			set 
			{
				if (this._isPushed != value) 
				{
					this._isPushed = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsPushed");
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
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Title
		{
			[DebuggerStepThrough()]
			get { return this._title; }
			set 
			{
				if (this._title != value) 
				{
					this._title = value;
					this.IsDirty = true;	
					OnPropertyChanged("Title");
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
	[AndroidUserID] ntext,
	[IOSUserID] ntext,
	[PushTime] datetime,
	[PushContent] ntext,
	[PushResult] ntext,
	[PushType] int,
	[RelatedID] int,
	[IsPushed] bit,
	[AddTime] datetime,
	[Title] nvarchar(200)
);

INSERT INTO [dbo].[JPushLog] (
	[JPushLog].[AndroidUserID],
	[JPushLog].[IOSUserID],
	[JPushLog].[PushTime],
	[JPushLog].[PushContent],
	[JPushLog].[PushResult],
	[JPushLog].[PushType],
	[JPushLog].[RelatedID],
	[JPushLog].[IsPushed],
	[JPushLog].[AddTime],
	[JPushLog].[Title]
) 
output 
	INSERTED.[ID],
	INSERTED.[AndroidUserID],
	INSERTED.[IOSUserID],
	INSERTED.[PushTime],
	INSERTED.[PushContent],
	INSERTED.[PushResult],
	INSERTED.[PushType],
	INSERTED.[RelatedID],
	INSERTED.[IsPushed],
	INSERTED.[AddTime],
	INSERTED.[Title]
into @table
VALUES ( 
	@AndroidUserID,
	@IOSUserID,
	@PushTime,
	@PushContent,
	@PushResult,
	@PushType,
	@RelatedID,
	@IsPushed,
	@AddTime,
	@Title 
); 

SELECT 
	[ID],
	[AndroidUserID],
	[IOSUserID],
	[PushTime],
	[PushContent],
	[PushResult],
	[PushType],
	[RelatedID],
	[IsPushed],
	[AddTime],
	[Title] 
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
	[AndroidUserID] ntext,
	[IOSUserID] ntext,
	[PushTime] datetime,
	[PushContent] ntext,
	[PushResult] ntext,
	[PushType] int,
	[RelatedID] int,
	[IsPushed] bit,
	[AddTime] datetime,
	[Title] nvarchar(200)
);

UPDATE [dbo].[JPushLog] SET 
	[JPushLog].[AndroidUserID] = @AndroidUserID,
	[JPushLog].[IOSUserID] = @IOSUserID,
	[JPushLog].[PushTime] = @PushTime,
	[JPushLog].[PushContent] = @PushContent,
	[JPushLog].[PushResult] = @PushResult,
	[JPushLog].[PushType] = @PushType,
	[JPushLog].[RelatedID] = @RelatedID,
	[JPushLog].[IsPushed] = @IsPushed,
	[JPushLog].[AddTime] = @AddTime,
	[JPushLog].[Title] = @Title 
output 
	INSERTED.[ID],
	INSERTED.[AndroidUserID],
	INSERTED.[IOSUserID],
	INSERTED.[PushTime],
	INSERTED.[PushContent],
	INSERTED.[PushResult],
	INSERTED.[PushType],
	INSERTED.[RelatedID],
	INSERTED.[IsPushed],
	INSERTED.[AddTime],
	INSERTED.[Title]
into @table
WHERE 
	[JPushLog].[ID] = @ID

SELECT 
	[ID],
	[AndroidUserID],
	[IOSUserID],
	[PushTime],
	[PushContent],
	[PushResult],
	[PushType],
	[RelatedID],
	[IsPushed],
	[AddTime],
	[Title] 
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
DELETE FROM [dbo].[JPushLog]
WHERE 
	[JPushLog].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public JPushLog() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetJPushLog(this.ID));
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
	[JPushLog].[ID],
	[JPushLog].[AndroidUserID],
	[JPushLog].[IOSUserID],
	[JPushLog].[PushTime],
	[JPushLog].[PushContent],
	[JPushLog].[PushResult],
	[JPushLog].[PushType],
	[JPushLog].[RelatedID],
	[JPushLog].[IsPushed],
	[JPushLog].[AddTime],
	[JPushLog].[Title]
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
                return "JPushLog";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a JPushLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="androidUserID">androidUserID</param>
		/// <param name="iOSUserID">iOSUserID</param>
		/// <param name="pushTime">pushTime</param>
		/// <param name="pushContent">pushContent</param>
		/// <param name="pushResult">pushResult</param>
		/// <param name="pushType">pushType</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="isPushed">isPushed</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		public static void InsertJPushLog(string @androidUserID, string @iOSUserID, DateTime @pushTime, string @pushContent, string @pushResult, int @pushType, int @relatedID, bool @isPushed, DateTime @addTime, string @title)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertJPushLog(@androidUserID, @iOSUserID, @pushTime, @pushContent, @pushResult, @pushType, @relatedID, @isPushed, @addTime, @title, helper);
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
		/// Insert a JPushLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="androidUserID">androidUserID</param>
		/// <param name="iOSUserID">iOSUserID</param>
		/// <param name="pushTime">pushTime</param>
		/// <param name="pushContent">pushContent</param>
		/// <param name="pushResult">pushResult</param>
		/// <param name="pushType">pushType</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="isPushed">isPushed</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="helper">helper</param>
		internal static void InsertJPushLog(string @androidUserID, string @iOSUserID, DateTime @pushTime, string @pushContent, string @pushResult, int @pushType, int @relatedID, bool @isPushed, DateTime @addTime, string @title, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AndroidUserID] ntext,
	[IOSUserID] ntext,
	[PushTime] datetime,
	[PushContent] ntext,
	[PushResult] ntext,
	[PushType] int,
	[RelatedID] int,
	[IsPushed] bit,
	[AddTime] datetime,
	[Title] nvarchar(200)
);

INSERT INTO [dbo].[JPushLog] (
	[JPushLog].[AndroidUserID],
	[JPushLog].[IOSUserID],
	[JPushLog].[PushTime],
	[JPushLog].[PushContent],
	[JPushLog].[PushResult],
	[JPushLog].[PushType],
	[JPushLog].[RelatedID],
	[JPushLog].[IsPushed],
	[JPushLog].[AddTime],
	[JPushLog].[Title]
) 
output 
	INSERTED.[ID],
	INSERTED.[AndroidUserID],
	INSERTED.[IOSUserID],
	INSERTED.[PushTime],
	INSERTED.[PushContent],
	INSERTED.[PushResult],
	INSERTED.[PushType],
	INSERTED.[RelatedID],
	INSERTED.[IsPushed],
	INSERTED.[AddTime],
	INSERTED.[Title]
into @table
VALUES ( 
	@AndroidUserID,
	@IOSUserID,
	@PushTime,
	@PushContent,
	@PushResult,
	@PushType,
	@RelatedID,
	@IsPushed,
	@AddTime,
	@Title 
); 

SELECT 
	[ID],
	[AndroidUserID],
	[IOSUserID],
	[PushTime],
	[PushContent],
	[PushResult],
	[PushType],
	[RelatedID],
	[IsPushed],
	[AddTime],
	[Title] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@AndroidUserID", EntityBase.GetDatabaseValue(@androidUserID)));
			parameters.Add(new SqlParameter("@IOSUserID", EntityBase.GetDatabaseValue(@iOSUserID)));
			parameters.Add(new SqlParameter("@PushTime", EntityBase.GetDatabaseValue(@pushTime)));
			parameters.Add(new SqlParameter("@PushContent", EntityBase.GetDatabaseValue(@pushContent)));
			parameters.Add(new SqlParameter("@PushResult", EntityBase.GetDatabaseValue(@pushResult)));
			parameters.Add(new SqlParameter("@PushType", EntityBase.GetDatabaseValue(@pushType)));
			parameters.Add(new SqlParameter("@RelatedID", EntityBase.GetDatabaseValue(@relatedID)));
			parameters.Add(new SqlParameter("@IsPushed", @isPushed));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a JPushLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="androidUserID">androidUserID</param>
		/// <param name="iOSUserID">iOSUserID</param>
		/// <param name="pushTime">pushTime</param>
		/// <param name="pushContent">pushContent</param>
		/// <param name="pushResult">pushResult</param>
		/// <param name="pushType">pushType</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="isPushed">isPushed</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		public static void UpdateJPushLog(int @iD, string @androidUserID, string @iOSUserID, DateTime @pushTime, string @pushContent, string @pushResult, int @pushType, int @relatedID, bool @isPushed, DateTime @addTime, string @title)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateJPushLog(@iD, @androidUserID, @iOSUserID, @pushTime, @pushContent, @pushResult, @pushType, @relatedID, @isPushed, @addTime, @title, helper);
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
		/// Updates a JPushLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="androidUserID">androidUserID</param>
		/// <param name="iOSUserID">iOSUserID</param>
		/// <param name="pushTime">pushTime</param>
		/// <param name="pushContent">pushContent</param>
		/// <param name="pushResult">pushResult</param>
		/// <param name="pushType">pushType</param>
		/// <param name="relatedID">relatedID</param>
		/// <param name="isPushed">isPushed</param>
		/// <param name="addTime">addTime</param>
		/// <param name="title">title</param>
		/// <param name="helper">helper</param>
		internal static void UpdateJPushLog(int @iD, string @androidUserID, string @iOSUserID, DateTime @pushTime, string @pushContent, string @pushResult, int @pushType, int @relatedID, bool @isPushed, DateTime @addTime, string @title, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[AndroidUserID] ntext,
	[IOSUserID] ntext,
	[PushTime] datetime,
	[PushContent] ntext,
	[PushResult] ntext,
	[PushType] int,
	[RelatedID] int,
	[IsPushed] bit,
	[AddTime] datetime,
	[Title] nvarchar(200)
);

UPDATE [dbo].[JPushLog] SET 
	[JPushLog].[AndroidUserID] = @AndroidUserID,
	[JPushLog].[IOSUserID] = @IOSUserID,
	[JPushLog].[PushTime] = @PushTime,
	[JPushLog].[PushContent] = @PushContent,
	[JPushLog].[PushResult] = @PushResult,
	[JPushLog].[PushType] = @PushType,
	[JPushLog].[RelatedID] = @RelatedID,
	[JPushLog].[IsPushed] = @IsPushed,
	[JPushLog].[AddTime] = @AddTime,
	[JPushLog].[Title] = @Title 
output 
	INSERTED.[ID],
	INSERTED.[AndroidUserID],
	INSERTED.[IOSUserID],
	INSERTED.[PushTime],
	INSERTED.[PushContent],
	INSERTED.[PushResult],
	INSERTED.[PushType],
	INSERTED.[RelatedID],
	INSERTED.[IsPushed],
	INSERTED.[AddTime],
	INSERTED.[Title]
into @table
WHERE 
	[JPushLog].[ID] = @ID

SELECT 
	[ID],
	[AndroidUserID],
	[IOSUserID],
	[PushTime],
	[PushContent],
	[PushResult],
	[PushType],
	[RelatedID],
	[IsPushed],
	[AddTime],
	[Title] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@AndroidUserID", EntityBase.GetDatabaseValue(@androidUserID)));
			parameters.Add(new SqlParameter("@IOSUserID", EntityBase.GetDatabaseValue(@iOSUserID)));
			parameters.Add(new SqlParameter("@PushTime", EntityBase.GetDatabaseValue(@pushTime)));
			parameters.Add(new SqlParameter("@PushContent", EntityBase.GetDatabaseValue(@pushContent)));
			parameters.Add(new SqlParameter("@PushResult", EntityBase.GetDatabaseValue(@pushResult)));
			parameters.Add(new SqlParameter("@PushType", EntityBase.GetDatabaseValue(@pushType)));
			parameters.Add(new SqlParameter("@RelatedID", EntityBase.GetDatabaseValue(@relatedID)));
			parameters.Add(new SqlParameter("@IsPushed", @isPushed));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a JPushLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteJPushLog(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteJPushLog(@iD, helper);
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
		/// Deletes a JPushLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteJPushLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[JPushLog]
WHERE 
	[JPushLog].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new JPushLog object.
		/// </summary>
		/// <returns>The newly created JPushLog object.</returns>
		public static JPushLog CreateJPushLog()
		{
			return InitializeNew<JPushLog>();
		}
		
		/// <summary>
		/// Retrieve information for a JPushLog by a JPushLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>JPushLog</returns>
		public static JPushLog GetJPushLog(int @iD)
		{
			string commandText = @"
SELECT 
" + JPushLog.SelectFieldList + @"
FROM [dbo].[JPushLog] 
WHERE 
	[JPushLog].[ID] = @ID " + JPushLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<JPushLog>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a JPushLog by a JPushLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>JPushLog</returns>
		public static JPushLog GetJPushLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + JPushLog.SelectFieldList + @"
FROM [dbo].[JPushLog] 
WHERE 
	[JPushLog].[ID] = @ID " + JPushLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<JPushLog>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection JPushLog objects.
		/// </summary>
		/// <returns>The retrieved collection of JPushLog objects.</returns>
		public static EntityList<JPushLog> GetJPushLogs()
		{
			string commandText = @"
SELECT " + JPushLog.SelectFieldList + "FROM [dbo].[JPushLog] " + JPushLog.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<JPushLog>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection JPushLog objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of JPushLog objects.</returns>
        public static EntityList<JPushLog> GetJPushLogs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<JPushLog>(SelectFieldList, "FROM [dbo].[JPushLog]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection JPushLog objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of JPushLog objects.</returns>
        public static EntityList<JPushLog> GetJPushLogs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<JPushLog>(SelectFieldList, "FROM [dbo].[JPushLog]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection JPushLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of JPushLog objects.</returns>
		protected static EntityList<JPushLog> GetJPushLogs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetJPushLogs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection JPushLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of JPushLog objects.</returns>
		protected static EntityList<JPushLog> GetJPushLogs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetJPushLogs(string.Empty, where, parameters, JPushLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection JPushLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of JPushLog objects.</returns>
		protected static EntityList<JPushLog> GetJPushLogs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetJPushLogs(prefix, where, parameters, JPushLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection JPushLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of JPushLog objects.</returns>
		protected static EntityList<JPushLog> GetJPushLogs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetJPushLogs(string.Empty, where, parameters, JPushLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection JPushLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of JPushLog objects.</returns>
		protected static EntityList<JPushLog> GetJPushLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetJPushLogs(prefix, where, parameters, JPushLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection JPushLog objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of JPushLog objects.</returns>
		protected static EntityList<JPushLog> GetJPushLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + JPushLog.SelectFieldList + "FROM [dbo].[JPushLog] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<JPushLog>(reader);
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
        protected static EntityList<JPushLog> GetJPushLogs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<JPushLog>(SelectFieldList, "FROM [dbo].[JPushLog] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of JPushLog objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetJPushLogCount()
        {
            return GetJPushLogCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of JPushLog objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetJPushLogCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[JPushLog] " + where;

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
		public static partial class JPushLog_Properties
		{
			public const string ID = "ID";
			public const string AndroidUserID = "AndroidUserID";
			public const string IOSUserID = "IOSUserID";
			public const string PushTime = "PushTime";
			public const string PushContent = "PushContent";
			public const string PushResult = "PushResult";
			public const string PushType = "PushType";
			public const string RelatedID = "RelatedID";
			public const string IsPushed = "IsPushed";
			public const string AddTime = "AddTime";
			public const string Title = "Title";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"AndroidUserID" , "string:"},
    			 {"IOSUserID" , "string:"},
    			 {"PushTime" , "DateTime:"},
    			 {"PushContent" , "string:"},
    			 {"PushResult" , "string:"},
    			 {"PushType" , "int:1-客户服务 2-物业公告 3-小区新闻 4-系统通知 5-设备维保 6-限时购通知 7-团购通知 8-生日通知 9-退款通知 10 发货通知 11-绩效考核"},
    			 {"RelatedID" , "int:"},
    			 {"IsPushed" , "bool:"},
    			 {"AddTime" , "DateTime:"},
    			 {"Title" , "string:"},
            };
		}
		#endregion
	}
}
