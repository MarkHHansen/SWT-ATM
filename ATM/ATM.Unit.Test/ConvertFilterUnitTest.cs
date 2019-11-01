using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            _fakevelocity = Substitute.For<IVelocity>();
            _fakecompassCourse = Substitute.For<ICompassCourse>();

            _uut = new ConvertFilter(_fakereceiver, _fakecompassCourse, _fakevelocity);
        }

        [Test]
        public void Test_Event_Received()
        {
            // Arrange
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85890;12000;20151006213456789");
            testData.Add("XYZ987;25059;75654;4000;20151006213456789");

            _fakereceiver.TransponderDataReady += (o, e) => { _dataEventArgs = e; };

            // Act: Trigger the fake object to execute event invocation
            _fakereceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            // Assert something here or use an NSubstitute Received
            Assert.NotNull(_dataEventArgs);
        }


        [Test]
        public void Test_Event_Rised()
        {
            // Arrange
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85890;12000;20151006213456789");
            testData.Add("XYZ987;25059;75654;4000;20151006213456789");

            // Act
            _fakereceiver.TransponderDataReady += Raise.EventWith(new RawTransponderDataEventArgs(testData));

            // Assert
            Assert.That(_uut.transponderData, Is.EqualTo(testData));
        }

        [Test]
        public void Test_Convert_Data_Funktion()
        {
            // Arrange
            List<string> testData = new List<string>();
            testData.Add("XYZ987;25059;75654;4000;20151006213456789");

            // Act
            _uut.convertdata(testData);

            Assert.Multiple((() =>
            {
                Assert.That(_uut.oldAirplanes.Last()._tag, Is.EqualTo("XYZ987"));
                Assert.That(_uut.oldAirplanes.Last()._xCoordiante, Is.EqualTo(25059));
                Assert.That(_uut.oldAirplanes.Last()._yCoordiante, Is.EqualTo(75654));
                Assert.That(_uut.oldAirplanes.Last()._Altitude, Is.EqualTo(4000));
                Assert.That(_uut.oldAirplanes.Last()._Time, Is.EqualTo(new DateTime(2015, 10, 06, 21, 34, 56, 789)));
            }));
        }

        [Test]
        public void Test_Convert_Data_Funktion_Velocity()
        {
            // Arrange
            Airplane airplane = new Airplane();
            airplane._tag = "XYZ987";
            airplane._xCoordiante = 2559;
            airplane._yCoordiante = 7565;
            airplane._Altitude = 4000;
            airplane._Time = DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            _uut.oldAirplanes.Add(airplane);

            // Act
            List<string> testData = new List<string>();
            testData.Add("XYZ987;2600;7600;4000;20151006213459789");
            _uut.convertdata(testData);
            
            // Assert
            _fakevelocity.Received(1);
        }

        [Test]
        public void Test_Convert_Data_Funktion_CompassCourse()
        {
            // Arrange
            Airplane airplane = new Airplane();
            airplane._tag = "XYZ987";
            airplane._xCoordiante = 2559;
            airplane._yCoordiante = 7565;
            airplane._Altitude = 4000;
            airplane._Time = DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            _uut.oldAirplanes.Add(airplane);

            // Act
            List<string> testData = new List<string>();
            testData.Add("XYZ987;2600;7600;4000;20151006213459789");
            _uut.convertdata(testData);

            // Assert
            _fakecompassCourse.Received(1);
        }
    }
}
