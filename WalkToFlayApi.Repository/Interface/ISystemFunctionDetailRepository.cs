using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 附屬功能介面
    /// </summary>
    public interface ISystemFunctionDetailRepository
    {
        /// <summary>
        /// 建立附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailModel">附屬功能Model</param>
        /// <returns>是否成功</returns>
        Task<bool> CreateAsync(SystemFunctionDetailModel systemFunctionDetailModel);

        /// <summary>
        /// 檢查是否存在此附屬名稱
        /// </summary>
        /// <param name="functionDetailName">附屬功能名稱</param>
        /// <returns>是否存在</returns>
        Task<bool> CheckExistByFunctionDetailNameAsync(string functionDetailName);

        /// <summary>
        /// 取得附屬功能列表By大功能Ids
        /// </summary>
        /// <param name="functionIds">大功能Ids</param>
        /// <returns>附屬功能列表</returns>
        Task<IEnumerable<SystemFunctionDetailModel>> GetByFunctionIdsAsync(int[] functionIds);

        /// <summary>
        /// 取得附屬功能列表By附屬功能Ids
        /// </summary>
        /// <param name="functionDetailIds">附屬功能Ids</param>
        /// <returns>附屬功能列表</returns>
        Task<IEnumerable<SystemFunctionDetailModel>> GetByFunctionDetailIdsAsync(int[] functionDetailIds);

        /// <summary>
        /// 修改附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailModel">附屬功能Model</param>
        /// <returns>是否成功</returns>
        Task<bool> UpdateAsync(SystemFunctionDetailModel systemFunctionDetailModel);
    }
}
