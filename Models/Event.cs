using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_System_2_.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int EventID { get; set; } 

        [Required]
        public string EventName { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public string EventLocation { get; set; } = string.Empty;

        [Required]
        public string OrganizerName { get; set; } = string.Empty;
    }
}