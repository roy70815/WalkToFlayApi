using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;

namespace WalkToFlayApi.Service.Interface
{
    /// <summary>
    /// 照片介面
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// 上船產品圖片
        /// </summary>
        /// <param name="productId">產品編號</param>
        /// <param name="memberId">會員編號</param>
        /// <param name="fileName">檔案名稱</param>
        /// <param name="stream">檔案</param>
        /// <returns></returns>
        Task<Result> UploadProductImagesAsync(int productId, string memberId, string fileName, Stream stream);
    }
}
