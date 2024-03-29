﻿using AutoMapper;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ps_DutchTreat.Data;
using ps_DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/26/2020 12:38 pm - SSN - [20200826-1226] - [003] - M08-07 -Creating association controller

namespace ps_DutchTreat.Controllers
{
    // 08/27/2020 10:10 am - SSN - [20200827-0827] - [003] - M09-07 - Use identity in the API

    [Route("/api/orders/{orderid}/items")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemsController : Controller
    {
        private readonly IDutchRepository repository;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public OrderItemsController(IDutchRepository _repository, ILogger<OrderItemsController> _logger, IMapper _mapper)
        {
            repository = _repository;
            logger = _logger;
            mapper = _mapper;
        }


        [HttpGet]
        public IActionResult Get(int orderId)
        {
            // 08/27/2020 11:01 am - SSN - [20200827-1038] - [003] - M09-08 - Use identity in read operations
            string userName = User.Identity.Name;

            var order = repository.GetOrderById(userName, orderId);

            if (order != null) return Ok(mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            // 08/27/2020 11:04 am - SSN - [20200827-1038] - [006] - M09-08 - Use identity in read operations
            string userName = User.Identity.Name;

            var order = repository.GetOrderById(userName, orderId);

            if (order != null)
            {
                var item = order.Items.Where(i => i.Id == id).FirstOrDefault();

                if (item != null)
                    return Ok(mapper.Map<OrderItem, OrderItemViewModel>(item));
            }

            return NotFound();
        }


    }
}
