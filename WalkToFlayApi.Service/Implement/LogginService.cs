using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Service.Implement
{
    /// <summary>
    /// 登入實作
    /// </summary>
    /// <seealso cref="ILogginService" />
    public class LogginService : ILogginService
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
        /// Initializes a new instance of the <see cref="LogginService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="memberRepository">The member repository.</param>
        public LogginService(IMapper mapper, IMemberRepository memberRepository)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
        }

        /// <summary>
        /// 檢查是否可登入
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public async Task<bool> CheckCanLogginAsync(string memberId, string password)
        {
            if (string.IsNullOrWhiteSpace(memberId))
            {
                throw new ArgumentNullException(nameof(memberId));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            password = EncryptHelper.SHA256(password);
            var result = await _memberRepository.CheckCanLoginAsync(memberId, password);
            
            return result;
        }
    }
}
