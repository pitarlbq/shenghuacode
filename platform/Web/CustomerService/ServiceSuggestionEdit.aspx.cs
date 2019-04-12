using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceSuggestionEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
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
            var service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
            if (service != null)
            {
                SetInfo(service);
            }
            else
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
        }
        private void SetInfo(Foresight.DataAccess.CustomerService data)
        {
            this.tdServiceFullName.InnerHtml = data.ServiceFullName;
            this.tdAddCustomerName.InnerHtml = data.AddCustomerName;
            this.tdAddTime.InnerHtml = data.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdServiceContent.InnerHtml = data.ServiceContent;
        }
    }
}