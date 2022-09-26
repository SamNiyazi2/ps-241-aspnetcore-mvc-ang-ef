using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        // 09/25/2022 03:23 pm - SSN - Added configuration and Datebase.Migrate().  Migration not work in Azure SQL.

        public DutchContext(DbContextOptions<DutchContext> options, IConfiguration configuration) : base(options)
        {


            bool.TryParse(configuration["Database_Migration"], out bool do_database_Migration);


            if (do_database_Migration)
            {
                try
                {
                    Database.SetCommandTimeout(6000);
                    Database.Migrate();
                }
                catch (Exception ex)
                {
                    // Todo
                    // Do nothing
                    // 09/25/2022 06:01 pm - SSN - Failing on Azure.
                    throw ex;

                }
            }
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 09/25/2022 07:09 am - SSN - Added
            // Leaving out causes an Identity error.
            // AggregateException: One or more errors occurred. (The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. If you intended to use a keyless entity type call 'HasNoKey()'.)
            base.OnModelCreating(modelBuilder);

            // 09/25/2022 01:42 pm - SSN - Added schema
            modelBuilder.HasDefaultSchema("ps_241");


            // 09/25/2022 03:14 am - SSN - Why?  Take out.
            //modelBuilder.Entity<Product>()
            //    .HasData(new Product
            //    {
            //        Id = 1,
            //        ArtistNationality = "",
            //        Category = ""
            //    });

        }

    }
}
