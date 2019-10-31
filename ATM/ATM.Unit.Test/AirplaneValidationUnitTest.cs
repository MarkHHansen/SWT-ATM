using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;
using ATM.ValidateAirplane;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestClass]
    class AirplaneValidationUnitTest
    {
        private AirplaneValidation _uut;
        //private ConvertEventArgs _receivedEventArgs;
        private IConvertFilter _tempRec;

        [SetUp]
        public void SetUp()
        {
            //_receivedEventArgs = null;

            _tempRec = Substitute.For<IConvertFilter>();
            _uut = new AirplaneValidation(_tempRec);

            /*_uut.ValidationEvent +=
            (o,args) =>
            {
                _receivedEvent
            }
            ;*/

        }

        [Test]
        public void AirplaneChanged_CurrentAirplaneIsCorrect(List<Airplane> a)
        {
            List<Airplane> temp = new List<Airplane>();

           // temp.Add
        }
    }
}
