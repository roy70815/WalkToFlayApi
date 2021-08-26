using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        Task<string> CreateAsync(MemberParameterDto memberParameterDto);

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        Task<MemberDto> GetAsync(string memberId, string password);

        ///// <summary>
        ///// 修改密碼
        ///// </summary>
        ///// <param name="memberId">會員Id</param>
        ///// <param name="oldPassword">舊密碼</param>
        ///// <param name="newPassword">新密碼</param>
        ///// <returns></returns>
        //Task<bool> UpdatePasswordAsync(string memberId, string oldPassword, string newPassword);
    }
}
