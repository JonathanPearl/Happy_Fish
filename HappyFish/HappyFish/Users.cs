﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Users
    {
        public int Id { get; set; }
        public int SupplierId;
        public int FisheryId;

        public string First_Name;
        public string Middle_Names;
        public string Last_Name;
        public string Password;
        public string EMail;
    }
}
