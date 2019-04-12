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
	/// This object represents the properties and methods of a OperationLog.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class OperationLog 
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
		private DateTime _operationTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime OperationTime
		{
			[DebuggerStepThrough()]
			get { return this._operationTime; }
			set 
			{
				if (this._operationTime != value) 
				{
					this._operationTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operationMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OperationMan
		{
			[DebuggerStepThrough()]
			get { return this._operationMan; }
			set 
			{
				if (this._operationMan != value) 
				{
					this._operationMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operationContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OperationContent
		{
			[DebuggerStepThrough()]
			get { return this._operationContent; }
			set 
			{
				if (this._operationContent != value) 
				{
					this._operationContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationContent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operationKey = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OperationKey
		{
			[DebuggerStepThrough()]
			get { return this._operationKey; }
			set 
			{
				if (this._operationKey != value) 
				{
					this._operationKey = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationKey");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _logoutTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LogoutTime
		{
			[DebuggerStepThrough()]
			get { return this._logoutTime; }
			set 
			{
				if (this._logoutTime != value) 
				{
					this._logoutTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("LogoutTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iPAddress = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IPAddress
		{
			[DebuggerStepThrough()]
			get { return this._iPAddress; }
			set 
			{
				if (this._iPAddress != value) 
				{
					this._iPAddress = value;
					this.IsDirty = true;	
					OnPropertyChanged("IPAddress");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operationTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OperationTitle
		{
			[DebuggerStepThrough()]
			get { return this._operationTitle; }
			set 
			{
				if (this._operationTitle != value) 
				{
					this._operationTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operationTableKey = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OperationTableKey
		{
			[DebuggerStepThrough()]
			get { return this._operationTableKey; }
			set 
			{
				if (this._operationTableKey != value) 
				{
					this._operationTableKey = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationTableKey");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _operationTableName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OperationTableName
		{
			[DebuggerStepThrough()]
			get { return this._operationTableName; }
			set 
			{
				if (this._operationTableName != value) 
				{
					this._operationTableName = value;
					this.IsDirty = true;	
					OnPropertyChanged("OperationTableName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isHide = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsHide
		{
			[DebuggerStepThrough()]
			get { return this._isHide; }
			set 
			{
				if (this._isHide != value) 
				{
					this._isHide = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsHide");
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
	[OperationTime] datetime,
	[OperationMan] nvarchar(500),
	[OperationContent] ntext,
	[OperationKey] nvarchar(100),
	[LogoutTime] datetime,
	[IPAddress] nvarchar(200),
	[OperationTitle] nvarchar(100),
	[OperationTableKey] ntext,
	[OperationTableName] nvarchar(100),
	[IsHide] bit
);

INSERT INTO [dbo].[OperationLog] (
	[OperationLog].[OperationTime],
	[OperationLog].[OperationMan],
	[OperationLog].[OperationContent],
	[OperationLog].[OperationKey],
	[OperationLog].[LogoutTime],
	[OperationLog].[IPAddress],
	[OperationLog].[OperationTitle],
	[OperationLog].[OperationTableKey],
	[OperationLog].[OperationTableName],
	[OperationLog].[IsHide]
) 
output 
	INSERTED.[ID],
	INSERTED.[OperationTime],
	INSERTED.[OperationMan],
	INSERTED.[OperationContent],
	INSERTED.[OperationKey],
	INSERTED.[LogoutTime],
	INSERTED.[IPAddress],
	INSERTED.[OperationTitle],
	INSERTED.[OperationTableKey],
	INSERTED.[OperationTableName],
	INSERTED.[IsHide]
into @table
VALUES ( 
	@OperationTime,
	@OperationMan,
	@OperationContent,
	@OperationKey,
	@LogoutTime,
	@IPAddress,
	@OperationTitle,
	@OperationTableKey,
	@OperationTableName,
	@IsHide 
); 

SELECT 
	[ID],
	[OperationTime],
	[OperationMan],
	[OperationContent],
	[OperationKey],
	[LogoutTime],
	[IPAddress],
	[OperationTitle],
	[OperationTableKey],
	[OperationTableName],
	[IsHide] 
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
	[OperationTime] datetime,
	[OperationMan] nvarchar(500),
	[OperationContent] ntext,
	[OperationKey] nvarchar(100),
	[LogoutTime] datetime,
	[IPAddress] nvarchar(200),
	[OperationTitle] nvarchar(100),
	[OperationTableKey] ntext,
	[OperationTableName] nvarchar(100),
	[IsHide] bit
);

UPDATE [dbo].[OperationLog] SET 
	[OperationLog].[OperationTime] = @OperationTime,
	[OperationLog].[OperationMan] = @OperationMan,
	[OperationLog].[OperationContent] = @OperationContent,
	[OperationLog].[OperationKey] = @OperationKey,
	[OperationLog].[LogoutTime] = @LogoutTime,
	[OperationLog].[IPAddress] = @IPAddress,
	[OperationLog].[OperationTitle] = @OperationTitle,
	[OperationLog].[OperationTableKey] = @OperationTableKey,
	[OperationLog].[OperationTableName] = @OperationTableName,
	[OperationLog].[IsHide] = @IsHide 
output 
	INSERTED.[ID],
	INSERTED.[OperationTime],
	INSERTED.[OperationMan],
	INSERTED.[OperationContent],
	INSERTED.[OperationKey],
	INSERTED.[LogoutTime],
	INSERTED.[IPAddress],
	INSERTED.[OperationTitle],
	INSERTED.[OperationTableKey],
	INSERTED.[OperationTableName],
	INSERTED.[IsHide]
into @table
WHERE 
	[OperationLog].[ID] = @ID

SELECT 
	[ID],
	[OperationTime],
	[OperationMan],
	[OperationContent],
	[OperationKey],
	[LogoutTime],
	[IPAddress],
	[OperationTitle],
	[OperationTableKey],
	[OperationTableName],
	[IsHide] 
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
DELETE FROM [dbo].[OperationLog]
WHERE 
	[OperationLog].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public OperationLog() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetOperationLog(this.ID));
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
	[OperationLog].[ID],
	[OperationLog].[OperationTime],
	[OperationLog].[OperationMan],
	[OperationLog].[OperationContent],
	[OperationLog].[OperationKey],
	[OperationLog].[LogoutTime],
	[OperationLog].[IPAddress],
	[OperationLog].[OperationTitle],
	[OperationLog].[OperationTableKey],
	[OperationLog].[OperationTableName],
	[OperationLog].[IsHide]
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
                return "OperationLog";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a OperationLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="operationTime">operationTime</param>
		/// <param name="operationMan">operationMan</param>
		/// <param name="operationContent">operationContent</param>
		/// <param name="operationKey">operationKey</param>
		/// <param name="logoutTime">logoutTime</param>
		/// <param name="iPAddress">iPAddress</param>
		/// <param name="operationTitle">operationTitle</param>
		/// <param name="operationTableKey">operationTableKey</param>
		/// <param name="operationTableName">operationTableName</param>
		/// <param name="isHide">isHide</param>
		public static void InsertOperationLog(DateTime @operationTime, string @operationMan, string @operationContent, string @operationKey, DateTime @logoutTime, string @iPAddress, string @operationTitle, string @operationTableKey, string @operationTableName, bool @isHide)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertOperationLog(@operationTime, @operationMan, @operationContent, @operationKey, @logoutTime, @iPAddress, @operationTitle, @operationTableKey, @operationTableName, @isHide, helper);
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
		/// Insert a OperationLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="operationTime">operationTime</param>
		/// <param name="operationMan">operationMan</param>
		/// <param name="operationContent">operationContent</param>
		/// <param name="operationKey">operationKey</param>
		/// <param name="logoutTime">logoutTime</param>
		/// <param name="iPAddress">iPAddress</param>
		/// <param name="operationTitle">operationTitle</param>
		/// <param name="operationTableKey">operationTableKey</param>
		/// <param name="operationTableName">operationTableName</param>
		/// <param name="isHide">isHide</param>
		/// <param name="helper">helper</param>
		internal static void InsertOperationLog(DateTime @operationTime, string @operationMan, string @operationContent, string @operationKey, DateTime @logoutTime, string @iPAddress, string @operationTitle, string @operationTableKey, string @operationTableName, bool @isHide, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OperationTime] datetime,
	[OperationMan] nvarchar(500),
	[OperationContent] ntext,
	[OperationKey] nvarchar(100),
	[LogoutTime] datetime,
	[IPAddress] nvarchar(200),
	[OperationTitle] nvarchar(100),
	[OperationTableKey] ntext,
	[OperationTableName] nvarchar(100),
	[IsHide] bit
);

INSERT INTO [dbo].[OperationLog] (
	[OperationLog].[OperationTime],
	[OperationLog].[OperationMan],
	[OperationLog].[OperationContent],
	[OperationLog].[OperationKey],
	[OperationLog].[LogoutTime],
	[OperationLog].[IPAddress],
	[OperationLog].[OperationTitle],
	[OperationLog].[OperationTableKey],
	[OperationLog].[OperationTableName],
	[OperationLog].[IsHide]
) 
output 
	INSERTED.[ID],
	INSERTED.[OperationTime],
	INSERTED.[OperationMan],
	INSERTED.[OperationContent],
	INSERTED.[OperationKey],
	INSERTED.[LogoutTime],
	INSERTED.[IPAddress],
	INSERTED.[OperationTitle],
	INSERTED.[OperationTableKey],
	INSERTED.[OperationTableName],
	INSERTED.[IsHide]
into @table
VALUES ( 
	@OperationTime,
	@OperationMan,
	@OperationContent,
	@OperationKey,
	@LogoutTime,
	@IPAddress,
	@OperationTitle,
	@OperationTableKey,
	@OperationTableName,
	@IsHide 
); 

SELECT 
	[ID],
	[OperationTime],
	[OperationMan],
	[OperationContent],
	[OperationKey],
	[LogoutTime],
	[IPAddress],
	[OperationTitle],
	[OperationTableKey],
	[OperationTableName],
	[IsHide] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OperationTime", EntityBase.GetDatabaseValue(@operationTime)));
			parameters.Add(new SqlParameter("@OperationMan", EntityBase.GetDatabaseValue(@operationMan)));
			parameters.Add(new SqlParameter("@OperationContent", EntityBase.GetDatabaseValue(@operationContent)));
			parameters.Add(new SqlParameter("@OperationKey", EntityBase.GetDatabaseValue(@operationKey)));
			parameters.Add(new SqlParameter("@LogoutTime", EntityBase.GetDatabaseValue(@logoutTime)));
			parameters.Add(new SqlParameter("@IPAddress", EntityBase.GetDatabaseValue(@iPAddress)));
			parameters.Add(new SqlParameter("@OperationTitle", EntityBase.GetDatabaseValue(@operationTitle)));
			parameters.Add(new SqlParameter("@OperationTableKey", EntityBase.GetDatabaseValue(@operationTableKey)));
			parameters.Add(new SqlParameter("@OperationTableName", EntityBase.GetDatabaseValue(@operationTableName)));
			parameters.Add(new SqlParameter("@IsHide", @isHide));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a OperationLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="operationMan">operationMan</param>
		/// <param name="operationContent">operationContent</param>
		/// <param name="operationKey">operationKey</param>
		/// <param name="logoutTime">logoutTime</param>
		/// <param name="iPAddress">iPAddress</param>
		/// <param name="operationTitle">operationTitle</param>
		/// <param name="operationTableKey">operationTableKey</param>
		/// <param name="operationTableName">operationTableName</param>
		/// <param name="isHide">isHide</param>
		public static void UpdateOperationLog(int @iD, DateTime @operationTime, string @operationMan, string @operationContent, string @operationKey, DateTime @logoutTime, string @iPAddress, string @operationTitle, string @operationTableKey, string @operationTableName, bool @isHide)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateOperationLog(@iD, @operationTime, @operationMan, @operationContent, @operationKey, @logoutTime, @iPAddress, @operationTitle, @operationTableKey, @operationTableName, @isHide, helper);
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
		/// Updates a OperationLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="operationTime">operationTime</param>
		/// <param name="operationMan">operationMan</param>
		/// <param name="operationContent">operationContent</param>
		/// <param name="operationKey">operationKey</param>
		/// <param name="logoutTime">logoutTime</param>
		/// <param name="iPAddress">iPAddress</param>
		/// <param name="operationTitle">operationTitle</param>
		/// <param name="operationTableKey">operationTableKey</param>
		/// <param name="operationTableName">operationTableName</param>
		/// <param name="isHide">isHide</param>
		/// <param name="helper">helper</param>
		internal static void UpdateOperationLog(int @iD, DateTime @operationTime, string @operationMan, string @operationContent, string @operationKey, DateTime @logoutTime, string @iPAddress, string @operationTitle, string @operationTableKey, string @operationTableName, bool @isHide, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OperationTime] datetime,
	[OperationMan] nvarchar(500),
	[OperationContent] ntext,
	[OperationKey] nvarchar(100),
	[LogoutTime] datetime,
	[IPAddress] nvarchar(200),
	[OperationTitle] nvarchar(100),
	[OperationTableKey] ntext,
	[OperationTableName] nvarchar(100),
	[IsHide] bit
);

UPDATE [dbo].[OperationLog] SET 
	[OperationLog].[OperationTime] = @OperationTime,
	[OperationLog].[OperationMan] = @OperationMan,
	[OperationLog].[OperationContent] = @OperationContent,
	[OperationLog].[OperationKey] = @OperationKey,
	[OperationLog].[LogoutTime] = @LogoutTime,
	[OperationLog].[IPAddress] = @IPAddress,
	[OperationLog].[OperationTitle] = @OperationTitle,
	[OperationLog].[OperationTableKey] = @OperationTableKey,
	[OperationLog].[OperationTableName] = @OperationTableName,
	[OperationLog].[IsHide] = @IsHide 
output 
	INSERTED.[ID],
	INSERTED.[OperationTime],
	INSERTED.[OperationMan],
	INSERTED.[OperationContent],
	INSERTED.[OperationKey],
	INSERTED.[LogoutTime],
	INSERTED.[IPAddress],
	INSERTED.[OperationTitle],
	INSERTED.[OperationTableKey],
	INSERTED.[OperationTableName],
	INSERTED.[IsHide]
into @table
WHERE 
	[OperationLog].[ID] = @ID

SELECT 
	[ID],
	[OperationTime],
	[OperationMan],
	[OperationContent],
	[OperationKey],
	[LogoutTime],
	[IPAddress],
	[OperationTitle],
	[OperationTableKey],
	[OperationTableName],
	[IsHide] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OperationTime", EntityBase.GetDatabaseValue(@operationTime)));
			parameters.Add(new SqlParameter("@OperationMan", EntityBase.GetDatabaseValue(@operationMan)));
			parameters.Add(new SqlParameter("@OperationContent", EntityBase.GetDatabaseValue(@operationContent)));
			parameters.Add(new SqlParameter("@OperationKey", EntityBase.GetDatabaseValue(@operationKey)));
			parameters.Add(new SqlParameter("@LogoutTime", EntityBase.GetDatabaseValue(@logoutTime)));
			parameters.Add(new SqlParameter("@IPAddress", EntityBase.GetDatabaseValue(@iPAddress)));
			parameters.Add(new SqlParameter("@OperationTitle", EntityBase.GetDatabaseValue(@operationTitle)));
			parameters.Add(new SqlParameter("@OperationTableKey", EntityBase.GetDatabaseValue(@operationTableKey)));
			parameters.Add(new SqlParameter("@OperationTableName", EntityBase.GetDatabaseValue(@operationTableName)));
			parameters.Add(new SqlParameter("@IsHide", @isHide));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a OperationLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteOperationLog(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteOperationLog(@iD, helper);
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
		/// Deletes a OperationLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteOperationLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[OperationLog]
WHERE 
	[OperationLog].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new OperationLog object.
		/// </summary>
		/// <returns>The newly created OperationLog object.</returns>
		public static OperationLog CreateOperationLog()
		{
			return InitializeNew<OperationLog>();
		}
		
		/// <summary>
		/// Retrieve information for a OperationLog by a OperationLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>OperationLog</returns>
		public static OperationLog GetOperationLog(int @iD)
		{
			string commandText = @"
SELECT 
" + OperationLog.SelectFieldList + @"
FROM [dbo].[OperationLog] 
WHERE 
	[OperationLog].[ID] = @ID " + OperationLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<OperationLog>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a OperationLog by a OperationLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>OperationLog</returns>
		public static OperationLog GetOperationLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + OperationLog.SelectFieldList + @"
FROM [dbo].[OperationLog] 
WHERE 
	[OperationLog].[ID] = @ID " + OperationLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<OperationLog>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection OperationLog objects.
		/// </summary>
		/// <returns>The retrieved collection of OperationLog objects.</returns>
		public static EntityList<OperationLog> GetOperationLogs()
		{
			string commandText = @"
SELECT " + OperationLog.SelectFieldList + "FROM [dbo].[OperationLog] " + OperationLog.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<OperationLog>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection OperationLog objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of OperationLog objects.</returns>
        public static EntityList<OperationLog> GetOperationLogs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<OperationLog>(SelectFieldList, "FROM [dbo].[OperationLog]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection OperationLog objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of OperationLog objects.</returns>
        public static EntityList<OperationLog> GetOperationLogs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<OperationLog>(SelectFieldList, "FROM [dbo].[OperationLog]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection OperationLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of OperationLog objects.</returns>
		protected static EntityList<OperationLog> GetOperationLogs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetOperationLogs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection OperationLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of OperationLog objects.</returns>
		protected static EntityList<OperationLog> GetOperationLogs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetOperationLogs(string.Empty, where, parameters, OperationLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection OperationLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of OperationLog objects.</returns>
		protected static EntityList<OperationLog> GetOperationLogs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetOperationLogs(prefix, where, parameters, OperationLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection OperationLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of OperationLog objects.</returns>
		protected static EntityList<OperationLog> GetOperationLogs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetOperationLogs(string.Empty, where, parameters, OperationLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection OperationLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of OperationLog objects.</returns>
		protected static EntityList<OperationLog> GetOperationLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetOperationLogs(prefix, where, parameters, OperationLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection OperationLog objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of OperationLog objects.</returns>
		protected static EntityList<OperationLog> GetOperationLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + OperationLog.SelectFieldList + "FROM [dbo].[OperationLog] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<OperationLog>(reader);
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
        protected static EntityList<OperationLog> GetOperationLogs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<OperationLog>(SelectFieldList, "FROM [dbo].[OperationLog] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of OperationLog objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetOperationLogCount()
        {
            return GetOperationLogCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of OperationLog objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetOperationLogCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[OperationLog] " + where;

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
		public static partial class OperationLog_Properties
		{
			public const string ID = "ID";
			public const string OperationTime = "OperationTime";
			public const string OperationMan = "OperationMan";
			public const string OperationContent = "OperationContent";
			public const string OperationKey = "OperationKey";
			public const string LogoutTime = "LogoutTime";
			public const string IPAddress = "IPAddress";
			public const string OperationTitle = "OperationTitle";
			public const string OperationTableKey = "OperationTableKey";
			public const string OperationTableName = "OperationTableName";
			public const string IsHide = "IsHide";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OperationTime" , "DateTime:"},
    			 {"OperationMan" , "string:"},
    			 {"OperationContent" , "string:"},
    			 {"OperationKey" , "string:"},
    			 {"LogoutTime" , "DateTime:"},
    			 {"IPAddress" , "string:"},
    			 {"OperationTitle" , "string:"},
    			 {"OperationTableKey" , "string:"},
    			 {"OperationTableName" , "string:"},
    			 {"IsHide" , "bool:"},
            };
		}
		#endregion
	}
}
