using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// API成功類別
    /// </summary>
    public class SuccessOutputModel<T>
    {
        /// <summary>
        /// API序號
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// API版本
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// 方法名稱
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 回傳內容
        /// </summary>
        public T Data { get; set; }
    }
}
