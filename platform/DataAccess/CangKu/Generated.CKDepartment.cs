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
	/// This object represents the properties and methods of a CKDepartment.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKDepartment 
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
		private string _departmentName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string DepartmentName
		{
			[DebuggerStepThrough()]
			get { return this._departmentName; }
			set 
			{
				if (this._departmentName != value) 
				{
					this._departmentName = value;
					this.IsDirty = true;	
					OnPropertyChanged("DepartmentName");
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
		[DataObjectField(false, false, false)]
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
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
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
		[DataObjectField(false, false, true)]
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
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
	[DepartmentName] nvarchar(200),
	[Description] ntext,
	[AddTime] datetime,
	[SortOrder] int,
	[AddUserName] nvarchar(200),
	[ParentID] int,
	[CompanyID] int
);

INSERT INTO [dbo].[CKDepartment] (
	[CKDepartment].[DepartmentName],
	[CKDepartment].[Description],
	[CKDepartment].[AddTime],
	[CKDepartment].[SortOrder],
	[CKDepartment].[AddUserName],
	[CKDepartment].[ParentID],
	[CKDepartment].[CompanyID]
) 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentName],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[SortOrder],
	INSERTED.[AddUserName],
	INSERTED.[ParentID],
	INSERTED.[CompanyID]
into @table
VALUES ( 
	@DepartmentName,
	@Description,
	@AddTime,
	@SortOrder,
	@AddUserName,
	@ParentID,
	@CompanyID 
); 

SELECT 
	[ID],
	[DepartmentName],
	[Description],
	[AddTime],
	[SortOrder],
	[AddUserName],
	[ParentID],
	[CompanyID] 
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
	[DepartmentName] nvarchar(200),
	[Description] ntext,
	[AddTime] datetime,
	[SortOrder] int,
	[AddUserName] nvarchar(200),
	[ParentID] int,
	[CompanyID] int
);

UPDATE [dbo].[CKDepartment] SET 
	[CKDepartment].[DepartmentName] = @DepartmentName,
	[CKDepartment].[Description] = @Description,
	[CKDepartment].[AddTime] = @AddTime,
	[CKDepartment].[SortOrder] = @SortOrder,
	[CKDepartment].[AddUserName] = @AddUserName,
	[CKDepartment].[ParentID] = @ParentID,
	[CKDepartment].[CompanyID] = @CompanyID 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentName],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[SortOrder],
	INSERTED.[AddUserName],
	INSERTED.[ParentID],
	INSERTED.[CompanyID]
into @table
WHERE 
	[CKDepartment].[ID] = @ID

SELECT 
	[ID],
	[DepartmentName],
	[Description],
	[AddTime],
	[SortOrder],
	[AddUserName],
	[ParentID],
	[CompanyID] 
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
DELETE FROM [dbo].[CKDepartment]
WHERE 
	[CKDepartment].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKDepartment() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKDepartment(this.ID));
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
	[CKDepartment].[ID],
	[CKDepartment].[DepartmentName],
	[CKDepartment].[Description],
	[CKDepartment].[AddTime],
	[CKDepartment].[SortOrder],
	[CKDepartment].[AddUserName],
	[CKDepartment].[ParentID],
	[CKDepartment].[CompanyID]
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
                return "CKDepartment";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKDepartment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="departmentName">departmentName</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="parentID">parentID</param>
		/// <param name="companyID">companyID</param>
		public static void InsertCKDepartment(string @departmentName, string @description, DateTime @addTime, int @sortOrder, string @addUserName, int @parentID, int @companyID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKDepartment(@departmentName, @description, @addTime, @sortOrder, @addUserName, @parentID, @companyID, helper);
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
		/// Insert a CKDepartment into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="departmentName">departmentName</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="parentID">parentID</param>
		/// <param name="companyID">companyID</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKDepartment(string @departmentName, string @description, DateTime @addTime, int @sortOrder, string @addUserName, int @parentID, int @companyID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DepartmentName] nvarchar(200),
	[Description] ntext,
	[AddTime] datetime,
	[SortOrder] int,
	[AddUserName] nvarchar(200),
	[ParentID] int,
	[CompanyID] int
);

INSERT INTO [dbo].[CKDepartment] (
	[CKDepartment].[DepartmentName],
	[CKDepartment].[Description],
	[CKDepartment].[AddTime],
	[CKDepartment].[SortOrder],
	[CKDepartment].[AddUserName],
	[CKDepartment].[ParentID],
	[CKDepartment].[CompanyID]
) 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentName],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[SortOrder],
	INSERTED.[AddUserName],
	INSERTED.[ParentID],
	INSERTED.[CompanyID]
into @table
VALUES ( 
	@DepartmentName,
	@Description,
	@AddTime,
	@SortOrder,
	@AddUserName,
	@ParentID,
	@CompanyID 
); 

SELECT 
	[ID],
	[DepartmentName],
	[Description],
	[AddTime],
	[SortOrder],
	[AddUserName],
	[ParentID],
	[CompanyID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@DepartmentName", EntityBase.GetDatabaseValue(@departmentName)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKDepartment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="departmentName">departmentName</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="parentID">parentID</param>
		/// <param name="companyID">companyID</param>
		public static void UpdateCKDepartment(int @iD, string @departmentName, string @description, DateTime @addTime, int @sortOrder, string @addUserName, int @parentID, int @companyID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKDepartment(@iD, @departmentName, @description, @addTime, @sortOrder, @addUserName, @parentID, @companyID, helper);
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
		/// Updates a CKDepartment into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="departmentName">departmentName</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="parentID">parentID</param>
		/// <param name="companyID">companyID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKDepartment(int @iD, string @departmentName, string @description, DateTime @addTime, int @sortOrder, string @addUserName, int @parentID, int @companyID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[DepartmentName] nvarchar(200),
	[Description] ntext,
	[AddTime] datetime,
	[SortOrder] int,
	[AddUserName] nvarchar(200),
	[ParentID] int,
	[CompanyID] int
);

UPDATE [dbo].[CKDepartment] SET 
	[CKDepartment].[DepartmentName] = @DepartmentName,
	[CKDepartment].[Description] = @Description,
	[CKDepartment].[AddTime] = @AddTime,
	[CKDepartment].[SortOrder] = @SortOrder,
	[CKDepartment].[AddUserName] = @AddUserName,
	[CKDepartment].[ParentID] = @ParentID,
	[CKDepartment].[CompanyID] = @CompanyID 
output 
	INSERTED.[ID],
	INSERTED.[DepartmentName],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[SortOrder],
	INSERTED.[AddUserName],
	INSERTED.[ParentID],
	INSERTED.[CompanyID]
into @table
WHERE 
	[CKDepartment].[ID] = @ID

SELECT 
	[ID],
	[DepartmentName],
	[Description],
	[AddTime],
	[SortOrder],
	[AddUserName],
	[ParentID],
	[CompanyID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@DepartmentName", EntityBase.GetDatabaseValue(@departmentName)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKDepartment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKDepartment(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKDepartment(@iD, helper);
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
		/// Deletes a CKDepartment from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKDepartment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKDepartment]
WHERE 
	[CKDepartment].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKDepartment object.
		/// </summary>
		/// <returns>The newly created CKDepartment object.</returns>
		public static CKDepartment CreateCKDepartment()
		{
			return InitializeNew<CKDepartment>();
		}
		
		/// <summary>
		/// Retrieve information for a CKDepartment by a CKDepartment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKDepartment</returns>
		public static CKDepartment GetCKDepartment(int @iD)
		{
			string commandText = @"
SELECT 
" + CKDepartment.SelectFieldList + @"
FROM [dbo].[CKDepartment] 
WHERE 
	[CKDepartment].[ID] = @ID " + CKDepartment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKDepartment>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKDepartment by a CKDepartment's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKDepartment</returns>
		public static CKDepartment GetCKDepartment(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKDepartment.SelectFieldList + @"
FROM [dbo].[CKDepartment] 
WHERE 
	[CKDepartment].[ID] = @ID " + CKDepartment.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKDepartment>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKDepartment objects.
		/// </summary>
		/// <returns>The retrieved collection of CKDepartment objects.</returns>
		public static EntityList<CKDepartment> GetCKDepartments()
		{
			string commandText = @"
SELECT " + CKDepartment.SelectFieldList + "FROM [dbo].[CKDepartment] " + CKDepartment.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKDepartment>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKDepartment objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKDepartment objects.</returns>
        public static EntityList<CKDepartment> GetCKDepartments(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKDepartment>(SelectFieldList, "FROM [dbo].[CKDepartment]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKDepartment objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKDepartment objects.</returns>
        public static EntityList<CKDepartment> GetCKDepartments(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKDepartment>(SelectFieldList, "FROM [dbo].[CKDepartment]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKDepartment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKDepartment objects.</returns>
		protected static EntityList<CKDepartment> GetCKDepartments(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKDepartments(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKDepartment objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKDepartment objects.</returns>
		protected static EntityList<CKDepartment> GetCKDepartments(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKDepartments(string.Empty, where, parameters, CKDepartment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKDepartment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKDepartment objects.</returns>
		protected static EntityList<CKDepartment> GetCKDepartments(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKDepartments(prefix, where, parameters, CKDepartment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKDepartment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKDepartment objects.</returns>
		protected static EntityList<CKDepartment> GetCKDepartments(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKDepartments(string.Empty, where, parameters, CKDepartment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKDepartment objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKDepartment objects.</returns>
		protected static EntityList<CKDepartment> GetCKDepartments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKDepartments(prefix, where, parameters, CKDepartment.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKDepartment objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKDepartment objects.</returns>
		protected static EntityList<CKDepartment> GetCKDepartments(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKDepartment.SelectFieldList + "FROM [dbo].[CKDepartment] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKDepartment>(reader);
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
        protected static EntityList<CKDepartment> GetCKDepartments(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKDepartment>(SelectFieldList, "FROM [dbo].[CKDepartment] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKDepartment objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKDepartmentCount()
        {
            return GetCKDepartmentCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKDepartment objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKDepartmentCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKDepartment] " + where;

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
		public static partial class CKDepartment_Properties
		{
			public const string ID = "ID";
			public const string DepartmentName = "DepartmentName";
			public const string Description = "Description";
			public const string AddTime = "AddTime";
			public const string SortOrder = "SortOrder";
			public const string AddUserName = "AddUserName";
			public const string ParentID = "ParentID";
			public const string CompanyID = "CompanyID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"DepartmentName" , "string:"},
    			 {"Description" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"SortOrder" , "int:"},
    			 {"AddUserName" , "string:"},
    			 {"ParentID" , "int:"},
    			 {"CompanyID" , "int:"},
            };
		}
		#endregion
	}
}
