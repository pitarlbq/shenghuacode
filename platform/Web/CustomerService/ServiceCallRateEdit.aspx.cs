using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceCallRateEdit : BasePage
    {
        public Foresight.DataAccess.CustomerService service;
        public int ID = 0;
        public string PhoneNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID <= 0)
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (service == null)
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            this.tdChuLiRate.Value = service.HuiFangRate > 0 ? service.HuiFangRate.ToString("0") : "";            
            //this.tdChuLiRate.Value = service.HuiFangRate.ToString("0");
        }
    }
}