using System.ComponentModel.DataAnnotations;

namespace World.DTO.State
{
    public class StateDTO
    {
        public string Name { get; set; }
        public string Population { get; set; }
        public int CountryId { get; set; }
    }
}
