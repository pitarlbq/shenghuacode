using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CangKu
{
    public partial class EditDepartment : BasePage
    {
        public int ID = 0;
        public int ParentID = 0;
        public int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["ID"], out ID);
            int.TryParse(Request.QueryString["ParentID"], out ParentID);
            int.TryParse(Request.QueryString["CompanyID"], out CompanyID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.CKDepartment.GetCKDepartment(ID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
            if (ParentID > 0)
            {
                var data = Foresight.DataAccess.CKDepartment.GetCKDepartment(ParentID);
                if (data != null)
                {
                    this.tdParentName.InnerHtml = data.DepartmentName;
                    this.CompanyID = data.CompanyID;
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.CKDepartment data)
        {
            this.tdDepartmentName.Value = data.DepartmentName;
            this.tdDescription.Value = data.Description;
            this.tdSortOrder.Value = data.SortOrder > int.MinValue ? data.SortOrder.ToString() : "";
            this.ParentID = data.ParentID;
            this.CompanyID = data.CompanyID;
            if (data.ParentID <= 1 && data.CompanyID > 0)
            {
                var company = Foresight.DataAccess.Company.GetCompany(data.CompanyID);
                this.tdParentName.InnerHtml = company != null ? company.CompanyName : string.Empty;
            }
        }
    }
}