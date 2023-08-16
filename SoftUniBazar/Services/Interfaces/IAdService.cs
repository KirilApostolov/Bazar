namespace SoftUniBazar.Services.Interfaces
{
    using SoftUniBazar.Models;

    public interface IAdService
    {
        Task AddAdAsync(AddAdViewModel model);

        Task<IEnumerable<AdViewModel>> GetAllAdsAsync();
        Task<AddAdViewModel?> GetAdByIdForEditAsync(int id);
        Task EditAdAsync(AddAdViewModel model, int id);
        Task<IEnumerable<AdViewModel>> GetMyAdsAsync(string id);
        Task AddAdToCollection(string userID, AddAdViewModel ad);
        Task RemoveAdFromCollection(string userID, AddAdViewModel ad);
    }
}
