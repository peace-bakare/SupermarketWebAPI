using SupermarketWebAPI.Domain.Models;
using SupermarketWebAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketWebAPI.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();

        Task<SaveCategoryResponse> SaveAsync(Category category);

        Task<SaveCategoryResponse> UpdateAsync(int id, Category category);

        Task<SaveCategoryResponse> DeleteAsync(int id);

    }
}
