using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 角色OutputModel
    /// </summary>
    public class SystemRoleUserOutputModel
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
