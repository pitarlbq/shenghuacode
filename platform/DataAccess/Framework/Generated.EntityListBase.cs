﻿
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Read / Write List of objects
    /// </summary>
    /// <typeparam name="T">object type</typeparam>
    [Serializable()]
    public partial class EntityListBase<T> : System.ComponentModel.BindingList<T>
    {
        internal void Sort(IComparer<T> comparer)
        {
            ((List<T>)this.Items).Sort(comparer);
        }
		
		public EntityListBase<T> FindAll(Predicate<T> match)
		{
			return FindAll(new EntityListBase<T>(), match);
		}

        protected EntityListBase<T> FindAll(EntityListBase<T> entityListBase, Predicate<T> match)
        {
            if (match == null)
            {
                //ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
                throw new System.ArgumentNullException();
            }
            for (int num1 = 0; num1 < this.Count; num1++)
            {
                if (match(this.Items[num1]))
                {
                    entityListBase.Add(this.Items[num1]);
                }
            }
            return entityListBase;
        }

        public delegate bool PredicateWithCriteria<TInput, TCriteria>(TInput obj, TCriteria criteria);

        public EntityListBase<T> FindAll(EntityListBase<T> entityListBase, object criteria, PredicateWithCriteria<T, object> match)
        {
            if (match == null)
            {
                throw new System.ArgumentNullException();
            }
            for (int num1 = 0; num1 < this.Count; num1++)
            {
                if (match(this.Items[num1], criteria))
                {
                    entityListBase.Add(this.Items[num1]);
                }
            }
            return entityListBase;
        }

        public T[] ToArray()
        {
            T[] localArray1 = new T[this.Count];
            this.CopyTo(localArray1, 0);
            return localArray1;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            this.InsertRange(this.Count, collection);
        }


        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if (collection == null)
            {
                //ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
                throw new System.ArgumentNullException();
            }
            if (index > this.Count)
            {
                //ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
                throw new System.ArgumentOutOfRangeException();
            }
            using (IEnumerator<T> enumerator1 = collection.GetEnumerator())
            {
                while (enumerator1.MoveNext())
                {
                    this.Insert(index++, enumerator1.Current);
                }
            }
        }

        public EntityListBase<TOutput> ConvertAll<TOutput>(EntityListBase<TOutput> entityListBase, Converter<T, TOutput> converter)
        {
            return ConvertAll(entityListBase, converter, false);
        }

        public EntityListBase<TOutput> ConvertAll<TOutput>(EntityListBase<TOutput> entityListBase, Converter<T, TOutput> converter, bool suspendListChangedEvent)
        {
            if (converter == null)
            {
                throw new ArgumentNullException();
            }
            for (int num1 = 0; num1 < this.Count; num1++)
            {
                if (suspendListChangedEvent)
                {
                    entityListBase.Load(converter(this[num1]));
                }
                else
                {
                    entityListBase.Add(converter(this[num1]));
                }
            }
            if (suspendListChangedEvent)
            {
                entityListBase.OnRangeLoaded();
            }
            return entityListBase;
        }

        public EntityListBase<TOutPut> ProxyAs<TOutPut>(EntityListBase<TOutPut> entityListBase, Converter<T, TOutPut> converter) 
        {
            entityListBase = ConvertAll<TOutPut>(entityListBase, converter);
            entityListBase.EntityListBaseChanged += new EntityListBase<TOutPut>.EntityListBaseChangedEventHandler(EntityListBaseOutput_EntityListBaseChanged);
            this.EntityListBaseChanged += new EntityListBaseChangedEventHandler(entityListBase.EntityListBaseOutput_EntityListBaseChanged);
            return entityListBase;
        }

        public EntityListBase<T> ProxyAs(EntityListBase<T> entityListBase)
        {
            for (int num1 = 0; num1 < this.Count; num1++)
            {
                entityListBase.Add(this[num1]);
            }
            entityListBase.EntityListBaseChanged += new EntityListBase<T>.EntityListBaseChangedEventHandler(EntityListBaseOutput_EntityListBaseChanged);
            return entityListBase;
        }

        internal void EntityListBaseOutput_EntityListBaseChanged(object source, EntityListBaseChangedEventArgs e)
        {
            if (e.type == System.ComponentModel.ListChangedType.ItemDeleted)
            {
                if (this.Items.Contains((T)e.item))
                {
                    this.Items.Remove((T)e.item);
                }
            }
            else if (e.type == System.ComponentModel.ListChangedType.ItemAdded)
            {
                if (!this.Items.Contains((T)e.item))
                {
	                this.Items.Add((T)e.item);
                }
            }
        }

        public virtual void OnEntityListBaseChanged(ListChangedType listChangedType, T item)
        {
            if (EntityListBaseChanged != null)
            {
                EntityListBaseChanged(this, new EntityListBaseChangedEventArgs(listChangedType, item));
            }
        }

        public delegate void EntityListBaseChangedEventHandler(object source, EntityListBaseChangedEventArgs e);
        public event EntityListBaseChangedEventHandler EntityListBaseChanged;

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            OnEntityListBaseChanged(ListChangedType.ItemAdded, item);
        }

        public T LastItemRemoved = default(T);

        protected override void RemoveItem(int index)
        {
            //T item = this[index];
            this.LastItemRemoved = this[index];
            base.RemoveItem(index);
            //OnEntityListBaseChanged(ListChangedType.ItemDeleted, item);
            OnEntityListBaseChanged(ListChangedType.ItemDeleted, LastItemRemoved);
            this.LastItemRemoved = default(T);
        }

        public void Load(T item)
        {
            this.suspendListChangedEvent = true;
            this.Add(item);
            this.suspendListChangedEvent = false;
        }

        public void LoadRange(IEnumerable<T> collection)
        {
            //if (collection == null)
            //{
            //    //ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
            //    throw new System.ArgumentNullException();
            //}
            //using (IEnumerator<T> enumerator1 = collection.GetEnumerator())
            //{
            //    while (enumerator1.MoveNext())
            //    {
            //        //this.Insert(index++, enumerator1.Current);
            //        this.Items.Add(enumerator1.Current);
            //    }
            //}
            this.suspendListChangedEvent = true;
            this.AddRange(collection);
            this.suspendListChangedEvent = false;
            OnRangeLoaded();
        }

        public event EventHandler RangeLoaded;
        protected void OnRangeLoaded()
        {
            if (RangeLoaded != null)
            {
                RangeLoaded(this, System.EventArgs.Empty);
            }
        }

        private bool suspendListChangedEvent = false;

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (!suspendListChangedEvent)
            {
                base.OnListChanged(e);
            }
        }

    }

    public class EntityListBaseChangedEventArgs : EventArgs
    {
        public ListChangedType type;
        public object item;
        public EntityListBaseChangedEventArgs(ListChangedType type, object item)
        {
            this.type = type;
            this.item = item;
        }
    }


}
