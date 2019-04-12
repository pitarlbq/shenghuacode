using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;
using System.ComponentModel;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a RoomPhoneRelation.
    /// </summary>
    public partial class RoomPhoneRelation : EntityBase
    {
        public static RoomPhoneRelation[] GetRoomPhoneRelationsByRoomID(int RoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            RoomPhoneRelation[] list = GetList<RoomPhoneRelation>("SELECT * FROM [RoomPhoneRelation] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
            return list;
        }
        public static Ui.DataGrid GetRoomPhoneRelationGridByRoomID(int RoomID, string RelationType, string orderBy, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (RoomID > 0)
            {
                conditions.Add("[RoomID]=@RoomID");
                parameters.Add(new SqlParameter("@RoomID", RoomID));
            }
            if (!string.IsNullOrEmpty(RelationType))
            {
                conditions.Add("([RelationType]=@RelationType or [RelationType] is null)");
                parameters.Add(new SqlParameter("@RelationType", RelationType));
            }
            string fieldList = "[RoomPhoneRelation].* ";
            string Statement = " from [RoomPhoneRelation] where  " + string.Join(" and ", conditions.ToArray());
            RoomPhoneRelation[] list = new RoomPhoneRelation[] { };
            list = GetList<RoomPhoneRelation>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
        public static RoomPhoneRelation[] GetRoomPhoneRelationsByPhone(string PhoneNumber, int uid = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                return new RoomPhoneRelation[] { };
            }
            if (uid > 0)
            {
                conditions.Add("[RelatePhoneNumber] in (select [LoginName] from [User] where [UserID]=@UserID or [ParentUserID]=@UserID)");
                parameters.Add(new SqlParameter("@UserID", uid));
            }
            conditions.Add("[RelatePhoneNumber]=@RelatePhoneNumber");
            parameters.Add(new SqlParameter("@RelatePhoneNumber", PhoneNumber));
            return GetList<RoomPhoneRelation>("select * from [RoomPhoneRelation] where " + string.Join(" or ", conditions.ToArray()), parameters).ToArray();
        }
        public static RoomPhoneRelation[] GetRoomPhoneRelationListByMinMaxRoomID(int MinRoomID, int MaxRoomID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("RoomID between " + MinRoomID + " and " + MaxRoomID);
            return GetList<RoomPhoneRelation>("select * from [RoomPhoneRelation] where " + string.Join(" and ", conditions.ToArray()), parameters).ToArray();
        }
        public string IsDefaultDesc
        {
            get
            {
                return this.IsDefault ? "是" : "否";
            }
        }
        public string IsChargeFeeDesc
        {
            get
            {
                return this.IsChargeFee ? "是" : "否";
            }
        }
        public string IsChargeManDesc
        {
            get
            {
                return this.IsChargeMan ? "是" : "否";
            }
        }
        public string RelationTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.RelationType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(RelationTypeDefine), this.RelationType);
            }
        }
        public string RelationPropertyDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.RelationProperty))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(RelationPropertyDefine), this.RelationProperty);
            }
        }
        public string IDCardTypeDesc
        {
            get
            {
                string typedesc = string.Empty;
                switch (this.IDCardType)
                {
                    case 1:
                        typedesc = "身份证";
                        break;
                    case 2:
                        typedesc = "护照";
                        break;
                    case 3:
                        typedesc = "军人证";
                        break;
                    case 4:
                        typedesc = "驾驶证";
                        break;
                    case 5:
                        typedesc = "其他";
                        break;
                    default:
                        break;
                }
                return typedesc;
            }
        }
        public string BirthdayDesc
        {
            get
            {
                if (this.Birthday == DateTime.MinValue)
                {
                    return string.Empty;
                }
                return this.Birthday.ToString("yyyy-MM-dd");
            }
        }
    }
    public enum RelationTypeDefine
    {
        [Description("业主")]
        homefamily,
        [Description("租户")]
        rentfamily,
    }
    public enum RelationPropertyDefine
    {
        [Description("个人")]
        geren,
        [Description("公司")]
        gongsi,
    }
}
