using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysSeting
{
    public partial class SeatEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = Foresight.DataAccess.Seat.GetSeatByIDAndUserID(0, WebUtil.GetUser(this.Context).UserID);
                if (data != null)
                {
                    this.tdSeatName.Value = data.SeatName;
                    this.tdRecordLocation.Value = data.RecordLocation;
                }
            }
        }
    }
}