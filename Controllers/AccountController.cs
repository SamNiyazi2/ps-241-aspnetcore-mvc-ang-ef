using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/27/2020 01:56 am - SSN - [20200827-0153] - [001] - M09-05 - Designing the login view

namespace ps_DutchTreat.Controllers
{
    public class AccountController:Controller
    {
        private readonly ILogger<AccountController> logger;

        public AccountController(ILogger<AccountController> _logger)
        {
            logger = _logger;
        }


        public IActionResult Login()
        {
            if ( User.Identity.IsAuthenticated )
            {
                return RedirectToAction("index", "app");
            }
             

            return View();
        }



    }
}
