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
	/// This object represents the properties and methods of a Project.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Project 
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
		[DataObjectField(false, false, true)]
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
		private string _addMan = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
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
		private string _typeDesc = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TypeDesc
		{
			[DebuggerStepThrough()]
			get { return this._typeDesc; }
			set 
			{
				if (this._typeDesc != value) 
				{
					this._typeDesc = value;
					this.IsDirty = true;	
					OnPropertyChanged("TypeDesc");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _grade = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Grade
		{
			[DebuggerStepThrough()]
			get { return this._grade; }
			set 
			{
				if (this._grade != value) 
				{
					this._grade = value;
					this.IsDirty = true;	
					OnPropertyChanged("Grade");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _iconID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int IconID
		{
			[DebuggerStepThrough()]
			get { return this._iconID; }
			set 
			{
				if (this._iconID != value) 
				{
					this._iconID = value;
					this.IsDirty = true;	
					OnPropertyChanged("IconID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _level = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int Level
		{
			[DebuggerStepThrough()]
			get { return this._level; }
			set 
			{
				if (this._level != value) 
				{
					this._level = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isParent = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool isParent
		{
			[DebuggerStepThrough()]
			get { return this._isParent; }
			set 
			{
				if (this._isParent != value) 
				{
					this._isParent = value;
					this.IsDirty = true;	
					OnPropertyChanged("isParent");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _pName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string PName
		{
			[DebuggerStepThrough()]
			get { return this._pName; }
			set 
			{
				if (this._pName != value) 
				{
					this._pName = value;
					this.IsDirty = true;	
					OnPropertyChanged("PName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _companyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int CompanyID
		{
			[DebuggerStepThrough()]
			get { return this._companyID; }
			set 
			{
				if (this._companyID != value) 
				{
					this._companyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("CompanyID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _orderBy = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int OrderBy
		{
			[DebuggerStepThrough()]
			get { return this._orderBy; }
			set 
			{
				if (this._orderBy != value) 
				{
					this._orderBy = value;
					this.IsDirty = true;	
					OnPropertyChanged("OrderBy");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _fullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string FullName
		{
			[DebuggerStepThrough()]
			get { return this._fullName; }
			set 
			{
				if (this._fullName != value) 
				{
					this._fullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("FullName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _oriFullName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string OriFullName
		{
			[DebuggerStepThrough()]
			get { return this._oriFullName; }
			set 
			{
				if (this._oriFullName != value) 
				{
					this._oriFullName = value;
					this.IsDirty = true;	
					OnPropertyChanged("OriFullName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _allParentID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string AllParentID
		{
			[DebuggerStepThrough()]
			get { return this._allParentID; }
			set 
			{
				if (this._allParentID != value) 
				{
					this._allParentID = value;
					this.IsDirty = true;	
					OnPropertyChanged("AllParentID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _defaultOrder = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string DefaultOrder
		{
			[DebuggerStepThrough()]
			get { return this._defaultOrder; }
			set 
			{
				if (this._defaultOrder != value) 
				{
					this._defaultOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("DefaultOrder");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _roomProperty = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string RoomProperty
		{
			[DebuggerStepThrough()]
			get { return this._roomProperty; }
			set 
			{
				if (this._roomProperty != value) 
				{
					this._roomProperty = value;
					this.IsDirty = true;	
					OnPropertyChanged("RoomProperty");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _propertyID = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int PropertyID
		{
			[DebuggerStepThrough()]
			get { return this._propertyID; }
			set 
			{
				if (this._propertyID != value) 
				{
					this._propertyID = value;
					this.IsDirty = true;	
					OnPropertyChanged("PropertyID");
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
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[TypeDesc] nvarchar(50),
	[Grade] nvarchar(20),
	[IconID] int,
	[Level] int,
	[isParent] bit,
	[PName] nvarchar(100),
	[CompanyID] int,
	[OrderBy] int,
	[FullName] nvarchar(500),
	[OriFullName] nvarchar(500),
	[AllParentID] nvarchar(500),
	[DefaultOrder] nvarchar(500),
	[RoomProperty] nvarchar(50),
	[PropertyID] int
);

INSERT INTO [dbo].[Project] (
	[Project].[ParentID],
	[Project].[Name],
	[Project].[Description],
	[Project].[AddTime],
	[Project].[AddMan],
	[Project].[TypeDesc],
	[Project].[Grade],
	[Project].[IconID],
	[Project].[Level],
	[Project].[isParent],
	[Project].[PName],
	[Project].[CompanyID],
	[Project].[OrderBy],
	[Project].[FullName],
	[Project].[OriFullName],
	[Project].[AllParentID],
	[Project].[DefaultOrder],
	[Project].[RoomProperty],
	[Project].[PropertyID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TypeDesc],
	INSERTED.[Grade],
	INSERTED.[IconID],
	INSERTED.[Level],
	INSERTED.[isParent],
	INSERTED.[PName],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[FullName],
	INSERTED.[OriFullName],
	INSERTED.[AllParentID],
	INSERTED.[DefaultOrder],
	INSERTED.[RoomProperty],
	INSERTED.[PropertyID]
into @table
VALUES ( 
	@ParentID,
	@Name,
	@Description,
	@AddTime,
	@AddMan,
	@TypeDesc,
	@Grade,
	@IconID,
	@Level,
	@isParent,
	@PName,
	@CompanyID,
	@OrderBy,
	@FullName,
	@OriFullName,
	@AllParentID,
	@DefaultOrder,
	@RoomProperty,
	@PropertyID 
); 

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[TypeDesc],
	[Grade],
	[IconID],
	[Level],
	[isParent],
	[PName],
	[CompanyID],
	[OrderBy],
	[FullName],
	[OriFullName],
	[AllParentID],
	[DefaultOrder],
	[RoomProperty],
	[PropertyID] 
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
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[TypeDesc] nvarchar(50),
	[Grade] nvarchar(20),
	[IconID] int,
	[Level] int,
	[isParent] bit,
	[PName] nvarchar(100),
	[CompanyID] int,
	[OrderBy] int,
	[FullName] nvarchar(500),
	[OriFullName] nvarchar(500),
	[AllParentID] nvarchar(500),
	[DefaultOrder] nvarchar(500),
	[RoomProperty] nvarchar(50),
	[PropertyID] int
);

UPDATE [dbo].[Project] SET 
	[Project].[ParentID] = @ParentID,
	[Project].[Name] = @Name,
	[Project].[Description] = @Description,
	[Project].[AddTime] = @AddTime,
	[Project].[AddMan] = @AddMan,
	[Project].[TypeDesc] = @TypeDesc,
	[Project].[Grade] = @Grade,
	[Project].[IconID] = @IconID,
	[Project].[Level] = @Level,
	[Project].[isParent] = @isParent,
	[Project].[PName] = @PName,
	[Project].[CompanyID] = @CompanyID,
	[Project].[OrderBy] = @OrderBy,
	[Project].[FullName] = @FullName,
	[Project].[OriFullName] = @OriFullName,
	[Project].[AllParentID] = @AllParentID,
	[Project].[DefaultOrder] = @DefaultOrder,
	[Project].[RoomProperty] = @RoomProperty,
	[Project].[PropertyID] = @PropertyID 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TypeDesc],
	INSERTED.[Grade],
	INSERTED.[IconID],
	INSERTED.[Level],
	INSERTED.[isParent],
	INSERTED.[PName],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[FullName],
	INSERTED.[OriFullName],
	INSERTED.[AllParentID],
	INSERTED.[DefaultOrder],
	INSERTED.[RoomProperty],
	INSERTED.[PropertyID]
into @table
WHERE 
	[Project].[ID] = @ID

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[TypeDesc],
	[Grade],
	[IconID],
	[Level],
	[isParent],
	[PName],
	[CompanyID],
	[OrderBy],
	[FullName],
	[OriFullName],
	[AllParentID],
	[DefaultOrder],
	[RoomProperty],
	[PropertyID] 
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
DELETE FROM [dbo].[Project]
WHERE 
	[Project].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Project() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProject(this.ID));
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
	[Project].[ID],
	[Project].[ParentID],
	[Project].[Name],
	[Project].[Description],
	[Project].[AddTime],
	[Project].[AddMan],
	[Project].[TypeDesc],
	[Project].[Grade],
	[Project].[IconID],
	[Project].[Level],
	[Project].[isParent],
	[Project].[PName],
	[Project].[CompanyID],
	[Project].[OrderBy],
	[Project].[FullName],
	[Project].[OriFullName],
	[Project].[AllParentID],
	[Project].[DefaultOrder],
	[Project].[RoomProperty],
	[Project].[PropertyID]
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
                return "Project";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="grade">grade</param>
		/// <param name="iconID">iconID</param>
		/// <param name="level">level</param>
		/// <param name="isParent">isParent</param>
		/// <param name="pName">pName</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="fullName">fullName</param>
		/// <param name="oriFullName">oriFullName</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="defaultOrder">defaultOrder</param>
		/// <param name="roomProperty">roomProperty</param>
		/// <param name="propertyID">propertyID</param>
		public static void InsertProject(int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @typeDesc, string @grade, int @iconID, int @level, bool @isParent, string @pName, int @companyID, int @orderBy, string @fullName, string @oriFullName, string @allParentID, string @defaultOrder, string @roomProperty, int @propertyID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProject(@parentID, @name, @description, @addTime, @addMan, @typeDesc, @grade, @iconID, @level, @isParent, @pName, @companyID, @orderBy, @fullName, @oriFullName, @allParentID, @defaultOrder, @roomProperty, @propertyID, helper);
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
		/// Insert a Project into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="grade">grade</param>
		/// <param name="iconID">iconID</param>
		/// <param name="level">level</param>
		/// <param name="isParent">isParent</param>
		/// <param name="pName">pName</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="fullName">fullName</param>
		/// <param name="oriFullName">oriFullName</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="defaultOrder">defaultOrder</param>
		/// <param name="roomProperty">roomProperty</param>
		/// <param name="propertyID">propertyID</param>
		/// <param name="helper">helper</param>
		internal static void InsertProject(int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @typeDesc, string @grade, int @iconID, int @level, bool @isParent, string @pName, int @companyID, int @orderBy, string @fullName, string @oriFullName, string @allParentID, string @defaultOrder, string @roomProperty, int @propertyID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[TypeDesc] nvarchar(50),
	[Grade] nvarchar(20),
	[IconID] int,
	[Level] int,
	[isParent] bit,
	[PName] nvarchar(100),
	[CompanyID] int,
	[OrderBy] int,
	[FullName] nvarchar(500),
	[OriFullName] nvarchar(500),
	[AllParentID] nvarchar(500),
	[DefaultOrder] nvarchar(500),
	[RoomProperty] nvarchar(50),
	[PropertyID] int
);

INSERT INTO [dbo].[Project] (
	[Project].[ParentID],
	[Project].[Name],
	[Project].[Description],
	[Project].[AddTime],
	[Project].[AddMan],
	[Project].[TypeDesc],
	[Project].[Grade],
	[Project].[IconID],
	[Project].[Level],
	[Project].[isParent],
	[Project].[PName],
	[Project].[CompanyID],
	[Project].[OrderBy],
	[Project].[FullName],
	[Project].[OriFullName],
	[Project].[AllParentID],
	[Project].[DefaultOrder],
	[Project].[RoomProperty],
	[Project].[PropertyID]
) 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TypeDesc],
	INSERTED.[Grade],
	INSERTED.[IconID],
	INSERTED.[Level],
	INSERTED.[isParent],
	INSERTED.[PName],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[FullName],
	INSERTED.[OriFullName],
	INSERTED.[AllParentID],
	INSERTED.[DefaultOrder],
	INSERTED.[RoomProperty],
	INSERTED.[PropertyID]
into @table
VALUES ( 
	@ParentID,
	@Name,
	@Description,
	@AddTime,
	@AddMan,
	@TypeDesc,
	@Grade,
	@IconID,
	@Level,
	@isParent,
	@PName,
	@CompanyID,
	@OrderBy,
	@FullName,
	@OriFullName,
	@AllParentID,
	@DefaultOrder,
	@RoomProperty,
	@PropertyID 
); 

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[TypeDesc],
	[Grade],
	[IconID],
	[Level],
	[isParent],
	[PName],
	[CompanyID],
	[OrderBy],
	[FullName],
	[OriFullName],
	[AllParentID],
	[DefaultOrder],
	[RoomProperty],
	[PropertyID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@TypeDesc", EntityBase.GetDatabaseValue(@typeDesc)));
			parameters.Add(new SqlParameter("@Grade", EntityBase.GetDatabaseValue(@grade)));
			parameters.Add(new SqlParameter("@IconID", EntityBase.GetDatabaseValue(@iconID)));
			parameters.Add(new SqlParameter("@Level", EntityBase.GetDatabaseValue(@level)));
			parameters.Add(new SqlParameter("@isParent", @isParent));
			parameters.Add(new SqlParameter("@PName", EntityBase.GetDatabaseValue(@pName)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			parameters.Add(new SqlParameter("@OriFullName", EntityBase.GetDatabaseValue(@oriFullName)));
			parameters.Add(new SqlParameter("@AllParentID", EntityBase.GetDatabaseValue(@allParentID)));
			parameters.Add(new SqlParameter("@DefaultOrder", EntityBase.GetDatabaseValue(@defaultOrder)));
			parameters.Add(new SqlParameter("@RoomProperty", EntityBase.GetDatabaseValue(@roomProperty)));
			parameters.Add(new SqlParameter("@PropertyID", EntityBase.GetDatabaseValue(@propertyID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="grade">grade</param>
		/// <param name="iconID">iconID</param>
		/// <param name="level">level</param>
		/// <param name="isParent">isParent</param>
		/// <param name="pName">pName</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="fullName">fullName</param>
		/// <param name="oriFullName">oriFullName</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="defaultOrder">defaultOrder</param>
		/// <param name="roomProperty">roomProperty</param>
		/// <param name="propertyID">propertyID</param>
		public static void UpdateProject(int @iD, int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @typeDesc, string @grade, int @iconID, int @level, bool @isParent, string @pName, int @companyID, int @orderBy, string @fullName, string @oriFullName, string @allParentID, string @defaultOrder, string @roomProperty, int @propertyID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProject(@iD, @parentID, @name, @description, @addTime, @addMan, @typeDesc, @grade, @iconID, @level, @isParent, @pName, @companyID, @orderBy, @fullName, @oriFullName, @allParentID, @defaultOrder, @roomProperty, @propertyID, helper);
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
		/// Updates a Project into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="parentID">parentID</param>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addMan">addMan</param>
		/// <param name="typeDesc">typeDesc</param>
		/// <param name="grade">grade</param>
		/// <param name="iconID">iconID</param>
		/// <param name="level">level</param>
		/// <param name="isParent">isParent</param>
		/// <param name="pName">pName</param>
		/// <param name="companyID">companyID</param>
		/// <param name="orderBy">orderBy</param>
		/// <param name="fullName">fullName</param>
		/// <param name="oriFullName">oriFullName</param>
		/// <param name="allParentID">allParentID</param>
		/// <param name="defaultOrder">defaultOrder</param>
		/// <param name="roomProperty">roomProperty</param>
		/// <param name="propertyID">propertyID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProject(int @iD, int @parentID, string @name, string @description, DateTime @addTime, string @addMan, string @typeDesc, string @grade, int @iconID, int @level, bool @isParent, string @pName, int @companyID, int @orderBy, string @fullName, string @oriFullName, string @allParentID, string @defaultOrder, string @roomProperty, int @propertyID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[ParentID] int,
	[Name] nvarchar(100),
	[Description] ntext,
	[AddTime] datetime,
	[AddMan] nvarchar(50),
	[TypeDesc] nvarchar(50),
	[Grade] nvarchar(20),
	[IconID] int,
	[Level] int,
	[isParent] bit,
	[PName] nvarchar(100),
	[CompanyID] int,
	[OrderBy] int,
	[FullName] nvarchar(500),
	[OriFullName] nvarchar(500),
	[AllParentID] nvarchar(500),
	[DefaultOrder] nvarchar(500),
	[RoomProperty] nvarchar(50),
	[PropertyID] int
);

UPDATE [dbo].[Project] SET 
	[Project].[ParentID] = @ParentID,
	[Project].[Name] = @Name,
	[Project].[Description] = @Description,
	[Project].[AddTime] = @AddTime,
	[Project].[AddMan] = @AddMan,
	[Project].[TypeDesc] = @TypeDesc,
	[Project].[Grade] = @Grade,
	[Project].[IconID] = @IconID,
	[Project].[Level] = @Level,
	[Project].[isParent] = @isParent,
	[Project].[PName] = @PName,
	[Project].[CompanyID] = @CompanyID,
	[Project].[OrderBy] = @OrderBy,
	[Project].[FullName] = @FullName,
	[Project].[OriFullName] = @OriFullName,
	[Project].[AllParentID] = @AllParentID,
	[Project].[DefaultOrder] = @DefaultOrder,
	[Project].[RoomProperty] = @RoomProperty,
	[Project].[PropertyID] = @PropertyID 
output 
	INSERTED.[ID],
	INSERTED.[ParentID],
	INSERTED.[Name],
	INSERTED.[Description],
	INSERTED.[AddTime],
	INSERTED.[AddMan],
	INSERTED.[TypeDesc],
	INSERTED.[Grade],
	INSERTED.[IconID],
	INSERTED.[Level],
	INSERTED.[isParent],
	INSERTED.[PName],
	INSERTED.[CompanyID],
	INSERTED.[OrderBy],
	INSERTED.[FullName],
	INSERTED.[OriFullName],
	INSERTED.[AllParentID],
	INSERTED.[DefaultOrder],
	INSERTED.[RoomProperty],
	INSERTED.[PropertyID]
into @table
WHERE 
	[Project].[ID] = @ID

SELECT 
	[ID],
	[ParentID],
	[Name],
	[Description],
	[AddTime],
	[AddMan],
	[TypeDesc],
	[Grade],
	[IconID],
	[Level],
	[isParent],
	[PName],
	[CompanyID],
	[OrderBy],
	[FullName],
	[OriFullName],
	[AllParentID],
	[DefaultOrder],
	[RoomProperty],
	[PropertyID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@ParentID", EntityBase.GetDatabaseValue(@parentID)));
			parameters.Add(new SqlParameter("@Name", EntityBase.GetDatabaseValue(@name)));
			parameters.Add(new SqlParameter("@Description", EntityBase.GetDatabaseValue(@description)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddMan", EntityBase.GetDatabaseValue(@addMan)));
			parameters.Add(new SqlParameter("@TypeDesc", EntityBase.GetDatabaseValue(@typeDesc)));
			parameters.Add(new SqlParameter("@Grade", EntityBase.GetDatabaseValue(@grade)));
			parameters.Add(new SqlParameter("@IconID", EntityBase.GetDatabaseValue(@iconID)));
			parameters.Add(new SqlParameter("@Level", EntityBase.GetDatabaseValue(@level)));
			parameters.Add(new SqlParameter("@isParent", @isParent));
			parameters.Add(new SqlParameter("@PName", EntityBase.GetDatabaseValue(@pName)));
			parameters.Add(new SqlParameter("@CompanyID", EntityBase.GetDatabaseValue(@companyID)));
			parameters.Add(new SqlParameter("@OrderBy", EntityBase.GetDatabaseValue(@orderBy)));
			parameters.Add(new SqlParameter("@FullName", EntityBase.GetDatabaseValue(@fullName)));
			parameters.Add(new SqlParameter("@OriFullName", EntityBase.GetDatabaseValue(@oriFullName)));
			parameters.Add(new SqlParameter("@AllParentID", EntityBase.GetDatabaseValue(@allParentID)));
			parameters.Add(new SqlParameter("@DefaultOrder", EntityBase.GetDatabaseValue(@defaultOrder)));
			parameters.Add(new SqlParameter("@RoomProperty", EntityBase.GetDatabaseValue(@roomProperty)));
			parameters.Add(new SqlParameter("@PropertyID", EntityBase.GetDatabaseValue(@propertyID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProject(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProject(@iD, helper);
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
		/// Deletes a Project from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProject(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Project]
WHERE 
	[Project].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Project object.
		/// </summary>
		/// <returns>The newly created Project object.</returns>
		public static Project CreateProject()
		{
			return InitializeNew<Project>();
		}
		
		/// <summary>
		/// Retrieve information for a Project by a Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Project</returns>
		public static Project GetProject(int @iD)
		{
			string commandText = @"
SELECT 
" + Project.SelectFieldList + @"
FROM [dbo].[Project] 
WHERE 
	[Project].[ID] = @ID " + Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Project by a Project's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Project</returns>
		public static Project GetProject(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Project.SelectFieldList + @"
FROM [dbo].[Project] 
WHERE 
	[Project].[ID] = @ID " + Project.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Project>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Project objects.
		/// </summary>
		/// <returns>The retrieved collection of Project objects.</returns>
		public static EntityList<Project> GetProjects()
		{
			string commandText = @"
SELECT " + Project.SelectFieldList + "FROM [dbo].[Project] " + Project.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Project>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Project objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project objects.</returns>
        public static EntityList<Project> GetProjects(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project>(SelectFieldList, "FROM [dbo].[Project]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Project objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Project objects.</returns>
        public static EntityList<Project> GetProjects(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project>(SelectFieldList, "FROM [dbo].[Project]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjects(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjects(string.Empty, where, parameters, Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjects(prefix, where, parameters, Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjects(string.Empty, where, parameters, Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjects(prefix, where, parameters, Project.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Project objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Project objects.</returns>
		protected static EntityList<Project> GetProjects(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Project.SelectFieldList + "FROM [dbo].[Project] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Project>(reader);
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
        protected static EntityList<Project> GetProjects(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Project>(SelectFieldList, "FROM [dbo].[Project] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Project objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectCount()
        {
            return GetProjectCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Project objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Project] " + where;

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
		public static partial class Project_Properties
		{
			public const string ID = "ID";
			public const string ParentID = "ParentID";
			public const string Name = "Name";
			public const string Description = "Description";
			public const string AddTime = "AddTime";
			public const string AddMan = "AddMan";
			public const string TypeDesc = "TypeDesc";
			public const string Grade = "Grade";
			public const string IconID = "IconID";
			public const string Level = "Level";
			public const string isParent = "isParent";
			public const string PName = "PName";
			public const string CompanyID = "CompanyID";
			public const string OrderBy = "OrderBy";
			public const string FullName = "FullName";
			public const string OriFullName = "OriFullName";
			public const string AllParentID = "AllParentID";
			public const string DefaultOrder = "DefaultOrder";
			public const string RoomProperty = "RoomProperty";
			public const string PropertyID = "PropertyID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"ParentID" , "int:"},
    			 {"Name" , "string:"},
    			 {"Description" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddMan" , "string:"},
    			 {"TypeDesc" , "string:"},
    			 {"Grade" , "string:"},
    			 {"IconID" , "int:"},
    			 {"Level" , "int:"},
    			 {"isParent" , "bool:"},
    			 {"PName" , "string:"},
    			 {"CompanyID" , "int:"},
    			 {"OrderBy" , "int:"},
    			 {"FullName" , "string:"},
    			 {"OriFullName" , "string:"},
    			 {"AllParentID" , "string:"},
    			 {"DefaultOrder" , "string:"},
    			 {"RoomProperty" , "string:"},
    			 {"PropertyID" , "int:"},
            };
		}
		#endregion
	}
}
