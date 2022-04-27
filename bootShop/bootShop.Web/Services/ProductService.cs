using bootShop.Entities;
using System.Collections.Generic;

namespace bootShop.Web.Services
{
    public class ProductService
    {
        private List<Product> products;
        public ProductService()
        {
            products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name ="Dell XPS 13",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 1,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name ="Samsung",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 1,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name ="MacBook Air",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 1,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name ="MacBook Air",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 1,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name ="MacBook Air",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 1,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name ="MacBook Air",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 1,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                }
            };
        }
        public List<Product> GetProducts()
        {
            return this.products;
        }
    }
}
