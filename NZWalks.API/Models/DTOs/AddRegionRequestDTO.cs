using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTOs
{
    public class AddRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "The Code has to be a minimum of 3 characters.")]
        [MaxLength(3, ErrorMessage = "The Code has to be a maximum of 3 characters.")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The Code has to be a maximum of 100 characters.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
