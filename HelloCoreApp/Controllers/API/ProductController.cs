using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL_Manager.Contact;
using HelloCoreApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelss;

namespace HelloCoreApp.Controllers.API
{
    [Route("api/Products")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ProductController : ControllerBase
    {
        private IProductManager productManager;        
        private IMapper mapper;
        public ProductController(IProductManager _productManager,  IMapper _mapper)
        {
            productManager = _productManager;
            mapper = _mapper;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productManager.GetAll();
        }
       
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productManager.GetById(id);
        } 
        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                var IsAdded = productManager.Add(product);
                if (IsAdded)
                {
                    return Ok(product);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id , Product product)
        {
            var existingProduct = productManager.GetById(id);
            if (existingProduct == null)
            {
                return BadRequest(new
                {
                    ErrorMessage="Ni Product Found!"
                });
            }
            if (ModelState.IsValid)
            {
                //  mapper.Map<Product, Product>(product, existingProduct);
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.IsActive = product.IsActive;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Description = product.Description;



                bool isUpdate= productManager.UpDate(existingProduct);
                if (isUpdate)
                {
                    return Ok();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = productManager.GetById(id);
            if (product == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Ni Product Found!"
                });
            }
            var isDeleted = productManager.Remove(product);
           if(isDeleted)
            {
                return Ok();
            }
            return BadRequest(new { ErrorMessage = "Could no delete product,unknow error!" });
        }

    }
}
