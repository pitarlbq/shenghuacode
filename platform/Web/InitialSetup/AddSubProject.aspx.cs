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
    public partial class AddSubProject : BasePage
    {
        public int ProjectID = 0;
        public string IsParent = string.Empty;
        public string CurrentGrade = string.Empty;
        public string AddMan = string.Empty;
        public int ParentID = 0;
        public int PropertyID = 0;
        public string FullName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ProjectID"]))
            {
                int.TryParse(Request.QueryString["ProjectID"], out ProjectID);
            }
            Project project = null;
            if (ProjectID > 0)
            {
                project = Project.GetProject(ProjectID);
            }
            if (project == null)
            {
                Response.End();
                return;
            }
            this.FullName = project.FullName;
            this.CurrentGrade = project.Grade;
            this.AddMan = WebUtil.GetUser(Context).RealName;
            this.ParentID = project.ParentID;
            this.ProjectID = project.ID;
            this.PropertyID = project.PropertyID > 0 ? project.PropertyID : 0;
        }
    }
}