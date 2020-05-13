using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

namespace Web.Handler
{
    /// <summary>
    /// BaseHandler 的摘要说明
    /// </summary>
    public class NonAuthBaseHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable => throw new NotImplementedException();

        public void ProcessRequest(HttpContext context)
        {
            Type ctrlType = this.GetType();
            string visit = context.Request["visit"];
            string action = context.Request["action"];
            action = string.IsNullOrEmpty(action) ? visit : action;
            try
            {
                if (string.IsNullOrEmpty(action))
                {
                    Utility.LogHelper.WriteDebug(ctrlType.Name, "action为空");
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
                action = action.ToLower();
                MethodInfo methodAction = ctrlType.GetMethod(action, BindingFlags.NonPublic | BindingFlags.Instance);
                if (methodAction == null)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "action 不存在" });
                    return;
                }
                methodAction.Invoke(this, new object[] { context });
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError(ctrlType.Name, action, ex);
                WebUtil.WriteJson(context, new { status = false });
            }
        }
    }
}