using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineMarketplace.Models;

namespace onlineMarketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private List<Product> _oProducts = new List<Product>
        {
            new Product {Id =001, ProductName = "Lavender heart", Price = 9.25 },
            new Product {Id =002, ProductName = "Personalised cufflinks", Price = 45.00 },
            new Product {Id =003, ProductName = "Kids T-shirt", Price = 19.95 },
        };

        [HttpGet]
        public IActionResult Gets()
        {
            if (_oProducts.Count == 0)
            {
                return NotFound("404 no products found");
            }
            return Ok(_oProducts);
        }

        [HttpGet("GetProduct")]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var oProduct = _oProducts.SingleOrDefault(x => x.Id == id);
            if (oProduct == null)
            {
                return NotFound("404 for an unknown product ID");
            }
            return Ok(oProduct);
        }

        [HttpPost]
        public IActionResult Save(Product oProduct)
        {
            _oProducts.Add(oProduct);
            if(_oProducts.Count == 0)
            {
                return NotFound("No product found");
            }
            return Ok(_oProducts);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var oProduct = _oProducts.SingleOrDefault(x => x.Id == id);
            if(oProduct == null)
            {
                return NotFound("404 for an unknown product ID");
            }
            _oProducts.Remove(oProduct);

            if (_oProducts.Count == 0)
            {
                return NotFound("No product found");
            }
            return Ok(_oProducts);
        }

    }

}

//        [HttpGet]
//        public ActionResult<List<Product>> Get()
//        {
//            return Ok(Products);
//        }

//        [HttpGet]
//        [Route("{id}")]
//        public ActionResult<Product> Get(string id)
//        {
//            var stock = Products.Find(item =>
//            //I could not find the integer altenate to StringComparison so chaned id to string in the models
//                    item.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

//            if (stock == null)
//            {
//                return NotFound("404 for an unknown product ID");
//            } else
//            {
//                return Ok(stock);
//            }
//        }

//        [HttpPost]
//        public ActionResult Post(Product product)
//        {
//            var existingProduct = Products.Find(item =>
//                    item.Id.Equals(product.Id, StringComparison.InvariantCultureIgnoreCase));

//            if (existingProduct != null)
//            {
//                return Conflict("Product already exists.");
//            }
//            else
//            {
//                Products.Add(product);
//                var resourceUrl = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(product.Id));
//                return Created(resourceUrl, product);
//            }
//        }
//    }
//}