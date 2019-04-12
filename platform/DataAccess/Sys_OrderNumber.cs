using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;
using System.ComponentModel;
using System.Web.Script.Serialization;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Sys_OrderNumber.
    /// </summary>
    public partial class Sys_OrderNumber : EntityBase
    {
        public static Sys_OrderNumber GetSys_OrderNumberByTypeName(string OrderTypeName, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OrderTypeName", OrderTypeName));
            return GetOne<Sys_OrderNumber>("select * from [Sys_OrderNumber] where [OrderTypeName]= @OrderTypeName", parameters, helper);
        }
        public static Sys_OrderNumber GetSys_OrderNumberByRoomID(string OrderTypeName, int RoomID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                var orderNumber = GetSys_OrderNumber(OrderTypeName, RoomID, helper);
                if (orderNumber == null)
                {
                    orderNumber = GetSys_OrderNumber(OrderTypeName, 0, helper);
                }
                return orderNumber;
            }
        }
        public static Sys_OrderNumber GetSys_OrderNumberByRoomID(string OrderTypeName, int RoomID, SqlHelper helper)
        {
            var orderNumber = GetSys_OrderNumber(OrderTypeName, RoomID, helper);
            if (orderNumber == null)
            {
                orderNumber = GetSys_OrderNumber(OrderTypeName, 0, helper);
            }
            return orderNumber;
        }
        public static Sys_OrderNumber GetSys_OrderNumber(string OrderTypeName, int RoomID, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (RoomID <= 0)
            {
                parameters.Add(new SqlParameter("@OrderTypeName", OrderTypeName));
                return GetOne<Sys_OrderNumber>("select top 1 * from [Sys_OrderNumber] where [OrderTypeName]=@OrderTypeName", parameters, helper);
            }
            Project project = Project.GetProject(RoomID, helper);
            if (project == null)
            {
                return null;
            }
            string IDs = string.Empty;
            if (string.IsNullOrEmpty(project.AllParentID) || project.AllParentID.Length < 3)
            {
                IDs = "[" + project.ID + "]";
            }
            else
            {
                IDs = "[" + project.AllParentID.Substring(1, project.AllParentID.Length - 2) + "]";
            }
            int[] IDList = new JavaScriptSerializer().Deserialize<int[]>(IDs);
            parameters.Add(new SqlParameter("@OrderTypeName", OrderTypeName));
            return GetOne<Sys_OrderNumber>("select top 1 * from [Sys_OrderNumber] where [OrderTypeName]=@OrderTypeName and [ID] in (select [OrderNumberID] from [ProjectOrderNumber] where [ProjectID] in (" + string.Join(",", IDList) + "))", parameters, helper);
        }
        public string OrderTypeNameDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.OrderTypeName))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(OrderTypeNameDefine), this.OrderTypeName);
            }
        }
        public string ChargeTypeDesc
        {
            get
            {
                if (!this.OrderTypeName.Equals(OrderTypeNameDefine.chargefee.ToString()))
                {
                    return "--";
                }
                if (this.ChargeType == 2)
                {
                    return "大写合计模板";
                }
                return "默认模板";
            }
        }
    }
    public enum OrderTypeNameDefine
    {
        [Description("收款单")]
        chargefee,
        [Description("冲抵单")]
        offseefee,
        [Description("付款单")]
        chargebackfee,
        [Description("客服登记单")]
        customerservice,
        [Description("交款单")]
        roomfeeorder,
        [Description("物品入库单")]
        productinnumber,
        [Description("物品出库单")]
        productoutnumber,
    }
}
