using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 縣市鄉鎮行政區介面
    /// </summary>
    public interface IDistrictService
    {
        /// <summary>
        /// 取得縣市列表
        /// </summary>
        /// <returns>縣市列表</returns>
        Task<IEnumerable<CityDto>> GetCityCollectionAsync();

        /// <summary>
        /// 取得鄉鎮縣市區列表
        /// </summary>
        /// <returns>鄉鎮縣市區列表</returns>
        Task<IEnumerable<AreaDto>> GetAreaCollectionAsync();
    }
}
