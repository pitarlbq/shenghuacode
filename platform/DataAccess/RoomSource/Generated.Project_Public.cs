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
	/// This object represents the properties and methods of a Project_Public.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Project_Public 
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
		private int _parentProjectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParentProjectID
		{
			[DebuggerStepThrough()]
			get { return this._parentProjectID; }
			set 
			{
				if (this._parentProjectID != value) 
				{
					this._parentProjectID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentProjectID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _parentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParentID
		{
			[DebuggerStepThrough()]
			get { return this._parentID; }
			set 
			{
				if (this._parentID != value) 
				{
					this._parentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentID");
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
		private string _description = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Description
		{
			[DebuggerStepThrough()]
			get { return this._description; }
			set 
			{
				if (this._description != value) 
				{
					this._description = value;
					this.IsDirty = true;	
					OnPropertyChanged("Description");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _addTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AddTime
		{
			[DebuggerStepThrough()]
			get { return this._addTime; }
			set 
			{
				if (this._addTime != value) 
				{
					this._addTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddMan
		{
			[DebuggerStepThrough()]
			get { return this._addMan; }
			set 
			{
				if (this._addMan != value) 
				{
					this._addMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _allParentID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AllParentID
		{
			[DebuggerStepThrough()]
			get { return this._allParentID; }
			set 
			{
				if (this._allParentID != value) 
				{
					this._allParentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AllParentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FullName
		{
			[DebuggerStepThrough()]
			get { return this._fullName; }
			set 
			{
				if (this._fullName != value) 
				{
					this._fullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FullName");
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
	[ParentProjectID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[AllParentID] nvarchar(500),
	[FullName] nvarchar(500)
);

INSERT INTO [dbo].[Project_Public] (
	[Project_Public].[ParentProjectID],
	[Project_Public].[ParentID],
	[Project_Public].[Name],
	[Project_Public].[Description],
	[Project_Public].[AddTime],
	[Project_Public].[AddMan],
	[Project_Public].[AllParentID],
	[Project_Public].[FullName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ParentProjectID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[AllParentID],
	INSERTED.[FullName]
into @table
VALUES ( 
	@ParentProjectID,
	@ParentID,
	@Name,
	@Description,
	@AddTime,
	@AddMan,
	@AllParentID,
	@FullName 
); 

SELECT 
	[ID],
	[ParentProjectID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[AllParentID],
	[FullName] 
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
	[ParentProjectID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[AllParentID] nvarchar(500),
	[FullName] nvarchar(500)
);

UPDATE [dbo].[Project_Public] SET 
	[Project_Public].[ParentProjectID] = @ParentProjectID,
	[Project_Public].[ParentID] = @ParentID,
	[Project_Public].[Name] = @Name,
	[Project_Public].[Description] = @Description,
	[Project_Public].[AddTime] = @AddTime,
	[Project_Public].[AddMan] = @AddMan,
	[Project_Public].[AllParentID] = @AllParentID,
	[Project_Public].[FullName] = @FullName 
output 
	INSERTED.[ID],
	INSERTED.[ParentProjectID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[AllParentID],
	INSERTED.[FullName]
into @table
WHERE 
	[Project_Public].[ID] = @ID

SELECT 
	[ID],
	[ParentProjectID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[AllParentID],
	[FullName] 
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
DELETE FROM [dbo].[Project_Public]
WHERE 
	[Project_Public].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Project_Public() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProject_Public(this.ID));
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
	[Project_Public].[ID],
	[Project_Public].[ParentProjectID],
	[Project_Public].[ParentID],
	[Project_Public].[Name],
	[Project_Public].[Description],
	[Project_Public].[AddTime],
	[Project_Public].[AddMan],
	[Project_Public].[AllParentID],
	[Project_Public].[FullName]
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
                return "Project_Public";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Project_Public into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="parentProjectID">parentProjectID</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="fullName">fullName</param>
		public static void InsertProject_Public(int @parentProjectID, int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @allParentID, string @fullName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProject_Public(@parentProjectID, @parentID, @name, @description, @addTime, @addMan, @allParentID, @fullName, helper);
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
		/// Insert a Project_Public into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="parentProjectID">parentProjectID</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="fullName">fullName</param>
		/// <param name="helper">helper</param>
		internal static void InsertProject_Public(int @parentProjectID, int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @allParentID, string @fullName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ParentProjectID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[AllParentID] nvarchar(500),
	[FullName] nvarchar(500)
);

INSERT INTO [dbo].[Project_Public] (
	[Project_Public].[ParentProjectID],
	[Project_Public].[ParentID],
	[Project_Public].[Name],
	[Project_Public].[Description],
	[Project_Public].[AddTime],
	[Project_Public].[AddMan],
	[Project_Public].[AllParentID],
	[Project_Public].[FullName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ParentProjectID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[AllParentID],
	INSERTED.[FullName]
into @table
VALUES ( 
	@ParentProjectID,
	@ParentID,
	@Name,
	@Description,
	@AddTime,
	@AddMan,
	@AllParentID,
	@FullName 
); 

SELECT 
	[ID],
	[ParentProjectID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[AllParentID],
	[FullName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ParentProjectID", EntityBase.GetDatabaseValue(@parentProjectID)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AllParentID", EntityBase.GetDatabaseValue(@allParentID)));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Project_Public into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentProjectID">parentProjectID</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="fullName">fullName</param>
		public static void UpdateProject_Public(int @iD, int @parentProjectID, int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @allParentID, string @fullName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProject_Public(@iD, @parentProjectID, @parentID, @name, @description, @addTime, @addMan, @allParentID, @fullName, helper);
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
		/// Updates a Project_Public into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentProjectID">parentProjectID</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="fullName">fullName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProject_Public(int @iD, int @parentProjectID, int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @allParentID, string @fullName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ParentProjectID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[AllParentID] nvarchar(500),
	[FullName] nvarchar(500)
);

UPDATE [dbo].[Project_Public] SET 
	[Project_Public].[ParentProjectID] = @ParentProjectID,
	[Project_Public].[ParentID] = @ParentID,
	[Project_Public].[Name] = @Name,
	[Project_Public].[Description] = @Description,
	[Project_Public].[AddTime] = @AddTime,
	[Project_Public].[AddMan] = @AddMan,
	[Project_Public].[AllParentID] = @AllParentID,
	[Project_Public].[FullName] = @FullName 
output 
	INSERTED.[ID],
	INSERTED.[ParentProjectID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[AllParentID],
	INSERTED.[FullName]
into @table
WHERE 
	[Project_Public].[ID] = @ID

SELECT 
	[ID],
	[ParentProjectID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[AllParentID],
	[FullName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ParentProjectID", EntityBase.GetDatabaseValue(@parentProjectID)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@AllParentID", EntityBase.GetDatabaseValue(@allParentID)));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Project_Public from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProject_Public(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProject_Public(@iD, helper);
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
		/// Deletes a Project_Public from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProject_Public(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Project_Public]
WHERE 
	[Project_Public].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Project_Public object.
		/// </summary>
		/// <returns>The newly created Project_Public object.</returns>
		public static Project_Public CreateProject_Public()
		{
			return InitializeNew<Project_Public>();
		}
		
		/// <summary>
		/// Retrieve information for a Project_Public by a Project_Public's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Project_Public</returns>
		public static Project_Public GetProject_Public(int @iD)
		{
			string commandText = @"
SELECT 
" + Project_Public.SelectFieldList + @"
FROM [dbo].[Project_Public] 
WHERE 
	[Project_Public].[ID] = @ID " + Project_Public.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project_Public>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Project_Public by a Project_Public's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Project_Public</returns>
		public static Project_Public GetProject_Public(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Project_Public.SelectFieldList + @"
FROM [dbo].[Project_Public] 
WHERE 
	[Project_Public].[ID] = @ID " + Project_Public.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project_Public>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Project_Public objects.
		/// </summary>
		/// <returns>The retrieved collection of Project_Public objects.</returns>
		public static EntityList<Project_Public> GetProject_Publics()
		{
			string commandText = @"
SELECT " + Project_Public.SelectFieldList + "FROM [dbo].[Project_Public] " + Project_Public.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Project_Public>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Project_Public objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project_Public objects.</returns>
        public static EntityList<Project_Public> GetProject_Publics(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_Public>(SelectFieldList, "FROM [dbo].[Project_Public]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Project_Public objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project_Public objects.</returns>
        public static EntityList<Project_Public> GetProject_Publics(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_Public>(SelectFieldList, "FROM [dbo].[Project_Public]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Project_Public objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Project_Public objects.</returns>
		protected static EntityList<Project_Public> GetProject_Publics(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_Publics(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Project_Public objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project_Public objects.</returns>
		protected static EntityList<Project_Public> GetProject_Publics(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_Publics(string.Empty, where, parameters, Project_Public.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Public objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project_Public objects.</returns>
		protected static EntityList<Project_Public> GetProject_Publics(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProject_Publics(prefix, where, parameters, Project_Public.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Public objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project_Public objects.</returns>
		protected static EntityList<Project_Public> GetProject_Publics(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProject_Publics(string.Empty, where, parameters, Project_Public.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Public objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project_Public objects.</returns>
		protected static EntityList<Project_Public> GetProject_Publics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProject_Publics(prefix, where, parameters, Project_Public.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project_Public objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Project_Public objects.</returns>
		protected static EntityList<Project_Public> GetProject_Publics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Project_Public.SelectFieldList + "FROM [dbo].[Project_Public] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Project_Public>(reader);
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
        protected static EntityList<Project_Public> GetProject_Publics(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project_Public>(SelectFieldList, "FROM [dbo].[Project_Public] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Project_Public objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProject_PublicCount()
        {
            return GetProject_PublicCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Project_Public objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProject_PublicCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Project_Public] " + where;

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
		public static partial class Project_Public_Properties
		{
			public const string ID = "ID";
			public const string ParentProjectID = "ParentProjectID";
			public const string ParentID = "ParentID";
			public const string Name = "Name";
			public const string Description = "Description";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string AllParentID = "AllParentID";
			public const string FullName = "FullName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ParentProjectID" , "int:"},
    			 {"ParentID" , "int:"},
    			 {"Name" , "string:"},
    			 {"Description" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"AllParentID" , "string:"},
    			 {"FullName" , "string:"},
            };
		}
		#endregion
	}
}
