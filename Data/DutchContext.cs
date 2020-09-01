﻿using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ps_DutchTreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/24/2020 01:54 pm - SSN - [20200824-1335] - [001] - M07-01 - Creating entities

namespace ps_DutchTreat.Data
{
    // 08/26/2020 05:47 pm - SSN - [20200826-1737] - [002] - M09-03 - Storing identities in the database

    //public class DutchContext : DbContext
    public class DutchContext : IdentityDbContext<CustomUser>
    {
        // 08/24/2020 02:47 pm - SSN - [20200824-1416] - [003] - M07-04 - Using configuration

        public DutchContext(DbContextOptions<DutchContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    Id = 1,
                    ArtistNationality = "",
                    Category = ""
                });

        }

    }
}