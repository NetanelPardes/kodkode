using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace BlogPlatformApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public Author Author { get; set; } = null!;
        [Required]
        [StringLength(500)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Body { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public bool IsPublished { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
