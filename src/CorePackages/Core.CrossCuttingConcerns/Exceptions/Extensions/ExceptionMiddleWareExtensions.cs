using Core.CrossCuttingConcerns.Exceptios;
using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions;

public static class ExceptionMiddleWareExtensions
{
    public static void ConfigureCustomExceptionMiddleWare(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleWare>();
}
