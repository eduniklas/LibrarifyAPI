using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrarifyAPI.Models
{
    public class Fee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public int LoanId { get; set; }
        [ForeignKey("LoanId")]
        public Loan Loan { get; set; }
        [Required, Range(0, 1000)]
        public decimal Amount { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        public DateTime IssueDate { get; set; }
    }
}

