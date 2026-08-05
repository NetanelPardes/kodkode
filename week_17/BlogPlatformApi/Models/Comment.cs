using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace BlogPlatformApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public int PostId { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public Post post { get; set; } = null!;
        [Required]
        [StringLength(200)]
        public string CommenterName { get; set; } = string.Empty;
        [StringLength(500)]
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

    }
}
