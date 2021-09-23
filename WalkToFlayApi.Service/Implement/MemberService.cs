using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
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
        public async Task<Result> CreateAsync(MemberParameterDto memberParameterDto)
        {
            var result = new Result(false);
            var isExist = await _memberRepository.CheckExistAsync(memberParameterDto.MemberId);
            if (isExist)
            {
                result.Message = "帳號已存在，請修改帳號";
                return result;
            }
            var memberModel = _mapper.Map<MemberModel>(memberParameterDto);
            memberModel.PassWord = EncryptHelper.SHA256(memberModel.PassWord);
            result.Success = await _memberRepository.CreateAsync(memberModel);
            if (result.Success)
            {
                result.Message = "註冊成功";
                return result;
            }
            else
            {
                result.Message = "發生未知錯誤，請聯絡系統管理員";
                return result;
            }
        }

        /// <summary>
        /// 取得會員清單
        /// </summary>
        /// <param name="pageDto">分頁參數Dto</param>
        /// <returns>會員清單</returns>
        public async Task<MemberPageDto> GetAllAsync(PageDto pageDto)
        {
            var memberPageDto = new MemberPageDto()
            {
                Page = pageDto.Page
            };
            var memberModels = await _memberRepository.GetAllAsync(pageDto);
            memberPageDto.TotalCount = await _memberRepository.GetTotalCountAsync();
            memberPageDto.memberDtos = _mapper.Map<IEnumerable<MemberDto>>(memberModels);

            return memberPageDto;
        }

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>會員資料Dto</returns>
        public async Task<MemberDto> GetAsync(string memberId)
        {
            if (string.IsNullOrWhiteSpace(memberId))
            {
                throw new ArgumentNullException(nameof(memberId));
            }

            var memberModel = await _memberRepository.GetAsync(memberId);
            var memberDto = _mapper.Map<MemberDto>(memberModel);

            return memberDto;
        }

        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="oldPassword">舊密碼</param>
        /// <param name="newPassword">新密碼</param>
        /// <returns></returns>
        public async Task<Result> UpdatePasswordAsync(string memberId, string oldPassword, string newPassword)
        {
            var result = new Result(false);
            oldPassword = EncryptHelper.SHA256(oldPassword);
            newPassword = EncryptHelper.SHA256(newPassword);

            result.Success = await _memberRepository.UpdatePasswordAsync(memberId, oldPassword, newPassword);
            
            if (result.Success)
            {
                //回傳成功訊息
                result.Message = "修改成功，請重新登入";
                result.Success = true;
                return result;
            }
            else
            {
                //回傳失敗訊息
                result.Message = "修改失敗，請確認舊密碼是否正確";
                return result;
            }
        }

        /// <summary>
        /// 修改會員資料
        /// </summary>
        /// <param name="memberParameterDto">會員參數Dto</param>
        /// <returns></returns>
        public async Task<Result> UpdateAsync(MemberParameterDto memberParameterDto)
        {
            var result = new Result(false);

            var memberModel = _mapper.Map<MemberModel>(memberParameterDto);
            result.Success = await _memberRepository.UpdateAsync(memberModel);

            if (result.Success)
            {
                //回傳成功訊息
                result.Message = "修改成功";
                result.Success = true;
                return result;
            }
            else
            {
                //回傳失敗訊息
                result.Message = "修改失敗";
                return result;
            }
        }
    }
}
