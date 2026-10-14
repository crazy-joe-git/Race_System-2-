using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_System_2_.Models
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; } 

        [Required]
        public DateTime Reg_Date { get; set; }

        [Required]
        public int BidNumber { get; set; }

        [Required]
        public string PaymentStatus { get; set; } = string.Empty; // "Paid", "Pending"

        public int ParticipantID { get; set; } 
        public int EventRaceID { get; set; } 
    }
}