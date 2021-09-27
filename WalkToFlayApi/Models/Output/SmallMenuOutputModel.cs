using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 附屬選單OutputModel
    /// </summary>
    public class SmallMenuOutputModel
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
