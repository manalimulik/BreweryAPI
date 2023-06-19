using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryAPI.Models
{
    [Table("tblBeer")]
    public class Beer
    {
        [Key]
        public int BeerId { get; set; }

        [Required]
        public string BeerName { get; set; }

        [Required]
        public decimal PercentageAlchoholByVolume { get; set; }

        public static explicit operator Task<object>(Beer v)
        {
            throw new NotImplementedException();
        }
    }
}
