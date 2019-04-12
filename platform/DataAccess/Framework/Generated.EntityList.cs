﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Read / Write List of entities
    /// </summary>
    /// <typeparam name="T">EntityBaseReadOnly type</typeparam>
    [Serializable()]
    public partial class EntityList<T> : EntityListReadOnly<T>, ISavable where T : EntityBaseReadOnly
    {
    	private EntityBaseReadOnly _parent;
		/// <summary>
        /// Parent Entity
        /// </summary>
        internal override EntityBaseReadOnly Parent
        {
            get
            {
                return this._parent;
            }
            set
            {
                _parent = value;
            }
        }

        /// <summary>
        /// Check to see if any of the child entities are dirty
        /// </summary>
        public bool IsSaveRequired
        {
            get
            {
                bool returnValue = false;

                foreach (EntityBaseReadOnly entity in this)
                {
                    returnValue = entity.IsSaveRequired;

                    if (returnValue) break;
                }

                return returnValue;
            }
        }
		
        /// <summary>
        /// Replace the entity if found in list
        /// </summary>
        /// <param name="entity"></param>
        public void Replace(T entity)
        {
            int patientIndex = base.IndexOf(entity);

            if (patientIndex != -1)
            {
                base.RemoveAt(patientIndex);
                base.Insert(patientIndex, entity);
            }
        }
		
		/// <summary>
        /// Gets validation errors for all entities in the list
        /// </summary>
        /// <returns>A list of validation errors for the entities</returns>
        public List<ValidationError> GetValidationErrors()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();
            
            foreach(T entity in Items)
            {
                if(entity is EntityBase)
                {
                    EntityBase entityBase = entity as EntityBase;
                    if (!entityBase.IsDeleted)
                    {
                        validationErrors.AddRange(entityBase.GetValidationErrors());
                    }
                }
            }

            return validationErrors;
        }

        /// <summary>
        /// Save List
        /// </summary>
        /// <param name="helper">Sql Helper</param>
        virtual public void Save(SqlHelper helper)
        {
            try
            {
                bool isDeletedItem = false;

                foreach (T entity in Items)
                {
                    if (entity.IsDeleted)
                    {
                        isDeletedItem = true;
                    }

                    EntityBaseReadOnly currentEntity = entity as EntityBaseReadOnly;
                    currentEntity.Save(helper);

                }

                if (isDeletedItem)
                {
                    for (int i = Items.Count - 1; i >= 0; i--)
                    {
                        if (Items[i].IsDeleted)
                        {
                            Items.RemoveAt(i);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Save List
        /// </summary>
        virtual public void Save()
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
        /// Deletes all members of the collection from the collection and from the data source.
        /// </summary>
        virtual public void DeleteAll()
        {
			using (SqlHelper helper = new SqlHelper())
			{
				try 
				{
					helper.BeginTransaction();
					for (int i = this.Count - 1; i >= 0; i--)
					{
						EntityBase entityBase = this[i] as EntityBase;
						if (entityBase != null)
						{
							entityBase.Delete(helper);
						}
					}
					this.ClearItems();
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
        /// Set all members of the collection as deleted or not delete (ie. IsDirty gets set to true or false).
        /// </summary>
        virtual public void SetAllDeleted(bool isDeleted)
        {
			foreach(T entity in this)
			{
                EntityBase entityBase = entity as EntityBase;
                if (entityBase != null)
                {
                    entityBase.SetDeleted(isDeleted);
                }
			}
        }
		
		public new EntityList<T> FindAll(Predicate<T> match)
		{
			return base.FindAll(new EntityList<T>() as EntityListBase<T>, match) as EntityList<T>;
		}

		/// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="reader">Reader</param>
        internal EntityList(System.Data.IDataReader reader) : base(reader)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="table">Table</param>
        internal EntityList(System.Data.DataTable table) : base(table)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent Entity</param>
        /// <param name="table">Data Table</param>
        internal EntityList(EntityBaseReadOnly parent, System.Data.DataTable table) : base(parent, table)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent Entity</param>
        /// <param name="reader">Reader</param>
        internal EntityList(EntityBaseReadOnly parent, System.Data.IDataReader reader) : base(parent, reader)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent Entity</param>
        internal EntityList(EntityBaseReadOnly parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructor (default)
        /// </summary>
        public EntityList()  : base() { }

        ///// <summary>
        ///// Clone an entity list by creating a new entity list, and cloning all list members.
        ///// </summary>
        public override object Clone()
        {
            EntityList<T> newEntityList = new EntityList<T>();

            foreach (ICloneable entity in this)
            {
                newEntityList.Add((T)entity.Clone());
            }

            return newEntityList;
        }


	}
}