using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Common.Dtos
{
    /// <summary>
    /// 分頁參數Dto
    /// </summary>
    public class PageDto
    {
        /// <summary>
        /// 第幾頁
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 第幾筆開始
        /// </summary>
        public int From { get; set; }

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
