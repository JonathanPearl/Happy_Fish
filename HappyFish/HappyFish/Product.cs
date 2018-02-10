using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Product
    {
        public int ProductId{ get; set; }
        public int OtherProductId{ get; set; }

        public int SupplierId{ get; set; }
        public int TankId{ get; set; }

        public string Name{ get; set; }
        public decimal Price{ get; set; }
        public string PriceUnits{ get; set; }
        public List<Need> Needs{ get; set; }
        public List<Product> FriendlyProducts{ get; set; }
        public List<Product> AggressiveProducts{ get; set; }
        public Dictionary<DateTime, Event> Events{ get; set; }
    }
}
