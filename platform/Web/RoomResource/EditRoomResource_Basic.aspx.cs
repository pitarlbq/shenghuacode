using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.RoomResource
{
    public partial class EditRoomResource_Basic : BasePage
    {
        public string TableName = Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString();
        public int RoomID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["RoomID"]))
                {
                    Response.End();
                    return;
                }
                RoomID = int.Parse(Request.QueryString["RoomID"]);
                var project = Project.GetProject(RoomID);
                if (project == null)
                {
                    Response.End();
                    return;
                }
                this.tdFullName.InnerHtml = project.FullName;
                this.tbRoomName.Value = project.Name;
                this.tdRoomProperty.InnerHtml = project.RoomProperty;
                string[] SortOrderArray = project.DefaultOrder.Split('-');
                int SortOrder = 0;
                if (SortOrderArray.Length > 0)
                {
                    int.TryParse(SortOrderArray[SortOrderArray.Length - 1], out SortOrder);
                }
                this.tdSortOrder.Value = SortOrder.ToString();
                RoomBasic basic = RoomBasic.GetRoomBasicByRoomID(RoomID);
                if (basic != null)
                {
                    SetInfo(basic);
                }
            }
        }
        private void SetInfo(RoomBasic data)
        {
            if (data.RoomID > 0)
            {

            }
            this.tbBuildingNumber.Value = data.BuildingNumber;
            this.tdSignDate.Value = WebUtil.GetStrDate(data.SignDate);
            this.tbPaymentTime.Value = WebUtil.GetStrDate(data.PaymentTime);
            this.tdCertificateTime.Value = WebUtil.GetStrDate(data.CertificateTime);
            this.tbRoomType.Value = data.RoomType;
            this.tdIsJingZhuangXiu.Value = data.IsJingZhuangXiu > 0 ? data.IsJingZhuangXiu.ToString() : "";
            this.tdBuildingOutArea.Value = data.BuildingOutArea > 0 ? data.BuildingOutArea.ToString() : "";
        }
    }
}