using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserInfo
{
    public partial class UserMgr : BasePage
    {
        public bool IsAdminSite = false;
        public bool IsFuShunJu = false;
        public int CanViewCoupon = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsAdminSite = new Utility.SiteConfig().IsAdminSite;
                IsFuShunJu = new Utility.SiteConfig().IsFuShunJu;
                CanViewCoupon = base.CheckAuthByModuleCode("1101383") ? 1 : 0;
                var departmentList = CKDepartment.GetCKDepartments().ToArray();
                var departmentItems = departmentList.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.DepartmentName };
                    return item;
                }).ToList();
                departmentItems.Insert(0, new { ID = 0, Name = "全部" });
                this.hdDepartment.Value = Utility.JsonConvert.SerializeObject(departmentItems);
            }
        }
    }
}