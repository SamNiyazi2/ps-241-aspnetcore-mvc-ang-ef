using DutchTreat.Data.Entities;
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

        public DutchRepository(DutchContext _ctx)
        {
            ctx = _ctx;
        }

        public IEnumerable<Product> GetAllProducts()
        {
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

    }
}
