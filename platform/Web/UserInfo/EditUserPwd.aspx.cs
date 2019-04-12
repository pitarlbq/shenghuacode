using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserInfo
{
    public partial class EditUserPwd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserID = 0;
            int.TryParse(Request.QueryString["UserID"], out UserID);
            if (UserID > 0)
            {
                var data = Foresight.DataAccess.User.GetUser(UserID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.User data)
        {
            this.tdLoginName.Value = data.LoginName;
            this.hdPwd.Value = data.Password;
        }
    }
}