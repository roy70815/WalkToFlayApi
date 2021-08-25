using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Repository.Models;
using WalkToFlayApi.Service.Dto;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Service.Implement
{
    /// <summary>
    /// 會員實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Service.Interface.IMemberService" />
    public class MemberService : IMemberService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The member repository
        /// </summary>
        private readonly IMemberRepository _memberRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="memberRepository">The member repository.</param>
        public MemberService(
            IMapper mapper,
            IMemberRepository memberRepository)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
        }

        /// <summary>
        /// 建立會員
        /// </summary>
        /// <param name="memberParameterDto">會員參數Dto</param>
        /// <returns>結果訊息</returns>
        public async Task<string> CreateAsync(MemberParameterDto memberParameterDto)
        {
            var isExist = await _memberRepository.CheckExistAsync(memberParameterDto.MemberId);
            if (isExist)
            {
                return "帳號已存在，請修改帳號";
            }
            var memberModel = _mapper.Map<MemberModel>(memberParameterDto);
            
            var result = await _memberRepository.CreateAsync(memberModel);
            if (result)
            {
                return "註冊成功";
            }
            else
            {
                return "發生未知錯誤，請聯絡系統管理員";
            }
        }
    }
}
