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
    public partial class ServiceWuYeTouSuFeeAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int WuYeTouSuServiceID = new Utility.SiteConfig().WuYeTouSuServiceID;
                var typeList = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
                var typeList2 = typeList.Where(p => p.ParentID == WuYeTouSuServiceID).ToArray();
                var typeItems2 = typeList2.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.ServiceTypeName };
                    return item;
                }).ToList();
                typeItems2.Insert(0, new { ID = 0, Name = "全部" });
                this.hdServiceTypeName2.Value = Utility.JsonConvert.SerializeObject(typeItems2);
                var typeList2IDList = typeList2.Select(p => p.ID).ToArray();
                var typeList3 = typeList.Where(p => typeList2IDList.Contains(p.ParentID)).ToArray();
                var typeItems3 = typeList3.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.ServiceTypeName, ParentID = p.ParentID };
                    return item;
                }).ToList();
                this.hdServiceTypeName3.Value = Utility.JsonConvert.SerializeObject(typeItems3);
            }
        }
    }
}