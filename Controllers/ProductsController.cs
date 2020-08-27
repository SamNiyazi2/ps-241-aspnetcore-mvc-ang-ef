using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ps_DutchTreat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 08/25/2020 11:40 am - SSN - [20200825-1139] - [001] - M08-01 - Create an API controller

namespace ps_DutchTreat.Controllers
{
    // 08/27/2020 10:11 am - SSN - [20200827-0827] - [004] - M09-07 - Use identity in the API

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly IDutchRepository repository;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IDutchRepository _repository, ILogger<ProductsController> _logger)
        {
            repository = _repository;
            logger = _logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {

            try
            {
                return Ok(repository.GetAllProducts().Take(10));

            }
            catch (Exception ex)
            {
                var errorInfo = APIErrorHandler.LogError<ProductsController>("20200825-1156", "APi failure.", "Failed API call.", ex, logger);

                return BadRequest(errorInfo);
            }

        }

    }
}
