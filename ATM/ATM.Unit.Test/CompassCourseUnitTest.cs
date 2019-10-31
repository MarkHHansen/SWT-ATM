using System;
using System.Collections.Generic;
using System.Globalization;
using NSubstitute;
using NUnit.Framework;
using ATM.Converter;


namespace ATM.Unit.Test
{
    [TestFixture]
    public class CompassCourseUnitTest
    {

        private CompasCourse _uut;

        [SetUp]
        public void Setup()
        {
            //arrange
            _uut = new CompasCourse();
        }
        [Test]
        public void Test_CalculateCompassCourse()
        {
            //act
            double Course = _uut.CalculateCompassCourse(2, 4, 6, 10);

            //assert
            Assert.That(Course, Is.EqualTo(56.309932474020213086));
        }
    }
}
