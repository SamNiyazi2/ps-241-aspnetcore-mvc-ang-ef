using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ps_DutchTreat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/25/2020 01:18 pm - SSN - [20200825-1315] - [001] - M08-02 - Returning data (API) 

namespace ps_DutchTreat.Controllers
{
    [Route("/api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository repository;
        private readonly ILogger<OrdersController> logger;

        public OrdersController(IDutchRepository _repository, ILogger<OrdersController> _logger)
        {
            repository = _repository;
            logger = _logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                return Ok(repository.GetAllOrders());
            }
            catch (Exception ex)
            {

                var errorInfo = APIErrorHandler.LogError<OrdersController>("20200825-1336", "APi failure.", "Failed API call.", ex, logger);

                return BadRequest(errorInfo);
            }
        }



        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {

            try
            {
                Order order = repository.GetOrderById(id);
                if (order != null)
                {
                    return Ok(order);
                }
                else
                {
                    var errorInfo = APIErrorHandler.LogInformation<OrdersController>("20200825-1526", "Invalid order number.", "User is requesting an invaid order number", logger);

                    return NotFound(errorInfo);

                }
            }
            catch (Exception ex)
            {

                var errorInfo = APIErrorHandler.LogError<OrdersController>("20200825-1336", "APi failure.", "Failed API call.", ex, logger);

                return BadRequest(errorInfo);
            }
        }


        [HttpPost]
        // public IActionResult Post(Order order)
        public IActionResult Post([FromBody] Order model)
        {
            try
            {
                repository.AddEntity(model);
                
                if (repository.SaveAll())
                {
                    return Created($"/api/orders/{model.Id}", model);
                }
                else
                {
                    var errorInfo = APIErrorHandler.LogInformation<OrdersController>("20200825-1742", "API Failure - failed to add order", "Failed to save new order.", logger);
                    return BadRequest(errorInfo);
                }
            }
            catch (Exception ex)
            {
                var errorInfo = APIErrorHandler.LogError<OrdersController>("20200825-1733", "API Failure", "Failed API call.", ex, logger);
                return BadRequest(errorInfo);
            }

        }

    }
}
