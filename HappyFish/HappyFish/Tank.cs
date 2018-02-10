using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Tank
    {
        private int Id;
        public string DisplayName;
        public Size Size;
        public Dictionary <DateTime,TankEnvironment> EnvironmentStates;
        public Dictionary<string, Product> Products;
        public Dictionary<DateTime, Event> Events;
    }
}
