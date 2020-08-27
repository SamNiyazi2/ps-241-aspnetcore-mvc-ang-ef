using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;


namespace ps_DutchTreat

// 08/25/2020 06:21 pm - SSN - Testing middleware - Attempt to capture Entity Framework errors.
// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-3.1
{
    public class Startup_Sub
    {

        public static void TestMiddleware_101(IApplicationBuilder app)
        {

            #region // 08/25/2020 06:21 pm - SSN - Testing middleware 


            app.Map("/map1", HandleMapTest1);

            app.Map("/map2", HandleMapTest2);



            app.Map("/map1/seg1", HandleMultiSeg);


            app.UseWhen(context => context.Request.Query.ContainsKey("branch"),
                             HandleBranchAndRejoin);


            if (false)
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
                });
            }






            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                // await next.Invoke();
                await next();

                // 08/27/2020 01:13 am - SSN - Added
                if (context.Response.StatusCode == 404)
                {

                    throw new Exception("Invalid url ");

                    //context.Request.Path = "/error404";
                    await next();

                }

                // Do logging or other work that doesn't write to the Response.
            });


            #endregion // 08/25/2020 06:21 pm - SSN - Testing middleware 
        }








        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }

        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }


        private static void HandleMultiSeg(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map multiple segments.");
            });
        }


        private static void HandleBranchAndRejoin(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var branchVer = context.Request.Query["branch"];

                // Do work that doesn't write to the Response.
                await next();
                // Do other work that doesn't write to the Response.
            });
        }



        public static void UseExceptionHandler_custom(IApplicationBuilder app)
        {
            // https://blog.georgekosmidis.net/2019/06/26/error-handling-in-asp-net-core-web-api/
            app.UseExceptionHandler(appError =>
            {

                appError.Run(async context =>
                {

                    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-3.1
                    #region 08/25/2020 07:43 pm - SSN



                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (!exceptionHandlerPathFeature.Path.ToLower().StartsWith("/api"))
                    {




                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                        //////var exceptionHandlerPathFeature =
                        //////    context.Features.Get<IExceptionHandlerPathFeature>();

                        // Use exceptionHandlerPathFeature to process the exception (for example, 
                        // logging), but do NOT expose sensitive error information directly to 
                        // the client.

                        if (exceptionHandlerPathFeature?.Error is System.IO.FileNotFoundException)
                        {
                            await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
                        }

                        await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512)); // IE padding

                        return;

                    }

                    #endregion 08/25/2020 07:43 pm - SSN




                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //Logging logic goes here
                        await context.Response.WriteAsync(context.Response.StatusCode + " Internal Server Error.");
                    }


                });





            });

        }


    }
}
