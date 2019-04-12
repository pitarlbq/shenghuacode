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
	/// This object represents the properties and methods of a DefineField.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class DefineField 
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
		private string _fieldName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FieldName
		{
			[DebuggerStepThrough()]
			get { return this._fieldName; }
			set 
			{
				if (this._fieldName != value) 
				{
					this._fieldName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FieldName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _table_Name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Table_Name
		{
			[DebuggerStepThrough()]
			get { return this._table_Name; }
			set 
			{
				if (this._table_Name != value) 
				{
					this._table_Name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Table_Name");
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
		private string _oriFieldName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OriFieldName
		{
			[DebuggerStepThrough()]
			get { return this._oriFieldName; }
			set 
			{
				if (this._oriFieldName != value) 
				{
					this._oriFieldName = value;
					this.IsDirty = true;	
					OnPropertyChanged("OriFieldName");
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
	[FieldName] nvarchar(500),
	[Table_Name] nvarchar(500),
	[AddTime] datetime,
	[IsShown] bit,
	[SortOrder] int,
	[ColumnName] nvarchar(500),
	[OriFieldName] nvarchar(500)
);

INSERT INTO [dbo].[DefineField] (
	[DefineField].[FieldName],
	[DefineField].[Table_Name],
	[DefineField].[AddTime],
	[DefineField].[IsShown],
	[DefineField].[SortOrder],
	[DefineField].[ColumnName],
	[DefineField].[OriFieldName]
) 
output 
	INSERTED.[ID],
	INSERTED.[FieldName],
	INSERTED.[Table_Name],
	INSERTED.[AddTime],
	INSERTED.[IsShown],
	INSERTED.[SortOrder],
	INSERTED.[ColumnName],
	INSERTED.[OriFieldName]
into @table
VALUES ( 
	@FieldName,
	@Table_Name,
	@AddTime,
	@IsShown,
	@SortOrder,
	@ColumnName,
	@OriFieldName 
); 

SELECT 
	[ID],
	[FieldName],
	[Table_Name],
	[AddTime],
	[IsShown],
	[SortOrder],
	[ColumnName],
	[OriFieldName] 
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
	[FieldName] nvarchar(500),
	[Table_Name] nvarchar(500),
	[AddTime] datetime,
	[IsShown] bit,
	[SortOrder] int,
	[ColumnName] nvarchar(500),
	[OriFieldName] nvarchar(500)
);

UPDATE [dbo].[DefineField] SET 
	[DefineField].[FieldName] = @FieldName,
	[DefineField].[Table_Name] = @Table_Name,
	[DefineField].[AddTime] = @AddTime,
	[DefineField].[IsShown] = @IsShown,
	[DefineField].[SortOrder] = @SortOrder,
	[DefineField].[ColumnName] = @ColumnName,
	[DefineField].[OriFieldName] = @OriFieldName 
output 
	INSERTED.[ID],
	INSERTED.[FieldName],
	INSERTED.[Table_Name],
	INSERTED.[AddTime],
	INSERTED.[IsShown],
	INSERTED.[SortOrder],
	INSERTED.[ColumnName],
	INSERTED.[OriFieldName]
into @table
WHERE 
	[DefineField].[ID] = @ID

SELECT 
	[ID],
	[FieldName],
	[Table_Name],
	[AddTime],
	[IsShown],
	[SortOrder],
	[ColumnName],
	[OriFieldName] 
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
DELETE FROM [dbo].[DefineField]
WHERE 
	[DefineField].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public DefineField() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetDefineField(this.ID));
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
	[DefineField].[ID],
	[DefineField].[FieldName],
	[DefineField].[Table_Name],
	[DefineField].[AddTime],
	[DefineField].[IsShown],
	[DefineField].[SortOrder],
	[DefineField].[ColumnName],
	[DefineField].[OriFieldName]
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
                return "DefineField";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a DefineField into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="fieldName">fieldName</param>
		/// <param name="table_Name">table_Name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isShown">isShown</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="columnName">columnName</param>
		/// <param name="oriFieldName">oriFieldName</param>
		public static void InsertDefineField(string @fieldName, string @table_Name, DateTime @addTime, bool @isShown, int @sortOrder, string @columnName, string @oriFieldName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertDefineField(@fieldName, @table_Name, @addTime, @isShown, @sortOrder, @columnName, @oriFieldName, helper);
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
		/// Insert a DefineField into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="fieldName">fieldName</param>
		/// <param name="table_Name">table_Name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isShown">isShown</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="columnName">columnName</param>
		/// <param name="oriFieldName">oriFieldName</param>
		/// <param name="helper">helper</param>
		internal static void InsertDefineField(string @fieldName, string @table_Name, DateTime @addTime, bool @isShown, int @sortOrder, string @columnName, string @oriFieldName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[FieldName] nvarchar(500),
	[Table_Name] nvarchar(500),
	[AddTime] datetime,
	[IsShown] bit,
	[SortOrder] int,
	[ColumnName] nvarchar(500),
	[OriFieldName] nvarchar(500)
);

INSERT INTO [dbo].[DefineField] (
	[DefineField].[FieldName],
	[DefineField].[Table_Name],
	[DefineField].[AddTime],
	[DefineField].[IsShown],
	[DefineField].[SortOrder],
	[DefineField].[ColumnName],
	[DefineField].[OriFieldName]
) 
output 
	INSERTED.[ID],
	INSERTED.[FieldName],
	INSERTED.[Table_Name],
	INSERTED.[AddTime],
	INSERTED.[IsShown],
	INSERTED.[SortOrder],
	INSERTED.[ColumnName],
	INSERTED.[OriFieldName]
into @table
VALUES ( 
	@FieldName,
	@Table_Name,
	@AddTime,
	@IsShown,
	@SortOrder,
	@ColumnName,
	@OriFieldName 
); 

SELECT 
	[ID],
	[FieldName],
	[Table_Name],
	[AddTime],
	[IsShown],
	[SortOrder],
	[ColumnName],
	[OriFieldName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@FieldName", EntityBase.GetDatabaseValue(@fieldName)));
			parameters.Add(new SqlParameter("@Table_Name", EntityBase.GetDatabaseValue(@table_Name)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsShown", @isShown));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ColumnName", EntityBase.GetDatabaseValue(@columnName)));
			parameters.Add(new SqlParameter("@OriFieldName", EntityBase.GetDatabaseValue(@oriFieldName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a DefineField into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="fieldName">fieldName</param>
		/// <param name="table_Name">table_Name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isShown">isShown</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="columnName">columnName</param>
		/// <param name="oriFieldName">oriFieldName</param>
		public static void UpdateDefineField(int @iD, string @fieldName, string @table_Name, DateTime @addTime, bool @isShown, int @sortOrder, string @columnName, string @oriFieldName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateDefineField(@iD, @fieldName, @table_Name, @addTime, @isShown, @sortOrder, @columnName, @oriFieldName, helper);
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
		/// Updates a DefineField into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="fieldName">fieldName</param>
		/// <param name="table_Name">table_Name</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isShown">isShown</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="columnName">columnName</param>
		/// <param name="oriFieldName">oriFieldName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateDefineField(int @iD, string @fieldName, string @table_Name, DateTime @addTime, bool @isShown, int @sortOrder, string @columnName, string @oriFieldName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[FieldName] nvarchar(500),
	[Table_Name] nvarchar(500),
	[AddTime] datetime,
	[IsShown] bit,
	[SortOrder] int,
	[ColumnName] nvarchar(500),
	[OriFieldName] nvarchar(500)
);

UPDATE [dbo].[DefineField] SET 
	[DefineField].[FieldName] = @FieldName,
	[DefineField].[Table_Name] = @Table_Name,
	[DefineField].[AddTime] = @AddTime,
	[DefineField].[IsShown] = @IsShown,
	[DefineField].[SortOrder] = @SortOrder,
	[DefineField].[ColumnName] = @ColumnName,
	[DefineField].[OriFieldName] = @OriFieldName 
output 
	INSERTED.[ID],
	INSERTED.[FieldName],
	INSERTED.[Table_Name],
	INSERTED.[AddTime],
	INSERTED.[IsShown],
	INSERTED.[SortOrder],
	INSERTED.[ColumnName],
	INSERTED.[OriFieldName]
into @table
WHERE 
	[DefineField].[ID] = @ID

SELECT 
	[ID],
	[FieldName],
	[Table_Name],
	[AddTime],
	[IsShown],
	[SortOrder],
	[ColumnName],
	[OriFieldName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@FieldName", EntityBase.GetDatabaseValue(@fieldName)));
			parameters.Add(new SqlParameter("@Table_Name", EntityBase.GetDatabaseValue(@table_Name)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsShown", @isShown));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@ColumnName", EntityBase.GetDatabaseValue(@columnName)));
			parameters.Add(new SqlParameter("@OriFieldName", EntityBase.GetDatabaseValue(@oriFieldName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a DefineField from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteDefineField(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteDefineField(@iD, helper);
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
		/// Deletes a DefineField from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteDefineField(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[DefineField]
WHERE 
	[DefineField].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new DefineField object.
		/// </summary>
		/// <returns>The newly created DefineField object.</returns>
		public static DefineField CreateDefineField()
		{
			return InitializeNew<DefineField>();
		}
		
		/// <summary>
		/// Retrieve information for a DefineField by a DefineField's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>DefineField</returns>
		public static DefineField GetDefineField(int @iD)
		{
			string commandText = @"
SELECT 
" + DefineField.SelectFieldList + @"
FROM [dbo].[DefineField] 
WHERE 
	[DefineField].[ID] = @ID " + DefineField.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<DefineField>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a DefineField by a DefineField's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>DefineField</returns>
		public static DefineField GetDefineField(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + DefineField.SelectFieldList + @"
FROM [dbo].[DefineField] 
WHERE 
	[DefineField].[ID] = @ID " + DefineField.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<DefineField>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection DefineField objects.
		/// </summary>
		/// <returns>The retrieved collection of DefineField objects.</returns>
		public static EntityList<DefineField> GetDefineFields()
		{
			string commandText = @"
SELECT " + DefineField.SelectFieldList + "FROM [dbo].[DefineField] " + DefineField.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<DefineField>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection DefineField objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of DefineField objects.</returns>
        public static EntityList<DefineField> GetDefineFields(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<DefineField>(SelectFieldList, "FROM [dbo].[DefineField]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection DefineField objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of DefineField objects.</returns>
        public static EntityList<DefineField> GetDefineFields(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<DefineField>(SelectFieldList, "FROM [dbo].[DefineField]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection DefineField objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of DefineField objects.</returns>
		protected static EntityList<DefineField> GetDefineFields(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDefineFields(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection DefineField objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of DefineField objects.</returns>
		protected static EntityList<DefineField> GetDefineFields(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDefineFields(string.Empty, where, parameters, DefineField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DefineField objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of DefineField objects.</returns>
		protected static EntityList<DefineField> GetDefineFields(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetDefineFields(prefix, where, parameters, DefineField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DefineField objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of DefineField objects.</returns>
		protected static EntityList<DefineField> GetDefineFields(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDefineFields(string.Empty, where, parameters, DefineField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DefineField objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of DefineField objects.</returns>
		protected static EntityList<DefineField> GetDefineFields(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetDefineFields(prefix, where, parameters, DefineField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection DefineField objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of DefineField objects.</returns>
		protected static EntityList<DefineField> GetDefineFields(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + DefineField.SelectFieldList + "FROM [dbo].[DefineField] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<DefineField>(reader);
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
        protected static EntityList<DefineField> GetDefineFields(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<DefineField>(SelectFieldList, "FROM [dbo].[DefineField] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of DefineField objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDefineFieldCount()
        {
            return GetDefineFieldCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of DefineField objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetDefineFieldCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[DefineField] " + where;

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
		public static partial class DefineField_Properties
		{
			public const string ID = "ID";
			public const string FieldName = "FieldName";
			public const string Table_Name = "Table_Name";
			public const string AddTime = "AddTime";
			public const string IsShown = "IsShown";
			public const string SortOrder = "SortOrder";
			public const string ColumnName = "ColumnName";
			public const string OriFieldName = "OriFieldName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"FieldName" , "string:"},
    			 {"Table_Name" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsShown" , "bool:"},
    			 {"SortOrder" , "int:"},
    			 {"ColumnName" , "string:"},
    			 {"OriFieldName" , "string:"},
            };
		}
		#endregion
	}
}
