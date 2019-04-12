using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.RoomResource
{
    public partial class EditRoomName : BasePage
    {
        public int show_address = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.End();
                return;
            }
            int ID = 0;
            if (!int.TryParse(Request.QueryString["ID"], out ID))
            {
                Response.End();
                return;
            }
            var project = Project.GetProject(ID);
            if (project == null)
            {
                Response.End();
                return;
            }
            if (project.ParentID == 1)
            {
                show_address = 1;
            }
            this.tdProjectName.Value = project.Name;
            this.tdOrderBy.Value = project.OrderBy == int.MinValue ? "" : project.OrderBy.ToString();
        }
    }
}