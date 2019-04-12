﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Default Value Information
    /// </summary>
    [Serializable]
    public class ColumnInfo
    {

        private static Dictionary<System.Type, Dictionary<string, ColumnInfo>> _columnInfo = new Dictionary<Type, Dictionary<string, ColumnInfo>>();
        private static Dictionary<System.Type, List<string>> _columnInfoDefaultValueKeys = new Dictionary<Type, List<string>>();

        private object _defaultValue = null;
        private string _functionName = null;
        private string _columnName = null;
        private string _dataType = null;
        private bool _isAutoNumber = false;
		private string _friendlyName = null;


        /// <summary>
        /// Default Value
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <param name="dataType"></param>
        private ColumnInfo(IDataReader reader)
        {
            string defaultValue = reader["COLUMN_DEFAULT"].ToString();
            _dataType = reader["DATA_TYPE"].ToString();
            _columnName = reader["COLUMN_NAME"].ToString();
			_friendlyName = reader["FriendlyName"].ToString();
			
            if (reader["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
            {
                _maximumLength = (int)reader["CHARACTER_MAXIMUM_LENGTH"];
            }
			
			if (reader["IS_NULLABLE"].ToString().ToUpper() == "YES")
            {
                _isNullable = true;
            }

            bool isStringValue = false;

            defaultValue = defaultValue.Replace("(", String.Empty).Replace(")", String.Empty);

            if (defaultValue.StartsWith("N'") && defaultValue.EndsWith("'"))
            {
                _defaultValue = defaultValue.Substring(2, defaultValue.Length - 3);
            }
            else if (defaultValue.StartsWith("'") && defaultValue.EndsWith("'"))
            {
                _defaultValue = defaultValue.Replace("'", "");
            }
            else if (defaultValue == "newid")
            {
                _isAutoNumber = true;
            }
            else if (isStringValue)
            {
                _defaultValue = defaultValue;
            }
            else
            {
                defaultValue = defaultValue.Replace("(", "").Replace(")", "");

                if (_dataType == "int")
                {
                    try
                    {
                        _defaultValue = int.Parse(defaultValue);
                    }
                    catch { }
                }
                else if (_dataType == "datetime" && defaultValue == "getdate")
                {
                    _functionName = defaultValue;
                }
                else if (_dataType == "bit")
                {
                    if (defaultValue == "1")
                    {
                        _defaultValue = true;
                    }
                    else
                    {
                        _defaultValue = false;
                    }
                }
                else if (_dataType == "tinyint")
                {
                    try
                    {
                        _defaultValue = Int16.Parse(defaultValue);
                    }
                    catch { }
                }
            }
        }

        private bool _isNullable = false;

        public bool IsNullable
        {
            get
            {
                return _isNullable;
            }
        }
		
		public string FriendlyName
		{
			get 
			{
				if (!String.IsNullOrEmpty(_friendlyName))
				{
					return _friendlyName;	
				}
				else 
				{
					return _columnName;	
				}
			}
		}

        public string ColumnName
        {
            get
            {
                return _columnName;
            }
        }

        public string DataType
        {
            get
            {
                return _dataType;
            }
        }

        public bool IsAutoNumber
        {
            get
            {
                return _isAutoNumber;
            }
        }

        private int? _maximumLength = null;

        public int? MaximumLength
        {
            get
            {
                return _maximumLength;
            }
        }

        /// <summary>
        /// Value
        /// </summary>
        public object Value
        {
            get
            {
                object returnValue = null;

                if (_functionName != null)
                {
                    switch (_functionName)
                    {
                        case "getdate":
                            returnValue = DateTime.Now;
                            break;
                    }
                }
                else
                {
                    returnValue = _defaultValue;
                }

                return returnValue;
            }
        }

        /// <summary>
        /// Get Column Info Default Values
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static List<ColumnInfo> GetColumnInfoDefaultValues(System.Type entityType)
        {
            Dictionary<string, ColumnInfo> columnInfoLookup = GetColumnInfoLookup(entityType);

            List<ColumnInfo> returnValue = new List<ColumnInfo>(_columnInfoDefaultValueKeys.Count);

            foreach(string key in _columnInfoDefaultValueKeys[entityType])
            {
                returnValue.Add(columnInfoLookup[key]);
            }

            return returnValue;

        }

        /// <summary>
        /// Get Column Info
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static Dictionary<string, ColumnInfo> GetColumnInfoLookup(System.Type entityType)
        {
            if (_columnInfo == null)
            {
                _columnInfo = new Dictionary<Type, Dictionary<string, ColumnInfo>>();
            }

            if (!_columnInfo.ContainsKey(entityType))
            {
                _columnInfo[entityType] = new Dictionary<string,ColumnInfo>();
                _columnInfoDefaultValueKeys[entityType] = new List<string>();

                System.Reflection.PropertyInfo property = entityType.GetProperty("TableName", BindingFlags.Public | BindingFlags.Static);

                if (property != null)
                {
                    string tableName = property.GetValue(null, null) as string;

                    string commandText = @"select c.COLUMN_NAME, c.COLUMN_DEFAULT, c.DATA_TYPE, c.IS_NULLABLE, c.CHARACTER_MAXIMUM_LENGTH, ep.value as FriendlyName from INFORMATION_SCHEMA.COLUMNS c 
                                                                                                inner join sys.columns sc ON OBJECT_ID(c.TABLE_SCHEMA + '.' + c.TABLE_NAME) = sc.[object_id] AND c.COLUMN_NAME = sc.name 
                                                                                                LEFT OUTER JOIN sys.extended_properties ep ON sc.[object_id] = ep.major_id AND sc.[column_id] = ep.minor_id AND ep.class = 1 and ep.Name = 'NSFx_FriendlyName'
                                                WHERE c.TABLE_NAME = @TableName";


                    System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();

                    parameters.Add(new SqlParameter("@TableName", tableName));

                    try
                    {
                        using (SqlHelper helper = new SqlHelper())
                        {
                            System.Data.IDataReader reader = helper.ExecuteDataReader(commandText, CommandType.Text, parameters);

                            while (reader.Read())
                            {
                                ColumnInfo columnInfo = new ColumnInfo(reader);

                                _columnInfo[entityType].Add(columnInfo.ColumnName, columnInfo);

                                if (columnInfo.Value != null)
                                {
                                    try
                                    {
                                        _columnInfoDefaultValueKeys[entityType].Add(columnInfo.ColumnName);
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                    catch { }
                }                        
            }
            
            return _columnInfo[entityType];
        }

    }
}
