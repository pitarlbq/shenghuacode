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
	/// This object represents the properties and methods of a ProjectNameRelation.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}, PID: {PID}")]
	public partial class ProjectNameRelation 
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
		[DataObjectField(true, false, false)]
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
		private int _pID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int PID
		{
			[DebuggerStepThrough()]
			get { return this._pID; }
			set 
			{
				if (this._pID != value) 
				{
					this._pID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PID");
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
	[PID] int
);

INSERT INTO [dbo].[ProjectNameRelation] (
	[ProjectNameRelation].[ID],
	[ProjectNameRelation].[PID]
) 
output 
	INSERTED.[ID],
	INSERTED.[PID]
into @table
VALUES ( 
	@ID,
	@PID 
); 

SELECT 
	[ID],
	[PID] 
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
	[PID] int
);

UPDATE [dbo].[ProjectNameRelation] SET 
 
output 
	INSERTED.[ID],
	INSERTED.[PID]
into @table
WHERE 
	[ProjectNameRelation].[ID] = @ID
	AND [ProjectNameRelation].[PID] = @PID

SELECT 
	[ID],
	[PID] 
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
DELETE FROM [dbo].[ProjectNameRelation]
WHERE 
	[ProjectNameRelation].[ID] = @ID
	AND [ProjectNameRelation].[PID] = @PID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ProjectNameRelation() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProjectNameRelation(this.ID, this.PID));
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
	[ProjectNameRelation].[ID],
	[ProjectNameRelation].[PID]
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
                return "ProjectNameRelation";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ProjectNameRelation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
		public static void InsertProjectNameRelation(int @iD, int @pID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProjectNameRelation(@iD, @pID, helper);
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
		/// Insert a ProjectNameRelation into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
		/// <param name="helper">helper</param>
		internal static void InsertProjectNameRelation(int @iD, int @pID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PID] int
);

INSERT INTO [dbo].[ProjectNameRelation] (
	[ProjectNameRelation].[ID],
	[ProjectNameRelation].[PID]
) 
output 
	INSERTED.[ID],
	INSERTED.[PID]
into @table
VALUES ( 
	@ID,
	@PID 
); 

SELECT 
	[ID],
	[PID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PID", EntityBase.GetDatabaseValue(@pID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ProjectNameRelation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
		public static void UpdateProjectNameRelation(int @iD, int @pID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProjectNameRelation(@iD, @pID, helper);
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
		/// Updates a ProjectNameRelation into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProjectNameRelation(int @iD, int @pID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PID] int
);

UPDATE [dbo].[ProjectNameRelation] SET 
 
output 
	INSERTED.[ID],
	INSERTED.[PID]
into @table
WHERE 
	[ProjectNameRelation].[ID] = @ID
	AND [ProjectNameRelation].[PID] = @PID

SELECT 
	[ID],
	[PID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PID", EntityBase.GetDatabaseValue(@pID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ProjectNameRelation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
		public static void DeleteProjectNameRelation(int @iD, int @pID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProjectNameRelation(@iD, @pID, helper);
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
		/// Deletes a ProjectNameRelation from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProjectNameRelation(int @iD, int @pID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ProjectNameRelation]
WHERE 
	[ProjectNameRelation].[ID] = @ID
	AND [ProjectNameRelation].[PID] = @PID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			parameters.Add(new SqlParameter("@PID", @pID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ProjectNameRelation object.
		/// </summary>
		/// <returns>The newly created ProjectNameRelation object.</returns>
		public static ProjectNameRelation CreateProjectNameRelation()
		{
			return InitializeNew<ProjectNameRelation>();
		}
		
		/// <summary>
		/// Retrieve information for a ProjectNameRelation by a ProjectNameRelation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
		/// <returns>ProjectNameRelation</returns>
		public static ProjectNameRelation GetProjectNameRelation(int @iD, int @pID)
		{
			string commandText = @"
SELECT 
" + ProjectNameRelation.SelectFieldList + @"
FROM [dbo].[ProjectNameRelation] 
WHERE 
	[ProjectNameRelation].[ID] = @ID
	AND [ProjectNameRelation].[PID] = @PID " + ProjectNameRelation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			parameters.Add(new SqlParameter("@PID", @pID));
			
			return GetOne<ProjectNameRelation>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ProjectNameRelation by a ProjectNameRelation's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pID">pID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ProjectNameRelation</returns>
		public static ProjectNameRelation GetProjectNameRelation(int @iD, int @pID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ProjectNameRelation.SelectFieldList + @"
FROM [dbo].[ProjectNameRelation] 
WHERE 
	[ProjectNameRelation].[ID] = @ID
	AND [ProjectNameRelation].[PID] = @PID " + ProjectNameRelation.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			parameters.Add(new SqlParameter("@PID", @pID));
			
			return GetOne<ProjectNameRelation>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ProjectNameRelation objects.
		/// </summary>
		/// <returns>The retrieved collection of ProjectNameRelation objects.</returns>
		public static EntityList<ProjectNameRelation> GetProjectNameRelations()
		{
			string commandText = @"
SELECT " + ProjectNameRelation.SelectFieldList + "FROM [dbo].[ProjectNameRelation] " + ProjectNameRelation.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ProjectNameRelation>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ProjectNameRelation objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectNameRelation objects.</returns>
        public static EntityList<ProjectNameRelation> GetProjectNameRelations(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectNameRelation>(SelectFieldList, "FROM [dbo].[ProjectNameRelation]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ProjectNameRelation objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectNameRelation objects.</returns>
        public static EntityList<ProjectNameRelation> GetProjectNameRelations(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectNameRelation>(SelectFieldList, "FROM [dbo].[ProjectNameRelation]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ProjectNameRelation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ProjectNameRelation objects.</returns>
		protected static EntityList<ProjectNameRelation> GetProjectNameRelations(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectNameRelations(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ProjectNameRelation objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectNameRelation objects.</returns>
		protected static EntityList<ProjectNameRelation> GetProjectNameRelations(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectNameRelations(string.Empty, where, parameters, ProjectNameRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectNameRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectNameRelation objects.</returns>
		protected static EntityList<ProjectNameRelation> GetProjectNameRelations(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectNameRelations(prefix, where, parameters, ProjectNameRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectNameRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectNameRelation objects.</returns>
		protected static EntityList<ProjectNameRelation> GetProjectNameRelations(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectNameRelations(string.Empty, where, parameters, ProjectNameRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectNameRelation objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectNameRelation objects.</returns>
		protected static EntityList<ProjectNameRelation> GetProjectNameRelations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectNameRelations(prefix, where, parameters, ProjectNameRelation.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectNameRelation objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ProjectNameRelation objects.</returns>
		protected static EntityList<ProjectNameRelation> GetProjectNameRelations(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ProjectNameRelation.SelectFieldList + "FROM [dbo].[ProjectNameRelation] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ProjectNameRelation>(reader);
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
        protected static EntityList<ProjectNameRelation> GetProjectNameRelations(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectNameRelation>(SelectFieldList, "FROM [dbo].[ProjectNameRelation] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ProjectNameRelationProperties
		{
			public const string ID = "ID";
			public const string PID = "PID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"PID" , "int:"},
            };
		}
		#endregion
	}
}
