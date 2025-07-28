using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCoreCodeFirst.customFilters
{
    public class MyResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("MyResultFilter OnResultExecuted called");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("MyResultFilter OnResultExecuting called");
        }
    }
}
