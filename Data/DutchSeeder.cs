using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ps_DutchTreat.Controllers;
using ps_DutchTreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// 08/25/2020 06:51 am - SSN - [20200825-0651] - [001] - M07-06 - Seeding the database 

// 08/27/2020 12:19 am - SSN - [20200826-1737] - [004] - M09-03 - Storing identities in the database

namespace ps_DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext ctx;
        private readonly UserManager<CustomUser> userManager;
        private readonly ILogger<DutchSeeder> logger;

        public IHostingEnvironment Hosting { get; }

        public DutchSeeder(DutchContext _ctx, IHostingEnvironment _hosting, UserManager<CustomUser> _userManager)
        {
            ctx = _ctx;
            Hosting = _hosting;
            userManager = _userManager;
          
        }

        string selectedUserEmail = "john@doe.com";

        public async Task SeedAsync()
        {

            ctx.Database.EnsureCreated();


            CustomUser user = await userManager.FindByNameAsync(selectedUserEmail);

            if (user == null)
            {

                user = new CustomUser
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = selectedUserEmail,
                    UserName = selectedUserEmail
                };

                var result = await userManager.CreateAsync(user, "P@ssw0rd!101!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Cout not create user for seeder. [20200827-0028]");
                }

            }



            if (ctx.Products.Any())
            {
                return;
            }

            var file = Path.Combine(Hosting.ContentRootPath, "data/art.json");
            var json = File.ReadAllText(file);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

            ctx.Products.AddRange(products);

            var order = ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();

            if (order != null)
            {

                var product = products.First();
                
                order.user = user;

                order.Items = new List<OrderItem>() {
                new OrderItem
                                {
                                    Product = product,
                                    Quantity = 2,
                                    UnitPrice = product.Price

                                }
                };

            }

            ctx.SaveChanges();

        }
    }
}
