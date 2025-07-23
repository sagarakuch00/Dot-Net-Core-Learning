using CrudUsingAdoNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingAdoNetCore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService dbService)
        {
            _categoryService = dbService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
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
            if (ModelState.IsValid)
            {
                if (_categoryService.Create(category))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var category = _categoryService.GetById(id ?? 0);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryService.Update(category))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var category = _categoryService.GetById(id ?? 0);
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var category = _categoryService.GetById(id ?? 0);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (_categoryService.Delete(id ?? 0))
            {
                return RedirectToAction("Index");
            }

            var category = _categoryService.GetById(id ?? 0);
            return View(category);
        }
        

    }
}
