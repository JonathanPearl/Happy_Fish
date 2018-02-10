using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class TankEnvironment
    {
        public int TankId{ get; set; }
        public int FisheryId{ get; set; }

        public DateTime EventTime{ get; set; }
        public Dictionary<string, string>MeasuringItem { get; set; }
    }
}
