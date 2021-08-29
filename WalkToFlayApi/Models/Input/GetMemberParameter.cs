using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Input
{
    /// <summary>
    /// 取得會員資料參數
    /// </summary>
    public class GetMemberParameter
    {
        /// <summary>
        /// 會員Id
        /// </summary>
        public string MemberId { get; set; }
        
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
    }
}
