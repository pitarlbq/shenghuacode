using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Utility
{
    public class EnumHelper
    {
        public static EnumDefine[] GetEnumDefines(Type enumType)
        {
            List<EnumDefine> list = new List<EnumDefine>();
            foreach (var key in Enum.GetNames(enumType))
            {
                list.Add(GetEnumDefine(enumType, key));
            }
            return list.ToArray();
        }

        public static EnumDefine[] GetEnumDefines<T>()
        {
            return GetEnumDefines(typeof(T));
        }

        public static EnumDefine GetEnumDefine(Type enumType, string key)
        {
            return new EnumDefine(key, (int)Enum.Parse(enumType, key), GetDescription(enumType, key) ?? key);
        }

        public static EnumDefine GetEnumDefine<T>(string key)
        {
            return GetEnumDefine(typeof(T), key);
        }

        public static string GetDescription(Type enumType, string key)
        {
            System.Reflection.FieldInfo finfo = enumType.GetField(key);
            if (finfo == null)
            {
                return string.Empty;
            }
            object[] enumAttr = finfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
            string description = null;
            if (enumAttr.Length > 0)
            {
                DescriptionAttribute desc = enumAttr[0] as DescriptionAttribute;
                if (desc != null)
                {
                    description = desc.Description;
                }
            }

            return description;
        }

        public static string GetDescription<T>(string key)
        {
            return GetDescription(typeof(T), key);
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

    }

    public class EnumDefine
    {
        public EnumDefine(string key, int value, string description)
        {
            this.Key = key;
            this.Value = value;
            this.Description = description;
        }

        public string Key { get; private set; }
        public int Value { get; private set; }
        public string Description { get; private set; }
    }
}
