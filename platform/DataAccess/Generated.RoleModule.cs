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
	/// This object represents the properties and methods of a RoleModule.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoleModule 
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
		private int _roleId = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoleId
		{
			[DebuggerStepThrough()]
			get { return this._roleId; }
			set 
			{
				if (this._roleId != value) 
				{
					this._roleId = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoleId");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _moduleId = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ModuleId
		{
			[DebuggerStepThrough()]
			get { return this._moduleId; }
			set 
			{
				if (this._moduleId != value) 
				{
					this._moduleId = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModuleId");
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
	[RoleId] int,
	[ModuleId] int,
	[UserID] int
);

INSERT INTO [dbo].[RoleModule] (
	[RoleModule].[RoleId],
	[RoleModule].[ModuleId],
	[RoleModule].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoleId],
	INSERTED.[ModuleId],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RoleId,
	@ModuleId,
	@UserID 
); 

SELECT 
	[ID],
	[RoleId],
	[ModuleId],
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
	[RoleId] int,
	[ModuleId] int,
	[UserID] int
);

UPDATE [dbo].[RoleModule] SET 
	[RoleModule].[RoleId] = @RoleId,
	[RoleModule].[ModuleId] = @ModuleId,
	[RoleModule].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[RoleId],
	INSERTED.[ModuleId],
	INSERTED.[UserID]
into @table
WHERE 
	[RoleModule].[ID] = @ID

SELECT 
	[ID],
	[RoleId],
	[ModuleId],
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
DELETE FROM [dbo].[RoleModule]
WHERE 
	[RoleModule].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoleModule() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoleModule(this.ID));
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
	[RoleModule].[ID],
	[RoleModule].[RoleId],
	[RoleModule].[ModuleId],
	[RoleModule].[UserID]
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
                return "RoleModule";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoleModule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleId">roleId</param>
		/// <param name="moduleId">moduleId</param>
		/// <param name="userID">userID</param>
		public static void InsertRoleModule(int @roleId, int @moduleId, int @userID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoleModule(@roleId, @moduleId, @userID, helper);
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
		/// Insert a RoleModule into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleId">roleId</param>
		/// <param name="moduleId">moduleId</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoleModule(int @roleId, int @moduleId, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoleId] int,
	[ModuleId] int,
	[UserID] int
);

INSERT INTO [dbo].[RoleModule] (
	[RoleModule].[RoleId],
	[RoleModule].[ModuleId],
	[RoleModule].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoleId],
	INSERTED.[ModuleId],
	INSERTED.[UserID]
into @table
VALUES ( 
	@RoleId,
	@ModuleId,
	@UserID 
); 

SELECT 
	[ID],
	[RoleId],
	[ModuleId],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleId", EntityBase.GetDatabaseValue(@roleId)));
			parameters.Add(new SqlParameter("@ModuleId", EntityBase.GetDatabaseValue(@moduleId)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoleModule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roleId">roleId</param>
		/// <param name="moduleId">moduleId</param>
		/// <param name="userID">userID</param>
		public static void UpdateRoleModule(int @iD, int @roleId, int @moduleId, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoleModule(@iD, @roleId, @moduleId, @userID, helper);
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
		/// Updates a RoleModule into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roleId">roleId</param>
		/// <param name="moduleId">moduleId</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoleModule(int @iD, int @roleId, int @moduleId, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoleId] int,
	[ModuleId] int,
	[UserID] int
);

UPDATE [dbo].[RoleModule] SET 
	[RoleModule].[RoleId] = @RoleId,
	[RoleModule].[ModuleId] = @ModuleId,
	[RoleModule].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[RoleId],
	INSERTED.[ModuleId],
	INSERTED.[UserID]
into @table
WHERE 
	[RoleModule].[ID] = @ID

SELECT 
	[ID],
	[RoleId],
	[ModuleId],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoleId", EntityBase.GetDatabaseValue(@roleId)));
			parameters.Add(new SqlParameter("@ModuleId", EntityBase.GetDatabaseValue(@moduleId)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoleModule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoleModule(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoleModule(@iD, helper);
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
		/// Deletes a RoleModule from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoleModule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoleModule]
WHERE 
	[RoleModule].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoleModule object.
		/// </summary>
		/// <returns>The newly created RoleModule object.</returns>
		public static RoleModule CreateRoleModule()
		{
			return InitializeNew<RoleModule>();
		}
		
		/// <summary>
		/// Retrieve information for a RoleModule by a RoleModule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoleModule</returns>
		public static RoleModule GetRoleModule(int @iD)
		{
			string commandText = @"
SELECT 
" + RoleModule.SelectFieldList + @"
FROM [dbo].[RoleModule] 
WHERE 
	[RoleModule].[ID] = @ID " + RoleModule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoleModule>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoleModule by a RoleModule's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoleModule</returns>
		public static RoleModule GetRoleModule(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoleModule.SelectFieldList + @"
FROM [dbo].[RoleModule] 
WHERE 
	[RoleModule].[ID] = @ID " + RoleModule.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoleModule>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoleModule objects.
		/// </summary>
		/// <returns>The retrieved collection of RoleModule objects.</returns>
		public static EntityList<RoleModule> GetRoleModules()
		{
			string commandText = @"
SELECT " + RoleModule.SelectFieldList + "FROM [dbo].[RoleModule] " + RoleModule.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoleModule>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoleModule objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoleModule objects.</returns>
        public static EntityList<RoleModule> GetRoleModules(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoleModule>(SelectFieldList, "FROM [dbo].[RoleModule]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoleModule objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoleModule objects.</returns>
        public static EntityList<RoleModule> GetRoleModules(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoleModule>(SelectFieldList, "FROM [dbo].[RoleModule]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoleModule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoleModule objects.</returns>
		protected static EntityList<RoleModule> GetRoleModules(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoleModules(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoleModule objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoleModule objects.</returns>
		protected static EntityList<RoleModule> GetRoleModules(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoleModules(string.Empty, where, parameters, RoleModule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleModule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoleModule objects.</returns>
		protected static EntityList<RoleModule> GetRoleModules(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoleModules(prefix, where, parameters, RoleModule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleModule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoleModule objects.</returns>
		protected static EntityList<RoleModule> GetRoleModules(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoleModules(string.Empty, where, parameters, RoleModule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleModule objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoleModule objects.</returns>
		protected static EntityList<RoleModule> GetRoleModules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoleModules(prefix, where, parameters, RoleModule.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoleModule objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoleModule objects.</returns>
		protected static EntityList<RoleModule> GetRoleModules(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoleModule.SelectFieldList + "FROM [dbo].[RoleModule] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoleModule>(reader);
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
        protected static EntityList<RoleModule> GetRoleModules(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoleModule>(SelectFieldList, "FROM [dbo].[RoleModule] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoleModule objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoleModuleCount()
        {
            return GetRoleModuleCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoleModule objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoleModuleCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoleModule] " + where;

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
		public static partial class RoleModule_Properties
		{
			public const string ID = "ID";
			public const string RoleId = "RoleId";
			public const string ModuleId = "ModuleId";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoleId" , "int:"},
    			 {"ModuleId" , "int:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
