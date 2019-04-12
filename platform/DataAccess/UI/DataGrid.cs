using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Foresight.DataAccess.Ui
{
    public class DataGrid
    {
        /// <summary>
        /// 数据
        /// </summary>
        public object rows { get; set; }

        /// <summary>
        /// 总数据量
        /// </summary>
        public long total { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// DataTable
        /// </summary>
        public DataTable dataTable { get; set; }

        public object footer { set; get; }
    }
}
