using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Infrastructure.Helpers;
using WalkToFlayApi.Models.Output;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Controllers.v1
{
    /// <summary>
    /// 選單API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MenuController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The menu service
        /// </summary>
        private readonly IMenuService _menuService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="menuService">The menu service.</param>
        public MenuController(IMapper mapper, IMenuService menuService)
        {
            _mapper = mapper;
            _menuService = menuService;
        }

        /// <summary>
        /// 取得選單列表
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>選單列表</returns>
        [Authorize]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<IEnumerable<MenuOutputModel>>))]
        public async Task<IActionResult> GetAsync()
        {
            var memberId = HttpContext.User.Identities.FirstOrDefault().Name;
            var menuDtos = await _menuService.GetAsync(memberId);
            var menuOutputModels = _mapper.Map<IEnumerable<MenuOutputModel>>(menuDtos);

            return Ok(menuOutputModels);
        }
    }
}
