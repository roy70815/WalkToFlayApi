using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Service.Dtos;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Service.Implement
{
    /// <summary>
    /// 系統角色介面
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.ISystemRoleUserService" />
    public class SystemRoleUserService : ISystemRoleUserService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The system role user repository
        /// </summary>
        private readonly ISystemRoleUserRepository _systemRoleUserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemRoleUserService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="systemRoleUserRepository">The system role user repository.</param>
        public SystemRoleUserService(IMapper mapper, ISystemRoleUserRepository systemRoleUserRepository)
        {
            _mapper = mapper;
            _systemRoleUserRepository = systemRoleUserRepository;
        }

        /// <summary>
        /// 建立系統角色
        /// </summary>
        /// <param name="roleUserName">角色名稱</param>
        /// <returns></returns>
        public async Task<Result> CreateAsync(string roleUserName)
        {
            var result = new Result(false);
            var isExist = await _systemRoleUserRepository.CheckExistAsync(roleUserName.ToLower());
            if (isExist)
            {
                result.Message = "已存在該角色";
                return result;
            }
            result.Success = await _systemRoleUserRepository.CreateAsync(roleUserName.ToLower());
            if (!result.Success)
            {
                result.Message = "新增失敗";
                return result;
            }

            return result;
        }

        /// <summary>
        /// 取得所有系統角色清單
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SystemRoleUserDto>> GetAllAsync()
        {
            var systemRoleUserModels = await _systemRoleUserRepository.GetAllAsync();
            var systemRoleUserDtos = _mapper.Map<IEnumerable<SystemRoleUserDto>>(systemRoleUserModels);

            return systemRoleUserDtos;
        }

        /// <summary>
        /// 取得角色名稱
        /// </summary>
        /// <param name="roleUserId">角色Id</param>
        /// <returns>角色名稱</returns>        
        public async Task<string> GetRoleUserNameByRoleUserIdAsync(int roleUserId)
        {
            return await _systemRoleUserRepository.GetRoleUserNameByRoleUserIdAsync(roleUserId);
        }
    }
}
