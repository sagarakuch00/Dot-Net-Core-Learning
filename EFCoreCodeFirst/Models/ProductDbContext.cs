using CRUDUsingEFCoreCodeFirst.Models.Entities;
using EFCoreCodeFirst.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDUsingEFCoreCodeFirst.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) 
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // insert default records
            modelBuilder.Entity<Category>().
                HasData(new Category() { Id = 1, Name = "electornics", Rating = 4 });

            modelBuilder.Entity<Category>().
                HasData(new Category() { Id = 2, Name = "mobiles", Rating = 5 });
        }
    }
}
