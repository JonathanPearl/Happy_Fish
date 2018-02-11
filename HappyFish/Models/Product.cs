using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace HappyFish
{
    public class Product
    {
        public int ProductId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public Guid Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Pricing Unit / Measurement")]
        public string PriceUnits { get; set; }

        public LifeStage LifeStage { get; set; }
        public ICollection<Nutrition> Nutrition { get; set; }
        public ICollection<Need> Needs { get; set; }
    }
}
