using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Analysis
{
    public partial class ServiceChuLiList : BasePage
    {
        public int typeid = 0;
        public int status = 0;
        public int CompanyID = 0;
        public int ProjectID = 0;
        public int ServiceType2ID = 0;
        public int ServiceType3ID = 0;
        public string StartTime = string.Empty;
        public string EndTime = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["typeid"]))
                {
                    int.TryParse(Request.QueryString["typeid"], out typeid);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["status"]))
                {
                    int.TryParse(Request.QueryString["status"], out status);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["CompanyID"]))
                {
                    int.TryParse(Request.QueryString["CompanyID"], out CompanyID);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ProjectID"]))
                {
                    int.TryParse(Request.QueryString["ProjectID"], out ProjectID);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ServiceType2ID"]))
                {
                    int.TryParse(Request.QueryString["ServiceType2ID"], out ServiceType2ID);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ServiceType3ID"]))
                {
                    int.TryParse(Request.QueryString["ServiceType3ID"], out ServiceType3ID);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["start"]))
                {
                    StartTime = Request.QueryString["start"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["end"]))
                {
                    EndTime = Request.QueryString["end"];
                }
            }
        }
    }
}