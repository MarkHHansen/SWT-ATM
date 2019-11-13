using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;
using ATM.ValidateAirplane;
using Castle.Core.Internal;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class AirplaneValidationUnitTest
    {
        private AirplaneValidation _uut;
        private ConvertEventArgs _receivedEventArgs;
        private ValidationEventArgs valarg;
        private IConvertFilter _tempRec = Substitute.For<IConvertFilter>();
        private IAirplaneValidation rec = Substitute.For<IAirplaneValidation>();

        #region EventTests

        

       
        [SetUp]
        public void SetUp()
        {
            _receivedEventArgs = null;
            _uut = new AirplaneValidation(_tempRec);

            _uut._receiver.ConvertedDataEvent +=
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

            Assert.NotNull(_receivedEventArgs);
        }

        [Test]
        public void EventUnchanged_DataNull()
        {
            Assert.That(_receivedEventArgs, Is.Null);
        }
        /*
        [Test]
        public void Validation_RaiseEvent()
        {

            _uut = new AirplaneValidation(_tempRec);
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

            rec.ValidationEvent += Raise.EventWith(this, new ValidationEventArgs(temp));

            Assert.NotNull(valarg);
        }*/


        [Test]
        public void AirplaneInAirspaceTrue()
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

            Assert.That(_receivedEventArgs.ConvertedData, Is.EqualTo(temp));
        }
        #endregion


        #region Checkairplanes

        [Test]
        public void NoAirplaneInAirspace()
        {


            List<Airplane> temp = new List<Airplane>();
            Airplane airplane = new Airplane();
            airplane._yCoordiante = 1;
            airplane._xCoordiante = 30000;
            airplane._Altitude = 2000;
            airplane._compasCourse = 60.0;
            airplane._velocity = 1000.0;
            airplane._Time =
                DateTime.ParseExact("20151006123123495", "yyyyMMddhhmmssfff", CultureInfo.InvariantCulture);

            temp.Add(airplane);

            Assert.That(_uut.CheckAirplaneInAirSpace(temp).IsNullOrEmpty());
        }

        [TestCase(5, 30000, 5000)]
        [TestCase(50000, 6, 3500)]
        [TestCase(50000, 50000, 7)]
        public void TwoAirplanesOneValidated_OneUnderLimit(int y, int x, int z)
        {
            Airplane airplane2 = new Airplane();
            airplane2._yCoordiante = 23456;
            airplane2._xCoordiante = 30000;
            airplane2._Altitude = 2000;
            airplane2._compasCourse = 60.0;
            airplane2._velocity = 1000.0;
            airplane2._Time =
                DateTime.ParseExact("20151006123123495", "yyyyMMddhhmmssfff", CultureInfo.InvariantCulture);

            List<Airplane> temp = new List<Airplane>();
            Airplane airplane = new Airplane();
            airplane._yCoordiante = y;
            airplane._xCoordiante = x;
            airplane._Altitude = z;
            airplane._compasCourse = 60.0;
            airplane._velocity = 1000.0;
            airplane._Time =
                DateTime.ParseExact("20151006123123495", "yyyyMMddhhmmssfff", CultureInfo.InvariantCulture);

            temp.Add(airplane);
            temp.Add(airplane2);

            List<Airplane> Result = new List<Airplane>();
            Result.Add(airplane2);

            Assert.That(_uut.CheckAirplaneInAirSpace(temp), Is.EqualTo(Result));
        }

        [TestCase(100000,30000,5000)]
        [TestCase(50000,91000,3500)]
        [TestCase(50000,50000,25000)]
        public void TwoAirplanesOneValidated_OneOverLimit(int y, int x, int z)
        {
            Airplane airplane2 = new Airplane();
            airplane2._yCoordiante = 23456;
            airplane2._xCoordiante = 30000;
            airplane2._Altitude = 2000;
            airplane2._compasCourse = 60.0;
            airplane2._velocity = 1000.0;
            airplane2._Time =
                DateTime.ParseExact("20151006123123495", "yyyyMMddhhmmssfff", CultureInfo.InvariantCulture);

            List<Airplane> temp = new List<Airplane>();
            Airplane airplane = new Airplane();
            airplane._yCoordiante = y;
            airplane._xCoordiante = x;
            airplane._Altitude = z;
            airplane._compasCourse = 60.0;
            airplane._velocity = 1000.0;
            airplane._Time =
                DateTime.ParseExact("20151006123123495", "yyyyMMddhhmmssfff", CultureInfo.InvariantCulture);

            temp.Add(airplane);
            temp.Add(airplane2);

            List<Airplane> Result = new List<Airplane>();
            Result.Add(airplane2);

            Assert.That(_uut.CheckAirplaneInAirSpace(temp), Is.EqualTo(Result));
        }
        #endregion


    }
}
