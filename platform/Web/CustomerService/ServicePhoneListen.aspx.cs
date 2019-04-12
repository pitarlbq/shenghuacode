using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServicePhoneListen : BasePage
    {
        public int ID = 0;
        public string FullFilePath = string.Empty;
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
            var data = Foresight.DataAccess.PhoneRecord.GetPhoneRecord(ID);
            if (data == null)
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            FullFilePath = WebUtil.GetContextPath() + data.RecordVoicePath;
        }
    }
}