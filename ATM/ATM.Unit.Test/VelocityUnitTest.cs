using System;
using System.Collections.Generic;
using System.Globalization;
using NSubstitute;
using NUnit.Framework;
using ATM.Converter;
using NUnit.Framework;



namespace ATM.Unit.Test
{
    [TestFixture]
    public class VelocityUnitTest
    {
        private Velocity _uut;

        [SetUp]
        public void Setup()
        {
            //arrange
            _uut = new Velocity();
        }

        [Test]
        public void Test_CalculateVolocity()
        {
            //arrange
            DateTime oldDateTime =
                DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            DateTime newDateTime =
                DateTime.ParseExact("20151006213459789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            //act
            double velocity = _uut.CalculateVolocity(5, 10, 4, 6, oldDateTime, newDateTime);

            //assert
            Assert.That(velocity, Is.EqualTo(1.7950549357115013438));
        }

        [Test]
        public void Test_DeltaTime()
        {
            //arrange
            DateTime oldDateTime =
                DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            DateTime newDateTime = 
                DateTime.ParseExact("20151006213459789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);


            //act
            double Timespan = _uut.deltaTime(oldDateTime, newDateTime);

            //assert
            Assert.That(Timespan, Is.EqualTo(3.0));
        }

    }
}
