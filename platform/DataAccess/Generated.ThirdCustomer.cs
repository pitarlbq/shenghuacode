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
	/// This object represents the properties and methods of a ThirdCustomer.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ThirdCustomer 
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
		private string _customerName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CustomerName
		{
			[DebuggerStepThrough()]
			get { return this._customerName; }
			set 
			{
				if (this._customerName != value) 
				{
					this._customerName = value;
					this.IsDirty = true;	
					OnPropertyChanged("CustomerName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _phoneNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string PhoneNumber
		{
			[DebuggerStepThrough()]
			get { return this._phoneNumber; }
			set 
			{
				if (this._phoneNumber != value) 
				{
					this._phoneNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("PhoneNumber");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _projectName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ProjectName
		{
			[DebuggerStepThrough()]
			get { return this._projectName; }
			set 
			{
				if (this._projectName != value) 
				{
					this._projectName = value;
					this.IsDirty = true;	
					OnPropertyChanged("ProjectName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomName
		{
			[DebuggerStepThrough()]
			get { return this._roomName; }
			set 
			{
				if (this._roomName != value) 
				{
					this._roomName = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _signDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime SignDate
		{
			[DebuggerStepThrough()]
			get { return this._signDate; }
			set 
			{
				if (this._signDate != value) 
				{
					this._signDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("SignDate");
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
		private int _addUserID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AddUserID
		{
			[DebuggerStepThrough()]
			get { return this._addUserID; }
			set 
			{
				if (this._addUserID != value) 
				{
					this._addUserID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _lastSendTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime LastSendTime
		{
			[DebuggerStepThrough()]
			get { return this._lastSendTime; }
			set 
			{
				if (this._lastSendTime != value) 
				{
					this._lastSendTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("LastSendTime");
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
	[CustomerName] nvarchar(100),
	[PhoneNumber] nvarchar(50),
	[ProjectName] nvarchar(100),
	[RoomName] nvarchar(100),
	[SignDate] datetime,
	[AddTime] datetime,
	[AddUserID] int,
	[LastSendTime] datetime
);

INSERT INTO [dbo].[ThirdCustomer] (
	[ThirdCustomer].[CustomerName],
	[ThirdCustomer].[PhoneNumber],
	[ThirdCustomer].[ProjectName],
	[ThirdCustomer].[RoomName],
	[ThirdCustomer].[SignDate],
	[ThirdCustomer].[AddTime],
	[ThirdCustomer].[AddUserID],
	[ThirdCustomer].[LastSendTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[CustomerName],
	INSERTED.[PhoneNumber],
	INSERTED.[ProjectName],
	INSERTED.[RoomName],
	INSERTED.[SignDate],
	INSERTED.[AddTime],
	INSERTED.[AddUserID],
	INSERTED.[LastSendTime]
into @table
VALUES ( 
	@CustomerName,
	@PhoneNumber,
	@ProjectName,
	@RoomName,
	@SignDate,
	@AddTime,
	@AddUserID,
	@LastSendTime 
); 

SELECT 
	[ID],
	[CustomerName],
	[PhoneNumber],
	[ProjectName],
	[RoomName],
	[SignDate],
	[AddTime],
	[AddUserID],
	[LastSendTime] 
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
	[CustomerName] nvarchar(100),
	[PhoneNumber] nvarchar(50),
	[ProjectName] nvarchar(100),
	[RoomName] nvarchar(100),
	[SignDate] datetime,
	[AddTime] datetime,
	[AddUserID] int,
	[LastSendTime] datetime
);

UPDATE [dbo].[ThirdCustomer] SET 
	[ThirdCustomer].[CustomerName] = @CustomerName,
	[ThirdCustomer].[PhoneNumber] = @PhoneNumber,
	[ThirdCustomer].[ProjectName] = @ProjectName,
	[ThirdCustomer].[RoomName] = @RoomName,
	[ThirdCustomer].[SignDate] = @SignDate,
	[ThirdCustomer].[AddTime] = @AddTime,
	[ThirdCustomer].[AddUserID] = @AddUserID,
	[ThirdCustomer].[LastSendTime] = @LastSendTime 
output 
	INSERTED.[ID],
	INSERTED.[CustomerName],
	INSERTED.[PhoneNumber],
	INSERTED.[ProjectName],
	INSERTED.[RoomName],
	INSERTED.[SignDate],
	INSERTED.[AddTime],
	INSERTED.[AddUserID],
	INSERTED.[LastSendTime]
into @table
WHERE 
	[ThirdCustomer].[ID] = @ID

SELECT 
	[ID],
	[CustomerName],
	[PhoneNumber],
	[ProjectName],
	[RoomName],
	[SignDate],
	[AddTime],
	[AddUserID],
	[LastSendTime] 
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
DELETE FROM [dbo].[ThirdCustomer]
WHERE 
	[ThirdCustomer].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ThirdCustomer() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetThirdCustomer(this.ID));
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
	[ThirdCustomer].[ID],
	[ThirdCustomer].[CustomerName],
	[ThirdCustomer].[PhoneNumber],
	[ThirdCustomer].[ProjectName],
	[ThirdCustomer].[RoomName],
	[ThirdCustomer].[SignDate],
	[ThirdCustomer].[AddTime],
	[ThirdCustomer].[AddUserID],
	[ThirdCustomer].[LastSendTime]
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
                return "ThirdCustomer";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ThirdCustomer into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="customerName">customerName</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="projectName">projectName</param>
		/// <param name="roomName">roomName</param>
		/// <param name="signDate">signDate</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="lastSendTime">lastSendTime</param>
		public static void InsertThirdCustomer(string @customerName, string @phoneNumber, string @projectName, string @roomName, DateTime @signDate, DateTime @addTime, int @addUserID, DateTime @lastSendTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertThirdCustomer(@customerName, @phoneNumber, @projectName, @roomName, @signDate, @addTime, @addUserID, @lastSendTime, helper);
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
		/// Insert a ThirdCustomer into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="customerName">customerName</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="projectName">projectName</param>
		/// <param name="roomName">roomName</param>
		/// <param name="signDate">signDate</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="lastSendTime">lastSendTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertThirdCustomer(string @customerName, string @phoneNumber, string @projectName, string @roomName, DateTime @signDate, DateTime @addTime, int @addUserID, DateTime @lastSendTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CustomerName] nvarchar(100),
	[PhoneNumber] nvarchar(50),
	[ProjectName] nvarchar(100),
	[RoomName] nvarchar(100),
	[SignDate] datetime,
	[AddTime] datetime,
	[AddUserID] int,
	[LastSendTime] datetime
);

INSERT INTO [dbo].[ThirdCustomer] (
	[ThirdCustomer].[CustomerName],
	[ThirdCustomer].[PhoneNumber],
	[ThirdCustomer].[ProjectName],
	[ThirdCustomer].[RoomName],
	[ThirdCustomer].[SignDate],
	[ThirdCustomer].[AddTime],
	[ThirdCustomer].[AddUserID],
	[ThirdCustomer].[LastSendTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[CustomerName],
	INSERTED.[PhoneNumber],
	INSERTED.[ProjectName],
	INSERTED.[RoomName],
	INSERTED.[SignDate],
	INSERTED.[AddTime],
	INSERTED.[AddUserID],
	INSERTED.[LastSendTime]
into @table
VALUES ( 
	@CustomerName,
	@PhoneNumber,
	@ProjectName,
	@RoomName,
	@SignDate,
	@AddTime,
	@AddUserID,
	@LastSendTime 
); 

SELECT 
	[ID],
	[CustomerName],
	[PhoneNumber],
	[ProjectName],
	[RoomName],
	[SignDate],
	[AddTime],
	[AddUserID],
	[LastSendTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@SignDate", EntityBase.GetDatabaseValue(@signDate)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserID", EntityBase.GetDatabaseValue(@addUserID)));
			parameters.Add(new SqlParameter("@LastSendTime", EntityBase.GetDatabaseValue(@lastSendTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ThirdCustomer into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="customerName">customerName</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="projectName">projectName</param>
		/// <param name="roomName">roomName</param>
		/// <param name="signDate">signDate</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="lastSendTime">lastSendTime</param>
		public static void UpdateThirdCustomer(int @iD, string @customerName, string @phoneNumber, string @projectName, string @roomName, DateTime @signDate, DateTime @addTime, int @addUserID, DateTime @lastSendTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateThirdCustomer(@iD, @customerName, @phoneNumber, @projectName, @roomName, @signDate, @addTime, @addUserID, @lastSendTime, helper);
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
		/// Updates a ThirdCustomer into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="customerName">customerName</param>
		/// <param name="phoneNumber">phoneNumber</param>
		/// <param name="projectName">projectName</param>
		/// <param name="roomName">roomName</param>
		/// <param name="signDate">signDate</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserID">addUserID</param>
		/// <param name="lastSendTime">lastSendTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateThirdCustomer(int @iD, string @customerName, string @phoneNumber, string @projectName, string @roomName, DateTime @signDate, DateTime @addTime, int @addUserID, DateTime @lastSendTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[CustomerName] nvarchar(100),
	[PhoneNumber] nvarchar(50),
	[ProjectName] nvarchar(100),
	[RoomName] nvarchar(100),
	[SignDate] datetime,
	[AddTime] datetime,
	[AddUserID] int,
	[LastSendTime] datetime
);

UPDATE [dbo].[ThirdCustomer] SET 
	[ThirdCustomer].[CustomerName] = @CustomerName,
	[ThirdCustomer].[PhoneNumber] = @PhoneNumber,
	[ThirdCustomer].[ProjectName] = @ProjectName,
	[ThirdCustomer].[RoomName] = @RoomName,
	[ThirdCustomer].[SignDate] = @SignDate,
	[ThirdCustomer].[AddTime] = @AddTime,
	[ThirdCustomer].[AddUserID] = @AddUserID,
	[ThirdCustomer].[LastSendTime] = @LastSendTime 
output 
	INSERTED.[ID],
	INSERTED.[CustomerName],
	INSERTED.[PhoneNumber],
	INSERTED.[ProjectName],
	INSERTED.[RoomName],
	INSERTED.[SignDate],
	INSERTED.[AddTime],
	INSERTED.[AddUserID],
	INSERTED.[LastSendTime]
into @table
WHERE 
	[ThirdCustomer].[ID] = @ID

SELECT 
	[ID],
	[CustomerName],
	[PhoneNumber],
	[ProjectName],
	[RoomName],
	[SignDate],
	[AddTime],
	[AddUserID],
	[LastSendTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@CustomerName", EntityBase.GetDatabaseValue(@customerName)));
			parameters.Add(new SqlParameter("@PhoneNumber", EntityBase.GetDatabaseValue(@phoneNumber)));
			parameters.Add(new SqlParameter("@ProjectName", EntityBase.GetDatabaseValue(@projectName)));
			parameters.Add(new SqlParameter("@RoomName", EntityBase.GetDatabaseValue(@roomName)));
			parameters.Add(new SqlParameter("@SignDate", EntityBase.GetDatabaseValue(@signDate)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserID", EntityBase.GetDatabaseValue(@addUserID)));
			parameters.Add(new SqlParameter("@LastSendTime", EntityBase.GetDatabaseValue(@lastSendTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ThirdCustomer from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteThirdCustomer(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteThirdCustomer(@iD, helper);
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
		/// Deletes a ThirdCustomer from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteThirdCustomer(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ThirdCustomer]
WHERE 
	[ThirdCustomer].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ThirdCustomer object.
		/// </summary>
		/// <returns>The newly created ThirdCustomer object.</returns>
		public static ThirdCustomer CreateThirdCustomer()
		{
			return InitializeNew<ThirdCustomer>();
		}
		
		/// <summary>
		/// Retrieve information for a ThirdCustomer by a ThirdCustomer's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ThirdCustomer</returns>
		public static ThirdCustomer GetThirdCustomer(int @iD)
		{
			string commandText = @"
SELECT 
" + ThirdCustomer.SelectFieldList + @"
FROM [dbo].[ThirdCustomer] 
WHERE 
	[ThirdCustomer].[ID] = @ID " + ThirdCustomer.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ThirdCustomer>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ThirdCustomer by a ThirdCustomer's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ThirdCustomer</returns>
		public static ThirdCustomer GetThirdCustomer(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ThirdCustomer.SelectFieldList + @"
FROM [dbo].[ThirdCustomer] 
WHERE 
	[ThirdCustomer].[ID] = @ID " + ThirdCustomer.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ThirdCustomer>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ThirdCustomer objects.
		/// </summary>
		/// <returns>The retrieved collection of ThirdCustomer objects.</returns>
		public static EntityList<ThirdCustomer> GetThirdCustomers()
		{
			string commandText = @"
SELECT " + ThirdCustomer.SelectFieldList + "FROM [dbo].[ThirdCustomer] " + ThirdCustomer.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ThirdCustomer>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ThirdCustomer objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ThirdCustomer objects.</returns>
        public static EntityList<ThirdCustomer> GetThirdCustomers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ThirdCustomer>(SelectFieldList, "FROM [dbo].[ThirdCustomer]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ThirdCustomer objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ThirdCustomer objects.</returns>
        public static EntityList<ThirdCustomer> GetThirdCustomers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ThirdCustomer>(SelectFieldList, "FROM [dbo].[ThirdCustomer]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ThirdCustomer objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ThirdCustomer objects.</returns>
		protected static EntityList<ThirdCustomer> GetThirdCustomers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetThirdCustomers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ThirdCustomer objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ThirdCustomer objects.</returns>
		protected static EntityList<ThirdCustomer> GetThirdCustomers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetThirdCustomers(string.Empty, where, parameters, ThirdCustomer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ThirdCustomer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ThirdCustomer objects.</returns>
		protected static EntityList<ThirdCustomer> GetThirdCustomers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetThirdCustomers(prefix, where, parameters, ThirdCustomer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ThirdCustomer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ThirdCustomer objects.</returns>
		protected static EntityList<ThirdCustomer> GetThirdCustomers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetThirdCustomers(string.Empty, where, parameters, ThirdCustomer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ThirdCustomer objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ThirdCustomer objects.</returns>
		protected static EntityList<ThirdCustomer> GetThirdCustomers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetThirdCustomers(prefix, where, parameters, ThirdCustomer.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ThirdCustomer objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ThirdCustomer objects.</returns>
		protected static EntityList<ThirdCustomer> GetThirdCustomers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ThirdCustomer.SelectFieldList + "FROM [dbo].[ThirdCustomer] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ThirdCustomer>(reader);
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
        protected static EntityList<ThirdCustomer> GetThirdCustomers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ThirdCustomer>(SelectFieldList, "FROM [dbo].[ThirdCustomer] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ThirdCustomer objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetThirdCustomerCount()
        {
            return GetThirdCustomerCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ThirdCustomer objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetThirdCustomerCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ThirdCustomer] " + where;

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
		public static partial class ThirdCustomer_Properties
		{
			public const string ID = "ID";
			public const string CustomerName = "CustomerName";
			public const string PhoneNumber = "PhoneNumber";
			public const string ProjectName = "ProjectName";
			public const string RoomName = "RoomName";
			public const string SignDate = "SignDate";
			public const string AddTime = "AddTime";
			public const string AddUserID = "AddUserID";
			public const string LastSendTime = "LastSendTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"CustomerName" , "string:"},
    			 {"PhoneNumber" , "string:"},
    			 {"ProjectName" , "string:"},
    			 {"RoomName" , "string:"},
    			 {"SignDate" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserID" , "int:"},
    			 {"LastSendTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
