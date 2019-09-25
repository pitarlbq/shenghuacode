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
    public class ExcelExportHelper
    {
        public static int TotalExcelColumns = 256;
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
                TotalExcelColumns = 56;
            }
            else if (excel.IndexOf(".xls") > 0) // 2003版本
            {
                TotalExcelColumns = 56;
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
                    if (j < 0)
                    {
                        continue;
                    }
                    ICell cell = null;
                    try
                    {
                        cell = row.GetCell(j);
                    }
                    catch (Exception)
                    {
                    }
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
        public static void ReportExcel(DataTable dt, string strFileName, List<CellRangeAddressModel> rangeList = null, List<NpoiHeadCfg> heads = null, bool headerRequired = true, string sheetName = "")
        {
            IWorkbook workbook = null;
            ReportExcel(dt, strFileName, workbook, rangeList, heads, headerRequired, sheetName);
        }
        /// <summary>
        /// 将datatable数据导出到excel中
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dt">DataTable对象</param>
        public static void ReportExcel(DataTable dt, string strFileName, IWorkbook workbook, List<CellRangeAddressModel> rangeList = null, List<NpoiHeadCfg> heads = null, bool headerRequired = true, string sheetName = "", List<ExportStyleModel> styleModelList = null)
        {
            if (workbook == null)
            {
                if (strFileName.IndexOf(".xlsx") > 0) // 2007版本
                {
                    workbook = new XSSFWorkbook();
                    TotalExcelColumns = 56;
                }
                else if (strFileName.IndexOf(".xls") > 0) // 2003版本
                {
                    TotalExcelColumns = 56;
                    workbook = new HSSFWorkbook();
                }
            }
            //创建该sheet页
            sheetName = string.IsNullOrEmpty(sheetName) ? "Sheet1" : sheetName;
            ISheet sheet = workbook.CreateSheet(sheetName);

            if (headerRequired)
            {
                //创建 表格头部
                CreadHeader(workbook, ref sheet, dt, heads);
            }
            //创建 表格数据
            CreadDataRows(dt, ref sheet, workbook, heads: heads, styleModelList: styleModelList);
            //表格合并
            if (rangeList != null && rangeList.Count > 0)
            {
                foreach (var item in rangeList)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(item.FirstRow, item.LastRow, item.FirstCol, item.LastCol));
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
        public static void ReportExcelMultiDT(List<WorkBookModel> list, string strFileName)
        {
            IWorkbook workbook = null;
            if (strFileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook();
                TotalExcelColumns = 56;
            }
            else if (strFileName.IndexOf(".xls") > 0) // 2003版本
            {
                TotalExcelColumns = 56;
                workbook = new HSSFWorkbook();
            }
            foreach (var data in list)
            {
                ReportExcel(data.dt, strFileName, rangeList: data.rangeList, heads: data.heads, workbook: workbook, sheetName: data.SheetName, headerRequired: data.headerRequired, styleModelList: data.styleModelList);
            }
        }
        public static void CreadDataRows(DataTable dt, ref ISheet sheet, IWorkbook workbook, List<NpoiHeadCfg> heads = null, List<ExportStyleModel> styleModelList = null)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            IDataFormat dataformat = workbook.CreateDataFormat();
            //ICellStyle cellStyle = workbook.CreateCellStyle();
            //style_douhao.DataFormat = dataformat.GetFormat("#,##0.00");//分段添加，号
            if (heads != null && heads.Count > 0)
            {
                List<NpoiHeadCfg> curhds = new List<NpoiHeadCfg>();
                //遍历所有顶层节点
                for (int x = 0; x < heads.Count; x++)
                {
                    List<NpoiHeadCfg> hds = GetAllLeafNode(heads[x]);//获取所有叶子子节点 
                    curhds.AddRange(hds);
                }
                //遍历所有数据行
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var myStyleModelList = new ExportStyleModel[] { };
                    if (styleModelList != null && styleModelList.Count > 0)
                    {
                        myStyleModelList = styleModelList.Where(p => p.rowIndex == i).ToArray();
                    }
                    IRow row = sheet.CreateRow(sheet.LastRowNum + 1);//创建空行   
                    int colIndex = 0;
                    //遍历所有叶子子节点
                    for (var y = 0; y < curhds.Count; y++)
                    {
                        var ColumnName = curhds[y].FieldName;
                        if (y < dt.Columns.Count)
                        {
                            ColumnName = string.IsNullOrEmpty(ColumnName) ? dt.Columns[y].ColumnName : ColumnName;
                        }
                        if (dt.Columns.Contains(ColumnName))
                        {//数据源列是否含有配置列
                            ICell cell = row.CreateCell(colIndex);
                            if (dt.Rows[i][ColumnName] != DBNull.Value)
                            {
                                var strValue = dt.Rows[i][ColumnName].ToString();
                                SetCellValue(workbook, ColumnName, cell, strValue);
                            }
                            colIndex++;
                            if (myStyleModelList.Length > 0)
                            {
                                var myStyleModel = myStyleModelList.FirstOrDefault(p => p.cellIndex <= 0 && string.IsNullOrEmpty(p.cellName));
                                if (myStyleModel == null)
                                {
                                    myStyleModel = myStyleModelList.FirstOrDefault(p => !string.IsNullOrEmpty(p.cellName) && p.cellName.Equals(ColumnName));
                                }
                                if (myStyleModel != null)
                                {
                                    ICellStyle cellStyle = workbook.CreateCellStyle();
                                    cellStyle = SetRowCellStyle(workbook, cellStyle, myStyleModel);
                                    cell.CellStyle = cellStyle;
                                    if (myStyleModel.rowHeight > 0)
                                    {
                                        row.Height = myStyleModel.rowHeight;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //填充内容
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var myStyleModelList = new ExportStyleModel[] { };
                    if (styleModelList != null && styleModelList.Count > 0)
                    {
                        myStyleModelList = styleModelList.Where(p => p.rowIndex == i).ToArray();
                    }
                    IRow row = sheet.CreateRow(sheet.LastRowNum + 1);//创建空行   
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string ColumnName = dt.Columns[j].ColumnName;
                        ICell cell = row.CreateCell(j);
                        if (dt.Rows[i][ColumnName] != DBNull.Value)
                        {
                            var strValue = dt.Rows[i][ColumnName].ToString();
                            SetCellValue(workbook, ColumnName, cell, strValue);
                        }
                        if (myStyleModelList.Length > 0)
                        {
                            var myStyleModel = myStyleModelList.FirstOrDefault(p => p.cellIndex <= 0 && string.IsNullOrEmpty(p.cellName));
                            if (myStyleModel == null)
                            {
                                myStyleModel = myStyleModelList.FirstOrDefault(p => !string.IsNullOrEmpty(p.cellName) && p.cellName.Equals(ColumnName));
                            }
                            if (myStyleModel != null)
                            {
                                ICellStyle cellStyle = workbook.CreateCellStyle();
                                cellStyle = SetRowCellStyle(workbook, cellStyle, myStyleModel);
                                cell.CellStyle = cellStyle;
                                if (myStyleModel.rowHeight > 0)
                                {
                                    row.Height = myStyleModel.rowHeight;
                                }
                            }
                        }
                    }
                }
            }
        }
        private static void SetCellValue(IWorkbook workbook, string ColumnName, ICell cell, string strValue)
        {
            double doubleValue = 0;
            if (strValue.Contains("."))
            {
                doubleValue = 0;
                if (double.TryParse(strValue, out doubleValue))
                {
                    cell.SetCellType(CellType.NUMERIC);
                    cell.SetCellValue(doubleValue);
                }
                else
                {
                    cell.SetCellType(CellType.STRING);
                    cell.SetCellValue(strValue);
                }
                return;
            }
            if (strValue.Length > 10)
            {
                cell.SetCellType(CellType.STRING);
                cell.SetCellValue(strValue);
                return;
            }
            if (strValue.StartsWith("0"))
            {
                cell.SetCellType(CellType.STRING);
                cell.SetCellValue(strValue);
                return;
            }
            if (strValue.Contains(","))
            {
                cell.SetCellType(CellType.STRING);
                cell.SetCellValue(strValue);
                return;
            }
            doubleValue = 0;
            if (double.TryParse(strValue, out doubleValue))
            {
                cell.SetCellType(CellType.NUMERIC);
                cell.SetCellValue(doubleValue);
            }
            else
            {
                cell.SetCellType(CellType.STRING);
                cell.SetCellValue(strValue);
            }
        }
        private static void CreadHeader(IWorkbook book, ref ISheet sheet, DataTable dt, List<NpoiHeadCfg> heads)
        {
            //创建 表格头部
            if (heads != null && heads.Count > 0)
            {
                //使用自定义表头（可以支持多行表头）

                IRow headRow = sheet.CreateRow(0);//创建空行
                headRow.Height = (short)(heads[0].Height * 20);  //设置行高
                //遍历自定义列头
                int maxHeadRowNum = 0;//多行最大行号
                //

                int newColIndex = 0;
                //记录当前列最多变成几列
                Dictionary<int, int[]> mgs = new Dictionary<int, int[]>();
                //
                for (int i = 0; i < heads.Count; i++)
                {
                    if (heads[i].Childs.Count == 0)
                    {
                        #region 无子节点
                        ICell cell = headRow.CreateCell(newColIndex); //创建单元格 
                        cell.SetCellValue(heads[i].FieldLable);    //设置单元格内容

                        var style = GetCellStyle(book, heads[i]);
                        cell.CellStyle = style;
                        // 设置列宽
                        if (heads[i].Width > 0)
                        {
                            sheet.SetColumnWidth(cell.ColumnIndex, heads[i].Width * TotalExcelColumns);
                        }
                        else
                        {
                            sheet.SetColumnWidth(cell.ColumnIndex, 100 * TotalExcelColumns);
                        }
                        // 
                        mgs.Add(i, new int[] { newColIndex, 1 });
                        newColIndex += 1;
                        #endregion
                    }
                    else
                    {
                        #region 多个子节点
                        int rowIndex = 0;
                        int outRowIndex = 0;
                        int old_colIndex = newColIndex;
                        int new_colIndex = CreateHeadCell(headRow, newColIndex, rowIndex, out outRowIndex, heads[i]);    // 返回最大列数 
                        //
                        for (int j = old_colIndex; j < new_colIndex; j++)
                        {
                            if (headRow.GetCell(j) == null)
                            {
                                ICell _cell = headRow.CreateCell(j); //创建单元格   
                                _cell.SetCellValue(heads[i].FieldLable);  //设置单元格内容  
                                var style = GetCellStyle(book, heads[i]);
                                _cell.CellStyle = style;
                            }
                        }
                        mgs.Add(i, new int[] { old_colIndex, new_colIndex - old_colIndex });
                        // 
                        //合并单元格
                        //参数1：起始行 参数2：终止行 参数3：起始列 参数4：终止列  
                        CellRangeAddress region1 = new CellRangeAddress(headRow.RowNum, headRow.RowNum, (short)old_colIndex, (short)new_colIndex - 1);
                        headRow.Sheet.AddMergedRegion(region1);
                        //
                        newColIndex = new_colIndex;
                        //
                        if (outRowIndex > maxHeadRowNum)
                        {
                            maxHeadRowNum = outRowIndex;//更新多行最大行号
                        }
                        #endregion
                    }
                }
                var fullstyle = GetCellStyle(book, heads[0]);
                //合并 列
                #region 合并列
                if (maxHeadRowNum > 0)
                {
                    foreach (var mg in mgs)
                    {
                        var values = mg.Value;
                        int cIndex = values[0];
                        int cCount = values[1];
                        if (cCount == 1)
                        {
                            for (int j = headRow.RowNum; j <= maxHeadRowNum; j++)
                            {
                                ICell cell = sheet.GetRow(j).GetCell(cIndex);
                                if (cellIsNull(cell))
                                {
                                    cell = sheet.GetRow(j).CreateCell(cIndex);
                                    cell.CellStyle = fullstyle;
                                }
                            }
                            CellRangeAddress region1 = new CellRangeAddress(headRow.RowNum, maxHeadRowNum, (short)cIndex, (short)cIndex);
                            headRow.Sheet.AddMergedRegion(region1);
                        }
                        else
                        {
                            for (int j = maxHeadRowNum; j >= headRow.RowNum; j--)
                            {
                                IRow row = sheet.GetRow(j);
                                ICell cell = row.GetCell(cIndex);
                                if (cellIsNull(cell))
                                {
                                    for (int y = 0; y < cCount; y++)
                                    {
                                        cell = row.GetCell(cIndex + y);
                                        if (cellIsNull(cell))
                                        {
                                            cell = row.CreateCell(cIndex + y);
                                            cell.CellStyle = fullstyle;
                                            //向上行合并
                                            CellRangeAddress region1 = new CellRangeAddress(j - 1, maxHeadRowNum, (short)(cIndex + y), (short)(cIndex + y));
                                            headRow.Sheet.AddMergedRegion(region1);
                                        }
                                    }
                                }
                                else
                                {
                                    for (int y = 0; y < cCount; y++)
                                    {
                                        cell = row.GetCell(cIndex + y);
                                        if (cellIsNull(cell))
                                        {
                                            cell = row.CreateCell(cIndex + y);
                                            cell.CellStyle = fullstyle;
                                            //判断上一行是否空
                                            for (int x = j - 1; x >= headRow.RowNum; x--)
                                            {
                                                IRow preRow = sheet.GetRow(x);
                                                var precell = preRow.GetCell(cIndex + y);
                                                if (cellIsNull(precell))
                                                {
                                                    var newcell = preRow.CreateCell(cIndex + y);
                                                    newcell.CellStyle = fullstyle;
                                                }
                                                else
                                                {
                                                    //向下行合并
                                                    CellRangeAddress region1 = new CellRangeAddress(x, maxHeadRowNum, (short)(cIndex + y), (short)(cIndex + y));
                                                    headRow.Sheet.AddMergedRegion(region1);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                //使用数据源列名作表头（只支持单行表头）
                IRow headRow = sheet.CreateRow(0);//创建空行
                var style = GetCellStyle(book, null);
                //遍历列
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = headRow.CreateCell(i);
                    cell.CellStyle = style;
                    sheet.SetColumnWidth(cell.ColumnIndex, 100 * TotalExcelColumns);
                    if (!string.IsNullOrEmpty(dt.Columns[i].Caption))
                    {
                        cell.SetCellValue(dt.Columns[i].Caption);
                    }
                    else
                    {
                        cell.SetCellValue(dt.Columns[i].ColumnName);
                    }
                }
            }
        }
        private static bool cellIsNull(ICell cell)
        {
            if (cell == null || (cell != null && string.IsNullOrEmpty(cell.StringCellValue)))
            {
                return true;
            }
            return false;
        }
        private static ICellStyle GetCellStyle(IWorkbook book, NpoiHeadCfg headCfg)
        {
            ICellStyle style0 = book.CreateCellStyle();
            style0.Alignment = HorizontalAlignment.LEFT;
            if (headCfg != null && !string.IsNullOrEmpty(headCfg.HAlign))
            {
                if (headCfg.HAlign.Equals("center"))
                {
                    style0.Alignment = HorizontalAlignment.CENTER;
                }
                if (headCfg.HAlign.Equals("right"))
                {
                    style0.Alignment = HorizontalAlignment.RIGHT;
                }
            }
            style0.VerticalAlignment = VerticalAlignment.CENTER;
            //四、设置字体: 
            IFont font = book.CreateFont();
            font.FontName = "黑体";//.SetFontName("黑体");
            font.FontHeightInPoints = (short)11.5;//.SetFontHeightInPoints((short)16);//设置字体大小    
            //font.Color = NPOI.HSSF.Util.HSSFColor.DARK_RED.index;
            style0.SetFont(font);//选择需要用到的字体格式 
            style0.WrapText = true;//换行
            //大坑，大坑，大坑，shunlu 2018-10-10
            //必须设置单元格背景色 FillForegroundColor 和 FillPattern 的值才能正确显示背景色
            //style0.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_CORNFLOWER_BLUE.index; //(short)1灰色  NPOI.HSSF.Util.HSSFColor.LightBlue.Index; 
            //style0.FillPattern = FillPatternType.SOLID_FOREGROUND;// CellStyle.SOLID_FOREGROUND
            return style0;
        }
        private static ICellStyle SetRowCellStyle(IWorkbook book, ICellStyle cellStyle, ExportStyleModel styleModel)
        {
            cellStyle.VerticalAlignment = VerticalAlignment.CENTER;
            cellStyle.Alignment = HorizontalAlignment.LEFT;
            if (!string.IsNullOrEmpty(styleModel.Alignment))
            {
                if (styleModel.Alignment.Equals("center"))
                {
                    cellStyle.Alignment = HorizontalAlignment.CENTER;
                }
                else if (styleModel.Alignment.Equals("left"))
                {
                    cellStyle.Alignment = HorizontalAlignment.LEFT;
                }
                else
                {
                    cellStyle.Alignment = HorizontalAlignment.RIGHT;
                }
            }
            cellStyle.WrapText = true;//换行
            //必须设置单元格背景色 FillForegroundColor 和 FillPattern 的值才能正确显示背景色
            if (styleModel.FillForegroundColor >= 1)
            {
                if (styleModel.FillForegroundColor == 1)
                {
                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.index; //(short)白色             
                }
                if (styleModel.FillForegroundColor == 2)
                {
                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.RED.index; //(short)红色             
                }
                if (styleModel.FillForegroundColor == 3)
                {
                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.BLACK.index; //(short)黑色             
                }
                if (styleModel.FillForegroundColor == 4)
                {
                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_CORNFLOWER_BLUE.index; //(short)浅蓝色
                }
                if (styleModel.FillForegroundColor == 5)
                {
                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.YELLOW.index; //(short)黄色
                }
                cellStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;// CellStyle.SOLID_FOREGROUND
            }
            if (styleModel.borderWidth > 0)
            {
                if (styleModel.borderColor == 1)
                {
                    cellStyle.BorderLeft = BorderStyle.THIN;
                    cellStyle.BorderRight = BorderStyle.THIN;
                    cellStyle.BorderBottom = BorderStyle.THIN;
                    cellStyle.BorderTop = BorderStyle.THIN;
                }
            }
            if (styleModel.Indention > 0)
            {
                cellStyle.Indention = styleModel.Indention;
            }
            //四、设置字体: 
            IFont font = book.CreateFont();
            if (styleModel.FontHeightInPoints <= 0)
            {
                styleModel.FontHeightInPoints = (short)11.5;
            }
            font.FontHeightInPoints = styleModel.FontHeightInPoints;//.SetFontHeightInPoints((short)16);//设置字体大小
            if (styleModel.Color == 1)
            {
                font.Color = NPOI.HSSF.Util.HSSFColor.RED.index;
            }
            else if (styleModel.Color == 2)
            {
                font.Color = NPOI.HSSF.Util.HSSFColor.BLUE.index;
            }
            else if (styleModel.Color == 3)
            {
                font.Color = NPOI.HSSF.Util.HSSFColor.WHITE.index;
            }
            if (string.IsNullOrEmpty(styleModel.FontName))
            {
                font.FontName = "黑体";//.SetFontName("黑体");
            }
            else
            {
                font.FontName = styleModel.FontName;
            }
            cellStyle.SetFont(font);//选择需要用到的字体格式 
            return cellStyle;
        }
        private static int CreateHeadCell(IRow preHeadRow, int startColIndex, int rowIndex, out int outRowIndex, NpoiHeadCfg headCfg)
        {
            // int colCount = headCfg.Childs.Count;
            int preRowIndex = rowIndex;
            rowIndex += 1;
            outRowIndex = rowIndex;
            var sheet = preHeadRow.Sheet;
            IWorkbook book = sheet.Workbook;
            var style = GetCellStyle(book, headCfg);
            //
            IRow curHeadRow = null;
            if (sheet.LastRowNum >= rowIndex)
            {
                curHeadRow = sheet.GetRow(rowIndex);
            }
            else
            {
                curHeadRow = sheet.CreateRow(rowIndex);//创建空行
                for (int i = 0; i < startColIndex; i++)
                {
                    ICell cell = curHeadRow.CreateCell(i); //创建单元格 
                    cell.CellStyle = style;
                    ////
                    ICell precell = preHeadRow.GetCell(i); //获取单元格 
                    if (precell != null)
                    {
                        cell.SetCellValue("");//设置单元格内容 
                        //precell.SetCellValue("");
                    }
                }
            }
            int newColIndex = startColIndex;
            for (int i = 0; i < headCfg.Childs.Count; i++)
            {
                style = GetCellStyle(book, headCfg.Childs[i]);
                short Height = (short)(headCfg.Childs[i].Height * 20);
                if (curHeadRow.Height < Height)
                {
                    curHeadRow.Height = Height;
                }
                if (headCfg.Childs[i].Childs.Count > 0)
                {
                    //Console.Write("递归调用\r\n");
                    //
                    int _outRowIndex = 0;
                    int old_ColIndex = newColIndex;
                    //
                    int new_ColIndex = CreateHeadCell(curHeadRow, newColIndex, rowIndex, out _outRowIndex, headCfg.Childs[i]);//递归调用 
                    // 
                    for (int j = old_ColIndex; j < new_ColIndex; j++)
                    {
                        ICell _cell = curHeadRow.GetCell(j);
                        if (_cell == null)
                        {
                            _cell = curHeadRow.CreateCell(j); //创建单元格  
                        }
                        // 设置列宽
                        _cell.SetCellValue(headCfg.Childs[i].FieldLable);  //设置单元格内容  
                        _cell.CellStyle = style;
                        if (headCfg.Childs[i].Width > 100)
                        {
                            sheet.SetColumnWidth(_cell.ColumnIndex, headCfg.Childs[i].Width * TotalExcelColumns);
                        }
                        else
                        {
                            sheet.SetColumnWidth(_cell.ColumnIndex, 100 * TotalExcelColumns);
                        }
                    }
                    //合并单元格
                    //参数1：起始行 参数2：终止行 参数3：起始列 参数4：终止列  
                    CellRangeAddress region1 = new CellRangeAddress(curHeadRow.RowNum, curHeadRow.RowNum, (short)old_ColIndex, (short)(new_ColIndex - 1));
                    sheet.AddMergedRegion(region1);
                    //
                    if (_outRowIndex > outRowIndex)
                    {
                        outRowIndex = _outRowIndex;
                    }
                    newColIndex = new_ColIndex;

                }
                else
                {
                    ICell _cell = curHeadRow.GetCell(newColIndex);
                    if (_cell == null)
                    {
                        _cell = curHeadRow.CreateCell(newColIndex); //创建单元格  
                    }
                    _cell.SetCellValue(headCfg.Childs[i].FieldLable);//设置单元格内容 
                    _cell.CellStyle = style;
                    // 设置列宽
                    if (headCfg.Width > 0)
                    {
                        sheet.SetColumnWidth(_cell.ColumnIndex, headCfg.Width * TotalExcelColumns);
                    }
                    else
                    {
                        sheet.SetColumnWidth(_cell.ColumnIndex, 100 * TotalExcelColumns);
                    }
                    //
                    newColIndex += 1;
                }
            }
            //
            return newColIndex;
        }
        private static List<NpoiHeadCfg> GetAllLeafNode(NpoiHeadCfg headcfg)
        {
            List<NpoiHeadCfg> heads = new List<NpoiHeadCfg>();
            if (headcfg != null)
            {
                if (headcfg.Childs.Count > 0)
                {
                    for (int i = 0; i < headcfg.Childs.Count; i++)
                    {
                        var hds = GetAllLeafNode(headcfg.Childs[i]);//递归调用
                        if (hds.Count > 0)
                        {
                            heads.AddRange(hds);
                        }
                    }
                    return heads;
                }
                else
                {
                    heads.Add(headcfg);
                    return heads;
                }
            }
            else
            {
                return heads;
            }
        }
    }
}
