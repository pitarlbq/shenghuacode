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
	/// This object represents the properties and methods of a ProjectOrderNumber.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ProjectID: {ProjectID}, OrderNumberID: {OrderNumberID}")]
	public partial class ProjectOrderNumber 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _projectID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderNumberID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(true, false, false)]
		public int OrderNumberID
		{
			[DebuggerStepThrough()]
			get { return this._orderNumberID; }
			set 
			{
				if (this._orderNumberID != value) 
				{
					this._orderNumberID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderNumberID");
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
	[ProjectID] int,
	[OrderNumberID] int
);

INSERT INTO [dbo].[ProjectOrderNumber] (
	[ProjectOrderNumber].[ProjectID],
	[ProjectOrderNumber].[OrderNumberID]
) 
output 
	INSERTED.[ProjectID],
	INSERTED.[OrderNumberID]
into @table
VALUES ( 
	@ProjectID,
	@OrderNumberID 
); 

SELECT 
	[ProjectID],
	[OrderNumberID] 
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
	[ProjectID] int,
	[OrderNumberID] int
);

UPDATE [dbo].[ProjectOrderNumber] SET 
 
output 
	INSERTED.[ProjectID],
	INSERTED.[OrderNumberID]
into @table
WHERE 
	[ProjectOrderNumber].[ProjectID] = @ProjectID
	AND [ProjectOrderNumber].[OrderNumberID] = @OrderNumberID

SELECT 
	[ProjectID],
	[OrderNumberID] 
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
DELETE FROM [dbo].[ProjectOrderNumber]
WHERE 
	[ProjectOrderNumber].[ProjectID] = @ProjectID
	AND [ProjectOrderNumber].[OrderNumberID] = @OrderNumberID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ProjectOrderNumber() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProjectOrderNumber(this.ProjectID, this.OrderNumberID));
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
	[ProjectOrderNumber].[ProjectID],
	[ProjectOrderNumber].[OrderNumberID]
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
                return "ProjectOrderNumber";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ProjectOrderNumber into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="orderNumberID">orderNumberID</param>
		public static void InsertProjectOrderNumber(int @projectID, int @orderNumberID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProjectOrderNumber(@projectID, @orderNumberID, helper);
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
		/// Insert a ProjectOrderNumber into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="helper">helper</param>
		internal static void InsertProjectOrderNumber(int @projectID, int @orderNumberID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ProjectID] int,
	[OrderNumberID] int
);

INSERT INTO [dbo].[ProjectOrderNumber] (
	[ProjectOrderNumber].[ProjectID],
	[ProjectOrderNumber].[OrderNumberID]
) 
output 
	INSERTED.[ProjectID],
	INSERTED.[OrderNumberID]
into @table
VALUES ( 
	@ProjectID,
	@OrderNumberID 
); 

SELECT 
	[ProjectID],
	[OrderNumberID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ProjectOrderNumber into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="orderNumberID">orderNumberID</param>
		public static void UpdateProjectOrderNumber(int @projectID, int @orderNumberID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProjectOrderNumber(@projectID, @orderNumberID, helper);
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
		/// Updates a ProjectOrderNumber into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProjectOrderNumber(int @projectID, int @orderNumberID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ProjectID] int,
	[OrderNumberID] int
);

UPDATE [dbo].[ProjectOrderNumber] SET 
 
output 
	INSERTED.[ProjectID],
	INSERTED.[OrderNumberID]
into @table
WHERE 
	[ProjectOrderNumber].[ProjectID] = @ProjectID
	AND [ProjectOrderNumber].[OrderNumberID] = @OrderNumberID

SELECT 
	[ProjectID],
	[OrderNumberID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", EntityBase.GetDatabaseValue(@projectID)));
			parameters.Add(new SqlParameter("@OrderNumberID", EntityBase.GetDatabaseValue(@orderNumberID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ProjectOrderNumber from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="orderNumberID">orderNumberID</param>
		public static void DeleteProjectOrderNumber(int @projectID, int @orderNumberID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProjectOrderNumber(@projectID, @orderNumberID, helper);
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
		/// Deletes a ProjectOrderNumber from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProjectOrderNumber(int @projectID, int @orderNumberID, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ProjectOrderNumber]
WHERE 
	[ProjectOrderNumber].[ProjectID] = @ProjectID
	AND [ProjectOrderNumber].[OrderNumberID] = @OrderNumberID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			parameters.Add(new SqlParameter("@OrderNumberID", @orderNumberID));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ProjectOrderNumber object.
		/// </summary>
		/// <returns>The newly created ProjectOrderNumber object.</returns>
		public static ProjectOrderNumber CreateProjectOrderNumber()
		{
			return InitializeNew<ProjectOrderNumber>();
		}
		
		/// <summary>
		/// Retrieve information for a ProjectOrderNumber by a ProjectOrderNumber's unique identifier.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="orderNumberID">orderNumberID</param>
		/// <returns>ProjectOrderNumber</returns>
		public static ProjectOrderNumber GetProjectOrderNumber(int @projectID, int @orderNumberID)
		{
			string commandText = @"
SELECT 
" + ProjectOrderNumber.SelectFieldList + @"
FROM [dbo].[ProjectOrderNumber] 
WHERE 
	[ProjectOrderNumber].[ProjectID] = @ProjectID
	AND [ProjectOrderNumber].[OrderNumberID] = @OrderNumberID " + ProjectOrderNumber.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			parameters.Add(new SqlParameter("@OrderNumberID", @orderNumberID));
			
			return GetOne<ProjectOrderNumber>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ProjectOrderNumber by a ProjectOrderNumber's unique identifier.
		/// </summary>
		/// <param name="projectID">projectID</param>
		/// <param name="orderNumberID">orderNumberID</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ProjectOrderNumber</returns>
		public static ProjectOrderNumber GetProjectOrderNumber(int @projectID, int @orderNumberID, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ProjectOrderNumber.SelectFieldList + @"
FROM [dbo].[ProjectOrderNumber] 
WHERE 
	[ProjectOrderNumber].[ProjectID] = @ProjectID
	AND [ProjectOrderNumber].[OrderNumberID] = @OrderNumberID " + ProjectOrderNumber.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ProjectID", @projectID));
			parameters.Add(new SqlParameter("@OrderNumberID", @orderNumberID));
			
			return GetOne<ProjectOrderNumber>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ProjectOrderNumber objects.
		/// </summary>
		/// <returns>The retrieved collection of ProjectOrderNumber objects.</returns>
		public static EntityList<ProjectOrderNumber> GetProjectOrderNumbers()
		{
			string commandText = @"
SELECT " + ProjectOrderNumber.SelectFieldList + "FROM [dbo].[ProjectOrderNumber] " + ProjectOrderNumber.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ProjectOrderNumber>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ProjectOrderNumber objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectOrderNumber objects.</returns>
        public static EntityList<ProjectOrderNumber> GetProjectOrderNumbers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectOrderNumber>(SelectFieldList, "FROM [dbo].[ProjectOrderNumber]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ProjectOrderNumber objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectOrderNumber objects.</returns>
        public static EntityList<ProjectOrderNumber> GetProjectOrderNumbers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectOrderNumber>(SelectFieldList, "FROM [dbo].[ProjectOrderNumber]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ProjectOrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ProjectOrderNumber objects.</returns>
		protected static EntityList<ProjectOrderNumber> GetProjectOrderNumbers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectOrderNumbers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ProjectOrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectOrderNumber objects.</returns>
		protected static EntityList<ProjectOrderNumber> GetProjectOrderNumbers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectOrderNumbers(string.Empty, where, parameters, ProjectOrderNumber.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectOrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectOrderNumber objects.</returns>
		protected static EntityList<ProjectOrderNumber> GetProjectOrderNumbers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectOrderNumbers(prefix, where, parameters, ProjectOrderNumber.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectOrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectOrderNumber objects.</returns>
		protected static EntityList<ProjectOrderNumber> GetProjectOrderNumbers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectOrderNumbers(string.Empty, where, parameters, ProjectOrderNumber.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectOrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectOrderNumber objects.</returns>
		protected static EntityList<ProjectOrderNumber> GetProjectOrderNumbers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectOrderNumbers(prefix, where, parameters, ProjectOrderNumber.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectOrderNumber objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ProjectOrderNumber objects.</returns>
		protected static EntityList<ProjectOrderNumber> GetProjectOrderNumbers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ProjectOrderNumber.SelectFieldList + "FROM [dbo].[ProjectOrderNumber] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ProjectOrderNumber>(reader);
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
        protected static EntityList<ProjectOrderNumber> GetProjectOrderNumbers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectOrderNumber>(SelectFieldList, "FROM [dbo].[ProjectOrderNumber] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ProjectOrderNumber objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectOrderNumberCount()
        {
            return GetProjectOrderNumberCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ProjectOrderNumber objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectOrderNumberCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ProjectOrderNumber] " + where;

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
		public static partial class ProjectOrderNumberProperties
		{
			public const string ProjectID = "ProjectID";
			public const string OrderNumberID = "OrderNumberID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ProjectID" , "int:"},
    			 {"OrderNumberID" , "int:"},
            };
		}
		#endregion
	}
}
