using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using Foresight.DataAccess.Framework;
using System.Data.SqlClient;
using System.Data;
using Utility;
using System.Web.SessionState;
using Foresight.DataAccess.Ui;

namespace Web.Handler
{
    /// <summary>
    /// ProjectHandler 的摘要说明
    /// </summary>
    public class ProjectHandler : IHttpHandler, IRequiresSessionState
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
                    case "getprojectinfo":
                        GetProjectInfo(context);
                        break;
                    case "savesubproject":
                        SaveSubProject(context);
                        break;
                    case "deletesubproject":
                        DeleteSubProject(context);
                        break;
                    case "savenames":
                        SaveNames(context);
                        break;
                    case "savenameswithyt":
                        SaveNamesWithYT(context);
                        break;
                    case "loadytnames":
                        LoadYTNames(context);
                        break;
                    case "saveprojectname":
                        SaveProjectName(context);
                        break;
                    case "getmaxlevel":
                        GetMaxLevel(context);
                        break;
                    case "deleteyt":
                        DeleteYT(context);
                        break;
                    case "getprojecttree":
                        GetProjectTree(context);
                        break;
                    case "connectproject":
                        ConnectProject(context);
                        break;
                    case "disconnectproject":
                        DisConnectProject(context);
                        break;
                    case "checkroomfeeonroom":
                        CheckRoomFeeOnRoom(context);
                        break;
                    case "removeprojectlogo":
                        removeprojectlogo(context);
                        break;
                    case "saveprojectneworder":
                        saveprojectneworder(context);
                        break;
                    case "getprojectbyid":
                        getprojectbyid(context);
                        break;
                    case "saveprojectnamebyid":
                        saveprojectnamebyid(context);
                        break;
                    case "getpublicprojecttree":
                        getpublicprojecttree(context);
                        break;
                    case "saveprojectpublic":
                        saveprojectpublic(context);
                        break;
                    case "loadpublicprojectgrid":
                        loadpublicprojectgrid(context);
                        break;
                    case "removepublicprojects":
                        removepublicprojects(context);
                        break;
                    case "getprojectparams":
                        getprojectparams(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void getprojectparams(HttpContext context)
        {
            int UserID = WebUtil.GetUser(context).UserID;
            var topProjectList = WebUtil.GetMyXiaoQuProjects(UserID);
            var CompanyIDList = topProjectList.Select(p => p.CompanyID).ToList();
            var companyList = Foresight.DataAccess.Company.GetCompanies().Where(p => CompanyIDList.Contains(p.CompanyID)).ToArray();
            var projectItems = topProjectList.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name, CompanyID = p.CompanyID };
                return item;
            }).ToList();
            var companyItems = companyList.Select(p =>
            {
                var item = new { ID = p.CompanyID, Name = p.CompanyName };
                return item;
            }).ToList();
            companyItems.Insert(0, new { ID = 0, Name = "全部" });
            companyItems.Insert(0, new { ID = -1, Name = "不限" });
            WebUtil.WriteJson(context, new { status = true, projectList = projectItems, companyList = companyItems });
        }
        private void removepublicprojects(HttpContext context)
        {
            string IDListstr = context.Request.Params["IDList"];
            var IDList = new List<int>();
            if (!string.IsNullOrEmpty(IDListstr))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(IDListstr);
            }
            if (IDList.Count < 1)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = string.Empty;
                    foreach (var ID in IDList)
                    {
                        cmdtext += "delete from [Project_Public] where [AllParentID] like '%," + ID + ",%';";
                    }
                    cmdtext += "delete from [Project_Public] where ID in (" + string.Join(",", IDList.ToArray()) + ");";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("ProjectHandler", "visit: removepublicprojects", ex);
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveprojectpublic(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ParentID = WebUtil.GetIntValue(context, "ParentID");
            int ParentProjectID = WebUtil.GetIntValue(context, "ParentProjectID");
            var user = WebUtil.GetUser(context);
            Project_Public data = null;
            if (ID > 0)
            {
                data = Project_Public.GetProject_Public(ID);
            }
            Project_Public parent_data = null;
            if (ParentID > 0)
            {
                parent_data = Project_Public.GetProject_Public(ParentID);
                ParentProjectID = parent_data.ParentProjectID;
            }
            if (data == null)
            {
                data = new Project_Public();
                data.AddMan = user.LoginName;
                data.AddTime = DateTime.Now;
                data.ParentProjectID = ParentProjectID;
                data.ParentID = ParentID;
            }
            data.Name = context.Request["Name"];
            data.Description = context.Request["Description"];
            if (parent_data == null)
            {
                data.FullName = data.Name;
            }
            else
            {
                if (string.IsNullOrEmpty(parent_data.FullName))
                {
                    data.FullName = data.Name;
                }
                else
                {
                    data.FullName = parent_data.FullName + "-" + data.Name;
                }
                if (string.IsNullOrEmpty(parent_data.AllParentID))
                {
                    data.AllParentID = "," + parent_data.ID + ",";
                }
                else
                {
                    data.AllParentID = parent_data.AllParentID + parent_data.ID + ",";
                }
            }
            var childs = new Project_Public[] { };
            var IDList = new List<int>();
            if (data.ID > 0)
            {
                IDList.Add(data.ID);
                childs = Foresight.DataAccess.Project_Public.GetAllProject_PublicListByIDs(IDList);
            }
            all_update_texts = new List<string>();
            savepublicprojectnameprocess(data.ID, childs, data.FullName);
            var listgroup = DevideListStr(all_update_texts);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    foreach (var item in listgroup)
                    {
                        string cmdsql = string.Join(";", item.ToArray());
                        helper.Execute(cmdsql, CommandType.Text, new List<SqlParameter>());
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadpublicprojectgrid(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string Keywords = context.Request.Params["keywords"];
                string ProjectIDs = context.Request["ProjectIDs"];
                var ProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
                }
                string PublicProjectIDs = context.Request["PublicProjectIDs"];
                var PublicProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(PublicProjectIDs))
                {
                    PublicProjectIDList = JsonConvert.DeserializeObject<List<int>>(PublicProjectIDs);
                }
                var user = WebUtil.GetUser(context);
                var dg = Project_Public.GetProjectPublicGridList(ProjectIDList, PublicProjectIDList, Keywords, "order by ID asc", startRowIndex, pageSize, UserID: user.UserID);
                WebUtil.WriteJson(context, dg);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ProjectHandler", "命令:loadpublicprojectgrid", ex);
                WebUtil.WriteJson(context, new DataGrid());
            }
        }
        private void getpublicprojecttree(HttpContext context)
        {
            try
            {
                string Keywords = context.Request.Params["keywords"];
                int ParentID = WebUtil.GetIntValue(context, "ParentID");
                int ParentProjectID = WebUtil.GetIntValue(context, "ParentProjectID");
                bool IsLastProject = WebUtil.GetBoolValue(context, "islastproject");
                var user = WebUtil.GetUser(context);
                string type_compnay = Utility.EnumModel.PublicProjectTypeDefine.company.ToString();
                string type_xiaoqu = Utility.EnumModel.PublicProjectTypeDefine.xiaoqu.ToString();
                string type_publicproject = Utility.EnumModel.PublicProjectTypeDefine.publicproject.ToString();
                ProjectTree[] list = new ProjectTree[] { };
                Project_Public[] public_list = new Project_Public[] { };
                if (ParentID <= 0)
                {
                    if (ParentProjectID <= 0)
                    {
                        list = WebUtil.GetMyProjectDetailsTree(user.UserID).ToArray();
                    }
                    else if (!IsLastProject)
                    {
                        list = ProjectTree.GetProjectTreeListByID(ParentProjectID, string.Empty, user.UserID);
                    }
                    else
                    {
                        public_list = Project_Public.GetProjectPublicTreeListByParentID(0, ParentProjectID, Keywords);
                    }
                }
                else
                {
                    public_list = Project_Public.GetProjectPublicTreeListByParentID(ParentID, ParentProjectID, Keywords);
                }
                var items_1 = list.Select(p =>
               {
                   var dic = new Dictionary<string, object>();
                   dic["isParent"] = true;
                   dic["open"] = true;
                   dic["hasradio"] = false;
                   dic["islastproject"] = false;
                   if (p.ID == 1)
                   {
                       dic["id"] = type_compnay + "_1";
                       dic["name"] = WebUtil.GetCompany(context).CompanyName;
                       dic["pId"] = 0;
                   }
                   else
                   {
                       dic["id"] = type_xiaoqu + "_" + p.ID;
                       dic["name"] = p.Name;
                       if (p.ParentID == 1)
                       {
                           dic["pId"] = type_compnay + "_1";
                       }
                       else
                       {
                           dic["pId"] = type_xiaoqu + "_" + p.ParentID;
                           dic["hasradio"] = true;
                           dic["islastproject"] = true;
                       }
                   }
                   dic["ID"] = p.ID;
                   dic["ParentID"] = 0;
                   dic["ParentProjectID"] = 0;
                   dic["Type"] = type_xiaoqu;
                   return dic;
               }).ToList();
                var items_2 = public_list.Select(p =>
                 {
                     var dic = new Dictionary<string, object>();
                     dic["id"] = type_publicproject + "_" + p.ID.ToString();
                     dic["isParent"] = true;
                     dic["open"] = true;
                     dic["hasradio"] = true;
                     dic["islastproject"] = false;
                     dic["ID"] = p.ID;
                     dic["ParentID"] = p.ParentID;
                     dic["ParentProjectID"] = p.ParentProjectID;
                     dic["name"] = p.Name;
                     if (p.ParentID > 0)
                     {
                         dic["pId"] = type_publicproject + "_" + p.ParentID;
                     }
                     else
                     {
                         dic["pId"] = type_xiaoqu + "_" + p.ParentProjectID;
                     }
                     dic["Type"] = type_publicproject;
                     return dic;
                 }).ToList();
                items_1.AddRange(items_2);
                WebUtil.WriteJson(context, items_1);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("ProjectHandler", "命令:getpublicprojecttree", ex);
                WebUtil.WriteJson(context, new DataGrid());
            }
        }
        private void saveprojectnamebyid(HttpContext context)
        {
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            int ProjectID = int.Parse(context.Request.Params["ProjectID"]);
            string ProjectName = context.Request.Params["ProjectName"];
            if (string.IsNullOrEmpty(ProjectName))
            {
                WebUtil.WriteJson(context, new { status = false, error = "项目名称不能为空" });
                return;
            }
            Project project = Project.GetProject(ProjectID);
            if (project == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "项目不存在或者已删除" });
                return;
            }
            project.Name = ProjectName;
            project.CompanyID = CompanyID;
            string parent_fullename = string.Empty;
            if (project.ParentID > 1)
            {
                var parent_project = Project.GetProject(project.ParentID);
                if (parent_project != null)
                {
                    parent_fullename = string.IsNullOrEmpty(parent_project.FullName) ? parent_project.Name : parent_project.FullName;
                }
            }
            Foresight.DataAccess.Project[] childs = Foresight.DataAccess.Project.GetAllChildProjectListByID(project.ID);
            all_update_texts = new List<string>();
            project.FullName = string.IsNullOrEmpty(parent_fullename) ? project.Name : parent_fullename + "-" + project.Name;
            saveprojectnameprocess(project.ID, childs, project.FullName, CompanyID);
            if (all_update_texts.Count > 0)
            {
                var listgroup = DevideListStr(all_update_texts);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        project.Save(helper);
                        foreach (var item in listgroup)
                        {
                            string cmdsql = string.Join(";", item.ToArray());
                            helper.Execute(cmdsql, CommandType.Text, new List<SqlParameter>());
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                        return;
                    }
                }
            }
            Web.APPCode.CacheHelper.RemoveMyViewProjectTree();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getprojectbyid(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var project = Foresight.DataAccess.Project.GetProject(ID);
            WebUtil.WriteJson(context, new { status = true, Name = (project == null ? "" : project.Name) });
        }
        private void saveprojectneworder(HttpContext context)
        {
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            var project = Foresight.DataAccess.Project.GetProject(ProjectID);
            if (project == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "项目不存在" });
                return;
            }
            if (string.IsNullOrEmpty(context.Request["SortOrder"]))
            {
                WebUtil.WriteJson(context, new { status = false, error = "请填写排序序号" });
                return;
            }
            int SortOrder = WebUtil.GetIntValue(context, "SortOrder");
            Project[] projects = new Project[] { };
            string parent_defaultorder = string.Empty;
            if (project.ParentID == 0)
            {
                projects = Foresight.DataAccess.Project.GetProjectByParentID(1).OrderBy(p => p.OrderBy).ToArray();
            }
            else
            {
                if (project.ParentID > 1)
                {
                    var parent_project = Project.GetProject(project.ParentID);
                    if (parent_project != null)
                    {
                        if (parent_project.ParentID == 1)
                        {
                            parent_defaultorder = parent_project.OrderBy.ToString("D3");
                        }
                        else
                        {
                            parent_defaultorder = parent_project.DefaultOrder;
                        }
                    }
                }
                projects = Foresight.DataAccess.Project.GetSameLevelProjectListByID(project.ID, WebUtil.GetUser(context).UserID).OrderBy(p => p.OrderBy).ToArray();
            }
            if (SortOrder > 1)
            {
                projects = projects.Where(p => p.ID == project.ID || p.OrderBy >= SortOrder).OrderBy(p => p.OrderBy).ToArray();
            }
            Foresight.DataAccess.Project[] childs = new Project[] { };
            if (project.ParentID > 1 && projects.Length > 0)
            {
                List<int> IDList = projects.Select(p => p.ID).ToList();
                childs = Foresight.DataAccess.Project.GetAllChildProjectListByIDs(IDList);
            }
            int count = SortOrder;
            all_update_texts = new List<string>();
            foreach (var item in projects)
            {
                if (item.ParentID < 1)
                {
                    continue;
                }
                if (item.ParentID == 1)
                {
                    childs = Foresight.DataAccess.Project.GetAllChildProjectListByID(item.ID);
                }
                if (item.ID == project.ID)
                {
                    item.OrderBy = SortOrder;
                }
                else
                {
                    count++;
                    item.OrderBy = count;
                }
                item.DefaultOrder = string.IsNullOrEmpty(parent_defaultorder) ? item.OrderBy.ToString("D3") : parent_defaultorder + "-" + item.OrderBy.ToString("D3");
                saveprojectneworderprocess(item.ID, childs, item.DefaultOrder, string.Empty);
                string cmdtext = "update [Project] set [DefaultOrder]='" + item.DefaultOrder + "',[OrderBy]='" + item.OrderBy + "' where [ID]=" + item.ID;
                all_update_texts.Add(cmdtext);
            }
            if (all_update_texts.Count > 0)
            {
                var listgroup = DevideListStr(all_update_texts);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var item in listgroup)
                        {
                            string cmdtext = string.Join(";", item.ToArray());
                            helper.Execute(cmdtext, CommandType.Text, new List<SqlParameter>());
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private List<List<string>> DevideListStr(List<string> list)
        {
            List<List<string>> listGroup = new List<List<string>>();
            int count = 100;
            int j = 100;
            for (int i = 0; i < list.Count; i += count)
            {
                List<string> cList = new List<string>();
                cList = list.Take(j).Skip(i).ToList();
                j += count;
                listGroup.Add(cList);
            }
            return listGroup;
        }
        public List<string> all_update_texts = new List<string>();
        private void saveprojectneworderprocess(int ID, Project[] childs, string NewDefaultOrder, string NewFullName)
        {
            var my_childs = childs.Where(p => p.ParentID == ID).OrderBy(p => p.OrderBy).ToArray();
            int count = 0;
            foreach (var data in my_childs)
            {
                count++;
                data.OrderBy = count;
                data.DefaultOrder = NewDefaultOrder + "-" + data.OrderBy.ToString("D3");
                if (!string.IsNullOrEmpty(NewFullName))
                {
                    if (data.isParent)
                    {
                        data.FullName = NewFullName + "-" + data.Name;
                    }
                    else
                    {
                        data.FullName = NewFullName;
                    }
                    string cmdtext = "update [Project] set [OrderBy]='" + data.OrderBy + "', [DefaultOrder]='" + data.DefaultOrder + "',[FullName]=N'" + data.FullName + "' where [ID]=" + data.ID;
                    all_update_texts.Add(cmdtext);
                    saveprojectneworderprocess(data.ID, childs, data.DefaultOrder, data.FullName);
                }
                else
                {
                    string cmdtext = "update [Project] set [OrderBy]='" + data.OrderBy + "', [DefaultOrder]='" + data.DefaultOrder + "' where [ID]=" + data.ID;
                    all_update_texts.Add(cmdtext);
                    saveprojectneworderprocess(data.ID, childs, data.DefaultOrder, string.Empty);
                }
            }
        }
        private void saveprojectnameprocess(int ID, Project[] childs, string NewFullName, int CompanyID)
        {
            var my_childs = childs.Where(p => p.ParentID == ID).OrderBy(p => p.OrderBy).ToArray();
            foreach (var data in my_childs)
            {
                if (data.isParent)
                {
                    data.FullName = NewFullName + "-" + data.Name;
                }
                else
                {
                    data.FullName = NewFullName;
                }
                data.CompanyID = CompanyID;
                string cmdtext = "update [Project] set [FullName]=N'" + data.FullName + "',CompanyID='" + CompanyID + "' where [ID]=" + data.ID;
                all_update_texts.Add(cmdtext);
                saveprojectnameprocess(data.ID, childs, data.FullName, CompanyID);
            }
        }
        private void savepublicprojectnameprocess(int ID, Project_Public[] childs, string NewFullName)
        {
            var my_childs = childs.Where(p => p.ParentID == ID).ToArray();
            foreach (var data in my_childs)
            {
                data.FullName = NewFullName + "-" + data.Name;
                string cmdtext = "update [Project_Public] set [FullName]=N'" + data.FullName + "' where [ID]=" + data.ID;
                all_update_texts.Add(cmdtext);
                savepublicprojectnameprocess(data.ID, childs, data.FullName);
            }
        }
        private void removeprojectlogo(HttpContext context)
        {
            int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
            var project = Foresight.DataAccess.Project.GetProject(ProjectID);
            if (project != null)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string commandText = @"update Project set [LogoPath]=NULL where [AllParentID] like '%," + ProjectID + ",%' or [ID]=" + ProjectID;
                        helper.Execute(commandText, CommandType.Text, new List<SqlParameter>());
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ProjectHandler", "visit: removeprojectlogo", ex);
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        /// <summary>
        /// 删除资源检测是否有收费项目
        /// </summary>
        /// <param name="context"></param>
        private void CheckRoomFeeOnRoom(HttpContext context)
        {
            string ProjectIDStr = context.Request.Params["ProjectID"];
            string RoomIDs = context.Request.Params["RoomIDs"];
            List<int> IDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                IDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            if (IDList.Count == 0 && !string.IsNullOrEmpty(ProjectIDStr))
            {
                int ProjectID = int.Parse(ProjectIDStr);
                var projectlist = Project.GetAllRoomChild(ProjectID);
                foreach (var project in projectlist)
                {
                    IDList.Add(project.ID);
                }
            }
            if (IDList.Count == 0)
            {
                context.Response.Write("{\"status\":false}");
                return;
            }
            context.Response.Write("{\"status\":true}");

        }
        private void DisConnectProject(HttpContext context)
        {
            try
            {
                string RoomIDs = context.Request.Params["IDList"];
                List<int> IDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                if (IDList.Count < 1)
                {
                    context.Response.Write("{\"status\":0}");
                    return;
                }
                int RoomID = int.Parse(context.Request.Params["RoomID"]);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        string cmdtext = string.Empty;
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        foreach (var ID in IDList)
                        {
                            cmdtext += "delete from RoomRelation where RoomID=" + ID + " and GUID in (select GUID from RoomRelation where RoomID=" + RoomID + ");";
                        }
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError("ProjectHandler", "visit: DisConnectProject", ex);
                        helper.Rollback();
                        context.Response.Write("{\"status\":false}");
                        return;
                    }
                }
                RoomRelation[] list = RoomRelation.GetRoomRelationListByRoomID(RoomID);
                if (list.Length == 1)
                {
                    list[0].Delete();
                }
                context.Response.Write("{\"status\":1}");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: DisConnectProject", ex);
                context.Response.Write("{\"status\":3}");
            }
        }
        private void ConnectProject(HttpContext context)
        {
            try
            {
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                if (RoomIDList.Count < 2)
                {
                    context.Response.Write("{\"status\":0}");
                    return;
                }
                RoomRelation[] list = RoomRelation.GetRoomRelationListByRoomIDList(RoomIDList);
                if (list.Length > 0)
                {
                    context.Response.Write("{\"status\":2}");
                    return;
                }
                string guid = Guid.NewGuid().ToString();
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        foreach (var RoomID in RoomIDList)
                        {
                            RoomRelation roomRelation = new RoomRelation();
                            roomRelation.RoomID = RoomID;
                            roomRelation.GUID = guid;
                            roomRelation.Save(helper);
                        }
                        helper.Commit();
                        context.Response.Write("{\"status\":1}");
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ProjectHandler", "visit: ConnectProject", ex);
                        context.Response.Write("{\"status\":3}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: ConnectProject", ex);
                context.Response.Write("{\"status\":3}");
            }
        }
        private void GetProjectTree(HttpContext context)
        {
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            int ID = WebUtil.GetIntValue(context, "ID");
            string Keywords = context.Request.Params["Keywords"];
            int UserID = WebUtil.GetIntValue(context, "UserID");
            ProjectTree[] list = new ProjectTree[] { };
            if (ID <= 0 && string.IsNullOrEmpty(Keywords))
            {
                list = WebUtil.GetMyProjectDetailsTree(UserID);
            }
            else
            {
                list = ProjectTree.GetProjectTreeListByID(ID, Keywords, UserID).ToArray();
            }
            List<Dictionary<string, object>> items = null;
            var company = WebUtil.GetCompany(context);
            if (string.IsNullOrEmpty(Keywords))
            {
                items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    if (p.ID == 1)
                    {
                        dic["name"] = company.CompanyName;
                    }
                    else
                    {
                        dic["name"] = p.Name;
                    }
                    dic["id"] = p.ID;
                    dic["pId"] = p.ParentID;
                    dic["iconSkin"] = "Icon_" + p.IconID;
                    dic["open"] = true;
                    dic["isRoom"] = false;
                    dic["IsLocked"] = p.IsLocked;
                    dic["chkDisabled"] = p.IsLocked;
                    if (!p.isParent)
                    {
                        dic["isRoom"] = true;
                    }
                    return dic;
                }).ToList();
            }
            else
            {
                items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    if (p.ID == 1)
                    {
                        dic["name"] = company.CompanyName;
                    }
                    else
                    {
                        dic["name"] = p.FullName + p.Name;
                    }
                    dic["id"] = p.ID;
                    dic["pId"] = p.ParentID;
                    dic["iconSkin"] = "Icon_" + p.IconID;
                    dic["open"] = true;
                    dic["isRoom"] = false;
                    dic["IsLocked"] = p.IsLocked;
                    dic["chkDisabled"] = p.IsLocked;
                    if (!p.isParent)
                    {
                        dic["isRoom"] = true;
                    }
                    return dic;
                }).ToList();
            }
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void DeleteYT(HttpContext context)
        {
            try
            {
                int ProjectID = 0;
                int.TryParse(context.Request.Params["ProjectID"], out ProjectID);
                int CompanyID = 0;
                int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
                string YTName = context.Request.Params["Name"];
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
                        ProjectYTOrder ytorder = ProjectYTOrder.GetProjectYTOrderByName(YTName, CompanyID, ProjectID, helper);
                        if (ytorder == null)
                        {
                            ytorder = new ProjectYTOrder();
                            ytorder.CompanyID = CompanyID;
                            ytorder.OrderBy = 1;
                            ytorder.Name = YTName;
                            ytorder.IsShow = false;
                            ytorder.ProjectID = ProjectID;
                        }
                        else
                        {
                            ytorder.IsShow = false;
                        }
                        ytorder.Save(helper);
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ProjectHandler", "visit: DeleteYT", ex);
                        context.Response.Write("1");
                        return;
                    }
                }
                context.Response.Write("0");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: DeleteYT", ex);
                context.Response.Write("1");
            }
        }
        private void GetMaxLevel(HttpContext context)
        {
            int ID = 0;
            int.TryParse(context.Request.Params["ID"], out ID);
            var project = Project.GetProject(ID);
            Project[] nexproject = Project.GetProjectListByParentID(project.ID, project.ParentID);
            var items = nexproject.Select(v =>
            {
                var dic = new Dictionary<string, object>();
                dic["MaxLevel"] = v.Level;
                dic["TypeDesc"] = v.TypeDesc;
                dic["PName"] = v.PName;
                return dic;
            }).ToArray();
            string strjson = JsonConvert.SerializeObject(items);
            context.Response.Write(strjson);
        }
        private void SaveNamesWithYT(HttpContext context)
        {
            try
            {
                string strjson = context.Request.Form["strjson"];
                int ProjectID = int.Parse(context.Request.Params["ProjectID"]);
                int OrderBy = 0;
                int.TryParse(context.Request.Params["OrderBy"], out OrderBy);
                List<string> list = JsonConvert.DeserializeObject<List<string>>(strjson);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        Project project = Project.GetProject(ProjectID, helper);
                        string PName = string.Empty;
                        List<int> idlist = new List<int>();
                        int count = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (string.IsNullOrEmpty(list[i]))
                            {
                                continue;
                            }
                            count++;
                            if (count == 1)
                            {
                                PName = list[i];
                                ProjectYT projectyt = ProjectYT.GetProjectYTByName(PName, helper);
                                if (projectyt == null)
                                {
                                    projectyt = new ProjectYT();
                                    projectyt.Name = PName;
                                    projectyt.OrderBy = OrderBy;
                                    projectyt.Save(helper);
                                }
                                continue;
                            }
                            ProjectName projectName = ProjectName.GetProjectNameByName(list[i], PName, helper);
                            if (projectName == null)
                            {
                                projectName = new ProjectName();
                                projectName.Name = list[i];
                                projectName.PName = PName;
                                projectName.Save(helper);
                            }
                            idlist.Add(projectName.ID);
                            if (count == 2)
                            {
                                ProjectName topname = ProjectName.GetProjectNameByName(project.TypeDesc, PName, helper);
                                if (topname == null)
                                {
                                    SaveProjectRelationName(projectName.ID, 0, helper);
                                }
                                else
                                {
                                    SaveProjectRelationName(projectName.ID, topname.ID, helper);
                                }
                                continue;
                            }
                            SaveProjectRelationName(idlist[(count - 2)], idlist[(count - 3)], helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ProjectHandler", "visit: SaveNamesWithYT", ex);
                        context.Response.Write("1");
                        return;
                    }
                }
                context.Response.Write("0");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: SaveNamesWithYT", ex);
                context.Response.Write("1");
            }
        }
        private void SaveProjectName(HttpContext context)
        {
            try
            {
                int ProjectID = int.Parse(context.Request.Params["ProjectID"]);
                string ProjectName = context.Request.Params["ProjectName"];
                int SortOrder = 0;
                int.TryParse(context.Request.Params["OrderBy"], out SortOrder);
                if (string.IsNullOrEmpty(ProjectName))
                {
                    WebUtil.WriteJson(context, new { status = false, error = "项目名称不能为空" });
                    return;
                }
                Project project = Project.GetProject(ProjectID);
                if (project == null)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "项目不存在或者已删除" });
                    return;
                }
                project.OrderBy = SortOrder;
                project.Name = ProjectName;
                string parent_fullename = string.Empty;
                string parent_defaultorder = string.Empty;
                if (project.ParentID > 1)
                {
                    var parent_project = Project.GetProject(project.ParentID);
                    if (parent_project != null)
                    {
                        parent_fullename = string.IsNullOrEmpty(parent_project.FullName) ? parent_project.Name : parent_project.FullName;
                        if (parent_project.ParentID == 1)
                        {
                            parent_defaultorder = parent_project.OrderBy.ToString("D3");
                        }
                        else
                        {
                            parent_defaultorder = parent_project.DefaultOrder;
                        }
                    }
                }
                Foresight.DataAccess.Project[] childs = Foresight.DataAccess.Project.GetAllChildProjectListByID(project.ID);
                all_update_texts = new List<string>();
                project.DefaultOrder = string.IsNullOrEmpty(parent_defaultorder) ? project.OrderBy.ToString("D3") : parent_defaultorder + "-" + project.OrderBy.ToString("D3");
                project.FullName = string.IsNullOrEmpty(parent_fullename) ? project.Name : parent_fullename + "-" + project.Name;
                saveprojectneworderprocess(project.ID, childs, project.DefaultOrder, project.FullName);
                if (all_update_texts.Count > 0)
                {
                    var listgroup = DevideListStr(all_update_texts);
                    using (SqlHelper helper = new SqlHelper())
                    {
                        try
                        {
                            helper.BeginTransaction();
                            project.Save(helper);
                            foreach (var item in listgroup)
                            {
                                string cmdsql = string.Join(";", item.ToArray());
                                helper.Execute(cmdsql, CommandType.Text, new List<SqlParameter>());
                            }
                            helper.Commit();
                        }
                        catch (Exception ex)
                        {
                            helper.Rollback();
                            WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                            return;
                        }
                    }
                }
                Web.APPCode.CacheHelper.RemoveMyViewProjectTree();
                WebUtil.WriteJson(context, new { status = true });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: SaveProjectName", ex);
                WebUtil.WriteJson(context, new { status = false });
            }

        }
        private void LoadYTNames(HttpContext context)
        {
            int ProjectID = 0;
            int.TryParse(context.Request.Params["ProjectID"], out ProjectID);
            int CompanyID = 0;
            int.TryParse(context.Request.Params["CompanyID"], out CompanyID);
            var project = Project.GetProject(ProjectID);
            string strjson = string.Empty;
            List<ViewYT> ytlist = new List<ViewYT>();
            ProjectNameDetails[] list = new ProjectNameDetails[] { };
            int _ID = project.ID;
            if (project.ID != 1 && project.ParentID != 1)
            {
                using (SqlHelper helper = new SqlHelper())
                {
                    GetParentID(project.ParentID, helper, out _ID);
                }
            }
            list = ProjectNameDetails.GetProjectNameListByName(_ID, project.TypeDesc, CompanyID, project.PName).OrderBy(p => p.OrderBy).ToArray();
            for (int i = 0; i < list.Length; i++)
            {
                ViewYT view = new ViewYT();
                view.title = list[i].PName;
                view.order = list[i].OrderBy;
                listView = new List<ViewName>();
                GetChildNames(list[i].ID, list[i].Name);
                if (listView.Count == 0)
                {
                    continue;
                }
                view.list = listView;
                ytlist.Add(view);
            }
            if (ytlist.Count > 0)
            {
                strjson = JsonConvert.SerializeObject(ytlist);
                context.Response.Write("{\"status\":true,\"values\":" + strjson + "}");
                return;
            }
            context.Response.Write("{\"status\":true,\"values\":[]}");
        }
        public List<ViewName> listView = new List<ViewName>();
        public void GetChildNames(int ID, string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                ViewName viewName = new ViewName();
                viewName.Name = title;
                listView.Add(viewName);
            }
            ProjectName projectName = ProjectName.GetFirstProjectNameByID(ID);
            if (projectName == null)
            {
                return;
            }
            ViewName _viewName = new ViewName();
            _viewName.Name = projectName.Name;
            listView.Add(_viewName);
            GetChildNames(projectName.ID, string.Empty);
        }
        private void SaveNames(HttpContext context)
        {
            try
            {
                string strjson = context.Request.Form["strjson"];
                int ProjectID = int.Parse(context.Request.Params["ProjectID"]);
                List<string> list = JsonConvert.DeserializeObject<List<string>>(strjson);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        Project project = Project.GetProject(ProjectID, helper);
                        string PName = string.Empty;
                        List<int> idlist = new List<int>();
                        int count = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (string.IsNullOrEmpty(list[i]))
                            {
                                continue;
                            }
                            count++;
                            if (count == 1)
                            {
                                PName = string.IsNullOrEmpty(project.PName) ? list[i] : project.PName;
                            }
                            ProjectName projectName = ProjectName.GetProjectNameByName(list[i], PName, helper);
                            if (projectName == null)
                            {
                                projectName = new ProjectName();
                                projectName.Name = list[i];
                                projectName.PName = PName;
                                projectName.Save(helper);
                            }
                            idlist.Add(projectName.ID);
                            if (count == 1)
                            {
                                ProjectName topname = ProjectName.GetProjectNameByName(project.TypeDesc, PName, helper);
                                if (topname == null)
                                {
                                    SaveProjectRelationName(projectName.ID, 0, helper);
                                }
                                else
                                {
                                    SaveProjectRelationName(projectName.ID, topname.ID, helper);
                                }
                                continue;
                            }
                            SaveProjectRelationName(idlist[(count - 1)], idlist[(count - 2)], helper);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ProjectHandler", "visit: SaveNames", ex);
                        context.Response.Write("1");
                        return;
                    }
                }
                context.Response.Write("0");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: SaveNames", ex);
                context.Response.Write("1");
            }
        }
        private void SaveProjectRelationName(int ID, int PID, SqlHelper helper)
        {
            try
            {
                ProjectNameRelation relation = new ProjectNameRelation()
                {
                    ID = ID,
                    PID = PID,
                };
                relation.Save(helper);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: SaveProjectRelationName", ex);
            }
        }
        private void GetProjectInfo(HttpContext context)
        {
            int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
            int ID = WebUtil.GetIntValue(context, "ID");
            int PublicID = WebUtil.GetIntValue(context, "PublicID");
            string Keywords = context.Request.Params["Keywords"];
            int UserID = WebUtil.GetUser(context).UserID;
            bool IncludePublic = WebUtil.GetBoolValue(context, "IncludePublic");
            List<ProjectTree> list = new List<ProjectTree>();
            List<Project_Public> list_public = new List<Project_Public>();
            if (ID <= 0 && string.IsNullOrEmpty(Keywords) && PublicID <= 0 && CompanyID <= 0)
            {
                list = WebUtil.GetMyProjectDetailsTree(UserID).ToList();
            }
            else
            {
                if (PublicID > 0)
                {
                    list_public = Project_Public.GetProjectPublicTreeListByParentID(PublicID, 0, string.Empty).ToList();
                }
                else
                {
                    if (IncludePublic && ID > 0)
                    {
                        list_public = Project_Public.GetProjectPublicTreeListByParentID(0, ID, string.Empty, ShowAllParentProject: true).ToList();
                    }
                    list = ProjectTree.GetProjectTreeListByID(ID, Keywords, UserID, CompanyID: CompanyID).ToList();
                    bool IncludeMyself = false;
                    if (context.Request["IncludeMyself"] != null)
                    {
                        bool.TryParse(context.Request["IncludeMyself"], out IncludeMyself);
                    }
                    if (IncludeMyself)
                    {
                        var my_project = ProjectTree.GetProjectTree(ID);
                        list.Add(my_project);
                    }
                }
            }
            List<Dictionary<string, object>> items = null;
            var company = WebUtil.GetCompany(context);
            if (string.IsNullOrEmpty(Keywords))
            {
                string type = string.Empty;
                items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    type = Utility.EnumModel.ProjectTreeTypeDefine.project.ToString();
                    dic["id"] = p.ID;
                    dic["name"] = p.Name;
                    dic["pId"] = p.FinalParentID;
                    dic["ParentID"] = p.FinalParentID;
                    dic["type"] = type;
                    dic["iconSkin"] = "Icon_" + p.IconID;
                    dic["open"] = true;
                    dic["isRoom"] = false;
                    dic["IsLocked"] = p.IsLocked;
                    dic["chkDisabled"] = p.IsLocked;
                    if (!p.isParent)
                    {
                        dic["isRoom"] = true;
                    }
                    return dic;
                }).ToList();
                if (CompanyID <= 0 && ID <= 0)
                {
                    var companyList = Foresight.DataAccess.Company.GetCompanyListByUserID(UserID).ToArray();
                    var companyItems = companyList.Select(p =>
                    {
                        var dic = new Dictionary<string, object>();
                        dic["TypeDesc"] = string.Empty;
                        dic["ID"] = p.CompanyID;
                        dic["ParentID"] = 0;
                        dic["Name"] = p.CompanyName;
                        dic["FullName"] = p.CompanyName;
                        dic["isParent"] = true;
                        dic["CompanyID"] = p.CompanyID;
                        dic["id"] = p.CompanyID;
                        dic["pId"] = 0;
                        dic["name"] = p.CompanyName;
                        dic["type"] = Utility.EnumModel.ProjectTreeTypeDefine.company.ToString();
                        dic["iconSkin"] = "Icon_0";
                        dic["open"] = "true";
                        dic["isRoom"] = false;
                        dic["IsLocked"] = false;
                        dic["chkDisabled"] = false;
                        return dic;
                    }).ToList();
                    items.AddRange(companyItems);
                }
                if (IncludePublic)
                {
                    type = Utility.EnumModel.ProjectTreeTypeDefine.publicproject.ToString();
                    var items2 = list_public.Select(p =>
                    {
                        var dic = p.ToJsonObject();
                        dic["name"] = p.Name;
                        dic["id"] = p.ID + "_" + type;
                        if (p.ParentID <= 0)
                        {
                            dic["pId"] = p.ParentProjectID;
                        }
                        else
                        {
                            dic["pId"] = p.ParentID + "_";
                        }
                        dic["type"] = type;
                        dic["open"] = true;
                        dic["isParent"] = true;
                        dic["ID"] = p.ID;
                        dic["ParentID"] = p.ParentID;
                        return dic;
                    }).ToList();
                    items.AddRange(items2);
                }
            }
            else
            {
                items = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    if (p.ID == 1)
                    {
                        dic["name"] = company.CompanyName;
                    }
                    else
                    {
                        dic["name"] = p.FullName + p.Name;
                    }
                    dic["id"] = p.ID;
                    dic["pId"] = p.ParentID;
                    dic["iconSkin"] = "Icon_" + p.IconID;
                    dic["open"] = true;
                    dic["isRoom"] = false;
                    dic["IsLocked"] = p.IsLocked;
                    dic["chkDisabled"] = p.IsLocked;
                    if (!p.isParent)
                    {
                        dic["isRoom"] = true;
                    }
                    return dic;
                }).ToList();
            }
            string result = JsonConvert.SerializeObject(items);
            context.Response.Write(result);
        }
        private void DeleteSubProject(HttpContext context)
        {
            try
            {
                string ProjectIDs = context.Request.Params["ProjectIDs"];
                string RoomIDs = context.Request.Params["RoomIDs"];
                List<int> RoomIDList = new List<int>();
                List<int> ProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                if (RoomIDList.Count == 0 && !string.IsNullOrEmpty(ProjectIDs))
                {
                    ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs);
                }
                if (RoomIDList.Count == 0 && ProjectIDList.Count == 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "请选择一条资源" });
                    return;
                }
                var customer_list = Foresight.DataAccess.CustomerService.GetCustomerServiceListByRoomIDList(RoomIDList, ProjectIDList, UserID: WebUtil.GetUser(context).UserID);
                if (customer_list.Length > 0)
                {
                    WebUtil.WriteJson(context, new { status = false, error = "有客户登记单，请先清理" });
                    return;
                }
                for (int i = 0; i < RoomIDList.Count; i++)
                {
                    Project.DeleteProjectByID(RoomIDList[i]);
                }
                for (int i = 0; i < ProjectIDList.Count; i++)
                {
                    if (ProjectIDList[i] == 1)
                    {
                        continue;
                    }
                    Project.DeleteProjectByID(ProjectIDList[i]);
                }
                Web.APPCode.CacheHelper.RemoveMyViewProjectTree();
                #region 删除日志
                var user = WebUtil.GetUser(context);
                APPCode.CommHelper.SaveOperationLog("RoomIDList:" + string.Join(",", RoomIDList.ToArray()) + "ProjectIDList:" + string.Join(",", ProjectIDList.ToArray()), Utility.EnumModel.OperationModule.ProjectDelete.ToString(), "资源删除", user.UserID.ToString(), "Project", user.LoginName, IsHide: true);
                APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了资源", Utility.EnumModel.OperationModule.ProjectDelete.ToString(), "资源删除", user.UserID.ToString(), "Project", user.LoginName, IsHide: true);
                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: DeleteSubProject", ex);
                WebUtil.WriteJson(context, new { status = false });
                return;
            }

            WebUtil.WriteJson(context, new { status = true });
        }
        public List<ProjectValues> list = new List<ProjectValues>();
        private string GetDefaultOrder(int SortBy, string NewDefaultOrder = "")
        {
            if (string.IsNullOrEmpty(NewDefaultOrder))
            {
                return SortBy.ToString("D3");
            }
            return NewDefaultOrder + "-" + SortBy.ToString("D3");
        }
        private void SaveSubProject(HttpContext context)
        {
            try
            {
                var user = WebUtil.GetUser(context);
                int ProjectID = WebUtil.GetIntValue(context, "ProjectID");
                int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
                int PropertyID = WebUtil.GetIntValue(context, "PropertyID");
                List<int> RoleIDList = UserRole.GetUserRoles().Where(p => p.UserID == user.UserID).Select(p => p.RoleID).ToList();
                var role_list = Foresight.DataAccess.RoleProject.GetRoleProjectListByUserID(user.UserID);
                bool role_can_add = role_list.Where(p => p.RoleID > 0).ToArray().Length > 0;
                bool user_can_add = role_list.Where(p => p.UserID > 0).ToArray().Length > 0;
                string strjson = context.Request.Form["strjson"];
                string AddMan = user.LoginName;
                string ProjectName = context.Request.Form["ProjectName"];
                string CompanyName = WebUtil.GetCompany(context).CompanyName;
                if (string.IsNullOrEmpty(strjson))
                {
                    context.Response.Write("1");
                    return;
                }
                string PropertyName = string.Empty;
                var projectValue = JsonConvert.DeserializeObject<ProjectValueList>(strjson);
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        var mainproject = Project.GetProject(ProjectID, helper);
                        if (mainproject == null)
                        {
                            helper.Rollback();
                            WebUtil.WriteJson(context, new { status = false, error = "请选择父级资源" });
                            return;
                        }
                        var myProperty = ProjectProperty.GetProjectProperty(PropertyID, helper);
                        PropertyName = myProperty != null ? myProperty.Title : string.Empty;
                        #region 新增小区
                        if (mainproject.ParentID == 0)
                        {
                            if (string.IsNullOrEmpty(ProjectName))
                            {
                                helper.Rollback();
                                WebUtil.WriteJson(context, new { status = false, error = "项目名称不能为空" });
                                return;
                            }
                            SaveProjectProperty(ProjectID, PropertyID, projectValue.order, helper);
                            int SortBy = 0;
                            mainproject = Project.GetProjectByName(1, ProjectName, helper, out SortBy);
                            if (mainproject == null)
                            {
                                mainproject = new Project();
                                mainproject.Name = FormatProjectName(ProjectName);
                                mainproject.ParentID = 1;
                                mainproject.AddTime = DateTime.Now;
                                mainproject.AddMan = AddMan;
                                mainproject.TypeDesc = "小区";
                                mainproject.Level = 1;
                                mainproject.OrderBy = SortBy;
                                mainproject.Grade = "1";
                                mainproject.DefaultOrder = GetDefaultOrder(mainproject.OrderBy);
                                mainproject.IconID = 1;
                                mainproject.isParent = true;
                                mainproject.CompanyID = CompanyID;
                                mainproject.OriFullName = mainproject.Name;
                                mainproject.AllParentID = GetALLParentID(null);
                                mainproject.FullName = GetFullName(mainproject.OriFullName);
                                mainproject.Save(helper);
                                #region 资源权限
                                RoleProject.Save_RoleProject(role_can_add, user_can_add, RoleIDList, role_list, mainproject.ID, user.UserID, helper);
                                #endregion
                            }
                        }
                        #endregion
                        #region 新增液态
                        if (mainproject.ParentID == 1)
                        {
                            int _ID = mainproject.ID;
                            if (mainproject.ParentID != 1)
                            {
                                GetParentID(mainproject.ParentID, helper, out _ID);
                            }
                            int SortBy = 0;
                            var project = Project.GetProjectByName(_ID, projectValue.title, helper, out SortBy);
                            if (project == null)
                            {
                                project = new Project();
                                project.Name = FormatProjectName(projectValue.title);
                                project.ParentID = mainproject.ID;
                                project.AddTime = DateTime.Now;
                                project.AddMan = AddMan;
                                project.TypeDesc = projectValue.title;
                                project.Level = 1;
                                project.Grade = "1";
                                project.OrderBy = projectValue.order;
                                project.DefaultOrder = GetDefaultOrder(project.OrderBy, mainproject.DefaultOrder);
                                project.IconID = 2;
                                project.PName = projectValue.title;
                                project.isParent = true;
                                project.CompanyID = CompanyID;
                                project.OriFullName = mainproject.OriFullName + "-" + project.Name;
                                project.AllParentID = GetALLParentID(mainproject);
                                project.FullName = GetFullName(project.OriFullName);
                                project.PropertyID = PropertyID;
                                project.RoomProperty = PropertyName;
                                project.Save(helper);
                                #region 资源权限
                                RoleProject.Save_RoleProject(role_can_add, user_can_add, RoleIDList, role_list, project.ID, user.UserID, helper);
                                #endregion
                            }
                            else
                            {
                                project.OrderBy = projectValue.order;
                                project.DefaultOrder = GetDefaultOrder(project.OrderBy, mainproject.DefaultOrder);
                                project.PropertyID = PropertyID;
                                project.RoomProperty = PropertyName;
                                project.Save(helper);
                            }
                            SaveProjectProperty(_ID, PropertyID, projectValue.order, helper);
                            mainproject = project;
                        }
                        #endregion
                        list = projectValue.list;
                        List<ProjectValues> toplist = list.Where(p => p.ParentID.Equals("0")).ToList();
                        for (int i = 0; i < toplist.Count; i++)
                        {
                            int MaxLevel = 0;
                            Project newproject = new Project();
                            if (!string.IsNullOrEmpty(toplist[i].Name))
                            {
                                var nextproject = Project.GetMaxProjectByParentID(mainproject.ID, toplist[i].TypeDesc, helper);
                                if (nextproject != null)
                                {
                                    MaxLevel = nextproject.Level;
                                }
                                int SortOrder = toplist[i].SortOrder > 0 ? toplist[i].SortOrder : (MaxLevel + 1);
                                newproject.Name = FormatProjectName(toplist[i].Name);
                                newproject.ParentID = mainproject.ID;
                                newproject.AddTime = DateTime.Now;
                                newproject.AddMan = AddMan;
                                newproject.TypeDesc = toplist[i].TypeDesc;
                                newproject.Level = (MaxLevel + 1);
                                newproject.OrderBy = SortOrder;
                                if (mainproject.IconID <= 2)
                                {
                                    newproject.Grade = newproject.Level.ToString();
                                }
                                else
                                {
                                    newproject.Grade = mainproject.Grade + "-" + newproject.Level.ToString();
                                }
                                newproject.DefaultOrder = GetDefaultOrder(newproject.OrderBy, mainproject.DefaultOrder);
                                newproject.OriFullName = mainproject.OriFullName + "-" + newproject.Name;
                                newproject.FullName = GetFullName(newproject.OriFullName);
                                //newproject.FullName = mainproject.FullName + "-" + newproject.Name;
                                newproject.IconID = mainproject.IconID + 1;
                                newproject.PName = mainproject.Name;
                                newproject.isParent = true;
                                newproject.CompanyID = CompanyID;
                                newproject.AllParentID = GetALLParentID(mainproject);
                                newproject.PropertyID = PropertyID;
                                newproject.RoomProperty = PropertyName;
                                newproject.Save(helper);
                            }
                            else
                            {
                                newproject = mainproject;
                            }
                            InsertSubProject(newproject, toplist[i].ID, string.Empty, CompanyID, CompanyName, PropertyID, PropertyName, helper, NewDefaultOrder: newproject.DefaultOrder);
                        }
                        helper.Commit();
                    }
                    catch (Exception ex)
                    {
                        helper.Rollback();
                        LogHelper.WriteError("ProjectHandler", "visit: SaveSubProject", ex);
                        context.Response.Write("3");
                        return;
                    }
                }
                Web.APPCode.CacheHelper.RemoveMyViewProjectTree();
                context.Response.Write("0");
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ProjectHandler", "visit: SaveSubProject", ex);
                context.Response.Write("3");
            }
        }
        private void SaveProjectProperty(int ProjectID, int PropertyID, int SortOrder, SqlHelper helper)
        {
            var projectProperty = Project_Property.GetProject_Property(ProjectID, PropertyID, helper);
            if (projectProperty == null)
            {
                projectProperty = new Project_Property();
                projectProperty.ProjectID = ProjectID;
                projectProperty.RelationID = PropertyID;
                projectProperty.AddTime = DateTime.Now;
            }
            projectProperty.SortOrder = SortOrder;
            projectProperty.IsHide = false;
            projectProperty.Save(helper);
        }
        public void GetParentID(int ID, SqlHelper helper, out int ParentID)
        {
            var project = Project.GetProject(ID, helper);
            ParentID = project.ID;
            if (project.ParentID == 1)
            {
                return;
            }
            GetParentID(project.ParentID, helper, out ParentID);
        }
        public void InsertSubProject(Project oldproject, string ParentID, string bakName, int CompanyID, string CompanyName, int PropertyID, string PropertyName, SqlHelper helper, string NewDefaultOrder = "")
        {
            ProjectValues newlist = list.FirstOrDefault(p => p.ParentID.Equals(ParentID));
            if (newlist == null)
            {
                oldproject.OriFullName = oldproject.OriFullName.Replace("-" + oldproject.Name, "");
                oldproject.FullName = GetFullName(oldproject.OriFullName);
                if (!string.IsNullOrEmpty(bakName))
                {
                    oldproject.Name = FormatProjectName(bakName);
                }
                oldproject.isParent = false;
                oldproject.DefaultOrder = NewDefaultOrder;
                oldproject.Save(helper);
                return;
            }
            if (newlist.Count == 0)
            {
                InsertSubProject(oldproject, newlist.ID, string.Empty, CompanyID, CompanyName, PropertyID, PropertyName, helper, NewDefaultOrder: NewDefaultOrder);
            }
            for (int i = 0; i < newlist.Count; i++)
            {
                string TypeDesc = newlist.Name;
                int MaxLevel = 0;
                var nextproject = Project.GetMaxProjectByParentID(oldproject.ID, TypeDesc, helper);
                if (nextproject != null)
                {
                    MaxLevel = nextproject.Level;
                }
                string level = (MaxLevel + 1).ToString();
                string Name = "第" + level + TypeDesc;
                int SortOrder = newlist.SortOrder > 0 ? newlist.SortOrder : (MaxLevel + 1);
                Project newproject = new Project();
                newproject.ParentID = oldproject.ID;
                newproject.Name = FormatProjectName(Name);
                newproject.AddTime = DateTime.Now;
                newproject.AddMan = oldproject.AddMan;
                newproject.TypeDesc = TypeDesc;
                newproject.Grade = oldproject.Grade + "-" + level;
                newproject.OrderBy = SortOrder;
                newproject.DefaultOrder = GetDefaultOrder(newproject.OrderBy, oldproject.DefaultOrder);
                newproject.IconID = oldproject.IconID + 1;
                newproject.Level = (MaxLevel + 1);
                newproject.PName = oldproject.Name;
                newproject.isParent = true;
                newproject.CompanyID = CompanyID;
                //newproject.FullName = oldproject.FullName + "-" + newproject.Name;
                newproject.OriFullName = oldproject.OriFullName + "-" + newproject.Name;
                newproject.FullName = GetFullName(newproject.OriFullName);
                newproject.AllParentID = GetALLParentID(oldproject);
                newproject.PropertyID = PropertyID;
                newproject.RoomProperty = PropertyName;
                newproject.Save(helper);
                if ((MaxLevel + 1) < 10)
                {
                    level = "0" + level;
                }
                string BakName = oldproject.Grade + level;
                InsertSubProject(newproject, newlist.ID, BakName, CompanyID, CompanyName, PropertyID, PropertyName, helper, NewDefaultOrder: newproject.DefaultOrder);
            }
        }
        private string GetFullName(string FullName)
        {
            return FullName;
            //return FullName.Replace("第", "").Replace("楼栋", "栋").Replace("楼层", "层");
        }
        private string FormatProjectName(string Name)
        {
            return Name.Replace("第", "").Replace("楼栋", "栋").Replace("楼层", "层");
        }
        private string GetALLParentID(Foresight.DataAccess.Project oldproject)
        {
            string allparentid = string.Empty;
            if (oldproject == null)
            {
                return ",1,";
            }
            if (oldproject.AllParentID.EndsWith(","))
            {
                allparentid = oldproject.AllParentID + oldproject.ID;
            }
            else
            {
                allparentid = oldproject.AllParentID + "," + oldproject.ID;
            }
            if (!allparentid.EndsWith(","))
            {
                allparentid = allparentid + ",";
            }
            return allparentid;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public class ProjectValueList
        {
            public int order { get; set; }
            public string title { get; set; }
            public List<ProjectValues> list { get; set; }
        }
        public class ProjectValues
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int SortOrder { get; set; }
            public int Count { get; set; }
            public string ParentID { get; set; }

            public string TypeDesc { get; set; }

            public string PName { get; set; }
        }
        public class ViewYT
        {
            public int order { get; set; }
            public string title { get; set; }
            public List<ViewName> list { get; set; }
        }
        public class ViewName
        {
            public string Name { get; set; }
        }
    }
}