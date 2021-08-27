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
    /// 大功能實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.ISystemFunctionRepository" />
    public class SystemFunctionRepository : ISystemFunctionRepository
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
        /// Initializes a new instance of the <see cref="SystemFunctionRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public SystemFunctionRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 檢查是否存在此大功能名稱
        /// </summary>
        /// <param name="FunctionName">大功能名稱</param>
        /// <returns></returns>
        public async Task<bool> CheckExistAsync(string functionName)
        {
            var sqlCommand = @" SELECT COUNT(*) 
                                FROM SystemFunction 
                                WHERE FunctionName = @FunctionName;";

            var parameter = new DynamicParameters();
            parameter.Add("FunctionName", functionName);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<int>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                if(result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 建立大功能資料
        /// </summary>
        /// <param name="systemFunctionModel">大功能Model</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(SystemFunctionModel systemFunctionModel)
        {
            var sqlCommand = @" INSERT INTO SystemFunction( 
	                                FunctionName, 
	                                FunctionChineseName, 
	                                EnableFlag, 
	                                Remark, 
	                                Sort
                                ) 
                                VALUES (
	                                @FunctionName,
	                                @FunctionChineseName,
	                                @EnableFlag,
	                                @Remark,
	                                @Sort
                                )";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    systemFunctionModel
                    );

                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 取得所有大功能清單
        /// </summary>
        /// <returns>大功能清單</returns>
        public async Task<IEnumerable<SystemFunctionModel>> GetAllAsync()
        {
            var sqlCommand = @" SELECT * FROM SystemFunction";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<SystemFunctionModel>(
                    connection,
                    sqlCommand
                    );

                return result;
            }
        }

        /// <summary>
        /// 取得大功能清單ByFunctionId
        /// </summary>
        /// <param name="functionId">大功能Id</param>
        /// <returns>大功能清單</returns>
        public async Task<IEnumerable<SystemFunctionModel>> GetByFunctionIdAsync(int[] functionId)
        {
            var sqlCommand = @" SELECT * 
                                FROM SystemFunction
                                WHERE FunctionId IN @FunctionId;";

            var parameter = new DynamicParameters();
            parameter.Add("FunctionId", functionId);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<SystemFunctionModel>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                return result;
            }
        }

        /// <summary>
        /// 修改大功能資料
        /// </summary>
        /// <param name="systemFunctionModel">大功能Model</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(SystemFunctionModel systemFunctionModel)
        {
            var sqlCommand = @" UPDATE SystemFunction SET 
                                    FunctionName = @FunctionName,
                                    FunctionChineseName = @FunctionChineseName,
                                    EnableFlag = @EnableFlag,
                                    Remark = @Remark,
                                    Sort = @Sort 
                                WHERE FunctionId = @FunctionId";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    systemFunctionModel
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
