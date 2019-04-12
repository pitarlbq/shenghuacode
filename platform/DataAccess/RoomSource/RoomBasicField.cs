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
    /// This object represents the properties and methods of a RoomBasicField.
    /// </summary>
    public partial class RoomBasicField : EntityBase
    {
        public static RoomBasicField[] GetRoomBasicFieldsByFieldID(int FieldID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            parameters.Add(new SqlParameter("@FieldID", FieldID));
            conditions.Add("FieldID=@FieldID");
            conditions.Add("isnull(FieldContent,'')!=''");
            return GetList<RoomBasicField>("select * from [RoomBasicField] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomBasicField[] GetRoomBasicFieldsByRoomID(int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            conditions.Add("RoomID=@RoomID");
            return GetList<RoomBasicField>("select * from [RoomBasicField] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomBasicField GetRoomBasicFieldByRoomIDandFieldID(int RoomID, int FieldID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            conditions.Add("RoomID=@RoomID");
            parameters.Add(new SqlParameter("@FieldID", FieldID));
            conditions.Add("FieldID=@FieldID");
            return GetOne<RoomBasicField>("select top 1 * from [RoomBasicField] where " + string.Join(" and ", conditions.ToArray()), parameters, helper);
        }
        public static RoomBasicField[] GetRoomBasicFieldsByRoomIDList(int MinRoomID, int MaxRoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("RoomID between " + MinRoomID + " and " + MaxRoomID);
            return GetList<RoomBasicField>("select * from [RoomBasicField] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomBasicField[] GetRoomBasicFieldsByFieldIDList(List<int> FieldIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            conditions.Add("FieldID in (" + string.Join(",", FieldIDList.ToArray()) + ")");
            return GetList<RoomBasicField>("select * from [RoomBasicField] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
