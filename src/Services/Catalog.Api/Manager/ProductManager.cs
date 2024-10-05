using Catalog.Api.Interface.Manager;
using Catalog.Api.Model;
using Catalog.Api.Repository;
using MongoRepo.Manager;
using MongoRepo.Repository;

namespace Catalog.Api.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        public ProductManager() : base(new ProductRepository())
        {
        }
    }
}
