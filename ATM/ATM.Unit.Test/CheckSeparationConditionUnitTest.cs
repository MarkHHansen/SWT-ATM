using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class CheckSeparationConditionUnitTest
    {
        #region Arrange
        private Airplane TestPlane1;
        private Airplane TestPlane2;
        private List<Airplane> TestSeparationInAirspace;
        private IAirplaneValidation plane;
        private CheckSeparationCondition _uut;
        private IAirplaneValidation _planeSource;
        private SeparationCondition _sepcond;
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

            _planeSource = Substitute.For<IAirplaneValidation>();
            _uut = new CheckSeparationCondition(_planeSource);
        }
        #endregion

        #region Assert
        [Test]
        public void Test_event_is_recieved_from_ValidationEventArgs()
        {
            List<Airplane> temp = new List<Airplane>();
            Airplane airplane = new Airplane();
            _planeSource.ValidationEvent += Raise.EventWith(new ValidationEventArgs(temp));
            _planeSource.Received(1);
        }

        [TestCase(500, 500, 700, 700, 283, TestName = "Two planes are colliding in XY")]
        [TestCase(2000, 1000, 1400, 1500, 781, TestName = "Two planes are colliding in XY")]
        [TestCase(16000, 17000, 300, 150, 23031, TestName = "Two planes are not colliding in XY")]
        [TestCase(10000, 10000, 10, 20, 14121, TestName = "Two planes are not colliding in XY")]
        public void Test_distance_between_two_planes_in_XY(double airplane1X, double airplane1Y,
            double airplane2X, double airplane2Y, double result)
        {
            TestPlane1._xCoordiante = airplane1X;
            TestPlane1._yCoordiante = airplane1Y;
            TestPlane2._xCoordiante = airplane2X;
            TestPlane2._yCoordiante = airplane2Y;

            Assert.That(_uut.CheckDistance(TestPlane1, TestPlane2), Is.EqualTo(result));
        }

        [TestCase(800, 1100, 300, TestName = "Two planes are colliding in altitude")]
        [TestCase(1000, 1100,100, TestName = "Two planes are colliding in altitude")]
        [TestCase(-1000, -1100, 100, TestName = "Two planes are colliding in altitude")]
        [TestCase(1000, 5000 , 4000, TestName = "Two planes are not colliding in altitude")]
        [TestCase(10000, 20000, 10000, TestName = "Two planes are not colliding in altitude")]
        public void Test_distance_between_two_plane_in_Altitude(double airplane1Altitude, double airplane2Altitude,
            double result)
        {
            TestPlane1._Altitude = airplane1Altitude;
            TestPlane2._Altitude = airplane2Altitude;

            Assert.That(_uut.CheckAltitude(TestPlane1, TestPlane2), Is.EqualTo(result));
        }

        [TestCase(16000, 17000, 1000, 300, 150, 5000, TestName = "Two planes are not colliding")]
        [TestCase(10000, 15000, 10000, 10, 20, 10100, TestName = "Two planes are not colliding")]
        public void Test_if_two_planes_are_NOT_colliding_inAltitude_AND_XY(int airplane1X, int airplane1Y, int airplane1Altitude,
            int airplane2X, int airplane2Y, int airplane2Altitude)
        {
            TestPlane1._xCoordiante = airplane1X;
            TestPlane1._yCoordiante = airplane1Y;
            TestPlane1._Altitude = airplane1Altitude;

            TestPlane2._xCoordiante = airplane2X;
            TestPlane2._yCoordiante = airplane2Y;
            TestPlane2._Altitude = airplane2Altitude;

            Assert.That(_uut.CheckForCollision(TestPlane1, TestPlane2), Is.False);
        }

        [TestCase(500, 500, 801, 500, 283, 1100, TestName = "Two planes are colliding")]
        [TestCase(2000, 1000, 1000, 1400, 1500, 1100, TestName = "Two planes are colliding")]
        public void Test_if_two_planes_are_colliding_inAltitude_AND_XY(int airplane1X, int airplane1Y, int airplane1Altitude,
            int airplane2X, int airplane2Y, int airplane2Altitude)
        {
            TestPlane1._xCoordiante = airplane1X;
            TestPlane1._yCoordiante = airplane1Y;
            TestPlane1._Altitude = airplane1Altitude;

            TestPlane2._xCoordiante = airplane2X;
            TestPlane2._yCoordiante = airplane2Y;
            TestPlane2._Altitude = airplane2Altitude;

            Assert.That(_uut.CheckForCollision(TestPlane1, TestPlane2), Is.True);
        }

        [TestCase(8000, 8000, 8000, 8000, 8000, 500, 0, TestName = "Detection Planes Colliding Leaving Condition")]
        public void Test_taht_detected_planes_are_removed(int airplane1X, int airplane1Y, int airplane1Altitude,
            int airplane2X, int airplane2Y, int airplane2Altitude, int result)
        {
            for (int i = 0; i < 1; i++)
            {
                TestPlane1._xCoordiante = airplane1X;
                TestPlane1._yCoordiante = airplane1Y;
                TestPlane1._Altitude = airplane1Altitude;

                TestPlane2._xCoordiante = airplane1X;
                TestPlane2._yCoordiante = airplane1Y;
                TestPlane2._Altitude = airplane1Altitude;
                TestPlane1._Time = new DateTime(1212);

                _uut.DetectCollisions(TestSeparationInAirspace);
            }
            TestPlane2._xCoordiante = airplane2X;
            TestPlane2._yCoordiante = airplane2Y;
            TestPlane2._Altitude = airplane2Altitude;
            TestPlane2._Time = new DateTime(11);

            _uut.DetectCollisions(TestSeparationInAirspace);

            Assert.That(_uut.GetCondition().Count, Is.EqualTo(result));
        }

        [TestCase(400, 500, 10000, 10001, 10000, 10001)]
        public void Check_conditions_list_is_not_empty(int airplane1X, int airplane1Y, int airplane1Altitude,
            int airplane2X, int airplane2Y, int airplane2Altitude)
        {
            TestPlane1._xCoordiante = airplane1X;
            TestPlane1._yCoordiante = airplane1Y;
            TestPlane1._Altitude = airplane1Altitude;

            TestPlane2._xCoordiante = airplane2X;
            TestPlane2._yCoordiante = airplane2Y;
            TestPlane2._Altitude = airplane2Altitude;

            TestSeparationInAirspace.Add(TestPlane1);
            TestSeparationInAirspace.Add(TestPlane2);

            _uut.DetectCollisions(TestSeparationInAirspace);
            Assert.That(TestSeparationInAirspace, Is.Not.Null);
        }

        [TestCase(5000, 5000, 5000, 19000, 19000, 15000, 0, TestName = "Detect planes not colliding")]
        [TestCase(1000, 1000, 500, 12000, 12000, 11000, 0, TestName = "Detect planes not colliding")]
        [TestCase(6800, 4500, 1000, 6500, 4700, 1100, 0, TestName = "Detect planes colliding")]
        [TestCase(10, 10, 10, 10, 10, 10, 0, TestName = "Detect planes colliding")]
        public void Test_planes_are_detected(int airplane1X, int airplane1Y, int airplane1Altitude,
            int airplane2X, int airplane2Y, int airplane2Altitude, int result)
        {
            TestPlane1._xCoordiante = airplane1X;
            TestPlane1._yCoordiante = airplane1Y;
            TestPlane1._Altitude = airplane1Altitude;
            TestPlane1._tag = "HJJAS3d";
            TestPlane1._Time = new DateTime(2019, 11, 11);

            TestPlane2._xCoordiante = airplane2X;
            TestPlane2._yCoordiante = airplane2Y;
            TestPlane2._Altitude = airplane2Altitude;
            TestPlane2._tag = "HAASKJD2";
            TestPlane2._Time = new DateTime(2019, 11, 11);
            _uut.DetectCollisions(TestSeparationInAirspace);

            Assert.That(_uut.GetCondition().Count, Is.EqualTo(result));
        }
        #endregion
    }
}
