using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.ErrorHelper;

namespace WebApp.Controllers
{
    [RoutePrefix("api/v1/product")]
    public class ProductController : ApiController
    {
        #region Private variable.

        private readonly IProductServices _productServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        #endregion

        // GET api/product
        //[GET("allproducts")]
        //[GET("all")]
        [Route("all")]
        [HttpGet()]
        public HttpResponseMessage Get()
        {
            var products = _productServices.GetAllProducts();
            var productEntities = products.ToList();
            if (productEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            throw new ApiDataException(1000, "Products not found", HttpStatusCode.NotFound);
        }

        // GET api/product/5
        [Route("productid/{id?}")]
        [Route("particularproduct/{id?}")]
        [Route("myproduct/{id:range(1, 3)}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            if (id > 0)
            {
                var product = _productServices.GetProductById(id);
                if (product != null)
                    return Request.CreateResponse(HttpStatusCode.OK, product);

                throw new ApiDataException(1001, "No product found for this id.", HttpStatusCode.NotFound);
            }
            throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..." };
        }

        // POST api/product
        [Route("Create")]
        [Route("Register")]
        [HttpPost]
        public int Post([FromBody] ProductEntity productEntity)
        {
            return _productServices.CreateProduct(productEntity);
        }

        // PUT api/product/5
        [Route("Update/productid/{id}")]
        [Route("Modify/productid/{id}")]
        [HttpPut]
        public bool Put(int id, [FromBody] ProductEntity productEntity)
        {
            return id > 0 && _productServices.UpdateProduct(id, productEntity);
        }

        // DELETE api/product/5


        [HttpDelete, Route("remove/productid/{id}"), Route("clear/productid/{id}")]
        [HttpPut, Route("delete/productid/{id}")]
        public bool Delete(int id)
        {
            if (id > 0)
            {
                var isSuccess = _productServices.DeleteProduct(id);
                if (isSuccess)
                {
                    return true;
                }
                throw new ApiDataException(1002, "Product is already deleted or not exist in system.", HttpStatusCode.NoContent);
            }
            throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..." };
        }
    }
}
