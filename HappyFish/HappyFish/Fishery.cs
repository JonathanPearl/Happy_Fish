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
        public string DisplayName;
        public string RegisteredName;
        public string Location; // ToDO - Change To Address
        public Dictionary<string ,Tank> Tanks;

        public Fishery()
        {
            Tanks = new Dictionary<string, Tank>();
        }

        internal void AddTank(Tank tank)
        {
           Tanks.Add(tank.DisplayName,tank);
        }

        internal void DeleteTank(string DisplayName)
        {
            
        }
    }
}
