using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.UserInfo
{
    public partial class EditUser : BasePage
    {
        public int UserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = Foresight.DataAccess.Company.GetCompanies();
                if (list.Count > 0)
                {
                    hdCompanys.Value = JsonConvert.SerializeObject(list);
                }
                UserID = 0;
                int.TryParse(Request.QueryString["UserID"], out UserID);
                var departmentList = CKDepartment.GetCKDepartments().ToArray();
                var departmentItems = departmentList.Select(p =>
                {
                    var item = new { ID = p.ID, Name = p.DepartmentName };
                    return item;
                }).ToList();
                this.hdDepartment.Value = Utility.JsonConvert.SerializeObject(departmentItems);
                if (UserID > 0)
                {
                    var data = Foresight.DataAccess.User.GetUser(UserID);
                    if (data != null)
                    {
                        SetInfo(data);
                        return;
                    }
                }
                var companys = Foresight.DataAccess.Company.GetCompanies();
                if (companys.Count > 0)
                {
                    this.tdCompanyID.Value = companys[0].CompanyID.ToString();
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.User data)
        {
            this.tdCustomerName.Value = string.IsNullOrEmpty(data.RealName) ? data.NickName : data.RealName;
            this.hdCustomerName.Value = this.tdCustomerName.Value;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdGender.Value = data.Gender;
            this.tdIsLocked.Value = data.IsLocked ? "1" : "0";
            this.tdLoginName.Value = data.LoginName;
            this.hdPwd.Value = data.Password;
            this.tdHotPhoneLine.Value = data.HotPhoneLine;
            this.tdBelongServiceName.Value = data.BelongServiceName;
            this.tdQQNumber.Value = data.QQNumber;
            if (data.UserID > 0)
            {
                var usercompany = Foresight.DataAccess.UserCompany.GetUserCompanyByUserID(data.UserID);
                if (usercompany != null)
                {
                    this.tdCompanyID.Value = usercompany.CompanyID.ToString();
                }
            }
            this.tdUserType.Value = data.Type;
            this.hdOpenID.Value = data.OpenID;
            if (!string.IsNullOrEmpty(data.OpenID))
            {
                var wechat_user = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(data.OpenID);
                this.tdOpenID.Value = wechat_user != null ? wechat_user.NickName : string.Empty;
            }
            this.hdIsAllowSysLogin.Value = data.IsAllowSysLogin ? "1" : "0";
            this.hdIsAllowAPPUserLogin.Value = data.IsAllowAPPUserLogin ? "1" : "0";
            var userDepartmentList = Foresight.DataAccess.UserDepartment.GetUserDepartmentListByMinMaxUserID(data.UserID, data.UserID);
            var DepartmentIDList = userDepartmentList.Select(p => p.DepartmentID).ToArray();
            if (DepartmentIDList.Length > 0)
            {
                this.tdDepartment.Value = string.Join(",", DepartmentIDList);
            }
        }
    }
}