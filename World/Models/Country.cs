using System.ComponentModel.DataAnnotations;

namespace World.Models
{
    public class Country
    {
        [Key]
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
