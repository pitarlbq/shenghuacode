﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Sort Type
    /// </summary>
    public enum SortType 
	{ 
		Ascending, 
		Descending 
	}

    /// <summary>
    /// Base Comparer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityComparer<T> : IComparer<T>
    {
        string[] _propertyNames = null;
        SortType _sortType = SortType.Ascending;

        /// <summary>
        /// Comparer constructor
        /// </summary>
        /// <param name="propertyName">Property name for sort</param>
        public EntityComparer(string propertyName)
        {
            _propertyNames = new string[] { propertyName };
        }

        /// <summary>
        /// Comparer constructor
        /// </summary>
        /// <param name="propertyName">Sort property name</param>
        /// <param name="sortType">Sort Type</param>
        public EntityComparer(string propertyName, SortType sortType)
            : this(propertyName)
        {
            this._sortType = sortType;
        }

        /// <summary>
        /// Base comparer
        /// </summary>
        /// <param name="propertyNames">Sort Property Name array</param>
        public EntityComparer(string[] propertyNames)
        {
            _propertyNames = propertyNames;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyNames">Property Name array</param>
        /// <param name="sortType">Sort Type</param>
        public EntityComparer(string[] propertyNames, SortType sortType)
            : this(propertyNames)
        {
            this._sortType = sortType;
        }

        /// <summary>
        /// Compare method
        /// </summary>
        /// <param name="entity1">First object</param>
        /// <param name="entity2">Comparison object</param>
        /// <returns>Comparison value</returns>
        public int Compare(T entity1, T entity2)
        {
            int returnValue = 0;

            if (entity1.GetType().ToString() == entity2.GetType().ToString())
            {
                foreach (string propertyName in _propertyNames)
                {
                    string[] propertyList = propertyName.Split('.');
                    
                    object currentObject1 = entity1;
                    object currentObject2 = entity2;

                    for (int i = 0; i < propertyList.Length; i++)
                    {
                        System.Reflection.PropertyInfo property = currentObject1.GetType().GetProperty(propertyList.GetValue(i).ToString());

                        if (property != null && property.CanRead)
                        {
                            currentObject1 = GetPropertyValue(property, currentObject1);
                            currentObject2 = GetPropertyValue(property, currentObject2);
                        }
                    }

                    if (currentObject1 != null && currentObject2 != null)
                    {
                        //  Assume all property types used are
                        //  Comparable 
                        IComparable value1 = (IComparable)currentObject1;
                        IComparable value2 = (IComparable)currentObject2;

                        returnValue = value1.CompareTo(value2);

                        if (returnValue != 0) break;
                    }
                }
            }

            if (this._sortType == SortType.Descending)
            {
                returnValue = returnValue * -1;
            }

            return returnValue;
        }

        /// <summary>
        /// Get Property value
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="entity">Entity</param>
        /// <returns>Value</returns>
        private object GetPropertyValue(System.Reflection.PropertyInfo property, object entity)
        {
            object returnValue = property.GetValue(entity, null);
            return returnValue;
        }
    }
}
