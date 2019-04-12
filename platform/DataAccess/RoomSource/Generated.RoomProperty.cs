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
	/// This object represents the properties and methods of a RoomProperty.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomProperty 
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
		[DataObjectField(false, false, false)]
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
		private string _desc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Desc
		{
			[DebuggerStepThrough()]
			get { return this._desc; }
			set 
			{
				if (this._desc != value) 
				{
					this._desc = value;
					this.IsDirty = true;	
					OnPropertyChanged("Desc");
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
	[Desc] nvarchar(500),
	[SortOrder] int
);

INSERT INTO [dbo].[RoomProperty] (
	[RoomProperty].[Name],
	[RoomProperty].[Desc],
	[RoomProperty].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Desc],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@Name,
	@Desc,
	@SortOrder 
); 

SELECT 
	[ID],
	[Name],
	[Desc],
	[SortOrder] 
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
	[Desc] nvarchar(500),
	[SortOrder] int
);

UPDATE [dbo].[RoomProperty] SET 
	[RoomProperty].[Name] = @Name,
	[RoomProperty].[Desc] = @Desc,
	[RoomProperty].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Desc],
	INSERTED.[SortOrder]
into @table
WHERE 
	[RoomProperty].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Desc],
	[SortOrder] 
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
DELETE FROM [dbo].[RoomProperty]
WHERE 
	[RoomProperty].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomProperty() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomProperty(this.ID));
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
	[RoomProperty].[ID],
	[RoomProperty].[Name],
	[RoomProperty].[Desc],
	[RoomProperty].[SortOrder]
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
                return "RoomProperty";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomProperty into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="desc">desc</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void InsertRoomProperty(string @name, string @desc, int @sortOrder)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomProperty(@name, @desc, @sortOrder, helper);
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
		/// Insert a RoomProperty into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="desc">desc</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomProperty(string @name, string @desc, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(50),
	[Desc] nvarchar(500),
	[SortOrder] int
);

INSERT INTO [dbo].[RoomProperty] (
	[RoomProperty].[Name],
	[RoomProperty].[Desc],
	[RoomProperty].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Desc],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@Name,
	@Desc,
	@SortOrder 
); 

SELECT 
	[ID],
	[Name],
	[Desc],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Desc", EntityBase.GetDatabaseValue(@desc)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomProperty into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="desc">desc</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void UpdateRoomProperty(int @iD, string @name, string @desc, int @sortOrder)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomProperty(@iD, @name, @desc, @sortOrder, helper);
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
		/// Updates a RoomProperty into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="desc">desc</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomProperty(int @iD, string @name, string @desc, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(50),
	[Desc] nvarchar(500),
	[SortOrder] int
);

UPDATE [dbo].[RoomProperty] SET 
	[RoomProperty].[Name] = @Name,
	[RoomProperty].[Desc] = @Desc,
	[RoomProperty].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[Desc],
	INSERTED.[SortOrder]
into @table
WHERE 
	[RoomProperty].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[Desc],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Desc", EntityBase.GetDatabaseValue(@desc)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomProperty from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomProperty(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomProperty(@iD, helper);
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
		/// Deletes a RoomProperty from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomProperty(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomProperty]
WHERE 
	[RoomProperty].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomProperty object.
		/// </summary>
		/// <returns>The newly created RoomProperty object.</returns>
		public static RoomProperty CreateRoomProperty()
		{
			return InitializeNew<RoomProperty>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomProperty by a RoomProperty's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomProperty</returns>
		public static RoomProperty GetRoomProperty(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomProperty.SelectFieldList + @"
FROM [dbo].[RoomProperty] 
WHERE 
	[RoomProperty].[ID] = @ID " + RoomProperty.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomProperty>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomProperty by a RoomProperty's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomProperty</returns>
		public static RoomProperty GetRoomProperty(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomProperty.SelectFieldList + @"
FROM [dbo].[RoomProperty] 
WHERE 
	[RoomProperty].[ID] = @ID " + RoomProperty.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomProperty>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomProperty objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomProperty objects.</returns>
		public static EntityList<RoomProperty> GetRoomProperties()
		{
			string commandText = @"
SELECT " + RoomProperty.SelectFieldList + "FROM [dbo].[RoomProperty] " + RoomProperty.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomProperty>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomProperty objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomProperty objects.</returns>
        public static EntityList<RoomProperty> GetRoomProperties(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomProperty>(SelectFieldList, "FROM [dbo].[RoomProperty]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomProperty objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomProperty objects.</returns>
        public static EntityList<RoomProperty> GetRoomProperties(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomProperty>(SelectFieldList, "FROM [dbo].[RoomProperty]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomProperty objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomProperty objects.</returns>
		protected static EntityList<RoomProperty> GetRoomProperties(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomProperties(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomProperty objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomProperty objects.</returns>
		protected static EntityList<RoomProperty> GetRoomProperties(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomProperties(string.Empty, where, parameters, RoomProperty.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomProperty objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomProperty objects.</returns>
		protected static EntityList<RoomProperty> GetRoomProperties(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomProperties(prefix, where, parameters, RoomProperty.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomProperty objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomProperty objects.</returns>
		protected static EntityList<RoomProperty> GetRoomProperties(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomProperties(string.Empty, where, parameters, RoomProperty.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomProperty objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomProperty objects.</returns>
		protected static EntityList<RoomProperty> GetRoomProperties(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomProperties(prefix, where, parameters, RoomProperty.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomProperty objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomProperty objects.</returns>
		protected static EntityList<RoomProperty> GetRoomProperties(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomProperty.SelectFieldList + "FROM [dbo].[RoomProperty] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomProperty>(reader);
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
        protected static EntityList<RoomProperty> GetRoomProperties(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomProperty>(SelectFieldList, "FROM [dbo].[RoomProperty] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomProperty objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomPropertyCount()
        {
            return GetRoomPropertyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomProperty objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomPropertyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomProperty] " + where;

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
		public static partial class RoomProperty_Properties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string Desc = "Desc";
			public const string SortOrder = "SortOrder";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"Desc" , "string:"},
    			 {"SortOrder" , "int:"},
            };
		}
		#endregion
	}
}
