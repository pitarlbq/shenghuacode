using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.InitialSetup
{
    public partial class PublicProjectEdit : BasePage
    {
        public int ID = 0;
        public int ParentID = 0;
        public int ParentProjectID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out ID);
                }
                if (Request.QueryString["ParentID"] != null)
                {
                    int.TryParse(Request.QueryString["ParentID"], out ParentID);
                }
                if (Request.QueryString["ParentProjectID"] != null)
                {
                    int.TryParse(Request.QueryString["ParentProjectID"], out ParentProjectID);
                }
                if (this.ParentID > 0)
                {
                    var parent = Foresight.DataAccess.Project_Public.GetProject_Public(this.ParentID);
                    if (parent == null)
                    {
                        Response.End();
                        return;
                    }
                    this.ParentProjectID = parent.ParentProjectID;
                }
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.Project_Public.GetProject_Public(ID);
                    if (data != null)
                    {
                        SetInfo(data);
                    }
                }
                var project = Project.GetProject(this.ParentProjectID);
                if (this.ParentID > 0)
                {
                    var parent = Foresight.DataAccess.Project_Public.GetProject_Public(this.ParentID);
                    if (parent == null)
                    {
                        Response.End();
                        return;
                    }
                    this.tdParentName.InnerHtml = project.FullName + "-" + parent.FullName;
                }
                else if (this.ParentProjectID > 0)
                {
                    if (project == null)
                    {
                        Response.End();
                        return;
                    }
                    this.tdParentName.InnerHtml = project.FullName;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.Project_Public data)
        {
            this.tdName.Value = data.Name;
            this.tdDescription.Value = data.Description;
            this.ParentID = data.ParentID;
            this.ParentProjectID = data.ParentProjectID;
        }
    }
}