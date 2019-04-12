using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web.CustomerService
{
    public partial class ServiceProcessFileView : BasePage
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Response.Write("ID不合法");
                Response.End();
                return;
            }
            int.TryParse(Request.QueryString["ID"], out ID);
            var fileList = Foresight.DataAccess.CustomerServiceChuli_Attach.GetCustomerServiceChuli_AttachList(ID);
            if (fileList.Length == 0)
            {
                Response.Write("没有附件");
                Response.End();
                return;
            }
            var contextPath = WebUtil.GetContextPath();
            var fileItems = fileList.Select(p => contextPath + p.AttachedFilePath).ToArray();
            this.hdImgItems.Value = Utility.JsonConvert.SerializeObject(fileItems);
        }
    }
}