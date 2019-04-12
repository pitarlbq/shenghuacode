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
	/// This object represents the properties and methods of a ProjectName.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ProjectName 
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
		private string _pName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PName
		{
			[DebuggerStepThrough()]
			get { return this._pName; }
			set 
			{
				if (this._pName != value) 
				{
					this._pName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PName");
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
	[PName] nvarchar(100)
);

INSERT INTO [dbo].[ProjectName] (
	[ProjectName].[Name],
	[ProjectName].[PName]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[PName]
into @table
VALUES ( 
	@Name,
	@PName 
); 

SELECT 
	[ID],
	[Name],
	[PName] 
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
	[PName] nvarchar(100)
);

UPDATE [dbo].[ProjectName] SET 
	[ProjectName].[Name] = @Name,
	[ProjectName].[PName] = @PName 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[PName]
into @table
WHERE 
	[ProjectName].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[PName] 
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
DELETE FROM [dbo].[ProjectName]
WHERE 
	[ProjectName].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ProjectName() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProjectName(this.ID));
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
	[ProjectName].[ID],
	[ProjectName].[Name],
	[ProjectName].[PName]
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
                return "ProjectName";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ProjectName into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="pName">pName</param>
		public static void InsertProjectName(string @name, string @pName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProjectName(@name, @pName, helper);
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
		/// Insert a ProjectName into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="pName">pName</param>
		/// <param name="helper">helper</param>
		internal static void InsertProjectName(string @name, string @pName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[PName] nvarchar(100)
);

INSERT INTO [dbo].[ProjectName] (
	[ProjectName].[Name],
	[ProjectName].[PName]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[PName]
into @table
VALUES ( 
	@Name,
	@PName 
); 

SELECT 
	[ID],
	[Name],
	[PName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@PName", EntityBase.GetDatabaseValue(@pName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ProjectName into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="pName">pName</param>
		public static void UpdateProjectName(int @iD, string @name, string @pName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProjectName(@iD, @name, @pName, helper);
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
		/// Updates a ProjectName into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="pName">pName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProjectName(int @iD, string @name, string @pName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[PName] nvarchar(100)
);

UPDATE [dbo].[ProjectName] SET 
	[ProjectName].[Name] = @Name,
	[ProjectName].[PName] = @PName 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[PName]
into @table
WHERE 
	[ProjectName].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[PName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@PName", EntityBase.GetDatabaseValue(@pName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ProjectName from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProjectName(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProjectName(@iD, helper);
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
		/// Deletes a ProjectName from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProjectName(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ProjectName]
WHERE 
	[ProjectName].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ProjectName object.
		/// </summary>
		/// <returns>The newly created ProjectName object.</returns>
		public static ProjectName CreateProjectName()
		{
			return InitializeNew<ProjectName>();
		}
		
		/// <summary>
		/// Retrieve information for a ProjectName by a ProjectName's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ProjectName</returns>
		public static ProjectName GetProjectName(int @iD)
		{
			string commandText = @"
SELECT 
" + ProjectName.SelectFieldList + @"
FROM [dbo].[ProjectName] 
WHERE 
	[ProjectName].[ID] = @ID " + ProjectName.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectName>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ProjectName by a ProjectName's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ProjectName</returns>
		public static ProjectName GetProjectName(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ProjectName.SelectFieldList + @"
FROM [dbo].[ProjectName] 
WHERE 
	[ProjectName].[ID] = @ID " + ProjectName.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectName>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ProjectName objects.
		/// </summary>
		/// <returns>The retrieved collection of ProjectName objects.</returns>
		public static EntityList<ProjectName> GetProjectNames()
		{
			string commandText = @"
SELECT " + ProjectName.SelectFieldList + "FROM [dbo].[ProjectName] " + ProjectName.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ProjectName>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ProjectName objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectName objects.</returns>
        public static EntityList<ProjectName> GetProjectNames(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectName>(SelectFieldList, "FROM [dbo].[ProjectName]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ProjectName objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectName objects.</returns>
        public static EntityList<ProjectName> GetProjectNames(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectName>(SelectFieldList, "FROM [dbo].[ProjectName]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ProjectName objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ProjectName objects.</returns>
		protected static EntityList<ProjectName> GetProjectNames(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectNames(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ProjectName objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectName objects.</returns>
		protected static EntityList<ProjectName> GetProjectNames(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectNames(string.Empty, where, parameters, ProjectName.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectName objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectName objects.</returns>
		protected static EntityList<ProjectName> GetProjectNames(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectNames(prefix, where, parameters, ProjectName.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectName objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectName objects.</returns>
		protected static EntityList<ProjectName> GetProjectNames(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectNames(string.Empty, where, parameters, ProjectName.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectName objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectName objects.</returns>
		protected static EntityList<ProjectName> GetProjectNames(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectNames(prefix, where, parameters, ProjectName.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectName objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ProjectName objects.</returns>
		protected static EntityList<ProjectName> GetProjectNames(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ProjectName.SelectFieldList + "FROM [dbo].[ProjectName] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ProjectName>(reader);
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
        protected static EntityList<ProjectName> GetProjectNames(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectName>(SelectFieldList, "FROM [dbo].[ProjectName] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ProjectNameProperties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string PName = "PName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"PName" , "string:"},
            };
		}
		#endregion
	}
}
