namespace MiddlewareDemo.Middlewares
{
    public class CustomMiddleware2
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Custom midddleware 2 Executed in Request");

            //if (context.Request.Method == "GET")
            //{
            //    context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
            //    return; // short circuit Middleware
            //}

            await _next(context); // call next middleware

            Console.WriteLine("Custom midddleware 2 Executed in Request");
        }
    }
}
