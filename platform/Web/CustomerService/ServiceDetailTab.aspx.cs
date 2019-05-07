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

namespace Web.CustomerService
{
    public partial class ServiceDetailTab : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["ID"], out ID);
            }
        }
    }
}