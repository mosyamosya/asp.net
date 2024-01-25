using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddLogging();

        var app = builder.Build();
        app.UseStaticFiles();

        app.UseMiddleware<ErrorLoggingMiddleware>();


        app.Map("/checkCookie", CheckCookieHandler);
        app.Map("/", FormHandler);

        app.Map("/error", async (context) =>
        {
            throw new Exception();

        });


       


        app.Run();
    }
   
    private static void CheckCookieHandler(HttpContext context)
    {
        var cookieValue = context.Request.Cookies["cookieValue"];
        if (cookieValue != null)
        {
            context.Response.WriteAsync($"Cookie value: {cookieValue}");
        }
        else
        {
            context.Response.WriteAsync("Cookie not found");
        }
    }

    private static void FormHandler(HttpContext context)
    {
        context.Response.Redirect("/index.html");
    }
}

