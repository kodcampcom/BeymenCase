using Stock.Core.Models;

namespace Stock.Core.Services
{
    public interface IProductService : IService<Product>
    {
        ProductResponseDto GetStockByProductCode(string productCode);
        ProductResponseDto GetStockByVariantCode(string variantCode);

        ProductResponseDto UpdateStockQuantityByVariantCode(string variantCode, int quantity);

        //List<ProductDto> GetAllProducts();
        ////Task<List<ProductDto>> CreateAsync(List<ProductDto> productDto);
        ////void Create(ProductDto productDto);
    }
}
