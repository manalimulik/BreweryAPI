using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryAPI.Models
{
    [Table("tblBreweryAndBeerInfo")] 
    public class BreweryAndBeerInfo
    {
        [Key]
        public int BreweryAndBeerInfoId { get; set; }

        public int BreweryId { get; set; }
        public int BeerId { get; set; }
    }
}
