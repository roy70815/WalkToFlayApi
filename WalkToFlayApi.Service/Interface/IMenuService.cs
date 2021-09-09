using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 選單介面
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// 取得選單
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>選單</returns>
        Task<IEnumerable<MenuDto>> GetAsync(string memberId);
    }
}
