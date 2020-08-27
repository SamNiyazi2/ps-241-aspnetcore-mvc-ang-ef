using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using ps_DutchTreat.Data.Entities;
using ps_DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/27/2020 01:56 am - SSN - [20200827-0153] - [001] - M09-05 - Designing the login view

namespace ps_DutchTreat.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<CustomUser> signInManager;

        // 08/27/2020 07:31 am - SSN - [20200827-0729] - [001] - M09-06 - Implementing login and logout

        public AccountController(ILogger<AccountController> _logger, SignInManager<CustomUser> _SignInManager)
        {
            logger = _logger;
            signInManager = _SignInManager;
        }


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "app");
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        string returnUrl = Request.Query["ReturnUrl"].FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(returnUrl))
                        {
                            Redirect(returnUrl);
                        }
                    }

                    return RedirectToAction("Shop", "App");

                }
            }

            ModelState.AddModelError("", "Invalid username or password.");

            return View();

        }

        // 08/27/2020 08:03 am - SSN - [20200827-0729] - [002] - M09-06 - Implementing login and logout

        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }

    }
}
