using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrarifyAPI.Models.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required, MaxLength(255)]
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
    }
}
