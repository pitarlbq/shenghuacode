
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Custom business object ancestor class
    /// </summary>
    public abstract partial class EntityBaseReadOnly
    {
        public virtual Dictionary<string, object> ToJsonObject(bool ignoreNullValue, bool ignoreDBColumn = true)
        {
            string[] ignorefields = this.JsonIgnoreFields;

            Dictionary<string, object> dic = new Dictionary<string, object>();
            Dictionary<string, PropertyInfo> property_dic = new Dictionary<string, PropertyInfo>();
            if (!ignoreDBColumn)
            {
                property_dic = this.GetALLPropertyList();
            }
            else
            {
                property_dic = this.GetPropertyList(ColumnType.DatabaseColumn);
            }
            foreach (var kv in property_dic)
            {
                if (ignorefields == null || !ignorefields.Contains(kv.Key))
                {
                    var v = this.GetJsonValue(kv.Value);

                    if (ignoreNullValue && v == null)
                    {
                        continue;
                    }
                    dic.Add(kv.Key, v);
                }
            }

            return dic;
        }
        public Dictionary<string, System.Reflection.PropertyInfo> GetALLPropertyList()
        {
            Dictionary<string, PropertyInfo> returnValue = new Dictionary<string, PropertyInfo>();

            System.Type type = this.GetType();

            PropertyInfo[] propertyList = type.GetProperties();

            foreach (PropertyInfo propertyInfo in propertyList)
            {
                returnValue.Add(propertyInfo.Name, propertyInfo);
            }

            return returnValue;
        }
        public virtual Dictionary<string, object> ToJsonObject(bool ignoreDBColumn = true)
        {
            return ToJsonObject(true, ignoreDBColumn: ignoreDBColumn);
        }

        public virtual object GetJsonValue(PropertyInfo p)
        {
            var v = p.GetValue(this, null);
            if (p.PropertyType == typeof(int))
            {
                if ((int)v == int.MinValue)
                {
                    return 0;
                }
            }
            else if (p.PropertyType == typeof(decimal))
            {
                if ((decimal)v == decimal.MinValue)
                {
                    return 0;
                }
            }
            else if (p.PropertyType == typeof(double))
            {
                if ((double)v == double.MinValue)
                {
                    return 0;
                }
            }
            else if (p.PropertyType == typeof(float))
            {
                if ((float)v == float.MinValue)
                {
                    return 0;
                }
            }
            //else if (p.PropertyType == typeof(DateTime))
            //{
            //    if ((DateTime)v == DateTime.MinValue)
            //    {
            //        return string.Empty;
            //    }
            //    else
            //    {
            //        return ((DateTime)v).ToString("yyyy-MM-dd HH:mm:ss");
            //    }
            //}
            return v;
        }

        public virtual string[] JsonIgnoreFields
        {
            get { return null; }
        }
    }
}
