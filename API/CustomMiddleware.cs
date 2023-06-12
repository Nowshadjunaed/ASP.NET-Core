namespace API
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("hello from custom middleware 1st\n");
            await next(context);
            await context.Response.WriteAsync("hello from custom middleware 2nd\n");
        }
    }
}
