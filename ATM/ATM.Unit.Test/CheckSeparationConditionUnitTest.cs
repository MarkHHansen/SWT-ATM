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
            plane = Substitute.For<IAirplaneValidation>();
            TestSeparationInAirspace.Add(TestPlane1);
            TestSeparationInAirspace.Add(TestPlane2);
            uut = new CheckSeparationCondition();
        }
        #endregion

        #region Assert
        //[TestCase(25,40,200,2000,4000,5000,0, TestName = "Planes are not colliding")]
        //[TestCase(5000, 40, 200, 2000, 4000, 5000, 0, TestName = "Planes are not colliding")]
        //public void Test_planes_not_colliding(int airplane1X, int airplane1Y, int airplane1Altitude,
        //    int airplane2X, int airplane2Y, int airplane2Altitude, double result)
        //{
        //    TestPlane1._xCoordiante = airplane1X;
        //    TestPlane1._yCoordiante = airplane1Y;
        //    TestPlane1._Altitude = airplane1Altitude;

        //    TestPlane2._xCoordiante = airplane2X;
        //    TestPlane2._yCoordiante = airplane2Y;
        //    TestPlane2._Altitude = airplane2Altitude;

        //    uut.DetectCollisions(TestSeparationInAirspace);

        //    Assert.That(uut.GetCondition(), Is.EqualTo(result));
        //}

        [TestCase(500,500,700,700,283,TestName = "Two planes are colliding in XY")]
        [TestCase(2000,1000,1400,1500, 781, TestName = "Two planes are colliding in XY")]
        [TestCase(16000, 17000, 300, 150, 23031, TestName = "Two planes are not colliding in XY")]
        [TestCase(10000, 10000, 10 , 20, 14121, TestName = "Two planes are not colliding in XY")]
        public void Test_distance_between_two_planes_in_XY(double airplane1X, double airplane1Y,
            double airplane2X, double airplane2Y, double result)
        {
            TestPlane1._xCoordiante = airplane1X;
            TestPlane1._yCoordiante = airplane1Y;
            TestPlane2._xCoordiante = airplane2X;
            TestPlane2._yCoordiante = airplane2Y;

            Assert.That(uut.CheckDistance(TestPlane1,TestPlane2), Is.EqualTo(result));
        }

        [TestCase(200, 500, 300, TestName = "Two planes are colliding in altitude")]
        [TestCase(1000, 1100,100, TestName = "Two planes are colliding in altitude")]
        [TestCase(16000, 17000, 23031, TestName = "Two planes are not colliding in altitude")]
        [TestCase(10000, 10000, 14121, TestName = "Two planes are not colliding in altitude")]
        public void Test_distance_between_two_plane_in_Altitude(int airplane1Altitude, int airplane2Altitude,
            double result)
        {
            TestPlane1._Altitude = airplane1Altitude;
            TestPlane2._Altitude = airplane2Altitude;

            Assert.That(uut.CheckAltitude(TestPlane1, TestPlane2), Is.EqualTo(result));
        }
        #endregion
    }
}
