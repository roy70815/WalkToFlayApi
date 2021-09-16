using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
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
        Task<MemberModel> GetAsync(string memberId);

        /// <summary>
        /// 檢查帳號是否存在
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns></returns>
        Task<bool> CheckExistAsync(string memberId);

        /// <summary>
        /// 檢查是否有這組帳號密碼
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        Task<bool> CheckCanLoginAsync(string memberId, string password);

        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="oldPassword">舊密碼</param>
        /// <param name="newPassword">新密碼</param>
        /// <returns></returns>
        Task<bool> UpdatePasswordAsync(string memberId, string oldPassword, string newPassword);

        /// <summary>
        /// 取得會員清單
        /// </summary>
        /// <param name="pageDto">分頁參數</param>
        /// <returns>會員清單</returns>
        Task<IEnumerable<MemberModel>> GetAllAsync(PageDto pageDto);

        /// <summary>
        /// 取得會員數量
        /// </summary>
        /// <returns>會員數量</returns>
        Task<int> GetTotalCountAsync();
    }
}
