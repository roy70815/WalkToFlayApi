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
    /// 縣市實作
    /// </summary>
    public class CityRepository : ICityRepository
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
        /// Initializes a new instance of the <see cref="CityRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public CityRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 取得縣市列表
        /// </summary>
        /// <returns>縣市列表</returns>
        public async Task<IEnumerable<CityModel>> GetAllAsync()
        {
            var sqlCommand = @" SELECT * FROM citys";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<CityModel>(
                    connection,
                    sqlCommand
                    );

                return result;
            }
        }
    }
}
