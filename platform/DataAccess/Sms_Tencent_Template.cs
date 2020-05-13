using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Sms_Tencent_Template.
    /// </summary>
    public partial class Sms_Tencent_Template : EntityBase
    {
        public static List<Dictionary<string, object>> GetSmsChargeRelationList(int SmsTemplateID)
        {
            var list = new List<Dictionary<string, object>>();
            var parameters = new List<SqlParameter>();
            //parameters.Add(new SqlParameter("@SmsTemplateID", SmsTemplateID));
            var dataList = GetList<Sms_Tencent_Param>("select ID, SmsTemplateID,ParamType,ParamChargeID,ParamValue from [Sms_Tencent_Params]", parameters).ToArray();
            var myDataList = dataList.Where(p => p.SmsTemplateID == SmsTemplateID).ToArray();
            var allChargeIDList = new List<int>();
            foreach (var item in dataList)
            {
                if (item.SmsTemplateID != SmsTemplateID && item.ParamChargeID > 0)
                {
                    allChargeIDList.Add(item.ParamChargeID);
                }
            }
            var data = GetSms_Tencent_Template(SmsTemplateID);
            if (data != null && data.ParamCount > 0)
            {
                for (int i = 0; i < data.ParamCount; i++)
                {
                    int ID = 0;
                    int ParamChargeID = 0;
                    int ParamType = 0;
                    string ParamValue = string.Empty;
                    if (myDataList.Length > i)
                    {
                        ID = myDataList[i].ID;
                        ParamType = myDataList[i].ParamType;
                        ParamChargeID = myDataList[i].ParamChargeID;
                        ParamValue = myDataList[i].ParamValue;
                    }
                    var item = new Dictionary<string, object>();
                    item["count"] = i;
                    item["ID"] = ID;
                    item["ParamType"] = ParamType;
                    item["ParamChargeID"] = ParamChargeID;
                    item["ParamValue"] = ParamValue;
                    item["ParamTitle"] = "第" + (i + 1) + "个参数";
                    list.Add(item);
                }
            }
            return list;
        }
        public static bool Save_SmsChargeRelationList(int SmsTemplateID, List<Dictionary<string, object>> requestList, ref string errormsg, string AddUserName)
        {
            var data = GetSms_Tencent_Template(SmsTemplateID);
            if (data == null)
            {
                errormsg = "短信模板不存在";
                return false;
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SmsTemplateID", data.ID));
            var dataList = GetList<Sms_Tencent_Param>("select * from Sms_Tencent_Params where [SmsTemplateID]=@SmsTemplateID", parameters).ToArray();
            var list = new List<Dictionary<string, object>>();
            foreach (var item in requestList)
            {
                int ID = Convert.ToInt32(item["ID"]);
                int ParamChargeID = Convert.ToInt32(item["ParamChargeID"]);
                int ParamType = Convert.ToInt32(item["ParamType"]);
                string ParamValue = item["ParamValue"].ToString();
                var myData = dataList.FirstOrDefault(p => p.ID == ID);
                if (myData == null)
                {
                    myData = new Sms_Tencent_Param();
                    myData.SmsTemplateID = data.ID;
                    myData.AddTime = DateTime.Now;
                    myData.AddUserName = AddUserName;
                }
                myData.ParamType = ParamType;
                myData.ParamChargeID = ParamChargeID;
                myData.ParamValue = ParamValue;
                myData.Save();
            }
            data.Save();
            return true;
        }
    }
    public partial class Sms_Tencent_Template_Ext : Sms_Tencent_Template
    {
        public string ChargeNames { get; set; }
        public static Utility.ResponseDataGrid GetSms_Tencent_TemplateGrid(string Keywords, long startRowIndex, int pageSize)
        {
            List<string> conditions = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("([TemplateID] like @Keywords or [TemplteTitle] like @Keywords)");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string orderBy = " order by [AddTime] desc";
            string fieldList = "[Sms_Tencent_Template].*";
            string Statement = " from [Sms_Tencent_Template] where " + string.Join(" and ", conditions);
            long totalRows = 0;
            var list = GetList<Sms_Tencent_Template_Ext>(fieldList, Statement, parameters, orderBy, startRowIndex, pageSize, out totalRows).ToArray();
            //SetListExtValues(list);
            var dg = new Utility.ResponseDataGrid();
            dg.rows = list.Select(p =>
            {
                var dic = p.ToJsonObject(false);
                return dic;
            }).ToList();
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }
    }
}
