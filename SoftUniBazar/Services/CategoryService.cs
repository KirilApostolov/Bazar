namespace SoftUniBazar.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoftUniBazar.Data;
    using SoftUniBazar.Models;
    using SoftUniBazar.Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly BazarDbContext dbContext;
        public CategoryService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var category = await this.dbContext
                .Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
            return category;
        }
    }
}
