using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL_Manager;
using BLL_Manager.Contact;
using HelloCoreApp.Models.Order.OrderEditViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Modelss;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloCoreApp.Controllers.API
{
    [Route("api/OrderDetail/Details")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class OrderDetailController : ControllerBase
    {

        private IOrderdetailsManager orderdetailsManager ;
        private IMapper mapper;
        public OrderDetailController(IOrderdetailsManager _orderdetailsManager, IMapper _mapper)
        {
            orderdetailsManager = _orderdetailsManager;
            mapper = _mapper;
        }
        // GET: api/<OrderDetailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderDetailController>
        [HttpPost]

        public IActionResult Post(EditOrderModel model)
        {
            if (ModelState.IsValid)
            {
                OrderDetail orderDetail = new OrderDetail();
                //orderDetail.Id = model.Id;
                orderDetail.OrderId = model.id;
                orderDetail.ProductId = model.ProductId;
                orderDetail.Qty = model.Qty;
                orderDetail.UnitPrice = model.UnitPrice;
                orderDetail.DiscountPercentage = model.DiscountPercentage;



                var IsAdded = orderdetailsManager.Add(orderDetail);
                if (IsAdded)
                {
                    return Ok(orderDetail);
                    //return Ok(product);
                }
            }
            return BadRequest(ModelState);
        }
        //public void Post([FromBody] EditOrderModel model)
        //{
        //}

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
