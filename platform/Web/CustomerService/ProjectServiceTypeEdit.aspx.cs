using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ProjectServiceTypeEdit : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var project = Foresight.DataAccess.Project.GetProject(ID);
                if (project == null)
                {
                    Response.End();
                    return;
                }
                this.tdProjectName.Value = project.Name;
                var data = Foresight.DataAccess.Project_ServiceTypeDelay.GetProject_ServiceTypeDelay(ID);
                if (data != null)
                {
                    this.tdDelayHour.Value = data.DelayHour.ToString("0");
                }
            }
        }
    }
}