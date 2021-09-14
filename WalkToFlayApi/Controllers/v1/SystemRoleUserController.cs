using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Models.Output;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Controllers.v1
{
    /// <summary>
    /// 系統角色相關API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SystemRoleUserController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The system role user service
        /// </summary>
        private readonly ISystemRoleUserService _systemRoleUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemRoleUserController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="systemRoleUserService">The system role user service.</param>
        public SystemRoleUserController(
            IMapper mapper,
            ISystemRoleUserService systemRoleUserService)
        {
            _mapper = mapper;
            _systemRoleUserService = systemRoleUserService;
        }

        /// <summary>
        /// 取得所有角色清單
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<IEnumerable<SystemRoleUserOutputModel>>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var systemRoleUserOutputModels = await _systemRoleUserService.GetAllAsync();
            return Ok(systemRoleUserOutputModels);
        }

        /// <summary>
        /// 建立系統角色
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<Result>))]
        public async Task<IActionResult> CreateAsync([FromBody] string systemRoleUserName)
        {
            var result = await _systemRoleUserService.CreateAsync(systemRoleUserName);
            if (!result.Success)
            {
                //寫Log
            }
            return Ok(result);
        }
    }
}
