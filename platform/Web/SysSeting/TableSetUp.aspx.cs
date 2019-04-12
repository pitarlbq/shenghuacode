using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class TableSetUp : BasePage
    {
        public int ColumnServiceStatus = -1;
        public int ColumnServiceType = -1;
        public string PageCode = string.Empty;
        public string TableName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["PageCode"]))
                {
                    Response.End();
                }
                PageCode = Request.QueryString["PageCode"];
                if (!string.IsNullOrEmpty(Request.QueryString["TableName"]))
                {
                    TableName = Request.QueryString["TableName"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ColumnServiceStatus"]))
                {
                    int.TryParse(Request.QueryString["ColumnServiceStatus"], out ColumnServiceStatus);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ColumnServiceType"]))
                {
                    int.TryParse(Request.QueryString["ColumnServiceType"], out ColumnServiceType);
                }
            }
        }
    }
}