using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Repository.Models
{
    /// <summary>
    /// 角色功能(角色綁功能)
    /// </summary>
    public class SystemRoleUserFunctionModel
    {
        /// <summary>
        /// 角色功能Id
        /// </summary>
        public int RoleUserFunctionId { get; set; }

        /// <summary>
        /// 角色Id RF: SystemRoleUser.RoleUserId
        /// </summary>
        public int RoleUserId { get; set; }

        /// <summary>
        /// 附屬功能Id RF:SystemFunctionDetail.FunctionDetailId
        /// </summary>
        public int FunctionDetailId { get; set; }
    }
}
