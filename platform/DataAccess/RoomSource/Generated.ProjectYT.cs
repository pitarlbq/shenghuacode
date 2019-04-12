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
	/// This object represents the properties and methods of a ProjectYT.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ProjectYT 
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
		private int _orderBy = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderBy
		{
			[DebuggerStepThrough()]
			get { return this._orderBy; }
			set 
			{
				if (this._orderBy != value) 
				{
					this._orderBy = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderBy");
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
	[OrderBy] int
);

INSERT INTO [dbo].[ProjectYT] (
	[ProjectYT].[Name],
	[ProjectYT].[OrderBy]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[OrderBy]
into @table
VALUES ( 
	@Name,
	@OrderBy 
); 

SELECT 
	[ID],
	[Name],
	[OrderBy] 
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
	[OrderBy] int
);

UPDATE [dbo].[ProjectYT] SET 
	[ProjectYT].[Name] = @Name,
	[ProjectYT].[OrderBy] = @OrderBy 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[OrderBy]
into @table
WHERE 
	[ProjectYT].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[OrderBy] 
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
DELETE FROM [dbo].[ProjectYT]
WHERE 
	[ProjectYT].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ProjectYT() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProjectYT(this.ID));
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
	[ProjectYT].[ID],
	[ProjectYT].[Name],
	[ProjectYT].[OrderBy]
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
                return "ProjectYT";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ProjectYT into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="orderBy">orderBy</param>
		public static void InsertProjectYT(string @name, int @orderBy)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProjectYT(@name, @orderBy, helper);
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
		/// Insert a ProjectYT into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="helper">helper</param>
		internal static void InsertProjectYT(string @name, int @orderBy, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[OrderBy] int
);

INSERT INTO [dbo].[ProjectYT] (
	[ProjectYT].[Name],
	[ProjectYT].[OrderBy]
) 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[OrderBy]
into @table
VALUES ( 
	@Name,
	@OrderBy 
); 

SELECT 
	[ID],
	[Name],
	[OrderBy] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ProjectYT into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="orderBy">orderBy</param>
		public static void UpdateProjectYT(int @iD, string @name, int @orderBy)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProjectYT(@iD, @name, @orderBy, helper);
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
		/// Updates a ProjectYT into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="name">name</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProjectYT(int @iD, string @name, int @orderBy, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[Name] nvarchar(100),
	[OrderBy] int
);

UPDATE [dbo].[ProjectYT] SET 
	[ProjectYT].[Name] = @Name,
	[ProjectYT].[OrderBy] = @OrderBy 
output 
	INSERTED.[ID],
	INSERTED.[Name],
	INSERTED.[OrderBy]
into @table
WHERE 
	[ProjectYT].[ID] = @ID

SELECT 
	[ID],
	[Name],
	[OrderBy] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ProjectYT from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProjectYT(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProjectYT(@iD, helper);
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
		/// Deletes a ProjectYT from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProjectYT(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ProjectYT]
WHERE 
	[ProjectYT].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ProjectYT object.
		/// </summary>
		/// <returns>The newly created ProjectYT object.</returns>
		public static ProjectYT CreateProjectYT()
		{
			return InitializeNew<ProjectYT>();
		}
		
		/// <summary>
		/// Retrieve information for a ProjectYT by a ProjectYT's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ProjectYT</returns>
		public static ProjectYT GetProjectYT(int @iD)
		{
			string commandText = @"
SELECT 
" + ProjectYT.SelectFieldList + @"
FROM [dbo].[ProjectYT] 
WHERE 
	[ProjectYT].[ID] = @ID " + ProjectYT.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectYT>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ProjectYT by a ProjectYT's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ProjectYT</returns>
		public static ProjectYT GetProjectYT(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ProjectYT.SelectFieldList + @"
FROM [dbo].[ProjectYT] 
WHERE 
	[ProjectYT].[ID] = @ID " + ProjectYT.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectYT>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ProjectYT objects.
		/// </summary>
		/// <returns>The retrieved collection of ProjectYT objects.</returns>
		public static EntityList<ProjectYT> GetProjectYTs()
		{
			string commandText = @"
SELECT " + ProjectYT.SelectFieldList + "FROM [dbo].[ProjectYT] " + ProjectYT.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ProjectYT>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ProjectYT objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectYT objects.</returns>
        public static EntityList<ProjectYT> GetProjectYTs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectYT>(SelectFieldList, "FROM [dbo].[ProjectYT]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ProjectYT objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectYT objects.</returns>
        public static EntityList<ProjectYT> GetProjectYTs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectYT>(SelectFieldList, "FROM [dbo].[ProjectYT]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ProjectYT objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ProjectYT objects.</returns>
		protected static EntityList<ProjectYT> GetProjectYTs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectYTs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ProjectYT objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectYT objects.</returns>
		protected static EntityList<ProjectYT> GetProjectYTs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectYTs(string.Empty, where, parameters, ProjectYT.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectYT objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectYT objects.</returns>
		protected static EntityList<ProjectYT> GetProjectYTs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectYTs(prefix, where, parameters, ProjectYT.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectYT objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectYT objects.</returns>
		protected static EntityList<ProjectYT> GetProjectYTs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectYTs(string.Empty, where, parameters, ProjectYT.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectYT objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectYT objects.</returns>
		protected static EntityList<ProjectYT> GetProjectYTs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectYTs(prefix, where, parameters, ProjectYT.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectYT objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ProjectYT objects.</returns>
		protected static EntityList<ProjectYT> GetProjectYTs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ProjectYT.SelectFieldList + "FROM [dbo].[ProjectYT] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ProjectYT>(reader);
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
        protected static EntityList<ProjectYT> GetProjectYTs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectYT>(SelectFieldList, "FROM [dbo].[ProjectYT] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ProjectYTProperties
		{
			public const string ID = "ID";
			public const string Name = "Name";
			public const string OrderBy = "OrderBy";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"Name" , "string:"},
    			 {"OrderBy" , "int:"},
            };
		}
		#endregion
	}
}
