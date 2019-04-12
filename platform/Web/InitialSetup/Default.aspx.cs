using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.InitialSetup
{
    public partial class Default : BasePage
    {
        public int ID = 0;
        public string GroupName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Response.End();
                    return;
                }
                if (!int.TryParse(Request.QueryString["ID"], out this.ID))
                {
                    Response.End();
                    return;
                }
                this.GroupName = Request.QueryString["groupname"];
                this.GroupName = string.IsNullOrEmpty(this.GroupName) ? Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString() : this.GroupName;
            }
        }
    }
}