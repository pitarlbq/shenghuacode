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
	/// This object represents the properties and methods of a Sms_Tencent_Template.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Sms_Tencent_Template 
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
		private string _templateID = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string TemplateID
		{
			[DebuggerStepThrough()]
			get { return this._templateID; }
			set 
			{
				if (this._templateID != value) 
				{
					this._templateID = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateID");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _templteTitle = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string TemplteTitle
		{
			[DebuggerStepThrough()]
			get { return this._templteTitle; }
			set 
			{
				if (this._templteTitle != value) 
				{
					this._templteTitle = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplteTitle");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _templateRemark = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TemplateRemark
		{
			[DebuggerStepThrough()]
			get { return this._templateRemark; }
			set 
			{
				if (this._templateRemark != value) 
				{
					this._templateRemark = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateRemark");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _templateContent = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TemplateContent
		{
			[DebuggerStepThrough()]
			get { return this._templateContent; }
			set 
			{
				if (this._templateContent != value) 
				{
					this._templateContent = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateContent");
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
		private string _addUserName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUserName
		{
			[DebuggerStepThrough()]
			get { return this._addUserName; }
			set 
			{
				if (this._addUserName != value) 
				{
					this._addUserName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUserName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _paramCount = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int ParamCount
		{
			[DebuggerStepThrough()]
			get { return this._paramCount; }
			set 
			{
				if (this._paramCount != value) 
				{
					this._paramCount = value;
					this.IsDirty = true;	
					OnPropertyChanged("ParamCount");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _templateType = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public int TemplateType
		{
			[DebuggerStepThrough()]
			get { return this._templateType; }
			set 
			{
				if (this._templateType != value) 
				{
					this._templateType = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateType");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _templateSign = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string TemplateSign
		{
			[DebuggerStepThrough()]
			get { return this._templateSign; }
			set 
			{
				if (this._templateSign != value) 
				{
					this._templateSign = value;
					this.IsDirty = true;	
					OnPropertyChanged("TemplateSign");
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
	[TemplateID] nvarchar(200),
	[TemplteTitle] nvarchar(50),
	[TemplateRemark] nvarchar(500),
	[TemplateContent] nvarchar(500),
	[AddTime] datetime,
	[AddUserName] nvarchar(50),
	[ParamCount] int,
	[TemplateType] int,
	[TemplateSign] nvarchar(50)
);

INSERT INTO [dbo].[Sms_Tencent_Template] (
	[Sms_Tencent_Template].[TemplateID],
	[Sms_Tencent_Template].[TemplteTitle],
	[Sms_Tencent_Template].[TemplateRemark],
	[Sms_Tencent_Template].[TemplateContent],
	[Sms_Tencent_Template].[AddTime],
	[Sms_Tencent_Template].[AddUserName],
	[Sms_Tencent_Template].[ParamCount],
	[Sms_Tencent_Template].[TemplateType],
	[Sms_Tencent_Template].[TemplateSign]
) 
output 
	INSERTED.[ID],
	INSERTED.[TemplateID],
	INSERTED.[TemplteTitle],
	INSERTED.[TemplateRemark],
	INSERTED.[TemplateContent],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ParamCount],
	INSERTED.[TemplateType],
	INSERTED.[TemplateSign]
into @table
VALUES ( 
	@TemplateID,
	@TemplteTitle,
	@TemplateRemark,
	@TemplateContent,
	@AddTime,
	@AddUserName,
	@ParamCount,
	@TemplateType,
	@TemplateSign 
); 

SELECT 
	[ID],
	[TemplateID],
	[TemplteTitle],
	[TemplateRemark],
	[TemplateContent],
	[AddTime],
	[AddUserName],
	[ParamCount],
	[TemplateType],
	[TemplateSign] 
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
	[TemplateID] nvarchar(200),
	[TemplteTitle] nvarchar(50),
	[TemplateRemark] nvarchar(500),
	[TemplateContent] nvarchar(500),
	[AddTime] datetime,
	[AddUserName] nvarchar(50),
	[ParamCount] int,
	[TemplateType] int,
	[TemplateSign] nvarchar(50)
);

UPDATE [dbo].[Sms_Tencent_Template] SET 
	[Sms_Tencent_Template].[TemplateID] = @TemplateID,
	[Sms_Tencent_Template].[TemplteTitle] = @TemplteTitle,
	[Sms_Tencent_Template].[TemplateRemark] = @TemplateRemark,
	[Sms_Tencent_Template].[TemplateContent] = @TemplateContent,
	[Sms_Tencent_Template].[AddTime] = @AddTime,
	[Sms_Tencent_Template].[AddUserName] = @AddUserName,
	[Sms_Tencent_Template].[ParamCount] = @ParamCount,
	[Sms_Tencent_Template].[TemplateType] = @TemplateType,
	[Sms_Tencent_Template].[TemplateSign] = @TemplateSign 
output 
	INSERTED.[ID],
	INSERTED.[TemplateID],
	INSERTED.[TemplteTitle],
	INSERTED.[TemplateRemark],
	INSERTED.[TemplateContent],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ParamCount],
	INSERTED.[TemplateType],
	INSERTED.[TemplateSign]
into @table
WHERE 
	[Sms_Tencent_Template].[ID] = @ID

SELECT 
	[ID],
	[TemplateID],
	[TemplteTitle],
	[TemplateRemark],
	[TemplateContent],
	[AddTime],
	[AddUserName],
	[ParamCount],
	[TemplateType],
	[TemplateSign] 
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
DELETE FROM [dbo].[Sms_Tencent_Template]
WHERE 
	[Sms_Tencent_Template].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Sms_Tencent_Template() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetSms_Tencent_Template(this.ID));
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
	[Sms_Tencent_Template].[ID],
	[Sms_Tencent_Template].[TemplateID],
	[Sms_Tencent_Template].[TemplteTitle],
	[Sms_Tencent_Template].[TemplateRemark],
	[Sms_Tencent_Template].[TemplateContent],
	[Sms_Tencent_Template].[AddTime],
	[Sms_Tencent_Template].[AddUserName],
	[Sms_Tencent_Template].[ParamCount],
	[Sms_Tencent_Template].[TemplateType],
	[Sms_Tencent_Template].[TemplateSign]
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
                return "Sms_Tencent_Template";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Sms_Tencent_Template into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="templateID">templateID</param>
		/// <param name="templteTitle">templteTitle</param>
		/// <param name="templateRemark">templateRemark</param>
		/// <param name="templateContent">templateContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="paramCount">paramCount</param>
		/// <param name="templateType">templateType</param>
		/// <param name="templateSign">templateSign</param>
		public static void InsertSms_Tencent_Template(string @templateID, string @templteTitle, string @templateRemark, string @templateContent, DateTime @addTime, string @addUserName, int @paramCount, int @templateType, string @templateSign)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertSms_Tencent_Template(@templateID, @templteTitle, @templateRemark, @templateContent, @addTime, @addUserName, @paramCount, @templateType, @templateSign, helper);
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
		/// Insert a Sms_Tencent_Template into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="templateID">templateID</param>
		/// <param name="templteTitle">templteTitle</param>
		/// <param name="templateRemark">templateRemark</param>
		/// <param name="templateContent">templateContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="paramCount">paramCount</param>
		/// <param name="templateType">templateType</param>
		/// <param name="templateSign">templateSign</param>
		/// <param name="helper">helper</param>
		internal static void InsertSms_Tencent_Template(string @templateID, string @templteTitle, string @templateRemark, string @templateContent, DateTime @addTime, string @addUserName, int @paramCount, int @templateType, string @templateSign, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TemplateID] nvarchar(200),
	[TemplteTitle] nvarchar(50),
	[TemplateRemark] nvarchar(500),
	[TemplateContent] nvarchar(500),
	[AddTime] datetime,
	[AddUserName] nvarchar(50),
	[ParamCount] int,
	[TemplateType] int,
	[TemplateSign] nvarchar(50)
);

INSERT INTO [dbo].[Sms_Tencent_Template] (
	[Sms_Tencent_Template].[TemplateID],
	[Sms_Tencent_Template].[TemplteTitle],
	[Sms_Tencent_Template].[TemplateRemark],
	[Sms_Tencent_Template].[TemplateContent],
	[Sms_Tencent_Template].[AddTime],
	[Sms_Tencent_Template].[AddUserName],
	[Sms_Tencent_Template].[ParamCount],
	[Sms_Tencent_Template].[TemplateType],
	[Sms_Tencent_Template].[TemplateSign]
) 
output 
	INSERTED.[ID],
	INSERTED.[TemplateID],
	INSERTED.[TemplteTitle],
	INSERTED.[TemplateRemark],
	INSERTED.[TemplateContent],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ParamCount],
	INSERTED.[TemplateType],
	INSERTED.[TemplateSign]
into @table
VALUES ( 
	@TemplateID,
	@TemplteTitle,
	@TemplateRemark,
	@TemplateContent,
	@AddTime,
	@AddUserName,
	@ParamCount,
	@TemplateType,
	@TemplateSign 
); 

SELECT 
	[ID],
	[TemplateID],
	[TemplteTitle],
	[TemplateRemark],
	[TemplateContent],
	[AddTime],
	[AddUserName],
	[ParamCount],
	[TemplateType],
	[TemplateSign] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@TemplateID", EntityBase.GetDatabaseValue(@templateID)));
			parameters.Add(new SqlParameter("@TemplteTitle", EntityBase.GetDatabaseValue(@templteTitle)));
			parameters.Add(new SqlParameter("@TemplateRemark", EntityBase.GetDatabaseValue(@templateRemark)));
			parameters.Add(new SqlParameter("@TemplateContent", EntityBase.GetDatabaseValue(@templateContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ParamCount", EntityBase.GetDatabaseValue(@paramCount)));
			parameters.Add(new SqlParameter("@TemplateType", EntityBase.GetDatabaseValue(@templateType)));
			parameters.Add(new SqlParameter("@TemplateSign", EntityBase.GetDatabaseValue(@templateSign)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Sms_Tencent_Template into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="templateID">templateID</param>
		/// <param name="templteTitle">templteTitle</param>
		/// <param name="templateRemark">templateRemark</param>
		/// <param name="templateContent">templateContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="paramCount">paramCount</param>
		/// <param name="templateType">templateType</param>
		/// <param name="templateSign">templateSign</param>
		public static void UpdateSms_Tencent_Template(int @iD, string @templateID, string @templteTitle, string @templateRemark, string @templateContent, DateTime @addTime, string @addUserName, int @paramCount, int @templateType, string @templateSign)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateSms_Tencent_Template(@iD, @templateID, @templteTitle, @templateRemark, @templateContent, @addTime, @addUserName, @paramCount, @templateType, @templateSign, helper);
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
		/// Updates a Sms_Tencent_Template into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="templateID">templateID</param>
		/// <param name="templteTitle">templteTitle</param>
		/// <param name="templateRemark">templateRemark</param>
		/// <param name="templateContent">templateContent</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUserName">addUserName</param>
		/// <param name="paramCount">paramCount</param>
		/// <param name="templateType">templateType</param>
		/// <param name="templateSign">templateSign</param>
		/// <param name="helper">helper</param>
		internal static void UpdateSms_Tencent_Template(int @iD, string @templateID, string @templteTitle, string @templateRemark, string @templateContent, DateTime @addTime, string @addUserName, int @paramCount, int @templateType, string @templateSign, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[TemplateID] nvarchar(200),
	[TemplteTitle] nvarchar(50),
	[TemplateRemark] nvarchar(500),
	[TemplateContent] nvarchar(500),
	[AddTime] datetime,
	[AddUserName] nvarchar(50),
	[ParamCount] int,
	[TemplateType] int,
	[TemplateSign] nvarchar(50)
);

UPDATE [dbo].[Sms_Tencent_Template] SET 
	[Sms_Tencent_Template].[TemplateID] = @TemplateID,
	[Sms_Tencent_Template].[TemplteTitle] = @TemplteTitle,
	[Sms_Tencent_Template].[TemplateRemark] = @TemplateRemark,
	[Sms_Tencent_Template].[TemplateContent] = @TemplateContent,
	[Sms_Tencent_Template].[AddTime] = @AddTime,
	[Sms_Tencent_Template].[AddUserName] = @AddUserName,
	[Sms_Tencent_Template].[ParamCount] = @ParamCount,
	[Sms_Tencent_Template].[TemplateType] = @TemplateType,
	[Sms_Tencent_Template].[TemplateSign] = @TemplateSign 
output 
	INSERTED.[ID],
	INSERTED.[TemplateID],
	INSERTED.[TemplteTitle],
	INSERTED.[TemplateRemark],
	INSERTED.[TemplateContent],
	INSERTED.[AddTime],
	INSERTED.[AddUserName],
	INSERTED.[ParamCount],
	INSERTED.[TemplateType],
	INSERTED.[TemplateSign]
into @table
WHERE 
	[Sms_Tencent_Template].[ID] = @ID

SELECT 
	[ID],
	[TemplateID],
	[TemplteTitle],
	[TemplateRemark],
	[TemplateContent],
	[AddTime],
	[AddUserName],
	[ParamCount],
	[TemplateType],
	[TemplateSign] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@TemplateID", EntityBase.GetDatabaseValue(@templateID)));
			parameters.Add(new SqlParameter("@TemplteTitle", EntityBase.GetDatabaseValue(@templteTitle)));
			parameters.Add(new SqlParameter("@TemplateRemark", EntityBase.GetDatabaseValue(@templateRemark)));
			parameters.Add(new SqlParameter("@TemplateContent", EntityBase.GetDatabaseValue(@templateContent)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUserName", EntityBase.GetDatabaseValue(@addUserName)));
			parameters.Add(new SqlParameter("@ParamCount", EntityBase.GetDatabaseValue(@paramCount)));
			parameters.Add(new SqlParameter("@TemplateType", EntityBase.GetDatabaseValue(@templateType)));
			parameters.Add(new SqlParameter("@TemplateSign", EntityBase.GetDatabaseValue(@templateSign)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Sms_Tencent_Template from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteSms_Tencent_Template(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteSms_Tencent_Template(@iD, helper);
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
		/// Deletes a Sms_Tencent_Template from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteSms_Tencent_Template(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Sms_Tencent_Template]
WHERE 
	[Sms_Tencent_Template].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Sms_Tencent_Template object.
		/// </summary>
		/// <returns>The newly created Sms_Tencent_Template object.</returns>
		public static Sms_Tencent_Template CreateSms_Tencent_Template()
		{
			return InitializeNew<Sms_Tencent_Template>();
		}
		
		/// <summary>
		/// Retrieve information for a Sms_Tencent_Template by a Sms_Tencent_Template's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Sms_Tencent_Template</returns>
		public static Sms_Tencent_Template GetSms_Tencent_Template(int @iD)
		{
			string commandText = @"
SELECT 
" + Sms_Tencent_Template.SelectFieldList + @"
FROM [dbo].[Sms_Tencent_Template] 
WHERE 
	[Sms_Tencent_Template].[ID] = @ID " + Sms_Tencent_Template.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Sms_Tencent_Template>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Sms_Tencent_Template by a Sms_Tencent_Template's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Sms_Tencent_Template</returns>
		public static Sms_Tencent_Template GetSms_Tencent_Template(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Sms_Tencent_Template.SelectFieldList + @"
FROM [dbo].[Sms_Tencent_Template] 
WHERE 
	[Sms_Tencent_Template].[ID] = @ID " + Sms_Tencent_Template.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Sms_Tencent_Template>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Template objects.
		/// </summary>
		/// <returns>The retrieved collection of Sms_Tencent_Template objects.</returns>
		public static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates()
		{
			string commandText = @"
SELECT " + Sms_Tencent_Template.SelectFieldList + "FROM [dbo].[Sms_Tencent_Template] " + Sms_Tencent_Template.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Sms_Tencent_Template>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Sms_Tencent_Template objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Sms_Tencent_Template objects.</returns>
        public static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sms_Tencent_Template>(SelectFieldList, "FROM [dbo].[Sms_Tencent_Template]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Sms_Tencent_Template objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Sms_Tencent_Template objects.</returns>
        public static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sms_Tencent_Template>(SelectFieldList, "FROM [dbo].[Sms_Tencent_Template]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Template objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Sms_Tencent_Template objects.</returns>
		protected static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSms_Tencent_Templates(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Template objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Sms_Tencent_Template objects.</returns>
		protected static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSms_Tencent_Templates(string.Empty, where, parameters, Sms_Tencent_Template.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Template objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Sms_Tencent_Template objects.</returns>
		protected static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetSms_Tencent_Templates(prefix, where, parameters, Sms_Tencent_Template.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Template objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Sms_Tencent_Template objects.</returns>
		protected static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSms_Tencent_Templates(string.Empty, where, parameters, Sms_Tencent_Template.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Template objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Sms_Tencent_Template objects.</returns>
		protected static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetSms_Tencent_Templates(prefix, where, parameters, Sms_Tencent_Template.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Sms_Tencent_Template objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Sms_Tencent_Template objects.</returns>
		protected static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Sms_Tencent_Template.SelectFieldList + "FROM [dbo].[Sms_Tencent_Template] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Sms_Tencent_Template>(reader);
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
        protected static EntityList<Sms_Tencent_Template> GetSms_Tencent_Templates(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Sms_Tencent_Template>(SelectFieldList, "FROM [dbo].[Sms_Tencent_Template] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Sms_Tencent_Template objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSms_Tencent_TemplateCount()
        {
            return GetSms_Tencent_TemplateCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Sms_Tencent_Template objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetSms_Tencent_TemplateCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Sms_Tencent_Template] " + where;

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
		public static partial class Sms_Tencent_Template_Properties
		{
			public const string ID = "ID";
			public const string TemplateID = "TemplateID";
			public const string TemplteTitle = "TemplteTitle";
			public const string TemplateRemark = "TemplateRemark";
			public const string TemplateContent = "TemplateContent";
			public const string AddTime = "AddTime";
			public const string AddUserName = "AddUserName";
			public const string ParamCount = "ParamCount";
			public const string TemplateType = "TemplateType";
			public const string TemplateSign = "TemplateSign";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"TemplateID" , "string:"},
    			 {"TemplteTitle" , "string:"},
    			 {"TemplateRemark" , "string:"},
    			 {"TemplateContent" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUserName" , "string:"},
    			 {"ParamCount" , "int:"},
    			 {"TemplateType" , "int:"},
    			 {"TemplateSign" , "string:"},
            };
		}
		#endregion
	}
}
