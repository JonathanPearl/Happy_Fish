using System;
using System.ComponentModel.DataAnnotations;

namespace WorkerRegistration.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        
        [Display(AutoGenerateField = false)]
        public string QRCode { get; set; }

        [Required]
        [Display(Name = "First Name(s)")]
        public string FirstNames { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Gender { get; set; }

        [Display(Name = "Date Issued (UTC/GMT)", AutoGenerateField = false)]
        [DataType(DataType.DateTime)]
        public DateTime Issue { get; set; }

        [Display(Name = "Expiry (UTC/GMT)", AutoGenerateField = false)]
        [DataType(DataType.DateTime)]
        public DateTime Expiry { get; set; }

        [Display(Name = "Place Of Registration", AutoGenerateField = false)]
        public string Place { get; set; }
        
        public string Language { get; set; }

        public string Occupation { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}