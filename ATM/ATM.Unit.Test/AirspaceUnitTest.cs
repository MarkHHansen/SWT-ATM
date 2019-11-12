using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.ValidateAirplane;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class AirspaceUnitTest
    {
        private Airspace uut;
        [SetUp]
        public void SetUp()
        {
            uut = new Airspace();
        }

        [Test]
        public void AirspaceReturnsCorrectIntArray()
        {
            int[] result = {20000, 500, 90000, 10000, 90000, 10000};
            int[] funcreturn = uut.getAirspaceLimits();

            Assert.That(funcreturn, Is.EqualTo(result));
        }

        
    }
}
