using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Repository.Models
{
    /// <summary>
    /// 產品LogModel
    /// </summary>
    public class ProductLogModel
    {
        /// <summary>
        /// LogId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// RF:Product.Id
        /// </summary>
        public int ProductId { get; set; }

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
        /// 修改會員Id
        /// </summary>
        public string UpdateUser { get; set; }

    }
}
