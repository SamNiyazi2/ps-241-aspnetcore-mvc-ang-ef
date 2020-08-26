using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ps_DutchTreat.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ErrorController : Controller
    {
        public ILogger<ErrorController> logger { get; }
        public ErrorController(ILogger<ErrorController> _logger)
        {
            logger = _logger;
        }


        [Route("/error2")]
        public IActionResult Error2()
        {
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            var exceptionHandlerPathFeature = this.HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            string path = exceptionHandlerPathFeature.Path;

            //HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //HttpContext.Response.ContentType = "application/json";
            if (path.ToLower().StartsWith("/api"))
            {
                var errorInfo = APIErrorHandler.LogError<ErrorController>("20200826-1647", "APi failure.", "Failed API call.", exceptionHandlerPathFeature.Error, logger);

                return BadRequest(errorInfo);
            }
            else
            {

                ErrorPage vm = new ErrorPage();
                vm.ErrorReferenceNo = Guid.NewGuid().ToString();
                vm.ErrorMessage = "System Error!";
                return View(vm);
            }
        }

    }

    public class ErrorPage
    {
        public string ErrorMessage { get; set; }
        public string ErrorReferenceNo { get; set; }
    }
}
