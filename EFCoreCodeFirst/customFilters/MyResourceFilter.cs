using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCoreCodeFirst.customFilters
{
    public class MyResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();

            Console.WriteLine($"{controllerName}/{actionName}MyResourceFilter onResourceExecuted");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();

            Console.WriteLine($"{controllerName}/{actionName}MyResourceFilter onResourceExecuting");
        }
    }
}
