using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Users
    {
        public int Id { get; set; }
        public int SupplierId{ get; set; }
        public int FisheryId{ get; set; }

        public string First_Name{ get; set; }
        public string Middle_Names{ get; set; }
        public string Last_Name{ get; set; }
        public string Password{ get; set; }
        public string EMail{ get; set; }
    }
}
