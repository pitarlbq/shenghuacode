using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foresight.DataAccess;

namespace Web.RoomResource
{
    public partial class EditRelateFamily : BasePage
    {
        public string TableName = Utility.EnumModel.DefineFieldTableName.RoomPhoneRelation.ToString();
        public RoomPhoneRelation relation = null;
        public bool canEditName = true;
        public int ID = 0;
        public int RoomID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["RoomID"]))
            {
                int.TryParse(Request.QueryString["RoomID"], out RoomID);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                if (int.TryParse(Request.QueryString["ID"], out ID))
                {
                    relation = RoomPhoneRelation.GetRoomPhoneRelation(ID);
                }
            }
            if (relation != null)
            {
                this.tdRelationProperty.Value = relation.RelationProperty;
                this.tdRelationType.Value = relation.RelationType;
                this.tdCompanyName.Value = relation.CompanyName;
                this.tdRelateName.Value = relation.RelationName;
                this.tdRelatePhone.Value = relation.RelatePhoneNumber;
                this.tdIsDefault.Value = relation.IsDefault ? "1" : "0";
                this.tdIDCardType.Value = relation.IDCardType == int.MinValue ? "1" : relation.IDCardType.ToString();
                this.tdRelateIDCard.Value = relation.RelationIDCard;
                this.tdRemark.Value = relation.Remark;
                RoomID = relation.RoomID;
            }
        }
    }
}