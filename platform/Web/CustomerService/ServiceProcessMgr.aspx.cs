using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.CustomerService
{
    public partial class ServiceProcessMgr : BasePage
    {
        public int ServiceID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            int.TryParse(Request.QueryString["ID"], out ServiceID);
            if (ServiceID <= 0)
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            var service = Foresight.DataAccess.CustomerService.GetCustomerService(ServiceID);
            if (service == null)
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
        }
    }
}