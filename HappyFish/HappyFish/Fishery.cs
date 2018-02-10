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
        private int Id;
        public string DisplayName;
        public Address Location;
        
        public List<Users> User; 
        public List<Tank> Tanks;

    }
}
