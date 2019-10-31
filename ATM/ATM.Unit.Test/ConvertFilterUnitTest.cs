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
    }
}
