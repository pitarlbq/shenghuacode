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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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