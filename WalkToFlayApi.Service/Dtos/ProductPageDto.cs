using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Service.Dtos
{
    /// <summary>
    /// 產品清單Dto
    /// </summary>
    public class ProductPageDto
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
        public IEnumerable<ProductDto> ProductDtos { get; set; }
    }
}
