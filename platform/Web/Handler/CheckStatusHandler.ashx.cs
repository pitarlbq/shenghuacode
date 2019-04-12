using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// CheckStatusHandler 的摘要说明
    /// </summary>
    public class CheckStatusHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("CheckStatusHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "checkdeleteproject":
                        checkdeleteproject(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CheckStatusHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void checkdeleteproject(HttpContext context)
        {
            string ProjectIDs = context.Request.Params["ProjectIds"];
            List<int> ProjectIDList = new List<int>();
            if (!string.IsNullOrEmpty(ProjectIDs))
            {
                ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
            }
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            var customer_list = Foresight.DataAccess.CustomerService.GetCustomerServiceListByRoomIDList(RoomIDList, ProjectIDList, UserID: WebUtil.GetUser(context).UserID);
            if (customer_list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "有客户登记单，请先清理" });
                return;
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}