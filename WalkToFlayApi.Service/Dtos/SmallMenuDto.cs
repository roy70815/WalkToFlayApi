using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Service.Dtos
{
    /// <summary>
    /// 附屬選單Dto
    /// </summary>
    public class SmallMenuDto
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
    }
}
