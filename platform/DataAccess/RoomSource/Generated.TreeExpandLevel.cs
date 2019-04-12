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
	/// This object represents the properties and methods of a TreeExpandLevel.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class TreeExpandLevel 
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
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CompanyID
		{
			[DebuggerStepThrough()]
			get { return this._companyID; }
			set 
			{
				if (this._companyID != value) 
				{
					this._companyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _levelID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int LevelID
		{
			[DebuggerStepThrough()]
			get { return this._levelID; }
			set 
			{
				if (this._levelID != value) 
				{
					this._levelID = value;
					this.IsDirty = true;	
					OnPropertyChanged("LevelID");
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
	[CompanyID] int,
	[LevelID] int
);

INSERT INTO [dbo].[TreeExpandLevel] (
	[TreeExpandLevel].[CompanyID],
	[TreeExpandLevel].[LevelID]
) 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[LevelID]
into @table
VALUES ( 
	@CompanyID,
	@LevelID 
); 

SELECT 
	[ID],
	[CompanyID],
	[LevelID] 
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
	[CompanyID] int,
	[LevelID] int
);

UPDATE [dbo].[TreeExpandLevel] SET 
	[TreeExpandLevel].[CompanyID] = @CompanyID,
	[TreeExpandLevel].[LevelID] = @LevelID 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[LevelID]
into @table
WHERE 
	[TreeExpandLevel].[ID] = @ID

SELECT 
	[ID],
	[CompanyID],
	[LevelID] 
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
DELETE FROM [dbo].[TreeExpandLevel]
WHERE 
	[TreeExpandLevel].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public TreeExpandLevel() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetTreeExpandLevel(this.ID));
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
	[TreeExpandLevel].[ID],
	[TreeExpandLevel].[CompanyID],
	[TreeExpandLevel].[LevelID]
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
                return "TreeExpandLevel";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a TreeExpandLevel into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="levelID">levelID</param>
		public static void InsertTreeExpandLevel(int @companyID, int @levelID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertTreeExpandLevel(@companyID, @levelID, helper);
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
		/// Insert a TreeExpandLevel into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="levelID">levelID</param>
		/// <param name="helper">helper</param>
		internal static void InsertTreeExpandLevel(int @companyID, int @levelID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CompanyID] int,
	[LevelID] int
);

INSERT INTO [dbo].[TreeExpandLevel] (
	[TreeExpandLevel].[CompanyID],
	[TreeExpandLevel].[LevelID]
) 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[LevelID]
into @table
VALUES ( 
	@CompanyID,
	@LevelID 
); 

SELECT 
	[ID],
	[CompanyID],
	[LevelID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@LevelID", EntityBase.GetDatabaseValue(@levelID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a TreeExpandLevel into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="companyID">companyID</param>
		/// <param name="levelID">levelID</param>
		public static void UpdateTreeExpandLevel(int @iD, int @companyID, int @levelID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateTreeExpandLevel(@iD, @companyID, @levelID, helper);
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
		/// Updates a TreeExpandLevel into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="companyID">companyID</param>
		/// <param name="levelID">levelID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateTreeExpandLevel(int @iD, int @companyID, int @levelID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CompanyID] int,
	[LevelID] int
);

UPDATE [dbo].[TreeExpandLevel] SET 
	[TreeExpandLevel].[CompanyID] = @CompanyID,
	[TreeExpandLevel].[LevelID] = @LevelID 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[LevelID]
into @table
WHERE 
	[TreeExpandLevel].[ID] = @ID

SELECT 
	[ID],
	[CompanyID],
	[LevelID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@LevelID", EntityBase.GetDatabaseValue(@levelID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a TreeExpandLevel from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteTreeExpandLevel(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteTreeExpandLevel(@iD, helper);
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
		/// Deletes a TreeExpandLevel from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteTreeExpandLevel(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[TreeExpandLevel]
WHERE 
	[TreeExpandLevel].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new TreeExpandLevel object.
		/// </summary>
		/// <returns>The newly created TreeExpandLevel object.</returns>
		public static TreeExpandLevel CreateTreeExpandLevel()
		{
			return InitializeNew<TreeExpandLevel>();
		}
		
		/// <summary>
		/// Retrieve information for a TreeExpandLevel by a TreeExpandLevel's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>TreeExpandLevel</returns>
		public static TreeExpandLevel GetTreeExpandLevel(int @iD)
		{
			string commandText = @"
SELECT 
" + TreeExpandLevel.SelectFieldList + @"
FROM [dbo].[TreeExpandLevel] 
WHERE 
	[TreeExpandLevel].[ID] = @ID " + TreeExpandLevel.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<TreeExpandLevel>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a TreeExpandLevel by a TreeExpandLevel's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>TreeExpandLevel</returns>
		public static TreeExpandLevel GetTreeExpandLevel(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + TreeExpandLevel.SelectFieldList + @"
FROM [dbo].[TreeExpandLevel] 
WHERE 
	[TreeExpandLevel].[ID] = @ID " + TreeExpandLevel.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<TreeExpandLevel>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection TreeExpandLevel objects.
		/// </summary>
		/// <returns>The retrieved collection of TreeExpandLevel objects.</returns>
		public static EntityList<TreeExpandLevel> GetTreeExpandLevels()
		{
			string commandText = @"
SELECT " + TreeExpandLevel.SelectFieldList + "FROM [dbo].[TreeExpandLevel] " + TreeExpandLevel.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<TreeExpandLevel>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection TreeExpandLevel objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of TreeExpandLevel objects.</returns>
        public static EntityList<TreeExpandLevel> GetTreeExpandLevels(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TreeExpandLevel>(SelectFieldList, "FROM [dbo].[TreeExpandLevel]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection TreeExpandLevel objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of TreeExpandLevel objects.</returns>
        public static EntityList<TreeExpandLevel> GetTreeExpandLevels(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TreeExpandLevel>(SelectFieldList, "FROM [dbo].[TreeExpandLevel]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection TreeExpandLevel objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of TreeExpandLevel objects.</returns>
		protected static EntityList<TreeExpandLevel> GetTreeExpandLevels(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTreeExpandLevels(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection TreeExpandLevel objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of TreeExpandLevel objects.</returns>
		protected static EntityList<TreeExpandLevel> GetTreeExpandLevels(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTreeExpandLevels(string.Empty, where, parameters, TreeExpandLevel.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TreeExpandLevel objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of TreeExpandLevel objects.</returns>
		protected static EntityList<TreeExpandLevel> GetTreeExpandLevels(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTreeExpandLevels(prefix, where, parameters, TreeExpandLevel.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TreeExpandLevel objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of TreeExpandLevel objects.</returns>
		protected static EntityList<TreeExpandLevel> GetTreeExpandLevels(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTreeExpandLevels(string.Empty, where, parameters, TreeExpandLevel.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TreeExpandLevel objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of TreeExpandLevel objects.</returns>
		protected static EntityList<TreeExpandLevel> GetTreeExpandLevels(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTreeExpandLevels(prefix, where, parameters, TreeExpandLevel.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TreeExpandLevel objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of TreeExpandLevel objects.</returns>
		protected static EntityList<TreeExpandLevel> GetTreeExpandLevels(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + TreeExpandLevel.SelectFieldList + "FROM [dbo].[TreeExpandLevel] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<TreeExpandLevel>(reader);
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
        protected static EntityList<TreeExpandLevel> GetTreeExpandLevels(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TreeExpandLevel>(SelectFieldList, "FROM [dbo].[TreeExpandLevel] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class TreeExpandLevelProperties
		{
			public const string ID = "ID";
			public const string CompanyID = "CompanyID";
			public const string LevelID = "LevelID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CompanyID" , "int:"},
    			 {"LevelID" , "int:"},
            };
		}
		#endregion
	}
}
