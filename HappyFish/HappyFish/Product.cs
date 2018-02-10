using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Product
    {
        public int ProductId;
        public int OtherProductId;

        public int SupplierId;
        public int TankId;

        public string Name;
        public decimal Price;
        public string PriceUnits;
        public List<Need> Needs;
        public List<Product> FriendlyProducts;
        public List<Product> AggressiveProducts;
        public Dictionary<DateTime, Event> Events;
    }
}
