using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class MeasuringCriteria
    {
        public int MeasuringCriteriaId { get; set; }
        public int TankEnvironmentId { get; set; }

        public string MeasuringType { get; set; } // EG PH, Oxygen O2, Ammonia NH3 Ect.
        public double MeasuringValue { get; set; } // Actual Value of Each measurement
    }
}
