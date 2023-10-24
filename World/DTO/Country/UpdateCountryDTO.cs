using System.ComponentModel.DataAnnotations;

namespace World.DTO.Country
{
    public class UpdateCountryDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryCallCode { get; set; }
    }
}
