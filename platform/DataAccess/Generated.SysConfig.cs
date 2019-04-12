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
	/// This object represents the properties and methods of a SysConfig.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class SysConfig 
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
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
			set 
			{
				if (this._name != value) 
				{
					this._name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Name");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _value = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Value
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
		private string _configType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ConfigType
		{
			[DebuggerStepThrough()]
			get { return this._configType; }
			set 
			{
				if (this._configType != value) 
				{
					this._configType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ConfigType");
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
	[Name] nvarchar(100),
	[Value] nvarchar(500),
	[AddTime] datetime,
	[ConfigType] nvarchar(50)
);

INSERT INTO [dbo].[SysConfig] (
	[SysConfig].[Name],
	[SysConfig].[Value],
	[SysConfig].[AddTime],
	[SysConfig].[ConfigType]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Value],
	INSERTED.[AddTime],
	INSERTED.[ConfigType]
into @table
VALUES ( 
	@Name,
	@Value,
	@AddTime,
	@ConfigType 
); 

SELECT 
	[ID],
	[Name],
	[Value],
	[AddTime],
	[ConfigType] 
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
	[Name] nvarchar(100),
	[Value] nvarchar(500),
	[AddTime] datetime,
	[ConfigType] nvarchar(50)
);

UPDATE [dbo].[SysConfig] SET 
	[SysConfig].[Name] = @Name,
	[SysConfig].[Value] = @Value,
	[SysConfig].[AddTime] = @AddTime,
	[SysConfig].[ConfigType] = @ConfigType 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Value],
	INSERTED.[AddTime],
	INSERTED.[ConfigType]
into @table
WHERE 
	[SysConfig].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Value],
	[AddTime],
	[ConfigType] 
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
DELETE FROM [dbo].[SysConfig]
WHERE 
	[SysConfig].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public SysConfig() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSysConfig(this.ID));
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
	[SysConfig].[ID],
	[SysConfig].[Name],
	[SysConfig].[Value],
	[SysConfig].[AddTime],
	[SysConfig].[ConfigType]
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
                return "SysConfig";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a SysConfig into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="value">value</param>
		/// <param name="addTime">addTime</param>
		/// <param name="configType">configType</param>
		public static void InsertSysConfig(string @name, string @value, DateTime @addTime, string @configType)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSysConfig(@name, @value, @addTime, @configType, helper);
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
		/// Insert a SysConfig into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="value">value</param>
		/// <param name="addTime">addTime</param>
		/// <param name="configType">configType</param>
		/// <param name="helper">helper</param>
		internal static void InsertSysConfig(string @name, string @value, DateTime @addTime, string @configType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[Value] nvarchar(500),
	[AddTime] datetime,
	[ConfigType] nvarchar(50)
);

INSERT INTO [dbo].[SysConfig] (
	[SysConfig].[Name],
	[SysConfig].[Value],
	[SysConfig].[AddTime],
	[SysConfig].[ConfigType]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Value],
	INSERTED.[AddTime],
	INSERTED.[ConfigType]
into @table
VALUES ( 
	@Name,
	@Value,
	@AddTime,
	@ConfigType 
); 

SELECT 
	[ID],
	[Name],
	[Value],
	[AddTime],
	[ConfigType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Value", EntityBase.GetDatabaseValue(@value)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ConfigType", EntityBase.GetDatabaseValue(@configType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a SysConfig into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="value">value</param>
		/// <param name="addTime">addTime</param>
		/// <param name="configType">configType</param>
		public static void UpdateSysConfig(int @iD, string @name, string @value, DateTime @addTime, string @configType)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSysConfig(@iD, @name, @value, @addTime, @configType, helper);
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
		/// Updates a SysConfig into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="value">value</param>
		/// <param name="addTime">addTime</param>
		/// <param name="configType">configType</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSysConfig(int @iD, string @name, string @value, DateTime @addTime, string @configType, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[Value] nvarchar(500),
	[AddTime] datetime,
	[ConfigType] nvarchar(50)
);

UPDATE [dbo].[SysConfig] SET 
	[SysConfig].[Name] = @Name,
	[SysConfig].[Value] = @Value,
	[SysConfig].[AddTime] = @AddTime,
	[SysConfig].[ConfigType] = @ConfigType 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Value],
	INSERTED.[AddTime],
	INSERTED.[ConfigType]
into @table
WHERE 
	[SysConfig].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Value],
	[AddTime],
	[ConfigType] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Value", EntityBase.GetDatabaseValue(@value)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@ConfigType", EntityBase.GetDatabaseValue(@configType)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a SysConfig from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSysConfig(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSysConfig(@iD, helper);
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
		/// Deletes a SysConfig from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSysConfig(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[SysConfig]
WHERE 
	[SysConfig].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new SysConfig object.
		/// </summary>
		/// <returns>The newly created SysConfig object.</returns>
		public static SysConfig CreateSysConfig()
		{
			return InitializeNew<SysConfig>();
		}
		
		/// <summary>
		/// Retrieve information for a SysConfig by a SysConfig's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>SysConfig</returns>
		public static SysConfig GetSysConfig(int @iD)
		{
			string commandText = @"
SELECT 
" + SysConfig.SelectFieldList + @"
FROM [dbo].[SysConfig] 
WHERE 
	[SysConfig].[ID] = @ID " + SysConfig.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysConfig>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a SysConfig by a SysConfig's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>SysConfig</returns>
		public static SysConfig GetSysConfig(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + SysConfig.SelectFieldList + @"
FROM [dbo].[SysConfig] 
WHERE 
	[SysConfig].[ID] = @ID " + SysConfig.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysConfig>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection SysConfig objects.
		/// </summary>
		/// <returns>The retrieved collection of SysConfig objects.</returns>
		public static EntityList<SysConfig> GetSysConfigs()
		{
			string commandText = @"
SELECT " + SysConfig.SelectFieldList + "FROM [dbo].[SysConfig] " + SysConfig.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<SysConfig>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection SysConfig objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysConfig objects.</returns>
        public static EntityList<SysConfig> GetSysConfigs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysConfig>(SelectFieldList, "FROM [dbo].[SysConfig]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection SysConfig objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysConfig objects.</returns>
        public static EntityList<SysConfig> GetSysConfigs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysConfig>(SelectFieldList, "FROM [dbo].[SysConfig]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection SysConfig objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of SysConfig objects.</returns>
		protected static EntityList<SysConfig> GetSysConfigs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysConfigs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection SysConfig objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysConfig objects.</returns>
		protected static EntityList<SysConfig> GetSysConfigs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysConfigs(string.Empty, where, parameters, SysConfig.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysConfig objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysConfig objects.</returns>
		protected static EntityList<SysConfig> GetSysConfigs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysConfigs(prefix, where, parameters, SysConfig.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysConfig objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysConfig objects.</returns>
		protected static EntityList<SysConfig> GetSysConfigs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysConfigs(string.Empty, where, parameters, SysConfig.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysConfig objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysConfig objects.</returns>
		protected static EntityList<SysConfig> GetSysConfigs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysConfigs(prefix, where, parameters, SysConfig.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysConfig objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of SysConfig objects.</returns>
		protected static EntityList<SysConfig> GetSysConfigs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + SysConfig.SelectFieldList + "FROM [dbo].[SysConfig] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<SysConfig>(reader);
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
        protected static EntityList<SysConfig> GetSysConfigs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysConfig>(SelectFieldList, "FROM [dbo].[SysConfig] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of SysConfig objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysConfigCount()
        {
            return GetSysConfigCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of SysConfig objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysConfigCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[SysConfig] " + where;

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
		public static partial class SysConfig_Properties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string Value = "Value";
			public const string AddTime = "AddTime";
			public const string ConfigType = "ConfigType";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"Value" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"ConfigType" , "string:"},
            };
		}
		#endregion
	}
}
