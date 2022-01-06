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

    public class CategoryRepository : BaseRepository, ICategoryRepository
    {

        //private readonly ICategoryRepository _context;

        public CategoryRepository (AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
