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
    /// 上傳檔案實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Repository.Interface.IUploadFileRepository" />
    public class UploadFileRepository : IUploadFileRepository
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
        /// Initializes a new instance of the <see cref="UploadFileRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public UploadFileRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="uploadFileModel">上傳檔案Model</param>
        /// <returns>是否成功</returns>
        public async Task<bool> CreateAsync(UploadFileModel uploadFileModel)
        {
            var sqlCommand = @" INSERT INTO UploadFile(
                                    Id,
                                    FileName, 
                                    Status, 
                                    CreateUser
                                ) 
                                VALUES 
                                (
                                    @Id,
                                    @FileName,
                                    @Status,
                                    @CreateUser
                                )";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    uploadFileModel
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
