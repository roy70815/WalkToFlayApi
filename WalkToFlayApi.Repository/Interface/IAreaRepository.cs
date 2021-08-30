using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 鄉鎮縣市區介面
    /// </summary>
    public interface IAreaRepository
    {
        /// <summary>
        /// 取得鄉鎮縣市區列表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AreaModel>> GetAllAsync();
    }
}
