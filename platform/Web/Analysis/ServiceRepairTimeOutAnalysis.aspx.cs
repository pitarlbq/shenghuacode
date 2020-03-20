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
    public partial class ServiceRepairTimeOutAnalysis : BasePage
    {
        public int ServiceTypeID = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["typeid"]))
                {
                    int.TryParse(Request.QueryString["typeid"], out ServiceTypeID);
                }
                int BaoXiuServiceID = new Utility.SiteConfig().BaoXiuServiceID;
                var typeList = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
                var typeList2 = typeList.Where(p => p.ParentID == BaoXiuServiceID).ToArray();
                var BaoShiServiceIDList = new SiteConfig().BaoShiServiceIDList;
                if (BaoShiServiceIDList != null && BaoShiServiceIDList.Length > 0)
                {
                    if (ServiceTypeID == 3)//报修
                    {
                        typeList2 = typeList2.Where(p => !BaoShiServiceIDList.Contains(p.ID)).ToArray();
                    }
                    if (ServiceTypeID == 4)//报事
                    {
                        typeList2 = typeList2.Where(p => BaoShiServiceIDList.Contains(p.ID)).ToArray();
                    }
                }
                var typeItems2 = typeList2.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.ServiceTypeName };
                    return item;
                }).ToList();
                typeItems2.Insert(0, new { ID = 0, Name = "全部" });
                typeItems2.Insert(0, new { ID = -1, Name = "不限" });
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