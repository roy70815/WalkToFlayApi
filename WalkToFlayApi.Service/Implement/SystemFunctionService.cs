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
    /// 大功能實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Service.Interface.ISystemFunctionService" />
    public class SystemFunctionService : ISystemFunctionService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The system function repository
        /// </summary>
        private readonly ISystemFunctionRepository _systemFunctionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemFunctionService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="systemFunctionRepository">The system function repository.</param>
        public SystemFunctionService(
            IMapper mapper, 
            ISystemFunctionRepository systemFunctionRepository)
        {
            _mapper = mapper;
            _systemFunctionRepository = systemFunctionRepository;
        }

        /// <summary>
        /// 建立大功能資料
        /// </summary>
        /// <param name="systemFunctionDto">大功能Dto</param>
        /// <returns></returns>
        public async Task<Result> CreateAsync(SystemFunctionDto systemFunctionDto)
        {
            var result = new Result(false);
            var isExist = await _systemFunctionRepository.CheckExistByFunctionNameAsync(systemFunctionDto.FunctionName);
            if (isExist)
            {
                result.Message = "大功能名稱已存在";
                return result;
            }

            var systemFunctionModel = _mapper.Map<SystemFunctionModel>(systemFunctionDto);
            result.Success = await _systemFunctionRepository.CreateAsync(systemFunctionModel);
            if (!result.Success)
            {
                result.Message = "新增失敗";
                return result;
            }

            return result;
        }

        /// <summary>
        /// 取得所有大功能清單
        /// </summary>
        /// <returns>大功能清單</returns>
        public async Task<IEnumerable<SystemFunctionDto>> GetAllAsync()
        {
            var systemFunctionModels = await _systemFunctionRepository.GetAllAsync();
            var systemFunctionDtos = _mapper.Map<IEnumerable<SystemFunctionDto>>(systemFunctionModels);

            return systemFunctionDtos;
        }

        /// <summary>
        /// 取得大功能清單By大功能Ids
        /// </summary>
        /// <param name="functionIds">大功能Ids</param>
        /// <returns>大功能清單</returns>
        public async Task<IEnumerable<SystemFunctionDto>> GetByFunctionIdsAsync(int[] functionIds)
        {
            if(functionIds.Length < 1)
            {
                throw new ArgumentNullException(nameof(functionIds));
            }

            var systemFunctionModels = await _systemFunctionRepository.GetByFunctionIdsAsync(functionIds);
            var systemFunctionDtos = _mapper.Map<IEnumerable<SystemFunctionDto>>(systemFunctionModels);

            return systemFunctionDtos;
        }

        /// <summary>
        /// 修改大功能資料
        /// </summary>
        /// <param name="systemFunctionDto">大功能Dto</param>
        /// <returns></returns>
        public async Task<Result> UpdateAsync(SystemFunctionDto systemFunctionDto)
        {
            var result = new Result(false);
            var isExist = await _systemFunctionRepository.CheckExistByFunctionNameAsync(systemFunctionDto.FunctionName);
            if (isExist)
            {
                result.Message = "大功能名稱已存在";
                return result;
            }

            var systemFunctionModel = _mapper.Map<SystemFunctionModel>(systemFunctionDto);
            result.Success = await _systemFunctionRepository.UpdateAsync(systemFunctionModel);

            if (!result.Success)
            {
                result.Message = "更新失敗";
            }

            return result;
        }
    }
}
