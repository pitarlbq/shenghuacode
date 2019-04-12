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
	/// This object represents the properties and methods of a Sys_OrderNumber.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Sys_OrderNumber 
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
		private string _orderTypeName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string OrderTypeName
		{
			[DebuggerStepThrough()]
			get { return this._orderTypeName; }
			set 
			{
				if (this._orderTypeName != value) 
				{
					this._orderTypeName = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderTypeName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderNumberCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int OrderNumberCount
		{
			[DebuggerStepThrough()]
			get { return this._orderNumberCount; }
			set 
			{
				if (this._orderNumberCount != value) 
				{
					this._orderNumberCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderNumberCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _useYear = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool UseYear
		{
			[DebuggerStepThrough()]
			get { return this._useYear; }
			set 
			{
				if (this._useYear != value) 
				{
					this._useYear = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseYear");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _useMonth = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool UseMonth
		{
			[DebuggerStepThrough()]
			get { return this._useMonth; }
			set 
			{
				if (this._useMonth != value) 
				{
					this._useMonth = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseMonth");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _useDay = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public bool UseDay
		{
			[DebuggerStepThrough()]
			get { return this._useDay; }
			set 
			{
				if (this._useDay != value) 
				{
					this._useDay = value;
					this.IsDirty = true;	
					OnPropertyChanged("UseDay");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _orderPrefix = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string OrderPrefix
		{
			[DebuggerStepThrough()]
			get { return this._orderPrefix; }
			set 
			{
				if (this._orderPrefix != value) 
				{
					this._orderPrefix = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderPrefix");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _orderPreview = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string OrderPreview
		{
			[DebuggerStepThrough()]
			get { return this._orderPreview; }
			set 
			{
				if (this._orderPreview != value) 
				{
					this._orderPreview = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderPreview");
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
		[DataObjectField(false, false, false)]
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
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _remark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Remark
		{
			[DebuggerStepThrough()]
			get { return this._remark; }
			set 
			{
				if (this._remark != value) 
				{
					this._remark = value;
					this.IsDirty = true;	
					OnPropertyChanged("Remark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _chargeType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int ChargeType
		{
			[DebuggerStepThrough()]
			get { return this._chargeType; }
			set 
			{
				if (this._chargeType != value) 
				{
					this._chargeType = value;
					this.IsDirty = true;	
					OnPropertyChanged("ChargeType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isYearReset = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsYearReset
		{
			[DebuggerStepThrough()]
			get { return this._isYearReset; }
			set 
			{
				if (this._isYearReset != value) 
				{
					this._isYearReset = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsYearReset");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isMonthReset = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsMonthReset
		{
			[DebuggerStepThrough()]
			get { return this._isMonthReset; }
			set 
			{
				if (this._isMonthReset != value) 
				{
					this._isMonthReset = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsMonthReset");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDayReset = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsDayReset
		{
			[DebuggerStepThrough()]
			get { return this._isDayReset; }
			set 
			{
				if (this._isDayReset != value) 
				{
					this._isDayReset = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsDayReset");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _orderNote = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OrderNote
		{
			[DebuggerStepThrough()]
			get { return this._orderNote; }
			set 
			{
				if (this._orderNote != value) 
				{
					this._orderNote = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderNote");
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
	[OrderTypeName] nvarchar(50),
	[OrderNumberCount] int,
	[UseYear] bit,
	[UseMonth] bit,
	[UseDay] bit,
	[OrderPrefix] nvarchar(50),
	[OrderPreview] nvarchar(500),
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[ChargeType] int,
	[IsYearReset] bit,
	[IsMonthReset] bit,
	[IsDayReset] bit,
	[OrderNote] ntext
);

INSERT INTO [dbo].[Sys_OrderNumber] (
	[Sys_OrderNumber].[OrderTypeName],
	[Sys_OrderNumber].[OrderNumberCount],
	[Sys_OrderNumber].[UseYear],
	[Sys_OrderNumber].[UseMonth],
	[Sys_OrderNumber].[UseDay],
	[Sys_OrderNumber].[OrderPrefix],
	[Sys_OrderNumber].[OrderPreview],
	[Sys_OrderNumber].[AddMan],
	[Sys_OrderNumber].[Remark],
	[Sys_OrderNumber].[ChargeType],
	[Sys_OrderNumber].[IsYearReset],
	[Sys_OrderNumber].[IsMonthReset],
	[Sys_OrderNumber].[IsDayReset],
	[Sys_OrderNumber].[OrderNote]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderTypeName],
	INSERTED.[OrderNumberCount],
	INSERTED.[UseYear],
	INSERTED.[UseMonth],
	INSERTED.[UseDay],
	INSERTED.[OrderPrefix],
	INSERTED.[OrderPreview],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[ChargeType],
	INSERTED.[IsYearReset],
	INSERTED.[IsMonthReset],
	INSERTED.[IsDayReset],
	INSERTED.[OrderNote]
into @table
VALUES ( 
	@OrderTypeName,
	@OrderNumberCount,
	@UseYear,
	@UseMonth,
	@UseDay,
	@OrderPrefix,
	@OrderPreview,
	@AddMan,
	@Remark,
	@ChargeType,
	@IsYearReset,
	@IsMonthReset,
	@IsDayReset,
	@OrderNote 
); 

SELECT 
	[ID],
	[OrderTypeName],
	[OrderNumberCount],
	[UseYear],
	[UseMonth],
	[UseDay],
	[OrderPrefix],
	[OrderPreview],
	[AddMan],
	[Remark],
	[ChargeType],
	[IsYearReset],
	[IsMonthReset],
	[IsDayReset],
	[OrderNote] 
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
	[OrderTypeName] nvarchar(50),
	[OrderNumberCount] int,
	[UseYear] bit,
	[UseMonth] bit,
	[UseDay] bit,
	[OrderPrefix] nvarchar(50),
	[OrderPreview] nvarchar(500),
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[ChargeType] int,
	[IsYearReset] bit,
	[IsMonthReset] bit,
	[IsDayReset] bit,
	[OrderNote] ntext
);

UPDATE [dbo].[Sys_OrderNumber] SET 
	[Sys_OrderNumber].[OrderTypeName] = @OrderTypeName,
	[Sys_OrderNumber].[OrderNumberCount] = @OrderNumberCount,
	[Sys_OrderNumber].[UseYear] = @UseYear,
	[Sys_OrderNumber].[UseMonth] = @UseMonth,
	[Sys_OrderNumber].[UseDay] = @UseDay,
	[Sys_OrderNumber].[OrderPrefix] = @OrderPrefix,
	[Sys_OrderNumber].[OrderPreview] = @OrderPreview,
	[Sys_OrderNumber].[AddMan] = @AddMan,
	[Sys_OrderNumber].[Remark] = @Remark,
	[Sys_OrderNumber].[ChargeType] = @ChargeType,
	[Sys_OrderNumber].[IsYearReset] = @IsYearReset,
	[Sys_OrderNumber].[IsMonthReset] = @IsMonthReset,
	[Sys_OrderNumber].[IsDayReset] = @IsDayReset,
	[Sys_OrderNumber].[OrderNote] = @OrderNote 
output 
	INSERTED.[ID],
	INSERTED.[OrderTypeName],
	INSERTED.[OrderNumberCount],
	INSERTED.[UseYear],
	INSERTED.[UseMonth],
	INSERTED.[UseDay],
	INSERTED.[OrderPrefix],
	INSERTED.[OrderPreview],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[ChargeType],
	INSERTED.[IsYearReset],
	INSERTED.[IsMonthReset],
	INSERTED.[IsDayReset],
	INSERTED.[OrderNote]
into @table
WHERE 
	[Sys_OrderNumber].[ID] = @ID

SELECT 
	[ID],
	[OrderTypeName],
	[OrderNumberCount],
	[UseYear],
	[UseMonth],
	[UseDay],
	[OrderPrefix],
	[OrderPreview],
	[AddMan],
	[Remark],
	[ChargeType],
	[IsYearReset],
	[IsMonthReset],
	[IsDayReset],
	[OrderNote] 
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
DELETE FROM [dbo].[Sys_OrderNumber]
WHERE 
	[Sys_OrderNumber].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Sys_OrderNumber() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSys_OrderNumber(this.ID));
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
	[Sys_OrderNumber].[ID],
	[Sys_OrderNumber].[OrderTypeName],
	[Sys_OrderNumber].[OrderNumberCount],
	[Sys_OrderNumber].[UseYear],
	[Sys_OrderNumber].[UseMonth],
	[Sys_OrderNumber].[UseDay],
	[Sys_OrderNumber].[OrderPrefix],
	[Sys_OrderNumber].[OrderPreview],
	[Sys_OrderNumber].[AddMan],
	[Sys_OrderNumber].[Remark],
	[Sys_OrderNumber].[ChargeType],
	[Sys_OrderNumber].[IsYearReset],
	[Sys_OrderNumber].[IsMonthReset],
	[Sys_OrderNumber].[IsDayReset],
	[Sys_OrderNumber].[OrderNote]
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
                return "Sys_OrderNumber";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Sys_OrderNumber into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderTypeName">orderTypeName</param>
		/// <param name="orderNumberCount">orderNumberCount</param>
		/// <param name="useYear">useYear</param>
		/// <param name="useMonth">useMonth</param>
		/// <param name="useDay">useDay</param>
		/// <param name="orderPrefix">orderPrefix</param>
		/// <param name="orderPreview">orderPreview</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="chargeType">chargeType</param>
		/// <param name="isYearReset">isYearReset</param>
		/// <param name="isMonthReset">isMonthReset</param>
		/// <param name="isDayReset">isDayReset</param>
		/// <param name="orderNote">orderNote</param>
		public static void InsertSys_OrderNumber(string @orderTypeName, int @orderNumberCount, bool @useYear, bool @useMonth, bool @useDay, string @orderPrefix, string @orderPreview, string @addMan, string @remark, int @chargeType, bool @isYearReset, bool @isMonthReset, bool @isDayReset, string @orderNote)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSys_OrderNumber(@orderTypeName, @orderNumberCount, @useYear, @useMonth, @useDay, @orderPrefix, @orderPreview, @addMan, @remark, @chargeType, @isYearReset, @isMonthReset, @isDayReset, @orderNote, helper);
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
		/// Insert a Sys_OrderNumber into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="orderTypeName">orderTypeName</param>
		/// <param name="orderNumberCount">orderNumberCount</param>
		/// <param name="useYear">useYear</param>
		/// <param name="useMonth">useMonth</param>
		/// <param name="useDay">useDay</param>
		/// <param name="orderPrefix">orderPrefix</param>
		/// <param name="orderPreview">orderPreview</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="chargeType">chargeType</param>
		/// <param name="isYearReset">isYearReset</param>
		/// <param name="isMonthReset">isMonthReset</param>
		/// <param name="isDayReset">isDayReset</param>
		/// <param name="orderNote">orderNote</param>
		/// <param name="helper">helper</param>
		internal static void InsertSys_OrderNumber(string @orderTypeName, int @orderNumberCount, bool @useYear, bool @useMonth, bool @useDay, string @orderPrefix, string @orderPreview, string @addMan, string @remark, int @chargeType, bool @isYearReset, bool @isMonthReset, bool @isDayReset, string @orderNote, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderTypeName] nvarchar(50),
	[OrderNumberCount] int,
	[UseYear] bit,
	[UseMonth] bit,
	[UseDay] bit,
	[OrderPrefix] nvarchar(50),
	[OrderPreview] nvarchar(500),
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[ChargeType] int,
	[IsYearReset] bit,
	[IsMonthReset] bit,
	[IsDayReset] bit,
	[OrderNote] ntext
);

INSERT INTO [dbo].[Sys_OrderNumber] (
	[Sys_OrderNumber].[OrderTypeName],
	[Sys_OrderNumber].[OrderNumberCount],
	[Sys_OrderNumber].[UseYear],
	[Sys_OrderNumber].[UseMonth],
	[Sys_OrderNumber].[UseDay],
	[Sys_OrderNumber].[OrderPrefix],
	[Sys_OrderNumber].[OrderPreview],
	[Sys_OrderNumber].[AddMan],
	[Sys_OrderNumber].[Remark],
	[Sys_OrderNumber].[ChargeType],
	[Sys_OrderNumber].[IsYearReset],
	[Sys_OrderNumber].[IsMonthReset],
	[Sys_OrderNumber].[IsDayReset],
	[Sys_OrderNumber].[OrderNote]
) 
output 
	INSERTED.[ID],
	INSERTED.[OrderTypeName],
	INSERTED.[OrderNumberCount],
	INSERTED.[UseYear],
	INSERTED.[UseMonth],
	INSERTED.[UseDay],
	INSERTED.[OrderPrefix],
	INSERTED.[OrderPreview],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[ChargeType],
	INSERTED.[IsYearReset],
	INSERTED.[IsMonthReset],
	INSERTED.[IsDayReset],
	INSERTED.[OrderNote]
into @table
VALUES ( 
	@OrderTypeName,
	@OrderNumberCount,
	@UseYear,
	@UseMonth,
	@UseDay,
	@OrderPrefix,
	@OrderPreview,
	@AddMan,
	@Remark,
	@ChargeType,
	@IsYearReset,
	@IsMonthReset,
	@IsDayReset,
	@OrderNote 
); 

SELECT 
	[ID],
	[OrderTypeName],
	[OrderNumberCount],
	[UseYear],
	[UseMonth],
	[UseDay],
	[OrderPrefix],
	[OrderPreview],
	[AddMan],
	[Remark],
	[ChargeType],
	[IsYearReset],
	[IsMonthReset],
	[IsDayReset],
	[OrderNote] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@OrderTypeName", EntityBase.GetDatabaseValue(@orderTypeName)));
			parameters.Add(new SqlParameter("@OrderNumberCount", EntityBase.GetDatabaseValue(@orderNumberCount)));
			parameters.Add(new SqlParameter("@UseYear", @useYear));
			parameters.Add(new SqlParameter("@UseMonth", @useMonth));
			parameters.Add(new SqlParameter("@UseDay", @useDay));
			parameters.Add(new SqlParameter("@OrderPrefix", EntityBase.GetDatabaseValue(@orderPrefix)));
			parameters.Add(new SqlParameter("@OrderPreview", EntityBase.GetDatabaseValue(@orderPreview)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@ChargeType", EntityBase.GetDatabaseValue(@chargeType)));
			parameters.Add(new SqlParameter("@IsYearReset", @isYearReset));
			parameters.Add(new SqlParameter("@IsMonthReset", @isMonthReset));
			parameters.Add(new SqlParameter("@IsDayReset", @isDayReset));
			parameters.Add(new SqlParameter("@OrderNote", EntityBase.GetDatabaseValue(@orderNote)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Sys_OrderNumber into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderTypeName">orderTypeName</param>
		/// <param name="orderNumberCount">orderNumberCount</param>
		/// <param name="useYear">useYear</param>
		/// <param name="useMonth">useMonth</param>
		/// <param name="useDay">useDay</param>
		/// <param name="orderPrefix">orderPrefix</param>
		/// <param name="orderPreview">orderPreview</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="chargeType">chargeType</param>
		/// <param name="isYearReset">isYearReset</param>
		/// <param name="isMonthReset">isMonthReset</param>
		/// <param name="isDayReset">isDayReset</param>
		/// <param name="orderNote">orderNote</param>
		public static void UpdateSys_OrderNumber(int @iD, string @orderTypeName, int @orderNumberCount, bool @useYear, bool @useMonth, bool @useDay, string @orderPrefix, string @orderPreview, string @addMan, string @remark, int @chargeType, bool @isYearReset, bool @isMonthReset, bool @isDayReset, string @orderNote)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSys_OrderNumber(@iD, @orderTypeName, @orderNumberCount, @useYear, @useMonth, @useDay, @orderPrefix, @orderPreview, @addMan, @remark, @chargeType, @isYearReset, @isMonthReset, @isDayReset, @orderNote, helper);
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
		/// Updates a Sys_OrderNumber into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="orderTypeName">orderTypeName</param>
		/// <param name="orderNumberCount">orderNumberCount</param>
		/// <param name="useYear">useYear</param>
		/// <param name="useMonth">useMonth</param>
		/// <param name="useDay">useDay</param>
		/// <param name="orderPrefix">orderPrefix</param>
		/// <param name="orderPreview">orderPreview</param>
		/// <param name="addMan">addMan</param>
		/// <param name="remark">remark</param>
		/// <param name="chargeType">chargeType</param>
		/// <param name="isYearReset">isYearReset</param>
		/// <param name="isMonthReset">isMonthReset</param>
		/// <param name="isDayReset">isDayReset</param>
		/// <param name="orderNote">orderNote</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSys_OrderNumber(int @iD, string @orderTypeName, int @orderNumberCount, bool @useYear, bool @useMonth, bool @useDay, string @orderPrefix, string @orderPreview, string @addMan, string @remark, int @chargeType, bool @isYearReset, bool @isMonthReset, bool @isDayReset, string @orderNote, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[OrderTypeName] nvarchar(50),
	[OrderNumberCount] int,
	[UseYear] bit,
	[UseMonth] bit,
	[UseDay] bit,
	[OrderPrefix] nvarchar(50),
	[OrderPreview] nvarchar(500),
	[AddMan] nvarchar(50),
	[Remark] ntext,
	[ChargeType] int,
	[IsYearReset] bit,
	[IsMonthReset] bit,
	[IsDayReset] bit,
	[OrderNote] ntext
);

UPDATE [dbo].[Sys_OrderNumber] SET 
	[Sys_OrderNumber].[OrderTypeName] = @OrderTypeName,
	[Sys_OrderNumber].[OrderNumberCount] = @OrderNumberCount,
	[Sys_OrderNumber].[UseYear] = @UseYear,
	[Sys_OrderNumber].[UseMonth] = @UseMonth,
	[Sys_OrderNumber].[UseDay] = @UseDay,
	[Sys_OrderNumber].[OrderPrefix] = @OrderPrefix,
	[Sys_OrderNumber].[OrderPreview] = @OrderPreview,
	[Sys_OrderNumber].[AddMan] = @AddMan,
	[Sys_OrderNumber].[Remark] = @Remark,
	[Sys_OrderNumber].[ChargeType] = @ChargeType,
	[Sys_OrderNumber].[IsYearReset] = @IsYearReset,
	[Sys_OrderNumber].[IsMonthReset] = @IsMonthReset,
	[Sys_OrderNumber].[IsDayReset] = @IsDayReset,
	[Sys_OrderNumber].[OrderNote] = @OrderNote 
output 
	INSERTED.[ID],
	INSERTED.[OrderTypeName],
	INSERTED.[OrderNumberCount],
	INSERTED.[UseYear],
	INSERTED.[UseMonth],
	INSERTED.[UseDay],
	INSERTED.[OrderPrefix],
	INSERTED.[OrderPreview],
	INSERTED.[AddMan],
	INSERTED.[Remark],
	INSERTED.[ChargeType],
	INSERTED.[IsYearReset],
	INSERTED.[IsMonthReset],
	INSERTED.[IsDayReset],
	INSERTED.[OrderNote]
into @table
WHERE 
	[Sys_OrderNumber].[ID] = @ID

SELECT 
	[ID],
	[OrderTypeName],
	[OrderNumberCount],
	[UseYear],
	[UseMonth],
	[UseDay],
	[OrderPrefix],
	[OrderPreview],
	[AddMan],
	[Remark],
	[ChargeType],
	[IsYearReset],
	[IsMonthReset],
	[IsDayReset],
	[OrderNote] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@OrderTypeName", EntityBase.GetDatabaseValue(@orderTypeName)));
			parameters.Add(new SqlParameter("@OrderNumberCount", EntityBase.GetDatabaseValue(@orderNumberCount)));
			parameters.Add(new SqlParameter("@UseYear", @useYear));
			parameters.Add(new SqlParameter("@UseMonth", @useMonth));
			parameters.Add(new SqlParameter("@UseDay", @useDay));
			parameters.Add(new SqlParameter("@OrderPrefix", EntityBase.GetDatabaseValue(@orderPrefix)));
			parameters.Add(new SqlParameter("@OrderPreview", EntityBase.GetDatabaseValue(@orderPreview)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@Remark", EntityBase.GetDatabaseValue(@remark)));
			parameters.Add(new SqlParameter("@ChargeType", EntityBase.GetDatabaseValue(@chargeType)));
			parameters.Add(new SqlParameter("@IsYearReset", @isYearReset));
			parameters.Add(new SqlParameter("@IsMonthReset", @isMonthReset));
			parameters.Add(new SqlParameter("@IsDayReset", @isDayReset));
			parameters.Add(new SqlParameter("@OrderNote", EntityBase.GetDatabaseValue(@orderNote)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Sys_OrderNumber from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSys_OrderNumber(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSys_OrderNumber(@iD, helper);
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
		/// Deletes a Sys_OrderNumber from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSys_OrderNumber(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Sys_OrderNumber]
WHERE 
	[Sys_OrderNumber].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Sys_OrderNumber object.
		/// </summary>
		/// <returns>The newly created Sys_OrderNumber object.</returns>
		public static Sys_OrderNumber CreateSys_OrderNumber()
		{
			return InitializeNew<Sys_OrderNumber>();
		}
		
		/// <summary>
		/// Retrieve information for a Sys_OrderNumber by a Sys_OrderNumber's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Sys_OrderNumber</returns>
		public static Sys_OrderNumber GetSys_OrderNumber(int @iD)
		{
			string commandText = @"
SELECT 
" + Sys_OrderNumber.SelectFieldList + @"
FROM [dbo].[Sys_OrderNumber] 
WHERE 
	[Sys_OrderNumber].[ID] = @ID " + Sys_OrderNumber.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Sys_OrderNumber>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Sys_OrderNumber by a Sys_OrderNumber's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Sys_OrderNumber</returns>
		public static Sys_OrderNumber GetSys_OrderNumber(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Sys_OrderNumber.SelectFieldList + @"
FROM [dbo].[Sys_OrderNumber] 
WHERE 
	[Sys_OrderNumber].[ID] = @ID " + Sys_OrderNumber.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Sys_OrderNumber>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Sys_OrderNumber objects.
		/// </summary>
		/// <returns>The retrieved collection of Sys_OrderNumber objects.</returns>
		public static EntityList<Sys_OrderNumber> GetSys_OrderNumbers()
		{
			string commandText = @"
SELECT " + Sys_OrderNumber.SelectFieldList + "FROM [dbo].[Sys_OrderNumber] " + Sys_OrderNumber.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Sys_OrderNumber>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Sys_OrderNumber objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Sys_OrderNumber objects.</returns>
        public static EntityList<Sys_OrderNumber> GetSys_OrderNumbers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sys_OrderNumber>(SelectFieldList, "FROM [dbo].[Sys_OrderNumber]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Sys_OrderNumber objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Sys_OrderNumber objects.</returns>
        public static EntityList<Sys_OrderNumber> GetSys_OrderNumbers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sys_OrderNumber>(SelectFieldList, "FROM [dbo].[Sys_OrderNumber]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Sys_OrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Sys_OrderNumber objects.</returns>
		protected static EntityList<Sys_OrderNumber> GetSys_OrderNumbers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSys_OrderNumbers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Sys_OrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Sys_OrderNumber objects.</returns>
		protected static EntityList<Sys_OrderNumber> GetSys_OrderNumbers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSys_OrderNumbers(string.Empty, where, parameters, Sys_OrderNumber.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sys_OrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Sys_OrderNumber objects.</returns>
		protected static EntityList<Sys_OrderNumber> GetSys_OrderNumbers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSys_OrderNumbers(prefix, where, parameters, Sys_OrderNumber.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sys_OrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Sys_OrderNumber objects.</returns>
		protected static EntityList<Sys_OrderNumber> GetSys_OrderNumbers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSys_OrderNumbers(string.Empty, where, parameters, Sys_OrderNumber.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sys_OrderNumber objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Sys_OrderNumber objects.</returns>
		protected static EntityList<Sys_OrderNumber> GetSys_OrderNumbers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSys_OrderNumbers(prefix, where, parameters, Sys_OrderNumber.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sys_OrderNumber objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Sys_OrderNumber objects.</returns>
		protected static EntityList<Sys_OrderNumber> GetSys_OrderNumbers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Sys_OrderNumber.SelectFieldList + "FROM [dbo].[Sys_OrderNumber] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Sys_OrderNumber>(reader);
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
        protected static EntityList<Sys_OrderNumber> GetSys_OrderNumbers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sys_OrderNumber>(SelectFieldList, "FROM [dbo].[Sys_OrderNumber] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Sys_OrderNumber objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSys_OrderNumberCount()
        {
            return GetSys_OrderNumberCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Sys_OrderNumber objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSys_OrderNumberCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Sys_OrderNumber] " + where;

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
		public static partial class Sys_OrderNumber_Properties
		{
			public const string ID = "ID";
			public const string OrderTypeName = "OrderTypeName";
			public const string OrderNumberCount = "OrderNumberCount";
			public const string UseYear = "UseYear";
			public const string UseMonth = "UseMonth";
			public const string UseDay = "UseDay";
			public const string OrderPrefix = "OrderPrefix";
			public const string OrderPreview = "OrderPreview";
			public const string AddMan = "AddMan";
			public const string Remark = "Remark";
			public const string ChargeType = "ChargeType";
			public const string IsYearReset = "IsYearReset";
			public const string IsMonthReset = "IsMonthReset";
			public const string IsDayReset = "IsDayReset";
			public const string OrderNote = "OrderNote";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"OrderTypeName" , "string:"},
    			 {"OrderNumberCount" , "int:"},
    			 {"UseYear" , "bool:"},
    			 {"UseMonth" , "bool:"},
    			 {"UseDay" , "bool:"},
    			 {"OrderPrefix" , "string:"},
    			 {"OrderPreview" , "string:"},
    			 {"AddMan" , "string:"},
    			 {"Remark" , "string:"},
    			 {"ChargeType" , "int:"},
    			 {"IsYearReset" , "bool:"},
    			 {"IsMonthReset" , "bool:"},
    			 {"IsDayReset" , "bool:"},
    			 {"OrderNote" , "string:"},
            };
		}
		#endregion
	}
}
