using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryAPI.Models
{

    [Table("tblBrewery")] 
    public class Brewery
    {
        [Key]
        public int BreweryId { get; set; }

        [Required]
        public string BreweryName { get; set; }
    }
}
