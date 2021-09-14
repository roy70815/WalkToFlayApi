using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Repository.Interface;

namespace WalkToFlayApi.Repository.Implement
{
    /// <summary>
    /// 角色功能實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.ISystemRoleUserFunctionRepository" />
    public class SystemRoleUserFunctionRepository : ISystemRoleUserFunctionRepository
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
        /// Initializes a new instance of the <see cref="SystemRoleUserFunctionRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public SystemRoleUserFunctionRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 取得附屬功能IdCollection
        /// </summary>
        /// <param name="roleUserId">角色Id</param>
        /// <returns>附屬功能IdCollection</returns>
        public async Task<IEnumerable<int>> GetFunctionDetailIdsByRoleUserIdAsync(int roleUserId)
        {
            var sqlCommand = @" SELECT FunctionDetailId FROM SystemRoleUserFunction 
                                WHERE RoleUserId = @RoleUserId";

            var parameter = new DynamicParameters();
            parameter.Add("RoleUserId", roleUserId);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<int>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                return result;
            }
        }
    }
}
