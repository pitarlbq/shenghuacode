using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserInfo
{
    public partial class EditRole : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int RoleID = 0;
            int.TryParse(Request.QueryString["RoleID"], out RoleID);
            if (RoleID > 0)
            {
                var data = Foresight.DataAccess.Role.GetRole(RoleID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Role data)
        {
            this.tdRoleName.Value = data.RoleName;
            this.tdRoleDesc.Value = data.RoleDes;
        }
    }
}