using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCoreCodeFirst.customFilters
{
    public class MyAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("MyAuthorizationFilter OnAuthorization called");
        }
    }
}
