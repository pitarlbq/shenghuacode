
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceDetailSummary : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.End();
                return;
            }
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            var service = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceByID(ID);
            if (service == null)
            {
                Response.End();
                return;
            }
            SetInfo(service);
        }
        private void SetInfo(Foresight.DataAccess.ViewCustomerService service)
        {
            this.CompanyName.InnerHtml = WebUtil.GetCompany(this.Context).CompanyName;
            this.tdServiceType.InnerHtml = service.ServiceTypeName;
            if (service.TaskType > 0)
            {
                var tasktype = Foresight.DataAccess.CustomerService_Task.GetCustomerService_Task(service.TaskType);
                this.tdTaskType.InnerHtml = tasktype != null ? tasktype.TaskName : "";
            }
            this.tdServiceNumber.InnerHtml = service.ServiceNumber;
            this.tdAddUserName.InnerHtml = service.AddUserName;
            if (service.SendUserID > 0)
            {
                var user = Foresight.DataAccess.User.GetUser(service.SendUserID);
                this.tdAddUserName.InnerHtml = user == null ? service.SendUserName : user.RealName;
                this.tdServiceAccpetManPhone.InnerHtml = user != null ? user.PhoneNumber : "";
            }
            this.tdAcceptMan.InnerHtml = service.FinalServiceAccpetMan;
            this.tdAPPSendTime.InnerHtml = service.APPSendTime == DateTime.MinValue ? "" : service.APPSendTime.ToString("yyyy-MM-dd HH:mm");
            this.tdAddCustomerName.InnerHtml = service.AddCustomerName;
            this.tdAppointTime.InnerHtml = service.ServiceAppointTime == DateTime.MinValue ? "" : service.ServiceAppointTime.ToString("yyyy-MM-dd HH:mm");
            this.tdAddCallPhone.InnerHtml = service.AddCallPhone;
            this.tdFullName.InnerHtml = service.ServiceFullName;
            this.tdServiceContent.InnerHtml = service.ServiceContent;
            this.tdAcceptTime.InnerHtml = service.AcceptTime == DateTime.MinValue ? "" : service.AcceptTime.ToString("yyyy-MM-dd HH:mm");
            this.tdBanJieTime.InnerHtml = service.BanJieTime == DateTime.MinValue ? "" : service.BanJieTime.ToString("yyyy-MM-dd HH:mm");
            this.tdBanJieNote.InnerHtml = service.BanJieNote;

            this.tdChargeStatus.InnerHtml = "未收取费用";
            if (service.IsRequireCost && service.TotalFee > 0)
            {
                this.tdChargeStatus.InnerHtml = "已收取费用";
            }
            this.tdTotalFee.InnerHtml = service.TotalFee > 0 ? service.TotalFee.ToString() : "";
        }
    }
}