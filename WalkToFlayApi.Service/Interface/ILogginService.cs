using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 登入介面
    /// </summary>
    public interface ILogginService
    {
        /// <summary>
        /// 檢查是否可登入
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        Task<bool> CheckCanLogginAsync(string memberId, string password);

    }
}
