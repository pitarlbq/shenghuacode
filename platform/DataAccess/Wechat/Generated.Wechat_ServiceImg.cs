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
	/// This object represents the properties and methods of a Wechat_ServiceImg.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_ServiceImg 
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
		private string _icon = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Icon
		{
			[DebuggerStepThrough()]
			get { return this._icon; }
			set 
			{
				if (this._icon != value) 
				{
					this._icon = value;
					this.IsDirty = true;	
					OnPropertyChanged("Icon");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _medium = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Medium
		{
			[DebuggerStepThrough()]
			get { return this._medium; }
			set 
			{
				if (this._medium != value) 
				{
					this._medium = value;
					this.IsDirty = true;	
					OnPropertyChanged("Medium");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _large = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Large
		{
			[DebuggerStepThrough()]
			get { return this._large; }
			set 
			{
				if (this._large != value) 
				{
					this._large = value;
					this.IsDirty = true;	
					OnPropertyChanged("Large");
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
		private string _fileName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FileName
		{
			[DebuggerStepThrough()]
			get { return this._fileName; }
			set 
			{
				if (this._fileName != value) 
				{
					this._fileName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FileName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isVertical = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsVertical
		{
			[DebuggerStepThrough()]
			get { return this._isVertical; }
			set 
			{
				if (this._isVertical != value) 
				{
					this._isVertical = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsVertical");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _openID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OpenID
		{
			[DebuggerStepThrough()]
			get { return this._openID; }
			set 
			{
				if (this._openID != value) 
				{
					this._openID = value;
					this.IsDirty = true;	
					OnPropertyChanged("OpenID");
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
	[Icon] nvarchar(500),
	[Medium] nvarchar(500),
	[Large] nvarchar(500),
	[AddTime] datetime,
	[FileName] nvarchar(500),
	[IsVertical] bit,
	[OpenID] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_ServiceImg] (
	[Wechat_ServiceImg].[ServiceID],
	[Wechat_ServiceImg].[Icon],
	[Wechat_ServiceImg].[Medium],
	[Wechat_ServiceImg].[Large],
	[Wechat_ServiceImg].[AddTime],
	[Wechat_ServiceImg].[FileName],
	[Wechat_ServiceImg].[IsVertical],
	[Wechat_ServiceImg].[OpenID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[Icon],
	INSERTED.[Medium],
	INSERTED.[Large],
	INSERTED.[AddTime],
	INSERTED.[FileName],
	INSERTED.[IsVertical],
	INSERTED.[OpenID]
into @table
VALUES ( 
	@ServiceID,
	@Icon,
	@Medium,
	@Large,
	@AddTime,
	@FileName,
	@IsVertical,
	@OpenID 
); 

SELECT 
	[ID],
	[ServiceID],
	[Icon],
	[Medium],
	[Large],
	[AddTime],
	[FileName],
	[IsVertical],
	[OpenID] 
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
	[Icon] nvarchar(500),
	[Medium] nvarchar(500),
	[Large] nvarchar(500),
	[AddTime] datetime,
	[FileName] nvarchar(500),
	[IsVertical] bit,
	[OpenID] nvarchar(500)
);

UPDATE [dbo].[Wechat_ServiceImg] SET 
	[Wechat_ServiceImg].[ServiceID] = @ServiceID,
	[Wechat_ServiceImg].[Icon] = @Icon,
	[Wechat_ServiceImg].[Medium] = @Medium,
	[Wechat_ServiceImg].[Large] = @Large,
	[Wechat_ServiceImg].[AddTime] = @AddTime,
	[Wechat_ServiceImg].[FileName] = @FileName,
	[Wechat_ServiceImg].[IsVertical] = @IsVertical,
	[Wechat_ServiceImg].[OpenID] = @OpenID 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[Icon],
	INSERTED.[Medium],
	INSERTED.[Large],
	INSERTED.[AddTime],
	INSERTED.[FileName],
	INSERTED.[IsVertical],
	INSERTED.[OpenID]
into @table
WHERE 
	[Wechat_ServiceImg].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[Icon],
	[Medium],
	[Large],
	[AddTime],
	[FileName],
	[IsVertical],
	[OpenID] 
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
DELETE FROM [dbo].[Wechat_ServiceImg]
WHERE 
	[Wechat_ServiceImg].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_ServiceImg() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_ServiceImg(this.ID));
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
	[Wechat_ServiceImg].[ID],
	[Wechat_ServiceImg].[ServiceID],
	[Wechat_ServiceImg].[Icon],
	[Wechat_ServiceImg].[Medium],
	[Wechat_ServiceImg].[Large],
	[Wechat_ServiceImg].[AddTime],
	[Wechat_ServiceImg].[FileName],
	[Wechat_ServiceImg].[IsVertical],
	[Wechat_ServiceImg].[OpenID]
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
                return "Wechat_ServiceImg";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_ServiceImg into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="icon">icon</param>
		/// <param name="medium">medium</param>
		/// <param name="large">large</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileName">fileName</param>
		/// <param name="isVertical">isVertical</param>
		/// <param name="openID">openID</param>
		public static void InsertWechat_ServiceImg(int @serviceID, string @icon, string @medium, string @large, DateTime @addTime, string @fileName, bool @isVertical, string @openID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_ServiceImg(@serviceID, @icon, @medium, @large, @addTime, @fileName, @isVertical, @openID, helper);
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
		/// Insert a Wechat_ServiceImg into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="serviceID">serviceID</param>
		/// <param name="icon">icon</param>
		/// <param name="medium">medium</param>
		/// <param name="large">large</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileName">fileName</param>
		/// <param name="isVertical">isVertical</param>
		/// <param name="openID">openID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_ServiceImg(int @serviceID, string @icon, string @medium, string @large, DateTime @addTime, string @fileName, bool @isVertical, string @openID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[Icon] nvarchar(500),
	[Medium] nvarchar(500),
	[Large] nvarchar(500),
	[AddTime] datetime,
	[FileName] nvarchar(500),
	[IsVertical] bit,
	[OpenID] nvarchar(500)
);

INSERT INTO [dbo].[Wechat_ServiceImg] (
	[Wechat_ServiceImg].[ServiceID],
	[Wechat_ServiceImg].[Icon],
	[Wechat_ServiceImg].[Medium],
	[Wechat_ServiceImg].[Large],
	[Wechat_ServiceImg].[AddTime],
	[Wechat_ServiceImg].[FileName],
	[Wechat_ServiceImg].[IsVertical],
	[Wechat_ServiceImg].[OpenID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[Icon],
	INSERTED.[Medium],
	INSERTED.[Large],
	INSERTED.[AddTime],
	INSERTED.[FileName],
	INSERTED.[IsVertical],
	INSERTED.[OpenID]
into @table
VALUES ( 
	@ServiceID,
	@Icon,
	@Medium,
	@Large,
	@AddTime,
	@FileName,
	@IsVertical,
	@OpenID 
); 

SELECT 
	[ID],
	[ServiceID],
	[Icon],
	[Medium],
	[Large],
	[AddTime],
	[FileName],
	[IsVertical],
	[OpenID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@Icon", EntityBase.GetDatabaseValue(@icon)));
			parameters.Add(new SqlParameter("@Medium", EntityBase.GetDatabaseValue(@medium)));
			parameters.Add(new SqlParameter("@Large", EntityBase.GetDatabaseValue(@large)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileName", EntityBase.GetDatabaseValue(@fileName)));
			parameters.Add(new SqlParameter("@IsVertical", @isVertical));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_ServiceImg into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="icon">icon</param>
		/// <param name="medium">medium</param>
		/// <param name="large">large</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileName">fileName</param>
		/// <param name="isVertical">isVertical</param>
		/// <param name="openID">openID</param>
		public static void UpdateWechat_ServiceImg(int @iD, int @serviceID, string @icon, string @medium, string @large, DateTime @addTime, string @fileName, bool @isVertical, string @openID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_ServiceImg(@iD, @serviceID, @icon, @medium, @large, @addTime, @fileName, @isVertical, @openID, helper);
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
		/// Updates a Wechat_ServiceImg into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="serviceID">serviceID</param>
		/// <param name="icon">icon</param>
		/// <param name="medium">medium</param>
		/// <param name="large">large</param>
		/// <param name="addTime">addTime</param>
		/// <param name="fileName">fileName</param>
		/// <param name="isVertical">isVertical</param>
		/// <param name="openID">openID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_ServiceImg(int @iD, int @serviceID, string @icon, string @medium, string @large, DateTime @addTime, string @fileName, bool @isVertical, string @openID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ServiceID] int,
	[Icon] nvarchar(500),
	[Medium] nvarchar(500),
	[Large] nvarchar(500),
	[AddTime] datetime,
	[FileName] nvarchar(500),
	[IsVertical] bit,
	[OpenID] nvarchar(500)
);

UPDATE [dbo].[Wechat_ServiceImg] SET 
	[Wechat_ServiceImg].[ServiceID] = @ServiceID,
	[Wechat_ServiceImg].[Icon] = @Icon,
	[Wechat_ServiceImg].[Medium] = @Medium,
	[Wechat_ServiceImg].[Large] = @Large,
	[Wechat_ServiceImg].[AddTime] = @AddTime,
	[Wechat_ServiceImg].[FileName] = @FileName,
	[Wechat_ServiceImg].[IsVertical] = @IsVertical,
	[Wechat_ServiceImg].[OpenID] = @OpenID 
output 
	INSERTED.[ID],
	INSERTED.[ServiceID],
	INSERTED.[Icon],
	INSERTED.[Medium],
	INSERTED.[Large],
	INSERTED.[AddTime],
	INSERTED.[FileName],
	INSERTED.[IsVertical],
	INSERTED.[OpenID]
into @table
WHERE 
	[Wechat_ServiceImg].[ID] = @ID

SELECT 
	[ID],
	[ServiceID],
	[Icon],
	[Medium],
	[Large],
	[AddTime],
	[FileName],
	[IsVertical],
	[OpenID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ServiceID", EntityBase.GetDatabaseValue(@serviceID)));
			parameters.Add(new SqlParameter("@Icon", EntityBase.GetDatabaseValue(@icon)));
			parameters.Add(new SqlParameter("@Medium", EntityBase.GetDatabaseValue(@medium)));
			parameters.Add(new SqlParameter("@Large", EntityBase.GetDatabaseValue(@large)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@FileName", EntityBase.GetDatabaseValue(@fileName)));
			parameters.Add(new SqlParameter("@IsVertical", @isVertical));
			parameters.Add(new SqlParameter("@OpenID", EntityBase.GetDatabaseValue(@openID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_ServiceImg from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_ServiceImg(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_ServiceImg(@iD, helper);
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
		/// Deletes a Wechat_ServiceImg from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_ServiceImg(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_ServiceImg]
WHERE 
	[Wechat_ServiceImg].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_ServiceImg object.
		/// </summary>
		/// <returns>The newly created Wechat_ServiceImg object.</returns>
		public static Wechat_ServiceImg CreateWechat_ServiceImg()
		{
			return InitializeNew<Wechat_ServiceImg>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_ServiceImg by a Wechat_ServiceImg's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_ServiceImg</returns>
		public static Wechat_ServiceImg GetWechat_ServiceImg(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_ServiceImg.SelectFieldList + @"
FROM [dbo].[Wechat_ServiceImg] 
WHERE 
	[Wechat_ServiceImg].[ID] = @ID " + Wechat_ServiceImg.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ServiceImg>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_ServiceImg by a Wechat_ServiceImg's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_ServiceImg</returns>
		public static Wechat_ServiceImg GetWechat_ServiceImg(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_ServiceImg.SelectFieldList + @"
FROM [dbo].[Wechat_ServiceImg] 
WHERE 
	[Wechat_ServiceImg].[ID] = @ID " + Wechat_ServiceImg.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ServiceImg>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceImg objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_ServiceImg objects.</returns>
		public static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs()
		{
			string commandText = @"
SELECT " + Wechat_ServiceImg.SelectFieldList + "FROM [dbo].[Wechat_ServiceImg] " + Wechat_ServiceImg.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_ServiceImg>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_ServiceImg objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ServiceImg objects.</returns>
        public static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ServiceImg>(SelectFieldList, "FROM [dbo].[Wechat_ServiceImg]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_ServiceImg objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ServiceImg objects.</returns>
        public static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ServiceImg>(SelectFieldList, "FROM [dbo].[Wechat_ServiceImg]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_ServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ServiceImg objects.</returns>
		protected static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ServiceImgs(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ServiceImg objects.</returns>
		protected static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ServiceImgs(string.Empty, where, parameters, Wechat_ServiceImg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ServiceImg objects.</returns>
		protected static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ServiceImgs(prefix, where, parameters, Wechat_ServiceImg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ServiceImg objects.</returns>
		protected static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ServiceImgs(string.Empty, where, parameters, Wechat_ServiceImg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceImg objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ServiceImg objects.</returns>
		protected static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ServiceImgs(prefix, where, parameters, Wechat_ServiceImg.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceImg objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ServiceImg objects.</returns>
		protected static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_ServiceImg.SelectFieldList + "FROM [dbo].[Wechat_ServiceImg] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_ServiceImg>(reader);
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
        protected static EntityList<Wechat_ServiceImg> GetWechat_ServiceImgs(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ServiceImg>(SelectFieldList, "FROM [dbo].[Wechat_ServiceImg] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_ServiceImg objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ServiceImgCount()
        {
            return GetWechat_ServiceImgCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_ServiceImg objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ServiceImgCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_ServiceImg] " + where;

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
		public static partial class Wechat_ServiceImg_Properties
		{
			public const string ID = "ID";
			public const string ServiceID = "ServiceID";
			public const string Icon = "Icon";
			public const string Medium = "Medium";
			public const string Large = "Large";
			public const string AddTime = "AddTime";
			public const string FileName = "FileName";
			public const string IsVertical = "IsVertical";
			public const string OpenID = "OpenID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ServiceID" , "int:"},
    			 {"Icon" , "string:"},
    			 {"Medium" , "string:"},
    			 {"Large" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"FileName" , "string:"},
    			 {"IsVertical" , "bool:"},
    			 {"OpenID" , "string:"},
            };
		}
		#endregion
	}
}
