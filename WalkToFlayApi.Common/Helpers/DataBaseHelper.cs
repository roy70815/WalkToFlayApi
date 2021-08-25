using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WalkToFlayApi.Common.Helpers
{
    /// <summary>
    /// DB連線實作
    /// </summary>
    public class DataBaseHelper : IDataBaseHelper
    {
        private IConfiguration _configuration;

        public DataBaseHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetWalkToFlyConnection() => GetConnectionString("WalkToFly");
       
        private MySqlConnection GetConnectionString(string dbName)
        {
            var connectionString = string.Format(_configuration["ConnectionStrings:DBConnection"], dbName);
            return new MySqlConnection(connectionString);
        }
    }
}
