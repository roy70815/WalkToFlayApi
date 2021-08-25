using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Input;
using WalkToFlayApi.Service.Dto;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MemberController : Controller
    {
        /// <summary>
        /// The member service
        /// </summary>
        private readonly IMemberService _memberService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberController"/> class.
        /// </summary>
        /// <param name="memberService">The member service.</param>
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        /// <summary>
        /// 創建會員
        /// </summary>
        /// <param name="memberParameter">建立會員參數</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> CreateAsync(MemberParameter memberParameter)
        {
            //要加Log
            var memberParameterDto = new MemberParameterDto()
            {
                MemberId = memberParameter.MemberId,
                FirstName = memberParameter.FirstName,
                LastName = memberParameter.LastName,
                PassWord = memberParameter.PassWord,
                Email = memberParameter.Email,
                BirthDay = memberParameter.BirthDay,
                Sex = memberParameter.Sex,
                MobilePhone = memberParameter.MobilePhone,
                TelePhone = memberParameter.TelePhone,
                County = memberParameter.County,
                City = memberParameter.City,
                Address = memberParameter.Address
            };

            var result = await _memberService.CreateAsync(memberParameterDto);
            return Ok(result);
        }
    }
}
