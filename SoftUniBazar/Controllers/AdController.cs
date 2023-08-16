namespace SoftUniBazar.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SoftUniBazar.Models;
    using SoftUniBazar.Services.Interfaces;

    public class AdController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IAdService adService;

        public AdController(ICategoryService categoryService, IAdService adService)
        {
            this.categoryService = categoryService;
            this.adService = adService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<AdViewModel> model = await this.adService.GetAllAdsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddAdViewModel model = new AddAdViewModel();
            model.Categories = await categoryService.GetAllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAdViewModel model)
        {
            decimal rate;
            if (!decimal.TryParse(model.Price, out rate))
            {
                ModelState.AddModelError(nameof(model.Price), "Price must be a number");
                return View(model);
            }
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            model.OwnerId = GetUserID();
            await adService.AddAdAsync(model);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            AddAdViewModel? ad = await adService.GetAdByIdForEditAsync(Id);
            if (ad == null)
            {
                return RedirectToAction("All");
            }
            ad.Categories = await categoryService.GetAllCategoriesAsync();
            return View(ad);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, AddAdViewModel model)
        {
            decimal rate;
            if (!decimal.TryParse(model.Price, out rate))
            {
                ModelState.AddModelError(nameof(model.Price), "Price must be a number");
                return View(model);
            }
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            await adService.EditAdAsync(model, Id);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Cart()
        {
            string Id = GetUserID();
            IEnumerable<AdViewModel> model = await this.adService.GetMyAdsAsync(Id);
            return View(model);
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            AddAdViewModel Ad = await this.adService.GetAdByIdForEditAsync(id);
            if (Ad == null)
            {
                return RedirectToAction("All");
            }
            var userID = GetUserID();
            await adService.AddAdToCollection(userID, Ad);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var ad = await this.adService.GetAdByIdForEditAsync(id);
            if (ad == null)
            {
                return RedirectToAction("All");
            }
            var userID = GetUserID();
            await adService.RemoveAdFromCollection(userID, ad);
            return RedirectToAction("All");
        }

        

    }
}
