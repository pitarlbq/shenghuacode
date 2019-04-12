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
	/// This object represents the properties and methods of a ProjectProperty.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class ProjectProperty 
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
		private int _mainSortOrder = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int MainSortOrder
		{
			[DebuggerStepThrough()]
			get { return this._mainSortOrder; }
			set 
			{
				if (this._mainSortOrder != value) 
				{
					this._mainSortOrder = value;
					this.IsDirty = true;	
					OnPropertyChanged("MainSortOrder");
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
		private bool _isBelongProject = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsBelongProject
		{
			[DebuggerStepThrough()]
			get { return this._isBelongProject; }
			set 
			{
				if (this._isBelongProject != value) 
				{
					this._isBelongProject = value;
					this.IsDirty = true;	
					OnPropertyChanged("IsBelongProject");
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
		[DataObjectField(false, false, true)]
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
		private string _level1 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level1
		{
			[DebuggerStepThrough()]
			get { return this._level1; }
			set 
			{
				if (this._level1 != value) 
				{
					this._level1 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level1");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _level2 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level2
		{
			[DebuggerStepThrough()]
			get { return this._level2; }
			set 
			{
				if (this._level2 != value) 
				{
					this._level2 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level2");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _level3 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level3
		{
			[DebuggerStepThrough()]
			get { return this._level3; }
			set 
			{
				if (this._level3 != value) 
				{
					this._level3 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level3");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _level4 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level4
		{
			[DebuggerStepThrough()]
			get { return this._level4; }
			set 
			{
				if (this._level4 != value) 
				{
					this._level4 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level4");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _level5 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level5
		{
			[DebuggerStepThrough()]
			get { return this._level5; }
			set 
			{
				if (this._level5 != value) 
				{
					this._level5 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level5");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _level6 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level6
		{
			[DebuggerStepThrough()]
			get { return this._level6; }
			set 
			{
				if (this._level6 != value) 
				{
					this._level6 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level6");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _level7 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level7
		{
			[DebuggerStepThrough()]
			get { return this._level7; }
			set 
			{
				if (this._level7 != value) 
				{
					this._level7 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level7");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _level8 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level8
		{
			[DebuggerStepThrough()]
			get { return this._level8; }
			set 
			{
				if (this._level8 != value) 
				{
					this._level8 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level8");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _level9 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level9
		{
			[DebuggerStepThrough()]
			get { return this._level9; }
			set 
			{
				if (this._level9 != value) 
				{
					this._level9 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level9");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _level10 = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Level10
		{
			[DebuggerStepThrough()]
			get { return this._level10; }
			set 
			{
				if (this._level10 != value) 
				{
					this._level10 = value;
					this.IsDirty = true;	
					OnPropertyChanged("Level10");
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
	[MainSortOrder] int,
	[AddTime] datetime,
	[IsBelongProject] bit,
	[Title] nvarchar(100),
	[Level1] nvarchar(100),
	[Level2] nvarchar(100),
	[Level3] nvarchar(100),
	[Level4] nvarchar(100),
	[Level5] nvarchar(100),
	[Level6] nvarchar(100),
	[Level7] nvarchar(100),
	[Level8] nvarchar(100),
	[Level9] nvarchar(100),
	[Level10] nvarchar(100)
);

INSERT INTO [dbo].[ProjectProperty] (
	[ProjectProperty].[MainSortOrder],
	[ProjectProperty].[AddTime],
	[ProjectProperty].[IsBelongProject],
	[ProjectProperty].[Title],
	[ProjectProperty].[Level1],
	[ProjectProperty].[Level2],
	[ProjectProperty].[Level3],
	[ProjectProperty].[Level4],
	[ProjectProperty].[Level5],
	[ProjectProperty].[Level6],
	[ProjectProperty].[Level7],
	[ProjectProperty].[Level8],
	[ProjectProperty].[Level9],
	[ProjectProperty].[Level10]
) 
output 
	INSERTED.[ID],
	INSERTED.[MainSortOrder],
	INSERTED.[AddTime],
	INSERTED.[IsBelongProject],
	INSERTED.[Title],
	INSERTED.[Level1],
	INSERTED.[Level2],
	INSERTED.[Level3],
	INSERTED.[Level4],
	INSERTED.[Level5],
	INSERTED.[Level6],
	INSERTED.[Level7],
	INSERTED.[Level8],
	INSERTED.[Level9],
	INSERTED.[Level10]
into @table
VALUES ( 
	@MainSortOrder,
	@AddTime,
	@IsBelongProject,
	@Title,
	@Level1,
	@Level2,
	@Level3,
	@Level4,
	@Level5,
	@Level6,
	@Level7,
	@Level8,
	@Level9,
	@Level10 
); 

SELECT 
	[ID],
	[MainSortOrder],
	[AddTime],
	[IsBelongProject],
	[Title],
	[Level1],
	[Level2],
	[Level3],
	[Level4],
	[Level5],
	[Level6],
	[Level7],
	[Level8],
	[Level9],
	[Level10] 
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
	[MainSortOrder] int,
	[AddTime] datetime,
	[IsBelongProject] bit,
	[Title] nvarchar(100),
	[Level1] nvarchar(100),
	[Level2] nvarchar(100),
	[Level3] nvarchar(100),
	[Level4] nvarchar(100),
	[Level5] nvarchar(100),
	[Level6] nvarchar(100),
	[Level7] nvarchar(100),
	[Level8] nvarchar(100),
	[Level9] nvarchar(100),
	[Level10] nvarchar(100)
);

UPDATE [dbo].[ProjectProperty] SET 
	[ProjectProperty].[MainSortOrder] = @MainSortOrder,
	[ProjectProperty].[AddTime] = @AddTime,
	[ProjectProperty].[IsBelongProject] = @IsBelongProject,
	[ProjectProperty].[Title] = @Title,
	[ProjectProperty].[Level1] = @Level1,
	[ProjectProperty].[Level2] = @Level2,
	[ProjectProperty].[Level3] = @Level3,
	[ProjectProperty].[Level4] = @Level4,
	[ProjectProperty].[Level5] = @Level5,
	[ProjectProperty].[Level6] = @Level6,
	[ProjectProperty].[Level7] = @Level7,
	[ProjectProperty].[Level8] = @Level8,
	[ProjectProperty].[Level9] = @Level9,
	[ProjectProperty].[Level10] = @Level10 
output 
	INSERTED.[ID],
	INSERTED.[MainSortOrder],
	INSERTED.[AddTime],
	INSERTED.[IsBelongProject],
	INSERTED.[Title],
	INSERTED.[Level1],
	INSERTED.[Level2],
	INSERTED.[Level3],
	INSERTED.[Level4],
	INSERTED.[Level5],
	INSERTED.[Level6],
	INSERTED.[Level7],
	INSERTED.[Level8],
	INSERTED.[Level9],
	INSERTED.[Level10]
into @table
WHERE 
	[ProjectProperty].[ID] = @ID

SELECT 
	[ID],
	[MainSortOrder],
	[AddTime],
	[IsBelongProject],
	[Title],
	[Level1],
	[Level2],
	[Level3],
	[Level4],
	[Level5],
	[Level6],
	[Level7],
	[Level8],
	[Level9],
	[Level10] 
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
DELETE FROM [dbo].[ProjectProperty]
WHERE 
	[ProjectProperty].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ProjectProperty() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetProjectProperty(this.ID));
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
	[ProjectProperty].[ID],
	[ProjectProperty].[MainSortOrder],
	[ProjectProperty].[AddTime],
	[ProjectProperty].[IsBelongProject],
	[ProjectProperty].[Title],
	[ProjectProperty].[Level1],
	[ProjectProperty].[Level2],
	[ProjectProperty].[Level3],
	[ProjectProperty].[Level4],
	[ProjectProperty].[Level5],
	[ProjectProperty].[Level6],
	[ProjectProperty].[Level7],
	[ProjectProperty].[Level8],
	[ProjectProperty].[Level9],
	[ProjectProperty].[Level10]
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
                return "ProjectProperty";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a ProjectProperty into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="mainSortOrder">mainSortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isBelongProject">isBelongProject</param>
		/// <param name="title">title</param>
		/// <param name="level1">level1</param>
		/// <param name="level2">level2</param>
		/// <param name="level3">level3</param>
		/// <param name="level4">level4</param>
		/// <param name="level5">level5</param>
		/// <param name="level6">level6</param>
		/// <param name="level7">level7</param>
		/// <param name="level8">level8</param>
		/// <param name="level9">level9</param>
		/// <param name="level10">level10</param>
		public static void InsertProjectProperty(int @mainSortOrder, DateTime @addTime, bool @isBelongProject, string @title, string @level1, string @level2, string @level3, string @level4, string @level5, string @level6, string @level7, string @level8, string @level9, string @level10)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertProjectProperty(@mainSortOrder, @addTime, @isBelongProject, @title, @level1, @level2, @level3, @level4, @level5, @level6, @level7, @level8, @level9, @level10, helper);
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
		/// Insert a ProjectProperty into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="mainSortOrder">mainSortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isBelongProject">isBelongProject</param>
		/// <param name="title">title</param>
		/// <param name="level1">level1</param>
		/// <param name="level2">level2</param>
		/// <param name="level3">level3</param>
		/// <param name="level4">level4</param>
		/// <param name="level5">level5</param>
		/// <param name="level6">level6</param>
		/// <param name="level7">level7</param>
		/// <param name="level8">level8</param>
		/// <param name="level9">level9</param>
		/// <param name="level10">level10</param>
		/// <param name="helper">helper</param>
		internal static void InsertProjectProperty(int @mainSortOrder, DateTime @addTime, bool @isBelongProject, string @title, string @level1, string @level2, string @level3, string @level4, string @level5, string @level6, string @level7, string @level8, string @level9, string @level10, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MainSortOrder] int,
	[AddTime] datetime,
	[IsBelongProject] bit,
	[Title] nvarchar(100),
	[Level1] nvarchar(100),
	[Level2] nvarchar(100),
	[Level3] nvarchar(100),
	[Level4] nvarchar(100),
	[Level5] nvarchar(100),
	[Level6] nvarchar(100),
	[Level7] nvarchar(100),
	[Level8] nvarchar(100),
	[Level9] nvarchar(100),
	[Level10] nvarchar(100)
);

INSERT INTO [dbo].[ProjectProperty] (
	[ProjectProperty].[MainSortOrder],
	[ProjectProperty].[AddTime],
	[ProjectProperty].[IsBelongProject],
	[ProjectProperty].[Title],
	[ProjectProperty].[Level1],
	[ProjectProperty].[Level2],
	[ProjectProperty].[Level3],
	[ProjectProperty].[Level4],
	[ProjectProperty].[Level5],
	[ProjectProperty].[Level6],
	[ProjectProperty].[Level7],
	[ProjectProperty].[Level8],
	[ProjectProperty].[Level9],
	[ProjectProperty].[Level10]
) 
output 
	INSERTED.[ID],
	INSERTED.[MainSortOrder],
	INSERTED.[AddTime],
	INSERTED.[IsBelongProject],
	INSERTED.[Title],
	INSERTED.[Level1],
	INSERTED.[Level2],
	INSERTED.[Level3],
	INSERTED.[Level4],
	INSERTED.[Level5],
	INSERTED.[Level6],
	INSERTED.[Level7],
	INSERTED.[Level8],
	INSERTED.[Level9],
	INSERTED.[Level10]
into @table
VALUES ( 
	@MainSortOrder,
	@AddTime,
	@IsBelongProject,
	@Title,
	@Level1,
	@Level2,
	@Level3,
	@Level4,
	@Level5,
	@Level6,
	@Level7,
	@Level8,
	@Level9,
	@Level10 
); 

SELECT 
	[ID],
	[MainSortOrder],
	[AddTime],
	[IsBelongProject],
	[Title],
	[Level1],
	[Level2],
	[Level3],
	[Level4],
	[Level5],
	[Level6],
	[Level7],
	[Level8],
	[Level9],
	[Level10] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@MainSortOrder", EntityBase.GetDatabaseValue(@mainSortOrder)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsBelongProject", @isBelongProject));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Level1", EntityBase.GetDatabaseValue(@level1)));
			parameters.Add(new SqlParameter("@Level2", EntityBase.GetDatabaseValue(@level2)));
			parameters.Add(new SqlParameter("@Level3", EntityBase.GetDatabaseValue(@level3)));
			parameters.Add(new SqlParameter("@Level4", EntityBase.GetDatabaseValue(@level4)));
			parameters.Add(new SqlParameter("@Level5", EntityBase.GetDatabaseValue(@level5)));
			parameters.Add(new SqlParameter("@Level6", EntityBase.GetDatabaseValue(@level6)));
			parameters.Add(new SqlParameter("@Level7", EntityBase.GetDatabaseValue(@level7)));
			parameters.Add(new SqlParameter("@Level8", EntityBase.GetDatabaseValue(@level8)));
			parameters.Add(new SqlParameter("@Level9", EntityBase.GetDatabaseValue(@level9)));
			parameters.Add(new SqlParameter("@Level10", EntityBase.GetDatabaseValue(@level10)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a ProjectProperty into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="mainSortOrder">mainSortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isBelongProject">isBelongProject</param>
		/// <param name="title">title</param>
		/// <param name="level1">level1</param>
		/// <param name="level2">level2</param>
		/// <param name="level3">level3</param>
		/// <param name="level4">level4</param>
		/// <param name="level5">level5</param>
		/// <param name="level6">level6</param>
		/// <param name="level7">level7</param>
		/// <param name="level8">level8</param>
		/// <param name="level9">level9</param>
		/// <param name="level10">level10</param>
		public static void UpdateProjectProperty(int @iD, int @mainSortOrder, DateTime @addTime, bool @isBelongProject, string @title, string @level1, string @level2, string @level3, string @level4, string @level5, string @level6, string @level7, string @level8, string @level9, string @level10)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateProjectProperty(@iD, @mainSortOrder, @addTime, @isBelongProject, @title, @level1, @level2, @level3, @level4, @level5, @level6, @level7, @level8, @level9, @level10, helper);
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
		/// Updates a ProjectProperty into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="mainSortOrder">mainSortOrder</param>
		/// <param name="addTime">addTime</param>
		/// <param name="isBelongProject">isBelongProject</param>
		/// <param name="title">title</param>
		/// <param name="level1">level1</param>
		/// <param name="level2">level2</param>
		/// <param name="level3">level3</param>
		/// <param name="level4">level4</param>
		/// <param name="level5">level5</param>
		/// <param name="level6">level6</param>
		/// <param name="level7">level7</param>
		/// <param name="level8">level8</param>
		/// <param name="level9">level9</param>
		/// <param name="level10">level10</param>
		/// <param name="helper">helper</param>
		internal static void UpdateProjectProperty(int @iD, int @mainSortOrder, DateTime @addTime, bool @isBelongProject, string @title, string @level1, string @level2, string @level3, string @level4, string @level5, string @level6, string @level7, string @level8, string @level9, string @level10, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[MainSortOrder] int,
	[AddTime] datetime,
	[IsBelongProject] bit,
	[Title] nvarchar(100),
	[Level1] nvarchar(100),
	[Level2] nvarchar(100),
	[Level3] nvarchar(100),
	[Level4] nvarchar(100),
	[Level5] nvarchar(100),
	[Level6] nvarchar(100),
	[Level7] nvarchar(100),
	[Level8] nvarchar(100),
	[Level9] nvarchar(100),
	[Level10] nvarchar(100)
);

UPDATE [dbo].[ProjectProperty] SET 
	[ProjectProperty].[MainSortOrder] = @MainSortOrder,
	[ProjectProperty].[AddTime] = @AddTime,
	[ProjectProperty].[IsBelongProject] = @IsBelongProject,
	[ProjectProperty].[Title] = @Title,
	[ProjectProperty].[Level1] = @Level1,
	[ProjectProperty].[Level2] = @Level2,
	[ProjectProperty].[Level3] = @Level3,
	[ProjectProperty].[Level4] = @Level4,
	[ProjectProperty].[Level5] = @Level5,
	[ProjectProperty].[Level6] = @Level6,
	[ProjectProperty].[Level7] = @Level7,
	[ProjectProperty].[Level8] = @Level8,
	[ProjectProperty].[Level9] = @Level9,
	[ProjectProperty].[Level10] = @Level10 
output 
	INSERTED.[ID],
	INSERTED.[MainSortOrder],
	INSERTED.[AddTime],
	INSERTED.[IsBelongProject],
	INSERTED.[Title],
	INSERTED.[Level1],
	INSERTED.[Level2],
	INSERTED.[Level3],
	INSERTED.[Level4],
	INSERTED.[Level5],
	INSERTED.[Level6],
	INSERTED.[Level7],
	INSERTED.[Level8],
	INSERTED.[Level9],
	INSERTED.[Level10]
into @table
WHERE 
	[ProjectProperty].[ID] = @ID

SELECT 
	[ID],
	[MainSortOrder],
	[AddTime],
	[IsBelongProject],
	[Title],
	[Level1],
	[Level2],
	[Level3],
	[Level4],
	[Level5],
	[Level6],
	[Level7],
	[Level8],
	[Level9],
	[Level10] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@MainSortOrder", EntityBase.GetDatabaseValue(@mainSortOrder)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@IsBelongProject", @isBelongProject));
			parameters.Add(new SqlParameter("@Title", EntityBase.GetDatabaseValue(@title)));
			parameters.Add(new SqlParameter("@Level1", EntityBase.GetDatabaseValue(@level1)));
			parameters.Add(new SqlParameter("@Level2", EntityBase.GetDatabaseValue(@level2)));
			parameters.Add(new SqlParameter("@Level3", EntityBase.GetDatabaseValue(@level3)));
			parameters.Add(new SqlParameter("@Level4", EntityBase.GetDatabaseValue(@level4)));
			parameters.Add(new SqlParameter("@Level5", EntityBase.GetDatabaseValue(@level5)));
			parameters.Add(new SqlParameter("@Level6", EntityBase.GetDatabaseValue(@level6)));
			parameters.Add(new SqlParameter("@Level7", EntityBase.GetDatabaseValue(@level7)));
			parameters.Add(new SqlParameter("@Level8", EntityBase.GetDatabaseValue(@level8)));
			parameters.Add(new SqlParameter("@Level9", EntityBase.GetDatabaseValue(@level9)));
			parameters.Add(new SqlParameter("@Level10", EntityBase.GetDatabaseValue(@level10)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a ProjectProperty from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteProjectProperty(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteProjectProperty(@iD, helper);
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
		/// Deletes a ProjectProperty from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteProjectProperty(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[ProjectProperty]
WHERE 
	[ProjectProperty].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new ProjectProperty object.
		/// </summary>
		/// <returns>The newly created ProjectProperty object.</returns>
		public static ProjectProperty CreateProjectProperty()
		{
			return InitializeNew<ProjectProperty>();
		}
		
		/// <summary>
		/// Retrieve information for a ProjectProperty by a ProjectProperty's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>ProjectProperty</returns>
		public static ProjectProperty GetProjectProperty(int @iD)
		{
			string commandText = @"
SELECT 
" + ProjectProperty.SelectFieldList + @"
FROM [dbo].[ProjectProperty] 
WHERE 
	[ProjectProperty].[ID] = @ID " + ProjectProperty.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectProperty>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a ProjectProperty by a ProjectProperty's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>ProjectProperty</returns>
		public static ProjectProperty GetProjectProperty(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + ProjectProperty.SelectFieldList + @"
FROM [dbo].[ProjectProperty] 
WHERE 
	[ProjectProperty].[ID] = @ID " + ProjectProperty.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<ProjectProperty>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection ProjectProperty objects.
		/// </summary>
		/// <returns>The retrieved collection of ProjectProperty objects.</returns>
		public static EntityList<ProjectProperty> GetProjectProperties()
		{
			string commandText = @"
SELECT " + ProjectProperty.SelectFieldList + "FROM [dbo].[ProjectProperty] " + ProjectProperty.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ProjectProperty>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ProjectProperty objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectProperty objects.</returns>
        public static EntityList<ProjectProperty> GetProjectProperties(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectProperty>(SelectFieldList, "FROM [dbo].[ProjectProperty]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ProjectProperty objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ProjectProperty objects.</returns>
        public static EntityList<ProjectProperty> GetProjectProperties(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectProperty>(SelectFieldList, "FROM [dbo].[ProjectProperty]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection ProjectProperty objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ProjectProperty objects.</returns>
		protected static EntityList<ProjectProperty> GetProjectProperties(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectProperties(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ProjectProperty objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectProperty objects.</returns>
		protected static EntityList<ProjectProperty> GetProjectProperties(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectProperties(string.Empty, where, parameters, ProjectProperty.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectProperty objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ProjectProperty objects.</returns>
		protected static EntityList<ProjectProperty> GetProjectProperties(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetProjectProperties(prefix, where, parameters, ProjectProperty.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectProperty objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectProperty objects.</returns>
		protected static EntityList<ProjectProperty> GetProjectProperties(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectProperties(string.Empty, where, parameters, ProjectProperty.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectProperty objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ProjectProperty objects.</returns>
		protected static EntityList<ProjectProperty> GetProjectProperties(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetProjectProperties(prefix, where, parameters, ProjectProperty.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ProjectProperty objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ProjectProperty objects.</returns>
		protected static EntityList<ProjectProperty> GetProjectProperties(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ProjectProperty.SelectFieldList + "FROM [dbo].[ProjectProperty] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ProjectProperty>(reader);
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
        protected static EntityList<ProjectProperty> GetProjectProperties(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ProjectProperty>(SelectFieldList, "FROM [dbo].[ProjectProperty] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of ProjectProperty objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectPropertyCount()
        {
            return GetProjectPropertyCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ProjectProperty objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetProjectPropertyCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ProjectProperty] " + where;

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
		public static partial class ProjectProperty_Properties
		{
			public const string ID = "ID";
			public const string MainSortOrder = "MainSortOrder";
			public const string AddTime = "AddTime";
			public const string IsBelongProject = "IsBelongProject";
			public const string Title = "Title";
			public const string Level1 = "Level1";
			public const string Level2 = "Level2";
			public const string Level3 = "Level3";
			public const string Level4 = "Level4";
			public const string Level5 = "Level5";
			public const string Level6 = "Level6";
			public const string Level7 = "Level7";
			public const string Level8 = "Level8";
			public const string Level9 = "Level9";
			public const string Level10 = "Level10";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"MainSortOrder" , "int:"},
    			 {"AddTime" , "DateTime:"},
    			 {"IsBelongProject" , "bool:"},
    			 {"Title" , "string:"},
    			 {"Level1" , "string:"},
    			 {"Level2" , "string:"},
    			 {"Level3" , "string:"},
    			 {"Level4" , "string:"},
    			 {"Level5" , "string:"},
    			 {"Level6" , "string:"},
    			 {"Level7" , "string:"},
    			 {"Level8" , "string:"},
    			 {"Level9" , "string:"},
    			 {"Level10" , "string:"},
            };
		}
		#endregion
	}
}
