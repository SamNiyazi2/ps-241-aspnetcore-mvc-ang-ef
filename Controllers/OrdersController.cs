using AutoMapper;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ps_DutchTreat.Data;
using ps_DutchTreat.ViewModels;
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
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository repository;
        private readonly ILogger<OrdersController> logger;
        private readonly IMapper mapper;

        public OrdersController(IDutchRepository _repository, ILogger<OrdersController> _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {

            try
            {
                return Ok(mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(repository.GetAllOrders(includeItems)));
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
                    return Ok(mapper.Map<Order, OrderViewModel>(order));
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
        public IActionResult Post([FromBody] OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var newOrder = mapper.Map<OrderViewModel, Order>(model);


                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    repository.AddEntity(newOrder);

                    if (repository.SaveAll())
                    {
                        return Created($"/api/orders/{newOrder.Id}", mapper.Map<Order, OrderViewModel>(newOrder));
                    }
                    else
                    {
                        var errorInfo = APIErrorHandler.LogInformation<OrdersController>("20200825-1742", "API Failure - failed to add order", "Failed to save new order.", logger);
                        return BadRequest(errorInfo);
                    }

                }
                else
                {
                    var errorInfo = APIErrorHandler.LogInformation<OrdersController>("20200826-0722", "API validation error", "API Validation error.", logger, ModelState);
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
