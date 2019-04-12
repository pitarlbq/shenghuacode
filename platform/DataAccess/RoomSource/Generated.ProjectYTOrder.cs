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
	/// This object represents the properties and methods of a ProjectYTOrder.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ProjectYTOrder 
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
		[DataObjectField(false, false, false)]
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
		private int _orderBy = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
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
		private bool _isShow = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool IsShow
		{
			[DebuggerStepThrough()]
			get { return this._isShow; }
			set 
			{
				if (this._isShow != value) 
				{
					this._isShow = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsShow");
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
	[OrderBy] int,
	[Name] nvarchar(100),
	[IsShow] bit,
	[ProjectID] int
);

INSERT INTO [dbo].[ProjectYTOrder] (
	[ProjectYTOrder].[CompanyID],
	[ProjectYTOrder].[OrderBy],
	[ProjectYTOrder].[Name],
	[ProjectYTOrder].[IsShow],
	[ProjectYTOrder].[ProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[Name],
	INSERTED.[IsShow],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@CompanyID,
	@OrderBy,
	@Name,
	@IsShow,
	@ProjectID 
); 

SELECT 
	[ID],
	[CompanyID],
	[OrderBy],
	[Name],
	[IsShow],
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
	[ID] int,
	[CompanyID] int,
	[OrderBy] int,
	[Name] nvarchar(100),
	[IsShow] bit,
	[ProjectID] int
);

UPDATE [dbo].[ProjectYTOrder] SET 
	[ProjectYTOrder].[CompanyID] = @CompanyID,
	[ProjectYTOrder].[OrderBy] = @OrderBy,
	[ProjectYTOrder].[Name] = @Name,
	[ProjectYTOrder].[IsShow] = @IsShow,
	[ProjectYTOrder].[ProjectID] = @ProjectID 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[Name],
	INSERTED.[IsShow],
	INSERTED.[ProjectID]
into @table
WHERE 
	[ProjectYTOrder].[ID] = @ID

SELECT 
	[ID],
	[CompanyID],
	[OrderBy],
	[Name],
	[IsShow],
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
DELETE FROM [dbo].[ProjectYTOrder]
WHERE 
	[ProjectYTOrder].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ProjectYTOrder() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProjectYTOrder(this.ID));
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
	[ProjectYTOrder].[ID],
	[ProjectYTOrder].[CompanyID],
	[ProjectYTOrder].[OrderBy],
	[ProjectYTOrder].[Name],
	[ProjectYTOrder].[IsShow],
	[ProjectYTOrder].[ProjectID]
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
                return "ProjectYTOrder";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ProjectYTOrder into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="name">name</param>
		/// <param name="isShow">isShow</param>
		/// <param name="projectID">projectID</param>
		public static void InsertProjectYTOrder(int @companyID, int @orderBy, string @name, bool @isShow, int @projectID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProjectYTOrder(@companyID, @orderBy, @name, @isShow, @projectID, helper);
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
		/// Insert a ProjectYTOrder into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="name">name</param>
		/// <param name="isShow">isShow</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void InsertProjectYTOrder(int @companyID, int @orderBy, string @name, bool @isShow, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CompanyID] int,
	[OrderBy] int,
	[Name] nvarchar(100),
	[IsShow] bit,
	[ProjectID] int
);

INSERT INTO [dbo].[ProjectYTOrder] (
	[ProjectYTOrder].[CompanyID],
	[ProjectYTOrder].[OrderBy],
	[ProjectYTOrder].[Name],
	[ProjectYTOrder].[IsShow],
	[ProjectYTOrder].[ProjectID]
) 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[Name],
	INSERTED.[IsShow],
	INSERTED.[ProjectID]
into @table
VALUES ( 
	@CompanyID,
	@OrderBy,
	@Name,
	@IsShow,
	@ProjectID 
); 

SELECT 
	[ID],
	[CompanyID],
	[OrderBy],
	[Name],
	[IsShow],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@IsShow", @isShow));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ProjectYTOrder into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="name">name</param>
		/// <param name="isShow">isShow</param>
		/// <param name="projectID">projectID</param>
		public static void UpdateProjectYTOrder(int @iD, int @companyID, int @orderBy, string @name, bool @isShow, int @projectID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProjectYTOrder(@iD, @companyID, @orderBy, @name, @isShow, @projectID, helper);
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
		/// Updates a ProjectYTOrder into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="name">name</param>
		/// <param name="isShow">isShow</param>
		/// <param name="projectID">projectID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProjectYTOrder(int @iD, int @companyID, int @orderBy, string @name, bool @isShow, int @projectID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CompanyID] int,
	[OrderBy] int,
	[Name] nvarchar(100),
	[IsShow] bit,
	[ProjectID] int
);

UPDATE [dbo].[ProjectYTOrder] SET 
	[ProjectYTOrder].[CompanyID] = @CompanyID,
	[ProjectYTOrder].[OrderBy] = @OrderBy,
	[ProjectYTOrder].[Name] = @Name,
	[ProjectYTOrder].[IsShow] = @IsShow,
	[ProjectYTOrder].[ProjectID] = @ProjectID 
output 
	INSERTED.[ID],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[Name],
	INSERTED.[IsShow],
	INSERTED.[ProjectID]
into @table
WHERE 
	[ProjectYTOrder].[ID] = @ID

SELECT 
	[ID],
	[CompanyID],
	[OrderBy],
	[Name],
	[IsShow],
	[ProjectID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@IsShow", @isShow));
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ProjectYTOrder from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProjectYTOrder(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProjectYTOrder(@iD, helper);
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
		/// Deletes a ProjectYTOrder from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProjectYTOrder(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ProjectYTOrder]
WHERE 
	[ProjectYTOrder].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ProjectYTOrder object.
		/// </summary>
		/// <returns>The newly created ProjectYTOrder object.</returns>
		public static ProjectYTOrder CreateProjectYTOrder()
		{
			return InitializeNew<ProjectYTOrder>();
		}
		
		/// <summary>
		/// Retrieve information for a ProjectYTOrder by a ProjectYTOrder's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ProjectYTOrder</returns>
		public static ProjectYTOrder GetProjectYTOrder(int @iD)
		{
			string commandText = @"
SELECT 
" + ProjectYTOrder.SelectFieldList + @"
FROM [dbo].[ProjectYTOrder] 
WHERE 
	[ProjectYTOrder].[ID] = @ID " + ProjectYTOrder.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectYTOrder>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ProjectYTOrder by a ProjectYTOrder's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ProjectYTOrder</returns>
		public static ProjectYTOrder GetProjectYTOrder(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ProjectYTOrder.SelectFieldList + @"
FROM [dbo].[ProjectYTOrder] 
WHERE 
	[ProjectYTOrder].[ID] = @ID " + ProjectYTOrder.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectYTOrder>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ProjectYTOrder objects.
		/// </summary>
		/// <returns>The retrieved collection of ProjectYTOrder objects.</returns>
		public static EntityList<ProjectYTOrder> GetProjectYTOrders()
		{
			string commandText = @"
SELECT " + ProjectYTOrder.SelectFieldList + "FROM [dbo].[ProjectYTOrder] " + ProjectYTOrder.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ProjectYTOrder>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ProjectYTOrder objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectYTOrder objects.</returns>
        public static EntityList<ProjectYTOrder> GetProjectYTOrders(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectYTOrder>(SelectFieldList, "FROM [dbo].[ProjectYTOrder]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ProjectYTOrder objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectYTOrder objects.</returns>
        public static EntityList<ProjectYTOrder> GetProjectYTOrders(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectYTOrder>(SelectFieldList, "FROM [dbo].[ProjectYTOrder]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ProjectYTOrder objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ProjectYTOrder objects.</returns>
		protected static EntityList<ProjectYTOrder> GetProjectYTOrders(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectYTOrders(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ProjectYTOrder objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectYTOrder objects.</returns>
		protected static EntityList<ProjectYTOrder> GetProjectYTOrders(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectYTOrders(string.Empty, where, parameters, ProjectYTOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectYTOrder objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectYTOrder objects.</returns>
		protected static EntityList<ProjectYTOrder> GetProjectYTOrders(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectYTOrders(prefix, where, parameters, ProjectYTOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectYTOrder objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectYTOrder objects.</returns>
		protected static EntityList<ProjectYTOrder> GetProjectYTOrders(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectYTOrders(string.Empty, where, parameters, ProjectYTOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectYTOrder objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectYTOrder objects.</returns>
		protected static EntityList<ProjectYTOrder> GetProjectYTOrders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectYTOrders(prefix, where, parameters, ProjectYTOrder.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectYTOrder objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ProjectYTOrder objects.</returns>
		protected static EntityList<ProjectYTOrder> GetProjectYTOrders(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ProjectYTOrder.SelectFieldList + "FROM [dbo].[ProjectYTOrder] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ProjectYTOrder>(reader);
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
        protected static EntityList<ProjectYTOrder> GetProjectYTOrders(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectYTOrder>(SelectFieldList, "FROM [dbo].[ProjectYTOrder] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
		#endregion
		
		#region Subclasses
		public static partial class ProjectYTOrderProperties
		{
			public const string ID = "ID";
			public const string CompanyID = "CompanyID";
			public const string OrderBy = "OrderBy";
			public const string Name = "Name";
			public const string IsShow = "IsShow";
			public const string ProjectID = "ProjectID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CompanyID" , "int:"},
    			 {"OrderBy" , "int:"},
    			 {"Name" , "string:"},
    			 {"IsShow" , "bool:"},
    			 {"ProjectID" , "int:"},
            };
		}
		#endregion
	}
}
