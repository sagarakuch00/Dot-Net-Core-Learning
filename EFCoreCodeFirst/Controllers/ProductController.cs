using CRUDUsingEFCoreCodeFirst.Models;
using CRUDUsingEFCoreCodeFirst.Models.Entities;
using EFCoreCodeFirst.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductDbContext _dbContext;

        public ProductController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int? categoryId)
        {
            List<Product> products = new List<Product>();
            if (categoryId != null)
            {
                products = _dbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
            else
            {
                products = _dbContext.Products.ToList();
            }
            return View(products);

            //var products = _dbContext.Products.ToList();
            //return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _dbContext.Categories.ToList();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            //if (ModelState.IsValid)
            //{
            //    _dbContext.Products.Add(product);
            //    _dbContext.SaveChanges();
            //    return RedirectToAction("Index");

            //}
            //return View(product);

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            Product product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            Product product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            try
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Product product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(Product product)
        {
            try
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }
    }
}
