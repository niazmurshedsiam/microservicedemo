using Catalog.Api.Model;
using MongoRepo.Interfaces.Manager;

namespace Catalog.Api.Interface.Manager
{
    public interface IProductManager:ICommonManager<Product>
    {
       public List<Product> GetByCategory(string category);
    }
}
