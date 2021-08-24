using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Repository.Models
{
    /// <summary>
    /// 規則(帳號綁角色)
    /// </summary>
    public class SystemRoleModel
    {
        /// <summary>
        /// 規則Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 會員帳號 RF: Member.MemberId
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 角色IdRF: SystemRoleUser.RoleUserId
        /// </summary>
        public int RoleUserId { get; set; }
    }
}
