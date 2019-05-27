using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.CustomerService
{
    public partial class CustomerServiceTypeEdit : BasePage
    {
        public int ID;
        public int ParentID;
        public int IsDisableTime = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = 0;
            int.TryParse(Request.QueryString["ID"], out ID);
            ParentID = 0;
            int.TryParse(Request.QueryString["ParentID"], out ParentID);
            this.tdStartHour.Value = "08:00";
            this.tdEndHour.Value = "18:00";
            if (ID > 0)
            {
                var data = Foresight.DataAccess.ServiceType.GetServiceType(ID);
                if (data != null)
                {
                    SetInfo(data);
                }
            }
            if (ParentID > 0)
            {
                var data = Foresight.DataAccess.ServiceType.GetServiceType(ParentID);
                if (data != null)
                {
                    this.tdParentName.InnerHtml = data.ServiceTypeName;
                    return;
                }
            }
        }
        private void SetInfo(Foresight.DataAccess.ServiceType data)
        {
            this.IsDisableTime = data.IsDisableTime ? 1 : 0;
            this.tdServiceTypeName.Value = data.ServiceTypeName;
            this.tdPaiDanTime.Value = data.PaiDanTime > 0 ? data.PaiDanTime.ToString() : "";
            this.tdResponseTime.Value = data.ResponseTime > 0 ? data.ResponseTime.ToString() : "";
            this.tdCheckTime.Value = data.CheckTime > 0 ? data.CheckTime.ToString() : "";
            this.tdChuliTime.Value = data.ChuliTime > 0 ? data.ChuliTime.ToString() : "";
            this.tdBanJieTime.Value = data.BanJieTime > 0 ? data.BanJieTime.ToString() : "";
            this.tdHuiFangTime.Value = data.HuiFangTime > 0 ? data.HuiFangTime.ToString() : "";
            this.tdGuanDanTime.Value = data.GuanDanTime > 0 ? data.GuanDanTime.ToString() : "";
            this.tdSortOrder.Value = data.SortOrder > int.MinValue ? data.SortOrder.ToString() : "";
            this.ParentID = data.ParentID;
            this.tdDisableSend.Value = data.DisableSend ? "1" : "0";
            this.tdDisableProcee.Value = data.DisableProcee ? "1" : "0";
            this.tdDisableCompelte.Value = data.DisableCompelte ? "1" : "0";
            this.tdDisableCallback.Value = data.DisableCallback ? "1" : "0";
            this.tdDisableShenJi.Value = data.DisableShenJi ? "1" : "0";
            this.tdCloseServiceType.Value = data.CloseServiceType.ToString();
            this.tdGongDanType.Value = data.GongDanType > 0 ? data.GongDanType.ToString() : "";
            this.tdCallBackServiceType.Value = data.CallBackServiceType > 0 ? data.CallBackServiceType.ToString() : "";
            this.tdBanJieServiceType.Value = data.BanJieServiceType > 0 ? data.BanJieServiceType.ToString() : "";
            this.tdDisableHolidayTime.Value = data.DisableHolidayTime ? "1" : "0";
            this.tdStartHour.Value = string.IsNullOrEmpty(data.StartHour) ? "08:00" : data.StartHour;
            this.tdEndHour.Value = string.IsNullOrEmpty(data.EndHour) ? "18:00" : data.EndHour;
        }
    }
}