using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class Need
    {
        [Key]
        public int NeedId{ get; set; }

        public int ProductId{ get; set; }

        public TankEnvironment MinEnvironment{ get; set; }// PH 3.7 // Amonia 0.1mg p l Blue Tilapia / Tempreature
        public TankEnvironment MaxEnvironment{ get; set; }// PH 11 // Ammonia 7.1mg p l / Temprature
        public TankEnvironment MinRecommended{ get; set; }// PH 7 // Oxygen 7ppm // 
        public TankEnvironment MaxRecommended{ get; set; }// PH 9 //Density 2 Pounds per Cubic Foot
        public ICollection<string> Preventions{ get; set; }
        public ICollection<string> Interactions{ get; set; }
    }
}