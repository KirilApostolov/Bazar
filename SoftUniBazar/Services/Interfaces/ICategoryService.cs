namespace SoftUniBazar.Services.Interfaces
{
    using SoftUniBazar.Models;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
