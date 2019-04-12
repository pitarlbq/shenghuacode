
using System;
using System.Collections.Generic;
using System.Text;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Over-ride type converter to return null if column is minValue
    /// Only alters regular implementation if output is string and
    /// the input is the MinValue
    /// </summary>
    class MinToEmptyTypeConverter : System.ComponentModel.TypeConverter
    {
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, GetValue(destinationType, value), destinationType);
        }

        /// <summary>
        /// Get Formatted value for specified type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static object GetValue(System.Type targetType, object value)
        {
            object returnValue = value;

            if (targetType == typeof(System.String))
            {
                if (value != null)
                {
                    System.Type type = value.GetType();

                    System.Reflection.FieldInfo minValue = type.GetField("MinValue");

                    if (minValue != null)
                    {
                        if (minValue.GetValue(null).ToString().Equals(value.ToString()))
                        {
                                returnValue = String.Empty;
                        }
                    }                    
                }
            }

            return returnValue;

        }

    }
}
