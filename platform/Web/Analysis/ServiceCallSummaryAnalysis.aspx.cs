using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace Web.Analysis
{
    public partial class ServiceCallSummaryAnalysis : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userList = Foresight.DataAccess.User.GetUsers().Where(p => p.PositionName.Equals("400专员")).ToArray();
                var userItems = userList.Select(p =>
                {
                    var item = new { ID = p.UserID, Name = p.FinalRealName };
                    return item;
                }).ToList();
                userItems.Insert(0, new { ID = 0, Name = "全部" });
                this.hdAddUserName.Value = Utility.JsonConvert.SerializeObject(userItems);
                this.hdStartTime.Value = DateTime.Today.AddDays(1 - DateTime.Today.Day).ToString("yyyy-MM-dd");
                this.hdEndTime.Value = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            }
        }
    }
}