using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Input
{
    /// <summary>
    /// 產品參數
    /// </summary>
    public class ProductParameter
    {
        /// <summary>
        /// 產品名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 產品描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 0:下架 1:上架
        /// </summary>
        public short Status { get; set; }
    }
}
