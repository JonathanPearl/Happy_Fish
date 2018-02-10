using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Tank
    {
        public int TankId{ get; set; }
        public int FisheryId{ get; set; }

        public string DisplayName{ get; set; }
        public decimal Volume{ get; set; }

        public Dictionary <DateTime,TankEnvironment> TankMeasurements{ get; set; }
        public List <Product> Products{ get; set; }
        public Dictionary<DateTime, Event> Events{ get; set; }
    }
}
