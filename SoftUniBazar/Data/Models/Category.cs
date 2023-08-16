namespace SoftUniBazar.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static Common.GeneralConstants;

    [Comment("Ad Categories")]
    public class Category
    {
        public Category()
        {
            this.Ads = new HashSet<Ad>();
        }
        [Comment("Primary Key")]
        [Key]
        public int Id { get; set; }

        [Comment("Ad Name")]
        [Required]
        [MaxLength(AdCategiryMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Ad> Ads { get; set; }
    }
}
