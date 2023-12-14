namespace SpaceWeatherApplication.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalLoggingMiddleware>();
        }
    }
}
