using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// CKHandler 的摘要说明
    /// </summary>
    public class CKHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("CKHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "removeckdepartment":
                        removeckdepartment(context);
                        break;
                    case "loadckdepartmentgrid":
                        loadckdepartmentgrid(context);
                        break;
                    case "saveckdepartment":
                        saveckdepartment(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("CKHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void removeckdepartment(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            if (!string.IsNullOrEmpty(IDs))
            {
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = "delete from [CKDepartment] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                        helper.Execute(cmdtext, CommandType.Text, new List<System.Data.SqlClient.SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("CKHandler", "visit:removeckdepartment", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
                WebUtil.WriteJson(context, new { status = true });
            }
        }
        private void loadckdepartmentgrid(HttpContext context)
        {
            string Keywords = context.Request.Params["Keywords"];
            DataGrid dg = CKDepartment.GetCKDepartmentGridByKeywords(Keywords, "order by AddTime desc");
            string result = JsonConvert.SerializeObject(dg);
            context.Response.Write(result);
        }
        private void saveckdepartment(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ParentID = WebUtil.GetIntValue(context, "ParentID");
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            Foresight.DataAccess.CKDepartment ckdepartment = null;
            if (ID > 0)
            {
                ckdepartment = CKDepartment.GetCKDepartment(ID);
            }
            if (ckdepartment == null)
            {
                ckdepartment = new CKDepartment();
                ckdepartment.AddTime = DateTime.Now;
                ckdepartment.ParentID = ParentID;
                ckdepartment.CompanyID = CompanyID;
            }
            ckdepartment.DepartmentName = WebUtil.getServerValue(context, "tdDepartmentName");
            ckdepartment.Description = WebUtil.getServerValue(context, "tdDescription");
            ckdepartment.SortOrder = WebUtil.getServerIntValue(context, "tdSortOrder");
            ckdepartment.Save();
            WebUtil.WriteJson(context, new { status = true, ID = ckdepartment.ID });
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class TreeModule
        {
            public string id { get; set; }
            public int ID { get; set; }
            public string pId { get; set; }
            public string name { get; set; }
            public bool isParent { get; set; }
            public bool open { get; set; }
            public string type { get; set; }
            public string Unit { get; set; }
            public string ModelNumber { get; set; }
            public decimal TotalInventory { get; set; }
        }
    }
}