using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFish
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public Business Business{ get; set; }
        public List<Users> Users{ get; set; }
        public List<Product> Products{ get; set; }
    }
}
