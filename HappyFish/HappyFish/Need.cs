using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Need
    {
        public int NeedId{ get; set; }
        public int ProductId{ get; set; }

        public LifeStage LifeStage{ get; set; }
        public List<Nutrition> Nutrition{ get; set; }
        public TankEnvironment MinEnvironment{ get; set; }// PH 3.7 // Amonia 0.1mg p l Blue Tilapia
        public TankEnvironment MaxEnvironment{ get; set; }// PH 11 // Ammonia 7.1mg p l
        public TankEnvironment MinRecommended{ get; set; }// PH 7 // Oxygen 7ppm // 
        public TankEnvironment MaxRecommended{ get; set; }// PH 9 //Density 2 Pounds per Cubic Foot
        public List<string> Preventions{ get; set; }
        public List<string> Interactions{ get; set; }
    }
}
