using bootShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootShop.DataAccess.Data
{
    public class bootShopDbContext : DbContext
    {
        public bootShopDbContext(DbContextOptions<bootShopDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p=>p.Category)
                                          .WithMany(c=>c.Products)
                                          .HasForeignKey(p=>p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Telefon"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Laptop"
                    },
                    new Category { Id = 3, Name = "Tablet"}
                );

            modelBuilder.Entity<Product>().HasData(
                            new Product { Id = 1, Name = "IPhone", Price = 1500, Discount = 0.15, ImageUrl = "https://productimages.hepsiburada.net/s/189/222-222/110000155170720.jpg/format:webp", CategoryId = 1 },
                            new Product { Id = 2, Name = "Samsung", Price = 1500, Discount = 0.15, ImageUrl = "https://productimages.hepsiburada.net/s/178/222-222/110000142772021.jpg/format:webp", CategoryId = 1 },
                            new Product { Id = 3, Name = "Huawei", Price = 1500, Discount = 0.15, ImageUrl = "https://productimages.hepsiburada.net/s/50/222-222/11030233219122.jpg/format:webp", CategoryId = 1 },
                            new Product {Id = 4, Name = "Macbook Pro", Price = 1500, Discount = 0.15, ImageUrl = "https://productimages.hepsiburada.net/s/131/222-222/110000081537720.jpg/format:webp", CategoryId = 2},
                            new Product {Id = 5, Name = "Lenovo", Price = 1500, Discount = 0.15, ImageUrl = "https://productimages.hepsiburada.net/s/206/222-222/110000182816133.jpg/format:webp", CategoryId = 2},
                            new Product {Id = 6, Name = "Matebook", Price = 1500, Discount = 0.15, ImageUrl = "https://productimages.hepsiburada.net/s/153/222-222/110000109127071.jpg/format:webp", CategoryId = 2}
                );
        }
    }
}
