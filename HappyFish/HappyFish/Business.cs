using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Business
    {
        private int Id{ get; set; }
        public int SupplierId{ get; set; }
        public int FisheryId{ get; set; }

        public string DisplayName{ get; set; }
        public Address Location{ get; set; }
    }
}
