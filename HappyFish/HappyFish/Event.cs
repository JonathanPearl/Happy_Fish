using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Event
    {
        public int EventId{ get; set; }
        public int TankId{ get; set; }
        public int ProductId{ get; set; }

        public DateTime EventTime{ get; set; }
        public string DisplayNote{ get; set; }
        public string WarningType{ get; set; }

    }
}
