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
    public abstract partial class EntityBase: INotifyPropertyChanged
    {
		#region Public Events and Event Handler Methods
		/// <summary>
        /// Event that is fired when a property changes
        /// </summary>
		[field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method responsible for raising the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The name of the property that changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Method responsible for raising the PropertyChanged event
        /// </summary>
        /// <param name="e">Teh PropertyChangedEventArgs class</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
		
		/// <summary>
        /// Event that is fired when a IsNew, IsDirty or IsDeleted changes
        /// </summary>
        [field: NonSerialized()]
        public event PropertyChangedEventHandler StateChanged;

        /// <summary>
        /// Method responsible for raising the StateChanged event
        /// </summary>
        /// <param name="propertyName">The name of the property that changed</param>
        protected virtual void OnStateChanged(string propertyName)
        {
            OnStateChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Method responsible for raising the StateChanged event
        /// </summary>
        /// <param name="e">The PropertyChangedEventArgs class</param>
        protected virtual void OnStateChanged(PropertyChangedEventArgs e)
        {
            if (StateChanged != null)
            {
                StateChanged(this, e);
            }
        }
		
		/// <summary>
		/// Event that is fired before a save occurs
		/// </summary>
		[field: NonSerialized()]
        public event EventHandler<EntityCancelEventArgs> Saving;
		
		/// <summary>
		/// Method responsible for raising the Saving event
		/// </summary>
		protected virtual void OnSaving(EntityCancelEventArgs e) 
		{
			if (Saving != null)
			{
				Saving(this, e);	
			}
		}
		
		/// <summary>
		/// Event that is fired after a save is successful
		/// </summary>
		[field: NonSerialized()]
        public event EventHandler<EntityEventArgs> Saved;
		
		/// <summary>
		/// Method responsible for raising the Saved event
		/// </summary>
		protected virtual void OnSaved(EntityEventArgs e) 
		{
			if (Saved != null)
			{
				Saved(this, e);
			}
		}
		
		/// <summary>
		/// Event that is fired before a delete occurs
		/// </summary>
        [field: NonSerialized()]
		public event EventHandler<EntityCancelEventArgs> Deleting;
		
		/// <summary>
		/// Method responsible for raising the Deleting event
		/// </summary>
		protected virtual void OnDeleting(EntityCancelEventArgs e) 
		{
			if (Deleting != null)
			{
				Deleting(this, e);	
			}
		}
		
		/// <summary>
		/// Event that is fired after a delete is successful
		/// </summary>
        [field: NonSerialized()]
		public event EventHandler<EntityEventArgs> Deleted;
		
		/// <summary>
		/// Method responsible for raising the Deleted event
		/// </summary>
		protected virtual void OnDeleted(EntityEventArgs e) 
		{
			if (Deleted != null)
			{
				Deleted(this, e);
			}
		}
		
		/// <summary>
		/// Event that is fired before an insert occurs
		/// </summary>
        [field: NonSerialized()]
		public event EventHandler<EntityCancelEventArgs> Inserting;
		
		/// <summary>
		/// Method responsible for raising the Inserting event
		/// </summary>
		protected virtual void OnInserting(EntityCancelEventArgs e) 
		{
			if (Inserting != null)
			{
				Inserting(this, e);	
			}
		}
		
		/// <summary>
		/// Event that is fired after an insert is successful
		/// </summary>
        [field: NonSerialized()]
		public event EventHandler<EntityEventArgs> Inserted;
		
		/// <summary>
		/// Method responsible for raising the Inserted event
		/// </summary>
		protected virtual void OnInserted(EntityEventArgs e) 
		{
			if (Inserted != null)
			{
				Inserted(this, e);
			}
		}
		
		/// <summary>
		/// Event that is fired before an update occurs
		/// </summary>
        [field: NonSerialized()]
		public event EventHandler<EntityCancelEventArgs> Updating;
		
		/// <summary>
		/// Method responsible for raising the Updating event
		/// </summary>
		protected virtual void OnUpdating(EntityCancelEventArgs e) 
		{
			if (Updating != null)
			{
				Updating(this, e);	
			}
		}
		
		/// <summary>
		/// Event that is fired after an update is successful
		/// </summary>
        [field: NonSerialized()]
		public event EventHandler<EntityEventArgs> Updated;		
		/// <summary>
		/// Method responsible for raising the Updated event
		/// </summary>
		protected virtual void OnUpdated(EntityEventArgs e) 
		{
			if (Updated != null)
			{
				Updated(this, e);
			}
		}	

		/// <summary>
		/// Event that is fired after a replacement of core data from one entity to another has successful
		/// </summary>
		[field: NonSerialized()]
        public event EventHandler<EventArgs> Replaced;
		/// <summary>
		/// Method responsible for raising the Replaced event
		/// </summary>
        public virtual void OnReplaced(object sender, EventArgs e)
        {
            if (Replaced != null)
            {
                Replaced(sender, e);
            }
        }

		/// <summary>
		/// Event that is fired after a merge of one entity into another has successful
		/// </summary>
		[field: NonSerialized()]
        public event EventHandler<EventArgs> Merged;
		/// <summary>
		/// Method responsible for raising the Merged event
		/// </summary>
        protected virtual void OnMerged(object sender, EventArgs e)
        {
            if (Merged != null)
            {
                Merged(sender, e);
            }
        }
		
		/// <summary>
		/// Event that is fired before an entity is validated. Can be canceled.
		/// </summary>
		[field: NonSerialized()]
		public event EventHandler<EntityValidationCancelEventArgs> EntityValidating;
		/// <summary>
		/// Method responsible for raising the Validating event
		/// </summary>
        protected virtual void OnEntityValidating(object sender, EntityValidationCancelEventArgs e)
		{
			if (EntityValidating != null)
			{
				EntityValidating(sender, e);	
			}
		}

		/// <summary>
		/// Event that is fired after an entity is validated.
		/// </summary>
		[field: NonSerialized()]
		public event EventHandler<EntityValidationEventArgs> EntityValidated;
		/// <summary>
		/// Method responsible for raising the Validated event
		/// </summary>
        protected virtual void OnEntityValidated(object sender, EntityValidationEventArgs e)
		{
			if (EntityValidated != null)
			{
				EntityValidated(sender, e);	
			}
		}
		
		/// <summary>
        /// Event that is fired before a property is validated. Can be canceled.
        /// </summary>
        [field: NonSerialized()]
        public event EventHandler<EntityValidationCancelEventArgs> PropertyValidating;
        /// <summary>
        /// Method responsible for raising the PropertyValidating event
        /// </summary>
        protected virtual void OnPropertyValidating(object sender, EntityValidationCancelEventArgs e)
        {
            if (PropertyValidating != null)
            {
                PropertyValidating(sender, e);
            }
        }

        /// <summary>
        /// Event that is fired after a property is validated.
        /// </summary>
        [field: NonSerialized()]
        public event EventHandler<EntityValidationEventArgs> PropertyValidated;
        /// <summary>
        /// Method responsible for raising the PropertyValidated event
        /// </summary>
        protected virtual void OnPropertyValidated(object sender, EntityValidationEventArgs e)
        {
            if (PropertyValidated != null)
            {
                PropertyValidated(sender, e);
            }
        }
		#endregion
		
		#region Constructors
		/// <summary>
		/// Default Constructor is protected so that a factory method is used to create this object
		/// </summary>
		protected EntityBase() : base() { }
		
		/// <summary>
		/// Constructor that initializes an Entity from a data reader
		/// </summary>
		/// <param name="reader">The reader containing the data row to load</param>
		internal EntityBase(IDataReader reader) : base(reader) { }

        /// <summary>
		/// Constructor that initializes an Entity from a data row
		/// </summary>
		/// <param name="row">The reader containing the data row to load</param>
        internal EntityBase(DataRowView row) : base(row) { } 
		
        /// <summary>
        /// Constructor that initializes an Entity with a parent list
        /// </summary>
        /// <param name="list">The parent list</param>
        internal EntityBase(System.Collections.IList list) : base(list) { }
		#endregion
	
		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isNew = true;
		/// <summary>
		/// Determines if the object is new
		/// </summary>
		public override bool IsNew
		{
			[DebuggerStepThrough()]
			get { return this._isNew; }
			internal set 
			{ 
				if (this._isNew != value) 
				{
					this._isNew = value; 
					this.OnStateChanged("IsNew");
				}
			}
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDirty = true;
		/// <summary>
		/// Determines if the object has been changed since being loaded
		/// </summary>
		public override bool IsDirty
		{
			[DebuggerStepThrough()]
			get { return this._isDirty; }
            internal set {
                if (value != _isDirty)
                {
                    if (value)
                    {
                        if (_originalItem == null)
                        {
                            _originalItem = this.Clone() as EntityBase;
                        }
                    }
                    else if (!_isDeleted && !value)
                    {
                        _originalItem = null;
                    }

                    this._isDirty = value; 
					this.OnStateChanged("IsDirty");
                }
            }
		}

        private EntityBase _originalItem = null;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _isDeleted = false;
		/// <summary>
		/// Determines if the custom business object has been flagged to be deleted
		/// </summary>
		public override bool IsDeleted
		{
			[DebuggerStepThrough()]
			get { return this._isDeleted; }
			internal set 
            {
                if (value != _isDeleted)
                {
                    if (value)
                    {
                        if (_originalItem == null)
                        {
                            _originalItem = this.Clone() as EntityBase;
                        }
                    }
                    else if (!value && !_isDirty)
                    {
                        _originalItem = null;
                    }

                    _isDeleted = value;
					this.OnStateChanged("IsDirty");
                }
            }
		}

		/// <summary>
        /// Gets a <see lanword="bool"/> indicating if the current state is valid.
        /// </summary>
        public bool IsValid
        {
            get 
			{ 
				Validate(null);
				return (this.ValidationErrors.Count == 0); 
			}
        }
		
		private List<ValidationError> _validationErrors;
		public List<ValidationError> ValidationErrors
		{
			get 
			{
				if (_validationErrors == null)
				{
					_validationErrors = new List<ValidationError>();
				}
				return _validationErrors;
			}
			set 
			{
				_validationErrors = value;	
			}
		}
		#endregion
	
		#region Non-Public Properties
		/// <summary>
		/// Gets the SQL statement for an insert
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected abstract string InsertSqlStatement
		{
			get;
		}
		
		/// <summary>
		/// Gets the SQL statement for an update by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected abstract string UpdateSqlStatement
		{
			get;	
		}
		
		/// <summary>
		/// Gets the SQL statement for a delete by key
		/// </summary>
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected abstract string DeleteSqlStatement
		{
			get;	
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// Gets a list of validation errors.
		/// </summary>
		/// <returns>The list of errors</returns>
        public virtual List<ValidationError> GetValidationErrors()
        {
            return GetValidationErrors(String.Empty);
        }

        /// <summary>
        /// Gets a list of validation errors.
        /// </summary>
        /// <param name="helper">The current SqlHelper</param>
        /// <returns>the list of errors</returns>
        public virtual List<ValidationError> GetValidationErrors(SqlHelper helper)
        {
            return GetValidationErrors(helper, String.Empty);
        }

        /// <summary>
        /// Gets a list of validation errors.
        /// </summary>
        /// <param name="validationGroup">The validation group to validate. There are constants for this value in Foresight.DataAccess.Framework.ValidationGroup</param>
        /// <returns>the list of errors</returns>
        public virtual List<ValidationError> GetValidationErrors(string validationGroup)
        {
            return GetValidationErrors(null, validationGroup);
        }

        /// <summary>
        /// Gets a list of validation errors
        /// </summary>
        /// <param name="helper">The current SqlHelper</param>
        /// <param name="validationGroup">The validation group to validate. There are constants for this value in Foresight.DataAccess.Framework.ValidationGroup</param>
        /// <returns>the list of errors</returns>
        public virtual List<ValidationError> GetValidationErrors(SqlHelper helper, string validationGroup)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            EntityValidationCancelEventArgs e = new EntityValidationCancelEventArgs(this, helper, String.Empty, validationGroup);

            OnEntityValidating(this, e);

            if(!e.Cancel)
            {
                Dictionary<string, PropertyInfo> propertyList = GetPropertyList(ColumnType.DatabaseColumn);

                foreach (string propertyName in propertyList.Keys)
                {
                    validationErrors.AddRange(GetValidationErrorsByProperty(propertyName, helper, validationGroup));
                }

                validationErrors.AddRange(GetChildrenValidationErrors());

                OnEntityValidated(this, new EntityValidationEventArgs(this, helper, String.Empty, validationGroup));
            }

            return validationErrors;
        }

        /// <summary>
        /// Gets a list of validation errors for a property.
        /// </summary>
        /// <param name="propertyName">The property to check. There are constants for the properties at Foresight.DataAccess.[EntityName].[EntityName]Properties</param>
        /// <returns>the list of errors.</returns>
        public virtual List<ValidationError> GetValidationErrorsByProperty(string propertyName)
        {
            return GetValidationErrorsByProperty(propertyName, String.Empty);
        }

        /// <summary>
        /// Gets a list of validation errors for a property.
        /// </summary>
        /// <param name="propertyName">The property to check. There are constants for the properties at Foresight.DataAccess.[EntityName].[EntityName]Properties</param>
        /// <param name="helper">The current SqlHelper</param>
        /// <returns>the list of errors</returns>
        public virtual List<ValidationError> GetValidationErrorsByProperty(string propertyName, SqlHelper helper)
        {
            return GetValidationErrorsByProperty(propertyName, helper, String.Empty);
        }

        /// <summary>
        /// Gets a list of validation errors for a property.
        /// </summary>
        /// <param name="propertyName">The property to check. There are constants for the properties at Foresight.DataAccess.[EntityName].[EntityName]Properties</param>
        /// <param name="validationGroup">The validation group to validate. There are constants for this value in Foresight.DataAccess.Framework.ValidationGroup</param>
        /// <returns>the list of errors</returns>
        public virtual List<ValidationError> GetValidationErrorsByProperty(string propertyName, string validationGroup)
        {
            return GetValidationErrorsByProperty(propertyName, null, validationGroup);
        }

        /// <summary>
        /// Gets a list of validation errors for a property.
        /// </summary>
        /// <param name="propertyName">The property to check. There are constants for the properties at Foresight.DataAccess.[EntityName].[EntityName]Properties</param>
        /// <param name="validationGroup">The validation group to validate. There are constants for this value in Foresight.DataAccess.Framework.ValidationGroup</param>
        /// <returns>the list of errors</returns>
        public virtual List<ValidationError> GetValidationErrorsByProperty(string propertyName, SqlHelper helper, string validationGroup)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            EntityValidationCancelEventArgs e = new EntityValidationCancelEventArgs(this, helper, propertyName, validationGroup);

            OnPropertyValidating(this, e);

            if(!e.Cancel)
            {
                System.Type type = this.GetType();
                Dictionary<string, ColumnInfo> columns = ColumnInfo.GetColumnInfoLookup(type);

                ColumnInfo column;
                if (columns.TryGetValue(propertyName, out column))
                {
                    validationErrors.AddRange(GetValidationErrors(type, column, validationGroup));
                }
                OnPropertyValidated(this, new EntityValidationEventArgs(this, helper, propertyName, validationGroup));
            }

            return validationErrors;
        }
		
		/// <summary>
		/// Flags the object to be deleted. The delete does not occur immediately,
		/// but when the save method is called or a parent object is saved
		/// </summary>
        public void SetDeleted(bool isDeleted)
		{
			this.IsDeleted = isDeleted;	
		}
		
		/// <summary>
        /// Delete the data associated with a custom business object from the database
        /// </summary>
        public virtual void Delete() 
		{
			using (SqlHelper helper = new SqlHelper())
			{
				try 
				{
					helper.BeginTransaction();
					this.Delete(helper);
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
        /// Roll back to the Loaded state
        /// </summary>
        public virtual void RollBack()
        {
            if (_originalItem != null)
            {
                Replace(_originalItem);
            }
            else
            {
                //We get the array of fields for the new type instance.
                FieldInfo[] fields = this.GetType().GetFields(BINDINGS_PRIVATE_INSTANCES);

                foreach (FieldInfo fi in fields)
                {
                    if (fi.FieldType.IsGenericType)
                    {
                        System.Type genericType = fi.FieldType.GetGenericTypeDefinition();

                        if (genericType.Equals(typeof(EntityList<>)))
                        {
                            System.Collections.IList entityList = fi.GetValue(this) as System.Collections.IList;

                            if (entityList != null)
                            {
                                foreach (EntityBase entity in entityList)
                                {
                                    entity.RollBack();
                                }
                            }
                        }
                    }
					else if (fi.FieldType.IsSubclassOf(typeof(EntityBase)))
					{
						// then replace the entity using it's own .Replace method if it is not null
						EntityBase entityBase = fi.GetValue(this) as EntityBase;
						if (entityBase != null)
						{
							entityBase.RollBack();
						}
					}
                }
            }
        }
		
		/// <summary>
        /// Persists a Customer object to the data store. This is 
        /// internal, and is used for recursive saves within a transaction.
        /// </summary>
        /// <param name="helper">The data connection helper</param>
        public override void Save(SqlHelper helper)
        {
            EntityCancelEventArgs e = new EntityCancelEventArgs(this, helper);

            bool isSavingEntity = false;

			EnsureParentProperties();
			
			OnSaveStarting(e);

            if (!e.Cancel)
            {
				if (IsNew || IsDirty || IsDeleted)
				{
					isSavingEntity = true;
	
					OnSaving(e);
					
					this.Validate(helper);
					if ((!this.IsDeleted) && (this.ValidationErrors.Count > 0))
					{
						throw new EntityException("Validation failed.", this, helper);
					}
	
					if (!e.Cancel)
					{
						if (this.IsDeleted)
						{
							this.Delete(helper);
							return;
						}
	
						if (this.IsDirty)
						{
							if (this.IsNew)
							{
								this.Insert(helper);
							}
							else
							{
								this.Update(helper);
							}
						}
					}
				}
	
				if (!e.Cancel)
				{
					UpdateChildren(helper, UpdateType.Save);
	
					if (isSavingEntity)
					{
						OnSaved(new EntityEventArgs(this, helper));
					}
	
				}
				
				OnSaveFinished(new EntityEventArgs(this, helper));
			}
        }
		
		/// <summary>
        /// Replaces data of an entity with that of the specified entity, using the public properties. Triggers PropertyChanged events. Useful, for instance, for popping up a modal dialog and then applying gathered information to the original entity via the public interface.
        /// </summary>
        /// <param name="entity">The entity from which the data will be retrieved</param>
        public virtual void Merge(EntityBase entity)
        {
            //We get the array of fields for the new type instance.
            PropertyInfo[] properties = this.GetType().GetProperties(BINDINGS_PUBLIC_INSTANCES);

            foreach (PropertyInfo pi in properties)
            {
                ReplaceForPropertyInfo(pi, entity);
            }
			OnMerged(this, EventArgs.Empty);
        }

		/// <summary>
		/// Replaces the core data of an entity with that of the specified entity via the private members. Does not trigger PropertyChanged events.
        /// </summary>
        /// <param name="entity">The entity from which the data will be retrieved</param>
        public virtual void Replace(EntityBase entity)
        {
            //We get the array of fields for the new type instance.
            FieldInfo[] fields = this.GetType().GetFields(BINDINGS_PRIVATE_INSTANCES);

            foreach (FieldInfo fi in fields)
            {
                ReplaceForFieldInfo(fi, entity);
            }

            IsNew = entity.IsNew;
            IsDeleted = entity.IsDeleted;

            // If dirty is false, _original item will be null after this
            IsDirty = entity.IsDirty;
			
			OnReplaced(this, EventArgs.Empty);
        }
        
        /// <summary>
        /// Replaces the DB data of an entity with that of the specified entity via the private members. Does not trigger PropertyChanged events.
        /// </summary>
        /// <param name="entity">The entity from which the data will be retrieved</param>
        public virtual void CopyData(EntityBase entity)
        {
            //We get the array of fields for the new type instance.
            FieldInfo[] fields = this.GetType().GetFields(BINDINGS_PRIVATE_INSTANCES);

            foreach (FieldInfo fi in fields)
            {
                ReplaceForFieldInfo(fi, entity);
            }
        }

        /// <summary>
        /// Refreshes the entity with data from the data source. Lazily loaded entity objects and entity list objects will be preserved (ie. they will not be replaced with new objects so that references to them are retained, such as bound data controls).
        /// </summary>
		public abstract void Refresh();
		
		#endregion
		
		#region Non-Public Methods
		/// <summary>
		/// Validates an entity.
		/// </summary>
        private void Validate(SqlHelper helper)
		{
			this.ValidationErrors.Clear();
			this.ValidationErrors = GetValidationErrors(helper);
		}
		
		/// <summary>
        /// Gets the validation errors for a column
        /// </summary>
        /// <param name="type">The type of the entity</param>
        /// <param name="column">The column information</param>
        /// <param name="validationGroup">The validation group to validate.</param>
        /// <returns>A list of any validation messages for the property</returns>
		protected virtual List<ValidationError> GetValidationErrors(System.Type type, ColumnInfo column, string validationGroup)
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            System.Reflection.PropertyInfo property = GetDatabaseColumnPropertyInfo(type, column.ColumnName);

            if (String.IsNullOrEmpty(validationGroup) || validationGroup == ValidationGroup.Required)
            {
                if (!column.IsNullable && !column.IsAutoNumber)
                {
                    if (property.GetValue(this, null) == null)
                    {
                        validationErrors.Add(new ValidationError(String.Format("{0} is required.", column.FriendlyName), this, column.ColumnName, ValidationGroup.Required));
                    }
                }
            }

            if (IsStringDataType(column.DataType) && (String.IsNullOrEmpty(validationGroup) || validationGroup == ValidationGroup.Length))
            {
                // Check for maximum length
                object propertyValue = property.GetValue(this, null);
                if (propertyValue != null && propertyValue.ToString().Length > column.MaximumLength)
                {
                    validationErrors.Add(new ValidationError(String.Format("{0} must be less than {1} characters.", column.FriendlyName, column.MaximumLength), this, column.ColumnName));
                }
            }
			
            return validationErrors;
        }

        /// <summary>
        /// Gets validation messages for children objects.
        /// </summary>
        /// <returns>A collection of validation messages for any filled in children properties</returns>
        protected List<ValidationError> GetChildrenValidationErrors()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            Dictionary<string, PropertyInfo> properties = GetPropertyList(ColumnType.SaveableChildEntities);

            foreach (string key in properties.Keys)
            {
                object currentValue = GetPropertyValue(this, properties[key]);

                if (currentValue != null)
                {
                    System.Reflection.MethodInfo methodInfo = EntityBase.GetValidationMethod(currentValue);

                    if (methodInfo != null)
                    {
                        System.Reflection.MethodBase methodBase = (System.Reflection.MethodBase)methodInfo;

                        validationErrors.AddRange(methodBase.Invoke(currentValue, null) as List<ValidationError>);
                    }
                }
            }

            return validationErrors;
        }

        /// <summary>
        ///  Determines if the sql type is a string
        /// </summary>
        /// <param name="dataType">the datatype to check</param>
        /// <returns>true if string, false otherwise</returns>
        protected bool IsStringDataType(string dataType)
        {
            return (dataType == "nchar" || dataType == "nvarchar" || dataType == "char" || dataType == "varchar");
        }
		
		[Obsolete("The RollBack(EntityBase entityBase) method has been deprecated, and will be removed in a future release. Please use the Replace(EntityBase entityBase) method instead.")]
		internal void RollBack(EntityBase entityBase)
		{
			Replace(entityBase);
		}

        private void SetFieldValueAndTriggerPropertyChangedEvent(object targetObject, FieldInfo fieldInfo, object sourceObjectValue)
        {
            object targetObjectValue = fieldInfo.GetValue(targetObject);
            if (!((targetObjectValue == null) && (sourceObjectValue == null)))
            {
                if (
                    ((targetObjectValue == null) && (sourceObjectValue != null))
                    || (!targetObjectValue.Equals(sourceObjectValue))
                    )
                {
                    fieldInfo.SetValue(targetObject, sourceObjectValue);
                    // if field is a property backer, then trigger property changed event.
                    if (fieldInfo.Name.IndexOf("_") == 0)
                    {
                        string propertyName = fieldInfo.Name.Substring(1, 1).ToUpper() + fieldInfo.Name.Substring(2);
                        PropertyInfo propertyInfo = this.GetType().GetProperty(propertyName);
                        if (propertyInfo != null)
                        {
                            this.OnPropertyChanged(propertyInfo.Name);
                        }
                    }
                }
            }
        }
		
		/// <summary>
		/// Replaces core data from the specified field (FieldInfo) in entity.
		/// </summary>
        protected void ReplaceForFieldInfo(FieldInfo fi, EntityBase entity)
        {
			// if the field is a NuSoft Framework entity or entityList, then we need to take care to
			// preserve the currently existing entity and entityList instantiated objects as the consumer may
			// have reference to them (ie. data bound to a presentation control)
			if ((fi.FieldType.IsGenericType) && (fi.FieldType.GetGenericTypeDefinition().Equals(typeof(EntityList<>))))
            {
                System.Collections.IList entityListSource = fi.GetValue(entity) as System.Collections.IList;
                System.Collections.IList entityListTarget = fi.GetValue(this) as System.Collections.IList;

                if ((entityListSource == null) && (entityListTarget != null))
                {
                    // un-lazy load the private member of the source so that the entityList items are visible... after loading the items, then the 
                    // "if ((entityList != null) && (entityListSource != null))" clause will be hit below, effectively adding the items to the already-
                    // existing entityList instantiated object.
                    string memberName = fi.Name;
                    if (memberName.IndexOf('_') == 0)
                    {
                        string propertyName = memberName.Substring(1, 1).ToUpper() + memberName.Substring(2);
                        PropertyInfo propertyInfo = this.GetType().GetProperty(propertyName);
                        if (propertyInfo != null)
                        {
                            // we're not going to do anything with entityListForProperty... we just access it get the the entityList lazily-loaded.
                            System.Collections.IList entityListForProperty = propertyInfo.GetValue(entity, null) as System.Collections.IList;
                            entityListSource = fi.GetValue(entity) as System.Collections.IList;
                            entityListTarget = fi.GetValue(this) as System.Collections.IList;
                        }
                    }
                }
                if ((entityListTarget != null) && (entityListSource != null))
                {
					// todo:mjj move this section to entityList.Replace(entityList)
                    for (int i = entityListTarget.Count - 1; i >= 0; i--)
                    {
                        EntityBase entityTarget = (EntityBase)entityListTarget[i];
                        EntityBase entitySource = (EntityBase)((ISearchable)entityListSource).GetEntityById(entityTarget.UniqueIdentifier);
                        if (entityTarget.IsDeleted)
                        {
                            entityListTarget.Remove(entityTarget);
                        }
                        else if (entitySource != null)
                        {
                            entityTarget.Replace(entitySource);
                        }
                        else
                        {
                            entityListTarget.Remove(entityTarget);
                        }
                    }
                    foreach (EntityBase entitySource in entityListSource)
                    {
                        EntityBase entityTarget = (EntityBase)((ISearchable)entityListTarget).GetEntityById(entitySource.UniqueIdentifier);
                        if (entityTarget == null)
                        {
                            entityListTarget.Add(entitySource);
                        }
                    }
                }
                else if ((entityListSource != null) && (entityListTarget == null))
                {
                    SetFieldValueAndTriggerPropertyChangedEvent(this, fi, ((ICloneable)fi.GetValue(entity)).Clone());
                }
                else
                {
                    SetFieldValueAndTriggerPropertyChangedEvent(this, fi, fi.GetValue(entity));
            	}
            }
			else if (fi.FieldType.IsSubclassOf(typeof(EntityBase)))
			{
				EntityBase entityBaseTarget = fi.GetValue(this) as EntityBase;
                EntityBase entityBaseSource = fi.GetValue(entity) as EntityBase;
                if ((entityBaseSource == null) && (entityBaseTarget != null))
                {
                    // provoke source entity's corresponding property to get it lazily loaded
                    string memberName = fi.Name;
                    if (memberName.IndexOf('_') == 0)
                    {
                        string propertyName = memberName.Substring(1, 1).ToUpper() + memberName.Substring(2);
                        PropertyInfo propertyInfo = this.GetType().GetProperty(propertyName);
                        if (propertyInfo != null)
                        {
                            // we're not going to do anything with entityBase... we just access it to get it lazily-loaded.
                            EntityBase entityBase = propertyInfo.GetValue(entity, null) as EntityBase;
                            entityBaseSource = fi.GetValue(entity) as EntityBase;
                        }
                    }
                }
                if ((entityBaseTarget != null) && (entityBaseSource != null))
                {
                    if (entityBaseTarget.UniqueIdentifier == entityBaseSource.UniqueIdentifier)
				    {
					    entityBaseTarget.Replace(entityBaseSource);					
				    }
				    else
                    {
                        SetFieldValueAndTriggerPropertyChangedEvent(this, fi, fi.GetValue(entity));
                    }
                }
                else if ((entityBaseSource != null) && (entityBaseTarget == null))
                {
                    SetFieldValueAndTriggerPropertyChangedEvent(this, fi, ((ICloneable)fi.GetValue(entity)).Clone());
                }
                else
                {
                    SetFieldValueAndTriggerPropertyChangedEvent(this, fi, fi.GetValue(entity));
                }
            }
            else
            {
                SetFieldValueAndTriggerPropertyChangedEvent(this, fi, fi.GetValue(entity));
            }
        }

		/// <summary>
		/// Replaces data from the specified property (PropertyInfo) in entity.
		/// </summary>
        protected void ReplaceForPropertyInfo(PropertyInfo propertyInfo, EntityBase entity)
        {
            // If the setter method of the property is not public, then don't process it. This will exclude ID fields, for instance.
            if (propertyInfo.GetSetMethod(false) != null)
            {
				// if the property is a NuSoft Framework entity or entityList, then we need to take care to
				// preserve the currently existing entity and entityList instantiated objects as the consumer may
				// have reference to them (ie. data bound to a presentation control)
				
				// if the property is an entityList...
				if ((propertyInfo.PropertyType.IsGenericType) && (propertyInfo.PropertyType.GetGenericTypeDefinition().Equals(typeof(EntityList<>))))
				{
					// Get the source object's private member that corresponds to the property (ie. the property backer).
					// If it's value is not null, then let's get the collection's members and merge them into the target's collection.
					// A null collection for the source does not mean that the target should then be null; it only means that the
					// source's collection was never lazily loaded.
					string propertyName = propertyInfo.Name;
					string memberName = "_" + propertyName.Substring(0, 1).ToLower() + propertyName.Substring(1);
					FieldInfo fieldInfo = this.GetType().GetField(memberName, BINDINGS_PRIVATE_INSTANCES);
					if ((fieldInfo != null) && ((fieldInfo.GetValue(entity) as System.Collections.IList) != null))
					{
						// By virture of unique identifer...
						// - Exists in source collection, and exists in target collection, then merge to target collection
						// - Exists in source, but not is target, add to target.
						// - Doesn't exist in source, and doesn't exist in target, do nothing.
						// - Doesn't exist in source, but does in target, delete/remove from source.
						System.Collections.IList entityListSource = propertyInfo.GetValue(entity, null) as System.Collections.IList;
						System.Collections.IList entityListTarget = propertyInfo.GetValue(this, null) as System.Collections.IList;
	
						for (int i = entityListTarget.Count - 1; i >= 0; i--)
						{
							EntityBase entityTarget = (EntityBase)entityListTarget[i];
							if (!entityTarget.IsDeleted)
							{
								EntityBase entitySource = (EntityBase)((ISearchable)entityListSource).GetEntityById(entityTarget.UniqueIdentifier);
								if (entitySource != null)
								{
									entityTarget.Merge(entitySource);
								}
								else
								{
									entityListTarget.Remove(entityTarget);
								}
							}
						}
						foreach (EntityBase entitySource in entityListSource)
						{
							EntityBase entityTarget = (EntityBase)((ISearchable)entityListTarget).GetEntityById(entitySource.UniqueIdentifier);
							if (entityTarget == null)
							{
								entityListTarget.Add(entitySource);
							} 
							else if (entitySource.IsDeleted)
							{
								entityTarget.SetDeleted(true);
							}
						}
					}
				}
				// else if the property is an entity...
				else if (propertyInfo.PropertyType.IsSubclassOf(typeof(EntityBase)))
				{
					EntityBase entityBaseTarget = propertyInfo.GetValue(this, null) as EntityBase;
					EntityBase entityBaseSource = propertyInfo.GetValue(entity, null) as EntityBase;
					if ((entityBaseTarget != null) && (entityBaseSource != null))
					{
						if (entityBaseTarget.UniqueIdentifier == entityBaseSource.UniqueIdentifier)
						{
							entityBaseTarget.Replace(entityBaseSource);					
						}
						else if (propertyInfo.CanWrite)
						{
							propertyInfo.SetValue(this, propertyInfo.GetValue(entity, null), null);
						}
					}
					else if ((entityBaseSource != null) && (entityBaseTarget == null))
					{
						if (propertyInfo.CanWrite)
						{
							propertyInfo.SetValue(this, ((ICloneable)propertyInfo.GetValue(entity, null)).Clone(), null);
						}
					}
					else
					{
						if (propertyInfo.CanWrite)
						{
							propertyInfo.SetValue(this, propertyInfo.GetValue(entity, null), null);
						}
					}
				}
				else	// just copy the value or object
				{
					if (propertyInfo.CanWrite)
					{
						propertyInfo.SetValue(this, propertyInfo.GetValue(entity, null), null);
					}
				}
			}
        }

        /// <summary>
        /// Inserts the data associated with a custom business object into the database. Accepts an existing SqlHelper object as input
        /// to allow the Insert to participate in a transaction.
        /// </summary>
        /// <param name="sqlHelper">The current database connection</param>
        protected void Insert(SqlHelper helper)
        {
            EntityCancelEventArgs e = new EntityCancelEventArgs(this, helper);
            OnInserting(e);

            if (!e.Cancel)
            {
				string commandText = this.InsertSqlStatement;
				
                System.Collections.Generic.List<SqlParameter> parameters = GetParameterList(ColumnType.DatabaseColumnNoIdentity);

                using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
                	if (reader.Read())
                	{
                    	this.Initialize(reader);
                	}
                }

                OnInserted(new EntityEventArgs(this, helper));
            }
        }

        /// <summary>
        /// Deletes a Customer object from the data store. This is 
        /// is used for deletes within a transaction.
        /// </summary>
        /// <param name="helper">The data connection helper</param>
        public void Delete(SqlHelper helper)
        {
            EntityCancelEventArgs e = new EntityCancelEventArgs(this, helper);
            OnDeleting(e);

            if (!e.Cancel)
            {
				string commandText = this.DeleteSqlStatement;
				
                System.Collections.Generic.List<SqlParameter> parameters = GetParameterList(ColumnType.PrimaryKeyColumn);

                helper.Execute(commandText, CommandType.Text, parameters);

                OnDeleted(new EntityEventArgs(this, helper));
            }
        }

        ///// <summary>
        ///// Updates a Customer object to the data store. This is 
        ///// protected, and is used for updates within a transaction.
        ///// </summary>
        ///// <param name="helper">The data connection helper</param>
        protected void Update(SqlHelper helper)
        {
            EntityCancelEventArgs e = new EntityCancelEventArgs(this, helper);
            OnUpdating(e);

            if (!e.Cancel)
            {
				string commandText = this.UpdateSqlStatement;

                System.Collections.Generic.List<SqlParameter> parameters = GetParameterList(ColumnType.DatabaseColumn);

                using (IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters))
				{
					if (reader.Read())
					{
						this.Initialize(reader);
					}
                }

                OnUpdated(new EntityEventArgs(this, helper));
            }
        }
		#endregion
		
		#region Non-Public Static Properties
		
        /// <summary>
        /// Initialize New 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal static T InitializeNew<T>() where T : EntityBase
        {
            T entity = EntityBaseReadOnly.GetEntityInstance<T>();

            System.Type entityType = entity.GetType();

            List<ColumnInfo> defaultValues = ColumnInfo.GetColumnInfoDefaultValues(entityType);

            foreach (ColumnInfo column in defaultValues)
            {
                PropertyInfo propertyInfo = GetDatabaseColumnPropertyInfo(entityType, column.ColumnName);

                if (propertyInfo != null)
                {
                    SetPropertyValueIfNotNull(entity, propertyInfo, column.Value);
                }
            }

            entity.IsNew = true;
            entity.IsDirty = true;

            return entity;
        }
		
        #endregion
		
		#region Non-Public Static Methods and Constants
        /// <summary>
        /// Search the Entity for a get validation method 
        /// </summary>
        /// <param name="list">List Entity</param>
        /// <returns>MethodInfo of found save method</returns>
        private static System.Reflection.MethodInfo GetValidationMethod(object list)
        {
            System.Type listType = list.GetType();

            System.Reflection.MethodInfo[] methodInfoList = listType.GetMethods(BINDINGS_ALL_INCLUDING_BASE);

            System.Reflection.MethodInfo methodInfo = null;

            foreach (System.Reflection.MethodInfo currentMethod in methodInfoList)
            {
                System.Reflection.ParameterInfo[] parameterList = currentMethod.GetParameters();

                if (parameterList.Length == 0 && currentMethod.Name == "GetValidationErrors")
                {
                    methodInfo = currentMethod;
                }
            }

            return methodInfo;
        }
        #endregion
    }
}
