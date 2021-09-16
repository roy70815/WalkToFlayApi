using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Service.Dtos
{
    /// <summary>
    /// 會員列表Dto
    /// </summary>
    public class MemberPageDto
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
        public IEnumerable<MemberDto> memberDtos { get; set; }
    }
}
