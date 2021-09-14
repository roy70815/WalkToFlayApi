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
    /// 系統角色實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.ISystemRoleUserRepository" />
    public class SystemRoleUserRepository : ISystemRoleUserRepository
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
        /// Initializes a new instance of the <see cref="SystemRoleUserRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public SystemRoleUserRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 檢查是否有此系統角色
        /// </summary>
        /// <param name="roleUserName">角色名稱</param>
        /// <returns>是否有此系統角色</returns>
        public async Task<bool> CheckExistAsync(string roleUserName)
        {
            var sqlCommand = @" SELECT Count(*) 
                                FROM SystemRoleUser
                                WHERE RoleUserName = @RoleUserName";

            var parameter = new DynamicParameters();
            parameter.Add("RoleUserName", roleUserName);

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
        /// 建立系統角色
        /// </summary>
        /// <param name="roleUserName">角色名稱</param>
        /// <returns>是否建立成功</returns>
        public async Task<bool> CreateAsync(string roleUserName)
        {
            var sqlCommand = @" INSERT INTO SystemRoleUser
                                (
                                    RoleUserName
                                ) 
                                VALUES 
                                (
                                    @RoleUserName
                                )";

            var parameter = new DynamicParameters();
            parameter.Add("RoleUserName", roleUserName);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
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
        /// 取得所有角色清單
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SystemRoleUserModel>> GetAllAsync()
        {
            var sqlCommand = @" SELECT * FROM SystemRoleUser";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<SystemRoleUserModel>(
                    connection,
                    sqlCommand
                    );

                return result;
            }
        }

        /// <summary>
        /// 取得角色名稱
        /// </summary>
        /// <param name="roleUserId">角色Id</param>
        /// <returns>角色名稱</returns>
        public async Task<string> GetRoleUserNameByRoleUserIdAsync(int roleUserId)
        {
            var sqlCommand = @" SELECT RoleUserName	 FROM SystemRoleUser
                                WHERE RoleUserId = @RoleUserId";

            var parameter = new DynamicParameters();
            parameter.Add("RoleUserId", roleUserId);

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
    }
}
