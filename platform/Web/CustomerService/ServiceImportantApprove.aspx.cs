using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceImportantApprove : BasePage
    {
        public int ServiceID = 0;
        public string FilePath = string.Empty;
        public int ApproveStatus = 1;
        public int ApplicationType = 0;
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
                var data = Foresight.DataAccess.ServiceType_ImportantService.GetServiceType_ImportantServiceByServiceID(ServiceID);
                if (data != null)
                {
                    this.tdRemark.InnerText = data.ApplicationRemark;
                    this.FilePath = WebUtil.GetContextPath() + data.ApplicationFilePath;
                    this.tdResponseRemark.Value = data.ApproveRemark;
                    this.ApproveStatus = data.ApproveStatus;
                    this.ApplicationType = data.ApplicationType;
                    if (data.ApplicationType == 1)
                    {
                        this.tdApplicationType.InnerText = "启用第三方";
                    }
                    if (data.ApplicationType == 2)
                    {
                        this.tdApplicationType.InnerText = "第三方二次维修";
                    }
                    if (data.ApplicationType == 3)
                    {
                        this.tdApplicationType.InnerText = "维修转赔偿意见未达成一致";
                    }
                    if (data.ApplicationType == 4)
                    {
                        this.tdApplicationType.InnerText = "业主不在家";
                    }
                    this.tdApplicationUsreName.InnerText = data.ApplicationUserName;
                    this.tdApplicationTime.InnerText = data.ApplicationTime.ToString("yyyy-MM-dd HH:mm");
                    this.tdApproveTime.InnerText = data.ApproveTime > DateTime.MinValue ? data.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
                    this.tdApproveUserName.InnerText = data.ApproveUserName;
                    this.tdApproveStatus.InnerText = data.ApproveStatusDesc;
                    this.tdReturnHomeDate.InnerText = WebUtil.GetStrDate(data.ReturnHomeDate);
                }
            }
        }
    }
}