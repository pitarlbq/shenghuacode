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
    /// This object represents the properties and methods of a Project_ServiceTypeDelay.
    /// </summary>
    public partial class Project_ServiceTypeDelay : EntityBase
    {
        public static Ui.DataGrid GetProject_ServiceTypeDelayGrid(string Keywords)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("ParentID=1");
            if (!string.IsNullOrEmpty(Keywords))
            {
                conditions.Add("Name like @Keywords");
                parameters.Add(new SqlParameter("@Keywords", "%" + Keywords + "%"));
            }
            string cmdtext = "select Project.ID,Project.Name from Project where " + string.Join(" and ", conditions) + " order by ID desc";
            var list = GetList<Project>(cmdtext, parameters).ToArray();
            var delayList = Project_ServiceTypeDelay.GetProject_ServiceTypeDelays().ToArray();
            var results = new List<Dictionary<string, object>>();
            foreach (var item in list)
            {
                var resultItem = new Dictionary<string, object>();
                resultItem["ProjectID"] = item.ID;
                resultItem["ProjectName"] = item.Name;
                var myDelayItem = delayList.FirstOrDefault(p => p.ProjectID == item.ID);
                resultItem["DelayHour"] = myDelayItem != null ? myDelayItem.DelayHour.ToString("0") : "";
                results.Add(resultItem);
            }
            var dg = new Ui.DataGrid();
            dg.rows = results;
            dg.total = results.Count;
            dg.page = 1;
            return dg;
        }
    }
}
