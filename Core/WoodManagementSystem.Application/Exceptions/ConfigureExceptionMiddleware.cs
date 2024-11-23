using Microsoft.AspNetCore.Builder;

namespace WoodManagementSystem.Application.Exceptions
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            //Middleware çalışcağını burda gösteriyoruz
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
