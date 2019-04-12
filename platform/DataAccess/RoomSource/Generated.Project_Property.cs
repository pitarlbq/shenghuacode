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
	/// This object represents the properties and methods of a Project_Property.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Project_Property 
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ProjectID
		{
			[DebuggerStepThrough()]
			get { return this._projectID; }
			set 
			{
				if (this._projectID != value) 
				{
					this._projectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _relationID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RelationID
		{
			[DebuggerStepThrough()]
			get { return this._relationID; }
			set 
			{
				if (this._relationID != value) 
				{
					this._relationID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RelationID");
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
	[ProjectID] int,
	[RelationID] int,
	[SortOrder] int,
	[IsHide] bit,
	[AddTime] datetime
);

INSERT INTO [dbo].[Project_Property] (
	[Project_Property].[ProjectID],
	[Project_Property].[RelationID],
	[Project_Property].[SortOrder],
	[Project_Property].[IsHide],
	[Project_Property].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[RelationID],
	INSERTED.[SortOrder],
	INSERTED.[IsHide],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ProjectID,
	@RelationID,
	@SortOrder,
	@IsHide,
	@AddTime 
); 

SELECT 
	[ID],
	[ProjectID],
	[RelationID],
	[SortOrder],
	[IsHide],
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
	[ProjectID] int,
	[RelationID] int,
	[SortOrder] int,
	[IsHide] bit,
	[AddTime] datetime
);

UPDATE [dbo].[Project_Property] SET 
	[Project_Property].[ProjectID] = @ProjectID,
	[Project_Property].[RelationID] = @RelationID,
	[Project_Property].[SortOrder] = @SortOrder,
	[Project_Property].[IsHide] = @IsHide,
	[Project_Property].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[RelationID],
	INSERTED.[SortOrder],
	INSERTED.[IsHide],
	INSERTED.[AddTime]
into @table
WHERE 
	[Project_Property].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[RelationID],
	[SortOrder],
	[IsHide],
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
DELETE FROM [dbo].[Project_Property]
WHERE 
	[Project_Property].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Project_Property() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProject_Property(this.ID));
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
	[Project_Property].[ID],
	[Project_Property].[ProjectID],
	[Project_Property].[RelationID],
	[Project_Property].[SortOrder],
	[Project_Property].[IsHide],
	[Project_Property].[AddTime]
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
                return "Project_Property";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Project_Property into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="relationID">relationID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isHide">isHide</param>
		/// <param name="addTime">addTime</param>
		public static void InsertProject_Property(int @projectID, int @relationID, int @sortOrder, bool @isHide, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProject_Property(@projectID, @relationID, @sortOrder, @isHide, @addTime, helper);
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
		/// Insert a Project_Property into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="relationID">relationID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isHide">isHide</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertProject_Property(int @projectID, int @relationID, int @sortOrder, bool @isHide, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[RelationID] int,
	[SortOrder] int,
	[IsHide] bit,
	[AddTime] datetime
);

INSERT INTO [dbo].[Project_Property] (
	[Project_Property].[ProjectID],
	[Project_Property].[RelationID],
	[Project_Property].[SortOrder],
	[Project_Property].[IsHide],
	[Project_Property].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[RelationID],
	INSERTED.[SortOrder],
	INSERTED.[IsHide],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@ProjectID,
	@RelationID,
	@SortOrder,
	@IsHide,
	@AddTime 
); 

SELECT 
	[ID],
	[ProjectID],
	[RelationID],
	[SortOrder],
	[IsHide],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@RelationID", EntityBase.GetDatabaseValue(@relationID)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsHide", @isHide));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Project_Property into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="relationID">relationID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isHide">isHide</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateProject_Property(int @iD, int @projectID, int @relationID, int @sortOrder, bool @isHide, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProject_Property(@iD, @projectID, @relationID, @sortOrder, @isHide, @addTime, helper);
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
		/// Updates a Project_Property into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="projectID">projectID</param>
		/// <param name="relationID">relationID</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isHide">isHide</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProject_Property(int @iD, int @projectID, int @relationID, int @sortOrder, bool @isHide, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProjectID] int,
	[RelationID] int,
	[SortOrder] int,
	[IsHide] bit,
	[AddTime] datetime
);

UPDATE [dbo].[Project_Property] SET 
	[Project_Property].[ProjectID] = @ProjectID,
	[Project_Property].[RelationID] = @RelationID,
	[Project_Property].[SortOrder] = @SortOrder,
	[Project_Property].[IsHide] = @IsHide,
	[Project_Property].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[ProjectID],
	INSERTED.[RelationID],
	INSERTED.[SortOrder],
	INSERTED.[IsHide],
	INSERTED.[AddTime]
into @table
WHERE 
	[Project_Property].[ID] = @ID

SELECT 
	[ID],
	[ProjectID],
	[RelationID],
	[SortOrder],
	[IsHide],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@RelationID", EntityBase.GetDatabaseValue(@relationID)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsHide", @isHide));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Project_Property from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProject_Property(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProject_Property(@iD, helper);
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
		/// Deletes a Project_Property from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProject_Property(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Project_Property]
WHERE 
	[Project_Property].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Project_Property object.
		/// </summary>
		/// <returns>The newly created Project_Property object.</returns>
		public static Project_Property CreateProject_Property()
		{
			return InitializeNew<Project_Property>();
		}
		
		/// <summary>
		/// Retrieve information for a Project_Property by a Project_Property's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Project_Property</returns>
		public static Project_Property GetProject_Property(int @iD)
		{
			string commandText = @"
SELECT 
" + Project_Property.SelectFieldList + @"
FROM [dbo].[Project_Property] 
WHERE 
	[Project_Property].[ID] = @ID " + Project_Property.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project_Property>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Project_Property by a Project_Property's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Project_Property</returns>
		public static Project_Property GetProject_Property(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Project_Property.SelectFieldList + @"
FROM [dbo].[Project_Property] 
WHERE 
	[Project_Property].[ID] = @ID " + Project_Property.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project_Property>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Project_Property objects.
		/// </summary>
		/// <returns>The retrieved collection of Project_Property objects.</returns>
		public static EntityList<Project_Property> GetProject_Properties()
		{
			string commandText = @"
SELECT " + Project_Property.SelectFieldList + "FROM [dbo].[Project_Property] " + Project_Property.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Project_Property>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Project_Property objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project_Property objects.</returns>
        public static EntityList<Project_Property> GetProject_Properties(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_Property>(SelectFieldList, "FROM [dbo].[Project_Property]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Project_Property objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project_Property objects.</returns>
        public static EntityList<Project_Property> GetProject_Properties(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_Property>(SelectFieldList, "FROM [dbo].[Project_Property]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Project_Property objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Project_Property objects.</returns>
		protected static EntityList<Project_Property> GetProject_Properties(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_Properties(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Project_Property objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project_Property objects.</returns>
		protected static EntityList<Project_Property> GetProject_Properties(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_Properties(string.Empty, where, parameters, Project_Property.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Property objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project_Property objects.</returns>
		protected static EntityList<Project_Property> GetProject_Properties(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_Properties(prefix, where, parameters, Project_Property.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Property objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project_Property objects.</returns>
		protected static EntityList<Project_Property> GetProject_Properties(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProject_Properties(string.Empty, where, parameters, Project_Property.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Property objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project_Property objects.</returns>
		protected static EntityList<Project_Property> GetProject_Properties(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProject_Properties(prefix, where, parameters, Project_Property.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Property objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Project_Property objects.</returns>
		protected static EntityList<Project_Property> GetProject_Properties(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Project_Property.SelectFieldList + "FROM [dbo].[Project_Property] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Project_Property>(reader);
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
        protected static EntityList<Project_Property> GetProject_Properties(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_Property>(SelectFieldList, "FROM [dbo].[Project_Property] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Project_Property objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProject_PropertyCount()
        {
            return GetProject_PropertyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Project_Property objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProject_PropertyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Project_Property] " + where;

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
		public static partial class Project_Property_Properties
		{
			public const string ID = "ID";
			public const string ProjectID = "ProjectID";
			public const string RelationID = "RelationID";
			public const string SortOrder = "SortOrder";
			public const string IsHide = "IsHide";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"RelationID" , "int:"},
    			 {"SortOrder" , "int:"},
    			 {"IsHide" , "bool:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
