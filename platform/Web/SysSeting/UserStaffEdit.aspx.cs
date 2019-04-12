using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class UserStaffEdit : BasePage
    {
        public string type = string.Empty;
        public int UserID = 0;
        public int OrgID = 0;
        public string op = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    op = Request.QueryString["op"];
                }
                if (Request.QueryString["UserID"] != null)
                {
                    int.TryParse(Request.QueryString["UserID"], out UserID);
                }
                if (Request.QueryString["OrgID"] != null)
                {
                    int.TryParse(Request.QueryString["OrgID"], out OrgID);
                }
                if (op.Equals("detail"))
                {
                    UserID = WebUtil.GetUser(this.Context).UserID;
                }
                Foresight.DataAccess.User data = null;
                if (UserID > 0)
                {
                    data = Foresight.DataAccess.User.GetUser(UserID);
                }
                var departmentList = Foresight.DataAccess.CKDepartment.GetCKDepartments().ToArray();
                var departmentItems = departmentList.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.DepartmentName };
                    return item;
                }).ToArray();
                this.hdDepartment.Value = Utility.JsonConvert.SerializeObject(departmentItems);
                if (data != null)
                {
                    SetInfo(data);
                    return;
                }
                if (OrgID > 0)
                {
                    var department = Foresight.DataAccess.CKDepartment.GetCKDepartment(OrgID);
                    if (department != null)
                    {
                        this.tdDepartment.Value = department.ID.ToString();
                    }
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.User data)
        {
            this.tdLoginName.Value = data.LoginName;
            this.tdRealName.Value = data.RealName;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdGender.Value = data.Gender;
            this.tdIsLocked.Value = data.IsLocked ? "1" : "0";
            this.type = data.Type;
            var departmentList = Foresight.DataAccess.CKDepartment.GetAdminInDepartmentList(data.UserID);
            if (departmentList.Length > 0)
            {
                this.tdDepartment.Value = departmentList[0].ID.ToString();
            }
            this.OrgID = data.DepartmentID;
            this.tdServiceFrom.Value = data.ServiceFrom;
            this.tdPositionName.Value = data.PositionName;
        }
    }
}