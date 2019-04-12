using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using Web.APPCode;

namespace Web.WeiXin
{
    public partial class SuggesitonRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string activitypath = "/html/newweixin/service/suggestion.html";
                string file = HttpContext.Current.Server.MapPath("~" + activitypath);
                if (!System.IO.File.Exists(file))
                {
                    this.Response.Write("<p style=\"font-size:15px;\">你访问的页面已丢失</p>");
                }
                if (System.IO.File.Exists(file))
                {
                    this.Response.Redirect(WebUtil.GetContextPath() + activitypath + "?t=" + DateTime.Now.Ticks.ToString(), false);
                    return;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("WeiXin", this.Request.Url.ToString(), ex);
                Response.Write("请求已过期，请刷新后重试");
                return;
            }
        }
    }
}