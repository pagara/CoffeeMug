using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeMug.Data.Abstract;
using CoffeeMug.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMug.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _productRepository.GetAll();
            return Ok(_productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetById(Guid id)
        {
            var product = _productRepository.Get(x => x.Id == id);
            if (product == null) return BadRequest(new { name = "Product does not exist!" });
            return Ok(product);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {

            _productRepository.Add(product);
            _productRepository.Commit();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }
    }
}
