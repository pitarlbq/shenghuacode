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
	/// This object represents the properties and methods of a ProjectComany.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("CompanyID: {CompanyID}, ProjectID: {ProjectID}")]
	public partial class ProjectComany 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
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
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
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
	[CompanyID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[ProjectComany] (
	[ProjectComany].[CompanyID],
	[ProjectComany].[ProjectID]
) 
output 
	INSERTED.[CompanyID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@CompanyID,
	@ProjectID 
); 

SELECT 
	[CompanyID],
	[ProjectID] 
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
	[CompanyID] int,
	[ProjectID] int
);

UPDATE [dbo].[ProjectComany] SET 
 
output 
	INSERTED.[CompanyID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[ProjectComany].[CompanyID] = @CompanyID
	AND [ProjectComany].[ProjectID] = @ProjectID

SELECT 
	[CompanyID],
	[ProjectID] 
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
DELETE FROM [dbo].[ProjectComany]
WHERE 
	[ProjectComany].[CompanyID] = @CompanyID
	AND [ProjectComany].[ProjectID] = @ProjectID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ProjectComany() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProjectComany(this.CompanyID, this.ProjectID));
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
	[ProjectComany].[CompanyID],
	[ProjectComany].[ProjectID]
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
                return "ProjectComany";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ProjectComany into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="projectID">projectID</param>
		public static void InsertProjectComany(int @companyID, int @projectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProjectComany(@companyID, @projectID, helper);
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
		/// Insert a ProjectComany into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertProjectComany(int @companyID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[CompanyID] int,
	[ProjectID] int
);

INSERT INTO [dbo].[ProjectComany] (
	[ProjectComany].[CompanyID],
	[ProjectComany].[ProjectID]
) 
output 
	INSERTED.[CompanyID],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@CompanyID,
	@ProjectID 
); 

SELECT 
	[CompanyID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ProjectComany into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="projectID">projectID</param>
		public static void UpdateProjectComany(int @companyID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProjectComany(@companyID, @projectID, helper);
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
		/// Updates a ProjectComany into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProjectComany(int @companyID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[CompanyID] int,
	[ProjectID] int
);

UPDATE [dbo].[ProjectComany] SET 
 
output 
	INSERTED.[CompanyID],
	INSERTED.[ProjectID]
into @table
WHERE 
	[ProjectComany].[CompanyID] = @CompanyID
	AND [ProjectComany].[ProjectID] = @ProjectID

SELECT 
	[CompanyID],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ProjectComany from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="projectID">projectID</param>
		public static void DeleteProjectComany(int @companyID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProjectComany(@companyID, @projectID, helper);
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
		/// Deletes a ProjectComany from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProjectComany(int @companyID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ProjectComany]
WHERE 
	[ProjectComany].[CompanyID] = @CompanyID
	AND [ProjectComany].[ProjectID] = @ProjectID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", @companyID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ProjectComany object.
		/// </summary>
		/// <returns>The newly created ProjectComany object.</returns>
		public static ProjectComany CreateProjectComany()
		{
			return InitializeNew<ProjectComany>();
		}
		
		/// <summary>
		/// Retrieve information for a ProjectComany by a ProjectComany's unique identifier.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="projectID">projectID</param>
		/// <returns>ProjectComany</returns>
		public static ProjectComany GetProjectComany(int @companyID, int @projectID)
		{
			string commandText = @"
SELECT 
" + ProjectComany.SelectFieldList + @"
FROM [dbo].[ProjectComany] 
WHERE 
	[ProjectComany].[CompanyID] = @CompanyID
	AND [ProjectComany].[ProjectID] = @ProjectID " + ProjectComany.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", @companyID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<ProjectComany>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ProjectComany by a ProjectComany's unique identifier.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="projectID">projectID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ProjectComany</returns>
		public static ProjectComany GetProjectComany(int @companyID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ProjectComany.SelectFieldList + @"
FROM [dbo].[ProjectComany] 
WHERE 
	[ProjectComany].[CompanyID] = @CompanyID
	AND [ProjectComany].[ProjectID] = @ProjectID " + ProjectComany.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", @companyID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<ProjectComany>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ProjectComany objects.
		/// </summary>
		/// <returns>The retrieved collection of ProjectComany objects.</returns>
		public static EntityList<ProjectComany> GetProjectComanies()
		{
			string commandText = @"
SELECT " + ProjectComany.SelectFieldList + "FROM [dbo].[ProjectComany] " + ProjectComany.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ProjectComany>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ProjectComany objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectComany objects.</returns>
        public static EntityList<ProjectComany> GetProjectComanies(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectComany>(SelectFieldList, "FROM [dbo].[ProjectComany]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ProjectComany objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectComany objects.</returns>
        public static EntityList<ProjectComany> GetProjectComanies(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectComany>(SelectFieldList, "FROM [dbo].[ProjectComany]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ProjectComany objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ProjectComany objects.</returns>
		protected static EntityList<ProjectComany> GetProjectComanies(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectComanies(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ProjectComany objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectComany objects.</returns>
		protected static EntityList<ProjectComany> GetProjectComanies(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectComanies(string.Empty, where, parameters, ProjectComany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectComany objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectComany objects.</returns>
		protected static EntityList<ProjectComany> GetProjectComanies(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectComanies(prefix, where, parameters, ProjectComany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectComany objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectComany objects.</returns>
		protected static EntityList<ProjectComany> GetProjectComanies(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectComanies(string.Empty, where, parameters, ProjectComany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectComany objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectComany objects.</returns>
		protected static EntityList<ProjectComany> GetProjectComanies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectComanies(prefix, where, parameters, ProjectComany.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectComany objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ProjectComany objects.</returns>
		protected static EntityList<ProjectComany> GetProjectComanies(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ProjectComany.SelectFieldList + "FROM [dbo].[ProjectComany] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ProjectComany>(reader);
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
        protected static EntityList<ProjectComany> GetProjectComanies(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectComany>(SelectFieldList, "FROM [dbo].[ProjectComany] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ProjectComanyProperties
		{
			public const string CompanyID = "CompanyID";
			public const string ProjectID = "ProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"CompanyID" , "int:"},
    			 {"ProjectID" , "int:"},
            };
		}
		#endregion
	}
}
