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
	/// This object represents the properties and methods of a Role.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("RoleID: {RoleID}")]
	public partial class Role 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _roleID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, true, false)]
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
		private string _roleName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string RoleName
		{
			[DebuggerStepThrough()]
			get { return this._roleName; }
			set 
			{
				if (this._roleName != value) 
				{
					this._roleName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoleName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roleDes = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoleDes
		{
			[DebuggerStepThrough()]
			get { return this._roleDes; }
			set 
			{
				if (this._roleDes != value) 
				{
					this._roleDes = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoleDes");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _type = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int Type
		{
			[DebuggerStepThrough()]
			get { return this._type; }
			set 
			{
				if (this._type != value) 
				{
					this._type = value;
					this.IsDirty = true;	
					OnPropertyChanged("Type");
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
	[RoleID] int,
	[RoleName] nvarchar(256),
	[RoleDes] varchar(100),
	[Type] int
);

INSERT INTO [dbo].[Roles] (
	[Roles].[RoleName],
	[Roles].[RoleDes],
	[Roles].[Type]
) 
output 
	INSERTED.[RoleID],
	INSERTED.[RoleName],
	INSERTED.[RoleDes],
	INSERTED.[Type]
into @table
VALUES ( 
	@RoleName,
	@RoleDes,
	ISNULL(@Type, ((0))) 
); 

SELECT 
	[RoleID],
	[RoleName],
	[RoleDes],
	[Type] 
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
	[RoleID] int,
	[RoleName] nvarchar(256),
	[RoleDes] varchar(100),
	[Type] int
);

UPDATE [dbo].[Roles] SET 
	[Roles].[RoleName] = @RoleName,
	[Roles].[RoleDes] = @RoleDes,
	[Roles].[Type] = @Type 
output 
	INSERTED.[RoleID],
	INSERTED.[RoleName],
	INSERTED.[RoleDes],
	INSERTED.[Type]
into @table
WHERE 
	[Roles].[RoleID] = @RoleID

SELECT 
	[RoleID],
	[RoleName],
	[RoleDes],
	[Type] 
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
DELETE FROM [dbo].[Roles]
WHERE 
	[Roles].[RoleID] = @RoleID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Role() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRole(this.RoleID));
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
	[Roles].[RoleID],
	[Roles].[RoleName],
	[Roles].[RoleDes],
	[Roles].[Type]
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
                return "Roles";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Role into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleName">roleName</param>
		/// <param name="roleDes">roleDes</param>
		/// <param name="type">type</param>
		public static void InsertRole(string @roleName, string @roleDes, int @type)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRole(@roleName, @roleDes, @type, helper);
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
		/// Insert a Role into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleName">roleName</param>
		/// <param name="roleDes">roleDes</param>
		/// <param name="type">type</param>
		/// <param name="helper">helper</param>
		internal static void InsertRole(string @roleName, string @roleDes, int @type, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[RoleID] int,
	[RoleName] nvarchar(256),
	[RoleDes] varchar(100),
	[Type] int
);

INSERT INTO [dbo].[Roles] (
	[Roles].[RoleName],
	[Roles].[RoleDes],
	[Roles].[Type]
) 
output 
	INSERTED.[RoleID],
	INSERTED.[RoleName],
	INSERTED.[RoleDes],
	INSERTED.[Type]
into @table
VALUES ( 
	@RoleName,
	@RoleDes,
	ISNULL(@Type, ((0))) 
); 

SELECT 
	[RoleID],
	[RoleName],
	[RoleDes],
	[Type] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleName", EntityBase.GetDatabaseValue(@roleName)));
			parameters.Add(new SqlParameter("@RoleDes", EntityBase.GetDatabaseValue(@roleDes)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Role into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="roleName">roleName</param>
		/// <param name="roleDes">roleDes</param>
		/// <param name="type">type</param>
		public static void UpdateRole(int @roleID, string @roleName, string @roleDes, int @type)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRole(@roleID, @roleName, @roleDes, @type, helper);
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
		/// Updates a Role into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="roleName">roleName</param>
		/// <param name="roleDes">roleDes</param>
		/// <param name="type">type</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRole(int @roleID, string @roleName, string @roleDes, int @type, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[RoleID] int,
	[RoleName] nvarchar(256),
	[RoleDes] varchar(100),
	[Type] int
);

UPDATE [dbo].[Roles] SET 
	[Roles].[RoleName] = @RoleName,
	[Roles].[RoleDes] = @RoleDes,
	[Roles].[Type] = @Type 
output 
	INSERTED.[RoleID],
	INSERTED.[RoleName],
	INSERTED.[RoleDes],
	INSERTED.[Type]
into @table
WHERE 
	[Roles].[RoleID] = @RoleID

SELECT 
	[RoleID],
	[RoleName],
	[RoleDes],
	[Type] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", EntityBase.GetDatabaseValue(@roleID)));
			parameters.Add(new SqlParameter("@RoleName", EntityBase.GetDatabaseValue(@roleName)));
			parameters.Add(new SqlParameter("@RoleDes", EntityBase.GetDatabaseValue(@roleDes)));
			parameters.Add(new SqlParameter("@Type", EntityBase.GetDatabaseValue(@type)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Role from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		public static void DeleteRole(int @roleID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRole(@roleID, helper);
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
		/// Deletes a Role from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRole(int @roleID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Roles]
WHERE 
	[Roles].[RoleID] = @RoleID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", @roleID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Role object.
		/// </summary>
		/// <returns>The newly created Role object.</returns>
		public static Role CreateRole()
		{
			return InitializeNew<Role>();
		}
		
		/// <summary>
		/// Retrieve information for a Role by a Role's unique identifier.
		/// </summary>
		/// <param name="roleID">roleID</param>
		/// <returns>Role</returns>
		public static Role GetRole(int @roleID)
		{
			string commandText = @"
SELECT 
" + Role.SelectFieldList + @"
FROM [dbo].[Roles] 
WHERE 
	[Roles].[RoleID] = @RoleID " + Role.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", @roleID));
			
			return GetOne<Role>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Role by a Role's unique identifier.
		/// </summary>
		/// <param name="roleID">roleID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Role</returns>
		public static Role GetRole(int @roleID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Role.SelectFieldList + @"
FROM [dbo].[Roles] 
WHERE 
	[Roles].[RoleID] = @RoleID " + Role.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoleID", @roleID));
			
			return GetOne<Role>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Role objects.
		/// </summary>
		/// <returns>The retrieved collection of Role objects.</returns>
		public static EntityList<Role> GetRoles()
		{
			string commandText = @"
SELECT " + Role.SelectFieldList + "FROM [dbo].[Roles] " + Role.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Role>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Role objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Role objects.</returns>
        public static EntityList<Role> GetRoles(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Role>(SelectFieldList, "FROM [dbo].[Roles]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Role objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Role objects.</returns>
        public static EntityList<Role> GetRoles(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Role>(SelectFieldList, "FROM [dbo].[Roles]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Role objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Role objects.</returns>
		protected static EntityList<Role> GetRoles(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoles(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Role objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Role objects.</returns>
		protected static EntityList<Role> GetRoles(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoles(string.Empty, where, parameters, Role.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Role objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Role objects.</returns>
		protected static EntityList<Role> GetRoles(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoles(prefix, where, parameters, Role.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Role objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Role objects.</returns>
		protected static EntityList<Role> GetRoles(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoles(string.Empty, where, parameters, Role.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Role objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Role objects.</returns>
		protected static EntityList<Role> GetRoles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoles(prefix, where, parameters, Role.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Role objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Role objects.</returns>
		protected static EntityList<Role> GetRoles(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Role.SelectFieldList + "FROM [dbo].[Roles] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Role>(reader);
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
        protected static EntityList<Role> GetRoles(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Role>(SelectFieldList, "FROM [dbo].[Roles] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class RoleProperties
		{
			public const string RoleID = "RoleID";
			public const string RoleName = "RoleName";
			public const string RoleDes = "RoleDes";
			public const string Type = "Type";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"RoleID" , "int:"},
    			 {"RoleName" , "string:"},
    			 {"RoleDes" , "string:"},
    			 {"Type" , "int:"},
            };
		}
		#endregion
	}
}
