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
        public int FisheryId;

        public Business Business;     
        public List<Users> User; 
        public List<Tank> Tanks;
    }
}
