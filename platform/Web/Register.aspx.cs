using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            this.lbMsg.Text = null;
            if (string.IsNullOrEmpty(this.tdCompanyName.Text))
            {
                this.lbMsg.Text = "请输入公司名称";
                return;
            }
            if (string.IsNullOrEmpty(this.tdPhoneNumber.Text))
            {
                this.lbMsg.Text = "请输入联系方式";
                return;
            }
            if (string.IsNullOrEmpty(this.tbLoginName.Text))
            {
                this.lbMsg.Text = "请输入用户名";
                return;
            }
            if (string.IsNullOrEmpty(this.tbPassword.Text))
            {
                this.lbMsg.Text = "请输入密码";
                return;
            }
            if (string.IsNullOrEmpty(this.tdRePassword.Text))
            {
                this.lbMsg.Text = "请输入密码";
                return;
            }
            string errormsg = string.Empty;
            this.lbMsg.Text = errormsg;
            return;
        }
        protected string GetContextPath()
        {
            string _ApplicationPath = HttpContext.Current.Request.ApplicationPath;
            if (_ApplicationPath.Length == 1)
            {
                _ApplicationPath = "";
            }
            else if (!_ApplicationPath.StartsWith("/"))
            {
                _ApplicationPath = "/" + _ApplicationPath;
            }
            return "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + _ApplicationPath;
        }
    }
}