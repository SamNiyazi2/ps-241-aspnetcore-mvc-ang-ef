﻿using Microsoft.AspNetCore.Mvc;
using ps_DutchTreat.Data;
using ps_DutchTreat.Services;
using ps_DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/23/2020 08:39 pm - SSN - [20200823-2037] - [001] - M05-03 - First controller/view 

namespace ps_DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;

        public DutchContext context { get; }

        // 08/24/2020 08:07 am - SSN - [20200824-0751] - [003] - M05-12 - Adding a service
        public AppController(IMailService mailService, DutchContext _context)
        {
            this.mailService = mailService;
            context = _context;
        }


        public IActionResult Index()
        {
            // 08/25/2020 07:29 am - SSN - [20200825-0651] - [004] - M07-06 - Seeding the database 
            // Duplicate of Shop ???
            var results = context.Products
               .OrderBy(p => p.Category)
               .ToList();

            return View(results);
        }


        // 08/23/2020 10:10 pm - SSN - [20200823-2148] - [001] - M05-06 - Adding more views
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {

            if (ModelState.IsValid)
            {
                this.mailService.SendMessage("sam@niyazi.com", model.Subject, $"From: {model.Name} ({model.Email}), Message: {model.Message}");
                ModelState.Clear();
                ViewBag.UserMessage = "Email sent";
                ViewBag.UserMessageClassname = "text-success";

            }

            return View();
        }



        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }

        public IActionResult ThrowError()
        {

            throw new InvalidOperationException("Something went wrong!");
        }


        // 08/24/2020 04:43 pm - SSN - [20200824-1643] - [001] - M07-05 - Using DbContext 
        public IActionResult Shop()
        {
            var results = context.Products
                .OrderBy(p => p.Category)
                .ToList();

            return View(results);
        }

    }
}
