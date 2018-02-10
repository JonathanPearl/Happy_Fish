using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyFish
{
    public class TankEnvironment
    {
        public int TankEnvironmentId;

        public int TankId{ get; set; }
        public int FisheryId{ get; set; }
        public int NeedId { get; set; }

        public DateTime EventTime{ get; set; }
        public List<MeasuringCriteria>MeasuringCriterias { get; set; } // Todo: Figure Out a Way Generically to Add a Generic List of Measurement Criteria
    }
}
