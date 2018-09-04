using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            // Demo a sample middleware
            // IApplicationBuilder.Use(Func<RequestDelegate, RequestDelegate> middleware)
            // A RequestDelegate takes in a "HttpContext" and returns a Task 
            // - this Task would either write to the response or call the "next" middleware delegate
            app.Use(
                // RequestDelegate in argument
                next => {
                    // RequestDelegate return 
                    return async context => {
                        if (context.Request.Path.StartsWithSegments("/mym"))
                        {
                            // pipeline terminates and reverses here
                            await context.Response.WriteAsync("My middleware hit!");
                        } 
                        else 
                        {
                            // pipeline continues to next middleware
                            await next(context);    
                        }
                };
            });

            app.UseWelcomePage(new WelcomePageOptions {
                Path = "/wp"
            });

            app.Run(async (context) =>
            {
                var greeting = configuration["greeting"];
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
