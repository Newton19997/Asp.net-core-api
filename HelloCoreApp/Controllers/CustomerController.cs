using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL_Manager;
using BLL_Manager.Contact;
using DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Modelss;
using Repositoris;

namespace HelloCoreApp.Controllers
{
    public class CustomerController : Controller
    {
       private ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
           // _customerManager = new CustomerManager();
        }
        public IActionResult Create()
        {
            //return "Myname is "+ custoner.CustomerName + " "+ custoner.Address + "";
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer custoner)
        {
           
            if (ModelState.IsValid)
            {
                //db.Customers.Add(custoner);
               bool isSave= _customerManager.Add (custoner); 
                if (isSave)
                {
                    return RedirectToAction("Details", custoner);
                }                
                

            }
            else
            {

            }

            return View();
        }
        public IActionResult Details(Customer custoner)
        {
            return View(custoner);
        }
    }
}
