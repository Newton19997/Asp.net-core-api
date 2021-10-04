using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL_Manager.Base;
using BLL_Manager.Contact;
using HelloCoreApp.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelss;

namespace HelloCoreApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager productManager;
        private ICategoryManager categoryManager;
       private IMapper mapper;
        public ProductController(IProductManager _productManager, ICategoryManager _categoryManager, IMapper _mapper)
        {
            productManager = _productManager;
            categoryManager = _categoryManager;
           mapper = _mapper;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var product = productManager.GetAll();

            var productviewmolellist = mapper.Map<IEnumerable<ProductViewModel>>(product);
            return View(productviewmolellist);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {

            List<SelectListItem> categorylist = categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text=c.Name
            }).ToList();

           // ViewBag.categorylists = categorylist;

            var model = new ProductCreateViewModel();

            model.listofCategory = categorylist;
            model.productsList = productManager.GetAll();
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //rowng work for newton chack parpase start
                    if (model.listofCategory == null)
                    {
                        
                       var categorylist = categoryManager.GetAll().Select(c => new SelectListItem()
                        {
                            Value = c.Id.ToString(),
                            Text = c.Name
                        }).ToList();
                        // ViewBag.categorylists = categorylist;
                        model.listofCategory = categorylist;
                      
                    }
                    //rowng work for newton chack parpase end
                    var product = mapper.Map<Product>(model);
                    bool isAdd =productManager.Add(product);
                    if(isAdd)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CategoryWiseProduct()
        {
            var model = new CategoryWiseProductViewModel();
            model.CategoryList = categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            // ViewBag.categorylists = categorylist; 
            if (model.CategoryList == null)
            {
                model.CategoryList = new List<SelectListItem>();
            }
             return View(model);
        }
        //[Route("api/[controller]/[action]")]
        [Route("api/Product/productlist")]
        public IEnumerable<Product> GetByCategory(int CategoryID)
        {
            var prodect = productManager.GetByCategory(CategoryID);
            return prodect;
        }
    }
}
