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
	/// This object represents the properties and methods of a RoomState.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomState 
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
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _backColor = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BackColor
		{
			[DebuggerStepThrough()]
			get { return this._backColor; }
			set 
			{
				if (this._backColor != value) 
				{
					this._backColor = value;
					this.IsDirty = true;	
					OnPropertyChanged("BackColor");
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
	[Name] nvarchar(50),
	[SortOrder] int,
	[BackColor] nvarchar(50)
);

INSERT INTO [dbo].[RoomState] (
	[RoomState].[Name],
	[RoomState].[SortOrder],
	[RoomState].[BackColor]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[SortOrder],
	INSERTED.[BackColor]
into @table
VALUES ( 
	@Name,
	@SortOrder,
	@BackColor 
); 

SELECT 
	[ID],
	[Name],
	[SortOrder],
	[BackColor] 
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
	[Name] nvarchar(50),
	[SortOrder] int,
	[BackColor] nvarchar(50)
);

UPDATE [dbo].[RoomState] SET 
	[RoomState].[Name] = @Name,
	[RoomState].[SortOrder] = @SortOrder,
	[RoomState].[BackColor] = @BackColor 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[SortOrder],
	INSERTED.[BackColor]
into @table
WHERE 
	[RoomState].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[SortOrder],
	[BackColor] 
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
DELETE FROM [dbo].[RoomState]
WHERE 
	[RoomState].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomState() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomState(this.ID));
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
	[RoomState].[ID],
	[RoomState].[Name],
	[RoomState].[SortOrder],
	[RoomState].[BackColor]
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
                return "RoomState";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomState into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="backColor">backColor</param>
		public static void InsertRoomState(string @name, int @sortOrder, string @backColor)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomState(@name, @sortOrder, @backColor, helper);
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
		/// Insert a RoomState into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="backColor">backColor</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomState(string @name, int @sortOrder, string @backColor, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(50),
	[SortOrder] int,
	[BackColor] nvarchar(50)
);

INSERT INTO [dbo].[RoomState] (
	[RoomState].[Name],
	[RoomState].[SortOrder],
	[RoomState].[BackColor]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[SortOrder],
	INSERTED.[BackColor]
into @table
VALUES ( 
	@Name,
	@SortOrder,
	@BackColor 
); 

SELECT 
	[ID],
	[Name],
	[SortOrder],
	[BackColor] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@BackColor", EntityBase.GetDatabaseValue(@backColor)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomState into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="backColor">backColor</param>
		public static void UpdateRoomState(int @iD, string @name, int @sortOrder, string @backColor)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomState(@iD, @name, @sortOrder, @backColor, helper);
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
		/// Updates a RoomState into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="backColor">backColor</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomState(int @iD, string @name, int @sortOrder, string @backColor, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(50),
	[SortOrder] int,
	[BackColor] nvarchar(50)
);

UPDATE [dbo].[RoomState] SET 
	[RoomState].[Name] = @Name,
	[RoomState].[SortOrder] = @SortOrder,
	[RoomState].[BackColor] = @BackColor 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[SortOrder],
	INSERTED.[BackColor]
into @table
WHERE 
	[RoomState].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[SortOrder],
	[BackColor] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@BackColor", EntityBase.GetDatabaseValue(@backColor)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomState from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomState(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomState(@iD, helper);
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
		/// Deletes a RoomState from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomState(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomState]
WHERE 
	[RoomState].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomState object.
		/// </summary>
		/// <returns>The newly created RoomState object.</returns>
		public static RoomState CreateRoomState()
		{
			return InitializeNew<RoomState>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomState by a RoomState's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomState</returns>
		public static RoomState GetRoomState(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomState.SelectFieldList + @"
FROM [dbo].[RoomState] 
WHERE 
	[RoomState].[ID] = @ID " + RoomState.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomState>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomState by a RoomState's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomState</returns>
		public static RoomState GetRoomState(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomState.SelectFieldList + @"
FROM [dbo].[RoomState] 
WHERE 
	[RoomState].[ID] = @ID " + RoomState.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomState>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomState objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomState objects.</returns>
		public static EntityList<RoomState> GetRoomStates()
		{
			string commandText = @"
SELECT " + RoomState.SelectFieldList + "FROM [dbo].[RoomState] " + RoomState.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomState>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomState objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomState objects.</returns>
        public static EntityList<RoomState> GetRoomStates(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomState>(SelectFieldList, "FROM [dbo].[RoomState]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomState objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomState objects.</returns>
        public static EntityList<RoomState> GetRoomStates(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomState>(SelectFieldList, "FROM [dbo].[RoomState]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomState objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomState objects.</returns>
		protected static EntityList<RoomState> GetRoomStates(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomStates(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomState objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomState objects.</returns>
		protected static EntityList<RoomState> GetRoomStates(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomStates(string.Empty, where, parameters, RoomState.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomState objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomState objects.</returns>
		protected static EntityList<RoomState> GetRoomStates(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomStates(prefix, where, parameters, RoomState.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomState objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomState objects.</returns>
		protected static EntityList<RoomState> GetRoomStates(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomStates(string.Empty, where, parameters, RoomState.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomState objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomState objects.</returns>
		protected static EntityList<RoomState> GetRoomStates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomStates(prefix, where, parameters, RoomState.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomState objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomState objects.</returns>
		protected static EntityList<RoomState> GetRoomStates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomState.SelectFieldList + "FROM [dbo].[RoomState] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomState>(reader);
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
        protected static EntityList<RoomState> GetRoomStates(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomState>(SelectFieldList, "FROM [dbo].[RoomState] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomState objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomStateCount()
        {
            return GetRoomStateCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomState objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomStateCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomState] " + where;

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
		public static partial class RoomState_Properties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string SortOrder = "SortOrder";
			public const string BackColor = "BackColor";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"BackColor" , "string:"},
            };
		}
		#endregion
	}
}
