using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace HappyFish
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public int TankId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public DateTime EventTime { get; set; }

        public string Notes { get; set; }
    }
}