using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Interface
{
    /// <summary>
    /// 上傳檔案介面
    /// </summary>
    public interface IUploadFileRepository
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="uploadFileModel">上傳檔案Model</param>
        /// <returns>是否成功</returns>
        Task<bool> CreateAsync(UploadFileModel uploadFileModel);
    }
}
