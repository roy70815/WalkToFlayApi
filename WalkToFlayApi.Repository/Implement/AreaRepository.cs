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
    /// 鄉鎮縣市區實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.IAreaRepository" />
    public class AreaRepository : IAreaRepository
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
        /// Initializes a new instance of the <see cref="AreaRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public AreaRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 取得鄉鎮縣市區列表
        /// </summary>
        /// <returns>鄉鎮縣市區列表</returns>
        public async Task<IEnumerable<AreaModel>> GetAllAsync()
        {
            var sqlCommand = @" SELECT * FROM areas";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<AreaModel>(
                    connection,
                    sqlCommand
                    );

                return result;
            }
        }
    }
}
