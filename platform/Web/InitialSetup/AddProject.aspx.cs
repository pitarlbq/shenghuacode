using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;

namespace Web.InitialSetup
{
    public partial class AddProject : BasePage
    {
        public int ProjectID = 0;
        public string IsParent = string.Empty;
        public string CurrentGrade = string.Empty;
        public int CompanyID = 0;
        public string AddMan = string.Empty;
        public int ParentID = 0;
        public string FullName = string.Empty;
        public bool can_add = true;
        public int TotalRoomCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            TotalRoomCount = new Utility.SiteConfig().TotalRoomCount;
            if (string.IsNullOrEmpty(Request.QueryString["ProjectID"]))
            {
                Response.End();
                return;
            }
            if (!int.TryParse(Request.QueryString["ProjectID"], out ProjectID))
            {
                Response.End();
                return;
            }
            Project project = Project.GetProject(ProjectID);
            if (project == null)
            {
                Response.End();
                return;
            }
            if (project.ID == 1)
            {
                var company = WebUtil.GetCompany(this.Context, false);
                var main_list = Foresight.DataAccess.Project.GetProjectByParentID(1);
                if (company.ProjectCount <= main_list.Length && company.ProjectCount > int.MinValue)
                {
                    this.can_add = false;
                    base.RegisterClientMessage("授权项目数已达上限");
                    return;
                }
            }
            this.CurrentGrade = project.Grade;
            this.CompanyID = WebUtil.GetCompanyID(Context);
            this.AddMan = WebUtil.GetUser(Context).RealName;
            this.ParentID = project.ParentID;
            this.ProjectID = project.ID;
            this.FullName = project.FullName;
            List<ProjectPropertyDetail> list = new List<ProjectPropertyDetail>();
            if (project.ParentID > 1)
            {
                var property = ProjectPropertyDetail.GetProjectPropertyDetailByID(project.PropertyID, this.ProjectID);
                property.Title = project.Name;
                list.Add(property);
            }
            else
            {
                list = ProjectPropertyDetail.GetProjectPropertyDetailListByProjectID(this.ProjectID).ToList();
            }
            this.rptAccord.DataSource = list;
            this.rptAccord.DataBind();
            this.hdCloseYT.Value = base.CheckAuthByModuleCode("1191134") ? "1" : "0";
        }
    }
}