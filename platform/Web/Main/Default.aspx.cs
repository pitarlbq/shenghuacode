using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Main
{
    public partial class Default : BasePage
    {
        public string phoneNumber = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ServiceFrom = WebUtil.GetUser(this.Context).ServiceFrom;
                ServiceFrom = string.IsNullOrEmpty(ServiceFrom) ? Utility.EnumModel.WechatServiceFromDefine.four00call.ToString() : ServiceFrom;
                string ServiceFromDesc = Utility.EnumHelper.GetDescription<Utility.EnumModel.WechatServiceFromDefine>(ServiceFrom);
                this.tdServiceFrom.InnerHtml = ServiceFromDesc;
                this.hdServiceFrom.Value = ServiceFrom;
                this.tdAddUserName.InnerHtml = WebUtil.GetUser(this.Context).FinalRealName;
                this.tdAddTime.InnerHtml = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (!string.IsNullOrEmpty(Request.QueryString["phoneNumber"]))
                {
                    phoneNumber = Request.QueryString["phoneNumber"];
                }
            }
        }
    }
}