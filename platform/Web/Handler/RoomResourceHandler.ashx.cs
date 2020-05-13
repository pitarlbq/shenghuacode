using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using Foresight.DataAccess.Ui;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// RoomResourceHandler 的摘要说明
    /// </summary>
    public class RoomResourceHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("RoomResourceHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "loadroomresourcelist":
                        LoadRoomResourceList(context);
                        break;
                    case "saveroomresource":
                        saveroomresource(context);
                        break;
                    case "loadroomproperty":
                        LoadRoomProperty(context);
                        break;
                    case "loadlrelatefamily":
                        LoadlRelateFamily(context);
                        break;
                    case "saveroomphonefamily":
                        saveroomphonefamily(context);
                        break;
                    case "deletefamily":
                        DeleteFamily(context);
                        break;
                    case "loadlrelateroomresource":
                        LoadlRelateRoomResource(context);
                        break;
                    case "addrelatesource":
                        AddRelateSource(context);
                        break;
                    case "saveshowlevel":
                        SaveShowLevel(context);
                        break;
                    case "loadtablecolumn":
                        loadtablecolumn(context);
                        break;
                    case "savefamilyphoto":
                        savefamilyphoto(context);
                        break;
                    case "getroomstate":
                        getroomstate(context);
                        break;
                    case "saveroomstate":
                        saveroomstate(context);
                        break;
                    case "savecomboboxroomstate":
                        savecomboboxroomstate(context);
                        break;
                    case "savecomboboxroomtype":
                        savecomboboxroomtype(context);
                        break;
                    case "savecomboboxroomproperty":
                        savecomboboxroomproperty(context);
                        break;
                    case "deletecomboboxroomstate":
                        deletecomboboxroomstate(context);
                        break;
                    case "deletecomboboxroomtype":
                        deletecomboboxroomtype(context);
                        break;
                    case "deletecomboboxroomproperty":
                        deletecomboboxroomproperty(context);
                        break;
                    case "getthridcustomergrid":
                        getthridcustomergrid(context);
                        break;
                    case "savethirdcustomer":
                        savethirdcustomer(context);
                        break;
                    case "doremovethridcustomer":
                        doremovethridcustomer(context);
                        break;
                    case "getthirdprojectlist":
                        getthirdprojectlist(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:" + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void getthirdprojectlist(HttpContext context)
        {
            var list = ThirdCustomer.GetThirdProjectList();
            WebUtil.WriteJson(context, new { list = list });
        }
        private void doremovethridcustomer(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            ThirdCustomer.DeleteThirdCustomer(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savethirdcustomer(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            ThirdCustomer data = null;
            if (ID > 0)
            {
                data = ThirdCustomer.GetThirdCustomer(ID);
            }
            if (data == null)
            {
                data = new ThirdCustomer();
                data.AddTime = DateTime.Now;
                data.AddUserID = WebUtil.GetUser(context).UserID;
            }
            data.ProjectName = context.Request["ProjectName"];
            data.RoomName = context.Request["RoomName"];
            data.CustomerName = context.Request["CustomerName"];
            data.PhoneNumber = context.Request["PhoneNumber"];
            data.SignDate = WebUtil.GetDateValue(context, "SignDate");
            var existData = ThirdCustomer.GetThirdCustomerByPhone(data.PhoneNumber);
            if (existData.ID != data.ID)
            {
                WebUtil.WriteJson(context, new { status = false, error = "手机号码重复，请检查" });
                return;
            }
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getthridcustomergrid(HttpContext context)
        {
            string page = context.Request.Form["page"];
            string rows = context.Request.Form["rows"];
            long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
            int pageSize = int.Parse(rows);
            string Keywords = context.Request["Keywords"];
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int SendStatus = WebUtil.GetIntValue(context, "SendStatus");
            string ProjectName = context.Request["ProjectName"];

            bool canexport = WebUtil.GetBoolValue(context, "canexport");
            DataGrid dg = ThirdCustomer.GetThirdCustomerListByKeywords(Keywords, StartTime, EndTime, SendStatus, ProjectName, "order by LastSendTime desc,ID desc", startRowIndex, pageSize, canexport: canexport);
            if (canexport)
            {
                bool isTemplate = WebUtil.GetIntValue(context, "istemplate") == 1;
                string downloadurl = string.Empty;
                string error = string.Empty;
                bool status = APPCode.ExportHelper.DownLoadThirdCustomerData(dg, isTemplate, out downloadurl, out error);
                WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
            }
            else
            {
                WebUtil.WriteJson(context, dg);
            }
        }
        private void deletecomboboxroomproperty(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.RoomBasic.GetRoomBasicListByParams(null, null, new int[] { ID });
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "房源属性使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.RoomProperty.DeleteRoomProperty(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletecomboboxroomtype(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.RoomBasic.GetRoomBasicListByParams(null, new int[] { ID }, null);
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "房间类型使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.RoomType.DeleteRoomType(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void deletecomboboxroomstate(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = Foresight.DataAccess.RoomBasic.GetRoomBasicListByParams(new int[] { ID }, null, null);
            if (list.Length > 0)
            {
                WebUtil.WriteJson(context, new { status = false, msg = "房间状态使用中，禁止删除" });
                return;
            }
            Foresight.DataAccess.RoomState.DeleteRoomState(ID);
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecomboboxroomproperty(HttpContext context)
        {
            string liststr = context.Request["list"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            List<Utility.BasicModel> list = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(liststr);
            foreach (var item in list)
            {
                Foresight.DataAccess.RoomProperty roomproperty = null;
                if (item.id > 0)
                {
                    roomproperty = Foresight.DataAccess.RoomProperty.GetRoomProperty(item.id);
                }
                if (roomproperty == null)
                {
                    roomproperty = new RoomProperty();
                }
                roomproperty.Name = item.value;
                roomproperty.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecomboboxroomtype(HttpContext context)
        {
            string liststr = context.Request["list"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            List<Utility.BasicModel> list = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(liststr);
            foreach (var item in list)
            {
                Foresight.DataAccess.RoomType roomtype = null;
                if (item.id > 0)
                {
                    roomtype = Foresight.DataAccess.RoomType.GetRoomType(item.id);
                }
                if (roomtype == null)
                {
                    roomtype = new RoomType();
                }
                roomtype.RoomTypeName = item.value;
                roomtype.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savecomboboxroomstate(HttpContext context)
        {
            string liststr = context.Request["list"];
            if (string.IsNullOrEmpty(liststr))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "参数错误" });
                return;
            }
            List<Utility.BasicModel> list = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(liststr);
            foreach (var item in list)
            {
                Foresight.DataAccess.RoomState state = null;
                if (item.id > 0)
                {
                    state = Foresight.DataAccess.RoomState.GetRoomState(item.id);
                }
                if (state == null)
                {
                    state = new RoomState();
                }
                state.Name = item.value;
                state.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveroomstate(HttpContext context)
        {
            string roomstates = context.Request["roomstates"];
            List<Utility.RoomStateModel> list = new List<Utility.RoomStateModel>();
            if (!string.IsNullOrEmpty(roomstates))
            {
                list = JsonConvert.DeserializeObject<List<Utility.RoomStateModel>>(roomstates);
            }
            var roomstatelist = Foresight.DataAccess.RoomState.GetRoomStates();
            foreach (var item in list)
            {
                var data = roomstatelist.FirstOrDefault(p => p.Name.Equals(item.Name));
                if (data == null)
                {
                    continue;
                }
                data.BackColor = item.BackColor;
                data.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getroomstate(HttpContext context)
        {
            var list = Foresight.DataAccess.RoomState.GetRoomStates().OrderBy(p => p.SortOrder).OrderBy(p => p.ID);
            var results = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.Name, BackColor = p.BackColor };
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = results });
        }
        private void savefamilyphoto(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var relation = RoomPhoneRelation.GetRoomPhoneRelation(ID);
            HttpFileCollection uploadFiles = context.Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];
                string fileOriName = postedFile.FileName;
                if (fileOriName != "" && fileOriName != null)
                {
                    string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                    string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                    string filepath = "/upload/Family/";
                    string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                    if (!System.IO.Directory.Exists(rootPath))
                    {
                        System.IO.Directory.CreateDirectory(rootPath);
                    }
                    string Path = rootPath + fileName;
                    postedFile.SaveAs(Path);
                    relation.HeadImg = filepath + fileName;
                    relation.Save();
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadtablecolumn(HttpContext context)
        {
            string pagecode = context.Request["pagecode"];
            string TableName = context.Request["TableName"];
            int ColumnServiceStatus = WebUtil.GetIntValue(context, "ColumnServiceStatus");
            int ColumnServiceType = WebUtil.GetIntValue(context, "ColumnServiceType");
            var list = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode(pagecode, true, ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType);
            var results = new List<Dictionary<string, object>>();
            if (string.IsNullOrEmpty(TableName))
            {
                results = list.Select(p =>
                {
                    var dic = p.ToJsonObject();
                    dic["FieldID"] = 0;
                    return dic;
                }).ToList();
            }
            else
            {
                var all_fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0);
                results = list.Select(p =>
               {
                   if (p.ColumnName.StartsWith("业主自定义"))
                   {
                       p.ColumnName = p.ColumnName.Replace("业主", "");
                   }
                   var exist_fieldlist = all_fieldlist.Where(q => !string.IsNullOrEmpty(q.ColumnName));
                   var exist_field = exist_fieldlist.FirstOrDefault(q => q.OriFieldName.Equals(p.ColumnName));
                   if (exist_field != null)
                   {
                       p.ColumnField = p.ColumnField.Replace(p.ColumnName, exist_field.FieldName);
                       p.ColumnName = exist_field.FieldName;
                   }
                   var dic = p.ToJsonObject();
                   dic["FieldID"] = 0;
                   return dic;
               }).ToList();

                var fieldlist = all_fieldlist.Where(p => string.IsNullOrEmpty(p.ColumnName) && p.IsShown);
                foreach (var item in fieldlist)
                {
                    var dic = new Dictionary<string, object>();
                    dic["ID"] = 0;
                    dic["FieldID"] = item.ID;
                    dic["PageCode"] = pagecode;
                    dic["ColumnField"] = "field: '" + item.FieldName + "', title: '" + item.FieldName + "', width: 150";
                    dic["SortOrder"] = item.SortOrder < 0 ? 0 : item.SortOrder;
                    dic["IsShown"] = item.IsShown;
                    dic["ColumnName"] = item.FieldName;
                    results.Add(dic);
                }
            }
            results = results.OrderBy(p => p["SortOrder"]).ToList();
            int ChargeID = 0;
            int.TryParse(context.Request.Params["ChargeID"], out ChargeID);
            StringBuilder columns = new StringBuilder("[[");
            foreach (var item in results)
            {
                columns.Append("{" + item["ColumnField"] + "},");
            }
            if (results.Count > 0)
            {
                columns.Remove(columns.Length - 1, 1);
            }
            columns.Append("]]");
            var items = new
            {
                status = results.Count > 0 ? true : false,
                columns = columns.ToString(),
            };
            WebUtil.WriteJson(context, items);
        }
        private void SaveShowLevel(HttpContext context)
        {
            int LevelID = int.Parse(context.Request.Params["LevelID"]);
            int CompanyID = int.Parse(context.Request.Params["CompanyID"]);
            var treeExpandLevel = Foresight.DataAccess.TreeExpandLevel.GetTreeExpandLevelByCompanyID(CompanyID);
            if (treeExpandLevel == null)
            {
                treeExpandLevel = new TreeExpandLevel();
                treeExpandLevel.CompanyID = CompanyID;
            }
            treeExpandLevel.LevelID = LevelID;
            treeExpandLevel.Save();
            context.Response.Write("{\"status\":true}");
        }
        private void AddRelateSource(HttpContext context)
        {
            int RoomID = 0;
            int.TryParse(context.Request.Params["RoomID"], out RoomID);
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            context.Response.Write("{\"status\":true}");
        }
        private void LoadlRelateRoomResource(HttpContext context)
        {
            try
            {
                int RoomID = int.Parse(context.Request.Params["RoomID"]);
                string Keywords = context.Request.Params["Keywords"];
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                bool loadIn = bool.Parse(context.Request.Params["loadIn"]);
                DataGrid dg = ViewRoomBasic.GetProjectDetailsGridByRoomID(RoomID, loadIn, Keywords, "order by RoomID asc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);

            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:LoadlRelateRoomResource", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void DeleteFamily(HttpContext context)
        {
            string IDs = context.Request.Params["IDList"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    string cmdtext = "delete from [RoomPhoneRelation] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("RoomResourceHandler", "命令:DeleteFamily", ex);
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            #region 删除日志
            var user = WebUtil.GetUser(context);
            APPCode.CommHelper.SaveOperationLog(string.Join(",", IDList.ToArray()), Utility.EnumModel.OperationModule.RoomPhoneRelationDelete.ToString(), "住户删除", user.UserID.ToString(), "RoomPhoneRelation", user.LoginName, IsHide: true);
            APPCode.CommHelper.SaveOperationLog("用户" + user.LoginName + "删除了住户", Utility.EnumModel.OperationModule.RoomPhoneRelationDelete.ToString(), "住户删除", user.UserID.ToString(), "RoomPhoneRelation", user.LoginName, IsHide: true);
            #endregion
            WebUtil.WriteJson(context, new { status = true });
        }
        private void saveroomphonefamily(HttpContext context)
        {
            int ID = GetIntValue(context, "ID");
            int RoomID = GetIntValue(context, "RoomID");
            RoomPhoneRelation relation = null;
            if (ID > 0)
            {
                relation = RoomPhoneRelation.GetRoomPhoneRelation(ID);
            }
            if (relation == null)
            {
                relation = new RoomPhoneRelation();
                relation.AddTime = DateTime.Now;
                relation.RoomID = RoomID;
            }
            relation.RelationProperty = WebUtil.getServerValue(context, "tdRelationProperty");
            relation.RelationType = WebUtil.getServerValue(context, "tdRelationType");
            relation.CompanyName = WebUtil.getServerValue(context, "tdCompanyName");
            relation.RelationName = WebUtil.getServerValue(context, "tdRelateName");
            relation.RelatePhoneNumber = WebUtil.getServerValue(context, "tdRelatePhone");
            relation.IsDefault = WebUtil.getServerIntValue(context, "tdIsDefault") == 1;
            relation.IDCardType = WebUtil.getServerIntValue(context, "tdIDCardType");
            relation.RelationIDCard = WebUtil.getServerValue(context, "tdRelateIDCard");
            relation.Remark = WebUtil.getServerValue(context, "tdRemark");
            string cmdtext = string.Empty;
            if (relation.IsDefault)
            {
                cmdtext += "update [RoomPhoneRelation] set [IsDefault]=0 where RoomID=@RoomID and ID!=@RelationID;";
            }
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    relation.Save(helper);
                    if (!string.IsNullOrEmpty(cmdtext))
                    {
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@RoomID", relation.RoomID));
                        parameters.Add(new SqlParameter("@RoomOwner", relation.RelationName));
                        parameters.Add(new SqlParameter("@OwnerPhone", relation.RelatePhoneNumber));
                        parameters.Add(new SqlParameter("@OwnerIDCard", relation.RelationIDCard));
                        parameters.Add(new SqlParameter("@RelationID", relation.ID > 0 ? relation.ID : 0));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true, ID = relation.ID });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("RoomResourceHandler", "命令:saveroomphonefamily", ex);
                    context.Response.Write("{\"status\":false}");
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void LoadlRelateFamily(HttpContext context)
        {
            try
            {
                int RoomID = int.Parse(context.Request.Params["RoomID"]);
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                string RelationType = context.Request.Params["RelationType"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                DataGrid dg = RoomPhoneRelation.GetRoomPhoneRelationGridByRoomID(RoomID, RelationType, "order by ID asc", startRowIndex, pageSize);
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:LoadlRelateFamily", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void LoadRoomProperty(HttpContext context)
        {
            try
            {
                RoomProperty[] property = RoomProperty.GetRoomProperties().ToArray();
                string result = JsonConvert.SerializeObject(property);
                context.Response.Write("{\"status\":true,\"list\":" + result + "}");
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:LoadRoomProperty", ex);
                context.Response.Write("{\"status\":false,\"list\":[]}");
            }
        }
        private void saveroomresource(HttpContext context)
        {
            int RoomID = WebUtil.GetIntValue(context, "RoomID");
            Project project = Project.GetProject(RoomID);
            if (project == null)
            {
                WebUtil.WriteJson(context, new { status = false, error = "房间不存在" });
                return;
            }
            RoomBasic basic = RoomBasic.GetRoomBasicByRoomID(RoomID);
            string list = context.Request["FieldList"];
            List<Utility.BasicModel> ModelList = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(list);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    project.Name = WebUtil.getServerValue(context, "tbRoomName");
                    int SortOrder = WebUtil.getServerIntValue(context, "tdSortOrder");
                    if (!string.IsNullOrEmpty(project.DefaultOrder))
                    {
                        string NewDefaultOrder = string.Empty;
                        string[] SortOrderArray = project.DefaultOrder.Split('-');
                        for (int i = 0; i < SortOrderArray.Length; i++)
                        {
                            if (i != SortOrderArray.Length - 1)
                            {
                                NewDefaultOrder += SortOrderArray[i] + "-";
                            }
                            else
                            {
                                NewDefaultOrder += SortOrder.ToString("D3");
                            }
                        }
                        project.DefaultOrder = NewDefaultOrder;
                    }
                    project.Save(helper);
                    if (basic == null)
                    {
                        basic = new RoomBasic();
                        basic.RoomID = project.ID;
                        basic.AddTime = DateTime.Now;
                    }
                    basic.BuildingNumber = WebUtil.getServerValue(context, "tbBuildingNumber");
                    basic.SignDate = WebUtil.getServerTimeValue(context, "tdSignDate");
                    basic.PaymentTime = WebUtil.getServerTimeValue(context, "tbPaymentTime");
                    basic.CertificateTime = WebUtil.getServerTimeValue(context, "tdCertificateTime");
                    basic.RoomType = WebUtil.getServerValue(context, "tbRoomType");
                    basic.IsJingZhuangXiu = WebUtil.getServerIntValue(context, "tdIsJingZhuangXiu");
                    basic.BuildingOutArea = WebUtil.getServerDecimalValue(context, "tdBuildingOutArea");
                    basic.Save(helper);
                    if (ModelList.Count > 0)
                    {
                        foreach (var item in ModelList)
                        {
                            if (item.id <= 0)
                            {
                                continue;
                            }
                            var roombasic_field = RoomBasicField.GetRoomBasicFieldByRoomIDandFieldID(RoomID, item.id, helper);
                            if (roombasic_field == null)
                            {
                                roombasic_field = new RoomBasicField();
                                roombasic_field.AddTime = DateTime.Now;
                            }
                            roombasic_field.RoomID = RoomID;
                            roombasic_field.FieldID = item.id;
                            roombasic_field.FieldContent = item.value;
                            roombasic_field.Save(helper);
                        }
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("RoomResourceHandler", "命令:saveroomresource", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void LoadRoomResourceList(HttpContext context)
        {
            try
            {
                string page = context.Request.Form["page"];
                string rows = context.Request.Form["rows"];
                string ProjectIDs = context.Request.Params["ProjectID"];
                string RoomIDs = context.Request.Params["RoomID"];
                List<int> RoomIDList = new List<int>();
                if (!string.IsNullOrEmpty(RoomIDs))
                {
                    RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
                }
                List<int> ProjectIDList = new List<int>();
                if (RoomIDList.Count == 0)
                {
                    if (!string.IsNullOrEmpty(ProjectIDs))
                    {
                        ProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                    }
                    ProjectIDList = WebUtil.GetMyProjects(WebUtil.GetUser(context).UserID, ProjectIDList).Where(p => p.ID != 1).Select(p => p.ID).ToList();
                }
                string OwnerName = context.Request.Params["OwnerName"];
                string OwnerPhoneNumber = context.Request.Params["OwnerPhoneNumber"];
                string Keywords = context.Request.Params["Keywords"];
                long startRowIndex = (long.Parse(page) - 1) * long.Parse(rows);
                int pageSize = int.Parse(rows);
                string SearchAreas = context.Request.Params["SearchAreas"];
                List<string> SearchAreaList = new List<string>();
                if (!string.IsNullOrEmpty(SearchAreas))
                {
                    SearchAreaList = JsonConvert.DeserializeObject<List<string>>(SearchAreas);
                }
                bool canexport = WebUtil.GetBoolValue(context, "canexport");
                int CompanyID = WebUtil.GetIntValue(context, "CompanyID");
                DataGrid dg = ViewRoomBasic.GetRoomBasicListByKeywords(RoomIDList, ProjectIDList, OwnerName, OwnerPhoneNumber, Keywords, SearchAreaList, "order by DefaultOrder asc", startRowIndex, pageSize, canexport: canexport, CompanyID: CompanyID);
                if (canexport)
                {
                    string downloadurl = string.Empty;
                    string error = string.Empty;
                    bool status = APPCode.ExportHelper.DownLoadRoomSourceData(dg, out downloadurl, out error);
                    WebUtil.WriteJson(context, new { status = status, downloadurl = downloadurl, error = error });
                }
                else
                {
                    WebUtil.WriteJson(context, dg);
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("RoomResourceHandler", "命令:LoadRoomResourceList", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private decimal GetDecimalValue(HttpContext context, string param)
        {
            decimal value = 0;
            decimal.TryParse(context.Request.Params[param], out value);
            return value;
        }
        private int GetIntValue(HttpContext context, string param)
        {
            int value = 0;
            int.TryParse(context.Request.Params[param], out value);
            return value;
        }
        private DateTime GetDateValue(HttpContext context, string param)
        {
            DateTime value = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params[param], out value);
            return value;
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