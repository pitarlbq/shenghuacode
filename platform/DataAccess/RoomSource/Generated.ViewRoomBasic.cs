using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Foresight.DataAccess.Framework;


namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a ViewRoomBasic.
	/// </summary>
	[Serializable()]
	public partial class ViewRoomBasic 
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
		[DataObjectField(false, false, true)]
		public int ID
		{
			[DebuggerStepThrough()]
			get { return this._iD; }
            protected set { this._iD = value;}
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
            protected set { this._buildingOutArea = value;}
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
            protected set { this._addTime = value;}
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
            protected set { this._paymentTime = value;}
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
            protected set { this._buildingNumber = value;}
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
            protected set { this._signDate = value;}
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
            protected set { this._certificateTime = value;}
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
            protected set { this._roomType = value;}
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
            protected set { this._isJingZhuangXiu = value;}
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
            protected set { this._name = value;}
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
            protected set { this._fullName = value;}
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
            protected set { this._allParentID = value;}
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
            protected set { this._defaultOrder = value;}
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
            protected set { this._roomProperty = value;}
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
            protected set { this._propertyID = value;}
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
            protected set { this._roomID = value;}
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
            protected set { this._isParent = value;}
		}
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewRoomBasic() { }
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
	[ViewRoomBasic].[ID],
	[ViewRoomBasic].[BuildingOutArea],
	[ViewRoomBasic].[AddTime],
	[ViewRoomBasic].[PaymentTime],
	[ViewRoomBasic].[BuildingNumber],
	[ViewRoomBasic].[SignDate],
	[ViewRoomBasic].[CertificateTime],
	[ViewRoomBasic].[RoomType],
	[ViewRoomBasic].[IsJingZhuangXiu],
	[ViewRoomBasic].[Name],
	[ViewRoomBasic].[FullName],
	[ViewRoomBasic].[AllParentID],
	[ViewRoomBasic].[DefaultOrder],
	[ViewRoomBasic].[RoomProperty],
	[ViewRoomBasic].[PropertyID],
	[ViewRoomBasic].[RoomID],
	[ViewRoomBasic].[isParent]
";
			}
		}
		
		
		/// <summary>
        /// View Name
        /// </summary>
        public static string ViewName
        {
            get
            {
                return "ViewRoomBasic";
            }
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
		
		#region Static Methods
				
		/// <summary>
		/// Gets a collection ViewRoomBasic objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		public static EntityList<ViewRoomBasic> GetViewRoomBasics()
		{
			string commandText = @"
SELECT " + ViewRoomBasic.SelectFieldList + "FROM [dbo].[ViewRoomBasic] " + ViewRoomBasic.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewRoomBasic>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewRoomBasic objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
        public static EntityList<ViewRoomBasic> GetViewRoomBasics(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomBasic>(SelectFieldList, "FROM [dbo].[ViewRoomBasic]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewRoomBasic objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
        public static EntityList<ViewRoomBasic> GetViewRoomBasics(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomBasic>(SelectFieldList, "FROM [dbo].[ViewRoomBasic]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewRoomBasic objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewRoomBasicCount()
        {
            return GetViewRoomBasicCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewRoomBasic objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewRoomBasicCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewRoomBasic] " + where;

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
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomBasics(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomBasics(string.Empty, where, parameters, ViewRoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewRoomBasics(prefix, where, parameters, ViewRoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomBasics(string.Empty, where, parameters, ViewRoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewRoomBasics(prefix, where, parameters, ViewRoomBasic.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewRoomBasic objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewRoomBasic objects.</returns>
		protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewRoomBasic.SelectFieldList + "FROM [dbo].[ViewRoomBasic] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewRoomBasic>(reader);
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
        protected static EntityList<ViewRoomBasic> GetViewRoomBasics(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewRoomBasic>(SelectFieldList, "FROM [dbo].[ViewRoomBasic] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewRoomBasicProperties
		{
			public const string ID = "ID";
			public const string BuildingOutArea = "BuildingOutArea";
			public const string AddTime = "AddTime";
			public const string PaymentTime = "PaymentTime";
			public const string BuildingNumber = "BuildingNumber";
			public const string SignDate = "SignDate";
			public const string CertificateTime = "CertificateTime";
			public const string RoomType = "RoomType";
			public const string IsJingZhuangXiu = "IsJingZhuangXiu";
			public const string Name = "Name";
			public const string FullName = "FullName";
			public const string AllParentID = "AllParentID";
			public const string DefaultOrder = "DefaultOrder";
			public const string RoomProperty = "RoomProperty";
			public const string PropertyID = "PropertyID";
			public const string RoomID = "RoomID";
			public const string isParent = "isParent";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"ID" , "int:"},
    			 {"BuildingOutArea" , "decimal:"},
    			 {"AddTime" , "DateTime:"},
    			 {"PaymentTime" , "DateTime:"},
    			 {"BuildingNumber" , "string:"},
    			 {"SignDate" , "DateTime:"},
    			 {"CertificateTime" , "DateTime:"},
    			 {"RoomType" , "string:"},
    			 {"IsJingZhuangXiu" , "int:"},
    			 {"Name" , "string:"},
    			 {"FullName" , "string:"},
    			 {"AllParentID" , "string:"},
    			 {"DefaultOrder" , "string:"},
    			 {"RoomProperty" , "string:"},
    			 {"PropertyID" , "int:"},
    			 {"RoomID" , "int:"},
    			 {"isParent" , "bool:"},
            };
		}
		#endregion
	}
}
