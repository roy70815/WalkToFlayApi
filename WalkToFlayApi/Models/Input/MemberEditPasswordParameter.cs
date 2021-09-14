using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Input
{
    /// <summary>
    /// 會員修改密碼參數
    /// </summary>
    public class MemberEditPasswordParameter
    {
        /// <summary>
        /// 舊密碼
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密碼
        /// </summary>
        public string NewPassword { get; set; }
    }
}
