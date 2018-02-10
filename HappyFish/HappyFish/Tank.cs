using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Tank
    {
        public int TankId;
        public int FisheryId;

        public string DisplayName;
        public decimal Volume;

        public Dictionary <DateTime,TankEnvironment> EnvironmentStates;
        public List <Product> Products;
        public Dictionary<DateTime, Event> Events;
    }
}
