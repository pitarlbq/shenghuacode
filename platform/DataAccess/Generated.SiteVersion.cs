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
	/// This object represents the properties and methods of a SiteVersion.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class SiteVersion 
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
		private int _versionCode = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int VersionCode
		{
			[DebuggerStepThrough()]
			get { return this._versionCode; }
			set 
			{
				if (this._versionCode != value) 
				{
					this._versionCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("VersionCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DateTime _publishDate = DateTime.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public DateTime PublishDate
		{
			[DebuggerStepThrough()]
			get { return this._publishDate; }
			set 
			{
				if (this._publishDate != value) 
				{
					this._publishDate = value;
					this.IsDirty = true;	
					OnPropertyChanged("PublishDate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _versionDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string VersionDesc
		{
			[DebuggerStepThrough()]
			get { return this._versionDesc; }
			set 
			{
				if (this._versionDesc != value) 
				{
					this._versionDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("VersionDesc");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _filePath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FilePath
		{
			[DebuggerStepThrough()]
			get { return this._filePath; }
			set 
			{
				if (this._filePath != value) 
				{
					this._filePath = value;
					this.IsDirty = true;	
					OnPropertyChanged("FilePath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _updatedCompany = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string UpdatedCompany
		{
			[DebuggerStepThrough()]
			get { return this._updatedCompany; }
			set 
			{
				if (this._updatedCompany != value) 
				{
					this._updatedCompany = value;
					this.IsDirty = true;	
					OnPropertyChanged("UpdatedCompany");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _sqlPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string SqlPath
		{
			[DebuggerStepThrough()]
			get { return this._sqlPath; }
			set 
			{
				if (this._sqlPath != value) 
				{
					this._sqlPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("SqlPath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _versionType = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string VersionType
		{
			[DebuggerStepThrough()]
			get { return this._versionType; }
			set 
			{
				if (this._versionType != value) 
				{
					this._versionType = value;
					this.IsDirty = true;	
					OnPropertyChanged("VersionType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _aPPVersionCode = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int APPVersionCode
		{
			[DebuggerStepThrough()]
			get { return this._aPPVersionCode; }
			set 
			{
				if (this._aPPVersionCode != value) 
				{
					this._aPPVersionCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPVersionCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _aPPVersionDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string APPVersionDesc
		{
			[DebuggerStepThrough()]
			get { return this._aPPVersionDesc; }
			set 
			{
				if (this._aPPVersionDesc != value) 
				{
					this._aPPVersionDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPVersionDesc");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _aPPType = int.MinValue;
		/// <summary>
		/// 1-业主端 2-员工端 3-商家端
		/// </summary>
        [Description("1-业主端 2-员工端 3-商家端")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int APPType
		{
			[DebuggerStepThrough()]
			get { return this._aPPType; }
			set 
			{
				if (this._aPPType != value) 
				{
					this._aPPType = value;
					this.IsDirty = true;	
					OnPropertyChanged("APPType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _disableUpdate = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool DisableUpdate
		{
			[DebuggerStepThrough()]
			get { return this._disableUpdate; }
			set 
			{
				if (this._disableUpdate != value) 
				{
					this._disableUpdate = value;
					this.IsDirty = true;	
					OnPropertyChanged("DisableUpdate");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isForceUpdate = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsForceUpdate
		{
			[DebuggerStepThrough()]
			get { return this._isForceUpdate; }
			set 
			{
				if (this._isForceUpdate != value) 
				{
					this._isForceUpdate = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsForceUpdate");
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
	[VersionCode] int,
	[PublishDate] datetime,
	[VersionDesc] ntext,
	[FilePath] nvarchar(500),
	[UpdatedCompany] ntext,
	[SqlPath] ntext,
	[VersionType] nvarchar(50),
	[APPVersionCode] int,
	[APPVersionDesc] nvarchar(50),
	[APPType] int,
	[DisableUpdate] bit,
	[IsForceUpdate] bit
);

INSERT INTO [dbo].[SiteVersion] (
	[SiteVersion].[VersionCode],
	[SiteVersion].[PublishDate],
	[SiteVersion].[VersionDesc],
	[SiteVersion].[FilePath],
	[SiteVersion].[UpdatedCompany],
	[SiteVersion].[SqlPath],
	[SiteVersion].[VersionType],
	[SiteVersion].[APPVersionCode],
	[SiteVersion].[APPVersionDesc],
	[SiteVersion].[APPType],
	[SiteVersion].[DisableUpdate],
	[SiteVersion].[IsForceUpdate]
) 
output 
	INSERTED.[ID],
	INSERTED.[VersionCode],
	INSERTED.[PublishDate],
	INSERTED.[VersionDesc],
	INSERTED.[FilePath],
	INSERTED.[UpdatedCompany],
	INSERTED.[SqlPath],
	INSERTED.[VersionType],
	INSERTED.[APPVersionCode],
	INSERTED.[APPVersionDesc],
	INSERTED.[APPType],
	INSERTED.[DisableUpdate],
	INSERTED.[IsForceUpdate]
into @table
VALUES ( 
	@VersionCode,
	@PublishDate,
	@VersionDesc,
	@FilePath,
	@UpdatedCompany,
	@SqlPath,
	@VersionType,
	@APPVersionCode,
	@APPVersionDesc,
	@APPType,
	@DisableUpdate,
	@IsForceUpdate 
); 

SELECT 
	[ID],
	[VersionCode],
	[PublishDate],
	[VersionDesc],
	[FilePath],
	[UpdatedCompany],
	[SqlPath],
	[VersionType],
	[APPVersionCode],
	[APPVersionDesc],
	[APPType],
	[DisableUpdate],
	[IsForceUpdate] 
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
	[VersionCode] int,
	[PublishDate] datetime,
	[VersionDesc] ntext,
	[FilePath] nvarchar(500),
	[UpdatedCompany] ntext,
	[SqlPath] ntext,
	[VersionType] nvarchar(50),
	[APPVersionCode] int,
	[APPVersionDesc] nvarchar(50),
	[APPType] int,
	[DisableUpdate] bit,
	[IsForceUpdate] bit
);

UPDATE [dbo].[SiteVersion] SET 
	[SiteVersion].[VersionCode] = @VersionCode,
	[SiteVersion].[PublishDate] = @PublishDate,
	[SiteVersion].[VersionDesc] = @VersionDesc,
	[SiteVersion].[FilePath] = @FilePath,
	[SiteVersion].[UpdatedCompany] = @UpdatedCompany,
	[SiteVersion].[SqlPath] = @SqlPath,
	[SiteVersion].[VersionType] = @VersionType,
	[SiteVersion].[APPVersionCode] = @APPVersionCode,
	[SiteVersion].[APPVersionDesc] = @APPVersionDesc,
	[SiteVersion].[APPType] = @APPType,
	[SiteVersion].[DisableUpdate] = @DisableUpdate,
	[SiteVersion].[IsForceUpdate] = @IsForceUpdate 
output 
	INSERTED.[ID],
	INSERTED.[VersionCode],
	INSERTED.[PublishDate],
	INSERTED.[VersionDesc],
	INSERTED.[FilePath],
	INSERTED.[UpdatedCompany],
	INSERTED.[SqlPath],
	INSERTED.[VersionType],
	INSERTED.[APPVersionCode],
	INSERTED.[APPVersionDesc],
	INSERTED.[APPType],
	INSERTED.[DisableUpdate],
	INSERTED.[IsForceUpdate]
into @table
WHERE 
	[SiteVersion].[ID] = @ID

SELECT 
	[ID],
	[VersionCode],
	[PublishDate],
	[VersionDesc],
	[FilePath],
	[UpdatedCompany],
	[SqlPath],
	[VersionType],
	[APPVersionCode],
	[APPVersionDesc],
	[APPType],
	[DisableUpdate],
	[IsForceUpdate] 
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
DELETE FROM [dbo].[SiteVersion]
WHERE 
	[SiteVersion].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public SiteVersion() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSiteVersion(this.ID));
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
	[SiteVersion].[ID],
	[SiteVersion].[VersionCode],
	[SiteVersion].[PublishDate],
	[SiteVersion].[VersionDesc],
	[SiteVersion].[FilePath],
	[SiteVersion].[UpdatedCompany],
	[SiteVersion].[SqlPath],
	[SiteVersion].[VersionType],
	[SiteVersion].[APPVersionCode],
	[SiteVersion].[APPVersionDesc],
	[SiteVersion].[APPType],
	[SiteVersion].[DisableUpdate],
	[SiteVersion].[IsForceUpdate]
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
                return "SiteVersion";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a SiteVersion into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="versionCode">versionCode</param>
		/// <param name="publishDate">publishDate</param>
		/// <param name="versionDesc">versionDesc</param>
		/// <param name="filePath">filePath</param>
		/// <param name="updatedCompany">updatedCompany</param>
		/// <param name="sqlPath">sqlPath</param>
		/// <param name="versionType">versionType</param>
		/// <param name="aPPVersionCode">aPPVersionCode</param>
		/// <param name="aPPVersionDesc">aPPVersionDesc</param>
		/// <param name="aPPType">aPPType</param>
		/// <param name="disableUpdate">disableUpdate</param>
		/// <param name="isForceUpdate">isForceUpdate</param>
		public static void InsertSiteVersion(int @versionCode, DateTime @publishDate, string @versionDesc, string @filePath, string @updatedCompany, string @sqlPath, string @versionType, int @aPPVersionCode, string @aPPVersionDesc, int @aPPType, bool @disableUpdate, bool @isForceUpdate)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSiteVersion(@versionCode, @publishDate, @versionDesc, @filePath, @updatedCompany, @sqlPath, @versionType, @aPPVersionCode, @aPPVersionDesc, @aPPType, @disableUpdate, @isForceUpdate, helper);
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
		/// Insert a SiteVersion into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="versionCode">versionCode</param>
		/// <param name="publishDate">publishDate</param>
		/// <param name="versionDesc">versionDesc</param>
		/// <param name="filePath">filePath</param>
		/// <param name="updatedCompany">updatedCompany</param>
		/// <param name="sqlPath">sqlPath</param>
		/// <param name="versionType">versionType</param>
		/// <param name="aPPVersionCode">aPPVersionCode</param>
		/// <param name="aPPVersionDesc">aPPVersionDesc</param>
		/// <param name="aPPType">aPPType</param>
		/// <param name="disableUpdate">disableUpdate</param>
		/// <param name="isForceUpdate">isForceUpdate</param>
		/// <param name="helper">helper</param>
		internal static void InsertSiteVersion(int @versionCode, DateTime @publishDate, string @versionDesc, string @filePath, string @updatedCompany, string @sqlPath, string @versionType, int @aPPVersionCode, string @aPPVersionDesc, int @aPPType, bool @disableUpdate, bool @isForceUpdate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[VersionCode] int,
	[PublishDate] datetime,
	[VersionDesc] ntext,
	[FilePath] nvarchar(500),
	[UpdatedCompany] ntext,
	[SqlPath] ntext,
	[VersionType] nvarchar(50),
	[APPVersionCode] int,
	[APPVersionDesc] nvarchar(50),
	[APPType] int,
	[DisableUpdate] bit,
	[IsForceUpdate] bit
);

INSERT INTO [dbo].[SiteVersion] (
	[SiteVersion].[VersionCode],
	[SiteVersion].[PublishDate],
	[SiteVersion].[VersionDesc],
	[SiteVersion].[FilePath],
	[SiteVersion].[UpdatedCompany],
	[SiteVersion].[SqlPath],
	[SiteVersion].[VersionType],
	[SiteVersion].[APPVersionCode],
	[SiteVersion].[APPVersionDesc],
	[SiteVersion].[APPType],
	[SiteVersion].[DisableUpdate],
	[SiteVersion].[IsForceUpdate]
) 
output 
	INSERTED.[ID],
	INSERTED.[VersionCode],
	INSERTED.[PublishDate],
	INSERTED.[VersionDesc],
	INSERTED.[FilePath],
	INSERTED.[UpdatedCompany],
	INSERTED.[SqlPath],
	INSERTED.[VersionType],
	INSERTED.[APPVersionCode],
	INSERTED.[APPVersionDesc],
	INSERTED.[APPType],
	INSERTED.[DisableUpdate],
	INSERTED.[IsForceUpdate]
into @table
VALUES ( 
	@VersionCode,
	@PublishDate,
	@VersionDesc,
	@FilePath,
	@UpdatedCompany,
	@SqlPath,
	@VersionType,
	@APPVersionCode,
	@APPVersionDesc,
	@APPType,
	@DisableUpdate,
	@IsForceUpdate 
); 

SELECT 
	[ID],
	[VersionCode],
	[PublishDate],
	[VersionDesc],
	[FilePath],
	[UpdatedCompany],
	[SqlPath],
	[VersionType],
	[APPVersionCode],
	[APPVersionDesc],
	[APPType],
	[DisableUpdate],
	[IsForceUpdate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@VersionCode", EntityBase.GetDatabaseValue(@versionCode)));
			parameters.Add(new SqlParameter("@PublishDate", EntityBase.GetDatabaseValue(@publishDate)));
			parameters.Add(new SqlParameter("@VersionDesc", EntityBase.GetDatabaseValue(@versionDesc)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@UpdatedCompany", EntityBase.GetDatabaseValue(@updatedCompany)));
			parameters.Add(new SqlParameter("@SqlPath", EntityBase.GetDatabaseValue(@sqlPath)));
			parameters.Add(new SqlParameter("@VersionType", EntityBase.GetDatabaseValue(@versionType)));
			parameters.Add(new SqlParameter("@APPVersionCode", EntityBase.GetDatabaseValue(@aPPVersionCode)));
			parameters.Add(new SqlParameter("@APPVersionDesc", EntityBase.GetDatabaseValue(@aPPVersionDesc)));
			parameters.Add(new SqlParameter("@APPType", EntityBase.GetDatabaseValue(@aPPType)));
			parameters.Add(new SqlParameter("@DisableUpdate", @disableUpdate));
			parameters.Add(new SqlParameter("@IsForceUpdate", @isForceUpdate));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a SiteVersion into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="versionCode">versionCode</param>
		/// <param name="publishDate">publishDate</param>
		/// <param name="versionDesc">versionDesc</param>
		/// <param name="filePath">filePath</param>
		/// <param name="updatedCompany">updatedCompany</param>
		/// <param name="sqlPath">sqlPath</param>
		/// <param name="versionType">versionType</param>
		/// <param name="aPPVersionCode">aPPVersionCode</param>
		/// <param name="aPPVersionDesc">aPPVersionDesc</param>
		/// <param name="aPPType">aPPType</param>
		/// <param name="disableUpdate">disableUpdate</param>
		/// <param name="isForceUpdate">isForceUpdate</param>
		public static void UpdateSiteVersion(int @iD, int @versionCode, DateTime @publishDate, string @versionDesc, string @filePath, string @updatedCompany, string @sqlPath, string @versionType, int @aPPVersionCode, string @aPPVersionDesc, int @aPPType, bool @disableUpdate, bool @isForceUpdate)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSiteVersion(@iD, @versionCode, @publishDate, @versionDesc, @filePath, @updatedCompany, @sqlPath, @versionType, @aPPVersionCode, @aPPVersionDesc, @aPPType, @disableUpdate, @isForceUpdate, helper);
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
		/// Updates a SiteVersion into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="versionCode">versionCode</param>
		/// <param name="publishDate">publishDate</param>
		/// <param name="versionDesc">versionDesc</param>
		/// <param name="filePath">filePath</param>
		/// <param name="updatedCompany">updatedCompany</param>
		/// <param name="sqlPath">sqlPath</param>
		/// <param name="versionType">versionType</param>
		/// <param name="aPPVersionCode">aPPVersionCode</param>
		/// <param name="aPPVersionDesc">aPPVersionDesc</param>
		/// <param name="aPPType">aPPType</param>
		/// <param name="disableUpdate">disableUpdate</param>
		/// <param name="isForceUpdate">isForceUpdate</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSiteVersion(int @iD, int @versionCode, DateTime @publishDate, string @versionDesc, string @filePath, string @updatedCompany, string @sqlPath, string @versionType, int @aPPVersionCode, string @aPPVersionDesc, int @aPPType, bool @disableUpdate, bool @isForceUpdate, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[VersionCode] int,
	[PublishDate] datetime,
	[VersionDesc] ntext,
	[FilePath] nvarchar(500),
	[UpdatedCompany] ntext,
	[SqlPath] ntext,
	[VersionType] nvarchar(50),
	[APPVersionCode] int,
	[APPVersionDesc] nvarchar(50),
	[APPType] int,
	[DisableUpdate] bit,
	[IsForceUpdate] bit
);

UPDATE [dbo].[SiteVersion] SET 
	[SiteVersion].[VersionCode] = @VersionCode,
	[SiteVersion].[PublishDate] = @PublishDate,
	[SiteVersion].[VersionDesc] = @VersionDesc,
	[SiteVersion].[FilePath] = @FilePath,
	[SiteVersion].[UpdatedCompany] = @UpdatedCompany,
	[SiteVersion].[SqlPath] = @SqlPath,
	[SiteVersion].[VersionType] = @VersionType,
	[SiteVersion].[APPVersionCode] = @APPVersionCode,
	[SiteVersion].[APPVersionDesc] = @APPVersionDesc,
	[SiteVersion].[APPType] = @APPType,
	[SiteVersion].[DisableUpdate] = @DisableUpdate,
	[SiteVersion].[IsForceUpdate] = @IsForceUpdate 
output 
	INSERTED.[ID],
	INSERTED.[VersionCode],
	INSERTED.[PublishDate],
	INSERTED.[VersionDesc],
	INSERTED.[FilePath],
	INSERTED.[UpdatedCompany],
	INSERTED.[SqlPath],
	INSERTED.[VersionType],
	INSERTED.[APPVersionCode],
	INSERTED.[APPVersionDesc],
	INSERTED.[APPType],
	INSERTED.[DisableUpdate],
	INSERTED.[IsForceUpdate]
into @table
WHERE 
	[SiteVersion].[ID] = @ID

SELECT 
	[ID],
	[VersionCode],
	[PublishDate],
	[VersionDesc],
	[FilePath],
	[UpdatedCompany],
	[SqlPath],
	[VersionType],
	[APPVersionCode],
	[APPVersionDesc],
	[APPType],
	[DisableUpdate],
	[IsForceUpdate] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@VersionCode", EntityBase.GetDatabaseValue(@versionCode)));
			parameters.Add(new SqlParameter("@PublishDate", EntityBase.GetDatabaseValue(@publishDate)));
			parameters.Add(new SqlParameter("@VersionDesc", EntityBase.GetDatabaseValue(@versionDesc)));
			parameters.Add(new SqlParameter("@FilePath", EntityBase.GetDatabaseValue(@filePath)));
			parameters.Add(new SqlParameter("@UpdatedCompany", EntityBase.GetDatabaseValue(@updatedCompany)));
			parameters.Add(new SqlParameter("@SqlPath", EntityBase.GetDatabaseValue(@sqlPath)));
			parameters.Add(new SqlParameter("@VersionType", EntityBase.GetDatabaseValue(@versionType)));
			parameters.Add(new SqlParameter("@APPVersionCode", EntityBase.GetDatabaseValue(@aPPVersionCode)));
			parameters.Add(new SqlParameter("@APPVersionDesc", EntityBase.GetDatabaseValue(@aPPVersionDesc)));
			parameters.Add(new SqlParameter("@APPType", EntityBase.GetDatabaseValue(@aPPType)));
			parameters.Add(new SqlParameter("@DisableUpdate", @disableUpdate));
			parameters.Add(new SqlParameter("@IsForceUpdate", @isForceUpdate));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a SiteVersion from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSiteVersion(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSiteVersion(@iD, helper);
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
		/// Deletes a SiteVersion from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSiteVersion(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[SiteVersion]
WHERE 
	[SiteVersion].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new SiteVersion object.
		/// </summary>
		/// <returns>The newly created SiteVersion object.</returns>
		public static SiteVersion CreateSiteVersion()
		{
			return InitializeNew<SiteVersion>();
		}
		
		/// <summary>
		/// Retrieve information for a SiteVersion by a SiteVersion's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>SiteVersion</returns>
		public static SiteVersion GetSiteVersion(int @iD)
		{
			string commandText = @"
SELECT 
" + SiteVersion.SelectFieldList + @"
FROM [dbo].[SiteVersion] 
WHERE 
	[SiteVersion].[ID] = @ID " + SiteVersion.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SiteVersion>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a SiteVersion by a SiteVersion's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>SiteVersion</returns>
		public static SiteVersion GetSiteVersion(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + SiteVersion.SelectFieldList + @"
FROM [dbo].[SiteVersion] 
WHERE 
	[SiteVersion].[ID] = @ID " + SiteVersion.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SiteVersion>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection SiteVersion objects.
		/// </summary>
		/// <returns>The retrieved collection of SiteVersion objects.</returns>
		public static EntityList<SiteVersion> GetSiteVersions()
		{
			string commandText = @"
SELECT " + SiteVersion.SelectFieldList + "FROM [dbo].[SiteVersion] " + SiteVersion.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<SiteVersion>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection SiteVersion objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SiteVersion objects.</returns>
        public static EntityList<SiteVersion> GetSiteVersions(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SiteVersion>(SelectFieldList, "FROM [dbo].[SiteVersion]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection SiteVersion objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SiteVersion objects.</returns>
        public static EntityList<SiteVersion> GetSiteVersions(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SiteVersion>(SelectFieldList, "FROM [dbo].[SiteVersion]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection SiteVersion objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of SiteVersion objects.</returns>
		protected static EntityList<SiteVersion> GetSiteVersions(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSiteVersions(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection SiteVersion objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SiteVersion objects.</returns>
		protected static EntityList<SiteVersion> GetSiteVersions(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSiteVersions(string.Empty, where, parameters, SiteVersion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SiteVersion objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SiteVersion objects.</returns>
		protected static EntityList<SiteVersion> GetSiteVersions(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSiteVersions(prefix, where, parameters, SiteVersion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SiteVersion objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SiteVersion objects.</returns>
		protected static EntityList<SiteVersion> GetSiteVersions(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSiteVersions(string.Empty, where, parameters, SiteVersion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SiteVersion objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SiteVersion objects.</returns>
		protected static EntityList<SiteVersion> GetSiteVersions(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSiteVersions(prefix, where, parameters, SiteVersion.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SiteVersion objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of SiteVersion objects.</returns>
		protected static EntityList<SiteVersion> GetSiteVersions(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + SiteVersion.SelectFieldList + "FROM [dbo].[SiteVersion] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<SiteVersion>(reader);
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
        protected static EntityList<SiteVersion> GetSiteVersions(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SiteVersion>(SelectFieldList, "FROM [dbo].[SiteVersion] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of SiteVersion objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSiteVersionCount()
        {
            return GetSiteVersionCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of SiteVersion objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSiteVersionCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[SiteVersion] " + where;

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
		public static partial class SiteVersion_Properties
		{
			public const string ID = "ID";
			public const string VersionCode = "VersionCode";
			public const string PublishDate = "PublishDate";
			public const string VersionDesc = "VersionDesc";
			public const string FilePath = "FilePath";
			public const string UpdatedCompany = "UpdatedCompany";
			public const string SqlPath = "SqlPath";
			public const string VersionType = "VersionType";
			public const string APPVersionCode = "APPVersionCode";
			public const string APPVersionDesc = "APPVersionDesc";
			public const string APPType = "APPType";
			public const string DisableUpdate = "DisableUpdate";
			public const string IsForceUpdate = "IsForceUpdate";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"VersionCode" , "int:"},
    			 {"PublishDate" , "DateTime:"},
    			 {"VersionDesc" , "string:"},
    			 {"FilePath" , "string:"},
    			 {"UpdatedCompany" , "string:"},
    			 {"SqlPath" , "string:"},
    			 {"VersionType" , "string:"},
    			 {"APPVersionCode" , "int:"},
    			 {"APPVersionDesc" , "string:"},
    			 {"APPType" , "int:1-业主端 2-员工端 3-商家端"},
    			 {"DisableUpdate" , "bool:"},
    			 {"IsForceUpdate" , "bool:"},
            };
		}
		#endregion
	}
}
