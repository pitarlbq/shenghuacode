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
	/// This object represents the properties and methods of a RoleProject.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoleProject 
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
		private int _roleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoleID
		{
			[DebuggerStepThrough()]
			get { return this._roleID; }
			set 
			{
				if (this._roleID != value) 
				{
					this._roleID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoleID");
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
		[DataObjectField(false, false, false)]
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
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
	[RoleID] int,
	[ProjectID] int,
	[UserID] int
);

INSERT INTO [dbo].[RoleProject] (
	[RoleProject].[RoleID],
	[RoleProject].[ProjectID],
	[RoleProject].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[ProjectID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RoleID,
	@ProjectID,
	@UserID 
); 

SELECT 
	[ID],
	[RoleID],
	[ProjectID],
	[UserID] 
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
	[RoleID] int,
	[ProjectID] int,
	[UserID] int
);

UPDATE [dbo].[RoleProject] SET 
	[RoleProject].[RoleID] = @RoleID,
	[RoleProject].[ProjectID] = @ProjectID,
	[RoleProject].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[ProjectID],
	INSERTED.[UserID]
into @table
WHERE 
	[RoleProject].[ID] = @ID

SELECT 
	[ID],
	[RoleID],
	[ProjectID],
	[UserID] 
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
DELETE FROM [dbo].[RoleProject]
WHERE 
	[RoleProject].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoleProject() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoleProject(this.ID));
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
	[RoleProject].[ID],
	[RoleProject].[RoleID],
	[RoleProject].[ProjectID],
	[RoleProject].[UserID]
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
                return "RoleProject";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoleProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="userID">userID</param>
		public static void InsertRoleProject(int @roleID, int @projectID, int @userID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoleProject(@roleID, @projectID, @userID, helper);
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
		/// Insert a RoleProject into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoleProject(int @roleID, int @projectID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoleID] int,
	[ProjectID] int,
	[UserID] int
);

INSERT INTO [dbo].[RoleProject] (
	[RoleProject].[RoleID],
	[RoleProject].[ProjectID],
	[RoleProject].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[ProjectID],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RoleID,
	@ProjectID,
	@UserID 
); 

SELECT 
	[ID],
	[RoleID],
	[ProjectID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoleProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roleID">roleID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="userID">userID</param>
		public static void UpdateRoleProject(int @iD, int @roleID, int @projectID, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoleProject(@iD, @roleID, @projectID, @userID, helper);
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
		/// Updates a RoleProject into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roleID">roleID</param>
		/// <param name="projectID">projectID</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoleProject(int @iD, int @roleID, int @projectID, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoleID] int,
	[ProjectID] int,
	[UserID] int
);

UPDATE [dbo].[RoleProject] SET 
	[RoleProject].[RoleID] = @RoleID,
	[RoleProject].[ProjectID] = @ProjectID,
	[RoleProject].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[RoleID],
	INSERTED.[ProjectID],
	INSERTED.[UserID]
into @table
WHERE 
	[RoleProject].[ID] = @ID

SELECT 
	[ID],
	[RoleID],
	[ProjectID],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoleProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoleProject(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoleProject(@iD, helper);
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
		/// Deletes a RoleProject from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoleProject(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoleProject]
WHERE 
	[RoleProject].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoleProject object.
		/// </summary>
		/// <returns>The newly created RoleProject object.</returns>
		public static RoleProject CreateRoleProject()
		{
			return InitializeNew<RoleProject>();
		}
		
		/// <summary>
		/// Retrieve information for a RoleProject by a RoleProject's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoleProject</returns>
		public static RoleProject GetRoleProject(int @iD)
		{
			string commandText = @"
SELECT 
" + RoleProject.SelectFieldList + @"
FROM [dbo].[RoleProject] 
WHERE 
	[RoleProject].[ID] = @ID " + RoleProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoleProject>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoleProject by a RoleProject's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoleProject</returns>
		public static RoleProject GetRoleProject(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoleProject.SelectFieldList + @"
FROM [dbo].[RoleProject] 
WHERE 
	[RoleProject].[ID] = @ID " + RoleProject.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoleProject>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoleProject objects.
		/// </summary>
		/// <returns>The retrieved collection of RoleProject objects.</returns>
		public static EntityList<RoleProject> GetRoleProjects()
		{
			string commandText = @"
SELECT " + RoleProject.SelectFieldList + "FROM [dbo].[RoleProject] " + RoleProject.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoleProject>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoleProject objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoleProject objects.</returns>
        public static EntityList<RoleProject> GetRoleProjects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoleProject>(SelectFieldList, "FROM [dbo].[RoleProject]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoleProject objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoleProject objects.</returns>
        public static EntityList<RoleProject> GetRoleProjects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoleProject>(SelectFieldList, "FROM [dbo].[RoleProject]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoleProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoleProject objects.</returns>
		protected static EntityList<RoleProject> GetRoleProjects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoleProjects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoleProject objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoleProject objects.</returns>
		protected static EntityList<RoleProject> GetRoleProjects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoleProjects(string.Empty, where, parameters, RoleProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoleProject objects.</returns>
		protected static EntityList<RoleProject> GetRoleProjects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoleProjects(prefix, where, parameters, RoleProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoleProject objects.</returns>
		protected static EntityList<RoleProject> GetRoleProjects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoleProjects(string.Empty, where, parameters, RoleProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleProject objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoleProject objects.</returns>
		protected static EntityList<RoleProject> GetRoleProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoleProjects(prefix, where, parameters, RoleProject.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleProject objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoleProject objects.</returns>
		protected static EntityList<RoleProject> GetRoleProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoleProject.SelectFieldList + "FROM [dbo].[RoleProject] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoleProject>(reader);
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
        protected static EntityList<RoleProject> GetRoleProjects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoleProject>(SelectFieldList, "FROM [dbo].[RoleProject] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoleProject objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoleProjectCount()
        {
            return GetRoleProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoleProject objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoleProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoleProject] " + where;

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
		public static partial class RoleProject_Properties
		{
			public const string ID = "ID";
			public const string RoleID = "RoleID";
			public const string ProjectID = "ProjectID";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoleID" , "int:"},
    			 {"ProjectID" , "int:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
