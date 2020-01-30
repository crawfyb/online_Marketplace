using System;
using System.Collections.Generic;
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
        private List<Product> Products = new List<Product>
        {
            new Product {Id ="001", ProductName = "Lavender heart", Price = 9.25 },
            new Product {Id ="002", ProductName = "Personalised cufflinks", Price = 45.00 },
            new Product {Id ="003", ProductName = "Kids T-shirt", Price = 19.95 },
        };

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(Products);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> Get(string id)
        {
            var stock = Products.Find(item => 
                    item.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

            if (stock == null)
            {
                return NotFound();
            } else
            {
                return Ok(stock);
            }
        }
    }
}