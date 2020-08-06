using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(c => c.Id);
            builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(c => c.CategoryId);

            builder.Entity<Category>().HasData(
                new Category { Id = 100, Name = "Fruits and Vegetables" },
                new Category { Id = 101, Name = "Meat" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
        }
    }
}
