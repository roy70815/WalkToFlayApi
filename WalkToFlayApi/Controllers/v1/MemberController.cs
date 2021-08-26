using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Input;
using WalkToFlayApi.Models.Output;
using WalkToFlayApi.Service.Dtos;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class MemberController : ControllerBase
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
        /// Initializes a new instance of the <see cref="MemberController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="memberService">The member service.</param>
        public MemberController(
            IMapper mapper,
            IMemberService memberService)
        {
            _mapper = mapper;
            _memberService = memberService;
        }

        /// <summary>
        /// 創建會員
        /// </summary>
        /// <param name="memberParameter">建立會員參數</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<string>))]
        public async Task<IActionResult> CreateAsync(MemberParameter memberParameter)
        {
            //要加Log
            var memberParameterDto = _mapper.Map<MemberParameterDto>(memberParameter);

            var result = await _memberService.CreateAsync(memberParameterDto);
            return Ok(result);
        }
    }
}
