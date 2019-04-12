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
    public partial class PersionalInfo : BasePage
    {
        public int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = Foresight.DataAccess.Company.GetCompanies();
                if (list.Count > 0)
                {
                    hdCompanys.Value = JsonConvert.SerializeObject(list);
                }
            }
            UserID = WebUtil.GetUser(this.Context).UserID;
            var data = Foresight.DataAccess.User.GetUser(UserID);
            SetInfo(data);
        }
        private void SetInfo(Foresight.DataAccess.User data)
        {
            this.tdCustomerName.Value = data.RealName;
            this.hdCustomerName.Value = data.RealName;
            this.tdPhoneNumber.Value = data.PhoneNumber;
            this.tdGender.Value = data.Gender;
            this.tdIsLocked.Value = data.IsLocked ? "1" : "0";
            this.tdLoginName.Value = data.LoginName;
            this.hdPwd.Value = data.Password;
            this.tdHotPhoneLine.Value = data.HotPhoneLine;
            this.tdBelongServiceName.Value = data.BelongServiceName;
            this.tdQQNumber.Value = data.QQNumber;
            var usercompany = Foresight.DataAccess.UserCompany.GetUserCompanyByUserID(data.UserID);
            if (usercompany != null)
            {
                this.tdCompanyID.Value = usercompany.CompanyID.ToString();
            }
            this.tdUserType.Value = data.Type;
            this.hdOpenID.Value = data.OpenID;
            if (!string.IsNullOrEmpty(data.OpenID))
            {
                var wechat_user = Foresight.DataAccess.Wechat_User.GetWechat_UserByUserOpenID(data.OpenID);
                this.tdOpenID.Value = wechat_user != null ? wechat_user.NickName : string.Empty;
            }
        }
    }
}