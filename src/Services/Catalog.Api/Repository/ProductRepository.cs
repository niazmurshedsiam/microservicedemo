using Catalog.Api.Context;
using Catalog.Api.Interface.Repository;
using Catalog.Api.Model;
using MongoRepo.Repository;

namespace Catalog.Api.Repository
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository() : base(new CatalogDbContext())
        {
        }
    }
}
