using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceImportantApplication : BasePage
    {
        public int ServiceID = 0;
        public int IsSuggestion = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    int.TryParse(Request.QueryString["ID"], out ServiceID);
                }
                var service = Foresight.DataAccess.CustomerService.GetCustomerService(ServiceID);
                if (service != null)
                {
                    IsSuggestion = service.ServiceType1ID == new Utility.SiteConfig().BaoXiuServiceID ? 0 : 1;
                }
            }
        }
    }
}