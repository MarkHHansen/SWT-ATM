using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.ValidateAirplane;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ATM.Unit.Test
{
    [TestClass]
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

            Assert.That(uut.Ge)
        }
    }
}
