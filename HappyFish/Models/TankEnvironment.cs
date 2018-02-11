using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HappyFish
{
    public class TankEnvironment
    {
        [Key]
        public int TankEnvironmentId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public Guid Code { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(AutoGenerateField = false)]
        public DateTime EventTime { get; set; }

        public double PH { get; set; }
        public double Ammonia { get; set; }
        public double Oxygen { get; set; }
        public double Conductivity { get; set; }
        public double Temperature { get; set; }
    }
}