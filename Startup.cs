using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ps_DutchTreat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            // 08/23/2020 11:51 pm - SSN - [20200823-2324] - [002] - M05-08 - Razor pages
            services.AddRazorPages();

            // 08/23/2020 09:23 pm - SSN - [20200823-2113] - [002] - M05-04 - Enabling MVC 6
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // 08/23/2020 12:28 am - SSN - [20200823-0028] - [001] - M02-06 - Installing Visual Studio 2019 

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // 08/23/2020 11:26 pm - SSN - [20200823-2324] - [001] - M05-08 - Razor pages
                app.UseExceptionHandler("/error");
            }


            //  app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hellow World!!!");
            //});

            // 08/23/2020 11:52 am - SSN - [20200823-1152] - [001] - M02-08 - Serving your first file
            // Order matters

            // 08/23/2020 09:18 pm - SSN - [20200823-2113] - [001] - M05-04 - Enabling MVC 6

            // app.UseDefaultFiles();   // [20200823-2113] - [001] 



            app.UseStaticFiles();

            app.UseNodeModules();

            app.UseRouting(); // [20200823-2113] - [001] 

            app.UseEndpoints(cfg =>   // [20200823-2113] - [001]
            {
                cfg.MapControllerRoute("Fallback",
                    "{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" }
                    );
            });


            // 08/23/2020 11:52 pm - SSN - [20200823-2324] - [003] - M05-08 - Razor pages
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });


        }
    }
}
