namespace SoftUniBazar.Services.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SoftUniBazar.Data;
    using SoftUniBazar.Data.Models;
    using SoftUniBazar.Models;

    public class AdService : IAdService
    {
        private readonly BazarDbContext dbContext;
        public AdService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAdAsync(AddAdViewModel model)
        {
            Ad ad = new Ad
            {
                Id = model.Id,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                OwnerId = model.OwnerId,
                Price = decimal.Parse(model.Price),
                CategoryId = model.CategoryId,
                Description = model.Description,
                CreatedOn = DateTime.Now,
            };
            await this.dbContext.Ads.AddAsync(ad);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<AdViewModel>> GetAllAdsAsync()
        {
            var Ads = await this.dbContext
                .Ads
                .Select(x => new AdViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    CreatedOn = x.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Category = x.Category.Name,
                    Description = x.Description,
                    Price = x.Price.ToString(),
                    Owner = x.Owner.UserName,
                }).ToListAsync();
            return Ads;
        }

        public async Task EditAdAsync(AddAdViewModel model, int id)
        {
            var ad = await dbContext.Ads.FindAsync(id);
            if (ad != null)
            {
                ad.Name = model.Name;
                ad.Price = decimal.Parse(model.Price);
                ad.Description = model.Description;
                ad.ImageUrl = model.ImageUrl;
                ad.CategoryId = model.CategoryId;
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddAdViewModel?> GetAdByIdForEditAsync(int id)
        {
            AddAdViewModel? Ad = await this.dbContext.Ads.Where(a => a.Id == id)
                .Select(a => new AddAdViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description=a.Description,
                    ImageUrl = a.ImageUrl,
                    OwnerId = a.OwnerId,
                    Price = a.Price.ToString(),
                    CreatedOn = a.CreatedOn,
                    CategoryId = a.CategoryId,
                }).FirstOrDefaultAsync();
            
            return Ad;
        }

        public async Task<IEnumerable<AdViewModel>> GetMyAdsAsync(string id)
        {
            var Ads = await this.dbContext
                .AdsBuyers
                .Where(a => a.BuyerId == id)
                .Select(x => new AdViewModel
                {
                    Id = x.Ad.Id,
                    Name = x.Ad.Name,
                    ImageUrl = x.Ad.ImageUrl,
                    CreatedOn = x.Ad.CreatedOn.ToString(),
                    Category = x.Ad.Category.Name,
                    Description = x.Ad.Description,
                    Price = x.Ad.Price.ToString(),
                    Owner = x.Ad.Owner.UserName,
                }).ToListAsync();
            return Ads;
        }

        public async Task AddAdToCollection(string userID, AddAdViewModel ad)
        {
            bool AlreadyAdded = await dbContext.AdsBuyers
                .AnyAsync(ub => ub.BuyerId == userID && ub.AdId == ad.Id);

            if (!AlreadyAdded)
            {
                var userBook = new AdBuyer { BuyerId = userID, AdId = ad.Id };
                await dbContext.AdsBuyers.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveAdFromCollection(string userID, AddAdViewModel ad)
        {
            var AdsBuyer = await dbContext.AdsBuyers
                                .FirstOrDefaultAsync(ub => ub.BuyerId == userID && ub.AdId == ad.Id);
            if (AdsBuyer != null)
            {
                dbContext.AdsBuyers.Remove(AdsBuyer);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}