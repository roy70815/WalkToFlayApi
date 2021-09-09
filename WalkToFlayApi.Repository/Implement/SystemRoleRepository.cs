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
    /// 規則(帳號綁角色)實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.ISystemRoleRepository" />
    public class SystemRoleRepository : ISystemRoleRepository
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
        /// Initializes a new instance of the <see cref="SystemRoleRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public SystemRoleRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 取得角色Id
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>角色Id</returns>
        public async Task<int> GetRoleUserIdByMemberIdAsync(string memberId)
        {
            var sqlCommand = @" SELECT RoleUserId FROM SystemRole 
                                WHERE MemberId = @MemberId";

            var parameter = new DynamicParameters();
            parameter.Add("MemberId",memberId);

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
    }
}
