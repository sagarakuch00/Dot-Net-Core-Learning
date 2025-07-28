namespace MiddlewareDemo.Middlewares
{
    public class CustomMiddleware1
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Custom midddleware 1 Executed in Request");

            await _next(context);

            Console.WriteLine("Custom Middleware 1 Executed in Response");
        }
    }
}
