using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Products
    {
        public string Name;
        public List<Needs> Needs;
        public List<Products> FriendlyProducts;
        public List<Products> AggressiveProducts;

    }
}
