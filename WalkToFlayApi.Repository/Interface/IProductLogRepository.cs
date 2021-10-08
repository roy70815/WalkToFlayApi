using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 產品記錄介面
    /// </summary>
    public interface IProductLogRepository
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="productLogModel">產品紀錄 Model</param>
        /// <returns>是否成功</returns>
        Task<bool> CreateAsync(ProductLogModel productLogModel);
    }
}
