using System;
using System.ComponentModel.DataAnnotations;

namespace HappyFish
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public Guid Code { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "First Name(s)")]
        public string FirstNames { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}