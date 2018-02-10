using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Need
    {
        public LifeStage LifeStage;
        public List<Nutrition> Nutrition;
        public TankEnvironment MinEnvironment;// PH 3.7 // Amonia 0.1mg p l Blue Tilapia
        public TankEnvironment MaxEnvironment;// PH 11 // Ammonia 7.1mg p l
        public TankEnvironment MinRecommended;// PH 7 // Oxygen 7ppm // 
        public TankEnvironment MaxRecommended;// PH 9 //Density 2 Pounds per Cubic Foot
        public List<string> Preventions;
        public List<string> Interactions;
    }
}
