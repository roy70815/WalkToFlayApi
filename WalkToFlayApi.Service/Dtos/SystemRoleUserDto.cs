using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Service.Dtos
{
    /// <summary>
    /// 角色Dto
    /// </summary>
    public class SystemRoleUserDto
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleUserId { get; set; }

        /// <summary>
        /// 角色名稱
        /// </summary>
        public string RoleUserName { get; set; }
    }
}
