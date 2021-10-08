using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Input;
using WalkToFlayApi.Models.Output;
using WalkToFlayApi.Service.Dtos;
using WalkToFlayApi.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Infrastructure.Validation;

namespace WalkToFlayApi.Controllers.v1
{
    /// <summary>
    /// 產品API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The product service
        /// </summary>
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="productService">The product service.</param>
        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        /// <summary>
        /// 建立產品
        /// </summary>
        /// <param name="productParameter">建立產品參數</param>
        /// <returns>是否成功</returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<Result>))]
        public async Task<IActionResult> CreateAsync(ProductParameter productParameter)
        {
            
            var productDto = _mapper.Map<ProductDto>(productParameter);
            productDto.CreateUser = HttpContext.User.Identity.Name;

            var result = await _productService.CreateAsync(productDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        ///// <summary>
        ///// 修改產品資料
        ///// </summary>
        ///// <param name="memberEditParameter">修改會員參數</param>
        ///// <returns></returns>
        //[Authorize]
        //[HttpPost("[action]")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<Result>))]
        //public async Task<IActionResult> UpdateAsync(MemberEditParameter memberEditParameter)
        //{
        //    var memberId = HttpContext.User.Identity.Name;
            
        //    var memberParameterDto = _mapper.Map<MemberParameterDto>(memberEditParameter);
        //    var result = await _memberService.UpdateAsync(memberParameterDto);

        //    return Ok(result);
        //}

        /// <summary>
        /// 取得產品詳細資料
        /// </summary>
        /// <returns>會員資料</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<ProductDetailOutputModel>))]
        public async Task<IActionResult> GetAsync(int productId)
        {
            var productDetailDto = await _productService.GetAsync(productId);
            var productDetailOutputModel = _mapper.Map<ProductDetailOutputModel>(productDetailDto);

            return Ok(productDetailOutputModel);
        }

        /// <summary>
        /// 取得產品清單
        /// </summary>
        /// <param name="page">第幾頁</param>
        /// <param name="size">一頁幾筆</param>
        /// <param name="sortColumn">排序欄位</param>
        /// <param name="sortType">排序方式</param>
        /// <returns>產品清單</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessOutputModel<ProductPageOutputModel>))]
        public async Task<IActionResult> GetAllAsync(
            int page = 1,
            int size = 20,
            string sortColumn = "CreateTime",
            string sortType = "DESC")
        {
            var pageDto = new PageDto()
            {
                Page = 1,
                From = (page - 1) * size,
                Size = size,
                SortColumn = sortColumn,
                SortType = sortType
            };
            var productPageDto = await _productService.GetAllAsync(pageDto);
            var productPageOutputModel = _mapper.Map<ProductPageOutputModel>(productPageDto);

            return Ok(productPageOutputModel);
        }
    }
}
