using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Service.Implement
{
    /// <summary>
    /// 規則實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Service.Interface.ISystemRoleService" />
    public class SystemRoleService : ISystemRoleService
    {
        /// <summary>
        /// The system role repository
        /// </summary>
        private readonly ISystemRoleRepository _systemRoleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemRoleService"/> class.
        /// </summary>
        /// <param name="systemRoleRepository">The system role repository.</param>
        public SystemRoleService(ISystemRoleRepository systemRoleRepository)
        {
            _systemRoleRepository = systemRoleRepository;
        }

        /// <summary>
        /// 取得角色Id
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>角色Id</returns>
        public async Task<int> GetRoleUserIdByMemberIdAsync(string memberId)
        {
            return await _systemRoleRepository.GetRoleUserIdByMemberIdAsync(memberId);
        }
    }
}
