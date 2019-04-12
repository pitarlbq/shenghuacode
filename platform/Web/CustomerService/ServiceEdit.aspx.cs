using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceEdit : BasePage
    {
        public int ProjectID = 0;
        public string guid = string.Empty;
        public int OrderNumberID = 0;
        public int ID = 0;
        public string op = string.Empty;
        public int ServiceType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["op"]))
                {
                    op = Request.QueryString["op"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ServiceType"]))
                {
                    int.TryParse(Request.QueryString["ServiceType"], out ServiceType);
                }
                guid = System.Guid.NewGuid().ToString();
                this.tdAddUserName.InnerHtml = WebUtil.GetUser(this.Context).FinalRealName;
                this.tdAddTime.InnerHtml = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                int.TryParse(Request.QueryString["ID"], out ID);
                Foresight.DataAccess.ViewCustomerService data = null;
                if (ID > 0)
                {
                    data = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceByID(ID);
                }
                if (data != null)
                {
                    SetInfo(data);
                }
                else
                {
                    string ServiceFrom = WebUtil.GetUser(this.Context).ServiceFrom;
                    ServiceFrom = string.IsNullOrEmpty(ServiceFrom) ? Utility.EnumModel.WechatServiceFromDefine.system.ToString() : ServiceFrom;
                    string ServiceFromDesc = Utility.EnumHelper.GetDescription<Utility.EnumModel.WechatServiceFromDefine>(ServiceFrom);
                    this.tdServiceFrom.InnerHtml = ServiceFromDesc;
                    this.hdServiceFrom.Value = ServiceFrom;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.ViewCustomerService data)
        {
            this.ProjectID = data.ProjectID;
            this.OrderNumberID = data.OrderNumberID;
            this.tdProjectName.InnerHtml = data.FinalProjectName;
            this.tdFullName.Value = data.ServiceFullName;
            this.tdAddCustomerName.Value = data.AddCustomerName;
            this.tdAddCallPhone.Value = data.AddCallPhone;
            this.tdIsHighTouSu.Value = data.IsHighTouSu ? "1" : "0";
            this.tdIsInvalidCall.Value = data.IsInvalidCall ? "1" : "0";
            this.tdIsInWeiBao.Value = data.IsInWeiBao ? "1" : "0";
            this.hdServiceFrom.Value = data.ServiceFrom;
            this.tdServiceFrom.InnerHtml = Utility.EnumHelper.GetDescription<Utility.EnumModel.WechatServiceFromDefine>(data.ServiceFrom);
            this.tdServiceNumber.Value = data.ServiceNumber;
            this.tdAppointTime.Value = WebUtil.GetStrDate(data.ServiceAppointTime, format: "yyyy-MM-dd HH:mm:ss");
            this.tdTaskType.Value = data.TaskType > 0 ? data.TaskType.ToString() : "";
            this.tdServiceArea.Value = data.ServiceArea;
            this.tdServiceContent.Value = data.ServiceContent;
            this.tdBelongTeamName.Value = data.DepartmentID > 0 ? data.DepartmentID.ToString() : "";
            var ServiceAccpetManIDList = Foresight.DataAccess.CustomerService_Accpet.GetCustomerService_AccpetListByServiceID(data.ID, new int[] { 0, 1 }).Select(p => p.AccpetManID).ToArray();
            this.tdAcceptManInput.Value = ServiceAccpetManIDList.Length > 0 ? ServiceAccpetManIDList[0].ToString() : "";
            this.tdAddUserName.InnerHtml = data.AddUserName;
            this.tdAddTime.InnerHtml = WebUtil.GetStrDate(data.AddTime, format: "yyyy-MM-dd HH:mm:ss");
            this.tdServiceType1.Value = data.ServiceType1ID > 0 ? data.ServiceType1ID.ToString() : "";
            if (data.ServiceType2IDList.Length > 0)
            {
                this.tdServiceType2.Value = string.Join(",", data.ServiceType2IDList);
            }
            if (data.ServiceType3IDList.Length > 0)
            {
                this.tdServiceType3.Value = string.Join(",", data.ServiceType3IDList);
            }
        }
    }
}