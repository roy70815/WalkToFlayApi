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
    /// 附屬功能實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.ISystemFunctionDetailRepository" />
    public class SystemFunctionDetailRepository : ISystemFunctionDetailRepository
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
        /// Initializes a new instance of the <see cref="SystemFunctionDetailRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public SystemFunctionDetailRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 檢查是否存在此附屬名稱
        /// </summary>
        /// <param name="functionDetailName">附屬功能名稱</param>
        /// <returns>是否存在</returns>
        public async Task<bool> CheckExistByFunctionDetailNameAsync(string functionDetailName)
        {
            var sqlCommand = @" SELECT COUNT(*) 
                                FROM SystemFunctionDetail 
                                WHERE FunctionDetailName = @FunctionDetailName;";

            var parameter = new DynamicParameters();
            parameter.Add("FunctionDetailName", functionDetailName);

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
        /// 建立附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailModel">附屬功能Model</param>
        /// <returns>是否成功</returns>
        public async Task<bool> CreateAsync(SystemFunctionDetailModel systemFunctionDetailModel)
        {
            var sqlCommand = @" INSERT INTO SystemFunctionDetail(
                                    FunctionId, 
                                    FunctionDetailName, 
                                    FunctionDetailChineseName, 
                                    Url,
                                    Remark, 
                                    Sort
                                ) 
                                VALUES (
                                    @FunctionId,
                                    @FunctionDetailName,
                                    @FunctionDetailChineseName,
                                    @Url,
                                    @Remark,
                                    @Sort
                                )";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    systemFunctionDetailModel
                    );

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 取得附屬功能列表By大功能Ids
        /// </summary>
        /// <param name="functionIds">大功能Ids</param>
        /// <returns>附屬功能列表</returns>
        public async Task<IEnumerable<SystemFunctionDetailModel>> GetByFunctionIdsAsync(int[] functionIds)
        {
            var sqlCommand = @" SELECT * 
                                FROM SystemFunctionDetail
                                Where FunctionId IN @FunctionId
                                AND EnableFlag = 1;";

            var parameter = new DynamicParameters();
            parameter.Add("FunctionId", functionIds);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<SystemFunctionDetailModel>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                return result;
            }
        }

        /// <summary>
        /// 取得附屬功能列表By附屬功能Ids
        /// </summary>
        /// <param name="functionDetailIds">附屬功能Ids</param>
        /// <returns>附屬功能列表</returns>
        public async Task<IEnumerable<SystemFunctionDetailModel>> GetByFunctionDetailIdsAsync(IEnumerable<int> functionDetailIds)
        {
            var sqlCommand = @" SELECT * 
                                FROM SystemFunctionDetail
                                WHERE FunctionDetailId IN @FunctionDetailId
                                AND EnableFlag = 1;";

            var parameter = new DynamicParameters();
            parameter.Add("FunctionDetailId", functionDetailIds);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<SystemFunctionDetailModel>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                return result;
            }
        }

        /// <summary>
        /// 修改附屬功能
        /// </summary>
        /// <param name="systemFunctionDetailModel">附屬功能Model</param>
        /// <returns>是否成功</returns>
        public async Task<bool> UpdateAsync(SystemFunctionDetailModel systemFunctionDetailModel)
        {
            var sqlCommand = @" UPDATE SystemFunctionDetail SET 
	                                FunctionId = @FunctionId,
	                                FunctionDetailName = @FunctionDetailName,
	                                FunctionDetailChineseName = @FunctionDetailChineseName,
                                    Url = @Url,
	                                Remark = @Remark,
	                                Sort = @Sort,
	                                EnableFlag = @EnableFlag
                                WHERE FunctionDetailId = @FunctionDetailId";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    systemFunctionDetailModel
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
