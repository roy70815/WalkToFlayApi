using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Output;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Controllers.v1
{
    /// <summary>
    /// 縣市鄉鎮區API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistrictController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The district service
        /// </summary>
        private readonly IDistrictService _districtService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistrictController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="districtService">The district service.</param>
        public DistrictController(IMapper mapper, IDistrictService districtService)
        {
            _mapper = mapper;
            _districtService = districtService;
        }

        /// <summary>
        /// 取得縣市清單
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<IEnumerable<CityOutputModel>>))]
        public async Task<IActionResult> GetCityCollectionAsync()
        {

            var cityDtos = await _districtService.GetCityCollectionAsync();
            var cityOutputModels = _mapper.Map<IEnumerable<CityOutputModel>>(cityDtos);

            return Ok(cityOutputModels);
        }

        /// <summary>
        /// 取得鄉鎮市區清單
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<IEnumerable<AreaOutputModel>>))]
        public async Task<IActionResult> GetAreaCollectionAsync()
        {

            var areaDtos = await _districtService.GetAreaCollectionAsync();
            var areaOutputModels = _mapper.Map<IEnumerable<AreaOutputModel>>(areaDtos);

            return Ok(areaOutputModels);
        }
    }
}
