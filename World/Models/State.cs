using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace World.Models
{
    public class State
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name {  get; set; }
        [Required]
        public string Population { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
