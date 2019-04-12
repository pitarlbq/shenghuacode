using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.CustomerService
{
    public partial class ServiceProcess : BasePage
    {
        public Foresight.DataAccess.ViewCustomerService service;
        public int ID = 0;
        public string op = string.Empty;
        public int isComplete = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["op"]))
            {
                op = Request.QueryString["op"];
            }
            if (op.Equals("complete"))
            {
                isComplete = 1;
            }
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
            service = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceByID(ID);
            if (service == null)
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            this.tdServiceType1.Value = service.ServiceType1ID > 0 ? service.ServiceType1ID.ToString() : "";
            if (service.ServiceType2IDList.Length > 0)
            {
                this.tdServiceType2.Value = string.Join(",", service.ServiceType2IDList);
            }
            if (service.ServiceType3IDList.Length > 0)
            {
                this.tdServiceType3.Value = string.Join(",", service.ServiceType3IDList);
            }
            this.tdResponseTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdCheckTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdChuLiTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.tdBanJieTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}