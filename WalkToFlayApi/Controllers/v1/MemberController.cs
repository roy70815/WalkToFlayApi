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

            return Ok(result);
        }

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <returns>會員資料</returns>
        [Authorize]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<MemberOutputModel>))]
        public async Task<IActionResult> GetAsync()
        {
            var memberId = HttpContext.User.Identity.Name;
            var memberDto = await _memberService.GetAsync(memberId);
            var memberOutputModel = _mapper.Map<MemberOutputModel>(memberDto);
            return Ok(memberOutputModel);
        }

        /// <summary>
        /// 取得會員資料(管理者專用)
        /// </summary>
        /// <returns>會員資料</returns>
        [Authorize(Roles ="administrator")]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<MemberOutputModel>))]
        public async Task<IActionResult> GetByMemberIdAsync(string memberId)
        {
            var memberDto = await _memberService.GetAsync(memberId);
            var memberOutputModel = _mapper.Map<MemberOutputModel>(memberDto);
            return Ok(memberOutputModel);
        }

        /// <summary>
        /// 取得會員清單
        /// </summary>
        /// <param name="page">第幾頁</param>
        /// <param name="size">一頁幾筆</param>
        /// <param name="sortColumn">排序欄位</param>
        /// <param name="sortType">排序方式</param>
        /// <returns>會員清單</returns>
        [Authorize(Roles ="administrator")]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<MemberPageOutputModel>))]
        public async Task<IActionResult> GetAllAsync(
            int page = 1, 
            int size = 20, 
            string sortColumn = "CreateTime", 
            string sortType = "DESC")
        {
            var pageDto = new PageDto()
            {
                Page = 1,
                From = (page - 1)*size,
                Size = size,
                SortColumn = sortColumn,
                SortType = sortType
            };
            var memberPageDto = await _memberService.GetAllAsync(pageDto);
            var memberPageOutputModel = _mapper.Map<MemberPageOutputModel>(memberPageDto);
            return Ok(memberPageOutputModel);
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
            var memberId = HttpContext.User.Identity.Name;
            var result = await _memberService.UpdatePasswordAsync(
                memberId,
                memberEditPasswordParameter.OldPassword,
                memberEditPasswordParameter.NewPassword);
            return Ok(result);
        }
    }
}
