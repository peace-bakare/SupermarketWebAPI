using SupermarketWebAPI.Domain.Models;
using SupermarketWebAPI.Domain.Repositories;
using SupermarketWebAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketWebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        Task<IEnumerable<Product>> IProductService.ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
