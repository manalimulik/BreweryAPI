using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryAPI.Models
{
    [Table("tblBarAndBeerInfo")] 
    public class BarAndBeerInfo
    {
        [Key]
        public int BarAndBeerInfoId { get; set; }

        public int BarId { get; set; }
        public int BeerId { get; set; }
    }
}
