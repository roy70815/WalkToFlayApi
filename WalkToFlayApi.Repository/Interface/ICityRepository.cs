using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 縣市介面
    /// </summary>
    public interface ICityRepository
    {
        /// <summary>
        /// 取得縣市列表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CityModel>> GetAllAsync();
    }
}
