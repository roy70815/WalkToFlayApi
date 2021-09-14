using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Input
{
    /// <summary>
    /// 登入參數
    /// </summary>
    public class LogginParameter
    {
        /// <summary>
        /// 會員帳號
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
    }
}
