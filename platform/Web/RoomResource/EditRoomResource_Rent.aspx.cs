using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.RoomResource
{
    public partial class EditRoomResource_Rent : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["RoomID"]))
                {
                    Response.End();
                    return;
                }
                int RoomID = int.Parse(Request.QueryString["RoomID"]);
                Foresight.DataAccess.Project basic = Foresight.DataAccess.Project.GetProject(RoomID);
                if (basic == null)
                {
                    Response.End();
                    return;
                }
            }
        }
    }
}