using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.CustomerService
{
    public partial class ServiceComplete : BasePage
    {
        public Foresight.DataAccess.CustomerService service;
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            this.tdBanJieTime.Value = DateTime.Now.ToString("yyyy-MM-dd Hh:mm:ss");
            service = Foresight.DataAccess.CustomerService.GetCustomerService(ID);
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
            this.tdBanJieTime.Value = data.BanJieTime == DateTime.MinValue ? "" : data.BanJieTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdBanJieNote.Value = data.BanJieNote;
        }
    }
}