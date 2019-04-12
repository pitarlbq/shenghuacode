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
    public partial class ServiceList : BasePage
    {
        public int status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (base.CheckAuthByModuleCode("1101206"))
                {
                    status = 101;
                }
                else
                {
                    status = 100;
                }
            }
        }
    }
}