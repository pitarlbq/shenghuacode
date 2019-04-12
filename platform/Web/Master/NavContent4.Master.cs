using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.APPCode;

namespace Web.Master
{
    public partial class NavContent4 : MasterBasePage
    {
        public int navtype = 1;//1-房源信息 2-房源+公共区域 3-隐藏
        protected void Page_Load(object sender, EventArgs e)
        {
            var treeExpandLevel = Foresight.DataAccess.TreeExpandLevel.GetTreeExpandLevelByCompanyID(WebUtil.GetCompanyID(this.Context));
            if (Request.QueryString["navtype"] != null)
            {
                int.TryParse(Request.QueryString["navtype"], out navtype);
            }
        }
    }
}