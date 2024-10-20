using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarifyAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Author { get; set; }
        [Required, MinLength(13), MaxLength(17)]
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        [Required, MaxLength(70)]
        public string Genre { get; set; }
        [Required, MaxLength(2000)]
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        [Url]
        [MaxLength(200)]
        public string DigitalUrl { get; set; } // For digital or audiobook files
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
