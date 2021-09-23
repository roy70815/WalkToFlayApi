using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Repository.Models;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 會員介面
    /// </summary>
    public interface IMemberService
    {
        /// <summary>
        /// 建立會員
        /// </summary>
        /// <param name="memberParameterDto">會員參數Dto</param>
        /// <returns>結果訊息</returns>
        Task<Result> CreateAsync(MemberParameterDto memberParameterDto);

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns></returns>
        Task<MemberDto> GetAsync(string memberId);

        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="oldPassword">舊密碼</param>
        /// <param name="newPassword">新密碼</param>
        /// <returns></returns>
        Task<Result> UpdatePasswordAsync(string memberId, string oldPassword, string newPassword);

        /// <summary>
        /// 取得會員清單
        /// </summary>
        /// <param name="pageDto">分頁參數Dto</param>
        /// <returns>會員清單</returns>
        Task<MemberPageDto> GetAllAsync(PageDto pageDto);

        /// <summary>
        /// 修改會員資料
        /// </summary>
        /// <param name="memberParameterDto">會員參數Dto</param>
        /// <returns></returns>
        Task<Result> UpdateAsync(MemberParameterDto memberParameterDto);
    }
}
