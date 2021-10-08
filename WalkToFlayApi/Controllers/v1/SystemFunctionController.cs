using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    /// 大功能相關API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SystemFunctionController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The system function service
        /// </summary>
        private readonly ISystemFunctionService _systemFunctionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemFunctionController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="systemFunctionService">The system function service.</param>
        public SystemFunctionController(IMapper mapper, ISystemFunctionService systemFunctionService)
        {
            _mapper = mapper;
            _systemFunctionService = systemFunctionService;
        }

        /// <summary>
        /// 建立大功能
        /// </summary>
        /// <param name="systemFunctionParameter">建立大功能參數</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<Result>))]
        public async Task<IActionResult> CreateAsync(SystemFunctionParameter systemFunctionParameter)
        {
            
            var systemFunctionDto = _mapper.Map<SystemFunctionDto>(systemFunctionParameter);
            var result = await _systemFunctionService.CreateAsync(systemFunctionDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        /// <summary>
        /// 取得所有大功能清單
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<IEnumerable<SystemFunctionOutputModel>>))]
        public async Task<IActionResult> GetAllAsync()
        {
            
            var systemFunctionDtos = await _systemFunctionService.GetAllAsync();
            var systemRoleUserOutputModels = _mapper.Map<IEnumerable<SystemFunctionOutputModel>>(systemFunctionDtos);

            return Ok(systemRoleUserOutputModels);
        }

        /// <summary>
        /// 取得大功能清單By大功能Ids
        /// </summary>
        /// <param name="functionIds">大功能Ids</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<IEnumerable<SystemFunctionOutputModel>>))]
        public async Task<IActionResult> GetAllByFunctionIdsAsync([FromQuery] int[] functionIds)
        {
            var systemFunctionDtos = await _systemFunctionService.GetByFunctionIdsAsync(functionIds);
            var systemRoleUserOutputModels = _mapper.Map<IEnumerable<SystemFunctionOutputModel>>(systemFunctionDtos);

            return Ok(systemRoleUserOutputModels);
        }

        /// <summary>
        /// 修改大功能
        /// </summary>
        /// <param name="systemFunctionParameter">修改大功能參數</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<Result>))]
        public async Task<IActionResult> UpdateAsync(SystemFunctionParameter systemFunctionParameter)
        {

            var systemFunctionDto = _mapper.Map<SystemFunctionDto>(systemFunctionParameter);
            var result = await _systemFunctionService.UpdateAsync(systemFunctionDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            
            return Ok(result);
        }
    }
}
