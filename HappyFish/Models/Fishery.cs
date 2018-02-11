using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HappyFish
{
    public class Fishery
    {
        [Key]
        public int FisheryId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public Guid Code { get; set; }
        //List of Users Via Guid Code
        public virtual ICollection<Tank> Tanks { get; set; }
    }
}