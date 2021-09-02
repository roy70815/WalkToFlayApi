using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 附屬功能介面
    /// </summary>
    public interface ISystemFunctionDetailService
    {
        /// <summary>
        /// 建立附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailDto">附屬功能Dto</param>
        /// <returns>是否成功</returns>
        Task<Result> CreateAsync(SystemFunctionDetailDto systemFunctionDetailDto);

        /// <summary>
        /// 取得附屬功能列表By大功能Ids
        /// </summary>
        /// <param name="functionIds">大功能Ids</param>
        /// <returns>附屬功能列表</returns>
        Task<IEnumerable<SystemFunctionDetailDto>> GetByFunctionIdsAsync(int[] functionIds);

        /// <summary>
        /// 取得附屬功能列表By附屬功能Ids
        /// </summary>
        /// <param name="functionDetailIds">附屬功能Id</param>
        /// <returns>附屬功能列表</returns>
        Task<IEnumerable<SystemFunctionDetailDto>> GetByFunctionDetailIdAsync(int[] functionDetailIds);

        /// <summary>
        /// 修改附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailDto">附屬功能Dto</param>
        /// <returns>是否成功</returns>
        Task<Result> UpdateAsync(SystemFunctionDetailDto systemFunctionDetailDto);
    }
}
