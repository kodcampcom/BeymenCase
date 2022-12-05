using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stock.Core.Models;
using Stock.Core.Services;

namespace Stock.ApiHost.Controllers
{
    public class StockController : ProductBaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public StockController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productsDto = _mapper.Map<List<ProductResponseDto>>(await _productService.GetAllAsync());

            return Result(Response<List<ProductResponseDto>>.Success((int)ResultCodes.Success, productsDto));
        }

        [HttpGet("{productCode}")]
        public IActionResult GetStockByProductCode(string productCode)
        {
            var productsDto = _mapper.Map<ProductResponseDto>(_productService.GetStockByProductCode(productCode));

            return Result(Response<ProductResponseDto>.Success((int)ResultCodes.Success, productsDto));
        }

        [HttpGet("{variantCode}")]
        public IActionResult GetStockByVariantCode(string variantCode)
        {
            var productsDto = _mapper.Map<ProductResponseDto>(_productService.GetStockByVariantCode(variantCode));

            return Result(Response<ProductResponseDto>.Success((int)ResultCodes.Success, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductQuantity(ProductUpdateRequestDto productUpdateRequestDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateRequestDto));

            return Result(Response<ProductResponseDto>.Success((int)ResultCodes.Success));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAll(List<ProductRequestDto> productRequestDtos)
        {
            var products = await _productService.AddRangeAsync(_mapper.Map<List<Product>>(productRequestDtos));
            var productsDto = _mapper.Map<List<ProductRequestDto>>(products);

            return Result(Response<List<ProductRequestDto>>.Success((int)ResultCodes.Success, productsDto));
        }
    }
}
