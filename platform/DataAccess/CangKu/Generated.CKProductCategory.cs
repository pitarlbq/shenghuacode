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
	/// This object represents the properties and methods of a CKProductCategory.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CKProductCategory 
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
		private string _productCategoryName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string ProductCategoryName
		{
			[DebuggerStepThrough()]
			get { return this._productCategoryName; }
			set 
			{
				if (this._productCategoryName != value) 
				{
					this._productCategoryName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductCategoryName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _productCategoryDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProductCategoryDesc
		{
			[DebuggerStepThrough()]
			get { return this._productCategoryDesc; }
			set 
			{
				if (this._productCategoryDesc != value) 
				{
					this._productCategoryDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProductCategoryDesc");
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
	[ProductCategoryName] nvarchar(100),
	[ProductCategoryDesc] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50)
);

INSERT INTO [dbo].[CKProductCategory] (
	[CKProductCategory].[ProductCategoryName],
	[CKProductCategory].[ProductCategoryDesc],
	[CKProductCategory].[AddTime],
	[CKProductCategory].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductCategoryName],
	INSERTED.[ProductCategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@ProductCategoryName,
	@ProductCategoryDesc,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[ProductCategoryName],
	[ProductCategoryDesc],
	[AddTime],
	[AddMan] 
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
	[ProductCategoryName] nvarchar(100),
	[ProductCategoryDesc] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50)
);

UPDATE [dbo].[CKProductCategory] SET 
	[CKProductCategory].[ProductCategoryName] = @ProductCategoryName,
	[CKProductCategory].[ProductCategoryDesc] = @ProductCategoryDesc,
	[CKProductCategory].[AddTime] = @AddTime,
	[CKProductCategory].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[ProductCategoryName],
	INSERTED.[ProductCategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[CKProductCategory].[ID] = @ID

SELECT 
	[ID],
	[ProductCategoryName],
	[ProductCategoryDesc],
	[AddTime],
	[AddMan] 
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
DELETE FROM [dbo].[CKProductCategory]
WHERE 
	[CKProductCategory].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CKProductCategory() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCKProductCategory(this.ID));
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
	[CKProductCategory].[ID],
	[CKProductCategory].[ProductCategoryName],
	[CKProductCategory].[ProductCategoryDesc],
	[CKProductCategory].[AddTime],
	[CKProductCategory].[AddMan]
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
                return "CKProductCategory";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CKProductCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productCategoryName">productCategoryName</param>
		/// <param name="productCategoryDesc">productCategoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void InsertCKProductCategory(string @productCategoryName, string @productCategoryDesc, DateTime @addTime, string @addMan)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCKProductCategory(@productCategoryName, @productCategoryDesc, @addTime, @addMan, helper);
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
		/// Insert a CKProductCategory into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="productCategoryName">productCategoryName</param>
		/// <param name="productCategoryDesc">productCategoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void InsertCKProductCategory(string @productCategoryName, string @productCategoryDesc, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductCategoryName] nvarchar(100),
	[ProductCategoryDesc] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50)
);

INSERT INTO [dbo].[CKProductCategory] (
	[CKProductCategory].[ProductCategoryName],
	[CKProductCategory].[ProductCategoryDesc],
	[CKProductCategory].[AddTime],
	[CKProductCategory].[AddMan]
) 
output 
	INSERTED.[ID],
	INSERTED.[ProductCategoryName],
	INSERTED.[ProductCategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
VALUES ( 
	@ProductCategoryName,
	@ProductCategoryDesc,
	@AddTime,
	@AddMan 
); 

SELECT 
	[ID],
	[ProductCategoryName],
	[ProductCategoryDesc],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProductCategoryName", EntityBase.GetDatabaseValue(@productCategoryName)));
			parameters.Add(new SqlParameter("@ProductCategoryDesc", EntityBase.GetDatabaseValue(@productCategoryDesc)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CKProductCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productCategoryName">productCategoryName</param>
		/// <param name="productCategoryDesc">productCategoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		public static void UpdateCKProductCategory(int @iD, string @productCategoryName, string @productCategoryDesc, DateTime @addTime, string @addMan)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCKProductCategory(@iD, @productCategoryName, @productCategoryDesc, @addTime, @addMan, helper);
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
		/// Updates a CKProductCategory into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="productCategoryName">productCategoryName</param>
		/// <param name="productCategoryDesc">productCategoryDesc</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCKProductCategory(int @iD, string @productCategoryName, string @productCategoryDesc, DateTime @addTime, string @addMan, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ProductCategoryName] nvarchar(100),
	[ProductCategoryDesc] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50)
);

UPDATE [dbo].[CKProductCategory] SET 
	[CKProductCategory].[ProductCategoryName] = @ProductCategoryName,
	[CKProductCategory].[ProductCategoryDesc] = @ProductCategoryDesc,
	[CKProductCategory].[AddTime] = @AddTime,
	[CKProductCategory].[AddMan] = @AddMan 
output 
	INSERTED.[ID],
	INSERTED.[ProductCategoryName],
	INSERTED.[ProductCategoryDesc],
	INSERTED.[AddTime],
	INSERTED.[AddMan]
into @table
WHERE 
	[CKProductCategory].[ID] = @ID

SELECT 
	[ID],
	[ProductCategoryName],
	[ProductCategoryDesc],
	[AddTime],
	[AddMan] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ProductCategoryName", EntityBase.GetDatabaseValue(@productCategoryName)));
			parameters.Add(new SqlParameter("@ProductCategoryDesc", EntityBase.GetDatabaseValue(@productCategoryDesc)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CKProductCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCKProductCategory(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCKProductCategory(@iD, helper);
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
		/// Deletes a CKProductCategory from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCKProductCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CKProductCategory]
WHERE 
	[CKProductCategory].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CKProductCategory object.
		/// </summary>
		/// <returns>The newly created CKProductCategory object.</returns>
		public static CKProductCategory CreateCKProductCategory()
		{
			return InitializeNew<CKProductCategory>();
		}
		
		/// <summary>
		/// Retrieve information for a CKProductCategory by a CKProductCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CKProductCategory</returns>
		public static CKProductCategory GetCKProductCategory(int @iD)
		{
			string commandText = @"
SELECT 
" + CKProductCategory.SelectFieldList + @"
FROM [dbo].[CKProductCategory] 
WHERE 
	[CKProductCategory].[ID] = @ID " + CKProductCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProductCategory>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CKProductCategory by a CKProductCategory's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CKProductCategory</returns>
		public static CKProductCategory GetCKProductCategory(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CKProductCategory.SelectFieldList + @"
FROM [dbo].[CKProductCategory] 
WHERE 
	[CKProductCategory].[ID] = @ID " + CKProductCategory.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CKProductCategory>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CKProductCategory objects.
		/// </summary>
		/// <returns>The retrieved collection of CKProductCategory objects.</returns>
		public static EntityList<CKProductCategory> GetCKProductCategories()
		{
			string commandText = @"
SELECT " + CKProductCategory.SelectFieldList + "FROM [dbo].[CKProductCategory] " + CKProductCategory.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CKProductCategory>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CKProductCategory objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProductCategory objects.</returns>
        public static EntityList<CKProductCategory> GetCKProductCategories(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProductCategory>(SelectFieldList, "FROM [dbo].[CKProductCategory]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CKProductCategory objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CKProductCategory objects.</returns>
        public static EntityList<CKProductCategory> GetCKProductCategories(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProductCategory>(SelectFieldList, "FROM [dbo].[CKProductCategory]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CKProductCategory objects.</returns>
		protected static EntityList<CKProductCategory> GetCKProductCategories(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProductCategories(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProductCategory objects.</returns>
		protected static EntityList<CKProductCategory> GetCKProductCategories(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProductCategories(string.Empty, where, parameters, CKProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CKProductCategory objects.</returns>
		protected static EntityList<CKProductCategory> GetCKProductCategories(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCKProductCategories(prefix, where, parameters, CKProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProductCategory objects.</returns>
		protected static EntityList<CKProductCategory> GetCKProductCategories(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProductCategories(string.Empty, where, parameters, CKProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductCategory objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CKProductCategory objects.</returns>
		protected static EntityList<CKProductCategory> GetCKProductCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCKProductCategories(prefix, where, parameters, CKProductCategory.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CKProductCategory objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CKProductCategory objects.</returns>
		protected static EntityList<CKProductCategory> GetCKProductCategories(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CKProductCategory.SelectFieldList + "FROM [dbo].[CKProductCategory] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CKProductCategory>(reader);
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
        protected static EntityList<CKProductCategory> GetCKProductCategories(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CKProductCategory>(SelectFieldList, "FROM [dbo].[CKProductCategory] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CKProductCategory objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProductCategoryCount()
        {
            return GetCKProductCategoryCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CKProductCategory objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCKProductCategoryCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CKProductCategory] " + where;

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
		public static partial class CKProductCategory_Properties
		{
			public const string ID = "ID";
			public const string ProductCategoryName = "ProductCategoryName";
			public const string ProductCategoryDesc = "ProductCategoryDesc";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ProductCategoryName" , "string:"},
    			 {"ProductCategoryDesc" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
            };
		}
		#endregion
	}
}
