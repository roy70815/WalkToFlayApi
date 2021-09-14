using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 大功能介面
    /// </summary>
    public interface ISystemFunctionRepository
    {
        /// <summary>
        /// 檢查是否存在此大功能名稱
        /// </summary>
        /// <param name="functionName">大功能名稱</param>
        /// <returns></returns>
        Task<bool> CheckExistByFunctionNameAsync(string functionName);

        /// <summary>
        /// 檢查是否存在此大功能
        /// </summary>
        /// <param name="functionId">大功能編號</param>
        /// <returns></returns>
        Task<bool> CheckExistByFunctionIdAsync(int functionId);

        /// <summary>
        /// 建立大功能資料
        /// </summary>
        /// <param name="systemFunctionModel">大功能Model</param>
        /// <returns></returns>
        Task<bool> CreateAsync(SystemFunctionModel systemFunctionModel);

        /// <summary>
        /// 取得所有大功能清單
        /// </summary>
        /// <returns>大功能清單</returns>
        Task<IEnumerable<SystemFunctionModel>> GetAllAsync();

        /// <summary>
        /// 取得大功能清單By大功能Ids
        /// </summary>
        /// <param name="functionIds">大功能Ids</param>
        /// <returns>大功能清單</returns>
        Task<IEnumerable<SystemFunctionModel>> GetByFunctionIdsAsync(IEnumerable<int> functionIds);

        /// <summary>
        /// 修改大功能資料
        /// </summary>
        /// <param name="systemFunctionModel">大功能Model</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(SystemFunctionModel systemFunctionModel);
    }
}
