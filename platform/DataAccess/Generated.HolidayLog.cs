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
	/// This object represents the properties and methods of a HolidayLog.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class HolidayLog 
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
		private string _day = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Day
		{
			[DebuggerStepThrough()]
			get { return this._day; }
			set 
			{
				if (this._day != value) 
				{
					this._day = value;
					this.IsDirty = true;	
					OnPropertyChanged("Day");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _value = int.MinValue;
		/// <summary>
		/// 0-工作日 1-休息日 2-节假日
		/// </summary>
        [Description("0-工作日 1-休息日 2-节假日")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Value
		{
			[DebuggerStepThrough()]
			get { return this._value; }
			set 
			{
				if (this._value != value) 
				{
					this._value = value;
					this.IsDirty = true;	
					OnPropertyChanged("Value");
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
	[Day] nvarchar(200),
	[Value] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[HolidayLog] (
	[HolidayLog].[Day],
	[HolidayLog].[Value],
	[HolidayLog].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Day],
	INSERTED.[Value],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Day,
	@Value,
	@AddTime 
); 

SELECT 
	[ID],
	[Day],
	[Value],
	[AddTime] 
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
	[Day] nvarchar(200),
	[Value] int,
	[AddTime] datetime
);

UPDATE [dbo].[HolidayLog] SET 
	[HolidayLog].[Day] = @Day,
	[HolidayLog].[Value] = @Value,
	[HolidayLog].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Day],
	INSERTED.[Value],
	INSERTED.[AddTime]
into @table
WHERE 
	[HolidayLog].[ID] = @ID

SELECT 
	[ID],
	[Day],
	[Value],
	[AddTime] 
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
DELETE FROM [dbo].[HolidayLog]
WHERE 
	[HolidayLog].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public HolidayLog() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetHolidayLog(this.ID));
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
	[HolidayLog].[ID],
	[HolidayLog].[Day],
	[HolidayLog].[Value],
	[HolidayLog].[AddTime]
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
                return "HolidayLog";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a HolidayLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="day">day</param>
		/// <param name="value">value</param>
		/// <param name="addTime">addTime</param>
		public static void InsertHolidayLog(string @day, int @value, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertHolidayLog(@day, @value, @addTime, helper);
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
		/// Insert a HolidayLog into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="day">day</param>
		/// <param name="value">value</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertHolidayLog(string @day, int @value, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Day] nvarchar(200),
	[Value] int,
	[AddTime] datetime
);

INSERT INTO [dbo].[HolidayLog] (
	[HolidayLog].[Day],
	[HolidayLog].[Value],
	[HolidayLog].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[Day],
	INSERTED.[Value],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@Day,
	@Value,
	@AddTime 
); 

SELECT 
	[ID],
	[Day],
	[Value],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Day", EntityBase.GetDatabaseValue(@day)));
			parameters.Add(new SqlParameter("@Value", EntityBase.GetDatabaseValue(@value)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a HolidayLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="day">day</param>
		/// <param name="value">value</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateHolidayLog(int @iD, string @day, int @value, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateHolidayLog(@iD, @day, @value, @addTime, helper);
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
		/// Updates a HolidayLog into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="day">day</param>
		/// <param name="value">value</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateHolidayLog(int @iD, string @day, int @value, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Day] nvarchar(200),
	[Value] int,
	[AddTime] datetime
);

UPDATE [dbo].[HolidayLog] SET 
	[HolidayLog].[Day] = @Day,
	[HolidayLog].[Value] = @Value,
	[HolidayLog].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[Day],
	INSERTED.[Value],
	INSERTED.[AddTime]
into @table
WHERE 
	[HolidayLog].[ID] = @ID

SELECT 
	[ID],
	[Day],
	[Value],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Day", EntityBase.GetDatabaseValue(@day)));
			parameters.Add(new SqlParameter("@Value", EntityBase.GetDatabaseValue(@value)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a HolidayLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteHolidayLog(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteHolidayLog(@iD, helper);
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
		/// Deletes a HolidayLog from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteHolidayLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[HolidayLog]
WHERE 
	[HolidayLog].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new HolidayLog object.
		/// </summary>
		/// <returns>The newly created HolidayLog object.</returns>
		public static HolidayLog CreateHolidayLog()
		{
			return InitializeNew<HolidayLog>();
		}
		
		/// <summary>
		/// Retrieve information for a HolidayLog by a HolidayLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>HolidayLog</returns>
		public static HolidayLog GetHolidayLog(int @iD)
		{
			string commandText = @"
SELECT 
" + HolidayLog.SelectFieldList + @"
FROM [dbo].[HolidayLog] 
WHERE 
	[HolidayLog].[ID] = @ID " + HolidayLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<HolidayLog>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a HolidayLog by a HolidayLog's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>HolidayLog</returns>
		public static HolidayLog GetHolidayLog(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + HolidayLog.SelectFieldList + @"
FROM [dbo].[HolidayLog] 
WHERE 
	[HolidayLog].[ID] = @ID " + HolidayLog.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<HolidayLog>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection HolidayLog objects.
		/// </summary>
		/// <returns>The retrieved collection of HolidayLog objects.</returns>
		public static EntityList<HolidayLog> GetHolidayLogs()
		{
			string commandText = @"
SELECT " + HolidayLog.SelectFieldList + "FROM [dbo].[HolidayLog] " + HolidayLog.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<HolidayLog>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection HolidayLog objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of HolidayLog objects.</returns>
        public static EntityList<HolidayLog> GetHolidayLogs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<HolidayLog>(SelectFieldList, "FROM [dbo].[HolidayLog]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection HolidayLog objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of HolidayLog objects.</returns>
        public static EntityList<HolidayLog> GetHolidayLogs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<HolidayLog>(SelectFieldList, "FROM [dbo].[HolidayLog]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection HolidayLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of HolidayLog objects.</returns>
		protected static EntityList<HolidayLog> GetHolidayLogs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetHolidayLogs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection HolidayLog objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of HolidayLog objects.</returns>
		protected static EntityList<HolidayLog> GetHolidayLogs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetHolidayLogs(string.Empty, where, parameters, HolidayLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection HolidayLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of HolidayLog objects.</returns>
		protected static EntityList<HolidayLog> GetHolidayLogs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetHolidayLogs(prefix, where, parameters, HolidayLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection HolidayLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of HolidayLog objects.</returns>
		protected static EntityList<HolidayLog> GetHolidayLogs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetHolidayLogs(string.Empty, where, parameters, HolidayLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection HolidayLog objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of HolidayLog objects.</returns>
		protected static EntityList<HolidayLog> GetHolidayLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetHolidayLogs(prefix, where, parameters, HolidayLog.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection HolidayLog objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of HolidayLog objects.</returns>
		protected static EntityList<HolidayLog> GetHolidayLogs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + HolidayLog.SelectFieldList + "FROM [dbo].[HolidayLog] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<HolidayLog>(reader);
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
        protected static EntityList<HolidayLog> GetHolidayLogs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<HolidayLog>(SelectFieldList, "FROM [dbo].[HolidayLog] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of HolidayLog objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetHolidayLogCount()
        {
            return GetHolidayLogCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of HolidayLog objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetHolidayLogCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[HolidayLog] " + where;

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
		public static partial class HolidayLog_Properties
		{
			public const string ID = "ID";
			public const string Day = "Day";
			public const string Value = "Value";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Day" , "string:"},
    			 {"Value" , "int:0-工作日 1-休息日 2-节假日"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
