using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Repository.Models;
using WalkToFlayApi.Service.Dtos;
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
            memberModel.PassWord = EncryptHelper.SHA256(memberModel.PassWord);
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

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="password">密碼</param>
        /// <returns>會員資料Dto</returns>
        public async Task<MemberDto> GetAsync(string memberId, string password)
        {
            if (string.IsNullOrWhiteSpace(memberId))
            {
                throw new ArgumentNullException(nameof(memberId));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var memberModel = await _memberRepository.GetAsync(memberId, password);
            var memberDto = _mapper.Map<MemberDto>(memberModel);

            return memberDto;
        }

        ///// <summary>
        ///// 修改密碼
        ///// </summary>
        ///// <param name="memberId">會員Id</param>
        ///// <param name="oldPassword">舊密碼</param>
        ///// <param name="newPassword">新密碼</param>
        ///// <returns></returns>
        //public async Task<bool> UpdatePasswordAsync(string memberId, string oldPassword, string newPassword)
        //{
        //    oldPassword = EncryptHelper.SHA256(oldPassword);
        //    newPassword = EncryptHelper.SHA256(newPassword);

        //    var result = await _memberRepository.UpdatePasswordAsync(memberId, oldPassword, newPassword);
        //    //
        //    if (result)
        //    {
        //        //回傳成功訊息
        //    }
        //    else
        //    {
        //        //回傳失敗訊息
        //    }
        //}
    }
}
