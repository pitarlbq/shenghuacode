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
	/// This object represents the properties and methods of a Mall_UserProject.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("UserID: {UserID}, ProjectID: {ProjectID}")]
	public partial class Mall_UserProject 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isManualAdd = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsManualAdd
		{
			[DebuggerStepThrough()]
			get { return this._isManualAdd; }
			set 
			{
				if (this._isManualAdd != value) 
				{
					this._isManualAdd = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsManualAdd");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDisable = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDisable
		{
			[DebuggerStepThrough()]
			get { return this._isDisable; }
			set 
			{
				if (this._isDisable != value) 
				{
					this._isDisable = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDisable");
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
	[UserID] int,
	[ProjectID] int,
	[IsManualAdd] bit,
	[IsDisable] bit
);

INSERT INTO [dbo].[Mall_UserProject] (
	[Mall_UserProject].[UserID],
	[Mall_UserProject].[ProjectID],
	[Mall_UserProject].[IsManualAdd],
	[Mall_UserProject].[IsDisable]
) 
output 
	INSERTED.[UserID],
	INSERTED.[ProjectID],
	INSERTED.[IsManualAdd],
	INSERTED.[IsDisable]
into @table
VALUES ( 
	@UserID,
	@ProjectID,
	@IsManualAdd,
	@IsDisable 
); 

SELECT 
	[UserID],
	[ProjectID],
	[IsManualAdd],
	[IsDisable] 
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
	[UserID] int,
	[ProjectID] int,
	[IsManualAdd] bit,
	[IsDisable] bit
);

UPDATE [dbo].[Mall_UserProject] SET 
	[Mall_UserProject].[IsManualAdd] = @IsManualAdd,
	[Mall_UserProject].[IsDisable] = @IsDisable 
output 
	INSERTED.[UserID],
	INSERTED.[ProjectID],
	INSERTED.[IsManualAdd],
	INSERTED.[IsDisable]
into @table
WHERE 
	[Mall_UserProject].[UserID] = @UserID
	AND [Mall_UserProject].[ProjectID] = @ProjectID

SELECT 
	[UserID],
	[ProjectID],
	[IsManualAdd],
	[IsDisable] 
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
DELETE FROM [dbo].[Mall_UserProject]
WHERE 
	[Mall_UserProject].[UserID] = @UserID
	AND [Mall_UserProject].[ProjectID] = @ProjectID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Mall_UserProject() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetMall_UserProject(this.UserID, this.ProjectID));
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
	[Mall_UserProject].[UserID],
	[Mall_UserProject].[ProjectID],
	[Mall_UserProject].[IsManualAdd],
	[Mall_UserProject].[IsDisable]
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
                return "Mall_UserProject";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Mall_UserProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="isManualAdd">isManualAdd</param>
		/// <param name="isDisable">isDisable</param>
		public static void InsertMall_UserProject(int @userID, int @projectID, bool @isManualAdd, bool @isDisable)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertMall_UserProject(@userID, @projectID, @isManualAdd, @isDisable, helper);
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
		/// Insert a Mall_UserProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="isManualAdd">isManualAdd</param>
		/// <param name="isDisable">isDisable</param>
		/// <param name="helper">helper</param>
		internal static void InsertMall_UserProject(int @userID, int @projectID, bool @isManualAdd, bool @isDisable, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[UserID] int,
	[ProjectID] int,
	[IsManualAdd] bit,
	[IsDisable] bit
);

INSERT INTO [dbo].[Mall_UserProject] (
	[Mall_UserProject].[UserID],
	[Mall_UserProject].[ProjectID],
	[Mall_UserProject].[IsManualAdd],
	[Mall_UserProject].[IsDisable]
) 
output 
	INSERTED.[UserID],
	INSERTED.[ProjectID],
	INSERTED.[IsManualAdd],
	INSERTED.[IsDisable]
into @table
VALUES ( 
	@UserID,
	@ProjectID,
	@IsManualAdd,
	@IsDisable 
); 

SELECT 
	[UserID],
	[ProjectID],
	[IsManualAdd],
	[IsDisable] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@IsManualAdd", @isManualAdd));
			parameters.Add(new SqlParameter("@IsDisable", @isDisable));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Mall_UserProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="isManualAdd">isManualAdd</param>
		/// <param name="isDisable">isDisable</param>
		public static void UpdateMall_UserProject(int @userID, int @projectID, bool @isManualAdd, bool @isDisable)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateMall_UserProject(@userID, @projectID, @isManualAdd, @isDisable, helper);
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
		/// Updates a Mall_UserProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="isManualAdd">isManualAdd</param>
		/// <param name="isDisable">isDisable</param>
		/// <param name="helper">helper</param>
		internal static void UpdateMall_UserProject(int @userID, int @projectID, bool @isManualAdd, bool @isDisable, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[UserID] int,
	[ProjectID] int,
	[IsManualAdd] bit,
	[IsDisable] bit
);

UPDATE [dbo].[Mall_UserProject] SET 
	[Mall_UserProject].[IsManualAdd] = @IsManualAdd,
	[Mall_UserProject].[IsDisable] = @IsDisable 
output 
	INSERTED.[UserID],
	INSERTED.[ProjectID],
	INSERTED.[IsManualAdd],
	INSERTED.[IsDisable]
into @table
WHERE 
	[Mall_UserProject].[UserID] = @UserID
	AND [Mall_UserProject].[ProjectID] = @ProjectID

SELECT 
	[UserID],
	[ProjectID],
	[IsManualAdd],
	[IsDisable] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@IsManualAdd", @isManualAdd));
			parameters.Add(new SqlParameter("@IsDisable", @isDisable));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Mall_UserProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		public static void DeleteMall_UserProject(int @userID, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteMall_UserProject(@userID, @projectID, helper);
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
		/// Deletes a Mall_UserProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteMall_UserProject(int @userID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Mall_UserProject]
WHERE 
	[Mall_UserProject].[UserID] = @UserID
	AND [Mall_UserProject].[ProjectID] = @ProjectID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", @userID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Mall_UserProject object.
		/// </summary>
		/// <returns>The newly created Mall_UserProject object.</returns>
		public static Mall_UserProject CreateMall_UserProject()
		{
			return InitializeNew<Mall_UserProject>();
		}
		
		/// <summary>
		/// Retrieve information for a Mall_UserProject by a Mall_UserProject's unique identifier.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
		/// <returns>Mall_UserProject</returns>
		public static Mall_UserProject GetMall_UserProject(int @userID, int @projectID)
		{
			string commandText = @"
SELECT 
" + Mall_UserProject.SelectFieldList + @"
FROM [dbo].[Mall_UserProject] 
WHERE 
	[Mall_UserProject].[UserID] = @UserID
	AND [Mall_UserProject].[ProjectID] = @ProjectID " + Mall_UserProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", @userID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Mall_UserProject>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Mall_UserProject by a Mall_UserProject's unique identifier.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="projectID">projectID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Mall_UserProject</returns>
		public static Mall_UserProject GetMall_UserProject(int @userID, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Mall_UserProject.SelectFieldList + @"
FROM [dbo].[Mall_UserProject] 
WHERE 
	[Mall_UserProject].[UserID] = @UserID
	AND [Mall_UserProject].[ProjectID] = @ProjectID " + Mall_UserProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", @userID));
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			
			return GetOne<Mall_UserProject>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserProject objects.
		/// </summary>
		/// <returns>The retrieved collection of Mall_UserProject objects.</returns>
		public static EntityList<Mall_UserProject> GetMall_UserProjects()
		{
			string commandText = @"
SELECT " + Mall_UserProject.SelectFieldList + "FROM [dbo].[Mall_UserProject] " + Mall_UserProject.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Mall_UserProject>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Mall_UserProject objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserProject objects.</returns>
        public static EntityList<Mall_UserProject> GetMall_UserProjects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserProject>(SelectFieldList, "FROM [dbo].[Mall_UserProject]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Mall_UserProject objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Mall_UserProject objects.</returns>
        public static EntityList<Mall_UserProject> GetMall_UserProjects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserProject>(SelectFieldList, "FROM [dbo].[Mall_UserProject]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Mall_UserProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserProject objects.</returns>
		protected static EntityList<Mall_UserProject> GetMall_UserProjects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserProjects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserProject objects.</returns>
		protected static EntityList<Mall_UserProject> GetMall_UserProjects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserProjects(string.Empty, where, parameters, Mall_UserProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserProject objects.</returns>
		protected static EntityList<Mall_UserProject> GetMall_UserProjects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetMall_UserProjects(prefix, where, parameters, Mall_UserProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserProject objects.</returns>
		protected static EntityList<Mall_UserProject> GetMall_UserProjects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserProjects(string.Empty, where, parameters, Mall_UserProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Mall_UserProject objects.</returns>
		protected static EntityList<Mall_UserProject> GetMall_UserProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetMall_UserProjects(prefix, where, parameters, Mall_UserProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Mall_UserProject objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Mall_UserProject objects.</returns>
		protected static EntityList<Mall_UserProject> GetMall_UserProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Mall_UserProject.SelectFieldList + "FROM [dbo].[Mall_UserProject] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Mall_UserProject>(reader);
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
        protected static EntityList<Mall_UserProject> GetMall_UserProjects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Mall_UserProject>(SelectFieldList, "FROM [dbo].[Mall_UserProject] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Mall_UserProject objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserProjectCount()
        {
            return GetMall_UserProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Mall_UserProject objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetMall_UserProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Mall_UserProject] " + where;

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
		public static partial class Mall_UserProject_Properties
		{
			public const string UserID = "UserID";
			public const string ProjectID = "ProjectID";
			public const string IsManualAdd = "IsManualAdd";
			public const string IsDisable = "IsDisable";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"UserID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"IsManualAdd" , "bool:"},
    			 {"IsDisable" , "bool:"},
            };
		}
		#endregion
	}
}
