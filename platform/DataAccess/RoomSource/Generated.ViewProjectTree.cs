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
	/// This object represents the properties and methods of a ViewProjectTree.
	/// </summary>
	[Serializable()]
	public partial class ViewProjectTree 
	{
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _id = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int id
		{
			[DebuggerStepThrough()]
			get { return this._id; }
            protected set { this._id = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _pId = int.MinValue;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, false)]
		public int pId
		{
			[DebuggerStepThrough()]
			get { return this._pId; }
            protected set { this._pId = value;}
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
		public string name
		{
			[DebuggerStepThrough()]
			get { return this._name; }
            protected set { this._name = value;}
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
            protected set { this._typeDesc = value;}
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
            protected set { this._level = value;}
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
            protected set { this._iconID = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _iconSkin = String.Empty;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public string iconSkin
		{
			[DebuggerStepThrough()]
			get { return this._iconSkin; }
            protected set { this._iconSkin = value;}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _open = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool open
		{
			[DebuggerStepThrough()]
			get { return this._open; }
            protected set { this._open = value;}
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
            protected set { this._pName = value;}
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
            protected set { this._companyID = value;}
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
            protected set { this._orderBy = value;}
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
		private bool _isLocked = false;
		/// <summary>
		/// 
		/// </summary>
        [Description("")]
		[DatabaseColumn()]
		[TypeConverter(typeof(MinToEmptyTypeConverter))]
		[DataObjectField(false, false, true)]
		public bool IsLocked
		{
			[DebuggerStepThrough()]
			get { return this._isLocked; }
            protected set { this._isLocked = value;}
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
		
		
		#endregion
		
		#region Constructors
		/// <summary>
		/// The default protected constructor
		/// </summary>
		public ViewProjectTree() { }
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
	[ViewProjectTree].[id],
	[ViewProjectTree].[pId],
	[ViewProjectTree].[name],
	[ViewProjectTree].[TypeDesc],
	[ViewProjectTree].[Level],
	[ViewProjectTree].[isParent],
	[ViewProjectTree].[IconID],
	[ViewProjectTree].[iconSkin],
	[ViewProjectTree].[open],
	[ViewProjectTree].[PName],
	[ViewProjectTree].[CompanyID],
	[ViewProjectTree].[OrderBy],
	[ViewProjectTree].[FullName],
	[ViewProjectTree].[IsLocked],
	[ViewProjectTree].[DefaultOrder]
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
                return "ViewProjectTree";
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
		/// Gets a collection ViewProjectTree objects.
		/// </summary>
		/// <returns>The retrieved collection of ViewProjectTree objects.</returns>
		public static EntityList<ViewProjectTree> GetViewProjectTrees()
		{
			string commandText = @"
SELECT " + ViewProjectTree.SelectFieldList + "FROM [dbo].[ViewProjectTree] " + ViewProjectTree.DefaultSortOrder;
		
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			return GetList<ViewProjectTree>(commandText, parameters);
		}
		
		/// <summary>
        /// Gets a collection ViewProjectTree objects.
        /// </summary>
		/// <param name="orderBy">order by</param>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">PageSize</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewProjectTree objects.</returns>
        public static EntityList<ViewProjectTree> GetViewProjectTrees(string orderBy, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewProjectTree>(SelectFieldList, "FROM [dbo].[ViewProjectTree]", new List<SqlParameter>(),orderBy,  startRowIndex, pageSize, out totalRows);
        }

		/// <summary>
        /// Gets a collection ViewProjectTree objects.
        /// </summary>
		/// <param name="startRowIndex">Start Row Index</param>
		/// <param name="pageSize">Page Size</param>
		/// <param name="totalRows">Total rows</param>
        /// <returns>The retrieved collection of ViewProjectTree objects.</returns>
        public static EntityList<ViewProjectTree> GetViewProjectTrees(int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewProjectTree>(SelectFieldList, "FROM [dbo].[ViewProjectTree]", new List<SqlParameter>(), null,  startRowIndex, pageSize, out totalRows);
        }

        /// <summary>
        /// Gets Total Count of ViewProjectTree objects.
        /// </summary>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewProjectTreeCount()
        {
            return GetViewProjectTreeCount(string.Empty,new System.Collections.Generic.List<SqlParameter>());
        }

        /// <summary>
        /// Gets Total Count of ViewProjectTree objects by custom where clause.
        /// </summary>
        /// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
        /// <param name="parameters">The parameters that are listed in the where clause</param>
        /// <returns>The count of Customer objects.</returns>
        public static long GetViewProjectTreeCount(string where, System.Collections.Generic.List<SqlParameter> parameters)
        {
            string commandText = @"SELECT count(*) as [Count] FROM [dbo].[ViewProjectTree] " + where;

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
		/// Gets a collection ViewProjectTree objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <param name="orderBy">the order by clause. Should start with "order by"</param>
		/// <returns>The retrieved collection of ViewProjectTree objects.</returns>
		protected static EntityList<ViewProjectTree> GetViewProjectTrees(string where, SqlParameter parameter, string orderBy)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewProjectTrees(string.Empty, where, parameters, orderBy);
		}
		
		/// <summary>
		/// Gets a collection ViewProjectTree objects by custom where clause.
		/// </summary>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewProjectTree objects.</returns>
		protected static EntityList<ViewProjectTree> GetViewProjectTrees(string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewProjectTrees(string.Empty, where, parameters, ViewProjectTree.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewProjectTree objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameter">The parameter that is in the where clause</param>
		/// <returns>The retrieved collection of ViewProjectTree objects.</returns>
		protected static EntityList<ViewProjectTree> GetViewProjectTrees(string prefix, string where, SqlParameter parameter)
		{
			System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
			
			parameters.Add(parameter);
						
			return GetViewProjectTrees(prefix, where, parameters, ViewProjectTree.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewProjectTree objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewProjectTree objects.</returns>
		protected static EntityList<ViewProjectTree> GetViewProjectTrees(string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewProjectTrees(string.Empty, where, parameters, ViewProjectTree.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewProjectTree objects by custom where clause.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <returns>The retrieved collection of ViewProjectTree objects.</returns>
		protected static EntityList<ViewProjectTree> GetViewProjectTrees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters)
		{
			return GetViewProjectTrees(prefix, where, parameters, ViewProjectTree.DefaultSortOrder);
		}
		
		/// <summary>
		/// Gets a collection ViewProjectTree objects by custom where clause and order by.
		/// </summary>
		/// <param name="prefix">The prefix clause allows you to inject a distinct or top clause.</param>
		/// <param name="where">The where clause to use for the query. Should be parameterized and start with "where"</param>
		/// <param name="parameters">The parameters that are listed in the where clause</param>
		/// <param name="orderBy">the order by clause. Shoudl start with "order by"</param>
		/// <returns>The retrieved collection of ViewProjectTree objects.</returns>
		protected static EntityList<ViewProjectTree> GetViewProjectTrees(string prefix, string where, System.Collections.Generic.List<SqlParameter> parameters, string orderBy)
		{
			string commandText = @"SELECT " + prefix + "" + ViewProjectTree.SelectFieldList + "FROM [dbo].[ViewProjectTree] " + where + " " + orderBy;			
			
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return EntityBase.InitializeList<ViewProjectTree>(reader);
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
        protected static EntityList<ViewProjectTree> GetViewProjectTrees(string orderBy, string where, System.Collections.Generic.List<SqlParameter> parameters, int startRowIndex, int pageSize, out long totalRows)
        {
            return GetList<ViewProjectTree>(SelectFieldList, "FROM [dbo].[ViewProjectTree] " + where, parameters, orderBy, startRowIndex, pageSize, out totalRows);			
		}
		#endregion
		
		#region Subclasses
		public static partial class ViewProjectTreeProperties
		{
			public const string id = "id";
			public const string pId = "pId";
			public const string name = "name";
			public const string TypeDesc = "TypeDesc";
			public const string Level = "Level";
			public const string isParent = "isParent";
			public const string IconID = "IconID";
			public const string iconSkin = "iconSkin";
			public const string open = "open";
			public const string PName = "PName";
			public const string CompanyID = "CompanyID";
			public const string OrderBy = "OrderBy";
			public const string FullName = "FullName";
			public const string IsLocked = "IsLocked";
			public const string DefaultOrder = "DefaultOrder";
            
            public static Dictionary<string,string> AllPropertiesDescription=new Dictionary<string,string>(){
    			 {"id" , "int:"},
    			 {"pId" , "int:"},
    			 {"name" , "string:"},
    			 {"TypeDesc" , "string:"},
    			 {"Level" , "int:"},
    			 {"isParent" , "bool:"},
    			 {"IconID" , "int:"},
    			 {"iconSkin" , "string:"},
    			 {"open" , "bool:"},
    			 {"PName" , "string:"},
    			 {"CompanyID" , "int:"},
    			 {"OrderBy" , "int:"},
    			 {"FullName" , "string:"},
    			 {"IsLocked" , "bool:"},
    			 {"DefaultOrder" , "string:"},
            };
		}
		#endregion
	}
}
