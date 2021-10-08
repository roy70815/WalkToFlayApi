using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Repository.Models
{
    /// <summary>
    /// 上傳檔案Model
    /// </summary>
    public class UploadFileModel
    {
        /// <summary>
        /// 圖片編號
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 上傳日期
        /// </summary>
        public DateTime UploadTime { get; set; }

        /// <summary>
        /// 刪除日期
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 0:已刪除1:使用中
        /// </summary>
        public short Status { get; set; }

        /// <summary>
        /// 上傳者
        /// </summary>
        public string CreateUser { get; set; }

    }




}
