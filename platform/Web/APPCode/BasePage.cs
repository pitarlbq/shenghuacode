using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Foresight.DataAccess;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Text;
using System.Data;
using ExcelProcess;

namespace Web
{
    public class BasePage : System.Web.UI.Page
    {
        const string tokenkey = "1000";
        override protected void OnInit(EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                LogInOutTime("您的登陆凭证已过期，请重新登录", false);
                return;
            }
            var user = WebUtil.GetUser(HttpContext.Current);
            if (user == null)
            {
                LogInOutTime("您的登陆凭证已过期，请重新登录", false);
                return;
            }
        }
        private void LogInOutTime(string Msg)
        {
            LogInOutTime(Msg, true);
        }
        private void LogInOutTime(string Msg, bool showpopup)
        {
            Context.Response.Clear();
            Context.Response.Write("<script src=\"" + GetContextPath() + "/js/jquery-1.8.3.min.js\" type=\"text/javascript\"></script>\n");
            Context.Response.Write("<script src=\"" + GetContextPath() + "/js/easyui/jquery.easyui.min.js\" type=\"text/javascript\"></script>\n");
            Context.Response.Write("<link href=\"" + GetContextPath() + "/js/easyui/gray/easyui.css\" type=\"text/css\" rel=\"stylesheet\" />\n");
            Context.Response.Write("<Script language=javascript>\n");
            Context.Response.Write("$(function(){\n");
            Context.Response.Write("$.messager.alert('提示','" + Msg + "','info',function(){\n");
            if (showpopup)
            {
                Context.Response.Write("var frame = '<iframe name=\"mainFrame\" scrolling=\"auto\" frameborder=\"0\"  src=\"" + GetContextPath() + "/MinLogin.aspx\" style=\"width:100%;height:260px;border:0;\"></iframe>;'\n");
                Context.Response.Write("var pagewidth=$(top.window).width()\n");
                Context.Response.Write("top.$(\"<div id='winlogin'></div>\").appendTo(\"body\").window({\n");
                Context.Response.Write("title: '登录',\n");
                Context.Response.Write("width: 400,\n");
                Context.Response.Write("height: 300,\n");
                Context.Response.Write("top: 50,\n");
                Context.Response.Write("left: 300,\n");
                Context.Response.Write("modal: true,\n");
                Context.Response.Write("minimizable: false,\n");
                Context.Response.Write("maximizable: false,\n");
                Context.Response.Write("collapsible: false,\n");
                Context.Response.Write("closable: false,\n");
                Context.Response.Write("draggable: false,\n");
                Context.Response.Write("resizable: false,\n");
                Context.Response.Write("content: frame,\n");
                Context.Response.Write("onClose: function(){top.$('#winlogin').remove();window.location.reload();}\n");
                Context.Response.Write("})\n");
                Context.Response.Write("top.$('#winlogin').window('center');\n");
            }
            else
            {
                Context.Response.Write("top.location.href='" + GetContextPath() + "/login.aspx?op=logout';\n");
            }
            Context.Response.Write("});\n");
            Context.Response.Write("})");
            Context.Response.Write("</Script>");
            Context.Response.End();
        }
        public string getToken()
        {
            string RandJsToken = ConfigurationManager.AppSettings["RandJsToken"];
            if (string.IsNullOrEmpty(RandJsToken))
            {
                RandJsToken = "yyyyMMdd";
            }
            return DateTime.Now.ToString(RandJsToken) + tokenkey;
        }
        public override void ProcessRequest(HttpContext context)
        {

            if (context.Request.Headers["Accept"].IndexOf("application/json") > -1)
            {
                try
                {
                    ProcessAjaxRequest(context);
                }
                catch (Exception ex)
                {
                    WebUtil.WriteJsonError(context, ErrorCode.ServerError, ex.Message);
                }
            }
            else
            {
                base.ProcessRequest(context);
            }
        }

        protected virtual string ModuleCodes
        {
            get { return string.Empty; }
        }


        #region Process Ajax

        protected virtual void ProcessAjaxRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"];
            if (action == null)
            {
                action = context.Request.Form["action"];
            }
            if (!string.IsNullOrEmpty(action))
            {
                ProcessAjaxRequest(context, action);
            }
            else
            {
                base.ProcessRequest(context);
            }
        }

        protected virtual void ProcessAjaxRequest(HttpContext context, string action)
        {
            WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Not Implemented Ajax Request. Action: " + action);
        }

        #endregion

        #region RegisterClientScriptBlcok

        public void RegisterClientScript(string key, string scriptcontent, bool endresponse)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), key, "<script type=\"text/javascript\">" + scriptcontent + "</script>");
            if (endresponse)
            {
                Response.End();
            }
        }
        public void RegisterClientScript(string key, string scriptcontent)
        {
            RegisterClientScript(key, scriptcontent, false);
        }

        public void RegisterClientMessage(string msg, bool refreshOpener, bool closeWindow)
        {
            string script = "";
            if (!string.IsNullOrEmpty(msg))
            {
                script += "alert('" + msg.Replace("\r", "\\r").Replace("\n", "\\n").Replace("'", "\\'") + "');";
            }
            if (refreshOpener)
            {
                script += "if(window.opener){window.opener.location.reload();}";
            }
            if (closeWindow)
            {
                script += "window.close();";
            }
            RegisterClientScript("error", script, false);
        }

        public void RegisterClientMessage(string msg)
        {
            RegisterClientMessage(msg, false, false);
        }

        #endregion

        protected Foresight.DataAccess.User CurrentUser
        {
            get
            {
                return WebUtil.GetUser(this.Context);
            }
        }

        public bool CheckAuthByModuleCode(string _ModuleCode)
        {
            return WebUtil.Authorization(this.Context, _ModuleCode);
        }
        public bool CheckAuthByModuleCodeList(string[] _ModuleCodes)
        {
            foreach (var _ModuleCode in _ModuleCodes)
            {
                bool result = WebUtil.Authorization(this.Context, _ModuleCode);
                if (result)
                {
                    return true;
                }
            }
            return false;
        }
        protected string GetContextPath()
        {
            return "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + getApplicationPath();
        }
        private string getApplicationPath()
        {
            string _ApplicationPath = HttpContext.Current.Request.ApplicationPath;
            if (_ApplicationPath.Length == 1)
            {
                _ApplicationPath = "";
            }
            else if (!_ApplicationPath.StartsWith("/"))
            {
                _ApplicationPath = "/" + _ApplicationPath;
            }
            return _ApplicationPath;
        }
        public void ExportMultiFile(string FileName, string filepath, List<WorkBookModel> dtlist)
        {
            ExportFile(FileName, filepath, null, null, dtlist);
        }
        public void ExportFile(string FileName, string filepath, DataTable dt, List<CellRangeAddressModel> rangeList, List<WorkBookModel> dtlist, bool exportDirect = true)
        {
            try
            {
                if (!System.IO.Directory.Exists(filepath))
                {
                    System.IO.Directory.CreateDirectory(filepath);
                }
                string strFileName = Path.Combine(filepath, FileName);
                if (rangeList != null)
                {
                    ExcelProcess.ExcelExportHelper.ReportExcel(dt, strFileName, rangeList);
                }
                else if (dtlist != null)
                {
                    ExcelProcess.ExcelExportHelper.ReportExcelMultiDT(dtlist, strFileName);
                }
                else
                {
                    ExcelProcess.ExcelExportHelper.ReportExcel(dt, strFileName);
                }
                if (!exportDirect)
                {
                    return;
                }
                FileInfo DownloadFile = new FileInfo(strFileName);
                if (DownloadFile.Exists)
                {
                    string outputFileName = null;
                    Encoding encoding;
                    string browser = HttpContext.Current.Request.UserAgent.ToUpper();
                    if (browser.Contains("MS") == true && browser.Contains("IE") == true)
                    {
                        outputFileName = HttpUtility.UrlEncode(FileName);
                        encoding = System.Text.Encoding.Default;
                    }
                    else if (browser.Contains("FIREFOX") == true)
                    {
                        outputFileName = FileName;
                        encoding = System.Text.Encoding.GetEncoding("GB2312");
                    }
                    else
                    {
                        outputFileName = HttpUtility.UrlEncode(FileName);
                        encoding = System.Text.Encoding.Default;
                    }
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.ContentEncoding = encoding;
                    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", string.IsNullOrEmpty(outputFileName) ? DateTime.Now.ToString("yyyyMMddHHmmssfff") : outputFileName));
                    HttpContext.Current.Response.WriteFile(DownloadFile.FullName);
                    HttpContext.Current.Response.End();
                }
                else
                {
                    RegisterClientMessage("服务器没有导出该数据文件");
                }
            }
            catch (Exception)
            {
            }
        }
        private APPCode.CommHelper comm_helper = new APPCode.CommHelper();
        public string GetExistColumns(string TableName, string ColumnName)
        {
            return comm_helper.GetExistColumns(TableName, ColumnName);
        }
    }
}