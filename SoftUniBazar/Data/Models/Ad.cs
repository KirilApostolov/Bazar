namespace SoftUniBazar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.GeneralConstants;

    [Comment("Ad for Pazar")]
    public class Ad
    {
        //public Ad()
        //{
        //    this.AdBuyers = new HashSet<AdBuyer>();
        //}

        [Comment("Primary Key")]
        [Key]
        public int Id { get; set; }

        [Comment("Ad Name")]
        [Required]
        [MaxLength(AdNameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Ad Description")]
        [Required]
        [MaxLength(AdDiscriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Add Price")]
        [Required]
        public decimal Price { get; set; }

        [Comment("Owner Id")]
        [ForeignKey("IdentityUser")]
        public string OwnerId { get; set; } = null!;

        [Required]
        public IdentityUser Owner { get; set; } = null!;

        [Comment("Ad ImageUrl")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Ad CreatedOn")]
        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [Comment("Ad Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;


   //     public ICollection<AdBuyer> AdBuyers { get; set; }

    }
}

