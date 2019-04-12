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
    public partial class ServiceDetailAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var typeList = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
                var typeList1 = typeList.Where(p => p.ParentID == 1).ToArray();
                var typeItems1 = typeList1.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.ServiceTypeName };
                    return item;
                }).ToList();
                typeItems1.Insert(0, new { ID = 0, Name = "全部" });
                this.hdServiceTypeName1.Value = Utility.JsonConvert.SerializeObject(typeItems1);
            }
        }
    }
}