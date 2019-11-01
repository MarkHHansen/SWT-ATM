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
using Castle.Core.Logging;

namespace ATM.Unit.Test
{
    [TestFixture]
    class OutputFilterTest
    {
        private OutputFilter _uut;
        private IAirplaneValidation _planeSource;
        private ConsoleLogger _logger;

        #region EventTests

        

        
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
            

            //Test af clear
            

        }
        #endregion

        

        


    }
  
}
