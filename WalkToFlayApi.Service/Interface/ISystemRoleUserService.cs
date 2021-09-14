using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 系統角色介面
    /// </summary>
    public interface ISystemRoleUserService
    {
        /// <summary>
        /// 建立系統角色
        /// </summary>
        /// <param name="roleUserName">角色名稱</param>
        Task<Result> CreateAsync(string roleUserName);

        /// <summary>
        /// 取得所有系統角色清單
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SystemRoleUserDto>> GetAllAsync();

        /// <summary>
        /// 取得角色名稱
        /// </summary>
        /// <param name="roleUserId">角色Id</param>
        /// <returns>角色名稱</returns>
        Task<string> GetRoleUserNameByRoleUserIdAsync(int roleUserId);
    }
}
