using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelProcess
{
    public class ExportStyleModel
    {
        public int rowIndex { get; set; }
        public int cellIndex { get; set; }
        public string cellName { get; set; }
        public string Alignment { get; set; }//是否居中
        public short FontHeightInPoints { get; set; }//文字大小
        /// <summary>
        /// //1-红色 2-蓝色 3-白色
        /// </summary>
        public int Color { get; set; }
        /// <summary>
        /// 背景颜色 1-白色 2-红色 3-黑色 4-浅蓝色 5-黄色
        /// </summary>
        public short FillForegroundColor { get; set; }
        public short rowHeight { get; set; }
        /// <summary>
        /// 0-没有边框
        /// </summary>
        public int borderWidth { get; set; }
        /// <summary>
        /// 1-黑色
        /// </summary>
        public int borderColor { get; set; }
        public short Indention { get; set; }
        public string FontName { get; set; }
    }
    public class WorkBookModel
    {
        public DataTable dt { get; set; }
        public string SheetName { get; set; }
        public List<CellRangeAddressModel> rangeList { get; set; }
        public List<NpoiHeadCfg> heads { get; set; }
        public bool headerRequired { get; set; }
        public List<ExportStyleModel> styleModelList { get; set; }
    }
    public class CellRangeAddressModel
    {
        public bool IsUse { get; set; }
        public int FirstRow { get; set; }
        public int LastRow { get; set; }
        public int FirstCol { get; set; }
        public int LastCol { get; set; }
    }
    /// <summary>
    ///  电子表格的表头设置（支持多行表头设置）
    /// </summary>
    /// <remarks>
    /// 创建：shunlu 2018-10-24 
    /// </remarks>
    public class NpoiHeadCfg
    {

        /// <summary>
        /// 表头格式设置（支持多行表头）
        /// </summary>
        public NpoiHeadCfg()
        {
            Childs = new List<NpoiHeadCfg>();
        }

        /// <summary>
        /// 重载构造函数
        /// </summary> 
        /// <param name="FieldName">数据源列名</param>
        /// <param name="FieldLable">电子表格列名</param>
        /// <param name="Height">行高</param>
        /// <param name="Width">列宽</param>
        public NpoiHeadCfg(string FieldName, string FieldLable, int Width = 10, int Height = 13, string HAlign = "left")
        {

            this.FieldName = FieldName;
            this.FieldLable = FieldLable;
            this.Height = Height;
            this.Width = Width;
            this.IsBold = true;
            this.HAlign = HAlign;
            //
            Childs = new List<NpoiHeadCfg>();
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 字段标签（表格行头标题）
        /// </summary>
        public string FieldLable { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 背景颜色
        /// </summary>
        public string BackColor { get; set; }

        /// <summary>
        /// 文本颜色
        /// </summary>
        public string FontColor { get; set; }
        /// <summary>
        /// 是否粗体显示
        /// </summary>
        public bool IsBold { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<NpoiHeadCfg> Childs { get; set; }

        public string HAlign { get; set; }
    }

    /// <summary>
    /// 内存字节流
    /// </summary>
    public class NpoiMemoryStream : MemoryStream
    {
        /// <summary>
        /// 
        /// </summary>
        public NpoiMemoryStream()
        {
            AllowClose = true;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AllowClose { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public override void Close()
        {
            if (AllowClose)
                base.Close();
        }
    }
}
