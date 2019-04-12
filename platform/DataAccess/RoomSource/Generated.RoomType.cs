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
	/// This object represents the properties and methods of a RoomType.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomType 
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
		private string _roomTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomTypeName
		{
			[DebuggerStepThrough()]
			get { return this._roomTypeName; }
			set 
			{
				if (this._roomTypeName != value) 
				{
					this._roomTypeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomTypeName");
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
	[RoomTypeName] nvarchar(50),
	[SortOrder] int
);

INSERT INTO [dbo].[RoomType] (
	[RoomType].[RoomTypeName],
	[RoomType].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomTypeName],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@RoomTypeName,
	@SortOrder 
); 

SELECT 
	[ID],
	[RoomTypeName],
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
	[RoomTypeName] nvarchar(50),
	[SortOrder] int
);

UPDATE [dbo].[RoomType] SET 
	[RoomType].[RoomTypeName] = @RoomTypeName,
	[RoomType].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[RoomTypeName],
	INSERTED.[SortOrder]
into @table
WHERE 
	[RoomType].[ID] = @ID

SELECT 
	[ID],
	[RoomTypeName],
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
DELETE FROM [dbo].[RoomType]
WHERE 
	[RoomType].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomType() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomType(this.ID));
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
	[RoomType].[ID],
	[RoomType].[RoomTypeName],
	[RoomType].[SortOrder]
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
                return "RoomType";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomTypeName">roomTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void InsertRoomType(string @roomTypeName, int @sortOrder)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomType(@roomTypeName, @sortOrder, helper);
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
		/// Insert a RoomType into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomTypeName">roomTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomType(string @roomTypeName, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomTypeName] nvarchar(50),
	[SortOrder] int
);

INSERT INTO [dbo].[RoomType] (
	[RoomType].[RoomTypeName],
	[RoomType].[SortOrder]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomTypeName],
	INSERTED.[SortOrder]
into @table
VALUES ( 
	@RoomTypeName,
	@SortOrder 
); 

SELECT 
	[ID],
	[RoomTypeName],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomTypeName", EntityBase.GetDatabaseValue(@roomTypeName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomTypeName">roomTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		public static void UpdateRoomType(int @iD, string @roomTypeName, int @sortOrder)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomType(@iD, @roomTypeName, @sortOrder, helper);
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
		/// Updates a RoomType into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomTypeName">roomTypeName</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomType(int @iD, string @roomTypeName, int @sortOrder, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomTypeName] nvarchar(50),
	[SortOrder] int
);

UPDATE [dbo].[RoomType] SET 
	[RoomType].[RoomTypeName] = @RoomTypeName,
	[RoomType].[SortOrder] = @SortOrder 
output 
	INSERTED.[ID],
	INSERTED.[RoomTypeName],
	INSERTED.[SortOrder]
into @table
WHERE 
	[RoomType].[ID] = @ID

SELECT 
	[ID],
	[RoomTypeName],
	[SortOrder] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomTypeName", EntityBase.GetDatabaseValue(@roomTypeName)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomType(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomType(@iD, helper);
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
		/// Deletes a RoomType from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomType]
WHERE 
	[RoomType].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomType object.
		/// </summary>
		/// <returns>The newly created RoomType object.</returns>
		public static RoomType CreateRoomType()
		{
			return InitializeNew<RoomType>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomType by a RoomType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomType</returns>
		public static RoomType GetRoomType(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomType.SelectFieldList + @"
FROM [dbo].[RoomType] 
WHERE 
	[RoomType].[ID] = @ID " + RoomType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomType>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomType by a RoomType's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomType</returns>
		public static RoomType GetRoomType(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomType.SelectFieldList + @"
FROM [dbo].[RoomType] 
WHERE 
	[RoomType].[ID] = @ID " + RoomType.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomType>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomType objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomType objects.</returns>
		public static EntityList<RoomType> GetRoomTypes()
		{
			string commandText = @"
SELECT " + RoomType.SelectFieldList + "FROM [dbo].[RoomType] " + RoomType.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomType>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomType objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomType objects.</returns>
        public static EntityList<RoomType> GetRoomTypes(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomType>(SelectFieldList, "FROM [dbo].[RoomType]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomType objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomType objects.</returns>
        public static EntityList<RoomType> GetRoomTypes(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomType>(SelectFieldList, "FROM [dbo].[RoomType]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomType objects.</returns>
		protected static EntityList<RoomType> GetRoomTypes(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomTypes(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomType objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomType objects.</returns>
		protected static EntityList<RoomType> GetRoomTypes(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomTypes(string.Empty, where, parameters, RoomType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomType objects.</returns>
		protected static EntityList<RoomType> GetRoomTypes(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomTypes(prefix, where, parameters, RoomType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomType objects.</returns>
		protected static EntityList<RoomType> GetRoomTypes(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomTypes(string.Empty, where, parameters, RoomType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomType objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomType objects.</returns>
		protected static EntityList<RoomType> GetRoomTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomTypes(prefix, where, parameters, RoomType.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomType objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomType objects.</returns>
		protected static EntityList<RoomType> GetRoomTypes(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomType.SelectFieldList + "FROM [dbo].[RoomType] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomType>(reader);
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
        protected static EntityList<RoomType> GetRoomTypes(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomType>(SelectFieldList, "FROM [dbo].[RoomType] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomType objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomTypeCount()
        {
            return GetRoomTypeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomType objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomTypeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomType] " + where;

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
		public static partial class RoomType_Properties
		{
			public const string ID = "ID";
			public const string RoomTypeName = "RoomTypeName";
			public const string SortOrder = "SortOrder";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomTypeName" , "string:"},
    			 {"SortOrder" , "int:"},
            };
		}
		#endregion
	}
}
