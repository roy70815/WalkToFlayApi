using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Models.Input;
using WalkToFlayApi.Models.Output;
using WalkToFlayApi.Service.Dtos;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Controllers.v1
{
    /// <summary>
    /// 附屬功能API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SystemFunctionDetailController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The system function detail service
        /// </summary>
        private readonly ISystemFunctionDetailService _systemFunctionDetailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemFunctionDetailController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="systemFunctionDetailService">The system function detail service.</param>
        public SystemFunctionDetailController(IMapper mapper, ISystemFunctionDetailService systemFunctionDetailService)
        {
            _mapper = mapper;
            _systemFunctionDetailService = systemFunctionDetailService;
        }

        /// <summary>
        /// 建立附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailParameter">建立附屬功能參數</param>
        /// <returns>是否成功</returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<Result>))]
        public async Task<IActionResult> CreateAsync(SystemFunctionDetailParameter  systemFunctionDetailParameter)
        {

            var systemFunctionDetailDto = _mapper.Map<SystemFunctionDetailDto>(systemFunctionDetailParameter);
            var result = await _systemFunctionDetailService.CreateAsync(systemFunctionDetailDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        /// <summary>
        /// 取得附屬功能列表By大功能Ids
        /// </summary>
        /// <param name="functionIds">大功能Ids</param>
        /// <returns>附屬功能清單</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<IEnumerable<SystemFunctionDetailOutputModel>>))]
        public async Task<IActionResult> GetByFunctionIdsAsync([FromQuery] int[] functionIds)
        {

            var systemFunctionDetailDtos = await _systemFunctionDetailService.GetByFunctionIdsAsync(functionIds);
            var systemRoleUserDetailOutputModels = _mapper.Map<IEnumerable<SystemFunctionDetailOutputModel>>(systemFunctionDetailDtos);

            return Ok(systemRoleUserDetailOutputModels);
        }

        /// <summary>
        /// 取得附屬功能列表By附屬功能Ids
        /// </summary>
        /// <param name="functionDefunctionDetailIdstailId">附屬功能Ids</param>
        /// <returns>附屬功能清單</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<IEnumerable<SystemFunctionDetailOutputModel>>))]
        public async Task<IActionResult> GetByFunctionDetailIdsAsync([FromQuery] int[] functionDefunctionDetailIdstailId)
        {

            var systemFunctionDetailDtos = await _systemFunctionDetailService.GetByFunctionDetailIdsAsync(functionDefunctionDetailIdstailId);
            var systemRoleUserDetailOutputModels = _mapper.Map<IEnumerable<SystemFunctionDetailOutputModel>>(systemFunctionDetailDtos);

            return Ok(systemRoleUserDetailOutputModels);
        }

        /// <summary>
        /// 修改附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailParameter">修改大功能參數</param>
        /// <returns>是否成功</returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<Result>))]
        public async Task<IActionResult> UpdateAsync(SystemFunctionDetailParameter systemFunctionDetailParameter)
        {
            var systemFunctionDetailDto = _mapper.Map<SystemFunctionDetailDto>(systemFunctionDetailParameter);
            var result = await _systemFunctionDetailService.UpdateAsync(systemFunctionDetailDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
