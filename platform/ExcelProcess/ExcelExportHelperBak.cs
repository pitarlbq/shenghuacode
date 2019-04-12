using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ExcelProcess
{
    public class ExcelExportHelperBak
    {
        /// <summary>
        /// 利用模板，DataTable导出到Excel
        /// </summary>
        /// <param name="dtSource">DataTable</param>
        /// <param name="strFileName">生成的文件路径，名称</param>
        /// <param name="strTemplateFileName">模板的文件路径，名称</param>
        /// <param name="titleName">表头名称</param>
        /// <param name="indexDataRow">excle的数据起始行数</param> 
        /// <param name="endDataRow">excle的数据结束行数</param> 
        public static void ExportExcelForDtByNPOI(DataTable dtSource, string strFileName, string strTemplateFileName, string titleName, int indexDataRow, int endDataRow)
        {
            using (MemoryStream ms = ExportExcelForDtByNPOI(dtSource, strTemplateFileName, titleName, indexDataRow, endDataRow))
            {
                byte[] data = ms.ToArray();
                #region 客户端保存
                HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                //Encoding pageEncode = Encoding.GetEncoding(PageEncode);
                response.Charset = "UTF-8";
                response.ContentType = "application/vnd-excel";//"application/vnd.ms-excel";
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + strFileName));
                System.Web.HttpContext.Current.Response.BinaryWrite(data);
                #endregion
            }
        }
        /// <summary>
        /// 利用模板，DataTable导出到Excel
        /// </summary>
        /// <param name="dtSource">DataTable</param>
        /// <param name="strFileName">生成的文件路径，名称</param>
        /// <param name="strTemplateFileName">模板的文件路径，名称</param>
        /// <param name="titleName">表头名称</param>
        public static void ExportExcelForDtByNPOITitle(DataTable dtSource, string strFileName, string strTemplateFileName, string titleName)
        {
            using (MemoryStream ms = ExportExcelForDtByNPOITitle(dtSource, strTemplateFileName, titleName))
            {
                byte[] data = ms.ToArray();
                #region 客户端保存
                HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                //Encoding pageEncode = Encoding.GetEncoding(PageEncode);
                response.Charset = "UTF-8";
                response.ContentType = "application/vnd-excel";//"application/vnd.ms-excel";
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + strFileName));
                System.Web.HttpContext.Current.Response.BinaryWrite(data);
                #endregion
            }
        }
        public static void ExportExcelForDtByNPOI(DataTable dtSource, string strFileName, string strTemplateFileName, string titleName, HttpContext context, int indexDataRow, int endDataRow)
        {
            using (MemoryStream ms = ExportExcelForDtByNPOI(dtSource, strTemplateFileName, titleName, indexDataRow, endDataRow))
            {
                //byte[] data = ms.ToArray();
                //#region 客户端保存
                //HttpResponse response = context.Response;
                //response.Clear();
                //Encoding pageEncode = Encoding.GetEncoding(PageEncode);
                //response.Charset = "UTF-8";
                //response.ContentType = "application/vnd-excel";//"application/vnd.ms-excel";
                //context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + System.Web.HttpUtility.UrlEncode(strFileName, System.Text.Encoding.GetEncoding("utf-8"))));
                //context.Response.BinaryWrite(data);
                //context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + strFileName));
                //context.Response.BinaryWrite(data);
                //#endregion

                //context.Response.ContentType = "application/octet-stream";
                //string encodeFileName = HttpUtility.UrlEncode("LegalPersonBaseExport.xls");
                //context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", "E:\\pro\\Compile\\MyWeb\\Page\\Excel\\LegalPersonBaseExport.xls"));
                //获得文件的文件名称
                //string filepath = context.Server.MapPath("~/Page/LegalPersonManagement/LegalPersonList.aspx");
                //利用文件流保存
                //context.Response.Write(File.ReadAllText(filepath));



                context.Response.ContentType = "application/octet-stream";

                string encodeFileName = HttpUtility.UrlEncode("文件.htm");

                string filepath = "E:\\pro\\Compile\\MyWeb\\Page\\Excel\\LegalPersonBaseExport.xls";

                context.Response.AddHeader("Content-Disposition", "attachment;filename=" + encodeFileName);
                context.Response.AddHeader("Content-Length", encodeFileName.Length.ToString());

                context.Response.WriteFile(filepath);
                context.Response.End();


            }
        }

        /// <summary>
        /// 利用模板，DataTable导出到Excel
        /// </summary>
        /// <param name="dtSource">DataTable</param>
        /// <param name="strTemplateFileName">模板的文件路径，名称</param>
        /// <param name="titleName">表头名称</param>
        /// <param name="indexDataRow">excle的数据起始行数</param> 
        /// <param name="indexDataRow">excle的数据结束行数</param> 
        /// <returns></returns>
        private static MemoryStream ExportExcelForDtByNPOI(DataTable dtSource, string strTemplateFileName, string titleName, int indexDataRow, int endDataRow)
        {
            //int totalIndex = 999;     //每个类别的总行数 :导出模版要设置：totalIndex+rowIndex行的样式，不能设置全部的行样式。
            //int rowIndex = 1;        // 起始行
            int totalIndex = endDataRow;     //每个类别的总行数 :导出模版要设置：totalIndex+rowIndex行的样式，不能设置全部的行样式。
            int rowIndex = indexDataRow;        // 起始行
            int dtRowIndex = dtSource.Rows.Count;    // DataTable的数据行数

            FileStream file = new FileStream(strTemplateFileName, FileMode.Open, FileAccess.Read);    //读入excel模板
            IWorkbook workbook = null;
            if (strTemplateFileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook(file);
            }
            else if (strTemplateFileName.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook(file);
            }
            string sheetName = "Sheet1"; //工作簿名称
            ISheet sheet = workbook.GetSheet(sheetName);
            #region 表头
            //IRow headerRow = sheet.GetRow(1);
            //ICell headerCell = headerRow.GetCell(0);
            //headerCell.SetCellValue("11");
            #endregion
            //隐藏多余行
            for (int i = rowIndex + dtRowIndex; i < rowIndex + totalIndex; i++)
            {
                IRow dataRowD = sheet.GetRow(i);
                dataRowD.Height = 0;
                dataRowD.ZeroHeight = true;
            }
            foreach (DataRow row in dtSource.Rows)
            {
                #region 填充内容

                IRow dataRow = sheet.GetRow(rowIndex);

                int columnIndex = 0;        // 开始列（0为标题列，从1开始）
                foreach (DataColumn column in dtSource.Columns)
                {

                    // 列序号赋值
                    if (columnIndex >= dtSource.Columns.Count)
                        break;
                    ICell newCell = dataRow.GetCell(columnIndex);
                    if (newCell == null)
                        newCell = dataRow.CreateCell(columnIndex);
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                    columnIndex++;
                }

                #endregion
                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                sheet = null;
                workbook = null;
                return ms;
            }
        }

        /// <summary>
        /// 利用模板，DataTable导出到Excel
        /// </summary>
        /// <param name="dtSource">DataTable</param>
        /// <param name="strTemplateFileName">模板的文件路径，名称</param>
        /// <param name="titleName">表头名称</param>
        /// <returns></returns>
        private static MemoryStream ExportExcelForDtByNPOITitle(DataTable dtSource, string strTemplateFileName, string titleName)
        {
            int totalIndex = 999;     //每个类别的总行数 :导出模版要设置：totalIndex+rowIndex行的样式，不能设置全部的行样式。
            int rowIndex = 2;        // 起始行
            int dtRowIndex = dtSource.Rows.Count;    // DataTable的数据行数

            FileStream file = new FileStream(strTemplateFileName, FileMode.Open, FileAccess.Read);    //读入excel模板
            IWorkbook workbook = null;
            if (strTemplateFileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook(file);
            }
            else if (strTemplateFileName.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook(file);
            }
            string sheetName = "Sheet1"; //工作簿名称
            ISheet sheet = workbook.GetSheet(sheetName);

            #region 表头
            //IRow headerRow = sheet.GetRow(1);
            //ICell headerCell = headerRow.GetCell(0);
            //headerCell.SetCellValue("11");
            #endregion
            //隐藏多余行
            for (int i = rowIndex + dtRowIndex; i < rowIndex + totalIndex; i++)
            {
                IRow dataRowD = sheet.GetRow(i);
                dataRowD.Height = 0;
                dataRowD.ZeroHeight = true;
            }

            foreach (DataRow row in dtSource.Rows)
            {
                #region 填充内容

                IRow dataRow = sheet.GetRow(rowIndex);

                int columnIndex = 0;        // 开始列（0为标题列，从1开始）
                foreach (DataColumn column in dtSource.Columns)
                {

                    // 列序号赋值
                    if (columnIndex >= dtSource.Columns.Count)
                        break;
                    ICell newCell = dataRow.GetCell(columnIndex);
                    if (newCell == null)
                        newCell = dataRow.CreateCell(columnIndex);
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                    columnIndex++;
                }

                #endregion

                rowIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                sheet = null;
                workbook = null;
                return ms;
            }

        }


        /// <summary>
        /// 读取excel里面数据信息
        /// </summary>
        /// <param name="excel">excel文件路径</param>
        /// <returns></returns>
        public static DataTable NPOIReadExcel(string excel)
        {
            FileStream file = new FileStream(excel, FileMode.Open, FileAccess.Read);
            //根据路径通过已存在的excel来创建HSSFWorkbook，即整个excel文档
            IWorkbook workbook = null;
            if (excel.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook(file);
            }
            else if (excel.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook(file);
            }
            //获取excel的第一个sheet
            ISheet sheet = workbook.GetSheetAt(0);
            DataTable table = new DataTable();
            //获取sheet的首行
            IRow headerRow = sheet.GetRow(0);

            //一行最后一个方格的编号,即总的列数
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            //最后一列的标号,即总的行数
            int rowCount = sheet.LastRowNum;
            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum + 1; i++)
            {
                IRow row = sheet.GetRow(i);

                //这一句很关键，因为没有数据的行默认是null
                if (row == null)
                {
                    continue;
                }
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    ICell cell = row.GetCell(j);
                    object value = null;
                    //同理，没有数据的单元格都默认是null
                    if (cell != null && cell.CellType != CellType.BLANK)
                    {
                        switch (cell.CellType)
                        {
                            case CellType.STRING:
                                string str = cell.StringCellValue;
                                if (!string.IsNullOrEmpty(str))
                                {
                                    value = str.ToString();
                                }
                                else
                                {
                                    value = string.Empty;
                                }
                                break;
                            case CellType.NUMERIC:
                                // Date comes here
                                var iCellStyle = cell.CellStyle;
                                short format = iCellStyle.DataFormat;
                                //日期
                                if (HSSFDateUtil.IsCellDateFormatted(cell))
                                {
                                    value = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                else if (format == 20 || format == 32)
                                {
                                    value = cell.DateCellValue.ToString("HH:mm");
                                }
                                else
                                {
                                    value = cell.NumericCellValue;
                                }
                                break;
                            case CellType.BOOLEAN:
                                value = cell.BooleanCellValue;
                                break;
                            case CellType.FORMULA:
                                {
                                    switch (cell.CachedFormulaResultType)
                                    {
                                        case CellType.BOOLEAN:
                                            value = cell.BooleanCellValue;
                                            break;
                                        case CellType.ERROR:
                                            value = ErrorEval.GetText(cell.ErrorCellValue);
                                            break;
                                        case CellType.NUMERIC:
                                            if (DateUtil.IsCellDateFormatted(cell))
                                            {
                                                value = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                                            }
                                            else
                                            {
                                                value = cell.NumericCellValue;
                                            }
                                            break;
                                        case CellType.STRING:
                                            string cellstr = cell.StringCellValue;
                                            if (!string.IsNullOrEmpty(cellstr))
                                            {
                                                value = cellstr.ToString();
                                            }
                                            else
                                            {
                                                value = null;
                                            }
                                            break;
                                        case CellType.Unknown:
                                        case CellType.BLANK:
                                            break;
                                        default:
                                            value = string.Empty;
                                            break;
                                    }
                                    break;
                                }
                            default:
                                value = cell.StringCellValue;
                                break;
                        }
                        dataRow[j] = value;
                    }
                }
                table.Rows.Add(dataRow);
            }
            workbook = null;
            sheet = null;
            return table;
        }
        /// <summary>
        /// 将datatable数据导出到excel中
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dt">DataTable对象</param>
        public static void ReportExcel(DataTable dt, string strFileName)
        {
            ReportExcel(dt, strFileName, new List<CellRangeAddressModel>());
        }
        public static void ReportExcel(DataTable dt, string strFileName, List<CellRangeAddressModel> rangeList)
        {
            IWorkbook workbook = null;
            if (strFileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook();
            }
            else if (strFileName.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook();
            }
            ISheet sheet = CreateSheet(dt, workbook, "Sheet1");
            foreach (var item in rangeList)
            {
                sheet.AddMergedRegion(new CellRangeAddress(item.FirstRow, item.LastRow, item.FirstCol, item.LastCol));
            }
            //保存
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
            }
        }
        public static void ReportExcelMultiDT(List<WorkBookModel> list, string strFileName)
        {
            IWorkbook workbook = null;
            if (strFileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook();
            }
            else if (strFileName.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook();
            }
            foreach (var dt in list)
            {
                ISheet sheet = CreateSheet(dt.dt, workbook, dt.SheetName);
                if (dt.rangeList != null)
                {
                    foreach (var item in dt.rangeList)
                    {
                        sheet.AddMergedRegion(new CellRangeAddress(item.FirstRow, item.LastRow, item.FirstCol, item.LastCol));
                    }
                }
            }
            //保存
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
            }
        }
        public static ISheet CreateSheet(DataTable dt, IWorkbook workbook, string sheetName)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);
            //填充表头
            IRow dataRow = sheet.CreateRow(0);
            foreach (DataColumn column in dt.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                dataRow.Sheet.SetColumnWidth(column.Ordinal, 100 * 56);
            }
            IDataFormat dataformat = workbook.CreateDataFormat();
            ICellStyle style_douhao = workbook.CreateCellStyle();
            style_douhao.DataFormat = dataformat.GetFormat("#,##0.00");//分段添加，号
            //填充内容
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string ColumnName = dt.Columns[j].ColumnName;
                    var strValue = dt.Rows[i][j].ToString();
                    ICell cell = dataRow.CreateCell(j);
                    double doubleValue = 0;
                    if (ColumnName.Contains("房号") || ColumnName.Contains("编号") || ColumnName.Contains("ID"))
                    {
                        cell.SetCellType(CellType.STRING);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                        continue;
                    }
                    if (strValue.Contains("."))
                    {
                        doubleValue = 0;
                        if (double.TryParse(strValue, out doubleValue))
                        {
                            cell.SetCellType(CellType.NUMERIC);
                            cell.SetCellValue(doubleValue);
                            cell.CellStyle = style_douhao;
                        }
                        else
                        {
                            cell.SetCellType(CellType.STRING);
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                        }
                        continue;
                    }
                    if (strValue.Length > 10)
                    {
                        cell.SetCellType(CellType.STRING);
                        cell.SetCellValue(strValue);
                        continue;
                    }
                    if (strValue.StartsWith("0"))
                    {
                        cell.SetCellType(CellType.STRING);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                        continue;
                    }
                    if (strValue.Contains(","))
                    {
                        cell.SetCellType(CellType.STRING);
                        cell.SetCellValue(strValue);
                        continue;
                    }
                    doubleValue = 0;
                    if (double.TryParse(strValue, out doubleValue))
                    {
                        cell.SetCellType(CellType.NUMERIC);
                        cell.SetCellValue(doubleValue);
                        cell.CellStyle = style_douhao;
                    }
                    else
                    {
                        cell.SetCellType(CellType.STRING);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }
            }
            return sheet;
        }
    }
}
