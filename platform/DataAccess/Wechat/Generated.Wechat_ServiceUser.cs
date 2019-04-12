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
	/// This object represents the properties and methods of a Wechat_ServiceUser.
	/// </summary>
	[Serializable()]
	[DebuggerDisplay("ID: {ID}")]
	public partial class Wechat_ServiceUser 
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
		private string _nickName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string NickName
		{
			[DebuggerStepThrough()]
			get { return this._nickName; }
			set 
			{
				if (this._nickName != value) 
				{
					this._nickName = value;
					this.IsDirty = true;	
					OnPropertyChanged("NickName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _accountName = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AccountName
		{
			[DebuggerStepThrough()]
			get { return this._accountName; }
			set 
			{
				if (this._accountName != value) 
				{
					this._accountName = value;
					this.IsDirty = true;	
					OnPropertyChanged("AccountName");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _wx_Account = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string Wx_Account
		{
			[DebuggerStepThrough()]
			get { return this._wx_Account; }
			set 
			{
				if (this._wx_Account != value) 
				{
					this._wx_Account = value;
					this.IsDirty = true;	
					OnPropertyChanged("Wx_Account");
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
		private string _addUser = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public string AddUser
		{
			[DebuggerStepThrough()]
			get { return this._addUser; }
			set 
			{
				if (this._addUser != value) 
				{
					this._addUser = value;
					this.IsDirty = true;	
					OnPropertyChanged("AddUser");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _headImage = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string HeadImage
		{
			[DebuggerStepThrough()]
			get { return this._headImage; }
			set 
			{
				if (this._headImage != value) 
				{
					this._headImage = value;
					this.IsDirty = true;	
					OnPropertyChanged("HeadImage");
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
		[DataObjectField(false, false, true)]
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
	[NickName] nvarchar(50),
	[AccountName] nvarchar(50),
	[Wx_Account] nvarchar(50),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[HeadImage] nvarchar(200),
	[UserID] int
);

INSERT INTO [dbo].[Wechat_ServiceUser] (
	[Wechat_ServiceUser].[NickName],
	[Wechat_ServiceUser].[AccountName],
	[Wechat_ServiceUser].[Wx_Account],
	[Wechat_ServiceUser].[AddTime],
	[Wechat_ServiceUser].[AddUser],
	[Wechat_ServiceUser].[HeadImage],
	[Wechat_ServiceUser].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[NickName],
	INSERTED.[AccountName],
	INSERTED.[Wx_Account],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[HeadImage],
	INSERTED.[UserID]
into @table
VALUES ( 
	@NickName,
	@AccountName,
	@Wx_Account,
	@AddTime,
	@AddUser,
	@HeadImage,
	@UserID 
); 

SELECT 
	[ID],
	[NickName],
	[AccountName],
	[Wx_Account],
	[AddTime],
	[AddUser],
	[HeadImage],
	[UserID] 
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
	[NickName] nvarchar(50),
	[AccountName] nvarchar(50),
	[Wx_Account] nvarchar(50),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[HeadImage] nvarchar(200),
	[UserID] int
);

UPDATE [dbo].[Wechat_ServiceUser] SET 
	[Wechat_ServiceUser].[NickName] = @NickName,
	[Wechat_ServiceUser].[AccountName] = @AccountName,
	[Wechat_ServiceUser].[Wx_Account] = @Wx_Account,
	[Wechat_ServiceUser].[AddTime] = @AddTime,
	[Wechat_ServiceUser].[AddUser] = @AddUser,
	[Wechat_ServiceUser].[HeadImage] = @HeadImage,
	[Wechat_ServiceUser].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[NickName],
	INSERTED.[AccountName],
	INSERTED.[Wx_Account],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[HeadImage],
	INSERTED.[UserID]
into @table
WHERE 
	[Wechat_ServiceUser].[ID] = @ID

SELECT 
	[ID],
	[NickName],
	[AccountName],
	[Wx_Account],
	[AddTime],
	[AddUser],
	[HeadImage],
	[UserID] 
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
DELETE FROM [dbo].[Wechat_ServiceUser]
WHERE 
	[Wechat_ServiceUser].[ID] = @ID";	
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public Wechat_ServiceUser() { }
		#endregion
		
		#region Public Methods
		

        /// <summary>
        /// Refreshes the entity with data from the data source. Child entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
        public override void Refresh()
		{
			this.Replace(GetWechat_ServiceUser(this.ID));
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
	[Wechat_ServiceUser].[ID],
	[Wechat_ServiceUser].[NickName],
	[Wechat_ServiceUser].[AccountName],
	[Wechat_ServiceUser].[Wx_Account],
	[Wechat_ServiceUser].[AddTime],
	[Wechat_ServiceUser].[AddUser],
	[Wechat_ServiceUser].[HeadImage],
	[Wechat_ServiceUser].[UserID]
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
                return "Wechat_ServiceUser";
            }
        }

		#endregion
		
		#region Static Methods
		/// <summary>
		/// Insert a Wechat_ServiceUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="nickName">nickName</param>
		/// <param name="accountName">accountName</param>
		/// <param name="wx_Account">wx_Account</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="headImage">headImage</param>
		/// <param name="userID">userID</param>
		public static void InsertWechat_ServiceUser(string @nickName, string @accountName, string @wx_Account, DateTime @addTime, string @addUser, string @headImage, int @userID)
		{
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
            		InsertWechat_ServiceUser(@nickName, @accountName, @wx_Account, @addTime, @addUser, @headImage, @userID, helper);
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
		/// Insert a Wechat_ServiceUser into the data store based on the primitive properties. This can be used as the 
		/// insert method for an ObjectDataSource.
		/// </summary>
		/// <param name="nickName">nickName</param>
		/// <param name="accountName">accountName</param>
		/// <param name="wx_Account">wx_Account</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="headImage">headImage</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void InsertWechat_ServiceUser(string @nickName, string @accountName, string @wx_Account, DateTime @addTime, string @addUser, string @headImage, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[NickName] nvarchar(50),
	[AccountName] nvarchar(50),
	[Wx_Account] nvarchar(50),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[HeadImage] nvarchar(200),
	[UserID] int
);

INSERT INTO [dbo].[Wechat_ServiceUser] (
	[Wechat_ServiceUser].[NickName],
	[Wechat_ServiceUser].[AccountName],
	[Wechat_ServiceUser].[Wx_Account],
	[Wechat_ServiceUser].[AddTime],
	[Wechat_ServiceUser].[AddUser],
	[Wechat_ServiceUser].[HeadImage],
	[Wechat_ServiceUser].[UserID]
) 
output 
	INSERTED.[ID],
	INSERTED.[NickName],
	INSERTED.[AccountName],
	INSERTED.[Wx_Account],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[HeadImage],
	INSERTED.[UserID]
into @table
VALUES ( 
	@NickName,
	@AccountName,
	@Wx_Account,
	@AddTime,
	@AddUser,
	@HeadImage,
	@UserID 
); 

SELECT 
	[ID],
	[NickName],
	[AccountName],
	[Wx_Account],
	[AddTime],
	[AddUser],
	[HeadImage],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@NickName", EntityBase.GetDatabaseValue(@nickName)));
			parameters.Add(new SqlParameter("@AccountName", EntityBase.GetDatabaseValue(@accountName)));
			parameters.Add(new SqlParameter("@Wx_Account", EntityBase.GetDatabaseValue(@wx_Account)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@HeadImage", EntityBase.GetDatabaseValue(@headImage)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Updates a Wechat_ServiceUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="nickName">nickName</param>
		/// <param name="accountName">accountName</param>
		/// <param name="wx_Account">wx_Account</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="headImage">headImage</param>
		/// <param name="userID">userID</param>
		public static void UpdateWechat_ServiceUser(int @iD, string @nickName, string @accountName, string @wx_Account, DateTime @addTime, string @addUser, string @headImage, int @userID)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try
				{
					helper.BeginTransaction();
					UpdateWechat_ServiceUser(@iD, @nickName, @accountName, @wx_Account, @addTime, @addUser, @headImage, @userID, helper);
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
		/// Updates a Wechat_ServiceUser into the data store based on the primitive properties. This can be used as the 
		/// update method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="nickName">nickName</param>
		/// <param name="accountName">accountName</param>
		/// <param name="wx_Account">wx_Account</param>
		/// <param name="addTime">addTime</param>
		/// <param name="addUser">addUser</param>
		/// <param name="headImage">headImage</param>
		/// <param name="userID">userID</param>
		/// <param name="helper">helper</param>
		internal static void UpdateWechat_ServiceUser(int @iD, string @nickName, string @accountName, string @wx_Account, DateTime @addTime, string @addUser, string @headImage, int @userID, SqlHelper @helper)
		{
			string commandText = @"
DECLARE @table TABLE(
	[ID] int,
	[NickName] nvarchar(50),
	[AccountName] nvarchar(50),
	[Wx_Account] nvarchar(50),
	[AddTime] datetime,
	[AddUser] nvarchar(100),
	[HeadImage] nvarchar(200),
	[UserID] int
);

UPDATE [dbo].[Wechat_ServiceUser] SET 
	[Wechat_ServiceUser].[NickName] = @NickName,
	[Wechat_ServiceUser].[AccountName] = @AccountName,
	[Wechat_ServiceUser].[Wx_Account] = @Wx_Account,
	[Wechat_ServiceUser].[AddTime] = @AddTime,
	[Wechat_ServiceUser].[AddUser] = @AddUser,
	[Wechat_ServiceUser].[HeadImage] = @HeadImage,
	[Wechat_ServiceUser].[UserID] = @UserID 
output 
	INSERTED.[ID],
	INSERTED.[NickName],
	INSERTED.[AccountName],
	INSERTED.[Wx_Account],
	INSERTED.[AddTime],
	INSERTED.[AddUser],
	INSERTED.[HeadImage],
	INSERTED.[UserID]
into @table
WHERE 
	[Wechat_ServiceUser].[ID] = @ID

SELECT 
	[ID],
	[NickName],
	[AccountName],
	[Wx_Account],
	[AddTime],
	[AddUser],
	[HeadImage],
	[UserID] 
FROM @table;
";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", EntityBase.GetDatabaseValue(@iD)));
			parameters.Add(new SqlParameter("@NickName", EntityBase.GetDatabaseValue(@nickName)));
			parameters.Add(new SqlParameter("@AccountName", EntityBase.GetDatabaseValue(@accountName)));
			parameters.Add(new SqlParameter("@Wx_Account", EntityBase.GetDatabaseValue(@wx_Account)));
			parameters.Add(new SqlParameter("@AddTime", EntityBase.GetDatabaseValue(@addTime)));
			parameters.Add(new SqlParameter("@AddUser", EntityBase.GetDatabaseValue(@addUser)));
			parameters.Add(new SqlParameter("@HeadImage", EntityBase.GetDatabaseValue(@headImage)));
			parameters.Add(new SqlParameter("@UserID", EntityBase.GetDatabaseValue(@userID)));
			
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Deletes a Wechat_ServiceUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		public static void DeleteWechat_ServiceUser(int @iD)
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					DeleteWechat_ServiceUser(@iD, helper);
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
		/// Deletes a Wechat_ServiceUser from the data store based on the primitive primary keys. This can be used as the 
		/// delete method for an ObjectDataSource.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <param name="helper">helper</param>
		internal static void DeleteWechat_ServiceUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
DELETE FROM [dbo].[Wechat_ServiceUser]
WHERE 
	[Wechat_ServiceUser].[ID] = @ID";
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
		
			@helper.Execute(commandText, CommandType.Text, parameters);
		}
		
		/// <summary>
		/// Creates a new Wechat_ServiceUser object.
		/// </summary>
		/// <returns>The newly created Wechat_ServiceUser object.</returns>
		public static Wechat_ServiceUser CreateWechat_ServiceUser()
		{
			return InitializeNew<Wechat_ServiceUser>();
		}
		
		/// <summary>
		/// Retrieve information for a Wechat_ServiceUser by a Wechat_ServiceUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Wechat_ServiceUser</returns>
		public static Wechat_ServiceUser GetWechat_ServiceUser(int @iD)
		{
			string commandText = @"
SELECT 
" + Wechat_ServiceUser.SelectFieldList + @"
FROM [dbo].[Wechat_ServiceUser] 
WHERE 
	[Wechat_ServiceUser].[ID] = @ID " + Wechat_ServiceUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ServiceUser>(commandText, parameters);
		}
        
        /// <summary>
		/// Retrieve information for a Wechat_ServiceUser by a Wechat_ServiceUser's unique identifier.
		/// </summary>
		/// <param name="iD">iD</param>
        /// <param name="helper">SqlHelper</param>
		/// <returns>Wechat_ServiceUser</returns>
		public static Wechat_ServiceUser GetWechat_ServiceUser(int @iD, SqlHelper @helper)
		{
			string commandText = @"
SELECT 
" + Wechat_ServiceUser.SelectFieldList + @"
FROM [dbo].[Wechat_ServiceUser] 
WHERE 
	[Wechat_ServiceUser].[ID] = @ID " + Wechat_ServiceUser.DefaultSortOrder;
			
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			parameters.Add(new SqlParameter("@ID", @iD));
			
			return GetOne<Wechat_ServiceUser>(commandText, parameters, @helper);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceUser objects.
		/// </summary>
		/// <returns>The retrieved collection of Wechat_ServiceUser objects.</returns>
		public static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers()
		{
			string commandText = @"
SELECT " + Wechat_ServiceUser.SelectFieldList + "FROM [dbo].[Wechat_ServiceUser] " + Wechat_ServiceUser.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<Wechat_ServiceUser>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection Wechat_ServiceUser objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ServiceUser objects.</returns>
        public static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ServiceUser>(SelectFieldList, "FROM [dbo].[Wechat_ServiceUser]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection Wechat_ServiceUser objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of Wechat_ServiceUser objects.</returns>
        public static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ServiceUser>(SelectFieldList, "FROM [dbo].[Wechat_ServiceUser]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }
		
		/// <summary>
		/// Gets a collection Wechat_ServiceUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ServiceUser objects.</returns>
		protected static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ServiceUsers(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceUser objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ServiceUser objects.</returns>
		protected static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ServiceUsers(string.Empty, where, parameters, Wechat_ServiceUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ServiceUser objects.</returns>
		protected static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetWechat_ServiceUsers(prefix, where, parameters, Wechat_ServiceUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ServiceUser objects.</returns>
		protected static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ServiceUsers(string.Empty, where, parameters, Wechat_ServiceUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceUser objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of Wechat_ServiceUser objects.</returns>
		protected static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetWechat_ServiceUsers(prefix, where, parameters, Wechat_ServiceUser.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection Wechat_ServiceUser objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of Wechat_ServiceUser objects.</returns>
		protected static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + Wechat_ServiceUser.SelectFieldList + "FROM [dbo].[Wechat_ServiceUser] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<Wechat_ServiceUser>(reader);
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
        protected static EntityList<Wechat_ServiceUser> GetWechat_ServiceUsers(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<Wechat_ServiceUser>(SelectFieldList, "FROM [dbo].[Wechat_ServiceUser] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		
        
        /// <summary>
        /// Gets Total Count of Wechat_ServiceUser objects
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ServiceUserCount()
        {
            return GetWechat_ServiceUserCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of Wechat_ServiceUser objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetWechat_ServiceUserCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[Wechat_ServiceUser] " + where;

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
		public static partial class Wechat_ServiceUser_Properties
		{
			public const string ID = "ID";
			public const string NickName = "NickName";
			public const string AccountName = "AccountName";
			public const string Wx_Account = "Wx_Account";
			public const string AddTime = "AddTime";
			public const string AddUser = "AddUser";
			public const string HeadImage = "HeadImage";
			public const string UserID = "UserID";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"NickName" , "string:"},
    			 {"AccountName" , "string:"},
    			 {"Wx_Account" , "string:"},
    			 {"AddTime" , "DateTime:"},
    			 {"AddUser" , "string:"},
    			 {"HeadImage" , "string:"},
    			 {"UserID" , "int:"},
            };
		}
		#endregion
	}
}
