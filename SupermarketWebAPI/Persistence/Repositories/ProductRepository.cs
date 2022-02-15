using Microsoft.EntityFrameworkCore;
using SupermarketWebAPI.Domain.Models;
using SupermarketWebAPI.Domain.Repositories;
using SupermarketWebAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketWebAPI.Persistence.Repositories
{   
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _appDbContext.Products.Include(p => p.Category)
                                            .ToListAsync();
        }
    }
    
}
