using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 會員清單OutputModel
    /// </summary>
    public class MemberPageOutputModel
    {
        /// <summary>
        /// 第幾頁
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 總數量
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 會員Dto
        /// </summary>
        public IEnumerable<MemberOutputModel> MemberOutputModels { get; set; }
    }
}
