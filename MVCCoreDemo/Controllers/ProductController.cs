using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index1()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index2()
        {
            List<Products> products = new List<Products>()
            {
                new Products(){ Name = "Product1", Price = 599},
                new Products(){ Name = "Product2", Price = 1599},
                new Products(){ Name = "Product3", Price = 2000}

            };

            return View(products);
        }

        [HttpGet]
        public IActionResult Index3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index3(Products products)
        {
            // insert to database   
            return View();
        }
    }
}
