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
using Microsoft.AspNetCore.Authorization;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Infrastructure.Validation;

namespace WalkToFlayApi.Controllers.v1
{
    /// <summary>
    /// 會員相關API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        /// 建立會員
        /// </summary>
        /// <param name="memberParameter">建立會員參數</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<Result>))]
        public async Task<IActionResult> CreateAsync(MemberParameter memberParameter)
        {
            //要加Log
            var memberParameterDto = _mapper.Map<MemberParameterDto>(memberParameter);

            var result = await _memberService.CreateAsync(memberParameterDto);

            return Ok("Test");
        }

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="getMemberParameter">取得會員資料參數</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<MemberOutputModel>))]
        public async Task<IActionResult> GetAsync(GetMemberParameter getMemberParameter)
        {
            var memberDto = await _memberService.GetAsync(getMemberParameter.MemberId, getMemberParameter.Password);
            var memberOutputModel = _mapper.Map<MemberOutputModel>(memberDto);
            return Ok(memberOutputModel);
        }

        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <param name="memberEditPasswordParameter">會員修改密碼參數</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<Result>))]
        public async Task<IActionResult> UpdatePasswordAsync(MemberEditPasswordParameter memberEditPasswordParameter)
        {
            var result = await _memberService.UpdatePasswordAsync(
                memberEditPasswordParameter.MemberId,
                memberEditPasswordParameter.OldPassword,
                memberEditPasswordParameter.NewPassword);
            return Ok(result);
        }
    }
}
