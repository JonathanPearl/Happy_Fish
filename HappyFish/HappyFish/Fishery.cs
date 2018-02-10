using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFish
{
    public class Fishery
    {
        public int FisheryId{ get; set; }

        public Business Business{ get; set; }     
        public List<Users> User{ get; set; } 
        public List<Tank> Tanks{ get; set; }
    }
}
