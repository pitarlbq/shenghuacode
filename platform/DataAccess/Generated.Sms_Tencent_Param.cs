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
	/// This object represents the properties and methods of a Sms_Tencent_Param.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Sms_Tencent_Param 
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
		private int _smsTemplateID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SmsTemplateID
		{
			[DebuggerStepThrough()]
			get { return this._smsTemplateID; }
			set 
			{
				if (this._smsTemplateID != value) 
				{
					this._smsTemplateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("SmsTemplateID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _paramType = int.MinValue;
		/// <summary>
		/// 1- 业主姓名 2-业主电话 3-业主姓名(业主电话) 4-收费项目金额 5-固定值
		/// </summary>
        [Description("1- 业主姓名 2-业主电话 3-业主姓名(业主电话) 4-收费项目金额 5-固定值")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParamType
		{
			[DebuggerStepThrough()]
			get { return this._paramType; }
			set 
			{
				if (this._paramType != value) 
				{
					this._paramType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParamType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _paramChargeID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParamChargeID
		{
			[DebuggerStepThrough()]
			get { return this._paramChargeID; }
			set 
			{
				if (this._paramChargeID != value) 
				{
					this._paramChargeID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParamChargeID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _paramValue = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ParamValue
		{
			[DebuggerStepThrough()]
			get { return this._paramValue; }
			set 
			{
				if (this._paramValue != value) 
				{
					this._paramValue = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParamValue");
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
		[DataObjectField(false, false, false)]
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
	[SmsTemplateID] int,
	[ParamType] int,
	[ParamChargeID] int,
	[ParamValue] nvarchar(100),
	[AddTime] datetime,
	[AddUserName] nvarchar(100)
);

INSERT INTO [dbo].[Sms_Tencent_Params] (
	[Sms_Tencent_Params].[SmsTemplateID],
	[Sms_Tencent_Params].[ParamType],
	[Sms_Tencent_Params].[ParamChargeID],
	[Sms_Tencent_Params].[ParamValue],
	[Sms_Tencent_Params].[AddTime],
	[Sms_Tencent_Params].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[SmsTemplateID],
	INSERTED.[ParamType],
	INSERTED.[ParamChargeID],
	INSERTED.[ParamValue],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@SmsTemplateID,
	@ParamType,
	@ParamChargeID,
	@ParamValue,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[SmsTemplateID],
	[ParamType],
	[ParamChargeID],
	[ParamValue],
	[AddTime],
	[AddUserName] 
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
	[SmsTemplateID] int,
	[ParamType] int,
	[ParamChargeID] int,
	[ParamValue] nvarchar(100),
	[AddTime] datetime,
	[AddUserName] nvarchar(100)
);

UPDATE [dbo].[Sms_Tencent_Params] SET 
	[Sms_Tencent_Params].[SmsTemplateID] = @SmsTemplateID,
	[Sms_Tencent_Params].[ParamType] = @ParamType,
	[Sms_Tencent_Params].[ParamChargeID] = @ParamChargeID,
	[Sms_Tencent_Params].[ParamValue] = @ParamValue,
	[Sms_Tencent_Params].[AddTime] = @AddTime,
	[Sms_Tencent_Params].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[SmsTemplateID],
	INSERTED.[ParamType],
	INSERTED.[ParamChargeID],
	INSERTED.[ParamValue],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[Sms_Tencent_Params].[ID] = @ID

SELECT 
	[ID],
	[SmsTemplateID],
	[ParamType],
	[ParamChargeID],
	[ParamValue],
	[AddTime],
	[AddUserName] 
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
DELETE FROM [dbo].[Sms_Tencent_Params]
WHERE 
	[Sms_Tencent_Params].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Sms_Tencent_Param() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSms_Tencent_Param(this.ID));
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
	[Sms_Tencent_Params].[ID],
	[Sms_Tencent_Params].[SmsTemplateID],
	[Sms_Tencent_Params].[ParamType],
	[Sms_Tencent_Params].[ParamChargeID],
	[Sms_Tencent_Params].[ParamValue],
	[Sms_Tencent_Params].[AddTime],
	[Sms_Tencent_Params].[AddUserName]
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
                return "Sms_Tencent_Params";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Sms_Tencent_Param into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="smsTemplateID">smsTemplateID</param>
		/// <param name="paramType">paramType</param>
		/// <param name="paramChargeID">paramChargeID</param>
		/// <param name="paramValue">paramValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void InsertSms_Tencent_Param(int @smsTemplateID, int @paramType, int @paramChargeID, string @paramValue, DateTime @addTime, string @addUserName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSms_Tencent_Param(@smsTemplateID, @paramType, @paramChargeID, @paramValue, @addTime, @addUserName, helper);
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
		/// Insert a Sms_Tencent_Param into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="smsTemplateID">smsTemplateID</param>
		/// <param name="paramType">paramType</param>
		/// <param name="paramChargeID">paramChargeID</param>
		/// <param name="paramValue">paramValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void InsertSms_Tencent_Param(int @smsTemplateID, int @paramType, int @paramChargeID, string @paramValue, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SmsTemplateID] int,
	[ParamType] int,
	[ParamChargeID] int,
	[ParamValue] nvarchar(100),
	[AddTime] datetime,
	[AddUserName] nvarchar(100)
);

INSERT INTO [dbo].[Sms_Tencent_Params] (
	[Sms_Tencent_Params].[SmsTemplateID],
	[Sms_Tencent_Params].[ParamType],
	[Sms_Tencent_Params].[ParamChargeID],
	[Sms_Tencent_Params].[ParamValue],
	[Sms_Tencent_Params].[AddTime],
	[Sms_Tencent_Params].[AddUserName]
) 
output 
	INSERTED.[ID],
	INSERTED.[SmsTemplateID],
	INSERTED.[ParamType],
	INSERTED.[ParamChargeID],
	INSERTED.[ParamValue],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
VALUES ( 
	@SmsTemplateID,
	@ParamType,
	@ParamChargeID,
	@ParamValue,
	@AddTime,
	@AddUserName 
); 

SELECT 
	[ID],
	[SmsTemplateID],
	[ParamType],
	[ParamChargeID],
	[ParamValue],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@SmsTemplateID", EntityBase.GetDatabaseValue(@smsTemplateID)));
			parameters.Add(new SqlParameter("@ParamType", EntityBase.GetDatabaseValue(@paramType)));
			parameters.Add(new SqlParameter("@ParamChargeID", EntityBase.GetDatabaseValue(@paramChargeID)));
			parameters.Add(new SqlParameter("@ParamValue", EntityBase.GetDatabaseValue(@paramValue)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Sms_Tencent_Param into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="smsTemplateID">smsTemplateID</param>
		/// <param name="paramType">paramType</param>
		/// <param name="paramChargeID">paramChargeID</param>
		/// <param name="paramValue">paramValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		public static void UpdateSms_Tencent_Param(int @iD, int @smsTemplateID, int @paramType, int @paramChargeID, string @paramValue, DateTime @addTime, string @addUserName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSms_Tencent_Param(@iD, @smsTemplateID, @paramType, @paramChargeID, @paramValue, @addTime, @addUserName, helper);
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
		/// Updates a Sms_Tencent_Param into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="smsTemplateID">smsTemplateID</param>
		/// <param name="paramType">paramType</param>
		/// <param name="paramChargeID">paramChargeID</param>
		/// <param name="paramValue">paramValue</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSms_Tencent_Param(int @iD, int @smsTemplateID, int @paramType, int @paramChargeID, string @paramValue, DateTime @addTime, string @addUserName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[SmsTemplateID] int,
	[ParamType] int,
	[ParamChargeID] int,
	[ParamValue] nvarchar(100),
	[AddTime] datetime,
	[AddUserName] nvarchar(100)
);

UPDATE [dbo].[Sms_Tencent_Params] SET 
	[Sms_Tencent_Params].[SmsTemplateID] = @SmsTemplateID,
	[Sms_Tencent_Params].[ParamType] = @ParamType,
	[Sms_Tencent_Params].[ParamChargeID] = @ParamChargeID,
	[Sms_Tencent_Params].[ParamValue] = @ParamValue,
	[Sms_Tencent_Params].[AddTime] = @AddTime,
	[Sms_Tencent_Params].[AddUserName] = @AddUserName 
output 
	INSERTED.[ID],
	INSERTED.[SmsTemplateID],
	INSERTED.[ParamType],
	INSERTED.[ParamChargeID],
	INSERTED.[ParamValue],
	INSERTED.[AddTime],
	INSERTED.[AddUserName]
into @table
WHERE 
	[Sms_Tencent_Params].[ID] = @ID

SELECT 
	[ID],
	[SmsTemplateID],
	[ParamType],
	[ParamChargeID],
	[ParamValue],
	[AddTime],
	[AddUserName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@SmsTemplateID", EntityBase.GetDatabaseValue(@smsTemplateID)));
			parameters.Add(new SqlParameter("@ParamType", EntityBase.GetDatabaseValue(@paramType)));
			parameters.Add(new SqlParameter("@ParamChargeID", EntityBase.GetDatabaseValue(@paramChargeID)));
			parameters.Add(new SqlParameter("@ParamValue", EntityBase.GetDatabaseValue(@paramValue)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Sms_Tencent_Param from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSms_Tencent_Param(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSms_Tencent_Param(@iD, helper);
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
		/// Deletes a Sms_Tencent_Param from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSms_Tencent_Param(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Sms_Tencent_Params]
WHERE 
	[Sms_Tencent_Params].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Sms_Tencent_Param object.
		/// </summary>
		/// <returns>The newly created Sms_Tencent_Param object.</returns>
		public static Sms_Tencent_Param CreateSms_Tencent_Param()
		{
			return InitializeNew<Sms_Tencent_Param>();
		}
		
		/// <summary>
		/// Retrieve information for a Sms_Tencent_Param by a Sms_Tencent_Param's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Sms_Tencent_Param</returns>
		public static Sms_Tencent_Param GetSms_Tencent_Param(int @iD)
		{
			string commandText = @"
SELECT 
" + Sms_Tencent_Param.SelectFieldList + @"
FROM [dbo].[Sms_Tencent_Params] 
WHERE 
	[Sms_Tencent_Params].[ID] = @ID " + Sms_Tencent_Param.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Sms_Tencent_Param>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Sms_Tencent_Param by a Sms_Tencent_Param's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Sms_Tencent_Param</returns>
		public static Sms_Tencent_Param GetSms_Tencent_Param(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Sms_Tencent_Param.SelectFieldList + @"
FROM [dbo].[Sms_Tencent_Params] 
WHERE 
	[Sms_Tencent_Params].[ID] = @ID " + Sms_Tencent_Param.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Sms_Tencent_Param>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Param objects.
		/// </summary>
		/// <returns>The retrieved collection of Sms_Tencent_Param objects.</returns>
		public static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params()
		{
			string commandText = @"
SELECT " + Sms_Tencent_Param.SelectFieldList + "FROM [dbo].[Sms_Tencent_Params] " + Sms_Tencent_Param.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Sms_Tencent_Param>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Sms_Tencent_Param objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Sms_Tencent_Param objects.</returns>
        public static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sms_Tencent_Param>(SelectFieldList, "FROM [dbo].[Sms_Tencent_Params]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Sms_Tencent_Param objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Sms_Tencent_Param objects.</returns>
        public static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sms_Tencent_Param>(SelectFieldList, "FROM [dbo].[Sms_Tencent_Params]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Param objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Sms_Tencent_Param objects.</returns>
		protected static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSms_Tencent_Params(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Param objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Sms_Tencent_Param objects.</returns>
		protected static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSms_Tencent_Params(string.Empty, where, parameters, Sms_Tencent_Param.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Param objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Sms_Tencent_Param objects.</returns>
		protected static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSms_Tencent_Params(prefix, where, parameters, Sms_Tencent_Param.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Param objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Sms_Tencent_Param objects.</returns>
		protected static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSms_Tencent_Params(string.Empty, where, parameters, Sms_Tencent_Param.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Param objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Sms_Tencent_Param objects.</returns>
		protected static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSms_Tencent_Params(prefix, where, parameters, Sms_Tencent_Param.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Param objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Sms_Tencent_Param objects.</returns>
		protected static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Sms_Tencent_Param.SelectFieldList + "FROM [dbo].[Sms_Tencent_Params] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Sms_Tencent_Param>(reader);
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
        protected static EntityList<Sms_Tencent_Param> GetSms_Tencent_Params(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sms_Tencent_Param>(SelectFieldList, "FROM [dbo].[Sms_Tencent_Params] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Sms_Tencent_Param objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSms_Tencent_ParamCount()
        {
            return GetSms_Tencent_ParamCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Sms_Tencent_Param objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSms_Tencent_ParamCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Sms_Tencent_Params] " + where;

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
		public static partial class Sms_Tencent_Param_Properties
		{
			public const string ID = "ID";
			public const string SmsTemplateID = "SmsTemplateID";
			public const string ParamType = "ParamType";
			public const string ParamChargeID = "ParamChargeID";
			public const string ParamValue = "ParamValue";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"SmsTemplateID" , "int:"},
    			 {"ParamType" , "int:1- 业主姓名 2-业主电话 3-业主姓名(业主电话) 4-收费项目金额 5-固定值"},
    			 {"ParamChargeID" , "int:"},
    			 {"ParamValue" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
            };
		}
		#endregion
	}
}
