using Catalog.Api.Interface.Manager;
using Catalog.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
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
                    return NotFound();
                }
                else
                {
                    return Ok(products);
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
