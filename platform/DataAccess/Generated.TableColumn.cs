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
	/// This object represents the properties and methods of a TableColumn.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class TableColumn 
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
		private string _pageCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PageCode
		{
			[DebuggerStepThrough()]
			get { return this._pageCode; }
			set 
			{
				if (this._pageCode != value) 
				{
					this._pageCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("PageCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _columnField = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ColumnField
		{
			[DebuggerStepThrough()]
			get { return this._columnField; }
			set 
			{
				if (this._columnField != value) 
				{
					this._columnField = value;
					this.IsDirty = true;	
					OnPropertyChanged("ColumnField");
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
		private bool _isShown = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsShown
		{
			[DebuggerStepThrough()]
			get { return this._isShown; }
			set 
			{
				if (this._isShown != value) 
				{
					this._isShown = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsShown");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _columnName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ColumnName
		{
			[DebuggerStepThrough()]
			get { return this._columnName; }
			set 
			{
				if (this._columnName != value) 
				{
					this._columnName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ColumnName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDeleted = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDeleted
		{
			[DebuggerStepThrough()]
			get { return this._isDeleted; }
			set 
			{
				if (this._isDeleted != value) 
				{
					this._isDeleted = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDeleted");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _groupName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GroupName
		{
			[DebuggerStepThrough()]
			get { return this._groupName; }
			set 
			{
				if (this._groupName != value) 
				{
					this._groupName = value;
					this.IsDirty = true;	
					OnPropertyChanged("GroupName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isNecessary = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsNecessary
		{
			[DebuggerStepThrough()]
			get { return this._isNecessary; }
			set 
			{
				if (this._isNecessary != value) 
				{
					this._isNecessary = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsNecessary");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAnalysis = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAnalysis
		{
			[DebuggerStepThrough()]
			get { return this._isAnalysis; }
			set 
			{
				if (this._isAnalysis != value) 
				{
					this._isAnalysis = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAnalysis");
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
	[PageCode] nvarchar(500),
	[ColumnField] nvarchar(1000),
	[SortOrder] int,
	[IsShown] bit,
	[ColumnName] nvarchar(200),
	[IsDeleted] bit,
	[GroupName] nvarchar(200),
	[IsNecessary] bit,
	[IsAnalysis] bit
);

INSERT INTO [dbo].[TableColumns] (
	[TableColumns].[ID],
	[TableColumns].[PageCode],
	[TableColumns].[ColumnField],
	[TableColumns].[SortOrder],
	[TableColumns].[IsShown],
	[TableColumns].[ColumnName],
	[TableColumns].[IsDeleted],
	[TableColumns].[GroupName],
	[TableColumns].[IsNecessary],
	[TableColumns].[IsAnalysis]
) 
output 
	INSERTED.[ID],
	INSERTED.[PageCode],
	INSERTED.[ColumnField],
	INSERTED.[SortOrder],
	INSERTED.[IsShown],
	INSERTED.[ColumnName],
	INSERTED.[IsDeleted],
	INSERTED.[GroupName],
	INSERTED.[IsNecessary],
	INSERTED.[IsAnalysis]
into @table
VALUES ( 
	@ID,
	@PageCode,
	@ColumnField,
	@SortOrder,
	@IsShown,
	@ColumnName,
	@IsDeleted,
	@GroupName,
	@IsNecessary,
	@IsAnalysis 
); 

SELECT 
	[ID],
	[PageCode],
	[ColumnField],
	[SortOrder],
	[IsShown],
	[ColumnName],
	[IsDeleted],
	[GroupName],
	[IsNecessary],
	[IsAnalysis] 
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
	[PageCode] nvarchar(500),
	[ColumnField] nvarchar(1000),
	[SortOrder] int,
	[IsShown] bit,
	[ColumnName] nvarchar(200),
	[IsDeleted] bit,
	[GroupName] nvarchar(200),
	[IsNecessary] bit,
	[IsAnalysis] bit
);

UPDATE [dbo].[TableColumns] SET 
	[TableColumns].[PageCode] = @PageCode,
	[TableColumns].[ColumnField] = @ColumnField,
	[TableColumns].[SortOrder] = @SortOrder,
	[TableColumns].[IsShown] = @IsShown,
	[TableColumns].[ColumnName] = @ColumnName,
	[TableColumns].[IsDeleted] = @IsDeleted,
	[TableColumns].[GroupName] = @GroupName,
	[TableColumns].[IsNecessary] = @IsNecessary,
	[TableColumns].[IsAnalysis] = @IsAnalysis 
output 
	INSERTED.[ID],
	INSERTED.[PageCode],
	INSERTED.[ColumnField],
	INSERTED.[SortOrder],
	INSERTED.[IsShown],
	INSERTED.[ColumnName],
	INSERTED.[IsDeleted],
	INSERTED.[GroupName],
	INSERTED.[IsNecessary],
	INSERTED.[IsAnalysis]
into @table
WHERE 
	[TableColumns].[ID] = @ID

SELECT 
	[ID],
	[PageCode],
	[ColumnField],
	[SortOrder],
	[IsShown],
	[ColumnName],
	[IsDeleted],
	[GroupName],
	[IsNecessary],
	[IsAnalysis] 
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
DELETE FROM [dbo].[TableColumns]
WHERE 
	[TableColumns].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public TableColumn() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetTableColumn(this.ID));
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
	[TableColumns].[ID],
	[TableColumns].[PageCode],
	[TableColumns].[ColumnField],
	[TableColumns].[SortOrder],
	[TableColumns].[IsShown],
	[TableColumns].[ColumnName],
	[TableColumns].[IsDeleted],
	[TableColumns].[GroupName],
	[TableColumns].[IsNecessary],
	[TableColumns].[IsAnalysis]
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
                return "TableColumns";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a TableColumn into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pageCode">pageCode</param>
		/// <param name="columnField">columnField</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShown">isShown</param>
		/// <param name="columnName">columnName</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="groupName">groupName</param>
		/// <param name="isNecessary">isNecessary</param>
		/// <param name="isAnalysis">isAnalysis</param>
		public static void InsertTableColumn(int @iD, string @pageCode, string @columnField, int @sortOrder, bool @isShown, string @columnName, bool @isDeleted, string @groupName, bool @isNecessary, bool @isAnalysis)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertTableColumn(@iD, @pageCode, @columnField, @sortOrder, @isShown, @columnName, @isDeleted, @groupName, @isNecessary, @isAnalysis, helper);
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
		/// Insert a TableColumn into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pageCode">pageCode</param>
		/// <param name="columnField">columnField</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShown">isShown</param>
		/// <param name="columnName">columnName</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="groupName">groupName</param>
		/// <param name="isNecessary">isNecessary</param>
		/// <param name="isAnalysis">isAnalysis</param>
		/// <param name="helper">helper</param>
		internal static void InsertTableColumn(int @iD, string @pageCode, string @columnField, int @sortOrder, bool @isShown, string @columnName, bool @isDeleted, string @groupName, bool @isNecessary, bool @isAnalysis, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PageCode] nvarchar(500),
	[ColumnField] nvarchar(1000),
	[SortOrder] int,
	[IsShown] bit,
	[ColumnName] nvarchar(200),
	[IsDeleted] bit,
	[GroupName] nvarchar(200),
	[IsNecessary] bit,
	[IsAnalysis] bit
);

INSERT INTO [dbo].[TableColumns] (
	[TableColumns].[ID],
	[TableColumns].[PageCode],
	[TableColumns].[ColumnField],
	[TableColumns].[SortOrder],
	[TableColumns].[IsShown],
	[TableColumns].[ColumnName],
	[TableColumns].[IsDeleted],
	[TableColumns].[GroupName],
	[TableColumns].[IsNecessary],
	[TableColumns].[IsAnalysis]
) 
output 
	INSERTED.[ID],
	INSERTED.[PageCode],
	INSERTED.[ColumnField],
	INSERTED.[SortOrder],
	INSERTED.[IsShown],
	INSERTED.[ColumnName],
	INSERTED.[IsDeleted],
	INSERTED.[GroupName],
	INSERTED.[IsNecessary],
	INSERTED.[IsAnalysis]
into @table
VALUES ( 
	@ID,
	@PageCode,
	@ColumnField,
	@SortOrder,
	@IsShown,
	@ColumnName,
	@IsDeleted,
	@GroupName,
	@IsNecessary,
	@IsAnalysis 
); 

SELECT 
	[ID],
	[PageCode],
	[ColumnField],
	[SortOrder],
	[IsShown],
	[ColumnName],
	[IsDeleted],
	[GroupName],
	[IsNecessary],
	[IsAnalysis] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PageCode", EntityBase.GetDatabaseValue(@pageCode)));
			parameters.Add(new SqlParameter("@ColumnField", EntityBase.GetDatabaseValue(@columnField)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsShown", @isShown));
			parameters.Add(new SqlParameter("@ColumnName", EntityBase.GetDatabaseValue(@columnName)));
			parameters.Add(new SqlParameter("@IsDeleted", @isDeleted));
			parameters.Add(new SqlParameter("@GroupName", EntityBase.GetDatabaseValue(@groupName)));
			parameters.Add(new SqlParameter("@IsNecessary", @isNecessary));
			parameters.Add(new SqlParameter("@IsAnalysis", @isAnalysis));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a TableColumn into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pageCode">pageCode</param>
		/// <param name="columnField">columnField</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShown">isShown</param>
		/// <param name="columnName">columnName</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="groupName">groupName</param>
		/// <param name="isNecessary">isNecessary</param>
		/// <param name="isAnalysis">isAnalysis</param>
		public static void UpdateTableColumn(int @iD, string @pageCode, string @columnField, int @sortOrder, bool @isShown, string @columnName, bool @isDeleted, string @groupName, bool @isNecessary, bool @isAnalysis)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateTableColumn(@iD, @pageCode, @columnField, @sortOrder, @isShown, @columnName, @isDeleted, @groupName, @isNecessary, @isAnalysis, helper);
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
		/// Updates a TableColumn into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="pageCode">pageCode</param>
		/// <param name="columnField">columnField</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="isShown">isShown</param>
		/// <param name="columnName">columnName</param>
		/// <param name="isDeleted">isDeleted</param>
		/// <param name="groupName">groupName</param>
		/// <param name="isNecessary">isNecessary</param>
		/// <param name="isAnalysis">isAnalysis</param>
		/// <param name="helper">helper</param>
		internal static void UpdateTableColumn(int @iD, string @pageCode, string @columnField, int @sortOrder, bool @isShown, string @columnName, bool @isDeleted, string @groupName, bool @isNecessary, bool @isAnalysis, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[PageCode] nvarchar(500),
	[ColumnField] nvarchar(1000),
	[SortOrder] int,
	[IsShown] bit,
	[ColumnName] nvarchar(200),
	[IsDeleted] bit,
	[GroupName] nvarchar(200),
	[IsNecessary] bit,
	[IsAnalysis] bit
);

UPDATE [dbo].[TableColumns] SET 
	[TableColumns].[PageCode] = @PageCode,
	[TableColumns].[ColumnField] = @ColumnField,
	[TableColumns].[SortOrder] = @SortOrder,
	[TableColumns].[IsShown] = @IsShown,
	[TableColumns].[ColumnName] = @ColumnName,
	[TableColumns].[IsDeleted] = @IsDeleted,
	[TableColumns].[GroupName] = @GroupName,
	[TableColumns].[IsNecessary] = @IsNecessary,
	[TableColumns].[IsAnalysis] = @IsAnalysis 
output 
	INSERTED.[ID],
	INSERTED.[PageCode],
	INSERTED.[ColumnField],
	INSERTED.[SortOrder],
	INSERTED.[IsShown],
	INSERTED.[ColumnName],
	INSERTED.[IsDeleted],
	INSERTED.[GroupName],
	INSERTED.[IsNecessary],
	INSERTED.[IsAnalysis]
into @table
WHERE 
	[TableColumns].[ID] = @ID

SELECT 
	[ID],
	[PageCode],
	[ColumnField],
	[SortOrder],
	[IsShown],
	[ColumnName],
	[IsDeleted],
	[GroupName],
	[IsNecessary],
	[IsAnalysis] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@PageCode", EntityBase.GetDatabaseValue(@pageCode)));
			parameters.Add(new SqlParameter("@ColumnField", EntityBase.GetDatabaseValue(@columnField)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@IsShown", @isShown));
			parameters.Add(new SqlParameter("@ColumnName", EntityBase.GetDatabaseValue(@columnName)));
			parameters.Add(new SqlParameter("@IsDeleted", @isDeleted));
			parameters.Add(new SqlParameter("@GroupName", EntityBase.GetDatabaseValue(@groupName)));
			parameters.Add(new SqlParameter("@IsNecessary", @isNecessary));
			parameters.Add(new SqlParameter("@IsAnalysis", @isAnalysis));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a TableColumn from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteTableColumn(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteTableColumn(@iD, helper);
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
		/// Deletes a TableColumn from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteTableColumn(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[TableColumns]
WHERE 
	[TableColumns].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new TableColumn object.
		/// </summary>
		/// <returns>The newly created TableColumn object.</returns>
		public static TableColumn CreateTableColumn()
		{
			return InitializeNew<TableColumn>();
		}
		
		/// <summary>
		/// Retrieve information for a TableColumn by a TableColumn's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>TableColumn</returns>
		public static TableColumn GetTableColumn(int @iD)
		{
			string commandText = @"
SELECT 
" + TableColumn.SelectFieldList + @"
FROM [dbo].[TableColumns] 
WHERE 
	[TableColumns].[ID] = @ID " + TableColumn.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<TableColumn>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a TableColumn by a TableColumn's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>TableColumn</returns>
		public static TableColumn GetTableColumn(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + TableColumn.SelectFieldList + @"
FROM [dbo].[TableColumns] 
WHERE 
	[TableColumns].[ID] = @ID " + TableColumn.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<TableColumn>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection TableColumn objects.
		/// </summary>
		/// <returns>The retrieved collection of TableColumn objects.</returns>
		public static EntityList<TableColumn> GetTableColumns()
		{
			string commandText = @"
SELECT " + TableColumn.SelectFieldList + "FROM [dbo].[TableColumns] " + TableColumn.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<TableColumn>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection TableColumn objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of TableColumn objects.</returns>
        public static EntityList<TableColumn> GetTableColumns(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TableColumn>(SelectFieldList, "FROM [dbo].[TableColumns]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection TableColumn objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of TableColumn objects.</returns>
        public static EntityList<TableColumn> GetTableColumns(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TableColumn>(SelectFieldList, "FROM [dbo].[TableColumns]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection TableColumn objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of TableColumn objects.</returns>
		protected static EntityList<TableColumn> GetTableColumns(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTableColumns(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection TableColumn objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of TableColumn objects.</returns>
		protected static EntityList<TableColumn> GetTableColumns(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTableColumns(string.Empty, where, parameters, TableColumn.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TableColumn objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of TableColumn objects.</returns>
		protected static EntityList<TableColumn> GetTableColumns(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetTableColumns(prefix, where, parameters, TableColumn.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TableColumn objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of TableColumn objects.</returns>
		protected static EntityList<TableColumn> GetTableColumns(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTableColumns(string.Empty, where, parameters, TableColumn.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TableColumn objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of TableColumn objects.</returns>
		protected static EntityList<TableColumn> GetTableColumns(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetTableColumns(prefix, where, parameters, TableColumn.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection TableColumn objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of TableColumn objects.</returns>
		protected static EntityList<TableColumn> GetTableColumns(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + TableColumn.SelectFieldList + "FROM [dbo].[TableColumns] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<TableColumn>(reader);
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
        protected static EntityList<TableColumn> GetTableColumns(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<TableColumn>(SelectFieldList, "FROM [dbo].[TableColumns] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of TableColumn objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetTableColumnCount()
        {
            return GetTableColumnCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of TableColumn objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetTableColumnCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[TableColumns] " + where;

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
		public static partial class TableColumn_Properties
		{
			public const string ID = "ID";
			public const string PageCode = "PageCode";
			public const string ColumnField = "ColumnField";
			public const string SortOrder = "SortOrder";
			public const string IsShown = "IsShown";
			public const string ColumnName = "ColumnName";
			public const string IsDeleted = "IsDeleted";
			public const string GroupName = "GroupName";
			public const string IsNecessary = "IsNecessary";
			public const string IsAnalysis = "IsAnalysis";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"PageCode" , "string:"},
    			 {"ColumnField" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"IsShown" , "bool:"},
    			 {"ColumnName" , "string:"},
    			 {"IsDeleted" , "bool:"},
    			 {"GroupName" , "string:"},
    			 {"IsNecessary" , "bool:"},
    			 {"IsAnalysis" , "bool:"},
            };
		}
		#endregion
	}
}
