﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Read List of entities
    /// </summary>
    /// <typeparam name="T">EntityBaseReadOnly type</typeparam>
    [Serializable()]
    public partial class EntityListReadOnly<T> : EntityListBase<T>, ISearchable, ICloneable where T : EntityBaseReadOnly
    {
        private EntityBaseReadOnly parent;
		/// <summary>
        /// Parent Entity
        /// </summary>
        internal virtual EntityBaseReadOnly Parent
        {
            get
            {
                return this.parent;
            }
			set { }
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="propertyName">Sort Property</param>
        /// <param name="sortType">Sort Type (Ascending / Descending)</param>
        public void Sort(string propertyName, SortType sortType)
        {
            EntityComparer<T> comparer = new EntityComparer<T>(propertyName, sortType);

            try
            {
                this.Sort(comparer);
            }
            catch (Exception ex)
            {
                throw new Exception("The requested sort property:" + propertyName + " does not exist.", ex);
            }
        }

        /// <summary>
        /// Sort 
        /// </summary>
        /// <param name="propertyNames">Property Name array</param>
        /// <param name="sortType">Sort Type (Ascending / Descending)</param>
        public void Sort(string[] propertyNames, SortType sortType)
        {
            EntityComparer<T> comparer = new EntityComparer<T>(propertyNames, sortType);
            this.Sort(comparer);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="propertyName">Sort Property</param>
        public void Sort(string propertyName)
        {
            EntityComparer<T> comparer = new EntityComparer<T>(propertyName);
            this.Sort(comparer);
        }

        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="propertyNames">Sort Property List</param>
        public void Sort(string[] propertyNames)
        {
            EntityComparer<T> comparer = new EntityComparer<T>(propertyNames);
            this.Sort(comparer);
        }

        internal void Sort(EntityComparer<T> comparer)
        {
            this.Sort(0, this.Count, comparer);
        }

        internal void Sort(int index, int count, EntityComparer<T> comparer)
        {
            if ((index < 0) || (count < 0))
            {
                //ThrowHelper.ThrowArgumentOutOfRangeException(, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
                throw new System.ArgumentOutOfRangeException();
            }
            //Array.Sort<T>(this.ToArray(), index, count, comparer);
            ((List<T>)this.Items).Sort(index, count, comparer);
        }

        /// <summary>
        /// Hydration method
        /// </summary>
        /// <param name="reader">Reader</param>
        internal virtual void Initialize(System.Data.IDataReader reader)
        {
            while (reader.Read())
            {
                T entity = EntityBaseReadOnly.GetEntityInstance<T>();
                entity.Initialize(reader);
                base.Add(entity);
            }
        }

        /// <summary>
        /// Hydration method
        /// </summary>
		/// <param name="parent">Parent Entity</param>
        /// <param name="reader">Reader</param>
        internal virtual void Initialize(System.Collections.IList parent, System.Data.IDataReader reader) 
        {
            while (reader.Read())
            {
                T entity = EntityBaseReadOnly.GetEntityInstance<T>();
                entity.Initialize(reader);
                entity.Parent = parent;
                base.Add(entity);
            }
        }

        /// <summary>
        /// Hydration method
        /// </summary>
		/// <param name="parent">Parent Entity</param>
        /// <param name="view">View</param>
        internal virtual void Initialize(System.Collections.IList parent, System.Data.DataView view)
        {
            foreach (DataRowView rowView in view)
            {
                T entity = EntityBaseReadOnly.GetEntityInstance<T>();
                entity.Initialize(rowView);
                entity.Parent = parent;
                base.Add(entity);
            }
        }

        /// <summary>
        /// Hydration method
        /// </summary>
		/// <param name="parent">Parent Entity</param>
        /// <param name="table">Table</param>
        internal virtual void Initialize(System.Collections.IList parent, System.Data.DataTable table)
        {
            Initialize(parent, table.DefaultView);
        }
		
        /// <summary>
        /// Hydration method
        /// </summary>		
        /// <param name="view">View</param>
        internal virtual void Initialize(System.Data.DataView view)
        {
            foreach (DataRowView rowView in view)
            {
                T entity = EntityBaseReadOnly.GetEntityInstance<T>();
                entity.Initialize(rowView);
                base.Add(entity);
            }
        }

        /// <summary>
        /// Hydration Method
        /// </summary>
        /// <param name="table">Data table</param>
        internal virtual void Initialize(System.Data.DataTable table)
        {
            Initialize(table.DefaultView);
        }

		/// <summary>
        /// Get Entity by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity</returns>
        public EntityBaseReadOnly GetEntityById(string uniqueIdentifer)
        {
            EntityBaseReadOnly returnValue = null;

            foreach (T tEntity in this)
            {
                if (tEntity is EntityBaseReadOnly)
                {
                    EntityBaseReadOnly entity = tEntity as EntityBaseReadOnly;

                    if (entity.UniqueIdentifier == uniqueIdentifer)
                    {
                        returnValue = entity;
                        break;
                    }
                }
            }

            return returnValue;
        }

        public int CountNonDeleted
        {
            get
            {
                int returnValue = 0;
                foreach (T entity in this.Items)
                {
                    if (!entity.IsDeleted)
                    {
                        returnValue++;
                    }
                }
                return returnValue;

            }
        }
		
		public new EntityListReadOnly<T> FindAll(Predicate<T> match)
		{
			return base.FindAll(new EntityListReadOnly<T>() as EntityListBase<T>, match) as EntityListReadOnly<T>;	
		}

        /// <summary>
        /// Find Entity
        /// </summary>
        /// <param name="entityFinder"></param>
        /// <returns></returns>
        public T FindEntity(EntityFinder entityFinder)
        {
			T returnValue = null;
			EntityListReadOnly<T> entityListReadOnly = this.FindEntities(entityFinder);
			if (entityListReadOnly.Count > 0)
			{
				returnValue = entityListReadOnly[0];
			}
			return returnValue;
        }

        /// <summary>
        /// Find Entity
        /// </summary>
        /// <param name="entityFinder"></param>
        /// <returns></returns>
        public EntityListReadOnly<T> FindEntities(EntityFinder entityFinder)
        {
            EntityListReadOnly<T> returnValue = new EntityListReadOnly<T>();
            this.FindAll(returnValue, entityFinder, PredicateForEntityFinder);
            return returnValue;
        }

        private bool PredicateForEntityFinder(T obj, object criteria)
        {
            bool returnValue = true;
            EntityFinder entityFinder = criteria as EntityFinder;
            if (entityFinder == null)
            {
                throw new ArgumentNullException();
            }

            System.Type type = typeof(T);

            for (int i = 0; i < entityFinder.Count; i++ )
            {
                System.Reflection.PropertyInfo property = type.GetProperty(entityFinder.GetKey(i), BINDINGS_ALL_INCLUDING_BASE);
                if ((property == null) || (!entityFinder.GetValue(i).Equals(property.GetValue(obj, null))))
                    {
                        returnValue = false;
                        break;
                    }
            }
            return returnValue;
        }
		
        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the 
        /// first occurrence within the entire list.  (The search is by primary key
        /// by default)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public new int IndexOf(T item)
        {
            return IndexOf(item, false);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the 
        /// first occurrence within the entire list
        /// </summary>
        /// <param name="item"></param>
        /// <param name="byReference">If true, the search is performed for object reference.  If false by primary key(s)</param>
        /// <returns></returns>
        public int IndexOf(T item, bool byReference)
        {
            int returnValue = -1;

            if (byReference)
            {
                returnValue = base.IndexOf(item);
            }
            else
            {
                T entity = GetEntityById(item.UniqueIdentifier) as T;

                if (entity != null)
                {
                    returnValue = base.IndexOf(entity);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the list (The search is performed
        /// by primary key by default)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public new bool Remove(T item)
        {
            return Remove(item, false);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the list
        /// </summary>
        /// <param name="item"></param>
        /// <param name="byReference">If true, the remove is performed based on object reference, otherwise by primary key </param>
        /// <returns></returns>
        public bool Remove(T item, bool byReference)
        {
            bool returnValue = false;

            if (byReference)
            {
                returnValue = base.Remove(item);
            }
            else
            {
                T entity = GetEntityById(item.UniqueIdentifier) as T;

                if (entity != null)
                {
                    returnValue = base.Remove(entity);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Determines whether an element is in the list (The search is performed by
        /// primary key by default)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public new bool Contains(T item)
        {
            return Contains(item, false);
        }

        /// <summary>
        /// Determines whether an element is in the list
        /// </summary>
        /// <param name="item"></param>
        /// <param name="byReference">If true, the search is performed by object reference, otherwise by primary key</param>
        /// <returns></returns>
        public bool Contains(T item, bool byReference)
        {
            bool returnValue = false;

            if (byReference)
            {
                returnValue = base.Contains(item);
            }
            else
            {
                T entity = GetEntityById(item.UniqueIdentifier) as T;

                if (entity != null)
                {
                    returnValue = base.Contains(entity);
                }
            }

            return returnValue;
        }


		/// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="reader">Reader</param>
        internal EntityListReadOnly(System.Data.IDataReader reader)
        {
            this.Initialize(reader);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="table">Table</param>
        internal EntityListReadOnly(System.Data.DataTable table) 
        {
            this.Initialize(table);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent Entity</param>
        /// <param name="table">Data Table</param>
        internal EntityListReadOnly(EntityBaseReadOnly parent, System.Data.DataTable table) : this(table)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent Entity</param>
        /// <param name="reader">Reader</param>
        internal EntityListReadOnly(EntityBaseReadOnly parent, System.Data.IDataReader reader) : this(reader)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent Entity</param>
        internal EntityListReadOnly(EntityBaseReadOnly parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Constructor (default)
        /// </summary>
        internal EntityListReadOnly() { } 

        const BindingFlags BINDINGS_ALL_INCLUDING_BASE = BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

        #region ICloneable Members

		/// <summary>
		/// Clone an entity list by creating a new entity list, and cloning all list members.
		/// </summary>
        public virtual object Clone()
        {
            EntityListReadOnly<T> newEntityList = new EntityListReadOnly<T>();

            foreach (ICloneable entity in this)
            {
                newEntityList.Add((T)entity.Clone());
            }

            return newEntityList;
        }

        #endregion

	}
}
