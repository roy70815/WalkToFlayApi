using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WalkToFlayApi.Infrastructure.Helpers;
using WalkToFlayApi.Models.Input;
using WalkToFlayApi.Models.Output;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Controllers.v1
{
    /// <summary>
    /// 登入相關API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LogginController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The member service
        /// </summary>
        private readonly IMemberService _memberService;

        /// <summary>
        /// The loggin service
        /// </summary>
        private readonly ILogginService _logginService;

        /// <summary>
        /// The jwt helper
        /// </summary>
        private readonly IJWTHelper _jWTHelper;

        /// <summary>
        /// The system role service
        /// </summary>
        private readonly ISystemRoleService _systemRoleService;

        /// <summary>
        /// The system role user service
        /// </summary>
        private readonly ISystemRoleUserService _systemRoleUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogginController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="memberService">The member service.</param>
        /// <param name="logginService">The loggin service.</param>
        /// <param name="jWTHelper">The j wt helper.</param>
        /// <param name="systemRoleService">The system role service.</param>
        /// <param name="systemRoleUserService">The system role user service.</param>
        public LogginController(
            IMapper mapper, 
            IMemberService memberService, 
            ILogginService logginService,
            IJWTHelper jWTHelper,
            ISystemRoleService systemRoleService,
            ISystemRoleUserService systemRoleUserService)
        {
            _mapper = mapper;
            _memberService = memberService;
            _logginService = logginService;
            _jWTHelper = jWTHelper;
            _systemRoleService = systemRoleService;
            _systemRoleUserService = systemRoleUserService;
        }

        /// <summary>
        /// 會員登入
        /// </summary>
        /// <param name="logginParameter">登入參數</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(SuccessOutputModel<string>), 200)]
        public async Task<IActionResult> LoginAsync(LogginParameter logginParameter)
        {
            var result = await _logginService.CheckCanLogginAsync(logginParameter.MemberId, logginParameter.Password);
            if (result)
            {
                var roleId = await _systemRoleService.GetRoleUserIdByMemberIdAsync(logginParameter.MemberId);
                if(roleId == 0)
                {
                    return Unauthorized();
                }
                var roleName = await _systemRoleUserService.GetRoleUserNameByRoleUserIdAsync(roleId);
                var claimsIdentity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name, logginParameter.MemberId),
                    new Claim(ClaimTypes.Role, roleName),
                }, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await Request.HttpContext.SignInAsync("Cookies", claimsPrincipal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(10)
                });
                //var jwtToken = _jWTHelper.CreateToken(logginParameter.MemberId);
                //_jWTHelper.ValidateJwtToken(jwtToken);
                //CookieOptions options = new CookieOptions();
                //options.Expires = DateTime.Now.AddHours(1);
                //HttpContext.Response.Cookies.Append("MemberId", logginParameter.MemberId, options);
                //發Token
                return Ok("已成功登入");
            }
            else
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(SuccessOutputModel<string>), 200)]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}
