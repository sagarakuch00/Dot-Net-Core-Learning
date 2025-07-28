using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCoreCodeFirst.customFilters
{
    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("MyActionFilter OnActionExecuted called");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("MyActionFilter OnActionExecuting called");
        }
    }
}
