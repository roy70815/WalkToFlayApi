using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Service.Dtos;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Service.Implement
{
    /// <summary>
    /// 縣市鄉鎮行政區實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Service.Interface.IDistrictService" />
    public class DistrictService : IDistrictService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The city repository
        /// </summary>
        private readonly ICityRepository _cityRepository;

        /// <summary>
        /// The area repository
        /// </summary>
        private readonly IAreaRepository _areaRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistrictService"/> class.
        /// </summary>
        /// <param name="cityRepository">The city repository.</param>
        /// <param name="areaRepository">The area repository.</param>
        public DistrictService(
            IMapper mapper,
            ICityRepository cityRepository, 
            IAreaRepository areaRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _areaRepository = areaRepository;
        }

        /// <summary>
        /// 取得鄉鎮縣市區列表
        /// </summary>
        /// <returns>鄉鎮縣市區列表</returns>
        public async Task<IEnumerable<AreaDto>> GetAreaCollectionAsync()
        {
            var areaModels = await _areaRepository.GetAllAsync();
            var areaDtos = _mapper.Map<IEnumerable<AreaDto>>(areaModels);

            return areaDtos;
        }

        /// <summary>
        /// 取得縣市列表
        /// </summary>
        /// <returns>縣市列表</returns>
        public async Task<IEnumerable<CityDto>> GetCityCollectionAsync()
        {
            var cityModels = await _cityRepository.GetAllAsync();
            var cityDtos = _mapper.Map<IEnumerable<CityDto>>(cityModels);

            return cityDtos;
        }
    }
}
