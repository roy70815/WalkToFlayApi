using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 系統角色介面
    /// </summary>
    public interface ISystemRoleUserRepository
    {
        /// <summary>
        /// 檢查是否有此系統角色
        /// </summary>
        /// <param name="roleUserName">角色名稱</param>
        Task<bool> CheckExistAsync(string roleUserName);

        /// <summary>
        /// 建立系統角色
        /// </summary>
        /// <param name="roleUserName">角色名稱</param>
        Task<bool> CreateAsync(string roleUserName);

        /// <summary>
        /// 取得所有系統角色清單
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SystemRoleUserModel>> GetAllAsync();
    }
}
