using System.ComponentModel.DataAnnotations;

namespace World.DTO.State
{
    public class UpdateStateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Population { get; set; }
        public int CountryId { get; set; }
    }
}
