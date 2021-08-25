using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Service.Dto;

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
    }
}
