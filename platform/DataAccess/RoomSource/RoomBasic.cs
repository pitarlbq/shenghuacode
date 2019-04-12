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
    /// This object represents the properties and methods of a RoomBasic.
    /// </summary>
    public partial class RoomBasic : EntityBase
    {
        public static RoomBasic GetRoomBasicByRoomID(int RoomID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetRoomBasicByRoomID(RoomID, helper);
            }
        }
        public static RoomBasic GetRoomBasicByRoomID(int RoomID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            return GetOne<RoomBasic>("select top 1 * from [RoomBasic] where " + string.Join(" and ", conditions.ToArray()) + " order by [AddTime] desc", parameters, helper);
        }
        public static RoomBasic[] GetRoomBasicListByParams(int[] RoomStateIDList = null, int[] RoomTypeIDList = null, int[] RoomPropertyIDList = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomStateIDList != null && RoomStateIDList.Length > 0)
            {
                conditions.Add("[RoomStateID] in (" + string.Join(",", RoomStateIDList) + ")");
            }
            if (RoomTypeIDList != null && RoomTypeIDList.Length > 0)
            {
                conditions.Add("[RoomTypeID] in (" + string.Join(",", RoomTypeIDList) + ")");
            }
            if (RoomPropertyIDList != null && RoomPropertyIDList.Length > 0)
            {
                conditions.Add("[RoomPropertyID] in (" + string.Join(",", RoomPropertyIDList) + ")");
            }
            return GetList<RoomBasic>("select * from [RoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomBasic[] GetRoomBasicListByMinMaxRoomID(int MinRoomID, int MaxRoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("RoomID between " + MinRoomID + " and " + MaxRoomID);
            return GetList<RoomBasic>("select * from [RoomBasic] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
    }
}
