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
	/// This object represents the properties and methods of a SysMenu.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class SysMenu 
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
		[DataObjectField(true, false, false)]
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
		private int _parentID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParentID
		{
			[DebuggerStepThrough()]
			get { return this._parentID; }
			set 
			{
				if (this._parentID != value) 
				{
					this._parentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _name = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
			set 
			{
				if (this._name != value) 
				{
					this._name = value;
					this.IsDirty = true;	
					OnPropertyChanged("Name");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _title = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string Title
		{
			[DebuggerStepThrough()]
			get { return this._title; }
			set 
			{
				if (this._title != value) 
				{
					this._title = value;
					this.IsDirty = true;	
					OnPropertyChanged("Title");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _moduleCode = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ModuleCode
		{
			[DebuggerStepThrough()]
			get { return this._moduleCode; }
			set 
			{
				if (this._moduleCode != value) 
				{
					this._moduleCode = value;
					this.IsDirty = true;	
					OnPropertyChanged("ModuleCode");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isAuthority = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsAuthority
		{
			[DebuggerStepThrough()]
			get { return this._isAuthority; }
			set 
			{
				if (this._isAuthority != value) 
				{
					this._isAuthority = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsAuthority");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _disabled = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool Disabled
		{
			[DebuggerStepThrough()]
			get { return this._disabled; }
			set 
			{
				if (this._disabled != value) 
				{
					this._disabled = value;
					this.IsDirty = true;	
					OnPropertyChanged("Disabled");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _url = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Url
		{
			[DebuggerStepThrough()]
			get { return this._url; }
			set 
			{
				if (this._url != value) 
				{
					this._url = value;
					this.IsDirty = true;	
					OnPropertyChanged("Url");
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
		private string _cssClass = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string CssClass
		{
			[DebuggerStepThrough()]
			get { return this._cssClass; }
			set 
			{
				if (this._cssClass != value) 
				{
					this._cssClass = value;
					this.IsDirty = true;	
					OnPropertyChanged("CssClass");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _sortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int SortOrder
		{
			[DebuggerStepThrough()]
			get { return this._sortOrder; }
			set 
			{
				if (this._sortOrder != value) 
				{
					this._sortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("SortOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _description = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Description
		{
			[DebuggerStepThrough()]
			get { return this._description; }
			set 
			{
				if (this._description != value) 
				{
					this._description = value;
					this.IsDirty = true;	
					OnPropertyChanged("Description");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _imgUrl = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string ImgUrl
		{
			[DebuggerStepThrough()]
			get { return this._imgUrl; }
			set 
			{
				if (this._imgUrl != value) 
				{
					this._imgUrl = value;
					this.IsDirty = true;	
					OnPropertyChanged("ImgUrl");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iconPath = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string IconPath
		{
			[DebuggerStepThrough()]
			get { return this._iconPath; }
			set 
			{
				if (this._iconPath != value) 
				{
					this._iconPath = value;
					this.IsDirty = true;	
					OnPropertyChanged("IconPath");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _usingImgURL = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool UsingImgURL
		{
			[DebuggerStepThrough()]
			get { return this._usingImgURL; }
			set 
			{
				if (this._usingImgURL != value) 
				{
					this._usingImgURL = value;
					this.IsDirty = true;	
					OnPropertyChanged("UsingImgURL");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _groupName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string GroupName
		{
			[DebuggerStepThrough()]
			get { return this._groupName; }
			set 
			{
				if (this._groupName != value) 
				{
					this._groupName = value;
					this.IsDirty = true;	
					OnPropertyChanged("GroupName");
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
	[ParentID] int,
	[Name] nvarchar(50),
	[Title] nvarchar(50),
	[ModuleCode] nvarchar(50),
	[IsAuthority] bit,
	[Disabled] bit,
	[Url] nvarchar(200),
	[Icon] nvarchar(200),
	[CssClass] nvarchar(200),
	[SortOrder] int,
	[Description] nvarchar(200),
	[ImgUrl] nvarchar(500),
	[IconPath] nvarchar(500),
	[UsingImgURL] bit,
	[GroupName] nvarchar(500)
);

INSERT INTO [dbo].[SysMenu] (
	[SysMenu].[ID],
	[SysMenu].[ParentID],
	[SysMenu].[Name],
	[SysMenu].[Title],
	[SysMenu].[ModuleCode],
	[SysMenu].[IsAuthority],
	[SysMenu].[Disabled],
	[SysMenu].[Url],
	[SysMenu].[Icon],
	[SysMenu].[CssClass],
	[SysMenu].[SortOrder],
	[SysMenu].[Description],
	[SysMenu].[ImgUrl],
	[SysMenu].[IconPath],
	[SysMenu].[UsingImgURL],
	[SysMenu].[GroupName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Title],
	INSERTED.[ModuleCode],
	INSERTED.[IsAuthority],
	INSERTED.[Disabled],
	INSERTED.[Url],
	INSERTED.[Icon],
	INSERTED.[CssClass],
	INSERTED.[SortOrder],
	INSERTED.[Description],
	INSERTED.[ImgUrl],
	INSERTED.[IconPath],
	INSERTED.[UsingImgURL],
	INSERTED.[GroupName]
into @table
VALUES ( 
	@ID,
	@ParentID,
	@Name,
	@Title,
	@ModuleCode,
	@IsAuthority,
	@Disabled,
	@Url,
	@Icon,
	@CssClass,
	@SortOrder,
	@Description,
	@ImgUrl,
	@IconPath,
	@UsingImgURL,
	@GroupName 
); 

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Title],
	[ModuleCode],
	[IsAuthority],
	[Disabled],
	[Url],
	[Icon],
	[CssClass],
	[SortOrder],
	[Description],
	[ImgUrl],
	[IconPath],
	[UsingImgURL],
	[GroupName] 
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
	[ParentID] int,
	[Name] nvarchar(50),
	[Title] nvarchar(50),
	[ModuleCode] nvarchar(50),
	[IsAuthority] bit,
	[Disabled] bit,
	[Url] nvarchar(200),
	[Icon] nvarchar(200),
	[CssClass] nvarchar(200),
	[SortOrder] int,
	[Description] nvarchar(200),
	[ImgUrl] nvarchar(500),
	[IconPath] nvarchar(500),
	[UsingImgURL] bit,
	[GroupName] nvarchar(500)
);

UPDATE [dbo].[SysMenu] SET 
	[SysMenu].[ParentID] = @ParentID,
	[SysMenu].[Name] = @Name,
	[SysMenu].[Title] = @Title,
	[SysMenu].[ModuleCode] = @ModuleCode,
	[SysMenu].[IsAuthority] = @IsAuthority,
	[SysMenu].[Disabled] = @Disabled,
	[SysMenu].[Url] = @Url,
	[SysMenu].[Icon] = @Icon,
	[SysMenu].[CssClass] = @CssClass,
	[SysMenu].[SortOrder] = @SortOrder,
	[SysMenu].[Description] = @Description,
	[SysMenu].[ImgUrl] = @ImgUrl,
	[SysMenu].[IconPath] = @IconPath,
	[SysMenu].[UsingImgURL] = @UsingImgURL,
	[SysMenu].[GroupName] = @GroupName 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Title],
	INSERTED.[ModuleCode],
	INSERTED.[IsAuthority],
	INSERTED.[Disabled],
	INSERTED.[Url],
	INSERTED.[Icon],
	INSERTED.[CssClass],
	INSERTED.[SortOrder],
	INSERTED.[Description],
	INSERTED.[ImgUrl],
	INSERTED.[IconPath],
	INSERTED.[UsingImgURL],
	INSERTED.[GroupName]
into @table
WHERE 
	[SysMenu].[ID] = @ID

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Title],
	[ModuleCode],
	[IsAuthority],
	[Disabled],
	[Url],
	[Icon],
	[CssClass],
	[SortOrder],
	[Description],
	[ImgUrl],
	[IconPath],
	[UsingImgURL],
	[GroupName] 
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
DELETE FROM [dbo].[SysMenu]
WHERE 
	[SysMenu].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public SysMenu() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSysMenu(this.ID));
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
	[SysMenu].[ID],
	[SysMenu].[ParentID],
	[SysMenu].[Name],
	[SysMenu].[Title],
	[SysMenu].[ModuleCode],
	[SysMenu].[IsAuthority],
	[SysMenu].[Disabled],
	[SysMenu].[Url],
	[SysMenu].[Icon],
	[SysMenu].[CssClass],
	[SysMenu].[SortOrder],
	[SysMenu].[Description],
	[SysMenu].[ImgUrl],
	[SysMenu].[IconPath],
	[SysMenu].[UsingImgURL],
	[SysMenu].[GroupName]
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
                return "SysMenu";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a SysMenu into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="title">title</param>
		/// <param name="moduleCode">moduleCode</param>
		/// <param name="isAuthority">isAuthority</param>
		/// <param name="disabled">disabled</param>
		/// <param name="url">url</param>
		/// <param name="icon">icon</param>
		/// <param name="cssClass">cssClass</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="description">description</param>
		/// <param name="imgUrl">imgUrl</param>
		/// <param name="iconPath">iconPath</param>
		/// <param name="usingImgURL">usingImgURL</param>
		/// <param name="groupName">groupName</param>
		public static void InsertSysMenu(int @iD, int @parentID, string @name, string @title, string @moduleCode, bool @isAuthority, bool @disabled, string @url, string @icon, string @cssClass, int @sortOrder, string @description, string @imgUrl, string @iconPath, bool @usingImgURL, string @groupName)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSysMenu(@iD, @parentID, @name, @title, @moduleCode, @isAuthority, @disabled, @url, @icon, @cssClass, @sortOrder, @description, @imgUrl, @iconPath, @usingImgURL, @groupName, helper);
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
		/// Insert a SysMenu into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="title">title</param>
		/// <param name="moduleCode">moduleCode</param>
		/// <param name="isAuthority">isAuthority</param>
		/// <param name="disabled">disabled</param>
		/// <param name="url">url</param>
		/// <param name="icon">icon</param>
		/// <param name="cssClass">cssClass</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="description">description</param>
		/// <param name="imgUrl">imgUrl</param>
		/// <param name="iconPath">iconPath</param>
		/// <param name="usingImgURL">usingImgURL</param>
		/// <param name="groupName">groupName</param>
		/// <param name="helper">helper</param>
		internal static void InsertSysMenu(int @iD, int @parentID, string @name, string @title, string @moduleCode, bool @isAuthority, bool @disabled, string @url, string @icon, string @cssClass, int @sortOrder, string @description, string @imgUrl, string @iconPath, bool @usingImgURL, string @groupName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ParentID] int,
	[Name] nvarchar(50),
	[Title] nvarchar(50),
	[ModuleCode] nvarchar(50),
	[IsAuthority] bit,
	[Disabled] bit,
	[Url] nvarchar(200),
	[Icon] nvarchar(200),
	[CssClass] nvarchar(200),
	[SortOrder] int,
	[Description] nvarchar(200),
	[ImgUrl] nvarchar(500),
	[IconPath] nvarchar(500),
	[UsingImgURL] bit,
	[GroupName] nvarchar(500)
);

INSERT INTO [dbo].[SysMenu] (
	[SysMenu].[ID],
	[SysMenu].[ParentID],
	[SysMenu].[Name],
	[SysMenu].[Title],
	[SysMenu].[ModuleCode],
	[SysMenu].[IsAuthority],
	[SysMenu].[Disabled],
	[SysMenu].[Url],
	[SysMenu].[Icon],
	[SysMenu].[CssClass],
	[SysMenu].[SortOrder],
	[SysMenu].[Description],
	[SysMenu].[ImgUrl],
	[SysMenu].[IconPath],
	[SysMenu].[UsingImgURL],
	[SysMenu].[GroupName]
) 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Title],
	INSERTED.[ModuleCode],
	INSERTED.[IsAuthority],
	INSERTED.[Disabled],
	INSERTED.[Url],
	INSERTED.[Icon],
	INSERTED.[CssClass],
	INSERTED.[SortOrder],
	INSERTED.[Description],
	INSERTED.[ImgUrl],
	INSERTED.[IconPath],
	INSERTED.[UsingImgURL],
	INSERTED.[GroupName]
into @table
VALUES ( 
	@ID,
	@ParentID,
	@Name,
	@Title,
	@ModuleCode,
	@IsAuthority,
	@Disabled,
	@Url,
	@Icon,
	@CssClass,
	@SortOrder,
	@Description,
	@ImgUrl,
	@IconPath,
	@UsingImgURL,
	@GroupName 
); 

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Title],
	[ModuleCode],
	[IsAuthority],
	[Disabled],
	[Url],
	[Icon],
	[CssClass],
	[SortOrder],
	[Description],
	[ImgUrl],
	[IconPath],
	[UsingImgURL],
	[GroupName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@ModuleCode", EntityBase.GetDatabaseValue(@moduleCode)));
			parameters.Add(new SqlParameter("@IsAuthority", @isAuthority));
			parameters.Add(new SqlParameter("@Disabled", @disabled));
			parameters.Add(new SqlParameter("@Url", EntityBase.GetDatabaseValue(@url)));
			parameters.Add(new SqlParameter("@Icon", EntityBase.GetDatabaseValue(@icon)));
			parameters.Add(new SqlParameter("@CssClass", EntityBase.GetDatabaseValue(@cssClass)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@ImgUrl", EntityBase.GetDatabaseValue(@imgUrl)));
			parameters.Add(new SqlParameter("@IconPath", EntityBase.GetDatabaseValue(@iconPath)));
			parameters.Add(new SqlParameter("@UsingImgURL", @usingImgURL));
			parameters.Add(new SqlParameter("@GroupName", EntityBase.GetDatabaseValue(@groupName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a SysMenu into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="title">title</param>
		/// <param name="moduleCode">moduleCode</param>
		/// <param name="isAuthority">isAuthority</param>
		/// <param name="disabled">disabled</param>
		/// <param name="url">url</param>
		/// <param name="icon">icon</param>
		/// <param name="cssClass">cssClass</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="description">description</param>
		/// <param name="imgUrl">imgUrl</param>
		/// <param name="iconPath">iconPath</param>
		/// <param name="usingImgURL">usingImgURL</param>
		/// <param name="groupName">groupName</param>
		public static void UpdateSysMenu(int @iD, int @parentID, string @name, string @title, string @moduleCode, bool @isAuthority, bool @disabled, string @url, string @icon, string @cssClass, int @sortOrder, string @description, string @imgUrl, string @iconPath, bool @usingImgURL, string @groupName)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSysMenu(@iD, @parentID, @name, @title, @moduleCode, @isAuthority, @disabled, @url, @icon, @cssClass, @sortOrder, @description, @imgUrl, @iconPath, @usingImgURL, @groupName, helper);
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
		/// Updates a SysMenu into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="title">title</param>
		/// <param name="moduleCode">moduleCode</param>
		/// <param name="isAuthority">isAuthority</param>
		/// <param name="disabled">disabled</param>
		/// <param name="url">url</param>
		/// <param name="icon">icon</param>
		/// <param name="cssClass">cssClass</param>
		/// <param name="sortOrder">sortOrder</param>
		/// <param name="description">description</param>
		/// <param name="imgUrl">imgUrl</param>
		/// <param name="iconPath">iconPath</param>
		/// <param name="usingImgURL">usingImgURL</param>
		/// <param name="groupName">groupName</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSysMenu(int @iD, int @parentID, string @name, string @title, string @moduleCode, bool @isAuthority, bool @disabled, string @url, string @icon, string @cssClass, int @sortOrder, string @description, string @imgUrl, string @iconPath, bool @usingImgURL, string @groupName, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ParentID] int,
	[Name] nvarchar(50),
	[Title] nvarchar(50),
	[ModuleCode] nvarchar(50),
	[IsAuthority] bit,
	[Disabled] bit,
	[Url] nvarchar(200),
	[Icon] nvarchar(200),
	[CssClass] nvarchar(200),
	[SortOrder] int,
	[Description] nvarchar(200),
	[ImgUrl] nvarchar(500),
	[IconPath] nvarchar(500),
	[UsingImgURL] bit,
	[GroupName] nvarchar(500)
);

UPDATE [dbo].[SysMenu] SET 
	[SysMenu].[ParentID] = @ParentID,
	[SysMenu].[Name] = @Name,
	[SysMenu].[Title] = @Title,
	[SysMenu].[ModuleCode] = @ModuleCode,
	[SysMenu].[IsAuthority] = @IsAuthority,
	[SysMenu].[Disabled] = @Disabled,
	[SysMenu].[Url] = @Url,
	[SysMenu].[Icon] = @Icon,
	[SysMenu].[CssClass] = @CssClass,
	[SysMenu].[SortOrder] = @SortOrder,
	[SysMenu].[Description] = @Description,
	[SysMenu].[ImgUrl] = @ImgUrl,
	[SysMenu].[IconPath] = @IconPath,
	[SysMenu].[UsingImgURL] = @UsingImgURL,
	[SysMenu].[GroupName] = @GroupName 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Title],
	INSERTED.[ModuleCode],
	INSERTED.[IsAuthority],
	INSERTED.[Disabled],
	INSERTED.[Url],
	INSERTED.[Icon],
	INSERTED.[CssClass],
	INSERTED.[SortOrder],
	INSERTED.[Description],
	INSERTED.[ImgUrl],
	INSERTED.[IconPath],
	INSERTED.[UsingImgURL],
	INSERTED.[GroupName]
into @table
WHERE 
	[SysMenu].[ID] = @ID

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Title],
	[ModuleCode],
	[IsAuthority],
	[Disabled],
	[Url],
	[Icon],
	[CssClass],
	[SortOrder],
	[Description],
	[ImgUrl],
	[IconPath],
	[UsingImgURL],
	[GroupName] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@ModuleCode", EntityBase.GetDatabaseValue(@moduleCode)));
			parameters.Add(new SqlParameter("@IsAuthority", @isAuthority));
			parameters.Add(new SqlParameter("@Disabled", @disabled));
			parameters.Add(new SqlParameter("@Url", EntityBase.GetDatabaseValue(@url)));
			parameters.Add(new SqlParameter("@Icon", EntityBase.GetDatabaseValue(@icon)));
			parameters.Add(new SqlParameter("@CssClass", EntityBase.GetDatabaseValue(@cssClass)));
			parameters.Add(new SqlParameter("@SortOrder", EntityBase.GetDatabaseValue(@sortOrder)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@ImgUrl", EntityBase.GetDatabaseValue(@imgUrl)));
			parameters.Add(new SqlParameter("@IconPath", EntityBase.GetDatabaseValue(@iconPath)));
			parameters.Add(new SqlParameter("@UsingImgURL", @usingImgURL));
			parameters.Add(new SqlParameter("@GroupName", EntityBase.GetDatabaseValue(@groupName)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a SysMenu from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSysMenu(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSysMenu(@iD, helper);
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
		/// Deletes a SysMenu from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSysMenu(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[SysMenu]
WHERE 
	[SysMenu].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new SysMenu object.
		/// </summary>
		/// <returns>The newly created SysMenu object.</returns>
		public static SysMenu CreateSysMenu()
		{
			return InitializeNew<SysMenu>();
		}
		
		/// <summary>
		/// Retrieve information for a SysMenu by a SysMenu's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>SysMenu</returns>
		public static SysMenu GetSysMenu(int @iD)
		{
			string commandText = @"
SELECT 
" + SysMenu.SelectFieldList + @"
FROM [dbo].[SysMenu] 
WHERE 
	[SysMenu].[ID] = @ID " + SysMenu.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysMenu>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a SysMenu by a SysMenu's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>SysMenu</returns>
		public static SysMenu GetSysMenu(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + SysMenu.SelectFieldList + @"
FROM [dbo].[SysMenu] 
WHERE 
	[SysMenu].[ID] = @ID " + SysMenu.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<SysMenu>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection SysMenu objects.
		/// </summary>
		/// <returns>The retrieved collection of SysMenu objects.</returns>
		public static EntityList<SysMenu> GetSysMenus()
		{
			string commandText = @"
SELECT " + SysMenu.SelectFieldList + "FROM [dbo].[SysMenu] " + SysMenu.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<SysMenu>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection SysMenu objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysMenu objects.</returns>
        public static EntityList<SysMenu> GetSysMenus(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysMenu>(SelectFieldList, "FROM [dbo].[SysMenu]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection SysMenu objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of SysMenu objects.</returns>
        public static EntityList<SysMenu> GetSysMenus(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysMenu>(SelectFieldList, "FROM [dbo].[SysMenu]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection SysMenu objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of SysMenu objects.</returns>
		protected static EntityList<SysMenu> GetSysMenus(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysMenus(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection SysMenu objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysMenu objects.</returns>
		protected static EntityList<SysMenu> GetSysMenus(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysMenus(string.Empty, where, parameters, SysMenu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysMenu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of SysMenu objects.</returns>
		protected static EntityList<SysMenu> GetSysMenus(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSysMenus(prefix, where, parameters, SysMenu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysMenu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysMenu objects.</returns>
		protected static EntityList<SysMenu> GetSysMenus(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysMenus(string.Empty, where, parameters, SysMenu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysMenu objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of SysMenu objects.</returns>
		protected static EntityList<SysMenu> GetSysMenus(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSysMenus(prefix, where, parameters, SysMenu.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection SysMenu objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of SysMenu objects.</returns>
		protected static EntityList<SysMenu> GetSysMenus(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + SysMenu.SelectFieldList + "FROM [dbo].[SysMenu] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<SysMenu>(reader);
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
        protected static EntityList<SysMenu> GetSysMenus(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<SysMenu>(SelectFieldList, "FROM [dbo].[SysMenu] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of SysMenu objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysMenuCount()
        {
            return GetSysMenuCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of SysMenu objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSysMenuCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[SysMenu] " + where;

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
		public static partial class SysMenu_Properties
		{
			public const string ID = "ID";
			public const string ParentID = "ParentID";
			public const string Name = "Name";
			public const string Title = "Title";
			public const string ModuleCode = "ModuleCode";
			public const string IsAuthority = "IsAuthority";
			public const string Disabled = "Disabled";
			public const string Url = "Url";
			public const string Icon = "Icon";
			public const string CssClass = "CssClass";
			public const string SortOrder = "SortOrder";
			public const string Description = "Description";
			public const string ImgUrl = "ImgUrl";
			public const string IconPath = "IconPath";
			public const string UsingImgURL = "UsingImgURL";
			public const string GroupName = "GroupName";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ParentID" , "int:"},
    			 {"Name" , "string:"},
    			 {"Title" , "string:"},
    			 {"ModuleCode" , "string:"},
    			 {"IsAuthority" , "bool:"},
    			 {"Disabled" , "bool:"},
    			 {"Url" , "string:"},
    			 {"Icon" , "string:"},
    			 {"CssClass" , "string:"},
    			 {"SortOrder" , "int:"},
    			 {"Description" , "string:"},
    			 {"ImgUrl" , "string:"},
    			 {"IconPath" , "string:"},
    			 {"UsingImgURL" , "bool:"},
    			 {"GroupName" , "string:"},
            };
		}
		#endregion
	}
}
