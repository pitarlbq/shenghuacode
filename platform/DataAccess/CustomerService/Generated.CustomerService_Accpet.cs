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
	/// This object represents the properties and methods of a CustomerService_Accpet.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class CustomerService_Accpet 
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
		private int _serviceID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ServiceID
		{
			[DebuggerStepThrough()]
			get { return this._serviceID; }
			set 
			{
				if (this._serviceID != value) 
				{
					this._serviceID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ServiceID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _accpetManID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int AccpetManID
		{
			[DebuggerStepThrough()]
			get { return this._accpetManID; }
			set 
			{
				if (this._accpetManID != value) 
				{
					this._accpetManID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetManID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _accpetMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AccpetMan
		{
			[DebuggerStepThrough()]
			get { return this._accpetMan; }
			set 
			{
				if (this._accpetMan != value) 
				{
					this._accpetMan = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetMan");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _appointTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AppointTime
		{
			[DebuggerStepThrough()]
			get { return this._appointTime; }
			set 
			{
				if (this._appointTime != value) 
				{
					this._appointTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AppointTime");
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
		private int _accpetStatus = int.MinValue;
		/// <summary>
		/// 1-已接单 0-未接单 2-已转单
		/// </summary>
        [Description("1-已接单 0-未接单 2-已转单")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AccpetStatus
		{
			[DebuggerStepThrough()]
			get { return this._accpetStatus; }
			set 
			{
				if (this._accpetStatus != value) 
				{
					this._accpetStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _accpetUserType = int.MinValue;
		/// <summary>
		/// 1-接单人 2-处理人
		/// </summary>
        [Description("1-接单人 2-处理人")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int AccpetUserType
		{
			[DebuggerStepThrough()]
			get { return this._accpetUserType; }
			set 
			{
				if (this._accpetUserType != value) 
				{
					this._accpetUserType = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetUserType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _accpetTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime AccpetTime
		{
			[DebuggerStepThrough()]
			get { return this._accpetTime; }
			set 
			{
				if (this._accpetTime != value) 
				{
					this._accpetTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccpetTime");
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
	[ServiceID] int,
	[AccpetManID] int,
	[AccpetMan] nvarchar(50),
	[AppointTime] datetime,
	[AddTime] datetime,
	[AccpetStatus] int,
	[AccpetUserType] int,
	[AccpetTime] datetime
);

INSERT INTO [dbo].[CustomerService_Accpet] (
	[CustomerService_Accpet].[ServiceID],
	[CustomerService_Accpet].[AccpetManID],
	[CustomerService_Accpet].[AccpetMan],
	[CustomerService_Accpet].[AppointTime],
	[CustomerService_Accpet].[AddTime],
	[CustomerService_Accpet].[AccpetStatus],
	[CustomerService_Accpet].[AccpetUserType],
	[CustomerService_Accpet].[AccpetTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[AccpetManID],
	INSERTED.[AccpetMan],
	INSERTED.[AppointTime],
	INSERTED.[AddTime],
	INSERTED.[AccpetStatus],
	INSERTED.[AccpetUserType],
	INSERTED.[AccpetTime]
into @table
VALUES ( 
	@ServiceID,
	@AccpetManID,
	@AccpetMan,
	@AppointTime,
	@AddTime,
	@AccpetStatus,
	@AccpetUserType,
	@AccpetTime 
); 

SELECT 
	[ID],
	[ServiceID],
	[AccpetManID],
	[AccpetMan],
	[AppointTime],
	[AddTime],
	[AccpetStatus],
	[AccpetUserType],
	[AccpetTime] 
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
	[ServiceID] int,
	[AccpetManID] int,
	[AccpetMan] nvarchar(50),
	[AppointTime] datetime,
	[AddTime] datetime,
	[AccpetStatus] int,
	[AccpetUserType] int,
	[AccpetTime] datetime
);

UPDATE [dbo].[CustomerService_Accpet] SET 
	[CustomerService_Accpet].[ServiceID] = @ServiceID,
	[CustomerService_Accpet].[AccpetManID] = @AccpetManID,
	[CustomerService_Accpet].[AccpetMan] = @AccpetMan,
	[CustomerService_Accpet].[AppointTime] = @AppointTime,
	[CustomerService_Accpet].[AddTime] = @AddTime,
	[CustomerService_Accpet].[AccpetStatus] = @AccpetStatus,
	[CustomerService_Accpet].[AccpetUserType] = @AccpetUserType,
	[CustomerService_Accpet].[AccpetTime] = @AccpetTime 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[AccpetManID],
	INSERTED.[AccpetMan],
	INSERTED.[AppointTime],
	INSERTED.[AddTime],
	INSERTED.[AccpetStatus],
	INSERTED.[AccpetUserType],
	INSERTED.[AccpetTime]
into @table
WHERE 
	[CustomerService_Accpet].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[AccpetManID],
	[AccpetMan],
	[AppointTime],
	[AddTime],
	[AccpetStatus],
	[AccpetUserType],
	[AccpetTime] 
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
DELETE FROM [dbo].[CustomerService_Accpet]
WHERE 
	[CustomerService_Accpet].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public CustomerService_Accpet() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetCustomerService_Accpet(this.ID));
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
	[CustomerService_Accpet].[ID],
	[CustomerService_Accpet].[ServiceID],
	[CustomerService_Accpet].[AccpetManID],
	[CustomerService_Accpet].[AccpetMan],
	[CustomerService_Accpet].[AppointTime],
	[CustomerService_Accpet].[AddTime],
	[CustomerService_Accpet].[AccpetStatus],
	[CustomerService_Accpet].[AccpetUserType],
	[CustomerService_Accpet].[AccpetTime]
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
                return "CustomerService_Accpet";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a CustomerService_Accpet into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="accpetManID">accpetManID</param>
		/// <param name="accpetMan">accpetMan</param>
		/// <param name="appointTime">appointTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="accpetStatus">accpetStatus</param>
		/// <param name="accpetUserType">accpetUserType</param>
		/// <param name="accpetTime">accpetTime</param>
		public static void InsertCustomerService_Accpet(int @serviceID, int @accpetManID, string @accpetMan, DateTime @appointTime, DateTime @addTime, int @accpetStatus, int @accpetUserType, DateTime @accpetTime)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertCustomerService_Accpet(@serviceID, @accpetManID, @accpetMan, @appointTime, @addTime, @accpetStatus, @accpetUserType, @accpetTime, helper);
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
		/// Insert a CustomerService_Accpet into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="accpetManID">accpetManID</param>
		/// <param name="accpetMan">accpetMan</param>
		/// <param name="appointTime">appointTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="accpetStatus">accpetStatus</param>
		/// <param name="accpetUserType">accpetUserType</param>
		/// <param name="accpetTime">accpetTime</param>
		/// <param name="helper">helper</param>
		internal static void InsertCustomerService_Accpet(int @serviceID, int @accpetManID, string @accpetMan, DateTime @appointTime, DateTime @addTime, int @accpetStatus, int @accpetUserType, DateTime @accpetTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[AccpetManID] int,
	[AccpetMan] nvarchar(50),
	[AppointTime] datetime,
	[AddTime] datetime,
	[AccpetStatus] int,
	[AccpetUserType] int,
	[AccpetTime] datetime
);

INSERT INTO [dbo].[CustomerService_Accpet] (
	[CustomerService_Accpet].[ServiceID],
	[CustomerService_Accpet].[AccpetManID],
	[CustomerService_Accpet].[AccpetMan],
	[CustomerService_Accpet].[AppointTime],
	[CustomerService_Accpet].[AddTime],
	[CustomerService_Accpet].[AccpetStatus],
	[CustomerService_Accpet].[AccpetUserType],
	[CustomerService_Accpet].[AccpetTime]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[AccpetManID],
	INSERTED.[AccpetMan],
	INSERTED.[AppointTime],
	INSERTED.[AddTime],
	INSERTED.[AccpetStatus],
	INSERTED.[AccpetUserType],
	INSERTED.[AccpetTime]
into @table
VALUES ( 
	@ServiceID,
	@AccpetManID,
	@AccpetMan,
	@AppointTime,
	@AddTime,
	@AccpetStatus,
	@AccpetUserType,
	@AccpetTime 
); 

SELECT 
	[ID],
	[ServiceID],
	[AccpetManID],
	[AccpetMan],
	[AppointTime],
	[AddTime],
	[AccpetStatus],
	[AccpetUserType],
	[AccpetTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@AccpetManID", EntityBase.GetDatabaseValue(@accpetManID)));
			parameters.Add(new SqlParameter("@AccpetMan", EntityBase.GetDatabaseValue(@accpetMan)));
			parameters.Add(new SqlParameter("@AppointTime", EntityBase.GetDatabaseValue(@appointTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AccpetStatus", EntityBase.GetDatabaseValue(@accpetStatus)));
			parameters.Add(new SqlParameter("@AccpetUserType", EntityBase.GetDatabaseValue(@accpetUserType)));
			parameters.Add(new SqlParameter("@AccpetTime", EntityBase.GetDatabaseValue(@accpetTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a CustomerService_Accpet into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="accpetManID">accpetManID</param>
		/// <param name="accpetMan">accpetMan</param>
		/// <param name="appointTime">appointTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="accpetStatus">accpetStatus</param>
		/// <param name="accpetUserType">accpetUserType</param>
		/// <param name="accpetTime">accpetTime</param>
		public static void UpdateCustomerService_Accpet(int @iD, int @serviceID, int @accpetManID, string @accpetMan, DateTime @appointTime, DateTime @addTime, int @accpetStatus, int @accpetUserType, DateTime @accpetTime)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateCustomerService_Accpet(@iD, @serviceID, @accpetManID, @accpetMan, @appointTime, @addTime, @accpetStatus, @accpetUserType, @accpetTime, helper);
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
		/// Updates a CustomerService_Accpet into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="accpetManID">accpetManID</param>
		/// <param name="accpetMan">accpetMan</param>
		/// <param name="appointTime">appointTime</param>
		/// <param name="addTime">addTime</param>
		/// <param name="accpetStatus">accpetStatus</param>
		/// <param name="accpetUserType">accpetUserType</param>
		/// <param name="accpetTime">accpetTime</param>
		/// <param name="helper">helper</param>
		internal static void UpdateCustomerService_Accpet(int @iD, int @serviceID, int @accpetManID, string @accpetMan, DateTime @appointTime, DateTime @addTime, int @accpetStatus, int @accpetUserType, DateTime @accpetTime, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[AccpetManID] int,
	[AccpetMan] nvarchar(50),
	[AppointTime] datetime,
	[AddTime] datetime,
	[AccpetStatus] int,
	[AccpetUserType] int,
	[AccpetTime] datetime
);

UPDATE [dbo].[CustomerService_Accpet] SET 
	[CustomerService_Accpet].[ServiceID] = @ServiceID,
	[CustomerService_Accpet].[AccpetManID] = @AccpetManID,
	[CustomerService_Accpet].[AccpetMan] = @AccpetMan,
	[CustomerService_Accpet].[AppointTime] = @AppointTime,
	[CustomerService_Accpet].[AddTime] = @AddTime,
	[CustomerService_Accpet].[AccpetStatus] = @AccpetStatus,
	[CustomerService_Accpet].[AccpetUserType] = @AccpetUserType,
	[CustomerService_Accpet].[AccpetTime] = @AccpetTime 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[AccpetManID],
	INSERTED.[AccpetMan],
	INSERTED.[AppointTime],
	INSERTED.[AddTime],
	INSERTED.[AccpetStatus],
	INSERTED.[AccpetUserType],
	INSERTED.[AccpetTime]
into @table
WHERE 
	[CustomerService_Accpet].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[AccpetManID],
	[AccpetMan],
	[AppointTime],
	[AddTime],
	[AccpetStatus],
	[AccpetUserType],
	[AccpetTime] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@AccpetManID", EntityBase.GetDatabaseValue(@accpetManID)));
			parameters.Add(new SqlParameter("@AccpetMan", EntityBase.GetDatabaseValue(@accpetMan)));
			parameters.Add(new SqlParameter("@AppointTime", EntityBase.GetDatabaseValue(@appointTime)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AccpetStatus", EntityBase.GetDatabaseValue(@accpetStatus)));
			parameters.Add(new SqlParameter("@AccpetUserType", EntityBase.GetDatabaseValue(@accpetUserType)));
			parameters.Add(new SqlParameter("@AccpetTime", EntityBase.GetDatabaseValue(@accpetTime)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a CustomerService_Accpet from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteCustomerService_Accpet(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteCustomerService_Accpet(@iD, helper);
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
		/// Deletes a CustomerService_Accpet from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteCustomerService_Accpet(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[CustomerService_Accpet]
WHERE 
	[CustomerService_Accpet].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new CustomerService_Accpet object.
		/// </summary>
		/// <returns>The newly created CustomerService_Accpet object.</returns>
		public static CustomerService_Accpet CreateCustomerService_Accpet()
		{
			return InitializeNew<CustomerService_Accpet>();
		}
		
		/// <summary>
		/// Retrieve information for a CustomerService_Accpet by a CustomerService_Accpet's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>CustomerService_Accpet</returns>
		public static CustomerService_Accpet GetCustomerService_Accpet(int @iD)
		{
			string commandText = @"
SELECT 
" + CustomerService_Accpet.SelectFieldList + @"
FROM [dbo].[CustomerService_Accpet] 
WHERE 
	[CustomerService_Accpet].[ID] = @ID " + CustomerService_Accpet.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService_Accpet>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a CustomerService_Accpet by a CustomerService_Accpet's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>CustomerService_Accpet</returns>
		public static CustomerService_Accpet GetCustomerService_Accpet(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + CustomerService_Accpet.SelectFieldList + @"
FROM [dbo].[CustomerService_Accpet] 
WHERE 
	[CustomerService_Accpet].[ID] = @ID " + CustomerService_Accpet.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<CustomerService_Accpet>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Accpet objects.
		/// </summary>
		/// <returns>The retrieved collection of CustomerService_Accpet objects.</returns>
		public static EntityList<CustomerService_Accpet> GetCustomerService_Accpets()
		{
			string commandText = @"
SELECT " + CustomerService_Accpet.SelectFieldList + "FROM [dbo].[CustomerService_Accpet] " + CustomerService_Accpet.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<CustomerService_Accpet>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection CustomerService_Accpet objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_Accpet objects.</returns>
        public static EntityList<CustomerService_Accpet> GetCustomerService_Accpets(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Accpet>(SelectFieldList, "FROM [dbo].[CustomerService_Accpet]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection CustomerService_Accpet objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of CustomerService_Accpet objects.</returns>
        public static EntityList<CustomerService_Accpet> GetCustomerService_Accpets(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Accpet>(SelectFieldList, "FROM [dbo].[CustomerService_Accpet]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection CustomerService_Accpet objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_Accpet objects.</returns>
		protected static EntityList<CustomerService_Accpet> GetCustomerService_Accpets(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Accpets(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Accpet objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Accpet objects.</returns>
		protected static EntityList<CustomerService_Accpet> GetCustomerService_Accpets(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Accpets(string.Empty, where, parameters, CustomerService_Accpet.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Accpet objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Accpet objects.</returns>
		protected static EntityList<CustomerService_Accpet> GetCustomerService_Accpets(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetCustomerService_Accpets(prefix, where, parameters, CustomerService_Accpet.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Accpet objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Accpet objects.</returns>
		protected static EntityList<CustomerService_Accpet> GetCustomerService_Accpets(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_Accpets(string.Empty, where, parameters, CustomerService_Accpet.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Accpet objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of CustomerService_Accpet objects.</returns>
		protected static EntityList<CustomerService_Accpet> GetCustomerService_Accpets(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetCustomerService_Accpets(prefix, where, parameters, CustomerService_Accpet.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection CustomerService_Accpet objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of CustomerService_Accpet objects.</returns>
		protected static EntityList<CustomerService_Accpet> GetCustomerService_Accpets(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + CustomerService_Accpet.SelectFieldList + "FROM [dbo].[CustomerService_Accpet] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<CustomerService_Accpet>(reader);
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
        protected static EntityList<CustomerService_Accpet> GetCustomerService_Accpets(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<CustomerService_Accpet>(SelectFieldList, "FROM [dbo].[CustomerService_Accpet] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of CustomerService_Accpet objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_AccpetCount()
        {
            return GetCustomerService_AccpetCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of CustomerService_Accpet objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetCustomerService_AccpetCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[CustomerService_Accpet] " + where;

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
		public static partial class CustomerService_Accpet_Properties
		{
			public const string ID = "ID";
			public const string ServiceID = "ServiceID";
			public const string AccpetManID = "AccpetManID";
			public const string AccpetMan = "AccpetMan";
			public const string AppointTime = "AppointTime";
			public const string AddTime = "AddTime";
			public const string AccpetStatus = "AccpetStatus";
			public const string AccpetUserType = "AccpetUserType";
			public const string AccpetTime = "AccpetTime";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"AccpetManID" , "int:"},
    			 {"AccpetMan" , "string:"},
    			 {"AppointTime" , "DateTime:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AccpetStatus" , "int:1-已接单 0-未接单 2-已转单"},
    			 {"AccpetUserType" , "int:1-接单人 2-处理人"},
    			 {"AccpetTime" , "DateTime:"},
            };
		}
		#endregion
	}
}
