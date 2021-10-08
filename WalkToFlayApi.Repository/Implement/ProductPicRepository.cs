using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Implement
{
    /// <summary>
    /// 產品照片實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.IProductPicRepository" />
    public class ProductPicRepository : IProductPicRepository
    {
        /// <summary>
        /// DapperHelper
        /// </summary>
        private readonly IDapperHelper _dapperHelper;

        /// <summary>
        /// DataBaseHelper
        /// </summary>
        private readonly IDataBaseHelper _dataBaseHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductPicRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public ProductPicRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="productPicModel">產品照片Model</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(ProductPicModel productPicModel)
        {
            var sqlCommand = @" INSERT INTO ProductPic
                                (
                                    UploadFileId, 
                                    ProductId, 
                                    Path, 
                                    Sort, 
                                    Status
                                ) 
                                VALUES 
                                (
                                    @UploadFileId,
                                    @ProductId,
                                    @Path,
                                    @Sort,
                                    @Status
                                )";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    productPicModel
                    );

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 取得產品照片數量
        /// </summary>
        /// <param name="productId">產品編號</param>
        /// <returns>該產品照片數量</returns>
        public async Task<int> GetProductPicCountAsync(int productId)
        {
            var sqlCommand = @" SELECT COUNT(*) 
                                FROM ProductPic
                                WHERE ProductId = @ProductId";

            var parameter = new DynamicParameters();
            parameter.Add("ProductId", productId);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<int>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                
                return result;
            }
        }

        /// <summary>
        /// 取得產品封面照路徑
        /// </summary>
        /// <param name="productId">產品編號</param>
        /// <returns>產品封面照路徑</returns>
        public async Task<string> GetCoverPicturePathByProductIdAsync(int productId)
        {
            var sqlCommand = @" SELECT Path
                                FROM ProductPic
                                WHERE ProductId = @ProductId
                                Order By Sort ASC
                                LIMIT 1;";

            var parameter = new DynamicParameters();
            parameter.Add("ProductId", productId);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<string>(
                    connection,
                    sqlCommand,
                    parameter
                    );


                return result;
            }
        }

        /// <summary>
        /// 取得產品所有照片路徑
        /// </summary>
        /// <param name="productId">產品編號</param>
        /// <returns>產品所有照片路徑</returns>
        public async Task<IEnumerable<string>> GetImagesPathByProductIdAsync(int productId)
        {
            var sqlCommand = @" SELECT Path
                                FROM ProductPic
                                WHERE ProductId = @ProductId
                                Order By Sort ASC;";

            var parameter = new DynamicParameters();
            parameter.Add("ProductId", productId);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<string>(
                    connection,
                    sqlCommand,
                    parameter
                    );


                return result;
            }
        }
    }
}
