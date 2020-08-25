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

        public IEnumerable<Order> GetAllOrders()
        {
            var results = ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(o => o.Product);

            results.Load(); // To see if we can trigger an error when table is missing.

            return results;

        }


        public Order GetOrderById(int id)
        {
            return ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(o => o.Product)
                .Where(o => o.Id == id).FirstOrDefault();
        }


        public IEnumerable<Product> GetAllProducts()
        {
            logger.LogInformation("Call to GetAllProducts - 20200825-1122");

            return ctx.Products
                .OrderBy(p => p.Title)
                .ToList();

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
