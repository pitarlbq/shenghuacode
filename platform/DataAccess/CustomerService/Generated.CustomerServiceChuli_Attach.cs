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
	/// This object represents the properties and methods of a CustomerServiceChuli_Attach.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CustomerServiceChuli_Attach 
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
		private int _chuliID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ChuliID
		{
			[DebuggerStepThrough()]
			get { return this._chuliID; }
			set 
			{
				if (this._chuliID != value) 
				{
					this._chuliID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChuliID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _attachedFilePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AttachedFilePath
		{
			[DebuggerStepThrough()]
			get { return this._attachedFilePath; }
			set 
			{
				if (this._attachedFilePath != value) 
				{
					this._attachedFilePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("AttachedFilePath");
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
		private string _fileOriName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FileOriName
		{
			[DebuggerStepThrough()]
			get { return this._fileOriName; }
			set 
			{
				if (this._fileOriName != value) 
				{
					this._fileOriName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FileOriName");
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
	[ChuliID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[CustomerServiceChuli_Attach] (
	[CustomerServiceChuli_Attach].[ChuliID],
	[CustomerServiceChuli_Attach].[AttachedFilePath],
	[CustomerServiceChuli_Attach].[AddTime],
	[CustomerServiceChuli_Attach].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ChuliID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@ChuliID,
	@AttachedFilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[ChuliID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName] 
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
	[ChuliID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[CustomerServiceChuli_Attach] SET 
	[CustomerServiceChuli_Attach].[ChuliID] = @ChuliID,
	[CustomerServiceChuli_Attach].[AttachedFilePath] = @AttachedFilePath,
	[CustomerServiceChuli_Attach].[AddTime] = @AddTime,
	[CustomerServiceChuli_Attach].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[ChuliID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[CustomerServiceChuli_Attach].[ID] = @ID

SELECT 
	[ID],
	[ChuliID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName] 
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
DELETE FROM [dbo].[CustomerServiceChuli_Attach]
WHERE 
	[CustomerServiceChuli_Attach].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CustomerServiceChuli_Attach() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCustomerServiceChuli_Attach(this.ID));
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
	[CustomerServiceChuli_Attach].[ID],
	[CustomerServiceChuli_Attach].[ChuliID],
	[CustomerServiceChuli_Attach].[AttachedFilePath],
	[CustomerServiceChuli_Attach].[AddTime],
	[CustomerServiceChuli_Attach].[FileOriName]
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
                return "CustomerServiceChuli_Attach";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CustomerServiceChuli_Attach into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chuliID">chuliID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void InsertCustomerServiceChuli_Attach(int @chuliID, string @attachedFilePath, DateTime @addTime, string @fileOriName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCustomerServiceChuli_Attach(@chuliID, @attachedFilePath, @addTime, @fileOriName, helper);
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
		/// Insert a CustomerServiceChuli_Attach into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="chuliID">chuliID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void InsertCustomerServiceChuli_Attach(int @chuliID, string @attachedFilePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ChuliID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

INSERT INTO [dbo].[CustomerServiceChuli_Attach] (
	[CustomerServiceChuli_Attach].[ChuliID],
	[CustomerServiceChuli_Attach].[AttachedFilePath],
	[CustomerServiceChuli_Attach].[AddTime],
	[CustomerServiceChuli_Attach].[FileOriName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ChuliID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
VALUES ( 
	@ChuliID,
	@AttachedFilePath,
	@AddTime,
	@FileOriName 
); 

SELECT 
	[ID],
	[ChuliID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ChuliID", EntityBase.GetDatabaseValue(@chuliID)));
			parameters.Add(new SqlParameter("@AttachedFilePath", EntityBase.GetDatabaseValue(@attachedFilePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CustomerServiceChuli_Attach into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="chuliID">chuliID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		public static void UpdateCustomerServiceChuli_Attach(int @iD, int @chuliID, string @attachedFilePath, DateTime @addTime, string @fileOriName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCustomerServiceChuli_Attach(@iD, @chuliID, @attachedFilePath, @addTime, @fileOriName, helper);
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
		/// Updates a CustomerServiceChuli_Attach into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="chuliID">chuliID</param>
		/// <param name="attachedFilePath">attachedFilePath</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileOriName">fileOriName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCustomerServiceChuli_Attach(int @iD, int @chuliID, string @attachedFilePath, DateTime @addTime, string @fileOriName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ChuliID] int,
	[AttachedFilePath] nvarchar(500),
	[AddTime] datetime,
	[FileOriName] nvarchar(500)
);

UPDATE [dbo].[CustomerServiceChuli_Attach] SET 
	[CustomerServiceChuli_Attach].[ChuliID] = @ChuliID,
	[CustomerServiceChuli_Attach].[AttachedFilePath] = @AttachedFilePath,
	[CustomerServiceChuli_Attach].[AddTime] = @AddTime,
	[CustomerServiceChuli_Attach].[FileOriName] = @FileOriName 
output 
	INSERTED.[ID],
	INSERTED.[ChuliID],
	INSERTED.[AttachedFilePath],
	INSERTED.[AddTime],
	INSERTED.[FileOriName]
into @table
WHERE 
	[CustomerServiceChuli_Attach].[ID] = @ID

SELECT 
	[ID],
	[ChuliID],
	[AttachedFilePath],
	[AddTime],
	[FileOriName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ChuliID", EntityBase.GetDatabaseValue(@chuliID)));
			parameters.Add(new SqlParameter("@AttachedFilePath", EntityBase.GetDatabaseValue(@attachedFilePath)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileOriName", EntityBase.GetDatabaseValue(@fileOriName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CustomerServiceChuli_Attach from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCustomerServiceChuli_Attach(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCustomerServiceChuli_Attach(@iD, helper);
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
		/// Deletes a CustomerServiceChuli_Attach from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCustomerServiceChuli_Attach(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CustomerServiceChuli_Attach]
WHERE 
	[CustomerServiceChuli_Attach].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CustomerServiceChuli_Attach object.
		/// </summary>
		/// <returns>The newly created CustomerServiceChuli_Attach object.</returns>
		public static CustomerServiceChuli_Attach CreateCustomerServiceChuli_Attach()
		{
			return InitializeNew<CustomerServiceChuli_Attach>();
		}
		
		/// <summary>
		/// Retrieve information for a CustomerServiceChuli_Attach by a CustomerServiceChuli_Attach's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CustomerServiceChuli_Attach</returns>
		public static CustomerServiceChuli_Attach GetCustomerServiceChuli_Attach(int @iD)
		{
			string commandText = @"
SELECT 
" + CustomerServiceChuli_Attach.SelectFieldList + @"
FROM [dbo].[CustomerServiceChuli_Attach] 
WHERE 
	[CustomerServiceChuli_Attach].[ID] = @ID " + CustomerServiceChuli_Attach.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerServiceChuli_Attach>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CustomerServiceChuli_Attach by a CustomerServiceChuli_Attach's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CustomerServiceChuli_Attach</returns>
		public static CustomerServiceChuli_Attach GetCustomerServiceChuli_Attach(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CustomerServiceChuli_Attach.SelectFieldList + @"
FROM [dbo].[CustomerServiceChuli_Attach] 
WHERE 
	[CustomerServiceChuli_Attach].[ID] = @ID " + CustomerServiceChuli_Attach.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerServiceChuli_Attach>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceChuli_Attach objects.
		/// </summary>
		/// <returns>The retrieved collection of CustomerServiceChuli_Attach objects.</returns>
		public static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches()
		{
			string commandText = @"
SELECT " + CustomerServiceChuli_Attach.SelectFieldList + "FROM [dbo].[CustomerServiceChuli_Attach] " + CustomerServiceChuli_Attach.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CustomerServiceChuli_Attach>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CustomerServiceChuli_Attach objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerServiceChuli_Attach objects.</returns>
        public static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerServiceChuli_Attach>(SelectFieldList, "FROM [dbo].[CustomerServiceChuli_Attach]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CustomerServiceChuli_Attach objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerServiceChuli_Attach objects.</returns>
        public static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerServiceChuli_Attach>(SelectFieldList, "FROM [dbo].[CustomerServiceChuli_Attach]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CustomerServiceChuli_Attach objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CustomerServiceChuli_Attach objects.</returns>
		protected static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerServiceChuli_Attaches(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceChuli_Attach objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerServiceChuli_Attach objects.</returns>
		protected static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerServiceChuli_Attaches(string.Empty, where, parameters, CustomerServiceChuli_Attach.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceChuli_Attach objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerServiceChuli_Attach objects.</returns>
		protected static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerServiceChuli_Attaches(prefix, where, parameters, CustomerServiceChuli_Attach.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceChuli_Attach objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerServiceChuli_Attach objects.</returns>
		protected static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerServiceChuli_Attaches(string.Empty, where, parameters, CustomerServiceChuli_Attach.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceChuli_Attach objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerServiceChuli_Attach objects.</returns>
		protected static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerServiceChuli_Attaches(prefix, where, parameters, CustomerServiceChuli_Attach.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerServiceChuli_Attach objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CustomerServiceChuli_Attach objects.</returns>
		protected static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CustomerServiceChuli_Attach.SelectFieldList + "FROM [dbo].[CustomerServiceChuli_Attach] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CustomerServiceChuli_Attach>(reader);
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
        protected static EntityList<CustomerServiceChuli_Attach> GetCustomerServiceChuli_Attaches(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerServiceChuli_Attach>(SelectFieldList, "FROM [dbo].[CustomerServiceChuli_Attach] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CustomerServiceChuli_Attach objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerServiceChuli_AttachCount()
        {
            return GetCustomerServiceChuli_AttachCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CustomerServiceChuli_Attach objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerServiceChuli_AttachCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CustomerServiceChuli_Attach] " + where;

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
		public static partial class CustomerServiceChuli_Attach_Properties
		{
			public const string ID = "ID";
			public const string ChuliID = "ChuliID";
			public const string AttachedFilePath = "AttachedFilePath";
			public const string AddTime = "AddTime";
			public const string FileOriName = "FileOriName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ChuliID" , "int:"},
    			 {"AttachedFilePath" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"FileOriName" , "string:"},
            };
		}
		#endregion
	}
}
