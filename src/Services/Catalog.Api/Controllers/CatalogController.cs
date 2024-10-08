using Catalog.Api.Interface.Manager;
using Catalog.Api.Model;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        [ResponseCache(Duration =10)]
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

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        [ResponseCache(Duration =10)]
        public IActionResult GetByCategory(string category) 
        {
            try
            {
                var products = _productManager.GetByCategory(category);
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

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            
        }
        [HttpGet]
        [ProducesResponseType(typeof(Product),(int)HttpStatusCode.OK)]
        public IActionResult GetById(string id) 
        {
            try
            {
                var product = _productManager.GetById(id);
                if (product == null) 
                {
                    return CustomResult("Data Not Found",HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Data Load Succssfully",product);
                }
                
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            
        }
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public IActionResult CreateProduct([FromBody]Product product) 
        {
            try
            {
                product.Id = ObjectId.GenerateNewId().ToString();
                bool isSaved = _productManager.Add(product);
                if (isSaved) 
                {
                    return CustomResult("Product has been save Successfully.", product, HttpStatusCode.Created);
                }
                else
                {
                    return CustomResult("Product saved Fail.",HttpStatusCode.BadGateway);    
                }
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Id))
                {
                    return CustomResult("Data Not Found.", HttpStatusCode.NotFound);
                }
                bool isUpdate = _productManager.Update(product.Id, product);

                if (isUpdate)
                {
                    return CustomResult("Product has been modify Successfully.", product, HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("Product modify Fail.", HttpStatusCode.BadGateway);
                }
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult DeleteProduct([FromBody] string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return CustomResult("Data Not Found.", HttpStatusCode.NotFound);
                }
                bool isDelete = _productManager.Delete(id);

                if (isDelete)
                {
                    return CustomResult("Product has been delete Successfully.", HttpStatusCode.OK);
                }
                else
                {
                    return CustomResult("Product delete Fail.", HttpStatusCode.BadGateway);
                }
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
