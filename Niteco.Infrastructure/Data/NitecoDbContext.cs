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
            // seed the database
            modelBuilder.Entity<Customer>().HasData(new Customer { Name = "Mr.Tran", Address = "Hanoi" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Name = "Mr.Hung", Address = "Haiphong" });
            // lam nhanh len em vat vao day, binh thuong em se tao ra class rieng
        }

        // Task 1:  Create db and table
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        // em se khong tao relation ma tu handle viec toan ven du lieu trong code
    }
}
