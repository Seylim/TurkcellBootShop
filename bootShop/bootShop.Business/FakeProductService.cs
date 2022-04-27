using bootShop.Dtos.Requests;
using bootShop.Dtos.Responses;
using bootShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootShop.Business
{
    public class FakeProductService : IProductService
    {
        private List<Product> products;
        public FakeProductService()
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
                    CategoryId = 2,
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
                    CategoryId = 2,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name ="MacBook Air",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 3,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name ="MacBook Air",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 3,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name ="MacBook Air",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 3,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name ="MacBook Air",
                    Price = 10000,
                    Discount = 0.15,
                    Description = "8 GB ram",
                    CategoryId = 3,
                    ImageUrl = @"https://cdn.dsmcdn.com//ty292/product/media/images/20220111/14/24965825/356386402/1/1_org.jpg"
                }
            };
        }

        public Task<int> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddProduct(AddProductRequest product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductListResponse> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return products;
        }

        public Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateProduct(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<ProductListResponse>> IProductService.GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
