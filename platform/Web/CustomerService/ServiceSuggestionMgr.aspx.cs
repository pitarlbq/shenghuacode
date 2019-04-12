using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.CustomerService
{
    public partial class ServiceSuggestionMgr : BasePage
    {
        public int status = -1;
        public string op = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    op = Request.QueryString["op"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["status"]))
                {
                    int.TryParse(Request.QueryString["status"], out status);
                }
            }
        }
    }
}