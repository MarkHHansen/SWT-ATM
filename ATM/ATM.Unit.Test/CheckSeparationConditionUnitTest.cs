using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;
using ATM.Separation;
using ATM.ValidateAirplane;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class CheckSeparationConditionUnitTest
    {
        #region Arrange
        private Airplane TestPlane1;
        private Airplane TestPlane2;
        private List<Airplane> TestSeparationInAirspace;
        private IAirplaneValidation plane;

        private CheckSeparationCondition uut;
        #endregion

        #region Act 
        [SetUp]
        public void Setup()
        {
            TestPlane1 = Substitute.For<Airplane>();
            TestPlane2 = Substitute.For<Airplane>();

            TestSeparationInAirspace = new List<Airplane>();

            TestSeparationInAirspace.Add(TestPlane1);
            TestSeparationInAirspace.Add(TestPlane2);
            uut = new CheckSeparationCondition(plane);
        }
        #endregion
        /*
        #region Assert
        [TestCase(25,40,200,2000,4000,5000,0, TestName = "Planes are not colliding")]
        [TestCase(5000, 40, 200, 2000, 4000, 5000, 0, TestName = "Planes are not colliding")]
        public void Test_planes_not_colliding(int airplane1X, int airplane1Y, int airplane1Altitude,
            int airplane2X, int airplane2Y, int airplane2Altitude, int result)
        {
            TestPlane1._xCoordiante.Returns(airplane1X);
            TestPlane1._yCoordiante.Returns(airplane1Y);
            TestPlane1._Altitude.Returns(airplane1Altitude);

            TestPlane2._xCoordiante.Returns(airplane2X);
            TestPlane2._yCoordiante.Returns(airplane2Y);
            TestPlane2._Altitude.Returns(airplane2Altitude);

            uut.DetectCollisions(TestSeparationInAirspace);

            Assert.That(uut.GetCondition().Count, Is.EqualTo(result));
        }
        #endregion
    */
    }
}
