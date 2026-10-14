using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_System_2_.Models
{
    [Table("RaceCategory")]
    public class RaceCategory
    {
        [Key]
        public int CategoryID { get; set; } 

        [Required]
        public string CategoryName { get; set; } = string.Empty; // e.g, "10K Challenge"

        [Required]
        public int Distance { get; set; } // Distance in km

        [Required]
        public string Category_description { get; set; } = string.Empty;
    }
}