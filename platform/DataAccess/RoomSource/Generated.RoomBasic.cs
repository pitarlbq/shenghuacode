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
	/// This object represents the properties and methods of a RoomBasic.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class RoomBasic 
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
		[DataObjectField(false, false, false)]
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
		private decimal _buildingOutArea = decimal.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public decimal BuildingOutArea
		{
			[DebuggerStepThrough()]
			get { return this._buildingOutArea; }
			set 
			{
				if (this._buildingOutArea != value) 
				{
					this._buildingOutArea = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildingOutArea");
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
		private DateTime _paymentTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PaymentTime
		{
			[DebuggerStepThrough()]
			get { return this._paymentTime; }
			set 
			{
				if (this._paymentTime != value) 
				{
					this._paymentTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("PaymentTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _buildingNumber = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string BuildingNumber
		{
			[DebuggerStepThrough()]
			get { return this._buildingNumber; }
			set 
			{
				if (this._buildingNumber != value) 
				{
					this._buildingNumber = value;
					this.IsDirty = true;	
					OnPropertyChanged("BuildingNumber");
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
		private DateTime _certificateTime = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime CertificateTime
		{
			[DebuggerStepThrough()]
			get { return this._certificateTime; }
			set 
			{
				if (this._certificateTime != value) 
				{
					this._certificateTime = value;
					this.IsDirty = true;	
					OnPropertyChanged("CertificateTime");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomType
		{
			[DebuggerStepThrough()]
			get { return this._roomType; }
			set 
			{
				if (this._roomType != value) 
				{
					this._roomType = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _isJingZhuangXiu = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int IsJingZhuangXiu
		{
			[DebuggerStepThrough()]
			get { return this._isJingZhuangXiu; }
			set 
			{
				if (this._isJingZhuangXiu != value) 
				{
					this._isJingZhuangXiu = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsJingZhuangXiu");
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
	[BuildingOutArea] decimal(18, 3),
	[AddTime] datetime,
	[PaymentTime] datetime,
	[BuildingNumber] nvarchar(50),
	[SignDate] datetime,
	[CertificateTime] datetime,
	[RoomType] nvarchar(50),
	[IsJingZhuangXiu] int
);

INSERT INTO [dbo].[RoomBasic] (
	[RoomBasic].[RoomID],
	[RoomBasic].[BuildingOutArea],
	[RoomBasic].[AddTime],
	[RoomBasic].[PaymentTime],
	[RoomBasic].[BuildingNumber],
	[RoomBasic].[SignDate],
	[RoomBasic].[CertificateTime],
	[RoomBasic].[RoomType],
	[RoomBasic].[IsJingZhuangXiu]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[BuildingOutArea],
	INSERTED.[AddTime],
	INSERTED.[PaymentTime],
	INSERTED.[BuildingNumber],
	INSERTED.[SignDate],
	INSERTED.[CertificateTime],
	INSERTED.[RoomType],
	INSERTED.[IsJingZhuangXiu]
into @table
VALUES ( 
	@RoomID,
	@BuildingOutArea,
	@AddTime,
	@PaymentTime,
	@BuildingNumber,
	@SignDate,
	@CertificateTime,
	@RoomType,
	@IsJingZhuangXiu 
); 

SELECT 
	[ID],
	[RoomID],
	[BuildingOutArea],
	[AddTime],
	[PaymentTime],
	[BuildingNumber],
	[SignDate],
	[CertificateTime],
	[RoomType],
	[IsJingZhuangXiu] 
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
	[BuildingOutArea] decimal(18, 3),
	[AddTime] datetime,
	[PaymentTime] datetime,
	[BuildingNumber] nvarchar(50),
	[SignDate] datetime,
	[CertificateTime] datetime,
	[RoomType] nvarchar(50),
	[IsJingZhuangXiu] int
);

UPDATE [dbo].[RoomBasic] SET 
	[RoomBasic].[RoomID] = @RoomID,
	[RoomBasic].[BuildingOutArea] = @BuildingOutArea,
	[RoomBasic].[AddTime] = @AddTime,
	[RoomBasic].[PaymentTime] = @PaymentTime,
	[RoomBasic].[BuildingNumber] = @BuildingNumber,
	[RoomBasic].[SignDate] = @SignDate,
	[RoomBasic].[CertificateTime] = @CertificateTime,
	[RoomBasic].[RoomType] = @RoomType,
	[RoomBasic].[IsJingZhuangXiu] = @IsJingZhuangXiu 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[BuildingOutArea],
	INSERTED.[AddTime],
	INSERTED.[PaymentTime],
	INSERTED.[BuildingNumber],
	INSERTED.[SignDate],
	INSERTED.[CertificateTime],
	INSERTED.[RoomType],
	INSERTED.[IsJingZhuangXiu]
into @table
WHERE 
	[RoomBasic].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[BuildingOutArea],
	[AddTime],
	[PaymentTime],
	[BuildingNumber],
	[SignDate],
	[CertificateTime],
	[RoomType],
	[IsJingZhuangXiu] 
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
DELETE FROM [dbo].[RoomBasic]
WHERE 
	[RoomBasic].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public RoomBasic() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetRoomBasic(this.ID));
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
	[RoomBasic].[ID],
	[RoomBasic].[RoomID],
	[RoomBasic].[BuildingOutArea],
	[RoomBasic].[AddTime],
	[RoomBasic].[PaymentTime],
	[RoomBasic].[BuildingNumber],
	[RoomBasic].[SignDate],
	[RoomBasic].[CertificateTime],
	[RoomBasic].[RoomType],
	[RoomBasic].[IsJingZhuangXiu]
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
                return "RoomBasic";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a RoomBasic into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="buildingOutArea">buildingOutArea</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paymentTime">paymentTime</param>
		/// <param name="buildingNumber">buildingNumber</param>
		/// <param name="signDate">signDate</param>
		/// <param name="certificateTime">certificateTime</param>
		/// <param name="roomType">roomType</param>
		/// <param name="isJingZhuangXiu">isJingZhuangXiu</param>
		public static void InsertRoomBasic(int @roomID, decimal @buildingOutArea, DateTime @addTime, DateTime @paymentTime, string @buildingNumber, DateTime @signDate, DateTime @certificateTime, string @roomType, int @isJingZhuangXiu)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertRoomBasic(@roomID, @buildingOutArea, @addTime, @paymentTime, @buildingNumber, @signDate, @certificateTime, @roomType, @isJingZhuangXiu, helper);
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
		/// Insert a RoomBasic into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="roomID">roomID</param>
		/// <param name="buildingOutArea">buildingOutArea</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paymentTime">paymentTime</param>
		/// <param name="buildingNumber">buildingNumber</param>
		/// <param name="signDate">signDate</param>
		/// <param name="certificateTime">certificateTime</param>
		/// <param name="roomType">roomType</param>
		/// <param name="isJingZhuangXiu">isJingZhuangXiu</param>
		/// <param name="helper">helper</param>
		internal static void InsertRoomBasic(int @roomID, decimal @buildingOutArea, DateTime @addTime, DateTime @paymentTime, string @buildingNumber, DateTime @signDate, DateTime @certificateTime, string @roomType, int @isJingZhuangXiu, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[BuildingOutArea] decimal(18, 3),
	[AddTime] datetime,
	[PaymentTime] datetime,
	[BuildingNumber] nvarchar(50),
	[SignDate] datetime,
	[CertificateTime] datetime,
	[RoomType] nvarchar(50),
	[IsJingZhuangXiu] int
);

INSERT INTO [dbo].[RoomBasic] (
	[RoomBasic].[RoomID],
	[RoomBasic].[BuildingOutArea],
	[RoomBasic].[AddTime],
	[RoomBasic].[PaymentTime],
	[RoomBasic].[BuildingNumber],
	[RoomBasic].[SignDate],
	[RoomBasic].[CertificateTime],
	[RoomBasic].[RoomType],
	[RoomBasic].[IsJingZhuangXiu]
) 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[BuildingOutArea],
	INSERTED.[AddTime],
	INSERTED.[PaymentTime],
	INSERTED.[BuildingNumber],
	INSERTED.[SignDate],
	INSERTED.[CertificateTime],
	INSERTED.[RoomType],
	INSERTED.[IsJingZhuangXiu]
into @table
VALUES ( 
	@RoomID,
	@BuildingOutArea,
	@AddTime,
	@PaymentTime,
	@BuildingNumber,
	@SignDate,
	@CertificateTime,
	@RoomType,
	@IsJingZhuangXiu 
); 

SELECT 
	[ID],
	[RoomID],
	[BuildingOutArea],
	[AddTime],
	[PaymentTime],
	[BuildingNumber],
	[SignDate],
	[CertificateTime],
	[RoomType],
	[IsJingZhuangXiu] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@BuildingOutArea", EntityBase.GetDatabaseValue(@buildingOutArea)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PaymentTime", EntityBase.GetDatabaseValue(@paymentTime)));
			parameters.Add(new SqlParameter("@BuildingNumber", EntityBase.GetDatabaseValue(@buildingNumber)));
			parameters.Add(new SqlParameter("@SignDate", EntityBase.GetDatabaseValue(@signDate)));
			parameters.Add(new SqlParameter("@CertificateTime", EntityBase.GetDatabaseValue(@certificateTime)));
			parameters.Add(new SqlParameter("@RoomType", EntityBase.GetDatabaseValue(@roomType)));
			parameters.Add(new SqlParameter("@IsJingZhuangXiu", EntityBase.GetDatabaseValue(@isJingZhuangXiu)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a RoomBasic into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="buildingOutArea">buildingOutArea</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paymentTime">paymentTime</param>
		/// <param name="buildingNumber">buildingNumber</param>
		/// <param name="signDate">signDate</param>
		/// <param name="certificateTime">certificateTime</param>
		/// <param name="roomType">roomType</param>
		/// <param name="isJingZhuangXiu">isJingZhuangXiu</param>
		public static void UpdateRoomBasic(int @iD, int @roomID, decimal @buildingOutArea, DateTime @addTime, DateTime @paymentTime, string @buildingNumber, DateTime @signDate, DateTime @certificateTime, string @roomType, int @isJingZhuangXiu)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateRoomBasic(@iD, @roomID, @buildingOutArea, @addTime, @paymentTime, @buildingNumber, @signDate, @certificateTime, @roomType, @isJingZhuangXiu, helper);
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
		/// Updates a RoomBasic into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="roomID">roomID</param>
		/// <param name="buildingOutArea">buildingOutArea</param>
		/// <param name="addTime">addTime</param>
		/// <param name="paymentTime">paymentTime</param>
		/// <param name="buildingNumber">buildingNumber</param>
		/// <param name="signDate">signDate</param>
		/// <param name="certificateTime">certificateTime</param>
		/// <param name="roomType">roomType</param>
		/// <param name="isJingZhuangXiu">isJingZhuangXiu</param>
		/// <param name="helper">helper</param>
		internal static void UpdateRoomBasic(int @iD, int @roomID, decimal @buildingOutArea, DateTime @addTime, DateTime @paymentTime, string @buildingNumber, DateTime @signDate, DateTime @certificateTime, string @roomType, int @isJingZhuangXiu, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[RoomID] int,
	[BuildingOutArea] decimal(18, 3),
	[AddTime] datetime,
	[PaymentTime] datetime,
	[BuildingNumber] nvarchar(50),
	[SignDate] datetime,
	[CertificateTime] datetime,
	[RoomType] nvarchar(50),
	[IsJingZhuangXiu] int
);

UPDATE [dbo].[RoomBasic] SET 
	[RoomBasic].[RoomID] = @RoomID,
	[RoomBasic].[BuildingOutArea] = @BuildingOutArea,
	[RoomBasic].[AddTime] = @AddTime,
	[RoomBasic].[PaymentTime] = @PaymentTime,
	[RoomBasic].[BuildingNumber] = @BuildingNumber,
	[RoomBasic].[SignDate] = @SignDate,
	[RoomBasic].[CertificateTime] = @CertificateTime,
	[RoomBasic].[RoomType] = @RoomType,
	[RoomBasic].[IsJingZhuangXiu] = @IsJingZhuangXiu 
output 
	INSERTED.[ID],
	INSERTED.[RoomID],
	INSERTED.[BuildingOutArea],
	INSERTED.[AddTime],
	INSERTED.[PaymentTime],
	INSERTED.[BuildingNumber],
	INSERTED.[SignDate],
	INSERTED.[CertificateTime],
	INSERTED.[RoomType],
	INSERTED.[IsJingZhuangXiu]
into @table
WHERE 
	[RoomBasic].[ID] = @ID

SELECT 
	[ID],
	[RoomID],
	[BuildingOutArea],
	[AddTime],
	[PaymentTime],
	[BuildingNumber],
	[SignDate],
	[CertificateTime],
	[RoomType],
	[IsJingZhuangXiu] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@RoomID", EntityBase.GetDatabaseValue(@roomID)));
			parameters.Add(new SqlParameter("@BuildingOutArea", EntityBase.GetDatabaseValue(@buildingOutArea)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@PaymentTime", EntityBase.GetDatabaseValue(@paymentTime)));
			parameters.Add(new SqlParameter("@BuildingNumber", EntityBase.GetDatabaseValue(@buildingNumber)));
			parameters.Add(new SqlParameter("@SignDate", EntityBase.GetDatabaseValue(@signDate)));
			parameters.Add(new SqlParameter("@CertificateTime", EntityBase.GetDatabaseValue(@certificateTime)));
			parameters.Add(new SqlParameter("@RoomType", EntityBase.GetDatabaseValue(@roomType)));
			parameters.Add(new SqlParameter("@IsJingZhuangXiu", EntityBase.GetDatabaseValue(@isJingZhuangXiu)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a RoomBasic from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteRoomBasic(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteRoomBasic(@iD, helper);
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
		/// Deletes a RoomBasic from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteRoomBasic(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[RoomBasic]
WHERE 
	[RoomBasic].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new RoomBasic object.
		/// </summary>
		/// <returns>The newly created RoomBasic object.</returns>
		public static RoomBasic CreateRoomBasic()
		{
			return InitializeNew<RoomBasic>();
		}
		
		/// <summary>
		/// Retrieve information for a RoomBasic by a RoomBasic's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>RoomBasic</returns>
		public static RoomBasic GetRoomBasic(int @iD)
		{
			string commandText = @"
SELECT 
" + RoomBasic.SelectFieldList + @"
FROM [dbo].[RoomBasic] 
WHERE 
	[RoomBasic].[ID] = @ID " + RoomBasic.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomBasic>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a RoomBasic by a RoomBasic's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>RoomBasic</returns>
		public static RoomBasic GetRoomBasic(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + RoomBasic.SelectFieldList + @"
FROM [dbo].[RoomBasic] 
WHERE 
	[RoomBasic].[ID] = @ID " + RoomBasic.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<RoomBasic>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects.
		/// </summary>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		public static EntityList<RoomBasic> GetRoomBasics()
		{
			string commandText = @"
SELECT " + RoomBasic.SelectFieldList + "FROM [dbo].[RoomBasic] " + RoomBasic.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<RoomBasic>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection RoomBasic objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomBasic objects.</returns>
        public static EntityList<RoomBasic> GetRoomBasics(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomBasic>(SelectFieldList, "FROM [dbo].[RoomBasic]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection RoomBasic objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of RoomBasic objects.</returns>
        public static EntityList<RoomBasic> GetRoomBasics(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomBasic>(SelectFieldList, "FROM [dbo].[RoomBasic]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomBasics(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomBasics(string.Empty, where, parameters, RoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetRoomBasics(prefix, where, parameters, RoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomBasics(string.Empty, where, parameters, RoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetRoomBasics(prefix, where, parameters, RoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection RoomBasic objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of RoomBasic objects.</returns>
		protected static EntityList<RoomBasic> GetRoomBasics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + RoomBasic.SelectFieldList + "FROM [dbo].[RoomBasic] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<RoomBasic>(reader);
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
        protected static EntityList<RoomBasic> GetRoomBasics(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<RoomBasic>(SelectFieldList, "FROM [dbo].[RoomBasic] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of RoomBasic objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomBasicCount()
        {
            return GetRoomBasicCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of RoomBasic objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetRoomBasicCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[RoomBasic] " + where;

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
		public static partial class RoomBasic_Properties
		{
			public const string ID = "ID";
			public const string RoomID = "RoomID";
			public const string BuildingOutArea = "BuildingOutArea";
			public const string AddTime = "AddTime";
			public const string PaymentTime = "PaymentTime";
			public const string BuildingNumber = "BuildingNumber";
			public const string SignDate = "SignDate";
			public const string CertificateTime = "CertificateTime";
			public const string RoomType = "RoomType";
			public const string IsJingZhuangXiu = "IsJingZhuangXiu";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"BuildingOutArea" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PaymentTime" , "DateTime:"},
    			 {"BuildingNumber" , "string:"},
    			 {"SignDate" , "DateTime:"},
    			 {"CertificateTime" , "DateTime:"},
    			 {"RoomType" , "string:"},
    			 {"IsJingZhuangXiu" , "int:"},
            };
		}
		#endregion
	}
}
