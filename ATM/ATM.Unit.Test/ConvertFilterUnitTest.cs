using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using ATM.Converter;


namespace ATM.Unit.Test
{
    [TestFixture]
    public class ConvertFilterUnitTest
    {
        private ConvertFilter _uut;
        private RawTransponderDataEventArgs _dataEventArgs;
        private ITransponderReceiver _fakereceiver;
        private ICompassCourse _fakecompassCourse;
        private IVelocity _fakevelocity;

        [SetUp]
        public void Setup()
        {
            _fakereceiver = Substitute.For<ITransponderReceiver>();
            _fakecompassCourse = Substitute.For<ICompassCourse>();
            _fakevelocity = Substitute.For<IVelocity>();

            _uut = new ConvertFilter(_fakereceiver, _fakecompassCourse, _fakevelocity);
        }


        [Test]
        public void TestEvent()
        {
            // Arrange
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85890;12000;20151006213456789");
            testData.Add("XYZ987;25059;75654;4000;20151006213456789");

            _uut._receiver.TransponderDataReady += (o, e) => { _dataEventArgs = e; };

            // Act: Trigger the fake object to execute event invocation
            _fakereceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            // Assert something here or use an NSubstitute Received
            Assert.NotNull(_dataEventArgs);
        }

        #region FilterTests

        [Test]
        public void ConvertFilter_InsertTwoAirplanes_TwoDuplicates_Count2()
        {
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85890;12000;20151006213456789");
            _uut.convertdata(testData);
            
            List<string> testdata2 = new List<string>();
            testdata2.Add("ATR423;25059;75654;4000;20151006213456789");
            _uut.convertdata(testdata2);

            List<Airplane> temp = _uut.GetOldAirplanes();


            Assert.That(temp.Count, Is.EqualTo(2));
        }

        #endregion

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

            Assert.That(plane._tag, Is.EqualTo(temp));
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
            DateTime dt = new DateTime(1974, 10, 9, 8, 5, 3);
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
