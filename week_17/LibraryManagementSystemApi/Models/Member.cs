using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace LibraryManagementSystemApi.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(MembershipNumber), IsUnique = true)]
    public class Member
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string MembershipNumber { get; set; }

        public DateTime JoinedDate { get; set; }

    }
}
