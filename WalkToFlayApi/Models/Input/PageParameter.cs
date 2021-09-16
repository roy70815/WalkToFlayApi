using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Input
{
    /// <summary>
    /// 分頁參數
    /// </summary>
    public class PageParameter
    {
        /// <summary>
        /// 第幾頁
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 一頁幾筆
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 排序欄位
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public string SortType { get; set; }
    }
}
