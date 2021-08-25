using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 會員介面
    /// </summary>
    public interface IMemberRepository
    {
        /// <summary>
        /// 建立會員資料
        /// </summary>
        /// <param name="memberModel">會員資料Model</param>
        /// <returns>是否成功</returns>
        Task<bool> CreateAsync(MemberModel memberModel);

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>會員Model</returns>
        Task<MemberModel> GetByMemberIdAsync(string memberId);
    }
}
