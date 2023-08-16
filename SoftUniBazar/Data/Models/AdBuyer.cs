namespace SoftUniBazar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Ad Buyer")]

    public class AdBuyer
    {
        [Comment("Buyer Id")]
        [ForeignKey("IdentityUser")]
        public string BuyerId { get; set; } = null!;

        [Comment("Buyer")]
        [Required]
        public IdentityUser Buyer { get; set; } = null!;

        [Comment("Add Id")]
        [ForeignKey("Ad")]
        public int AdId { get; set; }

        [Comment("Ad")]
        [Required]
        public Ad Ad { get; set; } = null!;
    }
}
