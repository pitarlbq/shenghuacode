using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a DefineField.
    /// </summary>
    public partial class DefineField : EntityBase
    {
        public static DefineField[] GetDefineFieldsByTable_Name(string Table_Name, int IsNewField = 1, bool OnlyMySelf = false)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IsNewField == 1)
            {
                conditions.Add("isnull([ColumnName],'')=''");
            }
            else if (IsNewField == 2)
            {
                conditions.Add("isnull([ColumnName],'')!=''");
            }
            if (Table_Name.Equals(Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString()) && !OnlyMySelf)
            {
                conditions.Add("(Table_Name='RoomBasic' or Table_Name='RoomPhoneRelation')");
            }
            else
            {
                parameters.Add(new SqlParameter("@Table_Name", Table_Name));
                conditions.Add("Table_Name=@Table_Name");
            }
            return GetList<DefineField>("select * from [DefineField] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
