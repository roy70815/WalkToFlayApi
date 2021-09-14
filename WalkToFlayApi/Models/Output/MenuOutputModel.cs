using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 選單OutputModel
    /// </summary>
    public class MenuOutputModel
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
        /// 附屬功能列表
        /// </summary>
        public IEnumerable<SmallMenuOutputModel> SmallMenuDtos { get; set; }
    }
}
