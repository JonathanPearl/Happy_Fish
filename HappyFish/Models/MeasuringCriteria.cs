using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HappyFish
{
    public class MeasuringCriteria
    {
        [Key]
        public int MeasuringCriteriaId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public Guid Code { get; set; }

        public string MeasuringType { get; set; } // EG PH, Oxygen O2, Ammonia NH3 Ect.
        public double MeasuringValue { get; set; } // Actual Value of Each measurement
    }
}
