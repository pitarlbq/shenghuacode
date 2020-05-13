using Foresight.DataAccess;
using Foresight.DataAccess.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Foresight.DataAccess.Framework;
using System.Data.SqlClient;
using System.Data;
using Utility;
using System.Web.SessionState;
using Encript;

namespace Web.Handler
{
    /// <summary>
    /// SysSettingHandler 的摘要说明
    /// </summary>
    public class SysSettingHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("SysSettingHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "gettablefield":
                        gettablefield(context);
                        break;
                    case "savetablefield":
                        savetablefield(context);
                        break;
                    case "getdefinefield":
                        getdefinefield(context);
                        break;
                    case "savedefinefield":
                        savedefinefield(context);
                        break;
                    case "removedefinefield":
                        removedefinefield(context);
                        break;
                    case "getdefinecontent":
                        getdefinecontent(context);
                        break;
                    case "getsysmenus":
                        getsysmenus(context);
                        break;
                    case "getmenubyid":
                        getmenubyid(context);
                        break;
                    case "savesysmenu":
                        savesysmenu(context);
                        break;
                    case "deletesysmenuimg":
                        deletesysmenuimg(context);
                        break;
                    case "deletesysmenus":
                        deletesysmenus(context);
                        break;
                    case "getmymenus":
                        getmymenus(context);
                        break;
                    case "getdepartmenttree":
                        getdepartmenttree(context);
                        break;
                    case "saveuserstaffdata":
                        saveuserstaffdata(context);
                        break;
                    case "saveordernumber":
                        saveordernumber(context);
                        break;
                    case "deleteordernumber":
                        deleteordernumber(context);
                        break;
                    case "loadordernumberlist":
                        loadordernumberlist(context);
                        break;
                    case "savemyseat":
                        savemyseat(context);
                        break;
                    case "saveimporttousudata":
                        saveimporttousudata(context);
                        break;
                    case "getsmssendmsgparam":
                        getsmssendmsgparam(context);
                        break;
                    case "sendsmsbytemplate":
                        sendsmsbytemplate(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SysSettingHandler", "命令:" + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        /// <summary>
        /// 选择发送短信模板
        /// </summary>
        /// <param name="context"></param>
        private void getsmssendmsgparam(HttpContext context)
        {
            var list = Sms_Tencent_Template.GetSms_Tencent_Templates().ToArray();
            var items = list.Select(p =>
            {
                var item = new { ID = p.ID, Name = p.TemplteTitle, content = p.TemplateContent };
                return item;
            }).ToArray();
            WebUtil.WriteJson(context, new { list = items });
        }
        /// <summary>
        /// 发送物业费通知短信
        /// </summary>
        private void sendsmsbytemplate(HttpContext context)
        {
            var IDList = Utility.JsonConvert.DeserializeObject<List<int>>(context.Request["IDList"]);
            bool IsSelectAll = WebUtil.GetBoolValue(context, "IsSelectAll");
            string Keyword = context.Request["Keyword"];
            int SendStatus = WebUtil.GetIntValue(context, "SendStatus");
            string ProjectName = context.Request["ProjectName"];
            DateTime StartTime = WebUtil.GetDateValue(context, "StartTime");
            DateTime EndTime = WebUtil.GetDateValue(context, "EndTime");
            int TemplateID = WebUtil.GetIntValue(context, "TemplateID");
            string errormsg = string.Empty;
            int RestCount = EncriptHelper.GetMySmsRestCount();
            if (RestCount <= 0)
            {
                WebUtil.WriteJson(context, new { status = false, error = "短信余额不足，请先充值" });
                return;
            }
            bool status = Sms_SendResult.Send_SmsTemplteMsg(IDList, StartTime, EndTime, TemplateID, WebUtil.GetUser(context).UserID, Keyword, ProjectName, SendStatus, IsSelectAll, ref errormsg, RestCount);
            WebUtil.WriteJson(context, new { status = status, error = errormsg });
        }
        private void saveimporttousudata(HttpContext context)
        {
            var list = SysConfig.GetSysConfigListByType("ServiceType");
            string ConfigType = "ServiceType";
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();

                    var name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypePaiDanTime;
                    var value = WebUtil.getServerValue(context, "tdPaiDanTime");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeResponseTime;
                    value = WebUtil.getServerValue(context, "tdResponseTime");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeCheckTime;
                    value = WebUtil.getServerValue(context, "tdCheckTime");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeChuliTime;
                    value = WebUtil.getServerValue(context, "tdChuliTime");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeBanJieTime;
                    value = WebUtil.getServerValue(context, "tdBanJieTime");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeGuanDanTime;
                    value = WebUtil.getServerValue(context, "tdGuanDanTime");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeHuiFangTime;
                    value = WebUtil.getServerValue(context, "tdHuiFangTime");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeDisableHolidayTime;
                    value = WebUtil.getServerValue(context, "tdDisableHolidayTime");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeDisableWorkOffTime;
                    value = WebUtil.getServerValue(context, "tdDisableWorkOffTime");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeStartHour;
                    value = WebUtil.getServerValue(context, "tdStartHour");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeEndHour;
                    value = WebUtil.getServerValue(context, "tdEndHour");
                    SysConfig.SaveSysConfigByType(list, name, value, helper, ConfigType: ConfigType);

                    helper.Commit();
                }
                catch (Exception)
                {
                    helper.Rollback();
                    WebUtil.WriteJson(context, new { status = false });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savemyseat(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int UserID = WebUtil.GetUser(context).UserID;
            var data = Seat.GetSeatByIDAndUserID(ID, UserID);
            if (data == null)
            {
                data = new Seat();
                data.AddTime = DateTime.Now;
                data.UserID = UserID;
                data.SeatStatus = 1;
                data.DriverStatus = WebUtil.GetIntValue(context, "driverStatus");
            }
            data.SeatName = WebUtil.getServerValue(context, "tdSeatName");
            data.RecordLocation = WebUtil.getServerValue(context, "tdRecordLocation");
            data.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void loadordernumberlist(HttpContext context)
        {
            try
            {
                var list = Sys_OrderNumber.GetSys_OrderNumbers();
                var dg = new DataGrid();
                dg.rows = list;
                dg.total = list.Count;
                dg.page = 1;
                string result = JsonConvert.SerializeObject(dg);
                context.Response.Write(result);
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("SysSettingHandler", "命令: loadordernumberlist", ex);
                context.Response.Write("{\"rows\":[],\"total\":0,\"page\":0}");
            }
        }
        private void deleteordernumber(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [Sys_OrderNumber] where ID in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: deleteordernumber", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void saveordernumber(HttpContext context)
        {
            string id = context.Request.Params["id"];
            string OrderTypeName = context.Request.Params["OrderTypeName"];
            int OrderNumberCount = int.Parse(context.Request.Params["OrderNumberCount"]);
            int UseYear = int.Parse(context.Request.Params["UseYear"]);
            int UseMonth = int.Parse(context.Request.Params["UseMonth"]);
            int UseDay = int.Parse(context.Request.Params["UseDay"]);
            int IsYearReset = WebUtil.GetIntValue(context, "IsYearReset");
            int IsMonthReset = WebUtil.GetIntValue(context, "IsMonthReset");
            int IsDayReset = WebUtil.GetIntValue(context, "IsDayReset");
            string Prefix = context.Request.Params["Prefix"];
            string OrderPreview = context.Request.Params["OrderPreview"];
            string Remark = context.Request.Params["Remark"];
            string AddMan = context.Request.Params["AddMan"];
            Sys_OrderNumber orderNumber = null;
            if (!string.IsNullOrEmpty(id))
            {
                orderNumber = Sys_OrderNumber.GetSys_OrderNumber(int.Parse(id));
            }
            if (orderNumber == null)
            {
                orderNumber = new Sys_OrderNumber();
            }
            orderNumber.OrderTypeName = OrderTypeName;
            orderNumber.OrderNumberCount = OrderNumberCount;
            orderNumber.UseYear = UseYear == 1 ? true : false;
            orderNumber.UseMonth = UseMonth == 1 ? true : false;
            orderNumber.UseDay = UseDay == 1 ? true : false;
            orderNumber.OrderPrefix = Prefix;
            orderNumber.OrderPreview = GenerateOrderPreview(orderNumber);
            orderNumber.Remark = Remark;
            orderNumber.AddMan = AddMan;
            orderNumber.ChargeType = WebUtil.GetIntValue(context, "ChargeType");
            orderNumber.IsYearReset = IsYearReset == 1 ? true : false;
            orderNumber.IsMonthReset = IsMonthReset == 1 ? true : false;
            orderNumber.IsDayReset = IsDayReset == 1 ? true : false;
            orderNumber.Save();
            context.Response.Write("{\"status\":true}");
        }
        private string GenerateOrderPreview(Sys_OrderNumber orderNumber)
        {
            string orderPreview = orderNumber.OrderPrefix;
            if (orderNumber.UseYear)
            {
                orderPreview += DateTime.Now.ToString("yyyy");
            }
            if (orderNumber.UseMonth)
            {
                orderPreview += DateTime.Now.ToString("MM");
            }
            if (orderNumber.UseDay)
            {
                orderPreview += DateTime.Now.ToString("dd");
            }
            Random ran = new Random();
            int start = Convert.ToInt32(Math.Pow(10, (orderNumber.OrderNumberCount - 1)));
            int end = Convert.ToInt32(Math.Pow(10, (orderNumber.OrderNumberCount))) - 1;
            orderPreview += ran.Next(start, end).ToString();
            return orderPreview;
        }
        private void saveuserstaffdata(HttpContext context)
        {
            int UserID = WebUtil.GetIntValue(context, "UserID");
            Foresight.DataAccess.User data = null;
            if (UserID > 0)
            {
                data = Foresight.DataAccess.User.GetUser(UserID);
            }
            if (data == null)
            {
                data = new User();
                data.CreateTime = DateTime.Now;
                data.Type = UserTypeDefine.APPUser.ToString();
            }
            data.LoginName = WebUtil.getServerValue(context, "tdLoginName");
            string Password = WebUtil.getServerValue(context, "tdPassword");
            if (!string.IsNullOrEmpty(Password))
            {
                data.Password = User.EncryptPassword(Password);
            }
            data.RealName = WebUtil.getServerValue(context, "tdRealName");
            data.PhoneNumber = WebUtil.getServerValue(context, "tdPhoneNumber");
            data.Gender = WebUtil.getServerValue(context, "tdGender");
            bool IsLocked = WebUtil.getServerIntValue(context, "tdIsLocked") == 1;
            if (IsLocked && !data.IsLocked)
            {
                data.LockTime = DateTime.Now;
            }
            if (!IsLocked && data.IsLocked)
            {
                data.ActiveTime = DateTime.Now;
            }
            data.IsLocked = IsLocked;
            int OrgID = WebUtil.getServerIntValue(context, "tdDepartment");
            UserDepartment org = null;
            if (OrgID > 0 && !data.Type.Equals(UserTypeDefine.SystemUser.ToString()))
            {
                org = UserDepartment.GetUserDepartment(UserID, OrgID);
                if (org == null)
                {
                    org = new UserDepartment();
                    org.DepartmentID = OrgID;
                }
            }
            data.ServiceFrom = WebUtil.getServerValue(context, "tdServiceFrom");
            data.PositionName = WebUtil.getServerValue(context, "tdPositionName");
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    data.Save(helper);
                    if (org != null)
                    {
                        org.UserID = data.UserID;
                        org.Save(helper);
                        var parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@UserID", data.UserID));
                        parameters.Add(new SqlParameter("@DepartmentID", org.DepartmentID));
                        helper.Execute("delete from [UserDepartment] where [UserID]=@UserID and [DepartmentID]!=@DepartmentID", CommandType.Text, parameters);
                    }
                    var userCompany = UserCompany.GetUserCompanyByUserID(data.UserID);
                    if (userCompany == null)
                    {
                        userCompany = new UserCompany();
                        userCompany.UserID = data.UserID;
                        userCompany.CompanyID = 1;
                        userCompany.Save(helper);
                    }
                    helper.Commit();
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    LogHelper.WriteError("SysSettingHandler", "saveuserdata", ex);
                    WebUtil.WriteJson(context, new { status = false, error = ex.Message });
                    return;
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getdepartmenttree(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var list = CKDepartment.GetCKDepartments().ToArray();
            var dic = new Dictionary<string, object>();
            var companyList = Foresight.DataAccess.Company.GetCompanyListByUserID(WebUtil.GetUser(context).UserID);
            var items = list.Where(p => companyList.Select(q => q.CompanyID).Contains(p.CompanyID)).Select(p =>
            {
                var type = "department";
                dic = new Dictionary<string, object>();
                dic["type"] = type;
                dic["name"] = p.DepartmentName;
                dic["id"] = type + "_" + p.ID;
                dic["pId"] = p.ParentID <= 1 ? "company_" + p.CompanyID : type + "_" + p.ParentID.ToString();
                dic["open"] = true;
                dic["ID"] = p.ID;
                dic["ParentID"] = p.ParentID;
                dic["CompanyID"] = p.CompanyID;
                return dic;
            }).ToList();
            var companyItems = companyList.Select(p =>
            {
                var type = "company";
                dic = new Dictionary<string, object>();
                dic["type"] = type;
                dic["name"] = p.CompanyName;
                dic["id"] = type + "_" + p.CompanyID;
                dic["pId"] = "0";
                dic["open"] = true;
                dic["ID"] = p.CompanyID;
                dic["ParentID"] = "0";
                dic["CompanyID"] = p.CompanyID;
                return dic;
            }).ToList();
            items.AddRange(companyItems);
            WebUtil.WriteJson(context, items);
        }
        private void getmymenus(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            if (ID < 0)
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            string GroupName = context.Request["GroupName"];
            string[] modulecodes = WebUtil.GetModuleCodes(context);
            GroupName = string.IsNullOrEmpty(GroupName) ? Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString() : GroupName;
            var modules = SysMenu.GetSysMenuForUser(WebUtil.GetUser(context).UserID, ID, GroupName: GroupName).Where(p => modulecodes.Contains(p.ModuleCode)).OrderBy(p => p.SortOrder);
            string context_path = WebUtil.getApplicationPath();
            var items = modules.Select(p =>
            {
                var item = p.ToJsonObject();
                item["IconPath"] = !string.IsNullOrEmpty(p.IconPath) ? context_path + p.IconPath : string.Empty;
                return item;
            });
            WebUtil.WriteJson(context, new { status = true, list = items });
        }
        private void deletesysmenus(HttpContext context)
        {
            string ids = context.Request.Params["ids"];
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(ids);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string cmdtext = "delete from [SysMenu] where [ID] in (" + string.Join(",", IDList.ToArray()) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    helper.Commit();
                    context.Response.Write("{\"status\":true}");
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: deletesysmenus", ex);
                    context.Response.Write("{\"status\":false}");
                }
            }
        }
        private void deletesysmenuimg(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int type = WebUtil.GetIntValue(context, "type");
            var menu = Foresight.DataAccess.SysMenu.GetSysMenu(ID);
            if (type == 1)
            {
                menu.IconPath = string.Empty;
            }
            else
            {
                menu.ImgUrl = string.Empty;
            }
            menu.Save();
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savesysmenu(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            int ParentID = WebUtil.GetIntValue(context, "ParentID");
            var MaxID = Foresight.DataAccess.SysMenu.GetSysMenus().Max(p => p.ID);
            var menu = Foresight.DataAccess.SysMenu.GetSysMenu(ID);
            if (menu == null)
            {
                menu = new SysMenu();
                menu.ID = (MaxID + 1);
                menu.ModuleCode = "1101" + menu.ID.ToString("D3");
            }
            if (ParentID > 0)
            {
                var parent_module = Foresight.DataAccess.SysMenu.GetSysMenu(ParentID);
                menu.GroupName = parent_module.GroupName;
            }
            else
            {
                string GroupName = context.Request["GroupName"];
                if (!string.IsNullOrEmpty(GroupName))
                {
                    menu.GroupName = GroupName;
                    menu.ParentID = 0;
                }
            }
            menu.Name = context.Request["Name"];
            menu.Title = menu.Name;
            menu.ParentID = ParentID;
            menu.IsAuthority = WebUtil.GetIntValue(context, "MenuType") != 1;
            menu.Url = context.Request["URL"];
            menu.UsingImgURL = WebUtil.GetIntValue(context, "UsingImgURL") == 1;
            menu.SortOrder = WebUtil.GetIntValue(context, "SortOrder");
            menu.Description = context.Request["Description"];
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    string fileOriName = postedFile.FileName;
                    if (fileOriName != "" && fileOriName != null)
                    {
                        string extension = System.IO.Path.GetExtension(fileOriName).ToLower();
                        string fileName = DateTime.Now.ToFileTime().ToString() + extension;
                        string filepath = "/upload/VersionMgr/";
                        string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                        if (!System.IO.Directory.Exists(rootPath))
                        {
                            System.IO.Directory.CreateDirectory(rootPath);
                        }
                        string Path = rootPath + fileName;
                        postedFile.SaveAs(Path);
                        if (i == 0)
                        {
                            menu.IconPath = filepath + fileName;
                        }
                        else
                        {
                            menu.ImgUrl = filepath + fileName;
                        }
                    }
                }
            }
            menu.Save();
            WebUtil.WriteJson(context, new { status = true, ID = menu.ID });
        }
        private void getmenubyid(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            var menu = Foresight.DataAccess.SysMenu.GetSysMenu(ID);
            string ParentName = string.Empty;
            if (menu.ParentID > 0)
            {
                var parent = Foresight.DataAccess.SysMenu.GetSysMenu(menu.ParentID);
                ParentName = parent.Name;
            }
            else if (!string.IsNullOrEmpty(menu.GroupName))
            {
                ParentName = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.SysMenuGroupNameDefine), menu.GroupName);
            }
            int MenuType = 2;
            if (!menu.IsAuthority)
            {
                MenuType = 1;
            }
            if (menu.IsAuthority && !string.IsNullOrEmpty(menu.Url))
            {
                MenuType = 3;
            }
            string IconPath = menu.IconPath;
            int SortOrder = menu.SortOrder > 0 ? menu.SortOrder : 0;
            int UsingImgURL = menu.UsingImgURL ? 1 : 0;
            IconPath = string.IsNullOrEmpty(IconPath) ? string.Empty : WebUtil.GetContextPath() + IconPath;
            string ImgUrl = menu.ImgUrl;
            ImgUrl = string.IsNullOrEmpty(ImgUrl) ? string.Empty : WebUtil.GetContextPath() + ImgUrl;
            var item = new { ID = menu.ID, Name = menu.Name, ParentName = ParentName, MenuType = MenuType, URL = menu.Url, IconPath = IconPath, SortOrder = SortOrder, UsingImgURL = UsingImgURL, ImgUrl = ImgUrl, Description = menu.Description, GroupName = menu.GroupName, ParentID = menu.ParentID, ModuleCode = menu.ModuleCode };
            WebUtil.WriteJson(context, new { status = true, menu = item });
        }
        private void getsysmenus(HttpContext context)
        {
            var menus = Foresight.DataAccess.SysMenu.GetSysMenus().Where(p => !p.Disabled).OrderBy(p => p.SortOrder);
            var items = menus.Select(p =>
            {
                var item = p.ToJsonObject();
                item["id"] = p.ID.ToString();
                if (p.ParentID == 0)
                {
                    if (!string.IsNullOrEmpty(p.GroupName))
                    {
                        item["pId"] = p.GroupName;
                    }
                    else
                    {
                        item["pId"] = Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString();
                    }
                }
                else
                {
                    item["pId"] = p.ParentID.ToString();
                }
                item["name"] = p.Title;
                return item;
            }).ToList();

            items.Add(AddSysMenuTree(Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString()));
            items.Add(AddSysMenuTree(Utility.EnumModel.SysMenuGroupNameDefine.appgl.ToString()));
            items.Add(AddSysMenuTree(Utility.EnumModel.SysMenuGroupNameDefine.jygl.ToString()));
            items.Add(AddSysMenuTree(Utility.EnumModel.SysMenuGroupNameDefine.jspt.ToString()));
            items.Add(AddSysMenuTree(Utility.EnumModel.SysMenuGroupNameDefine.sjzx.ToString()));
            items.Add(AddSysMenuTree(Utility.EnumModel.SysMenuGroupNameDefine.xtsz.ToString()));
            WebUtil.WriteJson(context, items);
        }
        private Dictionary<string, object> AddSysMenuTree(string id)
        {
            var dic = new Dictionary<string, object>();
            dic["id"] = id;
            dic["ID"] = 0;
            dic["pId"] = "0";
            dic["name"] = Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.SysMenuGroupNameDefine), id);
            return dic;
        }
        private void getdefinecontent(HttpContext context)
        {
            string TableName = context.Request["TableName"];
            if (string.IsNullOrEmpty(TableName))
            {
                WebUtil.WriteJson(context, new { status = false, msg = "TableName为空" });
                return;
            }
            var all_list = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0);
            var list = all_list.Where(p => string.IsNullOrEmpty(p.ColumnName)).ToArray();
            List<Dictionary<string, object>> list_dic = new List<Dictionary<string, object>>();
            if (TableName.Equals(Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString()))
            {
                int RoomID = WebUtil.GetIntValue(context, "RoomID");
                var basic_field_list = Foresight.DataAccess.RoomBasicField.GetRoomBasicFieldsByRoomID(RoomID);
                foreach (var item in list)
                {
                    var basic_field = basic_field_list.FirstOrDefault(p => p.FieldID == item.ID);
                    var dic = item.ToJsonObject();
                    dic["FieldContent"] = basic_field == null ? "" : basic_field.FieldContent;
                    list_dic.Add(dic);
                }
            }
            WebUtil.WriteJson(context, new { status = true, list = list_dic });
        }
        private void removedefinefield(HttpContext context)
        {
            int ID = WebUtil.GetIntValue(context, "ID");
            string TableName = context.Request["TableName"];
            if (TableName.Equals(Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString()))
            {
                var list = RoomBasicField.GetRoomBasicFieldsByFieldID(ID);
                if (list.Length > 0)
                {
                    WebUtil.WriteJson(context, new { status = false, msg = "该字段包含数据，禁止删除" });
                    return;
                }
                string cmdtext = "delete from RoomBasicField where FieldID=@FieldID and isnull(FieldContent,'')='';";
                cmdtext += "delete from DefineField where ID=@FieldID;";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@FieldID", ID));
                using (SqlHelper helper = new SqlHelper())
                {
                    try
                    {
                        helper.BeginTransaction();
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                        helper.Commit();
                    }
                    catch (Exception)
                    {
                        helper.Rollback();
                        WebUtil.WriteJson(context, new { status = false });
                        return;
                    }
                }
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void savedefinefield(HttpContext context)
        {
            string list = context.Request["list"];
            string TableName = context.Request["TableName"];
            List<Utility.BasicModel> ModelList = JsonConvert.DeserializeObject<List<Utility.BasicModel>>(list);
            foreach (var item in ModelList)
            {
                Foresight.DataAccess.DefineField define_field = null;
                if (item.id > 0)
                {
                    define_field = Foresight.DataAccess.DefineField.GetDefineField(item.id);
                }
                if (define_field == null)
                {
                    define_field = new DefineField();
                    define_field.AddTime = DateTime.Now;
                    define_field.IsShown = false;
                }
                define_field.FieldName = item.value;
                define_field.Table_Name = TableName;
                define_field.Save();
            }
            WebUtil.WriteJson(context, new { status = true });
        }
        private void getdefinefield(HttpContext context)
        {
            string TableName = context.Request["TableName"];
            if (string.IsNullOrEmpty(TableName))
            {
                WebUtil.WriteJson(context, new { status = false });
                return;
            }
            var all_list = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0, true);
            var list = all_list.Where(p => string.IsNullOrEmpty(p.ColumnName)).ToArray();
            var exist_list = all_list.Where(p => !string.IsNullOrEmpty(p.ColumnName)).ToArray();
            WebUtil.WriteJson(context, new { status = true, list = list, exist_list = exist_list });
        }
        private void savetablefield(HttpContext context)
        {
            string IDs = context.Request.Params["IDs"];
            string PageCode = context.Request.Params["PageCode"];
            string TableName = context.Request.Params["TableName"];
            string SortOrders = context.Request.Params["SortOrders"];
            string FieldIDs = context.Request.Params["FieldIDs"];
            int ColumnServiceStatus = WebUtil.GetIntValue(context, "ColumnServiceStatus");
            int ColumnServiceType = WebUtil.GetIntValue(context, "ColumnServiceType");
            List<int> IDList = JsonConvert.DeserializeObject<List<int>>(IDs);
            List<int> SortOrderList = JsonConvert.DeserializeObject<List<int>>(SortOrders);
            List<int> FieldIDList = JsonConvert.DeserializeObject<List<int>>(FieldIDs);
            int UserID = WebUtil.GetUser(context).UserID;
            var column_user_list = TableColumnsUser.GetTableColumnsUserListByUserID(UserID, ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType).ToList();
            var column_list = TableColumn.GetTableColumnByPageCode(PageCode, false, ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    string cmdwhere = string.Empty;
                    if (ColumnServiceStatus >= -1)
                    {
                        cmdwhere += " and ServiceStatus=@ServiceStatus";
                        parameters.Add(new SqlParameter("@ServiceStatus", ColumnServiceStatus));
                    }
                    if (ColumnServiceType >= -1)
                    {
                        cmdwhere += " and ServiceType=@ServiceType";
                        parameters.Add(new SqlParameter("@ServiceType", ColumnServiceType));
                    }
                    string cmdtext = "update [TableColumnsUser] set IsShown=0 where [UserID]=@UserID and [TableColumnID] in (select [ID] from [TableColumns] where PageCode=@PageCode) and [TableColumnID] not in (" + string.Join(",", IDList.ToArray()) + ") " + cmdwhere + ";";
                    parameters.Add(new SqlParameter("@PageCode", PageCode));
                    parameters.Add(new SqlParameter("@UserID", UserID));
                    helper.Execute(cmdtext, CommandType.Text, parameters);
                    foreach (var item in column_list)
                    {
                        var my_column_user = column_user_list.FirstOrDefault(p => p.TableColumnID == item.ID);
                        if (my_column_user == null)
                        {
                            my_column_user = new TableColumnsUser();
                            my_column_user.UserID = UserID;
                            my_column_user.TableColumnID = item.ID;
                            my_column_user.SortOrder = item.SortOrder;
                            my_column_user.IsShown = false;
                            my_column_user.Save(helper);
                            my_column_user.ServiceStatus = ColumnServiceStatus;
                            my_column_user.ServiceType = ColumnServiceType;
                            column_user_list.Add(my_column_user);
                        }
                    }
                    for (int i = 0; i < IDList.Count; i++)
                    {
                        int ID = IDList[i];
                        if (ID <= 0)
                        {
                            continue;
                        }
                        int SortOrder = SortOrderList[i];
                        var my_column_user = column_user_list.FirstOrDefault(p => p.TableColumnID == ID);
                        if (my_column_user == null)
                        {
                            my_column_user = new TableColumnsUser();
                            my_column_user.UserID = UserID;
                            my_column_user.TableColumnID = ID;
                            my_column_user.ServiceStatus = ColumnServiceStatus;
                            my_column_user.ServiceType = ColumnServiceType;
                        }
                        my_column_user.SortOrder = SortOrder;
                        my_column_user.IsShown = true;
                        my_column_user.Save(helper);
                    }
                    if (!string.IsNullOrEmpty(TableName))
                    {
                        if (TableName.Equals(Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString()))
                        {
                            cmdtext = " update [DefineField] set IsShown=0 where (Table_Name=@TableName or Table_Name='RoomPhoneRelation');";
                        }
                        else
                        {
                            cmdtext = " update [DefineField] set IsShown=0 where Table_Name=@TableName;";
                        }
                        for (int i = 0; i < FieldIDList.Count; i++)
                        {
                            if (FieldIDList[i] <= 0)
                            {
                                continue;
                            }
                            cmdtext += " update [DefineField] set IsShown=1,SortOrder=" + SortOrderList[i] + " where ID=" + FieldIDList[i] + ";";
                        }
                        parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@TableName", TableName));
                        helper.Execute(cmdtext, CommandType.Text, parameters);
                    }
                    helper.Commit();
                    WebUtil.WriteJson(context, new { status = true });
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                    Utility.LogHelper.WriteError("SysSettingHandler", "命令: savetablefield", ex);
                    WebUtil.WriteJson(context, new { status = false });
                }
            }
        }
        private void gettablefield(HttpContext context)
        {
            try
            {
                string PageCode = context.Request["PageCode"];
                string TableName = context.Request["TableName"];
                int ColumnServiceStatus = WebUtil.GetIntValue(context, "ColumnServiceStatus");
                int ColumnServiceType = WebUtil.GetIntValue(context, "ColumnServiceType");
                var list = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode(PageCode, false, ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType);
                var results = new List<Dictionary<string, object>>();
                var dic_list = new List<Dictionary<string, object>>();
                var dic = new Dictionary<string, object>();
                bool has_define_filed = false;
                if (string.IsNullOrEmpty(TableName))
                {
                    dic_list = list.Select(p =>
                    {
                        dic = p.ToJsonObject();
                        dic["FieldID"] = 0;
                        dic["GroupName"] = p.FinalGroupName;
                        return dic;
                    }).ToList();
                }
                else
                {
                    var all_fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0);
                    dic_list = list.Select(p =>
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
                       dic = p.ToJsonObject();
                       if (exist_field != null)
                       {
                           dic["FieldID"] = exist_field.ID;
                       }
                       else
                       {
                           dic["FieldID"] = 0;
                       }
                       dic["GroupName"] = p.FinalGroupName;
                       return dic;
                   }).ToList();
                    var fieldlist = all_fieldlist.Where(p => string.IsNullOrEmpty(p.ColumnName));
                    foreach (var item in fieldlist)
                    {
                        dic = new Dictionary<string, object>();
                        dic["ID"] = 0;
                        dic["FieldID"] = item.ID;
                        dic["PageCode"] = PageCode;
                        dic["ColumnField"] = "field: '" + item.FieldName + "', title: '" + item.FieldName + "', width: 150";
                        dic["SortOrder"] = item.SortOrder < 0 ? 0 : item.SortOrder;
                        dic["IsShown"] = item.IsShown;
                        dic["ColumnName"] = item.FieldName;
                        dic["GroupName"] = "自定义信息";
                        dic["IsNecessary"] = false;
                        dic_list.Add(dic);
                        has_define_filed = true;
                    }
                }
                dic_list = dic_list.OrderBy(p => p["SortOrder"]).ToList();
                var GroupNameArray = new List<string>();
                foreach (var item in dic_list)
                {
                    if (!item.ContainsKey("GroupName"))
                    {
                        continue;
                    }
                    string GroupName = item["GroupName"].ToString();
                    if (GroupName.Equals("自定义信息"))
                    {
                        continue;
                    }
                    if (!string.IsNullOrEmpty(GroupName) && !GroupNameArray.Contains(GroupName))
                    {
                        GroupNameArray.Add(GroupName);
                    }
                }
                foreach (var GroupName in GroupNameArray)
                {
                    dic = new Dictionary<string, object>();
                    dic["Title"] = GroupName;
                    var my_list = dic_list.Where(p => p["GroupName"].ToString().Equals(GroupName)).OrderBy(p => p["SortOrder"]).ToList();
                    dic["list"] = my_list;
                    results.Add(dic);
                }
                string DefaultGrounName = string.Empty;
                if (GroupNameArray.Count > 0)
                {
                    DefaultGrounName = "其他信息";
                }
                else if (has_define_filed)
                {
                    DefaultGrounName = "基本信息";
                }
                var other_list = dic_list.Where(p => string.IsNullOrEmpty(p["GroupName"].ToString())).OrderBy(p => p["SortOrder"]).ToList();
                dic = new Dictionary<string, object>();
                dic["Title"] = DefaultGrounName;
                dic["list"] = other_list;
                results.Add(dic);
                var define_list = dic_list.Where(p => p["GroupName"].ToString().Equals("自定义信息")).OrderBy(p => p["SortOrder"]).ToList();
                dic = new Dictionary<string, object>();
                dic["Title"] = "自定义信息";
                dic["list"] = define_list;
                results.Add(dic);
                var items = new
                {
                    status = true,
                    list = results,
                };
                WebUtil.WriteJson(context, items);
            }
            catch (Exception)
            {
                var items = new
                {
                    status = false,
                };
                context.Response.Write(JsonConvert.SerializeObject(items));
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    public class ChargeBiaoModel
    {
        public int ID { get; set; }
        public string BiaoCategory { get; set; }
    }
}