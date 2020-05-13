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
	/// This object represents the properties and methods of a Sms_SendResult.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Sms_SendResult 
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
		private string _templateID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string TemplateID
		{
			[DebuggerStepThrough()]
			get { return this._templateID; }
			set 
			{
				if (this._templateID != value) 
				{
					this._templateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _sendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public DateTime SendTime
		{
			[DebuggerStepThrough()]
			get { return this._sendTime; }
			set 
			{
				if (this._sendTime != value) 
				{
					this._sendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sendStatus = int.MinValue;
		/// <summary>
		/// 发送状态 1-成功 2-失败
		/// </summary>
        [Description("发送状态 1-成功 2-失败")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SendStatus
		{
			[DebuggerStepThrough()]
			get { return this._sendStatus; }
			set 
			{
				if (this._sendStatus != value) 
				{
					this._sendStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sendResult = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SendResult
		{
			[DebuggerStepThrough()]
			get { return this._sendResult; }
			set 
			{
				if (this._sendResult != value) 
				{
					this._sendResult = value;
					this.IsDirty = true;	
					OnPropertyChanged("SendResult");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _customerID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CustomerID
		{
			[DebuggerStepThrough()]
			get { return this._customerID; }
			set 
			{
				if (this._customerID != value) 
				{
					this._customerID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomerID");
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
	[TemplateID] nvarchar(200),
	[SendTime] datetime,
	[SendStatus] int,
	[SendResult] nvarchar(500),
	[CustomerID] int
);

INSERT INTO [dbo].[Sms_SendResult] (
	[Sms_SendResult].[TemplateID],
	[Sms_SendResult].[SendTime],
	[Sms_SendResult].[SendStatus],
	[Sms_SendResult].[SendResult],
	[Sms_SendResult].[CustomerID]
) 
output 
	INSERTED.[ID],
	INSERTED.[TemplateID],
	INSERTED.[SendTime],
	INSERTED.[SendStatus],
	INSERTED.[SendResult],
	INSERTED.[CustomerID]
into @table
VALUES ( 
	@TemplateID,
	@SendTime,
	@SendStatus,
	@SendResult,
	@CustomerID 
); 

SELECT 
	[ID],
	[TemplateID],
	[SendTime],
	[SendStatus],
	[SendResult],
	[CustomerID] 
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
	[TemplateID] nvarchar(200),
	[SendTime] datetime,
	[SendStatus] int,
	[SendResult] nvarchar(500),
	[CustomerID] int
);

UPDATE [dbo].[Sms_SendResult] SET 
	[Sms_SendResult].[TemplateID] = @TemplateID,
	[Sms_SendResult].[SendTime] = @SendTime,
	[Sms_SendResult].[SendStatus] = @SendStatus,
	[Sms_SendResult].[SendResult] = @SendResult,
	[Sms_SendResult].[CustomerID] = @CustomerID 
output 
	INSERTED.[ID],
	INSERTED.[TemplateID],
	INSERTED.[SendTime],
	INSERTED.[SendStatus],
	INSERTED.[SendResult],
	INSERTED.[CustomerID]
into @table
WHERE 
	[Sms_SendResult].[ID] = @ID

SELECT 
	[ID],
	[TemplateID],
	[SendTime],
	[SendStatus],
	[SendResult],
	[CustomerID] 
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
DELETE FROM [dbo].[Sms_SendResult]
WHERE 
	[Sms_SendResult].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Sms_SendResult() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSms_SendResult(this.ID));
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
	[Sms_SendResult].[ID],
	[Sms_SendResult].[TemplateID],
	[Sms_SendResult].[SendTime],
	[Sms_SendResult].[SendStatus],
	[Sms_SendResult].[SendResult],
	[Sms_SendResult].[CustomerID]
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
                return "Sms_SendResult";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Sms_SendResult into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="templateID">templateID</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="sendStatus">sendStatus</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="customerID">customerID</param>
		public static void InsertSms_SendResult(string @templateID, DateTime @sendTime, int @sendStatus, string @sendResult, int @customerID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSms_SendResult(@templateID, @sendTime, @sendStatus, @sendResult, @customerID, helper);
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
		/// Insert a Sms_SendResult into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="templateID">templateID</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="sendStatus">sendStatus</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="customerID">customerID</param>
		/// <param name="helper">helper</param>
		internal static void InsertSms_SendResult(string @templateID, DateTime @sendTime, int @sendStatus, string @sendResult, int @customerID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TemplateID] nvarchar(200),
	[SendTime] datetime,
	[SendStatus] int,
	[SendResult] nvarchar(500),
	[CustomerID] int
);

INSERT INTO [dbo].[Sms_SendResult] (
	[Sms_SendResult].[TemplateID],
	[Sms_SendResult].[SendTime],
	[Sms_SendResult].[SendStatus],
	[Sms_SendResult].[SendResult],
	[Sms_SendResult].[CustomerID]
) 
output 
	INSERTED.[ID],
	INSERTED.[TemplateID],
	INSERTED.[SendTime],
	INSERTED.[SendStatus],
	INSERTED.[SendResult],
	INSERTED.[CustomerID]
into @table
VALUES ( 
	@TemplateID,
	@SendTime,
	@SendStatus,
	@SendResult,
	@CustomerID 
); 

SELECT 
	[ID],
	[TemplateID],
	[SendTime],
	[SendStatus],
	[SendResult],
	[CustomerID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TemplateID", EntityBase.GetDatabaseValue(@templateID)));
			parameters.Add(new SqlParameter("@SendTime", EntityBase.GetDatabaseValue(@sendTime)));
			parameters.Add(new SqlParameter("@SendStatus", EntityBase.GetDatabaseValue(@sendStatus)));
			parameters.Add(new SqlParameter("@SendResult", EntityBase.GetDatabaseValue(@sendResult)));
			parameters.Add(new SqlParameter("@CustomerID", EntityBase.GetDatabaseValue(@customerID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Sms_SendResult into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="templateID">templateID</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="sendStatus">sendStatus</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="customerID">customerID</param>
		public static void UpdateSms_SendResult(int @iD, string @templateID, DateTime @sendTime, int @sendStatus, string @sendResult, int @customerID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSms_SendResult(@iD, @templateID, @sendTime, @sendStatus, @sendResult, @customerID, helper);
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
		/// Updates a Sms_SendResult into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="templateID">templateID</param>
		/// <param name="sendTime">sendTime</param>
		/// <param name="sendStatus">sendStatus</param>
		/// <param name="sendResult">sendResult</param>
		/// <param name="customerID">customerID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSms_SendResult(int @iD, string @templateID, DateTime @sendTime, int @sendStatus, string @sendResult, int @customerID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TemplateID] nvarchar(200),
	[SendTime] datetime,
	[SendStatus] int,
	[SendResult] nvarchar(500),
	[CustomerID] int
);

UPDATE [dbo].[Sms_SendResult] SET 
	[Sms_SendResult].[TemplateID] = @TemplateID,
	[Sms_SendResult].[SendTime] = @SendTime,
	[Sms_SendResult].[SendStatus] = @SendStatus,
	[Sms_SendResult].[SendResult] = @SendResult,
	[Sms_SendResult].[CustomerID] = @CustomerID 
output 
	INSERTED.[ID],
	INSERTED.[TemplateID],
	INSERTED.[SendTime],
	INSERTED.[SendStatus],
	INSERTED.[SendResult],
	INSERTED.[CustomerID]
into @table
WHERE 
	[Sms_SendResult].[ID] = @ID

SELECT 
	[ID],
	[TemplateID],
	[SendTime],
	[SendStatus],
	[SendResult],
	[CustomerID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@TemplateID", EntityBase.GetDatabaseValue(@templateID)));
			parameters.Add(new SqlParameter("@SendTime", EntityBase.GetDatabaseValue(@sendTime)));
			parameters.Add(new SqlParameter("@SendStatus", EntityBase.GetDatabaseValue(@sendStatus)));
			parameters.Add(new SqlParameter("@SendResult", EntityBase.GetDatabaseValue(@sendResult)));
			parameters.Add(new SqlParameter("@CustomerID", EntityBase.GetDatabaseValue(@customerID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Sms_SendResult from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSms_SendResult(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSms_SendResult(@iD, helper);
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
		/// Deletes a Sms_SendResult from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSms_SendResult(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Sms_SendResult]
WHERE 
	[Sms_SendResult].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Sms_SendResult object.
		/// </summary>
		/// <returns>The newly created Sms_SendResult object.</returns>
		public static Sms_SendResult CreateSms_SendResult()
		{
			return InitializeNew<Sms_SendResult>();
		}
		
		/// <summary>
		/// Retrieve information for a Sms_SendResult by a Sms_SendResult's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Sms_SendResult</returns>
		public static Sms_SendResult GetSms_SendResult(int @iD)
		{
			string commandText = @"
SELECT 
" + Sms_SendResult.SelectFieldList + @"
FROM [dbo].[Sms_SendResult] 
WHERE 
	[Sms_SendResult].[ID] = @ID " + Sms_SendResult.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Sms_SendResult>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Sms_SendResult by a Sms_SendResult's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Sms_SendResult</returns>
		public static Sms_SendResult GetSms_SendResult(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Sms_SendResult.SelectFieldList + @"
FROM [dbo].[Sms_SendResult] 
WHERE 
	[Sms_SendResult].[ID] = @ID " + Sms_SendResult.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Sms_SendResult>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Sms_SendResult objects.
		/// </summary>
		/// <returns>The retrieved collection of Sms_SendResult objects.</returns>
		public static EntityList<Sms_SendResult> GetSms_SendResults()
		{
			string commandText = @"
SELECT " + Sms_SendResult.SelectFieldList + "FROM [dbo].[Sms_SendResult] " + Sms_SendResult.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Sms_SendResult>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Sms_SendResult objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Sms_SendResult objects.</returns>
        public static EntityList<Sms_SendResult> GetSms_SendResults(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sms_SendResult>(SelectFieldList, "FROM [dbo].[Sms_SendResult]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Sms_SendResult objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Sms_SendResult objects.</returns>
        public static EntityList<Sms_SendResult> GetSms_SendResults(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sms_SendResult>(SelectFieldList, "FROM [dbo].[Sms_SendResult]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Sms_SendResult objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Sms_SendResult objects.</returns>
		protected static EntityList<Sms_SendResult> GetSms_SendResults(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSms_SendResults(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Sms_SendResult objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Sms_SendResult objects.</returns>
		protected static EntityList<Sms_SendResult> GetSms_SendResults(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSms_SendResults(string.Empty, where, parameters, Sms_SendResult.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_SendResult objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Sms_SendResult objects.</returns>
		protected static EntityList<Sms_SendResult> GetSms_SendResults(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSms_SendResults(prefix, where, parameters, Sms_SendResult.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_SendResult objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Sms_SendResult objects.</returns>
		protected static EntityList<Sms_SendResult> GetSms_SendResults(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSms_SendResults(string.Empty, where, parameters, Sms_SendResult.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_SendResult objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Sms_SendResult objects.</returns>
		protected static EntityList<Sms_SendResult> GetSms_SendResults(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSms_SendResults(prefix, where, parameters, Sms_SendResult.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_SendResult objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Sms_SendResult objects.</returns>
		protected static EntityList<Sms_SendResult> GetSms_SendResults(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Sms_SendResult.SelectFieldList + "FROM [dbo].[Sms_SendResult] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Sms_SendResult>(reader);
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
        protected static EntityList<Sms_SendResult> GetSms_SendResults(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sms_SendResult>(SelectFieldList, "FROM [dbo].[Sms_SendResult] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Sms_SendResult objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSms_SendResultCount()
        {
            return GetSms_SendResultCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Sms_SendResult objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSms_SendResultCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Sms_SendResult] " + where;

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
		public static partial class Sms_SendResult_Properties
		{
			public const string ID = "ID";
			public const string TemplateID = "TemplateID";
			public const string SendTime = "SendTime";
			public const string SendStatus = "SendStatus";
			public const string SendResult = "SendResult";
			public const string CustomerID = "CustomerID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"TemplateID" , "string:"},
    			 {"SendTime" , "DateTime:"},
    			 {"SendStatus" , "int:发送状态 1-成功 2-失败"},
    			 {"SendResult" , "string:"},
    			 {"CustomerID" , "int:"},
            };
		}
		#endregion
	}
}
