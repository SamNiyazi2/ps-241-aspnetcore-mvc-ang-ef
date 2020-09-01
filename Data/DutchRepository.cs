using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/25/2020 07:50 am - SSN - [20200825-0749] - [001] - M07-07 - The repository pattern

namespace ps_DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext ctx;
        private readonly ILogger<DutchRepository> logger;

        public DutchRepository(DutchContext _ctx, ILogger<DutchRepository> _logger)
        {
            ctx = _ctx;
            logger = _logger;
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            var results = default(IEnumerable<Order>);
            if (includeItems)
            {
                results = ctx.Orders
                  .Include(o => o.Items)
                  .ThenInclude(o => o.Product);
            }
            else
            {
                results = ctx.Orders;
            }

            //    results.Load(); // To see if we can trigger an error when table is missing.

            return results;

        }



        // 08/27/2020 10:45 am - SSN - [20200827-1038] - [002] - M09-08 - Use identity in read operations

        public IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems)
        {
            var results = default(IEnumerable<Order>);
            if (includeItems)
            {
                results = ctx.Orders
                    .Where(o => o.user.UserName == userName)
                    .Include(o => o.Items)
                    .ThenInclude(o => o.Product);
            }
            else
            {
                results = ctx.Orders
                            .Where(o => o.user.UserName == userName);
            }

            return results;
        }


        // 08/27/2020 11:02 am - SSN - [20200827-1038] - [004] - M09-08 - Use identity in read operations

        public Order GetOrderById(string userName, int id)
        {
            return ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(o => o.Product)
                .Where(o => o.Id == id && o.user.UserName == userName).FirstOrDefault();
        }


        public IEnumerable<Product> GetAllProducts()
        {
            logger.LogInformation("Call to GetAllProducts - 20200825-1122");

            return ctx.Products
                .OrderBy(p => p.Title)
                .ToList();

        }


        public List<Product> getRandomRecords(List<Product> results_1)
        {
            List<Product> results = new List<Product>();
            int rangeMax = results_1.Count();

            Random rand = new Random();
            var counter = 0;
            while (rangeMax > 0 && counter < 10)
            {
                counter++;
                results.Add(results_1[rand.Next(1, rangeMax)]);
            }
            //  rand.Next(1, 800);
            return results;

        }


        public IEnumerable<Product> GetProductsyCategory(string category)
        {
            return ctx.Products
                .Where(p => p.Category == category)
                .OrderBy(p => p.Title)
                .ToList();
        }

        public bool SaveAll()
        {
            return ctx.SaveChanges() > 0;
        }

        public void AddEntity(object model)
        {
            ctx.Add(model);
        }

    }
}
