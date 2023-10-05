using System.ComponentModel.DataAnnotations;
using static SneakerSellingSystem.Data.DataConstants;

namespace SneakerSellingSystem.Data.Models
{
    public class Sneaker
    {
        public int Id { get; init; }

        [Required]
        [StringLength(SneakerBrandMaxLength, MinimumLength = SneakerBrandMinLength)]
        public string Brand { get; set; }

        [Required]
        [StringLength(SneakerModelMaxLength, MinimumLength = SneakerModelMinLength)]
        public string Model { get; set; }

        [Required]
        [StringLength(SneakerColorMaxLength, MinimumLength = SneakerColorMinLength)]
        public string Color { get; set; }

        [Required]
        [StringLength(SneakerDescriptionMaxLength, MinimumLength = SneakerDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }
    }
}
