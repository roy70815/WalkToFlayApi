using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 角色功能介面
    /// </summary>
    public interface ISystemRoleUserFunctionRepository
    {
        /// <summary>
        /// 取得附屬功能IdCollection
        /// </summary>
        /// <param name="roleUserId">角色Id</param>
        /// <returns>附屬功能IdCollection</returns>
        Task<IEnumerable<int>> GetFunctionDetailIdsByRoleUserIdAsync(int roleUserId);
    }
}
