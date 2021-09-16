using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Common.Helpers
{
    /// <summary>
    /// 分頁Helper
    /// </summary>
    public static class PageHelper
    {
        /// <summary>
        /// 分頁SQL
        /// </summary>
        /// <returns>分頁SQL</returns>
        public static string GetPageSQL()
        {
            return "LIMIT @From,@Size;";
        }

        /// <summary>
        /// 排序SQL
        /// </summary>
        /// <returns>排序SQL</returns>
        public static string GetSortSQL()
        {
            return "ORDER BY @SortColumn @SortType ";
        }
    }
}
