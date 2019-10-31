using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;
using ATM.ValidateAirplane;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class AirplaneValidationUnitTest
    {
        private AirplaneValidation _uut;
        private ConvertEventArgs _receivedEventArgs;
        private IConvertFilter _tempRec = Substitute.For<IConvertFilter>();

        [SetUp]
        public void SetUp()
        {
            _receivedEventArgs = null;
            _uut = new AirplaneValidation(_tempRec);

            _uut.ConvertedDataEvent +=
            (o,args) => { _receivedEventArgs = args; };
        }

        [Test]
        public void AirplaneChanged_CurrentAirplaneIsCorrect()
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

            temp.Add(airplane);

            _tempRec.ConvertedDataEvent += Raise.EventWith(this, new ConvertEventArgs(temp));

            Assert.That(_receivedEventArgs.ConvertedData, Is.Not.Null);
        }
    }
}
