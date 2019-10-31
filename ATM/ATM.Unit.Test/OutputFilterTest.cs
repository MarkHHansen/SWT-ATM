using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using ATM.Converter;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using ATM.OutputValidation_;
using ATM.ValidateAirplane;

namespace ATM.Unit.Test
{
    [TestFixture]
    class OutputFilterTest
    {
        private OutputFilter _uut;
        private IAirplaneValidation _planeSource;

        [SetUp]
        public void Setup()
        {

            _planeSource = Substitute.For<IAirplaneValidation>();
            _uut = new OutputFilter(_planeSource);


        }

        [Test]
        public void TestEvent()
        {
            List<Airplane> temp = new List<Airplane>();
            Airplane airplane = new Airplane();
            airplane._yCoordiante = 23456;
            airplane._xCoordiante = 30000;
            airplane._Altitude = 2000;
            airplane._compasCourse = 60.0;
            airplane._velocity = 1000.0;
            airplane._Time =
                DateTime.ParseExact("20151006123123495", "yyyyMMddhhmmssfff", CultureInfo.InvariantCulture);

            _planeSource.ValidationEvent += Raise.EventWith(new ValidationEventArgs(temp));
            _planeSource.Received(1);

          
        }

        #region AirplaneTests

        private Airplane plane;
        [SetUp]
        public void SetUp()
        {
            plane = new Airplane();
        }

        [Test]
        public void setTag_Correct()
        {
            plane._tag = "AAXX01";

            Assert.That(plane._tag, Is.EqualTo("AAXX01"));
        }

        [Test]
        public void getTag_Correct()
        {
            plane._tag = "AAXX01";
            string temp = plane._tag;

            Assert.That(temp, Is.EqualTo(plane._tag));
        }

        [Test]
        public void setSeperation_Correct()
        {
            plane._seperationCodition = true;

            Assert.That(plane._seperationCodition, Is.EqualTo(true));
        }

        [Test]
        public void getSeperation_Correct()
        {
            plane._seperationCodition = true;
            bool temp = plane._seperationCodition;

            Assert.That(temp, Is.EqualTo(true));
        }

        [Test]
        public void getTime_Correct()
        {
            DateTime dt = new DateTime(1974,10,9,8,5,3);
            plane._Time = dt;
            DateTime temp = plane._Time;

            Assert.That(temp, Is.EqualTo(dt));
        }

        [Test]
        public void getCompasCourse_Correct()
        {
            plane._compasCourse = 160.0;
            double temp = plane._compasCourse;

            Assert.That(temp, Is.EqualTo(160.0));
        }

        [Test]
        public void getVelocity_Correct()
        {
            plane._velocity = 7000;
            double temp = plane._velocity;

            Assert.That(temp, Is.EqualTo(7000));
        }
        #endregion


    }
  
}
