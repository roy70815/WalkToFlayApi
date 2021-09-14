using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Repository.Models;
using WalkToFlayApi.Service.Dtos;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Service.Implement
{
    /// <summary>
    /// 附屬功能實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Service.Interface.ISystemFunctionDetailService" />
    public class SystemFunctionDetailService : ISystemFunctionDetailService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The system function detail repository
        /// </summary>
        private readonly ISystemFunctionDetailRepository _systemFunctionDetailRepository;

        /// <summary>
        /// The system function repository
        /// </summary>
        private readonly ISystemFunctionRepository _systemFunctionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemFunctionDetailService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="systemFunctionDetailRepository">The system function detail repository.</param>
        /// <param name="systemFunctionRepository">The system function repository.</param>
        public SystemFunctionDetailService(IMapper mapper, 
            ISystemFunctionDetailRepository systemFunctionDetailRepository,
            ISystemFunctionRepository systemFunctionRepository)
        {
            _mapper = mapper;
            _systemFunctionDetailRepository = systemFunctionDetailRepository;
            _systemFunctionRepository = systemFunctionRepository;
        }

        /// <summary>
        /// 建立附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailDto">附屬功能Dto</param>
        /// <returns>是否成功</returns>
        public async Task<Result> CreateAsync(SystemFunctionDetailDto systemFunctionDetailDto)
        {
            var result = new Result(false);

            result.Success = await _systemFunctionRepository.CheckExistByFunctionIdAsync(systemFunctionDetailDto.FunctionId);
            if (!result.Success)
            {
                result.Message = "大功能不存在";
                return result;
            }

            result.Success = await _systemFunctionDetailRepository.CheckExistByFunctionDetailNameAsync(systemFunctionDetailDto.FunctionDetailName);
            if (result.Success)
            {
                result.Message = "此附屬功能名稱已存在";
                return result;
            }

            var systemFunctionDetailModel = _mapper.Map<SystemFunctionDetailModel>(systemFunctionDetailDto);
            result.Success = await _systemFunctionDetailRepository.CreateAsync(systemFunctionDetailModel);

            if (!result.Success)
            {
                result.Message = "新增失敗";
                return result;
            }
            return result;
        }

        /// <summary>
        /// 取得附屬功能列表By大功能Ids
        /// </summary>
        /// <param name="functionIds">大功能Ids</param>
        /// <returns>附屬功能列表</returns>
        public async Task<IEnumerable<SystemFunctionDetailDto>> GetByFunctionIdsAsync(int[] functionIds)
        {
            var systemFunctionDetailModels = await _systemFunctionDetailRepository.GetByFunctionIdsAsync(functionIds);
            var systemFunctionDetailDtos = _mapper.Map<IEnumerable<SystemFunctionDetailDto>>(systemFunctionDetailModels);

            return systemFunctionDetailDtos;
        }

        /// <summary>
        /// 取得附屬功能列表By附屬功能Ids
        /// </summary>
        /// <param name="functionDetailIds">附屬功能Ids</param>
        /// <returns>附屬功能列表</returns>
        public async Task<IEnumerable<SystemFunctionDetailDto>> GetByFunctionDetailIdsAsync(int[] functionDetailIds)
        {
            var systemFunctionDetailModels = await _systemFunctionDetailRepository.GetByFunctionDetailIdsAsync(functionDetailIds);
            var systemFunctionDetailDtos = _mapper.Map<IEnumerable<SystemFunctionDetailDto>>(systemFunctionDetailModels);

            return systemFunctionDetailDtos;
        }

        /// <summary>
        /// 修改附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailDto">附屬功能Dto</param>
        /// <returns>是否成功</returns>
        public async Task<Result> UpdateAsync(SystemFunctionDetailDto systemFunctionDetailDto)
        {
            var result = new Result(false);
            result.Success = await _systemFunctionRepository.CheckExistByFunctionIdAsync(systemFunctionDetailDto.FunctionId);
            if (!result.Success)
            {
                result.Message = "大功能不存在";
                return result;
            }

            result.Success = await _systemFunctionDetailRepository.CheckExistByFunctionDetailNameAsync(systemFunctionDetailDto.FunctionDetailName);
            if (!result.Success)
            {
                result.Message = "此附屬功能名稱已存在";
                return result;
            }

            var systemFunctionDetailModel = _mapper.Map<SystemFunctionDetailModel>(systemFunctionDetailDto);
            result.Success = await _systemFunctionDetailRepository.UpdateAsync(systemFunctionDetailModel);

            if (!result.Success)
            {
                result.Message = "更新失敗";
            }

            return result;
        }
    }
}
