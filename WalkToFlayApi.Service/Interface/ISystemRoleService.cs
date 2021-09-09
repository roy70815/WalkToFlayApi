using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 規則介面
    /// </summary>
    public interface ISystemRoleService
    {
        /// <summary>
        /// 取得角色Id
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>角色Id</returns>
        Task<int> GetRoleUserIdByMemberIdAsync(string memberId);
    }
}
