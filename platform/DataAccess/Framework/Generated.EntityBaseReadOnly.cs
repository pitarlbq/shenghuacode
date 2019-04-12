﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Custom business object ancestor class
    /// </summary>
	[Serializable()]
    public abstract partial class EntityBaseReadOnly : ICloneable, ISavable
    {
		#region Public Events and Event Handler Methods
		/// <summary>
		/// Event that is fired when the entity is initialized
		/// </summary>
        [field: NonSerialized()]
		public event EventHandler<EntityEventArgs> Init;

		/// <summary>
		/// Method responsible for raising the Init event
		/// </summary>
		protected virtual void OnInit(EntityEventArgs e)
		{
			if(Init != null)
			{
				Init(this, e);	
			}
		}
		
		/// <summary>
		/// Event that is fired before the save process is started, regardless if 
		/// save will actually occur
		/// </summary>
        [field: NonSerialized()]
		public event EventHandler<EntityCancelEventArgs> SaveStarting;
		
		/// <summary>
		/// Method responsible for raising the SaveStarting event
		/// </summary>
		protected virtual void OnSaveStarting(EntityCancelEventArgs e)
		{
			if (SaveStarting != null)
			{
				SaveStarting(this, e);	
			}
		}
		
		/// <summary>
		/// Event that is fired after the save process is successful, regardless if
		/// this entity actually got saved.
		/// </summary>
        [field: NonSerialized()]
		public event EventHandler<EntityEventArgs> SaveFinished;
		
		/// <summary>
		/// Method responsible for raising the SaveFinished event
		/// </summary>
		protected virtual void OnSaveFinished(EntityEventArgs e) 
		{
			if (SaveFinished != null)
			{
				SaveFinished(this, e);
			}
		}
		#endregion
		
		#region Constructors
		/// <summary>
		/// Default Constructor is protected so that a factory method is used to create this object
		/// </summary>
		protected EntityBaseReadOnly() 
		{ 
			EntityEventArgs entityEventArgs = new EntityEventArgs(this);
			OnInit(entityEventArgs);
		}
		
		/// <summary>
		/// Constructor that initializes an Entity from a data reader
		/// </summary>
		/// <param name="reader">The reader containing the data row to load</param>
		internal EntityBaseReadOnly(IDataReader reader) : this()
        {
            Initialize(reader);
        }

        /// <summary>
		/// Constructor that initializes an Entity from a data row
		/// </summary>
		/// <param name="row">The reader containing the data row to load</param>
		internal EntityBaseReadOnly(DataRowView row) : this()
        {
            Initialize(row);
        }
		
        /// <summary>
        /// Constructor that initializes an Entity with a parent list
        /// </summary>
        /// <param name="list">The parent list</param>
        internal EntityBaseReadOnly(System.Collections.IList list) : this()
        {
            _parent = list;
        }
		#endregion
	
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isNew = false;
		/// <summary>
		/// Determines if the object is new
		/// </summary>
		public virtual bool IsNew
		{
			[DebuggerStepThrough()]
			get { return this._isNew; }
			internal set { }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDirty = false;
		/// <summary>
		/// Determines if the object has been changed since being loaded
		/// </summary>
		public virtual bool IsDirty
		{
			[DebuggerStepThrough()]
			get { return this._isDirty; }
            internal set { }
		}

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDeleted = false;
		/// <summary>
		/// Determines if the custom business object has been flagged to be deleted
		/// </summary>
		public virtual bool IsDeleted
		{
			[DebuggerStepThrough()]
			get { return this._isDeleted; }
			internal set { }
		}
		#endregion
	
		#region Non-Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private System.Collections.IList _parent;
        /// <summary>
        /// Parent Entity
        /// </summary>
        internal System.Collections.IList Parent
        {
			[DebuggerStepThrough()]
            get { return this._parent; }
            set { _parent = value; }
        }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Guid _uniqueKey = Guid.Empty;
		/// <summary>
        /// Return a uniqueidentifier for this entity.  If new, a Guid will be used, otherwise
        /// the primary key will be
        /// </summary>
        internal virtual string UniqueIdentifier
        {
            get
            {
                string returnValue = string.Empty;

                if (!_isNew)
                {
                    Dictionary<string, PropertyInfo> propertyList = GetPropertyList(ColumnType.PrimaryKeyColumn);

                    if (propertyList.Count > 0)
                    {
                        foreach (string key in propertyList.Keys)
                        {
                            if (propertyList[key].CanRead)
                            {
                                object objectValue = propertyList[key].GetValue(this, null);

                                if (objectValue != null)
                                {
                                    returnValue += objectValue.ToString() + "|";
                                }
                            }
                        }
                    }
                }

                // No Primary key was found, so the identifier will have to be 
                // a guid
                if (returnValue == String.Empty)
                {
                    if (_uniqueKey == Guid.Empty)
                    {
                        _uniqueKey = Guid.NewGuid();
                    }

                    returnValue = _uniqueKey.ToString();
                }

                return returnValue;
            }
        }
		
		/// <summary>
        /// Check to see if any of the child entities are dirty
        /// </summary>
        public bool IsSaveRequired
        {
            get
            {
                bool returnValue = this.IsNew || this.IsDirty || this.IsDeleted;

                if (!returnValue)
                {
                    Dictionary<string, PropertyInfo> properties = GetPropertyList(ColumnType.SaveableChildEntities);

                    foreach (string key in properties.Keys)
                    {
                        object currentValue = GetPropertyValue(this, properties[key]);

                        if (currentValue != null)
                        {
                            bool isParent = false;

                            if (currentValue is EntityBaseReadOnly)
                            {
                                EntityBaseReadOnly entityValue = (EntityBaseReadOnly)currentValue;

                                isParent = IsParentEntity(entityValue);
                            }

                            if (!isParent)
                            {
                                System.Reflection.PropertyInfo property = currentValue.GetType().GetProperty("IsSaveRequired", BINDINGS_ALL_INCLUDING_BASE);

                                if (property != null)
                                {
                                    returnValue = (bool)property.GetValue(currentValue, null);

                                    if (returnValue) break;
                                }
                            }
                        }
                    }
                }

                return returnValue;
            }
        }
		#endregion
		
		#region Public Methods
		/// <summary>
        /// Save changes to the custom business object to the database
        /// </summary>
        public virtual void Save()  
		{	
			using (SqlHelper helper = new SqlHelper()) 
			{
				try 
				{
					helper.BeginTransaction();
					this.Save(helper);
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
        /// Clone to Depth
        /// </summary>
		/// <param name="depth">The depth to clone to</param>
		/// <returns>Reference to the cloned object</returns>
    	public object Clone(CloneType depth)
        {
            EntityBaseReadOnly newObject;
            // http://msdn2.microsoft.com/en-us/library/system.object.memberwiseclone.aspx
            if (depth == CloneType.Shallow)
            {
                newObject = (EntityBaseReadOnly)this.MemberwiseClone();
            }
            else
            {
                //First we create an instance of this specific type.
                newObject = this.GetType().InvokeMember(this.GetType().Name, BINDINGS_CREATE_INSTANCE, null, null, null) as EntityBaseReadOnly;
                //We get the array of fields for the new type instance.
                FieldInfo[] fields = newObject.GetType().GetFields(BINDINGS_PRIVATE_INSTANCES);
                try
                {
                    foreach (FieldInfo fi in fields)
                    {
                        if (fi.FieldType.IsValueType)
                        {
                            fi.SetValue(newObject, fi.GetValue(this));
                        }
                        else // Is Reference Type
                        {
                            //We query if the fields support the ICloneable interface.
                            Type ICloneType = fi.FieldType.GetInterface("ICloneable", true);
                            if (ICloneType != null)
                            {
                                //Getting the ICloneable interface from the object.
                                ICloneable cloneableObject = fi.GetValue(this) as ICloneable;
                                if (cloneableObject != null)
                                {
                                    //We use the clone method to set the new value to the field.
                                    fi.SetValue(newObject, cloneableObject.Clone());
                                }
                            }
                            else
                            {
                                // Doesn't support ICloneable... so default to copying the reference to it.
                                fi.SetValue(newObject, fi.GetValue(this));
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }

            newObject.IsDeleted = this.IsDeleted;
            newObject.IsNew = this.IsNew;
            newObject.IsDirty = this.IsDirty;

            return newObject;
        }

        /// <summary>
        /// Clone the object, and returning a reference to a cloned object.
        /// </summary>
        /// <returns>Reference to the new cloned object.</returns>
        public virtual object Clone()
        {
            return Clone(CloneType.Shallow);
        }

        /// <summary>
        /// Persists a Customer object to the data store. This is 
        /// internal, and is used for recursive saves within a transaction.
        /// </summary>
        /// <param name="helper">The data connection helper</param>
        public virtual void Save(SqlHelper helper)
        {
            EntityCancelEventArgs e = new EntityCancelEventArgs(this, helper);

			OnSaveStarting(e);

            if (!e.Cancel)
            {
				UpdateChildren(helper, UpdateType.Save);
				OnSaveFinished(new EntityEventArgs(this, helper));
			}
        }
		#endregion

		#region Non-Public Methods
		private static System.Collections.Hashtable typePropertyCustomAttributes = new System.Collections.Hashtable();
        private static Dictionary<Type, Dictionary<string, PropertyInfo>> _databaseColumnProperties = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		/// <summary>
		/// Get the database column property info (null if it doesn't exist)
		/// </summary>
        internal static System.Reflection.PropertyInfo GetDatabaseColumnPropertyInfo(Type type, string propertyName)
		{
			System.Reflection.PropertyInfo returnValue = null;
			
			propertyName = propertyName.ToLower();
			
			if (GetDatabaseColumnProperties(type).ContainsKey(propertyName))
			{
				returnValue = GetDatabaseColumnProperties(type)[propertyName];
			}
			
			return returnValue;
	    }

		/// <summary>
		/// Get database column properties
		/// </summary>
		/// <param name="reader">The data row to use to initialize the object with</param>
        private static Dictionary<string, PropertyInfo> GetDatabaseColumnProperties(Type type)
        {
            if (!_databaseColumnProperties.ContainsKey(type))
            {
                Dictionary<string, PropertyInfo> dictionary = new Dictionary<string, PropertyInfo>();

                dictionary = new Dictionary<string, PropertyInfo>();

                PropertyInfo[] propertyList = type.GetProperties();

                foreach (PropertyInfo property in propertyList)
                {
                    Object[] propertyAttributes = property.GetCustomAttributes(typeof(DatabaseColumnAttribute), true);

                    if (propertyAttributes.Length > 0)
                    {
                        string propertyName = property.Name.ToLower();

                        DatabaseColumnAttribute databaseColumn = (DatabaseColumnAttribute)propertyAttributes.GetValue(0);

                        if (!String.IsNullOrEmpty(databaseColumn.Name))
                        {
                            propertyName = databaseColumn.Name.ToLower();
                        }

                        dictionary.Add(propertyName, property);
                    }                    
                }

                _databaseColumnProperties.Add(type, dictionary);

                return dictionary;
            }
            else
            {
                return _databaseColumnProperties[type];
            }
        }
		
		/// <summary>
		/// Used to initialize an entity from a data reader
		/// </summary>
		/// <param name="reader">The data row to use to initialize the object with</param>
		internal void Initialize(IDataReader reader)
        {
			System.Type type = this.GetType();
			
			// For each column in the data reader, update the like-named property in the entity.
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (!reader.IsDBNull(i))
                {
					// Get the property information from the Entity for the name of the column
                    PropertyInfo propertyInfo = GetDatabaseColumnPropertyInfo(type, reader.GetName(i));
                    
					if (propertyInfo != null)
                    {
						// Property found with same name as column
                        SetPropertyValueIfNotNull(this, propertyInfo, reader[i]);
                    }
                }
            }
			
            this.IsNew = false;
            this.IsDirty = false;
		}

        /// <summary>
		/// Used to initialize an entity from a data row
		/// </summary>
		/// <param name="rowView">The data row to use to initialize the object with</param>
		internal void Initialize(DataRowView rowView)
        {
			System.Type type = this.GetType();
			
			// For each column in the data reader, update the like-named property in the entity.
            for (int i = 0; i < rowView.Row.Table.Columns.Count; i++)
            {
                if (!rowView.Row.IsNull(i))
                {
					// Get the property information from the Entity for the name of the column
                    PropertyInfo propertyInfo = GetDatabaseColumnPropertyInfo(type, rowView.Row.Table.Columns[i].ColumnName);
                    
					if (propertyInfo != null)
                    {
						// Property found with same name as column
                        SetPropertyValueIfNotNull(this, propertyInfo, rowView[i]);
                    }
                }
            }
            this.IsNew = false;
            this.IsDirty = false;
		}

        /// <summary>
        /// Updates all child entities
        /// </summary>
        /// <param name="helper">The current connection to the database</param>
		/// <param name="type">The type of update to perform on the children entities</param>
        protected void UpdateChildren(SqlHelper helper, UpdateType type)
        {
			if (!IsSaveRequired) return;
			
			try
			{
				Dictionary<string, PropertyInfo> properties = GetPropertyList(ColumnType.SaveableChildEntities);
	
				foreach (string key in properties.Keys)
				{
					object currentValue = GetPropertyValue(this, properties[key]);
	
					if (currentValue != null)
					{
						if (type == UpdateType.Save)
						{
							System.Reflection.MethodInfo methodInfo = EntityBaseReadOnly.GetSaveMethodWithSqlHelperParameter(currentValue);
	
							if (methodInfo != null)
							{
								System.Reflection.MethodBase methodBase = (System.Reflection.MethodBase)methodInfo;
	
								object[] parameters = new object[] { helper };
	
								methodBase.Invoke(currentValue, parameters);
							}
						}
						else
						{
							System.Reflection.MethodInfo methodInfo = EntityBaseReadOnly.GetRollBackMethod(currentValue);
	
							if (methodInfo != null)
							{
								System.Reflection.MethodBase methodBase = (System.Reflection.MethodBase)methodInfo;
								methodBase.Invoke(currentValue, null);
							}
	
						}
					}
				}
			}
            catch (System.Reflection.TargetInvocationException targetInvocationException)
            {
                throw (targetInvocationException.InnerException);
            }
            catch
            {
                throw;
            }
        }
    
		/// <summary>
		/// This is called before an entity is saved to ensure that any parent entities keys are set properly
		/// </summary>
		protected abstract void EnsureParentProperties();
		
        /// <summary>
        /// Retrieve the parameters for this object
        /// </summary>
        /// <param name="columnType">The type of columns to get for the parameters</param>
        /// <returns>A list of parameters</returns>
        protected System.Collections.Generic.List<SqlParameter> GetParameterList(ColumnType columnType)
        {
            System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();

            Dictionary<string, PropertyInfo> propertyList = GetPropertyList(columnType);

            foreach (string propertyName in propertyList.Keys)
            {
				if (propertyList[propertyName].PropertyType.FullName == "System.Byte[]")
				{
					SqlParameter varbinaryMax = new SqlParameter("@" + propertyName, SqlDbType.VarBinary, -1);
					varbinaryMax.Value = GetDatabaseValue(propertyList[propertyName], propertyList[propertyName].GetValue(this, null));
					parameters.Add(varbinaryMax);
				}
				else 
				{
	                parameters.Add(new SqlParameter("@" + propertyName, GetDatabaseValue(propertyList[propertyName], propertyList[propertyName].GetValue(this, null))));
    	        }
			}
            return parameters;
             
        }

        /// <summary>
		/// if about to load a lazy load entity, search through the parent items and check to make sure
        /// it already doesn't exist.  If it does, replace
        /// </summary>
        /// <param name="entity">The entity thought to be the parent</param>
        /// <returns>The parent entity</returns>
        internal EntityBaseReadOnly GetParentEntity(EntityBaseReadOnly entity)
        {
            EntityBaseReadOnly returnValue = entity;

            if (entity != null && !entity.IsNew)
            {
                System.Reflection.PropertyInfo property = this.GetType().GetProperty("Parent", BINDINGS_ALL_INCLUDING_BASE);

                if (property != null)
                {
                    object parentValue = property.GetValue(this, null);

                    while (parentValue != null)
                    {
                        if (parentValue.GetType() == entity.GetType())
                        {
                            EntityBaseReadOnly parentEntity = parentValue as EntityBaseReadOnly;

                            if (parentEntity != null)
                            {
                                if (parentEntity.UniqueIdentifier == entity.UniqueIdentifier)
                                {
                                    returnValue = parentValue as EntityBaseReadOnly;
                                    break;
                                }
                            }
                        }

                        property = parentValue.GetType().GetProperty("Parent", BINDINGS_ALL_INCLUDING_BASE);
                        parentValue = property.GetValue(parentValue, null);
                    }
                }
            }

            return returnValue;
        }

		/// <summary>
        /// Verify the entity is not a parent
        /// </summary>
        /// <param name="entity">Determines if the entity is the parent</param>
        /// <returns>True if it is the parent, false otherwise</returns>
        internal bool IsParentEntity(EntityBaseReadOnly entity)
        {
            bool returnValue = false;

            if (entity != null && !entity.IsNew)
            {
                System.Reflection.PropertyInfo property = this.GetType().GetProperty("Parent", BINDINGS_ALL_INCLUDING_BASE);

                if (property != null)
                {
                    object parentValue = property.GetValue(this, null);

                    while (parentValue != null)
                    {
                        if (parentValue.GetType() == entity.GetType())
                        {
                            EntityBaseReadOnly parentEntity = parentValue as EntityBaseReadOnly;

                            if (parentEntity != null)
                            {
                                if (parentEntity.UniqueIdentifier == entity.UniqueIdentifier)
                                {
                                    returnValue = true;
                                    break;
                                }
                            }
                        }

                        property = parentValue.GetType().GetProperty("Parent", BINDINGS_ALL_INCLUDING_BASE);
                        parentValue = property.GetValue(parentValue, null);
                    }
                }
            }

            return returnValue;
        }

  		/// <summary>
        /// Get Property List with specified attributes
        /// </summary>
        /// <param name="columnType">The type of colums to get</param>
        /// <returns>The list of properties</returns>
        public Dictionary<string, System.Reflection.PropertyInfo> GetPropertyList(ColumnType columnType)
        {
            Dictionary<string, PropertyInfo> returnValue = new Dictionary<string, PropertyInfo>();

            System.Type type = this.GetType();

            PropertyInfo[] propertyList = type.GetProperties();

            foreach (PropertyInfo propertyInfo in propertyList)
            {

                if (columnType == ColumnType.SaveableChildEntities)
                {
                    if (propertyInfo.PropertyType.IsGenericType && propertyInfo.Name != "Parent")
                    {
                        System.Type genericType = propertyInfo.PropertyType.GetGenericTypeDefinition();

                        if (genericType.Equals(typeof(EntityList<>)))
                        {
                            returnValue.Add(propertyInfo.Name, propertyInfo);
                        }
                    }
                }
                else
                {
                    object[] attributes = propertyInfo.GetCustomAttributes(typeof(DatabaseColumnAttribute), true);

                    if (attributes.Length > 0)
                    {
                        string propertyName = propertyInfo.Name;

                        DatabaseColumnAttribute column = (DatabaseColumnAttribute)attributes.GetValue(0);

                        if (column.Name != String.Empty)
                        {
                            propertyName = column.Name;
                        }

                        if (columnType == ColumnType.PrimaryKeyColumn || columnType == ColumnType.DatabaseColumnNoIdentity)
                        {
                            attributes = propertyInfo.GetCustomAttributes(typeof(System.ComponentModel.DataObjectFieldAttribute), true);

                            if (attributes.Length > 0)
                            {
                                System.ComponentModel.DataObjectFieldAttribute fieldAttribute = (System.ComponentModel.DataObjectFieldAttribute)attributes.GetValue(0);

                                if (fieldAttribute.PrimaryKey && columnType == ColumnType.PrimaryKeyColumn) returnValue.Add(propertyName, propertyInfo);
                                else if (!fieldAttribute.IsIdentity && columnType == ColumnType.DatabaseColumnNoIdentity) returnValue.Add(propertyName, propertyInfo);
                            }
                            else returnValue.Add(propertyName, propertyInfo);
                        }

                        else returnValue.Add(propertyName, propertyInfo);
                    }
                }
            }

            return returnValue;
        }
		
		/// <summary>
        /// Set the property value, trying to do it by instance and then property
        /// </summary>
		/// <param name="entity">The entity</param>
        /// <param name="property">The property to set</param>
        /// <param name="value">The value to use</param>
        internal static void SetPropertyValueIfNotNull(EntityBaseReadOnly entity, PropertyInfo property, object value)
        {
            if (!Convert.IsDBNull(value))
            {
                string fieldName = "_" + property.Name.Substring(0, 1).ToLower() + property.Name.Substring(1);

                FieldInfo field = null;

                Type entityType = entity.GetType();

                while (field == null && entityType != null)
                {
                    field = entityType.GetField(fieldName, BINDINGS_PRIVATE_INSTANCES);

                    if (field == null)
                    {
                        entityType = entityType.BaseType;
                    }
                }

                if (field != null)
                {
                    field.SetValue(entity, Convert.ChangeType(value, field.FieldType));
                }
                else
                {
                    property.SetValue(entity, Convert.ChangeType(value, property.PropertyType), null);
                }
            }
        }
        #endregion
		
		#region Non-Public Static Properties
		/// <summary>
		/// This is the default sort order that will be used when retrieving records from the database using dynamic SQL
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected static string DefaultSortOrder
		{
			get { return ""; }
		}

		/// <summary>
		/// This is the table name related to the entity class.  No brackets or prefix should be used.  Only the
		/// table name
		/// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected static string TableName
        {
            get { return String.Empty; }
        }

		#endregion
		
		#region Non-Public Static Methods and Constants

        #region GetDatabaseValue
        /// <summary>
        /// Get Database value for specified type
        /// </summary>
        /// <param name="property">The property to get the database value for</param>
        /// <param name="value">The default value</param>
        /// <returns>The database-safe value</returns>
        protected static object GetDatabaseValue(PropertyInfo property, object value)
        {
            object returnValue = System.DBNull.Value;

            if (value != null)
            {
                FieldInfo minValue = property.PropertyType.GetField("MinValue");

                if (minValue != null)
                {
                                                            if (!minValue.GetValue(null).ToString().Equals(value.ToString()))                   
                                                            {
                        returnValue = value;
                    }
                }
                else
                {
                    FieldInfo emptyValue = property.PropertyType.GetField("Empty");

                    if (emptyValue != null)
                    {
                        if (emptyValue.GetValue(null).ToString().Equals(value.ToString()))
                        {
                            object[] fieldAttributes = property.GetCustomAttributes(typeof(System.ComponentModel.DataObjectFieldAttribute), true);

                            bool isNullable = false;

                            if (fieldAttributes.Length > 0)
                            {
                                System.ComponentModel.DataObjectFieldAttribute fieldAttribute = (System.ComponentModel.DataObjectFieldAttribute)fieldAttributes.GetValue(0);
                                isNullable = fieldAttribute.IsNullable;
                            }

                            if (!isNullable)
                            {
                                returnValue = value;
                            }
                        }
                        else
                        {
                            returnValue = value;
                        }
                    }
                    else
                    {
                        returnValue = value;
                    }
                }

             
            }
            else
            {
                object[] fieldAttributes = property.GetCustomAttributes(typeof(System.ComponentModel.DataObjectFieldAttribute), true);

                if (fieldAttributes.Length > 0)
                {
                    System.ComponentModel.DataObjectFieldAttribute fieldAttribute = (System.ComponentModel.DataObjectFieldAttribute)fieldAttributes.GetValue(0);

                    if (!fieldAttribute.IsNullable)
                    {
                        FieldInfo emptyValue = property.PropertyType.GetField("Empty");

                        if (emptyValue != null)
                        {
                            returnValue = emptyValue.GetValue(null);
                        }
                    }
                }
            }

            return returnValue;

        }


		/// <summary>
        /// Gets a value that can be inserted into the database
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>A database acceptable value for the input</returns>
        protected static object GetDatabaseValue(DateTime input)
        {
            object returnValue = System.DBNull.Value;

            if (input != DateTime.MinValue)
            {
                returnValue = input;
            }

            return returnValue;
        }

        /// <summary>
        /// Gets a value that can be inserted into the database
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>A database acceptable value for the input</returns>
        protected static object GetDatabaseValue(decimal input)
        {
            object returnValue = System.DBNull.Value;

            if (input != decimal.MinValue)
            {
                returnValue = input;
            }

            return returnValue;
        }

        /// <summary>
        /// Gets a value that can be inserted into the database
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>A database acceptable value for the input</returns>
        protected static object GetDatabaseValue(int input)
        {
            object returnValue = System.DBNull.Value;

            if (input != int.MinValue)
            {
                returnValue = input;
            }

            return returnValue;
        }

        /// <summary>
        /// Gets a value that can be inserted into the database
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>A database acceptable value for the input</returns>
        protected static object GetDatabaseValue(double input)
        {
            object returnValue = System.DBNull.Value;

            if (input != double.MinValue)
            {
                returnValue = input;
            }

            return returnValue;

        }

        /// <summary>
        /// Gets a value that can be inserted into the database
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>A database acceptable value for the input</returns>
        protected static object GetDatabaseValue(string input)
        {
            object returnValue = System.DBNull.Value;

            if (input != String.Empty && input != null)
            {
                returnValue = input;
            }

            return returnValue;
        }

        /// <summary>
        /// Gets a value that can be inserted into the database
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>A database acceptable value for the input</returns>
        protected static object GetDatabaseValue(byte input)
        {
            object returnValue = System.DBNull.Value;

            if (input != byte.MinValue)
            {
                returnValue = input;
            }

            return returnValue;
        }

        /// <summary>
        /// Gets a value that can be inserted into the database
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>A database acceptable value for the input</returns>
        protected static object GetDatabaseValue(short input)
        {
            object returnValue = System.DBNull.Value;

            if (input != short.MinValue)
            {
                returnValue = input;
            }

            return returnValue;
        }

        /// <summary>
        /// Gets a value that can be inserted into the database
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>A database acceptable value for the input</returns>
        protected static object GetDatabaseValue(Guid input)
        {
            object returnValue = System.DBNull.Value;

            if (input != Guid.Empty)
            {
                returnValue = input;
            }

            return returnValue;
        }

        /// <summary>
        /// Gets a value that can be inserted into the database
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns>A database acceptable value for the input</returns>
        protected static object GetDatabaseValue(Int64 input)
        {
            object returnValue = System.DBNull.Value;

            if (input != Int64.MinValue)
            {
                returnValue = input;
            }

            return returnValue;
        }
        #endregion

        /// <summary>
        /// Get the property value, attempting by instance and then property 
        /// </summary>
		/// <param name="entity">the entity to get the property value from</param>
        /// <param name="property">The property to get the value from</param>
        /// <returns>the retrieved value</returns>
        public static object GetPropertyValue(EntityBaseReadOnly entity, PropertyInfo property)
        {
            object returnValue = null;

            string fieldName = "_" + property.Name.Substring(0, 1).ToLower() + property.Name.Substring(1);

            FieldInfo field = entity.GetType().GetField(fieldName, BINDINGS_PRIVATE_INSTANCES);

            if (field != null)
            {
                returnValue = field.GetValue(entity);
            }
            else if (property.CanRead)
            {
                returnValue = property.GetValue(entity, null);
            }

            return returnValue;
        }

        /// <summary>
        /// Uses reflection to get a new instance of an entity using the Create factory method
        /// </summary>
        /// <typeparam name="T">The type of entity to create</typeparam>
        /// <returns>The creacted entityBase</returns>
        internal static T GetEntityInstance<T>()
        {
               return (T)typeof(T).InvokeMember(typeof(T).Name, BINDINGS_CREATE_INSTANCE, null, null, null);
        }
        
        
     	/// <summary>
        /// Gets a single EntityBaseReadOnly object. This is protected and can be used from other retrieval methods.
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="commandText">The sql command to execute against the database</param>
        /// <param name="parameters">The parameters to be used for the database command</param>
        /// <param name="helper">SqlHelper</param>
        /// <returns>The retrieved EntityBaseReadOnly object.</returns>
        protected internal static T GetOne<T>(string commandText, List<SqlParameter> parameters, SqlHelper helper) where T : EntityBaseReadOnly
		{
			using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
			{
				return Initialize<T>(reader);
			}
		}

     	/// <summary>
        /// Gets a single EntityBaseReadOnly object. This is protected and can be used from other retrieval methods.
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="commandText">The sql command to execute against the database</param>
        /// <param name="parameters">The parameters to be used for the database command</param>
        /// <returns>The retrieved EntityBaseReadOnly object.</returns>
        protected internal static T GetOne<T>(string commandText, List<SqlParameter> parameters) where T : EntityBaseReadOnly
		{
			using (SqlHelper helper = new SqlHelper())
			{
                return GetOne<T>(commandText,parameters,helper);
			}
		}
		
		/// <summary>
        /// Gets a collection EntityBaseReadOnly objects. This is protected and can be used from other retrieval methods.
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="commandText">The sql command to execute against the database</param>
        /// <param name="parameters">The parameters to be used for the database command</param>
        /// <returns>The retrieved collection of EntitBase objects.</returns>
        protected internal static EntityList<T> GetList<T>(string commandText, List<SqlParameter> parameters) where T : EntityBaseReadOnly
		{
			using (SqlHelper helper = new SqlHelper()) 
			{
				using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return InitializeList<T>(reader);
				}
			}
		}

        /// <summary>
        /// Gets a collection EntityBaseReadOnly objects. This is protected and can be used from other retrieval methods.
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="parent">Parent Entity</param>
        /// <param name="commandText">The sql command to execute against the database</param>
        /// <param name="parameters">The parameters to be used for the database command</param>
        /// <returns>The retrieved collection of EntitBase objects.</returns>
        protected internal static EntityList<T> GetList<T>(EntityBaseReadOnly parent, string commandText, List<SqlParameter> parameters) where T : EntityBaseReadOnly
        {
            using (SqlHelper helper = new SqlHelper())
            {
                using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return InitializeList<T>(parent, reader);
				}
            }
        }
		
        /// <summary>
        /// Gets a collection EntityBaseReadOnly objects. This is protected and can be used from other retrieval methods.
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="selectedFieldList">Selected Field List</param>
        /// <param name="parameters">From statement and Where clause</param>
		/// <param name="orderBy">Order By</param>
		/// <param name="parameters">Parameters</param>
		/// <param name="startRowIndex">Start Page</param>
		/// <param name="pageSize">PageSize</param>
        /// <returns>The retrieved collection of EntitBase objects.</returns>
        protected internal static EntityList<T> GetList<T>(string selectedFieldList, string fromStatementAndCriteria, List<SqlParameter> parameters,string orderBy,  long startRowIndex, int pageSize) where T : EntityBaseReadOnly
        {
            long startRow = startRowIndex + 1;
            long endRow = startRow + (pageSize - 1);

			if (orderBy == null || orderBy.Trim() == String.Empty)
            {
                orderBy = DefaultSortOrder;
            }

            if (orderBy == null || orderBy.Trim() == String.Empty)
            {
                orderBy = "order by GetDate()";
            }
            else if (!orderBy.Trim().ToLower().StartsWith("order by "))
            {
                orderBy = "order by " + orderBy;
            }
			
            using (SqlHelper helper = new SqlHelper())
            {
                string commandText = @"SELECT * FROM (SELECT ROW_NUMBER() OVER (" + orderBy + ") AS row_number, " + selectedFieldList + " " + fromStatementAndCriteria + ") AS pagedTable WHERE row_number between " + startRow.ToString() + " and " + endRow.ToString();

                using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
                {
                    return InitializeList<T>(reader);
                }
            }

        }

        /// <summary>
        /// Gets a collection EntityBaseReadOnly objects. This is protected and can be used from other retrieval methods.
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="selectedFieldList">Selected Field List</param>
        /// <param name="parameters">From statement and Where clause</param>
		/// <param name="orderBy">Order By</param>
		/// <param name="parameters">Parameters</param>
		/// <param name="startPage">Start Page</param>
		/// <param name="endIndex">PageSize</param>
		/// <param name="totalRows">Output parameter.  Total rows will be returned</param>
        /// <returns>The retrieved collection of EntitBase objects.</returns>
        protected internal static EntityList<T> GetList<T>(string selectedFieldList, string fromStatementAndCriteria, List<SqlParameter> parameters, string orderBy, long startRowIndex, int pageSize, out long totalRows) where T : EntityBaseReadOnly
        {
            totalRows = 0;

            using (SqlHelper helper = new SqlHelper())
            {
                string commandText = @"SELECT count(*) " + fromStatementAndCriteria;

                using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
                {
                    if (reader.Read())
                    {
                        totalRows = reader.GetInt32(0);
                    }
                }
            }

            return GetList<T>(selectedFieldList, fromStatementAndCriteria, parameters, orderBy, startRowIndex, pageSize);
        }
		
		/// <summary>
        /// Gets a collection EntityBaseReadOnly objects. This is protected and can be used from other retrieval methods.
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="parent">Parent Entity</param>
        /// <param name="commandText">The sql command to execute against the database</param>
        /// <param name="parameters">The parameters to be used for the database command</param>
        /// <returns>The retrieved collection of EntitBase objects.</returns>
        protected internal static EntityListReadOnly<T> GetListReadOnly<T>(EntityBaseReadOnly parent, string commandText, List<SqlParameter> parameters) where T : EntityBaseReadOnly
        {
            using (SqlHelper helper = new SqlHelper())
            {
                using(IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
                	return InitializeListReadOnly<T>(parent, reader);
				}
            }
        }

		/// <summary>
        /// Gets a collection EntityBaseReadOnly objects. This is protected and can be used from other retrieval methods.
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="commandText">The sql command to execute against the database</param>
        /// <param name="parameters">The parameters to be used for the database command</param>
        /// <returns>The retrieved collection of EntitBase objects.</returns>
        protected internal static EntityListReadOnly<T> GetListReadOnly<T>(string commandText, List<SqlParameter> parameters) where T : EntityBaseReadOnly
        {
            using (SqlHelper helper = new SqlHelper())
            {
                using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					return InitializeListReadOnly<T>(reader);
				}
            }
        }

		/// <summary>
        /// Initialize the properties of a custom business object from a datareader
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="dataReader">An object that implements the IDataReader interface</param>
        /// <returns>The instance of the business object to initialize</returns>
        protected static T Initialize<T>(IDataReader reader) where T : EntityBaseReadOnly
        {
            if (reader.Read())
			{
                T entity = GetEntityInstance<T>();
                entity.Initialize(reader);
                return entity;
			}
			else 
			{
				return default(T);	
			}
        }

        /// <summary>
        /// Initialize the properties of a custom business object from a dataview
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="dataReader">A DataView object</param>
		/// <returns>The instance of the business object to initialize</returns>
        protected static T Initialize<T>(DataRowView dataView) where T : EntityBaseReadOnly
        {
            if(dataView != null)
            {
                T entity = GetEntityInstance<T>();
                entity.Initialize(dataView);
                return entity;
			}
			else 
			{
				return default(T);	
			}
        }

        /// <summary>
        /// Initialize the properties of a custom business object from a datatable
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="dataReader">A DataTable object</param>
        /// <returns>The instance of the business object</returns>
        protected static T Initialize<T>(DataTable dataTable) where T : EntityBaseReadOnly
        {
            if (dataTable.Rows.Count > 0) 
			{
				return Initialize<T>(dataTable.DefaultView[0]);
			}
			else 
			{
				return default(T);	
			}
        }

        /// <summary>
        /// Initialize the properties of a list of custom business objects from a datareader
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="dataReader">An object that implements the IDataReader interface</param>
        /// <returns>A collection of custom business objects of type T</returns>
        protected static EntityList<T> InitializeList<T>(IDataReader reader) where T : EntityBaseReadOnly
        {
            EntityList<T> list = new EntityList<T>(reader);
            return list;
        }

        /// <summary>
        /// Initialize the properties of a list of custom business objects from a datareader
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="dataReader">An object that implements the IDataReader interface</param>
        /// <returns>A collection of custom business objects of type T</returns>
        protected static EntityList<T> InitializeList<T>(EntityBaseReadOnly parent, IDataReader reader) where T : EntityBaseReadOnly
        {
            EntityList<T> list = new EntityList<T>(parent, reader);
            return list;
        }

        /// <summary>
		/// Initialize the properties of a list of custom business objects from a datareader
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
		/// <param name="parent">The parent entity</param>
        /// <param name="dataReader">An object that implements the IDataReader interface</param>
        /// <returns>A collection of custom business objects of type T</returns>
        protected static EntityListReadOnly<T> InitializeListReadOnly<T>(EntityBaseReadOnly parent, IDataReader reader) where T : EntityBaseReadOnly
        {
            EntityListReadOnly<T> list = new EntityListReadOnly<T>(parent, reader);
            return list;
        }
		
		/// <summary>
		/// Initialize the properties of a list of custom business objects from a datareader
        /// </summary>
        /// <typeparam name="T">The type of custom business object to initialize</typeparam>
        /// <param name="dataReader">An object that implements the IDataReader interface</param>
        /// <returns>A collection of custom business objects of type T</returns>
        protected static EntityListReadOnly<T> InitializeListReadOnly<T>(IDataReader reader) where T : EntityBaseReadOnly
        {
            EntityListReadOnly<T> list = new EntityListReadOnly<T>(reader);
            return list;
        }

        /// <summary>
        /// Search the Entity for a save method with Transaction Request parameter
        /// </summary>
        /// <param name="list">List Entity</param>
        /// <returns>MethodInfo of found save method</returns>
        private static System.Reflection.MethodInfo GetSaveMethodWithSqlHelperParameter(object list)
        {
            System.Type listType = list.GetType();

            System.Reflection.MethodInfo[] methodInfoList = listType.GetMethods(BINDINGS_ALL_INCLUDING_BASE);

            System.Reflection.MethodInfo methodInfo = null;

            foreach (System.Reflection.MethodInfo currentMethod in methodInfoList)
            {
                System.Reflection.ParameterInfo[] parameterList = currentMethod.GetParameters();

                if (parameterList.Length == 1 && currentMethod.Name == "Save")
                {
                    methodInfo = currentMethod;
                }
            }

            return methodInfo;
        }

        /// <summary>
        /// Search the Entity for a save method with Transaction Request
        /// parameter
        /// </summary>
        /// <param name="list">List Entity</param>
        /// <returns>MethodInfo of found save method</returns>
        private static System.Reflection.MethodInfo GetRollBackMethod(object list)
        {
            System.Type listType = list.GetType();

            System.Reflection.MethodInfo[] methodInfoList = listType.GetMethods(BINDINGS_ALL_INCLUDING_BASE);

            System.Reflection.MethodInfo methodInfo = null;

            foreach (System.Reflection.MethodInfo currentMethod in methodInfoList)
            {
                System.Reflection.ParameterInfo[] parameterList = currentMethod.GetParameters();

                if (parameterList.Length == 0 && currentMethod.Name == "RollBack")
                {
                    methodInfo = currentMethod;
                }
            }

            return methodInfo;
        }
        #endregion

		#region Enumerations
        /// <summary>
        /// Clone Type
        /// </summary>
        public enum CloneType
        {
            Deep,
            Shallow
        }

		/// <summary>
        /// RollBack or Save Type
        /// </summary>
        protected enum UpdateType
        {
            RollBack,
            Save
        }
		
		/// <summary>
        /// Desired Column Type
        /// </summary>
        public enum ColumnType
        {
            DatabaseColumn,
			DatabaseColumnNoIdentity,
            PrimaryKeyColumn,
            SaveableChildEntities
        }
		#endregion
		
		#region Constants
		protected const BindingFlags BINDINGS_PRIVATE_INSTANCES = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        protected const BindingFlags BINDINGS_PUBLIC_INSTANCES = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
        protected const BindingFlags BINDINGS_ALL_INCLUDING_BASE = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
        protected const BindingFlags BINDINGS_CREATE_INSTANCE = BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        protected const BindingFlags BINDINGS_PUBLIC_STATIC = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
		#endregion
    }
}
