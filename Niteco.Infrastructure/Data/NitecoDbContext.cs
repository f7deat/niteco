using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Niteco.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niteco.Infrastructure.Data
{
    public class NitecoDbContext : IdentityDbContext
    {
        public NitecoDbContext(DbContextOptions<NitecoDbContext> options) : base(options)
        {
            // dotnet ef migrations add InitialCreate -s Niteco.WebUI -p Niteco.Infrastructure
            // dotnet ef database update -s Niteco.WebUI -p Niteco.Infrastructure
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer { Name = "Mr.Tran", Address = "Hanoi" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Name = "Mr.Hung", Address = "Haiphong" });
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
