using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryAPI.Models
{
    [Table("tblBar")]
    public class Bar
    {
        [Key]
        public int BarId { get; set; }
        [Required]
        public string BarName { get; set; }
        [Required]
        public string BarAddress { get; set; }
       
    }
}
  