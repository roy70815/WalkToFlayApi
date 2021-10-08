using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 產品清單OutputModel
    /// </summary>
    public class ProductPageOutputModel
    {
        /// <summary>
        /// 第幾頁
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 總數量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 產品Dto
        /// </summary>
        public IEnumerable<ProductOutputModel> ProductOutputModel { get; set; }
    }
}
