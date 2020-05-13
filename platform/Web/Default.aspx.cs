using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Default : BasePage
    {
        public string SocketURL = string.Empty;
        public string RealName = string.Empty;
        public int pagetype = 1;
        public string LogoPath = string.Empty;
        public string RecordLocation = string.Empty;
        public int UserID = 0;
        public string AddUserName = "";
        public int CanViewHomeCall = 0;
        public int CanViewProject = 0;
        public int CanViewService = 0;
        public int CanViewCallBack = 0;
        public int CanViewAnalysis = 0;
        public int CanViewServiceDetail = 0;
        public int CanViewSetting = 0;
        public int CanViewSMS = 0;
        public string DefaultTitle = string.Empty;
        public string DefaultURL = string.Empty;
        public bool is400User = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = WebUtil.GetUser(this.Context);
                is400User = user.PositionName.Equals("400专员");
                UserID = user.UserID;
                AddUserName = user.LoginName;
                var data = Foresight.DataAccess.Seat.GetSeatByIDAndUserID(0, WebUtil.GetUser(this.Context).UserID);
                if (data != null)
                {
                    this.hdRecordLocation.Value = data.RecordLocation;
                }
                var config = new Utility.SiteConfig();
                SocketURL = config.SocketURL;
                RealName = WebUtil.GetUser(this.Context).RealName;
                LogoPath = "html/images/NewLogo.png";
                string LogoFullPath = HttpContext.Current.Server.MapPath("~/" + LogoPath);
                if (!System.IO.File.Exists(LogoFullPath))
                {
                    LogoPath = "/" + LogoPath;
                }
                SetAuthInfo();
            }
        }
        public void SetAuthInfo()
        {
            CanViewHomeCall = base.CheckAuthByModuleCode("110119001") ? 1 : 0;
            CanViewProject = base.CheckAuthByModuleCode("110119002") ? 1 : 0;
            CanViewService = base.CheckAuthByModuleCode("110119003") ? 1 : 0;
            CanViewCallBack = base.CheckAuthByModuleCode("110119004") ? 1 : 0;
            CanViewAnalysis = base.CheckAuthByModuleCode("110119005") ? 1 : 0;
            CanViewSetting = base.CheckAuthByModuleCode("110119006") ? 1 : 0;
            CanViewServiceDetail = base.CheckAuthByModuleCode("110119100") ? 1 : 0;
            CanViewSMS = base.CheckAuthByModuleCode("110119600") ? 1 : 0;
            if (CanViewHomeCall == 1)
            {
                this.DefaultTitle = "400客服";
                this.DefaultURL = "../Main/Default.aspx";
            }
        }
        protected override void ProcessAjaxRequest(HttpContext context, string action)
        {
            switch (action)
            {
                default:
                    base.ProcessAjaxRequest(context, action);
                    break;
            }
        }
    }
}