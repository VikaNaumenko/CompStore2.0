using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Context
{
    public class CompStoreVersion2Context:DbContext
    {
        public CompStoreVersion2Context(DbContextOptions options):base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Product>().HasOne<Brand>(x=>x.Brand).WithMany(x=>x.Products).HasForeignKey(x=>x.BrandId);
            modelBuilder.Entity<Orders>().HasOne<Product>(x => x.Product).WithMany(x => x.Orders).HasForeignKey(x => x.ProductID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Orders> Orders { get; set; }
    }
}
