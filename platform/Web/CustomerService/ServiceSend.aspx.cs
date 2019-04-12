using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceSend : BasePage
    {
        public int ID = 0;
        public int ProjectID = 0;
        public int status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Foresight.DataAccess.ViewCustomerService data = null;
                int.TryParse(Request.QueryString["ID"], out ID);
                int.TryParse(Request.QueryString["status"], out status);
                if (ID > 0)
                {
                    data = Foresight.DataAccess.ViewCustomerService.GetViewCustomerServiceByID(ID);
                }
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.ViewCustomerService data)
        {
            var accpetUserList = Foresight.DataAccess.CustomerService_Accpet.GetCustomerService_AccpetListByServiceID(data.ID, new int[] { 0, 1 }, AccpetUserType: 0);
            var ServiceAccpetManIDList = accpetUserList.Where(p => p.AccpetUserType == 1).Select(p => p.AccpetManID).ToArray();
            this.tdAcceptManInput.Value = ServiceAccpetManIDList.Length > 0 ? ServiceAccpetManIDList[0].ToString() : "";
            var ServiceProcessManIDList = accpetUserList.Where(p => p.AccpetUserType == 2).Select(p => p.AccpetManID).ToArray();
            this.tdServiceProcessManID.Value = ServiceProcessManIDList.Length > 0 ? ServiceProcessManIDList[0].ToString() : "";
            this.ProjectID = data.ProjectID > 0 ? data.ProjectID : 0;
            if (this.ProjectID <= 0)
            {
                var topProjectList = Foresight.DataAccess.Project.GetTopProjectListByCompanyID(0, WebUtil.GetUser(this.Context).UserID);
                var topProjectItems = topProjectList.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.Name };
                    return item;
                }).ToArray();
                this.hdProjectName.Value = Utility.JsonConvert.SerializeObject(topProjectItems);
            }
        }
    }
}