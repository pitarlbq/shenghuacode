using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.RoomResource
{
    public partial class EditAPPAccount : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int RelationID = 0;
            int.TryParse(Request.QueryString["RelationID"], out RelationID);
            if (RelationID > 0)
            {
                var relation = Foresight.DataAccess.RoomPhoneRelation.GetRoomPhoneRelation(RelationID);
                if (relation != null)
                {
                    if (relation.UserID > 0)
                    {
                        var data = Foresight.DataAccess.User.GetUser(relation.UserID);
                        if (data != null)
                        {
                            SetInfo(data);
                            return;
                        }
                    }
                    this.tdAPPUserName.Value = relation.RelatePhoneNumber;
                    this.hdPwd.Value = string.Empty;
                    this.tdIsLocked.Value = "0";
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.User data)
        {
            this.tdAPPUserName.Value = data.LoginName;
            this.hdPwd.Value = data.Password;
            this.tdIsLocked.Value = data.IsLocked ? "1" : "0";
        }
    }
}