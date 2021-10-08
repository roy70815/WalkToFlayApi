using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Repository.Models;
using WalkToFlayApi.Service.Dtos;
using WalkToFlayApi.Service.Infrastructure;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Service.Implement
{
    /// <summary>
    /// 產品實作
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The product repository
        /// </summary>
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// The product log repository
        /// </summary>
        private readonly IProductLogRepository _productLogRepository;

        /// <summary>
        /// The product pic repository
        /// </summary>
        private readonly IProductPicRepository _productPicRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="productLogRepository">The product log repository.</param>
        /// <param name="productPicRepository">The product pic repository.</param>
        public ProductService(
            IMapper mapper, 
            IProductRepository productRepository,
            IProductLogRepository productLogRepository,
            IProductPicRepository productPicRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productLogRepository = productLogRepository;
            _productPicRepository = productPicRepository;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="productDto">產品Dto</param>
        /// <returns>是否成功</returns>
        public async Task<Result> CreateAsync(ProductDto productDto)
        {
            var result = new Result(false);
            var productModel = _mapper.Map<ProductModel>(productDto);

            result.Success = await _productRepository.CreateAsync(productModel);

            if (!result.Success)
            {
                result.Message = "新增失敗";
            }

            result.Message = "新增成功";
            return result;
        }

        /// <summary>
        /// 取得產品清單
        /// </summary>
        /// <param name="pageDto">分業參數</param>
        /// <returns>產品清單頁Dto</returns>
        public async Task<ProductPageDto> GetAllAsync(PageDto pageDto)
        {
            var productPageDto = new ProductPageDto()
            {
                Page = pageDto.Page
            };

            var productTotalCountTask = _productRepository.GetTotalCountAsync();
            var productModels = await _productRepository.GetAllAsync(pageDto);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(productModels);
            foreach(var productDto in productDtos)
            {
                productDto.ImagesCoverPath = await _productPicRepository.GetCoverPicturePathByProductIdAsync(productDto.Id);
            }

            productPageDto.TotalCount = await productTotalCountTask;
            productPageDto.ProductDtos = productDtos;

            return productPageDto;

        }

        /// <summary>
        /// 取得產品Model
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns>產品DetailModel</returns>        
        public async Task<ProductDetailDto> GetAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }
            var imagesPathTask = _productPicRepository.GetImagesPathByProductIdAsync(id);
            var productModel = await _productRepository.GetAsync(id);
            var productDetailDto = _mapper.Map<ProductDetailDto>(productModel);
            productDetailDto.ImagesPath = await imagesPathTask;

            return productDetailDto;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="productDto">產品Dto</param>
        /// <returns>是否成功</returns>
        public async Task<Result> UpdateAsync(ProductDto productDto)
        {
            var result = new Result(false);
            var productModel = _mapper.Map<ProductModel>(productDto);
            
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    result.Success = await _productRepository.UpdateAsync(productModel);
                    if (!result.Success)
                    {
                        result.Message = "修改失敗";
                    }
                    var productLogModel = _mapper.Map<ProductLogModel>(productDto);
                    result.Success = await _productLogRepository.CreateAsync(productLogModel);
                    if (!result.Success)
                    {
                        result.Message = "ProductLog建立失敗";
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    result.Message = "修改產品異常失敗";
                    scope.Dispose();
                }  
            }

            return result;
        }
    }
}
