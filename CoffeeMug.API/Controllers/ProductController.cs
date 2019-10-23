using System;
using System.Collections.Generic;
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
            if (products == null) return BadRequest();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(Guid id)
        {
            var product = _productRepository.Get(x => x.Id == id);
            if (product == null) return BadRequest("Product does not exist!");
            return Ok(product);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            bool canAdd = _productRepository.IsProductIdValid(product.Id);
            if (canAdd)
            {
                _productRepository.Add(product);
                _productRepository.Commit();
                return Ok();
            }
            return BadRequest("Product already exists!");
        }

        [HttpPut("{id}")]
        public void Put([FromBody]Product product)
        {
            _productRepository.Update(product);
            _productRepository.Commit();
        }

        [HttpDelete]
        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }
    }
}
