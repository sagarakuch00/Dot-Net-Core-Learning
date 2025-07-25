using CRUDUsingEFCoreCodeFirst.Models;
using CRUDUsingEFCoreCodeFirst.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductDbContext _dbContext;

        public CategoryController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {          

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            //ViewBag.CategoryList = _dbContext.Categories
            //    .Select(c => new SelectListItem
            //    {
            //        Value = c.Id.ToString(),
            //        Text = c.Name
            //    }).ToList();
            try
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            Category category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);  
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Category category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            try
            {
                _dbContext.Entry(category).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
           
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Category category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(Category category)
        {
            try
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
           
        }
    }
}
