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
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
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
        /// Initializes a new instance of the <see cref="LogginController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="memberService">The member service.</param>
        /// <param name="logginService">The loggin service.</param>
        public LogginController(
            IMapper mapper, 
            IMemberService memberService, 
            ILogginService logginService)
        {
            _mapper = mapper;
            _memberService = memberService;
            _logginService = logginService;
        }

        /// <summary>
        /// 會員登入
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(SuccessOutputModel<string>), 200)]
        public async Task<IActionResult> LoginAsync(string memberId, string password)
        {
            var result = await _logginService.CheckCanLogginAsync(memberId, password);
            if (result)
            {
                //發Token
                return Ok("看要回傳什麼");
            }
            else
            {
                return Ok("帳號或密碼錯誤");
            }
            
        }
    }
}
