using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ps_DutchTreat.Data;
using ps_DutchTreat.Services;
using System.Reflection;

namespace ps_DutchTreat
{
    public class Startup
    {
        private readonly IConfiguration config;

        // 08/24/2020 02:17 pm - SSN - [20200824-1416] - [001] - M07-04 - Using configuration
        public Startup(IConfiguration config)
        {
            this.config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            // 08/24/2020 02:07 pm - SSN - [20200824-1400] - [001] - M07-03 - Using Entity Framework tooling
            services.AddDbContext<DutchContext>(cfg =>
           {
               cfg.UseSqlServer(this.config.GetConnectionString("DutchConnectionString"));
           });


            // 08/25/2020 07:23 am - SSN - [20200825-0651] - [003] - M07-06 - Seeding the database 
            services.AddTransient<DutchSeeder>();


            // 08/26/2020 09:09 am - SSN - [20200826-0856] - [001] - M08-06 - Using AutoMapper 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            // 08/24/2020 07:59 am - SSN - [20200824-0751] - [002] - M05-12 - Adding a service
            services.AddTransient<IMailService, NullMailService>();


            // 08/23/2020 11:51 pm - SSN - [20200823-2324] - [002] - M05-08 - Razor pages
            services.AddRazorPages();


            // 08/23/2020 09:23 pm - SSN - [20200823-2113] - [002] - M05-04 - Enabling MVC 6
            services.AddControllersWithViews();


            // 08/25/2020 07:57 am - SSN - [20200825-0749] - [003] - M07-07 - The repository pattern
            services.AddScoped<IDutchRepository, DutchRepository>();


            // 08/25/2020 12:19 pm - SSN - [20200825-1139] - [002] - M08-01 - Create an API controller
            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)
            // 08/25/2020 01:46 pm - SSN - [20200825-1315] - [002] - M08-02 - Returning data (API) 
                .AddJsonOptions(options =>
                 {
                     options.JsonSerializerOptions.MaxDepth = 0;
                 });

            // 08/25/2020 01:46 pm - SSN - [20200825-1315] - [002] - M08-02 - Returning data (API) 
            // Solution provided in video did not work.
            // Found this by downloading Microsoft.AspNetCore.Mvc.NewtonsoftJson 
            // services.AddMvc().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // An alternative - Tested OK.
            services.AddControllers().AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                x.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

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
                //  app.UseExceptionHandler("/error");

                Startup_Sub.UseExceptionHandler_custom(app);

            }

            Startup_Sub.TestMiddleware_101(app);



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

            app.UseEndpoints(endpoints =>   // [20200823-2113] - [001]
            {
                // 08/23/2020 11:52 pm - SSN - [20200823-2324] - [003] - M05-08 - Razor pages
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("Fallback",
                    "{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" }
                    );
            });

        }
    }
}
