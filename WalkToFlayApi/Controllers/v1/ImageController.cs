using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Models.Output;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Controllers.v1
{
    /// <summary>
    /// 照片API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ImageController : Controller
    {
        /// <summary>
        /// The image service
        /// </summary>
        private readonly IImageService _imageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageController"/> class.
        /// </summary>
        /// <param name="imageService">The image service.</param>
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        /// <summary>
        /// 上傳產品圖片
        /// </summary>
        /// <param name="productId">產品編號</param>
        /// <param name="file">上傳檔案</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(SuccessOutputModel<Result>), 200)]
        public async Task<IActionResult> UploadProductImageAsync([FromQuery] int productId, IFormFile file)
        {
            var memberId = HttpContext.User.Identity.Name;
            var fileName = file.FileName;
            using (var memoryStream = new MemoryStream())
            {
                
                file.CopyTo(memoryStream);
                var result = await _imageService.UploadProductImagesAsync(productId, memberId, fileName, memoryStream);

                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result);
            }
        }
    }
}
