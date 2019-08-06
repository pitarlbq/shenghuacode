using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceTypeImportShiXiaoEdit : BasePage
    {
        public int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            if (ID > 0)
            {
                var data = Foresight.DataAccess.ServiceType_ImportShiXiao.GetServiceType_ImportShiXiao(ID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.ServiceType_ImportShiXiao data)
        {
            this.tdPaiDanTime.Value = data.PaiDanTime > 0 ? data.PaiDanTime.ToString() : "";
            this.tdResponseTime.Value = data.ResponseTime > 0 ? data.ResponseTime.ToString() : "";
            this.tdCheckTime.Value = data.CheckTime > 0 ? data.CheckTime.ToString() : "";
            this.tdChuliTime.Value = data.ChuliTime > 0 ? data.ChuliTime.ToString() : "";
            this.tdBanJieTime.Value = data.BanJieTime > 0 ? data.BanJieTime.ToString() : "";
            this.tdHuiFangTime.Value = data.HuiFangTime > 0 ? data.HuiFangTime.ToString() : "";
            this.tdGuanDanTime.Value = data.GuanDanTime > 0 ? data.GuanDanTime.ToString() : "";
        }
    }
}