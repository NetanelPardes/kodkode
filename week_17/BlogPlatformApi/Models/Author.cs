using System.ComponentModel.DataAnnotations;

namespace BlogPlatformApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FullName is Required")]

        [StringLength(500)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateTime JoinedDate { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
