﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
                var user = WebUtil.GetUser(this.Context);
                string ServiceFrom = string.Empty;
                if (user != null)
                {
                    ServiceFrom = user.ServiceFrom;
                    ServiceFrom = string.IsNullOrEmpty(ServiceFrom) ? Utility.EnumModel.WechatServiceFromDefine.four00call.ToString() : ServiceFrom;
                    this.tdAddUserName.InnerHtml = user.FinalRealName;
                }
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
    }
}