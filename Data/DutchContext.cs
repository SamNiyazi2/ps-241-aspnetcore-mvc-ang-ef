using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/24/2020 01:54 pm - SSN - [20200824-1335] - [001] - M07-01 - Creating entities

namespace ps_DutchTreat.Data
{
    public class DutchContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }



    }
}
