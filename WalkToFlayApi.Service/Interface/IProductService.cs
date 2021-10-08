using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 產品介面
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="productDto">產品Dto</param>
        /// <returns>是否成功</returns>
        Task<Result> CreateAsync(ProductDto productDto);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="productDto">產品Dto</param>
        /// <returns>是否成功</returns>
        Task<Result> UpdateAsync(ProductDto productDto);

        /// <summary>
        /// 取得產品清單
        /// </summary>
        /// <param name="pageDto">分業參數</param>
        /// <returns>產品清單頁Dto</returns>
        Task<ProductPageDto> GetAllAsync(PageDto pageDto);

        /// <summary>
        /// 取得產品Model
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns>產品DetailModel</returns>
        Task<ProductDetailDto> GetAsync(int id);
    }
}
