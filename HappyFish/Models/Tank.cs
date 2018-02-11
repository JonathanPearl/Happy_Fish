using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace HappyFish
{
    public class Tank
    {
        [Key]
        public int TankId { get; set; }

        public int FisheryId { get; set; }

        public string Name { get; set; }

        public decimal Volume { get; set; }

        public ICollection<TankEnvironment> TankStates { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public Guid Code { get; set; } //For Products

        public ICollection<Event> Events { get; set; }
    }
}
