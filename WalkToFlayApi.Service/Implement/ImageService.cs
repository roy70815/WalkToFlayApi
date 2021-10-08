using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Constents;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Repository.Models;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Service.Implement
{
    /// <summary>
    /// 照片實作
    /// </summary>
    public class ImageService : IImageService
    {
        /// <summary>
        /// The upload file repository
        /// </summary>
        private readonly IUploadFileRepository _uploadFileRepository;

        /// <summary>
        /// The product pic repository
        /// </summary>
        private readonly IProductPicRepository _productPicRepository;

        /// <summary>
        /// The product repository
        /// </summary>
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageService"/> class.
        /// </summary>
        /// <param name="uploadFileRepository">The upload file repository.</param>
        /// <param name="productPicRepository">The product pic repository.</param>
        /// <param name="productRepository">The product repository.</param>
        public ImageService(
            IUploadFileRepository uploadFileRepository, 
            IProductPicRepository productPicRepository,
            IProductRepository productRepository)
        {
            _uploadFileRepository = uploadFileRepository;
            _productPicRepository = productPicRepository;
            _productRepository = productRepository;
        }

        /// <summary>
        /// 上船產品圖片
        /// </summary>
        /// <param name="productId">產品編號</param>
        /// <param name="memberId">會員編號</param>
        /// <param name="fileName">檔案名稱</param>
        /// <param name="stream">檔案</param>
        /// <returns></returns>
        public async Task<Result> UploadProductImagesAsync(int productId, string memberId, string fileName, Stream stream)
        {
            var result = new Result(false);

            result.Success = await _productRepository.CheckExistAsync(productId);
            if (!result.Success)
            {
                result.Message = "產品不存在，無法上傳圖片";
                return result;
            }

            var splitIndex = fileName.LastIndexOf(".") + 1;
            var extName = fileName.Substring(splitIndex).ToLower();
            if (ProjectConstents.Image.AcrossImageFile.All(x => x != extName))
            {
                result.Message = "上傳檔案格式不符";
                return result;
            }


            if (!File.Exists(ProjectConstents.FilePath.ProductImagesFilePath + $@"\{productId}"))
            {
                Directory.CreateDirectory(ProjectConstents.FilePath.ProductImagesFilePath + $@"\{productId}");
            }
            var path = ProjectConstents.FilePath.ProductImagesFilePath + $@"\{productId}" + @$"\{fileName}";
            
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }

            var uploadFileId = Guid.NewGuid();
            var uploadFileModel = new UploadFileModel()
            {
                Id = uploadFileId,
                CreateUser = memberId,
                FileName = fileName,
                Status = 1
            };
            var productPicCountTask = _productPicRepository.GetProductPicCountAsync(productId);
            result.Success = await _uploadFileRepository.CreateAsync(uploadFileModel);
            if (!result.Success)
            {
                result.Message = "寫入上傳紀錄失敗";
            }

            var productPicCount = await productPicCountTask;
            var productPicModel = new ProductPicModel()
            {
                UploadFileId = uploadFileId,
                ProductId = productId,
                Sort = productPicCount + 1,
                Status = 1,
                Path = fileName
            };

            result.Success = await _productPicRepository.CreateAsync(productPicModel);
            if (!result.Success)
            {
                result.Message = "寫入產品照片資料失敗";
            }

            result.Message = "上傳成功";
            return result;
        }
    }
}
