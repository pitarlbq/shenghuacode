using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Main
{
    public partial class PhoneDefault : System.Web.UI.Page
    {
        public string phoneNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ServiceFrom = Utility.EnumModel.WechatServiceFromDefine.four00call.ToString();
                string ServiceFromDesc = Utility.EnumHelper.GetDescription<Utility.EnumModel.WechatServiceFromDefine>(ServiceFrom);
                this.tdServiceFrom.InnerHtml = ServiceFromDesc;
                this.hdServiceFrom.Value = ServiceFrom;
                this.tdAddTime.InnerHtml = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (!string.IsNullOrEmpty(Request.QueryString["phoneNumber"]))
                {
                    phoneNumber = Request.QueryString["phoneNumber"];
                }
            }
        }
        public string getToken()
        {
            string RandJsToken = ConfigurationManager.AppSettings["RandJsToken"];
            if (string.IsNullOrEmpty(RandJsToken))
            {
                RandJsToken = "yyyyMMdd";
            }
            return DateTime.Now.ToString(RandJsToken);
        }
    }
}