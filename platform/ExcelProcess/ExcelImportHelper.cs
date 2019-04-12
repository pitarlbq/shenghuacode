using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ExcelProcess
{
    public static class ExcelImportHelper
    {
        public readonly static List<ExcelMap> sExcelMaps = new List<ExcelMap>();
        private static int sInited = 0;
        private static object m_LockedObject = new object();

        public static void Init(string configPath)
        {
            if (System.Threading.Interlocked.CompareExchange(ref sInited, 0, 0) == 0)
            {
                lock (m_LockedObject)
                {
                    if (System.Threading.Interlocked.CompareExchange(ref sInited, 0, 0) == 0)
                    {
                        if (File.Exists(configPath))
                        {
                            XmlSerializer ser = new XmlSerializer(typeof(ExcelMap[]));
                            using (StreamReader sr = new StreamReader(configPath, Encoding.UTF8))
                            {
                                ExcelMap[] p = (ExcelMap[])ser.Deserialize(sr);
                                sExcelMaps.AddRange(p);
                            }
                            System.Threading.Interlocked.Exchange(ref sInited, 1);
                        }
                        else
                        {
                            throw new FileNotFoundException("找不到Excel配置文件：" + configPath);
                        }
                    }
                }
            }
        }

        public static ExcelMap[] CheckExcel(string Filename)
        {
            List<ExcelMap> maps = new List<ExcelMap>();

            string filename = Filename;
            string connStr = string.Empty;
            string ext = Path.GetExtension(filename);
            if (string.Compare(ext, ".xlsx", true) == 0)
            {
                connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=Yes;IMEX=1'", filename);
            }
            else if (string.Compare(ext, ".xls", true) == 0)
            {
                connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", filename);
                //connStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", filename);
            }
            if (string.IsNullOrEmpty(connStr))
            {
                throw new ApplicationException("不支持的问题解决类型");
            }
            else
            {
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    DataTable sheetNames = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    foreach (DataRow row in sheetNames.Rows)
                    {
                        string sheetName = row["TABLE_NAME"].ToString();
                        Debug.WriteLine(sheetName);
                        System.Data.DataTable sheetColumns = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns, new object[] { null, null, sheetName, null });
                        List<string> columnNames = new List<string>();
                        foreach (DataRow column in sheetColumns.Rows)
                        {
                            columnNames.Add(column["Column_Name"].ToString().Trim());
                        }
                        Debug.WriteLine(string.Join(",", columnNames.OrderBy(p => p).ToArray()));
                        ExcelMap map = sExcelMaps.FirstOrDefault(p => string.Compare(string.Join("\t", p.ColumnNames.OrderBy(arg => arg).ToArray()), string.Join("\t", columnNames.OrderBy(arg => arg).ToArray())) == 0);


                        //for (int i = 0; i < sExcelMaps[2].ColumnNames.Length; i++)
                        //{
                        //    if(!columnNames.Contains(sExcelMaps[2].ColumnNames[i]))
                        //    {
                        //        Debug.WriteLine(sExcelMaps[2].ColumnNames[i]);
                        //    }
                        //}


                        if (map == null)
                        {
                            Regex reg = new Regex(@"F\d+");
                            map = sExcelMaps.FirstOrDefault(p => string.Compare(string.Join("\t", p.ColumnNames.OrderBy(arg => arg).ToArray()), string.Join("\t", columnNames.Where(arg => !reg.IsMatch(arg)).OrderBy(arg => arg).ToArray())) == 0);
                        }
                        if (map != null)
                        {
                            maps.Add(map);
                        }
                    }
                }
            }
            return maps.ToArray();
        }

        public static DataTable GetDataTable(string filename)
        {
            string connStr = string.Empty;
            string ext = Path.GetExtension(filename);
            if (string.Compare(ext, ".xlsx", true) == 0)
            {
                connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=Yes;IMEX=1'", filename);
            }
            else if (string.Compare(ext, ".xls", true) == 0)
            {
                connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", filename);
                //connStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", filename);
            }

            DataTable dt = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                DataTable sheetNames = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                foreach (DataRow row in sheetNames.Rows)
                {
                    string sheetName1 = row["TABLE_NAME"].ToString();

                    OleDbDataAdapter oda = new OleDbDataAdapter("select * from [" + sheetName1 + "]", conn);
                    oda.Fill(dt);
                    conn.Close();
                    break;
                }



            }

            return dt;
        }

        /// <summary>
        /// objs: objs[0]:当前时间   objs[1]：当前用户  objs[2]:未插入的行
        /// </summary>
        /// <param name="Filename"></param>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static string[] Import(string Filename, out DataTable dataTable, params Object[] objs)
        {
            dataTable = null;
            List<string> ImportedSheetNames = new List<string>();

            string filename = Filename;
            string connStr = string.Empty;
            string ext = Path.GetExtension(filename);
            if (string.Compare(ext, ".xlsx", true) == 0)
            {
                connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=Yes;IMEX=1'", filename);
            }
            else if (string.Compare(ext, ".xls", true) == 0)
            {
                connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", filename);
                //connStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", filename);
            }
            if (string.IsNullOrEmpty(connStr))
            {
                throw new ApplicationException("不支持的文件类型");
            }
            else
            {
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    DataTable sheetNames = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    foreach (DataRow row in sheetNames.Rows)
                    {
                        string sheetName = row["TABLE_NAME"].ToString();
                        Debug.WriteLine(sheetName);
                        System.Data.DataTable sheetColumns = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns, new object[] { null, null, sheetName, null });
                        List<string> columnNames = new List<string>();
                        foreach (DataRow column in sheetColumns.Rows)
                        {
                            columnNames.Add(column["Column_Name"].ToString().Trim());
                        }
                        Debug.WriteLine(string.Join(",", columnNames.OrderBy(p => p).ToArray()));
                        ExcelMap map = sExcelMaps.FirstOrDefault(p => string.Compare(string.Join("\t", p.ColumnNames.OrderBy(arg => arg).ToArray()), string.Join("\t", columnNames.OrderBy(arg => arg).ToArray())) == 0);
                        if (map == null)
                        {
                            Regex reg = new Regex(@"F\d+");
                            map = sExcelMaps.FirstOrDefault(p => string.Compare(string.Join("\t", p.ColumnNames.OrderBy(arg => arg).ToArray()), string.Join("\t", columnNames.Where(arg => !reg.IsMatch(arg)).OrderBy(arg => arg).ToArray())) == 0);
                        }
                        if (map != null)
                        {
                            DataTable dt = new DataTable();
                            OleDbDataAdapter oda = new OleDbDataAdapter("select * from [" + sheetName + "]", conn);
                            oda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                for (int Index = 0; Index < dt.Columns.Count; Index++)
                                {
                                    dt.Columns[Index].ColumnName = dt.Columns[Index].ColumnName.Trim();
                                }
                                Import(dt, map, out dataTable, objs);
                                ImportedSheetNames.Add(sheetName);
                            }
                        }
                    }
                }
            }
            return ImportedSheetNames.ToArray();
        }


        public static void Import(DataTable dt, ExcelMap map, out DataTable dataTable, params Object[] objs)
        {
            dataTable = null;
            if (dt == null || map == null)
            {
                return;
            }
            StringBuilder cmdText = new StringBuilder();
            List<string> conditions = new List<string>();
            List<string> allColumns = new List<string>(map.ColumnNames);
            List<string> noneNullableColumns = new List<string>();
            if (map.NoneNullableColumns != null)
            {
                noneNullableColumns.AddRange(map.NoneNullableColumns);
            }

            foreach (var colname in map.IdentityColumns)
            {
                conditions.Add("[" + colname + "]=@p" + allColumns.IndexOf(colname));
            }

            cmdText.Append("IF ((select count(*) from [" + map.TableName + "] where ");
            cmdText.Append(string.Join(" and ", conditions.ToArray()));
            cmdText.Append(") <1)");

            cmdText.Append(" BEGIN ");
            cmdText.Append("INSERT INTO [" + map.TableName + "] (");

            cmdText.Append("[" + string.Join("],[", allColumns.ToArray()) + "]");

            cmdText.Append(",[ImportTime],[CurrentUser],[IsLoad]");

            cmdText.Append(") VALUES (");
            cmdText.Append(string.Join(",", Enumerable.Range(0, allColumns.Count).Select(p => "@p" + p).ToArray()));
            cmdText.Append(",@Now");
            cmdText.Append(",@CurrentUser");
            cmdText.Append(",0");
            cmdText.Append(")");
            cmdText.Append(" END ");
            if (map.Override)//如果允许覆盖，则更新数据
            {
                cmdText.Append(" ELSE BEGIN ");
                cmdText.Append("UPDATE [" + map.TableName + "] SET ");

                int index = 0;
                string.Join(",", allColumns.Select(p => { return "[" + p + "]=@p" + (index++); }).ToArray());

                cmdText.Append(" [ImportTime]=@Now,[CurrentUser]=@CurrentUser,[IsLoad]=0 ");
                cmdText.Append(" WHERE " + string.Join(" and ", conditions.ToArray()));
                cmdText.Append(" END ");
            }
            DateTime dtNow = DateTime.Now;
            string currentUser = string.Empty;

            if (objs.Length == 2)
            {
                currentUser = objs[0].ToString();
                dtNow = Convert.ToDateTime(objs[1]);

                dt.Columns.Add("错误原因");
                dataTable = dt.Copy();//获取表结构
                dataTable.Rows.Clear();
            }
            using (SqlHelper helper = new SqlHelper())
            {
                Debug.WriteLine(DateTime.Now + " ImportExcel>>Start Import.TotalRow: " + dt.Rows.Count);
                foreach (DataRow row in dt.Rows)
                {
                    List<SqlParameter> paramerters = new List<SqlParameter>();
                    paramerters.Add(new SqlParameter("@Now", dtNow));
                    paramerters.Add(new SqlParameter("@CurrentUser", currentUser));
                    int count = 0;
                    var skip = false;
                    string errmsg = "";
                    foreach (var cn in allColumns)
                    {
                        if (noneNullableColumns.Contains(cn) && (row[cn] == null || string.IsNullOrEmpty(row[cn].ToString())))
                        {
                            errmsg += "[" + cn + "]不能为空;";
                            skip = true;
                            break;
                        }
                        if (row[cn] == null)
                        {
                            paramerters.Add(new SqlParameter("@p" + (count), null));
                        }
                        else if (row[cn] is DateTime)
                        {
                            paramerters.Add(new SqlParameter("@p" + (count), (DateTime)row[cn]));
                        }
                        else
                        {
                            paramerters.Add(new SqlParameter("@p" + (count), row[cn].ToString()));
                        }
                        count++;
                    }
                    if (!skip)
                    {
                        if (helper.Execute(cmdText.ToString(), CommandType.Text, paramerters) <= 0)
                        {
                            //把没有插入的行放到dataTable返回

                            //“重复”
                            // errmsg = "列[" + string.Join("],[", map.IdentityColumns) + ":" + row[] + "]数据重复";

                            StringBuilder builder = new StringBuilder();
                            foreach (var columnName in map.IdentityColumns)
                            {
                                builder.Append(string.Format("列：[{0}] 值：[{1}] ；", columnName, row[columnName]));
                            }

                            row["错误原因"] = builder.ToString() + "以上数据重复";
                            dataTable.ImportRow(row);
                        }
                    }
                    else
                    {
                        row["错误原因"] = errmsg;
                        dataTable.ImportRow(row);
                    }
                }
                Debug.WriteLine(DateTime.Now + " ImportExcel>>End Import.TotalRow: " + dt.Rows.Count);

                if (!string.IsNullOrEmpty(map.StoredProcedure))
                {
                    try
                    {
                        Debug.WriteLine(DateTime.Now + " ImportExcel>>Start Excuete Stored Procedure: " + map.StoredProcedure);
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        helper.Execute(map.StoredProcedure.Replace("@", ""), map.StoredProcedure.StartsWith("@") ? CommandType.StoredProcedure : CommandType.Text, parameters);
                        Debug.WriteLine(DateTime.Now + " ImportExcel>>End Excuete Stored Procedure: " + map.StoredProcedure);
                    }
                    catch
                    {
                        Debug.WriteLine(DateTime.Now + " ImportExcel>>Error Excuete Stored Procedure: " + map.StoredProcedure);
                        throw;
                    }
                }
            }
        }

        #region 原来的逻辑
        public static string[] Import(string Filename)
        {
            List<string> ImportedSheetNames = new List<string>();

            string filename = Filename;
            string connStr = string.Empty;
            string ext = Path.GetExtension(filename);
            if (string.Compare(ext, ".xlsx", true) == 0)
            {
                connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=Yes;IMEX=1'", filename);
            }
            else if (string.Compare(ext, ".xls", true) == 0)
            {
                connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", filename);
                //connStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", filename);
            }
            if (string.IsNullOrEmpty(connStr))
            {
                throw new ApplicationException("不支持的文件类型");
            }
            else
            {
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    DataTable sheetNames = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    foreach (DataRow row in sheetNames.Rows)
                    {
                        string sheetName = row["TABLE_NAME"].ToString();
                        Debug.WriteLine(sheetName);
                        System.Data.DataTable sheetColumns = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns, new object[] { null, null, sheetName, null });
                        List<string> columnNames = new List<string>();
                        foreach (DataRow column in sheetColumns.Rows)
                        {
                            columnNames.Add(column["Column_Name"].ToString().Trim());
                        }
                        Debug.WriteLine(string.Join(",", columnNames.OrderBy(p => p).ToArray()));
                        ExcelMap map = sExcelMaps.FirstOrDefault(p => string.Compare(string.Join("\t", p.ColumnNames.OrderBy(arg => arg).ToArray()), string.Join("\t", columnNames.OrderBy(arg => arg).ToArray())) == 0);
                        if (map == null)
                        {
                            Regex reg = new Regex(@"F\d+");
                            map = sExcelMaps.FirstOrDefault(p => string.Compare(string.Join("\t", p.ColumnNames.OrderBy(arg => arg).ToArray()), string.Join("\t", columnNames.Where(arg => !reg.IsMatch(arg)).OrderBy(arg => arg).ToArray())) == 0);
                        }
                        if (map != null)
                        {
                            DataTable dt = new DataTable();
                            OleDbDataAdapter oda = new OleDbDataAdapter("select * from [" + sheetName + "]", conn);
                            oda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                for (int Index = 0; Index < dt.Columns.Count; Index++)
                                {
                                    dt.Columns[Index].ColumnName = dt.Columns[Index].ColumnName.Trim();
                                }
                                Import(dt, map);
                                ImportedSheetNames.Add(sheetName);
                            }
                        }
                    }
                }
            }
            return ImportedSheetNames.ToArray();
        }


        public static void Import(DataTable dt, ExcelMap map)
        {
            if (dt == null || map == null)
            {
                return;
            }
            StringBuilder cmdText = new StringBuilder();
            List<string> conditions = new List<string>();
            List<string> allColumns = new List<string>(map.ColumnNames);
            List<string> noneNullableColumns = new List<string>();
            if (map.NoneNullableColumns != null)
            {
                noneNullableColumns.AddRange(map.NoneNullableColumns);
            }

            foreach (var colname in map.IdentityColumns)
            {
                conditions.Add("[" + colname + "]=@p" + allColumns.IndexOf(colname));
            }

            cmdText.Append("IF ((select count(*) from [" + map.TableName + "] where ");
            cmdText.Append(string.Join(" and ", conditions.ToArray()));
            cmdText.Append(") <1)");

            cmdText.Append(" BEGIN ");
            cmdText.Append("INSERT INTO [" + map.TableName + "] (");

            cmdText.Append("[" + string.Join("],[", allColumns.ToArray()) + "]");

            cmdText.Append(",[ImportTime],[IsLoad]");

            cmdText.Append(") VALUES (");
            cmdText.Append(string.Join(",", Enumerable.Range(0, allColumns.Count).Select(p => "@p" + p).ToArray()));
            cmdText.Append(",@Now");
            cmdText.Append(",0");
            cmdText.Append(")");
            cmdText.Append(" END ");
            if (map.Override)//如果允许覆盖，则更新数据
            {
                cmdText.Append(" ELSE BEGIN ");
                cmdText.Append("UPDATE [" + map.TableName + "] SET ");

                int index = 0;
                string.Join(",", allColumns.Select(p => { return "[" + p + "]=@p" + (index++); }).ToArray());

                cmdText.Append(" [ImportTime]=@Now,[IsLoad]=0");
                cmdText.Append(" WHERE " + string.Join(" and ", conditions.ToArray()));
                cmdText.Append(" END ");
            }
            DateTime dtNow = DateTime.Now;
            string currentUser = string.Empty;


            using (SqlHelper helper = new SqlHelper())
            {
                string errmsg = "";
                foreach (DataRow row in dt.Rows)
                {
                    List<SqlParameter> paramerters = new List<SqlParameter>();
                    paramerters.Add(new SqlParameter("@Now", dtNow));
                    int count = 0;
                    var skip = false;
                    foreach (var cn in allColumns)
                    {
                        if (noneNullableColumns.Contains(cn) && (row[cn] == null || string.IsNullOrEmpty(row[cn].ToString())))
                        {

                            errmsg += "[" + cn + "]不能为空;";
                            skip = true;
                            break;
                        }
                        if (row[cn] == null)
                        {
                            paramerters.Add(new SqlParameter("@p" + (count), null));
                        }
                        else if (row[cn] is DateTime)
                        {
                            paramerters.Add(new SqlParameter("@p" + (count), (DateTime)row[cn]));
                        }
                        else
                        {
                            paramerters.Add(new SqlParameter("@p" + (count), row[cn].ToString()));
                        }
                        count++;
                    }
                    if (!skip)
                    {
                        if (helper.Execute(cmdText.ToString(), CommandType.Text, paramerters) <= 0)
                        {
                            //把没有插入的行放到dataTable返回

                            //“重复”
                            errmsg = "列[" + string.Join("],[", map.IdentityColumns) + "]数据重复";
                        }

                    }
                    else
                    {
                        string xxx = errmsg;
                    }
                }

                if (!string.IsNullOrEmpty(map.StoredProcedure))
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    helper.Execute(map.StoredProcedure.Replace("@", ""), map.StoredProcedure.StartsWith("@") ? CommandType.StoredProcedure : CommandType.Text, parameters);
                }
            }
        }
        #endregion
    }

    public class ExcelMap
    {
        public string TableName { get; set; }
        public string ExcelName { get; set; }
        public bool Override { get; set; }
        public string Description { get; set; }
        public string StoredProcedure { get; set; }
        public string[] ColumnNames { get; set; }
        public string[] IdentityColumns { get; set; }
        public string[] NoneNullableColumns { get; set; }
    }
}
