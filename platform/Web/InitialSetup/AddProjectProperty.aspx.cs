using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;

using System.Text;

namespace Web.InitialSetup
{
    public partial class AddProjectProperty : BasePage
    {
        public int ProjectID = 0;
        public string IsParent = string.Empty;
        public string CurrentGrade = string.Empty;
        public string AddMan = string.Empty;
        public int ParentID = 0;
        public int PropertyID = 0;
        public int TotalRoomCount = 0;
        public int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            TotalRoomCount = new Utility.SiteConfig().TotalRoomCount;
            if (!string.IsNullOrEmpty(Request.QueryString["ProjectID"]))
            {
                int.TryParse(Request.QueryString["ProjectID"], out ProjectID);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["PropertyID"]))
            {
                int.TryParse(Request.QueryString["PropertyID"], out PropertyID);
            }
            this.AddMan = WebUtil.GetUser(Context).RealName;
            Project project = null;
            if (ProjectID > 0)
            {
                project = Project.GetProject(ProjectID);
            }
            this.hdCloseYT.Value = "0";
            if (project == null)
            {
                this.CurrentGrade = "1";
                this.ParentID = 1;
                this.ProjectID = 1;
                return;
            }
            this.CurrentGrade = project.Grade;
            this.ParentID = project.ParentID;
            this.ProjectID = project.ID;
            this.CompanyID = project.CompanyID;
            if (project.ID > 1 && project.ParentID > 1)
            {
                this.hdCloseYT.Value = "1";
            }
            if (!base.CheckAuthByModuleCode("1191134"))
            {
                this.hdCloseYT.Value = "1";
            }
        }
    }
}