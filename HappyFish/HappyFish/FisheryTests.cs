using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HappyFish
{
    [TestFixture]
    public class FisheryTests
    {
        [Test]
        public void FisheryCanAddDetails()
        {
            var name = "New Fishery";
            Fishery newFishery = new Fishery {DisplayName = name};
            Assert.AreEqual(name, newFishery.DisplayName);
        }

      

    
    }
}
