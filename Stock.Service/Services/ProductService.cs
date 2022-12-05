using AutoMapper;
using Stock.Core.Models;
using Stock.Core.Repository;
using Stock.Core.Services;
using Stock.Core.UnitOfWork;

namespace Stock.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductResponseDto GetStockByProductCode(string productCode)
        {
            var products = _productRepository.GetAll().Where(x => x.ProductCode == productCode).FirstOrDefault();
            return _mapper.Map<ProductResponseDto>(products);
        }

        public ProductResponseDto GetStockByVariantCode(string variantCode)
        {
            var products = _productRepository.GetAll().Where(x => x.VariantCode == variantCode).FirstOrDefault();
            return _mapper.Map<ProductResponseDto>(products);
        }

        public ProductResponseDto UpdateStockQuantity(string variantCode, int quantity)
        {
            Product product = _productRepository.GetAll().Where(x => x.VariantCode == variantCode).FirstOrDefault();
            product.Quantity = quantity;

            _productRepository.Update(product);
            return _mapper.Map<ProductResponseDto>(product);
        }

        public ProductResponseDto UpdateStockQuantityByVariantCode(string variantCode, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
