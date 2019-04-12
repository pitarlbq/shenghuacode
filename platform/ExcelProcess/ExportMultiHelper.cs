using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace ExcelProcess
{
    public class ExportMultiHelper
    {
        public ExportMultiHelper()
        {
            //  
            //TODO: 在此处添加构造函数逻辑  
            //  
        }

        /// <summary>  
        /// 描述：把DataTable内容导出excel并返回客户端   
        /// 作者：李伟波  
        /// 时间：2012-10-18  
        /// </summary>  
        /// <param name="dtData"></param>  
        /// <param name="header"></param>  
        /// <param name="fileName"></param>  
        /// <param name="mergeCellNums">要合并的列索引字典 格式：列索引-合并模式(合并模式 1 合并相同项、2 合并空项、3 合并相同项及空项)</param>  
        /// <param name="mergeKey">作为合并项的标记列索引</param>  
        public static void DataTable2Excel(System.Data.DataTable dtData, TableCell[] header, string fileName, Dictionary<int, int> mergeCellNums, int? mergeKey)
        {
            System.Web.UI.WebControls.GridView gvExport = null;
            // 当前对话   
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            // IO用于导出并返回excel文件   
            System.IO.StringWriter strWriter = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                // 设置编码和附件格式   
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                curContext.Response.Charset = "gb2312";
                if (!string.IsNullOrEmpty(fileName))
                {
                    //处理中文名乱码问题  
                    fileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
                    curContext.Response.AppendHeader("Content-Disposition", ("attachment;filename=" + (fileName.ToLower().EndsWith(".xls") ? fileName : fileName + ".xls")));
                }
                // 导出excel文件   
                strWriter = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

                // 重新定义一个无分页的GridView   
                gvExport = new System.Web.UI.WebControls.GridView();
                gvExport.DataSource = dtData.DefaultView;
                gvExport.AllowPaging = false;
                //优化导出数据显示，如身份证、12-1等显示异常问题  
                gvExport.RowDataBound += new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);

                gvExport.DataBind();
                //处理表头  
                if (header != null && header.Length > 0)
                {
                    if (gvExport.HeaderRow == null)
                    {
                        return;
                    }
                    gvExport.HeaderRow.Cells.Clear();
                    gvExport.HeaderRow.Cells.AddRange(header);
                }
                //合并单元格  
                if (mergeCellNums != null && mergeCellNums.Count > 0)
                {
                    foreach (int cellNum in mergeCellNums.Keys)
                    {
                        MergeRows(gvExport, cellNum, mergeCellNums[cellNum], mergeKey);
                    }
                }

                // 返回客户端   
                gvExport.RenderControl(htmlWriter);
                curContext.Response.Clear();
                curContext.Response.Write("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=gb2312\"/>" + strWriter.ToString());
                curContext.Response.End();
            }
        }
        /// <summary>  
        /// 描述：行绑定事件  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        protected static void dgExport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    //优化导出数据显示，如身份证、12-1等显示异常问题  
                    if (Regex.IsMatch(cell.Text.Trim(), @"^\d{12,}$") || Regex.IsMatch(cell.Text.Trim(), @"^\d+[-]\d+$"))
                    {
                        cell.Attributes.Add("style", "vnd.ms-excel.numberformat:@");
                    }
                }
            }
        }

        /// <summary>     
        /// 描述：合并GridView列中相同的行  
        /// 作者：李伟波  
        /// 时间：2012-10-18  
        /// </summary>     
        /// <param   name="gvExport">GridView对象</param>     
        /// <param   name="cellNum">需要合并的列</param>     
        /// <param name="mergeMode">合并模式 1 合并相同项、2 合并空项、3 合并相同项及空项</param>  
        /// <param name="mergeKey">作为合并项的标记列索引</param>  
        public static void MergeRows(GridView gvExport, int cellNum, int mergeMode, int? mergeKey)
        {
            int i = 0, rowSpanNum = 1;
            System.Drawing.Color alterColor = System.Drawing.Color.LightGray;
            while (i < gvExport.Rows.Count - 1)
            {
                GridViewRow gvr = gvExport.Rows[i];
                for (++i; i < gvExport.Rows.Count; i++)
                {
                    GridViewRow gvrNext = gvExport.Rows[i];
                    if ((!mergeKey.HasValue || (mergeKey.HasValue && (gvr.Cells[mergeKey.Value].Text.Equals(gvrNext.Cells[mergeKey.Value].Text) || " ".Equals(gvrNext.Cells[mergeKey.Value].Text)))) && ((mergeMode == 1 && gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text) || (mergeMode == 2 && " ".Equals(gvrNext.Cells[cellNum].Text.Trim())) || (mergeMode == 3 && (gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text || " ".Equals(gvrNext.Cells[cellNum].Text.Trim())))))
                    {
                        gvrNext.Cells[cellNum].Visible = false;
                        rowSpanNum++;
                        //gvrNext.BackColor = gvr.BackColor;  //2016.4.18 处理个别电脑可能会出现底色不变的问题  
                        if (alterColor == System.Drawing.Color.White)
                            gvrNext.BackColor = System.Drawing.Color.LightGray;
                    }
                    else
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                        rowSpanNum = 1;
                        //间隔行加底色，便于阅读  
                        if (mergeKey.HasValue && cellNum == mergeKey.Value)
                        {
                            if (alterColor == System.Drawing.Color.White)
                            {
                                gvr.BackColor = System.Drawing.Color.LightGray;
                                alterColor = System.Drawing.Color.LightGray;
                            }
                            else
                            {
                                alterColor = System.Drawing.Color.White;
                            }
                        }
                        break;
                    }
                    if (i == gvExport.Rows.Count - 1)
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                        if (mergeKey.HasValue && cellNum == mergeKey.Value)
                        {
                            if (alterColor == System.Drawing.Color.White)
                                gvr.BackColor = System.Drawing.Color.LightGray;
                        }
                    }
                }
            }
        }
    }
}
