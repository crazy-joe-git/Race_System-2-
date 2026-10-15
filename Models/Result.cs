using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_System_2_.Models
{
    [Table("Result")]
    public class Result
    {
        [Key]
        public int ResultID { get; set; }

        [Required]
        [Display(Name = "Finish Time")]
        public string FinishTime { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Position")]
        public int Position { get; set; }

        [Required]
        [Display(Name = "Registration ID")]
        public int RegistrationID { get; set; }
    }
}