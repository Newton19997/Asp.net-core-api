using AutoMapper;
using BLL_Manager.Contact;
using HelloCoreApp.Models.Customer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelss;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloCoreApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CustomerController : ControllerBase
    {
        private ICountryManager countryManager;       
        private IMapper mapper;
        private ICustomerManager customerManager;
        private ICustomerAddressManager customerAddressManager;
        // private IOrderdetailsManager orderdetailsManager;

     
       // private IWebHostEnvironment webHostEnvironment;
        //[Obsolete]
        
  

        [Obsolete]
        public CustomerController(ICountryManager _countryManager,IMapper _mapper, ICustomerManager _customerManager, ICustomerAddressManager _customerAddressManager)
        {

            countryManager = _countryManager;
            mapper = _mapper;
            customerManager = _customerManager;
            customerAddressManager = _customerAddressManager;
            


        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
       {
            return customerManager.GetAll();
        }

     
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]


        //public string Get(int id)
        public IActionResult Get(int id)
        {

        var model = new EditCustomerModel();
            var countrysList = countryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CountryName
            }).ToList();
          //  ViewBag.productList = productList;
            model.Countrys = countrysList;

            //var customerlist = customerManager.GetAll().Select(c => new SelectListItem()
            //{
            //    Value = c.Id.ToString(),
            //    Text = c.CustomerName
            //}).ToList();
            //model.Customers = customerlist;

            var customer = customerManager.GetEdit_forCustomer(id).ToList();
            model.Id = customer[0].Id;
            model.CustomerName = customer[0].CustomerName;
            model.FatherName = customer[0].FatherName;
            model.MotherName = customer[0].MotherName;
            model.MaritalStatus = customer[0].MaritalStatus;
            model.Image = customer[0].Image;
            model.CountryId = customer[0].CountryId;
            // model.CountryName=customer[0].CountryName

            var customerAddresss = customerManager.GetEdit_forCustomerAddress(id).ToList();
            model.CustomerAddresss = customerAddresss.ToList();
            return Ok(model);
            // return View(model);
        }    



        // POST api/<CustomerController>
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post(CustomerViewModel model)
        {

            if (ModelState.IsValid)
            {
                //var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", file.FileName);
                //using(var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    file.CopyTo(fileStream);
                //}
                //var baseURL = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host + httpContextAccessor.HttpContext.Request.PathBase;
                //return Ok(new
                //{
                //    fileName = baseURL+ "uploads"+ file.FileName,fileSize=file.Length

                //});


                /*  ////newton
                  var file = Request.Form.Files[0];
                  var folderName = Path.Combine("Resources", "Image");
                  var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                  if (file.Length > 0)
                  {
                      var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
                      var fullPath = Path.Combine(pathToSave, fileName);
                      var dbPath = Path.Combine(folderName, fileName);
                      using(var stream =new FileStream(fullPath, FileMode.Create))
                      {

                      }
                      return Ok(new { dbPath });
                  }
                  else
                  {
                      return BadRequest();
                  }
                  */
                //var files = HttpContext.Request.Form.Files;
                //if (files != null && files.Count > 0)
                //{
                //    foreach (var file in files)
                //    {
                //        FileInfo fi = new FileInfo(file.FileName);
                //        var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                //        var path = Path.Combine("", hostingEnvironment.ContentRootPath + "/Images/" + newfilename);
                //        using (var stream = new FileStream(path, FileMode.Create))
                //        {
                //            file.CopyTo(stream);
                //        }
                //        //CustomerViewModel CustomerViewModel = new CustomerViewModel();
                //        model.Image = path;
                //    }
                //}
                ////newtimage

                var customer = mapper.Map<Customer>(model);               
                bool isAdded = customerManager.Add(customer);
                if (isAdded)
                {
                    return Ok(customer);
                    // return RedirectToAction(nameof(Index), "Home");
                }

            }
            return BadRequest(ModelState);
        }

        // PUT api/<CustomerController>/5
        // [HttpPut("{id}")]
        //[HttpPut]
      //link://www.c-sharpcorner.com/article/build-crud-operation-using-angular-9-and-dot-net-core-3-1-webapi-and-deploy-to-a/

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditCustomerModel editCustomerModel)
        {

            if (ModelState.IsValid)
            {

                // var customer = mapper.Map<Customer>(editCustomerModel);
                Customer customer = new Customer();
                customer.Id = editCustomerModel.Id;
                customer.CustomerName = editCustomerModel.CustomerName;
                customer.FatherName = editCustomerModel.FatherName;
                customer.MotherName = editCustomerModel.MotherName;
                customer.MaritalStatus = editCustomerModel.MaritalStatus;
                customer.CountryId = editCustomerModel.CountryId;
                customer.Image = editCustomerModel.Image;

                var IsAdded = customerManager.UpDate(customer);

                customerAddressManager.DeleteCustomerAddresssAfteredit(customer.Id);

                //CustomerAddress cuAddress = new CustomerAddress();
                //foreach (var property in editCustomerModel.CustomerAddresss)
                //{
                //    cuAddress.Id = property.Id;
                //    cuAddress.CustomerId = id;
                //    cuAddress.Customer_Address = property.Customer_Address;


                //    if (cuAddress.Id == 0)
                //    {
                //        var Customer_Add = mapper.Map<CustomerAddress>(cuAddress);
                //        customerAddressManager.Add(Customer_Add);
                //    }
                //    else
                //    {
                //        var Customer_Address = mapper.Map<CustomerAddress>(cuAddress);
                //        customerAddressManager.UpDate(Customer_Address);
                //    }
                //}

                if (IsAdded)
                {
                
                    CustomerAddress cuAddress = new CustomerAddress();
                    foreach (var property in editCustomerModel.CustomerAddresss)
                    {
                        cuAddress.Id = property.Id;
                        cuAddress.CustomerId = id;
                        cuAddress.Customer_Address = property.Customer_Address;

                        customerAddressManager.EditInsert_CustomerAddresss(id, property.Customer_Address,1);

                        //if (cuAddress.Id == 0)
                        //{
                        //    var Customer_Add = mapper.Map<CustomerAddress>(cuAddress);
                        //    bool isAdded = customerAddressManager.Add(Customer_Add);
                        //}
                        //else
                        //{
                        //    var Customer_Address = mapper.Map<CustomerAddress>(cuAddress);
                        //    customerAddressManager.UpDate(Customer_Address);
                        //}
                    }
                   
                    return Ok(customer);
                    //return Ok(product);
                }
            }
            //return Ok();
            return BadRequest(new { ErrorMessage = "SomeThing,unknow error!" });
        }

        //public IActionResult Put(int id, [FromBody] Employee obj)
        //{}
        //public async Task<ActionResult<EditCustomerModel>> Put(int id, [FromBody] EditCustomerModel editCustomerModel)
        //{

        //    //try
        //    //{

        //    //    return Ok();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
        //    //}
        //    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");

        //}

        //public void Put(int id, [FromBody] string value)
        //{
        //}
        /*
                public async Task<ActionResult<EditCustomerModel>>  Put(int id, EditCustomerModel editCustomerModel)
                {
                    try
                    {
                    //www.pragimtech.com/blog/blazor/put-in-asp.net-core-rest-api/
                        if (id != editCustomerModel.Id)
                            return BadRequest("Employee ID mismatch");

                        var employeeToUpdate = await employeeRepository.GetEmployee(id);

                        if (employeeToUpdate == null)
                            return NotFound($"Employee with Id = {id} not found");

                        return await employeeRepository.UpdateEmployee(employee);
                    }
                    catch (Exception)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,"Error updating data");
                    }
                }
        */
  
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
        //link serch
        // how to delete primary key and foreign key relationship table data asp.net core

       //sidelink https:
            //stackoverflow.com/questions/9752287/how-to-delete-a-record-with-a-foreign-key-constraint


            var productLoad = customerManager.GetById(id);
               var productViewmodelListn = mapper.Map<Customer>(productLoad);
            var deleted = customerManager.Remove(productViewmodelListn);
            return Ok(deleted);



        }
        
    }
}
