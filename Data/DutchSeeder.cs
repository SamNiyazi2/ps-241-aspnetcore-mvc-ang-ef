using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// 08/25/2020 06:51 am - SSN - [20200825-0651] - [001] - M07-06 - Seeding the database 

namespace ps_DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext ctx;
        public IHostingEnvironment Hosting { get; }

        public DutchSeeder(DutchContext _ctx, IHostingEnvironment _hosting)
        {
            ctx = _ctx;
            Hosting = _hosting;
        }


        public void Seed()
        {
            ctx.Database.EnsureCreated();

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
