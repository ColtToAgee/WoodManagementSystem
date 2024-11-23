using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace WoodManagementSystem.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            //Eğer validationa göre oluşmuş bir hata ise bu bölümden halledilir.
            if (exception.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());
            }

            List<string> errors = new List<string>()
            {
                exception.Message,
                exception.InnerException?.ToString()
            };

            return context.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statusCode
            }.ToString());
        }

        //Gelen hata türüne göre status code döner.
        private static int GetStatusCode(Exception exception)
        {
            var result = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
            return result;
        }
    }
}

