using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ps_DutchTreat.Data.Entities;
using ps_DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// 08/27/2020 01:56 am - SSN - [20200827-0153] - [001] - M09-05 - Designing the login view

namespace ps_DutchTreat.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<CustomUser> signInManager;
        private readonly UserManager<CustomUser> userManager;
        private readonly IConfiguration config;

        // 08/27/2020 07:31 am - SSN - [20200827-0729] - [001] - M09-06 - Implementing login and logout

        public AccountController(ILogger<AccountController> _logger, SignInManager<CustomUser> _SignInManager, UserManager<CustomUser> _userManager, IConfiguration _config)
        {
            logger = _logger;
            signInManager = _SignInManager;
            userManager = _userManager;
            config = _config;
        }


        class Cred
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "app");
            }
            Cred cred = new Cred();
            config.Bind("Cred", cred);

            LoginViewModel model = new LoginViewModel(); ;
            if (cred != null)
            {
                model = new LoginViewModel { Username = cred.Username, temp = cred.Password };
            }

            return View(model);
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
                            return Redirect(returnUrl);
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


        // 08/27/2020 08:51 am - SSN - [20200827-0827] - [002] - M09-07 - Use identity in the API
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);

                if (user != null)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };



                        var token_key = config["Tokens:key"];
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token_key));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(

                            config["Tokens:Issuer"],
                            config["Tokens:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(5),
                            signingCredentials: creds
                            );

                        var results = new
                        {
                            token = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return Created("", results);

                    }
                }
            }

            return BadRequest();
        }

    }
}
