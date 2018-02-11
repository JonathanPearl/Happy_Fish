using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyFish
{
    public class Nutrition
    {
        [Key]
        public int NutritionId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Feeding { get; set; }
    }
}