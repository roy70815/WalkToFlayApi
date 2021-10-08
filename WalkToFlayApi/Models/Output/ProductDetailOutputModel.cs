using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 產品詳細資訊OutputModel
    /// </summary>
    public class ProductDetailOutputModel
    {
        /// <summary>
        /// 產品編號
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 建立會員Id
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 照片路徑
        /// </summary>
        public IEnumerable<string> ImagesPath { get; set; }
    }
}
