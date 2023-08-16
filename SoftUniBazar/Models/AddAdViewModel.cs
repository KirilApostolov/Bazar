namespace SoftUniBazar.Models
{
    using Microsoft.AspNetCore.Identity;
    using SoftUniBazar.Data.Models;
    using System.ComponentModel.DataAnnotations;

    using static Common.GeneralConstants;
    public class AddAdViewModel
    {
        public AddAdViewModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(AdNameMaxLength, MinimumLength = AdNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(AdDiscriptionMaxLength, MinimumLength = AdDiscriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Price { get; set; } = null!;

        public string OwnerId { get; set; } = null!;

        public IdentityUser Owner { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        public IEnumerable<CategoryViewModel> Categories { get; set; }

    }
}
