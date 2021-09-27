using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Service.Dtos
{
    /// <summary>
    /// 大功能Dto
    /// </summary>
    public class SystemFunctionDto
    {
        /// <summary>
        /// 大功能Id
        /// </summary>
        public int FunctionId { get; set; }

        /// <summary>
        /// 大功能名稱
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// 大功能中文名稱
        /// </summary>
        public string FunctionChineseName { get; set; }

        /// <summary>
        /// 功能路徑
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool EnableFlag { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
    }
}
