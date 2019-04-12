using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// ProjectPropertyHandler 的摘要说明
    /// </summary>
    public class ProjectPropertyHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("ProjectHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadyttables":
                        loadyttables(context);
                        break;
                    case "deleteproperty":
                        deleteproperty(context);
                        break;
                    case "loadtopproperty":
                        loadtopproperty(context);
                        break;
                    case "savetopproperty":
                        savetopproperty(context);
                        break;
                    case "addproperty":
                        addproperty(context);
                        break;
                    case "removetopproperty":
                        removetopproperty(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectPropertyHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void removetopproperty(HttpContext context)
        {
            string IDs = context.Request.Params["IDs"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    cmdtext += "delete from [Project_Property] where RelationID in (select [ID] from [ProjectProperty] where ID in (" + string.Join(",", IDList.ToArray()) + ") and [IsBelongProject]=1)";
                    cmdtext += "delete from [ProjectProperty] where ID in (" + string.Join(",", IDList.ToArray()) + ") and [IsBelongProject]=1";
                    helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ProjectPropertyHandler", "visit: removetopproperty", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void addproperty(HttpContext context)
        {
            try
            {
                string strjson = context.Request.Form["strjson"];
                int ProjectID = int.Parse(context.Request.Params["ProjectID"]);
                List<string> list = JsonConvert.DeserializeObject<List<string>>(strjson);
                Project project = Project.GetProject(ProjectID);
                string PName = string.Empty;
                List<int> idlist = new List<int>();
                int count = 0;
                ProjectProperty property = new ProjectProperty();
                property.AddTime = DateTime.Now;
                property.MainSortOrder = 0;
                property.IsBelongProject = true;
                PropertyInfo[] propertylist = property.GetType().GetProperties();
                for (int i = 0; i < list.Count; i++)
                {
                    if (string.IsNullOrEmpty(list[i]))
                    {
                        continue;
                    }
                    count++;
                    if (count == 1)
                    {
                        property.Title = string.IsNullOrEmpty(project.PName) ? list[i] : project.PName;
                    }
                    PropertyInfo info = propertylist.FirstOrDefault(p => p.Name.Equals("Level" + (count - 1)));
                    if (info != null)
                    {
                        info.SetValue(property, list[i], null);
                    }
                }
                var project_property = new Project_Property();
                project_property.ProjectID = ProjectID;
                project_property.SortOrder = 1;
                project_property.IsHide = false;
                project_property.AddTime = DateTime.Now;
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        property.Save(helper);
                        project_property.RelationID = property.ID;
                        project_property.Save(helper);
                        helper.Commit();
                        context.Response.Write("0");
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ProjectPropertyHandler", "visit: addproperty", ex);
                        context.Response.Write("1");
                    }
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectPropertyHandler", "visit: addproperty", ex);
                context.Response.Write("1");
            }
        }
        private void savetopproperty(HttpContext context)
        {
            string IDs = context.Request.Params["IDs"];
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            string SortOrders = context.Request.Params["SortOrders"];
            string CheckLists = context.Request.Params["CheckLists"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            List<int> SortOrderList = JsonConvert.DeserializeObject<List<int>>(SortOrders);
            List<int> CheckList = JsonConvert.DeserializeObject<List<int>>(CheckLists);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    int i = 0;
                    foreach (var ID in IDList)
                    {
                        var projectProperty = Project_Property.GetProject_Property(ProjectID, ID, helper);
                        if (projectProperty == null)
                        {
                            projectProperty = new Project_Property();
                            projectProperty.ProjectID = ProjectID;
                            projectProperty.RelationID = ID;
                            projectProperty.AddTime = DateTime.Now;
                        }
                        projectProperty.SortOrder = SortOrderList[i];
                        projectProperty.IsHide = CheckList[i] == 1 ? false : true;
                        projectProperty.Save(helper);
                        i++;
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ProjectPropertyHandler", "visit: savetopproperty", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void loadtopproperty(HttpContext context)
        {
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            var project = Project.GetProject(ProjectID);
            string strjson = string.Empty;
            var list = ProjectPropertyDetail.GetProjectPropertyDetailListByProjectID(ProjectID, project.PropertyID, false).OrderBy(p => p.SortOrder).ThenBy(p => p.MainSortOrder).ToArray();
            WebUtil.WriteJson(context, new { status = true, list = list });
        }
        private void deleteproperty(HttpContext context)
        {
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            int PropertyID = WebUtil.GetIntValue(context, "PropertyID");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    Project project = Project.GetProject(ProjectID, helper);
                    if (project.ID != 1 && project.ParentID != 1)
                    {
                        context.Response.Write("2");
                        return;
                    }
                    var projectProperty = Project_Property.GetProject_Property(ProjectID, PropertyID, helper);
                    if (projectProperty == null)
                    {
                        projectProperty = new Project_Property();
                        projectProperty.ProjectID = ProjectID;
                        projectProperty.RelationID = PropertyID;
                        projectProperty.AddTime = DateTime.Now;
                    }
                    projectProperty.IsHide = true;
                    projectProperty.Save(helper);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("ProjectPropertyHandler", "visit: deleteproperty", ex);
                    context.Response.Write("1");
                    return;
                }
            }
            context.Response.Write("0");
        }
        private void loadyttables(HttpContext context)
        {
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            int PropertyID = WebUtil.GetIntValue(context, "PropertyID");
            var project = Project.GetProject(ProjectID);
            string strjson = string.Empty;
            List<ViewYT> ytlist = new List<ViewYT>();
            List<ProjectPropertyDetail> list = new List<ProjectPropertyDetail>();
            if (project.ParentID > 1)
            {
                var property = ProjectPropertyDetail.GetProjectPropertyDetailByID(project.PropertyID);
                property.Title = project.Name;
                list.Add(property);
            }
            else
            {
                list = ProjectPropertyDetail.GetProjectPropertyDetailListByProjectID(project.ID, PropertyID).ToList();
            }
            int startlevel = (project.IconID - 1) < 0 ? 0 : (project.IconID - 1);
            foreach (var item in list)
            {
                int SortOrder = 0;
                if (item.SortOrder > 0)
                {
                    SortOrder = item.SortOrder;
                }
                else if (item.MainSortOrder > 0)
                {
                    SortOrder = item.MainSortOrder;
                }
                ViewYT view = new ViewYT();
                view.ID = item.ID;
                view.title = item.Title;
                view.order = SortOrder;
                var listView = new List<ViewName>();
                PropertyInfo[] projectProperty = item.GetType().GetProperties();
                for (int i = startlevel; i <= projectProperty.Length; i++)
                {
                    PropertyInfo info = projectProperty.FirstOrDefault(p => p.Name.Equals("Level" + i));
                    if (info != null)
                    {
                        object value = info.GetValue(item, null);
                        if (value != null && !string.IsNullOrEmpty(value.ToString()))
                        {
                            string name = info.Name;
                            ViewName viewName = new ViewName();
                            viewName.Name = value.ToString();
                            listView.Add(viewName);
                        }
                    }
                }
                view.list = listView;
                ytlist.Add(view);
            }
            WebUtil.WriteJson(context, new { status = true, values = ytlist });
        }
        public class ViewYT
        {
            public int ID { get; set; }
            public int order { get; set; }
            public string title { get; set; }
            public List<ViewName> list { get; set; }
        }
        public class ViewName
        {
            public string Name { get; set; }
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