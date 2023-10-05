namespace SneakerSellingSystem.Models.Sneakers
{
    using System.ComponentModel.DataAnnotations;
    using static SneakerSellingSystem.Data.DataConstants;

    public class AddSneakerFormModel
    {
        [Required]
        [StringLength(SneakerBrandMaxLength, MinimumLength = SneakerBrandMinLength)]
        public string Brand { get; init; }

        [Required]
        [StringLength(SneakerModelMaxLength, MinimumLength = SneakerModelMinLength)]
        public string Model { get; init; }

        [Required]
        [StringLength(SneakerColorMaxLength, MinimumLength = SneakerColorMinLength)]
        public string Color { get; init; }

        [Required]
        [StringLength(SneakerDescriptionMaxLength, MinimumLength = SneakerDescriptionMinLength)]
        public string Description { get; init; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageUrl { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<SneakerCategoryViewModel> Categories { get; set; }
    }
}
