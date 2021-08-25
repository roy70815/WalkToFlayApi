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
        /// The member repository
        /// </summary>
        private readonly IMemberRepository _memberRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberService"/> class.
        /// </summary>
        /// <param name="memberRepository">The member repository.</param>
        public MemberService(IMemberRepository memberRepository)
        {
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
            var memberModel = new MemberModel()
            {
                MemberId = memberParameterDto.MemberId,
                FirstName = memberParameterDto.FirstName,
                LastName = memberParameterDto.LastName,
                PassWord = memberParameterDto.PassWord,
                Email = memberParameterDto.Email,
                BirthDay = memberParameterDto.BirthDay,
                Sex = memberParameterDto.Sex,
                MobilePhone = memberParameterDto.MobilePhone,
                TelePhone = memberParameterDto.TelePhone,
                County = memberParameterDto.County,
                City = memberParameterDto.City,
                Address = memberParameterDto.Address,
                EnableFlag = true //暫時沒有審核機制
            };
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
