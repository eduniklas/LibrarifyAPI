using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibrarifyAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }
        [Required, MinLength(8), MaxLength(60)]
        public string Password { get; set; }
        [Required, MaxLength(60)]
        public string FirstName { get; set; }
        [Required, MaxLength(60)]
        public string LastName { get; set; }
        [Required, MinLength(4), MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public DateTime DateJoined { get; set; }
        [Required]
        public bool IsAccountActive { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
