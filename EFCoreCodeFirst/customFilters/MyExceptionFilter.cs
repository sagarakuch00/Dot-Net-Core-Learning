using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCoreCodeFirst.customFilters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("MyExceptionFilter OnException called");
        }
    }
}
