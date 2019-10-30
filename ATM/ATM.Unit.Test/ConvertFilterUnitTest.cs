using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using ATM;
using TransponderReceiver;

namespace ATM.Unit.Test
{
    [TestClass]
    public class ConvertFilterUnitTest
    {
        private ConvertFilter _uut;
        private DataConvertEventArgs _receivedEventArgs;
        private ITransponderReceiver _fakereceiver;
        private ICompassCourse _fakecompassCourse;
        private IVelocity _fakevelocity;

        [SetUp]
        public void Setup()
        {
            _fakereceiver = Substitute.For<ITransponderReceiver>();
            _fakecompassCourse = Substitute.For<ICompassCourse>();
            _fakevelocity = Substitute.For<IVelocity>();

            _uut = new ConvertFilter(_receiver, _compassCourse, _velocity);
        }


        [TestMethod]
        public void TestEvent()
        {
            // Setup test data
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85890;12000;20151006213456789");
            testData.Add("XYZ987;25059;75654;4000;20151006213456789");

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            // Assert something here or use an NSubstitute Received
            _fakereceiver.Received(1);
        }
    }
}
