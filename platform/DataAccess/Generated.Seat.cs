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
	/// This object represents the properties and methods of a Seat.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Seat 
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
		private int _userID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int UserID
		{
			[DebuggerStepThrough()]
			get { return this._userID; }
			set 
			{
				if (this._userID != value) 
				{
					this._userID = value;
					this.IsDirty = true;	
					OnPropertyChanged("UserID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _seatName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SeatName
		{
			[DebuggerStepThrough()]
			get { return this._seatName; }
			set 
			{
				if (this._seatName != value) 
				{
					this._seatName = value;
					this.IsDirty = true;	
					OnPropertyChanged("SeatName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _seatStatus = int.MinValue;
		/// <summary>
		/// 1-正常 2-异常
		/// </summary>
        [Description("1-正常 2-异常")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int SeatStatus
		{
			[DebuggerStepThrough()]
			get { return this._seatStatus; }
			set 
			{
				if (this._seatStatus != value) 
				{
					this._seatStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("SeatStatus");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _driverStatus = int.MinValue;
		/// <summary>
		/// 1-正常 2-异常
		/// </summary>
        [Description("1-正常 2-异常")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int DriverStatus
		{
			[DebuggerStepThrough()]
			get { return this._driverStatus; }
			set 
			{
				if (this._driverStatus != value) 
				{
					this._driverStatus = value;
					this.IsDirty = true;	
					OnPropertyChanged("DriverStatus");
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
		private string _recordLocation = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RecordLocation
		{
			[DebuggerStepThrough()]
			get { return this._recordLocation; }
			set 
			{
				if (this._recordLocation != value) 
				{
					this._recordLocation = value;
					this.IsDirty = true;	
					OnPropertyChanged("RecordLocation");
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
	[UserID] int,
	[SeatName] nvarchar(100),
	[SeatStatus] int,
	[DriverStatus] int,
	[AddTime] datetime,
	[RecordLocation] nvarchar(500)
);

INSERT INTO [dbo].[Seat] (
	[Seat].[UserID],
	[Seat].[SeatName],
	[Seat].[SeatStatus],
	[Seat].[DriverStatus],
	[Seat].[AddTime],
	[Seat].[RecordLocation]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[SeatName],
	INSERTED.[SeatStatus],
	INSERTED.[DriverStatus],
	INSERTED.[AddTime],
	INSERTED.[RecordLocation]
into @table
VALUES ( 
	@UserID,
	@SeatName,
	@SeatStatus,
	@DriverStatus,
	@AddTime,
	@RecordLocation 
); 

SELECT 
	[ID],
	[UserID],
	[SeatName],
	[SeatStatus],
	[DriverStatus],
	[AddTime],
	[RecordLocation] 
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
	[UserID] int,
	[SeatName] nvarchar(100),
	[SeatStatus] int,
	[DriverStatus] int,
	[AddTime] datetime,
	[RecordLocation] nvarchar(500)
);

UPDATE [dbo].[Seat] SET 
	[Seat].[UserID] = @UserID,
	[Seat].[SeatName] = @SeatName,
	[Seat].[SeatStatus] = @SeatStatus,
	[Seat].[DriverStatus] = @DriverStatus,
	[Seat].[AddTime] = @AddTime,
	[Seat].[RecordLocation] = @RecordLocation 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[SeatName],
	INSERTED.[SeatStatus],
	INSERTED.[DriverStatus],
	INSERTED.[AddTime],
	INSERTED.[RecordLocation]
into @table
WHERE 
	[Seat].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[SeatName],
	[SeatStatus],
	[DriverStatus],
	[AddTime],
	[RecordLocation] 
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
DELETE FROM [dbo].[Seat]
WHERE 
	[Seat].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Seat() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSeat(this.ID));
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
	[Seat].[ID],
	[Seat].[UserID],
	[Seat].[SeatName],
	[Seat].[SeatStatus],
	[Seat].[DriverStatus],
	[Seat].[AddTime],
	[Seat].[RecordLocation]
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
                return "Seat";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Seat into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="seatName">seatName</param>
		/// <param name="seatStatus">seatStatus</param>
		/// <param name="driverStatus">driverStatus</param>
		/// <param name="addTime">addTime</param>
		/// <param name="recordLocation">recordLocation</param>
		public static void InsertSeat(int @userID, string @seatName, int @seatStatus, int @driverStatus, DateTime @addTime, string @recordLocation)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSeat(@userID, @seatName, @seatStatus, @driverStatus, @addTime, @recordLocation, helper);
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
		/// Insert a Seat into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="userID">userID</param>
		/// <param name="seatName">seatName</param>
		/// <param name="seatStatus">seatStatus</param>
		/// <param name="driverStatus">driverStatus</param>
		/// <param name="addTime">addTime</param>
		/// <param name="recordLocation">recordLocation</param>
		/// <param name="helper">helper</param>
		internal static void InsertSeat(int @userID, string @seatName, int @seatStatus, int @driverStatus, DateTime @addTime, string @recordLocation, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[SeatName] nvarchar(100),
	[SeatStatus] int,
	[DriverStatus] int,
	[AddTime] datetime,
	[RecordLocation] nvarchar(500)
);

INSERT INTO [dbo].[Seat] (
	[Seat].[UserID],
	[Seat].[SeatName],
	[Seat].[SeatStatus],
	[Seat].[DriverStatus],
	[Seat].[AddTime],
	[Seat].[RecordLocation]
) 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[SeatName],
	INSERTED.[SeatStatus],
	INSERTED.[DriverStatus],
	INSERTED.[AddTime],
	INSERTED.[RecordLocation]
into @table
VALUES ( 
	@UserID,
	@SeatName,
	@SeatStatus,
	@DriverStatus,
	@AddTime,
	@RecordLocation 
); 

SELECT 
	[ID],
	[UserID],
	[SeatName],
	[SeatStatus],
	[DriverStatus],
	[AddTime],
	[RecordLocation] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SeatName", EntityBase.GetDatabaseValue(@seatName)));
			parameters.Add(new SqlParameter("@SeatStatus", EntityBase.GetDatabaseValue(@seatStatus)));
			parameters.Add(new SqlParameter("@DriverStatus", EntityBase.GetDatabaseValue(@driverStatus)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RecordLocation", EntityBase.GetDatabaseValue(@recordLocation)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Seat into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="seatName">seatName</param>
		/// <param name="seatStatus">seatStatus</param>
		/// <param name="driverStatus">driverStatus</param>
		/// <param name="addTime">addTime</param>
		/// <param name="recordLocation">recordLocation</param>
		public static void UpdateSeat(int @iD, int @userID, string @seatName, int @seatStatus, int @driverStatus, DateTime @addTime, string @recordLocation)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSeat(@iD, @userID, @seatName, @seatStatus, @driverStatus, @addTime, @recordLocation, helper);
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
		/// Updates a Seat into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="userID">userID</param>
		/// <param name="seatName">seatName</param>
		/// <param name="seatStatus">seatStatus</param>
		/// <param name="driverStatus">driverStatus</param>
		/// <param name="addTime">addTime</param>
		/// <param name="recordLocation">recordLocation</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSeat(int @iD, int @userID, string @seatName, int @seatStatus, int @driverStatus, DateTime @addTime, string @recordLocation, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[UserID] int,
	[SeatName] nvarchar(100),
	[SeatStatus] int,
	[DriverStatus] int,
	[AddTime] datetime,
	[RecordLocation] nvarchar(500)
);

UPDATE [dbo].[Seat] SET 
	[Seat].[UserID] = @UserID,
	[Seat].[SeatName] = @SeatName,
	[Seat].[SeatStatus] = @SeatStatus,
	[Seat].[DriverStatus] = @DriverStatus,
	[Seat].[AddTime] = @AddTime,
	[Seat].[RecordLocation] = @RecordLocation 
output 
	INSERTED.[ID],
	INSERTED.[UserID],
	INSERTED.[SeatName],
	INSERTED.[SeatStatus],
	INSERTED.[DriverStatus],
	INSERTED.[AddTime],
	INSERTED.[RecordLocation]
into @table
WHERE 
	[Seat].[ID] = @ID

SELECT 
	[ID],
	[UserID],
	[SeatName],
	[SeatStatus],
	[DriverStatus],
	[AddTime],
	[RecordLocation] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			parameters.Add(new SqlParameter("@SeatName", EntityBase.GetDatabaseValue(@seatName)));
			parameters.Add(new SqlParameter("@SeatStatus", EntityBase.GetDatabaseValue(@seatStatus)));
			parameters.Add(new SqlParameter("@DriverStatus", EntityBase.GetDatabaseValue(@driverStatus)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@RecordLocation", EntityBase.GetDatabaseValue(@recordLocation)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Seat from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSeat(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSeat(@iD, helper);
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
		/// Deletes a Seat from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSeat(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Seat]
WHERE 
	[Seat].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Seat object.
		/// </summary>
		/// <returns>The newly created Seat object.</returns>
		public static Seat CreateSeat()
		{
			return InitializeNew<Seat>();
		}
		
		/// <summary>
		/// Retrieve information for a Seat by a Seat's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Seat</returns>
		public static Seat GetSeat(int @iD)
		{
			string commandText = @"
SELECT 
" + Seat.SelectFieldList + @"
FROM [dbo].[Seat] 
WHERE 
	[Seat].[ID] = @ID " + Seat.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Seat>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Seat by a Seat's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Seat</returns>
		public static Seat GetSeat(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Seat.SelectFieldList + @"
FROM [dbo].[Seat] 
WHERE 
	[Seat].[ID] = @ID " + Seat.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Seat>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Seat objects.
		/// </summary>
		/// <returns>The retrieved collection of Seat objects.</returns>
		public static EntityList<Seat> GetSeats()
		{
			string commandText = @"
SELECT " + Seat.SelectFieldList + "FROM [dbo].[Seat] " + Seat.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Seat>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Seat objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Seat objects.</returns>
        public static EntityList<Seat> GetSeats(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Seat>(SelectFieldList, "FROM [dbo].[Seat]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Seat objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Seat objects.</returns>
        public static EntityList<Seat> GetSeats(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Seat>(SelectFieldList, "FROM [dbo].[Seat]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Seat objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Seat objects.</returns>
		protected static EntityList<Seat> GetSeats(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSeats(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Seat objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Seat objects.</returns>
		protected static EntityList<Seat> GetSeats(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSeats(string.Empty, where, parameters, Seat.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Seat objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Seat objects.</returns>
		protected static EntityList<Seat> GetSeats(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSeats(prefix, where, parameters, Seat.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Seat objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Seat objects.</returns>
		protected static EntityList<Seat> GetSeats(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSeats(string.Empty, where, parameters, Seat.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Seat objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Seat objects.</returns>
		protected static EntityList<Seat> GetSeats(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSeats(prefix, where, parameters, Seat.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Seat objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Seat objects.</returns>
		protected static EntityList<Seat> GetSeats(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Seat.SelectFieldList + "FROM [dbo].[Seat] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Seat>(reader);
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
        protected static EntityList<Seat> GetSeats(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Seat>(SelectFieldList, "FROM [dbo].[Seat] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Seat objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSeatCount()
        {
            return GetSeatCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Seat objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSeatCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Seat] " + where;

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
		public static partial class Seat_Properties
		{
			public const string ID = "ID";
			public const string UserID = "UserID";
			public const string SeatName = "SeatName";
			public const string SeatStatus = "SeatStatus";
			public const string DriverStatus = "DriverStatus";
			public const string AddTime = "AddTime";
			public const string RecordLocation = "RecordLocation";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"UserID" , "int:"},
    			 {"SeatName" , "string:"},
    			 {"SeatStatus" , "int:1-正常 2-异常"},
    			 {"DriverStatus" , "int:1-正常 2-异常"},
    			 {"AddTime" , "DateTime:"},
    			 {"RecordLocation" , "string:"},
            };
		}
		#endregion
	}
}
