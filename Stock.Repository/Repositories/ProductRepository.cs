using Stock.Core.Models;
using Stock.Core.Repository;
using Stock.Repository.Context;

namespace Stock.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
