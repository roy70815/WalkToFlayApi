using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 產品照片介面
    /// </summary>
    public interface IProductPicRepository
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="productPicModel">產品照片Model</param>
        /// <returns></returns>
        Task<bool> CreateAsync(ProductPicModel productPicModel);

        /// <summary>
        /// 取得產品照片數量
        /// </summary>
        /// <param name="productId">產品編號</param>
        /// <returns></returns>
        Task<int> GetProductPicCountAsync(int productId);

        /// <summary>
        /// 取得產品所有照片路徑
        /// </summary>
        /// <param name="productId">產品編號</param>
        /// <returns>產品所有照片路徑</returns>
        Task<IEnumerable<string>> GetImagesPathByProductIdAsync(int productId);

        /// <summary>
        /// 取得產品封面照路徑
        /// </summary>
        /// <param name="productId">產品編號</param>
        /// <returns>產品封面照路徑</returns>
        Task<string> GetCoverPicturePathByProductIdAsync(int productId);
    }
}
