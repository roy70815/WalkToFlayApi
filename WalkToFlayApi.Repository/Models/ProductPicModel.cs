using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Repository.Models
{
    /// <summary>
    /// 產品圖片Model
    /// </summary>
    public class ProductPicModel
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int ProductPicId { get; set; }

        /// <summary>
        /// 上傳檔案編號
        /// </summary>
        public Guid UploadFileId { get; set; }

        /// <summary>
        /// 產品編號
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 照片路徑
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 0:未使用1:使用
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

    }




}
