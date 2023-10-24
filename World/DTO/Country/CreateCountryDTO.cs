using System.ComponentModel.DataAnnotations;

namespace World.DTO.Country
{
    public class CreateCountryDTO
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryCallCode { get; set; }
    }
}
