using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrarifyAPI.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [Required, Range(0, 5)]
        public int Rating { get; set; }
        [MaxLength(255)]
        public string Comment { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }
    }
}
