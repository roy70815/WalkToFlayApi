using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Service.Dtos;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Service.Implement
{
    /// <summary>
    /// 選單實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Service.Interface.IMenuService" />
    public class MenuService : IMenuService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The system role user function repository
        /// </summary>
        private readonly ISystemRoleUserFunctionRepository _systemRoleUserFunctionRepository;

        /// <summary>
        /// The system role repository
        /// </summary>
        private readonly ISystemRoleRepository _systemRoleRepository;

        /// <summary>
        /// The system function repository
        /// </summary>
        private readonly ISystemFunctionDetailRepository _systemFunctionDetailRepository;

        /// <summary>
        /// The system function repository
        /// </summary>
        private readonly ISystemFunctionRepository _systemFunctionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="systemRoleUserFunctionRepository">The system role user function repository.</param>
        /// <param name="systemRoleRepository">The system role repository.</param>
        /// <param name="systemFunctionDetailRepository">The system function detail repository.</param>
        /// <param name="systemFunctionRepository">The system function repository.</param>
        public MenuService(
            IMapper mapper,
            ISystemRoleUserFunctionRepository systemRoleUserFunctionRepository, 
            ISystemRoleRepository systemRoleRepository,
            ISystemFunctionDetailRepository systemFunctionDetailRepository,
            ISystemFunctionRepository systemFunctionRepository
            )
        {
            _mapper = mapper;
            _systemRoleUserFunctionRepository = systemRoleUserFunctionRepository;
            _systemRoleRepository = systemRoleRepository;
            _systemFunctionDetailRepository = systemFunctionDetailRepository;
            _systemFunctionRepository = systemFunctionRepository;
        }

        /// <summary>
        /// 取得選單
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>選單</returns>        
        public async Task<IEnumerable<MenuDto>> GetAsync(string memberId)
        {

            var roleUserId = await _systemRoleRepository.GetRoleUserIdByMemberIdAsync(memberId);
            var functionDetailIds = await _systemRoleUserFunctionRepository.GetFunctionDetailIdsByRoleUserIdAsync(roleUserId);
            var systemFunctionDetailModels = await _systemFunctionDetailRepository.GetByFunctionDetailIdsAsync(functionDetailIds);
            var functionIds = systemFunctionDetailModels.Select(x => x.FunctionId).ToList();
            var systemFunctionModels = await _systemFunctionRepository.GetByFunctionIdsAsync(functionIds);
            var menuDtos = _mapper.Map<IEnumerable<MenuDto>>(systemFunctionModels);
            foreach(var menu in menuDtos)
            {
                var filterfunctionDetailModels = systemFunctionDetailModels.Where(x => x.FunctionId == menu.FunctionId);
                menu.SmallMenuDtos = _mapper.Map<IEnumerable<SmallMenuDto>>(filterfunctionDetailModels);
            }

            return menuDtos;
        }
    }
}
