using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Service.Dtos
{
    /// <summary>
    /// 選單Dto
    /// </summary>
    public class MenuDto
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
        public IEnumerable<SmallMenuDto> SmallMenuDtos { get; set; }
    }
}
