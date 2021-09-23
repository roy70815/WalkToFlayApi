using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 錯誤輸出格式
    /// </summary>
    public class FailOutputModel
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
        /// 錯誤訊息
        /// </summary>
        public FailInformation Error { get; set; }
    }
}
