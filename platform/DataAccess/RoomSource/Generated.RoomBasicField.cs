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
	/// This object represents the properties and methods of a RoomBasicField.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomBasicField 
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
		private int _roomID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int RoomID
		{
			[DebuggerStepThrough()]
			get { return this._roomID; }
			set 
			{
				if (this._roomID != value) 
				{
					this._roomID = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _fieldID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int FieldID
		{
			[DebuggerStepThrough()]
			get { return this._fieldID; }
			set 
			{
				if (this._fieldID != value) 
				{
					this._fieldID = value;
					this.IsDirty = true;	
					OnPropertyChanged("FieldID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fieldContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FieldContent
		{
			[DebuggerStepThrough()]
			get { return this._fieldContent; }
			set 
			{
				if (this._fieldContent != value) 
				{
					this._fieldContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("FieldContent");
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
	[RoomID] int,
	[FieldID] int,
	[FieldContent] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[RoomBasicField] (
	[RoomBasicField].[RoomID],
	[RoomBasicField].[FieldID],
	[RoomBasicField].[FieldContent],
	[RoomBasicField].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[FieldID],
	INSERTED.[FieldContent],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@RoomID,
	@FieldID,
	@FieldContent,
	@AddTime 
); 

SELECT 
	[ID],
	[RoomID],
	[FieldID],
	[FieldContent],
	[AddTime] 
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
	[RoomID] int,
	[FieldID] int,
	[FieldContent] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[RoomBasicField] SET 
	[RoomBasicField].[RoomID] = @RoomID,
	[RoomBasicField].[FieldID] = @FieldID,
	[RoomBasicField].[FieldContent] = @FieldContent,
	[RoomBasicField].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[FieldID],
	INSERTED.[FieldContent],
	INSERTED.[AddTime]
into @table
WHERE 
	[RoomBasicField].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[FieldID],
	[FieldContent],
	[AddTime] 
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
DELETE FROM [dbo].[RoomBasicField]
WHERE 
	[RoomBasicField].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomBasicField() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomBasicField(this.ID));
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
	[RoomBasicField].[ID],
	[RoomBasicField].[RoomID],
	[RoomBasicField].[FieldID],
	[RoomBasicField].[FieldContent],
	[RoomBasicField].[AddTime]
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
                return "RoomBasicField";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomBasicField into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="fieldID">fieldID</param>
		/// <param name="fieldContent">fieldContent</param>
		/// <param name="addTime">addTime</param>
		public static void InsertRoomBasicField(int @roomID, int @fieldID, string @fieldContent, DateTime @addTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomBasicField(@roomID, @fieldID, @fieldContent, @addTime, helper);
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
		/// Insert a RoomBasicField into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="fieldID">fieldID</param>
		/// <param name="fieldContent">fieldContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomBasicField(int @roomID, int @fieldID, string @fieldContent, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[FieldID] int,
	[FieldContent] nvarchar(500),
	[AddTime] datetime
);

INSERT INTO [dbo].[RoomBasicField] (
	[RoomBasicField].[RoomID],
	[RoomBasicField].[FieldID],
	[RoomBasicField].[FieldContent],
	[RoomBasicField].[AddTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[FieldID],
	INSERTED.[FieldContent],
	INSERTED.[AddTime]
into @table
VALUES ( 
	@RoomID,
	@FieldID,
	@FieldContent,
	@AddTime 
); 

SELECT 
	[ID],
	[RoomID],
	[FieldID],
	[FieldContent],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@FieldID", EntityBase.GetDatabaseValue(@fieldID)));
			parameters.Add(new SqlParameter("@FieldContent", EntityBase.GetDatabaseValue(@fieldContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomBasicField into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="fieldID">fieldID</param>
		/// <param name="fieldContent">fieldContent</param>
		/// <param name="addTime">addTime</param>
		public static void UpdateRoomBasicField(int @iD, int @roomID, int @fieldID, string @fieldContent, DateTime @addTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomBasicField(@iD, @roomID, @fieldID, @fieldContent, @addTime, helper);
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
		/// Updates a RoomBasicField into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="fieldID">fieldID</param>
		/// <param name="fieldContent">fieldContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomBasicField(int @iD, int @roomID, int @fieldID, string @fieldContent, DateTime @addTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[FieldID] int,
	[FieldContent] nvarchar(500),
	[AddTime] datetime
);

UPDATE [dbo].[RoomBasicField] SET 
	[RoomBasicField].[RoomID] = @RoomID,
	[RoomBasicField].[FieldID] = @FieldID,
	[RoomBasicField].[FieldContent] = @FieldContent,
	[RoomBasicField].[AddTime] = @AddTime 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[FieldID],
	INSERTED.[FieldContent],
	INSERTED.[AddTime]
into @table
WHERE 
	[RoomBasicField].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[FieldID],
	[FieldContent],
	[AddTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@FieldID", EntityBase.GetDatabaseValue(@fieldID)));
			parameters.Add(new SqlParameter("@FieldContent", EntityBase.GetDatabaseValue(@fieldContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomBasicField from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomBasicField(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomBasicField(@iD, helper);
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
		/// Deletes a RoomBasicField from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomBasicField(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomBasicField]
WHERE 
	[RoomBasicField].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomBasicField object.
		/// </summary>
		/// <returns>The newly created RoomBasicField object.</returns>
		public static RoomBasicField CreateRoomBasicField()
		{
			return InitializeNew<RoomBasicField>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomBasicField by a RoomBasicField's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomBasicField</returns>
		public static RoomBasicField GetRoomBasicField(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomBasicField.SelectFieldList + @"
FROM [dbo].[RoomBasicField] 
WHERE 
	[RoomBasicField].[ID] = @ID " + RoomBasicField.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomBasicField>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomBasicField by a RoomBasicField's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomBasicField</returns>
		public static RoomBasicField GetRoomBasicField(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomBasicField.SelectFieldList + @"
FROM [dbo].[RoomBasicField] 
WHERE 
	[RoomBasicField].[ID] = @ID " + RoomBasicField.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomBasicField>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomBasicField objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomBasicField objects.</returns>
		public static EntityList<RoomBasicField> GetRoomBasicFields()
		{
			string commandText = @"
SELECT " + RoomBasicField.SelectFieldList + "FROM [dbo].[RoomBasicField] " + RoomBasicField.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomBasicField>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomBasicField objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomBasicField objects.</returns>
        public static EntityList<RoomBasicField> GetRoomBasicFields(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomBasicField>(SelectFieldList, "FROM [dbo].[RoomBasicField]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomBasicField objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomBasicField objects.</returns>
        public static EntityList<RoomBasicField> GetRoomBasicFields(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomBasicField>(SelectFieldList, "FROM [dbo].[RoomBasicField]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomBasicField objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomBasicField objects.</returns>
		protected static EntityList<RoomBasicField> GetRoomBasicFields(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomBasicFields(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomBasicField objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomBasicField objects.</returns>
		protected static EntityList<RoomBasicField> GetRoomBasicFields(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomBasicFields(string.Empty, where, parameters, RoomBasicField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasicField objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomBasicField objects.</returns>
		protected static EntityList<RoomBasicField> GetRoomBasicFields(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomBasicFields(prefix, where, parameters, RoomBasicField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasicField objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomBasicField objects.</returns>
		protected static EntityList<RoomBasicField> GetRoomBasicFields(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomBasicFields(string.Empty, where, parameters, RoomBasicField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasicField objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomBasicField objects.</returns>
		protected static EntityList<RoomBasicField> GetRoomBasicFields(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomBasicFields(prefix, where, parameters, RoomBasicField.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasicField objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomBasicField objects.</returns>
		protected static EntityList<RoomBasicField> GetRoomBasicFields(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomBasicField.SelectFieldList + "FROM [dbo].[RoomBasicField] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomBasicField>(reader);
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
        protected static EntityList<RoomBasicField> GetRoomBasicFields(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomBasicField>(SelectFieldList, "FROM [dbo].[RoomBasicField] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomBasicField objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomBasicFieldCount()
        {
            return GetRoomBasicFieldCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomBasicField objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomBasicFieldCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomBasicField] " + where;

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
		public static partial class RoomBasicField_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string FieldID = "FieldID";
			public const string FieldContent = "FieldContent";
			public const string AddTime = "AddTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"FieldID" , "int:"},
    			 {"FieldContent" , "string:"},
    			 {"AddTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
