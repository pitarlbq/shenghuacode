using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceCall : BasePage
    {
        public Foresight.DataAccess.CustomerService service;
        public int ID = 0;
        public string PhoneNumber = string.Empty;
        public bool CanManualyAddPhoneState = false;
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
            PhoneNumber = service.AddCallPhone;
            this.tdHuiFangTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var phoneRecordList = Foresight.DataAccess.PhoneRecord.GetPhoneRecorByServiceID(service.ID, 2);
            var pickUpPhoneData = phoneRecordList.FirstOrDefault(p => p.FinalPickUpTime > DateTime.MinValue);
            var huifangList = CustomerServiceHuifang.GetCustomerServiceHuifangList(service.ID);
            if (pickUpPhoneData == null)
            {
                CanManualyAddPhoneState = true;
                if (huifangList.FirstOrDefault(p => p.PhoneCallBackType == 1) != null)
                {
                    this.tdPhoneCallBackType.Value = "1";
                    //this.labelPhoneStatusDesc.InnerHtml = "电话回访手动修改为接通";
                }
                else if (huifangList.FirstOrDefault(p => p.PhoneCallBackType == 2) != null)
                {
                    this.tdPhoneCallBackType.Value = "2";
                }
                else
                {
                    this.tdPhoneCallBackType.Value = "3";
                }
            }
            else if (pickUpPhoneData != null)
            {
                this.labelPhoneStatusDesc.InnerHtml = "电话回访已接通";
            }
        }
    }
}