using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Service.Dtos
{
    /// <summary>
    /// 附屬功能Dto(大功能底下)
    /// </summary>
    public class SystemFunctionDetailDto
    {
        /// <summary>
        /// 附屬功能Id
        /// </summary>
        public int FunctionDetailId { get; set; }

        /// <summary>
        /// 大功能Id RF:SystemFunction.FunctionId
        /// </summary>
        public int FunctionId { get; set; }

        /// <summary>
        /// 附屬功能名稱
        /// </summary>
        public string FunctionDetailName { get; set; }

        /// <summary>
        /// 附屬功能中文名稱
        /// </summary>
        public string FunctionDetailChineseName { get; set; }

        /// <summary>
        /// 附屬功能路徑
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool EnableFlag { get; set; }
    }
}
