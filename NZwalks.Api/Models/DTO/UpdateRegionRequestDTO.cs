using System.ComponentModel.DataAnnotations;

namespace NZwalks.Api.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Code has Max length is 3 Charcter")]
        [MinLength(3, ErrorMessage = "Code has Minimum length is 3 Charcter")]
        
        public string Code { get; set; }
        [MaxLength(100, ErrorMessage = "Code has Minimum length is 100 Charcter")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
