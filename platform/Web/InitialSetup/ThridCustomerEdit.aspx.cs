using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.InitialSetup
{
    public partial class ThridCustomerEdit : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(Request.QueryString["ID"], out ID);
                }
                if (ID > 0)
                {
                    var data = Foresight.DataAccess.ThirdCustomer.GetThirdCustomer(ID);
                    if (data != null)
                    {
                        SetInfo(data);
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.ThirdCustomer data)
        {
            this.tdProjectName.Value = data.ProjectName;
            this.tdRoomName.Value = data.RoomName;
            this.tdCustomerName.Value = data.CustomerName;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdSignDate.Value = WebUtil.GetStrDate(data.SignDate);
        }
    }
}