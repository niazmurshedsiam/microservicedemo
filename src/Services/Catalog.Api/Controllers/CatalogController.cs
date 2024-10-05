using Catalog.Api.Interface.Manager;
using Catalog.Api.Model;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : BaseController
    {
        IProductManager _productManager;
        public CatalogController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        public IActionResult GetProduct() 
        {
            try
            {
                var products = _productManager.GetAll();
                if (products == null) 
                {
                    return CustomResult("Data Not Found",HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Data Load Succssfully",products);
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
