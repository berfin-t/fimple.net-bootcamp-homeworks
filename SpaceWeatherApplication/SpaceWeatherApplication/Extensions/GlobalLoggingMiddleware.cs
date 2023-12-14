namespace SpaceWeatherApplication.Extensions
{
    public class GlobalLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log entry point
            Console.WriteLine($"Action {context.Request.Path} started");

            await _next(context);

            // Log exit point
            Console.WriteLine($"Action {context.Request.Path} completed");
        }
    }
}
