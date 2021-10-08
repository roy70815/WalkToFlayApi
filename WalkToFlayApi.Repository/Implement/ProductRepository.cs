using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Implement
{
    /// <summary>
    /// 產品實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.IProductRepository" />
    public class ProductRepository : IProductRepository
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
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public ProductRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="productModel">產品Model</param>
        /// <returns>是否成功</returns>
        public async Task<bool> CreateAsync(ProductModel productModel)
        {
            var sqlCommand = @" INSERT INTO Product
                                (
                                    Name, 
                                    Description, 
                                    Price, 
                                    Status,
                                    CreateUser
                                ) 
                                VALUES 
                                (
                                    @Name,
                                    @Description,
                                    @Price,
                                    @Status,
                                    @CreateUser
                                )";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    productModel
                    );

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 取得產品清單
        /// </summary>
        /// <param name="pageDto">分業參數</param>
        /// <returns>產品清單</returns>
        public async Task<IEnumerable<ProductModel>> GetAllAsync(PageDto pageDto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT * FROM Product ");
            sqlCommand.Append(PageHelper.GetSortSQL());
            sqlCommand.Append(PageHelper.GetPageSQL());

            var parameter = new DynamicParameters();
            parameter.Add("From", pageDto.From);
            parameter.Add("Size", pageDto.Size);
            parameter.Add("SortColumn", pageDto.SortColumn);
            parameter.Add("SortType", pageDto.SortType);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<ProductModel>(
                    connection,
                    sqlCommand.ToString(),
                    parameter
                    );

                return result;
            }
        }

        /// <summary>
        /// 取得產品Model
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns>產品Model</returns>
        public async Task<ProductModel> GetAsync(int id)
        {
            var sqlCommand = @" SELECT * 
                                FROM Product
                                WHERE Id = @Id";

            var parameter = new DynamicParameters();
            parameter.Add("Id", id);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<ProductModel>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                return result;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="productModel">產品Model</param>
        /// <returns>是否成功</returns>
        public async Task<bool> UpdateAsync(ProductModel productModel)
        {
            var sqlCommand = @" Update Product Set
                                    Name = @Name,
                                    Description = @Description,
                                    Price = @Price,
                                    Status = @Status,
                                    UpdateTime = CURRENT_TIME()
                                WHERE Id = @Id;";

            var parameter = new DynamicParameters();
            parameter.Add("Name", productModel.Name);
            parameter.Add("Description", productModel.Description);
            parameter.Add("Price", productModel.Price);
            parameter.Add("Status", productModel.Status);
            parameter.Add("Id", productModel.Id);


            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    parameter);

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 檢查是否有該產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns>是否存在</returns>
        public async Task<bool> CheckExistAsync(int id)
        {
            var sqlCommand = @" SELECT COUNT(*) 
                                FROM Product
                                WHERE Id = @Id";

            var parameter = new DynamicParameters();
            parameter.Add("Id", id);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<int>(
                    connection,
                    sqlCommand,
                    parameter
                    );
                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 取得產品總數量
        /// </summary>
        /// <returns>產品總數量</returns>
        public async Task<int> GetTotalCountAsync()
        {
            var sqlCommand = @" SELECT COUNT(*) FROM Product";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<int>(
                    connection,
                    sqlCommand
                    );

                return result;
            }
        }
    }
}
