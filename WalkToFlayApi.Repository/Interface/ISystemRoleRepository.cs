using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 規則(帳號綁角色)介面
    /// </summary>
    public interface ISystemRoleRepository
    {
        /// <summary>
        /// 取得角色Id
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns></returns>
        Task<int> GetRoleUserIdByMemberIdAsync(string memberId);
    }
}
