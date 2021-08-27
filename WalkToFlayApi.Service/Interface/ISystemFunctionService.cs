using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 大功能介面
    /// </summary>
    public interface ISystemFunctionService
    {
        /// <summary>
        /// 建立大功能資料
        /// </summary>
        /// <param name="systemFunctionDto">大功能Dto</param>
        /// <returns></returns>
        Task<Result> CreateAsync(SystemFunctionDto systemFunctionDto);

        /// <summary>
        /// 取得所有大功能清單
        /// </summary>
        /// <returns>大功能清單</returns>
        Task<IEnumerable<SystemFunctionDto>> GetAllAsync();

        /// <summary>
        /// 取得大功能清單ByFunctionId
        /// </summary>
        /// <param name="functionIds">大功能Id</param>
        /// <returns>大功能清單</returns>
        Task<IEnumerable<SystemFunctionDto>> GetByFunctionIdAsync(int[] functionIds);

        /// <summary>
        /// 修改大功能資料
        /// </summary>
        /// <param name="systemFunctionDto">大功能Dto</param>
        /// <returns></returns>
        Task<Result> UpdateAsync(SystemFunctionDto systemFunctionDto);
    }
}
