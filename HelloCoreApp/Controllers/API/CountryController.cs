using AutoMapper;
using BLL_Manager.Contact;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloCoreApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CountryController : ControllerBase
    {
        private ICountryManager countryManager;
        private IMapper mapper;
        public CountryController(ICountryManager _countryManager, IMapper _mapper)
        {
            countryManager = _countryManager;
            mapper = _mapper;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return countryManager.GetAll();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            return countryManager.GetById(id);
        }

        //// POST api/<CountryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPost]
        public IActionResult Post(Country country)
        {
            if (ModelState.IsValid)
            {
             var IsAdded =  countryManager.Insert_Countyr(country.CountryName, 1);

                //  var IsAdded = countryManager.Add(country);
                if (IsAdded == 1)
                {
                    return Ok(country);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Country country)
        {
            var existingProduct = countryManager.GetById(id);
            if (existingProduct == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Ni Product Found!"
                });
            }
            if (ModelState.IsValid)
            {
                //  mapper.Map<Product, Product>(product, existingProduct);
                existingProduct.CountryName = country.CountryName;
                //existingProduct.Price = product.Price;
                //existingProduct.IsActive = product.IsActive;
                //existingProduct.CategoryId = product.CategoryId;
                //existingProduct.Description = product.Description;



                bool isUpdate = countryManager.UpDate(existingProduct);
                if (isUpdate)
                {
                    return Ok();
                }
            }
            return BadRequest(ModelState);
        }

        // PUT api/<CountryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CountryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var country = countryManager.GetById(id);
            if (country == null)
            {
                return BadRequest(new
                {
                    ErrorMessage = "Ni Product Found!"
                });
            }
            var isDeleted = countryManager.Remove(country);
            if (isDeleted)
            {
                return Ok();
            }
            return BadRequest(new { ErrorMessage = "Could no delete country,unknow error!" });
        }
    }
}
