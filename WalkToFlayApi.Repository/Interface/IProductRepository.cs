using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 產品介面
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="productModel">產品Model</param>
        /// <returns>是否成功</returns>
        Task<bool> CreateAsync(ProductModel productModel);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="productModel">產品Model</param>
        /// <returns>是否成功</returns>
        Task<bool> UpdateAsync(ProductModel productModel);

        /// <summary>
        /// 取得產品清單
        /// </summary>
        /// <param name="pageDto">分業參數</param>
        /// <returns>產品清單</returns>
        Task<IEnumerable<ProductModel>> GetAllAsync(PageDto pageDto);

        /// <summary>
        /// 取得產品Model
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns>產品Model</returns>
        Task<ProductModel> GetAsync(int id);

        /// <summary>
        /// 檢查是否有該產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns>是否存在</returns>
        Task<bool> CheckExistAsync(int id);

        /// <summary>
        /// 取得產品總數量
        /// </summary>
        /// <returns>產品總數量</returns>
        Task<int> GetTotalCountAsync();
    }
}
