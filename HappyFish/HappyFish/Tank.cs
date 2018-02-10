using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Tank
    {
        private int Id;
        public string DisplayName;
        private Size Size;
        public Dictionary <DateTime,TankEnvironment> environment;
        private Dictionary<string, Products> products;
        
       


    }
}
