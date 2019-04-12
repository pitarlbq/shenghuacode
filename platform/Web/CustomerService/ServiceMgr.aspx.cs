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
    public partial class ServiceMgr : BasePage
    {
        public int status = -1;
        public string op = string.Empty;
        public int BeforeBanJieTimeOutHour = 0;
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
                if (!string.IsNullOrEmpty(Request.QueryString["BeforeBanJieTimeOutHour"]))
                {
                    int.TryParse(Request.QueryString["BeforeBanJieTimeOutHour"], out BeforeBanJieTimeOutHour);
                }
            }
        }
    }
}