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

namespace Web.CustomerService
{
    public partial class ServiceSuggestionMgr : BasePage
    {
        public int status = -1;
        public string op = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    op = Request.QueryString["op"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["status"]))
                {
                    int.TryParse(Request.QueryString["status"], out status);
                }
                var typeList = Foresight.DataAccess.ServiceType.GetServiceTypes().ToArray();
                var typeList1 = typeList.Where(p => p.ParentID <= 1).ToArray();
                var typeItems1 = typeList1.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.ServiceTypeName, ParentID = 1 };
                    return item;
                }).ToList();
                this.hdServiceTypeName1.Value = Utility.JsonConvert.SerializeObject(typeItems1);

                var typeList1IDList = typeList1.Select(p => p.ID).ToArray();
                var typeList2 = typeList.Where(p => typeList1IDList.Contains(p.ParentID)).ToArray();
                var typeItems2 = typeList2.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.ServiceTypeName, ParentID = p.ParentID };
                    return item;
                }).ToList();
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