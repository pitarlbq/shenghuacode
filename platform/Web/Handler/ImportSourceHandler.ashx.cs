using ExcelProcess;
using Foresight.DataAccess;
using Foresight.DataAccess.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace Web.Handler
{
    /// <summary>
    /// ImportHandler 的摘要说明
    /// </summary>
    public class ImportSourceHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string visit = context.Request.Params["visit"];
            if (string.IsNullOrEmpty(visit))
            {
                LogHelper.WriteDebug("ImportSourceHandler", "visit为空");
                context.Response.Write(null);
                return;
            }
            visit = visit.ToLower();
            try
            {
                switch (visit)
                {
                    case "importroomsource":
                        importroomsource(context);
                        break;
                    case "importthirdcustomer":
                        importthirdcustomer(context);
                        break;
                    default:
                        WebUtil.WriteJsonError(context, ErrorCode.InvalideRequest, "Unkown Visit: " + visit);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("ImportSourceHandler", "visit: " + visit, ex);
                context.Response.Write("{\"status\":false}");
            }
        }
        private void importthirdcustomer(HttpContext context)
        {
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count == 0)
            {
                context.Response.Write("请选择一个文件");
                return;
            }
            if (string.IsNullOrEmpty(uploadFiles[0].FileName))
            {
                context.Response.Write("请选择一个文件");
                return;
            }
            HttpPostedFile postedFile = uploadFiles[0];
            string filepath = HttpContext.Current.Server.MapPath("~/upload/ImportRoomSource/" + DateTime.Now.ToString("yyyyMMdd"));
            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }
            string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
            string fullpath = Path.Combine(filepath, filename);
            postedFile.SaveAs(fullpath);
            DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
            string msg = string.Empty;
            int count = 0;
            var user = WebUtil.GetUser(context);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    #region 导入处理
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        count = i;
                        ThirdCustomer data = null;
                        string PhoneNumber = table.Rows[i]["手机号码"].ToString();
                        if (string.IsNullOrEmpty(PhoneNumber))
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：手机号码为空</p>";
                            continue;
                        }
                        object Value = table.Rows[i]["ID"];
                        int ID = 0;
                        if (Value != null)
                        {
                            int.TryParse(Value.ToString(), out ID);
                        }
                        if (ID > 0)
                        {
                            data = Foresight.DataAccess.ThirdCustomer.GetThirdCustomer(ID, helper);
                        }
                        if (data == null)
                        {
                            data = ThirdCustomer.GetThirdCustomerByPhone(PhoneNumber, helper);
                        }
                        if (data == null)
                        {
                            data = new ThirdCustomer();
                            data.AddTime = DateTime.Now;
                            data.AddUserID = user.UserID;
                        }
                        data.PhoneNumber = PhoneNumber;
                        data.CustomerName = table.Rows[i]["项目名称"].ToString();
                        data.ProjectName = table.Rows[i]["姓名"].ToString();
                        data.RoomName = table.Rows[i]["资源编号"].ToString();
                        data.SignDate = WebUtil.GetDateTimeByStr(table.Rows[i]["签约日期"].ToString());
                        data.Save(helper);
                    }
                    #endregion
                    helper.Commit();
                    msg += "<p>导入完成</p>";
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("ImportSourceHandler", "visit: importroomsource", ex);
                    msg = "导入失败，第" + (count + 2) + "行数据有问题，导入取消";
                    helper.Rollback();
                }
            }
            context.Response.Write(msg);
        }
        private decimal GetDecimalValue(object value)
        {
            decimal result = 0;
            decimal.TryParse(value.ToString(), out result);
            return result;
        }
        private DateTime GetDateTimeValue(object value)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(value.ToString(), out result);
            return result;
        }
        private bool GetColumnValue(string Title, DataTable table, int index, out object Value)
        {
            Value = null;
            bool result = false;
            if (!table.Columns.Contains(Title))
            {
                return false;
            }
            for (int i = 0; i < titleList.Count; i++)
            {
                if (titleList[i]["ColumnName"].Equals(Title))
                {
                    DataRow dr = table.Rows[index];
                    if (dr == null)
                    {
                        return false;
                    }
                    Value = dr[Title];
                    result = true;
                    break;
                }
            }
            return result;
        }
        List<Dictionary<string, object>> titleList = new List<Dictionary<string, object>>();
        private void importroomsource(HttpContext context)
        {
            HttpFileCollection uploadFiles = context.Request.Files;
            if (uploadFiles.Count == 0)
            {
                context.Response.Write("请选择一个文件");
                return;
            }
            if (string.IsNullOrEmpty(uploadFiles[0].FileName))
            {
                context.Response.Write("请选择一个文件");
                return;
            }
            HttpPostedFile postedFile = uploadFiles[0];
            string filepath = HttpContext.Current.Server.MapPath("~/upload/ImportRoomSource/" + DateTime.Now.ToString("yyyyMMdd"));
            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }
            string filename = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmss") + "_" + postedFile.FileName;
            string fullpath = Path.Combine(filepath, filename);
            postedFile.SaveAs(fullpath);
            string msg = string.Empty;
            DataTable table = ExcelExportHelper.NPOIReadExcel(fullpath);
            if (!table.Columns.Contains("资源ID"))
            {
                msg += "<p>导入失败，原因：资源ID列不存在</p>";
                WebUtil.WriteJson(context, msg);
                return;
            }
            int MinID = table.Select().Min(r =>
            {
                int ID = 0;
                if (r.Field<object>("资源ID") != null)
                {
                    int.TryParse(r.Field<object>("资源ID").ToString(), out ID);
                }
                return ID;
            });
            int MaxID = table.Select().Max(r =>
            {
                int ID = 0;
                if (r.Field<object>("资源ID") != null)
                {
                    int.TryParse(r.Field<object>("资源ID").ToString(), out ID);
                }
                return ID;
            });
            string TableName = Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString();
            string TableName_Relation = Utility.EnumModel.DefineFieldTableName.RoomPhoneRelation.ToString();
            string isconver = context.Request["isconver"];
            bool ImportFailed = false;
            int count = 0;
            var comm_helper = new APPCode.CommHelper();
            titleList = GetTableColumns();
            var basicList = RoomBasic.GetRoomBasicListByMinMaxRoomID(MinID, MaxID);
            var phoneList = RoomPhoneRelation.GetRoomPhoneRelationListByMinMaxRoomID(MinID, MaxID);
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    #region 导入处理
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        count = i;
                        Project project = null;
                        object Value = table.Rows[i]["资源ID"];
                        int RoomID = 0;
                        if (Value != null)
                        {
                            int.TryParse(Value.ToString(), out RoomID);
                        }
                        if (RoomID > 0)
                        {
                            project = Foresight.DataAccess.Project.GetProject(RoomID, helper);
                        }
                        if (project == null)
                        {
                            msg += "<p>第" + (i + 2) + "行上传失败。原因：所属项目不存在</p>";
                            ImportFailed = true;
                            break;
                        }
                        if (GetColumnValue("房号", table, i, out Value))
                        {
                            project.Name = Value.ToString().Trim();
                        }
                        project.Save(helper);
                        RoomBasic basic = basicList.FirstOrDefault(p => p.RoomID == project.ID);
                        if (isconver.Equals("0") && basic != null)
                        {
                            continue;
                        }
                        if (basic == null)
                        {
                            basic = new RoomBasic();
                            basic.RoomID = project.ID;
                            basic.AddTime = DateTime.Now;
                        }
                        if (GetColumnValue("期数", table, i, out Value))
                        {
                            basic.BuildingNumber = Value.ToString().Trim();
                        }
                        if (GetColumnValue("签约日期", table, i, out Value))
                        {
                            basic.SignDate = GetDateTimeValue(Value);
                        }
                        if (GetColumnValue("交付时间", table, i, out Value))
                        {
                            basic.PaymentTime = GetDateTimeValue(Value);
                        }
                        if (GetColumnValue("产权办理时间", table, i, out Value))
                        {
                            basic.CertificateTime = GetDateTimeValue(Value);
                        }
                        if (GetColumnValue("房产类别", table, i, out Value))
                        {
                            basic.RoomType = Value.ToString().Trim();
                        }
                        if (GetColumnValue("精装修情况", table, i, out Value))
                        {
                            basic.IsJingZhuangXiu = 0;
                            if (Value.ToString().Trim().Equals("是"))
                            {
                                basic.IsJingZhuangXiu = 1;
                            }
                            if (Value.ToString().Trim().Equals("否"))
                            {
                                basic.IsJingZhuangXiu = 2;
                            }
                        }
                        if (GetColumnValue("建筑面积", table, i, out Value))
                        {
                            basic.BuildingOutArea = GetDecimalValue(Value);
                        }
                        List<RoomPhoneRelation> roomPhoneRelationList = new List<RoomPhoneRelation>();
                        string phoneName = string.Empty;
                        if (GetColumnValue("业主1", table, i, out Value))
                        {
                            phoneName = Value.ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(phoneName))
                        {
                            var myPhoneRelation = phoneList.FirstOrDefault(p => p.RoomID == basic.RoomID && p.RelationName.Equals(phoneName));
                            if (myPhoneRelation == null)
                            {
                                myPhoneRelation = new RoomPhoneRelation();
                                myPhoneRelation.AddTime = DateTime.Now;
                                myPhoneRelation.RoomID = basic.RoomID;
                            }
                            myPhoneRelation.RelationType = "homefamily";
                            myPhoneRelation.RelationName = phoneName;
                            if (GetColumnValue("业主1联系方式", table, i, out Value))
                            {
                                myPhoneRelation.RelatePhoneNumber = Value.ToString().Trim();
                            }
                            myPhoneRelation.Save(helper);
                        }
                        phoneName = string.Empty;
                        if (GetColumnValue("业主2", table, i, out Value))
                        {
                            phoneName = Value.ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(phoneName))
                        {
                            var myPhoneRelation = phoneList.FirstOrDefault(p => p.RoomID == basic.RoomID && p.RelationName.Equals(phoneName));
                            if (myPhoneRelation == null)
                            {
                                myPhoneRelation = new RoomPhoneRelation();
                                myPhoneRelation.AddTime = DateTime.Now;
                                myPhoneRelation.RoomID = basic.RoomID;
                            }
                            myPhoneRelation.RelationType = "homefamily";
                            myPhoneRelation.RelationName = phoneName;
                            if (GetColumnValue("业主2联系方式", table, i, out Value))
                            {
                                myPhoneRelation.RelatePhoneNumber = Value.ToString().Trim();
                            }
                            myPhoneRelation.Save(helper);
                        }
                        phoneName = string.Empty;
                        if (GetColumnValue("住户1", table, i, out Value))
                        {
                            phoneName = Value.ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(phoneName))
                        {
                            var myPhoneRelation = phoneList.FirstOrDefault(p => p.RoomID == basic.RoomID && p.RelationName.Equals(phoneName));
                            if (myPhoneRelation == null)
                            {
                                myPhoneRelation = new RoomPhoneRelation();
                                myPhoneRelation.AddTime = DateTime.Now;
                                myPhoneRelation.RoomID = basic.RoomID;
                            }
                            myPhoneRelation.RelationType = "rentfamily";
                            myPhoneRelation.RelationName = phoneName;
                            if (GetColumnValue("住户1联系方式", table, i, out Value))
                            {
                                myPhoneRelation.RelatePhoneNumber = Value.ToString().Trim();
                            }
                            myPhoneRelation.Save(helper);
                        }
                        basic.Save(helper);
                    }
                    #endregion
                    if (!ImportFailed)
                    {
                        helper.Commit();
                        msg += "<p>导入完成</p>";
                    }
                    else
                    {
                        helper.Rollback();
                        msg += "<p>导入失败</p>";
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("ImportSourceHandler", "visit: importroomsource", ex);
                    msg = "第" + (count + 2) + "行数据有问题，导入取消";
                    helper.Rollback();
                }
                context.Response.Write(msg);
            }
        }
        private string[] GetStringArray(string ColumName, DataTable table, int i)
        {
            object Value = null;
            if (GetColumnValue(ColumName, table, i, out Value))
            {
                return GetStringArrayByValue(Value);
            }
            return new string[] { };
        }
        private string[] GetStringArrayByValue(object Value)
        {
            if (Value == null)
            {
                return new string[] { };
            }
            if (string.IsNullOrEmpty(Value.ToString().Trim()))
            {
                return new string[] { };
            }
            return Value.ToString().Trim().Replace("，", ",").Split(',').ToArray();
        }
        private string GetStrFromArray(string[] arrayList, int j)
        {
            if (arrayList.Length > 0)
            {
                string Value = arrayList[arrayList.Length - 1];
                if (j < arrayList.Length)
                {
                    Value = arrayList[j];
                }
                return Value;
            }
            return string.Empty;
        }
        private List<Dictionary<string, object>> GetTableColumns()
        {
            string TableName = Utility.EnumModel.DefineFieldTableName.RoomBasic.ToString();
            var list = Foresight.DataAccess.TableColumn.GetTableColumnByPageCode("roomsource", true).Where(p => !p.ColumnName.Equals("选择按钮")).ToArray();
            var all_fieldlist = Foresight.DataAccess.DefineField.GetDefineFieldsByTable_Name(TableName, 0);
            var results = list.Select(p =>
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
                return dic;
            }).ToList();
            var fieldlist = all_fieldlist.Where(p => p.IsShown && string.IsNullOrEmpty(p.ColumnName));
            foreach (var item in fieldlist)
            {
                var dic = new Dictionary<string, object>();
                dic["ID"] = 0;
                dic["FieldID"] = item.ID;
                dic["PageCode"] = "roomsource";
                dic["ColumnField"] = "field: '" + item.FieldName + "', title: '" + item.FieldName + "', width: 150";
                dic["SortOrder"] = item.SortOrder < 0 ? 0 : item.SortOrder;
                dic["IsShown"] = item.IsShown;
                dic["ColumnName"] = item.FieldName;
                results.Add(dic);
            }
            results = results.OrderBy(p => p["SortOrder"]).ToList();
            return results;
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