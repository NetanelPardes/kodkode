using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace LibraryManagementSystemApi.Models
{
    [Index(nameof(ISBN), IsUnique = true)]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; }
        
        [Range(1800,2100)]
        public int PublishedYear { get; set; }

        [Range(0,int.MaxValue)]
        public int AvailableCopies{ get; set; }
    }
}
