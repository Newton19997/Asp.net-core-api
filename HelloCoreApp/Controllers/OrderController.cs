using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL_Manager.Contact;
using HelloCoreApp.Models.Order;
using HelloCoreApp.Models.Order.OrderEditViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Modelss;

namespace HelloCoreApp.Controllers
{
    public class OrderController : Controller
    {
        private IProductManager productManager;
        private IOrderManager orderManager;
        private IMapper mapper;
        private ICustomerManager customerManager;
        private IOrderdetailsManager orderdetailsManager;
        public OrderController(IProductManager _productManager, IOrderManager _orderManager, IMapper _mapper, ICustomerManager _customerManager,  IOrderdetailsManager _orderdetailsManager)
        {
            productManager = _productManager;
            orderManager = _orderManager;
            mapper = _mapper;
            customerManager = _customerManager;
            orderdetailsManager= _orderdetailsManager;
    }

        //public IActionResult Index(OrderSearchCriteria criteria)
        //{
        //    var orders=

        //    var order = orderManager.GetAllOrdersummary();
        //    return View(order);
        //}
        public IActionResult Index()
        {
            var order = orderManager.GetAllOrdersummary();
            return View(order);
        }
        public IActionResult Create()
        {
            var productList = productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            var model = new OrderViewModel()
            {
                ProductSelectItem = productList
            };


            var customerlist = customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustomerName
            }).ToList();
            model.Customers = customerlist;

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = mapper.Map<Order>(model);
                bool isAdded = orderManager.Add(order);
                if (isAdded)
                {
                    return RedirectToAction(nameof(Index), "Home");
                }

            }

            var productList = productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            model.ProductSelectItem = productList;

            var customerlist = customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustomerName
            }).ToList();
            model.Customers = customerlist;

            return View(model);
        }

        //public IActionResult ShowOrder()
        //{
        //    var model = orderManager.GetSpOrderInfo();

        //    return View(model);
        //}
        public IActionResult ShowOrder(string Order, string CustomerName)
        {
            //var model = orderManager.GetSpOrderInfo();
            var model = orderManager.GetSpOrderInfos_paramater(Order, CustomerName);
            return View(model);
        }


        //for edit start
        public ActionResult Edit(int id)
        {
            var model = new EditOrderModel();
            var productList = productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            ViewBag.productList = productList;
            model.ProductSelectItem = productList;

            var customerlist = customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustomerName
            }).ToList();
            model.Customers = customerlist;

            var OrderId = orderManager.GetSpOrderID(id).ToList();
            model.id = OrderId[0].id;
            model.OrderNo = OrderId[0].OrderNo;
            model.OrderDate = OrderId[0].OrderDate;
            model.CustomerId = OrderId[0].CustomerId;

            var OrderIDWiseDetail = orderManager.GetSpOrderIDWiseDetails(id).ToList();
            model.OrderDetails = OrderIDWiseDetail.ToList();

            //var shopeditload = shopManager.GetById(id);
            //return View(shopeditload);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditOrderModel Order)
        {
            try
            {
                // var edited = shopManager.UpDate(shop);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditOrder(int id, EditOrderModel model)
        {
            try
            {
                var order = mapper.Map<Order>(model);
                var edited = orderManager.UpDate(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        [Route("api/Order/OrderDetails")]
        public IEnumerable<OrderDetail> GetByOrderDetailsByID(int Id)
        {
            var OrderDetailIDWise = orderManager.GetByOrderDetailsByID(Id).ToList();
            return OrderDetailIDWise;
        }
        [Route("api/Order/OrderDetails")]
        [HttpPost]
        public IActionResult PostOrderDetails(EditOrderModel model)
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
            return Ok();
        }
    }
}
