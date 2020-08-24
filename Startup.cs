using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ps_DutchTreat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // 08/23/2020 12:28 am - SSN - [20200823-0028] - [001] - M02-06 - Installing Visual Studio 2019 

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});


            //  app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hellow World!!!");
            //});

            // 08/23/2020 11:52 am - SSN - [20200823-1152] - [001] - M02-08 - Serving your first file
            // Order matters
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseNodeModules();


        }
    }
}
