using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class ServiceImportantTouSuApprove : BasePage
    {
        public int ServiceID = 0;
        public int isimport = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    int.TryParse(Request.QueryString["ID"], out ServiceID);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["isimport"]))
                {
                    int.TryParse(Request.QueryString["isimport"], out isimport);
                }
            }
            this.tdStartHour.Value = "08:00";
            this.tdEndHour.Value = "18:00";
            if (ServiceID > 0)
            {
                var list = Foresight.DataAccess.ServiceType_ImportantService.GetServiceType_ImportantServiceListByMinMaxServiceID(ServiceID, ServiceID);
                if (list.Length > 0)
                {
                    var data = list[0];
                    if (this.isimport == 1)
                    {
                        this.tdPaiDanTime.Value = data.PaiDanTime > 0 ? data.PaiDanTime.ToString() : "";
                        this.tdResponseTime.Value = data.ResponseTime > 0 ? data.ResponseTime.ToString() : "";
                        this.tdCheckTime.Value = data.CheckTime > 0 ? data.CheckTime.ToString() : "";
                        this.tdChuliTime.Value = data.ChuliTime > 0 ? data.ChuliTime.ToString() : "";
                        this.tdBanJieTime.Value = data.BanJieTime > 0 ? data.BanJieTime.ToString() : "";
                        this.tdHuiFangTime.Value = data.HuiFangTime > 0 ? data.HuiFangTime.ToString() : "";
                        this.tdGuanDanTime.Value = data.GuanDanTime > 0 ? data.GuanDanTime.ToString() : "";
                        this.tdDisableHolidayTime.Value = data.DisableHolidayTime ? "1" : "0";
                        this.tdStartHour.Value = string.IsNullOrEmpty(data.StartHour) ? "08:00" : data.StartHour;
                        this.tdEndHour.Value = string.IsNullOrEmpty(data.EndHour) ? "18:00" : data.EndHour;
                        this.tdDisableWorkOffTime.Value = data.DisableWorkOffTime ? "1" : "0";
                    }
                    else
                    {
                        var serviceData = Foresight.DataAccess.CustomerService.GetCustomerService(ServiceID);
                        if (serviceData != null)
                        {
                            this.tdBanJieDateTime.Value = serviceData.AddTime.AddSeconds((double)data.BanJieTime * 3600).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }
                }
            }
        }
    }
}