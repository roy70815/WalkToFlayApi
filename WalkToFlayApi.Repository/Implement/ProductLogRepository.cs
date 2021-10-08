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
    /// 產品紀錄實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.IProductLogRepository" />
    public class ProductLogRepository : IProductLogRepository
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
        /// Initializes a new instance of the <see cref="ProductLogRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public ProductLogRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="productLogModel">產品紀錄 Model</param>
        /// <returns>是否成功</returns>
        public async Task<bool> CreateAsync(ProductLogModel productLogModel)
        {
            var sqlCommand = @" INSERT INTO ProductLog
                                (
                                    ProductId,
                                    Name, 
                                    Description, 
                                    Price, 
                                    Status,
                                    UpdateUser
                                ) 
                                VALUES 
                                (
                                    @ProductId,
                                    @Name,
                                    @Description,
                                    @Price,
                                    @Status,
                                    @UpdateUser
                                )";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    productLogModel
                    );

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
