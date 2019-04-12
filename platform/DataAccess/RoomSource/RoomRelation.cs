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
    /// This object represents the properties and methods of a RoomRelation.
    /// </summary>
    public partial class RoomRelation : EntityBase
    {
        public static RoomRelation[] GetRoomRelationListByRoomID(int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@RoomID", RoomID));
            string cmd = " and RoomID=@RoomID";
            return GetList<RoomRelation>(@"select * from [RoomRelation] where [GUID] in (select [GUID] from RoomRelation where 1=1 " + cmd + ")", parameters).ToArray();
        }
        public static RoomRelation[] GetRoomRelationListByRoomIDList(List<int> RoomIDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string cmd = " and RoomID in (" + string.Join(",", RoomIDList.ToArray()) + ")";
            return GetList<RoomRelation>(@"select * from [RoomRelation] where 1=1 " + cmd + " and [GUID] =(select [GUID] from RoomRelation where 1=1 " + cmd + " group by [GUID] having Count(1)>" + (RoomIDList.Count - 1) + ")", parameters).ToArray();
        }
    }
}
