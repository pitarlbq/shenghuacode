using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class EditServiceMaterial : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            Foresight.DataAccess.CustomerService_Material material = null;
            if (ID > 0)
            {
                material = Foresight.DataAccess.CustomerService_Material.GetCustomerService_Material(ID);
                if (material != null)
                {
                    this.tdMateralName.Value = material.MateralName;
                    this.tdUnitPrice.Value = material.UnitPrice > 0 ? material.UnitPrice.ToString() : "";
                    this.tdTotalCount.Value = material.TotalCount > 0 ? material.TotalCount.ToString() : "";
                    this.tdTotalCost.Value = material.TotalCost > 0 ? material.TotalCost.ToString() : "";
                }
            }
        }
    }
}