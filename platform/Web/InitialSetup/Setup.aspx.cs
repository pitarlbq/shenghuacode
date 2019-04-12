using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.InitialSetup
{
    public partial class Setup : BasePage
    {
        public bool can_add = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            var company = WebUtil.GetCompany(this.Context);
            var list = Foresight.DataAccess.Project.GetProjectByParentID(1);
            if (company.ProjectCount <= list.Length && company.ProjectCount > int.MinValue)
            {
                can_add = false;
            }
        }
    }
}