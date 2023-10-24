using System.ComponentModel.DataAnnotations;

namespace World.DTO.Country
{
    public class UpdateCountryDTO
    {
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        [MaxLength(3)]
        public string CountryCode { get; set; }
        [Required]
        [MaxLength(10)]
        public string CountryCallCode { get; set; }
    }
}
