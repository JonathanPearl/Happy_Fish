using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Nutrition
    {
        public int NutritionId{ get; set; }
        public int NeedId{ get; set; }

        public string Name{ get; set; }
        public decimal Value{ get; set; }
        public decimal Frequency{ get; set; }
        public string FrequencyMeasuringPeriod{ get; set; }

    }
}
