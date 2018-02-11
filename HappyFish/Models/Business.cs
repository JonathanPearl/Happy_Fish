using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace HappyFish
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public Guid Code { get; set; }

        [Display(Name = "Name")]
        public string DisplayName { get; set; }

        public Address Address { get; set; }
    }
}