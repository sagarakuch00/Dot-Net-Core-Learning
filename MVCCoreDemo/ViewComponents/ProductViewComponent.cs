using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
         public async Task<IViewComponentResult> InvokeAsync(string description)
        {
            List<Products> products = new List<Products>()
            {
                new Products(){ Name = "samsung", Price = 95000, Description = "Top Rated"},
                new Products(){ Name = "Apple", Price = 150000, Description = "Top Rated"},
                new Products(){ Name = "Redmi", Price = 15000, Description = "Top Rated"},
                 new Products(){ Name = "fridge", Price = 20000, Description = "Discount Products"},
                new Products(){ Name = "washing machine", Price = 25000, Description = "Discount Products"},
                new Products(){ Name = "TV", Price = 56000, Description = "Discount Products"}
            };

            if (!string.IsNullOrEmpty(description))
            {
                products = products.Where(p => p.Description.Contains(description)).ToList();
            }


            return View(products);
        }
    }
}
